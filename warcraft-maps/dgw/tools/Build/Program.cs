using War3Net.Build;
using War3Net.Build.Extensions;
using War3Net.Build.Info;
using War3Net.Build.Common;
using War3Net.Build.Script;
using War3Net.Build.Object;
using War3Net.Build.Widget;
using War3Net.IO.Mpq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
var original=args[0];var root=args[1];var output=args[2];Directory.CreateDirectory(output);
var map=Map.Open(original);using var cat=JsonDocument.Parse(File.ReadAllText(Path.Combine(root,"source/catalog.json")));using var lay=JsonDocument.Parse(File.ReadAllText(Path.Combine(root,"source/layout.json")));
int Id(string s)=>BitConverter.ToInt32(Encoding.ASCII.GetBytes(s));
object Value(JsonElement v,int type)=>type==3?v.GetString()!:type==0?(object)v.GetInt32():v.GetSingle();
foreach(var o in cat.RootElement.GetProperty("objects").EnumerateArray()){
 var unit=new SimpleObjectModification{OldId=Id(o.GetProperty("old").GetString()!),NewId=Id(o.GetProperty("id").GetString()!)};
 foreach(var f in o.GetProperty("fields").EnumerateArray()){int type=f.GetProperty("type").GetInt32();unit.Modifications.Add(new SimpleObjectDataModification{Id=Id(f.GetProperty("id").GetString()!),Type=(ObjectDataType)type,Value=Value(f.GetProperty("value"),type)});}
 map.UnitObjectData!.NewUnits.Add(unit);
}
void Ability(string id,string name,string icon,bool point){
 var a=new LevelObjectModification{OldId=Id("ANcl"),NewId=Id(id)};
 void Add(string key,int type,object v,int level=0,int pointer=0)=>a.Modifications.Add(new LevelObjectDataModification{Id=Id(key),Type=(ObjectDataType)type,Value=v,Level=level,Pointer=pointer});
 Add("anam",3,name);Add("aart",3,icon);Add("aher",0,0);Add("aite",0,0);Add("alev",0,1);Add("areq",3,"");Add("ahky",3,point?"Z":"V");Add("abpx",0,point?1:0);Add("abpy",0,point?1:2);Add("aani",3,"spell");
 Add("atp1",3,name+(point?" (Z)":" (V)"),1);Add("aub1",3,point?"Божественная способность: удар по области и особый эффект расы. Радиус 420, дальность 700, перезарядка 55 секунд.":"Требуется цитадель III, 800 золота, 350 дерева и 150 веры. Призывает одного бога. Павшего бога можно воскресить в алтаре.",1);
 Add("acdn",1,point?55f:3f,1);Add("amcs",0,point?125:0,1);Add("aran",1,point?700f:0f,1);Add("aare",1,point?420f:0f,1);
 Add("Ncl1",1,0f,1,1);Add("Ncl2",0,point?2:0,1,2);Add("Ncl3",0,17,1,3);Add("Ncl4",1,0f,1,4);Add("Ncl5",0,0,1,5);Add("Ncl6",3,"channel",1,6);
 map.AbilityObjectData!.NewAbilities.Add(a);
}
Ability("ZG00","Вознесение бога","ReplaceableTextures\\CommandButtons\\BTNResurrection.blp",false);
foreach(var f in cat.RootElement.GetProperty("factions").EnumerateArray()){
 var prefix=f.GetProperty("prefix").GetString()!;var avatar=f.GetProperty("avatar").GetString()!;var objectDef=cat.RootElement.GetProperty("objects").EnumerateArray().Single(o=>o.GetProperty("id").GetString()==avatar);var icon=objectDef.GetProperty("fields").EnumerateArray().Single(x=>x.GetProperty("id").GetString()=="uico").GetProperty("value").GetString()!;
 Ability(f.GetProperty("spell").GetString()!,f.GetProperty("spellName").GetString()!,icon,true);
 foreach(bool weapon in new[]{true,false}){
  var up=new LevelObjectModification{OldId=Id(weapon?"Rhme":"Rhar"),NewId=Id(f.GetProperty(weapon?"weaponUpgrade":"armorUpgrade").GetString()!)};
  void U(string key,int type,object value,int level=0)=>up.Modifications.Add(new LevelObjectDataModification{Id=Id(key),Type=(ObjectDataType)type,Value=value,Level=level,Pointer=0});
  U("glvl",0,3);U("gglb",0,100);U("gglm",0,75);U("glmb",0,50);U("glmm",0,40);U("gtib",0,25);U("gtim",0,10);U("gef1",3,weapon?"ratd":"rarm");U("gba1",2,weapon?3f:1f);U("gmo1",2,0f);
  for(int i=2;i<=4;i++)U("gef"+i,3,"");
  for(int level=1;level<=3;level++){
   var label=(weapon?"Вооружение":"Броня")+" "+level;U("gnam",3,label,level);U("gtp1",3,label,level);U("gub1",3,weapon?"Повышает урон всех войск этой расы на 3.":"Повышает броню всех войск этой расы на 1.",level);U("greq",3,level==1?"":prefix+(level==2?"11":"12"),level);
  }
  map.UpgradeObjectData!.NewUpgrades.Add(up);
 }
}
for(int i=0;i<map.Regions!.Regions.Count;i++){if(map.Regions.Regions[i].Name.Any(c=>c>127))map.Regions.Regions[i].Name="DGW_Region_"+i.ToString("D2");}
map.Info!.MapName="DGW: Боги и Империи — 16 рас";map.Info.MapDescription="FFA для 2–12 игроков: 16 рас, развитие столицы, боги, вера и захват святилищ. Warcraft III 1.26.";map.Info.MapAuthor="Расширение: Bro / Codex; исходная карта DGW";map.Info.RecommendedPlayers="2–12, FFA";map.Info.LoadingScreenTitle="Боги и Империи";map.Info.LoadingScreenText="Выбери расу. Развивай столицу, захватывай святилища и призывай бога. Последний владыка побеждает. Правила — F9.";
map.Info.MapFlags|=MapFlags.UseCustomForces|MapFlags.FixedPlayerSettingsForCustomForces;map.Info.MapFlags&=~MapFlags.MeleeMap;map.Info.Forces.Clear();
foreach(var p in map.Info.Players){p.Controller=PlayerController.User;p.Race=PlayerRace.Human;p.AllyHighPriorityFlags=new Bitmask32(0);p.AllyLowPriorityFlags=new Bitmask32(0);var point=lay.RootElement.GetProperty("starts")[p.Id];p.StartPosition=new System.Numerics.Vector2(point.GetProperty("x").GetInt32(),point.GetProperty("y").GetInt32());map.Info.Forces.Add(new ForceData{Flags=(ForceFlags)0,Players=new Bitmask32(1<<p.Id),Name="Владыка "+(p.Id+1)});}
map.Units!.Units.RemoveAll(u=>u.TypeId!=Id("sloc"));
foreach(var u in map.Units.Units){var point=lay.RootElement.GetProperty("starts")[u.OwnerId];u.Position=new System.Numerics.Vector3(point.GetProperty("x").GetInt32(),point.GetProperty("y").GetInt32(),0);}
int legacy=0;foreach(var t in map.Triggers!.TriggerItems.OfType<TriggerDefinition>()){t.IsEnabled=false;if(t.Name.Any(c=>c>127)||t.Name.EndsWith('_')){t.Description="Original prototype: "+t.Name+". "+t.Description;t.Name="Legacy_"+legacy.ToString("D2");}legacy++;}
map.Triggers.TriggerItems.Add(new TriggerCategoryDefinition{Id=900,ParentId=-1,Name="DGW - Gods and Empires",IsExpanded=true});map.Triggers.TriggerItems.Add(new TriggerDefinition{Name="DGW_Expansion",ParentId=900,IsEnabled=true,IsInitiallyOn=true,IsCustomTextTrigger=true,RunOnMapInit=false,Description="16 complete factions and the synchronized FFA game loop. Original prototype triggers remain disabled for reference."});
var decl=File.ReadAllText(Path.Combine(root,"source/globals.j"));var code=File.ReadAllText(Path.Combine(root,"source/expansion.j"));
map.CustomTextTriggers!.GlobalCustomScriptCode=new CustomTextTrigger{Code="globals\n"+decl+"\nendglobals\n"};map.CustomTextTriggers.GlobalCustomScriptComment="Classic NewGen JASS globals; original prototype trigger sources are retained in disabled entries.";map.CustomTextTriggers.CustomTextTriggers.Add(new CustomTextTrigger{Code=code});
var builder=new MapScriptBuilder();builder.SetDefaultOptionsForMap(map);builder.FindVariableReferences(map);var script=builder.Build(map).Replace("\r\n","\n");script=Regex.Replace(script,@"^//   Date:.*\n","",RegexOptions.Multiline);int end=script.IndexOf("endglobals");script=script.Insert(end,decl+"\n");var pattern=@"function InitTrig_DGW_Expansion takes nothing returns nothing.*?endfunction";if(!Regex.IsMatch(script,pattern,RegexOptions.Singleline))throw new Exception("Missing new trigger initializer");script=Regex.Replace(script,pattern,_=>code.Trim(),RegexOptions.Singleline);map.Script=script;
void Save(string name,MpqFile? f){if(f==null)return;using(f){using var stream=File.Create(Path.Combine(output,name));f.MpqStream.Position=0;f.MpqStream.CopyTo(stream);}}
Save("war3map.w3i",map.GetInfoFile());Save("war3map.w3r",map.GetRegionsFile());Save("war3map.w3u",map.GetUnitObjectDataFile());Save("war3map.w3a",map.GetAbilityObjectDataFile());Save("war3map.w3q",map.GetUpgradeObjectDataFile());Save("war3mapUnits.doo",map.GetUnitsFile());Save("war3map.wtg",map.GetTriggersFile());Save("war3map.wct",map.GetCustomTextTriggersFile());File.WriteAllText(Path.Combine(output,"war3map.j"),script);
using(var header=File.Create(Path.Combine(output,"archive-header.bin"))){map.Info.WriteArchiveHeaderToStream(header);header.SetLength(512);}
Console.WriteLine($"Built classic metadata: {map.UnitObjectData!.NewUnits.Count} custom unit definitions; {map.AbilityObjectData!.NewAbilities.Count} custom abilities; {map.UpgradeObjectData!.NewUpgrades.Count} custom upgrades; 12 independent forces; original prototype sources retained disabled.");
