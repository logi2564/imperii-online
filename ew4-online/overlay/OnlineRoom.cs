using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Nodes;
using Ew4.Mods;

// One private, two-player room per host process. The engine, not the clients,
// owns random state, turn order and saves. All reads/checks/writes share a gate.
public sealed class OnlineRoom
{
    private static readonly JsonSerializerOptions Json = new(JsonSerializerDefaults.Web) { WriteIndented = true };
    private readonly object gate = new();
    private readonly ModStore store;
    private readonly string folder, configPath, frontend;
    private RoomConfig config;
    private JsonObject? state;
    private JsonArray choices = [];
    private long sequence;
    private string? problem;
    private readonly Dictionary<string, DateTimeOffset> seen = new();

    public sealed record RoomConfig(string HostToken, string GuestToken, string? Scenario = null,
        string? Country = null, string? HostFaction = null, string? GuestFaction = null, bool Started = false);

    public OnlineRoom(ModStore store, string saves, string frontend)
    {
        this.store = store; this.frontend = frontend;
        folder = Path.GetFullPath(saves); Directory.CreateDirectory(folder);
        configPath = Path.Combine(folder, "online-room.json");
        config = File.Exists(configPath) ? JsonSerializer.Deserialize<RoomConfig>(File.ReadAllText(configPath), Json)!
            : new(Convert.ToHexString(RandomNumberGenerator.GetBytes(32)), Convert.ToHexString(RandomNumberGenerator.GetBytes(32)));
        Persist();
        if (config.Scenario != null) choices = Engine("local-players", new { scenario = config.Scenario, country = config.Country }).AsArray();
        if (config.Started)
        {
            try { state = Engine("load", new { slot = 0, mode = 0 }).AsObject(); }
            catch (InvalidOperationException e) { problem = "Не удалось восстановить партию: " + e.Message; }
        }
    }

    private void Persist()
    {
        File.WriteAllText(configPath + ".tmp", JsonSerializer.Serialize(config, Json));
        File.Move(configPath + ".tmp", configPath, true);
    }
    private JsonNode Engine(string route, object args)
    {
        var result = JsonNode.Parse(store.Dispatch("/api/" + route, JsonSerializer.Serialize(args, Json)))!.AsObject();
        if (result["ok"]?.GetValue<bool>() != true)
            throw new InvalidOperationException(result["message"]?.GetValue<string>() ?? result["error"]?.GetValue<string>() ?? "Ошибка игрового движка");
        return result["data"]!;
    }
    private static string Text(JsonNode? node, string key) => node?[key]?.GetValue<string>() ?? "";
    private string? Role(HttpContext context)
    {
        string token = context.Request.Cookies["ew4-online"] ?? "";
        return Same(token, config.HostToken) ? "host" : Same(token, config.GuestToken) ? "guest" : null;
    }
    private static bool Same(string a, string b) => a.Length == b.Length &&
        CryptographicOperations.FixedTimeEquals(System.Text.Encoding.UTF8.GetBytes(a), System.Text.Encoding.UTF8.GetBytes(b));
    private string? Seat(string role) => role == "host" ? config.HostFaction : config.GuestFaction;
    private bool CanAct(string role)
    {
        if (state == null || Text(state, "phase") == "Finished" || Seat(role) is not string seat) return false;
        if (state["dialogue"] != null || state["scenarioPopup"] != null) return Text(state, "playerFaction") == seat;
        return Text(state, "activeFaction") == seat;
    }
    private JsonObject Snapshot(string role)
    {
        var snapshot = Engine("online-state", new { country = Seat(role) }).AsObject();
        snapshot["online"] = JsonSerializer.SerializeToNode(new { role, seat = Seat(role), canAct = CanAct(role), sequence });
        return snapshot;
    }
    private object Status(string? role) => role == null ? new { authenticated = false } : (object)new
    {
        authenticated = true, role, started = state != null, scenario = config.Scenario, country = config.Country,
        hostFaction = config.HostFaction, guestFaction = config.GuestFaction, seat = Seat(role), canAct = CanAct(role),
        choices, sequence, revision = state?["revision"], round = state?["round"],
        activeFaction = state?["activeFaction"], playerFaction = state?["playerFaction"],
        phase = state?["phase"], outcome = state?["outcome"], problem,
        hostOnline = seen.GetValueOrDefault("host") > DateTimeOffset.UtcNow.AddSeconds(-20),
        guestOnline = seen.GetValueOrDefault("guest") > DateTimeOffset.UtcNow.AddSeconds(-20),
        guestToken = role == "host" ? config.GuestToken : null,
        publicUrl = role == "host" && File.Exists(Path.Combine(folder, "public-url.txt"))
            ? File.ReadAllText(Path.Combine(folder, "public-url.txt")).Trim() : null
    };
    private void Saved()
    {
        try { Engine("save", new { slot = 0, mode = 0 }); problem = null; }
        catch (InvalidOperationException e) { problem = "Партия работает, но сохранение не удалось: " + e.Message; }
    }
    private void Refresh() { state = Engine("action", new { op = "state", delta = false }).AsObject(); sequence++; }

    public async Task Handle(HttpContext context, RequestDelegate next)
    {
        string path = context.Request.Path.Value ?? "/";
        if (path == "/health") { await context.Response.WriteAsJsonAsync(new { ok = true, version = "0.1.0" }); return; }
        if (path is "/" or "/room.js" or "/room.css")
        {
            context.Response.ContentType = path == "/" ? "text/html; charset=utf-8" : path.EndsWith(".js") ? "text/javascript; charset=utf-8" : "text/css; charset=utf-8";
            context.Response.Headers.CacheControl = "no-store";
            context.Response.Headers.ContentSecurityPolicy = "default-src 'self'; script-src 'self'; style-src 'self'; img-src 'self' data:; frame-src 'self'; frame-ancestors 'self'";
            context.Response.Headers["Referrer-Policy"] = "no-referrer";
            await context.Response.SendFileAsync(Path.Combine(frontend, path == "/" ? "room.html" : path[1..])); return;
        }
        if (path == "/game") { context.Request.Path = "/"; await next(context); return; }
        if (!path.StartsWith("/online/") && !path.StartsWith("/api/"))
        {
            // Immutable game art may be cached on a slow mobile connection.
            if (path.StartsWith("/content/")) context.Response.OnStarting(() => { context.Response.Headers.CacheControl = "public, max-age=86400"; return Task.CompletedTask; });
            await next(context); return;
        }
        context.Response.Headers.CacheControl = "no-store";
        if (context.Request.Method != "POST" && path != "/online/status") { await Error(context, "Нужен POST-запрос", 405); return; }
        if (context.Request.Headers.Origin.Count > 0 && (!Uri.TryCreate(context.Request.Headers.Origin, UriKind.Absolute, out var origin)
            || !string.Equals(origin.Authority, context.Request.Host.Value, StringComparison.OrdinalIgnoreCase)))
        { await Error(context, "Чужой источник запроса", 403); return; }
        object? response = null; int status = 200;
        try
        {
            string body = context.Request.Query["q"].FirstOrDefault() ?? await new StreamReader(context.Request.Body).ReadToEndAsync();
            if (body.Length > 32768) throw new InvalidOperationException("Слишком большой запрос");
            JsonObject args = string.IsNullOrEmpty(body) ? new() : JsonNode.Parse(body)!.AsObject();
            lock (gate)
            {
                string? role = Role(context);
                if (path == "/online/login")
                {
                    string token = Text(args, "token");
                    role = Same(token, config.HostToken) ? "host" : Same(token, config.GuestToken) ? "guest" : null;
                    if (role == null) { status = 401; response = new { error = "Приглашение не подходит. Попроси новую ссылку." }; }
                    else
                    {
                        context.Response.Cookies.Append("ew4-online", token, new CookieOptions { HttpOnly = true, SameSite = SameSiteMode.Strict,
                            Secure = !context.Request.Host.Host.Equals("localhost") && context.Request.Host.Host != "127.0.0.1",
                            IsEssential = true, Path = "/", MaxAge = TimeSpan.FromDays(30) });
                        seen[role] = DateTimeOffset.UtcNow; response = Status(role);
                    }
                }
                else if (path == "/online/status") { if (role != null) seen[role] = DateTimeOffset.UtcNow; response = Status(role); }
                else if (role == null) { status = 401; response = new { error = "Открой игру по приглашению." }; }
                else
                {
                    seen[role] = DateTimeOffset.UtcNow;
                    switch (path)
                    {
                        case "/online/catalog":
                            if (role != "host") throw new InvalidOperationException("Карту выбирает создатель");
                            response = Engine("catalog", new { }); break;
                        case "/online/countries":
                            if (role != "host") throw new InvalidOperationException("Карту выбирает создатель");
                            response = Engine("countries", new { scenario = Text(args, "scenario") }); break;
                        case "/online/prepare":
                            if (role != "host" || state != null) throw new InvalidOperationException("Сначала заверши текущую партию");
                            string scenario = Text(args, "scenario"), country = Text(args, "country");
                            var scenarios = Engine("catalog", new { })["scenarios"]!.AsArray();
                            if (!scenarios.Any(s => Text(s, "id") == scenario && s!["mode"]!.GetValue<int>() == 2))
                                throw new InvalidOperationException("Выбери карту завоевания");
                            var options = Engine("local-players", new { scenario, country }).AsArray();
                            string hostFaction = Text(options.Single(x => x!["locked"]!.GetValue<bool>()), "id");
                            if (options.Count < 2) throw new InvalidOperationException("На этой карте мало стран");
                            choices = options;
                            config = config with { Scenario = scenario, Country = country, HostFaction = hostFaction, GuestFaction = null, Started = false };
                            Persist(); sequence++; response = Status(role); break;
                        case "/online/choose":
                            string faction = Text(args, "faction");
                            if (role != "guest" || state != null || faction == config.HostFaction || !choices.Any(c => Text(c, "id") == faction))
                                throw new InvalidOperationException("Выбери свободную страну до начала партии");
                            config = config with { GuestFaction = faction }; Persist(); sequence++; response = Status(role); break;
                        case "/online/start":
                            if (role != "host" || state != null || config.GuestFaction == null) throw new InvalidOperationException("Дождись выбора страны другом");
                            state = Engine("start", new { scenario = config.Scenario, country = config.Country,
                                localPlayers = new[] { config.HostFaction, config.GuestFaction } }).AsObject();
                            config = config with { Started = true }; Saved(); Persist(); sequence++; response = Status(role); break;
                        case "/online/reset":
                            if (role != "host" || args["confirm"]?.GetValue<bool>() != true) throw new InvalidOperationException("Новая партия требует подтверждения создателя");
                            if (state != null) { Saved(); Engine("leave", new { revision = state["revision"] }); }
                            state = null; choices = []; config = config with { Started = false, Scenario = null, Country = null, HostFaction = null, GuestFaction = null };
                            Persist(); sequence++; response = Status(role); break;
                        default:
                            if (!path.StartsWith("/api/")) { status = 404; response = new { error = "Неизвестный запрос" }; break; }
                            response = Api(role, path[5..], args); break;
                    }
                }
            }
        }
        catch (Exception e) when (e is InvalidOperationException or JsonException or ArgumentException or IOException)
        { status = 400; response = new { ok = false, code = "online.denied", message = e.Message, error = e.Message }; }
        context.Response.StatusCode = status;
        await context.Response.WriteAsJsonAsync(response);
    }
    private object Api(string role, string route, JsonObject args)
    {
        if (route == "mods" && Text(args, "op") == "") return JsonNode.Parse(store.Status())!;
        if (route == "catalog") return new { ok = true, data = Engine(route, args) };
        if (state == null) throw new InvalidOperationException("Создатель ещё не начал партию");
        if (route == "action" && Text(args, "op") == "state") return new { ok = true, data = Snapshot(role) };
        if (route is "unit-info" or "headquarters") return new { ok = true, data = Engine(route, args) };
        if (route == "save") { if (role != "host") throw new InvalidOperationException("Партия сохраняется автоматически"); Saved(); return new { ok = true, data = new { saved = true } }; }
        if (route is not ("action" or "deployment" or "commander" or "commerce" or "items" or "exchange"))
            throw new InvalidOperationException("Этот режим недоступен в сетевой партии");
        if (!CanAct(role)) throw new InvalidOperationException("Сейчас ход другой страны. Подожди свой ход.");
        if (route == "action" && Text(args, "op") is "ai" or "ai_batch") throw new InvalidOperationException("Ходы компьютера выполняет сервер");
        args["delta"] = false; // Upstream delta history is per process, not per connection.
        JsonNode result = Engine(route, args);
        bool readOnly = route == "deployment" || route == "action" && Text(args, "op") == "select";
        if (!readOnly) { Refresh(); Saved(); }
        if (result is JsonObject obj && obj.ContainsKey("cells") && obj.ContainsKey("factions"))
        {
            var view = Snapshot(role);
            foreach (string key in new[] { "movements", "combat", "notices", "recruited", "suppliedUnit" })
                if (obj.ContainsKey(key)) view[key] = obj[key]?.DeepClone();
            result = view;
        }
        return new { ok = true, data = result };
    }
    public async Task RunAi(CancellationToken stop)
    {
        while (!stop.IsCancellationRequested)
        {
            try
            {
                await Task.Delay(150, stop);
                lock (gate)
                {
                    if (state == null || state["dialogue"] != null || state["scenarioPopup"] != null || Text(state, "phase") == "Finished") continue;
                    string active = Text(state, "activeFaction");
                    if (active == config.HostFaction || active == config.GuestFaction) continue;
                    var batch = Engine("action", new { op = "ai_batch", revision = state["revision"], delta = false });
                    Refresh(); Saved();
                    if (batch["error"] != null) throw new InvalidOperationException(Text(batch["error"], "message"));
                }
            }
            catch (OperationCanceledException) when (stop.IsCancellationRequested) { break; }
            catch (Exception e) when (e is InvalidOperationException or IOException)
            { lock (gate) problem = "Не удалось продолжить ход компьютера: " + e.Message; await Task.Delay(1000, stop); }
        }
    }
    private static async Task Error(HttpContext c, string message, int status)
    { c.Response.StatusCode = status; await c.Response.WriteAsJsonAsync(new { error = message }); }
}
