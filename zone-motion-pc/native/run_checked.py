"""Keep public-input preparation failures inspectable in GitHub annotations."""
from pathlib import Path
import subprocess
import sys

result = subprocess.run(sys.argv[1:], stdout=subprocess.PIPE, stderr=subprocess.STDOUT,
                        text=True, encoding='utf-8', errors='replace')
output = result.stdout
folder = Path('dist/native-validation')
folder.mkdir(parents=True, exist_ok=True)
with (folder / 'preparation.log').open('a', encoding='utf-8') as log:
    log.write(output)
print(output, flush=True)
if result.returncode:
    tail = output[-12000:].replace('%', '%25').replace('\r', '%0D').replace('\n', '%0A')
    print('::error title=Native preparation::' + tail, flush=True)
raise SystemExit(result.returncode)
