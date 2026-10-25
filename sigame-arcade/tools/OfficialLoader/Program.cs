using SIPackages;
using SIPackages.Core;
using System.Text.Json;
var root=args[0];
using var catalogJson=JsonDocument.Parse(File.ReadAllText(Path.Combine(root,"sigame-arcade/catalog.json")));
var catalog=catalogJson.RootElement.EnumerateArray().ToDictionary(g=>g.GetProperty("id").GetString()!);
foreach(var filename in new[]{"Bro-Arcade-61.siq","Bro-Arcade-61-QR.siq"}){
 using var stream=File.OpenRead(Path.Combine(root,"dist/arcade",filename));using var doc=SIDocument.Load(stream);
 int questions=0,html=0,images=0,final=0;var answerSet=new HashSet<string>();
 if(doc.Package.Rounds.Count!=3)throw new Exception("Expected two standard rounds and one final");
 foreach(var round in doc.Package.Rounds){
  bool isFinal=round.Type==RoundTypes.Final;
  if(round.Themes.Count!=(isFinal?1:6))throw new Exception("Theme count");
  foreach(var theme in round.Themes){
   if(theme.Questions.Count!=(isFinal?1:5))throw new Exception("Question count in theme");
   foreach(var q in theme.Questions){
    questions++;if(isFinal){final++;if(q.TypeName!=QuestionTypes.StakeAll)throw new Exception("Final is not stakeAll");}
    if(q.Right.Count!=1||!answerSet.Add(q.Right[0]))throw new Exception("Missing/repeated secret answer");
    var items=q.GetContent().ToList();var media=items.Where(i=>i.Type==ContentTypes.Image||i.Type==ContentTypes.Html).ToList();
    if(media.Count!=(filename.Contains("-QR")?1:2))throw new Exception("Unexpected playable media");
    string? id=null;
    foreach(var item in media){
     if(!item.IsRef)throw new Exception("External package media");
     var store=item.Type==ContentTypes.Html?doc.Html:doc.Images;
     var file=store.GetFile(item.Value)??throw new Exception("Missing media "+item.Value);using var data=file.Stream;using var memory=new MemoryStream();data.CopyTo(memory);memory.Position=0;
     if(memory.Length<100)throw new Exception("Empty content");
     if(item.Type==ContentTypes.Html){html++;using var reader=new StreamReader(memory);var text=reader.ReadToEnd();if(!text.Contains("window.ENTRY_GAME")||!text.Contains("Начать"))throw new Exception("HTML not playable");}else images++;
     id=Path.GetFileNameWithoutExtension(item.Value);
    }
    if(id==null||!catalog.TryGetValue(id,out var expected))throw new Exception("Unknown game id");
    if(q.Right[0]!=expected.GetProperty("answer").GetString())throw new Exception("Reward and official answer differ");
    if(media[^1].Duration.TotalSeconds!=expected.GetProperty("seconds").GetInt32()+45)throw new Exception("Incorrect per-game question duration");
   }
  }
 }
 if(questions!=61||images!=61||html!=(filename.Contains("-QR")?0:61)||final!=1)throw new Exception("Wrong media/final totals");
 Console.WriteLine($"PASS official SIPackages 7.14.0: {filename}, 61 questions, {html} embedded HTML games, 61 QR cards, per-game durations, 1 stake-for-all final");
}
