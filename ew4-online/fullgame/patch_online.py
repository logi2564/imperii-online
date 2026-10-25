"""Release 0.3.1: use bundled media online and keep turn controls seat-bound."""
from pathlib import Path
HERE=Path(__file__).resolve().parent

def patch(root):
 def edit(file,old,new):
  p=root/file;s=p.read_text(encoding='utf-8');assert s.count(old)==1,(file,old[:80]);p.write_text(s.replace(old,new),encoding='utf-8')
 web='rewrite/Ew4.Web/wwwroot/'
 # Share a protocol version so different APK/PC assets cannot silently disagree.
 edit('rewrite/Ew4.Web/OnlineRoom.cs','version = "0.3.0"','version = "0.3.1", protocol = 31')
 edit('rewrite/Ew4.Web/OnlineRoom.cs','context.Response.ContentType = path.EndsWith(".json")', 'context.Response.Headers.CacheControl="no-store";\n            context.Response.ContentType = path.EndsWith(".json")')
 edit('rewrite/Ew4.Web/Program.cs','var app = builder.Build();', '''builder.Services.AddResponseCompression(o => { o.EnableForHttps=true; o.MimeTypes=Microsoft.AspNetCore.ResponseCompression.ResponseCompressionDefaults.MimeTypes.Concat(["application/json"]); });
builder.Services.Configure<Microsoft.AspNetCore.ResponseCompression.BrotliCompressionProviderOptions>(o=>o.Level=System.IO.Compression.CompressionLevel.Fastest);
builder.Services.Configure<Microsoft.AspNetCore.ResponseCompression.GzipCompressionProviderOptions>(o=>o.Level=System.IO.Compression.CompressionLevel.Fastest);
var app = builder.Build();
app.UseResponseCompression();''')
 # No request waits forever. Never retry a mutating move/end automatically.
 edit(web+'app.js',"{method: 'POST', cache: 'no-store'}", "{method: 'POST', cache: 'no-store',signal:window.Ew4OnlineMode?window.ew4RequestSignal(20000):undefined}")
 edit(web+'app.js',"if(window.Ew4OnlineMode&&route==='action'&&args.op!=='state'&&!window.Ew4OnlineCanAct)","if(window.Ew4OnlineMode&&route==='action'&&args.op==='end'&&!window.Ew4OnlineCanEnd)throw Error('Дождись своего хода');\n  if(window.Ew4OnlineMode&&route==='action'&&args.op!=='state'&&!window.Ew4OnlineCanAct)")
 # Mobile renders at its CSS resolution; PC retains the existing surface cap.
 edit(web+'app.js','Math.min(window.devicePixelRatio||1,1.25,',"Math.min(window.devicePixelRatio||1,navigator.maxTouchPoints>0?1:1.25,")
 edit(web+'app.js','if(time-lastRenderTime<32)', 'if(time-lastRenderTime<(navigator.maxTouchPoints>0?42:32))')
 # Render region/year labels as Russian text rather than English image lettering.
 edit(web+'app.js',"for (const name of slot.labels||[]) {", "for (const name of window.Ew4Ru?[]:slot.labels||[]) {")
 edit(web+'menus.js',"b.append(this.api.uiImage('button_general_'+count+'.png',152,55));", "b.classList.add('native-command','blue');b.append(this.lettering(['1 звезда','2 звезды','3 звезды'][rating],'font_text_3_cn_hd','#ebe6e1',145,'center',{singleLine:true}));")
 edit(web+'menus.js',"else b.append(this.api.uiImage('button_general_'+[6,4,2][rating]+'.png',110,40));", "else{b.classList.add('native-command','blue');b.append(this.lettering(['1 звезда','2 звезды','3 звезды'][rating],'font_text_3_cn_hd','#ebe6e1',105,'center',{singleLine:true}));}")
 # Keep installed-game assets local even when the page/API use a friend's origin.
 activity='rewrite/Ew4.Android/MainActivity.cs'
 edit(activity,'private sealed class LocalClient(Func<string, byte[]> read, Lazy<ModStore> store, Func<string?> peer) : WebViewClient\n    {', 'private sealed class LocalClient(Func<string, byte[]> read, Lazy<ModStore> store, Func<string?> peer) : WebViewClient\n    {\n        internal static int BundledMedia, RemoteMediaFallback;')
 edit(activity,'                if (!path.StartsWith("/content/", StringComparison.Ordinal)) bytes', '                if(remote&&path.StartsWith("/content/",StringComparison.Ordinal))Interlocked.Increment(ref BundledMedia);\n                if (!path.StartsWith("/content/", StringComparison.Ordinal)) bytes')
 edit(activity,'[JavascriptInterface,Java.Interop.Export("quit")]public void Quit()=>activity.RunOnUiThread(()=>activity.ConfirmExit());', '[JavascriptInterface,Java.Interop.Export("quit")]public void Quit()=>activity.RunOnUiThread(()=>activity.ConfirmExit());\n#if EW4_DIAGNOSTICS\n        [JavascriptInterface,Java.Interop.Export("stats")]public string Stats()=>System.Text.Json.JsonSerializer.Serialize(new {bundledMedia=LocalClient.BundledMedia,remoteMediaFallback=LocalClient.RemoteMediaFallback});\n#endif')
 edit(activity,'        web = new WebView(this);','        Window?.AddFlags(WindowManagerFlags.KeepScreenOn);\n        web = new WebView(this);')
 edit(activity,'        peerOrigin=uri.GetLeftPart(UriPartial.Authority);web.LoadUrl(peerOrigin+"/native#join="+token);','''        var nextOrigin=uri.GetLeftPart(UriPartial.Authority);
        _=Task.Run(async()=>{try {
            using var http=new HttpClient {Timeout=TimeSpan.FromSeconds(20)};
            using var health=System.Text.Json.JsonDocument.Parse(await http.GetStringAsync(nextOrigin+"/health"));
            if(!health.RootElement.TryGetProperty("protocol",out var protocol)||protocol.GetInt32()!=31)throw new InvalidOperationException("Обновите игру на ПК и телефоне до 0.3.1");
            RunOnUiThread(()=>{peerOrigin=nextOrigin;web?.LoadUrl(peerOrigin+"/native#join="+token);});
        }catch(Exception error){RunOnUiThread(()=>{string message=error is InvalidOperationException?error.Message:"Не удалось связаться с ПК. Проверь интернет и попроси свежий код приглашения.";web?.EvaluateJavascript("window.ew4JoinFailed?.("+System.Text.Json.JsonSerializer.Serialize(message)+")",null);});}});''')
 edit(activity,'[JavascriptInterface,Java.Interop.Export("home")]public void Home()=>activity.Home();','''[JavascriptInterface,Java.Interop.Export("home")]public void Home()=>activity.Home();
        [JavascriptInterface,Java.Interop.Export("paste")]public string Paste(){
            var result=new TaskCompletionSource<string>();activity.RunOnUiThread(()=>{
                if(activity.web?.Url?.StartsWith("https://ew4.local/",StringComparison.Ordinal)!=true){result.TrySetResult("");return;}
                var clipboard=activity.GetSystemService(ClipboardService) as global::Android.Content.ClipboardManager;
                result.TrySetResult(clipboard?.PrimaryClip?.GetItemAt(0)?.CoerceToText(activity)?.ToString()??"");
            });return result.Task.Wait(TimeSpan.FromSeconds(2))?result.Task.Result:"";
        }''')
 # Remote state stays authoritative. Only immutable game files come from the APK.
 edit(activity,'if (uri?.Host != "ew4.local") return Allowed(uri?.ToString())?null:Response("text/plain","Запрос заблокирован",403);', '''bool remote=uri?.Host!="ew4.local";
            if(remote&&!Allowed(uri?.ToString()))return Response("text/plain","Запрос заблокирован",403);
            if(remote&&(uri!.EncodedPath!.StartsWith("/online/",StringComparison.Ordinal)||uri.EncodedPath.StartsWith("/api/",StringComparison.Ordinal)||uri.EncodedPath=="/health"))return null;''')
 edit(activity,'string path = Uri.UnescapeDataString(uri.EncodedPath ?? "/");', '''string path = Uri.UnescapeDataString(uri!.EncodedPath ?? "/");
            if(remote&&path is "/native" or "/game")path=path=="/native"?"/native.html":"/index.html";''')
 edit(activity,'                global::Android.Util.Log.Error("EW4", "Local request failed " + path + ": " + error);','''                if(remote&&error is IOException or Java.IO.IOException){if(path.StartsWith("/content/",StringComparison.Ordinal))Interlocked.Increment(ref RemoteMediaFallback);return null;}
                global::Android.Util.Log.Error("EW4", "Local request failed " + path + ": " + error);''')
 edit(activity,'org.logi2564.ew4fullgame.GameActivity','org.logi2564.ew4fullgame.r31.GameActivity')
 edit('rewrite/Ew4.Android/Ew4.Android.csproj','<ApplicationId>org.logi2564.ew4fullgame</ApplicationId>','<ApplicationId>org.logi2564.ew4fullgame.r31</ApplicationId>')
 edit('rewrite/Ew4.Android/Ew4.Android.csproj','<ApplicationTitle>Европейская война 4</ApplicationTitle>','<ApplicationTitle>EW4 Наполеон 0.3.1</ApplicationTitle>')
 edit(activity,'Label = "Европейская война 4"','Label = "EW4 Наполеон 0.3.1"')
 edit('rewrite/Ew4.Android/Ew4.Android.csproj','<ApplicationVersion>30</ApplicationVersion>','<ApplicationVersion>31</ApplicationVersion>')
 edit('rewrite/Ew4.Android/Ew4.Android.csproj','<ApplicationDisplayVersion>0.3.0</ApplicationDisplayVersion>','<ApplicationDisplayVersion>0.3.1</ApplicationDisplayVersion>')
