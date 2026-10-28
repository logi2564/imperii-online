# Rexxar VII: experimental single-map campaign

Resumed at the user's request on 2026-10-28. The generator now emits an actual
classic W3X, not preparation files. Runtime/native-client limits are recorded
in `README-VII-RU.txt` and the generated `Build-report.json`.

Build:

```sh
dotnet build coop/Tools -c Release
python coop/unified_build.py --out build-out
pjass +shadow coop/tests/reference/common.j coop/tests/reference/Blizzard.j build-out/Rexxar-VII.j
dotnet coop/Tools/bin/Release/net10.0/Tools.dll atlas-verify build-out/Maps/Rexxar-VII-Coop-1.26.w3x
dotnet coop/Tools/bin/Release/net10.0/Tools.dll transpile build-out/Rexxar-VII.j coop/tests/reference build-out/Rexxar-VII.lua
python coop/tests/test_unified.py build-out/Rexxar-VII.lua
python coop/tests/test_unified_archive.py build-out
```

All 17 supplied locations, original heights/cliffs/water/pathing, placed
objects, namespaced original quest/cinematic scripts and shared cooperative
runtime are merged into one 480-square atlas. Classic terrain has 16 shared
ground textures; this changes some ground appearance from the originals.
There are 3373 merged unit/start markers and 50224 decorations. Sixteen custom
skills, forty talents, classic native learning, explicit kill XP and the
existing Z6 compact progression format remain. Classic AbilityMetaData data
pointers now apply to every generated ability field, including hidden HP bits.

Heroes are indexed by character, with a bidirectional character/color map.
The native command card selects unique heroes, host difficulty/chapter and
per-player readiness. Only actual occupied human slots get playable heroes.

Locations initialize lazily. Direct/event timers, trigger enable states,
quests, floor items and NPC owner/pause/visibility/invulnerability are retained
while a zone is inactive. Heroes and owned troops travel as physical handles;
doors do not serialize/recreate heroes. Source unit cache operations retain
handles, avoiding campaign RestoreUnit. Sleeping source actions have an epoch
guard, and original periodic portal actions no longer disable themselves then
sleep across a map change. Single-player disk-save checks/copies/profile
unlocks cannot branch the multiplayer simulation.

The original AI scripts live in the game MPQ and assume one map's coordinates
and rawcodes. Starting those VMs unchanged would be incorrect. AI-enabled
factions instead have synchronized active-zone attacks and bounded production
from living factories, using actual aliased train lists. Quest waves remain.
This is an adapted AI, not a claim of identical original AI behavior.

Tests execute actual generated code with explicit native mocks. They do not
run the full mission initialization/cinematics or emulate native pathfinding,
UI rendering or networking. Native Warcraft 1.26 and IrinaBot testing is still
required. Manual codes preserve hero/story checkpoints rather than a complete
snapshot of every NPC/combat event across a new session.
