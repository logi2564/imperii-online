"""Add a classic 1.26 menu to the independently verified Russian base."""
import hashlib
import json
import re
import shutil
import subprocess
import sys
import tempfile
from pathlib import Path

HERE = Path(__file__).resolve().parent
ROOT = HERE.parent
sys.path.insert(0, str(ROOT/'tools'))
from catalog import encode_jass
from storm import Storm
from handbook import extract


def generated_data(data):
    lines = []
    def set_(name, index, value):
        if isinstance(value, str):
            assert len(value.encode()) <= 900
            value = encode_jass(value)
        lines.append(f'set {name}[{index}]={value}')
    for i, role in enumerate(data['roles']):
        set_('GGMRoleName', i, role)
    skill_id = text_id = about_id = 0
    aliases = {}
    for i, hero in enumerate(data['heroes']):
        lines.append(f"set GGMHeroRaw[{i}]='{hero['raw']}'")
        set_('GGMHeroName', i, hero['name'])
        set_('GGMHeroRole', i, hero['role'])
        set_('GGMHeroTavern', i, hero['tavern'])
        set_('GGMHeroAboutStart', i, about_id)
        set_('GGMHeroAboutCount', i, len(hero['about']))
        for text in hero['about']:
            set_('GGMHeroAbout', about_id, text)
            about_id += 1
        set_('GGMHeroSkillStart', i, skill_id)
        set_('GGMHeroSkillCount', i, len(hero['skills']))
        for raw in hero['aliases']:
            aliases.setdefault(raw, i)  # shared cosmetic forms resolve to the base hero
        for skill in hero['skills']:
            set_('GGMSkillName', skill_id, skill['title'])
            set_('GGMSkillTextStart', skill_id, text_id)
            set_('GGMSkillTextCount', skill_id, len(skill['pages']))
            for text in skill['pages']:
                set_('GGMSkillText', text_id, text)
                text_id += 1
            skill_id += 1
    for i, (raw, hero) in enumerate(aliases.items()):
        lines.append(f"set GGMAliasRaw[{i}]='{raw}'")
        set_('GGMAliasHero', i, hero)
    assert max(skill_id, text_id, about_id) < 8192
    functions = []
    names = []
    for first in range(0, len(lines), 80):
        name = f'GGMData{first//80}'
        names.append(name)
        functions.append(f'function {name} takes nothing returns nothing\n'+'\n'.join(lines[first:first+80])+'\nendfunction\n')
    init = f'set GGMHeroCount={len(data["heroes"])}\n'
    init += f'set GGMAliasCount={len(aliases)}\n'
    init += '\n'.join(f'call ExecuteFunc("{name}")' for name in names)
    return '\n'.join(functions), init, dict(heroes=len(data['heroes']), skills=skill_id,
                                         skillPages=text_id, heroPages=about_id, transformedHeroTypes=len(aliases))


def enhance(script, data):
    script = script.replace('\r\n', '\n')
    patches = []
    def patch(old, new, label):
        nonlocal script
        assert script.count(old) == 1, (label, script.count(old))
        script = script.replace(old, new, 1)
        patches.append(dict(label=label, before=old, after=new))
    def change_function(name, transform, label):
        match = re.search(r'^function '+name+r' takes .*?^endfunction', script, re.M|re.S)
        assert match, name
        patch(match[0], transform(match[0]), label)

    calls = re.findall(r'(?m)^call KB\([^\n]+,null\)$', script)
    assert len(calls) == 9
    for i, call in enumerate(calls):
        # JASS null has zero representation. Explicit false preserves that
        # branch while removing the inherited null -> boolean type errors.
        # Some statements repeat in different functions: replace by offset.
        script = script.replace(call, call[:-5]+'false)', 1)
        patches.append(dict(label=f'KB boolean argument {i+1}', before=call,
                            after=call[:-5]+'false)'))

    for name in ['Trig_kill_set_Team_Actions', 'Trig_kill_set_Epiccenter_Actions', 'Trig_kill_set_Banpick_Actions']:
        def score(body):
            line = next(v for v in body.splitlines() if v.startswith('set udg_killgoal='))
            return body.replace(line, 'if GGMGoalPending>0 then\nset udg_killgoal=GGMGoalPending\nelse\n'+line+'\nendif', 1)
        change_function(name, score, 'Button score input: '+name)

    def startup(body):
        body = body.replace('call QuestMessageBJ(bj_FORCE_ALL_PLAYERS,6,"|c00ff0000Красный игрок|r|c00ffff80, введите «epiccenter», затем «-12», чтобы начать игру.")',
                            'call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,8.,"Откройте меню: -menu. Навыки своего героя: -skills.")')
        return body.replace('\nendfunction', '\ncall ExecuteFunc("GGMStart")\nendfunction')
    change_function('Trig_Start_Actions', startup, 'Open menu after original startup')
    change_function('main', lambda body: body.replace('call ConditionalTriggerExecute(gg_trg_Load)', 'call ExecuteFunc("GGMInit")\ncall ConditionalTriggerExecute(gg_trg_Load)'), 'Register menu before loading original game')
    blank = 'set bj_forLoopAIndex=1\nset bj_forLoopAIndexEnd=14\nloop\nexitwhen bj_forLoopAIndex>bj_forLoopAIndexEnd\ncall BJDebugMsg(" ")\nset bj_forLoopAIndex=bj_forLoopAIndex+1\nendloop'
    patch(blank, '// GGM: removed fourteen empty messages.', 'Remove blank-message spam')
    change_function('Trig_kill_set_Team2_Actions', lambda body: body.replace('У вас есть 60 секунд, чтобы выбрать героя!.', 'Выбор героев открыт. Подтверждайте героя в каталоге; время выбора ограничено.'), 'Correct misleading arena selection countdown')

    module = (HERE/'main_menu.j').read_text()
    globals_, functions = module.split('// GGG_MENU_GLOBALS_END', 1)
    globals_ = globals_.replace('// GGG_MENU_GLOBALS_BEGIN', '')
    generated, init, counts = generated_data(data)
    functions = generated+'\n'+functions.replace('// GGG_DATA_INIT', init)
    global_block = '// GGM_GLOBALS_BEGIN\n'+globals_+'\n// GGM_GLOBALS_END\n'
    function_block = '// GGM_FUNCTIONS_BEGIN\n'+functions+'\n// GGM_FUNCTIONS_END\n'
    script = script.replace('endglobals', global_block+'endglobals', 1)
    script = script.replace('function main takes nothing returns nothing', function_block+'function main takes nothing returns nothing', 1)
    return script, patches, counts


def build(base_path, out_dir, pjass):
    base_path, out = Path(base_path), Path(out_dir)
    out.mkdir(parents=True, exist_ok=True)
    st = Storm()
    arc = st.open(base_path)
    try:
        names = st.read(arc, '(listfile)').decode().splitlines()
        data = extract(st, arc)
        base_script = st.read(arc, 'war3map.j').decode()
        info = st.read(arc, 'war3map.w3i')
        hashes = {name: hashlib.sha256(st.read(arc, name)).hexdigest() for name in names if not name.startswith('(')}
    finally:
        st.close(arc)
    script, patches, counts = enhance(base_script, data)
    path = out/'GGG-RU-MENU.w3x'
    shutil.copyfile(base_path, path)
    title = 'GGG RU MENU I'
    end = info.index(0, 12)
    info = info[:12]+title.encode()+info[end:]
    with tempfile.TemporaryDirectory(prefix='ggg-menu-') as d:
        st.replace(path, {'war3map.j': script.encode(), 'war3map.w3i': info}, d)
    raw = bytearray(path.read_bytes())
    old_end = raw.index(0, 8)
    header = raw[:8]+title.encode()+b'\0'+raw[old_end+1:old_end+9]
    raw[:512] = header+bytes(512-len(header))
    path.write_bytes(raw)
    (out/'Menu.j').write_text(script)
    # Undo every permitted source change to prove no unrelated game edits.
    restored = re.sub(r'(?ms)^// GGM_GLOBALS_BEGIN\n.*?^// GGM_GLOBALS_END\n', '', script)
    restored = re.sub(r'(?ms)^// GGM_FUNCTIONS_BEGIN\n.*?^// GGM_FUNCTIONS_END\n', '', restored)
    for patch in reversed(patches):
        assert patch['after'] in restored, patch['label']
        # Equal KB statements occur multiple times. Reversing in order still
        # restores the same statements exactly without touching other code.
        restored = restored.replace(patch['after'], patch['before'], 1)
    assert restored == base_script.replace('\r\n', '\n'), 'Unreviewed gameplay edit'
    ref = ROOT/'tests/reference'
    result = subprocess.run([str(pjass), '+shadow', str(ref/'common.j'), str(ref/'Blizzard.j'), str(out/'Menu.j')],
                            stdout=subprocess.PIPE, stderr=subprocess.STDOUT, text=True)
    (out/'Menu-compiler.txt').write_text(result.stdout)
    assert result.returncode == 0, result.stdout[-14000:]
    arc = st.open(path)
    try:
        for name, digest in hashes.items():
            blob = st.read(arc, name)
            assert blob is not None, name
            if name not in ('war3map.j', 'war3map.w3i'):
                assert hashlib.sha256(blob).hexdigest() == digest, name
        assert st.read(arc, 'war3map.j') == script.encode()
        assert st.read(arc, 'war3map.wts') is None
    finally:
        st.close(arc)
    report = dict(**counts, baseSha256=hashlib.sha256(base_path.read_bytes()).hexdigest(),
                  sha256=hashlib.sha256(path.read_bytes()).hexdigest(), bytes=path.stat().st_size,
                  nativeWarcraftTested=False, strictJassCompilerClean=True,
                  retainedFiles=len(hashes), assetAndObjectDataUnchanged=True,
                  repairedLegacyBooleanArguments=9,
                  patches=[p['label'] for p in patches],
                  unresolvedOriginalReferences=data['unresolvedOriginalReferences'])
    (out/'Menu-report.json').write_text(json.dumps(report, ensure_ascii=False, indent=2))
    (out/'Hero-handbook.json').write_text(json.dumps(data, ensure_ascii=False, indent=2))
    (out/'Source-patches.json').write_text(json.dumps(patches, ensure_ascii=False, indent=2))
    print(json.dumps(report, ensure_ascii=False))


if __name__ == '__main__':
    build(*sys.argv[1:4])
