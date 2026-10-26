# Rexxar cooperative mission adaptation, RC1

Inputs are the seventeen actual maps uploaded by the user, not synthetic replacement terrain. `build.py` preserves their terrain/import data and original quest functions, reserves player IDs 0/3/4/5, remaps conflicting NPC factions, and injects `runtime/core.j`. In the final mission the existing three Horde armies become the three additional human players' armies; their campaign AI is suppressed. In two crowded missions revival stones move to the engine's neutral-victim player 13, outside the twelve playable lobby slots. Editor unit placements receive the same owner remapping, after a byte-identical round-trip check.

The runtime adds per-role heroes and signature skills, difficulty selection before initialization, army/reward sharing, revival/leave handling, synchronized story-owner tests/events, hero adoption, and RC1 save codes for heroes, six inventory slots/charges, base stats, five ordinary skills, resource accounts, shared stash, temporary companion Jaina’s carried loot, and 41 story fields. It retains original story companions' recruitment events; stand-ins remain playable until their narrative unit joins. Codes use checksums and separate role/session checks and fit classic chat. Disk generation is local visual/file output only; all gameplay decisions remain synchronized.

Classic single-player map switching is replaced with a saved destination and instructions for creating the next network lobby. This is **not seamless network map loading**. Save codes do not serialize the entire world snapshot (all enemies, floor items, destructables or every local scene variable). Mission quest/scenes, neutral-player changes, AI and final balance require real 1.26 playtesting; native Warcraft has **not** been run here. Output reports and player documentation explicitly call this experimental RC1.

`Catalog` fingerprints the originals' item definitions and required modified abilities, resolves their WTS strings, and emits 318 portable item aliases plus five dependent ability definitions into every map. Lookup tables translate back to a mission's original quest item ID when equivalent. This avoids the observed original I003 collision between act II's overworld claw and the following mission's explosive mixture. It does not automatically port arbitrary custom item-trigger scripts between maps. Classic object field wire types are validated against `metadata-types.json`, derived from w3x2lni classic 1.24.4 metadata at commit `82916514a12b7edb15252d42225cd8cc8ce61cfd`.

Build requirements: Python 3.12, StormLib, .NET 10. Tests additionally use Lupa 2.8, pinned pjass and the public declarations in `tests/reference`.

```sh
python coop/build.py --out build-out
dotnet run --project coop/Tools -c Release -- verify build-out
python coop/tests/test_maps.py build-out
```

The workflow transpiles actual generated mission JASS through War3Net and executes save/load, cross-act/alias, role/difficulty, stash, army, spell, leave/revive and corruption tests against controlled natives. It checks syntax for all 17 complete scripts and audits the runtime against classic API names. Neither the native mocks nor the modern syntax declarations establish real game/network compatibility.

`SaveHelper.cs` builds a small .NET Framework 4 Windows Forms executable. It reads only known save text files, validates checksums and role fields, filters stale files by party/session/map, and copies commands on a user click. It never executes save/JASS text. The Windows workflow tests the exact executable's parser against files produced by the actual-JASS tests; it does not claim the Forms UI or Warcraft itself was exercised.
