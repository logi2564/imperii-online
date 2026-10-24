"""Apply our networking additions to the exact, isolated upstream checkout."""
from pathlib import Path
import argparse, json, shutil, subprocess

HERE = Path(__file__).resolve().parent
def apply(root):
    pin = json.loads((HERE / 'UPSTREAM.json').read_text())['commit']
    actual = subprocess.check_output(['git', '-C', str(root), 'rev-parse', 'HEAD'], text=True).strip()
    if actual != pin:
        raise SystemExit('Wrong upstream revision: ' + actual)
    def original(path):
        return subprocess.check_output(['git', '-C', str(root), 'show', pin + ':' + path]).decode('utf-8-sig')
    def replace(text, old, new):
        if text.count(old) != 1:
            raise ValueError('Upstream hook is missing or ambiguous: ' + old[:80])
        return text.replace(old, new)
    def write(path, text):
        (root / path).write_text(text, encoding='utf-8')
    client = 'rewrite/Ew4.Client/ClientGame.cs'
    write(client, replace(original(client), '"/api/action" => Action(Command(body)),',
          '"/api/action" => Action(Command(body)),\n                    "/api/online-state" => NetworkView(Command(body)),'))
    program = 'rewrite/Ew4.Web/Program.cs'
    server = original(program).replace('1024L * 1024 * 1024', '64 * 1024')
    server = replace(server, 'var app = builder.Build();', '''var app = builder.Build();
var onlineRoom = new OnlineRoom(store, saves, frontend);
app.Use(onlineRoom.Handle);
_ = onlineRoom.RunAi(app.Lifetime.ApplicationStopping);''')
    write(program, server)
    app_path = 'rewrite/Ew4.Web/wwwroot/app.js'
    app = original(app_path)
    app = replace(app, 'async function showMain() {', '''async function showMain() {
  if(window.Ew4OnlineMode&&state){parent.postMessage({type:'ew4-lobby'},location.origin);return;}''')
    app = replace(app, 'function runAi() {', '''function runAi() {
  if(window.Ew4OnlineMode)return Promise.resolve();''')
    app = replace(app, 'async function rpc(route, args = {}) {', '''async function rpc(route, args = {}) {
  if(window.Ew4OnlineMode&&route==='action'&&args.op!=='state'&&!window.Ew4OnlineCanAct)throw Error('Сейчас ход другой страны');''')
    app = replace(app, "if (!response.ok) throw Error('连接失败 (' + response.status + ')');", '''if (!response.ok) {const error=await response.json().catch(()=>({}));throw Error(error.message||error.error||'Нет связи с создателем игры');}''')
    app = replace(app, "if ((!restore&&busy) || !state || cell < 0", "if ((window.Ew4OnlineMode&&!window.Ew4OnlineCanAct) || (!restore&&busy) || !state || cell < 0")
    app = replace(app, "    Ew4Startup.pending('游戏目录与资源索引');", "    await window.Ew4Ru?.ready;\n    Ew4Startup.pending('游戏目录与资源索引');")
    app = replace(app, "if(['localhost','127.0.0.1','[::1]'].includes(location.hostname)){", "if(!window.Ew4Ru&&['localhost','127.0.0.1','[::1]'].includes(location.hostname)){")
    app += '''\n// Network adapter: imported worlds are full snapshots for this particular seat.
window.Ew4OnlineGame={
 ready:()=>startupReady&&!startupRunning,
 busy:()=>busy||aiRunning||sessionTransition,
 revision:()=>state?.revision,
 enter:async next=>{
  if(busy||sessionTransition)return false;
  busy=true;
  try{
   const first=!state;await installState(next,first);
   $('menu').hidden=true;$('play').hidden=false;$('pause').hidden=true;
   stageIntroOpen=false;tutorial=null;refreshHud();requestRender();return true;
  }finally{busy=false;refreshHud();}
 },
 end:()=>act('end'),
 pause:()=>{parent.postMessage({type:'ew4-lobby'},location.origin);}
};
'''
    write(app_path, app)
    index_path = 'rewrite/Ew4.Web/wwwroot/index.html'
    index = replace(original(index_path), '<script src="startup.js?v=20261021.1"></script>',
                    '<script src="native-locale.js"></script>\n  <script src="online-client.js"></script>\n  <script src="startup.js?v=20261021.1"></script>')
    write(index_path, index)
    renderer_path = 'rewrite/Ew4.Web/wwwroot/original-ui.js'
    renderer = original(renderer_path)
    renderer = replace(renderer, "const families=['EW4 UI Latin','EW4 UI Kai',...mapFamilies];", "const families=window.Ew4Ru?['EW4 Russian','EW4 UI Latin','EW4 UI Kai',...mapFamilies]:['EW4 UI Latin','EW4 UI Kai',...mapFamilies];")
    renderer = replace(renderer, 'const point=char.codePointAt(0);\n      if(!glyphRanges', 'const point=char.codePointAt(0);\n      if(root.Ew4Ru&&point>=32&&point<0x0530)return char;\n      if(!glyphRanges')
    renderer = replace(renderer, "return /[\\r\\n\\t]/.test(char)||/\\p{Default_Ignorable_Code_Point}/u.test(char)||loadedFaces.some(face=>inRanges(point,face.ranges))?char:'\\ufffd';", "return root.Ew4Ru&&point>=32&&point<0x0530||/[\\r\\n\\t]/.test(char)||/\\p{Default_Ignorable_Code_Point}/u.test(char)||loadedFaces.some(face=>inRanges(point,face.ranges))?char:'\\ufffd';")
    renderer = replace(renderer, '    async prepare(){\n      await prepareFonts();', '''    async prepare(){
      if(root.Ew4Ru){await root.Ew4Ru.ready;const face=new FontFace('EW4 Russian','url("/native-font.ttf")');await face.load();document.fonts.add(face);}
      await prepareFonts();''')
    renderer = replace(renderer, "    layout(text,font,width=Infinity,options={}){", "    layout(text,font,width=Infinity,options={}){\n      if(root.Ew4Ru)text=root.Ew4Ru.text(text);")
    renderer = replace(renderer, "    element(text,font='font_text_2_cn_hd',color='#404040',width,align='left',options={}){", "    element(text,font='font_text_2_cn_hd',color='#404040',width,align='left',options={}){\n      if(root.Ew4Ru)text=root.Ew4Ru.text(text);")
    renderer = replace(renderer, '    prose(text,font,color,width){', '    prose(text,font,color,width){\n      if(root.Ew4Ru)text=root.Ew4Ru.text(text);')
    write(renderer_path, renderer)
    for file in (HERE / 'overlay').iterdir():
        if file.name == 'ClientNetworkView.cs': dest = root / 'rewrite/Ew4.Client' / file.name
        elif file.suffix == '.cs': dest = root / 'rewrite/Ew4.Web' / file.name
        else: dest = root / 'rewrite/Ew4.Web/wwwroot' / file.name
        shutil.copyfile(file, dest)
    print('Applied two-player online room to upstream', pin)

if __name__ == '__main__':
    parser = argparse.ArgumentParser();parser.add_argument('upstream', type=Path)
    apply(parser.parse_args().upstream.resolve())
