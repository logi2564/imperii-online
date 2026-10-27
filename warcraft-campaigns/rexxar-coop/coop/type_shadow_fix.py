"""A single candidate with only two identifier fixes versus native-rejected B.

The exact previous B script and all non-script data are pinned by hash. Thus
the candidate is not a new collection of unrelated lobby/archive changes.
"""
import argparse,hashlib,json,re,shutil,struct,tempfile,zipfile
from pathlib import Path
from storm import Storm
from formats import read_info,s
from lobby_probe import retitle

REJECTED_SCRIPT='f4b3de52ac5d294053d7b233788db7ef20ba1bc26a8e63f173d2583363d3ccd2'
REJECTED_DATA='20991a1263305f4e2c44426da3cc92c2dd8588f4f441658495a138b652f66627'
REJECTED_METADATA='a693e3d239005ee49401117e56b772686a46fbebdc7b9be98aede89e07be2f42'
TITLE='CHECK C - COOP FIX'
FILE='C-Coop-Fix.w3x'
README='''РЕКСАР — ИСПРАВЛЕНИЕ КОНФЛИКТОВ ИМЁН, КАРТА C

На Warcraft III 1.26.0.6401 пользователь проверил предыдущую пару:
A открывает локальное лобби, B не открывает. Значит, одинаковые данные карты
и настройки игроков пригодны для входа, а искать отказ нужно в полном скрипте.

Строгая проверка +shadow обнаружила в добавленном коде два имени, совпадающих
с типами Warcraft: параметр boolean dialog и локальная integer ability.
Они переименованы в showDialog и abilityId. Обычная проверка это пропускала.
Во всех 17 исходниках исправление одинаковое.

Этот файл C сохраняет полный код первой миссии. По отношению к проверенной B
меняются только эти два имени и подпись карты. Хеши доказывают совпадение
остального кода, настроек игроков, ландшафта, объектов и ресурсов.

ПРОВЕРКА НА ТВОЁМ WARCRAFT
1. Положи C-Coop-Fix.w3x в Warcraft III\\Maps\\Download.
2. «Локальная сеть → Создать игру → CHECK C - COOP FIX».
3. Сообщи, открылось ли лобби. Сначала нужен именно этот результат.
4. Если запустишь партию: ведущий выбирает сложность и вводит -start.

Это кандидат на исправление полного скрипта, а не пустая карта A.
Строгая проверка скриптов и перенос данных проверены автоматически.
Сам файл C в Warcraft/IrinaBot в облачной среде НЕ запускался. Что именно
вызывало отказ в нативном движке, подтвердит только этот запуск на клиенте.
Полное прохождение и перенос между всеми миссиями пока не подтверждены.
Для первоначальной проверки IrinaBot и новая загрузка боту не требуются.
'''

def title_config(script,title):
    return re.sub(r'(call SetMapName\(")[^"\n]*("\))',lambda m:m[1]+title+m[2],script)

def legacy_identifiers(script):
    """Reconstruct known rejected B, not an invented small negative example."""
    script=script.replace('function RC_Victory takes player p, boolean showDialog, boolean scores','function RC_Victory takes player p, boolean dialog, boolean scores')
    match=re.search(r'^function RC_Spell takes[\s\S]*?^endfunction',script,re.M)
    assert match is not None
    body,count=re.subn(r'\babilityId\b','ability',match[0]);assert count==5
    return script[:match.start()]+body+script[match.end():]

def data_digest(data):
    payload='\n'.join(n.lower()+':'+hashlib.sha256(data[n]).hexdigest() for n in sorted(data,key=str.lower) if n.lower() not in {'war3map.j','war3map.w3i'})
    return hashlib.sha256(payload.encode()).hexdigest()

def read_map(path):
    storm=Storm();archive=storm.open(path)
    try:
        names=[n for n in storm.read(archive,'(listfile)').decode().splitlines() if not n.startswith('(')]
        return {n:storm.read(archive,n) for n in names}
    finally:storm.close(archive)

def build(out):
    root=out/'type-fix';root.mkdir(exist_ok=True);source=out/'Maps/RX3-OrcX01.w3x';data=read_map(source)
    fixed=data['war3map.j'].decode();rejected=title_config(legacy_identifiers(fixed),'CHECK B - COOP')
    assert hashlib.sha256(rejected.encode()).hexdigest()==REJECTED_SCRIPT,'Unexpected changes versus the actual user-rejected B script'
    assert data_digest(data)==REJECTED_DATA,'Terrain/assets/objects differ from the known B'
    assert hashlib.sha256(retitle(data['war3map.w3i'],'SHARED')).hexdigest()==REJECTED_METADATA,'Lobby records differ from the known B'
    candidate=title_config(fixed,TITLE);info=retitle(data['war3map.w3i'],TITLE)
    target=root/FILE;shutil.copyfile(source,target);storm=Storm()
    with tempfile.TemporaryDirectory(prefix='rexxar-type-fix-') as tmp:storm.replace(target,{'war3map.j':candidate.encode(),'war3map.w3i':info},tmp)
    blob=bytearray(target.read_bytes());parsed=read_info(info);flags=struct.unpack_from('<I',parsed['prefix'],parsed['flags_offset'])[0]
    header=bytes(blob[:8])+s(TITLE)+struct.pack('<II',flags,4);blob[:512]=header+bytes(512-len(header));target.write_bytes(blob)
    (root/'candidate.j').write_text(candidate);(root/'rejected-B.j').write_text(rejected)
    (root/'ЧИТАЙ.txt').write_text(README)
    report=dict(status='native-candidate-result-pending',nativeWarcraftTested=False,liveIrinaBotTested=False,userReported={'version':'1.26.0.6401','AOpensLobby':True,'BOpensLobby':False},candidate=dict(file=FILE,title=TITLE,bytes=len(blob),sha256=hashlib.sha256(blob).hexdigest(),scriptSha256=hashlib.sha256(candidate.encode()).hexdigest()),rejectedBScriptSha256=REJECTED_SCRIPT,unchangedDataSha256=REJECTED_DATA,unchangedLobbyMetadataSha256=REJECTED_METADATA,changes=['RC_Victory parameter dialog -> showDialog','RC_Spell local ability -> abilityId','Identifying map title'])
    (root/'Type-fix.json').write_text(json.dumps(report,indent=2));return report

def package(source,out):
    out.mkdir(parents=True,exist_ok=True);archive=out/'Rexxar-Coop-Type-Fix.zip'
    with zipfile.ZipFile(archive,'w',zipfile.ZIP_DEFLATED) as z:
        for name in [FILE,'Type-fix.json','Type-fix-check.txt','ЧИТАЙ.txt']:z.write(source/name,name)
    with zipfile.ZipFile(archive) as z:assert z.testzip() is None
    (out/(archive.name+'.sha256')).write_text(hashlib.sha256(archive.read_bytes()).hexdigest()+'  '+archive.name+'\n')
    return dict(zipBytes=archive.stat().st_size,nativeWarcraftTested=False)

if __name__=='__main__':
    p=argparse.ArgumentParser();sub=p.add_subparsers(dest='command',required=True)
    b=sub.add_parser('build');b.add_argument('out',type=Path)
    b=sub.add_parser('package');b.add_argument('source',type=Path);b.add_argument('out',type=Path)
    a=p.parse_args();print(json.dumps(build(a.out) if a.command=='build' else package(a.source,a.out),indent=2))
