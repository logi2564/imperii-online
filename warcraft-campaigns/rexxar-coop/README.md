# Rexxar four-player campaign — actual mission adaptation

The user has now provided all seventeen original missions. The current implementation is [the experimental RC2 adaptation](coop/README.md), with actual four-player maps, heroes, signature skills, difficulty and portable character/story/stash save codes. The workflow builds those maps and a small Windows clipboard helper. Real Warcraft III 1.26 gameplay has **not** been tested; the output is not described as a verified complete playthrough.

The source-export and slot-only tools below are historical preparation steps.

The user's requested target is the complete three-act **Founding of Durotar** campaign for four players on Warcraft III 1.26. No replacement mini-campaign is being presented as the original campaign.

`Export-Rexxar-Maps.exe` was the first source-collection tool. It opens only known classic Warcraft MPQs for reading, searches the seventeen original mission paths, prefers patch/localized versions, checks nested map archives, and exports byte-identical maps into per-act ZIP parts. Its manifest reports missing sources explicitly.

The exporter reads installation paths from the local registry when available, or asks for the game folder. It writes a separate timestamped desktop folder, makes no network requests and includes no personal installation paths or unrelated files in the manifest. The reader is [War3Net.IO.Mpq](https://github.com/Drake53/War3Net), version 6.0.3. The campaign path inventory was cross-checked against the community Warcraft MPQ listfile.

Run `dotnet run --project tools/ExportRexxar -- --self-test --no-pause` for the source-export checks. Tests exercise all seventeen paths, patch priority, Russian locales, invalid-patch fallback, ZIP splitting and byte identity, read-only source archives, and missing/partial installation reporting. They do not claim an actual installed campaign or Warcraft gameplay has been tested.

# Four lobby slots

`tools/FourSlots` builds `Rexxar-4-Slots.exe`. It can read the installed campaign or accept a dragged `.w3x`, and writes new copies with four human lobby positions. See [FOUR-SLOTS-RU.txt](FOUR-SLOTS-RU.txt) for use and exact limitations. It does not implement hero assignment, multiplayer quests, balance or campaign transitions.

The patcher supports classic W3I 18/25 and MPQ v0. Only inactive/missing player positions not explicitly referenced by gameplay `Player(n)` calls qualify; active computer, neutral and rescuable factions are retained. A map is refused when three spare positions cannot be found. Static reference scanning cannot prove arbitrary dynamic script behavior safe; game testing is still required.

Map info editing preserves raw prefix/tail bytes. Config overrides are appended after original configuration. MPQ replacements are appended, retaining all unrelated block offsets/bytes and hash slots, including unknown encrypted imports; obsolete checksums/signatures are tombstoned. Existing map files are never overwritten. Tests include encrypted unnamed imports without a listfile and an independent War3Net.Build W3I reader. The workflow publishes a self-contained Windows x64 slot patcher, runs that exact EXE's tests on Windows, and exercises its map-processing command line. Neither Warcraft nor NewGen has been run here.
