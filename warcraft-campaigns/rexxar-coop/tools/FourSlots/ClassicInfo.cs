using System.Text;
namespace RexxarSlots;

// Edit only the classic player/force section. Preserve all other bytes, including
// original string encoding, terrain settings, upgrade restrictions and tables.
internal sealed record Slot(int Id,int Controller,int Race,int Flags,byte[] Name,float X,float Y,int Low,int High);
internal sealed record Team(int Flags,int Members,byte[] Name);
internal sealed class ClassicInfo{
    public byte[] Prefix=null!,Tail=null!;
    public int FlagsOffset;
    public List<Slot> Players=new();
    public List<Team> Forces=new();
    public static ClassicInfo Read(byte[] bytes){
        using var stream=new MemoryStream(bytes,false);using var r=new BinaryReader(stream);
        var v=r.ReadInt32();if(v!=18&&v!=25)throw new InvalidDataException("Поддерживаются классические карты W3I 18/25 (Warcraft 1.26).");
        r.ReadInt32();r.ReadInt32();for(int i=0;i<4;i++)CString(r);
        Skip(r,32+16+8);int flagsOffset=(int)stream.Position;Skip(r,5);
        r.ReadInt32();if(v==25)CString(r);
        for(int i=0;i<3;i++)CString(r);
        r.ReadInt32();if(v==25)CString(r);
        for(int i=0;i<3;i++)CString(r);
        if(v==25){Skip(r,20+4);CString(r);Skip(r,5);}
        int start=(int)stream.Position;
        var info=new ClassicInfo{Prefix=bytes[..start],FlagsOffset=flagsOffset};
        int count=Count(r,12);for(int i=0;i<count;i++)info.Players.Add(new(r.ReadInt32(),r.ReadInt32(),r.ReadInt32(),r.ReadInt32(),CString(r),r.ReadSingle(),r.ReadSingle(),r.ReadInt32(),r.ReadInt32()));
        count=Count(r,12);for(int i=0;i<count;i++)info.Forces.Add(new(r.ReadInt32(),r.ReadInt32(),CString(r)));
        info.Tail=bytes[(int)stream.Position..];
        if(info.Players.Any(p=>p.Id<0||p.Id>11)||info.Players.Select(p=>p.Id).Distinct().Count()!=info.Players.Count)throw new InvalidDataException("Некорректные позиции игроков.");
        return info;
    }
    public int[] AddFourSlots(string gameplay){
        var users=Players.Where(p=>p.Controller==1).ToList();
        if(users.Count!=1)throw new InvalidDataException("Ожидалась исходная миссия с одним игроком. Повторная обработка и чужие мультиплеерные карты не поддерживаются.");
        int host=users[0].Id;
        var used=ScriptPatch.ReferencedPlayers(gameplay);
        var spare=Enumerable.Range(0,12).Where(id=>id!=host&&!used.Contains(id)&&Players.All(p=>p.Id!=id||p.Controller==0)).Take(3).ToArray();
        if(spare.Length!=3)throw new InvalidDataException("Нет трёх свободных позиций: занятые сюжетными странами слоты не заменены.");
        var ids=new[]{host}.Concat(spare).ToArray();int mask=ids.Sum(id=>1<<id);
        foreach(int id in ids){
            var index=Players.FindIndex(p=>p.Id==id);
            var slot=index>=0?Players[index]:users[0] with{Id=id,Name=Encoding.UTF8.GetBytes("Co-op player "+(Array.IndexOf(ids,id)+1))};
            slot=slot with{Controller=1,Flags=slot.Flags|1,Low=0,High=mask&~(1<<id),X=users[0].X,Y=users[0].Y};
            if(index<0)Players.Add(slot);else Players[index]=slot;
        }
        int team=Forces.FindIndex(f=>(f.Members&(1<<host))!=0);
        if(team<0){if(Forces.Count>=12)throw new InvalidDataException("Нет свободной команды для игроков.");team=Forces.Count;Forces.Add(new(0,0,Encoding.UTF8.GetBytes("Rexxar - 4 players")));}
        for(int i=0;i<Forces.Count;i++)Forces[i]=Forces[i] with{Members=Forces[i].Members&~mask};
        Forces[team]=Forces[team] with{Members=Forces[team].Members|mask,Flags=Forces[team].Flags|1|2|8};
        int flags=BitConverter.ToInt32(Prefix,FlagsOffset);BitConverter.GetBytes((flags|0x60)&~4).CopyTo(Prefix,FlagsOffset);
        return ids;
    }
    public byte[] Write(){
        using var stream=new MemoryStream();using var w=new BinaryWriter(stream);
        w.Write(Prefix);w.Write(Players.Count);
        foreach(var p in Players){w.Write(p.Id);w.Write(p.Controller);w.Write(p.Race);w.Write(p.Flags);CString(w,p.Name);w.Write(p.X);w.Write(p.Y);w.Write(p.Low);w.Write(p.High);}
        w.Write(Forces.Count);foreach(var f in Forces){w.Write(f.Flags);w.Write(f.Members);CString(w,f.Name);}w.Write(Tail);return stream.ToArray();
    }
    private static int Count(BinaryReader r,int max){int n=r.ReadInt32();if(n<0||n>max)throw new InvalidDataException("Недопустимый размер таблицы.");return n;}
    private static byte[] CString(BinaryReader r){var b=new List<byte>();byte c;while((c=r.ReadByte())!=0){if(b.Count>1024*1024)throw new InvalidDataException();b.Add(c);}return b.ToArray();}
    private static void CString(BinaryWriter w,byte[] b){w.Write(b);w.Write((byte)0);}
    private static void Skip(BinaryReader r,int n){if(r.ReadBytes(n).Length!=n)throw new EndOfStreamException();}
}
