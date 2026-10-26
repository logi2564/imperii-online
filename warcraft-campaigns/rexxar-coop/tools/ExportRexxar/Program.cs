using System.Text;
using RexxarExport;

Console.OutputEncoding=Encoding.UTF8;
var pause=!args.Contains("--no-pause")&&!Console.IsInputRedirected;
int result;
try{
    if(args.Contains("--self-test")){
        SelfTests.Run();
        result=0;
    }else{
        Console.WriteLine("Выгрузка оригинальных миссий Рексара из Warcraft III");
        Console.WriteLine("Архивы игры открываются для чтения. Результат — отдельные ZIP с миссиями.");
        var game=Option("--game")??GameLocator.Find();
        if(game is null){
            Console.WriteLine("Папка игры не найдена. Вставь путь к папке Warcraft III и нажми Enter:");
            game=Console.ReadLine()?.Trim().Trim('"');
        }
        if(string.IsNullOrWhiteSpace(game)||!Directory.Exists(game))throw new IOException("Нужна папка с архивами War3x.mpq / War3Patch.mpq.");
        var output=Option("--out")??DefaultOutput();
        var report=Exporter.Export(game,output,Console.WriteLine);
        Console.WriteLine();
        Console.WriteLine($"Найдено карт: {report.Files.Count} из {Exporter.Missions.Length}.");
        Console.WriteLine("Результат: "+Path.GetFullPath(output));
        if(report.Files.Count==0){
            Console.WriteLine("Миссии не найдены. Пришли Rexxar-source-info.json: там перечислены проверенные архивы и отсутствующие карты.");
            result=2;
        }else if(report.Missing.Count>0){
            Console.WriteLine("Комплект неполный. Пришли созданные ZIP и Rexxar-source-info.json, чтобы определить недостающие миссии.");
            result=3;
        }else{
            Console.WriteLine("Все 17 миссий найдены. Пришли созданные ZIP: это исходники для сборки кооператива.");
            result=0;
        }
    }
}catch(Exception exception){
    Console.Error.WriteLine("Не удалось выгрузить миссии: "+exception.Message);
    result=1;
}
if(pause){Console.WriteLine("Нажми Enter, чтобы закрыть окно.");Console.ReadLine();}
return result;

string? Option(string name){var i=Array.IndexOf(args,name);return i>=0&&i+1<args.Length?args[i+1]:null;}
static string DefaultOutput(){
    var desktop=Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
    if(string.IsNullOrWhiteSpace(desktop))desktop=Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
    return Path.Combine(desktop,"Rexxar-sources-"+DateTime.Now.ToString("yyyyMMdd-HHmmss")+"-"+Guid.NewGuid().ToString("N")[..4]);
}
