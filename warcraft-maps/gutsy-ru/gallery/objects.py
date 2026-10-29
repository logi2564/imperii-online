"""Real 1.26 command-card buttons and harmless nonhero model controllers."""
from classic_data import field

ORDERS=('channel','acidbomb','banish','farsight','drunkenhaze','healingward',
        'thunderclap','roar','berserk','divineshield','fanofknives','taunt')
KEYS='QWERASDFZXCV'
LABELS={
1:('roles','Герои по ролям','Открыть каталог героев. Просмотр не создаёт боевого героя.'),
2:('arena','Арена','Режим с монстрами, захватом баз и очками за победы. Можно проверить одному.'),
3:('epic','Эпицентр','Командные раунды. Нужен хотя бы один соперник в другой команде.'),
4:('team','Сменить команду','Переключить команду. Изменение снимает твою готовность.'),
5:('goal','Цель матча','Переключить цель по очкам или победам. Текущая цель видна в панели подготовки.'),
6:('close','Закрыть меню','Вернуться к карте. Открыть меню снова: -menu.'),
7:('help','Как играть','Показать короткую инструкцию и состояние подготовки.'),
8:('camera','Расстояние камеры','Сменить расстояние камеры в бою. Просмотр героя использует отдельную камеру.'),
9:('mine','Мой герой','Открыть закреплённого героя или навыки своего боевого героя.'),
10:('change','Изменить выбор','Освободить закреплённого героя и выбрать другого до запуска. Живой герой не заменяется.'),
11:('ready','Готов','Отметить себя готовым после закрепления героя. Само по себе это не запускает бой.'),
12:('start','Начать бой','Ведущий запускает матч после готовности всех игроков. Повторное нажатие не выдаёт второго героя.'),
13:('main','Главное меню','Режим, команда, цель матча и готовность игроков.'),
14:('roles','Выбрать роль','Открыть героев выбранной роли.'),
15:('prev','Предыдущие герои','Показать предыдущую страницу портретов.'),
16:('next','Следующие герои','Показать следующую страницу портретов.'),
19:('prev','Предыдущие навыки','Показать предыдущие четыре иконки навыков.'),
20:('next','Ещё навыки','Показать другие навыки, пассивные эффекты и формы героя.'),
21:('about','О герое','Показать роль, описание и состояние выбора героя.'),
22:('confirm','Закрепить героя','Закрепить одного героя за собой. Боевой герой создаётся только при запуске матча.'),
23:('rankprev','Предыдущая часть','Вернуться к предыдущей странице описания или рангу навыка.'),
24:('ranknext','Следующая часть','Показать продолжение описания или следующий ранг навыка.'),
25:('skillprev','Предыдущий навык','Открыть описание предыдущего навыка этого героя.'),
26:('skillnext','Следующий навык','Открыть описание следующего навыка этого героя.'),
27:('mine','Назад к герою','Вернуться к иконкам навыков и модели героя.'),
}


def binding_pairs():
    result=set()
    screens=[[(1,0),(2,1),(3,2),(4,3),(5,4),(6,5),(7,6),(8,7),(9,8),(10,9),(11,10),(12,11),(6,11)],
             [(13,8),(9,9),(11,10),(12,11),(6,11)],
             [(15,8),(16,9),(13,10),(12,11),(6,11)],
             [(19,4),(20,5),(21,6),(4,7),(22,8),(10,8),(11,9),(1,10),(12,11),(6,11)],
             [(25,0),(26,1),(23,2),(24,3),(27,4),(21,5),(8,6),(4,7),(22,8),(10,8),(11,9),(1,10),(12,11),(6,11)]]
    for screen in screens:
        for action,slot in screen:
            result.add((action,slot,0))
            if action==11:result.add((action,slot,1))
    result.update((14,slot,slot) for slot in range(8))
    return sorted(result)


class Codes:
    def __init__(self,used):self.used=set(used);self.next={}
    def take(self,prefix):
        alphabet='0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ'
        n=self.next.get(prefix,0)
        while True:
            value=n;tail=''
            for _ in range(3):tail=alphabet[value%36]+tail;value//=36
            assert not value,'FourCC allocation exhausted'
            raw=prefix+tail;n+=1
            if raw not in self.used:break
        self.next[prefix]=n;self.used.add(raw)
        return raw


def ability(raw,title,icon,slot,description):
    assert len(description.encode())<=1023
    mods=[field('aher',0,0),field('aite',0,0),field('alev',0,1),field('arlv',0,0),
          field('anam',3,title),field('aart',3,icon),field('ahky',3,KEYS[slot]),
          field('abpx',0,slot%4),field('abpy',0,slot//4),field('acat',3,''),
          field('aeat',3,''),field('atat',3,''),field('arac',3,'other'),field('areq',3,''),field('arqa',3,'')]
    mods += [field('atp1',3,title,1),field('aub1',3,description+'|nКлавиша меню: '+KEYS[slot],1),
             field('amcs',0,0,1),field('acdn',2,0.,1),field('acas',2,0.,1),field('aran',2,0.,1),
             field('Ncl1',2,0.,1),field('Ncl2',0,0,1),field('Ncl3',0,1,1),
             field('Ncl4',2,0.,1),field('Ncl5',0,0,1),field('Ncl6',3,ORDERS[slot],1)]
    for mod in mods:
        if mod[0].startswith('Ncl'):mod[3]=int(mod[0][3])
    return dict(old=b'ANcl',new=raw.encode(),mods=mods)


def controller(raw,model,icon,scale=1.,floor=False,name='Подготовка матча'):
    mods=[field('unam',3,name if not floor else 'Площадка меню'),field('umdl',3,model),
          field('uico',3,icon),field('usca',1,scale),field('uabi',3,'Avul'+(',Aloc' if floor else '')),
          field('uhab',3,''),field('ures',3,''),field('utra',3,''),field('ubui',3,''),
          field('ufoo',0,0),field('uhpm',0,1000),field('uaen',0,0),field('uacq',2,0.),
          field('umvs',0,0),field('umvt',3,'fly'),field('umvh',2,0.),field('umvf',2,0.),
          field('ucol',2,0.),field('upat',3,''),field('ubdg',0,0),field('ushb',3,''),field('ushu',3,''),
          field('ucpt',2,0.),field('ucbs',2,0.),field('umpi',0,0),field('umpm',0,0),
          field('usid',0,0),field('usin',0,0)]
    return dict(old=b'hfoo',new=raw.encode(),mods=mods)


def build(data,used):
    codes=Codes(used);units=[];abilities=[];bindings=[]
    generic=codes.take('y');floor=codes.take('y')
    units.append(controller(generic,'buildings\\other\\Tavern\\Tavern','ReplaceableTextures\\CommandButtons\\BTNTavern.blp',1.1))
    units.append(controller(floor,'GGV\\Scene\\floor.mdx','ReplaceableTextures\\CommandButtons\\BTNTavern.blp',1.,True))
    role_ordinal={};skill_index=0
    for h,hero in enumerate(data['heroes']):
        hero['controller']=codes.take('y');units.append(controller(hero['controller'],hero['model'],hero['icon'],hero['previewScale'],name='Просмотр: '+hero['name']))
        ordinal=role_ordinal.get(hero['role'],0);role_ordinal[hero['role']]=ordinal+1
        hero['button']=codes.take('z')
        abilities.append(ability(hero['button'],hero['name'],hero['icon'],ordinal%8,hero['overview']+'|n|nНажми для просмотра модели и навыков. Это ещё не выбор.'))
        for offset,skill in enumerate(hero['skills']):
            skill['button']=codes.take('z');skill['index']=skill_index;skill_index+=1
            description=skill['pages'][0]+'|n|nНажми, чтобы открыть полное описание, формы и ранги.'
            abilities.append(ability(skill['button'],skill['title'],skill['icon'] or 'ReplaceableTextures\\CommandButtons\\BTNSelectHeroOn.blp',offset%4,description))
    for action,slot,variant in binding_pairs():
        key,title,description=LABELS[action]
        if action==14:
            title=data['roles'][variant];icon=next(h['icon'] for h in data['heroes'] if h['role']==variant)
        else:
            if action==11 and variant:key,title='unready','Отменить готовность'
            icon='GGV\\Icons\\'+key+'.blp'
        raw=codes.take('z');abilities.append(ability(raw,title,icon,slot,description))
        bindings.append((action*120+slot*10+variant,raw))
    return units,abilities,bindings,generic,floor
