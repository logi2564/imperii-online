# European War 4 — complete offline Windows and Android game

Version 0.3.1 ships the actual EW4 Rewrite engine and assets on both platforms. Android has its own campaigns, conquest, headquarters and saves; it no longer requires a PC for single-player. Both apps start at the main menu and load a save only after the player chooses it. Multiplayer still uses a Windows host and an invitation entered inside the full Android game.

This is a separate unofficial reconstruction, not an update to the official EasyTech APK. The phone package is `org.logi2564.ew4fullgame.r31`, distinct from the older connection-only app. Six campaign chapters, conquest and the engine's built-in content are available. Original assets and rights remain with their owners. See [player instructions](NATIVE-READ-ME.txt).

## Multiplayer and translation fixes in 0.3.1

End-turn permissions are independent of dialogue acknowledgement and are checked against the authenticated country on the server. Both end buttons lock outside the owning country’s active turn and immediately consume new permissions from an action response. The online AI-skip control is hidden. Tests attempt repeated foreign end commands and both country views.

Creating a party opens setup directly. Invitations become copyable only after the public tunnel health check succeeds. Join checks protocol 31, provides paste and retry controls, and retains the last invitation locally. Lost connections disable input and recover without replacing the seat. Status polling is shared between lobby and game, and JSON responses use compression.

Android serves pinned frontend, art, audio and fonts from its APK while keeping login, status and commands on the authoritative PC. It caps touch rendering at CSS resolution and 24 Hz, and keeps the foreground screen awake. The app has a separate package identifier to avoid deleting a previously installed build with a different development certificate; older saves remain in the older app. Russian overrides cover item errors, dynamic control labels and campaign/conquest/headquarters captions.

## Earlier startup fixes

Windows disables Electron hardware acceleration and WebGL, and explicitly selects Canvas 2D. Animation is capped at 30 Hz and the drawing surface at 1.25 DPR. The game uses a compact bundled Cyrillic font instead of loading the 53 MB Chinese font collection. Online save restoration is deferred until multiplayer is opened. The window shows startup progress immediately, then the real menu. The full game uses a separate `BroEW4FullGame` profile/save root, so an older running client cannot capture the new EXE startup or write to its saves. Older files in `BroEW4Online` are left unchanged.

These changes avoid the previous accelerated graphics path; they do not establish the cause of a reported Windows crash. No STOP CODE or dump from the user's computer was available. The optional `Check-Windows.cmd` reads the recent numeric bugcheck code, Windows build and GPU/driver names into a local file, without uploads, dumps or account identifiers. A physical user PC has not been tested.

## Full game and localization

[fullgame/apply_fullgame.py](fullgame/apply_fullgame.py) checks the pinned upstream revision, applies the multiplayer hooks and restores the original full campaign/tutorial/headquarters UI. Windows single-player has an independent local engine and save directory; its API is accessible only through a loopback host. Android uses the upstream .NET Android engine and local asset interception, with all original battle files and game media bundled in the APK. Local and online engines do not share mutable worlds.

The Russian game table, mission descriptions, dialogues, interface text and city labels are bundled. [fullgame/build_locale.py](fullgame/build_locale.py) checks coverage and preserves the original source files/hashes used by engine validation. The game text is machine translated, with reviewed overrides for common interface commands. Some historical background artwork retains its original map lettering. Cyrillic paragraphs wrap at word boundaries and scroll within the original game panels. No translation service is contacted during gameplay.

A validated HTTPS invitation switches the Android WebView to the shared party inside the app. External navigation is blocked. The Windows PC must remain running for multiplayer; offline Android does not need that PC or a network connection. The earlier server ownership, stale-command rejection, independent country views and durable saves remain in place.

## Verification and publishing

[ew4-fullgame.yml](../.github/workflows/ew4-fullgame.yml) publishes only after both platform jobs pass. Tests exercise a real Windows EXE, full menus/headquarters, a campaign, controller movement, manual save, restart into the menu, explicit save restoration, software rendering and drawing timing. An installed Android game is tested with Wi-Fi/mobile data disabled, then with a live PC host through public HTTPS. These tests use isolated profiles. Only controlled JSON and game screenshots are uploaded, never logs, user profiles, invitation credentials or memory dumps.

Neither a complete campaign nor physical user devices are claimed as tested. Test timings describe the build machines. Android needs Android 8+ and a functioning system WebView. APKs use a development signing certificate; save preservation needs consideration before reinstalling a differently signed future build.

To build: clone the pinned source in [UPSTREAM.json](UPSTREAM.json), run `python ew4-online/fullgame/apply_fullgame.py ENGINE`, install `ENGINE/tools/frontend` with `npm ci`, and publish `Ew4.Web` for Windows. Android requires .NET 10.0.100's Android workload and JDK 21; [fullgame/build_android.py](fullgame/build_android.py) builds release/test APKs and validates embedded resources. Electron 45.0.0 is pinned, and its explicit `install.js` step is required after `npm ci`.
