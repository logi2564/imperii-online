Negative lobby fixtures extracted from released RC2 OrcX01: https://github.com/logi2564/imperii-online/releases/tag/rexxar-coop-rc2-0138e829 . They preserve the actual unsorted W3I records and conflicting config teams. These fixtures are not playable maps.
{
  "rc2-OrcX01.w3i": "8d6a3f4e75650a93aeab6db206e684218214599dbf6d24dfdbc136a5ce6b4bfe",
  "rc2-OrcX01-config.j": "1a1cb5015d0fa96a1ae0fbb4178f6876c6d75f5829533ea250b9a07570ca8134"
}

RC3 first-map W3I/config are also retained from release rexxar-coop-rc3-799d2340. The prior structural checks accepted it, while explicit player-colour recording reveals that SetPlayerColor was omitted. This is a setup difference, not proof that it caused the user's native rejection.

`accepted-C.w3i` and `accepted-C-config.j` come from the exact C file
SHA256 `1f807fe9efd802fc26d1d51816de695797aa1a910e449a436b4b007aac7c40a3`.
User confirmed lobby entry and then provided a gameplay screenshot on
1.26.0.6401. IV must retain its lobby records/config except identifying
name/description, while intentionally replacing the gameplay implementation.
