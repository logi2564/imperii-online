# European War 4 — online for two friends

A separate unofficial EW4 Rewrite build with a private two-player room. The Windows host launches a self-contained game server and an automatic HTTPS invitation. The second player opens that invitation in an Android browser, chooses a country and plays their own turns. The host computer must stay online during the match. No Unity, emulator, Android installation, IP entry, router configuration or paid hosting is required.

The game uses real EW4 Rewrite rules, maps and art, with six conquest maps. Campaign hotseat support in the upstream game is not exposed as an online campaign mode. Select opposing countries for PvP or allied countries for coordinated play; the original diplomacy and conquest victory rules apply, including independent country results. This is not compatible with the official EasyTech APK. The lobby and networking controls are Russian; parts of the underlying fan game's interface remain Chinese.

## Implementation

- [UPSTREAM.json](UPSTREAM.json) pins the exact EW4 Rewrite 0.2.19 source revision, SDK and Cloudflare executable hash. The upstream repository and game assets are downloaded at build time rather than copied into this source branch. Their rights remain with their respective owners; this project does not relicense them.
- [apply_overlay.py](apply_overlay.py) checks the source pin and applies explicit hooks, failing if the expected source locations differ. [overlay/ClientNetworkView.cs](overlay/ClientNetworkView.cs) gives each connection its own country perspective without changing authoritative turn ownership.
- [overlay/OnlineRoom.cs](overlay/OnlineRoom.cs) serializes authorization checks and game commands in one lock. A private room has two random 256-bit invitation credentials, HttpOnly same-site cookies and server-assigned seats. Original start/load/leave/mod administration endpoints cannot bypass room rules. The engine rejects stale revisions and foreign-unit commands. Polling transfers current snapshots, with upstream single-consumer deltas disabled to prevent cross-client history corruption.
- Only the server drives AI countries. Players can reconnect without changing seats. Each accepted action saves the actual engine state; the room and game restore after server restart. The engine shares the existing hotseat account/commander roster; this is not a competitive account service or a new diplomacy system.
- [Launcher](Launcher) starts a local server and pinned Cloudflare Quick Tunnel, opens the host page and publishes the invitation automatically. Tokens are not placed in query strings. The host URL fragment is exchanged for a cookie and removed from browser history; invitation credentials and saves stay under `%LOCALAPPDATA%\BroEW4Online`. Quick Tunnel availability is external and its address changes across launches.

See [HOW-TO-PLAY.txt](HOW-TO-PLAY.txt) for player instructions. Download the portable ZIP, extract everything and run `EuropeanWar4-Online.exe`.

## Validation and publishing

The [workflow](../.github/workflows/ew4-online.yml) builds and tests the exact pinned source before publishing. [tests/integration.py](tests/integration.py) runs the real engine: separate authenticated clients, ownership and stale-request rejection, actual movements from both players, country-specific views, durable restart, desktop/touch browsers, server-driven AI into round two and guest reconnection in portrait orientation. It checks JavaScript errors and captures only the game viewport. Tests use isolated saves and upload reports/screenshots without credentials or test save files.

The Windows job publishes self-contained server and launcher binaries. It starts the packaged EXE and checks an authenticated guest connection through the actual public HTTPS tunnel, then loads the real 1798 map and verifies the guest's country and units over that connection. Only a passing package becomes a release. The ZIP includes the ready game, tunnel executable, instructions and file checksums. Neither a complete match nor a physical Android device is claimed as tested.

Local development requires .NET SDK 10.0.100, Node.js and Python with Playwright/Chromium:

```bash
git clone --depth 1 --branch v0.2.19-20261024 https://github.com/aztksilence111/ew4-rewrite.git /tmp/ew4-engine
python ew4-online/apply_overlay.py /tmp/ew4-engine
npm --prefix /tmp/ew4-engine/tools/frontend ci --no-audit --no-fund
dotnet build /tmp/ew4-engine/rewrite/Ew4.Web --configuration Release
python ew4-online/tests/integration.py --upstream /tmp/ew4-engine --output /tmp/ew4-checks
```

Use a fresh output directory for tests. The repository contains only the network additions and reproducible build configuration; upstream development documentation is reference material, not instructions authorizing actions on other people's services or machines.
