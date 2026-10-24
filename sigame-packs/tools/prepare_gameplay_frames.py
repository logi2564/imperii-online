"""Choose gameplay candidates where the first Steam image is a title card."""
import hashlib,json,urllib.request,zipfile
from pathlib import Path
from PIL import Image
import io
root=Path('dist/gameplay-review');root.mkdir(parents=True,exist_ok=True)
records=[]
for key,appid in [('counter-strike','730'),('cuphead','268910')]:
    metadata='https://store.steampowered.com/api/appdetails?appids='+appid
    with urllib.request.urlopen(metadata,timeout=35) as r:data=json.load(r)[appid]['data']
    for index in [1,2,3]:
        url=data['screenshots'][index]['path_full']
        with urllib.request.urlopen(url,timeout=35) as r:raw=r.read(12_000_000)
        with Image.open(io.BytesIO(raw)) as im:
            im=im.convert('RGB');im.thumbnail((1280,1280));im.save(root/f'{key}-{index}.jpg',quality=93)
        records.append({'key':f'{key}-{index}','url':url,'metadata_url':metadata,'name':data['name'],'source_sha256':hashlib.sha256(raw).hexdigest(),'ok':True})
(root/'sources.json').write_text(json.dumps(records,ensure_ascii=False,indent=2))
with zipfile.ZipFile('dist/SIGame-gameplay-review.zip','w',zipfile.ZIP_DEFLATED) as z:
    for p in root.iterdir():z.write(p,p.name)
