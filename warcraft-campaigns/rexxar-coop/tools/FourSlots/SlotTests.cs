using System.Text;
using War3Net.IO.Mpq;
namespace RexxarSlots;
internal static class SlotTests{
    public static void Run(){
        foreach(int version in new[]{18,25})foreach(bool nested in new[]{false,true}){
            byte[] map=Fixture(version,nested);byte[] original=map.ToArray();var patched=SlotPatcher.Patch(map);
            Need(original.SequenceEqual(map),"source bytes changed");
            using var before=MpqArchive.Open(new MemoryStream(map,false));using var after=MpqArchive.Open(new MemoryStream(patched.Data,false));
            var old=ClassicInfo.Read(SlotPatcher.Read(before,"war3map.w3i"));var current=ClassicInfo.Read(SlotPatcher.Read(after,"war3map.w3i"));
            Need(patched.Players.SequenceEqual(new[]{0,1,2,3}),"wrong slots");Need(current.Players.Count(p=>p.Controller==1)==4,"not four users");
            var npc=current.Players.Single(p=>p.Id==5);var oldNpc=old.Players.Single(p=>p.Id==5);Need(npc with{Name=oldNpc.Name}==oldNpc&&npc.Name.SequenceEqual(oldNpc.Name),"NPC changed");
            Need(old.Tail.SequenceEqual(current.Tail),"tech/upgrade/random tables changed");
            byte[] prefix=old.Prefix.ToArray();BitConverter.GetBytes((BitConverter.ToInt32(prefix,old.FlagsOffset)|0x60)&~4).CopyTo(prefix,old.FlagsOffset);Need(prefix.SequenceEqual(current.Prefix),"terrain/loading/camera settings changed");
            Need(current.Forces.Single(f=>(f.Members&1)!=0).Members==15,"party force missing");Need(current.Forces.Single(f=>(f.Members&(1<<5))!=0).Members==(1<<5),"NPC force changed");
            foreach(string asset in new[]{@"war3mapImported\hidden.mdx","war3map.w3u","war3map.w3e"})Need(SlotPatcher.Read(before,asset).SequenceEqual(SlotPatcher.Read(after,asset)),"asset changed: "+asset);
            Need(!after.FileExists("(attributes)"),"stale checksum file retained");
            int headerPlayers=BitConverter.ToInt32(patched.Data,8+Encoding.UTF8.GetByteCount("Test map")+1+4);Need(headerPlayers==4,"HM3W player count not four");
            string scriptName=nested?@"Scripts\war3map.j":"war3map.j";string originalScript=Encoding.Latin1.GetString(SlotPatcher.Read(before,scriptName));string script=Encoding.Latin1.GetString(SlotPatcher.Read(after,scriptName));
            int start=script.IndexOf("    "+ScriptPatch.Marker,StringComparison.Ordinal);int end=script.LastIndexOf("endfunction",StringComparison.Ordinal);
            Need(start>=0&&script.Contains("call SetPlayerController(Player(3), MAP_CONTROL_USER)"),"config not patched");
            // Remove the injected text and recover the exact original script.
            Need(script.Remove(start-1,end-(start-1))==originalScript,"non-config script bytes changed");
            Reject(()=>SlotPatcher.Patch(patched.Data),"duplicate patch accepted");
            string? folder=Environment.GetEnvironmentVariable("REXXAR_TEST_ARTIFACTS");if(!string.IsNullOrEmpty(folder)){
                Directory.CreateDirectory(folder);File.WriteAllBytes(Path.Combine(folder,$"slot-fixture-{version}-{nested}.w3i"),SlotPatcher.Read(after,"war3map.w3i"));
                if(version==25&&!nested){File.WriteAllBytes(Path.Combine(folder,"slot-source.w3x"),map);File.WriteAllBytes(Path.Combine(folder,"slot-fixture.w3x"),patched.Data);File.WriteAllBytes(Path.Combine(folder,"slot-fixture.j"),SlotPatcher.Read(after,scriptName));}
            }
        }
        var info=ClassicInfo.Read(Info(25));info.Players.AddRange(Enumerable.Range(1,11).Where(id=>id!=5).Select(id=>new Slot(id,2,2,1,Encoding.ASCII.GetBytes("NPC"),0,0,0,0)));Reject(()=>info.AddFourSlots(""),"occupied NPC slots overwritten");
        var refs=ScriptPatch.ReferencedPlayers("function config takes nothing returns nothing\ncall SetPlayerController(Player(1), MAP_CONTROL_NONE)\nendfunction\nfunction main takes nothing returns nothing\n// Player(2)\ncall BJDebugMsg(\"Player(3) endfunction\")\ncall SetPlayerState(Player(4), PLAYER_STATE_RESOURCE_GOLD, 0)\nendfunction");
        Need(refs.SetEquals(new[]{4}),"quoted/comment/config references incorrectly reserve slots");
        var reserved=ClassicInfo.Read(Info(25));Need(reserved.AddFourSlots("function main takes nothing returns nothing\ncall SetPlayerState(Player(1), PLAYER_STATE_RESOURCE_GOLD, 0)\nendfunction").SequenceEqual(new[]{0,2,3,4}),"gameplay-reserved empty slot reused");
        Reject(()=>SlotPatcher.Patch(Fixture(25,false,missingConfig:true)),"missing config accepted");
        Console.WriteLine("PASS: classic W3I 18/25; exactly four user slots; script + HM3W agreement; NPC/terrain/upgrades preserved; encrypted unknown imports retained byte-for-byte; root/nested JASS; checksum invalidation; duplicate/occupied/missing-config refusals; original bytes unchanged.");
    }
    private static byte[] Fixture(int version,bool nested,bool missingConfig=false){
        var b=new MpqArchiveBuilder();
        b.AddFile(MpqFile.New(new MemoryStream(Info(version)),"war3map.w3i"));
        string script="function main takes nothing returns nothing\n    local player p = Player(5)\n    // original quest logic\nendfunction\n\nfunction config takes nothing returns nothing\n    call SetPlayers(2)\n    call SetTeams(2)\n    call SetPlayerController(Player(0), MAP_CONTROL_USER)\n    call SetPlayerController(Player(5), MAP_CONTROL_COMPUTER)\nendfunction";
        if(missingConfig)script=script.Replace("function config ","function other ");
        b.AddFile(MpqFile.New(new MemoryStream(Encoding.Latin1.GetBytes(script)),nested?@"Scripts\war3map.j":"war3map.j"));
        foreach(string asset in new[]{@"war3mapImported\hidden.mdx","war3map.w3u","war3map.w3e"})b.AddFile(MpqFile.New(new MemoryStream(Enumerable.Range(0,15000).Select(i=>(byte)(i*31+7)).ToArray()),asset),MpqFileFlags.Exists|MpqFileFlags.CompressedMulti|MpqFileFlags.Encrypted|MpqFileFlags.BlockOffsetAdjustedKey);
        using var mpq=new MemoryStream();b.SaveTo(mpq,new MpqArchiveCreateOptions{ListFileCreateMode=MpqFileCreateMode.Prune,AttributesFlags=AttributesFlags.Crc32},true);
        using var stream=new MemoryStream();using(var w=new BinaryWriter(stream,Encoding.UTF8,true)){w.Write(Encoding.ASCII.GetBytes("HM3W"));w.Write(0);S(w,"Test map");w.Write(0);w.Write(1);}stream.SetLength(512);stream.Position=512;stream.Write(mpq.ToArray());return stream.ToArray();
    }
    private static byte[] Info(int version){
        using var stream=new MemoryStream();using var w=new BinaryWriter(stream);
        w.Write(version);w.Write(7);w.Write(6060);foreach(string s in new[]{"Тестовая карта","Original author","Original quest description","1 player"})S(w,s);
        for(int i=0;i<8;i++)w.Write((float)(i*100));for(int i=0;i<4;i++)w.Write(0);w.Write(64);w.Write(64);w.Write(0x4000);w.Write((byte)'L');
        w.Write(-1);if(version==25)S(w,"");foreach(string s in new[]{"Loading text","Title","Subtitle"})S(w,s);
        w.Write(0);if(version==25)S(w,"");foreach(string s in new[]{"Prologue","Title","Subtitle"})S(w,s);
        if(version==25){w.Write(0);w.Write(100f);w.Write(5000f);w.Write(0.5f);w.Write(-1);w.Write(0);S(w,"Default");w.Write((byte)'L');w.Write(-1);}
        w.Write(2);Player(w,0,1,"Host");Player(w,5,2,"NPC faction");w.Write(2);w.Write(3);w.Write(1);S(w,"Original party");w.Write(0);w.Write(1<<5);S(w,"Original NPCs");
        w.Write(0);w.Write(0);w.Write(0);if(version==25)w.Write(0);return stream.ToArray();
    }
    private static void Player(BinaryWriter w,int id,int ctrl,string name){w.Write(id);w.Write(ctrl);w.Write(2);w.Write(1);S(w,name);w.Write(100f);w.Write(200f);w.Write(0);w.Write(0);}
    private static void S(BinaryWriter w,string text){w.Write(Encoding.UTF8.GetBytes(text));w.Write((byte)0);}
    private static void Need(bool test,string message){if(!test)throw new InvalidOperationException("Self-test failed: "+message);}
    private static void Reject(Action test,string message){try{test();}catch(InvalidDataException){return;}throw new InvalidOperationException(message);}
}
