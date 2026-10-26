function DGW_LoadData takes nothing returns nothing
    set DGW_Data=InitHashtable()
    set DGW_Worker[1]='dA00'
    set DGW_HQ1[1]='dA10'
    set DGW_HQ2[1]='dA11'
    set DGW_HQ3[1]='dA12'
    set DGW_Farm[1]='dA20'
    set DGW_Barracks[1]='dA21'
    set DGW_Altar[1]='dA24'
    set DGW_ChampionType[1]='DA80'
    set DGW_GodType[1]='DA90'
    set DGW_Spell[1]='YA00'
    set DGW_RaceName[1]="Люди Рассвета"
    set DGW_GodName[1]="Аурион, бог Солнца"
    set DGW_Trait[1]="Дополнительные 10 золота каждые 5 секунд; лечение армии."
    call SaveInteger(DGW_Data,1,11,'AHhb')
    call SaveInteger(DGW_Data,'dA00',1,1)
    call SaveInteger(DGW_Data,'dA00',2,1)
    call SaveInteger(DGW_Data,'dA10',1,2)
    call SaveInteger(DGW_Data,'dA10',2,1)
    call SaveInteger(DGW_Data,'dA10',3,1)
    call SaveInteger(DGW_Data,'dA11',1,2)
    call SaveInteger(DGW_Data,'dA11',2,1)
    call SaveInteger(DGW_Data,'dA11',3,2)
    call SaveInteger(DGW_Data,'dA12',1,2)
    call SaveInteger(DGW_Data,'dA12',2,1)
    call SaveInteger(DGW_Data,'dA12',3,3)
    call SaveInteger(DGW_Data,'dA20',1,3)
    call SaveInteger(DGW_Data,'dA20',2,1)
    call SaveInteger(DGW_Data,'dA21',1,3)
    call SaveInteger(DGW_Data,'dA21',2,1)
    call SaveInteger(DGW_Data,'dA22',1,3)
    call SaveInteger(DGW_Data,'dA22',2,1)
    call SaveInteger(DGW_Data,'dA23',1,3)
    call SaveInteger(DGW_Data,'dA23',2,1)
    call SaveInteger(DGW_Data,'dA24',1,3)
    call SaveInteger(DGW_Data,'dA24',2,1)
    call SaveInteger(DGW_Data,'dA25',1,3)
    call SaveInteger(DGW_Data,'dA25',2,1)
    call SaveInteger(DGW_Data,'dA30',1,4)
    call SaveInteger(DGW_Data,'dA30',2,1)
    call SaveInteger(DGW_Data,'dA31',1,4)
    call SaveInteger(DGW_Data,'dA31',2,1)
    call SaveInteger(DGW_Data,'dA32',1,4)
    call SaveInteger(DGW_Data,'dA32',2,1)
    call SaveInteger(DGW_Data,'dA33',1,4)
    call SaveInteger(DGW_Data,'dA33',2,1)
    call SaveInteger(DGW_Data,'dA34',1,4)
    call SaveInteger(DGW_Data,'dA34',2,1)
    call SaveInteger(DGW_Data,'dA35',1,4)
    call SaveInteger(DGW_Data,'dA35',2,1)
    call SaveInteger(DGW_Data,'dA36',1,4)
    call SaveInteger(DGW_Data,'dA36',2,1)
    call SaveInteger(DGW_Data,'dA37',1,4)
    call SaveInteger(DGW_Data,'dA37',2,1)
    call SaveInteger(DGW_Data,'DA80',1,5)
    call SaveInteger(DGW_Data,'DA80',2,1)
    call SaveInteger(DGW_Data,'DA90',1,6)
    call SaveInteger(DGW_Data,'DA90',2,1)
    set DGW_Army[8]='dA30'
    set DGW_ArmyGold[8]=110
    set DGW_ArmyWood[8]=0
    set DGW_ArmyFood[8]=2
    set DGW_ArmyTier[8]=1
    set DGW_Army[9]='dA31'
    set DGW_ArmyGold[9]=130
    set DGW_ArmyWood[9]=15
    set DGW_ArmyFood[9]=2
    set DGW_ArmyTier[9]=1
    set DGW_Army[10]='dA32'
    set DGW_ArmyGold[10]=160
    set DGW_ArmyWood[10]=30
    set DGW_ArmyFood[10]=2
    set DGW_ArmyTier[10]=1
    set DGW_Army[11]='dA33'
    set DGW_ArmyGold[11]=220
    set DGW_ArmyWood[11]=45
    set DGW_ArmyFood[11]=3
    set DGW_ArmyTier[11]=2
    set DGW_Army[12]='dA34'
    set DGW_ArmyGold[12]=230
    set DGW_ArmyWood[12]=70
    set DGW_ArmyFood[12]=3
    set DGW_ArmyTier[12]=2
    set DGW_Army[13]='dA35'
    set DGW_ArmyGold[13]=260
    set DGW_ArmyWood[13]=80
    set DGW_ArmyFood[13]=4
    set DGW_ArmyTier[13]=2
    set DGW_Army[14]='dA36'
    set DGW_ArmyGold[14]=200
    set DGW_ArmyWood[14]=60
    set DGW_ArmyFood[14]=2
    set DGW_ArmyTier[14]=2
    set DGW_Army[15]='dA37'
    set DGW_ArmyGold[15]=380
    set DGW_ArmyWood[15]=110
    set DGW_ArmyFood[15]=5
    set DGW_ArmyTier[15]=3
    set DGW_Worker[2]='dB00'
    set DGW_HQ1[2]='dB10'
    set DGW_HQ2[2]='dB11'
    set DGW_HQ3[2]='dB12'
    set DGW_Farm[2]='dB20'
    set DGW_Barracks[2]='dB21'
    set DGW_Altar[2]='dB24'
    set DGW_ChampionType[2]='DB80'
    set DGW_GodType[2]='DB90'
    set DGW_Spell[2]='YB00'
    set DGW_RaceName[2]="Орда Грома"
    set DGW_GodName[2]="Громтар, бог Бури"
    set DGW_Trait[2]="Крепкая пехота: на 16% больше здоровья."
    call SaveInteger(DGW_Data,2,11,'AOcl')
    call SaveInteger(DGW_Data,'dB00',1,1)
    call SaveInteger(DGW_Data,'dB00',2,2)
    call SaveInteger(DGW_Data,'dB10',1,2)
    call SaveInteger(DGW_Data,'dB10',2,2)
    call SaveInteger(DGW_Data,'dB10',3,1)
    call SaveInteger(DGW_Data,'dB11',1,2)
    call SaveInteger(DGW_Data,'dB11',2,2)
    call SaveInteger(DGW_Data,'dB11',3,2)
    call SaveInteger(DGW_Data,'dB12',1,2)
    call SaveInteger(DGW_Data,'dB12',2,2)
    call SaveInteger(DGW_Data,'dB12',3,3)
    call SaveInteger(DGW_Data,'dB20',1,3)
    call SaveInteger(DGW_Data,'dB20',2,2)
    call SaveInteger(DGW_Data,'dB21',1,3)
    call SaveInteger(DGW_Data,'dB21',2,2)
    call SaveInteger(DGW_Data,'dB22',1,3)
    call SaveInteger(DGW_Data,'dB22',2,2)
    call SaveInteger(DGW_Data,'dB23',1,3)
    call SaveInteger(DGW_Data,'dB23',2,2)
    call SaveInteger(DGW_Data,'dB24',1,3)
    call SaveInteger(DGW_Data,'dB24',2,2)
    call SaveInteger(DGW_Data,'dB25',1,3)
    call SaveInteger(DGW_Data,'dB25',2,2)
    call SaveInteger(DGW_Data,'dB30',1,4)
    call SaveInteger(DGW_Data,'dB30',2,2)
    call SaveInteger(DGW_Data,'dB31',1,4)
    call SaveInteger(DGW_Data,'dB31',2,2)
    call SaveInteger(DGW_Data,'dB32',1,4)
    call SaveInteger(DGW_Data,'dB32',2,2)
    call SaveInteger(DGW_Data,'dB33',1,4)
    call SaveInteger(DGW_Data,'dB33',2,2)
    call SaveInteger(DGW_Data,'dB34',1,4)
    call SaveInteger(DGW_Data,'dB34',2,2)
    call SaveInteger(DGW_Data,'dB35',1,4)
    call SaveInteger(DGW_Data,'dB35',2,2)
    call SaveInteger(DGW_Data,'dB36',1,4)
    call SaveInteger(DGW_Data,'dB36',2,2)
    call SaveInteger(DGW_Data,'dB37',1,4)
    call SaveInteger(DGW_Data,'dB37',2,2)
    call SaveInteger(DGW_Data,'DB80',1,5)
    call SaveInteger(DGW_Data,'DB80',2,2)
    call SaveInteger(DGW_Data,'DB90',1,6)
    call SaveInteger(DGW_Data,'DB90',2,2)
    set DGW_Army[16]='dB30'
    set DGW_ArmyGold[16]=110
    set DGW_ArmyWood[16]=0
    set DGW_ArmyFood[16]=2
    set DGW_ArmyTier[16]=1
    set DGW_Army[17]='dB31'
    set DGW_ArmyGold[17]=130
    set DGW_ArmyWood[17]=15
    set DGW_ArmyFood[17]=2
    set DGW_ArmyTier[17]=1
    set DGW_Army[18]='dB32'
    set DGW_ArmyGold[18]=160
    set DGW_ArmyWood[18]=30
    set DGW_ArmyFood[18]=2
    set DGW_ArmyTier[18]=1
    set DGW_Army[19]='dB33'
    set DGW_ArmyGold[19]=220
    set DGW_ArmyWood[19]=45
    set DGW_ArmyFood[19]=3
    set DGW_ArmyTier[19]=2
    set DGW_Army[20]='dB34'
    set DGW_ArmyGold[20]=230
    set DGW_ArmyWood[20]=70
    set DGW_ArmyFood[20]=3
    set DGW_ArmyTier[20]=2
    set DGW_Army[21]='dB35'
    set DGW_ArmyGold[21]=260
    set DGW_ArmyWood[21]=80
    set DGW_ArmyFood[21]=4
    set DGW_ArmyTier[21]=2
    set DGW_Army[22]='dB36'
    set DGW_ArmyGold[22]=200
    set DGW_ArmyWood[22]=60
    set DGW_ArmyFood[22]=2
    set DGW_ArmyTier[22]=2
    set DGW_Army[23]='dB37'
    set DGW_ArmyGold[23]=380
    set DGW_ArmyWood[23]=110
    set DGW_ArmyFood[23]=5
    set DGW_ArmyTier[23]=3
    set DGW_Worker[3]='dC00'
    set DGW_HQ1[3]='dC10'
    set DGW_HQ2[3]='dC11'
    set DGW_HQ3[3]='dC12'
    set DGW_Farm[3]='dC20'
    set DGW_Barracks[3]='dC21'
    set DGW_Altar[3]='dC24'
    set DGW_ChampionType[3]='DC80'
    set DGW_GodType[3]='DC90'
    set DGW_Spell[3]='YC00'
    set DGW_RaceName[3]="Ледяная Плеть"
    set DGW_GodName[3]="Нергал, владыка Мороза"
    set DGW_Trait[3]="Сильный урон; божественная атака иссушает ману врага."
    call SaveInteger(DGW_Data,3,11,'AUfn')
    call SaveInteger(DGW_Data,'dC00',1,1)
    call SaveInteger(DGW_Data,'dC00',2,3)
    call SaveInteger(DGW_Data,'dC10',1,2)
    call SaveInteger(DGW_Data,'dC10',2,3)
    call SaveInteger(DGW_Data,'dC10',3,1)
    call SaveInteger(DGW_Data,'dC11',1,2)
    call SaveInteger(DGW_Data,'dC11',2,3)
    call SaveInteger(DGW_Data,'dC11',3,2)
    call SaveInteger(DGW_Data,'dC12',1,2)
    call SaveInteger(DGW_Data,'dC12',2,3)
    call SaveInteger(DGW_Data,'dC12',3,3)
    call SaveInteger(DGW_Data,'dC20',1,3)
    call SaveInteger(DGW_Data,'dC20',2,3)
    call SaveInteger(DGW_Data,'dC21',1,3)
    call SaveInteger(DGW_Data,'dC21',2,3)
    call SaveInteger(DGW_Data,'dC22',1,3)
    call SaveInteger(DGW_Data,'dC22',2,3)
    call SaveInteger(DGW_Data,'dC23',1,3)
    call SaveInteger(DGW_Data,'dC23',2,3)
    call SaveInteger(DGW_Data,'dC24',1,3)
    call SaveInteger(DGW_Data,'dC24',2,3)
    call SaveInteger(DGW_Data,'dC25',1,3)
    call SaveInteger(DGW_Data,'dC25',2,3)
    call SaveInteger(DGW_Data,'dC30',1,4)
    call SaveInteger(DGW_Data,'dC30',2,3)
    call SaveInteger(DGW_Data,'dC31',1,4)
    call SaveInteger(DGW_Data,'dC31',2,3)
    call SaveInteger(DGW_Data,'dC32',1,4)
    call SaveInteger(DGW_Data,'dC32',2,3)
    call SaveInteger(DGW_Data,'dC33',1,4)
    call SaveInteger(DGW_Data,'dC33',2,3)
    call SaveInteger(DGW_Data,'dC34',1,4)
    call SaveInteger(DGW_Data,'dC34',2,3)
    call SaveInteger(DGW_Data,'dC35',1,4)
    call SaveInteger(DGW_Data,'dC35',2,3)
    call SaveInteger(DGW_Data,'dC36',1,4)
    call SaveInteger(DGW_Data,'dC36',2,3)
    call SaveInteger(DGW_Data,'dC37',1,4)
    call SaveInteger(DGW_Data,'dC37',2,3)
    call SaveInteger(DGW_Data,'DC80',1,5)
    call SaveInteger(DGW_Data,'DC80',2,3)
    call SaveInteger(DGW_Data,'DC90',1,6)
    call SaveInteger(DGW_Data,'DC90',2,3)
    set DGW_Army[24]='dC30'
    set DGW_ArmyGold[24]=110
    set DGW_ArmyWood[24]=0
    set DGW_ArmyFood[24]=2
    set DGW_ArmyTier[24]=1
    set DGW_Army[25]='dC31'
    set DGW_ArmyGold[25]=130
    set DGW_ArmyWood[25]=15
    set DGW_ArmyFood[25]=2
    set DGW_ArmyTier[25]=1
    set DGW_Army[26]='dC32'
    set DGW_ArmyGold[26]=160
    set DGW_ArmyWood[26]=30
    set DGW_ArmyFood[26]=2
    set DGW_ArmyTier[26]=1
    set DGW_Army[27]='dC33'
    set DGW_ArmyGold[27]=220
    set DGW_ArmyWood[27]=45
    set DGW_ArmyFood[27]=3
    set DGW_ArmyTier[27]=2
    set DGW_Army[28]='dC34'
    set DGW_ArmyGold[28]=230
    set DGW_ArmyWood[28]=70
    set DGW_ArmyFood[28]=3
    set DGW_ArmyTier[28]=2
    set DGW_Army[29]='dC35'
    set DGW_ArmyGold[29]=260
    set DGW_ArmyWood[29]=80
    set DGW_ArmyFood[29]=4
    set DGW_ArmyTier[29]=2
    set DGW_Army[30]='dC36'
    set DGW_ArmyGold[30]=200
    set DGW_ArmyWood[30]=60
    set DGW_ArmyFood[30]=2
    set DGW_ArmyTier[30]=2
    set DGW_Army[31]='dC37'
    set DGW_ArmyGold[31]=380
    set DGW_ArmyWood[31]=110
    set DGW_ArmyFood[31]=5
    set DGW_ArmyTier[31]=3
    set DGW_Worker[4]='dD00'
    set DGW_HQ1[4]='dD10'
    set DGW_HQ2[4]='dD11'
    set DGW_HQ3[4]='dD12'
    set DGW_Farm[4]='dD20'
    set DGW_Barracks[4]='dD21'
    set DGW_Altar[4]='dD24'
    set DGW_ChampionType[4]='DD80'
    set DGW_GodType[4]='DD90'
    set DGW_Spell[4]='YD00'
    set DGW_RaceName[4]="Дети Луны"
    set DGW_GodName[4]="Элунара, хранительница Луны"
    set DGW_Trait[4]="Быстрые бойцы, мощное групповое лечение и восстановление маны."
    call SaveInteger(DGW_Data,4,11,'AEfa')
    call SaveInteger(DGW_Data,'dD00',1,1)
    call SaveInteger(DGW_Data,'dD00',2,4)
    call SaveInteger(DGW_Data,'dD10',1,2)
    call SaveInteger(DGW_Data,'dD10',2,4)
    call SaveInteger(DGW_Data,'dD10',3,1)
    call SaveInteger(DGW_Data,'dD11',1,2)
    call SaveInteger(DGW_Data,'dD11',2,4)
    call SaveInteger(DGW_Data,'dD11',3,2)
    call SaveInteger(DGW_Data,'dD12',1,2)
    call SaveInteger(DGW_Data,'dD12',2,4)
    call SaveInteger(DGW_Data,'dD12',3,3)
    call SaveInteger(DGW_Data,'dD20',1,3)
    call SaveInteger(DGW_Data,'dD20',2,4)
    call SaveInteger(DGW_Data,'dD21',1,3)
    call SaveInteger(DGW_Data,'dD21',2,4)
    call SaveInteger(DGW_Data,'dD22',1,3)
    call SaveInteger(DGW_Data,'dD22',2,4)
    call SaveInteger(DGW_Data,'dD23',1,3)
    call SaveInteger(DGW_Data,'dD23',2,4)
    call SaveInteger(DGW_Data,'dD24',1,3)
    call SaveInteger(DGW_Data,'dD24',2,4)
    call SaveInteger(DGW_Data,'dD25',1,3)
    call SaveInteger(DGW_Data,'dD25',2,4)
    call SaveInteger(DGW_Data,'dD30',1,4)
    call SaveInteger(DGW_Data,'dD30',2,4)
    call SaveInteger(DGW_Data,'dD31',1,4)
    call SaveInteger(DGW_Data,'dD31',2,4)
    call SaveInteger(DGW_Data,'dD32',1,4)
    call SaveInteger(DGW_Data,'dD32',2,4)
    call SaveInteger(DGW_Data,'dD33',1,4)
    call SaveInteger(DGW_Data,'dD33',2,4)
    call SaveInteger(DGW_Data,'dD34',1,4)
    call SaveInteger(DGW_Data,'dD34',2,4)
    call SaveInteger(DGW_Data,'dD35',1,4)
    call SaveInteger(DGW_Data,'dD35',2,4)
    call SaveInteger(DGW_Data,'dD36',1,4)
    call SaveInteger(DGW_Data,'dD36',2,4)
    call SaveInteger(DGW_Data,'dD37',1,4)
    call SaveInteger(DGW_Data,'dD37',2,4)
    call SaveInteger(DGW_Data,'DD80',1,5)
    call SaveInteger(DGW_Data,'DD80',2,4)
    call SaveInteger(DGW_Data,'DD90',1,6)
    call SaveInteger(DGW_Data,'DD90',2,4)
    set DGW_Army[32]='dD30'
    set DGW_ArmyGold[32]=110
    set DGW_ArmyWood[32]=0
    set DGW_ArmyFood[32]=2
    set DGW_ArmyTier[32]=1
    set DGW_Army[33]='dD31'
    set DGW_ArmyGold[33]=130
    set DGW_ArmyWood[33]=15
    set DGW_ArmyFood[33]=2
    set DGW_ArmyTier[33]=1
    set DGW_Army[34]='dD32'
    set DGW_ArmyGold[34]=160
    set DGW_ArmyWood[34]=30
    set DGW_ArmyFood[34]=2
    set DGW_ArmyTier[34]=1
    set DGW_Army[35]='dD33'
    set DGW_ArmyGold[35]=220
    set DGW_ArmyWood[35]=45
    set DGW_ArmyFood[35]=3
    set DGW_ArmyTier[35]=2
    set DGW_Army[36]='dD34'
    set DGW_ArmyGold[36]=230
    set DGW_ArmyWood[36]=70
    set DGW_ArmyFood[36]=3
    set DGW_ArmyTier[36]=2
    set DGW_Army[37]='dD35'
    set DGW_ArmyGold[37]=260
    set DGW_ArmyWood[37]=80
    set DGW_ArmyFood[37]=4
    set DGW_ArmyTier[37]=2
    set DGW_Army[38]='dD36'
    set DGW_ArmyGold[38]=200
    set DGW_ArmyWood[38]=60
    set DGW_ArmyFood[38]=2
    set DGW_ArmyTier[38]=2
    set DGW_Army[39]='dD37'
    set DGW_ArmyGold[39]=380
    set DGW_ArmyWood[39]=110
    set DGW_ArmyFood[39]=5
    set DGW_ArmyTier[39]=3
    set DGW_Worker[5]='dE00'
    set DGW_HQ1[5]='dE10'
    set DGW_HQ2[5]='dE11'
    set DGW_HQ3[5]='dE12'
    set DGW_Farm[5]='dE20'
    set DGW_Barracks[5]='dE21'
    set DGW_Altar[5]='dE24'
    set DGW_ChampionType[5]='DE80'
    set DGW_GodType[5]='DE90'
    set DGW_Spell[5]='YE00'
    set DGW_RaceName[5]="Кланы Кузни"
    set DGW_GodName[5]="Борунд, бог Горна"
    set DGW_Trait[5]="Дополнительные 8 дерева каждые 5 секунд; крепкая броня."
    call SaveInteger(DGW_Data,5,11,'AHtb')
    call SaveInteger(DGW_Data,'dE00',1,1)
    call SaveInteger(DGW_Data,'dE00',2,5)
    call SaveInteger(DGW_Data,'dE10',1,2)
    call SaveInteger(DGW_Data,'dE10',2,5)
    call SaveInteger(DGW_Data,'dE10',3,1)
    call SaveInteger(DGW_Data,'dE11',1,2)
    call SaveInteger(DGW_Data,'dE11',2,5)
    call SaveInteger(DGW_Data,'dE11',3,2)
    call SaveInteger(DGW_Data,'dE12',1,2)
    call SaveInteger(DGW_Data,'dE12',2,5)
    call SaveInteger(DGW_Data,'dE12',3,3)
    call SaveInteger(DGW_Data,'dE20',1,3)
    call SaveInteger(DGW_Data,'dE20',2,5)
    call SaveInteger(DGW_Data,'dE21',1,3)
    call SaveInteger(DGW_Data,'dE21',2,5)
    call SaveInteger(DGW_Data,'dE22',1,3)
    call SaveInteger(DGW_Data,'dE22',2,5)
    call SaveInteger(DGW_Data,'dE23',1,3)
    call SaveInteger(DGW_Data,'dE23',2,5)
    call SaveInteger(DGW_Data,'dE24',1,3)
    call SaveInteger(DGW_Data,'dE24',2,5)
    call SaveInteger(DGW_Data,'dE25',1,3)
    call SaveInteger(DGW_Data,'dE25',2,5)
    call SaveInteger(DGW_Data,'dE30',1,4)
    call SaveInteger(DGW_Data,'dE30',2,5)
    call SaveInteger(DGW_Data,'dE31',1,4)
    call SaveInteger(DGW_Data,'dE31',2,5)
    call SaveInteger(DGW_Data,'dE32',1,4)
    call SaveInteger(DGW_Data,'dE32',2,5)
    call SaveInteger(DGW_Data,'dE33',1,4)
    call SaveInteger(DGW_Data,'dE33',2,5)
    call SaveInteger(DGW_Data,'dE34',1,4)
    call SaveInteger(DGW_Data,'dE34',2,5)
    call SaveInteger(DGW_Data,'dE35',1,4)
    call SaveInteger(DGW_Data,'dE35',2,5)
    call SaveInteger(DGW_Data,'dE36',1,4)
    call SaveInteger(DGW_Data,'dE36',2,5)
    call SaveInteger(DGW_Data,'dE37',1,4)
    call SaveInteger(DGW_Data,'dE37',2,5)
    call SaveInteger(DGW_Data,'DE80',1,5)
    call SaveInteger(DGW_Data,'DE80',2,5)
    call SaveInteger(DGW_Data,'DE90',1,6)
    call SaveInteger(DGW_Data,'DE90',2,5)
    set DGW_Army[40]='dE30'
    set DGW_ArmyGold[40]=110
    set DGW_ArmyWood[40]=0
    set DGW_ArmyFood[40]=2
    set DGW_ArmyTier[40]=1
    set DGW_Army[41]='dE31'
    set DGW_ArmyGold[41]=130
    set DGW_ArmyWood[41]=15
    set DGW_ArmyFood[41]=2
    set DGW_ArmyTier[41]=1
    set DGW_Army[42]='dE32'
    set DGW_ArmyGold[42]=160
    set DGW_ArmyWood[42]=30
    set DGW_ArmyFood[42]=2
    set DGW_ArmyTier[42]=1
    set DGW_Army[43]='dE33'
    set DGW_ArmyGold[43]=220
    set DGW_ArmyWood[43]=45
    set DGW_ArmyFood[43]=3
    set DGW_ArmyTier[43]=2
    set DGW_Army[44]='dE34'
    set DGW_ArmyGold[44]=230
    set DGW_ArmyWood[44]=70
    set DGW_ArmyFood[44]=3
    set DGW_ArmyTier[44]=2
    set DGW_Army[45]='dE35'
    set DGW_ArmyGold[45]=260
    set DGW_ArmyWood[45]=80
    set DGW_ArmyFood[45]=4
    set DGW_ArmyTier[45]=2
    set DGW_Army[46]='dE36'
    set DGW_ArmyGold[46]=200
    set DGW_ArmyWood[46]=60
    set DGW_ArmyFood[46]=2
    set DGW_ArmyTier[46]=2
    set DGW_Army[47]='dE37'
    set DGW_ArmyGold[47]=380
    set DGW_ArmyWood[47]=110
    set DGW_ArmyFood[47]=5
    set DGW_ArmyTier[47]=3
    set DGW_Worker[6]='dF00'
    set DGW_HQ1[6]='dF10'
    set DGW_HQ2[6]='dF11'
    set DGW_HQ3[6]='dF12'
    set DGW_Farm[6]='dF20'
    set DGW_Barracks[6]='dF21'
    set DGW_Altar[6]='dF24'
    set DGW_ChampionType[6]='DF80'
    set DGW_GodType[6]='DF90'
    set DGW_Spell[6]='YF00'
    set DGW_RaceName[6]="Эльфы Феникса"
    set DGW_GodName[6]="Каэлион, вечный Феникс"
    set DGW_Trait[6]="Хрупкая, но сильная армия; жар феникса поражает площадь."
    call SaveInteger(DGW_Data,6,11,'AHfs')
    call SaveInteger(DGW_Data,'dF00',1,1)
    call SaveInteger(DGW_Data,'dF00',2,6)
    call SaveInteger(DGW_Data,'dF10',1,2)
    call SaveInteger(DGW_Data,'dF10',2,6)
    call SaveInteger(DGW_Data,'dF10',3,1)
    call SaveInteger(DGW_Data,'dF11',1,2)
    call SaveInteger(DGW_Data,'dF11',2,6)
    call SaveInteger(DGW_Data,'dF11',3,2)
    call SaveInteger(DGW_Data,'dF12',1,2)
    call SaveInteger(DGW_Data,'dF12',2,6)
    call SaveInteger(DGW_Data,'dF12',3,3)
    call SaveInteger(DGW_Data,'dF20',1,3)
    call SaveInteger(DGW_Data,'dF20',2,6)
    call SaveInteger(DGW_Data,'dF21',1,3)
    call SaveInteger(DGW_Data,'dF21',2,6)
    call SaveInteger(DGW_Data,'dF22',1,3)
    call SaveInteger(DGW_Data,'dF22',2,6)
    call SaveInteger(DGW_Data,'dF23',1,3)
    call SaveInteger(DGW_Data,'dF23',2,6)
    call SaveInteger(DGW_Data,'dF24',1,3)
    call SaveInteger(DGW_Data,'dF24',2,6)
    call SaveInteger(DGW_Data,'dF25',1,3)
    call SaveInteger(DGW_Data,'dF25',2,6)
    call SaveInteger(DGW_Data,'dF30',1,4)
    call SaveInteger(DGW_Data,'dF30',2,6)
    call SaveInteger(DGW_Data,'dF31',1,4)
    call SaveInteger(DGW_Data,'dF31',2,6)
    call SaveInteger(DGW_Data,'dF32',1,4)
    call SaveInteger(DGW_Data,'dF32',2,6)
    call SaveInteger(DGW_Data,'dF33',1,4)
    call SaveInteger(DGW_Data,'dF33',2,6)
    call SaveInteger(DGW_Data,'dF34',1,4)
    call SaveInteger(DGW_Data,'dF34',2,6)
    call SaveInteger(DGW_Data,'dF35',1,4)
    call SaveInteger(DGW_Data,'dF35',2,6)
    call SaveInteger(DGW_Data,'dF36',1,4)
    call SaveInteger(DGW_Data,'dF36',2,6)
    call SaveInteger(DGW_Data,'dF37',1,4)
    call SaveInteger(DGW_Data,'dF37',2,6)
    call SaveInteger(DGW_Data,'DF80',1,5)
    call SaveInteger(DGW_Data,'DF80',2,6)
    call SaveInteger(DGW_Data,'DF90',1,6)
    call SaveInteger(DGW_Data,'DF90',2,6)
    set DGW_Army[48]='dF30'
    set DGW_ArmyGold[48]=123
    set DGW_ArmyWood[48]=0
    set DGW_ArmyFood[48]=2
    set DGW_ArmyTier[48]=1
    set DGW_Army[49]='dF31'
    set DGW_ArmyGold[49]=146
    set DGW_ArmyWood[49]=15
    set DGW_ArmyFood[49]=2
    set DGW_ArmyTier[49]=1
    set DGW_Army[50]='dF32'
    set DGW_ArmyGold[50]=179
    set DGW_ArmyWood[50]=30
    set DGW_ArmyFood[50]=2
    set DGW_ArmyTier[50]=1
    set DGW_Army[51]='dF33'
    set DGW_ArmyGold[51]=246
    set DGW_ArmyWood[51]=45
    set DGW_ArmyFood[51]=3
    set DGW_ArmyTier[51]=2
    set DGW_Army[52]='dF34'
    set DGW_ArmyGold[52]=258
    set DGW_ArmyWood[52]=70
    set DGW_ArmyFood[52]=3
    set DGW_ArmyTier[52]=2
    set DGW_Army[53]='dF35'
    set DGW_ArmyGold[53]=291
    set DGW_ArmyWood[53]=80
    set DGW_ArmyFood[53]=4
    set DGW_ArmyTier[53]=2
    set DGW_Army[54]='dF36'
    set DGW_ArmyGold[54]=224
    set DGW_ArmyWood[54]=60
    set DGW_ArmyFood[54]=2
    set DGW_ArmyTier[54]=2
    set DGW_Army[55]='dF37'
    set DGW_ArmyGold[55]=426
    set DGW_ArmyWood[55]=110
    set DGW_ArmyFood[55]=5
    set DGW_ArmyTier[55]=3
    set DGW_Worker[7]='dG00'
    set DGW_HQ1[7]='dG10'
    set DGW_HQ2[7]='dG11'
    set DGW_HQ3[7]='dG12'
    set DGW_Farm[7]='dG20'
    set DGW_Barracks[7]='dG21'
    set DGW_Altar[7]='dG24'
    set DGW_ChampionType[7]='DG80'
    set DGW_GodType[7]='DG90'
    set DGW_Spell[7]='YG00'
    set DGW_RaceName[7]="Держава Прилива"
    set DGW_GodName[7]="Азшари, богиня Глубин"
    set DGW_Trait[7]="Призыв водных стражей; стойкая пехота и сильные стрелки."
    call SaveInteger(DGW_Data,7,11,'ANfl')
    call SaveInteger(DGW_Data,'dG00',1,1)
    call SaveInteger(DGW_Data,'dG00',2,7)
    call SaveInteger(DGW_Data,'dG10',1,2)
    call SaveInteger(DGW_Data,'dG10',2,7)
    call SaveInteger(DGW_Data,'dG10',3,1)
    call SaveInteger(DGW_Data,'dG11',1,2)
    call SaveInteger(DGW_Data,'dG11',2,7)
    call SaveInteger(DGW_Data,'dG11',3,2)
    call SaveInteger(DGW_Data,'dG12',1,2)
    call SaveInteger(DGW_Data,'dG12',2,7)
    call SaveInteger(DGW_Data,'dG12',3,3)
    call SaveInteger(DGW_Data,'dG20',1,3)
    call SaveInteger(DGW_Data,'dG20',2,7)
    call SaveInteger(DGW_Data,'dG21',1,3)
    call SaveInteger(DGW_Data,'dG21',2,7)
    call SaveInteger(DGW_Data,'dG22',1,3)
    call SaveInteger(DGW_Data,'dG22',2,7)
    call SaveInteger(DGW_Data,'dG23',1,3)
    call SaveInteger(DGW_Data,'dG23',2,7)
    call SaveInteger(DGW_Data,'dG24',1,3)
    call SaveInteger(DGW_Data,'dG24',2,7)
    call SaveInteger(DGW_Data,'dG25',1,3)
    call SaveInteger(DGW_Data,'dG25',2,7)
    call SaveInteger(DGW_Data,'dG30',1,4)
    call SaveInteger(DGW_Data,'dG30',2,7)
    call SaveInteger(DGW_Data,'dG31',1,4)
    call SaveInteger(DGW_Data,'dG31',2,7)
    call SaveInteger(DGW_Data,'dG32',1,4)
    call SaveInteger(DGW_Data,'dG32',2,7)
    call SaveInteger(DGW_Data,'dG33',1,4)
    call SaveInteger(DGW_Data,'dG33',2,7)
    call SaveInteger(DGW_Data,'dG34',1,4)
    call SaveInteger(DGW_Data,'dG34',2,7)
    call SaveInteger(DGW_Data,'dG35',1,4)
    call SaveInteger(DGW_Data,'dG35',2,7)
    call SaveInteger(DGW_Data,'dG36',1,4)
    call SaveInteger(DGW_Data,'dG36',2,7)
    call SaveInteger(DGW_Data,'dG37',1,4)
    call SaveInteger(DGW_Data,'dG37',2,7)
    call SaveInteger(DGW_Data,'DG80',1,5)
    call SaveInteger(DGW_Data,'DG80',2,7)
    call SaveInteger(DGW_Data,'DG90',1,6)
    call SaveInteger(DGW_Data,'DG90',2,7)
    set DGW_Army[56]='dG30'
    set DGW_ArmyGold[56]=110
    set DGW_ArmyWood[56]=0
    set DGW_ArmyFood[56]=2
    set DGW_ArmyTier[56]=1
    set DGW_Army[57]='dG31'
    set DGW_ArmyGold[57]=130
    set DGW_ArmyWood[57]=15
    set DGW_ArmyFood[57]=2
    set DGW_ArmyTier[57]=1
    set DGW_Army[58]='dG32'
    set DGW_ArmyGold[58]=160
    set DGW_ArmyWood[58]=30
    set DGW_ArmyFood[58]=2
    set DGW_ArmyTier[58]=1
    set DGW_Army[59]='dG33'
    set DGW_ArmyGold[59]=220
    set DGW_ArmyWood[59]=45
    set DGW_ArmyFood[59]=3
    set DGW_ArmyTier[59]=2
    set DGW_Army[60]='dG34'
    set DGW_ArmyGold[60]=230
    set DGW_ArmyWood[60]=70
    set DGW_ArmyFood[60]=3
    set DGW_ArmyTier[60]=2
    set DGW_Army[61]='dG35'
    set DGW_ArmyGold[61]=260
    set DGW_ArmyWood[61]=80
    set DGW_ArmyFood[61]=4
    set DGW_ArmyTier[61]=2
    set DGW_Army[62]='dG36'
    set DGW_ArmyGold[62]=200
    set DGW_ArmyWood[62]=60
    set DGW_ArmyFood[62]=2
    set DGW_ArmyTier[62]=2
    set DGW_Army[63]='dG37'
    set DGW_ArmyGold[63]=380
    set DGW_ArmyWood[63]=110
    set DGW_ArmyFood[63]=5
    set DGW_ArmyTier[63]=3
    set DGW_Worker[8]='dH00'
    set DGW_HQ1[8]='dH10'
    set DGW_HQ2[8]='dH11'
    set DGW_HQ3[8]='dH12'
    set DGW_Farm[8]='dH20'
    set DGW_Barracks[8]='dH21'
    set DGW_Altar[8]='dH24'
    set DGW_ChampionType[8]='DH80'
    set DGW_GodType[8]='DH90'
    set DGW_Spell[8]='YH00'
    set DGW_RaceName[8]="Тролли Лоа"
    set DGW_GodName[8]="Зул’Аман, голос Лоа"
    set DGW_Trait[8]="За убийства получаешь дополнительную веру; призыв духов."
    call SaveInteger(DGW_Data,8,11,'AOhw')
    call SaveInteger(DGW_Data,'dH00',1,1)
    call SaveInteger(DGW_Data,'dH00',2,8)
    call SaveInteger(DGW_Data,'dH10',1,2)
    call SaveInteger(DGW_Data,'dH10',2,8)
    call SaveInteger(DGW_Data,'dH10',3,1)
    call SaveInteger(DGW_Data,'dH11',1,2)
    call SaveInteger(DGW_Data,'dH11',2,8)
    call SaveInteger(DGW_Data,'dH11',3,2)
    call SaveInteger(DGW_Data,'dH12',1,2)
    call SaveInteger(DGW_Data,'dH12',2,8)
    call SaveInteger(DGW_Data,'dH12',3,3)
    call SaveInteger(DGW_Data,'dH20',1,3)
    call SaveInteger(DGW_Data,'dH20',2,8)
    call SaveInteger(DGW_Data,'dH21',1,3)
    call SaveInteger(DGW_Data,'dH21',2,8)
    call SaveInteger(DGW_Data,'dH22',1,3)
    call SaveInteger(DGW_Data,'dH22',2,8)
    call SaveInteger(DGW_Data,'dH23',1,3)
    call SaveInteger(DGW_Data,'dH23',2,8)
    call SaveInteger(DGW_Data,'dH24',1,3)
    call SaveInteger(DGW_Data,'dH24',2,8)
    call SaveInteger(DGW_Data,'dH25',1,3)
    call SaveInteger(DGW_Data,'dH25',2,8)
    call SaveInteger(DGW_Data,'dH30',1,4)
    call SaveInteger(DGW_Data,'dH30',2,8)
    call SaveInteger(DGW_Data,'dH31',1,4)
    call SaveInteger(DGW_Data,'dH31',2,8)
    call SaveInteger(DGW_Data,'dH32',1,4)
    call SaveInteger(DGW_Data,'dH32',2,8)
    call SaveInteger(DGW_Data,'dH33',1,4)
    call SaveInteger(DGW_Data,'dH33',2,8)
    call SaveInteger(DGW_Data,'dH34',1,4)
    call SaveInteger(DGW_Data,'dH34',2,8)
    call SaveInteger(DGW_Data,'dH35',1,4)
    call SaveInteger(DGW_Data,'dH35',2,8)
    call SaveInteger(DGW_Data,'dH36',1,4)
    call SaveInteger(DGW_Data,'dH36',2,8)
    call SaveInteger(DGW_Data,'dH37',1,4)
    call SaveInteger(DGW_Data,'dH37',2,8)
    call SaveInteger(DGW_Data,'DH80',1,5)
    call SaveInteger(DGW_Data,'DH80',2,8)
    call SaveInteger(DGW_Data,'DH90',1,6)
    call SaveInteger(DGW_Data,'DH90',2,8)
    set DGW_Army[64]='dH30'
    set DGW_ArmyGold[64]=110
    set DGW_ArmyWood[64]=0
    set DGW_ArmyFood[64]=2
    set DGW_ArmyTier[64]=1
    set DGW_Army[65]='dH31'
    set DGW_ArmyGold[65]=130
    set DGW_ArmyWood[65]=15
    set DGW_ArmyFood[65]=2
    set DGW_ArmyTier[65]=1
    set DGW_Army[66]='dH32'
    set DGW_ArmyGold[66]=160
    set DGW_ArmyWood[66]=30
    set DGW_ArmyFood[66]=2
    set DGW_ArmyTier[66]=1
    set DGW_Army[67]='dH33'
    set DGW_ArmyGold[67]=220
    set DGW_ArmyWood[67]=45
    set DGW_ArmyFood[67]=3
    set DGW_ArmyTier[67]=2
    set DGW_Army[68]='dH34'
    set DGW_ArmyGold[68]=230
    set DGW_ArmyWood[68]=70
    set DGW_ArmyFood[68]=3
    set DGW_ArmyTier[68]=2
    set DGW_Army[69]='dH35'
    set DGW_ArmyGold[69]=260
    set DGW_ArmyWood[69]=80
    set DGW_ArmyFood[69]=4
    set DGW_ArmyTier[69]=2
    set DGW_Army[70]='dH36'
    set DGW_ArmyGold[70]=200
    set DGW_ArmyWood[70]=60
    set DGW_ArmyFood[70]=2
    set DGW_ArmyTier[70]=2
    set DGW_Army[71]='dH37'
    set DGW_ArmyGold[71]=380
    set DGW_ArmyWood[71]=110
    set DGW_ArmyFood[71]=5
    set DGW_ArmyTier[71]=3
    set DGW_Worker[9]='dI00'
    set DGW_HQ1[9]='dI10'
    set DGW_HQ2[9]='dI11'
    set DGW_HQ3[9]='dI12'
    set DGW_Farm[9]='dI20'
    set DGW_Barracks[9]='dI21'
    set DGW_Altar[9]='dI24'
    set DGW_ChampionType[9]='DI80'
    set DGW_GodType[9]='DI90'
    set DGW_Spell[9]='YI00'
    set DGW_RaceName[9]="Огры Камня"
    set DGW_GodName[9]="Грум, отец Гор"
    set DGW_Trait[9]="Медленные великаны с большим запасом здоровья; урон зданиям."
    call SaveInteger(DGW_Data,9,11,'AOsh')
    call SaveInteger(DGW_Data,'dI00',1,1)
    call SaveInteger(DGW_Data,'dI00',2,9)
    call SaveInteger(DGW_Data,'dI10',1,2)
    call SaveInteger(DGW_Data,'dI10',2,9)
    call SaveInteger(DGW_Data,'dI10',3,1)
    call SaveInteger(DGW_Data,'dI11',1,2)
    call SaveInteger(DGW_Data,'dI11',2,9)
    call SaveInteger(DGW_Data,'dI11',3,2)
    call SaveInteger(DGW_Data,'dI12',1,2)
    call SaveInteger(DGW_Data,'dI12',2,9)
    call SaveInteger(DGW_Data,'dI12',3,3)
    call SaveInteger(DGW_Data,'dI20',1,3)
    call SaveInteger(DGW_Data,'dI20',2,9)
    call SaveInteger(DGW_Data,'dI21',1,3)
    call SaveInteger(DGW_Data,'dI21',2,9)
    call SaveInteger(DGW_Data,'dI22',1,3)
    call SaveInteger(DGW_Data,'dI22',2,9)
    call SaveInteger(DGW_Data,'dI23',1,3)
    call SaveInteger(DGW_Data,'dI23',2,9)
    call SaveInteger(DGW_Data,'dI24',1,3)
    call SaveInteger(DGW_Data,'dI24',2,9)
    call SaveInteger(DGW_Data,'dI25',1,3)
    call SaveInteger(DGW_Data,'dI25',2,9)
    call SaveInteger(DGW_Data,'dI30',1,4)
    call SaveInteger(DGW_Data,'dI30',2,9)
    call SaveInteger(DGW_Data,'dI31',1,4)
    call SaveInteger(DGW_Data,'dI31',2,9)
    call SaveInteger(DGW_Data,'dI32',1,4)
    call SaveInteger(DGW_Data,'dI32',2,9)
    call SaveInteger(DGW_Data,'dI33',1,4)
    call SaveInteger(DGW_Data,'dI33',2,9)
    call SaveInteger(DGW_Data,'dI34',1,4)
    call SaveInteger(DGW_Data,'dI34',2,9)
    call SaveInteger(DGW_Data,'dI35',1,4)
    call SaveInteger(DGW_Data,'dI35',2,9)
    call SaveInteger(DGW_Data,'dI36',1,4)
    call SaveInteger(DGW_Data,'dI36',2,9)
    call SaveInteger(DGW_Data,'dI37',1,4)
    call SaveInteger(DGW_Data,'dI37',2,9)
    call SaveInteger(DGW_Data,'DI80',1,5)
    call SaveInteger(DGW_Data,'DI80',2,9)
    call SaveInteger(DGW_Data,'DI90',1,6)
    call SaveInteger(DGW_Data,'DI90',2,9)
    set DGW_Army[72]='dI30'
    set DGW_ArmyGold[72]=110
    set DGW_ArmyWood[72]=0
    set DGW_ArmyFood[72]=2
    set DGW_ArmyTier[72]=1
    set DGW_Army[73]='dI31'
    set DGW_ArmyGold[73]=130
    set DGW_ArmyWood[73]=15
    set DGW_ArmyFood[73]=2
    set DGW_ArmyTier[73]=1
    set DGW_Army[74]='dI32'
    set DGW_ArmyGold[74]=160
    set DGW_ArmyWood[74]=30
    set DGW_ArmyFood[74]=2
    set DGW_ArmyTier[74]=1
    set DGW_Army[75]='dI33'
    set DGW_ArmyGold[75]=220
    set DGW_ArmyWood[75]=45
    set DGW_ArmyFood[75]=3
    set DGW_ArmyTier[75]=2
    set DGW_Army[76]='dI34'
    set DGW_ArmyGold[76]=230
    set DGW_ArmyWood[76]=70
    set DGW_ArmyFood[76]=3
    set DGW_ArmyTier[76]=2
    set DGW_Army[77]='dI35'
    set DGW_ArmyGold[77]=260
    set DGW_ArmyWood[77]=80
    set DGW_ArmyFood[77]=4
    set DGW_ArmyTier[77]=2
    set DGW_Army[78]='dI36'
    set DGW_ArmyGold[78]=200
    set DGW_ArmyWood[78]=60
    set DGW_ArmyFood[78]=2
    set DGW_ArmyTier[78]=2
    set DGW_Army[79]='dI37'
    set DGW_ArmyGold[79]=380
    set DGW_ArmyWood[79]=110
    set DGW_ArmyFood[79]=5
    set DGW_ArmyTier[79]=3
    set DGW_Worker[10]='dJ00'
    set DGW_HQ1[10]='dJ10'
    set DGW_HQ2[10]='dJ11'
    set DGW_HQ3[10]='dJ12'
    set DGW_Farm[10]='dJ20'
    set DGW_Barracks[10]='dJ21'
    set DGW_Altar[10]='dJ24'
    set DGW_ChampionType[10]='DJ80'
    set DGW_GodType[10]='DJ90'
    set DGW_Spell[10]='YJ00'
    set DGW_RaceName[10]="Кобольды Недр"
    set DGW_GodName[10]="Керн, хранитель Искры"
    set DGW_Trait[10]="Дешёвая армия и ремонт укреплений; выгодная экономика."
    call SaveInteger(DGW_Data,10,11,'ANsy')
    call SaveInteger(DGW_Data,'dJ00',1,1)
    call SaveInteger(DGW_Data,'dJ00',2,10)
    call SaveInteger(DGW_Data,'dJ10',1,2)
    call SaveInteger(DGW_Data,'dJ10',2,10)
    call SaveInteger(DGW_Data,'dJ10',3,1)
    call SaveInteger(DGW_Data,'dJ11',1,2)
    call SaveInteger(DGW_Data,'dJ11',2,10)
    call SaveInteger(DGW_Data,'dJ11',3,2)
    call SaveInteger(DGW_Data,'dJ12',1,2)
    call SaveInteger(DGW_Data,'dJ12',2,10)
    call SaveInteger(DGW_Data,'dJ12',3,3)
    call SaveInteger(DGW_Data,'dJ20',1,3)
    call SaveInteger(DGW_Data,'dJ20',2,10)
    call SaveInteger(DGW_Data,'dJ21',1,3)
    call SaveInteger(DGW_Data,'dJ21',2,10)
    call SaveInteger(DGW_Data,'dJ22',1,3)
    call SaveInteger(DGW_Data,'dJ22',2,10)
    call SaveInteger(DGW_Data,'dJ23',1,3)
    call SaveInteger(DGW_Data,'dJ23',2,10)
    call SaveInteger(DGW_Data,'dJ24',1,3)
    call SaveInteger(DGW_Data,'dJ24',2,10)
    call SaveInteger(DGW_Data,'dJ25',1,3)
    call SaveInteger(DGW_Data,'dJ25',2,10)
    call SaveInteger(DGW_Data,'dJ30',1,4)
    call SaveInteger(DGW_Data,'dJ30',2,10)
    call SaveInteger(DGW_Data,'dJ31',1,4)
    call SaveInteger(DGW_Data,'dJ31',2,10)
    call SaveInteger(DGW_Data,'dJ32',1,4)
    call SaveInteger(DGW_Data,'dJ32',2,10)
    call SaveInteger(DGW_Data,'dJ33',1,4)
    call SaveInteger(DGW_Data,'dJ33',2,10)
    call SaveInteger(DGW_Data,'dJ34',1,4)
    call SaveInteger(DGW_Data,'dJ34',2,10)
    call SaveInteger(DGW_Data,'dJ35',1,4)
    call SaveInteger(DGW_Data,'dJ35',2,10)
    call SaveInteger(DGW_Data,'dJ36',1,4)
    call SaveInteger(DGW_Data,'dJ36',2,10)
    call SaveInteger(DGW_Data,'dJ37',1,4)
    call SaveInteger(DGW_Data,'dJ37',2,10)
    call SaveInteger(DGW_Data,'DJ80',1,5)
    call SaveInteger(DGW_Data,'DJ80',2,10)
    call SaveInteger(DGW_Data,'DJ90',1,6)
    call SaveInteger(DGW_Data,'DJ90',2,10)
    set DGW_Army[80]='dJ30'
    set DGW_ArmyGold[80]=96
    set DGW_ArmyWood[80]=0
    set DGW_ArmyFood[80]=2
    set DGW_ArmyTier[80]=1
    set DGW_Army[81]='dJ31'
    set DGW_ArmyGold[81]=113
    set DGW_ArmyWood[81]=15
    set DGW_ArmyFood[81]=2
    set DGW_ArmyTier[81]=1
    set DGW_Army[82]='dJ32'
    set DGW_ArmyGold[82]=139
    set DGW_ArmyWood[82]=30
    set DGW_ArmyFood[82]=2
    set DGW_ArmyTier[82]=1
    set DGW_Army[83]='dJ33'
    set DGW_ArmyGold[83]=191
    set DGW_ArmyWood[83]=45
    set DGW_ArmyFood[83]=3
    set DGW_ArmyTier[83]=2
    set DGW_Army[84]='dJ34'
    set DGW_ArmyGold[84]=200
    set DGW_ArmyWood[84]=70
    set DGW_ArmyFood[84]=3
    set DGW_ArmyTier[84]=2
    set DGW_Army[85]='dJ35'
    set DGW_ArmyGold[85]=226
    set DGW_ArmyWood[85]=80
    set DGW_ArmyFood[85]=4
    set DGW_ArmyTier[85]=2
    set DGW_Army[86]='dJ36'
    set DGW_ArmyGold[86]=174
    set DGW_ArmyWood[86]=60
    set DGW_ArmyFood[86]=2
    set DGW_ArmyTier[86]=2
    set DGW_Army[87]='dJ37'
    set DGW_ArmyGold[87]=331
    set DGW_ArmyWood[87]=110
    set DGW_ArmyFood[87]=5
    set DGW_ArmyTier[87]=3
    set DGW_Worker[11]='dK00'
    set DGW_HQ1[11]='dK10'
    set DGW_HQ2[11]='dK11'
    set DGW_HQ3[11]='dK12'
    set DGW_Farm[11]='dK20'
    set DGW_Barracks[11]='dK21'
    set DGW_Altar[11]='dK24'
    set DGW_ChampionType[11]='DK80'
    set DGW_GodType[11]='DK90'
    set DGW_Spell[11]='YK00'
    set DGW_RaceName[11]="Нерубский Рой"
    set DGW_GodName[11]="Ануб’Ра, владыка Роя"
    set DGW_Trait[11]="Призыв жуков; крепкие наземные части и контроль."
    call SaveInteger(DGW_Data,11,11,'AUim')
    call SaveInteger(DGW_Data,'dK00',1,1)
    call SaveInteger(DGW_Data,'dK00',2,11)
    call SaveInteger(DGW_Data,'dK10',1,2)
    call SaveInteger(DGW_Data,'dK10',2,11)
    call SaveInteger(DGW_Data,'dK10',3,1)
    call SaveInteger(DGW_Data,'dK11',1,2)
    call SaveInteger(DGW_Data,'dK11',2,11)
    call SaveInteger(DGW_Data,'dK11',3,2)
    call SaveInteger(DGW_Data,'dK12',1,2)
    call SaveInteger(DGW_Data,'dK12',2,11)
    call SaveInteger(DGW_Data,'dK12',3,3)
    call SaveInteger(DGW_Data,'dK20',1,3)
    call SaveInteger(DGW_Data,'dK20',2,11)
    call SaveInteger(DGW_Data,'dK21',1,3)
    call SaveInteger(DGW_Data,'dK21',2,11)
    call SaveInteger(DGW_Data,'dK22',1,3)
    call SaveInteger(DGW_Data,'dK22',2,11)
    call SaveInteger(DGW_Data,'dK23',1,3)
    call SaveInteger(DGW_Data,'dK23',2,11)
    call SaveInteger(DGW_Data,'dK24',1,3)
    call SaveInteger(DGW_Data,'dK24',2,11)
    call SaveInteger(DGW_Data,'dK25',1,3)
    call SaveInteger(DGW_Data,'dK25',2,11)
    call SaveInteger(DGW_Data,'dK30',1,4)
    call SaveInteger(DGW_Data,'dK30',2,11)
    call SaveInteger(DGW_Data,'dK31',1,4)
    call SaveInteger(DGW_Data,'dK31',2,11)
    call SaveInteger(DGW_Data,'dK32',1,4)
    call SaveInteger(DGW_Data,'dK32',2,11)
    call SaveInteger(DGW_Data,'dK33',1,4)
    call SaveInteger(DGW_Data,'dK33',2,11)
    call SaveInteger(DGW_Data,'dK34',1,4)
    call SaveInteger(DGW_Data,'dK34',2,11)
    call SaveInteger(DGW_Data,'dK35',1,4)
    call SaveInteger(DGW_Data,'dK35',2,11)
    call SaveInteger(DGW_Data,'dK36',1,4)
    call SaveInteger(DGW_Data,'dK36',2,11)
    call SaveInteger(DGW_Data,'dK37',1,4)
    call SaveInteger(DGW_Data,'dK37',2,11)
    call SaveInteger(DGW_Data,'DK80',1,5)
    call SaveInteger(DGW_Data,'DK80',2,11)
    call SaveInteger(DGW_Data,'DK90',1,6)
    call SaveInteger(DGW_Data,'DK90',2,11)
    set DGW_Army[88]='dK30'
    set DGW_ArmyGold[88]=110
    set DGW_ArmyWood[88]=0
    set DGW_ArmyFood[88]=2
    set DGW_ArmyTier[88]=1
    set DGW_Army[89]='dK31'
    set DGW_ArmyGold[89]=130
    set DGW_ArmyWood[89]=15
    set DGW_ArmyFood[89]=2
    set DGW_ArmyTier[89]=1
    set DGW_Army[90]='dK32'
    set DGW_ArmyGold[90]=160
    set DGW_ArmyWood[90]=30
    set DGW_ArmyFood[90]=2
    set DGW_ArmyTier[90]=1
    set DGW_Army[91]='dK33'
    set DGW_ArmyGold[91]=220
    set DGW_ArmyWood[91]=45
    set DGW_ArmyFood[91]=3
    set DGW_ArmyTier[91]=2
    set DGW_Army[92]='dK34'
    set DGW_ArmyGold[92]=230
    set DGW_ArmyWood[92]=70
    set DGW_ArmyFood[92]=3
    set DGW_ArmyTier[92]=2
    set DGW_Army[93]='dK35'
    set DGW_ArmyGold[93]=260
    set DGW_ArmyWood[93]=80
    set DGW_ArmyFood[93]=4
    set DGW_ArmyTier[93]=2
    set DGW_Army[94]='dK36'
    set DGW_ArmyGold[94]=200
    set DGW_ArmyWood[94]=60
    set DGW_ArmyFood[94]=2
    set DGW_ArmyTier[94]=2
    set DGW_Army[95]='dK37'
    set DGW_ArmyGold[95]=380
    set DGW_ArmyWood[95]=110
    set DGW_ArmyFood[95]=5
    set DGW_ArmyTier[95]=3
    set DGW_Worker[12]='dL00'
    set DGW_HQ1[12]='dL10'
    set DGW_HQ2[12]='dL11'
    set DGW_HQ3[12]='dL12'
    set DGW_Farm[12]='dL20'
    set DGW_Barracks[12]='dL21'
    set DGW_Altar[12]='dL24'
    set DGW_ChampionType[12]='DL80'
    set DGW_GodType[12]='DL90'
    set DGW_Spell[12]='YL00'
    set DGW_RaceName[12]="Легион Пепла"
    set DGW_GodName[12]="Азгар, бог Пламени"
    set DGW_Trait[12]="Дорогие ударные войска; призыв инфернала."
    call SaveInteger(DGW_Data,12,11,'ANrf')
    call SaveInteger(DGW_Data,'dL00',1,1)
    call SaveInteger(DGW_Data,'dL00',2,12)
    call SaveInteger(DGW_Data,'dL10',1,2)
    call SaveInteger(DGW_Data,'dL10',2,12)
    call SaveInteger(DGW_Data,'dL10',3,1)
    call SaveInteger(DGW_Data,'dL11',1,2)
    call SaveInteger(DGW_Data,'dL11',2,12)
    call SaveInteger(DGW_Data,'dL11',3,2)
    call SaveInteger(DGW_Data,'dL12',1,2)
    call SaveInteger(DGW_Data,'dL12',2,12)
    call SaveInteger(DGW_Data,'dL12',3,3)
    call SaveInteger(DGW_Data,'dL20',1,3)
    call SaveInteger(DGW_Data,'dL20',2,12)
    call SaveInteger(DGW_Data,'dL21',1,3)
    call SaveInteger(DGW_Data,'dL21',2,12)
    call SaveInteger(DGW_Data,'dL22',1,3)
    call SaveInteger(DGW_Data,'dL22',2,12)
    call SaveInteger(DGW_Data,'dL23',1,3)
    call SaveInteger(DGW_Data,'dL23',2,12)
    call SaveInteger(DGW_Data,'dL24',1,3)
    call SaveInteger(DGW_Data,'dL24',2,12)
    call SaveInteger(DGW_Data,'dL25',1,3)
    call SaveInteger(DGW_Data,'dL25',2,12)
    call SaveInteger(DGW_Data,'dL30',1,4)
    call SaveInteger(DGW_Data,'dL30',2,12)
    call SaveInteger(DGW_Data,'dL31',1,4)
    call SaveInteger(DGW_Data,'dL31',2,12)
    call SaveInteger(DGW_Data,'dL32',1,4)
    call SaveInteger(DGW_Data,'dL32',2,12)
    call SaveInteger(DGW_Data,'dL33',1,4)
    call SaveInteger(DGW_Data,'dL33',2,12)
    call SaveInteger(DGW_Data,'dL34',1,4)
    call SaveInteger(DGW_Data,'dL34',2,12)
    call SaveInteger(DGW_Data,'dL35',1,4)
    call SaveInteger(DGW_Data,'dL35',2,12)
    call SaveInteger(DGW_Data,'dL36',1,4)
    call SaveInteger(DGW_Data,'dL36',2,12)
    call SaveInteger(DGW_Data,'dL37',1,4)
    call SaveInteger(DGW_Data,'dL37',2,12)
    call SaveInteger(DGW_Data,'DL80',1,5)
    call SaveInteger(DGW_Data,'DL80',2,12)
    call SaveInteger(DGW_Data,'DL90',1,6)
    call SaveInteger(DGW_Data,'DL90',2,12)
    set DGW_Army[96]='dL30'
    set DGW_ArmyGold[96]=123
    set DGW_ArmyWood[96]=0
    set DGW_ArmyFood[96]=2
    set DGW_ArmyTier[96]=1
    set DGW_Army[97]='dL31'
    set DGW_ArmyGold[97]=146
    set DGW_ArmyWood[97]=15
    set DGW_ArmyFood[97]=2
    set DGW_ArmyTier[97]=1
    set DGW_Army[98]='dL32'
    set DGW_ArmyGold[98]=179
    set DGW_ArmyWood[98]=30
    set DGW_ArmyFood[98]=2
    set DGW_ArmyTier[98]=1
    set DGW_Army[99]='dL33'
    set DGW_ArmyGold[99]=246
    set DGW_ArmyWood[99]=45
    set DGW_ArmyFood[99]=3
    set DGW_ArmyTier[99]=2
    set DGW_Army[100]='dL34'
    set DGW_ArmyGold[100]=258
    set DGW_ArmyWood[100]=70
    set DGW_ArmyFood[100]=3
    set DGW_ArmyTier[100]=2
    set DGW_Army[101]='dL35'
    set DGW_ArmyGold[101]=291
    set DGW_ArmyWood[101]=80
    set DGW_ArmyFood[101]=4
    set DGW_ArmyTier[101]=2
    set DGW_Army[102]='dL36'
    set DGW_ArmyGold[102]=224
    set DGW_ArmyWood[102]=60
    set DGW_ArmyFood[102]=2
    set DGW_ArmyTier[102]=2
    set DGW_Army[103]='dL37'
    set DGW_ArmyGold[103]=426
    set DGW_ArmyWood[103]=110
    set DGW_ArmyFood[103]=5
    set DGW_ArmyTier[103]=3
    set DGW_Worker[13]='dM00'
    set DGW_HQ1[13]='dM10'
    set DGW_HQ2[13]='dM11'
    set DGW_HQ3[13]='dM12'
    set DGW_Farm[13]='dM20'
    set DGW_Barracks[13]='dM21'
    set DGW_Altar[13]='dM24'
    set DGW_ChampionType[13]='DM80'
    set DGW_GodType[13]='DM90'
    set DGW_Spell[13]='YM00'
    set DGW_RaceName[13]="Двор Крови"
    set DGW_GodName[13]="Сангвир, алый Владыка"
    set DGW_Trait[13]="Божественный удар лечит своего владыку за каждого врага."
    call SaveInteger(DGW_Data,13,11,'AUav')
    call SaveInteger(DGW_Data,'dM00',1,1)
    call SaveInteger(DGW_Data,'dM00',2,13)
    call SaveInteger(DGW_Data,'dM10',1,2)
    call SaveInteger(DGW_Data,'dM10',2,13)
    call SaveInteger(DGW_Data,'dM10',3,1)
    call SaveInteger(DGW_Data,'dM11',1,2)
    call SaveInteger(DGW_Data,'dM11',2,13)
    call SaveInteger(DGW_Data,'dM11',3,2)
    call SaveInteger(DGW_Data,'dM12',1,2)
    call SaveInteger(DGW_Data,'dM12',2,13)
    call SaveInteger(DGW_Data,'dM12',3,3)
    call SaveInteger(DGW_Data,'dM20',1,3)
    call SaveInteger(DGW_Data,'dM20',2,13)
    call SaveInteger(DGW_Data,'dM21',1,3)
    call SaveInteger(DGW_Data,'dM21',2,13)
    call SaveInteger(DGW_Data,'dM22',1,3)
    call SaveInteger(DGW_Data,'dM22',2,13)
    call SaveInteger(DGW_Data,'dM23',1,3)
    call SaveInteger(DGW_Data,'dM23',2,13)
    call SaveInteger(DGW_Data,'dM24',1,3)
    call SaveInteger(DGW_Data,'dM24',2,13)
    call SaveInteger(DGW_Data,'dM25',1,3)
    call SaveInteger(DGW_Data,'dM25',2,13)
    call SaveInteger(DGW_Data,'dM30',1,4)
    call SaveInteger(DGW_Data,'dM30',2,13)
    call SaveInteger(DGW_Data,'dM31',1,4)
    call SaveInteger(DGW_Data,'dM31',2,13)
    call SaveInteger(DGW_Data,'dM32',1,4)
    call SaveInteger(DGW_Data,'dM32',2,13)
    call SaveInteger(DGW_Data,'dM33',1,4)
    call SaveInteger(DGW_Data,'dM33',2,13)
    call SaveInteger(DGW_Data,'dM34',1,4)
    call SaveInteger(DGW_Data,'dM34',2,13)
    call SaveInteger(DGW_Data,'dM35',1,4)
    call SaveInteger(DGW_Data,'dM35',2,13)
    call SaveInteger(DGW_Data,'dM36',1,4)
    call SaveInteger(DGW_Data,'dM36',2,13)
    call SaveInteger(DGW_Data,'dM37',1,4)
    call SaveInteger(DGW_Data,'dM37',2,13)
    call SaveInteger(DGW_Data,'DM80',1,5)
    call SaveInteger(DGW_Data,'DM80',2,13)
    call SaveInteger(DGW_Data,'DM90',1,6)
    call SaveInteger(DGW_Data,'DM90',2,13)
    set DGW_Army[104]='dM30'
    set DGW_ArmyGold[104]=110
    set DGW_ArmyWood[104]=0
    set DGW_ArmyFood[104]=2
    set DGW_ArmyTier[104]=1
    set DGW_Army[105]='dM31'
    set DGW_ArmyGold[105]=130
    set DGW_ArmyWood[105]=15
    set DGW_ArmyFood[105]=2
    set DGW_ArmyTier[105]=1
    set DGW_Army[106]='dM32'
    set DGW_ArmyGold[106]=160
    set DGW_ArmyWood[106]=30
    set DGW_ArmyFood[106]=2
    set DGW_ArmyTier[106]=1
    set DGW_Army[107]='dM33'
    set DGW_ArmyGold[107]=220
    set DGW_ArmyWood[107]=45
    set DGW_ArmyFood[107]=3
    set DGW_ArmyTier[107]=2
    set DGW_Army[108]='dM34'
    set DGW_ArmyGold[108]=230
    set DGW_ArmyWood[108]=70
    set DGW_ArmyFood[108]=3
    set DGW_ArmyTier[108]=2
    set DGW_Army[109]='dM35'
    set DGW_ArmyGold[109]=260
    set DGW_ArmyWood[109]=80
    set DGW_ArmyFood[109]=4
    set DGW_ArmyTier[109]=2
    set DGW_Army[110]='dM36'
    set DGW_ArmyGold[110]=200
    set DGW_ArmyWood[110]=60
    set DGW_ArmyFood[110]=2
    set DGW_ArmyTier[110]=2
    set DGW_Army[111]='dM37'
    set DGW_ArmyGold[111]=380
    set DGW_ArmyWood[111]=110
    set DGW_ArmyFood[111]=5
    set DGW_ArmyTier[111]=3
    set DGW_Worker[14]='dN00'
    set DGW_HQ1[14]='dN10'
    set DGW_HQ2[14]='dN11'
    set DGW_HQ3[14]='dN12'
    set DGW_Farm[14]='dN20'
    set DGW_Barracks[14]='dN21'
    set DGW_Altar[14]='dN24'
    set DGW_ChampionType[14]='DN80'
    set DGW_GodType[14]='DN90'
    set DGW_Spell[14]='YN00'
    set DGW_RaceName[14]="Пандарены Тумана"
    set DGW_GodName[14]="Шен, хранитель Равновесия"
    set DGW_Trait[14]="Устойчивая армия; исцеление и снятие отрицательных эффектов."
    call SaveInteger(DGW_Data,14,11,'ANbf')
    call SaveInteger(DGW_Data,'dN00',1,1)
    call SaveInteger(DGW_Data,'dN00',2,14)
    call SaveInteger(DGW_Data,'dN10',1,2)
    call SaveInteger(DGW_Data,'dN10',2,14)
    call SaveInteger(DGW_Data,'dN10',3,1)
    call SaveInteger(DGW_Data,'dN11',1,2)
    call SaveInteger(DGW_Data,'dN11',2,14)
    call SaveInteger(DGW_Data,'dN11',3,2)
    call SaveInteger(DGW_Data,'dN12',1,2)
    call SaveInteger(DGW_Data,'dN12',2,14)
    call SaveInteger(DGW_Data,'dN12',3,3)
    call SaveInteger(DGW_Data,'dN20',1,3)
    call SaveInteger(DGW_Data,'dN20',2,14)
    call SaveInteger(DGW_Data,'dN21',1,3)
    call SaveInteger(DGW_Data,'dN21',2,14)
    call SaveInteger(DGW_Data,'dN22',1,3)
    call SaveInteger(DGW_Data,'dN22',2,14)
    call SaveInteger(DGW_Data,'dN23',1,3)
    call SaveInteger(DGW_Data,'dN23',2,14)
    call SaveInteger(DGW_Data,'dN24',1,3)
    call SaveInteger(DGW_Data,'dN24',2,14)
    call SaveInteger(DGW_Data,'dN25',1,3)
    call SaveInteger(DGW_Data,'dN25',2,14)
    call SaveInteger(DGW_Data,'dN30',1,4)
    call SaveInteger(DGW_Data,'dN30',2,14)
    call SaveInteger(DGW_Data,'dN31',1,4)
    call SaveInteger(DGW_Data,'dN31',2,14)
    call SaveInteger(DGW_Data,'dN32',1,4)
    call SaveInteger(DGW_Data,'dN32',2,14)
    call SaveInteger(DGW_Data,'dN33',1,4)
    call SaveInteger(DGW_Data,'dN33',2,14)
    call SaveInteger(DGW_Data,'dN34',1,4)
    call SaveInteger(DGW_Data,'dN34',2,14)
    call SaveInteger(DGW_Data,'dN35',1,4)
    call SaveInteger(DGW_Data,'dN35',2,14)
    call SaveInteger(DGW_Data,'dN36',1,4)
    call SaveInteger(DGW_Data,'dN36',2,14)
    call SaveInteger(DGW_Data,'dN37',1,4)
    call SaveInteger(DGW_Data,'dN37',2,14)
    call SaveInteger(DGW_Data,'DN80',1,5)
    call SaveInteger(DGW_Data,'DN80',2,14)
    call SaveInteger(DGW_Data,'DN90',1,6)
    call SaveInteger(DGW_Data,'DN90',2,14)
    set DGW_Army[112]='dN30'
    set DGW_ArmyGold[112]=110
    set DGW_ArmyWood[112]=0
    set DGW_ArmyFood[112]=2
    set DGW_ArmyTier[112]=1
    set DGW_Army[113]='dN31'
    set DGW_ArmyGold[113]=130
    set DGW_ArmyWood[113]=15
    set DGW_ArmyFood[113]=2
    set DGW_ArmyTier[113]=1
    set DGW_Army[114]='dN32'
    set DGW_ArmyGold[114]=160
    set DGW_ArmyWood[114]=30
    set DGW_ArmyFood[114]=2
    set DGW_ArmyTier[114]=1
    set DGW_Army[115]='dN33'
    set DGW_ArmyGold[115]=220
    set DGW_ArmyWood[115]=45
    set DGW_ArmyFood[115]=3
    set DGW_ArmyTier[115]=2
    set DGW_Army[116]='dN34'
    set DGW_ArmyGold[116]=230
    set DGW_ArmyWood[116]=70
    set DGW_ArmyFood[116]=3
    set DGW_ArmyTier[116]=2
    set DGW_Army[117]='dN35'
    set DGW_ArmyGold[117]=260
    set DGW_ArmyWood[117]=80
    set DGW_ArmyFood[117]=4
    set DGW_ArmyTier[117]=2
    set DGW_Army[118]='dN36'
    set DGW_ArmyGold[118]=200
    set DGW_ArmyWood[118]=60
    set DGW_ArmyFood[118]=2
    set DGW_ArmyTier[118]=2
    set DGW_Army[119]='dN37'
    set DGW_ArmyGold[119]=380
    set DGW_ArmyWood[119]=110
    set DGW_ArmyFood[119]=5
    set DGW_ArmyTier[119]=3
    set DGW_Worker[15]='dO00'
    set DGW_HQ1[15]='dO10'
    set DGW_HQ2[15]='dO11'
    set DGW_HQ3[15]='dO12'
    set DGW_Farm[15]='dO20'
    set DGW_Barracks[15]='dO21'
    set DGW_Altar[15]='dO24'
    set DGW_ChampionType[15]='DO80'
    set DGW_GodType[15]='DO90'
    set DGW_Spell[15]='YO00'
    set DGW_RaceName[15]="Крылья Драконов"
    set DGW_GodName[15]="Астрагор, отец Неба"
    set DGW_Trait[15]="Дорогие драконы и сильная авиация; разрушительный огонь."
    call SaveInteger(DGW_Data,15,11,'AHfs')
    call SaveInteger(DGW_Data,'dO00',1,1)
    call SaveInteger(DGW_Data,'dO00',2,15)
    call SaveInteger(DGW_Data,'dO10',1,2)
    call SaveInteger(DGW_Data,'dO10',2,15)
    call SaveInteger(DGW_Data,'dO10',3,1)
    call SaveInteger(DGW_Data,'dO11',1,2)
    call SaveInteger(DGW_Data,'dO11',2,15)
    call SaveInteger(DGW_Data,'dO11',3,2)
    call SaveInteger(DGW_Data,'dO12',1,2)
    call SaveInteger(DGW_Data,'dO12',2,15)
    call SaveInteger(DGW_Data,'dO12',3,3)
    call SaveInteger(DGW_Data,'dO20',1,3)
    call SaveInteger(DGW_Data,'dO20',2,15)
    call SaveInteger(DGW_Data,'dO21',1,3)
    call SaveInteger(DGW_Data,'dO21',2,15)
    call SaveInteger(DGW_Data,'dO22',1,3)
    call SaveInteger(DGW_Data,'dO22',2,15)
    call SaveInteger(DGW_Data,'dO23',1,3)
    call SaveInteger(DGW_Data,'dO23',2,15)
    call SaveInteger(DGW_Data,'dO24',1,3)
    call SaveInteger(DGW_Data,'dO24',2,15)
    call SaveInteger(DGW_Data,'dO25',1,3)
    call SaveInteger(DGW_Data,'dO25',2,15)
    call SaveInteger(DGW_Data,'dO30',1,4)
    call SaveInteger(DGW_Data,'dO30',2,15)
    call SaveInteger(DGW_Data,'dO31',1,4)
    call SaveInteger(DGW_Data,'dO31',2,15)
    call SaveInteger(DGW_Data,'dO32',1,4)
    call SaveInteger(DGW_Data,'dO32',2,15)
    call SaveInteger(DGW_Data,'dO33',1,4)
    call SaveInteger(DGW_Data,'dO33',2,15)
    call SaveInteger(DGW_Data,'dO34',1,4)
    call SaveInteger(DGW_Data,'dO34',2,15)
    call SaveInteger(DGW_Data,'dO35',1,4)
    call SaveInteger(DGW_Data,'dO35',2,15)
    call SaveInteger(DGW_Data,'dO36',1,4)
    call SaveInteger(DGW_Data,'dO36',2,15)
    call SaveInteger(DGW_Data,'dO37',1,4)
    call SaveInteger(DGW_Data,'dO37',2,15)
    call SaveInteger(DGW_Data,'DO80',1,5)
    call SaveInteger(DGW_Data,'DO80',2,15)
    call SaveInteger(DGW_Data,'DO90',1,6)
    call SaveInteger(DGW_Data,'DO90',2,15)
    set DGW_Army[120]='dO30'
    set DGW_ArmyGold[120]=123
    set DGW_ArmyWood[120]=0
    set DGW_ArmyFood[120]=2
    set DGW_ArmyTier[120]=1
    set DGW_Army[121]='dO31'
    set DGW_ArmyGold[121]=146
    set DGW_ArmyWood[121]=15
    set DGW_ArmyFood[121]=2
    set DGW_ArmyTier[121]=1
    set DGW_Army[122]='dO32'
    set DGW_ArmyGold[122]=179
    set DGW_ArmyWood[122]=30
    set DGW_ArmyFood[122]=2
    set DGW_ArmyTier[122]=1
    set DGW_Army[123]='dO33'
    set DGW_ArmyGold[123]=246
    set DGW_ArmyWood[123]=45
    set DGW_ArmyFood[123]=3
    set DGW_ArmyTier[123]=2
    set DGW_Army[124]='dO34'
    set DGW_ArmyGold[124]=258
    set DGW_ArmyWood[124]=70
    set DGW_ArmyFood[124]=3
    set DGW_ArmyTier[124]=2
    set DGW_Army[125]='dO35'
    set DGW_ArmyGold[125]=291
    set DGW_ArmyWood[125]=80
    set DGW_ArmyFood[125]=4
    set DGW_ArmyTier[125]=2
    set DGW_Army[126]='dO36'
    set DGW_ArmyGold[126]=224
    set DGW_ArmyWood[126]=60
    set DGW_ArmyFood[126]=2
    set DGW_ArmyTier[126]=2
    set DGW_Army[127]='dO37'
    set DGW_ArmyGold[127]=426
    set DGW_ArmyWood[127]=110
    set DGW_ArmyFood[127]=5
    set DGW_ArmyTier[127]=3
    set DGW_Worker[16]='dP00'
    set DGW_HQ1[16]='dP10'
    set DGW_HQ2[16]='dP11'
    set DGW_HQ3[16]='dP12'
    set DGW_Farm[16]='dP20'
    set DGW_Barracks[16]='dP21'
    set DGW_Altar[16]='dP24'
    set DGW_ChampionType[16]='DP80'
    set DGW_GodType[16]='DP90'
    set DGW_Spell[16]='YP00'
    set DGW_RaceName[16]="Безликие Бездны"
    set DGW_GodName[16]="Ниал, око Бездны"
    set DGW_Trait[16]="Притягивание врагов к точке удара; сильная элитная пехота."
    call SaveInteger(DGW_Data,16,11,'AUav')
    call SaveInteger(DGW_Data,'dP00',1,1)
    call SaveInteger(DGW_Data,'dP00',2,16)
    call SaveInteger(DGW_Data,'dP10',1,2)
    call SaveInteger(DGW_Data,'dP10',2,16)
    call SaveInteger(DGW_Data,'dP10',3,1)
    call SaveInteger(DGW_Data,'dP11',1,2)
    call SaveInteger(DGW_Data,'dP11',2,16)
    call SaveInteger(DGW_Data,'dP11',3,2)
    call SaveInteger(DGW_Data,'dP12',1,2)
    call SaveInteger(DGW_Data,'dP12',2,16)
    call SaveInteger(DGW_Data,'dP12',3,3)
    call SaveInteger(DGW_Data,'dP20',1,3)
    call SaveInteger(DGW_Data,'dP20',2,16)
    call SaveInteger(DGW_Data,'dP21',1,3)
    call SaveInteger(DGW_Data,'dP21',2,16)
    call SaveInteger(DGW_Data,'dP22',1,3)
    call SaveInteger(DGW_Data,'dP22',2,16)
    call SaveInteger(DGW_Data,'dP23',1,3)
    call SaveInteger(DGW_Data,'dP23',2,16)
    call SaveInteger(DGW_Data,'dP24',1,3)
    call SaveInteger(DGW_Data,'dP24',2,16)
    call SaveInteger(DGW_Data,'dP25',1,3)
    call SaveInteger(DGW_Data,'dP25',2,16)
    call SaveInteger(DGW_Data,'dP30',1,4)
    call SaveInteger(DGW_Data,'dP30',2,16)
    call SaveInteger(DGW_Data,'dP31',1,4)
    call SaveInteger(DGW_Data,'dP31',2,16)
    call SaveInteger(DGW_Data,'dP32',1,4)
    call SaveInteger(DGW_Data,'dP32',2,16)
    call SaveInteger(DGW_Data,'dP33',1,4)
    call SaveInteger(DGW_Data,'dP33',2,16)
    call SaveInteger(DGW_Data,'dP34',1,4)
    call SaveInteger(DGW_Data,'dP34',2,16)
    call SaveInteger(DGW_Data,'dP35',1,4)
    call SaveInteger(DGW_Data,'dP35',2,16)
    call SaveInteger(DGW_Data,'dP36',1,4)
    call SaveInteger(DGW_Data,'dP36',2,16)
    call SaveInteger(DGW_Data,'dP37',1,4)
    call SaveInteger(DGW_Data,'dP37',2,16)
    call SaveInteger(DGW_Data,'DP80',1,5)
    call SaveInteger(DGW_Data,'DP80',2,16)
    call SaveInteger(DGW_Data,'DP90',1,6)
    call SaveInteger(DGW_Data,'DP90',2,16)
    set DGW_Army[128]='dP30'
    set DGW_ArmyGold[128]=110
    set DGW_ArmyWood[128]=0
    set DGW_ArmyFood[128]=2
    set DGW_ArmyTier[128]=1
    set DGW_Army[129]='dP31'
    set DGW_ArmyGold[129]=130
    set DGW_ArmyWood[129]=15
    set DGW_ArmyFood[129]=2
    set DGW_ArmyTier[129]=1
    set DGW_Army[130]='dP32'
    set DGW_ArmyGold[130]=160
    set DGW_ArmyWood[130]=30
    set DGW_ArmyFood[130]=2
    set DGW_ArmyTier[130]=1
    set DGW_Army[131]='dP33'
    set DGW_ArmyGold[131]=220
    set DGW_ArmyWood[131]=45
    set DGW_ArmyFood[131]=3
    set DGW_ArmyTier[131]=2
    set DGW_Army[132]='dP34'
    set DGW_ArmyGold[132]=230
    set DGW_ArmyWood[132]=70
    set DGW_ArmyFood[132]=3
    set DGW_ArmyTier[132]=2
    set DGW_Army[133]='dP35'
    set DGW_ArmyGold[133]=260
    set DGW_ArmyWood[133]=80
    set DGW_ArmyFood[133]=4
    set DGW_ArmyTier[133]=2
    set DGW_Army[134]='dP36'
    set DGW_ArmyGold[134]=200
    set DGW_ArmyWood[134]=60
    set DGW_ArmyFood[134]=2
    set DGW_ArmyTier[134]=2
    set DGW_Army[135]='dP37'
    set DGW_ArmyGold[135]=380
    set DGW_ArmyWood[135]=110
    set DGW_ArmyFood[135]=5
    set DGW_ArmyTier[135]=3
    set DGW_StartX[0]=8192.0
    set DGW_StartY[0]=0.0
    set DGW_StartX[1]=7168.0
    set DGW_StartY[1]=4096.0
    set DGW_StartX[2]=4096.0
    set DGW_StartY[2]=7168.0
    set DGW_StartX[3]=0.0
    set DGW_StartY[3]=8192.0
    set DGW_StartX[4]=-4096.0
    set DGW_StartY[4]=7168.0
    set DGW_StartX[5]=-7168.0
    set DGW_StartY[5]=4096.0
    set DGW_StartX[6]=-8192.0
    set DGW_StartY[6]=0.0
    set DGW_StartX[7]=-7168.0
    set DGW_StartY[7]=-4096.0
    set DGW_StartX[8]=-4096.0
    set DGW_StartY[8]=-7168.0
    set DGW_StartX[9]=0.0
    set DGW_StartY[9]=-7936.0
    set DGW_StartX[10]=4096.0
    set DGW_StartY[10]=-7168.0
    set DGW_StartX[11]=7168.0
    set DGW_StartY[11]=-4096.0
    set DGW_ShrineX[0]=0.0
    set DGW_ShrineY[0]=0.0
    set DGW_ShrineX[1]=4096.0
    set DGW_ShrineY[1]=0.0
    set DGW_ShrineX[2]=-4096.0
    set DGW_ShrineY[2]=0.0
    set DGW_ShrineX[3]=0.0
    set DGW_ShrineY[3]=4096.0
    set DGW_ShrineX[4]=0.0
    set DGW_ShrineY[4]=-4096.0
endfunction

function DGW_Message takes integer p, string s returns nothing
    call DisplayTimedTextToPlayer(Player(p),0,0,12,s)
endfunction

function DGW_Cell takes integer row, integer col, string text returns nothing
    local multiboarditem item=MultiboardGetItem(DGW_Board,row,col)
    call MultiboardSetItemStyle(item,true,false)
    call MultiboardSetItemValue(item,text)
    if col==0 then
        call MultiboardSetItemWidth(item,0.14)
    else
        call MultiboardSetItemWidth(item,0.065)
    endif
    call MultiboardReleaseItem(item)
    set item=null
endfunction

function DGW_ClearTree takes nothing returns nothing
    call RemoveDestructable(GetEnumDestructable())
endfunction

function DGW_ScanCapital takes integer p returns integer
    local group g=CreateGroup()
    local unit u
    local integer count=0
    local integer tier=0
    local integer t
    call GroupEnumUnitsOfPlayer(g,Player(p),null)
    set DGW_Main[p]=null
    loop
        set u=FirstOfGroup(g)
        exitwhen u==null
        call GroupRemoveUnit(g,u)
        if GetWidgetLife(u)>0.405 and LoadInteger(DGW_Data,GetUnitTypeId(u),1)==2 then
            set count=count+1
            set t=LoadInteger(DGW_Data,GetUnitTypeId(u),3)
            if t>tier then
                set tier=t
                set DGW_Main[p]=u
            endif
        endif
    endloop
    set DGW_Tier[p]=tier
    call DestroyGroup(g)
    set g=null
    set u=null
    return count
endfunction

function DGW_Win takes integer winner returns nothing
    local integer i=0
    if DGW_Ended then
        return
    endif
    set DGW_Ended=true
    call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,30,"|cffffcc00Победитель: "+GetPlayerName(Player(winner))+" — "+DGW_RaceName[DGW_Race[winner]]+"!|r")
    loop
        exitwhen i>=12
        if DGW_Active[i] then
            if i==winner then
                call CustomVictoryBJ(Player(i),true,true)
            elseif DGW_Alive[i] then
                call CustomDefeatBJ(Player(i),"Победил другой владыка.")
            endif
        endif
        set i=i+1
    endloop
endfunction

function DGW_CheckVictory takes nothing returns nothing
    local integer p=0
    local integer alive=0
    local integer last=-1
    if DGW_Ended or not DGW_Begun or DGW_Pending>0 or DGW_InitialPlayers<2 then
        return
    endif
    loop
        exitwhen p>=12
        if DGW_Alive[p] and DGW_Chosen[p] then
            set alive=alive+1
            set last=p
        endif
        set p=p+1
    endloop
    if alive==1 then
        call DGW_Win(last)
    endif
endfunction

function DGW_SpawnRace takes integer p, integer r returns nothing
    local real x=DGW_StartX[p]
    local real y=DGW_StartY[p]
    local integer i=0
    local unit u
    local unit mine
    local rect area
    if not DGW_Active[p] or not DGW_Chosen[p] or not DGW_Alive[p] or r<1 or r>16 or DGW_Ended then
        return
    endif
    call DialogDisplay(Player(p),DGW_Dialog[p],false)
    call DialogClear(DGW_Dialog[p])
    set area=Rect(x-500,y-500,x+500,y+500)
    call EnumDestructablesInRect(area,null,function DGW_ClearTree)
    call RemoveRect(area)
    set area=null
    set DGW_Main[p]=CreateUnit(Player(p),DGW_HQ1[r],x,y,270)
    set DGW_Tier[p]=1
    set u=CreateUnit(Player(p),DGW_Farm[r],x+288,y+256,270)
    set DGW_BarracksUnit[p]=CreateUnit(Player(p),DGW_Barracks[r],x-288,y+256,270)
    set DGW_AltarUnit[p]=CreateUnit(Player(p),DGW_Altar[r],x+288,y-256,270)
    set mine=CreateUnit(Player(PLAYER_NEUTRAL_PASSIVE),'ngol',x-384,y-256,270)
    call SetResourceAmount(mine,40000)
    loop
        exitwhen i>=5
        set u=CreateUnit(Player(p),DGW_Worker[r],x-180+i*65,y-150,270)
        call IssueTargetOrder(u,"harvest",mine)
        set i=i+1
    endloop
    set i=0
    loop
        exitwhen i>=3
        set u=CreateUnit(Player(p),DGW_Army[r*8],x-100+i*90,y-340,270)
        set i=i+1
    endloop
    set u=CreateUnit(Player(p),DGW_ChampionType[r],x,y-290,270)
    call SetPlayerTechMaxAllowed(Player(p),DGW_ChampionType[r],1)
    call SetPlayerTechMaxAllowed(Player(p),DGW_GodType[r],1)
    call SetPlayerTechMaxAllowed(Player(p),DGW_Worker[r],18)
    call SetPlayerTechMaxAllowed(Player(p),DGW_Farm[r]+5,10)
    call SetPlayerState(Player(p),PLAYER_STATE_RESOURCE_GOLD,750)
    call SetPlayerState(Player(p),PLAYER_STATE_RESOURCE_LUMBER,400)
    call SetPlayerState(Player(p),PLAYER_STATE_FOOD_CAP_CEILING,200)
    set DGW_Faith[p]=10
    call PanCameraToTimedForPlayer(Player(p),x,y,0)
    call SetCameraFieldForPlayer(Player(p),CAMERA_FIELD_TARGET_DISTANCE,2300,0)
    call SelectUnitForPlayerSingle(u,Player(p))
    call DGW_Message(p,"|cffffcc00"+DGW_RaceName[r]+"|r: "+DGW_Trait[r])
    call DGW_Message(p,"Развивай столицу, добывай ресурсы и захватывай святилища. Бог: цитадель III + 800 золота + 350 дерева + 150 веры; кнопка V в алтаре. Подробности — F9.")
    set mine=null
    set u=null
endfunction

function DGW_BeginMatch takes nothing returns nothing
    local integer p=0
    if DGW_Begun or DGW_Pending>0 or DGW_Ended then
        return
    endif
    set DGW_Begun=true
    set DGW_Time=0
    loop
        exitwhen p>=12
        if DGW_Active[p] and DGW_Alive[p] and DGW_Chosen[p] then
            call DGW_SpawnRace(p,DGW_Race[p])
        endif
        set p=p+1
    endloop
    call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,12,"|cffffcc00Все выбрали расы. Партия началась — удачи!|r")
endfunction

function DGW_ChooseRace takes integer p, integer r returns nothing
    if p<0 or p>=12 or r<1 or r>16 then
        return
    endif
    if not DGW_Active[p] or not DGW_Alive[p] or DGW_Chosen[p] or DGW_Begun or DGW_Ended then
        return
    endif
    set DGW_Race[p]=r
    set DGW_Chosen[p]=true
    set DGW_Pending=DGW_Pending-1
    call DialogDisplay(Player(p),DGW_Dialog[p],false)
    call DGW_Message(p,"Раса выбрана: "+DGW_RaceName[r]+". Ждём остальных — все начнут одновременно.")
    call DGW_BeginMatch()
endfunction

function DGW_ShowMenu takes integer p returns nothing
    local integer i=0
    local integer r
    if not DGW_Active[p] or DGW_Chosen[p] or not DGW_Alive[p] then
        return
    endif
    call DialogClear(DGW_Dialog[p])
    call DialogSetMessage(DGW_Dialog[p],"Боги и Империи — выбери расу ("+I2S(DGW_Page[p]+1)+"/2)")
    loop
        exitwhen i>=8
        set r=DGW_Page[p]*8+i+1
        set DGW_Button[p*12+i]=DialogAddButton(DGW_Dialog[p],DGW_RaceName[r],0)
        set i=i+1
    endloop
    set DGW_Button[p*12+8]=DialogAddButton(DGW_Dialog[p],"Следующие / предыдущие расы",0)
    set DGW_Button[p*12+9]=DialogAddButton(DGW_Dialog[p],"Случайная раса",0)
    call DialogDisplay(Player(p),DGW_Dialog[p],true)
endfunction

function DGW_MenuClick takes nothing returns nothing
    local integer p=GetPlayerId(GetTriggerPlayer())
    local button b=GetClickedButton()
    local integer i=0
    if p<0 or p>=12 or not DGW_Active[p] or DGW_Chosen[p] then
        set b=null
        return
    endif
    loop
        exitwhen i>=8
        if b==DGW_Button[p*12+i] then
            call DGW_ChooseRace(p,DGW_Page[p]*8+i+1)
            set b=null
            return
        endif
        set i=i+1
    endloop
    if b==DGW_Button[p*12+8] then
        set DGW_Page[p]=1-DGW_Page[p]
        call DGW_ShowMenu(p)
    elseif b==DGW_Button[p*12+9] then
        call DGW_ChooseRace(p,GetRandomInt(1,16))
    endif
    set b=null
endfunction

function DGW_TryAscend takes integer p returns boolean
    local integer r=DGW_Race[p]
    local unit u=DGW_AltarUnit[p]
    if not DGW_Alive[p] or r==0 or DGW_Ascended[p] then
        call DGW_Message(p,"Бог уже призван. Павшего бога можно воскресить в алтаре.")
        set u=null
        return false
    endif
    call DGW_ScanCapital(p)
    if DGW_Tier[p]<3 or u==null or GetWidgetLife(u)<=0.405 then
        call DGW_Message(p,"Для вознесения нужны цитадель III ступени и действующий алтарь.")
        set u=null
        return false
    endif
    if DGW_Faith[p]<150 or GetPlayerState(Player(p),PLAYER_STATE_RESOURCE_GOLD)<800 or GetPlayerState(Player(p),PLAYER_STATE_RESOURCE_LUMBER)<350 then
        call DGW_Message(p,"Вознесение стоит 800 золота, 350 дерева и 150 веры.")
        set u=null
        return false
    endif
    set DGW_Ascended[p]=true
    set DGW_Faith[p]=DGW_Faith[p]-150
    call SetPlayerState(Player(p),PLAYER_STATE_RESOURCE_GOLD,GetPlayerState(Player(p),PLAYER_STATE_RESOURCE_GOLD)-800)
    call SetPlayerState(Player(p),PLAYER_STATE_RESOURCE_LUMBER,GetPlayerState(Player(p),PLAYER_STATE_RESOURCE_LUMBER)-350)
    set DGW_God[p]=CreateUnit(Player(p),DGW_GodType[r],GetUnitX(u),GetUnitY(u)-210,270)
    call SetHeroLevel(DGW_God[p],6,false)
    call SelectHeroSkill(DGW_God[p],LoadInteger(DGW_Data,r,11))
    call DestroyEffect(AddSpecialEffect("Abilities\\Spells\\Human\\Resurrect\\ResurrectTarget.mdl",GetUnitX(u),GetUnitY(u)))
    call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,12,"|cffffcc00"+DGW_GodName[r]+" вступает в битву!|r")
    set u=null
    return true
endfunction

function DGW_SpellCast takes nothing returns nothing
    local unit caster=GetTriggerUnit()
    local player owner=GetOwningPlayer(caster)
    local integer p=GetPlayerId(owner)
    local integer r
    local integer mode
    local integer id=GetSpellAbilityId()
    local real x
    local real y
    local real damage
    local real healing
    local real hp
    local integer hits=0
    local integer i=0
    local integer summon=0
    local unit u
    local group g
    if p<0 or p>=12 or not DGW_Alive[p] then
        set caster=null
        set owner=null
        return
    endif
    set r=DGW_Race[p]
    if id=='ZG00' and LoadInteger(DGW_Data,GetUnitTypeId(caster),1)==3 and GetUnitTypeId(caster)==DGW_Altar[r] then
        set DGW_AltarUnit[p]=caster
        call DGW_TryAscend(p)
    elseif r>0 and id==DGW_Spell[r] and caster==DGW_God[p] then
        set mode=r-1
        set x=GetSpellTargetX()
        set y=GetSpellTargetY()
        set damage=330
        set healing=0
        if mode==0 then
            set damage=220
            set healing=260
        elseif mode==3 or mode==13 then
            set damage=100
            set healing=430
        elseif mode==5 or mode==14 then
            set damage=540
        endif
        call DestroyEffect(AddSpecialEffect("Abilities\\Spells\\Human\\Thunderclap\\ThunderClapCaster.mdl",x,y))
        set g=CreateGroup()
        call GroupEnumUnitsInRange(g,x,y,420,null)
        loop
            set u=FirstOfGroup(g)
            exitwhen u==null
            call GroupRemoveUnit(g,u)
            if GetWidgetLife(u)>0.405 and not IsUnitType(u,UNIT_TYPE_MAGIC_IMMUNE) then
                if IsUnitEnemy(u,owner) and GetUnitAbilityLevel(u,'Avul')==0 then
                    set hp=damage
                    if mode==8 and IsUnitType(u,UNIT_TYPE_STRUCTURE) then
                        set hp=hp*2
                    endif
                    call UnitDamageTarget(caster,u,hp,true,false,ATTACK_TYPE_MAGIC,DAMAGE_TYPE_MAGIC,null)
                    set hits=hits+1
                    if mode==2 then
                        call SetUnitState(u,UNIT_STATE_MANA,RMaxBJ(0,GetUnitState(u,UNIT_STATE_MANA)-120))
                    elseif mode==15 and not IsUnitType(u,UNIT_TYPE_STRUCTURE) then
                        call SetUnitPosition(u,GetUnitX(u)*0.45+x*0.55,GetUnitY(u)*0.45+y*0.55)
                    endif
                elseif IsUnitAlly(u,owner) then
                    set hp=healing
                    if (mode==4 or mode==9) and IsUnitType(u,UNIT_TYPE_STRUCTURE) then
                        set hp=700
                    endif
                    call SetWidgetLife(u,RMinBJ(GetUnitState(u,UNIT_STATE_MAX_LIFE),GetWidgetLife(u)+hp))
                    if mode==3 then
                        call SetUnitState(u,UNIT_STATE_MANA,RMinBJ(GetUnitState(u,UNIT_STATE_MAX_MANA),GetUnitState(u,UNIT_STATE_MANA)+120))
                    elseif mode==13 then
                        call UnitRemoveBuffs(u,false,true)
                    endif
                endif
            endif
        endloop
        call DestroyGroup(g)
        if mode==6 then
            set summon='nwat'
            set i=3
        elseif mode==7 then
            set summon='osw1'
            set i=4
        elseif mode==10 then
            set summon='ucs1'
            set i=6
        elseif mode==11 then
            set summon='ninf'
            set i=1
        elseif mode==12 then
            call SetWidgetLife(caster,RMinBJ(GetUnitState(caster,UNIT_STATE_MAX_LIFE),GetWidgetLife(caster)+60*hits))
        endif
        loop
            exitwhen i<=0
            set u=CreateUnit(owner,summon,x+GetRandomReal(-90,90),y+GetRandomReal(-90,90),270)
            call UnitApplyTimedLife(u,'BTLF',40)
            call SetUnitUseFood(u,false)
            set i=i-1
        endloop
        if mode==9 then
            set DGW_Faith[p]=DGW_Faith[p]+IMinBJ(hits,15)
        endif
        set g=null
        set u=null
    endif
    set caster=null
    set owner=null
endfunction

function DGW_ShrineTick takes nothing returns nothing
    local integer s=0
    local integer found
    local integer p
    local integer i
    local boolean contested
    local group g=CreateGroup()
    local unit u
    loop
        exitwhen s>=5
        set found=-1
        set contested=false
        call GroupEnumUnitsInRange(g,DGW_ShrineX[s],DGW_ShrineY[s],420,null)
        loop
            set u=FirstOfGroup(g)
            exitwhen u==null
            call GroupRemoveUnit(g,u)
            set p=GetPlayerId(GetOwningPlayer(u))
            if p>=0 and p<12 and DGW_Alive[p] and DGW_Chosen[p] and GetWidgetLife(u)>0.405 and not IsUnitType(u,UNIT_TYPE_STRUCTURE) and not IsUnitType(u,UNIT_TYPE_PEON) then
                if found==-1 then
                    set found=p
                elseif found!=p then
                    set contested=true
                endif
            endif
        endloop
        if found>=0 and not contested then
            if DGW_CapturePlayer[s]!=found then
                set DGW_CapturePlayer[s]=found
                set DGW_CaptureTime[s]=2
            else
                set DGW_CaptureTime[s]=DGW_CaptureTime[s]+2
            endif
            if DGW_CaptureTime[s]>=10 and GetOwningPlayer(DGW_Shrine[s])!=Player(found) then
                call SetUnitOwner(DGW_Shrine[s],Player(found),true)
                call DGW_Message(found,"|cffffcc00Святилище захвачено: +25 золота, +5 дерева и +5 веры каждые 5 секунд.|r")
                call PingMinimapForPlayer(Player(found),DGW_ShrineX[s],DGW_ShrineY[s],3)
            endif
        else
            set DGW_CapturePlayer[s]=-1
            set DGW_CaptureTime[s]=0
        endif
        set s=s+1
    endloop
    call DestroyGroup(g)
    set g=null
    set u=null
endfunction

function DGW_Death takes nothing returns nothing
    local unit dead=GetTriggerUnit()
    local unit killer=GetKillingUnit()
    local integer p
    local integer amount=3
    if killer!=null and IsUnitEnemy(dead,GetOwningPlayer(killer)) then
        set p=GetPlayerId(GetOwningPlayer(killer))
        if p>=0 and p<12 and DGW_Alive[p] and DGW_Chosen[p] then
            if IsUnitType(dead,UNIT_TYPE_HERO) then
                set amount=20
            elseif IsUnitType(dead,UNIT_TYPE_STRUCTURE) then
                set amount=8
            elseif IsUnitType(dead,UNIT_TYPE_PEON) then
                set amount=1
            endif
            if DGW_Race[p]==8 then
                set amount=amount+2
            endif
            set DGW_Faith[p]=DGW_Faith[p]+amount
            if GetPlayerId(GetOwningPlayer(dead))==PLAYER_NEUTRAL_AGGRESSIVE then
                call SetPlayerState(Player(p),PLAYER_STATE_RESOURCE_GOLD,GetPlayerState(Player(p),PLAYER_STATE_RESOURCE_GOLD)+30)
            endif
        endif
    endif
    set dead=null
    set killer=null
endfunction

function DGW_Produced takes nothing returns nothing
    local unit u=GetTrainedUnit()
    local integer kind
    local integer p
    if u==null then
        set u=GetConstructedStructure()
    endif
    if u==null then
        set u=GetRevivingUnit()
    endif
    if u!=null then
        set p=GetPlayerId(GetOwningPlayer(u))
        set kind=LoadInteger(DGW_Data,GetUnitTypeId(u),1)
        if p>=0 and p<12 then
            if GetUnitTypeId(u)==DGW_Altar[DGW_Race[p]] then
                set DGW_AltarUnit[p]=u
            elseif GetUnitTypeId(u)==DGW_Barracks[DGW_Race[p]] then
                set DGW_BarracksUnit[p]=u
            endif
        endif
        call IssueImmediateOrder(u,"healon")
        call IssueImmediateOrder(u,"slowon")
    endif
    set u=null
endfunction

function DGW_Income takes nothing returns nothing
    local integer p=0
    local integer s=0
    local integer r
    local integer alive=0
    local integer gold
    local integer wood
    loop
        exitwhen p>=12
        set DGW_ShrineCount[p]=0
        set p=p+1
    endloop
    loop
        exitwhen s>=5
        set p=GetPlayerId(GetOwningPlayer(DGW_Shrine[s]))
        if p>=0 and p<12 and DGW_Alive[p] then
            set DGW_ShrineCount[p]=DGW_ShrineCount[p]+1
        endif
        set s=s+1
    endloop
    set p=0
    loop
        exitwhen p>=12
        if DGW_Alive[p] and DGW_Chosen[p] then
            if DGW_ScanCapital(p)==0 then
                set DGW_Alive[p]=false
                call CustomDefeatBJ(Player(p),"Все твои столицы уничтожены.")
            else
                set r=DGW_Race[p]
                set gold=35+15*DGW_Tier[p]+25*DGW_ShrineCount[p]
                set wood=10+10*DGW_Tier[p]+5*DGW_ShrineCount[p]
                if r==1 or r==10 then
                    set gold=gold+10
                endif
                if r==5 then
                    set wood=wood+8
                endif
                call SetPlayerState(Player(p),PLAYER_STATE_RESOURCE_GOLD,GetPlayerState(Player(p),PLAYER_STATE_RESOURCE_GOLD)+gold)
                call SetPlayerState(Player(p),PLAYER_STATE_RESOURCE_LUMBER,GetPlayerState(Player(p),PLAYER_STATE_RESOURCE_LUMBER)+wood)
                set DGW_Faith[p]=DGW_Faith[p]+2+5*DGW_ShrineCount[p]
                if DGW_Time>=1200 and DGW_ShrineCount[p]>=3 and DGW_God[p]!=null and GetWidgetLife(DGW_God[p])>0.405 then
                    set DGW_Hold[p]=DGW_Hold[p]+5
                    if DGW_Hold[p]==5 then
                        call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,12,GetPlayerName(Player(p))+" начал удержание трёх святилищ! До победы 120 секунд.")
                    endif
                    if DGW_Hold[p]>=120 and DGW_InitialPlayers>=2 then
                        call DGW_Win(p)
                        return
                    endif
                else
                    set DGW_Hold[p]=0
                endif
                call DGW_Cell(p+1,0,GetPlayerName(Player(p)))
                call DGW_Cell(p+1,1,I2S(DGW_Tier[p])+" / "+I2S(DGW_ShrineCount[p]))
                call DGW_Cell(p+1,2,I2S(GetPlayerState(Player(p),PLAYER_STATE_RESOURCE_GOLD)))
                call DGW_Cell(p+1,3,I2S(DGW_Faith[p]))
                call DGW_Cell(p+1,4,I2S(DGW_Hold[p])+" / 120")
            endif
        elseif DGW_Active[p] then
            call DGW_Cell(p+1,0,GetPlayerName(Player(p)))
            if DGW_Chosen[p] then
                call DGW_Cell(p+1,1,"Выбыл")
            else
                call DGW_Cell(p+1,1,"Выбирает")
            endif
        endif
        set p=p+1
    endloop
    call DGW_CheckVictory()
endfunction

function DGW_AI takes nothing returns nothing
    local integer p=0
    local integer r
    local integer target
    local integer i
    local integer role
    local integer tier
    local unit u
    local unit enemy
    local group g=CreateGroup()
    loop
        exitwhen p>=12
        if DGW_Alive[p] and DGW_Chosen[p] and GetPlayerController(Player(p))==MAP_CONTROL_COMPUTER then
            set r=DGW_Race[p]
            set tier=DGW_Tier[p]
            if tier<3 and DGW_Time>=DGW_AINextUpgrade[p] then
                if tier==1 then
                    if IssueImmediateOrderById(DGW_Main[p],DGW_HQ2[r]) then
                        set DGW_AINextUpgrade[p]=DGW_Time+65
                    endif
                else
                    if IssueImmediateOrderById(DGW_Main[p],DGW_HQ3[r]) then
                        set DGW_AINextUpgrade[p]=DGW_Time+85
                    endif
                endif
            endif
            if tier>=3 and not DGW_Ascended[p] then
                call DGW_TryAscend(p)
            endif
            set role=0
            if tier>=3 then
                set role=7
            elseif tier>=2 then
                set role=3
            endif
            if ModuloInteger(DGW_Time,70)==0 then
                set role=1
            endif
            call IssueImmediateOrderById(DGW_BarracksUnit[p],DGW_Army[r*8+role])
            set target=-1
            set enemy=null
            set i=0
            loop
                exitwhen i>=12
                if i!=p and DGW_Alive[i] and DGW_Chosen[i] and DGW_Main[i]!=null then
                    if enemy==null or (GetUnitX(DGW_Main[i])-DGW_StartX[p])*(GetUnitX(DGW_Main[i])-DGW_StartX[p])+(GetUnitY(DGW_Main[i])-DGW_StartY[p])*(GetUnitY(DGW_Main[i])-DGW_StartY[p])<(GetUnitX(enemy)-DGW_StartX[p])*(GetUnitX(enemy)-DGW_StartX[p])+(GetUnitY(enemy)-DGW_StartY[p])*(GetUnitY(enemy)-DGW_StartY[p]) then
                        set enemy=DGW_Main[i]
                        set target=i
                    endif
                endif
                set i=i+1
            endloop
            if enemy!=null then
                call GroupEnumUnitsOfPlayer(g,Player(p),null)
                loop
                    set u=FirstOfGroup(g)
                    exitwhen u==null
                    call GroupRemoveUnit(g,u)
                    if GetWidgetLife(u)>0.405 and not IsUnitType(u,UNIT_TYPE_PEON) and not IsUnitType(u,UNIT_TYPE_STRUCTURE) then
                        if GetUnitCurrentOrder(u)==0 then
                            call IssuePointOrder(u,"attack",GetUnitX(enemy),GetUnitY(enemy))
                        endif
                    endif
                endloop
                if DGW_God[p]!=null and GetWidgetLife(DGW_God[p])>0.405 then
                    call IssuePointOrder(DGW_God[p],"channel",GetUnitX(enemy),GetUnitY(enemy))
                endif
            endif
        endif
        set p=p+1
    endloop
    call DestroyGroup(g)
    set g=null
    set enemy=null
    set u=null
endfunction

function DGW_Chat takes nothing returns nothing
    local integer p=GetPlayerId(GetTriggerPlayer())
    local string s=GetEventPlayerChatString()
    local real zoom
    if p<0 or p>=12 then
        return
    endif
    if s=="-race" then
        call DGW_ShowMenu(p)
    elseif s=="-info" then
        call DGW_Message(p,DGW_RaceName[DGW_Race[p]]+" | Ступень: "+I2S(DGW_Tier[p])+" | Вера: "+I2S(DGW_Faith[p])+" | Святилища: "+I2S(DGW_ShrineCount[p]))
    elseif SubString(s,0,5)=="-cam " then
        set zoom=RMaxBJ(1200,RMinBJ(3200,S2R(SubString(s,5,StringLength(s)))))
        call SetCameraFieldForPlayer(Player(p),CAMERA_FIELD_TARGET_DISTANCE,zoom,0.3)
    elseif s=="-help" then
        call DGW_Message(p,"-race: открыть выбор до старта; -info: вера и развитие; -cam 2300: высота камеры. Полные правила: F9. Последняя столица уничтожена — поражение. III ступень и 150 веры открывают вознесение в алтаре (V).")
    endif
    set s=null
endfunction

function DGW_Leave takes nothing returns nothing
    local integer p=GetPlayerId(GetTriggerPlayer())
    if p>=0 and p<12 and DGW_Active[p] and DGW_Alive[p] then
        set DGW_Alive[p]=false
        if not DGW_Chosen[p] then
            set DGW_Pending=DGW_Pending-1
        endif
        call DGW_BeginMatch()
        call DGW_CheckVictory()
    endif
endfunction

function DGW_Tick takes nothing returns nothing
    local integer p=0
    if DGW_Ended then
        return
    endif
    set DGW_Time=DGW_Time+1
    if DGW_Time==2 then
        loop
            exitwhen p>=12
            if DGW_Active[p] and GetPlayerController(Player(p))==MAP_CONTROL_USER then
                call DGW_ShowMenu(p)
            endif
            set p=p+1
        endloop
    elseif DGW_Time==5 or DGW_Time==90 then
        loop
            exitwhen p>=12
            if DGW_Active[p] and DGW_Alive[p] and not DGW_Chosen[p] and (DGW_Time==90 or GetPlayerController(Player(p))==MAP_CONTROL_COMPUTER) then
                call DGW_ChooseRace(p,GetRandomInt(1,16))
            endif
            set p=p+1
        endloop
    endif
    if not DGW_Begun or DGW_Time==0 then
        return
    endif
    if ModuloInteger(DGW_Time,2)==0 then
        call DGW_ShrineTick()
    endif
    if ModuloInteger(DGW_Time,5)==0 then
        call DGW_Income()
    endif
    if ModuloInteger(DGW_Time,35)==0 then
        call DGW_AI()
    endif
endfunction

function InitTrig_DGW_Expansion takes nothing returns nothing
    local trigger clock=CreateTrigger()
    local trigger menu=CreateTrigger()
    local trigger spells=CreateTrigger()
    local trigger deaths=CreateTrigger()
    local trigger chat=CreateTrigger()
    local trigger leave=CreateTrigger()
    local trigger produced=CreateTrigger()
    local integer p=0
    local integer j
    local integer i=0
    local quest q
    local unit u
    call DGW_LoadData()
    set DGW_Board=CreateMultiboard()
    call MultiboardSetTitleText(DGW_Board,"Боги и Империи — FFA | Ступень/Святилища | Золото | Вера | Удержание")
    call MultiboardSetRowCount(DGW_Board,13)
    call MultiboardSetColumnCount(DGW_Board,5)
    call DGW_Cell(0,0,"Игрок")
    call DGW_Cell(0,1,"Ступ./Свят.")
    call DGW_Cell(0,2,"Золото")
    call DGW_Cell(0,3,"Вера")
    call DGW_Cell(0,4,"Удержание")
    loop
        exitwhen p>=12
        set DGW_Dialog[p]=DialogCreate()
        call TriggerRegisterDialogEvent(menu,DGW_Dialog[p])
        set DGW_Active[p]=GetPlayerSlotState(Player(p))==PLAYER_SLOT_STATE_PLAYING and (GetPlayerController(Player(p))==MAP_CONTROL_USER or GetPlayerController(Player(p))==MAP_CONTROL_COMPUTER)
        set DGW_Alive[p]=DGW_Active[p]
        if DGW_Active[p] then
            set DGW_InitialPlayers=DGW_InitialPlayers+1
            set DGW_Pending=DGW_Pending+1
            call TriggerRegisterPlayerChatEvent(chat,Player(p),"-",false)
            call TriggerRegisterPlayerEvent(leave,Player(p),EVENT_PLAYER_LEAVE)
            call SetPlayerState(Player(p),PLAYER_STATE_ALLIED_VICTORY,0)
        endif
        set j=0
        loop
            exitwhen j>=12
            if p!=j then
                call SetPlayerAllianceStateBJ(Player(p),Player(j),bj_ALLIANCE_UNALLIED)
                call SetPlayerAlliance(Player(p),Player(j),ALLIANCE_SHARED_VISION,false)
                call SetPlayerAlliance(Player(p),Player(j),ALLIANCE_SHARED_CONTROL,false)
            endif
            set j=j+1
        endloop
        set p=p+1
    endloop
    loop
        exitwhen i>=5
        set DGW_Shrine[i]=CreateUnit(Player(PLAYER_NEUTRAL_PASSIVE),'dS00',DGW_ShrineX[i],DGW_ShrineY[i],270)
        set DGW_CapturePlayer[i]=-1
        set u=CreateUnit(Player(PLAYER_NEUTRAL_AGGRESSIVE),'ogru',DGW_ShrineX[i]+220,DGW_ShrineY[i]+140,270)
        set u=CreateUnit(Player(PLAYER_NEUTRAL_AGGRESSIVE),'ogru',DGW_ShrineX[i]-220,DGW_ShrineY[i]+140,270)
        set u=CreateUnit(Player(PLAYER_NEUTRAL_AGGRESSIVE),'nftt',DGW_ShrineX[i],DGW_ShrineY[i]+270,270)
        set i=i+1
    endloop
    call TriggerRegisterTimerEvent(clock,1,true)
    call TriggerAddAction(clock,function DGW_Tick)
    call TriggerAddAction(menu,function DGW_MenuClick)
    call TriggerRegisterAnyUnitEventBJ(spells,EVENT_PLAYER_UNIT_SPELL_EFFECT)
    call TriggerAddAction(spells,function DGW_SpellCast)
    call TriggerRegisterAnyUnitEventBJ(deaths,EVENT_PLAYER_UNIT_DEATH)
    call TriggerAddAction(deaths,function DGW_Death)
    call TriggerAddAction(chat,function DGW_Chat)
    call TriggerAddAction(leave,function DGW_Leave)
    call TriggerRegisterAnyUnitEventBJ(produced,EVENT_PLAYER_UNIT_TRAIN_FINISH)
    call TriggerRegisterAnyUnitEventBJ(produced,EVENT_PLAYER_UNIT_CONSTRUCT_FINISH)
    call TriggerRegisterAnyUnitEventBJ(produced,EVENT_PLAYER_HERO_REVIVE_FINISH)
    call TriggerAddAction(produced,function DGW_Produced)
    set q=CreateQuest()
    call QuestSetTitle(q,"Боги и Империи: как играть")
    call QuestSetRequired(q,true)
    call QuestSetDiscovered(q,true)
    call QuestSetDescription(q,"Выбери одну из 16 рас в окне при старте. На выбор 90 секунд, затем выбирается случайная. Каждый развивается у себя: рабочие добывают золото, пассивный доход даёт также дерево. Строй войска, жилища, святилища и мастерские, исследуй оружие и броню. Столицу можно улучшить дважды. Потеря всех столиц означает поражение, последний живой игрок побеждает. У компьютеров есть простой базовый противник; опытный человек играет сильнее.")
    set q=CreateQuest()
    call QuestSetTitle(q,"Боги, вера и святилища")
    call QuestSetRequired(q,true)
    call QuestSetDiscovered(q,true)
    call QuestSetDescription(q,"За убийства, время и захваченные святилища ты получаешь веру. В центре карты и по четырём сторонам стоят 5 святилищ: держи рядом боевой отряд 10 секунд без врагов. Рабочие не захватывают точки. Цитадель III, 800 золота, 350 дерева и 150 веры позволяют призвать одного бога кнопкой V в алтаре. Его особая способность — на Z. Павших героев можно воскресить в алтаре. С 20-й минуты действует вторая победа: удерживай 3 святилища 120 секунд подряд с живым богом.")
    set q=CreateQuest()
    call QuestSetTitle(q,"Управление")
    call QuestSetRequired(q,false)
    call QuestSetDiscovered(q,true)
    call QuestSetDescription(q,"Кнопка F9 — правила. -race открывает выбор, пока раса ещё не выбрана. -info показывает твоё развитие и веру. -cam 2300 меняет высоту камеры (1200–3200). Боги возносятся в алтаре кнопкой V, их особая сила — на Z. Потеряв чемпиона или бога, выбери алтарь для воскрешения. Компьютерные игроки подходят для тренировки; для полноценной FFA пригласи друзей.")
    call MultiboardDisplay(DGW_Board,true)
    set q=null
    set u=null
    set clock=null
    set menu=null
    set spells=null
    set deaths=null
    set chat=null
    set leave=null
    set produced=null
endfunction
