using War3Net.Build;
using War3Net.Build.Script;
using System.Text.RegularExpressions;
using System.Text.Json;
var map=Map.Open(args[0]);
var root=Directory.GetParent(Path.GetDirectoryName(Path.GetFullPath(args[0]))!)!.FullName;
using var indexJson=JsonDocument.Parse(File.ReadAllText(Path.Combine(root,"source","trigger-index.json")));
var index=indexJson.RootElement;
var originals=index.GetProperty("entries").EnumerateArray().ToArray();
if((int)map.Info!.FormatVersion!=25||(int)map.Info.EditorVersion!=6052)throw new Exception("Not a classic map info file");
if(map.Info.Players.Count!=12||!map.Info.Players.Select(p=>p.Id).Order().SequenceEqual(Enumerable.Range(0,12)))throw new Exception("Missing player slots");
if(map.Environment!.Width!=480||map.Environment.Height!=480||map.Info.PlayableMapAreaWidth!=436||map.Info.PlayableMapAreaHeight!=464)throw new Exception("Terrain/info dimensions differ");
if(map.Units!.Units.Count!=833||map.Regions!.Regions.Count!=64||map.Sounds!.Sounds.Count!=25)throw new Exception("Lost placements or sound/music entries");
if(map.Triggers!.Variables.Count!=479||map.CustomTextTriggers!.CustomTextTriggers.Count!=265)throw new Exception("Missing editable triggers");
if(map.ImportedFiles!.Files.Count!=569)throw new Exception("Missing imports");
var triggers=map.Triggers.TriggerItems.OfType<TriggerDefinition>().ToArray();
var expectedNames=new[]{"R23_Begin"}.Concat(originals.Select(e=>e.GetProperty("name").GetString()!)).Concat(new[]{"R23_End","EditorReferences"});
if(originals.Length!=262||triggers.Length!=265||!triggers.Select(t=>t.Name).SequenceEqual(expectedNames))throw new Exception("Original trigger names/order changed");
int gui=0,jass=0;
for(int i=0;i<262;i++){
 var t=triggers[i+1];var e=originals[i];var code=map.CustomTextTriggers.CustomTextTriggers[i+1].Code??"";
 if(!t.IsEnabled)throw new Exception("Disabled entry: "+t.Name);
 if(e.GetProperty("kind").GetString()=="GUI"){
  if(t.IsCustomTextTrigger||!string.IsNullOrEmpty(code)||t.Functions.Count==0)throw new Exception("GUI entry is empty: "+t.Name);gui++;
 }else{
  if(!t.IsCustomTextTrigger||!code.Contains("function R23_InitTrig_"+t.Name+" takes")||!code.Contains("function InitTrig_"+t.Name+" takes")||Regex.Matches(code,@"^function \w+ takes",RegexOptions.Multiline).Count!=e.GetProperty("functions").GetInt32()+1)throw new Exception("JASS entry lacks its original functions: "+t.Name);jass++;
 }
}
if(gui!=69||jass!=193)throw new Exception("Unexpected GUI/JASS split");
var outdir=args[1];Directory.CreateDirectory(outdir);
var builder=new MapScriptBuilder();builder.SetDefaultOptionsForMap(map);builder.FindVariableReferences(map);
var script=builder.Build(map).Replace("\r\n","\n");
var end=script.IndexOf("endglobals")+"endglobals".Length;
script=script.Insert(end,"\n"+map.CustomTextTriggers.GlobalCustomScriptCode.Code+"\n");
for(int i=0;i<triggers.Length;i++){
 var t=triggers[i];if(!t.IsCustomTextTrigger)continue;
 var code=map.CustomTextTriggers.CustomTextTriggers[i].Code!;
 var pattern=@"function InitTrig_"+Regex.Escape(t.Name)+@" takes nothing returns nothing.*?endfunction";
 if(!Regex.IsMatch(script,pattern,RegexOptions.Singleline))throw new Exception("No generated stub for "+t.Name);
 script=Regex.Replace(script,pattern,_=>code.Trim(),RegexOptions.Singleline);
}
File.WriteAllText(Path.Combine(outdir,"editor-generated.j"),script);
File.WriteAllText(Path.Combine(outdir,"original-gameplay.j"),map.Script!.Replace("\r\n","\n").Replace("\r","\n"));
var summary=new{infoVersion=25,editorVersion=6052,terrainWidth=480,terrainHeight=480,players=12,placedUnits=821,startLocations=12,regions=64,soundsAndMusic=25,variables=479,imports=569,originalTriggers=262,guiTriggers=gui,jassTriggers=jass,technicalTriggers=3,totalTriggerEntries=triggers.Length,codeHeaderBytes=System.Text.Encoding.UTF8.GetByteCount(map.CustomTextTriggers.GlobalCustomScriptCode.Code!),actualWorldEditorRun=false};
File.WriteAllText(Path.Combine(outdir,"metadata-check.json"),JsonSerializer.Serialize(summary,new JsonSerializerOptions{WriteIndented=true}));
Console.WriteLine("PASS War3Net 6.1.2: 262 original named entries (69 GUI + 193 full JASS), 3 technical entries, correct WCT/WTG pairing/order; classic metadata parses; editor script emitted for pjass");
