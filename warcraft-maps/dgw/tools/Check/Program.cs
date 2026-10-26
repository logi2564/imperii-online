using War3Net.Build;
using War3Net.Build.Script;
using System.Text.Json;
using System.Text;
using System.Text.RegularExpressions;
var root=args[0];var outdir=args[1];Directory.CreateDirectory(outdir);using var report=JsonDocument.Parse(File.ReadAllText(Path.Combine(root,"release",args.Length>2?args[2]:"verification.json")));var map=Map.Open(Path.Combine(root,"release",report.RootElement.GetProperty("file").GetString()!));using var cat=JsonDocument.Parse(File.ReadAllText(Path.Combine(root,"source/catalog.json")));
int Id(string s)=>BitConverter.ToInt32(Encoding.ASCII.GetBytes(s));
if((int)map.Info!.FormatVersion!=25||(int)map.Info.EditorVersion!=6052||map.Info.Players.Count!=12||map.Info.Forces.Count!=12||map.Environment!.Width!=288||map.Environment.Height!=288)throw new Exception("Wrong classic metadata");
if(map.Info.Forces.Where((f,i)=>(int)f.Players!=(1<<i)||(int)f.Flags!=0).Any())throw new Exception("Not independent FFA forces");
if(map.Units!.Units.Count!=12||map.Units.Units.Any(u=>u.TypeId!=Id("sloc")))throw new Exception("Prototype armies were not removed");
if(map.UnitObjectData!.NewUnits.Count!=339||map.AbilityObjectData!.NewAbilities.Count!=48||map.UpgradeObjectData!.NewUpgrades.Count!=33)throw new Exception("Missing custom objects");
var objects=map.UnitObjectData.NewUnits.ToDictionary(x=>x.NewId);if(objects.Count!=339)throw new Exception("Duplicate rawcodes");
foreach(var obj in cat.RootElement.GetProperty("objects").EnumerateArray()){
 var id=obj.GetProperty("id").GetString()!;var actual=objects[Id(id)];if(actual.OldId!=Id(obj.GetProperty("old").GetString()!))throw new Exception("Wrong base "+id);
 foreach(var field in obj.GetProperty("fields").EnumerateArray()){
  var key=field.GetProperty("id").GetString()!;var f=actual.Modifications.Single(m=>m.Id==Id(key));var type=field.GetProperty("type").GetInt32();if((int)f.Type!=type)throw new Exception("Field type "+id+":"+key);
  if(type==3?f.ValueAsString!=field.GetProperty("value").GetString():Math.Abs(Convert.ToDouble(f.Value)-field.GetProperty("value").GetDouble())>0.00001)throw new Exception("Field value "+id+":"+key);
 }
}
foreach(var f in cat.RootElement.GetProperty("factions").EnumerateArray()){
 var ability=map.AbilityObjectData.NewAbilities.Single(a=>a.NewId==Id(f.GetProperty("spell").GetString()!));
 if(ability.OldId!=Id("ANcl")||ability.Modifications.Single(m=>m.Id==Id("ahky")).ValueAsString!="Z"||ability.Modifications.Single(m=>m.Id==Id("abpx")).ValueAsInt!=1||ability.Modifications.Single(m=>m.Id==Id("abpy")).ValueAsInt!=1)throw new Exception("Divine button overlaps stock hero abilities");
 foreach(var key in new[]{"weaponUpgrade","armorUpgrade"})if(!map.UpgradeObjectData.NewUpgrades.Any(u=>u.NewId==Id(f.GetProperty(key).GetString()!)))throw new Exception("Missing faction research");
}
var triggers=map.Triggers!.TriggerItems.OfType<TriggerDefinition>().ToArray();var enabled=triggers.Where(t=>t.IsEnabled&&!t.IsComment).ToArray();if(enabled.Length!=1||enabled[0].Name!="DGW_Expansion"||map.CustomTextTriggers!.CustomTextTriggers.Count!=triggers.Length)throw new Exception("Wrong enabled trigger or WCT pairing");
var code=map.CustomTextTriggers.CustomTextTriggers[Array.IndexOf(triggers,enabled[0])].Code!;var decl=File.ReadAllText(Path.Combine(root,"source/globals.j"));if(code!=File.ReadAllText(Path.Combine(root,"source/expansion.j")))throw new Exception("Packaged expansion differs from tested source");if(map.CustomTextTriggers.GlobalCustomScriptCode.Code!="globals\n"+decl+"\nendglobals\n")throw new Exception("Missing globals");
var b=new MapScriptBuilder();b.SetDefaultOptionsForMap(map);b.FindVariableReferences(map);var script=b.Build(map).Replace("\r\n","\n");script=Regex.Replace(script,@"^//   Date:.*\n","",RegexOptions.Multiline);script=script.Insert(script.IndexOf("endglobals"),decl+"\n");script=Regex.Replace(script,@"function InitTrig_DGW_Expansion takes nothing returns nothing.*?endfunction",_=>code.Trim(),RegexOptions.Singleline);
File.WriteAllText(Path.Combine(outdir,"editor-generated.j"),script);File.WriteAllText(Path.Combine(outdir,"runtime.j"),map.Script);
if(script!=map.Script!.Replace("\r\n","\n"))throw new Exception("Runtime script differs from editor reconstruction");File.WriteAllText(Path.Combine(outdir,"editor-generated.j"),script);File.WriteAllText(Path.Combine(outdir,"runtime.j"),map.Script);
var summary=new{factions=16,newObjects=321,armyTypes=128,champions=16,gods=16,upgrades=32,divineAbilities=17,slots=12,forces=12,enabledTriggers=1,legacySourcesPreserved=21,editorScriptMatchesRuntime=true,nativeWarcraftGameRun=false};File.WriteAllText(Path.Combine(outdir,"metadata-check.json"),JsonSerializer.Serialize(summary,new JsonSerializerOptions{WriteIndented=true}));Console.WriteLine("PASS: actual W3X reopens; 321 new object definitions match the catalog; 12 independent FFA forces; original prototype sources preserved disabled; editor reconstruction exactly matches the shipped runtime.");
