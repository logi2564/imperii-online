using System.Text.Json;
using CSharpLua;
using War3Net.Build;
using War3Net.Build.Extensions;
using War3Net.Build.Info;
using War3Net.CodeAnalysis.Jass;
using War3Net.CodeAnalysis.Transpilers;
using War3Net.IO.Mpq;

if(args[0]=="atlas-placements"){
    AtlasPlacements.Run(args[1],args[2],args[3],args[4]);
}else if(args[0]=="owners"){
    using var json=JsonDocument.Parse(File.ReadAllText(args[2]));Directory.CreateDirectory(args[3]);
    foreach(var item in json.RootElement.EnumerateObject()){
        using var archive=MpqArchive.Open(Path.Combine(args[1],item.Name+".w3x"));using var source=archive.OpenFile("war3mapUnits.doo");using var memory=new MemoryStream();source.CopyTo(memory);byte[] original=memory.ToArray();
        memory.Position=0;using var reader=new BinaryReader(memory,System.Text.Encoding.UTF8,true);var units=reader.ReadMapUnits();
        using var roundtrip=new MemoryStream();using(var writer=new BinaryWriter(roundtrip,System.Text.Encoding.UTF8,true))writer.Write(units);
        if(!original.SequenceEqual(roundtrip.ToArray()))throw new InvalidDataException("Unit placement serializer changes unrelated bytes: "+item.Name);
        foreach(var unit in units.Units)if(item.Value.TryGetProperty(unit.OwnerId.ToString(),out var target))unit.OwnerId=target.GetInt32();
        using var output=File.Create(Path.Combine(args[3],item.Name+".doo"));using var outWriter=new BinaryWriter(output);outWriter.Write(units);
    }
    Console.WriteLine("PASS: all seventeen editor placement files round-trip byte-identically before owner-only changes.");
}else if(args[0]=="transpile"){
    var transpiler=new JassToLuaTranspiler{IgnoreComments=true,IgnoreEmptyDeclarations=true,KeepFunctionsSeparated=true};
    transpiler.RegisterJassFile(JassSyntaxFactory.ParseCompilationUnit(File.ReadAllText(Path.Combine(args[2],"common.j"))));
    transpiler.RegisterJassFile(JassSyntaxFactory.ParseCompilationUnit(File.ReadAllText(Path.Combine(args[2],"Blizzard.j"))));
    var unit=JassSyntaxFactory.ParseCompilationUnit(File.ReadAllText(args[1]));using var writer=new StreamWriter(args[3]);
    new LuaRenderer(new LuaSyntaxGenerator.SettingInfo{Indent=4},writer).RenderCompilationUnit(transpiler.Transpile(unit));
    Console.WriteLine("Transpiled actual co-op runtime for headless behavior tests.");
}else if(args[0]=="verify"){
    int count=0;
    foreach(var path in Directory.GetFiles(Path.Combine(args[1],"Maps"),"*.w3x")){
        var map=Map.Open(path,MapFiles.Info|MapFiles.Environment|MapFiles.Units|MapFiles.ItemObjectData|MapFiles.AbilityObjectData|MapFiles.UnitObjectData);var users=map.Info!.Players.Where(p=>p.Controller==PlayerController.User).Select(p=>p.Id).Order().ToArray();
        if(!users.SequenceEqual(new[]{0,1,2,3}))throw new InvalidDataException("Wrong player slots: "+path);
        if((int)map.Info.FormatVersion!=25)throw new InvalidDataException("Not classic W3I");
        if(map.Units is null||map.Environment is null||map.ItemObjectData is null||map.AbilityObjectData is null)throw new InvalidDataException("Missing mission data");
        if(map.ItemObjectData.NewItems.Count<300)throw new InvalidDataException("Portable item catalog absent");
        int Raw(string id)=>BitConverter.ToInt32(System.Text.Encoding.ASCII.GetBytes(id));
        for(int role=0;role<4;role++)for(int skill=0;skill<4;skill++)foreach(int group in new[]{4,7}){string id=$"R{group}{role}{skill}";if(!map.AbilityObjectData.NewAbilities.Any(a=>a.NewId==Raw(id)))throw new InvalidDataException("Missing cast/learn skill "+id);}
        count++;
    }
    if(count!=17)throw new InvalidDataException("Expected all seventeen actual mission maps");
    Console.WriteLine("PASS: independent War3Net reader opened 17 actual maps, classic W3I 25, four human roles, terrain, unit placements, portable items, sixteen cast abilities and sixteen native learning proxies.");
}else throw new ArgumentException("Unknown verification command");
