#!/usr/bin/env python3
"""Prepare a native-player compatibility candidate; not a Unity Editor build.

Only game data and game C# are adapted. The official player is copied unchanged;
license/entitlement fields, engine binaries and the Unity splash are not patched.
Windows execution and screenshots are required before distributing it as a game.
"""
import argparse
import collections
import hashlib
import json
import os
from pathlib import Path
import shutil
import subprocess
import urllib.request
import zipfile

import UnityPy
from UnityPy.enums import BuildTarget

APK_SHA256 = '23eeb5a6b082b31e117222c8b6ca84aed8de2c58a0837300df4e96d48b847607'
UNITY_SHA256 = 'df48bdc3e204c510e5a1fe257694a8b52f8bef477aaca975723936cec7bc91da'
UNITY_MD5 = 'eea7a4e91a180da9561df0f5bbf3b0f2'
NATIVE = Path(__file__).resolve().parent
ROOT = NATIVE.parent


def fetch(url, path, sha256):
    if not path.is_file() or hashlib.sha256(path.read_bytes()).hexdigest() != sha256:
        print('Downloading', path.name, flush=True)
        with urllib.request.urlopen(url, timeout=120) as response, path.open('wb') as out:
            shutil.copyfileobj(response, out)
    assert hashlib.sha256(path.read_bytes()).hexdigest() == sha256, path.name


parser = argparse.ArgumentParser()
parser.add_argument('--work', type=Path, required=True)
parser.add_argument('--output', type=Path, required=True)
parser.add_argument('--seven-zip', default='7z')
parser.add_argument('--dotnet', default='dotnet')
args = parser.parse_args()
args.work.mkdir(parents=True, exist_ok=True)
apk = args.work / 'ZoneMotion.apk'
installer = args.work / 'UnitySetup64-2017.2.0f3.exe'
fetch('https://drive.usercontent.google.com/download?id=1o_hPS0Tgwz5ZCIcXxGraZplTKD4361nV&export=download&confirm=t', apk, APK_SHA256)
fetch('https://download.unity3d.com/download_unity/46dda1414e51/Windows64EditorInstaller/UnitySetup64.exe', installer, UNITY_SHA256)
assert hashlib.md5(installer.read_bytes()).hexdigest() == UNITY_MD5

runtime_root = args.work / 'official-runtime'
variation = 'Editor/Data/PlaybackEngines/windowsstandalonesupport/Variations/win64_nondevelopment_mono'
subprocess.run([args.seven_zip, 'x', str(installer), '-o' + str(runtime_root),
                variation + '/*', '$PLUGINSDIR/License.rtf', '-y', '-bso0'], check=True)
runtime = runtime_root / variation
output = args.output.resolve()
if output.exists():
    raise RuntimeError('Use a fresh output directory: ' + str(output))
output.mkdir(parents=True)
data = output / 'ZoneMotionPC_Data'
shutil.copytree(runtime / 'Data', data, ignore=shutil.ignore_patterns('*.xml', '*.mdb', '*.pdb'))
for src, dest in [('WindowsPlayer.exe', 'ZoneMotionPC.exe'), ('UnityPlayer.dll', 'UnityPlayer.dll')]:
    shutil.copy2(runtime / src, output / dest)
    assert (runtime / src).read_bytes() == (output / dest).read_bytes()
shutil.copy2(runtime_root / '$PLUGINSDIR/License.rtf', output / 'Unity-LICENSE.rtf')

with zipfile.ZipFile(apk) as package:
    assert package.testzip() is None
    for name in package.namelist():
        prefix = 'assets/bin/Data/'
        if not name.startswith(prefix) or name.endswith('/'):
            continue
        relative = Path(name[len(prefix):])
        assert not relative.is_absolute() and '..' not in relative.parts
        dest = data / relative
        # The game assembly is rebuilt below. Loading the old DLL into the data
        # parser holds a Windows file handle and prevents replacing that DLL.
        if relative.as_posix() == 'Managed/Assembly-CSharp.dll':
            continue
        # Use matching Windows engine modules, while retaining game/SDK libraries.
        if relative.parts[0] == 'Managed' and dest.exists():
            continue
        # These engine built-ins carry the desktop runtime's shader variants.
        if relative.as_posix() == 'Resources/unity default resources':
            continue
        dest.parent.mkdir(parents=True, exist_ok=True)
        dest.write_bytes(package.read(name))

print('Adapting game assets', flush=True)
asset_paths = [str(path) for path in data.rglob('*') if path.is_file() and
               not {'Managed', 'Mono', 'MonoBleedingEdge'}.intersection(path.relative_to(data).parts)]
environment = UnityPy.load(*asset_paths)
counts = collections.Counter()
protected_build_settings = None
for obj in environment.objects:
    if obj.assets_file.target_platform != BuildTarget.Android:
        continue
    if obj.type.name == 'Texture2D':
        texture = obj.read()
        if texture.m_TextureFormat not in {1, 3, 4, 5, 7, 9, 10, 12, 13}:
            image = texture.image
            texture.set_image(image, target_format=4)
            texture.save()
            counts['converted_textures'] += 1
    elif obj.type.name == 'PlayerSettings':
        tree = obj.read_typetree()
        for key, value in {'productName': 'Zone Motion PC', 'defaultScreenWidth': 1280,
                           'defaultScreenHeight': 720, 'defaultIsFullScreen': False,
                           'defaultIsNativeResolution': False, 'displayResolutionDialog': 0,
                           'forceSingleInstance': True, 'resizableWindow': False}.items():
            assert key in tree
            tree[key] = value
        obj.save_typetree(tree)
    elif obj.type.name == 'BuildSettings':
        tree = obj.read_typetree()
        # Keep all existing license, watermark and authorization fields verbatim.
        protected_build_settings = {key: value for key, value in tree.items() if key != 'm_GraphicsAPIs'}
        tree['m_GraphicsAPIs'] = [21, 0, 0, 0]  # Vulkan; original shaders include SPIR-V.
        obj.save_typetree(tree)
        assert {key: value for key, value in obj.read_typetree().items()
                if key != 'm_GraphicsAPIs'} == protected_build_settings

for file in environment.files.values():
    if isinstance(file, UnityPy.files.SerializedFile) and file.target_platform == BuildTarget.Android:
        file.target_platform = BuildTarget.StandaloneWindows64
        (data / file.name).write_bytes(file.save())
        counts['adapted_serialized_files'] += 1

# Route through an existing menu lifecycle method: built runtime-init metadata
# predates the new desktop controls. Do not rely on adding only an attribute.
sources = sorted((ROOT / 'project/Assets/Scripts/Assembly-CSharp').rglob('*.cs'))
source_folder = args.work / 'native-csharp'
source_folder.mkdir(exist_ok=True)
compiled_sources = []
for source in sources:
    if source.name in {'Menu.cs', 'DesktopControls.cs'}:
        text = source.read_text(encoding='utf-8')
        if source.name == 'Menu.cs':
            marker = 'private void Start()\n\t{'
            assert text.count(marker) == 1
            text = text.replace(marker, marker + '\n\t\tZoneMotionPC.NativeBootstrap.Initialize();')
        else:
            assert 'private static void Install()' in text
            text = text.replace('private static void Install()', 'public static void Install()')
        dest = source_folder / source.name
        dest.write_text(text, encoding='utf-8')
        compiled_sources.append(dest)
    else:
        compiled_sources.append(source)
compiled_sources.append(NATIVE / 'NativeBootstrap.cs')
managed = data / 'Managed'
references = sorted(p for p in managed.glob('*.dll') if p.name != 'Assembly-CSharp.dll')
sdk_lines = subprocess.check_output([args.dotnet, '--list-sdks'], text=True).splitlines()
sdk = next(line for line in sdk_lines if line.startswith('8.0.426 '))
sdk_base = Path(sdk[sdk.index('[') + 1:sdk.rindex(']')]) / '8.0.426'
compiler = sdk_base / 'Roslyn/bincore/csc.dll'
response = args.work / 'native-compile.rsp'
options = ['/nologo', '/target:library', '/unsafe+', '/nostdlib+', '/langversion:6', '/codepage:65001',
           '/define:UNITY_STANDALONE;UNITY_STANDALONE_WIN;UNITY_2017_2;UNITY_2017_2_OR_NEWER',
           '/out:"' + str(managed / 'Assembly-CSharp.dll') + '"']
options += ['/reference:"' + str(p) + '"' for p in references]
options += ['"' + str(p) + '"' for p in compiled_sources]
response.write_text('\n'.join(options), encoding='utf-8')
subprocess.run([args.dotnet, str(compiler), '@' + str(response)], check=True)
(data / 'app.info').write_text('Sokol\nZone Motion PC\n', encoding='utf-8')
report = {'method': 'native runtime compatibility candidate', 'asset_changes': dict(counts),
          'engine_version': '2017.2.0f3 (46dda1414e51)', 'engine_binaries_modified': False,
          'license_fields_modified': False, 'windows_gameplay_tested': False}
(output / 'CANDIDATE.json').write_text(json.dumps(report, indent=2), encoding='utf-8')
print(json.dumps(report), flush=True)
