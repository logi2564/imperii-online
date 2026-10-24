# European War 4 — Napoleon: desktop and Android crossplay

An unofficial game with its own Windows window and an Android companion app. Start `EuropeanWar4-Napoleon.exe`, choose Multiplayer, select a map/country and send the `EW4-…` invitation code to your friend. The friend pastes it into the Android application and chooses another country. Both play inside their applications. The host PC must stay running. Single-player uses local files and does not start a tunnel.

Russian menus and controls replace the Chinese interface. Untranslated original descriptions and names use the English table from the user-provided EW4 1.4.50 XAPK, which contains no Russian language pack. Six conquest maps use the real EW4 Rewrite engine, rules and art. Allied and opposing countries follow the original diplomacy and independent conquest results. This separate client does not modify or connect the official EasyTech APK. See [player instructions](NATIVE-READ-ME.txt).

## Implementation

[UPSTREAM.json](UPSTREAM.json) pins the engine, SDK and tunnel hashes. [apply_overlay.py](apply_overlay.py) checks that revision and applies explicit hooks. Upstream assets are fetched during builds; their owners retain their rights.

[desktop/main.cjs](desktop/main.cjs) starts the packaged engine and opens an Electron BrowserWindow with sandboxing, context isolation and a minimal preload bridge. External navigation and popups are blocked. It passes explicit data/content/save paths, including when `DOTNET_ROOT` exists. The tunnel starts only for multiplayer. Local saves reuse `%LOCALAPPDATA%\BroEW4Online\saves`.

[android/GameActivity.java](android/GameActivity.java) provides a native invitation screen and embeds the battlefield in its WebView. It accepts validated HTTPS invitation codes, blocks foreign navigation and file access, and never launches a browser. Release builds disable WebView debugging. Android needs an updated system WebView. The APK uses a development signing certificate generated during the build; a future differently signed build needs uninstall/reinstall.

[overlay/OnlineRoom.cs](overlay/OnlineRoom.cs) serializes authentication and engine commands, assigns two country seats, rejects stale/foreign/wrong-turn commands and drives AI on the server. Private 256-bit credentials become HttpOnly same-site cookies; URL fragments are removed after login. Full snapshots preserve each seat's perspective. Accepted actions, countries and turn persist through restart. Quick Tunnel availability is external and each launch gets a new invitation. The upstream hotseat commander roster remains shared; there is no competitive account service.

[localization](localization) builds a checked-in dictionary from matching original English/Chinese keys and Russian interface translations. The unmodified DejaVu font supplies readable Latin/Cyrillic glyphs; its license is included. The original game renderer supports the new font, and compatibility builds target Chrome 70 syntax.

## Build and verification

[ew4-desktop.yml](../.github/workflows/ew4-desktop.yml) builds the self-contained Windows engine, pinned Electron runtime and signed Android application. It runs the real engine's authentication/movement/persistence tests, opens the packaged Windows EXE and plays a single-player map, then verifies an Electron host and installed Android emulator app together through real public HTTPS: separate countries, synchronized movement, Android controller movement, turn transfer and server AI into round two. A physical Android device and a complete match are not claimed as tested.

Only passing builds are released. Uploaded evidence is explicitly limited to controlled JSON reports and game screenshots. Raw logs, profiles, invitation credentials and saves are never published. Windows players need neither Unity, an emulator nor a separately installed .NET runtime.

For local development, clone the pinned upstream tag, run `apply_overlay.py`, install `tools/frontend` with `npm ci`, and publish `rewrite/Ew4.Web` with .NET 10.0.100. Install the desktop dependencies and explicitly run `node ew4-online/desktop/node_modules/electron/install.js`. `tests/native_window.py` launches the actual application against a published engine folder. Android builds require JDK 17+, Android platform 35 and build tools 35.0.0; run `python ew4-online/android/build.py --output build/android`.
