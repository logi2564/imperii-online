# Rexxar four-player campaign — source collection

The user's requested target is the complete three-act **Founding of Durotar** campaign for four players on Warcraft III 1.26. The original campaign is currently inside their local installation, which this cloud workspace cannot access. No replacement mini-campaign is being presented as the original campaign.

`Export-Rexxar-Maps.exe` is the first source-collection tool. It opens only known classic Warcraft MPQs for reading, searches the seventeen original mission paths, prefers patch/localized versions, checks nested map archives, and exports byte-identical maps into per-act ZIP parts. Its manifest reports missing sources explicitly. The user then sends the exported sources; the cooperative campaign is still to be built from those actual missions.

The exporter reads installation paths from the local registry when available, or asks for the game folder. It writes a separate timestamped desktop folder, makes no network requests and includes no personal installation paths or unrelated files in the manifest. The reader is [War3Net.IO.Mpq](https://github.com/Drake53/War3Net), version 6.0.3. The campaign path inventory was cross-checked against the community Warcraft MPQ listfile.

Run `dotnet run --project tools/ExportRexxar -- --self-test --no-pause` for the source-export checks. The workflow additionally publishes a self-contained Windows x64 executable and runs that exact EXE on Windows. Tests exercise all seventeen paths, patch priority, Russian locales, invalid-patch fallback, ZIP splitting and byte identity, read-only source archives, and missing/partial installation reporting. They do not claim an actual installed campaign or Warcraft gameplay has been tested.
