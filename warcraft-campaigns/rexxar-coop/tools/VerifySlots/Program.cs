using War3Net.Build.Extensions;
using War3Net.Build.Info;
int checkedFiles=0;
foreach(string path in Directory.GetFiles(args[0],"slot-fixture-*.w3i")){
    using var stream=File.OpenRead(path);using var reader=new BinaryReader(stream);
    var info=reader.ReadMapInfo();
    if(stream.Position!=stream.Length)throw new InvalidDataException("W3I trailing bytes: "+path);
    if(info.Players.Count(p=>p.Controller==PlayerController.User)!=4)throw new InvalidDataException("Not four users");
    if(info.RecommendedPlayers!="4 players")throw new InvalidDataException("Preview still recommends a single player");
    if(info.Players.Single(p=>p.Id==5).Controller!=PlayerController.Computer)throw new InvalidDataException("NPC slot changed");
    if((int)info.Forces.Single(f=>(f.Players&1)!=0).Players!=15)throw new InvalidDataException("Wrong party force");
    if(info.UpgradeData.Count!=0||info.TechData.Count!=0||info.PlayableMapAreaWidth!=64||info.PlayableMapAreaHeight!=64)throw new InvalidDataException("Unrelated map data changed");
    checkedFiles++;
}
if(checkedFiles!=4)throw new InvalidDataException("Expected all four classic W3I fixtures");
Console.WriteLine("PASS: independent War3Net.Build reader parsed all four W3I fixtures, four human slots, retained NPC/forces/terrain/upgrades, exact stream lengths.");
