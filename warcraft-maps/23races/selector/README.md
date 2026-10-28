# Classic race selection — FIX2 native command card

The recovered 23 Races map contains **34** research choices. FIX2 moves their
selection to the ordinary Warcraft1.26 command card: eight race abilities per
page, five pages, four navigation/confirmation buttons, native icons and a
native selected-unit portrait. [Player instructions](README-RU.txt).

The input is `../release/23-Races-3.2D-Triggers-NewGen-1.26.w3x`, SHA256
`9865022098044aad2e9e93f6e8738246c3dc4dcbc69004fb87f2bf7e93498c2b`.
The screenshot supplies the style reference. The separate Drive map could not
be fetched and has not been used.

## Result and reason for the change

FIX1 corrected a missing cine-filter texture path (`choice09.tga` vs
`race09.tga`). The user confirmed the screen then appeared without crashing,
but reported missing icon and nonfunctional mouse/arrow selection. FIX2
removes the projected 3D icon, invisible trackable hitboxes and fake buttons.
It keeps the faction camp and informational panel, leaving the entire bottom
HUD unobscured. The native interface, selection and user input are enabled.
The camera no longer clears selection continuously.

`controls.py` defines38 ordinary unit abilities based on classic Channel and
34 selectable menu units. Each unit has the eight races on its page plus
previous/next/random/confirm, with unique native command slots, hotkeys and
base orders. The units have no attack or movement commands and stay unpaused;
preview actors and the original world remain paused. Race icons come from the
original research data. Four new control icons include gray disabled variants
in classic BLP1 format with a complete mip chain. No Reforged frame API is used.
Channel's Ncl1..Ncl6 modifications explicitly carry DataPointer1..6, matching
classic AbilityMetaData's DataA..DataF columns. `classic-control-schema.json`
records the pinned classic metadata for every new ability/unit field; validation
checks types, levels and data pointers, not only the visible values. The schema
check rejects the intermediate zero-pointer build.

A registered `EVENT_PLAYER_UNIT_SPELL_EFFECT` handler validates the caster and
owner, then queues input. The selected unit is replaced from a later timer
callback, outside the native casting stack. A separate confirm flag preserves
a race click followed immediately by confirmation. The camera restores menu
selection only if lost, retaining the native command card and its hotkeys.
Arrow events remain a backup. A native timer dialog displays the90-second
selection period. Confirmation is guarded; all players start together, timeout
accepts each shown race and leaving players do not block the start.

## Other implementation files

* `catalog.py` extracts original research handlers, exact worker rewards,
  build/train trees, lore and stats. Unrelated reference-map buffs are not added.
* `ui_assets.py` generates transparent information panels, BLP1 control icons
  and the grass-floor MDX800. The floor uses opaque depth testing/writes; camera framing keeps the formation above the native HUD. Panels have zero alpha across the bottom third.
* `stages.py` finds12 separate camps above the original terrain. Terrain,
  pathing, placements and original visual resources remain intact.
* `runtime.j` synchronizes all unit/handle allocations; only camera, filter,
  selection and native UI visibility depend on `GetLocalPlayer()`.
* `build.py` preserves original unit/ability object entries and adds isolated
  previews, menu units and menu abilities. It preserves the original five-worker
  reward, original research and announcement for each race.
* `Check` patches WTG/WCT, retaining262 original triggers (69GUI and193JASS)
  plus three technical entries. Initial43 one-shot and two periodic timers
  start after selection instead of expiring or duplicating during the menu.
  The actual runtime must match a fresh regeneration from editable metadata.

## Build and validation

Requires Python3.12+, Pillow, mpyq0.2.5, Lupa2.8, .NET10, StormLib9.25 and pjass.
The CI workflow pins upstream tools. The unpublished War3Net MDX reader is
compiled from commit `5f6f7bac26ed7ce7d0db83ceb4fb9ce59f918ff8`.

```sh
dotnet build Check -p:War3NetSource=/path/to/War3Net
STORMLIB_PATH=/path/to/libstorm.so python build.py --out out
dotnet Check/bin/Debug/net10.0/Check.dll transpile out/editor-generated.j /path/to/classic-jass out/runtime.lua
python tests/test_runtime.py out
python verify.py out /path/to/classic-jass
pjass +shadow /path/to/classic-jass/common.j /path/to/classic-jass/Blizzard.j out/editor-generated.j
python package.py out release
```

Verification compares all629 baseline MPQ entries, including unnamed entries;
619 remain byte-identical. Original unit/ability definitions are preserved,
as are865 original trigger functions except relocated initial timer events.
All34 native command cards are checked for correct race icons, visible free
unit abilities, distinct slots/hotkeys/orders and non-locust menu units. BLP1
icons are decoded independently, model texture paths resolve and panel alpha
cannot cover the native HUD.

Behavior tests run the delivered JASS after War3Net transpilation. Mocks read
unit ability lists and resources from the actual W3X; button tests invoke the
registered native event with those abilities. Coverage includes all34 races,
page wrap, random, confirm, repeat/invalid input, immediate confirm in the same
frame, unpaused selected menu units, enabled native UI, preserved selection,
deferred caster teardown,12 independent players, timeout/departure, original
states/timers and identical gameplay allocations across local-player views.

There is **no running Warcraft1.26 client** in this environment. These checks
cannot establish physical mouse hit testing, native rendering, performance or
real network synchronization. This remains a prerelease for client validation.
The9.6MB map uses the user's existing large-map patch for network play.

## Data provenance

`base-units.json` contains836 stock metadata records extracted by
`extract_stock.py` from [w3x2lni](https://github.com/sumneko/w3x2lni), commit
`82916514a12b7edb15252d42225cd8cc8ce61cfd`, `zhCN-1.24.4` data. Custom map data
overrides the base. New interface textures/models are generated here; DejaVu
supplies Cyrillic text. The MDX parser is War3Net (MIT). Original gameplay and
imported resources retain their authorship.
