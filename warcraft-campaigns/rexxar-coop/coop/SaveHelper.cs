using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

// Offline clipboard helper: reads only the four known save text files. It never
// runs Preload/JASS text, modifies Warcraft, downloads code or launches a browser.
internal static class SaveHelper {
    const string Alphabet="0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz-_";
    [STAThread] static int Main(string[] args) {
        if(args.Length>0&&args[0]=="--self-test") {
            try { SelfTest(args[1]);if(args.Length>2)File.WriteAllText(args[2],"PASS: exact Windows EXE parsed four actual-JASS Z4/C3 and Z3/C2 checkpoint files; one command per hero, checksums, role numbers, shared completion identity, classic chat length, quoted Preload text and corruption refusals. No game code was executed.");return 0; } catch(Exception e){Console.WriteLine(e);if(args.Length>2)File.WriteAllText(args[2],e.ToString());return 1;}
        }
        Application.EnableVisualStyles();Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new SaveWindow());return 0;
    }
    internal static string Expand(string text) {
        if(!text.StartsWith("Z3")&&!text.StartsWith("Z4"))return text;
        int maximum=text.StartsWith("Z4")?104:102;
        var output=new StringBuilder(maximum==104?"C3":"C2");
        for(int pos=2;pos<text.Length;pos++) {
            char c=text[pos];
            if(c=='.') {
                if(++pos>=text.Length)return "";
                int count=Alphabet.IndexOf(text[pos]);
                if(count<3||output.Length+count>maximum)return "";
                output.Append('0',count);
            } else { if(Alphabet.IndexOf(c)<0)return "";output.Append(c); }
            if(output.Length>maximum)return "";
        }
        return output.ToString();
    }
    static bool IsCheckpoint(string command) { return command.StartsWith("-load C2")||command.StartsWith("-load Z3")||command.StartsWith("-load C3")||command.StartsWith("-load Z4"); }
    static string GroupIdentity(string command) { return Expand(command.Substring(6)).Substring(3,36); }
    static bool Valid(string payload,char kind) {
        payload=Expand(payload);
        int expected=kind=='C'?(payload.StartsWith("C3")?104:102):kind=='H'?81:kind=='S'?104:99;
        if(payload.Length!=expected||payload[0]!=kind||(kind=='C'?(payload[1]!='2'&&payload[1]!='3'):payload[1]!='1'))return false;
        int hash=19;
        for(int n=0;n<payload.Length-3;n++){int digit=Alphabet.IndexOf(payload[n]);if(digit<0)return false;hash=(hash*73+digit+1)%262139;}
        int saved=0;for(int n=payload.Length-3;n<payload.Length;n++){int digit=Alphabet.IndexOf(payload[n]);if(digit<0)return false;saved=saved*64+digit;}
        return hash==saved;
    }
    internal static Dictionary<string,string> Parse(string text) {
        var commands=new Dictionary<string,string>();
        foreach(Match match in Regex.Matches(text,@"-load ((?:C2[A-Za-z0-9_-]{100}|C3[A-Za-z0-9_-]{102}|Z[34][A-Za-z0-9_.-]{2,102}))(?![A-Za-z0-9_.-])")){
            string payload=match.Groups[1].Value;string expanded=Expand(payload);int role=expanded.Length>2?Alphabet.IndexOf(expanded[2]):-1;
            if(Valid(payload,'C')&&role>=0&&role<4)commands["hero"+(role+1)]="-load "+payload;
        }
        foreach(Match match in Regex.Matches(text,@"-load([1-4]) ([A-Za-z0-9_-]{81})(?![A-Za-z0-9_-])")){
            string payload=match.Groups[2].Value;int role=int.Parse(match.Groups[1].Value);
            if(Valid(payload,'H')&&Alphabet.IndexOf(payload[2])==role-1)commands["hero"+role]="-load"+role+" "+payload;
        }
        foreach(string name in new[]{"party","stash"}){
            foreach(Match match in Regex.Matches(text,"-"+name+@" ([A-Za-z0-9_-]{16,120})(?![A-Za-z0-9_-])")){
                string payload=match.Groups[1].Value;if(Valid(payload,name=="party"?'P':'S'))commands[name]="-"+name+" "+payload;
            }
        }
        return commands;
    }
    static void SelfTest(string folder) {
        int checkedFiles=0;
        foreach(string file in Directory.GetFiles(folder,"RexxarCoop-P*.txt")){
            string text=File.ReadAllText(file);var commands=Parse(text);
            int role=int.Parse(Path.GetFileNameWithoutExtension(file).Substring("RexxarCoop-P".Length));
            if(commands.Count!=1||!commands.ContainsKey("hero"+role))throw new Exception("Expected one generated Z4/C3 and Z3/C2 command per hero");
            foreach(var command in commands.Values)if(command.Length>127)throw new Exception("Command exceeds classic chat limit");
            string hero=commands["hero"+role],damaged=hero.Substring(0,hero.Length-1)+(hero[hero.Length-1]=='0'?'1':'0');
            if(Parse(damaged).Count!=0)throw new Exception("Damaged checksum accepted");
            string quoted="call Preload(\""+hero+"\")";
            if(Parse(quoted)["hero"+role]!=hero)throw new Exception("Actual Preload text wrapper not parsed");
            checkedFiles++;
        }
        if(checkedFiles!=4)throw new Exception("Expected four actual runtime save fixtures");
        var keys=new HashSet<string>();
        foreach(string file in Directory.GetFiles(folder,"RexxarCoop-P*.txt"))foreach(string command in Parse(File.ReadAllText(file)).Values)keys.Add(GroupIdentity(command));
        if(keys.Count!=1)throw new Exception("Generated fixture codes do not share a completion identity");
        Console.WriteLine("PASS: exact Windows save helper parsed four actual-JASS Z4/C3 and Z3/C2 fixtures, one command each, quoted Preload text, checksums, roles and classic chat lengths; rejected corruption and checked matching completion identity. No game code was executed.");
    }
    sealed class SaveWindow:Form {
        string folder=AppDomain.CurrentDomain.BaseDirectory;
        readonly Label status=new Label();readonly ListBox commands=new ListBox();
        readonly Dictionary<string,string> loaded=new Dictionary<string,string>();
        public SaveWindow(){
            Text="Коды продолжения Рексара — V";ClientSize=new Size(650,355);Font=new Font("Segoe UI",10);StartPosition=FormStartPosition.CenterScreen;
            var description=new Label{Left=16,Top=12,Width=620,Height=62,Text="В конце миссии игра сама выдаёт каждому один код.\nВ следующей карте введи -load СВОЙ_КОД, затем ведущий — -start.\nЭта программа только помогает скопировать код; играть можно без неё."};Controls.Add(description);
            commands.SetBounds(16,84,618,145);commands.DisplayMember="Key";Controls.Add(commands);
            var copy=new Button{Text="Скопировать выбранную команду",Left=16,Top=240,Width=310,Height=36};copy.Click+=(s,e)=>Copy();Controls.Add(copy);
            var browse=new Button{Text="Папка Warcraft…",Left=338,Top=240,Width=145,Height=36};browse.Click+=(s,e)=>{using(var dialog=new FolderBrowserDialog()){dialog.Description="Выбери папку Warcraft III, где есть Logs";dialog.SelectedPath=folder;if(dialog.ShowDialog()==DialogResult.OK){folder=dialog.SelectedPath;RefreshSaves();}}};Controls.Add(browse);
            var refresh=new Button{Text="Обновить",Left=495,Top=240,Width=139,Height=36};refresh.Click+=(s,e)=>RefreshSaves();Controls.Add(refresh);
            status.SetBounds(16,285,618,58);Controls.Add(status);RefreshSaves();
        }
        void RefreshSaves(){
            loaded.Clear();commands.Items.Clear();string latest="";
            var roots=new List<string>{folder,Path.GetDirectoryName(folder)??folder};
            string drive=Path.GetPathRoot(folder)??"";
            if(drive.Length>0)roots.Add(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"VirtualStore",folder.Substring(drive.Length)));
            var snapshots=new List<Tuple<DateTime,Dictionary<string,string>>>();
            foreach(string root in roots)for(int n=1;n<=4;n++){
                string file=Path.Combine(root,"Logs","RexxarCoop-P"+n+".txt");if(!File.Exists(file))continue;
                try{using(var input=new FileStream(file,FileMode.Open,FileAccess.Read,FileShare.ReadWrite)){if(input.Length>65536)continue;using(var reader=new StreamReader(input,Encoding.UTF8,true)){var parsed=Parse(reader.ReadToEnd());string key="hero"+n;if(parsed.ContainsKey(key)&&IsCheckpoint(parsed[key]))snapshots.Add(Tuple.Create(File.GetLastWriteTime(file),parsed));}}}catch(IOException){}catch(UnauthorizedAccessException){}
            }
            snapshots.Sort((a,b)=>b.Item1.CompareTo(a.Item1));
            if(snapshots.Count>0){
                string selected="";foreach(string value in snapshots[0].Item2.Values)if(IsCheckpoint(value)){selected=GroupIdentity(value);break;}
                latest=snapshots[0].Item1.ToString("g");
                foreach(var snapshot in snapshots)foreach(var entry in snapshot.Item2){if(!IsCheckpoint(entry.Value)||GroupIdentity(entry.Value)!=selected)continue;if(!loaded.ContainsKey(entry.Key))loaded[entry.Key]=entry.Value;}
            }
            for(int n=1;n<=4;n++)if(loaded.ContainsKey("hero"+n))commands.Items.Add(new KeyValuePair<string,string>("Герой "+n,loaded["hero"+n]));
            commands.Items.Add(new KeyValuePair<string,string>("Начать после загрузки всех кодов","-start"));commands.SelectedIndex=0;
            status.Text=loaded.Count==0?"Коды пока не найдены. Они появятся в конце миссии; резервные копии есть в игре через F9. Положи EXE в папку Warcraft или выбери её кнопкой.":"Файлы найдены, последнее время: "+latest+". Сюжет и тайник уже включены. Показаны только коды одного завершения миссии.";
        }
        void Copy(){
            if(commands.SelectedItem==null)return;var item=(KeyValuePair<string,string>)commands.SelectedItem;
            try{Clipboard.SetText(item.Value,TextDataFormat.UnicodeText);status.Text="Скопировано: "+item.Key+". Переключись в Warcraft, открой чат, нажми Ctrl+V и Enter.";}catch(Exception e){MessageBox.Show("Не удалось скопировать: "+e.Message);}
        }
    }
}
