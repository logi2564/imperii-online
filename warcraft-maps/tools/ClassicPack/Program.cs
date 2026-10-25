using War3Net.IO.Mpq;
using War3Net.Build;
using War3Net.Build.Extensions;
using System.Text.Json;
using System.Security.Cryptography;
using var archive=MpqArchive.Open(args[0]);
archive.DiscoverFileNames();
var folder=args[1];Directory.CreateDirectory(folder);
var records=new List<object>();
foreach(var file in archive.GetMpqFiles()){
 var name=$"{file.Name:x16}-{(uint)file.Locale:x8}.bin";
 var path=Path.Combine(folder,name);
 using(var output=File.Create(path)){file.MpqStream.Position=0;file.MpqStream.CopyTo(output);}
 records.Add(new{hash=file.Name.ToString("x16"),locale=(uint)file.Locale,file=name,size=file.MpqStream.Length,sha256=Convert.ToHexString(SHA256.HashData(File.ReadAllBytes(path))).ToLowerInvariant()});
}
File.WriteAllText(Path.Combine(folder,"entries.json"),JsonSerializer.Serialize(records));
var map=Map.Open(archive);
Console.WriteLine(JsonSerializer.Serialize(new{files=records.Count,infoVersion=(int)map.Info!.FormatVersion,editor=(int)map.Info!.EditorVersion,terrainWidth=map.Environment!.Width,terrainHeight=map.Environment!.Height,units=map.Units?.Units.Count,variables=map.Triggers?.Variables.Count,imported=map.ImportedFiles?.Files.Count}));
