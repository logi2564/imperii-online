#!/usr/bin/env python3
"""Package the source project; this does not build a Windows executable."""
import argparse
import hashlib
import json
from pathlib import Path
from zipfile import ZIP_DEFLATED, ZipFile

parser = argparse.ArgumentParser()
parser.add_argument("--output", type=Path, default=Path("dist"))
args = parser.parse_args()
root = Path(__file__).resolve().parents[1]
report = json.loads((root / "VALIDATION.json").read_text())
assert report["unity_player_built"] is False
assert report["windows_gameplay_tested"] is False
assert all(item["exit_code"] == 0 and item["errors"] == 0 for item in report["compilation"])
sources = set((root / "project/Assets/Scripts/Assembly-CSharp").rglob("*.cs"))
assert len(sources) == len(report["source_sha256"]) == 795
for relative, digest in report["source_sha256"].items():
    path = root / "project" / relative
    assert path in sources and hashlib.sha256(path.read_bytes()).hexdigest() == digest, relative
assert len(report["scenes"]) == 14
assert all((root / "project" / name).is_file() for name in report["scenes"])

args.output.mkdir(parents=True, exist_ok=True)
archive = args.output / "ZoneMotion-PC-project.zip"
with ZipFile(archive, "w", compression=ZIP_DEFLATED, compresslevel=9) as package:
    for path in sorted((root / "project").rglob("*")):
        if path.is_file():
            assert not any(part in {"Library", "Temp", "Obj", "Logs", "UserSettings"}
                           for part in path.relative_to(root / "project").parts)
            package.write(path, "ZoneMotion-PC/" + path.relative_to(root).as_posix())
    for name in ["README-PC.md", "BUILD-WINDOWS.cmd", "VALIDATION.json"]:
        package.write(root / name, "ZoneMotion-PC/" + name)
with ZipFile(archive) as package:
    assert package.testzip() is None
    assert len([name for name in package.namelist() if name.endswith(".unity")]) == 14
digest = hashlib.sha256(archive.read_bytes()).hexdigest()
archive.with_suffix(".zip.sha256").write_text(digest + "  " + archive.name + "\n")
print(f"Verified source project archive: {archive} ({archive.stat().st_size} bytes)")
