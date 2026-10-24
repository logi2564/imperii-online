using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Nodes;

public static class SmokeTest
{
    public static async Task Game(string local, string remote, JsonElement config)
    {
        using var host = new HttpClient { BaseAddress = new Uri(local), Timeout = TimeSpan.FromSeconds(90) };
        using var guest = new HttpClient { BaseAddress = new Uri(remote), Timeout = TimeSpan.FromSeconds(90) };
        guest.DefaultRequestHeaders.Add("Origin", remote);
        static async Task<JsonNode> Post(HttpClient client, string path, object body)
        {
            using var response = await client.PostAsJsonAsync(path, body);
            string text = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode) throw new IOException("Packaged game request failed: " + path + " " + response.StatusCode);
            return JsonNode.Parse(text)!;
        }
        await Post(host, "/online/login", new { token = config.GetProperty("hostToken").GetString() });
        await Post(guest, "/online/login", new { token = config.GetProperty("guestToken").GetString() });
        var maps = await Post(host, "/online/catalog", new { });
        if (!maps["scenarios"]!.AsArray().Any(m => m!["id"]!.GetValue<string>() == "conquest1")) throw new IOException("Missing conquest maps");
        var countries = await Post(host, "/online/countries", new { scenario = "conquest1" });
        var room = await Post(host, "/online/prepare", new { scenario = "conquest1", country = countries[0]!["id"]!.GetValue<string>() });
        string own = room["hostFaction"]!.GetValue<string>();
        string other = room["choices"]!.AsArray().First(c => c!["id"]!.GetValue<string>() != own)!["id"]!.GetValue<string>();
        await Post(guest, "/online/choose", new { faction = other });
        await Post(host, "/online/start", new { });
        var state = (await Post(guest, "/api/action", new { op = "state" }))["data"]!;
        if (state["playerFaction"]!.GetValue<string>() != other || state["units"]!.AsArray().Count < 100)
            throw new IOException("Guest did not receive its own country on the real map");
        Console.WriteLine("PASS: packaged engine loaded European 1798; an authenticated guest received its own country and the live battlefield.");
    }
}
