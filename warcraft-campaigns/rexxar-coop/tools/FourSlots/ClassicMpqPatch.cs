using System.Buffers.Binary;
using War3Net.IO.Mpq;
namespace RexxarSlots;

// Append replacements instead of rebuilding the archive: untouched blocks keep
// their bytes AND offsets, including imported files with unknown encrypted names.
internal static class ClassicMpqPatch{
    private static readonly uint[] Table=MakeTable();
    public static byte[] Replace(byte[] source,IReadOnlyDictionary<string,byte[]> replacements,int humanPlayers){
        int header=-1;for(int p=0;p+32<=source.Length;p+=512)if(U32(source,p)==0x1a51504d){header=p;break;}
        if(header<0||U32(source,header+4)!=32||BinaryPrimitives.ReadUInt16LittleEndian(source.AsSpan(header+12))!=0)throw new InvalidDataException("Поддерживается классический MPQ v0; исходник сохранён без изменений.");
        int hashes=checked((int)U32(source,header+24)),blocks=checked((int)U32(source,header+28));
        if(hashes<1||hashes>65536||blocks<1||blocks>65536)throw new InvalidDataException("Неверные таблицы MPQ.");
        byte[] hash=Slice(source,checked(header+(int)U32(source,header+16)),checked(hashes*16));
        byte[] block=Slice(source,checked(header+(int)U32(source,header+20)),checked(blocks*16));
        Crypt(hash,Key("(hash table)"),false);Crypt(block,Key("(block table)"),false);
        using var output=new MemoryStream();output.Write(source);
        var modified=new HashSet<int>();
        foreach(var item in replacements){
            ulong name=MpqHash.GetHashedFileName(item.Key);var indices=new List<int>();
            for(int i=0;i<hashes;i++){int p=i*16;uint index=U32(hash,p+12);if(index<blocks&&BinaryPrimitives.ReadUInt64LittleEndian(hash.AsSpan(p))==name)indices.Add((int)index);}
            if(indices.Count!=1)throw new InvalidDataException("Ожидалась одна запись MPQ: "+item.Key);
            int indexToChange=indices[0];if(!modified.Add(indexToChange))throw new InvalidDataException("Совместно используемый блок MPQ не поддерживается.");
            int bp=indexToChange*16;Put(block,bp,checked((uint)(output.Position-header)));Put(block,bp+4,(uint)item.Value.Length);Put(block,bp+8,(uint)item.Value.Length);Put(block,bp+12,0x81000000);
            output.Write(item.Value);
        }
        // The original checksums/signature describe the old map. Tombstones keep
        // the probing chains of all other (even unknown) hash entries intact.
        foreach(string obsolete in new[]{"(attributes)","(signature)"}){
            ulong name=MpqHash.GetHashedFileName(obsolete);for(int i=0;i<hashes;i++)if(BinaryPrimitives.ReadUInt64LittleEndian(hash.AsSpan(i*16))==name&&U32(hash,i*16+12)<blocks){Array.Fill(hash,(byte)255,i*16,16);Put(hash,i*16+12,0xfffffffe);}
        }
        uint hashPosition=checked((uint)(output.Position-header));Crypt(hash,Key("(hash table)"),true);output.Write(hash);
        uint blockPosition=checked((uint)(output.Position-header));Crypt(block,Key("(block table)"),true);output.Write(block);
        byte[] result=output.ToArray();Put(result,header+8,checked((uint)(result.Length-header)));Put(result,header+16,hashPosition);Put(result,header+20,blockPosition);
        if(header>=512&&U32(result,0)==0x57334d48){int p=8;while(p<header&&result[p]!=0)p++;if(p+9>header)throw new InvalidDataException("Неверный заголовок карты HM3W.");Put(result,p+5,(uint)humanPlayers);}
        return result;
    }
    private static byte[] Slice(byte[] source,int offset,int count){if(offset<0||count<0||offset>source.Length-count)throw new InvalidDataException("Таблица MPQ выходит за границы файла.");return source.AsSpan(offset,count).ToArray();}
    private static uint U32(byte[] b,int p)=>BinaryPrimitives.ReadUInt32LittleEndian(b.AsSpan(p,4));
    private static void Put(byte[] b,int p,uint n)=>BinaryPrimitives.WriteUInt32LittleEndian(b.AsSpan(p,4),n);
    private static uint[] MakeTable(){var t=new uint[1280];uint seed=0x100001;for(int i=0;i<256;i++)for(int j=0;j<5;j++){seed=(seed*125+3)%0x2aaaab;uint high=(seed&65535)<<16;seed=(seed*125+3)%0x2aaaab;t[i+j*256]=high|(seed&65535);}return t;}
    private static uint Key(string text){unchecked{uint a=0x7fed7fed,b=0xeeeeeeee;foreach(char c in text.ToUpperInvariant()){a=Table[0x300+c]^(a+b);b=c+a+b+(b<<5)+3;}return a;}}
    private static void Crypt(byte[] data,uint key,bool encrypt){unchecked{uint seed=0xeeeeeeee;for(int i=0;i<data.Length;i+=4){seed+=Table[0x400+(key&255)];uint input=U32(data,i),plain=encrypt?input:input^(key+seed);Put(data,i,encrypt?plain^(key+seed):plain);key=((~key<<21)+0x11111111)|(key>>11);seed=plain+seed+(seed<<5)+3;}}}
}
