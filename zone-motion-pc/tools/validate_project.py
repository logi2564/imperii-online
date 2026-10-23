#!/usr/bin/env python3
"""Check recovered asset links and compile runtime C# against Unity 2017 refs.

This does not run Unity, build a Player, or validate gameplay.
"""
from collections import Counter
from concurrent.futures import ThreadPoolExecutor
import hashlib
import json
import os
from pathlib import Path
import re
import struct
import subprocess

import dnfile

root = Path(__file__).resolve().parents[1]
project = root / "project"
inspection = root / "inspection"
references = inspection / "Managed"
sdk = Path(os.environ.get("ZONE_DOTNET_ROOT", "/workspace/.tools/dotnet-8"))
compiler = sdk / "sdk/8.0.426/Roslyn/bincore/csc.dll"
assert compiler.is_file(), "The verified .NET SDK 8.0.426 is required."
assert (references / "UnityEngine.UI.dll").is_file(), "Extract managed references from the original APK."

guids = {}
for meta in project.glob("Assets/**/*.meta"):
    match = re.search(r"^guid: ([0-9a-f]{32})$", meta.read_text(errors="replace"), re.M)
    if match:
        guid = match.group(1)
        assert guid not in guids, f"Duplicate asset GUID: {meta}"
        guids[guid] = str(meta.relative_to(project))

# Unity's legacy assembly script FileIDs use MD4 for identifiers, not security.
# Match every external UI script to an actual type from the APK's UI library.
ui_types = {}
ui = dnfile.dnPE(str(references / "UnityEngine.UI.dll"))
for row in ui.net.mdtables.TypeDef.rows:
    namespace, name = str(row.TypeNamespace), str(row.TypeName)
    digest = subprocess.run(
        ["openssl", "dgst", "-md4", "-provider", "legacy", "-binary"],
        input=b"s\0\0\0" + (namespace + name).encode(),
        capture_output=True, check=True,
    ).stdout
    ui_types[struct.unpack("<i", digest[:4])[0]] = namespace + "." + name

builtin = {
    "00000000000000000000000000000000", "0000000000000000f000000000000000",
    "0000000000000000e000000000000000", "0000000000000000d000000000000000",
}
ui_guid = "f5f67c52d1564df4a8936ccd202a3bd8"
unresolved = Counter()
ui_used = set()
for path in project.glob("Assets/**/*"):
    if not path.is_file() or path.suffix not in {".unity", ".prefab", ".asset", ".mat", ".controller"}:
        continue
    data = path.read_bytes()
    if not data.startswith(b"%YAML"):
        continue
    for raw in re.findall(rb"guid: ([a-f0-9]{32})", data):
        guid = raw.decode()
        if guid not in guids and guid not in builtin and guid != ui_guid:
            unresolved[guid] += 1
    ui_used.update(map(int, re.findall(
        rb"fileID: (-?\d+), guid: f5f67c52d1564df4a8936ccd202a3bd8", data)))
assert not unresolved, f"Unresolved asset GUIDs: {unresolved}"
assert ui_used and all(file_id in ui_types for file_id in ui_used), "Unknown Unity UI type reference."

settings = (project / "ProjectSettings/EditorBuildSettings.asset").read_text()
scenes = re.findall(r"path: (.+)", settings)
assert len(scenes) == 14 and scenes[0] == "Assets/Scens/Menu.unity"
assert all((project / scene).is_file() for scene in scenes), "A build scene is missing."
assert (project / "Assets/Editor/WindowsBuild.cs").is_file()

sources = sorted((project / "Assets/Scripts/Assembly-CSharp").rglob("*.cs"))
common = ["/nologo", "/target:library", "/unsafe+", "/nostdlib+", "/langversion:6"]
common += ['/reference:"' + str(path) + '"' for path in sorted(references.glob("*.dll"))
           if path.name != "Assembly-CSharp.dll"]
common += ['"' + str(path) + '"' for path in sources]


def compile_target(target):
    folder = inspection / "build" / target
    folder.mkdir(parents=True, exist_ok=True)
    defines = "UNITY_STANDALONE;UNITY_STANDALONE_WIN" if target == "desktop" else "UNITY_ANDROID"
    args = common + ["/define:" + defines + ";UNITY_2017_2;UNITY_2017_2_OR_NEWER",
                     "/out:" + str(folder / "Assembly-CSharp.dll")]
    response = folder / "compile.rsp"
    response.write_text("\n".join(args))
    result = subprocess.run([str(sdk / "dotnet"), str(compiler), "@" + str(response)],
                            capture_output=True, text=True, cwd=root)
    output = result.stdout + result.stderr
    (folder / "compile.log").write_text(output)
    errors = [line for line in output.splitlines() if ": error " in line]
    assert result.returncode == 0 and not errors, "\n".join(errors[:20]) or output
    assert (folder / "Assembly-CSharp.dll").is_file(), "Compiler produced no assembly."
    return {"target": target, "exit_code": result.returncode, "errors": len(errors),
            "warnings": len(re.findall(r": warning CS\d+:", output))}


with ThreadPoolExecutor(max_workers=2) as pool:
    results = list(pool.map(compile_target, ["desktop", "android"]))

report = {
    "runtime_sources": len(sources), "scene_count": len(scenes), "scenes": scenes,
    "asset_guid_count": len(guids), "unresolved_project_asset_guids": dict(unresolved),
    "external_unity_ui_types": [ui_types[n] for n in sorted(ui_used)],
    "compilation": results,
    "source_sha256": {str(path.relative_to(project)): hashlib.sha256(path.read_bytes()).hexdigest()
                      for path in sources},
    "unity_player_built": False, "windows_gameplay_tested": False,
}
(inspection / "validation.json").write_text(json.dumps(report, ensure_ascii=False, indent=2))
print(json.dumps({key: value for key, value in report.items() if key != "source_sha256"},
                 ensure_ascii=False, indent=2))
