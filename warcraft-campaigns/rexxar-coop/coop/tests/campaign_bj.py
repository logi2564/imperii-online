"""Transpile selected *original* Blizzard helpers for campaign integration tests."""
import os
import re
import subprocess
from pathlib import Path
import sys

sys.path.insert(0, str(Path(__file__).resolve().parents[1]))
from build import ROOT
from unified_script import FUNCTION,namespace
from unified_runtime import order_functions


def compile_helpers(out):
    reference = ROOT / 'tests' / 'reference'
    text = (reference / 'Blizzard.j').read_text()
    functions = {f[1]: f[0] for f in FUNCTION.finditer(text)}
    wanted = set('GetBooleanAnd GetBooleanOr RectContainsUnit IsUnitAliveBJ IsTriggerQueueEmptyBJ SetPlayerAllianceStateBJ ConditionalTriggerExecute GetForLoopIndexA GetStoredIntegerBJ GetStoredBooleanBJ GetStoredStringBJ GetLastCreatedGameCacheBJ CreateQuestBJ CreateQuestItemBJ GetLastCreatedQuestBJ GetLastCreatedQuestItemBJ QuestSetDiscoveredBJ QuestSetCompletedBJ QuestItemSetCompletedBJ IMaxBJ GetPlayersAll'.split())
    wanted.update('GetUnitsOfPlayerAndTypeId GetUnitsOfPlayerAndTypeIdFilter GetUnitsOfPlayerMatching ForGroupBJ SetHeroLevelBJ AddItemToStockBJ GetRectCenter UnitShareVisionBJ IssuePointOrderLocBJ GetLastCreatedUnit LeaderboardSetPlayerItemLabelBJ CountUnitsInGroup IsUnitGroupDeadBJ TriggerRegisterPlayerUnitEventSimple GroupRemoveUnitSimple TriggerRegisterTimerExpireEventBJ'.split())
    wanted.add('RescueUnitBJ')
    campaign_script=(Path(out)/'Rexxar-VII.j').read_text()
    for mission_fn in FUNCTION.finditer(campaign_script):
        if re.match(r'Z(?:15|16)_(?:Create\w+|Trig_(?:Init_01_Players|Init_02_Units|Activate_Shipyard|Create_Battleship_Leaderboard|Retarget_Human_Forces)\w*)$',mission_fn[1]):
            wanted.update(name for name in re.findall(r'\b(\w+)\s*\(',mission_fn[0]) if name in functions)
    pending=list(wanted)
    while pending:
        name = pending.pop()
        for dep in {v for pair in re.findall(r'\b(\w+)\s*\(|\bfunction\s+(\w+)', functions[name]) for v in pair if v}:
            if dep in functions and dep not in wanted:
                wanted.add(dep)
                pending.append(dep)
    consts = re.findall(r'(?m)^\s*constant integer\s+bj_(?:(?:ALLIANCE_|QUESTTYPE_)\w+|MAX_PLAYERS|MAX_PLAYER_SLOTS)\s*=\s*\d+[^\n]*', text)
    helper = Path(out) / 'Campaign-BJ.j'
    # Their declarations are already registered from Blizzard.j by Tools.
    # Materialize these known integer/array initializers in the Lua boundary.
    globals_lua='\n'.join(re.sub(r'^\s*constant integer\s+','',line).strip() for line in consts)
    globals_lua+='\nbj_queuedExecTotal=0\nbj_FORCE_PLAYER=__jarray(nil)\nbj_FORCE_ALL_PLAYERS=CreateForce()\nfor n=0,15 do ForceAddPlayer(bj_FORCE_ALL_PLAYERS,n) end\n'
    helper.write_text(namespace(order_functions('\n\n'.join(functions[n] for n in sorted(wanted))),wanted,'CB_'))
    target = helper.with_suffix('.lua')
    subprocess.run([os.environ.get('DOTNET', 'dotnet'), str(ROOT / 'Tools/bin/Release/net10.0/Tools.dll'),
                    'transpile', str(helper), str(reference), str(target)], check=True)
    return globals_lua+target.read_text()+'\n'+'\n'.join(name+'=CB_'+name for name in sorted(wanted))+'\nfilterGetUnitsOfPlayerAndTypeId=Condition(GetUnitsOfPlayerAndTypeIdFilter)\n'
