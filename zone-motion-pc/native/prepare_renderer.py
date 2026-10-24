"""Get an unchanged software Vulkan driver from verified official Electron files."""
import hashlib
from pathlib import Path
import shutil
import sys
import urllib.request
import zipfile

output = Path(sys.argv[1]).resolve()
cache = Path(sys.argv[2]).resolve()
cache.mkdir(parents=True, exist_ok=True)
package = cache / 'electron-v45.0.0-win32-x64.zip'
expected = 'ae53887a23bb640369c93dbd38c408a2af5c0deb86f2fa76c6c244cb444b7f47'
if not package.exists() or hashlib.sha256(package.read_bytes()).hexdigest() != expected:
    url = 'https://github.com/electron/electron/releases/download/v45.0.0/electron-v45.0.0-win32-x64.zip'
    with urllib.request.urlopen(url, timeout=120) as response, package.open('wb') as out:
        shutil.copyfileobj(response, out)
assert hashlib.sha256(package.read_bytes()).hexdigest() == expected
renderer = output / 'SoftwareRenderer'
renderer.mkdir(exist_ok=True)
with zipfile.ZipFile(package) as z:
    assert z.testzip() is None
    for name in ['vk_swiftshader.dll', 'vk_swiftshader_icd.json', 'LICENSE', 'LICENSES.chromium.html']:
        (renderer / name).write_bytes(z.read(name))
    (output / 'vulkan-1.dll').write_bytes(z.read('vulkan-1.dll'))
print('Verified Vulkan loader and software-driver files extracted unchanged.')
