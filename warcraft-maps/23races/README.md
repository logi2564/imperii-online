# 23 Races 3.2D — individually restored triggers

The protected upload lacked editor trigger data. This revision replaces the previous single shared JASS block with **262 named original trigger entries**, in their original initialization order:

- **69 GUI entries** with visual events/conditions and supported actions; unsupported actions remain as 82 custom-script lines. There are 137 recovered visual actions.
- **193 custom-text entries**, each containing its own full original JASS functions and native editor initializer.
- Three technical entries bind placed objects, initialize shared state, and run the original initialization event once.

Open `23-Races-3.2D-Triggers-NewGen-1.26.w3x` with NewGenWE/UMSWE for Warcraft III 1.26, enable **Grimoire → Enable No Limits**, and open **F4 → 01 - Original triggers (262)**. Save to a new filename. The original GUI layout and all visual actions cannot be recovered from the optimized JASS; complex triggers such as Human and Orc remain JASS. See [README-RU.txt](README-RU.txt).

The runtime script, terrain, objects and assets remain unchanged. The archive stays below the classic 8 MiB multiplayer limit. Editor metadata includes 821 units, 12 start locations, 64 regions, nine sound handles and 16 music strings.

Validation reopens the actual artifact with StormLib and War3Net, checks every preserved asset and strict classic metadata, verifies WTG/WCT pairing and all 262 names/order, compares all 865 original trigger functions with the reconstructed editor script, and compiles both scripts with classic JASS libraries. The token comparison permits only formatting/comments, equivalent numeric encodings and consistent symbol renaming. Unmatched GUI conversions fall back to their full original JASS. Native NewGenWE and an actual Warcraft game have **not** been run here.

`source/trigger-index.json` lists the format of every entry. `source/gui-equivalence.json` records accepted and rejected GUI candidates. The external source copies are for inspection; edit the map's entries to change the game. The GitHub Actions workflow repeats the independent checks before publishing the W3X and ZIP.
