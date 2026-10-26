using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using RexxarExport;
using RexxarSlots;

Console.OutputEncoding=Encoding.UTF8;
bool pause=!args.Contains("--no-pause")&&!Console.IsInputRedirected;
int result=0;
try{
    if(args.Contains("--self-test")){SlotTests.Run();}
    else{
        Console.WriteLine("Рексар: четыре позиции игроков в лобби (Warcraft III 1.26)");
        Console.WriteLine("Это изменение слотов. Отдельные герои, сюжетный кооператив и переходы ещё не готовы.");
        string? input=Option("--map")??Option("--game")??args.FirstOrDefault(a=>File.Exists(a)||Directory.Exists(a))??GameLocator.Find();
        if(input is null){Console.WriteLine("Вставь путь к папке Warcraft III или к исходной карте .w3x и нажми Enter:");input=Console.ReadLine()?.Trim().Trim('"');}
        if(string.IsNullOrWhiteSpace(input))throw new IOException("Не указана папка игры или карта.");
        if(!File.Exists(input)&&!Directory.Exists(input))throw new IOException("Указанная папка или карта не найдена.");
        string desktop=Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);if(string.IsNullOrEmpty(desktop))desktop=Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        string output=Option("--out")??Path.Combine(desktop,"Rexxar-4-Slots-"+DateTime.Now.ToString("yyyyMMdd-HHmmss")+"-"+Guid.NewGuid().ToString("N")[..4]);
        if(Directory.Exists(output)&&Directory.EnumerateFileSystemEntries(output).Any())throw new IOException("Папка результата должна быть новой или пустой.");
        Directory.CreateDirectory(output);
        List<(string Name,byte[] Data)> maps;
        if(File.Exists(input)){
            if(!Path.GetExtension(input).Equals(".w3x",StringComparison.OrdinalIgnoreCase))throw new IOException("Нужна карта .w3x или папка Warcraft III.");
            maps=new(){(Path.GetFileName(input),File.ReadAllBytes(input))};
        }else{
            var report=Exporter.Export(input,Path.Combine(output,"Original-sources"),Console.WriteLine);
            maps=report.Files.Select(f=>(f.Name,f.Data)).ToList();
        }
        string folder=Path.Combine(output,"Rexxar-4-Slots");Directory.CreateDirectory(folder);
        var entries=new List<SlotEntry>();int success=0;
        foreach(var (name,data) in maps){
            try{
                var patched=SlotPatcher.Patch(data);string target=Path.GetFileNameWithoutExtension(name)+"-4Slots.w3x";
                File.WriteAllBytes(Path.Combine(folder,target),patched.Data);success++;
                Console.WriteLine($"ГОТОВО: {target}; позиции {string.Join(", ",patched.Players.Select(id=>id+1))}");
                entries.Add(new(name,target,true,patched.Players.Select(id=>id+1).ToArray(),Hash(data),Hash(patched.Data),""));
            }catch(Exception e)when(e is IOException or InvalidDataException or ArgumentException or NotSupportedException or OverflowException){
                Console.WriteLine("НЕ ИЗМЕНЕНА: "+name+" — "+e.Message);
                entries.Add(new(name,"",false,Array.Empty<int>(),Hash(data),"",e.Message));
            }
        }
        using(var file=File.Create(Path.Combine(output,"Four-slots-report.json"))){using var w=new Utf8JsonWriter(file,new JsonWriterOptions{Indented=true});
            w.WriteStartObject();w.WriteString("scope","four lobby slots only");w.WriteBoolean("fullCoopImplemented",false);w.WriteNumber("mapsFound",maps.Count);w.WriteNumber("mapsPatched",success);w.WriteStartArray("maps");
            foreach(var entry in entries){w.WriteStartObject();w.WriteString("source",entry.Source);w.WriteString("file",entry.File);w.WriteBoolean("success",entry.Success);w.WriteStartArray("players");foreach(int id in entry.Players)w.WriteNumberValue(id);w.WriteEndArray();w.WriteString("sourceSha256",entry.SourceSha256);w.WriteString("sha256",entry.Sha256);w.WriteString("error",entry.Error);w.WriteEndObject();}
            w.WriteEndArray();w.WriteEndObject();
        }
        File.WriteAllText(Path.Combine(output,"ЧИТАЙ.txt"),"Созданы отдельные копии с четырьмя человеческими позициями в лобби. Оригиналы не изменены.\nСкопируй папку Rexxar-4-Slots в Warcraft III\\Maps и открой миссию через Локальная сеть → Создать игру. У всех должны быть одинаковые файлы.\nЭто только слоты: дополнительные герои, задания на четверых, баланс и переходы между миссиями ещё не реализованы.\nЗанятые сюжетными странами позиции не превращаются в игроков. Если трёх свободных позиций нет, карта пропускается с объяснением в Four-slots-report.json.\nПришли Four-slots-report.json и ZIP из Original-sources для дальнейшей работы над кампанией.\n");
        Console.WriteLine($"Создано карт с четырьмя слотами: {success} из {maps.Count}.\nПапка результата: {Path.GetFullPath(output)}");
        if(success>0)Console.WriteLine("Скопируй Rexxar-4-Slots в Warcraft III\\Maps. Создавай игру через «Локальная сеть».");
        else Console.WriteLine("Карты не созданы. Пришли Four-slots-report.json и отчёт из Original-sources.");
        if(success==0)result=2;else if(success!=maps.Count)result=3;
    }
}catch(Exception e){Console.Error.WriteLine(args.Contains("--self-test")?e.ToString():"Ошибка: "+e.Message);result=1;}
if(pause){Console.WriteLine("Нажми Enter, чтобы закрыть окно.");Console.ReadLine();}
return result;
string? Option(string name){int i=Array.IndexOf(args,name);return i>=0&&i+1<args.Length?args[i+1]:null;}
static string Hash(byte[] b)=>Convert.ToHexString(SHA256.HashData(b)).ToLowerInvariant();
internal sealed record SlotEntry(string Source,string File,bool Success,int[] Players,string SourceSha256,string Sha256,string Error);
