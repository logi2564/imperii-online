"""Create a controlled pair for the user's native lobby rejection.

Both use the same first-mission terrain/assets/objects/lobby records/config.
A replaces the complete gameplay script with a tiny entry-only main; B retains
the whole co-op script. Only the identifying titles and script differ. Neither
is described as a native-tested fix or as a replacement full campaign release.
"""
import argparse,hashlib,json,re,shutil,struct,tempfile,zipfile
from pathlib import Path
from formats import read_info,s
from storm import Storm

README='''ПРОВЕРКА ВХОДА РЕКСАРА — ДВА ФАЙЛА

RC3 у пользователя не открывает даже локальное лобби. Эта пара нужна, чтобы
локализовать отказ в настоящем Warcraft, а не выдавать ещё один пакет за готовое исправление.

1. Положи A-Entry.w3x и B-Coop.w3x в Warcraft III\\Maps\\Download.
2. «Локальная сеть → Создать игру»: сначала выбери CHECK A - ENTRY.
3. Затем так же проверь CHECK B - COOP. Достаточно появления лобби с местами.
   Запускать или проходить миссию для этой проверки не нужно.
4. Напиши результат: «A открывается / не открывается; B открывается / не открывается».

A — только вход, без героев и кампании. B — первая миссия с кодом кооператива.
Ландшафт, объекты и описание мест у них одинаковые; различаются весь игровой
скрипт и подписи, позволяющие различить файлы. В настройке обоих явно заданы
цвета всех игроков, как в обычном генерируемом World Editor коде. В RC3 эти
назначения отсутствовали. Это обнаруженное отличие, НЕ доказанная причина отказа.

Если A открывается, а B нет, отказ связан с загрузкой полного скрипта.
Если оба не открываются, искать нужно ниже: данные карты/архив/совместимость клиента.
Если оба открываются, новое описание входа пригодно на этом клиенте, но полное
прохождение кооператива этим ещё не проверено.

Сначала проверь локально, без IrinaBot. Его старые загруженные карты от этих
файлов не меняются. Для этого сравнения загружать ещё карты боту не требуется.
Нативный Warcraft и IrinaBot в облачной среде НЕ запускались. Коды сохранений
и старая RC3 сами по себе этой диагностической парой не заменяются.
'''

def retitle(data,title):
    info=read_info(data);a,b=info['title'];return data[:a]+s(title)+data[b:]

def main_script(config):
    return '''// Native entry control; intentionally no campaign/co-op code.
globals
endglobals
function main takes nothing returns nothing
    call InitBlizzard()
    call DisplayTimedTextToForce(GetPlayersAll(), 120.0, "CHECK A: entry only. No campaign gameplay is included.")
endfunction

'''+config+'\n'

def build(out):
    source=out/'Maps/RX3-OrcX01.w3x';root=out/'entrycheck';root.mkdir(exist_ok=True);(root/'scripts').mkdir(exist_ok=True)
    storm=Storm();a=storm.open(source)
    try:original_script=storm.read(a,'war3map.j').decode();original_info=storm.read(a,'war3map.w3i')
    finally:storm.close(a)
    config=re.search(r'^function config takes[\s\S]*?^endfunction',original_script,re.M)[0]
    if len(re.findall(r'call SetPlayerColor\(',config))!=len(read_info(original_info)['players']):raise ValueError('Canonical colour assignments missing')
    rows=[]
    for code,name,title in [('A','A-Entry.w3x','CHECK A - ENTRY'),('B','B-Coop.w3x','CHECK B - COOP')]:
        named_config=re.sub(r'call SetMapName\("[^"\n]*"\)',lambda _:'call SetMapName("'+title+'")',config)
        script=main_script(named_config) if code=='A' else original_script.replace(config,named_config)
        info=retitle(original_info,title);target=root/name;shutil.copyfile(source,target)
        with tempfile.TemporaryDirectory(prefix='rexxar-probe-') as temporary:storm.replace(target,{'war3map.j':script.encode(),'war3map.w3i':info},temporary)
        blob=bytearray(target.read_bytes());parsed=read_info(info);flags=struct.unpack_from('<I',parsed['prefix'],parsed['flags_offset'])[0]
        header=bytes(blob[:8])+s(title)+struct.pack('<II',flags,4);blob[:512]=header+bytes(512-len(header));target.write_bytes(blob)
        (root/'scripts'/(code+'.j')).write_text(script)
        rows.append(dict(code=code,file=name,title=title,bytes=target.stat().st_size,sha256=hashlib.sha256(blob).hexdigest(),scriptBytes=len(script.encode()),hasCoop=code=='B'))
    report=dict(status='native-comparison-required',nativeWarcraftTested=False,liveIrinaBotTested=False,sourceMapSha256=hashlib.sha256(source.read_bytes()).hexdigest(),maps=rows)
    (root/'Entry-check.json').write_text(json.dumps(report,indent=2));(root/'ЧИТАЙ.txt').write_text(README)
    return report

def package(source,out):
    out.mkdir(parents=True,exist_ok=True);archive=out/'Rexxar-Entry-Check.zip'
    with zipfile.ZipFile(archive,'w',zipfile.ZIP_DEFLATED) as z:
        for name in ['A-Entry.w3x','B-Coop.w3x','Entry-check.json','Entry-check.txt','ЧИТАЙ.txt']:
            z.write(source/name,name)
    with zipfile.ZipFile(archive) as z:assert z.testzip() is None
    (out/'Rexxar-Entry-Check.zip.sha256').write_text(hashlib.sha256(archive.read_bytes()).hexdigest()+'  '+archive.name+'\n')
    return dict(zipBytes=archive.stat().st_size,nativeWarcraftTested=False)

if __name__=='__main__':
    p=argparse.ArgumentParser();sub=p.add_subparsers(dest='command',required=True)
    b=sub.add_parser('build');b.add_argument('out',type=Path)
    b=sub.add_parser('package');b.add_argument('source',type=Path);b.add_argument('out',type=Path)
    a=p.parse_args();print(json.dumps(build(a.out) if a.command=='build' else package(a.source,a.out),indent=2))
