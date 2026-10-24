using System.Text.Json;

namespace Ew4.Client;

public sealed partial class ClientGame
{
    // A view only: the shared authoritative session keeps its real active player.
    private object NetworkView(ClientCommand command)
    {
        var original = Require();
        if (!original.Session.World.Factions.Any(f => f.Human && f.Id == command.Country))
            throw new Ew4.Core.RuleViolation("online.seat", "Unknown player seat");
        try
        {
            game = original with { Session = original.Session with { PlayerFaction = command.Country! } };
            return JsonSerializer.SerializeToElement(View(), Json);
        }
        finally { game = original; }
    }
}
