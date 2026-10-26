using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
namespace RexxarSlots;
internal static class ScriptPatch{
    public const string Marker="// REXXAR_FOUR_LOBBY_SLOTS_V1";
    private static readonly Regex Functions=new(@"(?m)^\s*function\s+(\w+)\s+takes[^\r\n]*[\r\n]+[\s\S]*?^\s*endfunction\b",RegexOptions.CultureInvariant);
    public static HashSet<int> ReferencedPlayers(string script){
        string masked=Mask(script);
        // Configuration describes lobby positions, not gameplay ownership.
        var configuration=new HashSet<string>{"config","InitCustomPlayerSlots","InitCustomTeams","InitAllyPriorities"};
        var chars=masked.ToCharArray();foreach(Match m in Functions.Matches(masked))if(configuration.Contains(m.Groups[1].Value))Array.Fill(chars,' ',m.Index,m.Length);
        return Regex.Matches(new string(chars),@"\bPlayer\s*\(\s*(\d+)\s*\)").Select(m=>int.Parse(m.Groups[1].Value,CultureInfo.InvariantCulture)).ToHashSet();
    }
    public static byte[] Patch(byte[] bytes,ClassicInfo info,int[] ids){
        // Latin-1 maps every byte to one char; non-ASCII text round-trips exactly.
        string script=Encoding.Latin1.GetString(bytes);if(script.Contains(Marker,StringComparison.Ordinal))throw new InvalidDataException("Карта уже обработана.");
        var matches=Functions.Matches(Mask(script)).Where(m=>m.Groups[1].Value=="config").ToArray();
        if(matches.Length!=1)throw new InvalidDataException("Не найдена единственная стандартная функция config.");
        var config=matches[0];string body=Mask(script).Substring(config.Index,config.Length);
        if(Regex.IsMatch(body,@"\breturn\b"))throw new InvalidDataException("Нестандартный досрочный выход из config; карта не изменена.");
        int end=config.Index+body.LastIndexOf("endfunction",StringComparison.Ordinal);var s=new StringBuilder("\n    "+Marker+"\n");
        s.AppendLine($"    call SetPlayers({info.Players.Count})");
        foreach(int id in ids){int pos=info.Players.FindIndex(p=>p.Id==id);var p=info.Players[pos];
            s.AppendLine($"    call DefineStartLocation({pos}, {Real(p.X)}, {Real(p.Y)})");
            s.AppendLine($"    call SetPlayerStartLocation(Player({id}), {pos})");
            s.AppendLine($"    call ForcePlayerStartLocation(Player({id}), {pos})");
            s.AppendLine($"    call SetPlayerController(Player({id}), MAP_CONTROL_USER)");
            s.AppendLine($"    call SetPlayerSlotAvailable(Player({id}), MAP_CONTROL_USER)");
            if(id!=ids[0]){
                string race=p.Race switch{1=>"RACE_PREF_HUMAN",2=>"RACE_PREF_ORC",3=>"RACE_PREF_UNDEAD",4=>"RACE_PREF_NIGHTELF",_=>"RACE_PREF_ORC"};
                s.AppendLine($"    call SetPlayerRacePreference(Player({id}), {race})");
                s.AppendLine($"    call SetPlayerRaceSelectable(Player({id}), false)");
                s.AppendLine($"    call SetPlayerTeam(Player({id}), GetPlayerTeam(Player({ids[0]})))");
            }
        }
        foreach(int a in ids)foreach(int b in ids)if(a!=b){s.AppendLine($"    call SetPlayerAlliance(Player({a}), Player({b}), ALLIANCE_PASSIVE, true)");s.AppendLine($"    call SetPlayerAlliance(Player({a}), Player({b}), ALLIANCE_SHARED_VISION, true)");}
        return Encoding.Latin1.GetBytes(script.Insert(end,s.ToString()));
    }
    // Ignore quoted text, rawcodes and // comments while retaining exact offsets.
    internal static string Mask(string text){var b=text.ToCharArray();for(int i=0;i<b.Length;i++){
        if(b[i]=='/'&&i+1<b.Length&&b[i+1]=='/'){while(i<b.Length&&b[i]!='\n')b[i++]=' ';i--;}
        else if(b[i]=='"'||b[i]=='\''){char quote=b[i];b[i]=' ';for(i++;i<b.Length;i++){char c=b[i];if(c!='\n'&&c!='\r')b[i]=' ';if(c=='\\'&&i+1<b.Length){b[++i]=' ';continue;}if(c==quote)break;}}
    }return new string(b);}
    private static string Real(float n){if(!float.IsFinite(n))throw new InvalidDataException("Неверная стартовая координата.");string v=n.ToString("0.########",CultureInfo.InvariantCulture);return v.Contains('.')?v:v+".0";}
}
