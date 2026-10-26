using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using War3Net.IO.Mpq;
namespace RexxarExport;
internal static class SelfTests{
    public static void Run(){
        var root=Path.Combine(Path.GetTempPath(),"RexxarExport-tests-"+Guid.NewGuid().ToString("N"));Directory.CreateDirectory(root);
        try{
            var game=Path.Combine(root,"game");Directory.CreateDirectory(game);
            var originals=Exporter.Missions.ToDictionary(m=>m.Name,m=>MapBytes("base:"+m.Name));
            WriteArchive(Path.Combine(game,"War3x.mpq"),Exporter.Missions.Select(m=>(@"Maps\FrozenThrone\Campaign\"+m.Name,originals[m.Name],MpqLocale.Neutral)));
            var patched=MapBytes("patched");var russian=MapBytes("russian");var english=MapBytes("english");
            WriteArchive(Path.Combine(game,"War3Patch.mpq"),new[]{(@"Maps\FrozenThrone\Campaign\OrcX02.w3x",patched,MpqLocale.Neutral),(@"Maps\FrozenThrone\Campaign\OrcX03a.w3x",Encoding.ASCII.GetBytes("corrupt partial map"),MpqLocale.Neutral)});
            WriteArchive(Path.Combine(game,"War3xLocal.mpq"),new[]{(@"Maps\FrozenThrone\Campaign\OrcX01.w3x",russian,MpqLocale.Russian),(@"Maps\FrozenThrone\Campaign\OrcX01.w3x",english,MpqLocale.English)});
            File.WriteAllText(Path.Combine(game,"private-unrelated.txt"),"DO-NOT-EXPORT-PRIVATE-CONTENT");
            var before=Directory.GetFiles(game).ToDictionary(p=>p,p=>Hash(File.ReadAllBytes(p)));
            var output=Path.Combine(root,"export");var report=Exporter.Export(game,output,partLimit:2000);
            Require(report.Files.Count==17&&report.Missing.Count==0,"all seventeen missions exported");
            Require(report.Files.Single(f=>f.Name=="OrcX02.w3x").Data.SequenceEqual(patched),"patch archive takes precedence");
            Require(report.Files.Single(f=>f.Name=="OrcX01.w3x").Data.SequenceEqual(russian),"Russian localized mission preferred");
            Require(report.Files.Single(f=>f.Name=="OrcX03a.w3x").Data.SequenceEqual(originals["OrcX03a.w3x"]),"corrupt patch mission falls back to complete base");
            var seen=new Dictionary<string,string>();
            foreach(var zip in report.ZipFiles){
                using var archive=ZipFile.OpenRead(Path.Combine(output,zip));
                foreach(var entry in archive.Entries){
                    Require(Exporter.Missions.Any(m=>m.Name==entry.FullName),"only known mission filenames are exported");
                    using var stream=entry.Open();using var memory=new MemoryStream();stream.CopyTo(memory);seen.Add(entry.FullName,Hash(memory.ToArray()));
                }
            }
            Require(seen.Count==17&&report.Files.All(f=>seen[f.Name]==f.Sha256),"ZIP files preserve each mission byte-for-byte");
            Require(report.ZipFiles.Count>3,"ZIP size splitting is exercised");
            Require(before.All(e=>Hash(File.ReadAllBytes(e.Key))==e.Value),"all source archives and unrelated files remain unchanged");
            var json=File.ReadAllText(Path.Combine(output,"Rexxar-source-info.json"));using var parsed=JsonDocument.Parse(json);
            Require(parsed.RootElement.GetProperty("complete").GetBoolean(),"completion report is correct");
            Require(!json.Contains(root)&&!json.Contains("DO-NOT-EXPORT"),"report excludes private paths and unrelated content");
            var empty=Path.Combine(root,"empty-game");Directory.CreateDirectory(empty);var missing=Exporter.Export(empty,Path.Combine(root,"empty-result"));
            Require(missing.Files.Count==0&&missing.Missing.Count==17&&missing.ZipFiles.Count==0,"missing campaigns are reported without empty successful exports");
            var incomplete=Path.Combine(root,"incomplete-game");Directory.CreateDirectory(incomplete);WriteArchive(Path.Combine(incomplete,"War3x.mpq"),new[]{(@"Maps\FrozenThrone\Campaign\OrcX01.w3x",originals["OrcX01.w3x"],MpqLocale.Neutral)});
            var partial=Exporter.Export(incomplete,Path.Combine(root,"partial-result"));Require(partial.Files.Count==1&&partial.Missing.Count==16,"partial campaign is not reported as complete");
            Console.WriteLine("PASS: 12 source-export checks; all 17 mission names, archive precedence, Russian locale, corrupt-patch fallback, ZIP byte identity/splitting, read-only sources, private-data exclusion and missing/partial source reports.");
        }finally{Directory.Delete(root,true);}
    }
    private static byte[] MapBytes(string marker){
        var b=new MpqArchiveBuilder();b.AddFile(MpqFile.New(new MemoryStream(BitConverter.GetBytes(25)),"war3map.w3i"));b.AddFile(MpqFile.New(new MemoryStream(Encoding.UTF8.GetBytes("function main takes nothing returns nothing\n// "+marker+"\nendfunction")),"war3map.j"));using var stream=new MemoryStream();b.SaveTo(stream,true);return stream.ToArray();
    }
    private static void WriteArchive(string path,IEnumerable<(string Name,byte[] Data,MpqLocale Locale)> files){
        var b=new MpqArchiveBuilder();foreach(var f in files)b.AddFile(MpqFile.New(new MemoryStream(f.Data),f.Name,f.Locale));b.SaveTo(path);
    }
    private static void Require(bool condition,string message){if(!condition)throw new InvalidOperationException("Self-test failed: "+message);}
    private static string Hash(byte[] b)=>Convert.ToHexString(SHA256.HashData(b)).ToLowerInvariant();
}
