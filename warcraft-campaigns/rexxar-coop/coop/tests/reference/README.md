`common.j` and `Blizzard.j` are the actual classic **1.24.4** script declarations from w3x2lni `data/zhCN-1.24.4/mpq/Scripts` at commit `82916514a12b7edb15252d42225cd8cc8ce61cfd`. RC3 uses these for full-script pjass checks and transpilation, replacing the earlier 1.32.9 test references. All 17 RC2 scripts also pass these classic declarations: this check alone does not establish the cause of the user's rejected lobby.

Line endings/trailing whitespace are normalized for the repository. These are build/test references. They are NOT embedded in the maps or used to supply IrinaBot's patch-specific map CRC/SHA1: those require the hosting service's actual matching game version.

`classic-api-names.json` remains an additional name audit against the older classic wc3lib reference. That old wc3lib TEST Blizzard.j incorrectly declared GetDyingDestructable as widget; the actual classic declaration used now returns destructable correctly.

No native Warcraft engine or live IrinaBot handshake is simulated by these files.
