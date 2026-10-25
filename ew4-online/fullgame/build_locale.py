"""Assemble a complete local Russian table while retaining engine source hashes."""
from pathlib import Path
import json,re,sys
HERE=Path(__file__).resolve().parent
sys.path.insert(0,str(HERE.parent/'localization'))
from build_dictionary import ini,RU,CUSTOM,LABELS,normal

def build(root):
    inputs=json.loads((HERE/'translation-input.json').read_text());translated=json.loads((HERE/'translated-ru.json').read_text())
    source=ini(root/'rewrite/data/original/stringtable_cn.ini');english=json.loads((HERE/'table-english.json').read_text())
    missing=[k for k,v in inputs.items() if v not in translated]
    if missing:raise ValueError('Russian translation incomplete: '+str(len(missing))+' entries')
    def ru(text):
        if normal(text) in RU:return RU[normal(text)]
        return translated.get(text,text)
    dictionary={};table={};cities={}
    for key,cn in source.items():
        if key.endswith('_char'):table[key]=cn;continue
        original=inputs.get('table:'+key,english.get(key,cn));value=ru(original)
        table[key]=value;dictionary[cn]=value;dictionary[original]=value
    for key,text in inputs.items():
        dictionary[text]=ru(text)
        if key.startswith('city:'):cities[key[5:]]=ru(text)
    dictionary.update(CUSTOM)
    dictionary.update({'Headquarter':'Штаб','Options':'Настройки','Tutorials':'Обучение','Quit':'Выход','RECRUIT':'Нанять','SCENARIO':'Кампании','English':'Русский','中文':'Русский','城市名称':'Названия городов','地理名称':'Географические названия','你好':'Здравствуйте'})
    table.update({k:dictionary.get(v,v) for k,v in table.items()})
    result={'language':'ru','dictionary':dictionary,'russian':RU,'labels':LABELS,'cities':cities,'table':table,'method':'machine_translated_game_text_with_reviewed_interface_overrides'}
    remaining={k:v for k,v in table.items() if not k.endswith('_char') and re.search('[\u3400-\u9fff]',v)}
    if remaining:raise ValueError('Chinese remains in '+str(len(remaining))+' table entries')
    web=root/'rewrite/Ew4.Web/wwwroot';(web/'native-ru.json').write_text(json.dumps(result,ensure_ascii=False,separators=(',',':')))
    csharp=root/'rewrite/Ew4.Client/RussianGameText.cs'
    # The embedded text is display data; original bytes remain unchanged for VerifySources.
    payload=json.dumps(table,ensure_ascii=False,separators=(',',':')).encode()
    import base64
    csharp.write_text('using System.Text.Json;\nnamespace Ew4.Client;\ninternal static class RussianGameText { private static readonly Dictionary<string,string> Table=JsonSerializer.Deserialize<Dictionary<string,string>>(Convert.FromBase64String("'+base64.b64encode(payload).decode()+'"))!; public static string Apply(string original) { return string.Join("\\n",original.Split(\'\\n\').Select(line=>{int i=line.IndexOf(\'=\'); if(i<0)return line; string key=line[..i].Trim(); return Table.TryGetValue(key,out string? value)?key+"="+value:line;})); } }\n')
    return {'table_keys':len(table),'known_texts':len(dictionary),'cities':len(cities),'missing':0,'chinese_table_entries':0,'translation_method':result['method']}
if __name__=='__main__':print(json.dumps(build(Path(sys.argv[1]).resolve()),indent=2))
