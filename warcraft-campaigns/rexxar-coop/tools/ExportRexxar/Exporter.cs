using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using War3Net.IO.Mpq;
namespace RexxarExport;
internal sealed record Mission(string Name,int Act);
internal sealed record MissionFile(string Name,int Act,string SourceArchive,string InternalPath,byte[] Data){
    public string Sha256=>Convert.ToHexString(SHA256.HashData(Data)).ToLowerInvariant();
}
internal sealed record ExportReport(List<MissionFile> Files,List<string> Missing,List<string> Archives,List<string> Warnings,List<string> ZipFiles);
internal static class Exporter{
    public static readonly string[] ArchivePriority={"War3Patch.mpq","War3xLocal.mpq","War3x.mpq","War3Local.mpq","War3.mpq"};
    public static readonly Mission[] Missions=BuildMissions();
    private static readonly string[] Prefixes={@"Maps\FrozenThrone\Campaign\",@"Campaign\",@"Maps\Campaign\",""};
    public static ExportReport Export(string game,string output,Action<string>? log=null,long partLimit=24*1024*1024){
        if(Path.GetFullPath(output).Equals(Path.GetFullPath(game),StringComparison.OrdinalIgnoreCase))throw new IOException("Для результата выбери отдельную папку.");
        var found=new Dictionary<string,MissionFile>(StringComparer.OrdinalIgnoreCase);var archives=new List<string>();var warnings=new List<string>();
        foreach(var archiveName in ArchivePriority){
            var path=Path.Combine(game,archiveName);if(!File.Exists(path))continue;
            archives.Add(archiveName);log?.Invoke("Читаю "+archiveName+"...");
            try{
                using var archive=MpqArchive.Open(path);
                foreach(var mission in Missions){
                    if(found.ContainsKey(mission.Name))continue;
                    foreach(var prefix in Prefixes){
                        var name=prefix+mission.Name;
                        try{
                            if(!archive.TryOpenFile(name,MpqLocale.Russian,out var stream)&&!archive.TryOpenFile(name,out stream))continue;
                            using(stream){
                                if(stream.Length<=0||stream.Length>64*1024*1024)throw new InvalidDataException("Недопустимый размер карты");
                                using var memory=new MemoryStream();stream.CopyTo(memory);var data=memory.ToArray();
                                if(!IsCompleteMap(data))throw new InvalidDataException("Запись не является полной картой Warcraft");
                                found.Add(mission.Name,new MissionFile(mission.Name,mission.Act,archiveName,name,data));
                                log?.Invoke("  Найдена "+mission.Name);
                            }
                            break;
                        }catch(Exception e)when(e is IOException or InvalidDataException or NotSupportedException or ArgumentException or MpqParserException or NotImplementedException or InvalidOperationException){
                            warnings.Add(archiveName+" / "+name+": "+e.GetType().Name);log?.Invoke("  Не удалось прочитать "+mission.Name+"; проверю следующий источник.");
                        }
                    }
                }
            }catch(Exception e)when(e is IOException or InvalidDataException or NotSupportedException or ArgumentException or MpqParserException or NotImplementedException or InvalidOperationException){warnings.Add(archiveName+": "+e.GetType().Name);}
        }
        Directory.CreateDirectory(output);
        var files=Missions.Where(m=>found.ContainsKey(m.Name)).Select(m=>found[m.Name]).ToList();var missing=Missions.Where(m=>!found.ContainsKey(m.Name)).Select(m=>m.Name).ToList();var zipFiles=new List<string>();
        foreach(var act in new[]{1,2,3}){
            var part=new List<MissionFile>();long bytes=0;int index=1;
            foreach(var file in files.Where(f=>f.Act==act)){
                if(part.Count>0&&bytes+file.Data.Length>partLimit){WritePart(output,act,index++,part,zipFiles);part.Clear();bytes=0;}
                part.Add(file);bytes+=file.Data.Length;
            }
            if(part.Count>0)WritePart(output,act,index,part,zipFiles);
        }
        var report=new ExportReport(files,missing,archives,warnings,zipFiles);
        using(var stream=File.Create(Path.Combine(output,"Rexxar-source-info.json"))){using var writer=new Utf8JsonWriter(stream,new JsonWriterOptions{Indented=true});WriteReport(writer,report);}
        return report;
    }
    private static Mission[] BuildMissions(){
        var result=new List<Mission>{new("OrcX01.w3x",1)};
        for(int n=2;n<=5;n++)result.Add(new Mission($"OrcX01_{n:D2}.w3x",1));
        result.Add(new Mission("OrcX02.w3x",2));
        for(int n=2;n<=10;n++)result.Add(new Mission($"OrcX02_{n:D2}.w3x",2));
        result.Add(new Mission("OrcX03a.w3x",3));result.Add(new Mission("OrcX03b.w3x",3));return result.ToArray();
    }
    internal static bool IsCompleteMap(byte[] data){
        try{
            using var archive=MpqArchive.Open(new MemoryStream(data,false));
            if(!archive.TryOpenFile("war3map.w3i",out var info))return false;
            using(info){if(info.Length<4)return false;Span<byte> version=stackalloc byte[4];info.ReadExactly(version);int v=BitConverter.ToInt32(version);if(v<18||v>33)return false;}
            return archive.FileExists("war3map.j")||archive.FileExists(@"Scripts\war3map.j");
        }catch(Exception e)when(e is IOException or InvalidDataException or ArgumentException or NotSupportedException or MpqParserException or NotImplementedException or InvalidOperationException){return false;}
    }
    private static void WritePart(string output,int act,int index,List<MissionFile> files,List<string> zipFiles){
        var name=$"Rexxar-act-{act}-part-{index}.zip";
        using(var archive=ZipFile.Open(Path.Combine(output,name),ZipArchiveMode.Create)){
            foreach(var file in files){using var stream=archive.CreateEntry(file.Name,CompressionLevel.NoCompression).Open();stream.Write(file.Data);}
        }
        zipFiles.Add(name);
    }
    private static void WriteReport(Utf8JsonWriter w,ExportReport report){
        w.WriteStartObject();w.WriteString("purpose","Original Rexxar campaign source export for a four-player adaptation");w.WriteNumber("expectedMaps",Missions.Length);w.WriteNumber("foundMaps",report.Files.Count);w.WriteBoolean("complete",report.Missing.Count==0);
        w.WriteStartArray("maps");foreach(var f in report.Files){w.WriteStartObject();w.WriteString("file",f.Name);w.WriteNumber("act",f.Act);w.WriteString("sourceArchive",f.SourceArchive);w.WriteString("internalPath",f.InternalPath);w.WriteNumber("bytes",f.Data.Length);w.WriteString("sha256",f.Sha256);w.WriteEndObject();}w.WriteEndArray();
        foreach(var (name,items)in new[]{("missingMaps",report.Missing),("checkedArchives",report.Archives),("warnings",report.Warnings),("zipFiles",report.ZipFiles)}){w.WriteStartArray(name);foreach(var item in items)w.WriteStringValue(item);w.WriteEndArray();}w.WriteEndObject();
    }
}
