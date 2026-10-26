# 23 Races 3.2D: editor recovery for classic NewGen

Recovery of the uploaded `70818_23Racesv3.2D.w3x` (SHA-256 `f6941774df1ea1b7047df9dd6639e9053484f3282c4982cab419670dc166a268`). The original was 8,152,173 bytes, with an intentionally invalid MPQ header and missing editor files.

The release restores classic `w3i` v25 / editor 6052, units v8.11, WTG v7, WCT v1, regions v5, sounds v1 and imports v1. Terrain is 480×480: NewGen's **Enable No Limits** is required. There are 821 placed units, 12 start locations, 64 regions, 9 sounds and 477 recovered source globals (plus two technical GUI variables).

The game's original JASS remains byte-for-byte intact under both `Scripts\war3map.j` and `war3map.j`. Editable custom code renames original symbols, binds original placements to editor-created handles, and avoids recreating the standard Blizzard state, region weather, sounds and referenced destructables. The original GUI graph cannot be reconstructed; logic is available as JASS in the map custom code header.

All 570 model/texture payloads are retained. Thirty unresolved filenames get editor-visible aliases without duplicating or recompressing the content; original hash entries remain in the downloadable map. Details are in `known-names.json`, `resource-aliases.json` and `original-assets.json`. The import manager lists 569 resources, excluding native map preview/media data.

The original asset compression is retained while encryption is removed, allowing alias hash entries to reference the same data blocks. This keeps the current file below classic Warcraft's 8 MiB multiplayer limit. Saving/editing in an editor can change compression and file size.

## Validation

- Native StormLib reads the final W3X; all 589 unchanged original filename-hash entries and all aliases match original decoded SHA-256 values. Only `(listfile)` and `war3map.w3i` are intentionally replaced; missing editor components are added.
- A separate strict W3I parser checks all classic level-info fields, player IDs, camera margins, terrain dimensions and complete EOF tables; it does not accept the protector's FF shortcut.
- `MapCheck` opens the actual release using War3Net 6.1.2, checks placements/imports and generates the post-save script from the embedded editor metadata and custom code.
- Both original gameplay and generated editor script are compiled by pjass against classic `common.j` and `Blizzard.j`.

The actual NewGenWE/UMSWE GUI and a running Warcraft match have **not** been tested. These checks establish archive/content integrity, classic serialization and JASS compile compatibility, not a confirmed native editor session.

The `source/` copies normalize text line endings for reading. The in-map gameplay payload keeps its original bytes. Russian user instructions are in [README-RU.txt](README-RU.txt).
