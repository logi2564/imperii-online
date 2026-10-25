using SIPackages;
using SIPackages.Core;
using System.Text.Json;
var root=args[0];
using var catalogJson=JsonDocument.Parse(File.ReadAllText(Path.Combine(root,"sigame-arcade/catalog.json")));
var catalog=catalogJson.RootElement.EnumerateArray().ToDictionary(g=>g.GetProperty("id").GetString()!);
const string filename="Bro-Arcade-Blitz-61.siq";
using var stream=File.OpenRead(Path.Combine(root,"dist/blitz",filename));
using var doc=SIDocument.Load(stream);
int questions=0,final=0;double totalSeconds=0;var answers=new HashSet<string>();
if(doc.Package.Rounds.Count!=3)throw new Exception("Expected 3 rounds");
foreach(var round in doc.Package.Rounds){
 bool isFinal=round.Type==RoundTypes.Final;
 if(round.Themes.Count!=(isFinal?1:6))throw new Exception("Theme count");
 foreach(var theme in round.Themes){
  if(theme.Questions.Count!=(isFinal?1:5))throw new Exception("Questions in theme");
  foreach(var q in theme.Questions){
   questions++;
   if(isFinal){final++;if(q.TypeName!=QuestionTypes.StakeAll)throw new Exception("Final must be stakeAll");}
   if(q.Right.Count!=1||!answers.Add(q.Right[0]))throw new Exception("Missing or repeated answer");
   var items=q.GetContent().ToList();
   if(items.Count!=1||items[0].Type!=ContentTypes.Html||!items[0].IsRef)throw new Exception("Question must contain exactly one embedded HTML game");
   var item=items[0];var id=Path.GetFileNameWithoutExtension(item.Value);
   if(!catalog.TryGetValue(id,out var expected))throw new Exception("Unknown game");
   if(q.Right[0]!=expected.GetProperty("answer").GetString())throw new Exception("Reward mismatch");
   if(item.Duration.TotalSeconds!=expected.GetProperty("seconds").GetInt32()+8)throw new Exception("Incorrect duration");
   totalSeconds+=item.Duration.TotalSeconds;
   var file=doc.Html.GetFile(item.Value)??throw new Exception("Missing HTML");
   using var data=file.Stream;using var memory=new MemoryStream();data.CopyTo(memory);
   if(memory.Length<5000||memory.Length>30000)throw new Exception("Unexpected phone payload size");
   var text=System.Text.Encoding.UTF8.GetString(memory.ToArray());
   if(!text.Contains("Arcade.prime()")||!text.Contains("si:media-control")||text.Contains("ENTRY_QR"))throw new Exception("Missing automatic SI integration or stale QR content");
  }
 }
}
if(questions!=61||final!=1||totalSeconds!=2048)throw new Exception("Wrong totals");
Console.WriteLine($"PASS official SIPackages 7.14.0: {filename}; 61 embedded HTML questions; no image/QR stages; 15–35s games, 40s final, automatic 5s preparation; 2048s total media windows; one stakeAll final");
