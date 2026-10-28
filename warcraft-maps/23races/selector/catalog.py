"""Read the map's existing choices, build trees and unit data for its new UI."""
import copy,json,re,struct
from pathlib import Path
from classic_data import read_objects,field

ROOT=Path(__file__).resolve().parent
RU={'hpea':'Крестьянин','opeo':'Раб','uaco':'Послушник','ewsp':'Огонёк','htow':'Ратуша','hkee':'Крепость','hcas':'Замок','hbar':'Казармы','hhou':'Ферма','halt':'Алтарь королей','harm':'Мастерская','hars':'Волшебное святилище','hgra':'Грифонья башня','hlum':'Лесопилка','hbla':'Кузница','hvlt':'Магазин','hfoo':'Пехотинец','hrif':'Стрелок','hkni':'Рыцарь','hmpr':'Целитель','hsor':'Волшебница','hspt':'Ведьмак','hgry':'Грифон','hdhw':'Ястреб','ogre':'Дом вождей','ostr':'Крепость','ofrt':'Цитадель','obar':'Казармы','oalt':'Алтарь бурь','ogru':'Бугай','ohun':'Охотник за головами','oshm':'Шаман','otau':'Минотавр','uzig':'Зиккурат','unpl':'Некрополь','unp1':'Чертоги мёртвых','unp2':'Чёрная цитадель','ugrv':'Кладбище','usep':'Склеп','etol':'Древо жизни','etoa':'Древо долголетия','etoe':'Древо вечности','eate':'Древо войны','emow':'Лунный колодец'}

def clean(text):
    return re.sub(r'\|[cC][0-9a-fA-F]{8}|\|[rR]','',text).replace('|n','\n').strip()

def value(mod):
    if mod[1]==3:return mod[4].decode('utf8','replace')
    return struct.unpack('<i' if mod[1]==0 else '<f',mod[4])[0]

class Catalog:
    def __init__(self,storm,handle,script):
        self.tables=read_objects(storm.read(handle,'war3map.w3u'))
        self.units={o['old'] if tab==0 else o['new']:o for tab,objects in enumerate(self.tables) for o in objects}
        self.base=json.loads((ROOT/'base-units.json').read_text());self.resolved={}
        upgrades=read_objects(storm.read(handle,'war3map.w3q'),True)
        self.upgrades={o['old'] if tab==0 else o['new']:{m[0]:value(m) for m in o['mods']} for tab,objects in enumerate(upgrades) for o in objects}
        functions={n:body for n,body in re.findall(r'^function (\w+) takes[^\n]*\n([\s\S]*?)^endfunction',script,re.M)}
        races=[]
        for name,body in functions.items():
            if not name.endswith('_Conditions'):continue
            rid=re.search(r"GetResearched\(\)\s*==\s*'([^']+)'",body)
            action=functions.get(name[:-11]+'_Actions','')
            worker=re.search(r"CreateNUnitsAtLoc\(\s*5,\s*'([^']+)'",action)
            label=re.search(r'выбрал расу - \|c[0-9A-Fa-f]{8}([^|]+)',action)
            if not (rid and worker and label):continue
            upgrade=self.upgrades[rid[1].encode()];w=self.unit(worker[1]);builds=[x for x in str(w.get('ubui','')).split(',') if x]
            army=[]
            for building in builds:
                for raw in str(self.unit(building).get('utra','')).split(','):
                    if len(raw)==4 and raw!=worker[1] and raw not in army:army.append(raw)
            normals=[u for u in army if u[0].islower() and self.unit(u).get('umvt')!='float' and not any(token in self.unit(u).get('umdl','').lower() for token in ['battleship','transportship','destroyer','juggernaught','frigate'])];heroes=[u for u in army if u[0].isupper()]
            preview_builds=builds[:3]
            tower=next((x for x in builds[3:] if 'tower' in self.unit(x).get('umdl','').lower() or 'баш' in self.name(x).lower()),None)
            if tower:preview_builds.append(tower)
            preview_units=normals[:4]+heroes[:1]
            flyer=next((u for u in normals[4:] if self.unit(u).get('umvt')=='fly'),None)
            if flyer:preview_units.append(flyer)
            races.append(dict(index=len(races),name=label[1],research=rid[1],worker=worker[1],workerName=self.name(worker[1]),hp=int(w.get('uhpm',0)),speed=int(w.get('umvs',0)),icon=upgrade.get('gar1',w.get('uico','')),description=clean(str(upgrade.get('gub1',''))).removeprefix('Описание расы:').strip(),buildings=builds,buildingNames=[self.name(x) for x in builds],army=army,armyNames=[self.name(x) for x in normals],previewBuildings=preview_builds,previewUnits=preview_units,action=action,originalTrigger=name.removesuffix('_Conditions').removeprefix('Trig_')))
        self.races=races
        assert len(races)==34 and len({r['research'] for r in races})==34

    def unit(self,raw):
        if raw in self.resolved:return self.resolved[raw]
        original=self.units.get(raw.encode());result=copy.deepcopy(self.base.get(raw,{}))
        if original:
            parent=original['old'].decode()
            if parent!=raw:result=copy.deepcopy(self.unit(parent))
            result.update({m[0]:value(m) for m in original['mods']})
            result['root']=self.base.get(parent,{}).get('root',parent)
        result.setdefault('root',raw);self.resolved[raw]=result
        return result

    def name(self,raw):
        data=self.unit(raw)
        original=self.units.get(raw.encode());mods={m[0]:value(m) for m in original['mods']} if original else {}
        label=clean(str(data.get('unam',raw)));root=data['root']
        if label.isascii() and root in RU:
            if 'utip' in mods:
                tooltip=re.sub(r'\s*\([^)]*\)\s*$','',clean(str(mods['utip'])))
                if not tooltip.isascii():return tooltip
            return RU[root]
        return RU.get(raw,label)

    def preview_objects(self):
        result=[];aliases={};alphabet='0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz'
        for race in self.races:
            for raw in race['previewBuildings']+race['previewUnits']+[race['worker']]:
                if raw in aliases:continue
                n=len(aliases);alias='qS'+alphabet[n//62]+alphabet[n%62];aliases[raw]=alias;data=self.unit(raw)
                # Inherit all modified appearance fields, then remove game rules.
                chain=[];cursor=raw;seen=set()
                while cursor not in seen:
                    seen.add(cursor);obj=self.units.get(cursor.encode())
                    if not obj:break
                    chain.insert(0,obj['mods']);cursor=obj['old'].decode()
                mods=[copy.deepcopy(m) for group in chain for m in group]
                for m in mods:m[5]=b'\0'*4
                overrides=[field('unam',3,'Предпросмотр'),field('uabi',3,'Aloc,Avul'),field('uhab',3,''),field('ures',3,''),field('utra',3,''),field('ubui',3,''),field('ufoo',0,0),field('uaen',0,0),field('uacq',2,0.),field('umvs',0,0),field('umvt',3,'fly'),field('umvh',2,0.),field('umvf',2,0.),field('ucol',2,0.),field('upat',3,''),field('ubdg',0,0),field('ushb',3,''),field('ushu',3,'')]
                keys={m[0] for m in overrides};mods=[m for m in mods if m[0] not in keys]+overrides
                result.append(dict(old=data['root'].encode(),new=alias.encode(),mods=mods))
        return result,aliases
