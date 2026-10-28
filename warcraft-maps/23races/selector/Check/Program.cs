using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using CSharpLua;
using War3Net.Build;
using War3Net.Build.Extensions;
using War3Net.Build.Script;
using War3Net.CodeAnalysis.Jass;
using War3Net.CodeAnalysis.Transpilers;
using War3Net.Modeling;

string Generate(Map map) {
    var builder=new MapScriptBuilder(); builder.SetDefaultOptionsForMap(map); builder.FindVariableReferences(map);
    string script=builder.Build(map).Replace("\r\n","\n");
    script=script.Insert(script.IndexOf("endglobals")+10,"\n"+map.CustomTextTriggers!.GlobalCustomScriptCode.Code+"\n");
    var entries=map.Triggers!.TriggerItems.OfType<TriggerDefinition>().ToArray();
    for(int i=0;i<entries.Length;i++) if(entries[i].IsCustomTextTrigger) {
        var regex=new Regex(@"function InitTrig_"+Regex.Escape(entries[i].Name)+@" takes nothing returns nothing.*?endfunction",RegexOptions.Singleline);
        if(regex.Matches(script).Count!=1)throw new Exception("Missing editor stub "+entries[i].Name);
        script=regex.Replace(script,_=>map.CustomTextTriggers.CustomTextTriggers[i].Code!.Trim());
    }
    return Regex.Replace(script,@"(?m)^//   Date:.*$","//   Reproducible classic 1.26 race selector example");
}

if(args[0]=="patch") {
    var map=Map.Open(args[1]); string work=args[2];
    map.Info!.MapName="23 Расы — Выбор расы FIX2";
    var entries=map.Triggers!.TriggerItems.OfType<TriggerDefinition>().ToArray();
    if(entries.Length!=265||map.Triggers.Variables.Count!=479)throw new Exception("Wrong baseline trigger inventory");
    using var vars=JsonDocument.Parse(File.ReadAllText(Path.Combine(work,"globals.json")));
    foreach(var v in vars.RootElement.EnumerateArray())map.Triggers.Variables.Add(new VariableDefinition {
        Name=v.GetProperty("name").GetString()!,Type=v.GetProperty("type").GetString()!,
        IsArray=v.GetProperty("array").GetBoolean(),ArraySize=1,IsInitialized=false,InitialValue="",Unk=1,
        Id=10000+map.Triggers.Variables.Count,ParentId=0
    });
    int removed=0;
    for(int i=1;i<=262;i++) {
        var t=entries[i];
        if(t.IsCustomTextTrigger) {
            string code=map.CustomTextTriggers!.CustomTextTriggers[i].Code!;
            var initializer=new Regex(@"(?m)^function R23_InitTrig_\w+ takes[^\n]*\n[\s\S]*?^endfunction");
            code=initializer.Replace(code,m=>Regex.Replace(m.Value,@"(?m)^\s*call TriggerRegisterTimerEvent(Single|Periodic)\([^\n]+\)\s*$",m2=>{removed++;return "// Initial timer is armed by AS_RestoreOriginals after race selection.";}));
            map.CustomTextTriggers.CustomTextTriggers[i].Code=code;
        } else {
            removed+=t.Functions.RemoveAll(f=>f.Type==TriggerFunctionType.Event&&(f.Name=="TriggerRegisterTimerEventSingle"||f.Name=="TriggerRegisterTimerEventPeriodic"));
        }
    }
    using var timerDoc=JsonDocument.Parse(File.ReadAllText(Path.Combine(work,"timers.json")));
    if(removed!=timerDoc.RootElement.GetArrayLength())throw new Exception($"Central timer inventory differs: removed {removed}");
    map.CustomTextTriggers!.GlobalCustomScriptCode.Code+="\n"+File.ReadAllText(Path.Combine(work,"selector-functions.j"));
    int end=Array.FindIndex(entries,e=>e.Name=="R23_End");
    var codeEnd=map.CustomTextTriggers.CustomTextTriggers[end].Code!;
    int pos=codeEnd.LastIndexOf("endfunction",StringComparison.Ordinal);
    map.CustomTextTriggers.CustomTextTriggers[end].Code=codeEnd.Insert(pos,"call AS_Bootstrap()\n");
    using(var w=new BinaryWriter(File.Create(Path.Combine(work,"war3map.wtg"))))w.Write(map.Triggers);
    using(var w=new BinaryWriter(File.Create(Path.Combine(work,"war3map.wct"))))w.Write(map.CustomTextTriggers);
    File.WriteAllText(Path.Combine(work,"editor-generated.j"),Generate(map));
    Console.WriteLine($"Patched editable WTG/WCT; {removed} original initial timers defer until selection ends.");
} else if(args[0]=="verify") {
    var map=Map.Open(args[1]); var dir=args[2]; Directory.CreateDirectory(dir);
    if((int)map.Info!.FormatVersion!=25||map.Info.Players.Count!=12||map.Environment!.Width!=480||map.Units!.Units.Count!=833||map.Regions!.Regions.Count!=64)throw new Exception("Lost classic map metadata");
    var entries=map.Triggers!.TriggerItems.OfType<TriggerDefinition>().ToArray();
    if(entries.Length!=265||entries.Skip(1).Take(262).Count(t=>!t.IsCustomTextTrigger)!=69)throw new Exception("Lost editable triggers");
    var generated=Generate(map);
    File.WriteAllText(Path.Combine(dir,"editor-regenerated.j"),generated);
    if(generated!=map.Script!.Replace("\r\n","\n"))throw new Exception("Runtime does not match editable editor script");
    Console.WriteLine($"PASS independent map parse: classic W3I25, 12 players, 833 placements, 64 regions; 262 original triggers, 69 GUI entries, {map.Triggers.Variables.Count} variables; editor resave emits the actual runtime.");
} else if(args[0]=="models") {
    int n=0;
    foreach(var p in Directory.GetFiles(args[1],"*.mdx")) {
        using var s=File.OpenRead(p); var m=BinaryModelParser.Parse(s,true);
        if(s.Position!=s.Length)throw new Exception("Incomplete model parse "+p);
        n++;
    }
    Console.WriteLine($"PASS independent War3Net classic MDX parser: {n} generated interface models.");
} else if(args[0]=="transpile") {
    var t=new JassToLuaTranspiler{IgnoreComments=true,IgnoreEmptyDeclarations=true,KeepFunctionsSeparated=true};
    foreach(string f in new[]{"common.j","Blizzard.j"})t.RegisterJassFile(JassSyntaxFactory.ParseCompilationUnit(File.ReadAllText(Path.Combine(args[2],f))));
    var unit=JassSyntaxFactory.ParseCompilationUnit(File.ReadAllText(args[1]));using var w=new StreamWriter(args[3]);
    new LuaRenderer(new LuaSyntaxGenerator.SettingInfo{Indent=4},w).RenderCompilationUnit(t.Transpile(unit));
    Console.WriteLine("Transpiled actual map runtime for native-boundary behavior tests.");
} else throw new Exception("Unknown command");
