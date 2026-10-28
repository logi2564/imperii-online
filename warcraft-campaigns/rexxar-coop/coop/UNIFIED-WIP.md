# Paused: unified multiplayer Rexxar campaign

User explicitly paused this work on 2026-10-28 to prioritize a race-selection
screen for 23 Races. Do not publish this as a playable map. Latest released
VI FIX remains b2524631, with rehosting between its 17 maps.

Branch: `warcraft-rexxar-unified`. Local work directory:
`/workspace/warcraft-map-work/rexxar/unified-build`. Inputs are the same 17
original maps in `coop/inputs`; prepared individual generated scripts are in
`/workspace/warcraft-map-work/rexxar/vi-fix-build/scripts`.

Implemented foundation:

- `unified_terrain.py`: all 17 playable regions + 2 original border cells on
  each edge fit 480x480, within an outer 8-cell margin. Deterministic max-rects
  packing. Original height, cliff, water and pathing grids copied. Ground
  materials reduced from 62 to 16 (classic four-bit limit); 14 cliff materials.
  Standalone terrain merge executed successfully. All 3,646 source preplaced
  units were checked against each cropped region +2 cells: none outside.
- `unified_script.py`: token-based source namespacing, exact TRIGSTR resolution,
  rawcode rewriting, absolute-coordinate relocation, and source/runtime split.
- `unified_catalog.py`: starts with the existing portable catalog to preserve
  RIxx item identities, then plans disjoint IDs for per-map object variants.
- `Tools/AtlasPlacements.cs`: merged units/doodads/random tables and coordinate
  shifts; .NET project compiles, but the actual merge has NOT been executed yet.
- `unified_build.py`: preparation orchestrator; not a complete map builder.

Current failure: preparation stops while reading additional object tables in
`UnifiedCatalog.__init__`: `read_objects(..., leveled=True)` is not correct for
at least one w3d/w3q table. Identify the subtype and use its actual binary
layout (or War3Net) before proceeding. No unified W3X has been produced.

Remaining design, not implemented:

- One shared cooperative runtime, original globals/functions prefixed Z00_..
  Z16_, and dynamic hook dispatch by active RC_map. No 17 duplicate runtimes.
- Lazy initialization per location, tracked unit groups, paused/hidden/neutral
  inactive locations, tracked explicit timer handles, source sleep guards.
- One physical party (1..4 occupied human slots); heroes and their armies move
  together. No serialization/recreation of heroes on a door transition.
- On returning, call the original Import_All and Resume_Game routines to sync
  quests and use original Set_Hero_Locations spawn A/B/C; place fourth hero
  alongside party when original act-I code only knows three. Keep world actors
  and original quest variables in memory. Partition shared story by act.
- Original Export_Mission_Data can populate in-memory cache; disable StoreUnit
  serialization because actual heroes persist. Track stash migration, quest
  visibility, sounds, cinematics and resource initialization across entries.
- Replace anonymous trigger timers with tracked timer-expire events so their
  remaining time survives inactive zones. Protect portal conditions during
  load and a short post-arrival interval against immediate bounce-back.
- Native campaign AI exists only in OrcX02_06, OrcX03a and OrcX03b. Per-map unit
  aliases and reused NPC player IDs may affect those AI scripts. Must resolve
  this rather than assert a complete native campaign playthrough.
- Merge/output classic W3I, object tables, doodads, terrain and proper minimap;
  syntax/structure/original-function tests, actual transition event tests,
  native-client party test with user. No native Warcraft client is available.

User-facing updates already explained the 17-region atlas and necessary ground
material sharing; promised no next downloadable campaign until internal
multiplayer location transitions are implemented. Do not imply background work
or scheduled delivery when this task is paused.
