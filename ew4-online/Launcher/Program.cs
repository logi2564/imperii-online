using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

Console.OutputEncoding = Encoding.UTF8;
string root = AppContext.BaseDirectory;
bool smoke = args.Contains("--smoke-test");
string folder = smoke ? Path.Combine(Path.GetTempPath(), "BroEW4Smoke-" + Guid.NewGuid().ToString("N"))
    : Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BroEW4Online");
Directory.CreateDirectory(folder);
string saves = Path.Combine(folder, "saves"); Directory.CreateDirectory(saves);
string publicFile = Path.Combine(saves, "public-url.txt");
FileStream hostLock;
try { hostLock = new FileStream(Path.Combine(folder, "host.lock"), FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None); }
catch (IOException) { Console.WriteLine("Игра уже запущена. Вернись в открытое окно или закрой предыдущий запуск."); if (!smoke) Console.ReadLine(); return; }
using var ownedLock = hostLock;
File.Delete(publicFile);
Process? server = null, tunnel = null;
string stage = "files";
var errorFlags = new HashSet<string>();
object logGate = new();
using var log = new StreamWriter(Path.Combine(folder, "last-launch.log"), false, Encoding.UTF8) { AutoFlush = true };
void Log(string? text)
{
    if (text == null) return;
    lock (logGate)
    {
        log.WriteLine(DateTimeOffset.Now.ToString("O") + " " + text);
        foreach (string kind in new[] { "FileNotFoundException", "DirectoryNotFoundException", "InvalidDataException", "InvalidOperationException", "JsonException", "UnauthorizedAccessException", "ArgumentException", "DllNotFoundException" })
            if (text.Contains(kind, StringComparison.Ordinal)) errorFlags.Add(kind);
    }
}
void SafeStatus(Exception? error)
{
    if (!smoke) return;
    lock (logGate)
    {
        // Deliberately no exception message, stack, paths, URLs or log lines.
        File.WriteAllText(Path.Combine(root, "startup-status.json"), JsonSerializer.Serialize(new {
            result = error == null ? "PASS" : "FAIL", stage,
            exceptionType = error?.GetType().Name, hresult = error?.HResult,
            nativeError = error is System.ComponentModel.Win32Exception win ? (int?)win.NativeErrorCode : null,
            serverExited = server?.HasExited, serverExitCode = server?.HasExited == true ? (int?)server.ExitCode : null,
            logExceptionKinds = errorFlags.Order().ToArray(),
            serverFile = File.Exists(Path.Combine(root, "server", "Ew4.Web.exe")),
            dataManifest = File.Exists(Path.Combine(root, "server", "data", "runtime-content.json")),
            webIndex = File.Exists(Path.Combine(root, "server", "wwwroot", "index.html"))
        }, new JsonSerializerOptions { WriteIndented = true }));
    }
}
try
{
    string exe = Path.Combine(root, "server", "Ew4.Web.exe");
    string cloudflared = Path.Combine(root, "cloudflared.exe");
    if (!File.Exists(exe) || !File.Exists(cloudflared))
        throw new IOException("Распакуй весь ZIP в одну папку. Рядом с EXE должны быть папка server и cloudflared.exe.");
    var listener = new TcpListener(IPAddress.Loopback, 0); listener.Start(); int port = ((IPEndPoint)listener.LocalEndpoint).Port; listener.Stop();
    string local = "http://127.0.0.1:" + port;
    Process Start(string file, IEnumerable<string> args, Action<string?> output)
    {
        var start = new ProcessStartInfo(file) { UseShellExecute = false, WorkingDirectory = Path.GetDirectoryName(file)!,
            CreateNoWindow = true, RedirectStandardError = true, RedirectStandardOutput = true };
        foreach (var arg in args) start.ArgumentList.Add(arg);
        var process = new Process { StartInfo = start };
        process.OutputDataReceived += (_, e) => output(e.Data); process.ErrorDataReceived += (_, e) => output(e.Data);
        process.Start(); process.BeginOutputReadLine(); process.BeginErrorReadLine(); return process;
    }
    Console.WriteLine("European War 4 — сетевая версия для друзей\n\nЗапускаем игру…");
    stage = "server-start";
    server = Start(exe, ["--urls", local, "--contentRoot", Path.Combine(root, "server"), "--save-root", saves], Log);
    using var client = new HttpClient { Timeout = TimeSpan.FromSeconds(2) };
    bool ready = false; stage = "server-ready";
    for (int i = 0; i < 120; i++)
    {
        if (server.HasExited) throw new IOException("Игра закрылась при запуске. Подробности: " + Path.Combine(folder, "last-launch.log"));
        try { using var response = await client.GetAsync(local + "/health"); ready = response.IsSuccessStatusCode; } catch (HttpRequestException) { } catch (TaskCanceledException) { }
        if (ready && File.Exists(Path.Combine(saves, "online-room.json"))) break;
        await Task.Delay(500);
    }
    if (!ready) throw new IOException("Не удалось дождаться запуска игрового сервера.");
    stage = "room-config";
    using var config = JsonDocument.Parse(File.ReadAllText(Path.Combine(saves, "online-room.json")));
    string token = config.RootElement.GetProperty("hostToken").GetString()!;
    string hostUrl = local + "/#host=" + token;
    File.WriteAllText(Path.Combine(folder, "Открыть игру.url"), "[InternetShortcut]\r\nURL=" + hostUrl + "\r\n");
    stage = "browser";
    if (!smoke) Process.Start(new ProcessStartInfo(hostUrl) { UseShellExecute = true });
    var linkReady = new TaskCompletionSource<string>(TaskCreationOptions.RunContinuationsAsynchronously);
    stage = "tunnel-start";
    tunnel = Start(cloudflared, ["tunnel", "--no-autoupdate", "--protocol", "http2", "--url", local], line =>
    {
        Log(line);
        var match = Regex.Match(line ?? "", @"https://[a-z0-9-]+\.trycloudflare\.com");
        if (match.Success)
        {
            try { File.WriteAllText(publicFile, match.Value); linkReady.TrySetResult(match.Value); }
            catch (IOException e) { Log(e.Message); }
        }
    });
    Console.WriteLine("Игра открыта в браузере. Выбери карту и страну.\nГотовим приглашение через интернет…");
    stage = "tunnel-connect";
    bool publicReady = await Task.WhenAny(linkReady.Task, Task.Delay(45000)) == linkReady.Task;
    if (publicReady)
        Console.WriteLine("Приглашение готово: скопируй его на странице игры и отправь другу.\nДруг открывает ссылку в Chrome на Android.\n");
    else Console.WriteLine("Пока не удалось получить ссылку. Проверь интернет.\nЕсли ссылка не появится на странице, перезапусти игру.\n");
    if (smoke)
    {
        if (!publicReady) throw new IOException("Не получена публичная ссылка Cloudflare");
        stage = "internet-auth";
        using var publicClient = new HttpClient { Timeout = TimeSpan.FromSeconds(15) };
        bool verified = false;
        for (int i = 0; i < 20 && !verified; i++)
        {
            try
            {
                string url = await linkReady.Task;
                using var body = new StringContent(JsonSerializer.Serialize(new { token = config.RootElement.GetProperty("guestToken").GetString() }), Encoding.UTF8, "application/json");
                using var login = await publicClient.PostAsync(url + "/online/login", body);
                using var result = JsonDocument.Parse(await login.Content.ReadAsStringAsync());
                if (login.IsSuccessStatusCode && result.RootElement.GetProperty("role").GetString() == "guest")
                {
                    using var status = JsonDocument.Parse(await publicClient.GetStringAsync(url + "/online/status"));
                    verified = status.RootElement.GetProperty("authenticated").GetBoolean();
                }
            }
            catch (Exception e) when (e is HttpRequestException or JsonException or TaskCanceledException) { Log(e.Message); }
            if (!verified) await Task.Delay(2000);
        }
        if (!verified) throw new IOException("Публичная ссылка не прошла проверку входа с сохранением сессии");
        stage = "internet-game";
        await SmokeTest.Game(local, await linkReady.Task, config.RootElement);
        stage = "complete"; SafeStatus(null);
        Console.WriteLine("PASS: packaged Windows EXE started its server; public HTTPS invitation and guest session verified.");
    }
    else
    {
        Console.WriteLine("Оставь это окно открытым во время партии.\nСохранения: " + saves + "\nДля завершения нажми Enter.");
        var stop = new TaskCompletionSource();
        Console.CancelKeyPress += (_, e) => { e.Cancel = true; stop.TrySetResult(); };
        await Task.WhenAny(Task.Run(Console.ReadLine), stop.Task);
    }
}
catch (Exception e)
{
    Environment.ExitCode = 1; SafeStatus(e);
    Log(e.ToString()); Console.WriteLine("\nНе удалось запустить игру: " + e.Message + "\n\nЖурнал: " + Path.Combine(folder, "last-launch.log")); if (!smoke) Console.ReadLine();
}
finally
{
    foreach (var process in new[] { tunnel, server }) if (process != null)
    {
        try { if (!process.HasExited) { process.Kill(true); process.WaitForExit(5000); } } catch (InvalidOperationException) { }
        process.Dispose();
    }
    File.Delete(publicFile);
}
