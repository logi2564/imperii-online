# Rexxar cooperative mission adaptation, RC3

Inputs are the seventeen actual maps uploaded by the user, not synthetic replacement terrain. `build.py` preserves their terrain/import data and original quest functions, reserves player IDs 0/3/4/5, remaps conflicting NPC factions, and injects `runtime/core.j`. In the final mission the existing three Horde armies become the three additional human players' armies; their campaign AI is suppressed. In two crowded missions revival stones move to the engine's neutral-victim player 13, outside the twelve playable lobby slots. Editor unit placements receive the same owner remapping, after a byte-identical round-trip check.

The runtime adds per-role heroes and signature skills, difficulty selection before initialization, army/reward sharing, revival/leave handling, synchronized story-owner tests/events, hero adoption, and C2 completion codes for heroes, six inventory slots/charges, base stats, five ordinary skills, resource accounts, shared stash, temporary companion Jaina’s carried loot, and 41 story fields. It retains original story companions' recruitment events; stand-ins remain playable until their narrative unit joins. Each player enters one chat-sized code; all four codes together restore the party. In-game F9 quests retain the codes; disk output and the clipboard helper are optional. All gameplay decisions remain synchronized.

Classic single-player map switching is replaced with a saved destination and instructions for creating the next network lobby. This is **not seamless network map loading**. Save codes do not serialize the entire world snapshot (all enemies, floor items, destructables or every local scene variable). Mission quest/scenes, neutral-player changes, AI and final balance require real 1.26 playtesting; native Warcraft has **not** been run here. Output reports and player documentation explicitly call this experimental RC1.

`Catalog` fingerprints the originals' item definitions and required modified abilities, resolves their WTS strings, and emits 318 portable item aliases plus five dependent ability definitions into every map. Lookup tables translate back to a mission's original quest item ID when equivalent. This avoids the observed original I003 collision between act II's overworld claw and the following mission's explosive mixture. It does not automatically port arbitrary custom item-trigger scripts between maps. Classic object field wire types are validated against `metadata-types.json`, derived from w3x2lni classic 1.24.4 metadata at commit `82916514a12b7edb15252d42225cd8cc8ce61cfd`.

Build requirements: Python 3.12, StormLib, .NET 10. Tests additionally use Lupa 2.8, pinned pjass and the public declarations in `tests/reference`.

```sh
python coop/build.py --out build-out
dotnet run --project coop/Tools -c Release -- verify build-out
python coop/tests/test_maps.py build-out
```

The workflow transpiles actual generated mission JASS through War3Net and executes save/load, cross-act/alias, role/difficulty, stash, army, spell, leave/revive and corruption tests against controlled natives. It checks syntax for all 17 complete scripts and audits the runtime against classic API names. Neither the native mocks nor the classic syntax declarations establish real game/network compatibility.

`SaveHelper.cs` builds a small .NET Framework 4 Windows Forms executable. It reads only known save text files, validates checksums and role fields, filters stale files by party/session/map, and copies commands on a user click. It never executes save/JASS text. The Windows workflow tests the exact executable's parser against files produced by the actual-JASS tests; it does not claim the Forms UI or Warcraft itself was exercised.

## RC2 loading and completion-code changes

RC1 contained a 1415-byte Russian help literal: pjass did not reject it, but the classic loader limit is 1023 bytes. The builder now splits long literals at UTF-8 character/escape boundaries; an independent serialized-script audit enforces the limit on all seventeen maps. Runtime allocation and menu display run on a short timer after `main`, with original triggers disabled immediately. The gating clock includes this delay so expired original one-shot timers are still rearmed. Native Warcraft has not been run, so the reported crash is not proven reproduced or eliminated.

`runtime/checkpoint.j` adds **C2**, one 102-character code per role. Each includes session/completion/source/destination/area/difficulty, all 41 story fields (1/4/12-bit checked widths), party flags, full hero progression/wallet/six charged item slots, and one quarter of the shared stash/Jaina payload. Portable and classic items use a stable 592-entry compact catalog derived from the same classic 1.24.4 source as the object metadata. All four matching codes are required, even for absent players (host may load them). `-load CODE` alone supplies the complete progress; `-party`/`-stash` remain legacy compatibility only. C2 checks destination, sender, exact completion identity, checksum and item indices before committing. `-reset` clears a selected checkpoint before start.

Codes are issued automatically on transition/victory, displayed personally and in per-role F9 quests, repeatable with `-code`, and optionally written to the existing known text paths. Start/periodic code generation was removed. A duplicate victory or manual-save request after completion cannot change issued codes; save failure leaves gameplay available and prior files intact. Act I's implicit campaign-screen edge now explicitly targets Act II; `SetNextLevel` selects a destination without prematurely saving. The helper is optional and copies the new single command; it filters different completion snapshots.

`tests/test_checkpoint.py` executes generated JASS for completion output/stability, four-code cross-map inventories/stash/loot/progression, packed-story ranges, destination/role/mixed-checkpoint/corruption/catalog/missing-code rejection, difficulty retention, reset, duplicate victories and failed-save recovery. These are native-mock tests, not real engine/network tests.

## RC3 lobby validation

The user confirmed that RC2 returns to multiplayer after downloading through IrinaBot AND does not open a local lobby. IrinaBot map81743 and its public API endpoints are blocked by the environment (HTTP403), so that actual hosted file/config and a native client handshake could not be inspected. Native Warcraft and live IrinaBot remain untested; RC3 is not claimed to eliminate the reported rejection.

RC2's W3I force memberships and its executed config disagreed on NPC teams/races; remapped/appended player records were unsorted, force masks included absent colours/overlap, and fixed-position records retained campaign priority garbage. RC3 sorts records, clears unused priorities, preserves the effective last-force assignment while bounding/disjoining membership to actual records, sets all controllers/races/starts, and derives config teams/alliances from W3I. Neutral NPC controllers are preserved, not converted to AI/human slots. Team capacity follows classic generated config's player-count bound. HM3W/W3I/config titles agree. Short distinct RX3- filenames and C3 titles distinguish files from old cached uploads. The first mission is published as a bare w3x in addition to the full ZIP.

Large injected item/trigger initializer functions now use bounded helper blocks. Full JASS validation/transpilation uses actual classic1.24.4 declarations (see tests/reference/README.md), rather than modern test declarations. All RC2 scripts also pass these classic declarations, so this change is not presented as proof of their rejection's cause.

`tests/test_lobby.py` independently parses W3I using the GHost++ classic v25 layout and slot policy, transpiles and EXECUTES each real config with recording natives, and compares controllers, races, teams, starts, forces and headers. The real released RC2 first-map metadata/config are retained as a negative fixture: the check catches their mismatches. These are protocol/metadata cross-checks, not a native Warcraft lobby or a live IrinaBot test. No patch-specific bot CRC/SHA1 configuration is invented using test script declarations.

Original campaign diplomacy is seeded after the lobby config, including neutral-victim revival stones and party/vendor friendliness across the new lobby forces. This does not change network team assignments. Runtime tests check source act-I friendliness and actual enemy10; party heroes keep private control.

## Native entry still rejected after RC3

The user confirmed both local multiplayer and IrinaBot still reject RC3. Previous metadata and mocked-JASS checks did not establish native acceptance; no root cause is claimed. Comparing with the original World Editor config found another omitted setup call: `SetPlayerColor` for every defined player. The builder now emits those assignments. Tests record them, with an actual RC3 config fixture proving the earlier omission, but it is NOT called a confirmed explanation for rejection.

`lobby_probe.py` produces a controlled pair from the same first-mission archive: **A-Entry.w3x** has only a tiny entry-only main plus config; **B-Coop.w3x** retains the full co-op code. Terrain, assets, object data, lobby records and configuration are identical apart from identifying titles. `tests/test_entrycheck.py` independently verifies this isolation and their file hashes. The workflow publishes ONLY this pair/small ZIP while native diagnosis is pending, rather than another claimed full fixed release. Its README requests only whether each local lobby opens; starting/playing the diagnostic A map is unnecessary and it intentionally contains no campaign gameplay.
