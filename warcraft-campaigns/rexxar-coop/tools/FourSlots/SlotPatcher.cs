using System.Text;
using War3Net.IO.Mpq;
namespace RexxarSlots;
internal sealed record PatchedMap(byte[] Data,int[] Players);
internal static class SlotPatcher{
    public static PatchedMap Patch(byte[] data){
        using var original=MpqArchive.Open(new MemoryStream(data,false));
        byte[] infoBytes=Read(original,"war3map.w3i");
        string scriptName=original.FileExists("war3map.j")?"war3map.j":@"Scripts\war3map.j";
        byte[] script=Read(original,scriptName);
        var info=ClassicInfo.Read(infoBytes);int[] ids=info.AddFourSlots(Encoding.Latin1.GetString(script));
        byte[] newInfo=info.Write(),newScript=ScriptPatch.Patch(script,info,ids);
        var replacements=new Dictionary<string,byte[]>{{"war3map.w3i",newInfo},{scriptName,newScript}};
        byte[] result=ClassicMpqPatch.Replace(data,replacements,4);
        using var verify=MpqArchive.Open(new MemoryStream(result,false));
        var reread=ClassicInfo.Read(Read(verify,"war3map.w3i"));
        if(reread.Players.Count(p=>p.Controller==1)!=4||!Read(verify,scriptName).SequenceEqual(newScript))throw new InvalidDataException("Проверка четырёх позиций не пройдена.");
        // Verify every untouched block through the independent MPQ reader. No
        // listfile is needed; encrypted unknown blocks remain at original offsets.
        var changed=replacements.Keys.Select(MpqHash.GetHashedFileName).ToHashSet();
        var metadata=new[]{"(attributes)","(signature)"}.Select(MpqHash.GetHashedFileName).ToHashSet();
        foreach(var hash in original.EnumerateHashes()){
            if(changed.Contains(hash.Name)||metadata.Contains(hash.Name))continue;
            var oldEntry=original[(int)hash.BlockIndex];var nextEntry=verify[(int)hash.BlockIndex];
            if(oldEntry.Flags!=nextEntry.Flags||oldEntry.FileSize!=nextEntry.FileSize||oldEntry.FileOffset!=nextEntry.FileOffset)throw new InvalidDataException("Изменился посторонний блок MPQ.");
        }
        return new(result,ids);
    }
    internal static byte[] Read(MpqArchive archive,string name){using var s=archive.OpenFile(name);using var m=new MemoryStream();s.CopyTo(m);return m.ToArray();}
}
