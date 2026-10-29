"""Execute the actual generated menu JASS against deterministic native stubs.

This verifies menu transitions, data coverage and multiplayer permissions.
It is deliberately not reported as a native Warcraft rendering/network test.
"""
import json
import re
import sys
from collections import defaultdict
from pathlib import Path

STR = re.compile(r'"(?:[^"\\]|\\.)*"')


def expression(text):
    strings = []
    def protect(match):
        strings.append(match[0])
        return f'__LITERAL_{len(strings)-1}__'
    text = STR.sub(protect, text)
    for old, new in [('null', 'None'), ('true', 'True'), ('false', 'False')]:
        text = re.sub(r'\b'+old+r'\b', new, text)
    text = re.sub(r'\bfunction (\w+)', r'\1', text)
    for i, value in enumerate(strings):
        text = text.replace(f'__LITERAL_{i}__', value)
    return text


def transpile(source, global_names):
    lines = []
    depth = 0
    for line in source.splitlines():
        line = line.strip()
        if not line or line.startswith('//'):
            continue
        if line.startswith('function '):
            name, arguments = re.match(r'function (\w+) takes (.*?) returns \w+', line).groups()
            params = [] if arguments == 'nothing' else [v.strip().split()[-1] for v in arguments.split(',')]
            lines.append(f'def {name}({",".join(params)}):')
            depth = 1
            lines.append('    global '+','.join(global_names))
            continue
        if line == 'endfunction':
            depth = 0
            continue
        if line in ('endif', 'endloop'):
            depth -= 1
            continue
        if line.startswith('elseif '):
            depth -= 1
            line = 'elif '+expression(line[7:-5])+':'
        elif line == 'else':
            depth -= 1
            line = 'else:'
        elif line.startswith('if '):
            line = 'if '+expression(line[3:-5])+':'
        elif line == 'loop':
            line = 'while True:'
        elif line.startswith('exitwhen '):
            line = 'if '+expression(line[9:])+': break'
        else:
            line = re.sub(r'^local \w+ ', '', line)
            line = re.sub(r'^(?:set|call) ', '', line)
            line = expression(line)
        lines.append('    '*depth+line)
        if line.endswith(':'):
            depth += 1
    return '\n'.join(lines)


class NativeModel:
    def __init__(self):
        self.state = {}
        self.next_button = 1
        self.player = 0
        self.clicked = None
        self.active = {0, 1}
        self.orders = []
        self.triggers = []
        self.notices = []
        self.disabled = set()
        self.world = []
        self.selections = []
        self.max_buttons = 0
        self.max_title = 0

    def dialog(self):
        return dict(buttons=[], visible=False, title='')

    def add(self, dialog, label, key):
        button = self.next_button
        self.next_button += 1
        dialog['buttons'].append((button, label))
        self.max_buttons = max(self.max_buttons, len(dialog['buttons']))
        assert len(dialog['buttons']) <= 12
        return button

    def message(self, dialog, title):
        self.max_title = max(self.max_title, len(title.encode()))
        assert len(title.encode()) <= 1023
        dialog['title'] = title

    def trigger(self, trigger):
        self.triggers.append(trigger)
        if trigger == 'gg_trg_Mode_Team':
            self.state['udg_System_Gamemode'] = 1
        elif trigger == 'gg_trg_Mode_Epiccenter':
            self.state['udg_System_Gamemode'] = 2
        elif trigger == 'gg_trg_Mode_Banpick':
            self.state['udg_System_Gamemode'] = 1
            self.state['udg_Banpickmode'] = True
        elif trigger.startswith('gg_trg_kill_set_'):
            self.state['udg_killgoal'] = self.state['GGMGoalPending']
            for i in range(9):
                self.state['udg_Starrrrr'][i] = {'tavern': i}

    def order(self, player, shop, raw):
        assert (player, raw) not in self.disabled
        self.orders.append((player, shop, raw))
        if not self.state['udg_Banpickmode']:
            self.state['udg_Player'][player+1] = {'raw': raw, 'owner': player}
        return True

    def select(self, target, player):
        self.selections.append((target, player))
        self.unit = target
        self.player = player
        self.state['GGMSelected']()

    def load(self, script):
        globals_ = re.search(r'(?ms)^// GGM_GLOBALS_BEGIN\n(.*?)^// GGM_GLOBALS_END', script)[1]
        functions = re.search(r'(?ms)^// GGM_FUNCTIONS_BEGIN\n(.*?)^// GGM_FUNCTIONS_END', script)[1]
        scalar = []
        for line in globals_.splitlines():
            words = line.split()
            if not words:
                continue
            if words[1] == 'array':
                factory = int if words[0] == 'integer' else str if words[0] == 'string' else lambda: None
                self.state[words[2]] = defaultdict(factory)
            else:
                name, value = words[1].split('=')
                scalar.append(name)
                self.state[name] = eval(expression(value))
        self.state.update(dict(
            Player=lambda p: p,
            GetPlayerId=lambda p: p,
            GetTriggerPlayer=lambda: self.player,
            GetLocalPlayer=lambda: self.player,
            GetClickedButton=lambda: self.clicked,
            GetEventPlayerChatString=lambda: self.chat,
            GetTriggerUnit=lambda: self.unit,
            GetPlayerController=lambda p: 'user' if p in self.active else 'none',
            GetPlayerSlotState=lambda p: 'playing' if p in self.active else 'empty',
            GetPlayerTechMaxAllowed=lambda p, raw: 0 if (p, raw) in self.disabled else -1,
            GetUnitTypeId=lambda u: u.get('raw', 1) if u else 0,
            GetOwningPlayer=lambda u: u['owner'],
            DialogCreate=self.dialog, DialogClear=lambda d: d['buttons'].clear(),
            DialogSetMessage=self.message, DialogAddButton=self.add,
            DialogDisplay=lambda p, d, visible: d.update(visible=visible),
            DisplayTimedTextToPlayer=lambda p, x, y, t, text: self.notices.append((p, text)),
            IssueNeutralImmediateOrderById=self.order,
            IsTriggerEnabled=lambda trigger: True,
            TriggerExecute=self.trigger,
            ExecuteFunc=lambda name: self.state[name](),
            CreateTrigger=lambda: {}, TriggerRegisterDialogEvent=lambda *args: None,
            TriggerRegisterPlayerChatEvent=lambda *args: None,
            TriggerRegisterPlayerUnitEvent=lambda *args: None,
            TriggerAddAction=lambda *args: None,
            RectContainsUnit=lambda r, u: True,
            SetCameraField=lambda *args: None,
            ForceRemovePlayer=lambda force, p: force.discard(p),
            ForceAddPlayer=lambda force, p: force.add(p),
            IsPlayerInForce=lambda p, force: p in force,
            CreateGroup=list,
            GroupEnumUnitsInRect=lambda group, rect, filter_: group.extend(self.world),
            FirstOfGroup=lambda group: group[0] if group else None,
            GroupRemoveUnit=lambda group, unit: group.remove(unit),
            DestroyGroup=lambda group: group.clear(),
            GetUnitX=lambda unit: unit.get('x', 0),
            GetUnitY=lambda unit: unit.get('y', 0),
            PanCameraToTimedForPlayer=lambda *args: None,
            SelectUnitForPlayerSingle=self.select,
            ModuloInteger=lambda a, b: a % b, I2S=lambda v: str(int(v)), I2R=float,
            MAP_CONTROL_USER='user', PLAYER_SLOT_STATE_PLAYING='playing',
            EVENT_PLAYER_UNIT_SELECTED=1, CAMERA_FIELD_TARGET_DISTANCE=1,
            udg_System_Gamemode=10, udg_Player=defaultdict(lambda: None),
            udg_Starrrrr=defaultdict(lambda: None), udg_TESTMODE=False,
            udg_Banpickmode=False, udg_Banpickended=False, udg_PickBanUnit=None,
            gg_rct_Loc_SelUnit='selection', udg_DoummalGroup=set(range(10)),
            udg_Camlock_Distance=defaultdict(float),
        ))
        for trigger in ['Mode_Team', 'Mode_Epiccenter', 'Mode_Banpick',
                        'kill_set_Team', 'kill_set_Epiccenter', 'kill_set_Banpick']:
            self.state['gg_trg_'+trigger] = 'gg_trg_'+trigger
        code = transpile(functions, scalar)
        exec(compile(code, '<actual-menu-jass-native-model>', 'exec'), self.state)
        self.state['GGMInit']()
        return self.state

    def click(self, p, action, value=None):
        self.player = p
        for index in range(self.state['GGMButtons'][p]):
            slot = p*12+index
            if self.state['GGMAction'][slot] == action and (value is None or self.state['GGMValue'][slot] == value):
                self.clicked = self.state['GGMButton'][slot]
                self.state['GGMDialog'][p]['visible'] = False
                self.state['GGMClick']()
                return
        raise AssertionError(('Button not reachable', p, action, value))


def test(out):
    out = Path(out)
    script = (out/'Menu.j').read_text()
    data = json.loads((out/'Hero-handbook.json').read_text())
    model = NativeModel()
    env = model.load(script)
    env['GGMStart']()
    env['GGMStart']()  # startup is idempotent
    model.click(0, 12)
    model.click(0, 18, 5000)
    assert env['udg_Camlock_Distance'][1] == 5000
    model.click(0, 19, 0)
    assert 0 not in env['udg_DoummalGroup'] and 1 in env['udg_DoummalGroup']
    model.click(0, 19, 1)
    assert 0 in env['udg_DoummalGroup']
    model.click(0, 10)
    # Two players read different heroes without touching each other's page.
    model.click(0, 2)
    model.click(1, 2)
    model.click(0, 5, 0)
    model.click(1, 5, 1)
    second = env['GGMDialog'][1]['title']
    model.click(0, 6)
    assert env['GGMDialog'][1]['title'] == second

    # Walk every real hero, all actual skill entries and every description
    # page through the production JASS Draw/Click handlers.
    visited = set()
    skill_count = page_count = 0
    for role in range(8):
        env['GGMScreen'][0] = 3
        env['GGMDraw'](0)
        model.click(0, 5, role)
        heroes = [i for i, h in enumerate(data['heroes']) if h['role'] == role]
        for ordinal, h in enumerate(heroes):
            env['GGMPage'][0] = ordinal//6
            env['GGMScreen'][0] = 4
            env['GGMDraw'](0)
            model.click(0, 6, h)
            visited.add(h)
            assert data['heroes'][h]['name'] in env['GGMDialog'][0]['title']
            first = env['GGMHeroSkillStart'][h]
            for offset in range(env['GGMHeroSkillCount'][h]):
                env['GGMPage'][0] = offset//4
                env['GGMScreen'][0] = 5
                env['GGMDraw'](0)
                model.click(0, 8, first+offset)
                skill_count += 1
                page_count += 1
                for page in range(1, env['GGMSkillTextCount'][first+offset]):
                    model.click(0, 16, 1)
                    assert env['GGMTextPage'][0] == page
                    page_count += 1
                model.click(0, 17)
            model.click(0, 15)
            assert env['GGMPage'][0] == ordinal//6
    assert len(visited) == len(data['heroes']) == env['GGMHeroCount']
    # Looking at a model selects only the real preview, never buys/clones it.
    # During draft even that selection is suppressed to avoid an accidental
    # second click in the original confirmation trigger.
    model.world = [dict(raw=env['GGMHeroRaw'][0], owner=15)]
    env['GGMModel'](0, 0)
    assert len(model.selections) == 1 and not model.orders
    assert env['GGMSkipPopup'][0] == 0
    env['udg_Banpickmode'] = True
    env['GGMModel'](0, 0)
    assert len(model.selections) == 1 and not model.orders
    env['udg_Banpickmode'] = False

    # A player cannot start someone else's match; invalid draft doesn't lock
    # setup; duplicate starts cannot restart an already launched game.
    env['GGMMode'][1] = 1
    env['GGMLaunch'](1, 25)
    assert not model.triggers
    assert model.notices[-1][0] == 1
    env['GGMMode'][0] = 3
    env['GGMLaunch'](0, 25)
    assert not env['GGMLaunching'] and not model.triggers
    env['GGMScreen'][0] = 0
    env['GGMDraw'](0)
    model.click(0, 1)
    model.click(0, 3, 2)
    model.click(0, 4, 7)
    assert env['udg_System_Gamemode'] == 2 and env['udg_killgoal'] == 7
    assert env['GGMGoalPending'] == 0
    assert model.triggers == ['gg_trg_Mode_Epiccenter', 'gg_trg_kill_set_Epiccenter']
    env['GGMLaunch'](0, 9)
    assert len(model.triggers) == 2

    # Confirm routes a purchase through the original tavern API. Disabled
    # heroes and a second non-test pick cannot issue another purchase.
    model.disabled.add((0, env['GGMHeroRaw'][0]))
    env['GGMConfirm'](0, 0)
    assert not model.orders
    model.disabled.clear()
    env['GGMConfirm'](0, 0)
    assert len(model.orders) == 1 and model.orders[0][2] == env['GGMHeroRaw'][0]
    env['GGMConfirm'](0, 1)
    assert len(model.orders) == 1
    # Draft turn and startup permissions are independent of the clicked card.
    env['udg_Player'][1] = None
    env['udg_Banpickmode'] = True
    env['udg_PickBanUnit'] = {'owner': 1}
    env['GGMConfirm'](0, 2)
    assert len(model.orders) == 1
    env['udg_PickBanUnit'] = {'owner': 0}
    env['GGMConfirm'](0, 2)
    assert len(model.orders) == 2
    assert all(p == 0 for p, text in model.notices[1:])
    for mode in (1, 3):
        other = NativeModel()
        if mode == 3:
            other.active = set(range(10))
        else:
            other.active = {1, 2}  # leading slot empty: first human is host
        state = other.load(script)
        host = state['GGMHost']()
        state['GGMMode'][host] = mode
        state['GGMLaunch'](host, 25)
        assert state['udg_killgoal'] == 25
        assert len(other.triggers) == 2
    local_bodies = re.findall(r'if GetLocalPlayer\(\)==Player\(p\) then\n(.*?)\nendif', script, re.S)
    assert local_bodies == ['call SetCameraField(CAMERA_FIELD_TARGET_DISTANCE,I2R(value),0.3)']
    result = dict(nativeWarcraftTested=False, testKind='Actual menu JASS with simulated native calls',
                  heroesTraversed=len(visited), skillsTraversed=skill_count, pagesTraversed=page_count,
                  maxButtons=model.max_buttons, maxDialogTitleBytes=model.max_title,
                  independentPlayerMenus=True, hostAndDraftTurnGuards=True,
                  duplicateStartsRejected=True, bannedAndDuplicateHeroPicksRejected=True,
                  modelPreviewDoesNotPick=True, threeModeStartRoutes=True,
                  noGameplayMutationsInLocalPlayerBranch=True)
    (out/'Menu-tests.json').write_text(json.dumps(result, ensure_ascii=False, indent=2))
    print(json.dumps(result, ensure_ascii=False))


if __name__ == '__main__':
    test(sys.argv[1])
