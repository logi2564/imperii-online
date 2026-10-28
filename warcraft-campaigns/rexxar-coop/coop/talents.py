"""Five two-way talent tiers per hero. IDs are role*10 + tier*2 + choice-1."""
LEVELS=[4,8,12,16,20]
ICONS=[
 ['BTNArcaniteMelee','BTNSpiritWolf','BTNEnsnare','BTNHealingSalve','BTNCriticalStrike','BTNPoisonSting','BTNThunderClap','BTNBloodLust','BTNStormBolt','BTNStampede'],
 ['BTNHealingWave','BTNHealingWard','BTNDispelMagic','BTNBrilliance','BTNRegeneration','BTNAncestralSpirit','BTNSerpentWard','BTNResurrection','BTNSpiritLink','BTNBigBadVoodooSpell'],
 ['BTNStrongDrink','BTNBreathOfFire','BTNVolcano','BTNDrunkenDodge','BTNWarStomp','BTNRejuvenation','BTNImmolationOn','BTNFlameStrike','BTNPhoenixEgg','BTNBreathOfFrost'],
 ['BTNShockWave','BTNDefend','BTNCommand','BTNImpale','BTNReincarnation','BTNWarStomp','BTNThunderClap','BTNRejuvenation','BTNOrbOfLightning','BTNDevotion']]
ORDERS=['avatar','thunderclap','stomp','roar','howlofterror','fanofknives','starfall','tranquility','windwalk','metamorphosis']
def ability_id(role,node):return f'T9{role}{node}'
def tech_id(role,node):return f'r9{role}{node}'
def book_id(role):return f'R9T{role}'
TREES=[
 [[('Острые лезвия','Урон возвращающегося топора +25%.'),('Крепкая стая','Волк, кабан и звери ультимейта получают ещё 200 здоровья.')],
  [('Неотступная охота','След охотника действует на 3 секунды дольше.'),('Живой трофей','Гибель отмеченной добычи лечит героев на 24% здоровья вместо 12%.')],
  [('Зубы и когти','Спутники и звери ультимейта получают ещё 8 урона.'),('Глубокая рана','Периодический урон Следа охотника +50%.')],
  [('Гром стаи','Взрыв Прыжка стаи также ненадолго оглушает врагов.'),('Кровавый след','Гибель отмеченной добычи наносит врагам рядом 120 + 8 за уровень Рексара урона.')],
  [('Тройной бросок','Q выпускает три возвращающихся топора веером.'),('Верховный охотник','Прыжок стаи призывает пять зверей вместо трёх.')]],
 [[('Сильная нить','Начальное и периодическое лечение Живой нити +30%.'),('Дальняя забота','Радиус лечения и очищения тотема +150.')],
  [('Чистая душа','Живая нить также снимает отрицательные эффекты при применении.'),('Источник маны','Якорь души при срабатывании восстанавливает 25% максимальной маны цели.')],
  [('Щедрый тотем','Каждый импульс тотема лечит ещё 15 здоровья.'),('Гнев предков','Круг предков наносит на 35 больше урона за импульс; лечение не меняется.')],
  [('Обряд расплаты','Тотем наносит врагам в своей области 20 урона в секунду.'),('Последняя надежда','Лечение Круга предков на 40% сильнее для героев ниже 35% здоровья.')],
  [('Две души','Якорь души дополнительно привязывает ближайшего другого героя отряда в радиусе 600 от первой цели.'),('Все голоса','Круг предков поднимает всех погибших героев отряда в радиусе 700 вместо одного.')]],
 [[('Крепкий настой','Мокрая метка от Хмельного веера длится на 3 секунды дольше.'),('Обжигающий веер','Урон Хмельного веера +25%.')],
  [('Большая бочка','Радиус взрыва бочки +100.'),('Дальний перекат','Максимальная дальность Огненного переката +180, стены по-прежнему блокируют рывок.')],
  [('Сотрясающий взрыв','Мокрые цели после взрыва бочки оглушаются на 1,25 сек.; герои на 0,5 сек.'),('Второе дыхание','Перекат лечит Чэня на 8% здоровья за задетого врага, максимум за двух за одно применение.')],
  [('Жар водоворота','Урон Огненного водоворота +25%.'),('Разлитый настой','После взрыва бочка оставляет на врагах мокрую метку на 4 секунды для следующих огненных атак.')],
  [('Бушующее пламя','Радиус водоворота +120, длительность +2 секунды.'),('Двойная порция','W запускает две взрывные бочки узким веером.')]],
 [[('Сила земли','Урон Раскола земли +25%.'),('Стальная шкура','Вызов вождя даёт дополнительно 4 брони.')],
  [('Накопленная ярость','Ответный удар переводит 50% накопленного урона вместо 35%; предел силы сохраняется.'),('Широкий разлом','Ширина поражения Раскола земли +80.')],
  [('Несокрушимый вождь','Во время Вызова вождя Кэрн восстанавливает 3% максимального здоровья в секунду.'),('Тяжёлое оглушение','Оглушения Кэрна длятся 1,25 сек. вместо 0,65; по героям 0,5 вместо 0,3.')],
  [('Ударная волна','Радиус Ответного удара +150.'),('Родная земля','Земля предков дополнительно лечит героев на 1,5% их здоровья в секунду.')],
  [('Три разлома','Q выпускает три разлома веером.'),('Плечом к плечу','Ответный удар также лечит других героев рядом на половину своего лечения.')]]
]

def initialization():
    lines=[]
    def quote(t):return '"'+t.replace('\\','\\\\').replace('"','\\"')+'"'
    for tier,level in enumerate(LEVELS):lines.append(f'    set RC_talentLevel[{tier}] = {level}')
    for role,tree in enumerate(TREES):
        for tier,choices in enumerate(tree):
            for choice,(name,description) in enumerate(choices):
                index=role*10+tier*2+choice
                lines += [f'    set RC_talentName[{index}] = {quote(name)}',f'    set RC_talentText[{index}] = {quote(description)}']
                lines += [f"    set RC_talentAbility[{index}] = '{ability_id(role,tier*2+choice)}'",f"    set RC_talentTech[{index}] = '{tech_id(role,tier*2+choice)}'"]
        lines.append(f"    set RC_talentBook[{role}] = '{book_id(role)}'")
    return '\n'.join(lines)


def abilities():
    from formats import field
    result=[]
    for role,tree in enumerate(TREES):
        for tier,choices in enumerate(tree):
            for choice,(name,description) in enumerate(choices):
                node=tier*2+choice;key='QWERASDFZX'[node]
                tip=description+f'|n|nТребуется уровень {LEVELS[tier]}. Один выбор в этом ряду.'
                tip+='|nПосле выбора остаётся подсвеченным выбранный талант. Другой закрывается. Выбор сохраняется.'
                mods=[field('aher',0,0),field('aite',0,0),field('alev',0,1),field('anam',3,name),field('aart',3,'ReplaceableTextures\\CommandButtons\\'+ICONS[role][node]+'.blp'),field('ahky',3,key),field('abpx',0,node%4),field('abpy',0,node//4),field('atp1',3,f'{name} — ур. {LEVELS[tier]} ({key})',1),field('aub1',3,tip,1),field('areq',3,tech_id(role,node)),field('arqa',3,'1'),field('acat',3,''),field('aeat',3,''),field('atat',3,''),field('amcs',0,0,1),field('acdn',2,0.,1),field('Ncl1',2,0.,1),field('Ncl2',0,0,1),field('Ncl3',0,1,1),field('Ncl4',2,0.,1),field('Ncl5',0,0,1),field('Ncl6',3,ORDERS[node],1)]
                result.append(dict(old=b'ANcl',new=ability_id(role,node).encode(),mods=mods))
        mods=[field('aher',0,0),field('aite',0,0),field('alev',0,1),field('anam',3,'Таланты героя'),field('aart',3,'ReplaceableTextures\\CommandButtons\\BTNStatUp.blp'),field('ahky',3,'T'),field('abpx',0,1),field('abpy',0,1),field('atp1',3,'Таланты героя (T)',1),field('aub1',3,'Открывает десять талантов: два варианта на уровнях 4, 8, 12, 16 и 20.|nНаведи на иконку, чтобы прочитать эффект. Серые варианты пока закрыты. Выбранный остаётся подсвеченным.',1),field('spb1',3,','.join(ability_id(role,n) for n in range(10)),1),field('spb2',0,0,1),field('spb3',0,10,1),field('spb4',0,10,1),field('spb5',3,'spellbook',1)]
        result.append(dict(old=b'Aspb',new=book_id(role).encode(),mods=mods))
    return result


def upgrades():
    from formats import field
    result=[]
    for role,tree in enumerate(TREES):
        for tier,choices in enumerate(tree):
            for choice,(name,_) in enumerate(choices):
                mods=[field('gnam',3,f'Уровень {LEVELS[tier]} / свободный выбор: {name}',1),field('glvl',0,1),field('gcls',3,''),field('grac',3,'other'),field('gglb',0,0),field('gglm',0,0),field('glmb',0,0),field('glmm',0,0),field('gtib',0,0),field('gtim',0,0),field('ginh',0,0)]
                # These are UI requirements, never inherited weapon upgrades.
                mods += [field('gef'+str(n),3,'') for n in range(1,5)]
                result.append(dict(old=b'Rhme',new=tech_id(role,tier*2+choice).encode(),mods=mods))
    return result
