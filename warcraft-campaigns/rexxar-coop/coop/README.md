# Rexxar VI FIX: XP, skill-learning events and shorter codes
Read [the Russian update notes](README-VI-FIX-RU.txt). Registered hero-skill
events mirror hidden native learning entries into permanent unit cast abilities;
the K dialog and `-learn q/w/e/r/5` share the same verified purchase path.
Experience writes explicitly clear/restore suspension, and corpse distance uses
coordinates. Original story deletion preserves the gameplay hero until adoption.
Z6 back-references shorten repeated state while preserving all existing save
formats. The Windows helper validates both envelopes against actual JASS fixtures.

This remains seventeen separate network maps: **seamless cave/location changes
are not implemented**. Rehosting is still required. Native Warcraft/IrinaBot
gameplay has not been executed here; mocked-event checks do not establish a
native playthrough. `test_gameplay_events.py` states and tests those boundaries.

---

# Rexxar cooperative campaign — VI

Current output: seventeen `RX6-*.w3x` missions, `package_vi.py`, and
[Russian player instructions](README-VI-RU.txt).

VI creates only occupied human roles: red/blue/teal/purple (`0,1,2,3`). Red
Rexxar is required by the original campaign story. Other roles can be closed;
there is no fallback hero given to host. Quest/starting reinforcements are shared
only among humans. Player-trained units remain owned. Inactive narrative actors
are hidden, neutral and inert outside cinematics, excluded from source party
groups; recruitment story state remains saved independently. NPC colours and
final-map Horde armies are explicitly remapped to avoid human-slot collisions.

Z5/C4 checkpoints contain the participant mask and only require codes of the
saved party. Full twelve-slot stash/companion data is split among present roles;
a worst-case dense solo save emits an additional snapshot-bound S2 stash command
so every command still fits the classic chat limit. C2/C3 and Z3/Z4 remain
loadable; old four-part stash saves still need all four source codes. Missing
roles' loaded items are dropped once at camp and their bank is shared. New joiners
start at the act's base level. `test_party.py` covers all eight red-led masks,
quest group/condition isolation, reinforcement/resource fairness, ownership,
legacy migration, departures, sparse/full saves and every command length. It
writes actual JASS fixtures for Windows EXE tests for party sizes 1/2/3/4 plus
full solo inventory/stash. Existing skill/talent/XP and data checks remain.

All seventeen map constants explicitly set `MaxHeroLevel=20`. The lobby colour
schema changed deliberately; native 1.26/IrinaBot acceptance of VI has not been
verified in this cloud environment. Use `pjass +shadow` on every complete script.

---

# Rexxar cooperative campaign — V

Current files: `RX5-*.w3x`, packaged by `package_v.py`. Player instructions:
[Russian README](README-V-RU.txt).

V provides explicit K skill learning (native point pool, no automatic purchases),
five two-way talent tiers per hero at levels 4/8/12/16/20, role-based choices
persisted in Z4/C3 checkpoints (Z3/C2 still loads), and direct shared kill XP:
each nearby living hero receives `24 + 8 * victim level`, plus 40 for enemy
heroes; structures grant `12 + 4 * level`. Summons/illusions/friendly deaths,
cutscenes and distant/dead heroes do not gain XP. Native automatic XP is
suspended on the four heroes to prevent double rewards; campaign XP-handicap
and suspension calls are wrapped. Local text tags display the actual award.

`test_progress.py` exercises learning, concurrent player dialogs, all 40 talent
choices, real kill reward/level progression, cross-map talent persistence,
legacy-code compatibility and invalid-state rejection on generated/transpiled
JASS. All 17 scripts require `pjass +shadow` and retain the native-confirmed C
lobby metadata/config, except identifying title/description. These are automatic
logic/data checks; this build has not been played in native Warcraft or IrinaBot.

---

# Rexxar cooperative campaign — IV

The current builder emits all seventeen `RX4-*.w3x` missions. See
[Russian player instructions](README-IV-RU.txt) for setup, sixteen learnable
Q/W/E/R skills, party scaling, and lossless short Z3/C2 continuation codes.
The first mission keeps the lobby records/config of the C map the user actually
played on Warcraft III 1.26.0.6401; this is a new gameplay build, not a native
playthrough certification. `package_iv.py` packages the exact generated files.

`test_kits.py` executes all sixteen mechanics, timed cleanup, local code output,
HP/damage scaling, and code compression against transpiled generated JASS.
`test_entry_regression.py` compares native-confirmed C lobby fixtures and checks
the strict parser's rejection of type-shadowing. Run `pjass +shadow` for **all**
complete scripts; default pjass missed the old native-loading failure.

The older entry below documents earlier iterations and their tooling. Historical
`type_shadow_fix.py` / `package_full_fix.py` preserve the exact old C diagnostic;
they must not be used to replace the first mission of the new gameplay package.

---

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

## User A/B result and candidate C

The user reports **A opens / B rejects** on Warcraft III **1.26.0.6401**. The same terrain/assets/object data/lobby setup therefore open with the tiny script; investigation now concerns full-script loading. A stricter `pjass +shadow` check on the exact rejected B finds two added type-name collisions: `RC_Victory` parameter `boolean dialog` and `RC_Spell` local `integer ability`. They are renamed to `showDialog` and `abilityId` in the shared runtime. Every generated mission must now pass `+shadow`, rather than only the default checks.

`type_shadow_fix.py` produces **C-Coop-Fix.w3x**, a full first-mission candidate. Reversing only these two identifier changes and the title reconstructs the exact native-rejected B script SHA256; hashes also pin all shared data and normalized lobby metadata to B. `tests/test_type_shadow_fix.py` proves the real B passes the default checker and fails `+shadow` with exactly those two diagnostics, while C passes. It checks the exact diff, assets, metadata, four-human config and file hash. This is an identified declaration conflict and focused candidate, **not a claim that native C acceptance or the entire campaign has been verified**. The workflow publishes C alone/small ZIP with regression evidence pending the user's local lobby test.

## User confirms C lobby entry; full corrected bundle

The user answered **“Лобби C открывается”** for the published exact-delta candidate on 1.26.0.6401. This establishes local lobby acceptance after the two identifier renames. `accepted-first.json` pins that exact release URL/size/SHA256 and scopes confirmation to local entry only. `package_full_fix.py` packages all seventeen strict-checked maps, substitutes the exact accepted C bytes under canonical RX3-OrcX01.w3x (so return-to-hub filenames remain valid), and records final included-file hashes in Fixed-package.json. The first generated Build-report row is updated to match the substitution; the original generated hash is retained separately. Other map titles now say REXXAR FIX to distinguish them from rejected RC3 copies; no other gameplay changes are introduced.

The bundle installs to Maps/Rexxar-Coop-Fixed and includes the optional Windows clipboard helper. Full four-client gameplay, all other native lobbies, complete story/scenes/balance and live IrinaBot connection remain unverified. The release notes state this scope. No new hosting-account permission is requested: actual IrinaBot upload requires the user's authenticated service session, which this cloud does not have.
