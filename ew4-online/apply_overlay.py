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
                    '<script src="online-client.js"></script>\n  <script src="startup.js?v=20261021.1"></script>')
    write(index_path, index)
    for file in (HERE / 'overlay').iterdir():
        if file.name == 'ClientNetworkView.cs': dest = root / 'rewrite/Ew4.Client' / file.name
        elif file.suffix == '.cs': dest = root / 'rewrite/Ew4.Web' / file.name
        else: dest = root / 'rewrite/Ew4.Web/wwwroot' / file.name
        shutil.copyfile(file, dest)
    print('Applied two-player online room to upstream', pin)

if __name__ == '__main__':
    parser = argparse.ArgumentParser();parser.add_argument('upstream', type=Path)
    apply(parser.parse_args().upstream.resolve())
