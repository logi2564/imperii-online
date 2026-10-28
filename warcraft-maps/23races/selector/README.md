# Classic race-selection example

Adds a black/gold Russian selection panel and a temporary 3D faction camp to
the user's recovered 23 Races map. Uses only classic 1.26 APIs. All **34** actual
research choices remain available. See [player instructions](README-RU.txt).

The uploaded map is byte-identical to `../release/23-Races-3.2D-Triggers-NewGen-1.26.w3x`.
Its SHA256 is `9865022098044aad2e9e93f6e8738246c3dc4dcbc69004fb87f2bf7e93498c2b`.
The screenshot supplied the visual reference. The Drive folder could not be
fetched in this environment; its separate Reforged map was not used.

## Implementation

* `catalog.py` derives 34 choices, worker rewards, build/train trees and lore
  from the original research handlers and object data. Stats are map data;
  unrelated percentage bonuses from the screenshot are not invented.
* `ui_assets.py` generates transparent RGBA TGA panels and small original MDX800
  icon, hitbox and grass-floor models. Actual faction models/icons come from
  the map and installed Warcraft resources. No external model pack is needed.
* `stages.py` locates 12 separate temporary stages. Non-colliding grass platforms
  sit above existing terrain; terrain and pathing are never repainted.
* `runtime.j` uses classic cine filters, camera controls, trackables and arrow
  events. Scene actors and all handles are allocated synchronously. Only camera,
  filter, selection and text-tag visibility depend on `GetLocalPlayer()`.
  Preview actors have isolated neutral/invulnerable/locust unit types.
* `build.py` creates the catalog, code, objects and assets. Original unit
  definitions remain untouched. Each original research handler's five-worker
  reward and announcement is reused with explicit player/spawn parameters.
* `Check` patches both WTG and WCT, adds 38 editor variables and emits the
  editor-generated script as the actual runtime. The existing 262 trigger
  entries (69 GUI actions and 193 JASS entries), plus three technical entries,
  remain editable. Initial registrations for 43 one-shot and two periodic
  timers are centralized: native timers start once the selection screen closes.
  This preserves 15/30/etc-minute events and avoids duplicate short timers.

All original world actors and chosen workers wait until everyone is ready.
Confirm is guarded against duplicate input. Departures do not block the start;
90 seconds expires to each player's current visible choice. Original pause,
trigger enable and fog states are restored. Actors, trees, tags and groups
are cleaned up. Classic trackables have no destroy API: their hit trigger is
disabled after use. The camera projection targets the normal classic 4:3
viewport, including clients that stretch it to widescreen.

## Build and validation

Requires Python 3.12+, Pillow, mpyq0.2.5, Lupa2.8, .NET10, StormLib9.25 and pjass.
The CI workflow pins upstream tool commits. War3Net's unpublished MDX parser is
compiled from commit `5f6f7bac26ed7ce7d0db83ceb4fb9ce59f918ff8`; pass its checkout
path using `-p:War3NetSource=/path/to/War3Net` when building `Check`.

```sh
dotnet build Check -p:War3NetSource=/path/to/War3Net
STORMLIB_PATH=/path/to/libstorm.so python build.py --out out
dotnet Check/bin/Debug/net10.0/Check.dll transpile out/editor-generated.j /path/to/classic-jass out/runtime.lua
python tests/test_runtime.py out
python verify.py out /path/to/classic-jass
pjass +shadow /path/to/classic-jass/common.j /path/to/classic-jass/Blizzard.j out/editor-generated.j
```

`verify.py` compares all baseline MPQ hash entries, including unnamed original
entries. 620 entries remain byte-identical; original units, abilities, upgrades,
terrain, pathing, placements and every original visual asset are retained.
865 original trigger functions are token-equivalent, with only the initial
timer registrations moved. `Check verify` requires a fresh editor regeneration
to match the delivered runtime exactly, apart from a normalized header date.
`tests/test_runtime.py` runs the actual map script after War3Net transpilation,
with explicit mocked native boundaries. It covers all34 rewards, registered
keyboard/trackable dispatch, 12 simultaneous choices, repeat input, timeout,
departure, cleanup, original states/timers and identical gameplay allocations
for different local-player views.

These checks **do not** prove native graphics, click hit testing, performance,
lobby/bot compatibility or real multiplayer synchronization. There is no
launchable Warcraft client in this environment. Keep this release a prototype
until it is exercised in 1.26. The file exceeds8MiB and uses the user's existing
large-map client patch for network play.

## Data provenance

`base-units.json` contains836 stock unit metadata records (model paths, names,
build/train lists, movement and base HP). Extracted from the `zhCN-1.24.4` data
of [w3x2lni](https://github.com/sumneko/w3x2lni), commit
`82916514a12b7edb15252d42225cd8cc8ce61cfd`, using `extract_stock.py`.
Custom data in the supplied map overrides this base. Interface textures/models
are generated here. DejaVu Serif supplies Cyrillic text; MDX parser source is
War3Net (MIT). Original gameplay and imported assets retain their authorship.
