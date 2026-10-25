"""Install the full offline game on both platforms without replacing original data hashes."""
from pathlib import Path
import sys,json,re,shutil,subprocess
HERE=Path(__file__).resolve().parent;BASE=HERE.parent
sys.path.insert(0,str(BASE));from apply_overlay import apply
sys.path.insert(0,str(HERE));from build_locale import build

def full(root):
 for relative in ['rewrite/Ew4.Client/ClientContent.cs','rewrite/Ew4.Web/wwwroot/menus.js','rewrite/Ew4.Web/wwwroot/battlefield.js','rewrite/Ew4.Android/MainActivity.cs','rewrite/Ew4.Android/Ew4.Android.csproj','rewrite/Ew4.Android/Properties/AndroidManifest.xml']:
  (root/relative).write_bytes(subprocess.check_output(['git','-C',str(root),'show','HEAD:'+relative]))
 apply(root)
 def edit(relative,old,new):
  p=root/relative;s=p.read_text()
  if s.count(old)!=1:raise ValueError('Full-game patch missing or ambiguous: '+relative+' '+old[:80])
  p.write_text(s.replace(old,new))
 web='rewrite/Ew4.Web/wwwroot/'
 # Offline single-player uses an independent engine and save directory on Windows.
 program=root/'rewrite/Ew4.Web/Program.cs';s=program.read_text()
 s=s.replace('app.Use(onlineRoom.Handle);','''var solo = new Lazy<ModStore>(() => new ModStore(store.Base, Path.Combine(saves,"single-mods"), Path.Combine(saves,"single")));
app.Use(async (context,next) => {
    string path=context.Request.Path.Value ?? "/";
    if(path.StartsWith("/solo-api/",StringComparison.Ordinal)) {
        string host=context.Request.Host.Host;
        if(host is not ("localhost" or "127.0.0.1" or "[::1]") || (context.Request.Headers.Origin.Count>0 && context.Request.Headers.Origin!="http://"+context.Request.Host)) {context.Response.StatusCode=403;return;}
        string body=context.Request.Query["q"].FirstOrDefault() ?? await new StreamReader(context.Request.Body).ReadToEndAsync();
        context.Response.ContentType="application/json; charset=utf-8";context.Response.Headers.CacheControl="no-store";
        await context.Response.WriteAsync(solo.Value.Dispatch("/api/"+path[10..],body));return;
    }
    if(path=="/single") {context.Request.Path="/";await next(context);return;}
    await onlineRoom.Handle(context,next);
});''')
 # /single must reach the original frontend directly rather than the multiplayer lobby.
 s=s.replace('if(path=="/single") {context.Request.Path="/";await next(context);return;}','''if(path=="/single") {context.Response.ContentType="text/html; charset=utf-8";context.Response.Headers.CacheControl="no-store";await context.Response.Body.WriteAsync(store.Frontend(File.ReadAllBytes(Path.Combine(frontend,"index.html")),".html"));return;}''')
 program.write_text(s)
 # Restore only when the user explicitly opens multiplayer, never on process startup.
 p=root/'rewrite/Ew4.Web/OnlineRoom.cs';s=p.read_text();start=s.index('        if (config.Scenario != null) choices =');end=s.index('\n    private void Persist()',start)
 restore=s[start:end];restore=restore[:restore.rfind('\n    }')]
 s=s[:start]+'    }\n    private bool restored;\n    private void EnsureRestored() { lock(gate) { if(restored)return;restored=true;\n'+restore+'\n    }}\n'+s[end:]
 marker='        object? response = null; int status = 200;';s=s.replace(marker,'        EnsureRestored();\n'+marker);s=s.replace('version = "0.2.0"','version = "0.3.0"');p.write_text(s)
 # Full single-player and network mode share graphics, but never state or RPC routes.
 edit(web+'app.js',"fetch('/api/' + route", "fetch((!window.Ew4OnlineMode&&location.hostname!=='ew4.local'?'/solo-api/':'/api/') + route")
 p=root/(web+'online-client.js');s=p.read_text();p.write_text("if(location.pathname==='/game'||new URLSearchParams(location.search).get('online')==='1'){\n"+s+"\n}else{window.Ew4OnlineMode=false;}\n")
 p=root/(web+'native.js');s=p.read_text().replace("autoEnter=true","autoEnter=false").replace("'/game?native=1'","'/game?native=1&online=1&renderer=canvas'")
 s=s.replace("action('solo',()=>setup('solo'));","action('solo',async()=>{if(window.Ew4Desktop)await Ew4Desktop.home();else window.Ew4App?.home();});")
 s=s.replace("$('fullscreen').onclick=()=>window.Ew4Desktop?.fullscreen();$('exit').onclick=()=>window.Ew4Desktop?.quit();","$('fullscreen').onclick=()=>window.Ew4Desktop?.fullscreen();$('exit').onclick=()=>{if(window.Ew4Desktop)Ew4Desktop.quit();else window.Ew4App?.home();};")
 s=s.replace("if(token){await api('login'", "autoEnter=hash.has('join');if(token){await api('login'")
 p.write_text(s)
 # No WebGL probe or driver initialization. A bounded 2D surface and 30 Hz animation.
 edit(web+'app.js','hd:true,screen:100','hd:false,screen:100')
 edit(web+'app.js',"settings.followAi=settings.followAi===true;","settings.followAi=settings.followAi===true;\nsettings.cityLanguage='ru';settings.geographicLanguage='ru';")
 edit(web+'app.js','  renderDirty=false;lastRenderTime=time;',"  if(time-lastRenderTime<32){renderRequest=requestAnimationFrame(render);return;}\n  renderDirty=false;lastRenderTime=time;")
 edit(web+'app.js','Math.min(window.devicePixelRatio||1,3,','Math.min(window.devicePixelRatio||1,1.25,')
 edit(web+'app.js',"const text=translated?.name===name?translated[settings.cityLanguage]:Ew4MenuArt.cityName(name,settings.cityLanguage,cityNames);","const text=window.Ew4Ru?.cities?.[String(name).toUpperCase()]||(translated?.name===name?translated.en:Ew4MenuArt.cityName(name,'en',cityNames));")
 edit(web+'app.js',"const languageControls=[['city-language','cityLanguage','城市名称'],['geographic-language','geographicLanguage','地理名称']];","const languageControls=[];")
 # One compact Latin/Cyrillic font replaces 53 MB of unrelated Chinese font subsets.
 edit(web+'original-ui.js',"const mapFamilies=['EW4 Kai'","const mapFamilies=window.Ew4Ru?['EW4 Russian']:['EW4 Kai'")
 edit(web+'original-ui.js',"const families=window.Ew4Ru?['EW4 Russian','EW4 UI Latin','EW4 UI Kai',...mapFamilies]","const families=window.Ew4Ru?['EW4 Russian']")
 edit(web+'original-ui.js','  async function prepareText(value,preferred=families){','  async function prepareText(value,preferred=families){\n    if(root.Ew4Ru)return;')
 edit(web+'original-ui.js','  async function prepareFonts(){', '''  async function prepareFonts(){
    if(root.Ew4Ru){
      if(!fontPreparation)fontPreparation=(async()=>{await root.Ew4Ru.ready;const face=new FontFace('EW4 Russian','url("/native-font.ttf")');await face.load();document.fonts.add(face);glyphRanges=[[32,1114111]];coverage={faces:[],ranges:glyphRanges};document.documentElement.dataset.fontsReady='true';})();
      await fontPreparation;return;
    }''')
 edit(web+'original-ui.js',"      if(root.Ew4Ru){await root.Ew4Ru.ready;const face=new FontFace('EW4 Russian','url(\"/native-font.ttf\")');await face.load();document.fonts.add(face);}\n",'')
 edit(web+'original-ui.js','return root.Ew4Ru&&point>=32&&point<0x0530||','return root.Ew4Ru&&point>=32||')
 edit(web+'native-locale.js','get labels(){return data.labels;}', 'get labels(){return data.labels;},get cities(){return data.cities||{};}')
 # Translate geographic lettering rather than reusing English artwork labels.
 p=root/(web+'battlefield.js');s=p.read_text();s=s.replace("const chinese=this.api.geographicLanguage==='zh'&&label.textZh;","const russian=this.api.geographicLanguage==='ru';const labelText=russian?window.Ew4Ru.text(label.textZh||''):label.textZh;const chinese=(russian||this.api.geographicLanguage==='zh')&&labelText;")
 s=s.replace("(chinese?'zh':'en')","(chinese?this.api.geographicLanguage:'en')").replace('prepareMapText(label.textZh','prepareMapText(labelText').replace('availableText(label.textZh)','availableText(labelText)');p.write_text(s)
 edit(web+'menus.js',"b.append(this.api.uiImage(placement.frm1,Number(placement.w),Number(placement.h)));","b.append(this.lettering(chapter.name,'font_text_2_cn_hd','#343929',Number(placement.w)-8,'center',{singleLine:true}));")
 edit(web+'native-locale.js',"title.append('European War 4'","title.append('Европейская война 4'")
 edit(web+'native-locale.js',"sub.textContent='Napoleon'","sub.textContent='Наполеон'")
 edit(web+'original-ui.js','      for(const char of value){',"      if(root.Ew4Ru&&!options.singleLine&&Number.isFinite(limit)){\n        let wrapped='',used=0,space='';\n        for(const word of value.match(/\\n|[^\\S\\n]+|[^\\s]+/g)||[]){\n          if(word==='\\n'){wrapped+='\\n';used=0;space='';continue;}\n          if(/^\\s+$/.test(word)){space=word;continue;}\n          const size=[...word].reduce((sum,c)=>sum+advance(c),0),gap=[...space].reduce((sum,c)=>sum+advance(c),0);\n          if(used&&used+gap+size>limit&&size<=limit){wrapped+='\\n';used=0;space='';}\n          if(used){wrapped+=space;used+=gap;}wrapped+=word;used+=size;space='';\n        }\n        value=wrapped;\n      }\n      for(const char of value){")
 # The game text changes at the display layer only; runtime source fingerprints stay valid.
 edit('rewrite/Ew4.Client/ClientContent.cs','return reader.ReadToEnd();', 'string text=reader.ReadToEnd();return name=="stringtable_cn.ini"?RussianGameText.Apply(text):text;')
 index=root/(web+'index.html');s=index.read_text().replace('<html lang="zh-CN">','<html lang="ru">').replace('<title>欧陆战争4</title>','<title>Европейская война 4 — Наполеон</title>')
 s=s.replace('<script src="native-locale.js"></script>', '<script src="native-locale.js"></script>\n<script src="full-controls.js" defer></script>')
 s=s.replace('</head>','<link rel="stylesheet" href="full-game.css"></head>');index.write_text(s)
 for name in ['full-controls.js','full-game.css']:shutil.copyfile(HERE/name,root/(web+name))
 shutil.copyfile(BASE/'localization/DejaVu-LICENSE.txt',root/(web+'DejaVu-LICENSE.txt'))
 # Android includes the actual C# game engine, every campaign/map and all game media.
 p=root/'rewrite/Ew4.Android/MainActivity.cs';s=subprocess.check_output(['git','-C',str(root),'show','HEAD:rewrite/Ew4.Android/MainActivity.cs'],text=True)
 s=s.replace('[Activity(Label = "欧陆战争4 重构",','[Activity(Name="org.logi2564.ew4fullgame.GameActivity", Label = "Европейская война 4",')
 s=s.replace('    private WebView? web;','    private WebView? web;\n    private string? peerOrigin;\n    private GameBridge? gameBridge;')
 s=s.replace('web.SetWebViewClient(new LocalClient(Read, store));','web.SetWebViewClient(new LocalClient(Read, store, () => peerOrigin));\n        gameBridge=new GameBridge(this);web.AddJavascriptInterface(gameBridge,"Ew4App");')
 s=s.replace('web.LoadUrl("https://ew4.local/index.html");','web.LoadUrl("https://ew4.local/index.html?native=1&renderer=canvas");')
 s=s.replace('private void NavigateBack() => web?.EvaluateJavascript("window.ew4Back?.()", new BackResult(this));','''private void NavigateBack() { if(peerOrigin!=null){Home();return;}web?.EvaluateJavascript("window.ew4Back?.()",new BackResult(this)); }
    private void Home(){RunOnUiThread(()=>{peerOrigin=null;web?.LoadUrl("https://ew4.local/index.html?native=1&renderer=canvas");});}
    private void Join(string code){RunOnUiThread(()=>{try{
        if(web?.Url?.StartsWith("https://ew4.local/",StringComparison.Ordinal)!=true||!code.StartsWith("EW4-")||code.Length>1800)throw new FormatException();
        string encoded=code[4..].Replace('-','+').Replace('_','/');encoded=encoded.PadRight((encoded.Length+3)/4*4,'=');
        using var data=System.Text.Json.JsonDocument.Parse(Convert.FromBase64String(encoded));
        var uri=new Uri(data.RootElement.GetProperty("u").GetString()!);string token=data.RootElement.GetProperty("t").GetString()!;
        if(uri.Scheme!="https"||!uri.Host.EndsWith(".trycloudflare.com",StringComparison.Ordinal)||!uri.IsDefaultPort||uri.UserInfo.Length!=0||uri.AbsolutePath!="/"||uri.Query.Length!=0||!System.Text.RegularExpressions.Regex.IsMatch(token,"^[A-Fa-f0-9]{64}$"))throw new FormatException();
        peerOrigin=uri.GetLeftPart(UriPartial.Authority);web.LoadUrl(peerOrigin+"/native#join="+token);
    }catch(Exception){Toast.MakeText(this,"Нужен полный код приглашения EW4-…",ToastLength.Long)?.Show();}});}
    private sealed class GameBridge(MainActivity activity):Java.Lang.Object {
        [JavascriptInterface,Java.Interop.Export("join")]public void Join(string code)=>activity.Join(code);
        [JavascriptInterface,Java.Interop.Export("home")]public void Home()=>activity.Home();
        [JavascriptInterface,Java.Interop.Export("quit")]public void Quit()=>activity.RunOnUiThread(()=>activity.ConfirmExit());
    }''')
 s=s.replace('退出游戏？','Выйти из игры?').replace('取消','Отмена').replace('退出','Выход')
 s=s.replace('        web?.RemoveJavascriptInterface("Ew4ModImport");','        web?.RemoveJavascriptInterface("Ew4App");gameBridge?.Dispose();gameBridge=null;\n        web?.RemoveJavascriptInterface("Ew4ModImport");')
 s=s.replace('private sealed class LocalClient(Func<string, byte[]> read, Lazy<ModStore> store)', 'private sealed class LocalClient(Func<string, byte[]> read, Lazy<ModStore> store, Func<string?> peer)')
 s=s.replace('public override bool ShouldOverrideUrlLoading(WebView? view, IWebResourceRequest? request) => request?.Url?.Host != "ew4.local";', '''public override bool ShouldOverrideUrlLoading(WebView? view, IWebResourceRequest? request) => !Allowed(request?.Url?.ToString());
        private bool Allowed(string? url)=>Uri.TryCreate(url,UriKind.Absolute,out var value)&&value.Scheme=="https"&&(value.Host=="ew4.local"||value.GetLeftPart(UriPartial.Authority)==peer());''')
 s=s.replace('if (uri?.Host != "ew4.local") return Response("text/plain", "External request blocked", 403);','if (uri?.Host != "ew4.local") return Allowed(uri?.ToString())?null:Response("text/plain","Запрос заблокирован",403);')
 p.write_text(s)
 p=root/'rewrite/Ew4.Android/Ew4.Android.csproj';s=p.read_text().replace('org.ew4.reconstruction','org.logi2564.ew4fullgame').replace('欧陆战争4 重构','Европейская война 4').replace('<ApplicationVersion>22</ApplicationVersion>','<ApplicationVersion>30</ApplicationVersion>').replace('<ApplicationDisplayVersion>0.2.19</ApplicationDisplayVersion>','<ApplicationDisplayVersion>0.3.0</ApplicationDisplayVersion>');s=s.replace('<Import Project="../Frontend.Build.targets" />','<ItemGroup><AndroidAsset Remove="../data/client/fonts/parts/**/*" /></ItemGroup><Import Project="../Frontend.Build.targets" />');p.write_text(s)
 p=root/'rewrite/Ew4.Android/Properties/AndroidManifest.xml';s=p.read_text().replace('欧陆战争4 重构','Европейская война 4');p.write_text(s)
 report=build(root);(root/(web+'full-locale-report.json')).write_text(json.dumps(report,indent=2)+'\n');print(json.dumps(report,indent=2))

if __name__=='__main__':full(Path(sys.argv[1]).resolve())
