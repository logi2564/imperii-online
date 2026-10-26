globals
boolean udg_Easy=false
integer udg_i=0
integer array udg_BCN
integer udg_Bag_space_num=0
integer udg_Bag_cur_num=0
integer udg_inv_numberpassiv=0
integer udg_inv_numberdouble=0
force udg_inv_playergroup=null
integer udg_inv_key=0
group udg_inv_group=null
boolean udg_inv_isdouble=false
boolean udg_inv_ispassiv=false
integer array udg_inv_itemcount
integer udg_MB_Row=0
force udg_Players=null
string array udg_Colours
integer udg_MaxBullets=0
integer array udg_Clips
integer array udg_Bullets
integer udg_PlayerNum=0
multiboard udg_Multiboard=null
integer udg_tempInteger=0
integer array udg_Leftover
real udg_MS_SpeedBase=0
real udg_MS_Speed=0
real udg_MS_Radius=0
real udg_MS_Duration=0
integer array udg_MS_AgiMultiplier
real array udg_MS_LifeMultiplier
integer array udg_MS_Damage
string udg_MS_StrikeSFX
string udg_MS_ArrowSFX
integer udg_MS_Levels=0
real udg_MS_CasterAngle=0
integer udg_MS_Agi=0
integer udg_MS_AHandle=0
group udg_MS_ArrowGroup=null
integer udg_MS_AHandle_2=0
integer udg_MS_AHandle_3=0
integer udg_MS_Handle=0
group array udg_MS_StrikeGroup
real udg_MS_Life=0
rect gg_rct_Sound01=null
rect gg_rct_S01=null
rect gg_rct________________004=null
rect gg_rct_Sound01_____________________u=null
rect gg_rct________________004_____________________u=null
rect gg_rct_S02=null
rect gg_rct________________008=null
rect gg_rct________________009=null
rect gg_rct________________008_____________________u=null
rect gg_rct________________001_____________________u=null
rect gg_rct________________011=null
rect gg_rct________________012=null
rect gg_rct________________014=null
rect gg_rct________________015=null
rect gg_rct________________016=null
rect gg_rct________________001=null
rect gg_rct________________001__________________________________________u=null
rect gg_rct________________013=null
rect gg_rct_SW=null
camerasetup gg_cam_Camera_001=null
camerasetup gg_cam_Camera_002=null
camerasetup gg_cam_Camera_003=null
sound gg_snd_sound0101=null
trigger gg_trg_____________________________________001_____________________u=null
trigger gg_trg_____________________________________001=null
trigger gg_trg_efe=null
trigger gg_trg_____________________________________002=null
trigger gg_trg_____________________________________002_____________________u=null
constant real MO_RADIUS=2500.00
constant real MO_PERIOD=1.00
constant real MO_MOVE_STEP=768.00
real MO_MIN_X
real MO_MIN_Y
real MO_MAX_X
real MO_MAX_Y
unit array MO_HERO
real array MO_OLD_X
real array MO_OLD_Y
boolean array MO_ACTIVE
boolean array MO_CHANGED
rect MO_RECT
group MO_GROUP
boolexpr MO_HERO_FILTER
constant real MO2_CELL_SIZE=512.00
constant real MO2_PERIOD=0.50
constant integer MO2_MAX_CELLS=8191
real MO2_MIN_X
real MO2_MIN_Y
real MO2_MAX_X
real MO2_MAX_Y
integer MO2_CELLS_X
integer MO2_CELLS_Y
integer array MO2_CELL_USERS
boolean array MO2_CELL_VISIBLE
integer array MO2_PLAYER_CX
integer array MO2_PLAYER_CY
boolean array MO2_PLAYER_ACTIVE
unit array MO2_HERO
group MO2_GROUP
filterfunc MO2_HERO_FILTER
rect MO2_RECT
boolean MO2_SHOW_MODE
constant integer VampireUnitType=0x75303030
constant integer VampireDayState=0x41303033
constant integer VampireDayDebuff=0x41303033
constant integer VampireDayDamage=0x41303042
constant integer VampireDayMoveSpeed=0x41303044
constant integer VampireDayAttackSpeed=0x41303046
constant integer VampireDayArmor=0x41303048
constant integer VampireNightState=0x41303034
constant integer VampireNightSkill=0x41303034
constant integer VampireNightDamage=0x41303041
constant integer VampireNightMoveSpeed=0x41303043
constant integer VampireNightAttackSpeed=0x41303045
constant integer VampireNightArmor=0x41303047
group VampireGroup=null
timer VampireTimer=null
rect VampireRect=null
boolean VampireIsDay=false
integer VampireCheckCount=0
constant integer BW_DRINK=0x4130304C
constant integer BW_BUFF_1=0x4130304D
constant integer BW_BUFF_2=0x4130304E
constant integer BW_BUFF_3=0x4130304F
constant real BW_MAX_MANA=300.00
constant real BW_HEAL_PER_BLOOD=1.00
constant real BW_RIGHTCLICK_MULTIPLIER=2.00
constant real BW_CAST_DELAY=0.10
constant real BW_RIGHTCLICK_MARK_TIME=0.25
hashtable BW_CastHash=InitHashtable()
hashtable BW_TimerHash=InitHashtable()
hashtable BW_RightClickHash=InitHashtable()
constant integer PLBC_ABILITY=0x41303051
constant real PLBC_IMPACT_DISTANCE=120.00
constant real PLBC_RADIUS=300.00
constant real PLBC_IMPACT_DELAY=0.25
constant real PLBC_SLOW_TIME=2.00
constant real PLBC_SLOW_FACTOR=0.75
constant string PLBC_FX_EXPLOSION="war3mapImported\\Blood Explosion.mdx"
constant string PLBC_FX_GROUND="war3mapImported\\Blood LakeRed.mdx"
hashtable PLBC_SlowHash=null
hashtable PLBC_FXHash=null
constant integer PLF_ABILITY=0x41303052
constant integer PLF_ATTACK_SPEED=0x41303053
constant integer PLF_HP_REGEN=0x41303055
constant real PLF_DURATION=15.00
constant real PLF_KILL_EXTEND=3.00
constant real PLF_CAST_FX_TIME=2.50
constant real PLF_KILL_FX_TIME=3.50
constant real PLF_END_FX_TIME=3.50
constant real PLF_PULSE_TIME=0.90
constant integer PLF_KEY_TIMER=1
constant integer PLF_KEY_WEAPON=2
constant integer PLF_KEY_OLD_ATTACK=3
constant integer PLF_KEY_OLD_REGEN=4
constant integer PLF_KEY_ACTIVE=5
constant integer PLF_KEY_HERO=0
constant integer PLF_KEY_TEMP_EFFECT=0
constant string PLF_FX_CAST="war3mapImported\\Blood Slam.mdx"
constant string PLF_FX_WEAPON="war3mapImported\\Blood Missile.mdx"
constant string PLF_FX_KILL="war3mapImported\\Death Nova.mdx"
constant string PLF_FX_END="war3mapImported\\Crack Shockwave.mdx"
constant string PLF_FX_PULSE="Abilities\\Spells\\Orc\\Bloodlust\\BloodlustTarget.mdl"
hashtable PLF_Hash=null
hashtable PLF_EffectHash=null
real PainLaser__Damage_Base=100.0
real PainLaser__Damage_Per_Level=10.0
integer PainLaser__Laser_Id=0x68303030
real PainLaser__LASER_RANGE=800.0
integer PainLaser__BURN_BUFF_ID=0x42303030
real PainLaser__BURN_DAMAGE=25.0
real PainLaser__BURN_DURATION=5.0
integer HellScale__SPELL_ID=0x41303036
integer HellScale__BUFF_ID=0x42303031
real HellScale__BURN_DAMAGE=25.0
real HellScale__BURN_DURATION=3.0
real HellScale__CHANCE_BASE=10.0
real HellScale__CHANCE_PER_LEVEL=1.0
real HellScale__BURN_COOLDOWN=2.0
hashtable HellScale__CooldownTable=InitHashtable()
timer HellScale__GameTimer=CreateTimer()
integer AshFlight__SPELL_ID=0x41303037
integer AshFlight__CANCEL_ID=0x41303039
integer AshFlight__STUN_BUFF=0x42505345
real AshFlight__BASE_FLIGHT_DURATION=5.00
real AshFlight__FLIGHT_TIME_PER_LEVEL=0.10
real AshFlight__START_SPEED=10.00
real AshFlight__BASE_MAX_SPEED=18.00
real AshFlight__SPEED_PER_LEVEL=0.25
real AshFlight__ACCELERATION=0.50
real AshFlight__FLIGHT_HEIGHT=380.00
real AshFlight__HP_THRESHOLD=0.25
real AshFlight__PERIOD=0.03
real AshFlight__UNIT_RADIUS=28.00
real AshFlight__MAP_MARGIN=4.00
boolean array AshFlight__Flying
boolean array AshFlight__Moving
boolean array AshFlight__Casting
real array AshFlight__TargetX
real array AshFlight__TargetY
real AshFlight__WorldMinX
real AshFlight__WorldMaxX
real AshFlight__WorldMinY
real AshFlight__WorldMaxY
timer AshFlight__FlightTimer=CreateTimer()
unit cj_v666_unit
integer si__PainLaser__BurnData_F=0
integer si__PainLaser__BurnData_I=0
integer array si__PainLaser__BurnData_V
unit array s__PainLaser__BurnData_target
unit array s__PainLaser__BurnData_caster
real array s__PainLaser__BurnData_duration
real array s__PainLaser__BurnData_nextTick
effect array s__PainLaser__BurnData_burnFX
timer s__PainLaser__BurnData_burnTimer=CreateTimer()
integer array s__PainLaser__BurnData_burnList
integer s__PainLaser__BurnData_burnCount=-1
integer si__PainLaser__Laser_F=0
integer si__PainLaser__Laser_I=0
integer array si__PainLaser__Laser_V
timer s__PainLaser__Laser_t=CreateTimer()
integer array s__PainLaser__Laser_Data
integer s__PainLaser__Laser_Count=-1
unit array s__PainLaser__Laser_caster
unit array s__PainLaser__Laser_missile
real array s__PainLaser__Laser_angle
real array s__PainLaser__Laser_distance
real array s__PainLaser__Laser_x
real array s__PainLaser__Laser_y
real array s__PainLaser__Laser_traveled
boolean array s__PainLaser__Laser_hit
real array s__PainLaser__Laser_damage
integer si__HellScale__BurnData_F=0
integer si__HellScale__BurnData_I=0
integer array si__HellScale__BurnData_V
unit array s__HellScale__BurnData_target
unit array s__HellScale__BurnData_caster
real array s__HellScale__BurnData_duration
real array s__HellScale__BurnData_nextTick
effect array s__HellScale__BurnData_burnFX
effect array s__HellScale__BurnData_tickFX
effect array s__HellScale__BurnData_sparkFX
timer s__HellScale__BurnData_burnTimer=CreateTimer()
integer array s__HellScale__BurnData_burnList
integer s__HellScale__BurnData_burnCount=-1
integer si__AshFlight__FlightData_F=0
integer si__AshFlight__FlightData_I=0
integer array si__AshFlight__FlightData_V
unit array s__AshFlight__FlightData_caster
real array s__AshFlight__FlightData_angle
real array s__AshFlight__FlightData_speed
real array s__AshFlight__FlightData_maxSpeed
real array s__AshFlight__FlightData_duration
real array s__AshFlight__FlightData_maxDuration
effect array s__AshFlight__FlightData_bodyFX
integer array s__AshFlight__FlightData_flightList
integer s__AshFlight__FlightData_flightCount=-1
endglobals
function s__PainLaser__BurnData__allocate takes nothing returns integer
local integer this=si__PainLaser__BurnData_F
if(this!=0)then
set si__PainLaser__BurnData_F=si__PainLaser__BurnData_V[this]
else
set si__PainLaser__BurnData_I=si__PainLaser__BurnData_I+1
set this=si__PainLaser__BurnData_I
endif
if(this>8190)then
call DisplayTimedTextToPlayer(GetLocalPlayer(),0,0,1000.,"Unable to allocate id for an object of type: PainLaser__BurnData")
return 0
endif
set si__PainLaser__BurnData_V[this]=-1
return this
endfunction
function s__PainLaser__BurnData_deallocate takes integer this returns nothing
if this==null then
call DisplayTimedTextToPlayer(GetLocalPlayer(),0,0,1000.,"Attempt to destroy a null struct of type: PainLaser__BurnData")
return
elseif(si__PainLaser__BurnData_V[this]!=-1)then
call DisplayTimedTextToPlayer(GetLocalPlayer(),0,0,1000.,"Double free of type: PainLaser__BurnData")
return
endif
set si__PainLaser__BurnData_V[this]=si__PainLaser__BurnData_F
set si__PainLaser__BurnData_F=this
endfunction
function s__AshFlight__FlightData__allocate takes nothing returns integer
local integer this=si__AshFlight__FlightData_F
if(this!=0)then
set si__AshFlight__FlightData_F=si__AshFlight__FlightData_V[this]
else
set si__AshFlight__FlightData_I=si__AshFlight__FlightData_I+1
set this=si__AshFlight__FlightData_I
endif
if(this>8190)then
call DisplayTimedTextToPlayer(GetLocalPlayer(),0,0,1000.,"Unable to allocate id for an object of type: AshFlight__FlightData")
return 0
endif
set si__AshFlight__FlightData_V[this]=-1
return this
endfunction
function s__AshFlight__FlightData_deallocate takes integer this returns nothing
if this==null then
call DisplayTimedTextToPlayer(GetLocalPlayer(),0,0,1000.,"Attempt to destroy a null struct of type: AshFlight__FlightData")
return
elseif(si__AshFlight__FlightData_V[this]!=-1)then
call DisplayTimedTextToPlayer(GetLocalPlayer(),0,0,1000.,"Double free of type: AshFlight__FlightData")
return
endif
set si__AshFlight__FlightData_V[this]=si__AshFlight__FlightData_F
set si__AshFlight__FlightData_F=this
endfunction
function s__HellScale__BurnData__allocate takes nothing returns integer
local integer this=si__HellScale__BurnData_F
if(this!=0)then
set si__HellScale__BurnData_F=si__HellScale__BurnData_V[this]
else
set si__HellScale__BurnData_I=si__HellScale__BurnData_I+1
set this=si__HellScale__BurnData_I
endif
if(this>8190)then
call DisplayTimedTextToPlayer(GetLocalPlayer(),0,0,1000.,"Unable to allocate id for an object of type: HellScale__BurnData")
return 0
endif
set si__HellScale__BurnData_V[this]=-1
return this
endfunction
function s__HellScale__BurnData_deallocate takes integer this returns nothing
if this==null then
call DisplayTimedTextToPlayer(GetLocalPlayer(),0,0,1000.,"Attempt to destroy a null struct of type: HellScale__BurnData")
return
elseif(si__HellScale__BurnData_V[this]!=-1)then
call DisplayTimedTextToPlayer(GetLocalPlayer(),0,0,1000.,"Double free of type: HellScale__BurnData")
return
endif
set si__HellScale__BurnData_V[this]=si__HellScale__BurnData_F
set si__HellScale__BurnData_F=this
endfunction
function s__PainLaser__Laser__allocate takes nothing returns integer
local integer this=si__PainLaser__Laser_F
if(this!=0)then
set si__PainLaser__Laser_F=si__PainLaser__Laser_V[this]
else
set si__PainLaser__Laser_I=si__PainLaser__Laser_I+1
set this=si__PainLaser__Laser_I
endif
if(this>8190)then
call DisplayTimedTextToPlayer(GetLocalPlayer(),0,0,1000.,"Unable to allocate id for an object of type: PainLaser__Laser")
return 0
endif
set si__PainLaser__Laser_V[this]=-1
return this
endfunction
function s__PainLaser__Laser_deallocate takes integer this returns nothing
if this==null then
call DisplayTimedTextToPlayer(GetLocalPlayer(),0,0,1000.,"Attempt to destroy a null struct of type: PainLaser__Laser")
return
elseif(si__PainLaser__Laser_V[this]!=-1)then
call DisplayTimedTextToPlayer(GetLocalPlayer(),0,0,1000.,"Double free of type: PainLaser__Laser")
return
endif
set si__PainLaser__Laser_V[this]=si__PainLaser__Laser_F
set si__PainLaser__Laser_F=this
endfunction
function InitGlobals takes nothing returns nothing
local integer i=0
set udg_Easy=false
set udg_i=0
set i=0
loop
exitwhen(i>1)
set udg_BCN[i]=0
set i=i+1
endloop
set udg_Bag_space_num=0
set udg_Bag_cur_num=0
set udg_inv_numberpassiv=0
set udg_inv_numberdouble=0
set udg_inv_playergroup=CreateForce()
set udg_inv_key=0
set udg_inv_group=CreateGroup()
set udg_inv_isdouble=false
set udg_inv_ispassiv=false
set i=0
loop
exitwhen(i>1)
set udg_inv_itemcount[i]=0
set i=i+1
endloop
set udg_MB_Row=0
set udg_Players=CreateForce()
set i=0
loop
exitwhen(i>1)
set udg_Colours[i]=""
set i=i+1
endloop
set udg_MaxBullets=0
set i=0
loop
exitwhen(i>1)
set udg_Clips[i]=0
set i=i+1
endloop
set i=0
loop
exitwhen(i>1)
set udg_Bullets[i]=0
set i=i+1
endloop
set udg_PlayerNum=0
set udg_Multiboard=CreateMultiboard()
set udg_tempInteger=0
set i=0
loop
exitwhen(i>1)
set udg_Leftover[i]=0
set i=i+1
endloop
set udg_MS_SpeedBase=0
set udg_MS_Speed=0
set udg_MS_Radius=0
set udg_MS_Duration=0
set i=0
loop
exitwhen(i>1)
set udg_MS_AgiMultiplier[i]=0
set i=i+1
endloop
set i=0
loop
exitwhen(i>1)
set udg_MS_LifeMultiplier[i]=0
set i=i+1
endloop
set i=0
loop
exitwhen(i>1)
set udg_MS_Damage[i]=0
set i=i+1
endloop
set udg_MS_StrikeSFX=""
set udg_MS_ArrowSFX=""
set udg_MS_Levels=0
set udg_MS_CasterAngle=0
set udg_MS_Agi=0
set udg_MS_AHandle=0
set udg_MS_ArrowGroup=CreateGroup()
set udg_MS_AHandle_2=0
set udg_MS_AHandle_3=0
set udg_MS_Handle=0
set i=0
loop
exitwhen(i>1)
set udg_MS_StrikeGroup[i]=CreateGroup()
set i=i+1
endloop
set udg_MS_Life=0
endfunction
function InitSounds takes nothing returns nothing
set gg_snd_sound0101=CreateSound("war3mapImported\\sound01.mp3",true,false,false,10,10,"DefaultEAXON")
call SetSoundDuration(gg_snd_sound0101,90854)
call SetSoundChannel(gg_snd_sound0101,0)
call SetSoundVolume(gg_snd_sound0101,127)
call SetSoundPitch(gg_snd_sound0101,1.0)
endfunction
function CreateBuildingsForPlayer0 takes nothing returns nothing
local player p=Player(0)
local unit u
local integer unitID
local trigger t
local real life
set u=CreateUnit(p,0x756E706C,-3968.0,6336.0,270.000)
set u=CreateUnit(p,0x68303038,-4864.0,6912.0,270.000)
set u=CreateUnit(p,0x68303039,-4224.0,7040.0,270.000)
set u=CreateUnit(p,0x68303041,-4672.0,7552.0,270.000)
set u=CreateUnit(p,0x65303030,-4448.0,6432.0,270.000)
set u=CreateUnit(p,0x65303030,-4832.0,6112.0,270.000)
set u=CreateUnit(p,0x65303030,-4640.0,5600.0,270.000)
set u=CreateUnit(p,0x68303043,-3456.0,6464.0,270.000)
set u=CreateUnit(p,0x75303032,-2976.0,6752.0,270.000)
set u=null
endfunction
function CreateUnitsForPlayer0 takes nothing returns nothing
local player p=Player(0)
local unit u
local integer unitID
local trigger t
local real life
set u=CreateUnit(p,0x48626C6D,13355.0,-16415.0,108.438)
set u=CreateUnit(p,0x48303035,13735.0,-16953.5,308.714)
set u=CreateUnit(p,0x48626C6D,13644.3,-17420.8,236.730)
set u=CreateUnit(p,0x48626C6D,12988.5,-16260.3,108.440)
call SetHeroLevel(u,30,false)
set u=CreateUnit(p,0x55646561,-4545.5,6095.6,355.473)
set u=CreateUnit(p,0x7562616E,-4273.9,6291.3,223.040)
set u=CreateUnit(p,0x68666F6F,-4074.5,5778.2,166.459)
set u=CreateUnit(p,0x75303030,-4087.0,6049.2,319.064)
set u=CreateUnit(p,0x75303030,-4394.2,5875.0,117.480)
set u=CreateUnit(p,0x75303030,-4144.3,5318.0,193.343)
set u=CreateUnit(p,0x75303030,-3800.9,5264.7,279.918)
set u=CreateUnit(p,0x75303030,-3539.1,6107.2,180.950)
set u=CreateUnit(p,0x75303030,-3967.0,5922.9,158.944)
set u=CreateUnit(p,0x55303033,-3783.9,6010.5,300.910)
call SetHeroLevel(u,25,false)
set u=null
endfunction
function CreateUnitsForPlayer5 takes nothing returns nothing
local player p=Player(5)
local unit u
local integer unitID
local trigger t
local real life
set u=CreateUnit(p,0x68666F6F,-3295.0,3502.1,305.166)
set u=CreateUnit(p,0x68666F6F,-2934.9,3672.9,117.030)
set u=CreateUnit(p,0x68666F6F,-3025.9,3393.5,312.735)
set u=CreateUnit(p,0x68666F6F,-2764.4,3695.0,31.147)
set u=CreateUnit(p,0x68666F6F,-3167.0,3781.2,208.889)
set u=CreateUnit(p,0x68666F6F,-3516.1,3582.7,253.056)
set u=CreateUnit(p,0x68666F6F,-3600.0,3949.3,129.763)
set u=CreateUnit(p,0x68666F6F,-3179.6,4022.5,63.162)
set u=CreateUnit(p,0x68666F6F,-2895.9,4248.4,207.967)
set u=CreateUnit(p,0x68666F6F,-3196.7,4324.3,134.147)
set u=CreateUnit(p,0x68666F6F,-3547.9,4030.7,238.960)
set u=CreateUnit(p,0x68666F6F,-3603.6,3324.5,259.527)
set u=CreateUnit(p,0x68666F6F,-3441.5,4342.4,211.713)
set u=CreateUnit(p,0x68666F6F,-3948.2,3933.2,184.389)
set u=CreateUnit(p,0x68666F6F,-3686.6,3450.7,69.941)
set u=CreateUnit(p,0x68666F6F,-3787.0,3917.3,256.440)
set u=CreateUnit(p,0x68666F6F,-3772.0,4191.4,23.039)
set u=CreateUnit(p,0x68666F6F,-4118.0,3540.3,113.152)
set u=CreateUnit(p,0x68666F6F,-3925.3,3519.4,341.334)
set u=CreateUnit(p,0x68666F6F,-4112.9,3834.9,214.262)
set u=CreateUnit(p,0x4870616C,-3793.8,4315.3,299.660)
call SetHeroLevel(u,25,false)
set u=CreateUnit(p,0x686B6E69,-2221.6,5125.4,79.148)
set u=CreateUnit(p,0x686B6E69,-1959.7,5549.4,350.090)
set u=CreateUnit(p,0x686B6E69,-1704.5,5933.3,132.730)
set u=CreateUnit(p,0x686B6E69,-1779.1,4977.6,79.148)
set u=CreateUnit(p,0x686B6E69,-1517.2,5401.6,350.090)
set u=CreateUnit(p,0x686B6E69,-1262.1,5785.5,132.730)
set u=CreateUnit(p,0x686B6E69,-1973.1,5103.7,79.148)
set u=CreateUnit(p,0x686B6E69,-1711.2,5527.7,350.090)
set u=CreateUnit(p,0x686B6E69,-1456.1,5911.6,132.730)
set u=CreateUnit(p,0x686B6E69,-2344.8,5281.4,79.148)
set u=CreateUnit(p,0x686B6E69,-2082.9,5705.4,350.090)
set u=CreateUnit(p,0x686B6E69,-1827.8,6089.3,132.730)
set u=CreateUnit(p,0x686B6E69,-2512.8,5381.1,79.148)
set u=CreateUnit(p,0x686B6E69,-2250.9,5805.2,350.090)
set u=CreateUnit(p,0x686B6E69,-1995.7,6189.0,132.730)
set u=CreateUnit(p,0x686B6E69,-1649.2,4884.2,79.148)
set u=CreateUnit(p,0x686B6E69,-1387.3,5308.2,350.090)
set u=CreateUnit(p,0x686B6E69,-1132.2,5692.1,132.730)
set u=null
endfunction
function CreateNeutralPassiveBuildings takes nothing returns nothing
local player p=Player(PLAYER_NEUTRAL_PASSIVE)
local unit u
local integer unitID
local trigger t
local real life
set u=CreateUnit(p,0x6E676F6C,-3392.0,5824.0,270.000)
call SetResourceAmount(u,12500)
set u=null
endfunction
function CreatePlayerBuildings takes nothing returns nothing
call CreateBuildingsForPlayer0()
endfunction
function CreatePlayerUnits takes nothing returns nothing
call CreateUnitsForPlayer0()
call CreateUnitsForPlayer5()
endfunction
function CreateAllUnits takes nothing returns nothing
call CreateNeutralPassiveBuildings()
call CreatePlayerBuildings()
call CreatePlayerUnits()
endfunction
function CreateRegions takes nothing returns nothing
local weathereffect we
set gg_rct_Sound01=Rect(-17760.0,-17248.0,-15360.0,-15168.0)
call SetSoundPosition(gg_snd_sound0101,-16560.0,-16208.0,9.0)
call RegisterStackedSound(gg_snd_sound0101,true,2400.0,2080.0)
set gg_rct_S01=Rect(-6752.0,-800.0,-6208.0,-416.0)
set gg_rct________________004=Rect(-17920.0,-17920.0,-15552.0,-15840.0)
set we=AddWeatherEffect(gg_rct________________004,0x4C526D61)
call EnableWeatherEffect(we,true)
set gg_rct_Sound01_____________________u=Rect(-17440.0,-14208.0,-15040.0,-12128.0)
call SetSoundPosition(gg_snd_sound0101,-16240.0,-13168.0,0.0)
call RegisterStackedSound(gg_snd_sound0101,true,2400.0,2080.0)
set gg_rct________________004_____________________u=Rect(-17472.0,-14208.0,-15104.0,-12128.0)
set we=AddWeatherEffect(gg_rct________________004_____________________u,0x4C526D61)
call EnableWeatherEffect(we,true)
set gg_rct_S02=Rect(4160.0,-832.0,4704.0,-448.0)
set gg_rct________________008=Rect(-7488.0,-1568.0,-3584.0,448.0)
set we=AddWeatherEffect(gg_rct________________008,0x4C526D61)
call EnableWeatherEffect(we,true)
set gg_rct________________009=Rect(-3616.0,-3168.0,1536.0,1760.0)
set gg_rct________________008_____________________u=Rect(1536.0,-1600.0,5440.0,416.0)
set we=AddWeatherEffect(gg_rct________________008_____________________u,0x4C526D61)
call EnableWeatherEffect(we,true)
set gg_rct________________001_____________________u=Rect(10048.0,-17952.0,17472.0,-13536.0)
set we=AddWeatherEffect(gg_rct________________001_____________________u,0x46447268)
call EnableWeatherEffect(we,true)
set gg_rct________________011=Rect(-17632.0,14368.0,-14080.0,17504.0)
set we=AddWeatherEffect(gg_rct________________011,0x46447268)
call EnableWeatherEffect(we,true)
set gg_rct________________012=Rect(-17024.0,16640.0,-16640.0,16928.0)
set gg_rct________________014=Rect(16736.0,-15488.0,17120.0,-15040.0)
set gg_rct________________015=Rect(16192.0,-15360.0,16384.0,-15168.0)
set gg_rct________________016=Rect(10048.0,-18112.0,17472.0,-13504.0)
set gg_rct________________001=Rect(10048.0,-18080.0,17472.0,-13504.0)
set we=AddWeatherEffect(gg_rct________________001,0x46447268)
call EnableWeatherEffect(we,true)
set gg_rct________________001__________________________________________u=Rect(10016.0,-18080.0,17664.0,-13664.0)
set we=AddWeatherEffect(gg_rct________________001__________________________________________u,0x574F6377)
call EnableWeatherEffect(we,true)
set gg_rct________________013=Rect(-16416.0,16224.0,-16288.0,16384.0)
set gg_rct_SW=Rect(-17920.0,-10304.0,17664.0,17728.0)
set we=null
endfunction
function CreateCameras takes nothing returns nothing
set gg_cam_Camera_001=CreateCameraSetup()
call CameraSetupSetField(gg_cam_Camera_001,CAMERA_FIELD_ZOFFSET,0.0,0.0)
call CameraSetupSetField(gg_cam_Camera_001,CAMERA_FIELD_ROTATION,90.0,0.0)
call CameraSetupSetField(gg_cam_Camera_001,CAMERA_FIELD_ANGLE_OF_ATTACK,304.0,0.0)
call CameraSetupSetField(gg_cam_Camera_001,CAMERA_FIELD_TARGET_DISTANCE,3536.9,0.0)
call CameraSetupSetField(gg_cam_Camera_001,CAMERA_FIELD_ROLL,0.0,0.0)
call CameraSetupSetField(gg_cam_Camera_001,CAMERA_FIELD_FIELD_OF_VIEW,70.0,0.0)
call CameraSetupSetField(gg_cam_Camera_001,CAMERA_FIELD_FARZ,5000.0,0.0)
call CameraSetupSetDestPosition(gg_cam_Camera_001,-16477.6,-17109.6,0.0)
set gg_cam_Camera_002=CreateCameraSetup()
call CameraSetupSetField(gg_cam_Camera_002,CAMERA_FIELD_ZOFFSET,0.0,0.0)
call CameraSetupSetField(gg_cam_Camera_002,CAMERA_FIELD_ROTATION,90.0,0.0)
call CameraSetupSetField(gg_cam_Camera_002,CAMERA_FIELD_ANGLE_OF_ATTACK,304.0,0.0)
call CameraSetupSetField(gg_cam_Camera_002,CAMERA_FIELD_TARGET_DISTANCE,3536.9,0.0)
call CameraSetupSetField(gg_cam_Camera_002,CAMERA_FIELD_ROLL,0.0,0.0)
call CameraSetupSetField(gg_cam_Camera_002,CAMERA_FIELD_FIELD_OF_VIEW,70.0,0.0)
call CameraSetupSetField(gg_cam_Camera_002,CAMERA_FIELD_FARZ,5000.0,0.0)
call CameraSetupSetDestPosition(gg_cam_Camera_002,-6224.8,-529.8,0.0)
set gg_cam_Camera_003=CreateCameraSetup()
call CameraSetupSetField(gg_cam_Camera_003,CAMERA_FIELD_ZOFFSET,0.0,0.0)
call CameraSetupSetField(gg_cam_Camera_003,CAMERA_FIELD_ROTATION,90.0,0.0)
call CameraSetupSetField(gg_cam_Camera_003,CAMERA_FIELD_ANGLE_OF_ATTACK,304.0,0.0)
call CameraSetupSetField(gg_cam_Camera_003,CAMERA_FIELD_TARGET_DISTANCE,3536.9,0.0)
call CameraSetupSetField(gg_cam_Camera_003,CAMERA_FIELD_ROLL,0.0,0.0)
call CameraSetupSetField(gg_cam_Camera_003,CAMERA_FIELD_FIELD_OF_VIEW,70.0,0.0)
call CameraSetupSetField(gg_cam_Camera_003,CAMERA_FIELD_FARZ,5000.0,0.0)
call CameraSetupSetDestPosition(gg_cam_Camera_003,4591.0,-668.0,0.0)
endfunction
function Trig_____________________________________001_____________________u_Actions takes nothing returns nothing
call SetCameraFieldForPlayer(GetTriggerPlayer(),CAMERA_FIELD_TARGET_DISTANCE,3000.00,1.00)
endfunction
function InitTrig_____________________________________001_____________________u takes nothing returns nothing
set gg_trg_____________________________________001_____________________u=CreateTrigger()
call TriggerRegisterPlayerEventEndCinematic(gg_trg_____________________________________001_____________________u,Player(0))
call TriggerRegisterPlayerEventEndCinematic(gg_trg_____________________________________001_____________________u,Player(1))
call TriggerRegisterPlayerEventEndCinematic(gg_trg_____________________________________001_____________________u,Player(2))
call TriggerRegisterPlayerEventEndCinematic(gg_trg_____________________________________001_____________________u,Player(3))
call TriggerRegisterPlayerEventEndCinematic(gg_trg_____________________________________001_____________________u,Player(4))
call TriggerRegisterPlayerEventEndCinematic(gg_trg_____________________________________001_____________________u,Player(5))
call TriggerRegisterPlayerEventEndCinematic(gg_trg_____________________________________001_____________________u,Player(6))
call TriggerRegisterPlayerEventEndCinematic(gg_trg_____________________________________001_____________________u,Player(7))
call TriggerRegisterPlayerEventEndCinematic(gg_trg_____________________________________001_____________________u,Player(8))
call TriggerRegisterPlayerEventEndCinematic(gg_trg_____________________________________001_____________________u,Player(9))
call TriggerAddAction(gg_trg_____________________________________001_____________________u,function Trig_____________________________________001_____________________u_Actions)
endfunction
function Trig_____________________________________001_Actions takes nothing returns nothing
call CreateFogModifierRectBJ(true,Player(0),FOG_OF_WAR_VISIBLE,gg_rct________________001__________________________________________u)
call CreateFogModifierRectBJ(true,Player(0),FOG_OF_WAR_VISIBLE,gg_rct________________011)
endfunction
function InitTrig_____________________________________001 takes nothing returns nothing
set gg_trg_____________________________________001=CreateTrigger()
call TriggerAddAction(gg_trg_____________________________________001,function Trig_____________________________________001_Actions)
endfunction
function MO_HeroFilter takes nothing returns boolean
local unit u=GetFilterUnit()
if IsUnitType(u,UNIT_TYPE_HERO)then
if GetWidgetLife(u)>0.405 then
set u=null
set u=null
return true
endif
endif
set u=null
return false
endfunction
function MO_FindHero takes integer pid returns unit
local unit u
call GroupClear(MO_GROUP)
call GroupEnumUnitsOfPlayer(MO_GROUP,Player(pid),MO_HERO_FILTER)
set u=FirstOfGroup(MO_GROUP)
call GroupClear(MO_GROUP)
set cj_v666_unit=u
set u=null
return cj_v666_unit
endfunction
function MO_SetArea takes real x,real y returns nothing
local real minx=x-MO_RADIUS
local real miny=y-MO_RADIUS
local real maxx=x+MO_RADIUS
local real maxy=y+MO_RADIUS
if minx<MO_MIN_X then
set minx=MO_MIN_X
endif
if miny<MO_MIN_Y then
set miny=MO_MIN_Y
endif
if maxx>MO_MAX_X then
set maxx=MO_MAX_X
endif
if maxy>MO_MAX_Y then
set maxy=MO_MAX_Y
endif
call SetRect(MO_RECT,minx,miny,maxx,maxy)
endfunction
function MO_ShowDestructable takes nothing returns nothing
call ShowDestructable(GetEnumDestructable(),true)
endfunction
function MO_ShowArea takes real x,real y returns nothing
call MO_SetArea(x,y)
call EnumDestructablesInRectAll(MO_RECT,function MO_ShowDestructable)
endfunction
function MO_HideDestructable takes nothing returns nothing
call ShowDestructable(GetEnumDestructable(),false)
endfunction
function MO_HideArea takes real x,real y returns nothing
call MO_SetArea(x,y)
call EnumDestructablesInRectAll(MO_RECT,function MO_HideDestructable)
endfunction
function MO_Update takes nothing returns nothing
local integer i=0
local unit u
local real x
local real y
local real dx
local real dy
local real step2=MO_MOVE_STEP*MO_MOVE_STEP
local boolean anyChanged=false
loop
exitwhen i>=bj_MAX_PLAYERS
set MO_CHANGED[i]=false
if GetPlayerSlotState(Player(i))==PLAYER_SLOT_STATE_PLAYING then
set u=MO_HERO[i]
if u==null or GetWidgetLife(u)<=0.405 then
set u=MO_FindHero(i)
if u!=MO_HERO[i]then
set MO_CHANGED[i]=true
endif
set MO_HERO[i]=u
endif
if u!=null then
set x=GetUnitX(u)
set y=GetUnitY(u)
if not MO_ACTIVE[i]then
set MO_CHANGED[i]=true
else
set dx=x-MO_OLD_X[i]
set dy=y-MO_OLD_Y[i]
if dx*dx+dy*dy>=step2 then
set MO_CHANGED[i]=true
endif
endif
elseif MO_ACTIVE[i]then
set MO_CHANGED[i]=true
endif
elseif MO_ACTIVE[i]then
set MO_CHANGED[i]=true
endif
if MO_CHANGED[i]then
set anyChanged=true
endif
set i=i+1
endloop
if anyChanged then
set i=0
loop
exitwhen i>=bj_MAX_PLAYERS
if MO_CHANGED[i]then
if MO_ACTIVE[i]then
call MO_HideArea(MO_OLD_X[i],MO_OLD_Y[i])
endif
endif
set i=i+1
endloop
set i=0
loop
exitwhen i>=bj_MAX_PLAYERS
if MO_CHANGED[i]then
set u=MO_HERO[i]
if u!=null and GetWidgetLife(u)>0.405 then
set MO_OLD_X[i]=GetUnitX(u)
set MO_OLD_Y[i]=GetUnitY(u)
set MO_ACTIVE[i]=true
else
set MO_ACTIVE[i]=false
set MO_HERO[i]=null
endif
endif
set i=i+1
endloop
set i=0
loop
exitwhen i>=bj_MAX_PLAYERS
if MO_ACTIVE[i]then
call MO_ShowArea(MO_OLD_X[i],MO_OLD_Y[i])
endif
set i=i+1
endloop
endif
set u=null
endfunction
function MO_Init takes nothing returns nothing
local rect r=GetPlayableMapRect()
local trigger t
set MO_MIN_X=GetRectMinX(r)
set MO_MIN_Y=GetRectMinY(r)
set MO_MAX_X=GetRectMaxX(r)
set MO_MAX_Y=GetRectMaxY(r)
set MO_RECT=Rect(0.00,0.00,0.00,0.00)
set MO_GROUP=CreateGroup()
set MO_HERO_FILTER=Filter(function MO_HeroFilter)
call SetRect(MO_RECT,MO_MIN_X,MO_MIN_Y,MO_MAX_X,MO_MAX_Y)
call EnumDestructablesInRectAll(MO_RECT,function MO_HideDestructable)
set t=CreateTrigger()
call TriggerRegisterTimerEvent(t,MO_PERIOD,true)
call TriggerAddAction(t,function MO_Update)
set t=null
set r=null
endfunction
function InitTrig_MapOptimizer takes nothing returns nothing
call MO_Init()
endfunction
function MO2_HeroFilter takes nothing returns boolean
local unit u=GetFilterUnit()
if IsUnitType(u,UNIT_TYPE_HERO)then
if GetWidgetLife(u)>0.405 then
set u=null
set u=null
return true
endif
endif
set u=null
return false
endfunction
function MO2_FindHero takes integer pid returns unit
local unit u
call GroupClear(MO2_GROUP)
call GroupEnumUnitsOfPlayer(MO2_GROUP,Player(pid),MO2_HERO_FILTER)
set u=FirstOfGroup(MO2_GROUP)
call GroupClear(MO2_GROUP)
set cj_v666_unit=u
set u=null
return cj_v666_unit
endfunction
function MO2_GetCellX takes real x returns integer
local integer i=R2I((x-MO2_MIN_X)/MO2_CELL_SIZE)
if i<0 then
set i=0
endif
if i>=MO2_CELLS_X then
set i=MO2_CELLS_X-1
endif
return i
endfunction
function MO2_GetCellY takes real y returns integer
local integer i=R2I((y-MO2_MIN_Y)/MO2_CELL_SIZE)
if i<0 then
set i=0
endif
if i>=MO2_CELLS_Y then
set i=MO2_CELLS_Y-1
endif
return i
endfunction
function MO2_CellID takes integer cx,integer cy returns integer
return cx+cy*MO2_CELLS_X
endfunction
function MO2_DestructableVisibility takes nothing returns nothing
call ShowDestructable(GetEnumDestructable(),MO2_SHOW_MODE)
endfunction
function MO2_SetCellVisible takes integer cx,integer cy,boolean flag returns nothing
local integer id
local real minx
local real miny
local real maxx
local real maxy
if cx<0 or cy<0 then
return
endif
if cx>=MO2_CELLS_X or cy>=MO2_CELLS_Y then
return
endif
set id=MO2_CellID(cx,cy)
if id<0 or id>=MO2_MAX_CELLS then
return
endif
if MO2_CELL_VISIBLE[id]==flag then
return
endif
set MO2_CELL_VISIBLE[id]=flag
set MO2_SHOW_MODE=flag
set minx=MO2_MIN_X+cx*MO2_CELL_SIZE
set miny=MO2_MIN_Y+cy*MO2_CELL_SIZE
set maxx=MO2_MIN_X+(cx+1)*MO2_CELL_SIZE
set maxy=MO2_MIN_Y+(cy+1)*MO2_CELL_SIZE
call SetRect(MO2_RECT,minx,miny,maxx,maxy)
call EnumDestructablesInRectAll(MO2_RECT,function MO2_DestructableVisibility)
endfunction
function MO2_AddCell takes integer cx,integer cy returns nothing
local integer id
if cx<0 or cy<0 then
return
endif
if cx>=MO2_CELLS_X or cy>=MO2_CELLS_Y then
return
endif
set id=MO2_CellID(cx,cy)
if id<0 or id>=MO2_MAX_CELLS then
return
endif
set MO2_CELL_USERS[id]=MO2_CELL_USERS[id]+1
if MO2_CELL_USERS[id]==1 then
call MO2_SetCellVisible(cx,cy,true)
endif
endfunction
function MO2_RemoveCell takes integer cx,integer cy returns nothing
local integer id
if cx<0 or cy<0 then
return
endif
if cx>=MO2_CELLS_X or cy>=MO2_CELLS_Y then
return
endif
set id=MO2_CellID(cx,cy)
if id<0 or id>=MO2_MAX_CELLS then
return
endif
if MO2_CELL_USERS[id]>0 then
set MO2_CELL_USERS[id]=MO2_CELL_USERS[id]-1
if MO2_CELL_USERS[id]==0 then
call MO2_SetCellVisible(cx,cy,false)
endif
endif
endfunction
function MO2_InArea takes integer cx,integer cy,integer px,integer py returns boolean
return cx>=px-5 and cx<=px+5 and cy>=py-5 and cy<=py+5
endfunction
function MO2_MovePlayer takes integer pid,integer nx,integer ny returns nothing
local integer ox=MO2_PLAYER_CX[pid]
local integer oy=MO2_PLAYER_CY[pid]
local integer x
local integer y
if not MO2_PLAYER_ACTIVE[pid]then
set x=nx-5
loop
exitwhen x>nx+5
set y=ny-5
loop
exitwhen y>ny+5
call MO2_AddCell(x,y)
set y=y+1
endloop
set x=x+1
endloop
set MO2_PLAYER_CX[pid]=nx
set MO2_PLAYER_CY[pid]=ny
set MO2_PLAYER_ACTIVE[pid]=true
return
endif
if ox==nx and oy==ny then
return
endif
set x=ox-5
loop
exitwhen x>ox+5
set y=oy-5
loop
exitwhen y>oy+5
if not MO2_InArea(x,y,nx,ny)then
call MO2_RemoveCell(x,y)
endif
set y=y+1
endloop
set x=x+1
endloop
set x=nx-5
loop
exitwhen x>nx+5
set y=ny-5
loop
exitwhen y>ny+5
if not MO2_InArea(x,y,ox,oy)then
call MO2_AddCell(x,y)
endif
set y=y+1
endloop
set x=x+1
endloop
set MO2_PLAYER_CX[pid]=nx
set MO2_PLAYER_CY[pid]=ny
endfunction
function MO2_RemovePlayerArea takes integer pid returns nothing
local integer x
local integer y
local integer cx=MO2_PLAYER_CX[pid]
local integer cy=MO2_PLAYER_CY[pid]
if not MO2_PLAYER_ACTIVE[pid]then
return
endif
set x=cx-5
loop
exitwhen x>cx+5
set y=cy-5
loop
exitwhen y>cy+5
call MO2_RemoveCell(x,y)
set y=y+1
endloop
set x=x+1
endloop
set MO2_PLAYER_ACTIVE[pid]=false
set MO2_HERO[pid]=null
endfunction
function MO2_Update takes nothing returns nothing
local integer i=0
local unit u
local integer cx
local integer cy
loop
exitwhen i>=bj_MAX_PLAYER_SLOTS
if GetPlayerSlotState(Player(i))==PLAYER_SLOT_STATE_PLAYING then
set u=MO2_HERO[i]
if u==null or GetWidgetLife(u)<=0.405 then
set u=MO2_FindHero(i)
set MO2_HERO[i]=u
if u==null then
call MO2_RemovePlayerArea(i)
endif
endif
if u!=null then
set cx=MO2_GetCellX(GetUnitX(u))
set cy=MO2_GetCellY(GetUnitY(u))
call MO2_MovePlayer(i,cx,cy)
endif
endif
set i=i+1
endloop
set u=null
endfunction
function MO2_Init takes nothing returns nothing
local rect r=GetPlayableMapRect()
local real w
local real h
local trigger t
set MO2_MIN_X=GetRectMinX(r)
set MO2_MIN_Y=GetRectMinY(r)
set MO2_MAX_X=GetRectMaxX(r)
set MO2_MAX_Y=GetRectMaxY(r)
set w=MO2_MAX_X-MO2_MIN_X
set h=MO2_MAX_Y-MO2_MIN_Y
set MO2_CELLS_X=R2I(w/MO2_CELL_SIZE)+1
set MO2_CELLS_Y=R2I(h/MO2_CELL_SIZE)+1
set MO2_RECT=Rect(0.00,0.00,0.00,0.00)
set MO2_GROUP=CreateGroup()
set MO2_HERO_FILTER=Filter(function MO2_HeroFilter)
call SetRect(MO2_RECT,MO2_MIN_X,MO2_MIN_Y,MO2_MAX_X,MO2_MAX_Y)
set MO2_SHOW_MODE=false
call EnumDestructablesInRectAll(MO2_RECT,function MO2_DestructableVisibility)
set t=CreateTrigger()
call TriggerRegisterTimerEvent(t,MO2_PERIOD,true)
call TriggerAddAction(t,function MO2_Update)
set t=null
set r=null
endfunction
function InitTrig_MapOptimizer_2026_2 takes nothing returns nothing
call MO2_Init()
endfunction
function Trig_efe_Actions takes nothing returns nothing
local string s=GetEventPlayerChatString()
if s=="-day"then
call SetFloatGameState(GAME_STATE_TIME_OF_DAY,12.00)
call SetDayNightModels("Environment\\DNC\\DNCLordaeron\\DNCLordaeronTerrain\\DNCLordaeronTerrain.mdl","Environment\\DNC\\DNCLordaeron\\DNCLordaeronUnit\\DNCLordaeronUnit.mdl")
call DisplayTextToPlayer(Player(0),0.00,0.00,"|cffffcc00ДЕНЬ|r")
elseif s=="-night"then
call SetFloatGameState(GAME_STATE_TIME_OF_DAY,0.00)
call SetDayNightModels("Environment\\DNC\\DNCLordaeron\\DNCLordaeronTerrain\\DNCLordaeronTerrain.mdl","Environment\\DNC\\DNCLordaeron\\DNCLordaeronUnit\\DNCLordaeronUnit.mdl")
call DisplayTextToPlayer(Player(0),0.00,0.00,"|cff6688ffНОЧЬ|r")
endif
set s=null
endfunction
function InitTrig_efe takes nothing returns nothing
set gg_trg_efe=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_efe,Player(0),"-day",true)
call TriggerRegisterPlayerChatEvent(gg_trg_efe,Player(0),"-night",true)
call TriggerAddAction(gg_trg_efe,function Trig_efe_Actions)
endfunction
function VampireIsUnit takes unit u returns boolean
if u==null then
return false
endif
return GetUnitTypeId(u)==VampireUnitType
endfunction
function VampireFilter takes nothing returns boolean
return VampireIsUnit(GetFilterUnit())
endfunction
function VampireAddAbility takes unit u,integer abilityId returns nothing
if abilityId!=0 then
if GetUnitAbilityLevel(u,abilityId)==0 then
call UnitAddAbilityBJ(abilityId,u)
endif
endif
endfunction
function VampireRemoveAbility takes unit u,integer abilityId returns nothing
if abilityId!=0 then
if GetUnitAbilityLevel(u,abilityId)>0 then
call UnitRemoveAbilityBJ(abilityId,u)
endif
endif
endfunction
function VampireApplyDay takes nothing returns nothing
local unit u=GetEnumUnit()
if VampireIsUnit(u)then
if GetWidgetLife(u)>0.405 then
call VampireRemoveAbility(u,VampireNightState)
call VampireRemoveAbility(u,VampireNightSkill)
call VampireRemoveAbility(u,VampireNightDamage)
call VampireRemoveAbility(u,VampireNightMoveSpeed)
call VampireRemoveAbility(u,VampireNightAttackSpeed)
call VampireRemoveAbility(u,VampireNightArmor)
call VampireAddAbility(u,VampireDayState)
call VampireAddAbility(u,VampireDayDebuff)
call VampireAddAbility(u,VampireDayDamage)
call VampireAddAbility(u,VampireDayMoveSpeed)
call VampireAddAbility(u,VampireDayAttackSpeed)
call VampireAddAbility(u,VampireDayArmor)
endif
endif
set u=null
endfunction
function VampireApplyNight takes nothing returns nothing
local unit u=GetEnumUnit()
if VampireIsUnit(u)then
if GetWidgetLife(u)>0.405 then
call VampireRemoveAbility(u,VampireDayState)
call VampireRemoveAbility(u,VampireDayDebuff)
call VampireRemoveAbility(u,VampireDayDamage)
call VampireRemoveAbility(u,VampireDayMoveSpeed)
call VampireRemoveAbility(u,VampireDayAttackSpeed)
call VampireRemoveAbility(u,VampireDayArmor)
call VampireAddAbility(u,VampireNightState)
call VampireAddAbility(u,VampireNightSkill)
call VampireAddAbility(u,VampireNightDamage)
call VampireAddAbility(u,VampireNightMoveSpeed)
call VampireAddAbility(u,VampireNightAttackSpeed)
call VampireAddAbility(u,VampireNightArmor)
endif
endif
set u=null
endfunction
function VampireUpdateAll takes nothing returns nothing
call GroupClear(VampireGroup)
call GroupEnumUnitsInRect(VampireGroup,VampireRect,Condition(function VampireFilter))
if VampireIsDay then
call ForGroup(VampireGroup,function VampireApplyDay)
else
call ForGroup(VampireGroup,function VampireApplyNight)
endif
endfunction
function VampireTimerAction takes nothing returns nothing
local boolean NewIsDay=false
if GetTimeOfDay()>=6.00 and GetTimeOfDay()<18.00 then
set NewIsDay=true
endif
if NewIsDay!=VampireIsDay then
set VampireIsDay=NewIsDay
set VampireCheckCount=0
call VampireUpdateAll()
else
set VampireCheckCount=VampireCheckCount+1
if VampireCheckCount>=4 then
set VampireCheckCount=0
call VampireUpdateAll()
endif
endif
endfunction
function InitTrig_vwvw takes nothing returns nothing
local rect r=GetWorldBounds()
set VampireGroup=CreateGroup()
set VampireTimer=CreateTimer()
set VampireRect=r
if GetTimeOfDay()>=6.00 and GetTimeOfDay()<18.00 then
set VampireIsDay=true
else
set VampireIsDay=false
endif
call VampireUpdateAll()
call TimerStart(VampireTimer,0.50,true,function VampireTimerAction)
set r=null
endfunction
function BW_IsDrink takes nothing returns boolean
return GetSpellAbilityId()==BW_DRINK
endfunction
function BW_GiveBuffs takes unit target returns nothing
if target==null then
return
endif
call UnitRemoveAbility(target,BW_BUFF_1)
call UnitRemoveAbility(target,BW_BUFF_2)
call UnitRemoveAbility(target,BW_BUFF_3)
call UnitAddAbility(target,BW_BUFF_1)
call SetUnitAbilityLevel(target,BW_BUFF_1,1)
call UnitAddAbility(target,BW_BUFF_2)
call SetUnitAbilityLevel(target,BW_BUFF_2,1)
call UnitAddAbility(target,BW_BUFF_3)
call SetUnitAbilityLevel(target,BW_BUFF_3,1)
endfunction
function BW_RemoveBuffs takes unit target returns nothing
local integer targetId
local timer currentTimer
if target==null then
return
endif
set targetId=GetHandleId(target)
call UnitRemoveAbility(target,BW_BUFF_1)
call UnitRemoveAbility(target,BW_BUFF_2)
call UnitRemoveAbility(target,BW_BUFF_3)
set currentTimer=LoadTimerHandle(BW_TimerHash,targetId,1)
if currentTimer!=null then
call RemoveSavedHandle(BW_TimerHash,targetId,1)
endif
set currentTimer=null
endfunction
function BW_BuffExpire takes nothing returns nothing
local timer expiredTimer
local integer timerId
local unit target
local integer targetId
local timer currentTimer
set expiredTimer=GetExpiredTimer()
set timerId=GetHandleId(expiredTimer)
set target=LoadUnitHandle(BW_TimerHash,timerId,0)
if target!=null then
set targetId=GetHandleId(target)
set currentTimer=LoadTimerHandle(BW_TimerHash,targetId,1)
if currentTimer==expiredTimer then
call BW_RemoveBuffs(target)
endif
endif
call FlushChildHashtable(BW_TimerHash,timerId)
call DestroyTimer(expiredTimer)
set currentTimer=null
set target=null
set expiredTimer=null
endfunction
function BW_StartBuffTimer takes unit target,real duration returns nothing
local integer targetId
local timer oldTimer
local timer newTimer
local integer newTimerId
if target==null then
return
endif
if duration<=0.00 then
return
endif
set targetId=GetHandleId(target)
set oldTimer=LoadTimerHandle(BW_TimerHash,targetId,1)
if oldTimer!=null then
call PauseTimer(oldTimer)
call FlushChildHashtable(BW_TimerHash,GetHandleId(oldTimer))
call DestroyTimer(oldTimer)
call RemoveSavedHandle(BW_TimerHash,targetId,1)
endif
set newTimer=CreateTimer()
set newTimerId=GetHandleId(newTimer)
call SaveUnitHandle(BW_TimerHash,newTimerId,0,target)
call SaveTimerHandle(BW_TimerHash,targetId,1,newTimer)
call TimerStart(newTimer,duration,false,function BW_BuffExpire)
set oldTimer=null
set newTimer=null
endfunction
function BW_ClearRightClickMark takes nothing returns nothing
local timer expiredTimer
local integer timerId
local unit target
local integer targetId
local timer currentTimer
set expiredTimer=GetExpiredTimer()
set timerId=GetHandleId(expiredTimer)
set target=LoadUnitHandle(BW_RightClickHash,timerId,0)
if target!=null then
set targetId=GetHandleId(target)
set currentTimer=LoadTimerHandle(BW_RightClickHash,targetId,1)
if currentTimer==expiredTimer then
call RemoveSavedHandle(BW_RightClickHash,targetId,0)
call RemoveSavedHandle(BW_RightClickHash,targetId,1)
endif
endif
call FlushChildHashtable(BW_RightClickHash,timerId)
call DestroyTimer(expiredTimer)
set currentTimer=null
set targetId=0
set target=null
set expiredTimer=null
endfunction
function BW_ProcessDrink takes nothing returns nothing
local timer delayTimer
local integer delayId
local unit well
local unit target
local real blood
local real hpBefore
local real hpFinal
local real healAmount
local real duration
local boolean rightClick
set delayTimer=GetExpiredTimer()
set delayId=GetHandleId(delayTimer)
set well=LoadUnitHandle(BW_CastHash,delayId,0)
set target=LoadUnitHandle(BW_CastHash,delayId,1)
set blood=LoadReal(BW_CastHash,delayId,2)
set hpBefore=LoadReal(BW_CastHash,delayId,3)
set rightClick=LoadBoolean(BW_CastHash,delayId,4)
if well==null then
call FlushChildHashtable(BW_CastHash,delayId)
call DestroyTimer(delayTimer)
set target=null
set delayTimer=null
set target=null
set well=null
set delayTimer=null
return
endif
if target==null then
call FlushChildHashtable(BW_CastHash,delayId)
call DestroyTimer(delayTimer)
set well=null
set delayTimer=null
set target=null
set well=null
set delayTimer=null
return
endif
if GetUnitState(well,UNIT_STATE_LIFE)<=0.405 then
call FlushChildHashtable(BW_CastHash,delayId)
call DestroyTimer(delayTimer)
set well=null
set target=null
set delayTimer=null
set target=null
set well=null
set delayTimer=null
return
endif
if GetUnitState(target,UNIT_STATE_LIFE)<=0.405 then
call FlushChildHashtable(BW_CastHash,delayId)
call DestroyTimer(delayTimer)
set well=null
set target=null
set delayTimer=null
set target=null
set well=null
set delayTimer=null
return
endif
if blood<0.00 then
set blood=0.00
endif
if blood>BW_MAX_MANA then
set blood=BW_MAX_MANA
endif
if blood<=0.00 then
call FlushChildHashtable(BW_CastHash,delayId)
call DestroyTimer(delayTimer)
set well=null
set target=null
set delayTimer=null
set target=null
set well=null
set delayTimer=null
return
endif
call SetUnitState(well,UNIT_STATE_MANA,0.00)
if rightClick then
set healAmount=blood*BW_HEAL_PER_BLOOD*BW_RIGHTCLICK_MULTIPLIER
else
set healAmount=blood*BW_HEAL_PER_BLOOD
endif
set hpFinal=hpBefore+healAmount
if hpFinal>GetUnitState(target,UNIT_STATE_MAX_LIFE)then
set hpFinal=GetUnitState(target,UNIT_STATE_MAX_LIFE)
endif
call SetUnitState(target,UNIT_STATE_LIFE,hpFinal)
if rightClick==false then
call BW_GiveBuffs(target)
set duration=blood
call BW_StartBuffTimer(target,duration)
endif
call FlushChildHashtable(BW_CastHash,delayId)
call DestroyTimer(delayTimer)
set duration=0.00
set healAmount=0.00
set hpFinal=0.00
set hpBefore=0.00
set blood=0.00
set rightClick=false
set well=null
set target=null
set delayTimer=null
endfunction
function BW_StartDrinkProcess takes nothing returns nothing
local unit well
local unit target
local integer targetId
local unit markedWell
local timer markedTimer
local real blood
local real hpBefore
local boolean rightClick
local timer delayTimer
local integer delayId
set well=GetSpellAbilityUnit()
set target=GetSpellTargetUnit()
if well==null then
set target=null
set target=null
set well=null
return
endif
if target==null then
set well=null
set target=null
set well=null
return
endif
if GetUnitState(well,UNIT_STATE_LIFE)<=0.405 then
set well=null
set target=null
set target=null
set well=null
return
endif
if GetUnitState(target,UNIT_STATE_LIFE)<=0.405 then
set well=null
set target=null
set target=null
set well=null
return
endif
set targetId=GetHandleId(target)
set markedWell=LoadUnitHandle(BW_RightClickHash,targetId,0)
set rightClick=false
if markedWell==well then
set rightClick=true
endif
call RemoveSavedHandle(BW_RightClickHash,targetId,0)
set markedTimer=LoadTimerHandle(BW_RightClickHash,targetId,1)
if markedTimer!=null then
call PauseTimer(markedTimer)
call FlushChildHashtable(BW_RightClickHash,GetHandleId(markedTimer))
call DestroyTimer(markedTimer)
call RemoveSavedHandle(BW_RightClickHash,targetId,1)
endif
set blood=GetUnitState(well,UNIT_STATE_MANA)
if blood<0.00 then
set blood=0.00
endif
if blood>BW_MAX_MANA then
set blood=BW_MAX_MANA
endif
if blood<=0.00 then
set markedTimer=null
set markedWell=null
set well=null
set target=null
set markedTimer=null
set markedWell=null
set target=null
set well=null
return
endif
set hpBefore=GetUnitState(target,UNIT_STATE_LIFE)
set delayTimer=CreateTimer()
set delayId=GetHandleId(delayTimer)
call SaveUnitHandle(BW_CastHash,delayId,0,well)
call SaveUnitHandle(BW_CastHash,delayId,1,target)
call SaveReal(BW_CastHash,delayId,2,blood)
call SaveReal(BW_CastHash,delayId,3,hpBefore)
call SaveBoolean(BW_CastHash,delayId,4,rightClick)
call TimerStart(delayTimer,BW_CAST_DELAY,false,function BW_ProcessDrink)
set markedTimer=null
set markedWell=null
set delayTimer=null
set target=null
set well=null
endfunction
function BW_RightClick takes nothing returns nothing
local unit worker
local unit well
local integer orderId
local integer workerId
local timer oldTimer
local timer markTimer
local integer markTimerId
set worker=GetOrderedUnit()
set well=GetOrderTargetUnit()
set orderId=GetIssuedOrderId()
if orderId==851970 or orderId==851971 then
if worker!=null then
if well!=null then
if GetUnitAbilityLevel(well,BW_DRINK)>0 then
if GetUnitState(well,UNIT_STATE_LIFE)>0.405 then
if GetUnitState(worker,UNIT_STATE_LIFE)>0.405 then
if IsUnitAlly(worker,GetOwningPlayer(well))then
set workerId=GetHandleId(worker)
set oldTimer=LoadTimerHandle(BW_RightClickHash,workerId,1)
if oldTimer!=null then
call PauseTimer(oldTimer)
call FlushChildHashtable(BW_RightClickHash,GetHandleId(oldTimer))
call DestroyTimer(oldTimer)
call RemoveSavedHandle(BW_RightClickHash,workerId,1)
endif
call SaveUnitHandle(BW_RightClickHash,workerId,0,well)
set markTimer=CreateTimer()
set markTimerId=GetHandleId(markTimer)
call SaveUnitHandle(BW_RightClickHash,markTimerId,0,worker)
call SaveTimerHandle(BW_RightClickHash,workerId,1,markTimer)
call TimerStart(markTimer,BW_RIGHTCLICK_MARK_TIME,false,function BW_ClearRightClickMark)
set markTimer=null
endif
endif
endif
endif
endif
endif
endif
set oldTimer=null
set worker=null
set well=null
endfunction
function BW_Death takes nothing returns nothing
local unit u
local integer unitId
local timer currentTimer
local timer rightClickTimer
set u=GetTriggerUnit()
if u!=null then
call UnitRemoveAbility(u,BW_BUFF_1)
call UnitRemoveAbility(u,BW_BUFF_2)
call UnitRemoveAbility(u,BW_BUFF_3)
set unitId=GetHandleId(u)
set currentTimer=LoadTimerHandle(BW_TimerHash,unitId,1)
if currentTimer!=null then
call PauseTimer(currentTimer)
call FlushChildHashtable(BW_TimerHash,GetHandleId(currentTimer))
call DestroyTimer(currentTimer)
call RemoveSavedHandle(BW_TimerHash,unitId,1)
endif
set rightClickTimer=LoadTimerHandle(BW_RightClickHash,unitId,1)
if rightClickTimer!=null then
call PauseTimer(rightClickTimer)
call FlushChildHashtable(BW_RightClickHash,GetHandleId(rightClickTimer))
call DestroyTimer(rightClickTimer)
call RemoveSavedHandle(BW_RightClickHash,unitId,0)
call RemoveSavedHandle(BW_RightClickHash,unitId,1)
endif
set rightClickTimer=null
set currentTimer=null
endif
set unitId=0
set u=null
endfunction
function InitTrig_BloodWell takes nothing returns nothing
local trigger drinkTrig
local trigger rightTrig
local trigger deathTrig
set drinkTrig=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(drinkTrig,EVENT_PLAYER_UNIT_SPELL_CAST)
call TriggerAddCondition(drinkTrig,Condition(function BW_IsDrink))
call TriggerAddAction(drinkTrig,function BW_StartDrinkProcess)
set rightTrig=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(rightTrig,EVENT_PLAYER_UNIT_ISSUED_TARGET_ORDER)
call TriggerAddAction(rightTrig,function BW_RightClick)
set deathTrig=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(deathTrig,EVENT_PLAYER_UNIT_DEATH)
call TriggerAddAction(deathTrig,function BW_Death)
set drinkTrig=null
set rightTrig=null
set deathTrig=null
endfunction
function PLBC_FXExpire takes nothing returns nothing
local timer t=GetExpiredTimer()
local integer tid=GetHandleId(t)
local effect fx
set fx=LoadEffectHandle(PLBC_FXHash,tid,0)
if fx!=null then
call DestroyEffect(fx)
endif
call FlushChildHashtable(PLBC_FXHash,tid)
call DestroyTimer(t)
set fx=null
set t=null
endfunction
function PLBC_AddFX takes string path,real x,real y,real duration returns nothing
local effect fx
local timer t
local integer tid
set fx=AddSpecialEffect(path,x,y)
set t=CreateTimer()
set tid=GetHandleId(t)
call SaveEffectHandle(PLBC_FXHash,tid,0,fx)
call TimerStart(t,duration,false,function PLBC_FXExpire)
set fx=null
set t=null
endfunction
function PLBC_SlowExpire takes nothing returns nothing
local timer t=GetExpiredTimer()
local integer tid=GetHandleId(t)
local unit target
local integer targetId
local timer currentTimer
local real originalSpeed
set target=LoadUnitHandle(PLBC_SlowHash,tid,0)
set originalSpeed=LoadReal(PLBC_SlowHash,tid,1)
if target!=null then
set targetId=GetHandleId(target)
set currentTimer=LoadTimerHandle(PLBC_SlowHash,targetId,0)
if currentTimer==t then
if GetUnitTypeId(target)!=0 then
call SetUnitMoveSpeed(target,originalSpeed)
endif
call RemoveSavedHandle(PLBC_SlowHash,targetId,0)
endif
endif
call FlushChildHashtable(PLBC_SlowHash,tid)
call DestroyTimer(t)
set currentTimer=null
set target=null
set t=null
endfunction
function PLBC_ApplySlow takes unit target returns nothing
local integer targetId
local integer tid
local timer oldTimer
local timer newTimer
local real originalSpeed
if target==null then
return
endif
if GetUnitTypeId(target)==0 then
return
endif
if GetUnitState(target,UNIT_STATE_LIFE)<=0.405 then
return
endif
set targetId=GetHandleId(target)
set oldTimer=LoadTimerHandle(PLBC_SlowHash,targetId,0)
if oldTimer!=null then
set originalSpeed=LoadReal(PLBC_SlowHash,GetHandleId(oldTimer),1)
call PauseTimer(oldTimer)
call FlushChildHashtable(PLBC_SlowHash,GetHandleId(oldTimer))
call DestroyTimer(oldTimer)
else
set originalSpeed=GetUnitMoveSpeed(target)
endif
if originalSpeed>0.00 then
call SetUnitMoveSpeed(target,originalSpeed*PLBC_SLOW_FACTOR)
endif
set newTimer=CreateTimer()
set tid=GetHandleId(newTimer)
call SaveUnitHandle(PLBC_SlowHash,tid,0,target)
call SaveReal(PLBC_SlowHash,tid,1,originalSpeed)
call SaveTimerHandle(PLBC_SlowHash,targetId,0,newTimer)
call TimerStart(newTimer,PLBC_SLOW_TIME,false,function PLBC_SlowExpire)
set oldTimer=null
set newTimer=null
endfunction
function PLBC_ExecuteImpact takes unit caster,real x,real y,real damage,real healPerEnemy returns nothing
local unit victim
local group victims
local real totalHeal
local real hpFinal
local real maxHP
set totalHeal=0.00
if caster==null then
return
endif
if GetUnitTypeId(caster)==0 then
return
endif
call PLBC_AddFX(PLBC_FX_EXPLOSION,x,y,1.00)
call PLBC_AddFX(PLBC_FX_GROUND,x,y,1.50)
set victims=CreateGroup()
call GroupEnumUnitsInRange(victims,x,y,PLBC_RADIUS,null)
loop
set victim=FirstOfGroup(victims)
exitwhen victim==null
call GroupRemoveUnit(victims,victim)
if GetUnitTypeId(victim)!=0 then
if victim!=caster then
if IsUnitEnemy(victim,GetOwningPlayer(caster))then
if GetUnitState(victim,UNIT_STATE_LIFE)>0.405 then
if not IsUnitType(victim,UNIT_TYPE_STRUCTURE)then
if UnitDamageTarget(caster,victim,damage,false,false,ATTACK_TYPE_NORMAL,DAMAGE_TYPE_NORMAL,WEAPON_TYPE_WHOKNOWS)then
set totalHeal=totalHeal+healPerEnemy
if GetUnitTypeId(victim)!=0 then
if GetUnitState(victim,UNIT_STATE_LIFE)>0.405 then
call PLBC_ApplySlow(victim)
endif
endif
endif
endif
endif
endif
endif
endif
endloop
if GetUnitTypeId(caster)!=0 then
if GetUnitState(caster,UNIT_STATE_LIFE)>0.405 then
set hpFinal=GetUnitState(caster,UNIT_STATE_LIFE)+totalHeal
set maxHP=GetUnitState(caster,UNIT_STATE_MAX_LIFE)
if hpFinal>maxHP then
set hpFinal=maxHP
endif
call SetUnitState(caster,UNIT_STATE_LIFE,hpFinal)
endif
endif
call DestroyGroup(victims)
set hpFinal=0.00
set maxHP=0.00
set totalHeal=0.00
set victims=null
set victim=null
endfunction
function PLBC_ImpactTimer takes nothing returns nothing
local timer t=GetExpiredTimer()
local integer tid=GetHandleId(t)
local unit caster
local real x
local real y
local real damage
local real healPerEnemy
set caster=LoadUnitHandle(PLBC_FXHash,tid,0)
set x=LoadReal(PLBC_FXHash,tid,1)
set y=LoadReal(PLBC_FXHash,tid,2)
set damage=LoadReal(PLBC_FXHash,tid,3)
set healPerEnemy=LoadReal(PLBC_FXHash,tid,4)
if caster!=null then
if GetUnitTypeId(caster)!=0 then
call PLBC_ExecuteImpact(caster,x,y,damage,healPerEnemy)
endif
endif
call FlushChildHashtable(PLBC_FXHash,tid)
call DestroyTimer(t)
set caster=null
set t=null
endfunction
function PLBC_ScheduleImpact takes unit caster,real x,real y,real damage,real healPerEnemy returns nothing
local timer t=CreateTimer()
local integer tid=GetHandleId(t)
call SaveUnitHandle(PLBC_FXHash,tid,0,caster)
call SaveReal(PLBC_FXHash,tid,1,x)
call SaveReal(PLBC_FXHash,tid,2,y)
call SaveReal(PLBC_FXHash,tid,3,damage)
call SaveReal(PLBC_FXHash,tid,4,healPerEnemy)
call TimerStart(t,PLBC_IMPACT_DELAY,false,function PLBC_ImpactTimer)
set t=null
endfunction
function PLBC_IsCleave takes nothing returns boolean
return GetSpellAbilityId()==PLBC_ABILITY
endfunction
function PLBC_BloodCleave takes nothing returns nothing
local unit caster
local real angle
local real x
local real y
local real damage
local real healPerEnemy
local integer level
set caster=GetTriggerUnit()
if caster==null then
set caster=null
return
endif
if GetUnitTypeId(caster)==0 then
set caster=null
set caster=null
return
endif
if GetUnitState(caster,UNIT_STATE_LIFE)<=0.405 then
set caster=null
set caster=null
return
endif
set level=GetUnitAbilityLevel(caster,PLBC_ABILITY)
if level<1 then
set caster=null
set caster=null
return
endif
if level>5 then
set level=5
endif
if level==1 then
set damage=60.00
set healPerEnemy=15.00
elseif level==2 then
set damage=100.00
set healPerEnemy=25.00
elseif level==3 then
set damage=140.00
set healPerEnemy=35.00
elseif level==4 then
set damage=180.00
set healPerEnemy=45.00
else
set damage=220.00
set healPerEnemy=55.00
endif
set angle=GetUnitFacing(caster)*bj_DEGTORAD
set x=GetUnitX(caster)+PLBC_IMPACT_DISTANCE*Cos(angle)
set y=GetUnitY(caster)+PLBC_IMPACT_DISTANCE*Sin(angle)
call PLBC_ScheduleImpact(caster,x,y,damage,healPerEnemy)
set angle=0.00
set x=0.00
set y=0.00
set damage=0.00
set healPerEnemy=0.00
set caster=null
endfunction
function InitTrig_PitLordBlood takes nothing returns nothing
local trigger t
set PLBC_SlowHash=InitHashtable()
set PLBC_FXHash=InitHashtable()
set t=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(t,EVENT_PLAYER_UNIT_SPELL_EFFECT)
call TriggerAddCondition(t,Condition(function PLBC_IsCleave))
call TriggerAddAction(t,function PLBC_BloodCleave)
set t=null
endfunction
function PLF_DestroyTimedEffect takes nothing returns nothing
local timer t=GetExpiredTimer()
local integer tid=GetHandleId(t)
local effect fx
set fx=LoadEffectHandle(PLF_EffectHash,tid,PLF_KEY_TEMP_EFFECT)
if fx!=null then
call DestroyEffect(fx)
endif
call FlushChildHashtable(PLF_EffectHash,tid)
call DestroyTimer(t)
set fx=null
set t=null
endfunction
function PLF_AddTimedEffectAtPoint takes string path,real x,real y,real duration returns nothing
local effect fx
local timer t
local integer tid
if duration<=0.00 then
return
endif
set fx=AddSpecialEffect(path,x,y)
if fx==null then
set fx=null
return
endif
set t=CreateTimer()
set tid=GetHandleId(t)
call SaveEffectHandle(PLF_EffectHash,tid,PLF_KEY_TEMP_EFFECT,fx)
call TimerStart(t,duration,false,function PLF_DestroyTimedEffect)
set tid=0
set fx=null
set t=null
endfunction
function PLF_AddTimedEffectTarget takes string path,unit hero,string attachPoint,real duration returns nothing
local effect fx
local timer t
local integer tid
if hero==null or duration<=0.00 then
return
endif
set fx=AddSpecialEffectTarget(path,hero,attachPoint)
if fx==null then
set fx=null
return
endif
set t=CreateTimer()
set tid=GetHandleId(t)
call SaveEffectHandle(PLF_EffectHash,tid,PLF_KEY_TEMP_EFFECT,fx)
call TimerStart(t,duration,false,function PLF_DestroyTimedEffect)
set tid=0
set fx=null
set t=null
endfunction
function PLF_CreateVisuals takes unit hero returns nothing
local integer heroId
local effect fx
if hero==null then
return
endif
set heroId=GetHandleId(hero)
set fx=LoadEffectHandle(PLF_Hash,heroId,PLF_KEY_WEAPON)
if fx==null then
set fx=AddSpecialEffectTarget(PLF_FX_WEAPON,hero,"weapon")
if fx!=null then
call SaveEffectHandle(PLF_Hash,heroId,PLF_KEY_WEAPON,fx)
endif
endif
set fx=null
endfunction
function PLF_RemoveVisuals takes unit hero returns nothing
local integer heroId
local effect fx
if hero==null then
return
endif
set heroId=GetHandleId(hero)
set fx=LoadEffectHandle(PLF_Hash,heroId,PLF_KEY_WEAPON)
if fx!=null then
call DestroyEffect(fx)
endif
call RemoveSavedHandle(PLF_Hash,heroId,PLF_KEY_WEAPON)
set fx=null
endfunction
function PLF_RestoreBonuses takes unit hero returns nothing
local integer heroId
local integer oldAttack
local integer oldRegen
if hero==null then
return
endif
set heroId=GetHandleId(hero)
set oldAttack=LoadInteger(PLF_Hash,heroId,PLF_KEY_OLD_ATTACK)
set oldRegen=LoadInteger(PLF_Hash,heroId,PLF_KEY_OLD_REGEN)
if oldAttack>0 then
if GetUnitAbilityLevel(hero,PLF_ATTACK_SPEED)<1 then
call UnitAddAbility(hero,PLF_ATTACK_SPEED)
endif
call SetUnitAbilityLevel(hero,PLF_ATTACK_SPEED,oldAttack)
else
call UnitRemoveAbility(hero,PLF_ATTACK_SPEED)
endif
if oldRegen>0 then
if GetUnitAbilityLevel(hero,PLF_HP_REGEN)<1 then
call UnitAddAbility(hero,PLF_HP_REGEN)
endif
call SetUnitAbilityLevel(hero,PLF_HP_REGEN,oldRegen)
else
call UnitRemoveAbility(hero,PLF_HP_REGEN)
endif
call RemoveSavedInteger(PLF_Hash,heroId,PLF_KEY_OLD_ATTACK)
call RemoveSavedInteger(PLF_Hash,heroId,PLF_KEY_OLD_REGEN)
call RemoveSavedBoolean(PLF_Hash,heroId,PLF_KEY_ACTIVE)
set heroId=0
set oldAttack=0
set oldRegen=0
endfunction
function PLF_ApplyBonuses takes unit hero,integer level returns nothing
if hero==null then
return
endif
if level<1 then
return
endif
if level>5 then
set level=5
endif
if GetUnitAbilityLevel(hero,PLF_ATTACK_SPEED)<1 then
call UnitAddAbility(hero,PLF_ATTACK_SPEED)
endif
call SetUnitAbilityLevel(hero,PLF_ATTACK_SPEED,level)
if GetUnitAbilityLevel(hero,PLF_HP_REGEN)<1 then
call UnitAddAbility(hero,PLF_HP_REGEN)
endif
call SetUnitAbilityLevel(hero,PLF_HP_REGEN,level)
endfunction
function PLF_CastVisuals takes unit hero returns nothing
local real x
local real y
if hero==null then
return
endif
if GetUnitState(hero,UNIT_STATE_LIFE)<=0.405 then
return
endif
set x=GetUnitX(hero)
set y=GetUnitY(hero)
call PLF_AddTimedEffectAtPoint(PLF_FX_CAST,x,y,PLF_CAST_FX_TIME)
call PLF_AddTimedEffectTarget(PLF_FX_PULSE,hero,"origin",PLF_PULSE_TIME)
set x=0.00
set y=0.00
endfunction
function PLF_EndVisuals takes unit hero returns nothing
local real x
local real y
if hero==null then
return
endif
if GetUnitState(hero,UNIT_STATE_LIFE)<=0.405 then
return
endif
set x=GetUnitX(hero)
set y=GetUnitY(hero)
call PLF_AddTimedEffectAtPoint(PLF_FX_END,x,y,PLF_END_FX_TIME)
set x=0.00
set y=0.00
endfunction
function PLF_FrenzyExpire takes nothing returns nothing
local timer t=GetExpiredTimer()
local integer tid=GetHandleId(t)
local unit hero
local integer heroId
local timer currentTimer
set hero=LoadUnitHandle(PLF_Hash,tid,PLF_KEY_HERO)
if hero!=null then
set heroId=GetHandleId(hero)
set currentTimer=LoadTimerHandle(PLF_Hash,heroId,PLF_KEY_TIMER)
if currentTimer==t then
call RemoveSavedHandle(PLF_Hash,heroId,PLF_KEY_TIMER)
call PLF_RemoveVisuals(hero)
call PLF_RestoreBonuses(hero)
call PLF_EndVisuals(hero)
endif
endif
call FlushChildHashtable(PLF_Hash,tid)
call DestroyTimer(t)
set currentTimer=null
set hero=null
set t=null
endfunction
function PLF_StartFrenzy takes unit hero returns nothing
local integer heroId
local integer level
local integer tid
local timer t
local real remaining
if hero==null then
return
endif
if GetUnitState(hero,UNIT_STATE_LIFE)<=0.405 then
return
endif
set heroId=GetHandleId(hero)
set level=GetUnitAbilityLevel(hero,PLF_ABILITY)
if level<1 then
return
endif
if level>5 then
set level=5
endif
set t=LoadTimerHandle(PLF_Hash,heroId,PLF_KEY_TIMER)
if t!=null then
set remaining=TimerGetRemaining(t)
if remaining>0.00 then
call PLF_ApplyBonuses(hero,level)
call PLF_CreateVisuals(hero)
call PLF_CastVisuals(hero)
if remaining<PLF_DURATION then
set remaining=PLF_DURATION
endif
call TimerStart(t,remaining,false,function PLF_FrenzyExpire)
set remaining=0.00
set t=null
set hero=null
set t=null
return
endif
call PauseTimer(t)
call FlushChildHashtable(PLF_Hash,GetHandleId(t))
call DestroyTimer(t)
call RemoveSavedHandle(PLF_Hash,heroId,PLF_KEY_TIMER)
if LoadBoolean(PLF_Hash,heroId,PLF_KEY_ACTIVE)then
call PLF_RemoveVisuals(hero)
call PLF_RestoreBonuses(hero)
endif
set t=null
endif
if LoadBoolean(PLF_Hash,heroId,PLF_KEY_ACTIVE)then
call PLF_RemoveVisuals(hero)
call PLF_RestoreBonuses(hero)
endif
call SaveInteger(PLF_Hash,heroId,PLF_KEY_OLD_ATTACK,GetUnitAbilityLevel(hero,PLF_ATTACK_SPEED))
call SaveInteger(PLF_Hash,heroId,PLF_KEY_OLD_REGEN,GetUnitAbilityLevel(hero,PLF_HP_REGEN))
call SaveBoolean(PLF_Hash,heroId,PLF_KEY_ACTIVE,true)
call PLF_ApplyBonuses(hero,level)
call PLF_CreateVisuals(hero)
call PLF_CastVisuals(hero)
set t=CreateTimer()
set tid=GetHandleId(t)
call SaveUnitHandle(PLF_Hash,tid,PLF_KEY_HERO,hero)
call SaveTimerHandle(PLF_Hash,heroId,PLF_KEY_TIMER,t)
call TimerStart(t,PLF_DURATION,false,function PLF_FrenzyExpire)
set tid=0
set remaining=0.00
set t=null
set hero=null
endfunction
function PLF_IsFrenzy takes nothing returns boolean
return GetSpellAbilityId()==PLF_ABILITY
endfunction
function PLF_Cast takes nothing returns nothing
local unit hero=GetTriggerUnit()
call PLF_StartFrenzy(hero)
set hero=null
endfunction
function PLF_UnitDeath takes nothing returns nothing
local unit deadUnit=GetTriggerUnit()
local unit killer=GetKillingUnit()
local integer killerId
local integer deadId
local timer frenzyTimer
local real remaining
if killer!=null then
if killer!=deadUnit then
if GetUnitState(killer,UNIT_STATE_LIFE)>0.405 then
if GetUnitAbilityLevel(killer,PLF_ABILITY)>0 then
if IsUnitEnemy(deadUnit,GetOwningPlayer(killer))then
if not IsUnitType(deadUnit,UNIT_TYPE_STRUCTURE)then
if not IsUnitType(deadUnit,UNIT_TYPE_PEON)then
set killerId=GetHandleId(killer)
set frenzyTimer=LoadTimerHandle(PLF_Hash,killerId,PLF_KEY_TIMER)
if frenzyTimer!=null then
if LoadBoolean(PLF_Hash,killerId,PLF_KEY_ACTIVE)then
set remaining=TimerGetRemaining(frenzyTimer)
if remaining>0.00 then
call TimerStart(frenzyTimer,remaining+PLF_KILL_EXTEND,false,function PLF_FrenzyExpire)
call PLF_AddTimedEffectAtPoint(PLF_FX_KILL,GetUnitX(deadUnit),GetUnitY(deadUnit),PLF_KILL_FX_TIME)
call PLF_AddTimedEffectTarget(PLF_FX_PULSE,killer,"origin",PLF_PULSE_TIME)
endif
endif
endif
endif
endif
endif
endif
endif
endif
endif
set deadId=GetHandleId(deadUnit)
set frenzyTimer=LoadTimerHandle(PLF_Hash,deadId,PLF_KEY_TIMER)
if frenzyTimer!=null or LoadBoolean(PLF_Hash,deadId,PLF_KEY_ACTIVE)then
if frenzyTimer!=null then
call PauseTimer(frenzyTimer)
call FlushChildHashtable(PLF_Hash,GetHandleId(frenzyTimer))
call DestroyTimer(frenzyTimer)
call RemoveSavedHandle(PLF_Hash,deadId,PLF_KEY_TIMER)
endif
call PLF_RemoveVisuals(deadUnit)
call PLF_RestoreBonuses(deadUnit)
endif
set remaining=0.00
set frenzyTimer=null
set killer=null
set deadUnit=null
endfunction
function InitTrig_PitLordFrenzy takes nothing returns nothing
local trigger castTrig
local trigger deathTrig
set PLF_Hash=InitHashtable()
set PLF_EffectHash=InitHashtable()
set castTrig=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(castTrig,EVENT_PLAYER_UNIT_SPELL_EFFECT)
call TriggerAddCondition(castTrig,Condition(function PLF_IsFrenzy))
call TriggerAddAction(castTrig,function PLF_Cast)
set deathTrig=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(deathTrig,EVENT_PLAYER_UNIT_DEATH)
call TriggerAddAction(deathTrig,function PLF_UnitDeath)
set castTrig=null
set deathTrig=null
endfunction
function Trig_____________________________________002_Actions takes nothing returns nothing
call SetUnitPositionLoc(GetEnteringUnit(),GetRectCenter(gg_rct________________015))
endfunction
function InitTrig_____________________________________002 takes nothing returns nothing
set gg_trg_____________________________________002=CreateTrigger()
call TriggerRegisterEnterRectSimple(gg_trg_____________________________________002,gg_rct________________012)
call TriggerAddAction(gg_trg_____________________________________002,function Trig_____________________________________002_Actions)
endfunction
function Trig_____________________________________002_____________________u_Actions takes nothing returns nothing
call SetUnitPositionLoc(GetEnteringUnit(),GetRectCenter(gg_rct________________013))
endfunction
function InitTrig_____________________________________002_____________________u takes nothing returns nothing
set gg_trg_____________________________________002_____________________u=CreateTrigger()
call TriggerRegisterEnterRectSimple(gg_trg_____________________________________002_____________________u,gg_rct________________014)
call TriggerAddAction(gg_trg_____________________________________002_____________________u,function Trig_____________________________________002_____________________u_Actions)
endfunction
function s__PainLaser__BurnData_BurnLoop takes nothing returns nothing
local integer i=0
local integer this
loop
exitwhen i>s__PainLaser__BurnData_burnCount
set this=s__PainLaser__BurnData_burnList[i]
if s__PainLaser__BurnData_target[this]==null or GetUnitState(s__PainLaser__BurnData_target[this],UNIT_STATE_LIFE)<=0.0 then
call DestroyEffect(s__PainLaser__BurnData_burnFX[this])
set s__PainLaser__BurnData_target[this]=null
set s__PainLaser__BurnData_caster[this]=null
set s__PainLaser__BurnData_burnList[i]=s__PainLaser__BurnData_burnList[s__PainLaser__BurnData_burnCount]
set s__PainLaser__BurnData_burnCount=s__PainLaser__BurnData_burnCount-1
call s__PainLaser__BurnData_deallocate(this)
set i=i-1
else
set s__PainLaser__BurnData_duration[this]=s__PainLaser__BurnData_duration[this]-0.03
set s__PainLaser__BurnData_nextTick[this]=s__PainLaser__BurnData_nextTick[this]-0.03
if s__PainLaser__BurnData_nextTick[this]<=0.0 then
set s__PainLaser__BurnData_nextTick[this]=1.0
call UnitDamageTarget(s__PainLaser__BurnData_caster[this],s__PainLaser__BurnData_target[this],PainLaser__BURN_DAMAGE,false,false,ATTACK_TYPE_NORMAL,DAMAGE_TYPE_MAGIC,null)
call DestroyEffect(AddSpecialEffectTarget("pivot.mdx",s__PainLaser__BurnData_target[this],"chest"))
endif
if s__PainLaser__BurnData_duration[this]<=0.0 then
call DestroyEffect(s__PainLaser__BurnData_burnFX[this])
set s__PainLaser__BurnData_target[this]=null
set s__PainLaser__BurnData_caster[this]=null
set s__PainLaser__BurnData_burnList[i]=s__PainLaser__BurnData_burnList[s__PainLaser__BurnData_burnCount]
set s__PainLaser__BurnData_burnCount=s__PainLaser__BurnData_burnCount-1
call s__PainLaser__BurnData_deallocate(this)
set i=i-1
endif
endif
set i=i+1
endloop
if s__PainLaser__BurnData_burnCount==-1 then
call PauseTimer(s__PainLaser__BurnData_burnTimer)
endif
endfunction
function s__PainLaser__BurnData_Add takes unit caster,unit target returns nothing
local integer this=s__PainLaser__BurnData__allocate()
set s__PainLaser__BurnData_target[this]=target
set s__PainLaser__BurnData_caster[this]=caster
set s__PainLaser__BurnData_duration[this]=PainLaser__BURN_DURATION
set s__PainLaser__BurnData_nextTick[this]=0.0
set s__PainLaser__BurnData_burnFX[this]=AddSpecialEffectTarget("pivot.mdx",target,"chest")
set s__PainLaser__BurnData_burnCount=s__PainLaser__BurnData_burnCount+1
set s__PainLaser__BurnData_burnList[s__PainLaser__BurnData_burnCount]=this
if s__PainLaser__BurnData_burnCount==0 then
call TimerStart(s__PainLaser__BurnData_burnTimer,0.03,true,function s__PainLaser__BurnData_BurnLoop)
endif
endfunction
function s__PainLaser__Laser_Stop takes integer this,integer i returns nothing
set s__PainLaser__Laser_Data[i]=s__PainLaser__Laser_Data[s__PainLaser__Laser_Count]
set s__PainLaser__Laser_Count=s__PainLaser__Laser_Count-1
if s__PainLaser__Laser_Count==-1 then
call PauseTimer(s__PainLaser__Laser_t)
endif
if s__PainLaser__Laser_missile[this]!=null then
call RemoveUnit(s__PainLaser__Laser_missile[this])
set s__PainLaser__Laser_missile[this]=null
endif
set s__PainLaser__Laser_caster[this]=null
call s__PainLaser__Laser_deallocate(this)
endfunction
function s__PainLaser__Laser_Loop takes nothing returns nothing
local integer i=0
local integer this
local group g
local unit u
local real height
loop
exitwhen i>s__PainLaser__Laser_Count
set this=s__PainLaser__Laser_Data[i]
if s__PainLaser__Laser_caster[this]==null or GetUnitState(s__PainLaser__Laser_caster[this],UNIT_STATE_LIFE)<=0.0 or s__PainLaser__Laser_hit[this]then
call s__PainLaser__Laser_Stop(this,i)
set i=i-1
else
set s__PainLaser__Laser_traveled[this]=s__PainLaser__Laser_traveled[this]+28.0
if s__PainLaser__Laser_traveled[this]>=s__PainLaser__Laser_distance[this]then
set s__PainLaser__Laser_hit[this]=true
call DestroyEffect(AddSpecialEffect("Abilities\\Spells\\Other\\Doom\\DoomDeath.mdl",s__PainLaser__Laser_x[this],s__PainLaser__Laser_y[this]))
else
set s__PainLaser__Laser_x[this]=s__PainLaser__Laser_x[this]+28.0*Cos(s__PainLaser__Laser_angle[this]*bj_DEGTORAD)
set s__PainLaser__Laser_y[this]=s__PainLaser__Laser_y[this]+28.0*Sin(s__PainLaser__Laser_angle[this]*bj_DEGTORAD)
set height=250.0-(s__PainLaser__Laser_traveled[this]/s__PainLaser__Laser_distance[this])*250.0
if height<0.0 then
set height=0.0
endif
call SetUnitX(s__PainLaser__Laser_missile[this],s__PainLaser__Laser_x[this])
call SetUnitY(s__PainLaser__Laser_missile[this],s__PainLaser__Laser_y[this])
call SetUnitFlyHeight(s__PainLaser__Laser_missile[this],height,0)
if ModuloReal(s__PainLaser__Laser_traveled[this],0.15)<0.05 then
endif
set g=CreateGroup()
call GroupEnumUnitsInRange(g,s__PainLaser__Laser_x[this],s__PainLaser__Laser_y[this],100.0,null)
set u=FirstOfGroup(g)
loop
exitwhen u==null
if IsUnitEnemy(u,GetOwningPlayer(s__PainLaser__Laser_caster[this]))and GetUnitState(u,UNIT_STATE_LIFE)>0.0 then
call UnitDamageTarget(s__PainLaser__Laser_caster[this],u,s__PainLaser__Laser_damage[this],false,false,ATTACK_TYPE_NORMAL,DAMAGE_TYPE_MAGIC,null)
call DestroyEffect(AddSpecialEffectTarget("Abilities\\Spells\\Other\\Doom\\DoomDeath.mdl",u,"origin"))
call DestroyEffect(AddSpecialEffectTarget("pivot.mdx",u,"chest"))
if GetUnitAbilityLevel(u,PainLaser__BURN_BUFF_ID)==0 then
call s__PainLaser__BurnData_Add(s__PainLaser__Laser_caster[this],u)
endif
set s__PainLaser__Laser_hit[this]=true
endif
call GroupRemoveUnit(g,u)
set u=FirstOfGroup(g)
endloop
call DestroyGroup(g)
endif
endif
set i=i+1
endloop
set u=null
set g=null
endfunction
function s__PainLaser__Laser_Start takes unit caster,real tx,real ty returns nothing
local integer this=s__PainLaser__Laser__allocate()
local real cx=GetUnitX(caster)
local real cy=GetUnitY(caster)
local real facing=GetUnitFacing(caster)*bj_DEGTORAD
local real dx=tx-cx
local real dy=ty-cy
local real angle=bj_RADTODEG*Atan2(dy,dx)
local real dist=SquareRoot(dx*dx+dy*dy)
local real startX=cx+80.0*Cos(facing)
local real startY=cy+80.0*Sin(facing)
local integer level=GetHeroLevel(caster)
if dist>PainLaser__LASER_RANGE then
set tx=cx+PainLaser__LASER_RANGE*Cos(angle*bj_DEGTORAD)
set ty=cy+PainLaser__LASER_RANGE*Sin(angle*bj_DEGTORAD)
set dist=PainLaser__LASER_RANGE
endif
set s__PainLaser__Laser_Count=s__PainLaser__Laser_Count+1
set s__PainLaser__Laser_Data[s__PainLaser__Laser_Count]=this
set s__PainLaser__Laser_caster[this]=caster
set s__PainLaser__Laser_angle[this]=angle
set s__PainLaser__Laser_distance[this]=dist
set s__PainLaser__Laser_traveled[this]=0.0
set s__PainLaser__Laser_hit[this]=false
set s__PainLaser__Laser_x[this]=startX
set s__PainLaser__Laser_y[this]=startY
set s__PainLaser__Laser_damage[this]=PainLaser__Damage_Base+PainLaser__Damage_Per_Level*(level-1)
set s__PainLaser__Laser_missile[this]=CreateUnit(GetOwningPlayer(caster),PainLaser__Laser_Id,startX,startY,angle)
call UnitAddAbility(s__PainLaser__Laser_missile[this],0x41726176)
call UnitRemoveAbility(s__PainLaser__Laser_missile[this],0x41726176)
call SetUnitFlyHeight(s__PainLaser__Laser_missile[this],250.0,0)
call SetUnitScale(s__PainLaser__Laser_missile[this],0.4,0.4,0.4)
call SetUnitVertexColor(s__PainLaser__Laser_missile[this],255,255,255,0)
call DestroyEffect(AddSpecialEffectTarget("Abilities\\Weapons\\RedDragonBreath\\RedDragonMissile.mdl",caster,"head"))
if s__PainLaser__Laser_Count==0 then
call TimerStart(s__PainLaser__Laser_t,0.03,true,function s__PainLaser__Laser_Loop)
endif
endfunction
function PainLaser__Cast takes nothing returns nothing
local unit caster=GetTriggerUnit()
local real tx=GetSpellTargetX()
local real ty=GetSpellTargetY()
call s__PainLaser__Laser_Start(caster,tx,ty)
set caster=null
endfunction
function PainLaser__Cond takes nothing returns boolean
return GetSpellAbilityId()==0x41303030
endfunction
function PainLaser__Init takes nothing returns nothing
local trigger t=CreateTrigger()
local integer i=0
loop
exitwhen i>11
call TriggerRegisterPlayerUnitEvent(t,Player(i),EVENT_PLAYER_UNIT_SPELL_EFFECT,null)
set i=i+1
endloop
call TriggerAddCondition(t,Condition(function PainLaser__Cond))
call TriggerAddAction(t,function PainLaser__Cast)
set t=null
endfunction
function s__HellScale__BurnData_BurnLoop takes nothing returns nothing
local integer i=0
local integer this
loop
exitwhen i>s__HellScale__BurnData_burnCount
set this=s__HellScale__BurnData_burnList[i]
if s__HellScale__BurnData_target[this]==null or GetUnitState(s__HellScale__BurnData_target[this],UNIT_STATE_LIFE)<=0.0 then
call DestroyEffect(s__HellScale__BurnData_burnFX[this])
set s__HellScale__BurnData_target[this]=null
set s__HellScale__BurnData_caster[this]=null
set s__HellScale__BurnData_burnList[i]=s__HellScale__BurnData_burnList[s__HellScale__BurnData_burnCount]
set s__HellScale__BurnData_burnCount=s__HellScale__BurnData_burnCount-1
call s__HellScale__BurnData_deallocate(this)
set i=i-1
else
set s__HellScale__BurnData_duration[this]=s__HellScale__BurnData_duration[this]-0.03
set s__HellScale__BurnData_nextTick[this]=s__HellScale__BurnData_nextTick[this]-0.03
if s__HellScale__BurnData_nextTick[this]<=0.0 then
set s__HellScale__BurnData_nextTick[this]=1.0
call UnitDamageTarget(s__HellScale__BurnData_caster[this],s__HellScale__BurnData_target[this],HellScale__BURN_DAMAGE,false,false,ATTACK_TYPE_NORMAL,DAMAGE_TYPE_MAGIC,null)
set s__HellScale__BurnData_tickFX[this]=AddSpecialEffectTarget("Doodads\\Cinematic\\FirePillarMedium\\FirePillarMedium.mdl",s__HellScale__BurnData_target[this],"chest")
call DestroyEffect(s__HellScale__BurnData_tickFX[this])
set s__HellScale__BurnData_sparkFX[this]=AddSpecialEffectTarget("Abilities\\Weapons\\RedDragonBreath\\RedDragonMissile.mdl",s__HellScale__BurnData_target[this],"origin")
call DestroyEffect(s__HellScale__BurnData_sparkFX[this])
endif
if s__HellScale__BurnData_duration[this]<=0.0 then
call DestroyEffect(s__HellScale__BurnData_burnFX[this])
set s__HellScale__BurnData_target[this]=null
set s__HellScale__BurnData_caster[this]=null
set s__HellScale__BurnData_burnList[i]=s__HellScale__BurnData_burnList[s__HellScale__BurnData_burnCount]
set s__HellScale__BurnData_burnCount=s__HellScale__BurnData_burnCount-1
call s__HellScale__BurnData_deallocate(this)
set i=i-1
endif
endif
set i=i+1
endloop
if s__HellScale__BurnData_burnCount==-1 then
call PauseTimer(s__HellScale__BurnData_burnTimer)
endif
endfunction
function s__HellScale__BurnData_Add takes unit dragon,unit enemy returns nothing
local integer this=s__HellScale__BurnData__allocate()
set s__HellScale__BurnData_target[this]=enemy
set s__HellScale__BurnData_caster[this]=dragon
set s__HellScale__BurnData_duration[this]=HellScale__BURN_DURATION
set s__HellScale__BurnData_nextTick[this]=0.0
set s__HellScale__BurnData_burnFX[this]=AddSpecialEffectTarget("Doodads\\Cinematic\\FirePillarMedium\\FirePillarMedium.mdl",enemy,"chest")
set s__HellScale__BurnData_burnCount=s__HellScale__BurnData_burnCount+1
set s__HellScale__BurnData_burnList[s__HellScale__BurnData_burnCount]=this
if s__HellScale__BurnData_burnCount==0 then
call TimerStart(s__HellScale__BurnData_burnTimer,0.03,true,function s__HellScale__BurnData_BurnLoop)
endif
endfunction
function HellScale__CanBurn takes unit dragon,unit attacker returns boolean
local integer key=GetHandleId(dragon)*10000+GetHandleId(attacker)
local real lastTime=LoadReal(HellScale__CooldownTable,key,0)
local real currentTime=TimerGetElapsed(HellScale__GameTimer)
if currentTime-lastTime>=HellScale__BURN_COOLDOWN then
call SaveReal(HellScale__CooldownTable,key,0,currentTime)
return true
endif
return false
endfunction
function HellScale__OnAttack takes nothing returns nothing
local unit dragon=GetTriggerUnit()
local unit attacker=GetAttacker()
local integer level
local real chance
local integer heroLevel
if attacker==null or IsUnitEnemy(attacker,GetOwningPlayer(dragon))==false then
set dragon=null
set attacker=null
set attacker=null
set dragon=null
return
endif
set level=GetUnitAbilityLevel(dragon,HellScale__SPELL_ID)
if level>0 and GetUnitAbilityLevel(dragon,HellScale__BUFF_ID)>0 then
set heroLevel=GetHeroLevel(dragon)
set chance=HellScale__CHANCE_BASE+heroLevel*HellScale__CHANCE_PER_LEVEL
if chance>75.0 then
set chance=75.0
endif
if HellScale__CanBurn(dragon,attacker)and GetRandomReal(0.0,100.0)<=chance then
call s__HellScale__BurnData_Add(dragon,attacker)
call DestroyEffect(AddSpecialEffectTarget("Doodads\\Cinematic\\FirePillarMedium\\FirePillarMedium.mdl",attacker,"chest"))
call DestroyEffect(AddSpecialEffectTarget("Abilities\\Weapons\\RedDragonBreath\\RedDragonMissile.mdl",attacker,"origin"))
endif
endif
set dragon=null
set attacker=null
endfunction
function HellScale__AttackCond takes nothing returns boolean
call HellScale__OnAttack()
return false
endfunction
function HellScale__Init takes nothing returns nothing
local trigger attackTrig=CreateTrigger()
local integer i=0
call TimerStart(HellScale__GameTimer,3600.0,false,null)
loop
exitwhen i>11
call TriggerRegisterPlayerUnitEvent(attackTrig,Player(i),EVENT_PLAYER_UNIT_ATTACKED,null)
set i=i+1
endloop
call TriggerAddCondition(attackTrig,Condition(function HellScale__AttackCond))
set attackTrig=null
endfunction
function AshFlight__IsOutside takes real x,real y returns boolean
if x<=AshFlight__WorldMinX+AshFlight__UNIT_RADIUS+AshFlight__MAP_MARGIN then
return true
endif
if x>=AshFlight__WorldMaxX-AshFlight__UNIT_RADIUS-AshFlight__MAP_MARGIN then
return true
endif
if y<=AshFlight__WorldMinY+AshFlight__UNIT_RADIUS+AshFlight__MAP_MARGIN then
return true
endif
if y>=AshFlight__WorldMaxY-AshFlight__UNIT_RADIUS-AshFlight__MAP_MARGIN then
return true
endif
return false
endfunction
function AshFlight__IsBlocked takes real x,real y returns boolean
if AshFlight__IsOutside(x,y)then
return true
endif
if IsTerrainPathable(x,y,PATHING_TYPE_WALKABILITY)then
return true
endif
if IsTerrainPathable(x,y,PATHING_TYPE_FLYABILITY)then
return true
endif
return false
endfunction
function AshFlight__MoveUnit takes unit u,real dx,real dy returns nothing
local real x
local real y
local real nx
local real ny
local real oldX
local real oldY
set x=GetUnitX(u)
set y=GetUnitY(u)
set nx=x+dx
set ny=y+dy
if nx<AshFlight__WorldMinX+AshFlight__UNIT_RADIUS+AshFlight__MAP_MARGIN then
set nx=AshFlight__WorldMinX+AshFlight__UNIT_RADIUS+AshFlight__MAP_MARGIN
endif
if nx>AshFlight__WorldMaxX-AshFlight__UNIT_RADIUS-AshFlight__MAP_MARGIN then
set nx=AshFlight__WorldMaxX-AshFlight__UNIT_RADIUS-AshFlight__MAP_MARGIN
endif
if ny<AshFlight__WorldMinY+AshFlight__UNIT_RADIUS+AshFlight__MAP_MARGIN then
set ny=AshFlight__WorldMinY+AshFlight__UNIT_RADIUS+AshFlight__MAP_MARGIN
endif
if ny>AshFlight__WorldMaxY-AshFlight__UNIT_RADIUS-AshFlight__MAP_MARGIN then
set ny=AshFlight__WorldMaxY-AshFlight__UNIT_RADIUS-AshFlight__MAP_MARGIN
endif
if AshFlight__IsBlocked(nx,ny)then
if not AshFlight__IsBlocked(nx,y)then
set oldX=GetUnitX(u)
call SetUnitPosition(u,nx,y)
if GetUnitX(u)==oldX then
call SetUnitPosition(u,x,y)
endif
endif
if not AshFlight__IsBlocked(x,ny)then
set oldY=GetUnitY(u)
call SetUnitPosition(u,x,ny)
if GetUnitY(u)==oldY then
call SetUnitPosition(u,x,y)
endif
endif
return
endif
call SetUnitPosition(u,nx,ny)
endfunction
function AshFlight__RemoveFlight takes integer this returns nothing
local integer i
local integer p
if s__AshFlight__FlightData_caster[this]==null then
call s__AshFlight__FlightData_deallocate(this)
return
endif
set p=GetPlayerId(GetOwningPlayer(s__AshFlight__FlightData_caster[this]))
set AshFlight__Flying[p]=false
set AshFlight__Moving[p]=false
set AshFlight__Casting[p]=false
call UnitRemoveAbility(s__AshFlight__FlightData_caster[this],AshFlight__CANCEL_ID)
call UnitAddAbility(s__AshFlight__FlightData_caster[this],0x41726176)
call UnitRemoveAbility(s__AshFlight__FlightData_caster[this],0x41726176)
call SetUnitPathing(s__AshFlight__FlightData_caster[this],true)
call SetUnitFlyHeight(s__AshFlight__FlightData_caster[this],0.00,0.00)
if s__AshFlight__FlightData_bodyFX[this]!=null then
call DestroyEffect(s__AshFlight__FlightData_bodyFX[this])
set s__AshFlight__FlightData_bodyFX[this]=null
endif
call DestroyEffect(AddSpecialEffectTarget("WhiteWave.mdx",s__AshFlight__FlightData_caster[this],"origin"))
set i=0
loop
exitwhen i>s__AshFlight__FlightData_flightCount
if s__AshFlight__FlightData_flightList[i]==this then
set s__AshFlight__FlightData_flightList[i]=s__AshFlight__FlightData_flightList[s__AshFlight__FlightData_flightCount]
set s__AshFlight__FlightData_flightCount=s__AshFlight__FlightData_flightCount-1
exitwhen true
endif
set i=i+1
endloop
set s__AshFlight__FlightData_caster[this]=null
call s__AshFlight__FlightData_deallocate(this)
endfunction
function AshFlight__CancelFlight takes unit u returns nothing
local integer i
local integer this
set i=0
loop
exitwhen i>s__AshFlight__FlightData_flightCount
set this=s__AshFlight__FlightData_flightList[i]
if s__AshFlight__FlightData_caster[this]==u then
call AshFlight__RemoveFlight(this)
call IssueImmediateOrder(u,"stop")
call ResetUnitAnimation(u)
return
endif
set i=i+1
endloop
endfunction
function AshFlight__FlightLoop takes nothing returns nothing
local integer i
local integer p
local integer this
local unit u
local real dx
local real dy
local real moveX
local real moveY
local real targetAngle
local real angleDiff
local real hp
local real maxHP
set i=0
loop
exitwhen i>s__AshFlight__FlightData_flightCount
set this=s__AshFlight__FlightData_flightList[i]
if s__AshFlight__FlightData_caster[this]==null then
set s__AshFlight__FlightData_flightList[i]=s__AshFlight__FlightData_flightList[s__AshFlight__FlightData_flightCount]
set s__AshFlight__FlightData_flightCount=s__AshFlight__FlightData_flightCount-1
call s__AshFlight__FlightData_deallocate(this)
set i=i-1
else
set u=s__AshFlight__FlightData_caster[this]
set p=GetPlayerId(GetOwningPlayer(u))
set hp=GetUnitState(u,UNIT_STATE_LIFE)
set maxHP=GetUnitState(u,UNIT_STATE_MAX_LIFE)
if hp<=0.00 then
call AshFlight__RemoveFlight(this)
set i=i-1
elseif GetUnitAbilityLevel(u,AshFlight__STUN_BUFF)>0 then
call AshFlight__RemoveFlight(this)
set i=i-1
elseif hp<=maxHP*AshFlight__HP_THRESHOLD then
call AshFlight__RemoveFlight(this)
set i=i-1
else
set s__AshFlight__FlightData_duration[this]=s__AshFlight__FlightData_duration[this]+AshFlight__PERIOD
if s__AshFlight__FlightData_duration[this]>=s__AshFlight__FlightData_maxDuration[this]then
call AshFlight__RemoveFlight(this)
set i=i-1
else
if not AshFlight__Casting[p]then
if AshFlight__Moving[p]then
set dx=AshFlight__TargetX[p]-GetUnitX(u)
set dy=AshFlight__TargetY[p]-GetUnitY(u)
if dx!=0.00 or dy!=0.00 then
set targetAngle=bj_RADTODEG*Atan2(dy,dx)
set angleDiff=targetAngle-s__AshFlight__FlightData_angle[this]
if angleDiff>180.00 then
set angleDiff=angleDiff-360.00
endif
if angleDiff<-180.00 then
set angleDiff=angleDiff+360.00
endif
set s__AshFlight__FlightData_angle[this]=s__AshFlight__FlightData_angle[this]+angleDiff*0.15
if s__AshFlight__FlightData_angle[this]>=360.00 then
set s__AshFlight__FlightData_angle[this]=s__AshFlight__FlightData_angle[this]-360.00
endif
if s__AshFlight__FlightData_angle[this]<0.00 then
set s__AshFlight__FlightData_angle[this]=s__AshFlight__FlightData_angle[this]+360.00
endif
endif
endif
if s__AshFlight__FlightData_speed[this]<s__AshFlight__FlightData_maxSpeed[this]then
set s__AshFlight__FlightData_speed[this]=s__AshFlight__FlightData_speed[this]+AshFlight__ACCELERATION
if s__AshFlight__FlightData_speed[this]>s__AshFlight__FlightData_maxSpeed[this]then
set s__AshFlight__FlightData_speed[this]=s__AshFlight__FlightData_maxSpeed[this]
endif
endif
set moveX=Cos(s__AshFlight__FlightData_angle[this]*bj_DEGTORAD)*s__AshFlight__FlightData_speed[this]
set moveY=Sin(s__AshFlight__FlightData_angle[this]*bj_DEGTORAD)*s__AshFlight__FlightData_speed[this]
call AshFlight__MoveUnit(u,moveX,moveY)
endif
call SetUnitFlyHeight(u,AshFlight__FLIGHT_HEIGHT,0.00)
call SetUnitFacing(u,s__AshFlight__FlightData_angle[this])
if s__AshFlight__FlightData_bodyFX[this]==null then
set s__AshFlight__FlightData_bodyFX[this]=AddSpecialEffectTarget("Firebolt Classic.mdx",u,"chest")
endif
endif
endif
endif
set u=null
set i=i+1
endloop
if s__AshFlight__FlightData_flightCount==-1 then
call PauseTimer(AshFlight__FlightTimer)
endif
endfunction
function AshFlight__StartFlight takes unit u,real tx,real ty returns nothing
local integer this
local integer p
local integer heroLevel
local real dx
local real dy
set p=GetPlayerId(GetOwningPlayer(u))
if AshFlight__Flying[p]then
return
endif
set this=s__AshFlight__FlightData__allocate()
set s__AshFlight__FlightData_caster[this]=u
set heroLevel=GetHeroLevel(u)
set s__AshFlight__FlightData_speed[this]=AshFlight__START_SPEED
set s__AshFlight__FlightData_maxSpeed[this]=AshFlight__BASE_MAX_SPEED+AshFlight__SPEED_PER_LEVEL*heroLevel
set s__AshFlight__FlightData_maxDuration[this]=AshFlight__BASE_FLIGHT_DURATION+AshFlight__FLIGHT_TIME_PER_LEVEL*heroLevel
set s__AshFlight__FlightData_duration[this]=0.00
set dx=tx-GetUnitX(u)
set dy=ty-GetUnitY(u)
if dx==0.00 and dy==0.00 then
set s__AshFlight__FlightData_angle[this]=GetUnitFacing(u)
else
set s__AshFlight__FlightData_angle[this]=bj_RADTODEG*Atan2(dy,dx)
endif
call UnitAddAbility(u,0x41726176)
call SetUnitPathing(u,true)
call SetUnitFlyHeight(u,AshFlight__FLIGHT_HEIGHT,0.00)
call UnitAddAbility(u,AshFlight__CANCEL_ID)
call UnitRemoveAbility(u,0x41726176)
set AshFlight__TargetX[p]=tx
set AshFlight__TargetY[p]=ty
set AshFlight__Moving[p]=true
set AshFlight__Flying[p]=true
set AshFlight__Casting[p]=false
set s__AshFlight__FlightData_bodyFX[this]=AddSpecialEffectTarget("Firebolt Classic.mdx",u,"chest")
call DestroyEffect(AddSpecialEffectTarget("WhiteWave.mdx",u,"origin"))
set s__AshFlight__FlightData_flightCount=s__AshFlight__FlightData_flightCount+1
set s__AshFlight__FlightData_flightList[s__AshFlight__FlightData_flightCount]=this
if s__AshFlight__FlightData_flightCount==0 then
call TimerStart(AshFlight__FlightTimer,AshFlight__PERIOD,true,function AshFlight__FlightLoop)
endif
endfunction
function AshFlight__SpellCastAction takes nothing returns nothing
local unit u
local integer p
local integer spellId
set u=GetTriggerUnit()
set p=GetPlayerId(GetOwningPlayer(u))
set spellId=GetSpellAbilityId()
if AshFlight__Flying[p]then
if spellId==AshFlight__CANCEL_ID then
call AshFlight__CancelFlight(u)
else
set AshFlight__Casting[p]=true
set AshFlight__Moving[p]=false
endif
endif
set u=null
endfunction
function AshFlight__SpellEffectAction takes nothing returns nothing
local unit u
local integer p
set u=GetTriggerUnit()
set p=GetPlayerId(GetOwningPlayer(u))
if not AshFlight__Flying[p]then
if GetSpellAbilityId()==AshFlight__SPELL_ID then
call AshFlight__StartFlight(u,GetSpellTargetX(),GetSpellTargetY())
endif
else
if GetSpellAbilityId()!=AshFlight__CANCEL_ID then
set AshFlight__Casting[p]=false
endif
endif
set u=null
endfunction
function AshFlight__PointOrderCond takes nothing returns boolean
return GetIssuedOrderId()==String2OrderIdBJ("move")or GetIssuedOrderId()==String2OrderIdBJ("smart")
endfunction
function AshFlight__PointOrderAction takes nothing returns nothing
local unit u
local integer p
set u=GetOrderedUnit()
set p=GetPlayerId(GetOwningPlayer(u))
if AshFlight__Flying[p]then
set AshFlight__TargetX[p]=GetOrderPointX()
set AshFlight__TargetY[p]=GetOrderPointY()
set AshFlight__Moving[p]=true
set AshFlight__Casting[p]=false
endif
set u=null
endfunction
function AshFlight__Init takes nothing returns nothing
local trigger spellCastTrig
local trigger spellEffectTrig
local trigger orderTrig
local rect world
local integer i
set world=GetWorldBounds()
set AshFlight__WorldMinX=GetRectMinX(world)
set AshFlight__WorldMaxX=GetRectMaxX(world)
set AshFlight__WorldMinY=GetRectMinY(world)
set AshFlight__WorldMaxY=GetRectMaxY(world)
call RemoveRect(world)
set world=null
set spellCastTrig=CreateTrigger()
set spellEffectTrig=CreateTrigger()
set orderTrig=CreateTrigger()
set i=0
loop
exitwhen i>11
call TriggerRegisterPlayerUnitEvent(spellCastTrig,Player(i),EVENT_PLAYER_UNIT_SPELL_CAST,null)
call TriggerRegisterPlayerUnitEvent(spellEffectTrig,Player(i),EVENT_PLAYER_UNIT_SPELL_EFFECT,null)
call TriggerRegisterPlayerUnitEvent(orderTrig,Player(i),EVENT_PLAYER_UNIT_ISSUED_POINT_ORDER,null)
set i=i+1
endloop
call TriggerAddAction(spellCastTrig,function AshFlight__SpellCastAction)
call TriggerAddAction(spellEffectTrig,function AshFlight__SpellEffectAction)
call TriggerAddCondition(orderTrig,Condition(function AshFlight__PointOrderCond))
call TriggerAddAction(orderTrig,function AshFlight__PointOrderAction)
set spellCastTrig=null
set spellEffectTrig=null
set orderTrig=null
endfunction
function InitCustomTriggers takes nothing returns nothing
call InitTrig_____________________________________001_____________________u()
call InitTrig_____________________________________001()
call InitTrig_MapOptimizer()
call InitTrig_efe()
call InitTrig_vwvw()
call InitTrig_BloodWell()
call InitTrig_PitLordBlood()
call InitTrig_PitLordFrenzy()
call InitTrig_____________________________________002()
call InitTrig_____________________________________002_____________________u()
endfunction
function RunInitializationTriggers takes nothing returns nothing
call ConditionalTriggerExecute(gg_trg_____________________________________001)
endfunction
function InitCustomPlayerSlots takes nothing returns nothing
call SetPlayerStartLocation(Player(0),0)
call ForcePlayerStartLocation(Player(0),0)
call SetPlayerColor(Player(0),ConvertPlayerColor(0))
call SetPlayerRacePreference(Player(0),RACE_PREF_HUMAN)
call SetPlayerRaceSelectable(Player(0),true)
call SetPlayerController(Player(0),MAP_CONTROL_USER)
call SetPlayerStartLocation(Player(1),1)
call ForcePlayerStartLocation(Player(1),1)
call SetPlayerColor(Player(1),ConvertPlayerColor(1))
call SetPlayerRacePreference(Player(1),RACE_PREF_HUMAN)
call SetPlayerRaceSelectable(Player(1),true)
call SetPlayerController(Player(1),MAP_CONTROL_USER)
call SetPlayerStartLocation(Player(2),2)
call ForcePlayerStartLocation(Player(2),2)
call SetPlayerColor(Player(2),ConvertPlayerColor(2))
call SetPlayerRacePreference(Player(2),RACE_PREF_HUMAN)
call SetPlayerRaceSelectable(Player(2),true)
call SetPlayerController(Player(2),MAP_CONTROL_USER)
call SetPlayerStartLocation(Player(3),3)
call ForcePlayerStartLocation(Player(3),3)
call SetPlayerColor(Player(3),ConvertPlayerColor(3))
call SetPlayerRacePreference(Player(3),RACE_PREF_HUMAN)
call SetPlayerRaceSelectable(Player(3),true)
call SetPlayerController(Player(3),MAP_CONTROL_USER)
call SetPlayerStartLocation(Player(4),4)
call ForcePlayerStartLocation(Player(4),4)
call SetPlayerColor(Player(4),ConvertPlayerColor(4))
call SetPlayerRacePreference(Player(4),RACE_PREF_HUMAN)
call SetPlayerRaceSelectable(Player(4),true)
call SetPlayerController(Player(4),MAP_CONTROL_USER)
call SetPlayerStartLocation(Player(5),5)
call ForcePlayerStartLocation(Player(5),5)
call SetPlayerColor(Player(5),ConvertPlayerColor(5))
call SetPlayerRacePreference(Player(5),RACE_PREF_HUMAN)
call SetPlayerRaceSelectable(Player(5),true)
call SetPlayerController(Player(5),MAP_CONTROL_USER)
call SetPlayerStartLocation(Player(6),6)
call ForcePlayerStartLocation(Player(6),6)
call SetPlayerColor(Player(6),ConvertPlayerColor(6))
call SetPlayerRacePreference(Player(6),RACE_PREF_HUMAN)
call SetPlayerRaceSelectable(Player(6),true)
call SetPlayerController(Player(6),MAP_CONTROL_USER)
call SetPlayerStartLocation(Player(7),7)
call ForcePlayerStartLocation(Player(7),7)
call SetPlayerColor(Player(7),ConvertPlayerColor(7))
call SetPlayerRacePreference(Player(7),RACE_PREF_HUMAN)
call SetPlayerRaceSelectable(Player(7),true)
call SetPlayerController(Player(7),MAP_CONTROL_USER)
call SetPlayerStartLocation(Player(8),8)
call ForcePlayerStartLocation(Player(8),8)
call SetPlayerColor(Player(8),ConvertPlayerColor(8))
call SetPlayerRacePreference(Player(8),RACE_PREF_HUMAN)
call SetPlayerRaceSelectable(Player(8),true)
call SetPlayerController(Player(8),MAP_CONTROL_USER)
call SetPlayerStartLocation(Player(9),9)
call ForcePlayerStartLocation(Player(9),9)
call SetPlayerColor(Player(9),ConvertPlayerColor(9))
call SetPlayerRacePreference(Player(9),RACE_PREF_HUMAN)
call SetPlayerRaceSelectable(Player(9),true)
call SetPlayerController(Player(9),MAP_CONTROL_USER)
call SetPlayerStartLocation(Player(10),10)
call ForcePlayerStartLocation(Player(10),10)
call SetPlayerColor(Player(10),ConvertPlayerColor(10))
call SetPlayerRacePreference(Player(10),RACE_PREF_UNDEAD)
call SetPlayerRaceSelectable(Player(10),true)
call SetPlayerController(Player(10),MAP_CONTROL_COMPUTER)
call SetPlayerStartLocation(Player(11),11)
call ForcePlayerStartLocation(Player(11),11)
call SetPlayerColor(Player(11),ConvertPlayerColor(11))
call SetPlayerRacePreference(Player(11),RACE_PREF_UNDEAD)
call SetPlayerRaceSelectable(Player(11),true)
call SetPlayerController(Player(11),MAP_CONTROL_COMPUTER)
endfunction
function InitCustomTeams takes nothing returns nothing
call SetPlayerTeam(Player(0),0)
call SetPlayerState(Player(0),PLAYER_STATE_ALLIED_VICTORY,1)
call SetPlayerTeam(Player(1),0)
call SetPlayerState(Player(1),PLAYER_STATE_ALLIED_VICTORY,1)
call SetPlayerTeam(Player(2),0)
call SetPlayerState(Player(2),PLAYER_STATE_ALLIED_VICTORY,1)
call SetPlayerTeam(Player(3),0)
call SetPlayerState(Player(3),PLAYER_STATE_ALLIED_VICTORY,1)
call SetPlayerTeam(Player(4),0)
call SetPlayerState(Player(4),PLAYER_STATE_ALLIED_VICTORY,1)
call SetPlayerAllianceStateAllyBJ(Player(0),Player(1),true)
call SetPlayerAllianceStateAllyBJ(Player(0),Player(2),true)
call SetPlayerAllianceStateAllyBJ(Player(0),Player(3),true)
call SetPlayerAllianceStateAllyBJ(Player(0),Player(4),true)
call SetPlayerAllianceStateAllyBJ(Player(1),Player(0),true)
call SetPlayerAllianceStateAllyBJ(Player(1),Player(2),true)
call SetPlayerAllianceStateAllyBJ(Player(1),Player(3),true)
call SetPlayerAllianceStateAllyBJ(Player(1),Player(4),true)
call SetPlayerAllianceStateAllyBJ(Player(2),Player(0),true)
call SetPlayerAllianceStateAllyBJ(Player(2),Player(1),true)
call SetPlayerAllianceStateAllyBJ(Player(2),Player(3),true)
call SetPlayerAllianceStateAllyBJ(Player(2),Player(4),true)
call SetPlayerAllianceStateAllyBJ(Player(3),Player(0),true)
call SetPlayerAllianceStateAllyBJ(Player(3),Player(1),true)
call SetPlayerAllianceStateAllyBJ(Player(3),Player(2),true)
call SetPlayerAllianceStateAllyBJ(Player(3),Player(4),true)
call SetPlayerAllianceStateAllyBJ(Player(4),Player(0),true)
call SetPlayerAllianceStateAllyBJ(Player(4),Player(1),true)
call SetPlayerAllianceStateAllyBJ(Player(4),Player(2),true)
call SetPlayerAllianceStateAllyBJ(Player(4),Player(3),true)
call SetPlayerAllianceStateVisionBJ(Player(0),Player(1),true)
call SetPlayerAllianceStateVisionBJ(Player(0),Player(2),true)
call SetPlayerAllianceStateVisionBJ(Player(0),Player(3),true)
call SetPlayerAllianceStateVisionBJ(Player(0),Player(4),true)
call SetPlayerAllianceStateVisionBJ(Player(1),Player(0),true)
call SetPlayerAllianceStateVisionBJ(Player(1),Player(2),true)
call SetPlayerAllianceStateVisionBJ(Player(1),Player(3),true)
call SetPlayerAllianceStateVisionBJ(Player(1),Player(4),true)
call SetPlayerAllianceStateVisionBJ(Player(2),Player(0),true)
call SetPlayerAllianceStateVisionBJ(Player(2),Player(1),true)
call SetPlayerAllianceStateVisionBJ(Player(2),Player(3),true)
call SetPlayerAllianceStateVisionBJ(Player(2),Player(4),true)
call SetPlayerAllianceStateVisionBJ(Player(3),Player(0),true)
call SetPlayerAllianceStateVisionBJ(Player(3),Player(1),true)
call SetPlayerAllianceStateVisionBJ(Player(3),Player(2),true)
call SetPlayerAllianceStateVisionBJ(Player(3),Player(4),true)
call SetPlayerAllianceStateVisionBJ(Player(4),Player(0),true)
call SetPlayerAllianceStateVisionBJ(Player(4),Player(1),true)
call SetPlayerAllianceStateVisionBJ(Player(4),Player(2),true)
call SetPlayerAllianceStateVisionBJ(Player(4),Player(3),true)
call SetPlayerTeam(Player(10),1)
call SetPlayerTeam(Player(11),1)
call SetPlayerTeam(Player(5),2)
call SetPlayerState(Player(5),PLAYER_STATE_ALLIED_VICTORY,1)
call SetPlayerTeam(Player(6),2)
call SetPlayerState(Player(6),PLAYER_STATE_ALLIED_VICTORY,1)
call SetPlayerTeam(Player(7),2)
call SetPlayerState(Player(7),PLAYER_STATE_ALLIED_VICTORY,1)
call SetPlayerTeam(Player(8),2)
call SetPlayerState(Player(8),PLAYER_STATE_ALLIED_VICTORY,1)
call SetPlayerTeam(Player(9),2)
call SetPlayerState(Player(9),PLAYER_STATE_ALLIED_VICTORY,1)
call SetPlayerAllianceStateAllyBJ(Player(5),Player(6),true)
call SetPlayerAllianceStateAllyBJ(Player(5),Player(7),true)
call SetPlayerAllianceStateAllyBJ(Player(5),Player(8),true)
call SetPlayerAllianceStateAllyBJ(Player(5),Player(9),true)
call SetPlayerAllianceStateAllyBJ(Player(6),Player(5),true)
call SetPlayerAllianceStateAllyBJ(Player(6),Player(7),true)
call SetPlayerAllianceStateAllyBJ(Player(6),Player(8),true)
call SetPlayerAllianceStateAllyBJ(Player(6),Player(9),true)
call SetPlayerAllianceStateAllyBJ(Player(7),Player(5),true)
call SetPlayerAllianceStateAllyBJ(Player(7),Player(6),true)
call SetPlayerAllianceStateAllyBJ(Player(7),Player(8),true)
call SetPlayerAllianceStateAllyBJ(Player(7),Player(9),true)
call SetPlayerAllianceStateAllyBJ(Player(8),Player(5),true)
call SetPlayerAllianceStateAllyBJ(Player(8),Player(6),true)
call SetPlayerAllianceStateAllyBJ(Player(8),Player(7),true)
call SetPlayerAllianceStateAllyBJ(Player(8),Player(9),true)
call SetPlayerAllianceStateAllyBJ(Player(9),Player(5),true)
call SetPlayerAllianceStateAllyBJ(Player(9),Player(6),true)
call SetPlayerAllianceStateAllyBJ(Player(9),Player(7),true)
call SetPlayerAllianceStateAllyBJ(Player(9),Player(8),true)
call SetPlayerAllianceStateVisionBJ(Player(5),Player(6),true)
call SetPlayerAllianceStateVisionBJ(Player(5),Player(7),true)
call SetPlayerAllianceStateVisionBJ(Player(5),Player(8),true)
call SetPlayerAllianceStateVisionBJ(Player(5),Player(9),true)
call SetPlayerAllianceStateVisionBJ(Player(6),Player(5),true)
call SetPlayerAllianceStateVisionBJ(Player(6),Player(7),true)
call SetPlayerAllianceStateVisionBJ(Player(6),Player(8),true)
call SetPlayerAllianceStateVisionBJ(Player(6),Player(9),true)
call SetPlayerAllianceStateVisionBJ(Player(7),Player(5),true)
call SetPlayerAllianceStateVisionBJ(Player(7),Player(6),true)
call SetPlayerAllianceStateVisionBJ(Player(7),Player(8),true)
call SetPlayerAllianceStateVisionBJ(Player(7),Player(9),true)
call SetPlayerAllianceStateVisionBJ(Player(8),Player(5),true)
call SetPlayerAllianceStateVisionBJ(Player(8),Player(6),true)
call SetPlayerAllianceStateVisionBJ(Player(8),Player(7),true)
call SetPlayerAllianceStateVisionBJ(Player(8),Player(9),true)
call SetPlayerAllianceStateVisionBJ(Player(9),Player(5),true)
call SetPlayerAllianceStateVisionBJ(Player(9),Player(6),true)
call SetPlayerAllianceStateVisionBJ(Player(9),Player(7),true)
call SetPlayerAllianceStateVisionBJ(Player(9),Player(8),true)
endfunction
function InitAllyPriorities takes nothing returns nothing
call SetStartLocPrioCount(0,1)
call SetStartLocPrio(0,0,7,MAP_LOC_PRIO_HIGH)
call SetStartLocPrioCount(1,1)
call SetStartLocPrio(1,0,5,MAP_LOC_PRIO_HIGH)
call SetStartLocPrioCount(2,1)
call SetStartLocPrio(2,0,9,MAP_LOC_PRIO_HIGH)
call SetStartLocPrioCount(3,3)
call SetStartLocPrio(3,0,2,MAP_LOC_PRIO_HIGH)
call SetStartLocPrio(3,1,6,MAP_LOC_PRIO_HIGH)
call SetStartLocPrio(3,2,9,MAP_LOC_PRIO_LOW)
call SetStartLocPrioCount(4,3)
call SetStartLocPrio(4,0,1,MAP_LOC_PRIO_HIGH)
call SetStartLocPrio(4,1,5,MAP_LOC_PRIO_HIGH)
call SetStartLocPrio(4,2,8,MAP_LOC_PRIO_HIGH)
call SetStartLocPrioCount(5,1)
call SetStartLocPrio(5,0,1,MAP_LOC_PRIO_HIGH)
call SetStartLocPrioCount(6,4)
call SetStartLocPrio(6,0,1,MAP_LOC_PRIO_HIGH)
call SetStartLocPrio(6,1,5,MAP_LOC_PRIO_LOW)
call SetStartLocPrio(6,2,8,MAP_LOC_PRIO_LOW)
call SetStartLocPrio(6,3,9,MAP_LOC_PRIO_LOW)
call SetStartLocPrioCount(7,2)
call SetStartLocPrio(7,0,0,MAP_LOC_PRIO_HIGH)
call SetStartLocPrio(7,1,8,MAP_LOC_PRIO_LOW)
call SetStartLocPrioCount(8,3)
call SetStartLocPrio(8,0,1,MAP_LOC_PRIO_HIGH)
call SetStartLocPrio(8,1,5,MAP_LOC_PRIO_LOW)
call SetStartLocPrio(8,2,6,MAP_LOC_PRIO_LOW)
call SetStartLocPrioCount(9,1)
call SetStartLocPrio(9,0,2,MAP_LOC_PRIO_HIGH)
endfunction
function main takes nothing returns nothing
call SetCameraBounds(-17664.0+GetCameraMargin(CAMERA_MARGIN_LEFT),-17920.0+GetCameraMargin(CAMERA_MARGIN_BOTTOM),17664.0-GetCameraMargin(CAMERA_MARGIN_RIGHT),17408.0-GetCameraMargin(CAMERA_MARGIN_TOP),-17664.0+GetCameraMargin(CAMERA_MARGIN_LEFT),17408.0-GetCameraMargin(CAMERA_MARGIN_TOP),17664.0-GetCameraMargin(CAMERA_MARGIN_RIGHT),-17920.0+GetCameraMargin(CAMERA_MARGIN_BOTTOM))
call SetDayNightModels("Environment\\DNC\\DNCLordaeron\\DNCLordaeronTerrain\\DNCLordaeronTerrain.mdl","Environment\\DNC\\DNCLordaeron\\DNCLordaeronUnit\\DNCLordaeronUnit.mdl")
call NewSoundEnvironment("Default")
call SetAmbientDaySound("LordaeronSummerDay")
call SetAmbientNightSound("LordaeronSummerNight")
call SetMapMusic("Music",true,0)
call InitSounds()
call CreateRegions()
call CreateCameras()
call CreateAllUnits()
call InitBlizzard()
call ExecuteFunc("jasshelper__initstructs6622000")
call PainLaser__Init()
call HellScale__Init()
call AshFlight__Init()
call InitGlobals()
call InitCustomTriggers()
call RunInitializationTriggers()
endfunction
function config takes nothing returns nothing
call SetMapName("Еще одна карта")
call SetMapDescription("Описание отсутствует")
call SetPlayers(12)
call SetTeams(12)
call SetGamePlacement(MAP_PLACEMENT_TEAMS_TOGETHER)
call DefineStartLocation(0,9088.0,-7680.0)
call DefineStartLocation(1,64.0,6784.0)
call DefineStartLocation(2,4672.0,16256.0)
call DefineStartLocation(3,15680.0,16320.0)
call DefineStartLocation(4,-8192.0,2304.0)
call DefineStartLocation(5,-1984.0,8256.0)
call DefineStartLocation(6,5632.0,7168.0)
call DefineStartLocation(7,3904.0,-5568.0)
call DefineStartLocation(8,384.0,1728.0)
call DefineStartLocation(9,2112.0,13568.0)
call DefineStartLocation(10,3264.0,-6336.0)
call DefineStartLocation(11,4032.0,4608.0)
call InitCustomPlayerSlots()
call InitCustomTeams()
call InitAllyPriorities()
endfunction
function jasshelper__initstructs6622000 takes nothing returns nothing
endfunction