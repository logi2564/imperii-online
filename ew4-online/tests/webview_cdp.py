"""Drive the installed Android app's real WebView using page-level DevTools."""
from pathlib import Path
import base64,json,subprocess,time
class ScriptError(RuntimeError):
    def __init__(self,details):
        error=details.get('exception',{});kind=error.get('className','Error')
        self.kind=kind if kind in ['Error','TypeError','ReferenceError','SyntaxError','RangeError','EvalError','DOMException'] else 'Error'
        description=error.get('description','');self.hint='unclassified'
        for marker,hint in [('revision','stale_revision'),('状态已更新','stale_revision'),('обнов','stale_revision'),('selectCell is not a function','missing_controller'),('Сейчас ход другой','wrong_turn'),('Failed to fetch','network_error')]:
            if marker in description:self.hint=hint
        super().__init__('WebView script failed: '+self.kind)
class WebView:
    def __init__(self,url,log):
        self.process=subprocess.Popen(['node',str(Path(__file__).with_suffix('.cjs')),url],stdin=subprocess.PIPE,stdout=subprocess.PIPE,stderr=log,text=True,bufsize=1)
        self.sequence=0
        if not json.loads(self.process.stdout.readline()).get('ready'):raise RuntimeError('WebView debugger startup failed')
    def command(self,method,params=None):
        self.sequence+=1;self.process.stdin.write(json.dumps({'id':self.sequence,'method':method,'params':params or {}})+'\n');self.process.stdin.flush()
        result=json.loads(self.process.stdout.readline())
        if 'error' in result:raise RuntimeError('WebView debugger command failed: '+method)
        return result.get('result',{})
    def evaluate(self,expression):
        result=self.command('Runtime.evaluate',{'expression':expression,'awaitPromise':True,'returnByValue':True,'userGesture':True})
        if 'exceptionDetails' in result:raise ScriptError(result['exceptionDetails'])
        return result['result'].get('value')
    def wait(self,expression,seconds=90):
        until=time.monotonic()+seconds
        while time.monotonic()<until:
            if self.evaluate(expression):return
            time.sleep(.3)
        raise TimeoutError('WebView condition was not reached')
    def click(self,selector):self.evaluate('document.querySelector('+json.dumps(selector)+').click()')
    def select(self,selector,value):self.evaluate('(function(){var e=document.querySelector('+json.dumps(selector)+');e.value='+json.dumps(value)+';e.dispatchEvent(new Event("change",{bubbles:true}));})()')
    def screenshot(self,path):
        result=self.command('Page.captureScreenshot',{'format':'png','fromSurface':True})
        Path(path).write_bytes(base64.b64decode(result['data']))
    def close(self):
        try:self.process.stdin.close()
        except BrokenPipeError:pass
        try:self.process.wait(5)
        except subprocess.TimeoutExpired:self.process.terminate();self.process.wait(5)
