globals
real udg_wawt=0
player udg_Instagator=null
integer udg_CountForTournamet=0
timer udg_Compteur1=null
leaderboard udg_Tableaudescore=null
integer array udg_Col_vo_units
player array udg_Player
force udg_Group=null
integer udg_Total_hero=0
integer array udg_Random_system
force udg_Players_hero=null
boolean array udg_Can_pick
integer udg_Random_Hero=0
integer array udg_PlayersCount
force array udg_PlayersForce
multiboard udg_MultiBoard=null
integer udg_List=0
integer array udg_Kill
integer array udg_Death
integer array udg_Kills
integer array udg_Deaths
integer udg_i=0
unit array udg_Dying
integer udg_Otbor=0
integer udg_oj=0
unit array udg_Ojuvlen
rect gg_rct_NerubianA1Ext=null
rect gg_rct_NerubianA1move=null
rect gg_rct_NerubianB2Ext=null
rect gg_rct_NerubianB2move=null
rect gg_rct_NerubianC3Ext=null
rect gg_rct_NerubianC3move=null
rect gg_rct_NorthrendSnow=null
rect gg_rct_NorthrendSnow2=null
rect gg_rct_OutlandExt=null
rect gg_rct_OutlandMove=null
rect gg_rct_SpawnPoint_Broken_isles=null
rect gg_rct_SpawnPoint_EasternKingdom1=null
rect gg_rct_SpawnPoint_EasternKingdom2=null
rect gg_rct_SpawnPoint_Kalimdor1=null
rect gg_rct_SpawnPoint_Kalimdor2=null
rect gg_rct_SpawnPoint_Northland1=null
rect gg_rct_SpawnPoint_Northland2=null
rect gg_rct_SpawnPoint_Pandaria=null
rect gg_rct_SpawnVision=null
rect gg_rct_KTunRaideExt=null
rect gg_rct_KTunRaideMove=null
rect gg_rct_QogSaronMove=null
rect gg_rct_QogSaronExt=null
rect gg_rct_NZotMove=null
rect gg_rct_NZotExt=null
rect gg_rct_Raide01Move=null
rect gg_rct_Raide01Ext=null
rect gg_rct_QOGGSARON=null
rect gg_rct_TEXTKalimdor1=null
rect gg_rct_TEXTKalimdor2=null
rect gg_rct_TEXTPandaria=null
rect gg_rct_TEXTBrokenIsles=null
rect gg_rct_TEXTEastKingdom2=null
rect gg_rct_TEXTEastKingdom1=null
rect gg_rct_TEXTNorth1=null
rect gg_rct_TEXTNorth2=null
rect gg_rct_SpawnLocation=null
rect gg_rct_RAGNAROSS=null
rect gg_rct_RAGNAROSS_EXT=null
rect gg_rct_HeroSpawn=null
rect gg_rct_VAICHmove=null
rect gg_rct_VAICHext=null
rect gg_rct_EarthExt=null
rect gg_rct_EarthMove=null
rect gg_rct_KazemateMove=null
rect gg_rct_KazemateExt=null
rect gg_rct_Necrositetext=null
rect gg_rct_Necrositemove=null
rect gg_rct_DalaranMove=null
rect gg_rct_DalaranExt=null
rect gg_rct_Effect1=null
rect gg_rct_Effect1_____________________u=null
rect gg_rct_DalaranEffect=null
rect gg_rct_UlduarEffect=null
rect gg_rct_Effect=null
rect gg_rct_NaxxramasSpellUsePoint=null
rect gg_rct_NaxxramasSpawn=null
rect gg_rct_Naxxramas=null
rect gg_rct_TEXTOutland=null
rect gg_rct_Outland=null
rect gg_rct_NaxxramasEXT=null
rect gg_rct_NaxxramasMOVE=null
rect gg_rct_HeroByCommand1=null
rect gg_rct_HeroByCommand2=null
sound gg_snd_ArtilleryCorpseExplodeDeath1=null
string gg_snd_UndeadVictory="Sound\\Music\\mp3Music\\UndeadVictory.mp3"
string gg_snd_OrcVictory="Sound\\Music\\mp3Music\\OrcVictory.mp3"
string gg_snd_NightElfVictory="Sound\\Music\\mp3Music\\NightElfVictory.mp3"
string gg_snd_HumanVictory="Sound\\Music\\mp3Music\\HumanVictory.mp3"
string gg_snd_ArthasTheme="Sound\\Music\\mp3Music\\ArthasTheme.mp3"
sound gg_snd_PeasantWarcry1=null
sound gg_snd_PeasantYes1=null
sound gg_snd_PeasantYesAttack4=null
sound gg_snd_HeroFarseerPissed1=null
string gg_snd_Doom="Sound\\Music\\mp3Music\\Doom.mp3"
sound gg_snd_HPitLordYesAttack1=null
string gg_snd_Credits01="Sound\\Music\\mp3Music\\Credits.mp3"
string gg_snd_BloodElfTheme="Sound\\Music\\mp3Music\\BloodElfTheme.mp3"
string gg_snd_IllidansTheme="Sound\\Music\\mp3Music\\IllidansTheme.mp3"
sound gg_snd_A07Kiljaeden30=null
sound gg_snd_zsukdarkportal=null
string gg_snd_TragicConfrontation="Sound\\Music\\mp3Music\\TragicConfrontation.mp3"
string gg_snd_DarkVictory="Sound\\Music\\mp3Music\\DarkVictory.mp3"
string gg_snd_U05AArthas02="Sound\\Dialogue\\UndeadCampaign\\Undead05A\\U05AArthas02.mp3"
string gg_snd_L01LichKing44="Sound\\Dialogue\\UndeadExpCamp\\Undead01x\\L01LichKing44.mp3"
sound gg_snd_U02KelThuzad27=null
string gg_snd_Kel_Thuzad="Kel'Thuzad.mp3"
string gg_snd_Chivalry="war3mapImported\\Chivalry.mp3"
string gg_snd_GloryGnoms="war3mapImported\\GloryGnoms.mp3"
trigger gg_trg_Information=null
trigger gg_trg_Tekst=null
trigger gg_trg_Start=null
trigger gg_trg_Time_f1=null
trigger gg_trg_Time_f2=null
trigger gg_trg_Time_f4=null
trigger gg_trg_Time_f5=null
trigger gg_trg_Time_f6=null
trigger gg_trg_Time_f7=null
trigger gg_trg_Time_f8=null
trigger gg_trg_Liver_Player=null
trigger gg_trg_AuthorVision=null
trigger gg_trg_GiveNeutal=null
trigger gg_trg_SpawnVision=null
trigger gg_trg_NochangeName1=null
trigger gg_trg_NochangeName2=null
trigger gg_trg_NochangeName3=null
trigger gg_trg_NochangeName4=null
trigger gg_trg_NochangeName5=null
trigger gg_trg_NochangeName8=null
trigger gg_trg_Human=null
trigger gg_trg_Orc=null
trigger gg_trg_Undead=null
trigger gg_trg_NightElf=null
trigger gg_trg_Nerubian=null
trigger gg_trg_Dwarfen=null
trigger gg_trg_Naga=null
trigger gg_trg_ScorgedElf=null
trigger gg_trg_Demon=null
trigger gg_trg_HighElf=null
trigger gg_trg_ForestTroll=null
trigger gg_trg_DarkTroll=null
trigger gg_trg_IceTroll=null
trigger gg_trg_FelOrc=null
trigger gg_trg_Kobold=null
trigger gg_trg_ScarletCrusade=null
trigger gg_trg_Futborg=null
trigger gg_trg_Gnoll=null
trigger gg_trg_Faceless=null
trigger gg_trg_Ogre=null
trigger gg_trg_Draenei=null
trigger gg_trg_Bandite=null
trigger gg_trg_Tauren=null
trigger gg_trg_Pandaren=null
trigger gg_trg_Goblin=null
trigger gg_trg_Murloc=null
trigger gg_trg_Centaur=null
trigger gg_trg_Illidari=null
trigger gg_trg_Worgen=null
trigger gg_trg_Forsaken=null
trigger gg_trg_Elemental=null
trigger gg_trg_Quraji=null
trigger gg_trg_DarkDwarf=null
trigger gg_trg_TwilightHammer=null
trigger gg_trg_Hostkick1=null
trigger gg_trg_Hostkick2=null
trigger gg_trg_Hostkick3=null
trigger gg_trg_Hostkick4=null
trigger gg_trg_Hostkick5=null
trigger gg_trg_Hostkick6=null
trigger gg_trg_Hostkick7=null
trigger gg_trg_Hostkick8=null
trigger gg_trg_Hostkick9=null
trigger gg_trg_Hostkick10=null
trigger gg_trg_Hostkick11=null
trigger gg_trg_Hostkick12=null
trigger gg_trg_destroy_1=null
trigger gg_trg_Timedestroy=null
trigger gg_trg_Debut=null
trigger gg_trg_Revenus=null
trigger gg_trg_ND1=null
trigger gg_trg_ND2=null
trigger gg_trg_ND3=null
trigger gg_trg_ND4=null
trigger gg_trg_ND5=null
trigger gg_trg_ND6=null
trigger gg_trg_ND7=null
trigger gg_trg_ND8=null
trigger gg_trg_ND9=null
trigger gg_trg_KL1=null
trigger gg_trg_KL2=null
trigger gg_trg_KL3=null
trigger gg_trg_KL4=null
trigger gg_trg_KL5=null
trigger gg_trg_KL6=null
trigger gg_trg_KL7=null
trigger gg_trg_KL8=null
trigger gg_trg_KL9=null
trigger gg_trg_KL10=null
trigger gg_trg_KL11=null
trigger gg_trg_KL12=null
trigger gg_trg_KL13=null
trigger gg_trg_KL14=null
trigger gg_trg_PA1=null
trigger gg_trg_PA2=null
trigger gg_trg_PA3=null
trigger gg_trg_PA4=null
trigger gg_trg_PA5=null
trigger gg_trg_BI1=null
trigger gg_trg_BI2=null
trigger gg_trg_BI3=null
trigger gg_trg_BI4=null
trigger gg_trg_BI5=null
trigger gg_trg_Bl6=null
trigger gg_trg_BI7=null
trigger gg_trg_BI8=null
trigger gg_trg_BI9=null
trigger gg_trg_BI10=null
trigger gg_trg_EK1=null
trigger gg_trg_EK2=null
trigger gg_trg_EK3=null
trigger gg_trg_EK4=null
trigger gg_trg_EK5=null
trigger gg_trg_EK6=null
trigger gg_trg_EK7=null
trigger gg_trg_EK8=null
trigger gg_trg_EK9=null
trigger gg_trg_EK10=null
trigger gg_trg_EK11=null
trigger gg_trg_EK12=null
trigger gg_trg_EK13=null
trigger gg_trg_EK14=null
trigger gg_trg_EK15=null
trigger gg_trg_EK16=null
trigger gg_trg_EK17=null
trigger gg_trg_EK18=null
trigger gg_trg_EK19=null
trigger gg_trg_EK20=null
trigger gg_trg_EK21=null
trigger gg_trg_EK22=null
trigger gg_trg_OUT1=null
trigger gg_trg_OUT2=null
trigger gg_trg_OUT3=null
trigger gg_trg_OUT4=null
trigger gg_trg_OUT5=null
trigger gg_trg_OUT6=null
trigger gg_trg_OUT7=null
trigger gg_trg_ZN1=null
trigger gg_trg_VE1=null
trigger gg_trg_KT=null
trigger gg_trg_Managorn1=null
trigger gg_trg_Managorn2=null
trigger gg_trg_Managorn3=null
trigger gg_trg_Managorn4=null
trigger gg_trg_Production_en_chaine=null
trigger gg_trg_Camera_command=null
trigger gg_trg_Name_command=null
trigger gg_trg_Red_color=null
trigger gg_trg_Blue_color=null
trigger gg_trg_Lightblue_color=null
trigger gg_trg_Viol_color=null
trigger gg_trg_Yelow_color=null
trigger gg_trg_Orange_color=null
trigger gg_trg_Green_color=null
trigger gg_trg_Rose_color=null
trigger gg_trg_Grey_color=null
trigger gg_trg_Cyan_color=null
trigger gg_trg_Dark_green_color=null
trigger gg_trg_Brown_color=null
trigger gg_trg_Black_color=null
trigger gg_trg_Turn_On=null
trigger gg_trg_Turn_Off=null
trigger gg_trg_Declare_War_1=null
trigger gg_trg_Declare_War_2=null
trigger gg_trg_Declare_War_5=null
trigger gg_trg_Declare_War_3=null
trigger gg_trg_Declare_War_4=null
trigger gg_trg_Declare_War_6=null
trigger gg_trg_Declare_War_7=null
trigger gg_trg_Declare_War_8=null
trigger gg_trg_Declare_War_9=null
trigger gg_trg_Declare_War_10=null
trigger gg_trg_Declare_War_11=null
trigger gg_trg_Declare_War_12=null
trigger gg_trg_Buildings=null
trigger gg_trg_Heroes=null
trigger gg_trg_Ship=null
trigger gg_trg_Select=null
trigger gg_trg_Race=null
trigger gg_trg_RandomInfo=null
trigger gg_trg_RaceSelect1=null
trigger gg_trg_RaceSelect2=null
trigger gg_trg_RaceSelect3=null
trigger gg_trg_RaceSelect4=null
trigger gg_trg_RaceSelect5=null
trigger gg_trg_RaceSelect6=null
trigger gg_trg_RaceSelect7=null
trigger gg_trg_RaceSelect8=null
trigger gg_trg_RaceSelect9=null
trigger gg_trg_RaceSelect10=null
trigger gg_trg_RaceSelect11=null
trigger gg_trg_RaceSelect12=null
trigger gg_trg_Kil=null
trigger gg_trg_Smertokril=null
trigger gg_trg_OldGodsPower=null
trigger gg_trg_LichKing=null
trigger gg_trg_AlAkir=null
trigger gg_trg_Kazzak=null
trigger gg_trg_RAGNAROSS=null
trigger gg_trg_Illidan=null
trigger gg_trg_Soul_Eater=null
trigger gg_trg_ChoGall=null
trigger gg_trg_Kael=null
trigger gg_trg_Kenya=null
trigger gg_trg_Neptulon=null
trigger gg_trg_Terazan=null
trigger gg_trg_Maiev=null
trigger gg_trg_Gandling=null
trigger gg_trg_NZOT=null
trigger gg_trg_NZOT_agent=null
trigger gg_trg_CTUN=null
trigger gg_trg_QOGGSARON=null
trigger gg_trg_SHA=null
trigger gg_trg_ItemCraft1=null
trigger gg_trg_Lich_King=null
trigger gg_trg_Illidan_H=null
trigger gg_trg_Cshi_Fire_Hand=null
trigger gg_trg_Tirion=null
trigger gg_trg_Kern=null
trigger gg_trg_Vaish=null
trigger gg_trg_Saidan=null
trigger gg_trg_Sylvanas=null
trigger gg_trg_Farion=null
trigger gg_trg_Genn=null
trigger gg_trg_Thrall=null
trigger gg_trg_Izjor=null
trigger gg_trg_VanCleef=null
trigger gg_trg_Ursol=null
trigger gg_trg_Vanol=null
trigger gg_trg_Magni=null
trigger gg_trg_DrBoom=null
trigger gg_trg_ChoGallLg=null
trigger gg_trg_Akama=null
trigger gg_trg_Nerub=null
trigger gg_trg_TrollIce=null
trigger gg_trg_TrollDArk=null
trigger gg_trg_TrollForest=null
trigger gg_trg_LorTemarTeron=null
trigger gg_trg_Ksavii=null
trigger gg_trg_Kargath=null
trigger gg_trg_Dagran_Taurissan=null
trigger gg_trg_Multiboard_Create=null
trigger gg_trg_K=null
trigger gg_trg_KH=null
trigger gg_trg_Update=null
trigger gg_trg_Update2=null
trigger gg_trg_AutoAlly_Copier_____________________u=null
trigger gg_trg_Declare_War_1_____________________u=null
trigger gg_trg_Declare_War_2_____________________u=null
trigger gg_trg_Declare_War_3_____________________u=null
trigger gg_trg_Declare_War_4_____________________u=null
trigger gg_trg_Declare_War_5_____________________u=null
trigger gg_trg_Declare_War_6_____________________u=null
trigger gg_trg_Declare_War_7_____________________u=null
trigger gg_trg_Declare_War_8_____________________u=null
trigger gg_trg_Declare_War_9_____________________u=null
trigger gg_trg_Declare_War_10_____________________u=null
trigger gg_trg_Declare_War_11_____________________u=null
trigger gg_trg_Declare_War_12_____________________u=null
trigger gg_trg_Turn_On_____________________u=null
trigger gg_trg_Turn_Off_____________________u=null
trigger gg_trg_lb_DyuingUnit=null
trigger gg_trg_RemoveUnitAntiLag=null
trigger gg_trg_Voina23=null
trigger gg_trg_NochangeName6=null
trigger gg_trg_gordik0101=null
trigger gg_trg_heavyboy2005=null
trigger gg_trg_NochangeName7=null
unit gg_unit_h01M_0069=null
unit gg_unit_h01K_0057=null
unit gg_unit_h01I_0067=null
unit gg_unit_h01H_0066=null
unit gg_unit_h01G_0064=null
unit gg_unit_h01F_0062=null
unit gg_unit_h01E_0010=null
unit gg_unit_h01D_0061=null
unit gg_unit_h01A_0060=null
unit gg_unit_h01C_0059=null
unit gg_unit_h01B_0058=null
unit gg_unit_h001_0011=null
unit gg_unit_h00A_0028=null
unit gg_unit_h009_0029=null
unit gg_unit_h008_0027=null
unit gg_unit_h007_0026=null
unit gg_unit_h006_0025=null
unit gg_unit_h002_0018=null
unit gg_unit_h005_0024=null
unit gg_unit_h004_0023=null
unit gg_unit_h003_0022=null
unit gg_unit_h00B_0013=null
unit gg_unit_h00C_0014=null
unit gg_unit_h00D_0015=null
unit gg_unit_h00E_0016=null
unit gg_unit_h00F_0017=null
unit gg_unit_h00G_0019=null
unit gg_unit_h00H_0020=null
unit gg_unit_h00I_0021=null
unit gg_unit_h00J_0030=null
unit gg_unit_h00K_0031=null
unit gg_unit_h00L_0032=null
unit gg_unit_h00M_0033=null
unit gg_unit_h00N_0034=null
unit gg_unit_h00O_0035=null
unit gg_unit_h00P_0036=null
unit gg_unit_h00Q_0037=null
unit gg_unit_h00R_0038=null
unit gg_unit_h00S_0039=null
unit gg_unit_h00T_0040=null
unit gg_unit_h00U_0041=null
unit gg_unit_h00V_0042=null
unit gg_unit_h00W_0043=null
unit gg_unit_h00X_0044=null
unit gg_unit_h00Y_0045=null
unit gg_unit_h00Z_0046=null
unit gg_unit_h010_0047=null
unit gg_unit_h011_0048=null
unit gg_unit_h012_0049=null
unit gg_unit_h013_0050=null
unit gg_unit_h014_0051=null
unit gg_unit_h015_0052=null
unit gg_unit_h016_0053=null
unit gg_unit_h017_0054=null
unit gg_unit_h018_0055=null
unit gg_unit_h019_0056=null
unit gg_unit_h01J_0068=null
unit gg_unit_h01N_0065=null
unit gg_unit_n01V_0108=null
unit gg_unit_n01W_0109=null
unit gg_unit_n01X_0110=null
unit gg_unit_n01Y_0159=null
unit gg_unit_h07P_0420=null
unit gg_unit_h07P_0419=null
unit gg_unit_h07P_0418=null
unit gg_unit_h07P_0417=null
unit gg_unit_h07O_0416=null
unit gg_unit_h07R_0791=null
unit gg_unit_h07Q_0422=null
unit gg_unit_h07S_0202=null
unit gg_unit_h07N_0415=null
unit gg_unit_U00T_0284=null
unit gg_unit_H034_0111=null
unit gg_unit_Ewrd_0749=null
unit gg_unit_Eevi_0573=null
unit gg_unit_h07F_0793=null
unit gg_unit_h046_0405=null
unit gg_unit_n02S_0532=null
unit gg_unit_h088_0545=null
unit gg_unit_n02T_0564=null
unit gg_unit_Ecen_0090=null
unit gg_unit_N055_0288=null
unit gg_unit_h052_0627=null
unit gg_unit_h053_0628=null
unit gg_unit_N05H_0633=null
unit gg_unit_h05M_0632=null
unit gg_unit_n06P_0634=null
unit gg_unit_Hkal_0645=null
unit gg_unit_N06Q_0668=null
unit gg_unit_h078_0695=null
unit gg_unit_N06V_0078=null
unit gg_unit_u024_0228=null
destructable gg_dest_B000_10403=null
destructable gg_dest_B000_5046=null
endglobals
function InitGlobals takes nothing returns nothing
local integer i=0
set udg_Compteur1=CreateTimer()
set i=0
loop
exitwhen(i>1)
set udg_Col_vo_units[i]=0
set udg_Can_pick[i]=false
set udg_PlayersCount[i]=0
set udg_PlayersForce[i]=CreateForce()
set udg_Kill[i]=0
set udg_Death[i]=0
set udg_Kills[i]=0
set udg_Deaths[i]=0
set i=i+1
endloop
set udg_Group=CreateForce()
set udg_Players_hero=CreateForce()
set udg_MultiBoard=CreateMultiboard()
endfunction
function ItemTable000000_DropItems takes nothing returns nothing
local widget trigWidget=null
local unit trigUnit=null
local integer itemID=0
local boolean canDrop=true
set trigWidget=bj_lastDyingWidget
if(trigWidget==null)then
set trigUnit=GetTriggerUnit()
endif
if(trigUnit!=null)then
set canDrop=not IsUnitHidden(trigUnit)
if(canDrop and GetChangingUnit()!=null)then
set canDrop=(GetChangingUnitPrevOwner()==Player($C))
endif
endif
if(canDrop)then
call RandomDistReset()
call RandomDistAddItem('I000','d')
set itemID=RandomDistChoose()
if(trigUnit!=null)then
call UnitDropItem(trigUnit,itemID)
else
call WidgetDropItem(trigWidget,itemID)
endif
endif
set bj_lastDyingWidget=null
call DestroyTrigger(GetTriggeringTrigger())
endfunction
function ItemTable000001_DropItems takes nothing returns nothing
local widget trigWidget=null
local unit trigUnit=null
local integer itemID=0
local boolean canDrop=true
set trigWidget=bj_lastDyingWidget
if(trigWidget==null)then
set trigUnit=GetTriggerUnit()
endif
if(trigUnit!=null)then
set canDrop=not IsUnitHidden(trigUnit)
if(canDrop and GetChangingUnit()!=null)then
set canDrop=(GetChangingUnitPrevOwner()==Player($C))
endif
endif
if(canDrop)then
call RandomDistReset()
call RandomDistAddItem('I002','d')
set itemID=RandomDistChoose()
if(trigUnit!=null)then
call UnitDropItem(trigUnit,itemID)
else
call WidgetDropItem(trigWidget,itemID)
endif
endif
set bj_lastDyingWidget=null
call DestroyTrigger(GetTriggeringTrigger())
endfunction
function ItemTable000002_DropItems takes nothing returns nothing
local widget trigWidget=null
local unit trigUnit=null
local integer itemID=0
local boolean canDrop=true
set trigWidget=bj_lastDyingWidget
if(trigWidget==null)then
set trigUnit=GetTriggerUnit()
endif
if(trigUnit!=null)then
set canDrop=not IsUnitHidden(trigUnit)
if(canDrop and GetChangingUnit()!=null)then
set canDrop=(GetChangingUnitPrevOwner()==Player($C))
endif
endif
if(canDrop)then
call RandomDistReset()
call RandomDistAddItem('I001','d')
set itemID=RandomDistChoose()
if(trigUnit!=null)then
call UnitDropItem(trigUnit,itemID)
else
call WidgetDropItem(trigWidget,itemID)
endif
endif
set bj_lastDyingWidget=null
call DestroyTrigger(GetTriggeringTrigger())
endfunction
function ItemTable000003_DropItems takes nothing returns nothing
local widget trigWidget=null
local unit trigUnit=null
local integer itemID=0
local boolean canDrop=true
set trigWidget=bj_lastDyingWidget
if(trigWidget==null)then
set trigUnit=GetTriggerUnit()
endif
if(trigUnit!=null)then
set canDrop=not IsUnitHidden(trigUnit)
if(canDrop and GetChangingUnit()!=null)then
set canDrop=(GetChangingUnitPrevOwner()==Player($C))
endif
endif
if(canDrop)then
call RandomDistReset()
call RandomDistAddItem('I003','d')
set itemID=RandomDistChoose()
if(trigUnit!=null)then
call UnitDropItem(trigUnit,itemID)
else
call WidgetDropItem(trigWidget,itemID)
endif
endif
set bj_lastDyingWidget=null
call DestroyTrigger(GetTriggeringTrigger())
endfunction
function ItemTable000004_DropItems takes nothing returns nothing
local widget trigWidget=null
local unit trigUnit=null
local integer itemID=0
local boolean canDrop=true
set trigWidget=bj_lastDyingWidget
if(trigWidget==null)then
set trigUnit=GetTriggerUnit()
endif
if(trigUnit!=null)then
set canDrop=not IsUnitHidden(trigUnit)
if(canDrop and GetChangingUnit()!=null)then
set canDrop=(GetChangingUnitPrevOwner()==Player($C))
endif
endif
if(canDrop)then
call RandomDistReset()
call RandomDistAddItem('I00B',$A)
call RandomDistAddItem('I005',$A)
call RandomDistAddItem('I00D',$A)
call RandomDistAddItem('I00A',$A)
call RandomDistAddItem('I00C',$A)
call RandomDistAddItem('I009',$A)
call RandomDistAddItem('I007',$A)
call RandomDistAddItem('I006',$A)
call RandomDistAddItem('I00E',$A)
call RandomDistAddItem('I006',$A)
set itemID=RandomDistChoose()
if(trigUnit!=null)then
call UnitDropItem(trigUnit,itemID)
else
call WidgetDropItem(trigWidget,itemID)
endif
endif
set bj_lastDyingWidget=null
call DestroyTrigger(GetTriggeringTrigger())
endfunction
function Unit000284_DropItems takes nothing returns nothing
local widget trigWidget=null
local unit trigUnit=null
local integer itemID=0
local boolean canDrop=true
set trigWidget=bj_lastDyingWidget
if(trigWidget==null)then
set trigUnit=GetTriggerUnit()
endif
if(trigUnit!=null)then
set canDrop=not IsUnitHidden(trigUnit)
if(canDrop and GetChangingUnit()!=null)then
set canDrop=(GetChangingUnitPrevOwner()==Player($C))
endif
endif
if(canDrop)then
call RandomDistReset()
call RandomDistAddItem('I00K','d')
set itemID=RandomDistChoose()
if(trigUnit!=null)then
call UnitDropItem(trigUnit,itemID)
else
call WidgetDropItem(trigWidget,itemID)
endif
endif
set bj_lastDyingWidget=null
call DestroyTrigger(GetTriggeringTrigger())
endfunction
function Unit000306_DropItems takes nothing returns nothing
local widget trigWidget=null
local unit trigUnit=null
local integer itemID=0
local boolean canDrop=true
set trigWidget=bj_lastDyingWidget
if(trigWidget==null)then
set trigUnit=GetTriggerUnit()
endif
if(trigUnit!=null)then
set canDrop=not IsUnitHidden(trigUnit)
if(canDrop and GetChangingUnit()!=null)then
set canDrop=(GetChangingUnitPrevOwner()==Player($C))
endif
endif
if(canDrop)then
call RandomDistReset()
call RandomDistAddItem('I00J','d')
set itemID=RandomDistChoose()
if(trigUnit!=null)then
call UnitDropItem(trigUnit,itemID)
else
call WidgetDropItem(trigWidget,itemID)
endif
endif
set bj_lastDyingWidget=null
call DestroyTrigger(GetTriggeringTrigger())
endfunction
function Unit000382_DropItems takes nothing returns nothing
local widget trigWidget=null
local unit trigUnit=null
local integer itemID=0
local boolean canDrop=true
set trigWidget=bj_lastDyingWidget
if(trigWidget==null)then
set trigUnit=GetTriggerUnit()
endif
if(trigUnit!=null)then
set canDrop=not IsUnitHidden(trigUnit)
if(canDrop and GetChangingUnit()!=null)then
set canDrop=(GetChangingUnitPrevOwner()==Player($C))
endif
endif
if(canDrop)then
call RandomDistReset()
call RandomDistAddItem('I01H','d')
set itemID=RandomDistChoose()
if(trigUnit!=null)then
call UnitDropItem(trigUnit,itemID)
else
call WidgetDropItem(trigWidget,itemID)
endif
endif
set bj_lastDyingWidget=null
call DestroyTrigger(GetTriggeringTrigger())
endfunction
function Unit000384_DropItems takes nothing returns nothing
local widget trigWidget=null
local unit trigUnit=null
local integer itemID=0
local boolean canDrop=true
set trigWidget=bj_lastDyingWidget
if(trigWidget==null)then
set trigUnit=GetTriggerUnit()
endif
if(trigUnit!=null)then
set canDrop=not IsUnitHidden(trigUnit)
if(canDrop and GetChangingUnit()!=null)then
set canDrop=(GetChangingUnitPrevOwner()==Player($C))
endif
endif
if(canDrop)then
call RandomDistReset()
call RandomDistAddItem('I00I','d')
set itemID=RandomDistChoose()
if(trigUnit!=null)then
call UnitDropItem(trigUnit,itemID)
else
call WidgetDropItem(trigWidget,itemID)
endif
endif
set bj_lastDyingWidget=null
call DestroyTrigger(GetTriggeringTrigger())
endfunction
function Unit000564_DropItems takes nothing returns nothing
local widget trigWidget=null
local unit trigUnit=null
local integer itemID=0
local boolean canDrop=true
set trigWidget=bj_lastDyingWidget
if(trigWidget==null)then
set trigUnit=GetTriggerUnit()
endif
if(trigUnit!=null)then
set canDrop=not IsUnitHidden(trigUnit)
if(canDrop and GetChangingUnit()!=null)then
set canDrop=(GetChangingUnitPrevOwner()==Player($C))
endif
endif
if(canDrop)then
call RandomDistReset()
call RandomDistAddItem('I01A','d')
set itemID=RandomDistChoose()
if(trigUnit!=null)then
call UnitDropItem(trigUnit,itemID)
else
call WidgetDropItem(trigWidget,itemID)
endif
endif
set bj_lastDyingWidget=null
call DestroyTrigger(GetTriggeringTrigger())
endfunction
function Unit000565_DropItems takes nothing returns nothing
local widget trigWidget=null
local unit trigUnit=null
local integer itemID=0
local boolean canDrop=true
set trigWidget=bj_lastDyingWidget
if(trigWidget==null)then
set trigUnit=GetTriggerUnit()
endif
if(trigUnit!=null)then
set canDrop=not IsUnitHidden(trigUnit)
if(canDrop and GetChangingUnit()!=null)then
set canDrop=(GetChangingUnitPrevOwner()==Player($C))
endif
endif
if(canDrop)then
call RandomDistReset()
call RandomDistAddItem('I00L','d')
set itemID=RandomDistChoose()
if(trigUnit!=null)then
call UnitDropItem(trigUnit,itemID)
else
call WidgetDropItem(trigWidget,itemID)
endif
endif
set bj_lastDyingWidget=null
call DestroyTrigger(GetTriggeringTrigger())
endfunction
function Unit000599_DropItems takes nothing returns nothing
local widget trigWidget=null
local unit trigUnit=null
local integer itemID=0
local boolean canDrop=true
set trigWidget=bj_lastDyingWidget
if(trigWidget==null)then
set trigUnit=GetTriggerUnit()
endif
if(trigUnit!=null)then
set canDrop=not IsUnitHidden(trigUnit)
if(canDrop and GetChangingUnit()!=null)then
set canDrop=(GetChangingUnitPrevOwner()==Player($C))
endif
endif
if(canDrop)then
call RandomDistReset()
call RandomDistAddItem('I00H','d')
set itemID=RandomDistChoose()
if(trigUnit!=null)then
call UnitDropItem(trigUnit,itemID)
else
call WidgetDropItem(trigWidget,itemID)
endif
endif
set bj_lastDyingWidget=null
call DestroyTrigger(GetTriggeringTrigger())
endfunction
function Unit000631_DropItems takes nothing returns nothing
local widget trigWidget=null
local unit trigUnit=null
local integer itemID=0
local boolean canDrop=true
set trigWidget=bj_lastDyingWidget
if(trigWidget==null)then
set trigUnit=GetTriggerUnit()
endif
if(trigUnit!=null)then
set canDrop=not IsUnitHidden(trigUnit)
if(canDrop and GetChangingUnit()!=null)then
set canDrop=(GetChangingUnitPrevOwner()==Player($C))
endif
endif
if(canDrop)then
call RandomDistReset()
call RandomDistAddItem('I01B','d')
set itemID=RandomDistChoose()
if(trigUnit!=null)then
call UnitDropItem(trigUnit,itemID)
else
call WidgetDropItem(trigWidget,itemID)
endif
endif
set bj_lastDyingWidget=null
call DestroyTrigger(GetTriggeringTrigger())
endfunction
function Unit000634_DropItems takes nothing returns nothing
local widget trigWidget=null
local unit trigUnit=null
local integer itemID=0
local boolean canDrop=true
set trigWidget=bj_lastDyingWidget
if(trigWidget==null)then
set trigUnit=GetTriggerUnit()
endif
if(trigUnit!=null)then
set canDrop=not IsUnitHidden(trigUnit)
if(canDrop and GetChangingUnit()!=null)then
set canDrop=(GetChangingUnitPrevOwner()==Player($C))
endif
endif
if(canDrop)then
call RandomDistReset()
call RandomDistAddItem('I01C','d')
set itemID=RandomDistChoose()
if(trigUnit!=null)then
call UnitDropItem(trigUnit,itemID)
else
call WidgetDropItem(trigWidget,itemID)
endif
endif
set bj_lastDyingWidget=null
call DestroyTrigger(GetTriggeringTrigger())
endfunction
function Unit000645_DropItems takes nothing returns nothing
local widget trigWidget=null
local unit trigUnit=null
local integer itemID=0
local boolean canDrop=true
set trigWidget=bj_lastDyingWidget
if(trigWidget==null)then
set trigUnit=GetTriggerUnit()
endif
if(trigUnit!=null)then
set canDrop=not IsUnitHidden(trigUnit)
if(canDrop and GetChangingUnit()!=null)then
set canDrop=(GetChangingUnitPrevOwner()==Player($C))
endif
endif
if(canDrop)then
call RandomDistReset()
call RandomDistAddItem('I01D','d')
set itemID=RandomDistChoose()
if(trigUnit!=null)then
call UnitDropItem(trigUnit,itemID)
else
call WidgetDropItem(trigWidget,itemID)
endif
endif
set bj_lastDyingWidget=null
call DestroyTrigger(GetTriggeringTrigger())
endfunction
function Unit000668_DropItems takes nothing returns nothing
local widget trigWidget=null
local unit trigUnit=null
local integer itemID=0
local boolean canDrop=true
set trigWidget=bj_lastDyingWidget
if(trigWidget==null)then
set trigUnit=GetTriggerUnit()
endif
if(trigUnit!=null)then
set canDrop=not IsUnitHidden(trigUnit)
if(canDrop and GetChangingUnit()!=null)then
set canDrop=(GetChangingUnitPrevOwner()==Player($C))
endif
endif
if(canDrop)then
call RandomDistReset()
call RandomDistAddItem('I01E','d')
set itemID=RandomDistChoose()
if(trigUnit!=null)then
call UnitDropItem(trigUnit,itemID)
else
call WidgetDropItem(trigWidget,itemID)
endif
endif
set bj_lastDyingWidget=null
call DestroyTrigger(GetTriggeringTrigger())
endfunction
function Unit000702_DropItems takes nothing returns nothing
local widget trigWidget=null
local unit trigUnit=null
local integer itemID=0
local boolean canDrop=true
set trigWidget=bj_lastDyingWidget
if(trigWidget==null)then
set trigUnit=GetTriggerUnit()
endif
if(trigUnit!=null)then
set canDrop=not IsUnitHidden(trigUnit)
if(canDrop and GetChangingUnit()!=null)then
set canDrop=(GetChangingUnitPrevOwner()==Player($C))
endif
endif
if(canDrop)then
call RandomDistReset()
call RandomDistAddItem('I01G','d')
set itemID=RandomDistChoose()
if(trigUnit!=null)then
call UnitDropItem(trigUnit,itemID)
else
call WidgetDropItem(trigWidget,itemID)
endif
endif
set bj_lastDyingWidget=null
call DestroyTrigger(GetTriggeringTrigger())
endfunction
function InitSounds takes nothing returns nothing
set gg_snd_ArtilleryCorpseExplodeDeath1=CreateSound("Sound\\Units\\Death\\ArtilleryCorpseExplodeDeath1.wav",false,true,true,$A,$A,"DefaultEAXON")
call SetSoundParamsFromLabel(gg_snd_ArtilleryCorpseExplodeDeath1,"ArtilleryExplodeDeath")
call SetSoundDuration(gg_snd_ArtilleryCorpseExplodeDeath1,$5CE)
set gg_snd_PeasantWarcry1=CreateSound("Units\\Human\\Peasant\\PeasantWarcry1.wav",false,true,true,$A,$A,"DefaultEAXON")
call SetSoundParamsFromLabel(gg_snd_PeasantWarcry1,"PeasantWarcry")
call SetSoundDuration(gg_snd_PeasantWarcry1,$49E)
set gg_snd_PeasantYes1=CreateSound("Units\\Human\\Peasant\\PeasantYes1.wav",false,true,true,$A,$A,"DefaultEAXON")
call SetSoundParamsFromLabel(gg_snd_PeasantYes1,"PeasantYes")
call SetSoundDuration(gg_snd_PeasantYes1,373)
set gg_snd_PeasantYesAttack4=CreateSound("Units\\Human\\Peasant\\PeasantYesAttack4.wav",false,true,true,$A,$A,"DefaultEAXON")
call SetSoundParamsFromLabel(gg_snd_PeasantYesAttack4,"PeasantYesAttack")
call SetSoundDuration(gg_snd_PeasantYesAttack4,$75E)
set gg_snd_HeroFarseerPissed1=CreateSound("Units\\Orc\\HeroFarseer\\HeroFarseerPissed1.wav",false,true,true,$A,$A,"HeroAcksEAX")
call SetSoundParamsFromLabel(gg_snd_HeroFarseerPissed1,"HeroFarseerPissed")
call SetSoundDuration(gg_snd_HeroFarseerPissed1,$F11)
set gg_snd_HPitLordYesAttack1=CreateSound("Units\\Demon\\HeroPitLord\\HPitLordYesAttack1.wav",false,true,true,$A,$A,"HeroAcksEAX")
call SetSoundParamsFromLabel(gg_snd_HPitLordYesAttack1,"HeroPitLordYesAttack")
call SetSoundDuration(gg_snd_HPitLordYesAttack1,$67A)
set gg_snd_A07Kiljaeden30=CreateSound("Sound\\Dialogue\\HumanExpCamp\\Human07xInterlude\\A07Kiljaeden30.mp3",false,false,false,$A,$A,"")
call SetSoundParamsFromLabel(gg_snd_A07Kiljaeden30,"A07Kiljaeden30")
call SetSoundDuration(gg_snd_A07Kiljaeden30,$43DB)
set gg_snd_zsukdarkportal=CreateSound("war3mapImported\\zsukdarkportal.mp3",false,false,false,$A,$A,"")
call SetSoundChannel(gg_snd_zsukdarkportal,0)
call SetSoundVolume(gg_snd_zsukdarkportal,$7F)
call SetSoundPitch(gg_snd_zsukdarkportal,1.)
set gg_snd_U02KelThuzad27=CreateSound("Sound\\Dialogue\\UndeadCampaign\\Undead02\\U02KelThuzad27.mp3",false,false,false,$A,$A,"")
call SetSoundParamsFromLabel(gg_snd_U02KelThuzad27,"U02KelThuzad27")
call SetSoundDuration(gg_snd_U02KelThuzad27,8594)
endfunction
function CreateAllDestructables takes nothing returns nothing
local destructable d
local trigger t
local real life
set gg_dest_B000_5046=CreateDestructable('B000',4096.,1088.,318.,.938,3)
set gg_dest_B000_10403=CreateDestructable('B000',4096.,1216.,318.,.938,3)
endfunction
function CreateBuildingsForPlayer0 takes nothing returns nothing
local player p=Player(0)
local unit u
local integer unitID
local trigger t
local real life
set u=CreateUnit(p,'n00B',25440.,-27104.,270.)
endfunction
function CreateBuildingsForPlayer1 takes nothing returns nothing
local player p=Player(1)
local unit u
local integer unitID
local trigger t
local real life
set u=CreateUnit(p,'n00B',25440.,-26848.,270.)
endfunction
function CreateBuildingsForPlayer2 takes nothing returns nothing
local player p=Player(2)
local unit u
local integer unitID
local trigger t
local real life
set u=CreateUnit(p,'n00B',25440.,-26592.,270.)
endfunction
function CreateBuildingsForPlayer3 takes nothing returns nothing
local player p=Player(3)
local unit u
local integer unitID
local trigger t
local real life
set u=CreateUnit(p,'n00B',25440.,-26336.,270.)
endfunction
function CreateBuildingsForPlayer4 takes nothing returns nothing
local player p=Player(4)
local unit u
local integer unitID
local trigger t
local real life
set u=CreateUnit(p,'n00B',25696.,-26336.,270.)
endfunction
function CreateBuildingsForPlayer5 takes nothing returns nothing
local player p=Player(5)
local unit u
local integer unitID
local trigger t
local real life
set u=CreateUnit(p,'n00B',25952.,-26336.,270.)
endfunction
function CreateBuildingsForPlayer6 takes nothing returns nothing
local player p=Player(6)
local unit u
local integer unitID
local trigger t
local real life
set u=CreateUnit(p,'n00B',26208.,-26336.,270.)
endfunction
function CreateBuildingsForPlayer7 takes nothing returns nothing
local player p=Player(7)
local unit u
local integer unitID
local trigger t
local real life
set u=CreateUnit(p,'n00B',26208.,-26592.,270.)
endfunction
function CreateBuildingsForPlayer8 takes nothing returns nothing
local player p=Player(8)
local unit u
local integer unitID
local trigger t
local real life
set u=CreateUnit(p,'n00B',26208.,-26848.,270.)
endfunction
function CreateBuildingsForPlayer9 takes nothing returns nothing
local player p=Player(9)
local unit u
local integer unitID
local trigger t
local real life
set u=CreateUnit(p,'n00B',26208.,-27104.,270.)
endfunction
function CreateBuildingsForPlayer10 takes nothing returns nothing
local player p=Player($A)
local unit u
local integer unitID
local trigger t
local real life
set u=CreateUnit(p,'n00B',25952.,-27104.,270.)
endfunction
function CreateBuildingsForPlayer11 takes nothing returns nothing
local player p=Player($B)
local unit u
local integer unitID
local trigger t
local real life
set u=CreateUnit(p,'n00B',25696.,-27104.,270.)
endfunction
function CreateNeutralHostileBuildings takes nothing returns nothing
local player p=Player($C)
local unit u
local integer unitID
local trigger t
local real life
set gg_unit_h01E_0010=CreateUnit(p,'h01E',-15616.,-21504.,270.)
set life=GetUnitState(gg_unit_h01E_0010,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h01E_0010,UNIT_STATE_LIFE,.5*life)
set gg_unit_h001_0011=CreateUnit(p,'h001',18752.,-4608.,270.)
set life=GetUnitState(gg_unit_h001_0011,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h001_0011,UNIT_STATE_LIFE,.5*life)
set gg_unit_h00B_0013=CreateUnit(p,'h00B',11712.,8256.,270.)
set life=GetUnitState(gg_unit_h00B_0013,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h00B_0013,UNIT_STATE_LIFE,.5*life)
set gg_unit_h00C_0014=CreateUnit(p,'h00C',17312.,14560.,270.)
set life=GetUnitState(gg_unit_h00C_0014,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h00C_0014,UNIT_STATE_LIFE,.5*life)
set gg_unit_h00D_0015=CreateUnit(p,'h00D',19936.,14880.,270.)
set life=GetUnitState(gg_unit_h00D_0015,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h00D_0015,UNIT_STATE_LIFE,.5*life)
set gg_unit_h00E_0016=CreateUnit(p,'h00E',17216.,18112.,270.)
set life=GetUnitState(gg_unit_h00E_0016,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h00E_0016,UNIT_STATE_LIFE,.5*life)
set gg_unit_h00F_0017=CreateUnit(p,'h00F',25536.,14656.,270.)
set life=GetUnitState(gg_unit_h00F_0017,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h00F_0017,UNIT_STATE_LIFE,.5*life)
set gg_unit_h002_0018=CreateUnit(p,'h002',15168.,1856.,270.)
set life=GetUnitState(gg_unit_h002_0018,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h002_0018,UNIT_STATE_LIFE,.5*life)
set gg_unit_h00G_0019=CreateUnit(p,'h00G',26272.,17824.,270.)
set life=GetUnitState(gg_unit_h00G_0019,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h00G_0019,UNIT_STATE_LIFE,.5*life)
set gg_unit_h00H_0020=CreateUnit(p,'h00H',25344.,25600.,270.)
set life=GetUnitState(gg_unit_h00H_0020,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h00H_0020,UNIT_STATE_LIFE,.5*life)
set gg_unit_h00I_0021=CreateUnit(p,'h00I',25152.,28160.,270.)
set life=GetUnitState(gg_unit_h00I_0021,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h00I_0021,UNIT_STATE_LIFE,.5*life)
set gg_unit_h003_0022=CreateUnit(p,'h003',18976.,-2592.,270.)
set life=GetUnitState(gg_unit_h003_0022,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h003_0022,UNIT_STATE_LIFE,.5*life)
set gg_unit_h004_0023=CreateUnit(p,'h004',23616.,320.,270.)
set life=GetUnitState(gg_unit_h004_0023,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h004_0023,UNIT_STATE_LIFE,.5*life)
set gg_unit_h005_0024=CreateUnit(p,'h005',18240.,2688.,270.)
set life=GetUnitState(gg_unit_h005_0024,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h005_0024,UNIT_STATE_LIFE,.5*life)
set gg_unit_h006_0025=CreateUnit(p,'h006',21344.,3424.,270.)
set life=GetUnitState(gg_unit_h006_0025,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h006_0025,UNIT_STATE_LIFE,.5*life)
set gg_unit_h007_0026=CreateUnit(p,'h007',15488.,4928.,270.)
set life=GetUnitState(gg_unit_h007_0026,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h007_0026,UNIT_STATE_LIFE,.5*life)
set gg_unit_h008_0027=CreateUnit(p,'h008',16256.,8896.,270.)
set life=GetUnitState(gg_unit_h008_0027,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h008_0027,UNIT_STATE_LIFE,.5*life)
set gg_unit_h00A_0028=CreateUnit(p,'h00A',14912.,14720.,270.)
set life=GetUnitState(gg_unit_h00A_0028,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h00A_0028,UNIT_STATE_LIFE,.5*life)
set gg_unit_h009_0029=CreateUnit(p,'h009',12832.,-15776.,270.)
set life=GetUnitState(gg_unit_h009_0029,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h009_0029,UNIT_STATE_LIFE,.5*life)
set gg_unit_h00J_0030=CreateUnit(p,'h00J',20992.,20800.,270.)
set life=GetUnitState(gg_unit_h00J_0030,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h00J_0030,UNIT_STATE_LIFE,.5*life)
set gg_unit_h00K_0031=CreateUnit(p,'h00K',-4160.,20544.,270.)
set life=GetUnitState(gg_unit_h00K_0031,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h00K_0031,UNIT_STATE_LIFE,.5*life)
set gg_unit_h00L_0032=CreateUnit(p,'h00L',-7808.,23104.,270.)
set life=GetUnitState(gg_unit_h00L_0032,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h00L_0032,UNIT_STATE_LIFE,.5*life)
set gg_unit_h00M_0033=CreateUnit(p,'h00M',-9824.,25952.,270.)
set life=GetUnitState(gg_unit_h00M_0033,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h00M_0033,UNIT_STATE_LIFE,.5*life)
set gg_unit_h00N_0034=CreateUnit(p,'h00N',1568.,23648.,270.)
set life=GetUnitState(gg_unit_h00N_0034,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h00N_0034,UNIT_STATE_LIFE,.5*life)
set gg_unit_h00O_0035=CreateUnit(p,'h00O',-3328.,28032.,270.)
set life=GetUnitState(gg_unit_h00O_0035,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h00O_0035,UNIT_STATE_LIFE,.5*life)
set gg_unit_h00P_0036=CreateUnit(p,'h00P',5024.,30368.,270.)
set life=GetUnitState(gg_unit_h00P_0036,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h00P_0036,UNIT_STATE_LIFE,.5*life)
set gg_unit_h00Q_0037=CreateUnit(p,'h00Q',7232.,22144.,270.)
set life=GetUnitState(gg_unit_h00Q_0037,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h00Q_0037,UNIT_STATE_LIFE,.5*life)
set gg_unit_h00R_0038=CreateUnit(p,'h00R',8640.,27520.,270.)
set life=GetUnitState(gg_unit_h00R_0038,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h00R_0038,UNIT_STATE_LIFE,.5*life)
set gg_unit_h00S_0039=CreateUnit(p,'h00S',-19392.,-7552.,270.)
set life=GetUnitState(gg_unit_h00S_0039,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h00S_0039,UNIT_STATE_LIFE,.5*life)
set gg_unit_h00T_0040=CreateUnit(p,'h00T',-17728.,-1920.,270.)
set life=GetUnitState(gg_unit_h00T_0040,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h00T_0040,UNIT_STATE_LIFE,.5*life)
set gg_unit_h00U_0041=CreateUnit(p,'h00U',-23424.,-6848.,270.)
set life=GetUnitState(gg_unit_h00U_0041,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h00U_0041,UNIT_STATE_LIFE,.5*life)
set gg_unit_h00V_0042=CreateUnit(p,'h00V',-12608.,1728.,270.)
set life=GetUnitState(gg_unit_h00V_0042,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h00V_0042,UNIT_STATE_LIFE,.5*life)
set gg_unit_h00W_0043=CreateUnit(p,'h00W',-19968.,5440.,270.)
set life=GetUnitState(gg_unit_h00W_0043,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h00W_0043,UNIT_STATE_LIFE,.5*life)
set gg_unit_h00X_0044=CreateUnit(p,'h00X',-14272.,8896.,270.)
set life=GetUnitState(gg_unit_h00X_0044,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h00X_0044,UNIT_STATE_LIFE,.5*life)
set gg_unit_h00Y_0045=CreateUnit(p,'h00Y',-15744.,14720.,270.)
set life=GetUnitState(gg_unit_h00Y_0045,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h00Y_0045,UNIT_STATE_LIFE,.5*life)
set gg_unit_h00Z_0046=CreateUnit(p,'h00Z',-10720.,13280.,270.)
set life=GetUnitState(gg_unit_h00Z_0046,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h00Z_0046,UNIT_STATE_LIFE,.5*life)
set gg_unit_h010_0047=CreateUnit(p,'h010',-26016.,15520.,270.)
set life=GetUnitState(gg_unit_h010_0047,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h010_0047,UNIT_STATE_LIFE,.5*life)
set gg_unit_h011_0048=CreateUnit(p,'h011',-26016.,19360.,270.)
set life=GetUnitState(gg_unit_h011_0048,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h011_0048,UNIT_STATE_LIFE,.5*life)
set gg_unit_h012_0049=CreateUnit(p,'h012',-22656.,15296.,270.)
set life=GetUnitState(gg_unit_h012_0049,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h012_0049,UNIT_STATE_LIFE,.5*life)
set gg_unit_h013_0050=CreateUnit(p,'h013',-18880.,19904.,270.)
set life=GetUnitState(gg_unit_h013_0050,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h013_0050,UNIT_STATE_LIFE,.5*life)
set gg_unit_h014_0051=CreateUnit(p,'h014',-21056.,26304.,270.)
set life=GetUnitState(gg_unit_h014_0051,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h014_0051,UNIT_STATE_LIFE,.5*life)
set gg_unit_h015_0052=CreateUnit(p,'h015',-3520.,-2624.,270.)
set life=GetUnitState(gg_unit_h015_0052,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h015_0052,UNIT_STATE_LIFE,.5*life)
set gg_unit_h016_0053=CreateUnit(p,'h016',-5440.,-5248.,270.)
set life=GetUnitState(gg_unit_h016_0053,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h016_0053,UNIT_STATE_LIFE,.5*life)
set gg_unit_h017_0054=CreateUnit(p,'h017',-4864.,-9664.,270.)
set life=GetUnitState(gg_unit_h017_0054,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h017_0054,UNIT_STATE_LIFE,.5*life)
set gg_unit_h018_0055=CreateUnit(p,'h018',3840.,-7552.,270.)
set life=GetUnitState(gg_unit_h018_0055,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h018_0055,UNIT_STATE_LIFE,.5*life)
set gg_unit_h019_0056=CreateUnit(p,'h019',5408.,9888.,270.)
set life=GetUnitState(gg_unit_h019_0056,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h019_0056,UNIT_STATE_LIFE,.5*life)
set gg_unit_h01K_0057=CreateUnit(p,'h01K',7040.,11456.,270.)
set life=GetUnitState(gg_unit_h01K_0057,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h01K_0057,UNIT_STATE_LIFE,.5*life)
set gg_unit_h01B_0058=CreateUnit(p,'h01B',-2240.,10432.,270.)
set life=GetUnitState(gg_unit_h01B_0058,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h01B_0058,UNIT_STATE_LIFE,.5*life)
set gg_unit_h01C_0059=CreateUnit(p,'h01C',3200.,14656.,270.)
set life=GetUnitState(gg_unit_h01C_0059,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h01C_0059,UNIT_STATE_LIFE,.5*life)
set gg_unit_h01A_0060=CreateUnit(p,'h01A',7104.,9280.,270.)
set life=GetUnitState(gg_unit_h01A_0060,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h01A_0060,UNIT_STATE_LIFE,.5*life)
set gg_unit_h01D_0061=CreateUnit(p,'h01D',-6848.,5824.,270.)
set life=GetUnitState(gg_unit_h01D_0061,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h01D_0061,UNIT_STATE_LIFE,.5*life)
set gg_unit_h01F_0062=CreateUnit(p,'h01F',-19712.,-22784.,270.)
set life=GetUnitState(gg_unit_h01F_0062,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h01F_0062,UNIT_STATE_LIFE,.5*life)
set gg_unit_h01G_0064=CreateUnit(p,'h01G',-20352.,-13632.,270.)
set life=GetUnitState(gg_unit_h01G_0064,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h01G_0064,UNIT_STATE_LIFE,.5*life)
set gg_unit_h01N_0065=CreateUnit(p,'h01N',-11232.,-16672.,270.)
set life=GetUnitState(gg_unit_h01N_0065,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h01N_0065,UNIT_STATE_LIFE,.5*life)
set gg_unit_h01H_0066=CreateUnit(p,'h01H',-11840.,-25792.,270.)
set life=GetUnitState(gg_unit_h01H_0066,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h01H_0066,UNIT_STATE_LIFE,.5*life)
set gg_unit_h01I_0067=CreateUnit(p,'h01I',-24256.,-26944.,270.)
set life=GetUnitState(gg_unit_h01I_0067,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h01I_0067,UNIT_STATE_LIFE,.5*life)
set gg_unit_h01J_0068=CreateUnit(p,'h01J',-20928.,-27520.,270.)
set life=GetUnitState(gg_unit_h01J_0068,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h01J_0068,UNIT_STATE_LIFE,.5*life)
set gg_unit_h01M_0069=CreateUnit(p,'h01M',-4480.,-15232.,270.)
set life=GetUnitState(gg_unit_h01M_0069,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h01M_0069,UNIT_STATE_LIFE,.5*life)
set gg_unit_n01V_0108=CreateUnit(p,'n01V',-5248.,-21248.,270.)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,gg_unit_n01V_0108,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,gg_unit_n01V_0108,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function ItemTable000002_DropItems)
set gg_unit_n01W_0109=CreateUnit(p,'n01W',-960.,-27328.,270.)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,gg_unit_n01W_0109,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,gg_unit_n01W_0109,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function ItemTable000000_DropItems)
set gg_unit_n01X_0110=CreateUnit(p,'n01X',-6144.,-26112.,270.)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,gg_unit_n01X_0110,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,gg_unit_n01X_0110,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function ItemTable000001_DropItems)
set gg_unit_n01Y_0159=CreateUnit(p,'n01Y',1760.,15200.,270.)
call SetUnitState(gg_unit_n01Y_0159,UNIT_STATE_MANA,0)
set gg_unit_h07S_0202=CreateUnit(p,'h07S',1312.,9504.,270.)
set life=GetUnitState(gg_unit_h07S_0202,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h07S_0202,UNIT_STATE_LIFE,.5*life)
set gg_unit_h046_0405=CreateUnit(p,'h046',-18848.,-9696.,270.)
set life=GetUnitState(gg_unit_h046_0405,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h046_0405,UNIT_STATE_LIFE,.5*life)
set gg_unit_h07N_0415=CreateUnit(p,'h07N',-1216.,13760.,270.)
set life=GetUnitState(gg_unit_h07N_0415,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h07N_0415,UNIT_STATE_LIFE,.5*life)
set gg_unit_h07O_0416=CreateUnit(p,'h07O',7040.,15360.,270.)
set life=GetUnitState(gg_unit_h07O_0416,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h07O_0416,UNIT_STATE_LIFE,.5*life)
set gg_unit_h07P_0417=CreateUnit(p,'h07P',-17472.,-13312.,270.)
set gg_unit_h07P_0418=CreateUnit(p,'h07P',-14336.,-17216.,270.)
set gg_unit_h07P_0419=CreateUnit(p,'h07P',-13632.,-14080.,270.)
set gg_unit_h07P_0420=CreateUnit(p,'h07P',-11584.,-15104.,270.)
set gg_unit_h07Q_0422=CreateUnit(p,'h07Q',-32.,6688.,270.)
set life=GetUnitState(gg_unit_h07Q_0422,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h07Q_0422,UNIT_STATE_LIFE,.5*life)
set gg_unit_h088_0545=CreateUnit(p,'h088',-320.,-7296.,270.)
set life=GetUnitState(gg_unit_h088_0545,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h088_0545,UNIT_STATE_LIFE,.5*life)
set gg_unit_h052_0627=CreateUnit(p,'h052',-7744.,14912.,270.)
set life=GetUnitState(gg_unit_h052_0627,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h052_0627,UNIT_STATE_LIFE,.5*life)
set gg_unit_h053_0628=CreateUnit(p,'h053',11008.,5824.,270.)
set life=GetUnitState(gg_unit_h053_0628,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h053_0628,UNIT_STATE_LIFE,.5*life)
set gg_unit_h05M_0632=CreateUnit(p,'h05M',24864.,15712.,270.)
set life=GetUnitState(gg_unit_h05M_0632,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h05M_0632,UNIT_STATE_LIFE,.5*life)
set gg_unit_h078_0695=CreateUnit(p,'h078',26432.,19904.,270.)
set life=GetUnitState(gg_unit_h078_0695,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h078_0695,UNIT_STATE_LIFE,.5*life)
set gg_unit_h07R_0791=CreateUnit(p,'h07R',2144.,15136.,270.)
set life=GetUnitState(gg_unit_h07R_0791,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h07R_0791,UNIT_STATE_LIFE,.5*life)
set gg_unit_h07F_0793=CreateUnit(p,'h07F',16288.,6240.,270.)
set life=GetUnitState(gg_unit_h07F_0793,UNIT_STATE_LIFE)
call SetUnitState(gg_unit_h07F_0793,UNIT_STATE_LIFE,.5*life)
endfunction
function CreateNeutralHostile takes nothing returns nothing
local player p=Player($C)
local unit u
local integer unitID
local trigger t
local real life
set gg_unit_N06V_0078=CreateUnit(p,'N06V',10586.6,-27920.5,154.53)
call SetHeroLevel(gg_unit_N06V_0078,20,false)
call SetHeroStr(gg_unit_N06V_0078,$A1,true)
call SetHeroAgi(gg_unit_N06V_0078,$9B,true)
call SetHeroInt(gg_unit_N06V_0078,$7E,true)
call SetUnitState(gg_unit_N06V_0078,UNIT_STATE_MANA,0)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,gg_unit_N06V_0078,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,gg_unit_N06V_0078,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function Unit000702_DropItems)
set gg_unit_Ecen_0090=CreateUnit(p,'Ecen',-16697.5,14806.8,181.77)
call SetHeroLevel(gg_unit_Ecen_0090,20,false)
call SetUnitState(gg_unit_Ecen_0090,UNIT_STATE_MANA,0)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,gg_unit_Ecen_0090,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,gg_unit_Ecen_0090,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function Unit000565_DropItems)
set u=CreateUnit(p,'ninf',6852.8,8895.5,209.46)
call SetUnitAcquireRange(u,200.)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function ItemTable000004_DropItems)
set gg_unit_H034_0111=CreateUnit(p,'H034',-2639.4,27867.2,338.23)
call SetHeroLevel(gg_unit_H034_0111,20,false)
call SetHeroStr(gg_unit_H034_0111,$B4,true)
call SetHeroAgi(gg_unit_H034_0111,'s',true)
call SetHeroInt(gg_unit_H034_0111,'t',true)
call SetUnitState(gg_unit_H034_0111,UNIT_STATE_MANA,0)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,gg_unit_H034_0111,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,gg_unit_H034_0111,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function Unit000306_DropItems)
set u=CreateUnit(p,'uabo',-2783.3,27200.3,4.192)
set u=CreateUnit(p,'uabo',-2692.4,27501.5,352.534)
set u=CreateUnit(p,'uabo',-2567.4,27285.,1.203)
set u=CreateUnit(p,'uabo',-2493.3,28190.8,324.746)
set u=CreateUnit(p,'uabo',-2351.8,28481.6,313.284)
set u=CreateUnit(p,'uabo',-2231.6,28219.1,317.251)
set u=CreateUnit(p,'unec',-3022.6,27297.5,351.71)
set u=CreateUnit(p,'unec',-2959.2,27447.8,355.475)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'unec',-2912.2,27591.6,350.467)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'uske',-2658.7,27219.,3.807)
set u=CreateUnit(p,'uske',-2425.8,27295.5,.835)
set u=CreateUnit(p,'uske',-2546.3,27448.4,354.017)
set u=CreateUnit(p,'uske',-2472.2,27175.9,6.387)
set u=CreateUnit(p,'uske',-2464.1,27376.9,356.969)
set u=CreateUnit(p,'uske',-2322.7,28118.7,323.054)
set u=CreateUnit(p,'uske',-2209.2,28432.3,310.558)
set u=CreateUnit(p,'uske',-2030.8,28191.7,311.578)
set u=CreateUnit(p,'uske',-2114.6,28259.2,312.382)
set u=CreateUnit(p,'uske',-2109.4,28074.4,318.42)
set u=CreateUnit(p,'h01U',-2837.3,27361.6,358.232)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'h01U',-2381.,28325.,318.145)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'h01U',-2508.5,27592.7,347.447)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'h01U',-2453.3,27785.5,338.532)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'h01U',-2379.8,27942.1,330.856)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'unec',-2718.2,28249.,327.457)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'unec',-2634.3,28387.4,322.157)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'unec',-2569.5,28546.,316.914)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'nrvd',-2708.3,27332.4,359.224)
set u=CreateUnit(p,'nrvd',-2340.9,28198.6,320.896)
set u=CreateUnit(p,'nrvd',-2484.,28378.1,319.171)
set u=CreateUnit(p,'nrvd',-2592.5,28244.7,325.209)
set u=CreateUnit(p,'nrvd',-2915.4,27301.3,.39)
set u=CreateUnit(p,'nrvd',-2823.4,27520.2,352.482)
set u=CreateUnit(p,'nrvd',-365.2,26670.8,318.59)
call SetUnitState(u,UNIT_STATE_MANA,0)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function ItemTable000004_DropItems)
set u=CreateUnit(p,'nrvd',-46.7,26978.1,285.391)
call SetUnitState(u,UNIT_STATE_MANA,0)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function ItemTable000004_DropItems)
set u=CreateUnit(p,'nskg',-408.2,26409.1,340.15)
set u=CreateUnit(p,'nskg',-317.1,26507.6,327.686)
set u=CreateUnit(p,'nskg',-198.8,26626.6,310.711)
set u=CreateUnit(p,'nskg',-5.2,26801.,286.027)
set u=CreateUnit(p,'nskg',95.4,26888.7,275.951)
set u=CreateUnit(p,'nskg',184.6,26969.2,268.692)
set u=CreateUnit(p,'unec',-544.3,26694.5,325.268)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'unec',-478.4,26770.4,318.602)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'unec',-406.2,26832.6,312.243)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'unec',-179.5,27037.8,292.505)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'unec',-107.2,27105.,286.882)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'unec',-46.6,27180.5,282.313)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'nfor',1898.8,14912.8,211.759)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nfor',1832.8,15463.4,144.788)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function ItemTable000004_DropItems)
set u=CreateUnit(p,'nubk',1811.3,14835.,209.177)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nubk',1970.2,14790.,197.471)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nubk',1940.8,15536.2,82.752)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nubk',1714.2,15410.,107.575)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nitw',8327.8,27169.,227.251)
call SetUnitAcquireRange(u,200.)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function ItemTable000004_DropItems)
set u=CreateUnit(p,'nith',8576.5,27084.9,207.639)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nith',8219.,27430.5,247.874)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nits',8390.7,26930.7,201.621)
call SetUnitAcquireRange(u,200.)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function ItemTable000004_DropItems)
set u=CreateUnit(p,'nits',8164.4,27207.5,244.076)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nith',4093.5,25780.1,57.386)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nith',4302.5,25717.8,86.555)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nith',4205.,25854.4,67.139)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nmit',-2782.7,22856.8,93.227)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nmit',-2596.1,22903.3,109.213)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nmam',-7539.,21477.4,7.66)
call SetUnitAcquireRange(u,200.)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function ItemTable000004_DropItems)
set u=CreateUnit(p,'nmam',-7762.2,21558.1,359.35)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nmam',-7620.,21630.9,352.487)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nbdo',-9678.6,25386.2,308.18)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nbdo',-9458.2,26156.5,4.921)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nbdo',-10219.4,26259.3,107.901)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nbdo',-10226.4,25550.8,225.548)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nbds',-9952.2,25325.1,256.594)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nbds',-9400.4,25737.4,345.32)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function ItemTable000004_DropItems)
set u=CreateUnit(p,'nbds',-10279.6,25926.,164.303)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nbds',-9773.7,26315.4,64.6)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function ItemTable000004_DropItems)
set u=CreateUnit(p,'nnwq',-3841.5,-15238.3,3.673)
set u=CreateUnit(p,'nnwq',-4455.6,-14685.6,86.935)
set u=CreateUnit(p,'nnwr',-4221.2,-14807.9,108.279)
set u=CreateUnit(p,'nnwr',-4623.2,-14794.1,72.402)
set u=CreateUnit(p,'nnwr',-4026.8,-15063.1,340.802)
set u=CreateUnit(p,'nnwr',-4029.7,-15379.2,19.113)
set u=CreateUnit(p,'nbal',7099.3,8742.8,190.696)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nbal',6741.7,9136.5,232.225)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nfgb',6887.6,8679.3,188.381)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nfgb',6635.,8948.1,228.43)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nfgb',6666.,8775.6,207.615)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nfgb',6767.1,8651.7,187.124)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nbal',4853.4,8327.2,312.56)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function ItemTable000004_DropItems)
set u=CreateUnit(p,'nfel',4857.6,8080.,328.928)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nfel',5075.2,8272.2,299.717)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nsrw',-420.6,2747.1,285.448)
set u=CreateUnit(p,'nsrn',-294.9,2701.3,271.517)
set u=CreateUnit(p,'nsra',-380.3,2611.2,285.037)
set u=CreateUnit(p,'nsrw',-490.8,4593.5,96.823)
set u=CreateUnit(p,'nsrh',-619.2,4634.6,87.646)
set u=CreateUnit(p,'nsrh',-558.3,4474.6,91.808)
set u=CreateUnit(p,'nsog',-9217.9,15781.4,207.979)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nsog',-9089.8,15611.5,191.64)
call SetUnitAcquireRange(u,200.)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function ItemTable000004_DropItems)
set u=CreateUnit(p,'nsko',-9241.4,15657.,198.693)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nsog',-13319.9,15288.4,310.294)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nsog',-13266.6,15424.9,299.739)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nsog',-13214.,15318.3,300.45)
call SetUnitAcquireRange(u,200.)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function ItemTable000004_DropItems)
set u=CreateUnit(p,'nfpu',-14029.4,18825.7,344.748)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nfpt',-13864.7,19047.2,323.403)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nfpt',-14080.,19009.,333.93)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function ItemTable000004_DropItems)
set u=CreateUnit(p,'nrvd',-25619.3,15232.6,318.04)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function ItemTable000004_DropItems)
set u=CreateUnit(p,'nrvl',-25582.8,15444.7,301.305)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function ItemTable000004_DropItems)
set u=CreateUnit(p,'nrvl',-25614.5,15631.1,296.37)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nrvl',-25771.8,15166.,333.177)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nrvl',-25947.4,15093.6,344.728)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n021',-21400.,-3707.6,90.475)
set u=CreateUnit(p,'n021',-21430.9,-2784.3,308.495)
set u=CreateUnit(p,'n020',-21225.2,-3121.7,288.751)
set u=CreateUnit(p,'n020',-21515.2,-3467.1,255.066)
set u=CreateUnit(p,'n020',-21252.7,-3588.7,203.594)
set gg_unit_u024_0228=CreateUnit(p,'u024',6722.9,-15033.,270.)
call SetUnitState(gg_unit_u024_0228,UNIT_STATE_MANA,0)
call SetUnitColor(gg_unit_u024_0228,ConvertPlayerColor(1))
call SetUnitAcquireRange(gg_unit_u024_0228,200.)
set u=CreateUnit(p,'unec',6877.2,-14992.5,270.)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'unec',6999.3,-15001.7,270.)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'unec',6944.8,-15085.1,270.)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'h084',-5282.1,-20492.6,270.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'h084',-6130.9,-21264.1,.0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'h084',-5274.7,-22116.,90.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n07N',-5719.,-22200.7,90.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n07N',-5494.5,-22209.2,90.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n07N',-5020.8,-22224.,90.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n07N',-4804.7,-22239.8,90.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n07N',-6355.,-21702.2,.0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n07N',-6356.4,-21482.3,.0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n07N',-6382.,-21078.4,.0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n07N',-6405.4,-20814.2,.0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n07N',-5797.4,-20323.5,270.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n07N',-5521.3,-20354.3,270.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n07N',-5017.1,-20370.9,270.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n07N',-4770.2,-20370.4,270.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n07H',-5643.3,-21989.3,90.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n07H',-4901.,-22016.9,90.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ugho',-353.9,26318.6,347.322)
set u=CreateUnit(p,'ugho',-288.2,26406.7,335.725)
set u=CreateUnit(p,'ugho',-220.5,26470.8,325.198)
set u=CreateUnit(p,'ugho',-155.3,26535.1,314.011)
set u=CreateUnit(p,'ugho',4.7,26720.1,287.377)
set u=CreateUnit(p,'ugho',111.4,26794.4,275.363)
set u=CreateUnit(p,'ugho',194.2,26857.3,267.627)
set u=CreateUnit(p,'ugho',269.6,26939.9,262.093)
set u=CreateUnit(p,'ugho',331.4,26858.9,255.968)
set u=CreateUnit(p,'ugho',250.8,26784.9,261.838)
set u=CreateUnit(p,'ugho',165.2,26739.9,270.199)
set u=CreateUnit(p,'ugho',79.8,26662.3,280.719)
set u=CreateUnit(p,'ugho',-91.9,26464.3,314.555)
set u=CreateUnit(p,'ugho',-174.1,26406.7,328.963)
set u=CreateUnit(p,'ugho',-221.9,26358.4,338.017)
set u=CreateUnit(p,'ugho',-300.3,26281.,350.333)
set u=CreateUnit(p,'n07H',-6129.3,-21576.3,.0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n07H',-6169.,-20871.6,.0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n07H',-5623.3,-20528.8,270.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n07H',-4897.7,-20540.,270.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ngh2',-199.9,-23547.9,15.478)
set u=CreateUnit(p,'ngh2',-55.,-23848.2,35.054)
set u=CreateUnit(p,'nrvd',400.5,-23755.9,53.631)
set u=CreateUnit(p,'nrvd',384.6,-23583.3,39.41)
set u=CreateUnit(p,'nrvd',58.5,-23797.9,36.656)
set u=CreateUnit(p,'nrvd',-53.8,-23522.3,16.46)
set u=CreateUnit(p,'nrvd',220.3,-23305.3,2.122)
set u=CreateUnit(p,'nrvd',338.7,-23403.9,16.147)
set u=CreateUnit(p,'nrvd',1128.9,-24215.9,118.441)
set u=CreateUnit(p,'nrvd',1297.1,-24098.5,141.461)
set u=CreateUnit(p,'nrvd',-966.4,-23763.6,3.296)
set u=CreateUnit(p,'nrvd',-697.,-24104.3,50.887)
set u=CreateUnit(p,'nrvd',-518.7,-24130.6,72.574)
set u=CreateUnit(p,'nrvd',-942.6,-23523.,339.306)
set u=CreateUnit(p,'nrvd',-922.,-22695.7,299.591)
set gg_unit_U00T_0284=CreateUnit(p,'U00T',-919.3,-23985.3,25.83)
call SetHeroLevel(gg_unit_U00T_0284,20,false)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,gg_unit_U00T_0284,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,gg_unit_U00T_0284,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function Unit000284_DropItems)
set gg_unit_N055_0288=CreateUnit(p,'N055',4331.2,-27997.,91.99)
call SetHeroLevel(gg_unit_N055_0288,20,false)
call SetHeroStr(gg_unit_N055_0288,$BE,true)
call SetHeroAgi(gg_unit_N055_0288,'d',true)
call SetHeroInt(gg_unit_N055_0288,$82,true)
call SetUnitState(gg_unit_N055_0288,UNIT_STATE_MANA,0)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,gg_unit_N055_0288,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,gg_unit_N055_0288,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function Unit000599_DropItems)
set u=CreateUnit(p,'nftk',15163.7,-3552.9,315.94)
call SetUnitAcquireRange(u,200.)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function ItemTable000004_DropItems)
set u=CreateUnit(p,'nftr',15406.4,-3328.1,298.087)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nftr',14878.9,-3625.3,327.725)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nftr',15057.1,-3686.6,325.343)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nftr',15373.3,-3498.9,304.719)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nftk',14975.7,-3504.3,320.453)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nftk',15206.7,-3347.5,307.205)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'N01R',-12781.1,-21798.,11.61)
call SetHeroLevel(u,5,false)
call SetUnitState(u,UNIT_STATE_MANA,'d')
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n01E',-12484.1,-22104.1,28.956)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n01E',-12478.1,-21920.7,20.897)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n01E',-12592.6,-21555.9,1.768)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nggr',23764.,13614.7,81.45)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function ItemTable000004_DropItems)
set u=CreateUnit(p,'ngst',24019.7,13635.2,109.443)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ngst',23542.1,13596.3,60.936)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nmrr',14220.9,18254.,195.192)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nmrr',14139.8,18373.8,212.938)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nmrr',14247.7,18377.1,207.041)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nmrr',14311.,18253.9,192.78)
call SetUnitAcquireRange(u,200.)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function ItemTable000004_DropItems)
set u=CreateUnit(p,'nmrr',14315.2,18467.7,211.469)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nogm',-22243.7,-13989.6,319.388)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nogm',-21972.8,-13917.,293.42)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nogm',-22087.8,-14102.2,317.32)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nchg',-15315.6,-21399.4,281.363)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nogl',-21531.9,-25061.,262.84)
call SetUnitAcquireRange(u,200.)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function ItemTable000004_DropItems)
set u=CreateUnit(p,'nogl',-21228.2,-25275.7,228.844)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nogl',-21421.4,-25239.2,232.954)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nogm',-26604.2,-24957.6,334.93)
call SetUnitAcquireRange(u,200.)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function ItemTable000004_DropItems)
set u=CreateUnit(p,'nogm',-26566.7,-24772.9,316.223)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nogm',-26803.6,-24972.3,343.223)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ninf',-13721.3,-19367.8,233.733)
set u=CreateUnit(p,'nbal',-13433.4,-19535.7,248.325)
set u=CreateUnit(p,'nchg',-15227.4,-21411.8,269.05)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ninf',-14046.1,-19999.,5.669)
set u=CreateUnit(p,'nvdw',-13908.1,-13674.9,230.22)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nvdw',-14111.4,-13605.1,246.72)
call SetUnitAcquireRange(u,200.)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function ItemTable000004_DropItems)
set u=CreateUnit(p,'nvdw',-14003.2,-13493.9,242.998)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nvdw',-14194.3,-13435.,256.518)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nvde',-15384.8,-17657.3,102.183)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nvdg',-15202.9,-17572.1,126.56)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function ItemTable000004_DropItems)
set u=CreateUnit(p,'nvdg',-15570.1,-17777.9,81.786)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nvdg',-15333.8,-17789.7,104.208)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nina',-11971.8,-26411.8,193.89)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nina',-12296.5,-25997.8,226.261)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nbal',-12279.3,-26478.1,194.714)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nbal',-12455.2,-26228.2,222.147)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nchg',-15152.8,-21413.9,258.298)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nchg',-15323.5,-21656.4,62.785)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nchg',-15231.3,-21656.,95.592)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nchg',-15151.3,-21663.7,120.923)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'h083',-4128.4,-20503.3,270.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'h083',-4202.3,-21864.,90.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'h083',-3438.4,-20766.5,270.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'h083',-3432.4,-21560.,90.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'h083',-3178.6,-20716.,270.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'h083',-3187.9,-21553.,90.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n07N',-5927.6,-21717.,.0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n07N',-5929.,-21497.1,.0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n07N',-5954.6,-21093.1,.0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n07N',-5978.,-20829.,.0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ncnk',-24416.1,11738.4,317.65)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function ItemTable000004_DropItems)
set u=CreateUnit(p,'ncim',-24265.,11987.,299.928)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ncim',-24678.6,11776.6,325.652)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ncen',-24599.5,11582.7,333.014)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ncen',-24190.7,11801.3,302.12)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ncen',-19357.8,2548.2,48.27)
call SetUnitAcquireRange(u,200.)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function ItemTable000004_DropItems)
set u=CreateUnit(p,'ndrs',-19173.8,-24072.7,116.76)
call SetUnitAcquireRange(u,200.)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function ItemTable000004_DropItems)
set u=CreateUnit(p,'ndrs',-19018.1,-23911.3,144.118)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ndrs',-19148.5,-23925.1,130.541)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ndrs',-19029.,-24024.4,133.398)
call SetUnitAcquireRange(u,200.)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function ItemTable000004_DropItems)
set u=CreateUnit(p,'ndrw',-25008.5,-21164.1,352.564)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ndrw',-24982.6,-20985.1,332.409)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ndrw',-24835.1,-20850.,310.023)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ndrh',-24875.2,-21103.9,340.834)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ndrh',-24849.9,-20976.8,322.91)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function ItemTable000004_DropItems)
set u=CreateUnit(p,'ndrd',-24746.6,-21074.6,326.166)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nwzr',13385.3,-3190.4,110.445)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nwzr',13568.1,-3037.5,129.829)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nban',13094.,-3155.9,86.378)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nban',13211.2,-3024.6,98.614)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nban',13365.5,-2896.5,121.376)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nban',13560.3,-2857.6,141.388)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nass',13280.6,-3209.7,101.925)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nass',13530.,-3158.6,121.68)
call SetUnitAcquireRange(u,200.)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function ItemTable000004_DropItems)
set u=CreateUnit(p,'nass',12809.,-3191.1,64.211)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ncen',-19468.3,2668.8,31.813)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ncer',-22475.8,734.1,7.204)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ncer',-22586.1,904.3,356.741)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ncer',-22467.2,927.1,354.84)
call SetUnitAcquireRange(u,200.)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function ItemTable000004_DropItems)
set u=CreateUnit(p,'ncer',-22363.7,844.2,.213)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ncer',-22499.8,1098.7,344.677)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ncen',-20060.2,8578.4,93.185)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ncea',-19971.8,8517.5,101.02)
call SetUnitAcquireRange(u,200.)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function ItemTable000004_DropItems)
set u=CreateUnit(p,'ncea',-19839.,8632.5,116.913)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nsat',-22802.3,13633.4,262.46)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function ItemTable000004_DropItems)
set u=CreateUnit(p,'nsat',-22968.8,13659.3,284.54)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nstl',-22853.5,13780.4,269.716)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ugho',20025.3,17585.9,13.669)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ugho',19939.6,17746.3,359.59)
call SetUnitAcquireRange(u,200.)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function ItemTable000004_DropItems)
set u=CreateUnit(p,'n03T',-19081.7,-8419.2,86.008)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n03T',-19215.3,-8352.,78.721)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ugho',20079.7,17712.9,2.77)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ugho',20029.4,17865.6,348.901)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n03T',-19113.5,-8266.6,83.552)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n03T',-18621.6,-8435.,108.33)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n03T',-18509.,-8384.2,114.18)
call SetUnitAcquireRange(u,200.)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function ItemTable000004_DropItems)
set u=CreateUnit(p,'nfod',-6437.8,-27167.7,90.)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'nfod',-6165.,-27158.2,90.)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'nfod',-5885.4,-27174.,90.)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'nfod',-6007.4,-26981.9,90.)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'nfod',-6319.8,-26988.8,90.)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'nfot',-5789.,-26933.5,90.)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'nfot',-5991.5,-26769.1,90.)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'nfot',-6343.6,-26747.7,90.)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'nfot',-6562.,-26971.9,90.)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'nfod',-6328.5,-25005.1,270.)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'nfod',-6114.8,-25005.1,270.)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'nfod',-5849.9,-24996.,270.)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'nfod',-5955.8,-25224.,270.)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'nfod',-6199.6,-25215.7,270.)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'nfot',-6433.9,-25219.6,270.)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'nfot',-6232.8,-25388.1,270.)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'nfot',-5981.9,-25390.,270.)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'nfot',-5725.7,-25224.3,270.)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'nubw',-5095.1,-26564.1,68.336)
set u=CreateUnit(p,'nubw',-4932.4,-26557.9,80.084)
set u=CreateUnit(p,'nubw',-4766.3,-26566.2,93.155)
set u=CreateUnit(p,'nubw',-4590.7,-26568.3,106.442)
set u=CreateUnit(p,'nubw',-5112.3,-25661.1,287.602)
set u=CreateUnit(p,'nubw',-4953.4,-25642.7,276.163)
set u=CreateUnit(p,'nubw',-4751.9,-25650.6,261.497)
set u=CreateUnit(p,'nubw',-4577.5,-25645.4,249.652)
set u=CreateUnit(p,'nfod',-4655.,-25445.5,257.769)
set u=CreateUnit(p,'nfod',-5048.9,-25431.2,280.243)
set u=CreateUnit(p,'nfod',-5026.7,-26814.5,77.299)
set u=CreateUnit(p,'nfod',-4688.2,-26794.7,97.041)
set u=CreateUnit(p,'nfot',-4069.6,-27124.4,86.713)
set u=CreateUnit(p,'nfot',-3887.1,-27124.4,97.337)
set u=CreateUnit(p,'nfot',-3962.5,-26960.5,93.564)
set u=CreateUnit(p,'nfod',-3967.2,-27227.1,92.436)
set u=CreateUnit(p,'nfod',-5394.6,-26461.7,13.71)
set u=CreateUnit(p,'nfod',-5409.2,-26270.1,5.088)
set u=CreateUnit(p,'nfod',-5419.4,-26080.6,356.511)
set u=CreateUnit(p,'nfod',-5429.1,-25892.,348.257)
set u=CreateUnit(p,'nfod',-5233.1,-25886.,345.909)
set u=CreateUnit(p,'nfod',-5229.,-26052.4,354.411)
set u=CreateUnit(p,'nfod',-5236.2,-26264.9,5.619)
set u=CreateUnit(p,'nfod',-5225.3,-26395.2,12.439)
set u=CreateUnit(p,'nfod',-484.,-27527.9,8.216)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nfod',-506.6,-26492.5,305.157)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nfod',-2.9,-28212.,78.198)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nfod',252.7,-28210.1,91.811)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nfod',495.3,-28217.5,104.497)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'esen',-16864.2,14484.4,160.033)
set u=CreateUnit(p,'esen',-16862.9,14621.5,169.095)
set u=CreateUnit(p,'esen',-16732.8,14563.8,167.18)
set u=CreateUnit(p,'nfod',-606.4,-26938.7,350.643)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nfod',-532.3,-27238.5,359.283)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nfot',-319.3,-27651.3,199.595)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nfot',-306.8,-27468.5,7.072)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nfot',-358.8,-27308.5,1.547)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nfot',-414.8,-27103.5,354.881)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nfot',-468.2,-26918.8,349.344)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nfot',-495.8,-26748.4,344.497)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nfot',-352.7,-26505.3,296.63)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nfot',-67.4,-27935.4,69.972)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nfot',82.4,-27935.4,80.136)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nfot',375.,-27935.4,101.216)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nfot',551.6,-27939.6,112.816)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'esen',-16902.,15013.4,197.143)
set u=CreateUnit(p,'esen',-16746.3,15015.6,194.506)
set u=CreateUnit(p,'esen',-16801.6,15166.4,204.183)
set u=CreateUnit(p,'emtg',-16663.3,14392.3,159.078)
set u=CreateUnit(p,'emtg',-16625.,15171.,200.682)
set u=CreateUnit(p,'emtg',-16484.1,14971.,189.306)
set u=CreateUnit(p,'nnrg',-23.4,-27734.3,55.856)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nnrg',442.3,-27748.,109.545)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nnrg',-205.5,-26854.6,345.376)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nnrg',-158.2,-27145.6,355.601)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nnrg',-127.6,-27442.5,6.927)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'emtg',-16500.4,14639.3,173.29)
set u=CreateUnit(p,'edot',-16452.8,15267.3,201.959)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'edot',-16352.4,15114.2,194.373)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'nnmg',40.6,-26898.5,322.392)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nnmg',58.6,-27047.,329.778)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nnmg',109.2,-27227.1,340.386)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nnmg',155.3,-27455.2,359.141)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nnmg',396.2,-27503.,5.806)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'edot',-16335.1,15298.6,201.363)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'edot',-16378.3,14565.5,170.702)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'edot',-16254.3,14706.7,177.163)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'edot',-16264.,14562.,171.309)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'edry',-16609.7,15026.3,193.252)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'H085',-21380.,-6099.9,153.572)
call SetHeroLevel(u,$F,false)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
call SelectHeroSkill(u,'A0AN')
call SelectHeroSkill(u,'A0AN')
call SelectHeroSkill(u,'A0AN')
call SelectHeroSkill(u,'A0CW')
call SelectHeroSkill(u,'A0AQ')
call SelectHeroSkill(u,'A0AQ')
call SelectHeroSkill(u,'A0AQ')
call SelectHeroSkill(u,'A0AU')
set u=CreateUnit(p,'h083',-21381.8,-6604.5,125.619)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'h083',-20905.,-6046.5,167.676)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'u023',-21184.6,-5882.7,175.24)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'u023',-21539.3,-6381.2,125.787)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'unec',6584.9,-14971.5,270.)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'unec',6456.7,-14973.1,270.)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'unec',6524.,-15077.1,270.)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'uabo',7010.1,-15370.2,270.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'uabo',6792.8,-15382.1,270.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'uabo',6603.8,-15383.2,270.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'uabo',6410.4,-15362.2,270.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'uabo',7091.9,-15127.3,270.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'uabo',6303.3,-15099.2,270.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'umtw',6527.,-14828.4,270.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'umtw',6946.5,-14833.5,270.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'uban',6461.1,-15209.9,270.)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'uban',6934.2,-15211.9,270.)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n02O',-631.2,-7983.3,180.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n02Q',-4102.5,-10504.7,101.577)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n02O',-307.3,-7619.8,139.643)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n02O',-495.9,-6792.8,203.901)
call SetUnitAcquireRange(u,200.)
set gg_unit_n02S_0532=CreateUnit(p,'n02S',-801.5,-7281.5,180.)
call SetUnitState(gg_unit_n02S_0532,UNIT_STATE_MANA,0)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,gg_unit_n02S_0532,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,gg_unit_n02S_0532,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function ItemTable000003_DropItems)
set u=CreateUnit(p,'n02R',-907.,-6770.1,180.)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function ItemTable000004_DropItems)
set u=CreateUnit(p,'n02R',-994.7,-7601.1,180.)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n02Q',-3888.7,-10427.,115.723)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n02Q',-756.1,-7653.3,180.)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n02Q',-711.4,-6909.2,180.)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n02Q',-807.3,-7928.5,180.)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n02Q',-578.9,-6953.2,180.)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n02Q',-564.,-7627.3,180.)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n02Q',-696.9,-6760.9,180.)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n02Q',-4020.7,-10357.1,109.409)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n02R',-3973.8,-10547.5,108.316)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n02R',-8979.1,-7754.8,303.929)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n02R',-8737.3,-7750.3,287.989)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n02Q',-8852.6,-7886.4,301.209)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n02Q',-8587.6,-7710.,276.038)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n02R',7640.1,-8650.6,162.645)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n02R',7608.9,-8427.7,180.293)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n02R',7772.5,-8305.6,188.553)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n07O',14912.4,11978.5,205.19)
call SetUnitAcquireRange(u,200.)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function ItemTable000004_DropItems)
set u=CreateUnit(p,'n07O',15371.6,11808.1,28.77)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n07O',16032.1,11898.8,287.76)
call SetUnitAcquireRange(u,200.)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function ItemTable000004_DropItems)
set u=CreateUnit(p,'n07O',16079.2,12677.8,312.022)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n07O',15705.8,12101.8,312.022)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n07P',15683.2,11723.8,285.576)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n07P',16263.6,12226.9,163.328)
call SetUnitAcquireRange(u,200.)
set gg_unit_n02T_0564=CreateUnit(p,'n02T',-14236.4,-19530.,339.352)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,gg_unit_n02T_0564,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,gg_unit_n02T_0564,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function Unit000564_DropItems)
set u=CreateUnit(p,'ndrd',-12131.,-26518.9,189.147)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ndrd',-12527.8,-26001.,238.923)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ndrd',-12647.,-26197.3,239.014)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ndrd',-12557.,-26327.6,221.505)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ndrd',-12431.6,-26542.5,191.987)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ndrd',-12362.4,-26630.4,181.545)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ndrs',-11907.9,-26237.8,202.009)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ndrs',-12125.9,-26001.,219.194)
call SetUnitAcquireRange(u,200.)
set gg_unit_Eevi_0573=CreateUnit(p,'Eevi',-12119.5,-26192.7,211.44)
call SetHeroLevel(gg_unit_Eevi_0573,20,false)
call SetHeroStr(gg_unit_Eevi_0573,$9B,true)
call SetHeroAgi(gg_unit_Eevi_0573,$84,true)
call SetHeroInt(gg_unit_Eevi_0573,'o',true)
call SetUnitAcquireRange(gg_unit_Eevi_0573,200.)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,gg_unit_Eevi_0573,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,gg_unit_Eevi_0573,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function Unit000384_DropItems)
set u=CreateUnit(p,'n03T',-18605.4,-8289.9,111.564)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n03T',-18880.9,-8400.2,96.227)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n03T',-18790.6,-8406.5,100.703)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n03T',-18841.6,-8260.,99.372)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n03T',-19654.1,-6475.6,353.95)
call SetUnitAcquireRange(u,200.)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function ItemTable000004_DropItems)
set u=CreateUnit(p,'n03T',-19634.8,-6270.9,332.218)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n03T',-19525.4,-6435.8,346.192)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n03T',-18715.8,-8245.6,111.564)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n03T',-18987.5,-8242.3,83.552)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'edry',-16631.5,14560.3,168.214)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'edry',-16541.,14727.2,177.481)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'edry',-16517.6,14886.6,185.444)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'earc',-16311.5,14962.4,187.782)
set u=CreateUnit(p,'earc',-16319.7,14842.5,182.786)
set u=CreateUnit(p,'earc',-16333.5,14694.7,176.481)
set u=CreateUnit(p,'earc',-16413.5,14902.4,185.712)
set u=CreateUnit(p,'earc',-16418.1,14789.6,180.585)
set u=CreateUnit(p,'n00G',-17023.1,14487.4,155.869)
set u=CreateUnit(p,'n00G',-17030.5,14665.2,170.085)
set u=CreateUnit(p,'n00G',-17035.2,14932.2,193.768)
set u=CreateUnit(p,'n00G',-17014.6,15114.5,207.289)
set u=CreateUnit(p,'e000',-16889.9,14731.4,176.663)
set u=CreateUnit(p,'e000',-16895.9,14889.5,188.294)
set u=CreateUnit(p,'e000',-16803.8,14911.7,188.857)
set u=CreateUnit(p,'e000',-16795.4,14709.6,175.601)
set u=CreateUnit(p,'e000',-16814.,14815.9,182.613)
set u=CreateUnit(p,'nlv3',3784.1,-27965.7,74.338)
set u=CreateUnit(p,'nlv3',3934.9,-27718.,77.286)
set u=CreateUnit(p,'nlv3',4024.6,-27959.4,81.911)
set u=CreateUnit(p,'nlv3',4566.2,-28040.4,99.304)
set u=CreateUnit(p,'nlv3',4816.5,-28018.8,107.013)
set u=CreateUnit(p,'nlv3',4654.,-27781.6,103.924)
set u=CreateUnit(p,'nlv3',3849.2,-26730.3,49.777)
set u=CreateUnit(p,'nlv3',3959.6,-27035.9,68.87)
set u=CreateUnit(p,'nlv3',4618.1,-26970.8,115.248)
set u=CreateUnit(p,'nlv3',4628.8,-26739.,125.325)
set u=CreateUnit(p,'n01E',-12720.3,-21455.8,357.156)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n07O',23001.8,23002.2,53.417)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n07O',22804.7,23163.4,338.243)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n07Q',26746.6,23853.,235.65)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nlv3',3904.3,-27839.2,77.286)
set u=CreateUnit(p,'nlv3',4673.8,-27911.2,103.924)
set u=CreateUnit(p,'ucry',23482.3,19371.3,88.845)
call SetUnitAcquireRange(u,200.)
set gg_unit_N05H_0633=CreateUnit(p,'N05H',-18838.2,-8590.2,89.87)
call SetHeroLevel(gg_unit_N05H_0633,20,false)
call SetHeroStr(gg_unit_N05H_0633,$A6,true)
call SetHeroAgi(gg_unit_N05H_0633,'x',true)
call SetHeroInt(gg_unit_N05H_0633,$82,true)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,gg_unit_N05H_0633,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,gg_unit_N05H_0633,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function Unit000631_DropItems)
set gg_unit_n06P_0634=CreateUnit(p,'n06P',21602.3,3403.4,3.79)
call SetUnitState(gg_unit_n06P_0634,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(gg_unit_n06P_0634,200.)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,gg_unit_n06P_0634,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,gg_unit_n06P_0634,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function Unit000634_DropItems)
set u=CreateUnit(p,'n04D',21644.4,3202.6,20.657)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n04D',21671.3,3578.6,348.405)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n04G',21831.2,3506.8,353.043)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n04G',21825.7,3354.,11.408)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nchg',21921.1,3511.2,340.276)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nchg',21913.7,3395.3,.494)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nchg',21923.2,3270.7,22.092)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nchg',21719.7,3492.3,355.795)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nchg',21713.1,3393.1,5.503)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nchg',21718.,3307.3,13.746)
call SetUnitAcquireRange(u,200.)
set gg_unit_Hkal_0645=CreateUnit(p,'Hkal',-12019.4,-16737.6,180.)
call SetHeroLevel(gg_unit_Hkal_0645,20,false)
call SetHeroStr(gg_unit_Hkal_0645,'l',true)
call SetHeroAgi(gg_unit_Hkal_0645,$81,true)
call SetHeroInt(gg_unit_Hkal_0645,$C2,true)
call SetUnitState(gg_unit_Hkal_0645,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(gg_unit_Hkal_0645,200.)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,gg_unit_Hkal_0645,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,gg_unit_Hkal_0645,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function Unit000645_DropItems)
set u=CreateUnit(p,'h02Z',-12073.8,-17066.6,180.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'h02Z',-12098.2,-16917.9,180.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'h02Z',-12124.8,-16550.8,180.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'h02Z',-12152.7,-16401.8,180.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'h02Z',-12258.7,-16987.4,180.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'h02Z',-12275.7,-16454.3,180.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'h02P',-12397.,-17087.1,180.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'h02P',-12424.9,-16966.1,180.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'h02P',-12427.3,-16900.9,180.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'h02P',-12438.6,-16788.4,180.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'h02P',-12437.4,-16636.,180.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'h02P',-12431.2,-16494.4,180.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'h02P',-12444.4,-16372.2,180.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'h02P',-12434.4,-16290.7,180.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n026',-12222.9,-17191.6,180.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n026',-12284.4,-16321.2,180.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n026',-12268.3,-16828.9,180.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n026',-12280.7,-16676.2,180.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'h030',-11958.8,-17057.4,180.)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'h030',-11958.,-16949.3,180.)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'h030',-12002.,-16477.3,180.)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'h030',-12000.3,-16339.3,180.)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set gg_unit_N06Q_0668=CreateUnit(p,'N06Q',2557.9,-16497.5,87.61)
call SetHeroLevel(gg_unit_N06Q_0668,20,false)
call SetHeroStr(gg_unit_N06Q_0668,$D7,true)
call SetHeroAgi(gg_unit_N06Q_0668,'d',true)
call SetHeroInt(gg_unit_N06Q_0668,$82,true)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,gg_unit_N06Q_0668,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,gg_unit_N06Q_0668,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function Unit000668_DropItems)
set u=CreateUnit(p,'nsel',1821.5,-16312.8,45.615)
set u=CreateUnit(p,'nsel',2116.5,-16464.2,62.975)
set u=CreateUnit(p,'nsel',3005.7,-16494.8,112.624)
set u=CreateUnit(p,'nsel',3416.4,-16336.1,135.001)
set u=CreateUnit(p,'nrel',3256.4,-16557.6,122.326)
set u=CreateUnit(p,'nrel',1838.1,-16560.3,53.861)
set u=CreateUnit(p,'nrel',1964.6,-16175.2,45.995)
set u=CreateUnit(p,'nrel',2125.3,-16265.6,57.63)
set u=CreateUnit(p,'nrel',3118.7,-16259.6,125.05)
set u=CreateUnit(p,'nrel',3272.1,-16205.6,134.418)
set u=CreateUnit(p,'ntrd',3148.5,-16050.5,135.935)
set u=CreateUnit(p,'ntrd',2164.1,-16047.4,50.576)
set u=CreateUnit(p,'nsel',3228.3,-16399.4,125.548)
set u=CreateUnit(p,'nsel',2842.6,-16492.,104.056)
set u=CreateUnit(p,'nsel',2322.4,-16492.,74.147)
set u=CreateUnit(p,'nsel',1641.4,-16141.4,33.045)
set u=CreateUnit(p,'nsel',2038.2,-16682.2,64.273)
set u=CreateUnit(p,'nsel',2990.8,-16720.8,108.057)
set u=CreateUnit(p,'nsel',3196.5,-14348.6,224.028)
set u=CreateUnit(p,'nsel',3360.8,-14615.3,197.963)
set u=CreateUnit(p,'nsel',3180.6,-14574.2,207.951)
set u=CreateUnit(p,'nsel',3382.6,-14409.5,211.579)
set u=CreateUnit(p,'nsel',3259.6,-14122.9,231.562)
set u=CreateUnit(p,'nsel',3453.,-14875.8,176.539)
set u=CreateUnit(p,'ngh2',5412.5,-21259.,273.583)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n06W',9223.2,-28059.7,49.222)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'n06W',9397.,-28193.7,66.329)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'n06W',10556.7,-28286.8,140.191)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'n06W',10761.3,-28158.8,149.102)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'n06W',10919.2,-27805.4,164.104)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'n06W',10948.8,-27581.4,172.856)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'n06W',11002.2,-26654.9,109.502)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'n06W',11349.5,-26428.1,149.114)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'n06W',11215.8,-26595.4,129.736)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'n06W',8102.3,-26321.3,51.793)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'n06W',10981.4,-24643.,259.691)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'n06W',11259.7,-24888.1,228.457)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'n06W',11055.5,-24913.,245.02)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'n06W',8175.5,-27423.,10.478)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'n06W',8144.3,-27210.8,356.302)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'n06W',8362.1,-27024.9,339.717)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'ngst',10053.9,-28184.8,125.601)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'ngst',10192.9,-28036.1,137.752)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'ngst',10387.3,-27694.6,161.726)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'ngst',10488.6,-27532.8,172.341)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'ngst',9453.6,-27956.6,61.425)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'ngst',8328.2,-27534.7,21.197)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'ngst',8335.3,-27325.3,4.863)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'ngst',8527.5,-27000.7,331.47)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'ngst',10782.2,-26484.1,86.272)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'ngst',11094.,-26405.3,133.574)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'ngst',11249.4,-26145.2,174.632)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'nggr',9988.3,-27964.5,131.307)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'nggr',10262.,-27540.3,169.589)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'nggr',10709.2,-27650.9,168.303)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'nggr',10337.6,-28100.7,140.333)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'nggr',11209.7,-24688.7,241.568)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'ngst',8158.3,-26139.6,46.007)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'ngst',8326.2,-26206.8,61.368)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'ngst',8309.8,-26018.9,48.97)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'ucry',23338.1,19186.2,90.539)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ngh1',5538.3,-21262.8,262.455)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ngh1',5286.3,-21266.6,284.608)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ngh1',5996.2,-21209.7,278.944)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ngh1',6140.3,-21213.5,265.855)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ngh1',6070.6,-21326.2,272.738)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ngh2',4441.6,-22545.6,87.33)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ngh2',4602.6,-22545.6,103.051)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ngh2',4537.9,-22450.3,98.17)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set gg_unit_Ewrd_0749=CreateUnit(p,'Ewrd',3835.,-23578.8,357.4)
call SetHeroLevel(gg_unit_Ewrd_0749,20,false)
call SetHeroStr(gg_unit_Ewrd_0749,$80,true)
call SetHeroAgi(gg_unit_Ewrd_0749,$C8,true)
call SetHeroInt(gg_unit_Ewrd_0749,'j',true)
call SetUnitState(gg_unit_Ewrd_0749,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(gg_unit_Ewrd_0749,200.)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,gg_unit_Ewrd_0749,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,gg_unit_Ewrd_0749,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function Unit000382_DropItems)
set u=CreateUnit(p,'nssn',3944.1,-23939.6,13.711)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nssn',4105.8,-24055.9,21.293)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nssn',3920.7,-23291.7,344.488)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nssn',4094.2,-23150.3,335.621)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nssn',5526.6,-24030.3,82.289)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nssn',5771.3,-24030.3,99.408)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nssn',5692.6,-23910.,94.621)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nssn',3540.,-21832.1,358.075)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nssn',3545.6,-21646.6,344.939)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nssn',3660.2,-21740.2,350.022)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nssn',6111.,-22067.1,172.968)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nssn',6095.5,-21810.6,191.532)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nssn',5997.4,-21953.6,181.318)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nssn',6200.,-21943.2,181.694)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nssn',6227.8,-21778.3,191.856)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nssn',6212.3,-22147.9,168.703)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nowk',4298.9,-23880.1,15.371)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nowk',4267.5,-23398.5,345.107)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nowk',5866.6,-23829.8,110.59)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nowk',5446.2,-23850.,73.237)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nowk',5970.4,-22197.8,160.699)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nowk',5937.2,-21762.,198.506)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nowk',3906.4,-21783.7,350.037)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'earc',3768.2,-23307.2,346.696)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'earc',3891.4,-23134.3,338.496)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'earc',4066.,-23003.9,330.155)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'earc',4016.5,-23225.5,340.317)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'earc',3799.7,-23812.9,7.188)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'earc',4020.,-23985.2,16.677)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'earc',4218.,-24128.3,27.079)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'earc',3974.,-24131.4,22.29)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'earc',3825.8,-24036.7,16.416)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ebal',3604.9,-23936.3,10.71)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ebal',3568.2,-23758.3,4.227)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ebal',3608.3,-23394.7,351.112)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ebal',3604.3,-23174.2,343.485)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ebal',6073.2,-22339.3,153.897)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ebal',6112.9,-21652.2,201.745)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'emtg',4104.3,-23853.3,11.303)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'emtg',4086.9,-23660.8,1.118)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'emtg',4063.6,-23402.3,347.937)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nsra',-473.3,4699.6,99.228)
set u=CreateUnit(p,'uban',6605.4,-15202.6,270.)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'uban',6797.4,-15202.1,270.)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nnws',-1421.5,24903.1,270.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nnws',-1216.1,24922.9,270.)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nnwq',-1310.9,25104.6,270.)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nnwl',-1181.,25062.6,270.)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nnwl',-1373.6,25069.3,270.)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'nnwl',-1290.1,24982.5,270.)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n01E',-12657.7,-22005.2,21.538)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n01E',-12758.9,-21614.3,4.054)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n01M',-12294.,-21954.1,26.632)
call SetUnitState(u,UNIT_STATE_MANA,'d')
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n01M',-12441.2,-21363.7,351.229)
call SetUnitState(u,UNIT_STATE_MANA,'d')
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'u028',8231.4,-21973.4,18.093)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'u028',8157.4,-21846.,1.467)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'uske',22936.5,19737.6,2.83)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'uske',22836.9,19346.4,35.222)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'uske',23040.4,19188.1,54.602)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ugho',8258.,-21850.6,2.483)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'unec',9474.9,-22963.8,130.205)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'uske',9476.7,-22877.6,152.001)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'uske',9379.4,-22948.4,105.064)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'uske',8167.,-22636.8,356.261)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'uske',8208.3,-22571.7,337.861)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'uske',8227.7,-22692.1,12.505)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n07O',23218.4,23051.1,107.104)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'ugho',24490.6,27164.7,235.29)
set u=CreateUnit(p,'ucry',25084.4,27553.5,248.967)
set u=CreateUnit(p,'unec',24761.4,27813.9,348.2)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'unec',24889.5,28213.7,279.501)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'uban',24254.8,27528.5,90.706)
call SetUnitState(u,UNIT_STATE_MANA,0)
set u=CreateUnit(p,'n01O',-25478.9,-15726.7,264.812)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n01O',-25961.,-15902.2,313.339)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n01M',-25487.7,-15911.3,263.783)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n01M',-25322.9,-15899.2,244.864)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n01M',-25857.,-16036.2,315.408)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n01M',-26059.6,-16088.1,333.187)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n01Q',-25737.9,-15755.6,288.696)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n01N',-26209.6,-27333.8,69.131)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n01N',-26495.4,-27079.6,34.025)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n01E',-26048.5,-27253.4,82.519)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n01E',-26124.6,-27091.2,68.088)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n01E',-26479.1,-26895.4,18.165)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n01E',-26335.7,-26923.4,28.329)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n01P',-26541.5,-27240.5,42.18)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
set u=CreateUnit(p,'n01P',-26408.7,-27391.3,56.98)
call SetUnitState(u,UNIT_STATE_MANA,0)
call SetUnitAcquireRange(u,200.)
endfunction
function CreateNeutralPassiveBuildings takes nothing returns nothing
local player p=Player($F)
local unit u
local integer unitID
local trigger t
local real life
set u=CreateUnit(p,'n004',27136.,-27904.,270.)
call WaygateSetDestination(u,GetRectCenterX(gg_rct_SpawnPoint_EasternKingdom1),GetRectCenterY(gg_rct_SpawnPoint_EasternKingdom1))
call WaygateActivate(u,true)
call SetUnitColor(u,ConvertPlayerColor(8))
set u=CreateUnit(p,'n003',27136.,-25216.,270.)
call WaygateSetDestination(u,GetRectCenterX(gg_rct_SpawnPoint_EasternKingdom2),GetRectCenterY(gg_rct_SpawnPoint_EasternKingdom2))
call WaygateActivate(u,true)
call SetUnitColor(u,ConvertPlayerColor(1))
set u=CreateUnit(p,'n006',24448.,-27904.,270.)
call WaygateSetDestination(u,GetRectCenterX(gg_rct_SpawnPoint_Kalimdor1),GetRectCenterY(gg_rct_SpawnPoint_Kalimdor1))
call WaygateActivate(u,true)
call SetUnitColor(u,ConvertPlayerColor(5))
set u=CreateUnit(p,'n005',24448.,-25216.,270.)
call WaygateSetDestination(u,GetRectCenterX(gg_rct_SpawnPoint_Kalimdor2),GetRectCenterY(gg_rct_SpawnPoint_Kalimdor2))
call WaygateActivate(u,true)
call SetUnitColor(u,ConvertPlayerColor(6))
set u=CreateUnit(p,'n007',25344.,-25216.,270.)
call WaygateSetDestination(u,GetRectCenterX(gg_rct_SpawnPoint_Northland1),GetRectCenterY(gg_rct_SpawnPoint_Northland1))
call WaygateActivate(u,true)
call SetUnitColor(u,ConvertPlayerColor(2))
set u=CreateUnit(p,'n008',26240.,-25216.,270.)
call WaygateSetDestination(u,GetRectCenterX(gg_rct_SpawnPoint_Northland2),GetRectCenterY(gg_rct_SpawnPoint_Northland2))
call WaygateActivate(u,true)
call SetUnitColor(u,ConvertPlayerColor(9))
set u=CreateUnit(p,'n009',25344.,-27904.,270.)
call WaygateSetDestination(u,GetRectCenterX(gg_rct_SpawnPoint_Pandaria),GetRectCenterY(gg_rct_SpawnPoint_Pandaria))
call WaygateActivate(u,true)
call SetUnitColor(u,ConvertPlayerColor($B))
set u=CreateUnit(p,'n00A',26240.,-27904.,270.)
call WaygateSetDestination(u,GetRectCenterX(gg_rct_SpawnPoint_Broken_isles),GetRectCenterY(gg_rct_SpawnPoint_Broken_isles))
call WaygateActivate(u,true)
call SetUnitColor(u,ConvertPlayerColor($A))
set u=CreateUnit(p,'n00C',3520.,1280.,270.)
call WaygateSetDestination(u,GetRectCenterX(gg_rct_NZotMove),GetRectCenterY(gg_rct_NZotMove))
call WaygateActivate(u,true)
set u=CreateUnit(p,'n00C',21504.,10496.,270.)
call WaygateSetDestination(u,GetRectCenterX(gg_rct_Raide01Move),GetRectCenterY(gg_rct_Raide01Move))
call WaygateActivate(u,true)
set u=CreateUnit(p,'n00C',896.,-22784.,270.)
call WaygateSetDestination(u,GetRectCenterX(gg_rct_Raide01Ext),GetRectCenterY(gg_rct_Raide01Ext))
call WaygateActivate(u,true)
set u=CreateUnit(p,'n00C',-3520.,-26112.,270.)
call WaygateSetDestination(u,GetRectCenterX(gg_rct_QogSaronExt),GetRectCenterY(gg_rct_QogSaronExt))
call WaygateActivate(u,true)
set u=CreateUnit(p,'n00C',-1280.,3456.,270.)
call WaygateSetDestination(u,GetRectCenterX(gg_rct_EarthMove),GetRectCenterY(gg_rct_EarthMove))
call WaygateActivate(u,true)
set u=CreateUnit(p,'n00C',-2496.,-21120.,270.)
call WaygateSetDestination(u,GetRectCenterX(gg_rct_KTunRaideExt),GetRectCenterY(gg_rct_KTunRaideExt))
call WaygateActivate(u,true)
set u=CreateUnit(p,'n00C',-21184.,-6208.,270.)
call WaygateSetDestination(u,GetRectCenterX(gg_rct_KTunRaideMove),GetRectCenterY(gg_rct_KTunRaideMove))
call WaygateActivate(u,true)
set u=CreateUnit(p,'n00C',-2880.,-13504.,270.)
call WaygateSetDestination(u,GetRectCenterX(gg_rct_NerubianB2Ext),GetRectCenterY(gg_rct_NerubianB2Ext))
call WaygateActivate(u,true)
set u=CreateUnit(p,'n00C',5120.,29952.,270.)
call WaygateSetDestination(u,GetRectCenterX(gg_rct_QogSaronMove),GetRectCenterY(gg_rct_QogSaronMove))
call WaygateActivate(u,true)
set u=CreateUnit(p,'n00C',5568.,23424.,270.)
call WaygateSetDestination(u,GetRectCenterX(gg_rct_NerubianC3move),GetRectCenterY(gg_rct_NerubianC3move))
call WaygateActivate(u,true)
set u=CreateUnit(p,'n00C',-640.,-15360.,270.)
call WaygateSetDestination(u,GetRectCenterX(gg_rct_NerubianC3Ext),GetRectCenterY(gg_rct_NerubianC3Ext))
call WaygateActivate(u,true)
set u=CreateUnit(p,'n00C',-6464.,-16768.,270.)
call WaygateSetDestination(u,GetRectCenterX(gg_rct_NerubianA1Ext),GetRectCenterY(gg_rct_NerubianA1Ext))
call WaygateActivate(u,true)
set u=CreateUnit(p,'n00C',-5120.,27200.,270.)
call WaygateSetDestination(u,GetRectCenterX(gg_rct_NerubianA1move),GetRectCenterY(gg_rct_NerubianA1move))
call WaygateActivate(u,true)
set u=CreateUnit(p,'n00D',23424.,-3264.,270.)
call WaygateSetDestination(u,GetRectCenterX(gg_rct_OutlandMove),GetRectCenterY(gg_rct_OutlandMove))
call WaygateActivate(u,true)
set u=CreateUnit(p,'n00D',-11072.,-21440.,270.)
call WaygateSetDestination(u,GetRectCenterX(gg_rct_OutlandExt),GetRectCenterY(gg_rct_OutlandExt))
call WaygateActivate(u,true)
set u=CreateUnit(p,'h02K',25792.,-26816.,270.)
set u=CreateUnit(p,'ngme',-18304.,-640.,270.)
set u=CreateUnit(p,'n00C',1536.,-27264.,270.)
call WaygateSetDestination(u,GetRectCenterX(gg_rct_NZotExt),GetRectCenterY(gg_rct_NZotExt))
call WaygateActivate(u,true)
set u=CreateUnit(p,'ngme',14016.,-8320.,270.)
set u=CreateUnit(p,'nmoo',19264.,9472.,270.)
set u=CreateUnit(p,'nfoh',21440.,4288.,270.)
set u=CreateUnit(p,'nfoh',-19200.,7104.,270.)
set u=CreateUnit(p,'nmoo',-19776.,19712.,270.)
set u=CreateUnit(p,'n00C',18240.,2304.,270.)
call WaygateSetDestination(u,GetRectCenterX(gg_rct_RAGNAROSS),GetRectCenterY(gg_rct_RAGNAROSS))
call WaygateActivate(u,true)
set u=CreateUnit(p,'n07S',8960.,-21568.,270.)
call WaygateSetDestination(u,GetRectCenterX(gg_rct_NaxxramasEXT),GetRectCenterY(gg_rct_NaxxramasEXT))
call WaygateActivate(u,true)
set u=CreateUnit(p,'n07S',23168.,16384.,270.)
call WaygateSetDestination(u,GetRectCenterX(gg_rct_NaxxramasMOVE),GetRectCenterY(gg_rct_NaxxramasMOVE))
call WaygateActivate(u,true)
set u=CreateUnit(p,'ngme',-4672.,23616.,270.)
set u=CreateUnit(p,'n070',19904.,14720.,270.)
call WaygateSetDestination(u,GetRectCenterX(gg_rct_Necrositemove),GetRectCenterY(gg_rct_Necrositemove))
call WaygateActivate(u,true)
set u=CreateUnit(p,'n00C',5312.,-14912.,270.)
call WaygateSetDestination(u,GetRectCenterX(gg_rct_Necrositetext),GetRectCenterY(gg_rct_Necrositetext))
call WaygateActivate(u,true)
set u=CreateUnit(p,'n00C',.0,6272.,270.)
call WaygateSetDestination(u,GetRectCenterX(gg_rct_KazemateMove),GetRectCenterY(gg_rct_KazemateMove))
call WaygateActivate(u,true)
set u=CreateUnit(p,'n057',-3456.,-4672.,270.)
set u=CreateUnit(p,'ngme',2368.,-5504.,270.)
set u=CreateUnit(p,'n056',1216.,-9792.,270.)
set u=CreateUnit(p,'n00C',1536.,29184.,270.)
call WaygateSetDestination(u,GetRectCenterX(gg_rct_NerubianB2move),GetRectCenterY(gg_rct_NerubianB2move))
call WaygateActivate(u,true)
set u=CreateUnit(p,'n00C',4288.,-26240.,270.)
call WaygateSetDestination(u,GetRectCenterX(gg_rct_RAGNAROSS_EXT),GetRectCenterY(gg_rct_RAGNAROSS_EXT))
call WaygateActivate(u,true)
set u=CreateUnit(p,'ngme',22976.,12032.,270.)
set u=CreateUnit(p,'ngme',-20096.,16064.,270.)
set u=CreateUnit(p,'n056',13504.,15040.,270.)
set u=CreateUnit(p,'n056',-12864.,6400.,270.)
set u=CreateUnit(p,'n057',-16128.,16768.,270.)
set u=CreateUnit(p,'n057',18816.,-3456.,270.)
set u=CreateUnit(p,'n056',8704.,20224.,270.)
set u=CreateUnit(p,'n057',5952.,27648.,270.)
set u=CreateUnit(p,'ngme',1664.,11776.,270.)
set u=CreateUnit(p,'ngme',-24000.,-15296.,270.)
set u=CreateUnit(p,'n057',-18560.,-25216.,270.)
set u=CreateUnit(p,'n056',-27328.,-20864.,270.)
set u=CreateUnit(p,'n00C',2048.,-14656.,270.)
call WaygateSetDestination(u,GetRectCenterX(gg_rct_VAICHext),GetRectCenterY(gg_rct_VAICHext))
call WaygateActivate(u,true)
set u=CreateUnit(p,'n00C',8384.,2112.,270.)
call WaygateSetDestination(u,GetRectCenterX(gg_rct_VAICHmove),GetRectCenterY(gg_rct_VAICHmove))
call WaygateActivate(u,true)
set u=CreateUnit(p,'nmer',14784.,9408.,270.)
call SetUnitColor(u,ConvertPlayerColor(0))
set u=CreateUnit(p,'nmer',12224.,-3456.,270.)
call SetUnitColor(u,ConvertPlayerColor(0))
set u=CreateUnit(p,'nmer',-16576.,-4416.,270.)
call SetUnitColor(u,ConvertPlayerColor(0))
set u=CreateUnit(p,'nmer',-24064.,4928.,270.)
call SetUnitColor(u,ConvertPlayerColor(0))
set u=CreateUnit(p,'nmer',-9984.,27136.,270.)
call SetUnitColor(u,ConvertPlayerColor(0))
set u=CreateUnit(p,'n07R',12864.,-16832.,270.)
call WaygateSetDestination(u,GetRectCenterX(gg_rct_DalaranExt),GetRectCenterY(gg_rct_DalaranExt))
call WaygateActivate(u,true)
set u=CreateUnit(p,'n00C',8512.,-24896.,270.)
call WaygateSetDestination(u,GetRectCenterX(gg_rct_EarthExt),GetRectCenterY(gg_rct_EarthExt))
call WaygateActivate(u,true)
set u=CreateUnit(p,'n00C',3712.,-21312.,270.)
call WaygateSetDestination(u,GetRectCenterX(gg_rct_KazemateExt),GetRectCenterY(gg_rct_KazemateExt))
call WaygateActivate(u,true)
set u=CreateUnit(p,'n07T',27200.,-26688.,270.)
call WaygateSetDestination(u,GetRectCenterX(gg_rct_Outland),GetRectCenterY(gg_rct_Outland))
call WaygateActivate(u,true)
call SetUnitColor(u,ConvertPlayerColor(0))
set u=CreateUnit(p,'n07R',12864.,-14464.,270.)
call WaygateSetDestination(u,GetRectCenterX(gg_rct_DalaranExt),GetRectCenterY(gg_rct_DalaranExt))
call WaygateActivate(u,true)
set u=CreateUnit(p,'nmer',-23616.,-25216.,270.)
call SetUnitColor(u,ConvertPlayerColor(0))
endfunction
function CreateNeutralPassive takes nothing returns nothing
local player p=Player($F)
local unit u
local integer unitID
local trigger t
local real life
set u=CreateUnit(p,'n05G',1850.9,-3547.9,235.082)
endfunction
function CreatePlayerBuildings takes nothing returns nothing
local player p
local unit u
local integer unitID
local trigger t
local real life
set p=Player(0)
set u=CreateUnit(p,'n00B',25440.,-27104.,270.)
set p=Player(1)
set u=CreateUnit(p,'n00B',25440.,-26848.,270.)
set p=Player(2)
set u=CreateUnit(p,'n00B',25440.,-26592.,270.)
set p=Player(3)
set u=CreateUnit(p,'n00B',25440.,-26336.,270.)
set p=Player(4)
set u=CreateUnit(p,'n00B',25696.,-26336.,270.)
set p=Player(5)
set u=CreateUnit(p,'n00B',25952.,-26336.,270.)
set p=Player(6)
set u=CreateUnit(p,'n00B',26208.,-26336.,270.)
set p=Player(7)
set u=CreateUnit(p,'n00B',26208.,-26592.,270.)
set p=Player(8)
set u=CreateUnit(p,'n00B',26208.,-26848.,270.)
set p=Player(9)
set u=CreateUnit(p,'n00B',26208.,-27104.,270.)
set p=Player($A)
set u=CreateUnit(p,'n00B',25952.,-27104.,270.)
set p=Player($B)
set u=CreateUnit(p,'n00B',25696.,-27104.,270.)
endfunction
function CreatePlayerUnits takes nothing returns nothing
endfunction
function CreateAllUnits takes nothing returns nothing
call CreateNeutralHostileBuildings()
call CreateNeutralPassiveBuildings()
call CreatePlayerBuildings()
call CreateNeutralHostile()
call CreateNeutralPassive()
call CreatePlayerUnits()
endfunction
function CreateRegions takes nothing returns nothing
local weathereffect we
set gg_rct_NerubianA1Ext=Rect(-5504.,26688.,-4832.,27424.)
set gg_rct_NerubianA1move=Rect(-6624.,-17152.,-5952.,-16416.)
set gg_rct_NerubianB2Ext=Rect(1216.,28736.,1888.,29472.)
set gg_rct_NerubianB2move=Rect(-3232.,-13888.,-2560.,-13152.)
set gg_rct_NerubianC3Ext=Rect(5184.,23040.,5856.,23776.)
set gg_rct_NerubianC3move=Rect(-1088.,-15680.,-416.,-14944.)
set gg_rct_NorthrendSnow=Rect(-11328.,23840.,7648.,30688.)
set we=AddWeatherEffect(gg_rct_NorthrendSnow,'SNbs')
call EnableWeatherEffect(we,true)
set gg_rct_NorthrendSnow2=Rect(-3360.,22048.,4704.,23968.)
set we=AddWeatherEffect(gg_rct_NorthrendSnow2,'SNbs')
call EnableWeatherEffect(we,true)
set gg_rct_OutlandExt=Rect(22880.,-3328.,23552.,-2688.)
set gg_rct_OutlandMove=Rect(-11648.,-21728.,-10976.,-21088.)
set gg_rct_SpawnPoint_Broken_isles=Rect(4448.,11904.,4832.,12288.)
set gg_rct_SpawnPoint_EasternKingdom1=Rect(15808.,-2080.,16128.,-1760.)
set gg_rct_SpawnPoint_EasternKingdom2=Rect(18464.,11680.,18784.,12000.)
set gg_rct_SpawnPoint_Kalimdor1=Rect(-20864.,2048.,-20480.,2432.)
set gg_rct_SpawnPoint_Kalimdor2=Rect(-14720.,10624.,-14336.,11008.)
set gg_rct_SpawnPoint_Northland1=Rect(-4416.,25024.,-4032.,25408.)
set gg_rct_SpawnPoint_Northland2=Rect(7232.,24352.,7616.,24736.)
set gg_rct_SpawnPoint_Pandaria=Rect(-4096.,-5888.,-3712.,-5504.)
set gg_rct_SpawnVision=Rect(23872.,-28448.,27648.,-24480.)
set gg_rct_KTunRaideExt=Rect(-21888.,-6080.,-21248.,-5440.)
set gg_rct_KTunRaideMove=Rect(-3072.,-21536.,-2336.,-20672.)
set gg_rct_QogSaronMove=Rect(-4032.,-26560.,-3200.,-25664.)
set gg_rct_QogSaronExt=Rect(4800.,29792.,5312.,30368.)
set gg_rct_NZotMove=Rect(832.,-27680.,1664.,-26784.)
set gg_rct_NZotExt=Rect(3424.,960.,4064.,1568.)
set gg_rct_Raide01Move=Rect(480.,-23232.,1312.,-22624.)
set gg_rct_Raide01Ext=Rect(21120.,10176.,21824.,10656.)
set gg_rct_QOGGSARON=Rect(-6816.,-27424.,-3168.,-24864.)
set we=AddWeatherEffect(gg_rct_QOGGSARON,'WNcw')
call EnableWeatherEffect(we,true)
set gg_rct_TEXTKalimdor1=Rect(24320.,-26048.,24576.,-25888.)
set gg_rct_TEXTKalimdor2=Rect(24320.,-27456.,24576.,-27296.)
set gg_rct_TEXTPandaria=Rect(25216.,-27456.,25472.,-27296.)
set gg_rct_TEXTBrokenIsles=Rect(26112.,-27456.,26368.,-27296.)
set gg_rct_TEXTEastKingdom2=Rect(27008.,-27488.,27264.,-27328.)
set gg_rct_TEXTEastKingdom1=Rect(27008.,-26048.,27264.,-25888.)
set gg_rct_TEXTNorth1=Rect(26112.,-26048.,26368.,-25888.)
set gg_rct_TEXTNorth2=Rect(25216.,-26016.,25472.,-25856.)
set gg_rct_SpawnLocation=Rect(25312.,-27232.,26336.,-26208.)
set gg_rct_RAGNAROSS=Rect(4000.,-26976.,4576.,-26240.)
set gg_rct_RAGNAROSS_EXT=Rect(18048.,1984.,18464.,2336.)
set gg_rct_HeroSpawn=Rect(13728.,-28192.,14144.,-27872.)
set gg_rct_VAICHmove=Rect(1664.,-15296.,2432.,-14432.)
set gg_rct_VAICHext=Rect(8288.,1728.,8800.,2304.)
set gg_rct_EarthExt=Rect(-1888.,3264.,-1312.,3712.)
set gg_rct_EarthMove=Rect(8128.,-25184.,8864.,-24512.)
set gg_rct_KazemateMove=Rect(3488.,-21696.,3936.,-21280.)
set gg_rct_KazemateExt=Rect(-192.,6016.,256.,6432.)
set gg_rct_Necrositetext=Rect(19360.,13856.,19712.,14208.)
set gg_rct_Necrositemove=Rect(4992.,-15328.,5600.,-14752.)
set gg_rct_DalaranMove=Rect(13600.,-16064.,14208.,-15552.)
set gg_rct_DalaranExt=Rect(2208.,26688.,2816.,27200.)
set gg_rct_Effect1=Rect(21600.,18016.,22432.,18144.)
set we=AddWeatherEffect(gg_rct_Effect1,'FDrh')
call EnableWeatherEffect(we,true)
set gg_rct_Effect1_____________________u=Rect(19808.,17408.,19872.,17760.)
set we=AddWeatherEffect(gg_rct_Effect1_____________________u,'FDrh')
call EnableWeatherEffect(we,true)
set gg_rct_DalaranEffect=Rect(11424.,-16960.,14144.,-14368.)
set we=AddWeatherEffect(gg_rct_DalaranEffect,'MEds')
call EnableWeatherEffect(we,true)
set gg_rct_UlduarEffect=Rect(1088.,27520.,6368.,30688.)
set we=AddWeatherEffect(gg_rct_UlduarEffect,'WNcw')
call EnableWeatherEffect(we,true)
set gg_rct_Effect=Rect(-24640.,7680.,-21664.,11904.)
set gg_rct_NaxxramasSpellUsePoint=Rect(-1664.,24896.,-1088.,25568.)
set gg_rct_NaxxramasSpawn=Rect(-1536.,25280.,-1344.,25472.)
set gg_rct_Naxxramas=Rect(7808.,-23456.,10144.,-20960.)
set gg_rct_TEXTOutland=Rect(26720.,-26752.,26976.,-26624.)
set gg_rct_Outland=Rect(-20160.,-21792.,-19648.,-21376.)
set gg_rct_NaxxramasEXT=Rect(23008.,16288.,23360.,16640.)
set gg_rct_NaxxramasMOVE=Rect(8768.,-21888.,9120.,-21536.)
set gg_rct_HeroByCommand1=Rect(19136.,-3616.,19392.,-3360.)
set gg_rct_HeroByCommand2=Rect(-15680.,-25312.,-15232.,-24992.)
endfunction
function Trig_Information_Actions takes nothing returns nothing
call CreateQuestBJ(2,"|c00FFFC0123 Расы|r","Данный проект является *реборном* некогда популярной и превосходной карты \"Возрождение Азерота\".
","ReplaceableTextures\\CommandButtons\\BTNAltarOfElders.blp")
call CreateQuestBJ(2,"Команды хоста","TRIGSTR_255","ReplaceableTextures\\WorldEditUI\\Editor-Random-Unit.blp")
call CreateQuestBJ(2,"|c00FFFC01Древние боги|r","TRIGSTR_257","ReplaceableTextures\\CommandButtons\\BTNForgottenOne.blp")
call CreateQuestBJ(2,"|c00FFFC01Легендарные|r","TRIGSTR_259","ReplaceableTextures\\CommandButtons\\BTNGhostMage.blp")
call CreateQuestBJ(0,"Общие команды","TRIGSTR_262","ReplaceableTextures\\WorldEditUI\\Editor-MultipleUnits.blp")
call CreateQuestBJ(0,"|cFFFF9900UOC
","TRIGSTR_264","ReplaceableTextures\\CommandButtons\\BTNAltarOfKings.blp")
call TriggerSleepAction(2)
call CreateTextTagLocBJ("TRIGSTR_265",GetRectCenter(gg_rct_TEXTKalimdor1),0,15.,'d','d','d',0)
call CreateTextTagLocBJ("TRIGSTR_266",GetRectCenter(gg_rct_TEXTKalimdor2),0,15.,'d','d','d',0)
call CreateTextTagLocBJ("TRIGSTR_267",GetRectCenter(gg_rct_TEXTPandaria),0,15.,'d','d','d',0)
call CreateTextTagLocBJ("TRIGSTR_2614",GetRectCenter(gg_rct_TEXTBrokenIsles),0,15.,'d','d','d',0)
call CreateTextTagLocBJ("TRIGSTR_4146",GetRectCenter(gg_rct_TEXTEastKingdom2),0,15.,'d','d','d',0)
call CreateTextTagLocBJ("TRIGSTR_290",GetRectCenter(gg_rct_TEXTOutland),0,15.,'d','d','d',0)
call CreateTextTagLocBJ("TRIGSTR_4147",GetRectCenter(gg_rct_TEXTEastKingdom1),0,15.,'d','d','d',0)
call CreateTextTagLocBJ("TRIGSTR_4148",GetRectCenter(gg_rct_TEXTNorth1),0,15.,'d','d','d',0)
call CreateTextTagLocBJ("TRIGSTR_4149",GetRectCenter(gg_rct_TEXTNorth2),0,15.,'d','d','d',0)
endfunction
function InitTrig_Information takes nothing returns nothing
set gg_trg_Information=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Information,.1)
call TriggerAddAction(gg_trg_Information,function Trig_Information_Actions)
endfunction
function Trig_Tekst_Actions takes nothing returns nothing
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,25.,"TRIGSTR_8216")
endfunction
function InitTrig_Tekst takes nothing returns nothing
set gg_trg_Tekst=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Tekst,30.)
call TriggerAddAction(gg_trg_Tekst,function Trig_Tekst_Actions)
endfunction
function Trig_Start_Actions takes nothing returns nothing
call MeleeStartingVisibility()
call MeleeStartingHeroLimit()
call MeleeGrantHeroItems()
call MeleeClearExcessUnits()
call SetPlayerStateBJ(Player(0),PLAYER_STATE_RESOURCE_GOLD,$7D0)
call SetPlayerStateBJ(Player(1),PLAYER_STATE_RESOURCE_GOLD,$7D0)
call SetPlayerStateBJ(Player(2),PLAYER_STATE_RESOURCE_GOLD,$7D0)
call SetPlayerStateBJ(Player(3),PLAYER_STATE_RESOURCE_GOLD,$7D0)
call SetPlayerStateBJ(Player(4),PLAYER_STATE_RESOURCE_GOLD,$7D0)
call SetPlayerStateBJ(Player(5),PLAYER_STATE_RESOURCE_GOLD,$7D0)
call SetPlayerStateBJ(Player(6),PLAYER_STATE_RESOURCE_GOLD,$7D0)
call SetPlayerStateBJ(Player(7),PLAYER_STATE_RESOURCE_GOLD,$7D0)
call SetPlayerStateBJ(Player(8),PLAYER_STATE_RESOURCE_GOLD,$7D0)
call SetPlayerStateBJ(Player(9),PLAYER_STATE_RESOURCE_GOLD,$7D0)
call SetPlayerStateBJ(Player($A),PLAYER_STATE_RESOURCE_GOLD,$7D0)
call SetPlayerStateBJ(Player($B),PLAYER_STATE_RESOURCE_GOLD,$7D0)
call SetPlayerStateBJ(Player(0),PLAYER_STATE_RESOURCE_LUMBER,$6D6)
call SetPlayerStateBJ(Player(1),PLAYER_STATE_RESOURCE_LUMBER,$6D6)
call SetPlayerStateBJ(Player(2),PLAYER_STATE_RESOURCE_LUMBER,$6D6)
call SetPlayerStateBJ(Player(3),PLAYER_STATE_RESOURCE_LUMBER,$6D6)
call SetPlayerStateBJ(Player(4),PLAYER_STATE_RESOURCE_LUMBER,$6D6)
call SetPlayerStateBJ(Player(5),PLAYER_STATE_RESOURCE_LUMBER,$6D6)
call SetPlayerStateBJ(Player(6),PLAYER_STATE_RESOURCE_LUMBER,$6D6)
call SetPlayerStateBJ(Player(7),PLAYER_STATE_RESOURCE_LUMBER,$6D6)
call SetPlayerStateBJ(Player(8),PLAYER_STATE_RESOURCE_LUMBER,$6D6)
call SetPlayerStateBJ(Player(9),PLAYER_STATE_RESOURCE_LUMBER,$6D6)
call SetPlayerStateBJ(Player($A),PLAYER_STATE_RESOURCE_LUMBER,$6D6)
call SetPlayerStateBJ(Player($B),PLAYER_STATE_RESOURCE_LUMBER,$6D6)
endfunction
function InitTrig_Start takes nothing returns nothing
set gg_trg_Start=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Start,.01)
call TriggerAddAction(gg_trg_Start,function Trig_Start_Actions)
endfunction
function Trig_Time_f1_Actions takes nothing returns nothing
call QuestMessageBJ(bj_FORCE_ALL_PLAYERS,$C,"Прошло 15 минут игры
")
endfunction
function InitTrig_Time_f1 takes nothing returns nothing
set gg_trg_Time_f1=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Time_f1,900.)
call TriggerAddAction(gg_trg_Time_f1,function Trig_Time_f1_Actions)
endfunction
function Trig_Time_f2_Actions takes nothing returns nothing
call QuestMessageBJ(bj_FORCE_ALL_PLAYERS,$C,"Прошло 30 минут игры")
endfunction
function InitTrig_Time_f2 takes nothing returns nothing
set gg_trg_Time_f2=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Time_f2,1800.)
call TriggerAddAction(gg_trg_Time_f2,function Trig_Time_f2_Actions)
endfunction
function Trig_Time_f4_Actions takes nothing returns nothing
call QuestMessageBJ(bj_FORCE_ALL_PLAYERS,$C,"Прошёл 1 час игры")
endfunction
function InitTrig_Time_f4 takes nothing returns nothing
set gg_trg_Time_f4=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Time_f4,3600.)
call TriggerAddAction(gg_trg_Time_f4,function Trig_Time_f4_Actions)
endfunction
function Trig_Time_f5_Actions takes nothing returns nothing
call QuestMessageBJ(bj_FORCE_ALL_PLAYERS,$C,"Прошло 1 час 15 минут игры")
endfunction
function InitTrig_Time_f5 takes nothing returns nothing
set gg_trg_Time_f5=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Time_f5,4500.)
call TriggerAddAction(gg_trg_Time_f5,function Trig_Time_f5_Actions)
endfunction
function Trig_Time_f6_Actions takes nothing returns nothing
call QuestMessageBJ(bj_FORCE_ALL_PLAYERS,$C,"Прошло полтора часа игры")
endfunction
function InitTrig_Time_f6 takes nothing returns nothing
set gg_trg_Time_f6=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Time_f6,5400.)
call TriggerAddAction(gg_trg_Time_f6,function Trig_Time_f6_Actions)
endfunction
function Trig_Time_f7_Actions takes nothing returns nothing
call QuestMessageBJ(bj_FORCE_ALL_PLAYERS,$C,"Прошло 1 час 45 минут игры")
endfunction
function InitTrig_Time_f7 takes nothing returns nothing
set gg_trg_Time_f7=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Time_f7,6300.)
call TriggerAddAction(gg_trg_Time_f7,function Trig_Time_f7_Actions)
endfunction
function Trig_Time_f8_Actions takes nothing returns nothing
call QuestMessageBJ(bj_FORCE_ALL_PLAYERS,$C,"Прошло 2 часа игры")
endfunction
function InitTrig_Time_f8 takes nothing returns nothing
set gg_trg_Time_f8=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Time_f8,7200.)
call TriggerAddAction(gg_trg_Time_f8,function Trig_Time_f8_Actions)
endfunction
function Trig_Liver_Player_Actions takes nothing returns nothing
set udg_CountForTournamet=(udg_CountForTournamet-1)
call DisplayTextToForce(bj_FORCE_ALL_PLAYERS,(("|cff00ff00"+(GetPlayerName(GetTriggerPlayer())+"|r"))+(" "+"покинул игру!")))
endfunction
function InitTrig_Liver_Player takes nothing returns nothing
set gg_trg_Liver_Player=CreateTrigger()
call TriggerRegisterPlayerEventLeave(gg_trg_Liver_Player,Player(0))
call TriggerRegisterPlayerEventLeave(gg_trg_Liver_Player,Player(1))
call TriggerRegisterPlayerEventLeave(gg_trg_Liver_Player,Player(2))
call TriggerRegisterPlayerEventLeave(gg_trg_Liver_Player,Player(3))
call TriggerRegisterPlayerEventLeave(gg_trg_Liver_Player,Player(4))
call TriggerRegisterPlayerEventLeave(gg_trg_Liver_Player,Player(5))
call TriggerRegisterPlayerEventLeave(gg_trg_Liver_Player,Player(6))
call TriggerRegisterPlayerEventLeave(gg_trg_Liver_Player,Player(7))
call TriggerRegisterPlayerEventLeave(gg_trg_Liver_Player,Player(8))
call TriggerRegisterPlayerEventLeave(gg_trg_Liver_Player,Player(9))
call TriggerRegisterPlayerEventLeave(gg_trg_Liver_Player,Player($A))
call TriggerRegisterPlayerEventLeave(gg_trg_Liver_Player,Player($B))
call TriggerAddAction(gg_trg_Liver_Player,function Trig_Liver_Player_Actions)
endfunction
function Trig_AuthorVision_Func002C takes nothing returns boolean
return(GetPlayerName(GetTriggerPlayer())=="bigwolf2000")or(GetPlayerName(GetTriggerPlayer())=="YaHLoS")or(GetPlayerName(GetTriggerPlayer())=="Old_Helm")or(GetPlayerName(GetTriggerPlayer())=="Shushpanchig")or(GetPlayerName(GetTriggerPlayer())=="king_maksss")or(GetPlayerName(GetTriggerPlayer())=="gordik0101")or(GetPlayerName(GetTriggerPlayer())=="fgjkoi")
endfunction
function Trig_AuthorVision_Conditions takes nothing returns boolean
return(Trig_AuthorVision_Func002C())
endfunction
function Trig_AuthorVision_Actions takes nothing returns nothing
call CreateFogModifierRectBJ(true,GetTriggerPlayer(),FOG_OF_WAR_VISIBLE,GetWorldBounds())
endfunction
function InitTrig_AuthorVision takes nothing returns nothing
set gg_trg_AuthorVision=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_AuthorVision,Player(0)," 1",true)
call TriggerRegisterPlayerChatEvent(gg_trg_AuthorVision,Player(1)," 1",true)
call TriggerRegisterPlayerChatEvent(gg_trg_AuthorVision,Player(2)," 1",true)
call TriggerRegisterPlayerChatEvent(gg_trg_AuthorVision,Player(3)," 1",true)
call TriggerRegisterPlayerChatEvent(gg_trg_AuthorVision,Player(4)," 1",true)
call TriggerRegisterPlayerChatEvent(gg_trg_AuthorVision,Player(5)," 1",true)
call TriggerRegisterPlayerChatEvent(gg_trg_AuthorVision,Player(6)," 1",true)
call TriggerRegisterPlayerChatEvent(gg_trg_AuthorVision,Player(7)," 1",true)
call TriggerRegisterPlayerChatEvent(gg_trg_AuthorVision,Player(8)," 1",true)
call TriggerRegisterPlayerChatEvent(gg_trg_AuthorVision,Player(9)," 1",true)
call TriggerRegisterPlayerChatEvent(gg_trg_AuthorVision,Player($A)," 1",true)
call TriggerRegisterPlayerChatEvent(gg_trg_AuthorVision,Player($B)," 1",true)
call TriggerAddCondition(gg_trg_AuthorVision,Condition(function Trig_AuthorVision_Conditions))
call TriggerAddAction(gg_trg_AuthorVision,function Trig_AuthorVision_Actions)
endfunction
function Trig_SpawnVision_Func002A takes nothing returns nothing
call CreateFogModifierRectBJ(true,GetEnumPlayer(),FOG_OF_WAR_VISIBLE,gg_rct_SpawnVision)
endfunction
function Trig_SpawnVision_Actions takes nothing returns nothing
call ForForce(bj_FORCE_ALL_PLAYERS,function Trig_SpawnVision_Func002A)
endfunction
function InitTrig_SpawnVision takes nothing returns nothing
set gg_trg_SpawnVision=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_SpawnVision,1.)
call TriggerAddAction(gg_trg_SpawnVision,function Trig_SpawnVision_Actions)
endfunction
function Trig_NochangeName1_Actions takes nothing returns nothing
call TriggerSleepAction(.1)
call SetPlayerName(GetTriggerPlayer(),"Ошибка")
endfunction
function InitTrig_NochangeName1 takes nothing returns nothing
set gg_trg_NochangeName1=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName1,Player(0),"-name bigwolf2000",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName1,Player(1),"-name bigwolf2000",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName1,Player(2),"-name bigwolf2000",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName1,Player(3),"-name bigwolf2000",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName1,Player(4),"-name bigwolf2000",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName1,Player(5),"-name bigwolf2000",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName1,Player(6),"-name bigwolf2000",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName1,Player(7),"-name bigwolf2000",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName1,Player(8),"-name bigwolf2000",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName1,Player(9),"-name bigwolf2000",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName1,Player($A),"-name bigwolf2000",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName1,Player($B),"-name bigwolf2000",true)
call TriggerAddAction(gg_trg_NochangeName1,function Trig_NochangeName1_Actions)
endfunction
function Trig_NochangeName2_Actions takes nothing returns nothing
call TriggerSleepAction(.1)
call SetPlayerName(GetTriggerPlayer(),"Ошибка")
endfunction
function InitTrig_NochangeName2 takes nothing returns nothing
set gg_trg_NochangeName2=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName2,Player(0),"-name Shushpanchig",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName2,Player(1),"-name Shushpanchig",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName2,Player(2),"-name Shushpanchig",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName2,Player(3),"-name Shushpanchig",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName2,Player(4),"-name Shushpanchig",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName2,Player(5),"-name Shushpanchig",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName2,Player(6),"-name Shushpanchig",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName2,Player(7),"-name Shushpanchig",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName2,Player(8),"-name Shushpanchig",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName2,Player(9),"-name Shushpanchig",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName2,Player($A),"-name Shushpanchig",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName2,Player($B),"-name Shushpanchig",true)
call TriggerAddAction(gg_trg_NochangeName2,function Trig_NochangeName2_Actions)
endfunction
function Trig_NochangeName3_Actions takes nothing returns nothing
call TriggerSleepAction(.1)
call SetPlayerName(GetTriggerPlayer(),"Ошибка")
endfunction
function InitTrig_NochangeName3 takes nothing returns nothing
set gg_trg_NochangeName3=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName3,Player(0),"-name gordik0101",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName3,Player(1),"-name gordik0101",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName3,Player(2),"-name gordik0101",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName3,Player(3),"-name gordik0101",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName3,Player(4),"-name gordik0101",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName3,Player(5),"-name gordik0101",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName3,Player(6),"-name gordik0101",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName3,Player(7),"-name gordik0101",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName3,Player(8),"-name gordik0101",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName3,Player(9),"-name gordik0101",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName3,Player($A),"-name gordik0101",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName3,Player($B),"-name gordik0101",true)
call TriggerAddAction(gg_trg_NochangeName3,function Trig_NochangeName3_Actions)
endfunction
function Trig_NochangeName4_Actions takes nothing returns nothing
call TriggerSleepAction(.1)
call SetPlayerName(GetTriggerPlayer(),"Ошибка")
endfunction
function InitTrig_NochangeName4 takes nothing returns nothing
set gg_trg_NochangeName4=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName4,Player(0),"-name Old_Helm",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName4,Player(1),"-name Old_Helm",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName4,Player(2),"-name Old_Helm",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName4,Player(3),"-name Old_Helm",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName4,Player(4),"-name Old_Helm",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName4,Player(5),"-name Old_Helm",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName4,Player(6),"-name Old_Helm",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName4,Player(7),"-name Old_Helm",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName4,Player(8),"-name Old_Helm",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName4,Player(9),"-name Old_Helm",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName4,Player($A),"-name Old_Helm",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName4,Player($B),"-name Old_Helm",true)
call TriggerAddAction(gg_trg_NochangeName4,function Trig_NochangeName4_Actions)
endfunction
function Trig_NochangeName5_Actions takes nothing returns nothing
call TriggerSleepAction(.1)
call SetPlayerName(GetTriggerPlayer(),"Ошибка")
endfunction
function InitTrig_NochangeName5 takes nothing returns nothing
set gg_trg_NochangeName5=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName5,Player(0),"-name YaHLoS",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName5,Player(1),"-name YaHLoS",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName5,Player(2),"-name YaHLoS",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName5,Player(3),"-name YaHLoS",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName5,Player(4),"-name YaHLoS",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName5,Player(5),"-name YaHLoS",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName5,Player(6),"-name YaHLoS",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName5,Player(7),"-name YaHLoS",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName5,Player(8),"-name YaHLoS",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName5,Player(9),"-name YaHLoS",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName5,Player($A),"-name YaHLoS",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName5,Player($B),"-name YaHLoS",true)
call TriggerAddAction(gg_trg_NochangeName5,function Trig_NochangeName5_Actions)
endfunction
function Trig_NochangeName8_Actions takes nothing returns nothing
call TriggerSleepAction(.1)
call SetPlayerName(GetTriggerPlayer(),"Ошибка")
endfunction
function InitTrig_NochangeName8 takes nothing returns nothing
set gg_trg_NochangeName8=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName8,Player(0),"-name fgjkoi",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName8,Player(1),"-name fgjkoi",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName8,Player(2),"-name fgjkoi",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName8,Player(3),"-name fgjkoi",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName8,Player(4),"-name fgjkoi",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName8,Player(5),"-name fgjkoi",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName8,Player(6),"-name fgjkoi",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName8,Player(7),"-name fgjkoi",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName8,Player(8),"-name fgjkoi",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName8,Player(9),"-name fgjkoi",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName8,Player($A),"-name fgjkoi",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName8,Player($B),"-name fgjkoi",true)
call TriggerAddAction(gg_trg_NochangeName8,function Trig_NochangeName8_Actions)
endfunction
function Trig_Human_Conditions takes nothing returns boolean
return(GetResearched()=='R000')
endfunction
function Trig_Human_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(5,'hpea',GetOwningPlayer(GetTriggerUnit()),GetUnitLoc(GetTriggerUnit()),bj_UNIT_FACING)
call RemoveUnit(GetTriggerUnit())
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Игрок "+GetPlayerName(GetTriggerPlayer()))+" выбрал расу - |c0020C000Люди|r"))
endfunction
function InitTrig_Human takes nothing returns nothing
set gg_trg_Human=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Human,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Human,Condition(function Trig_Human_Conditions))
call TriggerAddAction(gg_trg_Human,function Trig_Human_Actions)
endfunction
function Trig_Orc_Conditions takes nothing returns boolean
return(GetResearched()=='R005')
endfunction
function Trig_Orc_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(5,'opeo',GetOwningPlayer(GetTriggerUnit()),GetUnitLoc(GetTriggerUnit()),bj_UNIT_FACING)
call RemoveUnit(GetTriggerUnit())
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Игрок "+GetPlayerName(GetTriggerPlayer()))+" выбрал расу - |c0020C000Орки|r"))
endfunction
function InitTrig_Orc takes nothing returns nothing
set gg_trg_Orc=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Orc,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Orc,Condition(function Trig_Orc_Conditions))
call TriggerAddAction(gg_trg_Orc,function Trig_Orc_Actions)
endfunction
function Trig_Undead_Conditions takes nothing returns boolean
return(GetResearched()=='R006')
endfunction
function Trig_Undead_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(5,'uaco',GetOwningPlayer(GetTriggerUnit()),GetUnitLoc(GetTriggerUnit()),bj_UNIT_FACING)
call RemoveUnit(GetTriggerUnit())
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Игрок "+GetPlayerName(GetTriggerPlayer()))+" выбрал расу - |c0020C000Нежить|r"))
endfunction
function InitTrig_Undead takes nothing returns nothing
set gg_trg_Undead=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Undead,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Undead,Condition(function Trig_Undead_Conditions))
call TriggerAddAction(gg_trg_Undead,function Trig_Undead_Actions)
endfunction
function Trig_NightElf_Conditions takes nothing returns boolean
return(GetResearched()=='R008')
endfunction
function Trig_NightElf_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(5,'ewsp',GetOwningPlayer(GetTriggerUnit()),GetUnitLoc(GetTriggerUnit()),bj_UNIT_FACING)
call RemoveUnit(GetTriggerUnit())
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Игрок "+GetPlayerName(GetTriggerPlayer()))+" выбрал расу - |c0020C000Ночные эльфы|r"))
endfunction
function InitTrig_NightElf takes nothing returns nothing
set gg_trg_NightElf=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_NightElf,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_NightElf,Condition(function Trig_NightElf_Conditions))
call TriggerAddAction(gg_trg_NightElf,function Trig_NightElf_Actions)
endfunction
function Trig_Nerubian_Conditions takes nothing returns boolean
return(GetResearched()=='R00F')
endfunction
function Trig_Nerubian_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(5,'o003',GetOwningPlayer(GetTriggerUnit()),GetUnitLoc(GetTriggerUnit()),bj_UNIT_FACING)
call RemoveUnit(GetTriggerUnit())
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Игрок "+GetPlayerName(GetTriggerPlayer()))+" выбрал расу - |c0020C000Нерубы|r"))
endfunction
function InitTrig_Nerubian takes nothing returns nothing
set gg_trg_Nerubian=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Nerubian,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Nerubian,Condition(function Trig_Nerubian_Conditions))
call TriggerAddAction(gg_trg_Nerubian,function Trig_Nerubian_Actions)
endfunction
function Trig_Dwarfen_Conditions takes nothing returns boolean
return(GetResearched()=='R00K')
endfunction
function Trig_Dwarfen_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(5,'h01V',GetOwningPlayer(GetTriggerUnit()),GetUnitLoc(GetTriggerUnit()),bj_UNIT_FACING)
call RemoveUnit(GetTriggerUnit())
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Игрок "+GetPlayerName(GetTriggerPlayer()))+" выбрал расу - |c0020C000Дворфы|r"))
endfunction
function InitTrig_Dwarfen takes nothing returns nothing
set gg_trg_Dwarfen=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Dwarfen,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Dwarfen,Condition(function Trig_Dwarfen_Conditions))
call TriggerAddAction(gg_trg_Dwarfen,function Trig_Dwarfen_Actions)
endfunction
function Trig_Naga_Conditions takes nothing returns boolean
return(GetResearched()=='R00M')
endfunction
function Trig_Naga_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(5,'nmpe',GetOwningPlayer(GetTriggerUnit()),GetUnitLoc(GetTriggerUnit()),bj_UNIT_FACING)
call RemoveUnit(GetTriggerUnit())
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Игрок "+GetPlayerName(GetTriggerPlayer()))+" выбрал расу - |c0020C000Наги|r"))
endfunction
function InitTrig_Naga takes nothing returns nothing
set gg_trg_Naga=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Naga,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Naga,Condition(function Trig_Naga_Conditions))
call TriggerAddAction(gg_trg_Naga,function Trig_Naga_Actions)
endfunction
function Trig_ScorgedElf_Conditions takes nothing returns boolean
return(GetResearched()=='R00O')
endfunction
function Trig_ScorgedElf_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(5,'e002',GetOwningPlayer(GetTriggerUnit()),GetUnitLoc(GetTriggerUnit()),bj_UNIT_FACING)
call RemoveUnit(GetTriggerUnit())
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Игрок "+GetPlayerName(GetTriggerPlayer()))+" выбрал расу - |c0020C000Эльфы Тьмы|r"))
endfunction
function InitTrig_ScorgedElf takes nothing returns nothing
set gg_trg_ScorgedElf=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_ScorgedElf,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_ScorgedElf,Condition(function Trig_ScorgedElf_Conditions))
call TriggerAddAction(gg_trg_ScorgedElf,function Trig_ScorgedElf_Actions)
endfunction
function Trig_Demon_Conditions takes nothing returns boolean
return(GetResearched()=='R00W')
endfunction
function Trig_Demon_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(5,'u00G',GetOwningPlayer(GetTriggerUnit()),GetUnitLoc(GetTriggerUnit()),bj_UNIT_FACING)
call RemoveUnit(GetTriggerUnit())
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Игрок "+GetPlayerName(GetTriggerPlayer()))+" выбрал расу - |c0020C000Демоны|r"))
endfunction
function InitTrig_Demon takes nothing returns nothing
set gg_trg_Demon=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Demon,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Demon,Condition(function Trig_Demon_Conditions))
call TriggerAddAction(gg_trg_Demon,function Trig_Demon_Actions)
endfunction
function Trig_HighElf_Conditions takes nothing returns boolean
return(GetResearched()=='R012')
endfunction
function Trig_HighElf_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(5,'h02O',GetOwningPlayer(GetTriggerUnit()),GetUnitLoc(GetTriggerUnit()),bj_UNIT_FACING)
call RemoveUnit(GetTriggerUnit())
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Игрок "+GetPlayerName(GetTriggerPlayer()))+" выбрал расу - |c0020C000Кровавые Эльфы|r"))
endfunction
function InitTrig_HighElf takes nothing returns nothing
set gg_trg_HighElf=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_HighElf,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_HighElf,Condition(function Trig_HighElf_Conditions))
call TriggerAddAction(gg_trg_HighElf,function Trig_HighElf_Actions)
endfunction
function Trig_ForestTroll_Conditions takes nothing returns boolean
return(GetResearched()=='R01G')
endfunction
function Trig_ForestTroll_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(5,'o004',GetOwningPlayer(GetTriggerUnit()),GetUnitLoc(GetTriggerUnit()),bj_UNIT_FACING)
call RemoveUnit(GetTriggerUnit())
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Игрок "+GetPlayerName(GetTriggerPlayer()))+" выбрал расу - |c0020C000Лесные тролли|r"))
endfunction
function InitTrig_ForestTroll takes nothing returns nothing
set gg_trg_ForestTroll=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_ForestTroll,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_ForestTroll,Condition(function Trig_ForestTroll_Conditions))
call TriggerAddAction(gg_trg_ForestTroll,function Trig_ForestTroll_Actions)
endfunction
function Trig_DarkTroll_Conditions takes nothing returns boolean
return(GetResearched()=='R01H')
endfunction
function Trig_DarkTroll_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(5,'o005',GetOwningPlayer(GetTriggerUnit()),GetUnitLoc(GetTriggerUnit()),bj_UNIT_FACING)
call RemoveUnit(GetTriggerUnit())
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Игрок "+GetPlayerName(GetTriggerPlayer()))+" выбрал расу - |c0020C000Темные тролли|r"))
endfunction
function InitTrig_DarkTroll takes nothing returns nothing
set gg_trg_DarkTroll=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_DarkTroll,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_DarkTroll,Condition(function Trig_DarkTroll_Conditions))
call TriggerAddAction(gg_trg_DarkTroll,function Trig_DarkTroll_Actions)
endfunction
function Trig_IceTroll_Conditions takes nothing returns boolean
return(GetResearched()=='R01F')
endfunction
function Trig_IceTroll_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(5,'o006',GetOwningPlayer(GetTriggerUnit()),GetUnitLoc(GetTriggerUnit()),bj_UNIT_FACING)
call RemoveUnit(GetTriggerUnit())
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Игрок "+GetPlayerName(GetTriggerPlayer()))+" выбрал расу - |c0020C000Ледяные тролли|r"))
endfunction
function InitTrig_IceTroll takes nothing returns nothing
set gg_trg_IceTroll=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_IceTroll,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_IceTroll,Condition(function Trig_IceTroll_Conditions))
call TriggerAddAction(gg_trg_IceTroll,function Trig_IceTroll_Actions)
endfunction
function Trig_FelOrc_Conditions takes nothing returns boolean
return(GetResearched()=='R01I')
endfunction
function Trig_FelOrc_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(5,'ncpn',GetOwningPlayer(GetTriggerUnit()),GetUnitLoc(GetTriggerUnit()),bj_UNIT_FACING)
call RemoveUnit(GetTriggerUnit())
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Игрок "+GetPlayerName(GetTriggerPlayer()))+" выбрал расу - |c0020C000Орки Скверны|r"))
endfunction
function InitTrig_FelOrc takes nothing returns nothing
set gg_trg_FelOrc=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_FelOrc,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_FelOrc,Condition(function Trig_FelOrc_Conditions))
call TriggerAddAction(gg_trg_FelOrc,function Trig_FelOrc_Actions)
endfunction
function Trig_Kobold_Conditions takes nothing returns boolean
return(GetResearched()=='R01L')
endfunction
function Trig_Kobold_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(5,'o01I',GetOwningPlayer(GetTriggerUnit()),GetUnitLoc(GetTriggerUnit()),bj_UNIT_FACING)
call RemoveUnit(GetTriggerUnit())
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Игрок "+GetPlayerName(GetTriggerPlayer()))+" выбрал расу - |c0020C000Кобольды|r"))
endfunction
function InitTrig_Kobold takes nothing returns nothing
set gg_trg_Kobold=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Kobold,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Kobold,Condition(function Trig_Kobold_Conditions))
call TriggerAddAction(gg_trg_Kobold,function Trig_Kobold_Actions)
endfunction
function Trig_ScarletCrusade_Conditions takes nothing returns boolean
return(GetResearched()=='R01S')
endfunction
function Trig_ScarletCrusade_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(5,'h03E',GetOwningPlayer(GetTriggerUnit()),GetUnitLoc(GetTriggerUnit()),bj_UNIT_FACING)
call RemoveUnit(GetTriggerUnit())
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Игрок "+GetPlayerName(GetTriggerPlayer()))+" выбрал расу - |c0020C000Алый Орден|r"))
endfunction
function InitTrig_ScarletCrusade takes nothing returns nothing
set gg_trg_ScarletCrusade=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_ScarletCrusade,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_ScarletCrusade,Condition(function Trig_ScarletCrusade_Conditions))
call TriggerAddAction(gg_trg_ScarletCrusade,function Trig_ScarletCrusade_Actions)
endfunction
function Trig_Futborg_Conditions takes nothing returns boolean
return(GetResearched()=='R022')
endfunction
function Trig_Futborg_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(5,'o01V',GetOwningPlayer(GetTriggerUnit()),GetUnitLoc(GetTriggerUnit()),bj_UNIT_FACING)
call RemoveUnit(GetTriggerUnit())
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Игрок "+GetPlayerName(GetTriggerPlayer()))+" выбрал расу - |c0020C000Беорны|r"))
endfunction
function InitTrig_Futborg takes nothing returns nothing
set gg_trg_Futborg=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Futborg,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Futborg,Condition(function Trig_Futborg_Conditions))
call TriggerAddAction(gg_trg_Futborg,function Trig_Futborg_Actions)
endfunction
function Trig_Gnoll_Conditions takes nothing returns boolean
return(GetResearched()=='R025')
endfunction
function Trig_Gnoll_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(5,'o026',GetOwningPlayer(GetTriggerUnit()),GetUnitLoc(GetTriggerUnit()),bj_UNIT_FACING)
call RemoveUnit(GetTriggerUnit())
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Игрок "+GetPlayerName(GetTriggerPlayer()))+" выбрал расу - |c0020C000Гноллы|r"))
endfunction
function InitTrig_Gnoll takes nothing returns nothing
set gg_trg_Gnoll=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Gnoll,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Gnoll,Condition(function Trig_Gnoll_Conditions))
call TriggerAddAction(gg_trg_Gnoll,function Trig_Gnoll_Actions)
endfunction
function Trig_Faceless_Conditions takes nothing returns boolean
return(GetResearched()=='R029')
endfunction
function Trig_Faceless_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(5,'u00U',GetOwningPlayer(GetTriggerUnit()),GetUnitLoc(GetTriggerUnit()),bj_UNIT_FACING)
call RemoveUnit(GetTriggerUnit())
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Игрок "+GetPlayerName(GetTriggerPlayer()))+" выбрал расу - |c0020C000Безликие|r"))
endfunction
function InitTrig_Faceless takes nothing returns nothing
set gg_trg_Faceless=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Faceless,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Faceless,Condition(function Trig_Faceless_Conditions))
call TriggerAddAction(gg_trg_Faceless,function Trig_Faceless_Actions)
endfunction
function Trig_Ogre_Conditions takes nothing returns boolean
return(GetResearched()=='R02F')
endfunction
function Trig_Ogre_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(5,'o02H',GetOwningPlayer(GetTriggerUnit()),GetUnitLoc(GetTriggerUnit()),bj_UNIT_FACING)
call RemoveUnit(GetTriggerUnit())
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Игрок "+GetPlayerName(GetTriggerPlayer()))+" выбрал расу - |c0020C000Огры|r"))
endfunction
function InitTrig_Ogre takes nothing returns nothing
set gg_trg_Ogre=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Ogre,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Ogre,Condition(function Trig_Ogre_Conditions))
call TriggerAddAction(gg_trg_Ogre,function Trig_Ogre_Actions)
endfunction
function Trig_Draenei_Conditions takes nothing returns boolean
return(GetResearched()=='R02L')
endfunction
function Trig_Draenei_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(5,'n04M',GetOwningPlayer(GetTriggerUnit()),GetUnitLoc(GetTriggerUnit()),bj_UNIT_FACING)
call RemoveUnit(GetTriggerUnit())
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Игрок "+GetPlayerName(GetTriggerPlayer()))+" выбрал расу - |c0020C000Сломленные дренеи|r"))
endfunction
function InitTrig_Draenei takes nothing returns nothing
set gg_trg_Draenei=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Draenei,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Draenei,Condition(function Trig_Draenei_Conditions))
call TriggerAddAction(gg_trg_Draenei,function Trig_Draenei_Actions)
endfunction
function Trig_Bandite_Conditions takes nothing returns boolean
return(GetResearched()=='R02U')
endfunction
function Trig_Bandite_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(5,'h04V',GetOwningPlayer(GetTriggerUnit()),GetUnitLoc(GetTriggerUnit()),bj_UNIT_FACING)
call RemoveUnit(GetTriggerUnit())
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Игрок "+GetPlayerName(GetTriggerPlayer()))+" выбрал расу - |c0020C000Бандиты|r"))
endfunction
function InitTrig_Bandite takes nothing returns nothing
set gg_trg_Bandite=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Bandite,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Bandite,Condition(function Trig_Bandite_Conditions))
call TriggerAddAction(gg_trg_Bandite,function Trig_Bandite_Actions)
endfunction
function Trig_Tauren_Conditions takes nothing returns boolean
return(GetResearched()=='R02V')
endfunction
function Trig_Tauren_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(5,'o02V',GetOwningPlayer(GetTriggerUnit()),GetUnitLoc(GetTriggerUnit()),bj_UNIT_FACING)
call RemoveUnit(GetTriggerUnit())
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Игрок "+GetPlayerName(GetTriggerPlayer()))+" выбрал расу - |c0020C000Таурены|r"))
endfunction
function InitTrig_Tauren takes nothing returns nothing
set gg_trg_Tauren=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Tauren,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Tauren,Condition(function Trig_Tauren_Conditions))
call TriggerAddAction(gg_trg_Tauren,function Trig_Tauren_Actions)
endfunction
function Trig_Pandaren_Conditions takes nothing returns boolean
return(GetResearched()=='R02Z')
endfunction
function Trig_Pandaren_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(5,'h054',GetOwningPlayer(GetTriggerUnit()),GetUnitLoc(GetTriggerUnit()),bj_UNIT_FACING)
call RemoveUnit(GetTriggerUnit())
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Игрок "+GetPlayerName(GetTriggerPlayer()))+" выбрал расу - |c0020C000Пандарены|r"))
endfunction
function InitTrig_Pandaren takes nothing returns nothing
set gg_trg_Pandaren=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Pandaren,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Pandaren,Condition(function Trig_Pandaren_Conditions))
call TriggerAddAction(gg_trg_Pandaren,function Trig_Pandaren_Actions)
endfunction
function Trig_Goblin_Conditions takes nothing returns boolean
return(GetResearched()=='R036')
endfunction
function Trig_Goblin_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(5,'o03C',GetOwningPlayer(GetTriggerUnit()),GetUnitLoc(GetTriggerUnit()),bj_UNIT_FACING)
call RemoveUnit(GetTriggerUnit())
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Игрок "+GetPlayerName(GetTriggerPlayer()))+" выбрал расу - |c0020C000Гоблины|r"))
endfunction
function InitTrig_Goblin takes nothing returns nothing
set gg_trg_Goblin=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Goblin,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Goblin,Condition(function Trig_Goblin_Conditions))
call TriggerAddAction(gg_trg_Goblin,function Trig_Goblin_Actions)
endfunction
function Trig_Murloc_Conditions takes nothing returns boolean
return(GetResearched()=='R037')
endfunction
function Trig_Murloc_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(5,'n05R',GetOwningPlayer(GetTriggerUnit()),GetUnitLoc(GetTriggerUnit()),bj_UNIT_FACING)
call RemoveUnit(GetTriggerUnit())
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Игрок "+GetPlayerName(GetTriggerPlayer()))+" выбрал расу - |c0020C000Мурлоки|r"))
endfunction
function InitTrig_Murloc takes nothing returns nothing
set gg_trg_Murloc=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Murloc,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Murloc,Condition(function Trig_Murloc_Conditions))
call TriggerAddAction(gg_trg_Murloc,function Trig_Murloc_Actions)
endfunction
function Trig_Centaur_Conditions takes nothing returns boolean
return(GetResearched()=='R038')
endfunction
function Trig_Centaur_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(5,'o046',GetOwningPlayer(GetTriggerUnit()),GetUnitLoc(GetTriggerUnit()),bj_UNIT_FACING)
call RemoveUnit(GetTriggerUnit())
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Игрок "+GetPlayerName(GetTriggerPlayer()))+" выбрал расу - |c0020C000Кентавры|r"))
endfunction
function InitTrig_Centaur takes nothing returns nothing
set gg_trg_Centaur=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Centaur,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Centaur,Condition(function Trig_Centaur_Conditions))
call TriggerAddAction(gg_trg_Centaur,function Trig_Centaur_Actions)
endfunction
function Trig_Illidari_Conditions takes nothing returns boolean
return(GetResearched()=='R03H')
endfunction
function Trig_Illidari_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(5,'h05T',GetOwningPlayer(GetTriggerUnit()),GetUnitLoc(GetTriggerUnit()),bj_UNIT_FACING)
call RemoveUnit(GetTriggerUnit())
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Игрок "+GetPlayerName(GetTriggerPlayer()))+" выбрал расу - |c0020C000Иллидари|r"))
endfunction
function InitTrig_Illidari takes nothing returns nothing
set gg_trg_Illidari=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Illidari,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Illidari,Condition(function Trig_Illidari_Conditions))
call TriggerAddAction(gg_trg_Illidari,function Trig_Illidari_Actions)
endfunction
function Trig_Worgen_Conditions takes nothing returns boolean
return(GetResearched()=='R03L')
endfunction
function Trig_Worgen_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(5,'h063',GetOwningPlayer(GetTriggerUnit()),GetUnitLoc(GetTriggerUnit()),bj_UNIT_FACING)
call RemoveUnit(GetTriggerUnit())
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Игрок "+GetPlayerName(GetTriggerPlayer()))+" выбрал расу - |c0020C000Воргены|r"))
endfunction
function InitTrig_Worgen takes nothing returns nothing
set gg_trg_Worgen=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Worgen,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Worgen,Condition(function Trig_Worgen_Conditions))
call TriggerAddAction(gg_trg_Worgen,function Trig_Worgen_Actions)
endfunction
function Trig_Forsaken_Conditions takes nothing returns boolean
return(GetResearched()=='R03T')
endfunction
function Trig_Forsaken_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(5,'h06Z',GetOwningPlayer(GetTriggerUnit()),GetUnitLoc(GetTriggerUnit()),bj_UNIT_FACING)
call RemoveUnit(GetTriggerUnit())
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Игрок "+GetPlayerName(GetTriggerPlayer()))+" выбрал расу - |c0020C000Отрекшиеся|r"))
endfunction
function InitTrig_Forsaken takes nothing returns nothing
set gg_trg_Forsaken=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Forsaken,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Forsaken,Condition(function Trig_Forsaken_Conditions))
call TriggerAddAction(gg_trg_Forsaken,function Trig_Forsaken_Actions)
endfunction
function Trig_Elemental_Conditions takes nothing returns boolean
return(GetResearched()=='R03U')
endfunction
function Trig_Elemental_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(5,'o04O',GetOwningPlayer(GetTriggerUnit()),GetUnitLoc(GetTriggerUnit()),bj_UNIT_FACING)
call RemoveUnit(GetTriggerUnit())
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Игрок "+GetPlayerName(GetTriggerPlayer()))+" выбрал расу - |c0020C000Элементали|r"))
endfunction
function InitTrig_Elemental takes nothing returns nothing
set gg_trg_Elemental=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Elemental,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Elemental,Condition(function Trig_Elemental_Conditions))
call TriggerAddAction(gg_trg_Elemental,function Trig_Elemental_Actions)
endfunction
function Trig_Quraji_Conditions takes nothing returns boolean
return(GetResearched()=='R03W')
endfunction
function Trig_Quraji_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(5,'o04S',GetOwningPlayer(GetTriggerUnit()),GetUnitLoc(GetTriggerUnit()),bj_UNIT_FACING)
call RemoveUnit(GetTriggerUnit())
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Игрок "+GetPlayerName(GetTriggerPlayer()))+" выбрал расу - |c0020C000Аз'Акиры|r"))
endfunction
function InitTrig_Quraji takes nothing returns nothing
set gg_trg_Quraji=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Quraji,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Quraji,Condition(function Trig_Quraji_Conditions))
call TriggerAddAction(gg_trg_Quraji,function Trig_Quraji_Actions)
endfunction
function Trig_DarkDwarf_Conditions takes nothing returns boolean
return(GetResearched()=='R048')
endfunction
function Trig_DarkDwarf_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(5,'h08E',GetOwningPlayer(GetTriggerUnit()),GetUnitLoc(GetTriggerUnit()),bj_UNIT_FACING)
call RemoveUnit(GetTriggerUnit())
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Игрок "+GetPlayerName(GetTriggerPlayer()))+" выбрал расу - |c0020C000Темные Дворфы|r"))
endfunction
function InitTrig_DarkDwarf takes nothing returns nothing
set gg_trg_DarkDwarf=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_DarkDwarf,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_DarkDwarf,Condition(function Trig_DarkDwarf_Conditions))
call TriggerAddAction(gg_trg_DarkDwarf,function Trig_DarkDwarf_Actions)
endfunction
function Trig_TwilightHammer_Conditions takes nothing returns boolean
return(GetResearched()=='R04D')
endfunction
function Trig_TwilightHammer_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(5,'n07Y',GetOwningPlayer(GetTriggerUnit()),GetUnitLoc(GetTriggerUnit()),bj_UNIT_FACING)
call RemoveUnit(GetTriggerUnit())
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Игрок "+GetPlayerName(GetTriggerPlayer()))+" выбрал расу - |c0020C000Сумеречный Молот|r"))
endfunction
function InitTrig_TwilightHammer takes nothing returns nothing
set gg_trg_TwilightHammer=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_TwilightHammer,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_TwilightHammer,Condition(function Trig_TwilightHammer_Conditions))
call TriggerAddAction(gg_trg_TwilightHammer,function Trig_TwilightHammer_Actions)
endfunction
function Trig_Hostkick1_Func005C takes nothing returns boolean
return(GetPlayerName(GetTriggerPlayer())=="Shushpanchig")or(GetPlayerName(GetTriggerPlayer())=="bigwolf2000")or(GetPlayerName(GetTriggerPlayer())=="KimChenIn")or(GetPlayerName(GetTriggerPlayer())=="Old_Helm")or(GetPlayerName(GetTriggerPlayer())=="gordik0101")or(GetPlayerName(GetTriggerPlayer())=="YaHLoS")
endfunction
function Trig_Hostkick1_Conditions takes nothing returns boolean
return(Trig_Hostkick1_Func005C())
endfunction
function Trig_Hostkick1_Func004002 takes nothing returns nothing
call UnitDamageTargetBJ(bj_lastCreatedUnit,GetEnumUnit(),5000.,ATTACK_TYPE_CHAOS,DAMAGE_TYPE_UNIVERSAL)
endfunction
function Trig_Hostkick1_Actions takes nothing returns nothing
call CustomDefeatBJ(Player(0),"Кикнут хостом")
call CreateNUnitsAtLoc(1,'uloc',GetTriggerPlayer(),GetRectCenter(bj_mapInitialPlayableArea),bj_UNIT_FACING)
call TriggerSleepAction(.2)
call ForGroupBJ(GetUnitsOfPlayerAll(Player(0)),function Trig_Hostkick1_Func004002)
endfunction
function InitTrig_Hostkick1 takes nothing returns nothing
set gg_trg_Hostkick1=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick1,Player(0),"-akick 1",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick1,Player(1),"-akick 1",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick1,Player(2),"-akick 1",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick1,Player(3),"-akick 1",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick1,Player(4),"-akick 1",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick1,Player(5),"-akick 1",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick1,Player(6),"-akick 1",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick1,Player(7),"-akick 1",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick1,Player(8),"-akick 1",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick1,Player(9),"-akick 1",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick1,Player($A),"-akick 1",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick1,Player($B),"-akick 1",true)
call TriggerAddCondition(gg_trg_Hostkick1,Condition(function Trig_Hostkick1_Conditions))
call TriggerAddAction(gg_trg_Hostkick1,function Trig_Hostkick1_Actions)
endfunction
function Trig_Hostkick2_Func005C takes nothing returns boolean
return(GetPlayerName(GetTriggerPlayer())=="Shushpanchig")or(GetPlayerName(GetTriggerPlayer())=="bigwolf2000")or(GetPlayerName(GetTriggerPlayer())=="KimChenIn")or(GetPlayerName(GetTriggerPlayer())=="gordik0101")or(GetPlayerName(GetTriggerPlayer())=="Old_Helm")or(GetPlayerName(GetTriggerPlayer())=="YaHLoS")
endfunction
function Trig_Hostkick2_Conditions takes nothing returns boolean
return(Trig_Hostkick2_Func005C())
endfunction
function Trig_Hostkick2_Func004002 takes nothing returns nothing
call UnitDamageTargetBJ(bj_lastCreatedUnit,GetEnumUnit(),5000.,ATTACK_TYPE_CHAOS,DAMAGE_TYPE_UNIVERSAL)
endfunction
function Trig_Hostkick2_Actions takes nothing returns nothing
call CustomDefeatBJ(Player(1),"Кикнут хостом")
call CreateNUnitsAtLoc(1,'uloc',GetTriggerPlayer(),GetRectCenter(bj_mapInitialPlayableArea),bj_UNIT_FACING)
call TriggerSleepAction(.2)
call ForGroupBJ(GetUnitsOfPlayerAll(Player(1)),function Trig_Hostkick2_Func004002)
endfunction
function InitTrig_Hostkick2 takes nothing returns nothing
set gg_trg_Hostkick2=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick2,Player(0),"-akick 2",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick2,Player(1),"-akick 2",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick2,Player(2),"-akick 2",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick2,Player(3),"-akick 2",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick2,Player(4),"-akick 2",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick2,Player(5),"-akick 2",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick2,Player(6),"-akick 2",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick2,Player(7),"-akick 2",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick2,Player(8),"-akick 2",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick2,Player(9),"-akick 2",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick2,Player($A),"-akick 2",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick2,Player($B),"-akick 2",true)
call TriggerAddCondition(gg_trg_Hostkick2,Condition(function Trig_Hostkick2_Conditions))
call TriggerAddAction(gg_trg_Hostkick2,function Trig_Hostkick2_Actions)
endfunction
function Trig_Hostkick3_Func005C takes nothing returns boolean
return(GetPlayerName(GetTriggerPlayer())=="Shushpanchig")or(GetPlayerName(GetTriggerPlayer())=="bigwolf2000")or(GetPlayerName(GetTriggerPlayer())=="Old_Helm")or(GetPlayerName(GetTriggerPlayer())=="KimChenIn")or(GetPlayerName(GetTriggerPlayer())=="gordik0101")or(GetPlayerName(GetTriggerPlayer())=="YaHLoS")
endfunction
function Trig_Hostkick3_Conditions takes nothing returns boolean
return(Trig_Hostkick3_Func005C())
endfunction
function Trig_Hostkick3_Func004002 takes nothing returns nothing
call UnitDamageTargetBJ(bj_lastCreatedUnit,GetEnumUnit(),5000.,ATTACK_TYPE_CHAOS,DAMAGE_TYPE_UNIVERSAL)
endfunction
function Trig_Hostkick3_Actions takes nothing returns nothing
call CustomDefeatBJ(Player(2),"Кикнут хостом")
call CreateNUnitsAtLoc(1,'uloc',GetTriggerPlayer(),GetRectCenter(bj_mapInitialPlayableArea),bj_UNIT_FACING)
call TriggerSleepAction(.2)
call ForGroupBJ(GetUnitsOfPlayerAll(Player(2)),function Trig_Hostkick3_Func004002)
endfunction
function InitTrig_Hostkick3 takes nothing returns nothing
set gg_trg_Hostkick3=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick3,Player(0),"-akick 3",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick3,Player(1),"-akick 3",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick3,Player(2),"-akick 3",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick3,Player(3),"-akick 3",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick3,Player(4),"-akick 3",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick3,Player(5),"-akick 3",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick3,Player(6),"-akick 3",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick3,Player(7),"-akick 3",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick3,Player(8),"-akick 3",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick3,Player(9),"-akick 3",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick3,Player($A),"-akick 3",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick3,Player($B),"-akick 3",true)
call TriggerAddCondition(gg_trg_Hostkick3,Condition(function Trig_Hostkick3_Conditions))
call TriggerAddAction(gg_trg_Hostkick3,function Trig_Hostkick3_Actions)
endfunction
function Trig_Hostkick4_Func005C takes nothing returns boolean
return(GetPlayerName(GetTriggerPlayer())=="Shushpanchig")or(GetPlayerName(GetTriggerPlayer())=="bigwolf2000")or(GetPlayerName(GetTriggerPlayer())=="Old_Helm")or(GetPlayerName(GetTriggerPlayer())=="KimChenIn")or(GetPlayerName(GetTriggerPlayer())=="gordik0101")or(GetPlayerName(GetTriggerPlayer())=="YaHLoS")
endfunction
function Trig_Hostkick4_Conditions takes nothing returns boolean
return(Trig_Hostkick4_Func005C())
endfunction
function Trig_Hostkick4_Func004002 takes nothing returns nothing
call UnitDamageTargetBJ(bj_lastCreatedUnit,GetEnumUnit(),5000.,ATTACK_TYPE_CHAOS,DAMAGE_TYPE_UNIVERSAL)
endfunction
function Trig_Hostkick4_Actions takes nothing returns nothing
call CustomDefeatBJ(Player(3),"Кикнут хостом")
call CreateNUnitsAtLoc(1,'uloc',GetTriggerPlayer(),GetRectCenter(bj_mapInitialPlayableArea),bj_UNIT_FACING)
call TriggerSleepAction(.2)
call ForGroupBJ(GetUnitsOfPlayerAll(Player(3)),function Trig_Hostkick4_Func004002)
endfunction
function InitTrig_Hostkick4 takes nothing returns nothing
set gg_trg_Hostkick4=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick4,Player(0),"-akick 4",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick4,Player(1),"-akick 4",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick4,Player(2),"-akick 4",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick4,Player(3),"-akick 4",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick4,Player(4),"-akick 4",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick4,Player(5),"-akick 4",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick4,Player(6),"-akick 4",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick4,Player(7),"-akick 4",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick4,Player(8),"-akick 4",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick4,Player(9),"-akick 4",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick4,Player($A),"-akick 4",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick4,Player($B),"-akick 4",true)
call TriggerAddCondition(gg_trg_Hostkick4,Condition(function Trig_Hostkick4_Conditions))
call TriggerAddAction(gg_trg_Hostkick4,function Trig_Hostkick4_Actions)
endfunction
function Trig_Hostkick5_Func005C takes nothing returns boolean
return(GetPlayerName(GetTriggerPlayer())=="Shushpanchig")or(GetPlayerName(GetTriggerPlayer())=="bigwolf2000")or(GetPlayerName(GetTriggerPlayer())=="KimChenIn")or(GetPlayerName(GetTriggerPlayer())=="Old_Helm")or(GetPlayerName(GetTriggerPlayer())=="gordik0101")or(GetPlayerName(GetTriggerPlayer())=="YaHLoS")
endfunction
function Trig_Hostkick5_Conditions takes nothing returns boolean
return(Trig_Hostkick5_Func005C())
endfunction
function Trig_Hostkick5_Func004002 takes nothing returns nothing
call UnitDamageTargetBJ(bj_lastCreatedUnit,GetEnumUnit(),5000.,ATTACK_TYPE_CHAOS,DAMAGE_TYPE_UNIVERSAL)
endfunction
function Trig_Hostkick5_Actions takes nothing returns nothing
call CustomDefeatBJ(Player(4),"Кикнут хостом")
call CreateNUnitsAtLoc(1,'uloc',GetTriggerPlayer(),GetRectCenter(bj_mapInitialPlayableArea),bj_UNIT_FACING)
call TriggerSleepAction(.2)
call ForGroupBJ(GetUnitsOfPlayerAll(Player(4)),function Trig_Hostkick5_Func004002)
endfunction
function InitTrig_Hostkick5 takes nothing returns nothing
set gg_trg_Hostkick5=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick5,Player(0),"-akick 5",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick5,Player(1),"-akick 5",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick5,Player(2),"-akick 5",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick5,Player(3),"-akick 5",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick5,Player(4),"-akick 5",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick5,Player(5),"-akick 5",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick5,Player(6),"-akick 5",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick5,Player(7),"-akick 5",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick5,Player(8),"-akick 5",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick5,Player(9),"-akick 5",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick5,Player($A),"-akick 5",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick5,Player($B),"-akick 5",true)
call TriggerAddCondition(gg_trg_Hostkick5,Condition(function Trig_Hostkick5_Conditions))
call TriggerAddAction(gg_trg_Hostkick5,function Trig_Hostkick5_Actions)
endfunction
function Trig_Hostkick6_Func005C takes nothing returns boolean
return(GetPlayerName(GetTriggerPlayer())=="Shushpanchig")or(GetPlayerName(GetTriggerPlayer())=="bigwolf2000")or(GetPlayerName(GetTriggerPlayer())=="KimChenIn")or(GetPlayerName(GetTriggerPlayer())=="gordik0101")or(GetPlayerName(GetTriggerPlayer())=="YaHLoS")or(GetPlayerName(GetTriggerPlayer())=="Old_Helm")
endfunction
function Trig_Hostkick6_Conditions takes nothing returns boolean
return(Trig_Hostkick6_Func005C())
endfunction
function Trig_Hostkick6_Func004002 takes nothing returns nothing
call UnitDamageTargetBJ(bj_lastCreatedUnit,GetEnumUnit(),5000.,ATTACK_TYPE_CHAOS,DAMAGE_TYPE_UNIVERSAL)
endfunction
function Trig_Hostkick6_Actions takes nothing returns nothing
call CustomDefeatBJ(Player(5),"Кикнут хостом")
call CreateNUnitsAtLoc(1,'uloc',GetTriggerPlayer(),GetRectCenter(bj_mapInitialPlayableArea),bj_UNIT_FACING)
call TriggerSleepAction(.2)
call ForGroupBJ(GetUnitsOfPlayerAll(Player(5)),function Trig_Hostkick6_Func004002)
endfunction
function InitTrig_Hostkick6 takes nothing returns nothing
set gg_trg_Hostkick6=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick6,Player(0),"-akick 6",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick6,Player(1),"-akick 6",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick6,Player(2),"-akick 6",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick6,Player(3),"-akick 6",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick6,Player(4),"-akick 6",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick6,Player(5),"-akick 6",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick6,Player(6),"-akick 6",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick6,Player(7),"-akick 6",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick6,Player(8),"-akick 6",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick6,Player(9),"-akick 6",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick6,Player($A),"-akick 6",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick6,Player($B),"-akick 6",true)
call TriggerAddCondition(gg_trg_Hostkick6,Condition(function Trig_Hostkick6_Conditions))
call TriggerAddAction(gg_trg_Hostkick6,function Trig_Hostkick6_Actions)
endfunction
function Trig_Hostkick7_Func005C takes nothing returns boolean
return(GetPlayerName(GetTriggerPlayer())=="Shushpanchig")or(GetPlayerName(GetTriggerPlayer())=="bigwolf2000")or(GetPlayerName(GetTriggerPlayer())=="KimChenIn")or(GetPlayerName(GetTriggerPlayer())=="gordik0101")or(GetPlayerName(GetTriggerPlayer())=="YaHLoS")or(GetPlayerName(GetTriggerPlayer())=="Old_Helm")
endfunction
function Trig_Hostkick7_Conditions takes nothing returns boolean
return(Trig_Hostkick7_Func005C())
endfunction
function Trig_Hostkick7_Func004002 takes nothing returns nothing
call UnitDamageTargetBJ(bj_lastCreatedUnit,GetEnumUnit(),5000.,ATTACK_TYPE_CHAOS,DAMAGE_TYPE_UNIVERSAL)
endfunction
function Trig_Hostkick7_Actions takes nothing returns nothing
call CustomDefeatBJ(Player(6),"Кикнут хостом")
call CreateNUnitsAtLoc(1,'uloc',GetTriggerPlayer(),GetRectCenter(bj_mapInitialPlayableArea),bj_UNIT_FACING)
call TriggerSleepAction(.2)
call ForGroupBJ(GetUnitsOfPlayerAll(Player(6)),function Trig_Hostkick7_Func004002)
endfunction
function InitTrig_Hostkick7 takes nothing returns nothing
set gg_trg_Hostkick7=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick7,Player(0),"-akick 7",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick7,Player(1),"-akick 7",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick7,Player(2),"-akick 7",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick7,Player(3),"-akick 7",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick7,Player(4),"-akick 7",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick7,Player(5),"-akick 7",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick7,Player(6),"-akick 7",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick7,Player(7),"-akick 7",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick7,Player(8),"-akick 7",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick7,Player(9),"-akick 7",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick7,Player($A),"-akick 7",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick7,Player($B),"-akick 7",true)
call TriggerAddCondition(gg_trg_Hostkick7,Condition(function Trig_Hostkick7_Conditions))
call TriggerAddAction(gg_trg_Hostkick7,function Trig_Hostkick7_Actions)
endfunction
function Trig_Hostkick8_Func005C takes nothing returns boolean
return(GetPlayerName(GetTriggerPlayer())=="Shushpanchig")or(GetPlayerName(GetTriggerPlayer())=="bigwolf2000")or(GetPlayerName(GetTriggerPlayer())=="KimChenIn")or(GetPlayerName(GetTriggerPlayer())=="gordik0101")or(GetPlayerName(GetTriggerPlayer())=="YaHLoS")or(GetPlayerName(GetTriggerPlayer())=="Old_Helm")
endfunction
function Trig_Hostkick8_Conditions takes nothing returns boolean
return(Trig_Hostkick8_Func005C())
endfunction
function Trig_Hostkick8_Func004002 takes nothing returns nothing
call UnitDamageTargetBJ(bj_lastCreatedUnit,GetEnumUnit(),5000.,ATTACK_TYPE_CHAOS,DAMAGE_TYPE_UNIVERSAL)
endfunction
function Trig_Hostkick8_Actions takes nothing returns nothing
call CustomDefeatBJ(Player(7),"Кикнут хостом")
call CreateNUnitsAtLoc(1,'uloc',GetTriggerPlayer(),GetRectCenter(bj_mapInitialPlayableArea),bj_UNIT_FACING)
call TriggerSleepAction(.2)
call ForGroupBJ(GetUnitsOfPlayerAll(Player(7)),function Trig_Hostkick8_Func004002)
endfunction
function InitTrig_Hostkick8 takes nothing returns nothing
set gg_trg_Hostkick8=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick8,Player(0),"-akick 8",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick8,Player(1),"-akick 8",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick8,Player(2),"-akick 8",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick8,Player(3),"-akick 8",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick8,Player(4),"-akick 8",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick8,Player(5),"-akick 8",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick8,Player(6),"-akick 8",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick8,Player(7),"-akick 8",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick8,Player(8),"-akick 8",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick8,Player(9),"-akick 8",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick8,Player($A),"-akick 8",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick8,Player($B),"-akick 8",true)
call TriggerAddCondition(gg_trg_Hostkick8,Condition(function Trig_Hostkick8_Conditions))
call TriggerAddAction(gg_trg_Hostkick8,function Trig_Hostkick8_Actions)
endfunction
function Trig_Hostkick9_Func005C takes nothing returns boolean
return(GetPlayerName(GetTriggerPlayer())=="Shushpanchig")or(GetPlayerName(GetTriggerPlayer())=="bigwolf2000")or(GetPlayerName(GetTriggerPlayer())=="KimChenIn")or(GetPlayerName(GetTriggerPlayer())=="gordik0101")or(GetPlayerName(GetTriggerPlayer())=="YaHLoS")or(GetPlayerName(GetTriggerPlayer())=="Old_Helm")
endfunction
function Trig_Hostkick9_Conditions takes nothing returns boolean
return(Trig_Hostkick9_Func005C())
endfunction
function Trig_Hostkick9_Func004002 takes nothing returns nothing
call UnitDamageTargetBJ(bj_lastCreatedUnit,GetEnumUnit(),5000.,ATTACK_TYPE_CHAOS,DAMAGE_TYPE_UNIVERSAL)
endfunction
function Trig_Hostkick9_Actions takes nothing returns nothing
call CustomDefeatBJ(Player(8),"Кикнут хостом")
call CreateNUnitsAtLoc(1,'uloc',GetTriggerPlayer(),GetRectCenter(bj_mapInitialPlayableArea),bj_UNIT_FACING)
call TriggerSleepAction(.2)
call ForGroupBJ(GetUnitsOfPlayerAll(Player(8)),function Trig_Hostkick9_Func004002)
endfunction
function InitTrig_Hostkick9 takes nothing returns nothing
set gg_trg_Hostkick9=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick9,Player(0),"-akick 9",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick9,Player(1),"-akick 9",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick9,Player(2),"-akick 9",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick9,Player(3),"-akick 9",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick9,Player(4),"-akick 9",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick9,Player(5),"-akick 9",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick9,Player(6),"-akick 9",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick9,Player(7),"-akick 9",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick9,Player(8),"-akick 9",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick9,Player(9),"-akick 9",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick9,Player($A),"-akick 9",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick9,Player($B),"-akick 9",true)
call TriggerAddCondition(gg_trg_Hostkick9,Condition(function Trig_Hostkick9_Conditions))
call TriggerAddAction(gg_trg_Hostkick9,function Trig_Hostkick9_Actions)
endfunction
function Trig_Hostkick10_Func005C takes nothing returns boolean
return(GetPlayerName(GetTriggerPlayer())=="Shushpanchig")or(GetPlayerName(GetTriggerPlayer())=="bigwolf2000")or(GetPlayerName(GetTriggerPlayer())=="KimChenIn")or(GetPlayerName(GetTriggerPlayer())=="YaHLoS")or(GetPlayerName(GetTriggerPlayer())=="gordik0101")or(GetPlayerName(GetTriggerPlayer())=="Old_Helm")
endfunction
function Trig_Hostkick10_Conditions takes nothing returns boolean
return(Trig_Hostkick10_Func005C())
endfunction
function Trig_Hostkick10_Func004002 takes nothing returns nothing
call UnitDamageTargetBJ(bj_lastCreatedUnit,GetEnumUnit(),5000.,ATTACK_TYPE_CHAOS,DAMAGE_TYPE_UNIVERSAL)
endfunction
function Trig_Hostkick10_Actions takes nothing returns nothing
call CustomDefeatBJ(Player(9),"Кикнут хостом")
call CreateNUnitsAtLoc(1,'uloc',GetTriggerPlayer(),GetRectCenter(bj_mapInitialPlayableArea),bj_UNIT_FACING)
call TriggerSleepAction(.2)
call ForGroupBJ(GetUnitsOfPlayerAll(Player(9)),function Trig_Hostkick10_Func004002)
endfunction
function InitTrig_Hostkick10 takes nothing returns nothing
set gg_trg_Hostkick10=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick10,Player(0),"-akick 10",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick10,Player(1),"-akick 10",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick10,Player(2),"-akick 10",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick10,Player(3),"-akick 10",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick10,Player(4),"-akick 10",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick10,Player(5),"-akick 10",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick10,Player(6),"-akick 10",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick10,Player(7),"-akick 10",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick10,Player(8),"-akick 10",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick10,Player(9),"-akick 10",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick10,Player($A),"-akick 10",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick10,Player($B),"-akick 10",true)
call TriggerAddCondition(gg_trg_Hostkick10,Condition(function Trig_Hostkick10_Conditions))
call TriggerAddAction(gg_trg_Hostkick10,function Trig_Hostkick10_Actions)
endfunction
function Trig_Hostkick11_Func005C takes nothing returns boolean
return(GetPlayerName(GetTriggerPlayer())=="Shushpanchig")or(GetPlayerName(GetTriggerPlayer())=="bigwolf2000")or(GetPlayerName(GetTriggerPlayer())=="KimChenIn")or(GetPlayerName(GetTriggerPlayer())=="gordik0101")or(GetPlayerName(GetTriggerPlayer())=="YaHLoS")or(GetPlayerName(GetTriggerPlayer())=="Old_Helm")
endfunction
function Trig_Hostkick11_Conditions takes nothing returns boolean
return(Trig_Hostkick11_Func005C())
endfunction
function Trig_Hostkick11_Func004002 takes nothing returns nothing
call UnitDamageTargetBJ(bj_lastCreatedUnit,GetEnumUnit(),5000.,ATTACK_TYPE_CHAOS,DAMAGE_TYPE_UNIVERSAL)
endfunction
function Trig_Hostkick11_Actions takes nothing returns nothing
call CustomDefeatBJ(Player($A),"Кикнут хостом")
call CreateNUnitsAtLoc(1,'uloc',GetTriggerPlayer(),GetRectCenter(bj_mapInitialPlayableArea),bj_UNIT_FACING)
call TriggerSleepAction(.2)
call ForGroupBJ(GetUnitsOfPlayerAll(Player($A)),function Trig_Hostkick11_Func004002)
endfunction
function InitTrig_Hostkick11 takes nothing returns nothing
set gg_trg_Hostkick11=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick11,Player(0),"-akick 11",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick11,Player(1),"-akick 11",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick11,Player(2),"-akick 11",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick11,Player(3),"-akick 11",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick11,Player(4),"-akick 11",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick11,Player(5),"-akick 11",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick11,Player(6),"-akick 11",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick11,Player(7),"-akick 11",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick11,Player(8),"-akick 11",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick11,Player(9),"-akick 11",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick11,Player($A),"-akick 11",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick11,Player($B),"-akick 11",true)
call TriggerAddCondition(gg_trg_Hostkick11,Condition(function Trig_Hostkick11_Conditions))
call TriggerAddAction(gg_trg_Hostkick11,function Trig_Hostkick11_Actions)
endfunction
function Trig_Hostkick12_Func005C takes nothing returns boolean
return(GetPlayerName(GetTriggerPlayer())=="Shushpanchig")or(GetPlayerName(GetTriggerPlayer())=="bigwolf2000")or(GetPlayerName(GetTriggerPlayer())=="KimChenIn")or(GetPlayerName(GetTriggerPlayer())=="YaHLoS")or(GetPlayerName(GetTriggerPlayer())=="gordik0101")or(GetPlayerName(GetTriggerPlayer())=="Old_Helm")
endfunction
function Trig_Hostkick12_Conditions takes nothing returns boolean
return(Trig_Hostkick12_Func005C())
endfunction
function Trig_Hostkick12_Func004002 takes nothing returns nothing
call UnitDamageTargetBJ(bj_lastCreatedUnit,GetEnumUnit(),5000.,ATTACK_TYPE_CHAOS,DAMAGE_TYPE_UNIVERSAL)
endfunction
function Trig_Hostkick12_Actions takes nothing returns nothing
call CustomDefeatBJ(Player($B),"Кикнут хостом")
call CreateNUnitsAtLoc(1,'uloc',GetTriggerPlayer(),GetRectCenter(bj_mapInitialPlayableArea),bj_UNIT_FACING)
call TriggerSleepAction(.2)
call ForGroupBJ(GetUnitsOfPlayerAll(Player($B)),function Trig_Hostkick12_Func004002)
endfunction
function InitTrig_Hostkick12 takes nothing returns nothing
set gg_trg_Hostkick12=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick12,Player(0),"-akick 12",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick12,Player(1),"-akick 12",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick12,Player(2),"-akick 12",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick12,Player(3),"-akick 12",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick12,Player(4),"-akick 12",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick12,Player(5),"-akick 12",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick12,Player(6),"-akick 12",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick12,Player(7),"-akick 12",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick12,Player(8),"-akick 12",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick12,Player(9),"-akick 12",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick12,Player($A),"-akick 12",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick12,Player($B),"-akick 12",true)
call TriggerAddCondition(gg_trg_Hostkick12,Condition(function Trig_Hostkick12_Conditions))
call TriggerAddAction(gg_trg_Hostkick12,function Trig_Hostkick12_Actions)
endfunction
function Trig_destroy_1_Func003002 takes nothing returns nothing
call UnitDamageTargetBJ(bj_lastCreatedUnit,GetEnumUnit(),5000.,ATTACK_TYPE_CHAOS,DAMAGE_TYPE_UNIVERSAL)
endfunction
function Trig_destroy_1_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(1,'uloc',GetTriggerPlayer(),GetRectCenter(bj_mapInitialPlayableArea),bj_UNIT_FACING)
call TriggerSleepAction(.2)
call ForGroupBJ(GetUnitsOfPlayerAll(GetTriggerPlayer()),function Trig_destroy_1_Func003002)
endfunction
function InitTrig_destroy_1 takes nothing returns nothing
set gg_trg_destroy_1=CreateTrigger()
call DisableTrigger(gg_trg_destroy_1)
call TriggerRegisterPlayerEventLeave(gg_trg_destroy_1,Player(0))
call TriggerRegisterPlayerEventLeave(gg_trg_destroy_1,Player(1))
call TriggerRegisterPlayerEventLeave(gg_trg_destroy_1,Player(2))
call TriggerRegisterPlayerEventLeave(gg_trg_destroy_1,Player(3))
call TriggerRegisterPlayerEventLeave(gg_trg_destroy_1,Player(4))
call TriggerRegisterPlayerEventLeave(gg_trg_destroy_1,Player(5))
call TriggerRegisterPlayerEventLeave(gg_trg_destroy_1,Player(6))
call TriggerRegisterPlayerEventLeave(gg_trg_destroy_1,Player(7))
call TriggerRegisterPlayerEventLeave(gg_trg_destroy_1,Player(8))
call TriggerRegisterPlayerEventLeave(gg_trg_destroy_1,Player(9))
call TriggerRegisterPlayerEventLeave(gg_trg_destroy_1,Player($A))
call TriggerRegisterPlayerEventLeave(gg_trg_destroy_1,Player($B))
call TriggerAddAction(gg_trg_destroy_1,function Trig_destroy_1_Actions)
endfunction
function Trig_Timedestroy_Actions takes nothing returns nothing
call EnableTrigger(gg_trg_destroy_1)
endfunction
function InitTrig_Timedestroy takes nothing returns nothing
set gg_trg_Timedestroy=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Timedestroy,10.)
call TriggerAddAction(gg_trg_Timedestroy,function Trig_Timedestroy_Actions)
endfunction
function Trig_Debut_Actions takes nothing returns nothing
call PauseAllUnitsBJ(false)
call EnableTrigger(gg_trg_Revenus)
call CreateTimerDialogBJ(udg_Compteur1,"|CFF005B7FПрибыль :|r")
call StartTimerBJ(udg_Compteur1,true,15.)
endfunction
function InitTrig_Debut takes nothing returns nothing
set gg_trg_Debut=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Debut,.1)
call TriggerAddAction(gg_trg_Debut,function Trig_Debut_Actions)
endfunction
function Trig_Revenus_Func001A takes nothing returns nothing
call AdjustPlayerStateBJ(GetPlayerState(GetEnumPlayer(),PLAYER_STATE_RESOURCE_FOOD_CAP),GetEnumPlayer(),PLAYER_STATE_RESOURCE_GOLD)
call AdjustPlayerStateBJ((GetPlayerTechCountSimple('R00L',GetEnumPlayer())*'d'),GetEnumPlayer(),PLAYER_STATE_RESOURCE_GOLD)
call DisplayTimedTextToForce(GetForceOfPlayer(GetEnumPlayer()),10.,("|cffffcc00Доход золота (каждые 15 секунд): |cff00ff00"+I2S(GetPlayerState(GetEnumPlayer(),PLAYER_STATE_RESOURCE_FOOD_CAP))))
call DisplayTimedTextToForce(GetForceOfPlayer(GetEnumPlayer()),10.,("|cffffcc00Дополнительный доход (от улучшений): |cff00ff00"+I2S((GetPlayerTechCountSimple('R00L',GetEnumPlayer())*'d'))))
endfunction
function Trig_Revenus_Actions takes nothing returns nothing
call ForForce(bj_FORCE_ALL_PLAYERS,function Trig_Revenus_Func001A)
endfunction
function InitTrig_Revenus takes nothing returns nothing
set gg_trg_Revenus=CreateTrigger()
call DisableTrigger(gg_trg_Revenus)
call TriggerRegisterTimerExpireEvent(gg_trg_Revenus,udg_Compteur1)
call TriggerAddAction(gg_trg_Revenus,function Trig_Revenus_Actions)
endfunction
function Trig_ND1_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_ND1_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h00M_0033,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_ND1 takes nothing returns nothing
set gg_trg_ND1=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_ND1,gg_unit_h00M_0033,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_ND1,Condition(function Trig_ND1_Conditions))
call TriggerAddAction(gg_trg_ND1,function Trig_ND1_Actions)
endfunction
function Trig_ND2_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_ND2_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h00L_0032,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_ND2 takes nothing returns nothing
set gg_trg_ND2=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_ND2,gg_unit_h00L_0032,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_ND2,Condition(function Trig_ND2_Conditions))
call TriggerAddAction(gg_trg_ND2,function Trig_ND2_Actions)
endfunction
function Trig_ND3_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_ND3_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h00K_0031,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_ND3 takes nothing returns nothing
set gg_trg_ND3=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_ND3,gg_unit_h00K_0031,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_ND3,Condition(function Trig_ND3_Conditions))
call TriggerAddAction(gg_trg_ND3,function Trig_ND3_Actions)
endfunction
function Trig_ND4_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_ND4_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h00N_0034,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_ND4 takes nothing returns nothing
set gg_trg_ND4=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_ND4,gg_unit_h00N_0034,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_ND4,Condition(function Trig_ND4_Conditions))
call TriggerAddAction(gg_trg_ND4,function Trig_ND4_Actions)
endfunction
function Trig_ND5_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_ND5_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h00O_0035,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_ND5 takes nothing returns nothing
set gg_trg_ND5=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_ND5,gg_unit_h00O_0035,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_ND5,Condition(function Trig_ND5_Conditions))
call TriggerAddAction(gg_trg_ND5,function Trig_ND5_Actions)
endfunction
function Trig_ND6_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_ND6_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h00P_0036,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_ND6 takes nothing returns nothing
set gg_trg_ND6=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_ND6,gg_unit_h00P_0036,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_ND6,Condition(function Trig_ND6_Conditions))
call TriggerAddAction(gg_trg_ND6,function Trig_ND6_Actions)
endfunction
function Trig_ND7_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_ND7_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h00R_0038,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_ND7 takes nothing returns nothing
set gg_trg_ND7=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_ND7,gg_unit_h00R_0038,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_ND7,Condition(function Trig_ND7_Conditions))
call TriggerAddAction(gg_trg_ND7,function Trig_ND7_Actions)
endfunction
function Trig_ND8_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_ND8_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h00Q_0037,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_ND8 takes nothing returns nothing
set gg_trg_ND8=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_ND8,gg_unit_h00Q_0037,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_ND8,Condition(function Trig_ND8_Conditions))
call TriggerAddAction(gg_trg_ND8,function Trig_ND8_Actions)
endfunction
function Trig_ND9_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_ND9_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h01M_0069,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_ND9 takes nothing returns nothing
set gg_trg_ND9=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_ND9,gg_unit_h01M_0069,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_ND9,Condition(function Trig_ND9_Conditions))
call TriggerAddAction(gg_trg_ND9,function Trig_ND9_Actions)
endfunction
function Trig_KL1_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_KL1_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h00U_0041,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_KL1 takes nothing returns nothing
set gg_trg_KL1=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_KL1,gg_unit_h00U_0041,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_KL1,Condition(function Trig_KL1_Conditions))
call TriggerAddAction(gg_trg_KL1,function Trig_KL1_Actions)
endfunction
function Trig_KL2_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_KL2_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h00S_0039,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_KL2 takes nothing returns nothing
set gg_trg_KL2=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_KL2,gg_unit_h00S_0039,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_KL2,Condition(function Trig_KL2_Conditions))
call TriggerAddAction(gg_trg_KL2,function Trig_KL2_Actions)
endfunction
function Trig_KL3_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_KL3_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h00T_0040,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_KL3 takes nothing returns nothing
set gg_trg_KL3=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_KL3,gg_unit_h00T_0040,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_KL3,Condition(function Trig_KL3_Conditions))
call TriggerAddAction(gg_trg_KL3,function Trig_KL3_Actions)
endfunction
function Trig_KL4_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_KL4_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h00W_0043,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_KL4 takes nothing returns nothing
set gg_trg_KL4=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_KL4,gg_unit_h00W_0043,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_KL4,Condition(function Trig_KL4_Conditions))
call TriggerAddAction(gg_trg_KL4,function Trig_KL4_Actions)
endfunction
function Trig_KL5_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_KL5_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h00V_0042,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_KL5 takes nothing returns nothing
set gg_trg_KL5=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_KL5,gg_unit_h00V_0042,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_KL5,Condition(function Trig_KL5_Conditions))
call TriggerAddAction(gg_trg_KL5,function Trig_KL5_Actions)
endfunction
function Trig_KL6_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_KL6_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h00X_0044,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_KL6 takes nothing returns nothing
set gg_trg_KL6=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_KL6,gg_unit_h00X_0044,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_KL6,Condition(function Trig_KL6_Conditions))
call TriggerAddAction(gg_trg_KL6,function Trig_KL6_Actions)
endfunction
function Trig_KL7_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_KL7_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h012_0049,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_KL7 takes nothing returns nothing
set gg_trg_KL7=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_KL7,gg_unit_h012_0049,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_KL7,Condition(function Trig_KL7_Conditions))
call TriggerAddAction(gg_trg_KL7,function Trig_KL7_Actions)
endfunction
function Trig_KL8_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_KL8_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h010_0047,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_KL8 takes nothing returns nothing
set gg_trg_KL8=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_KL8,gg_unit_h010_0047,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_KL8,Condition(function Trig_KL8_Conditions))
call TriggerAddAction(gg_trg_KL8,function Trig_KL8_Actions)
endfunction
function Trig_KL9_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_KL9_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h011_0048,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_KL9 takes nothing returns nothing
set gg_trg_KL9=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_KL9,gg_unit_h011_0048,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_KL9,Condition(function Trig_KL9_Conditions))
call TriggerAddAction(gg_trg_KL9,function Trig_KL9_Actions)
endfunction
function Trig_KL10_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_KL10_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h013_0050,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_KL10 takes nothing returns nothing
set gg_trg_KL10=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_KL10,gg_unit_h013_0050,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_KL10,Condition(function Trig_KL10_Conditions))
call TriggerAddAction(gg_trg_KL10,function Trig_KL10_Actions)
endfunction
function Trig_KL11_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_KL11_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h014_0051,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_KL11 takes nothing returns nothing
set gg_trg_KL11=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_KL11,gg_unit_h014_0051,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_KL11,Condition(function Trig_KL11_Conditions))
call TriggerAddAction(gg_trg_KL11,function Trig_KL11_Actions)
endfunction
function Trig_KL12_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_KL12_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h00Z_0046,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_KL12 takes nothing returns nothing
set gg_trg_KL12=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_KL12,gg_unit_h00Z_0046,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_KL12,Condition(function Trig_KL12_Conditions))
call TriggerAddAction(gg_trg_KL12,function Trig_KL12_Actions)
endfunction
function Trig_KL13_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_KL13_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h00Y_0045,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_KL13 takes nothing returns nothing
set gg_trg_KL13=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_KL13,gg_unit_h00Y_0045,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_KL13,Condition(function Trig_KL13_Conditions))
call TriggerAddAction(gg_trg_KL13,function Trig_KL13_Actions)
endfunction
function Trig_KL14_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_KL14_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h046_0405,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_KL14 takes nothing returns nothing
set gg_trg_KL14=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_KL14,gg_unit_h046_0405,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_KL14,Condition(function Trig_KL14_Conditions))
call TriggerAddAction(gg_trg_KL14,function Trig_KL14_Actions)
endfunction
function Trig_PA1_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_PA1_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h015_0052,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_PA1 takes nothing returns nothing
set gg_trg_PA1=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_PA1,gg_unit_h015_0052,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_PA1,Condition(function Trig_PA1_Conditions))
call TriggerAddAction(gg_trg_PA1,function Trig_PA1_Actions)
endfunction
function Trig_PA2_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_PA2_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h016_0053,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_PA2 takes nothing returns nothing
set gg_trg_PA2=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_PA2,gg_unit_h016_0053,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_PA2,Condition(function Trig_PA2_Conditions))
call TriggerAddAction(gg_trg_PA2,function Trig_PA2_Actions)
endfunction
function Trig_PA3_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_PA3_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h017_0054,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_PA3 takes nothing returns nothing
set gg_trg_PA3=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_PA3,gg_unit_h017_0054,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_PA3,Condition(function Trig_PA3_Conditions))
call TriggerAddAction(gg_trg_PA3,function Trig_PA3_Actions)
endfunction
function Trig_PA4_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_PA4_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h018_0055,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_PA4 takes nothing returns nothing
set gg_trg_PA4=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_PA4,gg_unit_h018_0055,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_PA4,Condition(function Trig_PA4_Conditions))
call TriggerAddAction(gg_trg_PA4,function Trig_PA4_Actions)
endfunction
function Trig_PA5_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_PA5_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h088_0545,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_PA5 takes nothing returns nothing
set gg_trg_PA5=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_PA5,gg_unit_h088_0545,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_PA5,Condition(function Trig_PA5_Conditions))
call TriggerAddAction(gg_trg_PA5,function Trig_PA5_Actions)
endfunction
function Trig_BI1_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_BI1_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h01K_0057,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_BI1 takes nothing returns nothing
set gg_trg_BI1=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_BI1,gg_unit_h01K_0057,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_BI1,Condition(function Trig_BI1_Conditions))
call TriggerAddAction(gg_trg_BI1,function Trig_BI1_Actions)
endfunction
function Trig_BI2_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_BI2_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h01C_0059,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_BI2 takes nothing returns nothing
set gg_trg_BI2=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_BI2,gg_unit_h01C_0059,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_BI2,Condition(function Trig_BI2_Conditions))
call TriggerAddAction(gg_trg_BI2,function Trig_BI2_Actions)
endfunction
function Trig_BI3_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_BI3_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h019_0056,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_BI3 takes nothing returns nothing
set gg_trg_BI3=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_BI3,gg_unit_h019_0056,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_BI3,Condition(function Trig_BI3_Conditions))
call TriggerAddAction(gg_trg_BI3,function Trig_BI3_Actions)
endfunction
function Trig_BI4_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_BI4_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h01B_0058,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_BI4 takes nothing returns nothing
set gg_trg_BI4=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_BI4,gg_unit_h01B_0058,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_BI4,Condition(function Trig_BI4_Conditions))
call TriggerAddAction(gg_trg_BI4,function Trig_BI4_Actions)
endfunction
function Trig_BI5_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_BI5_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h01A_0060,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_BI5 takes nothing returns nothing
set gg_trg_BI5=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_BI5,gg_unit_h01A_0060,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_BI5,Condition(function Trig_BI5_Conditions))
call TriggerAddAction(gg_trg_BI5,function Trig_BI5_Actions)
endfunction
function Trig_Bl6_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_Bl6_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h07N_0415,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_Bl6 takes nothing returns nothing
set gg_trg_Bl6=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_Bl6,gg_unit_h07N_0415,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_Bl6,Condition(function Trig_Bl6_Conditions))
call TriggerAddAction(gg_trg_Bl6,function Trig_Bl6_Actions)
endfunction
function Trig_BI7_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_BI7_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h07O_0416,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_BI7 takes nothing returns nothing
set gg_trg_BI7=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_BI7,gg_unit_h07O_0416,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_BI7,Condition(function Trig_BI7_Conditions))
call TriggerAddAction(gg_trg_BI7,function Trig_BI7_Actions)
endfunction
function Trig_BI8_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_BI8_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h07R_0791,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_BI8 takes nothing returns nothing
set gg_trg_BI8=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_BI8,gg_unit_h07R_0791,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_BI8,Condition(function Trig_BI8_Conditions))
call TriggerAddAction(gg_trg_BI8,function Trig_BI8_Actions)
endfunction
function Trig_BI9_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_BI9_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h07Q_0422,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_BI9 takes nothing returns nothing
set gg_trg_BI9=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_BI9,gg_unit_h07Q_0422,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_BI9,Condition(function Trig_BI9_Conditions))
call TriggerAddAction(gg_trg_BI9,function Trig_BI9_Actions)
endfunction
function Trig_BI10_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_BI10_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h07S_0202,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_BI10 takes nothing returns nothing
set gg_trg_BI10=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_BI10,gg_unit_h07S_0202,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_BI10,Condition(function Trig_BI10_Conditions))
call TriggerAddAction(gg_trg_BI10,function Trig_BI10_Actions)
endfunction
function Trig_EK1_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_EK1_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h001_0011,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_EK1 takes nothing returns nothing
set gg_trg_EK1=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_EK1,gg_unit_h001_0011,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_EK1,Condition(function Trig_EK1_Conditions))
call TriggerAddAction(gg_trg_EK1,function Trig_EK1_Actions)
endfunction
function Trig_EK2_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_EK2_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h004_0023,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_EK2 takes nothing returns nothing
set gg_trg_EK2=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_EK2,gg_unit_h004_0023,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_EK2,Condition(function Trig_EK2_Conditions))
call TriggerAddAction(gg_trg_EK2,function Trig_EK2_Actions)
endfunction
function Trig_EK3_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_EK3_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h003_0022,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_EK3 takes nothing returns nothing
set gg_trg_EK3=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_EK3,gg_unit_h003_0022,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_EK3,Condition(function Trig_EK3_Conditions))
call TriggerAddAction(gg_trg_EK3,function Trig_EK3_Actions)
endfunction
function Trig_EK4_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_EK4_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h002_0018,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_EK4 takes nothing returns nothing
set gg_trg_EK4=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_EK4,gg_unit_h002_0018,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_EK4,Condition(function Trig_EK4_Conditions))
call TriggerAddAction(gg_trg_EK4,function Trig_EK4_Actions)
endfunction
function Trig_EK5_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_EK5_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h005_0024,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_EK5 takes nothing returns nothing
set gg_trg_EK5=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_EK5,gg_unit_h005_0024,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_EK5,Condition(function Trig_EK5_Conditions))
call TriggerAddAction(gg_trg_EK5,function Trig_EK5_Actions)
endfunction
function Trig_EK6_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_EK6_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h006_0025,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_EK6 takes nothing returns nothing
set gg_trg_EK6=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_EK6,gg_unit_h006_0025,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_EK6,Condition(function Trig_EK6_Conditions))
call TriggerAddAction(gg_trg_EK6,function Trig_EK6_Actions)
endfunction
function Trig_EK7_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_EK7_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h007_0026,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_EK7 takes nothing returns nothing
set gg_trg_EK7=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_EK7,gg_unit_h007_0026,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_EK7,Condition(function Trig_EK7_Conditions))
call TriggerAddAction(gg_trg_EK7,function Trig_EK7_Actions)
endfunction
function Trig_EK8_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_EK8_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h008_0027,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_EK8 takes nothing returns nothing
set gg_trg_EK8=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_EK8,gg_unit_h008_0027,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_EK8,Condition(function Trig_EK8_Conditions))
call TriggerAddAction(gg_trg_EK8,function Trig_EK8_Actions)
endfunction
function Trig_EK9_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_EK9_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h00B_0013,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_EK9 takes nothing returns nothing
set gg_trg_EK9=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_EK9,gg_unit_h00B_0013,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_EK9,Condition(function Trig_EK9_Conditions))
call TriggerAddAction(gg_trg_EK9,function Trig_EK9_Actions)
endfunction
function Trig_EK10_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_EK10_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h009_0029,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_EK10 takes nothing returns nothing
set gg_trg_EK10=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_EK10,gg_unit_h009_0029,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_EK10,Condition(function Trig_EK10_Conditions))
call TriggerAddAction(gg_trg_EK10,function Trig_EK10_Actions)
endfunction
function Trig_EK11_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_EK11_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h00A_0028,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_EK11 takes nothing returns nothing
set gg_trg_EK11=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_EK11,gg_unit_h00A_0028,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_EK11,Condition(function Trig_EK11_Conditions))
call TriggerAddAction(gg_trg_EK11,function Trig_EK11_Actions)
endfunction
function Trig_EK12_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_EK12_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h00E_0016,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_EK12 takes nothing returns nothing
set gg_trg_EK12=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_EK12,gg_unit_h00E_0016,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_EK12,Condition(function Trig_EK12_Conditions))
call TriggerAddAction(gg_trg_EK12,function Trig_EK12_Actions)
endfunction
function Trig_EK13_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_EK13_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h00C_0014,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_EK13 takes nothing returns nothing
set gg_trg_EK13=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_EK13,gg_unit_h00C_0014,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_EK13,Condition(function Trig_EK13_Conditions))
call TriggerAddAction(gg_trg_EK13,function Trig_EK13_Actions)
endfunction
function Trig_EK14_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_EK14_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h00D_0015,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_EK14 takes nothing returns nothing
set gg_trg_EK14=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_EK14,gg_unit_h00D_0015,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_EK14,Condition(function Trig_EK14_Conditions))
call TriggerAddAction(gg_trg_EK14,function Trig_EK14_Actions)
endfunction
function Trig_EK15_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_EK15_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h00F_0017,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_EK15 takes nothing returns nothing
set gg_trg_EK15=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_EK15,gg_unit_h00F_0017,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_EK15,Condition(function Trig_EK15_Conditions))
call TriggerAddAction(gg_trg_EK15,function Trig_EK15_Actions)
endfunction
function Trig_EK16_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_EK16_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h00G_0019,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_EK16 takes nothing returns nothing
set gg_trg_EK16=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_EK16,gg_unit_h00G_0019,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_EK16,Condition(function Trig_EK16_Conditions))
call TriggerAddAction(gg_trg_EK16,function Trig_EK16_Actions)
endfunction
function Trig_EK17_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_EK17_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h00J_0030,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_EK17 takes nothing returns nothing
set gg_trg_EK17=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_EK17,gg_unit_h00J_0030,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_EK17,Condition(function Trig_EK17_Conditions))
call TriggerAddAction(gg_trg_EK17,function Trig_EK17_Actions)
endfunction
function Trig_EK18_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_EK18_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h00H_0020,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_EK18 takes nothing returns nothing
set gg_trg_EK18=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_EK18,gg_unit_h00H_0020,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_EK18,Condition(function Trig_EK18_Conditions))
call TriggerAddAction(gg_trg_EK18,function Trig_EK18_Actions)
endfunction
function Trig_EK19_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_EK19_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h00I_0021,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_EK19 takes nothing returns nothing
set gg_trg_EK19=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_EK19,gg_unit_h00I_0021,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_EK19,Condition(function Trig_EK19_Conditions))
call TriggerAddAction(gg_trg_EK19,function Trig_EK19_Actions)
endfunction
function Trig_EK20_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_EK20_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h05M_0632,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_EK20 takes nothing returns nothing
set gg_trg_EK20=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_EK20,gg_unit_h05M_0632,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_EK20,Condition(function Trig_EK20_Conditions))
call TriggerAddAction(gg_trg_EK20,function Trig_EK20_Actions)
endfunction
function Trig_EK21_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_EK21_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h078_0695,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_EK21 takes nothing returns nothing
set gg_trg_EK21=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_EK21,gg_unit_h078_0695,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_EK21,Condition(function Trig_EK21_Conditions))
call TriggerAddAction(gg_trg_EK21,function Trig_EK21_Actions)
endfunction
function Trig_EK22_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_EK22_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h07F_0793,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_EK22 takes nothing returns nothing
set gg_trg_EK22=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_EK22,gg_unit_h07F_0793,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_EK22,Condition(function Trig_EK22_Conditions))
call TriggerAddAction(gg_trg_EK22,function Trig_EK22_Actions)
endfunction
function Trig_OUT1_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_OUT1_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h01E_0010,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_OUT1 takes nothing returns nothing
set gg_trg_OUT1=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_OUT1,gg_unit_h01E_0010,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_OUT1,Condition(function Trig_OUT1_Conditions))
call TriggerAddAction(gg_trg_OUT1,function Trig_OUT1_Actions)
endfunction
function Trig_OUT2_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_OUT2_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h01F_0062,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_OUT2 takes nothing returns nothing
set gg_trg_OUT2=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_OUT2,gg_unit_h01F_0062,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_OUT2,Condition(function Trig_OUT2_Conditions))
call TriggerAddAction(gg_trg_OUT2,function Trig_OUT2_Actions)
endfunction
function Trig_OUT3_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_OUT3_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h01J_0068,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_OUT3 takes nothing returns nothing
set gg_trg_OUT3=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_OUT3,gg_unit_h01J_0068,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_OUT3,Condition(function Trig_OUT3_Conditions))
call TriggerAddAction(gg_trg_OUT3,function Trig_OUT3_Actions)
endfunction
function Trig_OUT4_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_OUT4_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h01I_0067,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_OUT4 takes nothing returns nothing
set gg_trg_OUT4=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_OUT4,gg_unit_h01I_0067,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_OUT4,Condition(function Trig_OUT4_Conditions))
call TriggerAddAction(gg_trg_OUT4,function Trig_OUT4_Actions)
endfunction
function Trig_OUT5_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_OUT5_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h01G_0064,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_OUT5 takes nothing returns nothing
set gg_trg_OUT5=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_OUT5,gg_unit_h01G_0064,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_OUT5,Condition(function Trig_OUT5_Conditions))
call TriggerAddAction(gg_trg_OUT5,function Trig_OUT5_Actions)
endfunction
function Trig_OUT6_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_OUT6_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h01N_0065,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_OUT6 takes nothing returns nothing
set gg_trg_OUT6=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_OUT6,gg_unit_h01N_0065,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_OUT6,Condition(function Trig_OUT6_Conditions))
call TriggerAddAction(gg_trg_OUT6,function Trig_OUT6_Actions)
endfunction
function Trig_OUT7_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_OUT7_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h01H_0066,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_OUT7 takes nothing returns nothing
set gg_trg_OUT7=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_OUT7,gg_unit_h01H_0066,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_OUT7,Condition(function Trig_OUT7_Conditions))
call TriggerAddAction(gg_trg_OUT7,function Trig_OUT7_Actions)
endfunction
function Trig_ZN1_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_ZN1_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h01D_0061,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_ZN1 takes nothing returns nothing
set gg_trg_ZN1=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_ZN1,gg_unit_h01D_0061,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_ZN1,Condition(function Trig_ZN1_Conditions))
call TriggerAddAction(gg_trg_ZN1,function Trig_ZN1_Actions)
endfunction
function Trig_VE1_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_VE1_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h052_0627,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_VE1 takes nothing returns nothing
set gg_trg_VE1=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_VE1,gg_unit_h052_0627,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_VE1,Condition(function Trig_VE1_Conditions))
call TriggerAddAction(gg_trg_VE1,function Trig_VE1_Actions)
endfunction
function Trig_KT_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<3000.)
endfunction
function Trig_KT_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h053_0628,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_KT takes nothing returns nothing
set gg_trg_KT=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_KT,gg_unit_h053_0628,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_KT,Condition(function Trig_KT_Conditions))
call TriggerAddAction(gg_trg_KT,function Trig_KT_Actions)
endfunction
function Trig_Managorn1_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<2500.)
endfunction
function Trig_Managorn1_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h07P_0417,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_Managorn1 takes nothing returns nothing
set gg_trg_Managorn1=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_Managorn1,gg_unit_h07P_0417,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_Managorn1,Condition(function Trig_Managorn1_Conditions))
call TriggerAddAction(gg_trg_Managorn1,function Trig_Managorn1_Actions)
endfunction
function Trig_Managorn2_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<2500.)
endfunction
function Trig_Managorn2_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h07P_0419,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_Managorn2 takes nothing returns nothing
set gg_trg_Managorn2=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_Managorn2,gg_unit_h07P_0419,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_Managorn2,Condition(function Trig_Managorn2_Conditions))
call TriggerAddAction(gg_trg_Managorn2,function Trig_Managorn2_Actions)
endfunction
function Trig_Managorn3_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<2500.)
endfunction
function Trig_Managorn3_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h07P_0418,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_Managorn3 takes nothing returns nothing
set gg_trg_Managorn3=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_Managorn3,gg_unit_h07P_0418,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_Managorn3,Condition(function Trig_Managorn3_Conditions))
call TriggerAddAction(gg_trg_Managorn3,function Trig_Managorn3_Actions)
endfunction
function Trig_Managorn4_Conditions takes nothing returns boolean
return(GetUnitStateSwap(UNIT_STATE_LIFE,GetTriggerUnit())<2500.)
endfunction
function Trig_Managorn4_Actions takes nothing returns nothing
call SetUnitOwner(gg_unit_h07P_0420,GetOwningPlayer(GetAttacker()),true)
call SetUnitLifePercentBJ(GetTriggerUnit(),'d')
endfunction
function InitTrig_Managorn4 takes nothing returns nothing
set gg_trg_Managorn4=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_Managorn4,gg_unit_h07P_0420,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_Managorn4,Condition(function Trig_Managorn4_Conditions))
call TriggerAddAction(gg_trg_Managorn4,function Trig_Managorn4_Actions)
endfunction
function Trig_Production_en_chaine_Conditions takes nothing returns boolean
return(UnitHasBuffBJ(GetTriggerUnit(),'B000'))
endfunction
function Trig_Production_en_chaine_Func002C takes nothing returns boolean
return(UnitHasBuffBJ(GetTriggerUnit(),'B000'))
endfunction
function Trig_Production_en_chaine_Actions takes nothing returns nothing
call TriggerSleepAction(.1)
if(Trig_Production_en_chaine_Func002C())then
call IssueImmediateOrderById(GetTriggerUnit(),GetUnitTypeId(GetTrainedUnit()))
endif
endfunction
function InitTrig_Production_en_chaine takes nothing returns nothing
set gg_trg_Production_en_chaine=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Production_en_chaine,EVENT_PLAYER_UNIT_TRAIN_FINISH)
call TriggerAddCondition(gg_trg_Production_en_chaine,Condition(function Trig_Production_en_chaine_Conditions))
call TriggerAddAction(gg_trg_Production_en_chaine,function Trig_Production_en_chaine_Actions)
endfunction
function Trig_Camera_command_Actions takes nothing returns nothing
set udg_wawt=S2R(SubStringBJ(GetEventPlayerChatString(),6,9))
call SetCameraFieldForPlayer(GetTriggerPlayer(),CAMERA_FIELD_TARGET_DISTANCE,udg_wawt,1.)
endfunction
function InitTrig_Camera_command takes nothing returns nothing
set gg_trg_Camera_command=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Camera_command,Player(0),"-cam",false)
call TriggerRegisterPlayerChatEvent(gg_trg_Camera_command,Player(1),"-cam",false)
call TriggerRegisterPlayerChatEvent(gg_trg_Camera_command,Player(2),"-cam",false)
call TriggerRegisterPlayerChatEvent(gg_trg_Camera_command,Player(3),"-cam",false)
call TriggerRegisterPlayerChatEvent(gg_trg_Camera_command,Player(4),"-cam",false)
call TriggerRegisterPlayerChatEvent(gg_trg_Camera_command,Player(5),"-cam",false)
call TriggerRegisterPlayerChatEvent(gg_trg_Camera_command,Player(6),"-cam",false)
call TriggerRegisterPlayerChatEvent(gg_trg_Camera_command,Player(7),"-cam",false)
call TriggerRegisterPlayerChatEvent(gg_trg_Camera_command,Player(8),"-cam",false)
call TriggerRegisterPlayerChatEvent(gg_trg_Camera_command,Player(9),"-cam",false)
call TriggerRegisterPlayerChatEvent(gg_trg_Camera_command,Player($A),"-cam",false)
call TriggerRegisterPlayerChatEvent(gg_trg_Camera_command,Player($B),"-cam",false)
call TriggerAddAction(gg_trg_Camera_command,function Trig_Camera_command_Actions)
endfunction
function Trig_Name_command_Conditions takes nothing returns boolean
return(SubStringBJ(GetEventPlayerChatString(),1,6)=="-name ")
endfunction
function Trig_Name_command_Actions takes nothing returns nothing
call SetPlayerName(GetTriggerPlayer(),SubStringBJ(GetEventPlayerChatString(),7,47))
endfunction
function InitTrig_Name_command takes nothing returns nothing
set gg_trg_Name_command=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Name_command,Player(0),"-name ",false)
call TriggerRegisterPlayerChatEvent(gg_trg_Name_command,Player(1),"-name ",false)
call TriggerRegisterPlayerChatEvent(gg_trg_Name_command,Player(2),"-name ",false)
call TriggerRegisterPlayerChatEvent(gg_trg_Name_command,Player(3),"-name ",false)
call TriggerRegisterPlayerChatEvent(gg_trg_Name_command,Player(4),"-name ",false)
call TriggerRegisterPlayerChatEvent(gg_trg_Name_command,Player(5),"-name ",false)
call TriggerRegisterPlayerChatEvent(gg_trg_Name_command,Player(6),"-name ",false)
call TriggerRegisterPlayerChatEvent(gg_trg_Name_command,Player(7),"-name ",false)
call TriggerRegisterPlayerChatEvent(gg_trg_Name_command,Player(8),"-name ",false)
call TriggerRegisterPlayerChatEvent(gg_trg_Name_command,Player(9),"-name ",false)
call TriggerRegisterPlayerChatEvent(gg_trg_Name_command,Player($A),"-name ",false)
call TriggerRegisterPlayerChatEvent(gg_trg_Name_command,Player($B),"-name ",false)
call TriggerAddCondition(gg_trg_Name_command,Condition(function Trig_Name_command_Conditions))
call TriggerAddAction(gg_trg_Name_command,function Trig_Name_command_Actions)
endfunction
function Trig_Red_color_Actions takes nothing returns nothing
call SetPlayerColorBJ(GetTriggerPlayer(),PLAYER_COLOR_RED,true)
endfunction
function InitTrig_Red_color takes nothing returns nothing
set gg_trg_Red_color=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Red_color,Player(0),"-цвет красный",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Red_color,Player(1),"-цвет красный",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Red_color,Player(2),"-цвет красный",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Red_color,Player(3),"-цвет красный",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Red_color,Player(4),"-цвет красный",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Red_color,Player(5),"-цвет красный",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Red_color,Player(6),"-цвет красный",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Red_color,Player(7),"-цвет красный",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Red_color,Player(8),"-цвет красный",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Red_color,Player(9),"-цвет красный",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Red_color,Player($A),"-цвет красный",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Red_color,Player($B),"-цвет красный",true)
call TriggerAddAction(gg_trg_Red_color,function Trig_Red_color_Actions)
endfunction
function Trig_Blue_color_Actions takes nothing returns nothing
call SetPlayerColorBJ(GetTriggerPlayer(),PLAYER_COLOR_BLUE,true)
endfunction
function InitTrig_Blue_color takes nothing returns nothing
set gg_trg_Blue_color=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Blue_color,Player(0),"-цвет синий",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Blue_color,Player(1),"-цвет синий",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Blue_color,Player(2),"-цвет синий",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Blue_color,Player(3),"-цвет синий",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Blue_color,Player(4),"-цвет синий",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Blue_color,Player(5),"-цвет синий",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Blue_color,Player(6),"-цвет синий",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Blue_color,Player(7),"-цвет синий",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Blue_color,Player(8),"-цвет синий",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Blue_color,Player(9),"-цвет синий",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Blue_color,Player($A),"-цвет синий",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Blue_color,Player($B),"-цвет синий",true)
call TriggerAddAction(gg_trg_Blue_color,function Trig_Blue_color_Actions)
endfunction
function Trig_Lightblue_color_Actions takes nothing returns nothing
call SetPlayerColorBJ(GetTriggerPlayer(),PLAYER_COLOR_CYAN,true)
endfunction
function InitTrig_Lightblue_color takes nothing returns nothing
set gg_trg_Lightblue_color=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Lightblue_color,Player(0),"-цвет сине-зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Lightblue_color,Player(1),"-цвет сине-зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Lightblue_color,Player(2),"-цвет сине-зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Lightblue_color,Player(3),"-цвет сине-зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Lightblue_color,Player(4),"-цвет сине-зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Lightblue_color,Player(5),"-цвет сине-зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Lightblue_color,Player(6),"-цвет сине-зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Lightblue_color,Player(7),"-цвет сине-зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Lightblue_color,Player(8),"-цвет сине-зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Lightblue_color,Player(9),"-цвет сине-зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Lightblue_color,Player($A),"-цвет сине-зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Lightblue_color,Player($B),"-цвет сине-зеленый",true)
call TriggerAddAction(gg_trg_Lightblue_color,function Trig_Lightblue_color_Actions)
endfunction
function Trig_Viol_color_Actions takes nothing returns nothing
call SetPlayerColorBJ(GetTriggerPlayer(),PLAYER_COLOR_PURPLE,true)
endfunction
function InitTrig_Viol_color takes nothing returns nothing
set gg_trg_Viol_color=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Viol_color,Player(0),"-цвет фиолетовый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Viol_color,Player(1),"-цвет фиолетовый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Viol_color,Player(2),"-цвет фиолетовый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Viol_color,Player(3),"-цвет фиолетовый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Viol_color,Player(4),"-цвет фиолетовый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Viol_color,Player(5),"-цвет фиолетовый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Viol_color,Player(6),"-цвет фиолетовый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Viol_color,Player(7),"-цвет фиолетовый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Viol_color,Player(8),"-цвет фиолетовый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Viol_color,Player(9),"-цвет фиолетовый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Viol_color,Player($A),"-цвет фиолетовый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Viol_color,Player($B),"-цвет фиолетовый",true)
call TriggerAddAction(gg_trg_Viol_color,function Trig_Viol_color_Actions)
endfunction
function Trig_Yelow_color_Actions takes nothing returns nothing
call SetPlayerColorBJ(GetTriggerPlayer(),PLAYER_COLOR_YELLOW,true)
endfunction
function InitTrig_Yelow_color takes nothing returns nothing
set gg_trg_Yelow_color=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Yelow_color,Player(0),"-цвет желтый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Yelow_color,Player(1),"-цвет желтый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Yelow_color,Player(2),"-цвет желтый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Yelow_color,Player(3),"-цвет желтый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Yelow_color,Player(4),"-цвет желтый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Yelow_color,Player(5),"-цвет желтый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Yelow_color,Player(6),"-цвет желтый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Yelow_color,Player(7),"-цвет желтый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Yelow_color,Player(8),"-цвет желтый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Yelow_color,Player(9),"-цвет желтый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Yelow_color,Player($A),"-цвет желтый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Yelow_color,Player($B),"-цвет желтый",true)
call TriggerAddAction(gg_trg_Yelow_color,function Trig_Yelow_color_Actions)
endfunction
function Trig_Orange_color_Actions takes nothing returns nothing
call SetPlayerColorBJ(GetTriggerPlayer(),PLAYER_COLOR_ORANGE,true)
endfunction
function InitTrig_Orange_color takes nothing returns nothing
set gg_trg_Orange_color=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Orange_color,Player(0),"-цвет оранжевый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Orange_color,Player(1),"-цвет оранжевый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Orange_color,Player(2),"-цвет оранжевый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Orange_color,Player(3),"-цвет оранжевый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Orange_color,Player(4),"-цвет оранжевый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Orange_color,Player(5),"-цвет оранжевый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Orange_color,Player(6),"-цвет оранжевый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Orange_color,Player(7),"-цвет оранжевый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Orange_color,Player(8),"-цвет оранжевый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Orange_color,Player(9),"-цвет оранжевый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Orange_color,Player($A),"-цвет оранжевый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Orange_color,Player($B),"-цвет оранжевый",true)
call TriggerAddAction(gg_trg_Orange_color,function Trig_Orange_color_Actions)
endfunction
function Trig_Green_color_Actions takes nothing returns nothing
call SetPlayerColorBJ(GetTriggerPlayer(),PLAYER_COLOR_GREEN,true)
endfunction
function InitTrig_Green_color takes nothing returns nothing
set gg_trg_Green_color=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Green_color,Player(0),"-цвет зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Green_color,Player(1),"-цвет зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Green_color,Player(2),"-цвет зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Green_color,Player(3),"-цвет зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Green_color,Player(4),"-цвет зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Green_color,Player(5),"-цвет зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Green_color,Player(6),"-цвет зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Green_color,Player(7),"-цвет зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Green_color,Player(8),"-цвет зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Green_color,Player(9),"-цвет зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Green_color,Player($A),"-цвет зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Green_color,Player($B),"-цвет зеленый",true)
call TriggerAddAction(gg_trg_Green_color,function Trig_Green_color_Actions)
endfunction
function Trig_Rose_color_Actions takes nothing returns nothing
call SetPlayerColorBJ(GetTriggerPlayer(),PLAYER_COLOR_PINK,true)
endfunction
function InitTrig_Rose_color takes nothing returns nothing
set gg_trg_Rose_color=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Rose_color,Player(0),"-цвет розовый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Rose_color,Player(1),"-цвет розовый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Rose_color,Player(2),"-цвет розовый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Rose_color,Player(3),"-цвет розовый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Rose_color,Player(4),"-цвет розовый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Rose_color,Player(5),"-цвет розовый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Rose_color,Player(6),"-цвет розовый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Rose_color,Player(7),"-цвет розовый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Rose_color,Player(8),"-цвет розовый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Rose_color,Player(9),"-цвет розовый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Rose_color,Player($A),"-цвет розовый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Rose_color,Player($B),"-цвет розовый",true)
call TriggerAddAction(gg_trg_Rose_color,function Trig_Rose_color_Actions)
endfunction
function Trig_Grey_color_Actions takes nothing returns nothing
call SetPlayerColorBJ(GetTriggerPlayer(),PLAYER_COLOR_LIGHT_GRAY,true)
endfunction
function InitTrig_Grey_color takes nothing returns nothing
set gg_trg_Grey_color=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Grey_color,Player(0),"-цвет серый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Grey_color,Player(1),"-цвет серый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Grey_color,Player(2),"-цвет серый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Grey_color,Player(3),"-цвет серый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Grey_color,Player(4),"-цвет серый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Grey_color,Player(5),"-цвет серый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Grey_color,Player(6),"-цвет серый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Grey_color,Player(7),"-цвет серый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Grey_color,Player(8),"-цвет серый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Grey_color,Player(9),"-цвет серый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Grey_color,Player($A),"-цвет серый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Grey_color,Player($B),"-цвет серый",true)
call TriggerAddAction(gg_trg_Grey_color,function Trig_Grey_color_Actions)
endfunction
function Trig_Cyan_color_Actions takes nothing returns nothing
call SetPlayerColorBJ(GetTriggerPlayer(),PLAYER_COLOR_LIGHT_BLUE,true)
endfunction
function InitTrig_Cyan_color takes nothing returns nothing
set gg_trg_Cyan_color=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Cyan_color,Player(0),"-цвет светло-синий",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Cyan_color,Player(1),"-цвет светло-синий",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Cyan_color,Player(2),"-цвет светло-синий",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Cyan_color,Player(3),"-цвет светло-синий",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Cyan_color,Player(4),"-цвет светло-синий",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Cyan_color,Player(5),"-цвет светло-синий",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Cyan_color,Player(6),"-цвет светло-синий",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Cyan_color,Player(7),"-цвет светло-синий",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Cyan_color,Player(8),"-цвет светло-синий",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Cyan_color,Player(9),"-цвет светло-синий",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Cyan_color,Player($A),"-цвет светло-синий",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Cyan_color,Player($B),"-цвет светло-синий",true)
call TriggerAddAction(gg_trg_Cyan_color,function Trig_Cyan_color_Actions)
endfunction
function Trig_Dark_green_color_Actions takes nothing returns nothing
call SetPlayerColorBJ(GetTriggerPlayer(),PLAYER_COLOR_AQUA,true)
endfunction
function InitTrig_Dark_green_color takes nothing returns nothing
set gg_trg_Dark_green_color=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Dark_green_color,Player(0),"-цвет темно-зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Dark_green_color,Player(1),"-цвет темно-зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Dark_green_color,Player(2),"-цвет темно-зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Dark_green_color,Player(3),"-цвет темно-зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Dark_green_color,Player(4),"-цвет темно-зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Dark_green_color,Player(5),"-цвет темно-зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Dark_green_color,Player(6),"-цвет темно-зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Dark_green_color,Player(7),"-цвет темно-зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Dark_green_color,Player(8),"-цвет темно-зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Dark_green_color,Player(9),"-цвет темно-зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Dark_green_color,Player($A),"-цвет темно-зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Dark_green_color,Player($B),"-цвет темно-зеленый",true)
call TriggerAddAction(gg_trg_Dark_green_color,function Trig_Dark_green_color_Actions)
endfunction
function Trig_Brown_color_Actions takes nothing returns nothing
call SetPlayerColorBJ(GetTriggerPlayer(),PLAYER_COLOR_BROWN,true)
endfunction
function InitTrig_Brown_color takes nothing returns nothing
set gg_trg_Brown_color=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Brown_color,Player(0),"-цвет коричневый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Brown_color,Player(1),"-цвет коричневый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Brown_color,Player(2),"-цвет коричневый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Brown_color,Player(3),"-цвет коричневый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Brown_color,Player(4),"-цвет коричневый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Brown_color,Player(5),"-цвет коричневый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Brown_color,Player(6),"-цвет коричневый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Brown_color,Player(7),"-цвет коричневый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Brown_color,Player(8),"-цвет коричневый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Brown_color,Player(9),"-цвет коричневый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Brown_color,Player($A),"-цвет коричневый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Brown_color,Player($B),"-цвет коричневый",true)
call TriggerAddAction(gg_trg_Brown_color,function Trig_Brown_color_Actions)
endfunction
function Trig_Black_color_Actions takes nothing returns nothing
call SetPlayerColorBJ(GetTriggerPlayer(),ConvertPlayerColor($C),true)
endfunction
function InitTrig_Black_color takes nothing returns nothing
set gg_trg_Black_color=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Black_color,Player(0),"-цвет черный",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Black_color,Player(1),"-цвет черный",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Black_color,Player(2),"-цвет черный",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Black_color,Player(3),"-цвет черный",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Black_color,Player(4),"-цвет черный",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Black_color,Player(5),"-цвет черный",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Black_color,Player(6),"-цвет черный",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Black_color,Player(7),"-цвет черный",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Black_color,Player(8),"-цвет черный",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Black_color,Player(9),"-цвет черный",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Black_color,Player($A),"-цвет черный",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Black_color,Player($B),"-цвет черный",true)
call TriggerAddAction(gg_trg_Black_color,function Trig_Black_color_Actions)
endfunction
function Trig_Turn_On_Actions takes nothing returns nothing
call EnableTrigger(gg_trg_Declare_War_1)
call EnableTrigger(gg_trg_Declare_War_2)
call EnableTrigger(gg_trg_Declare_War_3)
call EnableTrigger(gg_trg_Declare_War_4)
call EnableTrigger(gg_trg_Declare_War_5)
call EnableTrigger(gg_trg_Declare_War_6)
call EnableTrigger(gg_trg_Declare_War_7)
call EnableTrigger(gg_trg_Declare_War_8)
call EnableTrigger(gg_trg_Declare_War_9)
call EnableTrigger(gg_trg_Declare_War_10)
call EnableTrigger(gg_trg_Declare_War_11)
call EnableTrigger(gg_trg_Declare_War_12)
endfunction
function InitTrig_Turn_On takes nothing returns nothing
set gg_trg_Turn_On=CreateTrigger()
call TriggerAddAction(gg_trg_Turn_On,function Trig_Turn_On_Actions)
endfunction
function Trig_Turn_Off_Actions takes nothing returns nothing
call DisableTrigger(gg_trg_Declare_War_1)
call DisableTrigger(gg_trg_Declare_War_2)
call DisableTrigger(gg_trg_Declare_War_3)
call DisableTrigger(gg_trg_Declare_War_4)
call DisableTrigger(gg_trg_Declare_War_5)
call DisableTrigger(gg_trg_Declare_War_6)
call DisableTrigger(gg_trg_Declare_War_7)
call DisableTrigger(gg_trg_Declare_War_8)
call DisableTrigger(gg_trg_Declare_War_9)
call DisableTrigger(gg_trg_Declare_War_10)
call DisableTrigger(gg_trg_Declare_War_11)
call DisableTrigger(gg_trg_Declare_War_12)
endfunction
function InitTrig_Turn_Off takes nothing returns nothing
set gg_trg_Turn_Off=CreateTrigger()
call TriggerAddAction(gg_trg_Turn_Off,function Trig_Turn_Off_Actions)
endfunction
function Trig_Declare_War_1_Func003001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_1_Func003002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_1_Func003002 takes nothing returns nothing
if(Trig_Declare_War_1_Func003002001())then
call DisplayTimedTextToForce(GetForceOfPlayer(GetEnumPlayer()),10.,(GetPlayerName(udg_Instagator)+" |c00FF0000Обьявил вам войну|r !"))
endif
endfunction
function Trig_Declare_War_1_Func004001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_1_Func004002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_1_Func004002 takes nothing returns nothing
if(Trig_Declare_War_1_Func004002001())then
call SetPlayerAllianceStateBJ(GetEnumPlayer(),udg_Instagator,0)
endif
endfunction
function Trig_Declare_War_1_Actions takes nothing returns nothing
call TriggerExecute(gg_trg_Turn_Off)
set udg_Instagator=Player(0)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_1_Func003001001)),function Trig_Declare_War_1_Func003002)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_1_Func004001001)),function Trig_Declare_War_1_Func004002)
call TriggerExecute(gg_trg_Turn_On)
endfunction
function InitTrig_Declare_War_1 takes nothing returns nothing
set gg_trg_Declare_War_1=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_1)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_1,Player(0))
call TriggerAddAction(gg_trg_Declare_War_1,function Trig_Declare_War_1_Actions)
endfunction
function Trig_Declare_War_2_Func004001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_2_Func004002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_2_Func004002 takes nothing returns nothing
if(Trig_Declare_War_2_Func004002001())then
call DisplayTimedTextToForce(GetForceOfPlayer(GetEnumPlayer()),10.,(GetPlayerName(udg_Instagator)+" |c00FF0000Обьявил вам войну|r !"))
endif
endfunction
function Trig_Declare_War_2_Func005001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_2_Func005002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_2_Func005002 takes nothing returns nothing
if(Trig_Declare_War_2_Func005002001())then
call SetPlayerAllianceStateBJ(GetEnumPlayer(),udg_Instagator,0)
endif
endfunction
function Trig_Declare_War_2_Actions takes nothing returns nothing
call TriggerExecute(gg_trg_Turn_Off)
set udg_Instagator=Player(1)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_2_Func004001001)),function Trig_Declare_War_2_Func004002)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_2_Func005001001)),function Trig_Declare_War_2_Func005002)
call TriggerExecute(gg_trg_Turn_On)
endfunction
function InitTrig_Declare_War_2 takes nothing returns nothing
set gg_trg_Declare_War_2=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_2)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_2,Player(1))
call TriggerAddAction(gg_trg_Declare_War_2,function Trig_Declare_War_2_Actions)
endfunction
function Trig_Declare_War_5_Func003001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_5_Func003002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_5_Func003002 takes nothing returns nothing
if(Trig_Declare_War_5_Func003002001())then
call DisplayTimedTextToForce(GetForceOfPlayer(GetEnumPlayer()),10.,(GetPlayerName(udg_Instagator)+"|c00FF0000Обьявил вам войну|r !"))
endif
endfunction
function Trig_Declare_War_5_Func004001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_5_Func004002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_5_Func004002 takes nothing returns nothing
if(Trig_Declare_War_5_Func004002001())then
call SetPlayerAllianceStateBJ(GetEnumPlayer(),udg_Instagator,0)
endif
endfunction
function Trig_Declare_War_5_Actions takes nothing returns nothing
call TriggerExecute(gg_trg_Turn_Off)
set udg_Instagator=Player(4)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_5_Func003001001)),function Trig_Declare_War_5_Func003002)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_5_Func004001001)),function Trig_Declare_War_5_Func004002)
call TriggerExecute(gg_trg_Turn_On)
endfunction
function InitTrig_Declare_War_5 takes nothing returns nothing
set gg_trg_Declare_War_5=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_5)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_5,Player(4))
call TriggerAddAction(gg_trg_Declare_War_5,function Trig_Declare_War_5_Actions)
endfunction
function Trig_Declare_War_3_Func003001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_3_Func003002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_3_Func003002 takes nothing returns nothing
if(Trig_Declare_War_3_Func003002001())then
call DisplayTimedTextToForce(GetForceOfPlayer(GetEnumPlayer()),10.,(GetPlayerName(udg_Instagator)+"|c00FF0000Обьявил вам войну|r !"))
endif
endfunction
function Trig_Declare_War_3_Func004001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_3_Func004002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_3_Func004002 takes nothing returns nothing
if(Trig_Declare_War_3_Func004002001())then
call SetPlayerAllianceStateBJ(GetEnumPlayer(),udg_Instagator,0)
endif
endfunction
function Trig_Declare_War_3_Actions takes nothing returns nothing
call TriggerExecute(gg_trg_Turn_Off)
set udg_Instagator=Player(2)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_3_Func003001001)),function Trig_Declare_War_3_Func003002)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_3_Func004001001)),function Trig_Declare_War_3_Func004002)
call TriggerExecute(gg_trg_Turn_On)
endfunction
function InitTrig_Declare_War_3 takes nothing returns nothing
set gg_trg_Declare_War_3=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_3)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_3,Player(2))
call TriggerAddAction(gg_trg_Declare_War_3,function Trig_Declare_War_3_Actions)
endfunction
function Trig_Declare_War_4_Func003001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_4_Func003002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_4_Func003002 takes nothing returns nothing
if(Trig_Declare_War_4_Func003002001())then
call DisplayTimedTextToForce(GetForceOfPlayer(GetEnumPlayer()),10.,(GetPlayerName(udg_Instagator)+"|c00FF0000Обьявил вам войну|r !"))
endif
endfunction
function Trig_Declare_War_4_Func004001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_4_Func004002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_4_Func004002 takes nothing returns nothing
if(Trig_Declare_War_4_Func004002001())then
call SetPlayerAllianceStateBJ(GetEnumPlayer(),udg_Instagator,0)
endif
endfunction
function Trig_Declare_War_4_Actions takes nothing returns nothing
call TriggerExecute(gg_trg_Turn_Off)
set udg_Instagator=Player(3)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_4_Func003001001)),function Trig_Declare_War_4_Func003002)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_4_Func004001001)),function Trig_Declare_War_4_Func004002)
call TriggerExecute(gg_trg_Turn_On)
endfunction
function InitTrig_Declare_War_4 takes nothing returns nothing
set gg_trg_Declare_War_4=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_4)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_4,Player(3))
call TriggerAddAction(gg_trg_Declare_War_4,function Trig_Declare_War_4_Actions)
endfunction
function Trig_Declare_War_6_Func003001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_6_Func003002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_6_Func003002 takes nothing returns nothing
if(Trig_Declare_War_6_Func003002001())then
call DisplayTimedTextToForce(GetForceOfPlayer(GetEnumPlayer()),10.,(GetPlayerName(udg_Instagator)+"|c00FF0000Обьявил вам войну|r !"))
endif
endfunction
function Trig_Declare_War_6_Func004001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_6_Func004002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_6_Func004002 takes nothing returns nothing
if(Trig_Declare_War_6_Func004002001())then
call SetPlayerAllianceStateBJ(GetEnumPlayer(),udg_Instagator,0)
endif
endfunction
function Trig_Declare_War_6_Actions takes nothing returns nothing
call TriggerExecute(gg_trg_Turn_Off)
set udg_Instagator=Player(5)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_6_Func003001001)),function Trig_Declare_War_6_Func003002)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_6_Func004001001)),function Trig_Declare_War_6_Func004002)
call TriggerExecute(gg_trg_Turn_On)
endfunction
function InitTrig_Declare_War_6 takes nothing returns nothing
set gg_trg_Declare_War_6=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_6)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_6,Player(5))
call TriggerAddAction(gg_trg_Declare_War_6,function Trig_Declare_War_6_Actions)
endfunction
function Trig_Declare_War_7_Func003001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_7_Func003002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_7_Func003002 takes nothing returns nothing
if(Trig_Declare_War_7_Func003002001())then
call DisplayTimedTextToForce(GetForceOfPlayer(GetEnumPlayer()),10.,(GetPlayerName(udg_Instagator)+"|c00FF0000Обьявил вам войну|r !"))
endif
endfunction
function Trig_Declare_War_7_Func004001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_7_Func004002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_7_Func004002 takes nothing returns nothing
if(Trig_Declare_War_7_Func004002001())then
call SetPlayerAllianceStateBJ(GetEnumPlayer(),udg_Instagator,0)
endif
endfunction
function Trig_Declare_War_7_Actions takes nothing returns nothing
call TriggerExecute(gg_trg_Turn_Off)
set udg_Instagator=Player(6)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_7_Func003001001)),function Trig_Declare_War_7_Func003002)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_7_Func004001001)),function Trig_Declare_War_7_Func004002)
call TriggerExecute(gg_trg_Turn_On)
endfunction
function InitTrig_Declare_War_7 takes nothing returns nothing
set gg_trg_Declare_War_7=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_7)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_7,Player(6))
call TriggerAddAction(gg_trg_Declare_War_7,function Trig_Declare_War_7_Actions)
endfunction
function Trig_Declare_War_8_Func003001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_8_Func003002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_8_Func003002 takes nothing returns nothing
if(Trig_Declare_War_8_Func003002001())then
call DisplayTimedTextToForce(GetForceOfPlayer(GetEnumPlayer()),10.,(GetPlayerName(udg_Instagator)+"|c00FF0000Обьявил вам войну|r !"))
endif
endfunction
function Trig_Declare_War_8_Func004001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_8_Func004002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_8_Func004002 takes nothing returns nothing
if(Trig_Declare_War_8_Func004002001())then
call SetPlayerAllianceStateBJ(GetEnumPlayer(),udg_Instagator,0)
endif
endfunction
function Trig_Declare_War_8_Actions takes nothing returns nothing
call TriggerExecute(gg_trg_Turn_Off)
set udg_Instagator=Player(7)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_8_Func003001001)),function Trig_Declare_War_8_Func003002)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_8_Func004001001)),function Trig_Declare_War_8_Func004002)
call TriggerExecute(gg_trg_Turn_On)
endfunction
function InitTrig_Declare_War_8 takes nothing returns nothing
set gg_trg_Declare_War_8=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_8)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_8,Player(7))
call TriggerAddAction(gg_trg_Declare_War_8,function Trig_Declare_War_8_Actions)
endfunction
function Trig_Declare_War_9_Func003001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_9_Func003002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_9_Func003002 takes nothing returns nothing
if(Trig_Declare_War_9_Func003002001())then
call DisplayTimedTextToForce(GetForceOfPlayer(GetEnumPlayer()),10.,(GetPlayerName(udg_Instagator)+"|c00FF0000Обьявил вам войну|r !"))
endif
endfunction
function Trig_Declare_War_9_Func004001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_9_Func004002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_9_Func004002 takes nothing returns nothing
if(Trig_Declare_War_9_Func004002001())then
call SetPlayerAllianceStateBJ(GetEnumPlayer(),udg_Instagator,0)
endif
endfunction
function Trig_Declare_War_9_Actions takes nothing returns nothing
call TriggerExecute(gg_trg_Turn_Off)
set udg_Instagator=Player(8)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_9_Func003001001)),function Trig_Declare_War_9_Func003002)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_9_Func004001001)),function Trig_Declare_War_9_Func004002)
call TriggerExecute(gg_trg_Turn_On)
endfunction
function InitTrig_Declare_War_9 takes nothing returns nothing
set gg_trg_Declare_War_9=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_9)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_9,Player(8))
call TriggerAddAction(gg_trg_Declare_War_9,function Trig_Declare_War_9_Actions)
endfunction
function Trig_Declare_War_10_Func003001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_10_Func003002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_10_Func003002 takes nothing returns nothing
if(Trig_Declare_War_10_Func003002001())then
call DisplayTimedTextToForce(GetForceOfPlayer(GetEnumPlayer()),10.,(GetPlayerName(udg_Instagator)+"|c00FF0000Обьявил вам войну|r !"))
endif
endfunction
function Trig_Declare_War_10_Func004001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_10_Func004002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_10_Func004002 takes nothing returns nothing
if(Trig_Declare_War_10_Func004002001())then
call SetPlayerAllianceStateBJ(GetEnumPlayer(),udg_Instagator,0)
endif
endfunction
function Trig_Declare_War_10_Actions takes nothing returns nothing
call TriggerExecute(gg_trg_Turn_Off)
set udg_Instagator=Player(9)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_10_Func003001001)),function Trig_Declare_War_10_Func003002)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_10_Func004001001)),function Trig_Declare_War_10_Func004002)
call TriggerExecute(gg_trg_Turn_On)
endfunction
function InitTrig_Declare_War_10 takes nothing returns nothing
set gg_trg_Declare_War_10=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_10)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_10,Player(9))
call TriggerAddAction(gg_trg_Declare_War_10,function Trig_Declare_War_10_Actions)
endfunction
function Trig_Declare_War_11_Func003001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_11_Func003002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_11_Func003002 takes nothing returns nothing
if(Trig_Declare_War_11_Func003002001())then
call DisplayTimedTextToForce(GetForceOfPlayer(GetEnumPlayer()),10.,(GetPlayerName(udg_Instagator)+"|c00FF0000Обьявил вам войну|r !"))
endif
endfunction
function Trig_Declare_War_11_Func004001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_11_Func004002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_11_Func004002 takes nothing returns nothing
if(Trig_Declare_War_11_Func004002001())then
call SetPlayerAllianceStateBJ(GetEnumPlayer(),udg_Instagator,0)
endif
endfunction
function Trig_Declare_War_11_Actions takes nothing returns nothing
call TriggerExecute(gg_trg_Turn_Off)
set udg_Instagator=Player($A)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_11_Func003001001)),function Trig_Declare_War_11_Func003002)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_11_Func004001001)),function Trig_Declare_War_11_Func004002)
call TriggerExecute(gg_trg_Turn_On)
endfunction
function InitTrig_Declare_War_11 takes nothing returns nothing
set gg_trg_Declare_War_11=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_11)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_11,Player($A))
call TriggerAddAction(gg_trg_Declare_War_11,function Trig_Declare_War_11_Actions)
endfunction
function Trig_Declare_War_12_Func003001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_12_Func003002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_12_Func003002 takes nothing returns nothing
if(Trig_Declare_War_12_Func003002001())then
call DisplayTimedTextToForce(GetForceOfPlayer(GetEnumPlayer()),10.,(GetPlayerName(udg_Instagator)+"|c00FF0000Обьявил вам войну|r !"))
endif
endfunction
function Trig_Declare_War_12_Func004001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_12_Func004002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_12_Func004002 takes nothing returns nothing
if(Trig_Declare_War_12_Func004002001())then
call SetPlayerAllianceStateBJ(GetEnumPlayer(),udg_Instagator,0)
endif
endfunction
function Trig_Declare_War_12_Actions takes nothing returns nothing
call TriggerExecute(gg_trg_Turn_Off)
set udg_Instagator=Player($B)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_12_Func003001001)),function Trig_Declare_War_12_Func003002)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_12_Func004001001)),function Trig_Declare_War_12_Func004002)
call TriggerExecute(gg_trg_Turn_On)
endfunction
function InitTrig_Declare_War_12 takes nothing returns nothing
set gg_trg_Declare_War_12=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_12)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_12,Player($B))
call TriggerAddAction(gg_trg_Declare_War_12,function Trig_Declare_War_12_Actions)
endfunction
function Trig_Buildings_Func001A takes nothing returns nothing
call SetPlayerTechMaxAllowedSwap('hbar',4,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('harm',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('hars',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('h01O',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('obar',4,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('obea',3,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('osld',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('otto',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('usep',4,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('uslh',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('utod',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('utom',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('eaom',4,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('eaow',3,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('eaoe',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('u006',4,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('u00A',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('u008',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('u00B',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('h021',4,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('h028',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('h024',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('nnsg',4,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('nnsa',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('n010',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('ncaw',4,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('e004',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('h02L',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('u00E',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('u00M',4,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('u00N',3,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('u00Q',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('n023',4,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('n025',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('h02X',3,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('o00M',4,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('o00V',3,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('o011',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('o00N',4,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('o00X',3,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('o012',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('o00O',4,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('o00W',3,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('o013',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('o019',4,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('o01F',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('o01D',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('o01B',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('o01N',4,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('o01T',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('o01S',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('o01Q',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('h03K',4,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('h03Q',3,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('h03N',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('o020',4,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('o023',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('o024',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('o02B',4,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('o02F',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('o02D',3,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('u00Z',4,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('u011',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('u012',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('o02M',4,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('o02Q',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('o02O',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('h04B',4,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('h04E',3,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('h04G',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('h04L',4,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('h04P',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('h04U',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('h04T',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('o031',4,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('o033',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('o030',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('o035',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('h05B',4,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('h05G',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('h05F',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('h05E',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('o03H',4,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('o03K',3,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('o03L',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('o03Q',4,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('o03V',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('o03U',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('o03T',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('o041',4,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('o043',3,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('o044',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('h05U',4,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('h05Y',3,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('n069',3,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('h069',4,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('h06F',3,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('h06C',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('h06L',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('u01E',4,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('u01G',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('u01I',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('u01H',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('h07W',6,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('h07Z',4,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('u020',4,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('h081',3,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('h082',3,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('h08P',4,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('h08R',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('h08Q',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('h08O',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('o04X',4,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('o051',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('o04Z',2,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('o050',2,GetEnumPlayer())
endfunction
function Trig_Buildings_Actions takes nothing returns nothing
call ForForce(bj_FORCE_ALL_PLAYERS,function Trig_Buildings_Func001A)
endfunction
function InitTrig_Buildings takes nothing returns nothing
set gg_trg_Buildings=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Buildings,EVENT_PLAYER_UNIT_CONSTRUCT_START)
call TriggerAddAction(gg_trg_Buildings,function Trig_Buildings_Actions)
endfunction
function Trig_Heroes_Func001A takes nothing returns nothing
call SetPlayerTechMaxAllowedSwap('Ogld',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('U00C',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('U01Q',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('U00D',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('H02J',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('H02H',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('H02I',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('E001',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('Hvsh',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('H072',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('E006',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('H02M',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('H02N',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('U00S',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('U00R',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('N01R',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('H031',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('H032',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('H033',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('H036',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('H039',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('O04D',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('H037',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('H03B',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('O04F',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('H038',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('H03A',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('O04E',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('O01H',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('N031',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('O01G',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('O01U',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('H03D',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('O04G',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('H03X',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('H03Y',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('H073',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('H041',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('O04H',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('O025',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('H043',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('O02G',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('H045',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('U015',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('U016',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('U01R',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('O02S',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('N04J',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('O02T',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('N04V',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('N04W',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('H044',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('H04Y',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('H050',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('H04Z',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('H051',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('Otch',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('O04I',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('H05L',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('O03A',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('N05C',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('N05P',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('N05Q',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('H074',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('O03W',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('H05R',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('O04J',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('H05S',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('O048',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('H075',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('E009',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('H06P',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('O04B',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('H06O',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('H070',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('U01S',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('U01O',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('N07C',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('N07A',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('N07B',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('H087',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('H086',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('H085',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('H08Y',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('H08Z',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('N07X',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('O055',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('N08B',1,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('O056',1,GetEnumPlayer())
endfunction
function Trig_Heroes_Actions takes nothing returns nothing
call ForForce(bj_FORCE_ALL_PLAYERS,function Trig_Heroes_Func001A)
endfunction
function InitTrig_Heroes takes nothing returns nothing
set gg_trg_Heroes=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Heroes,EVENT_PLAYER_UNIT_TRAIN_START)
call TriggerAddAction(gg_trg_Heroes,function Trig_Heroes_Actions)
endfunction
function Trig_Ship_Func001A takes nothing returns nothing
call SetPlayerTechMaxAllowedSwap('hbsh',18,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('ojgn',18,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('uubs',18,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('ebsh',18,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('hdes',36,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('odes',36,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('udes',36,GetEnumPlayer())
call SetPlayerTechMaxAllowedSwap('edes',36,GetEnumPlayer())
endfunction
function Trig_Ship_Actions takes nothing returns nothing
call ForForce(bj_FORCE_ALL_PLAYERS,function Trig_Ship_Func001A)
endfunction
function InitTrig_Ship takes nothing returns nothing
set gg_trg_Ship=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Ship,3.)
call TriggerAddAction(gg_trg_Ship,function Trig_Ship_Actions)
endfunction
function Trig_Select_Actions takes nothing returns nothing
set udg_Total_hero=34
set udg_Random_system[1]='hpea'
set udg_Random_system[2]='opeo'
set udg_Random_system[3]='uaco'
set udg_Random_system[4]='ewsp'
set udg_Random_system[5]='e002'
set udg_Random_system[6]='nmpe'
set udg_Random_system[7]='h03E'
set udg_Random_system[8]='h02O'
set udg_Random_system[9]='h01V'
set udg_Random_system[$A]='o01V'
set udg_Random_system[$B]='o01I'
set udg_Random_system[$C]='o006'
set udg_Random_system[$D]='o004'
set udg_Random_system[$E]='o026'
set udg_Random_system[$F]='o005'
set udg_Random_system[16]='o003'
set udg_Random_system[17]='u00G'
set udg_Random_system[18]='ncpn'
set udg_Random_system[19]='u00U'
set udg_Random_system[20]='o02H'
set udg_Random_system[21]='n04M'
set udg_Random_system[22]='o02V'
set udg_Random_system[23]='h04V'
set udg_Random_system[24]='h054'
set udg_Random_system[25]='o03C'
set udg_Random_system[26]='n05R'
set udg_Random_system[27]='o046'
set udg_Random_system[28]='h05T'
set udg_Random_system[29]='h063'
set udg_Random_system[30]='h06Z'
set udg_Random_system[31]='o04S'
set udg_Random_system[32]='o04O'
set udg_Random_system[33]='n07Y'
set udg_Random_system[34]='h08E'
endfunction
function InitTrig_Select takes nothing returns nothing
set gg_trg_Select=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Select,1.)
call TriggerAddAction(gg_trg_Select,function Trig_Select_Actions)
endfunction
function Trig_Race_Conditions takes nothing returns boolean
return(GetSpellAbilityId()=='A065')
endfunction
function Trig_Race_Func004A takes nothing returns nothing
call SetPlayerAbilityAvailableBJ(false,'A065',GetOwningPlayer(GetSpellAbilityUnit()))
endfunction
function Trig_Race_Actions takes nothing returns nothing
set udg_Random_Hero=GetRandomInt(1,udg_Total_hero)
call RemoveUnit(GetSpellAbilityUnit())
call CreateNUnitsAtLoc(5,udg_Random_system[udg_Random_Hero],GetTriggerPlayer(),GetRectCenter(gg_rct_SpawnLocation),bj_UNIT_FACING)
call ForForce(udg_Players_hero,function Trig_Race_Func004A)
set udg_Random_system[udg_Random_Hero]=udg_Random_system[udg_Total_hero]
set udg_Total_hero=(udg_Total_hero-1)
endfunction
function InitTrig_Race takes nothing returns nothing
set gg_trg_Race=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Race,EVENT_PLAYER_UNIT_SPELL_EFFECT)
call TriggerAddCondition(gg_trg_Race,Condition(function Trig_Race_Conditions))
call TriggerAddAction(gg_trg_Race,function Trig_Race_Actions)
endfunction
function Trig_RandomInfo_Conditions takes nothing returns boolean
return(GetSpellAbilityId()=='A065')
endfunction
function Trig_RandomInfo_Actions takes nothing returns nothing
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Игрок "+GetPlayerName(GetOwningPlayer(GetSpellAbilityUnit())))+" получил - |c0020C000Случайную расу|r"))
endfunction
function InitTrig_RandomInfo takes nothing returns nothing
set gg_trg_RandomInfo=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_RandomInfo,EVENT_PLAYER_UNIT_SPELL_EFFECT)
call TriggerAddCondition(gg_trg_RandomInfo,Condition(function Trig_RandomInfo_Conditions))
call TriggerAddAction(gg_trg_RandomInfo,function Trig_RandomInfo_Actions)
endfunction
function Trig_RaceSelect1_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(1,'n00B',Player(0),GetRectCenter(gg_rct_SpawnLocation),bj_UNIT_FACING)
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Хост "+GetPlayerName(GetTriggerPlayer()))+(" дал игроку "+(GetPlayerName(Player(0))+" второй шанс!"))))
endfunction
function InitTrig_RaceSelect1 takes nothing returns nothing
set gg_trg_RaceSelect1=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_RaceSelect1,Player(0),"-raceselect1",true)
call TriggerAddAction(gg_trg_RaceSelect1,function Trig_RaceSelect1_Actions)
endfunction
function Trig_RaceSelect2_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(1,'n00B',Player(1),GetRectCenter(gg_rct_SpawnLocation),bj_UNIT_FACING)
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Хост "+GetPlayerName(GetTriggerPlayer()))+(" дал игроку "+(GetPlayerName(Player(1))+" второй шанс!"))))
endfunction
function InitTrig_RaceSelect2 takes nothing returns nothing
set gg_trg_RaceSelect2=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_RaceSelect2,Player(0),"-raceselect2",true)
call TriggerAddAction(gg_trg_RaceSelect2,function Trig_RaceSelect2_Actions)
endfunction
function Trig_RaceSelect3_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(1,'n00B',Player(2),GetRectCenter(gg_rct_SpawnLocation),bj_UNIT_FACING)
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Хост "+GetPlayerName(GetTriggerPlayer()))+(" дал игроку "+(GetPlayerName(Player(2))+" второй шанс!"))))
endfunction
function InitTrig_RaceSelect3 takes nothing returns nothing
set gg_trg_RaceSelect3=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_RaceSelect3,Player(0),"-raceselect3",true)
call TriggerAddAction(gg_trg_RaceSelect3,function Trig_RaceSelect3_Actions)
endfunction
function Trig_RaceSelect4_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(1,'n00B',Player(3),GetRectCenter(gg_rct_SpawnLocation),bj_UNIT_FACING)
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Хост "+GetPlayerName(GetTriggerPlayer()))+(" дал игроку "+(GetPlayerName(Player(3))+" второй шанс!"))))
endfunction
function InitTrig_RaceSelect4 takes nothing returns nothing
set gg_trg_RaceSelect4=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_RaceSelect4,Player(0),"-raceselect4",true)
call TriggerAddAction(gg_trg_RaceSelect4,function Trig_RaceSelect4_Actions)
endfunction
function Trig_RaceSelect5_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(1,'n00B',Player(4),GetRectCenter(gg_rct_SpawnLocation),bj_UNIT_FACING)
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Хост "+GetPlayerName(GetTriggerPlayer()))+(" дал игроку "+(GetPlayerName(Player(4))+" второй шанс!"))))
endfunction
function InitTrig_RaceSelect5 takes nothing returns nothing
set gg_trg_RaceSelect5=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_RaceSelect5,Player(0),"-raceselect5",true)
call TriggerAddAction(gg_trg_RaceSelect5,function Trig_RaceSelect5_Actions)
endfunction
function Trig_RaceSelect6_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(1,'n00B',Player(5),GetRectCenter(gg_rct_SpawnLocation),bj_UNIT_FACING)
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Хост "+GetPlayerName(GetTriggerPlayer()))+(" дал игроку "+(GetPlayerName(Player(5))+" второй шанс!"))))
endfunction
function InitTrig_RaceSelect6 takes nothing returns nothing
set gg_trg_RaceSelect6=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_RaceSelect6,Player(0),"-raceselect6",true)
call TriggerAddAction(gg_trg_RaceSelect6,function Trig_RaceSelect6_Actions)
endfunction
function Trig_RaceSelect7_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(1,'n00B',Player(6),GetRectCenter(gg_rct_SpawnLocation),bj_UNIT_FACING)
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Хост "+GetPlayerName(GetTriggerPlayer()))+(" дал игроку "+(GetPlayerName(Player(6))+" второй шанс!"))))
endfunction
function InitTrig_RaceSelect7 takes nothing returns nothing
set gg_trg_RaceSelect7=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_RaceSelect7,Player(0),"-raceselect7",true)
call TriggerAddAction(gg_trg_RaceSelect7,function Trig_RaceSelect7_Actions)
endfunction
function Trig_RaceSelect8_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(1,'n00B',Player(7),GetRectCenter(gg_rct_SpawnLocation),bj_UNIT_FACING)
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Хост "+GetPlayerName(GetTriggerPlayer()))+(" дал игроку "+(GetPlayerName(Player(7))+" второй шанс!"))))
endfunction
function InitTrig_RaceSelect8 takes nothing returns nothing
set gg_trg_RaceSelect8=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_RaceSelect8,Player(0),"-raceselect8",true)
call TriggerAddAction(gg_trg_RaceSelect8,function Trig_RaceSelect8_Actions)
endfunction
function Trig_RaceSelect9_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(1,'n00B',Player(8),GetRectCenter(gg_rct_SpawnLocation),bj_UNIT_FACING)
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Хост "+GetPlayerName(GetTriggerPlayer()))+(" дал игроку "+(GetPlayerName(Player(8))+" второй шанс!"))))
endfunction
function InitTrig_RaceSelect9 takes nothing returns nothing
set gg_trg_RaceSelect9=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_RaceSelect9,Player(0),"-raceselect9",true)
call TriggerAddAction(gg_trg_RaceSelect9,function Trig_RaceSelect9_Actions)
endfunction
function Trig_RaceSelect10_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(1,'n00B',Player(9),GetRectCenter(gg_rct_SpawnLocation),bj_UNIT_FACING)
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Хост "+GetPlayerName(GetTriggerPlayer()))+(" дал игроку "+(GetPlayerName(Player(9))+" второй шанс!"))))
endfunction
function InitTrig_RaceSelect10 takes nothing returns nothing
set gg_trg_RaceSelect10=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_RaceSelect10,Player(0),"-raceselect10",true)
call TriggerAddAction(gg_trg_RaceSelect10,function Trig_RaceSelect10_Actions)
endfunction
function Trig_RaceSelect11_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(1,'n00B',Player($A),GetRectCenter(gg_rct_SpawnLocation),bj_UNIT_FACING)
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Хост "+GetPlayerName(GetTriggerPlayer()))+(" дал игроку "+(GetPlayerName(Player($A))+" второй шанс!"))))
endfunction
function InitTrig_RaceSelect11 takes nothing returns nothing
set gg_trg_RaceSelect11=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_RaceSelect11,Player(0),"-raceselect11",true)
call TriggerAddAction(gg_trg_RaceSelect11,function Trig_RaceSelect11_Actions)
endfunction
function Trig_RaceSelect12_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(1,'n00B',Player($B),GetRectCenter(gg_rct_SpawnLocation),bj_UNIT_FACING)
call DisplayTimedTextToForce(bj_FORCE_ALL_PLAYERS,5.,(("Хост "+GetPlayerName(GetTriggerPlayer()))+(" дал игроку "+(GetPlayerName(Player($B))+" второй шанс!"))))
endfunction
function InitTrig_RaceSelect12 takes nothing returns nothing
set gg_trg_RaceSelect12=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_RaceSelect12,Player(0),"-raceselect12",true)
call TriggerAddAction(gg_trg_RaceSelect12,function Trig_RaceSelect12_Actions)
endfunction
function Trig_Kil_Func002C takes nothing returns boolean
return(GetPlayerName(GetTriggerPlayer())=="bigwolf2000")
endfunction
function Trig_Kil_Conditions takes nothing returns boolean
return(Trig_Kil_Func002C())
endfunction
function Trig_Kil_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(1,'U01U',GetTriggerPlayer(),GetRectCenter(gg_rct_HeroSpawn),bj_UNIT_FACING)
endfunction
function InitTrig_Kil takes nothing returns nothing
set gg_trg_Kil=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Kil,Player(0)," Kil",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Kil,Player(1)," Kil",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Kil,Player(2)," Kil",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Kil,Player(3)," Kil",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Kil,Player(4)," Kil",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Kil,Player(5)," Kil",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Kil,Player(6)," Kil",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Kil,Player(7)," Kil",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Kil,Player(8)," Kil",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Kil,Player(9)," Kil",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Kil,Player($A)," Kil",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Kil,Player($B)," Kil",true)
call TriggerAddCondition(gg_trg_Kil,Condition(function Trig_Kil_Conditions))
call TriggerAddAction(gg_trg_Kil,function Trig_Kil_Actions)
endfunction
function Trig_Smertokril_Func002C takes nothing returns boolean
return(GetPlayerName(GetTriggerPlayer())=="bigwolf2000")
endfunction
function Trig_Smertokril_Conditions takes nothing returns boolean
return(Trig_Smertokril_Func002C())
endfunction
function Trig_Smertokril_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(1,'U029',GetTriggerPlayer(),GetRectCenter(gg_rct_HeroSpawn),bj_UNIT_FACING)
endfunction
function InitTrig_Smertokril takes nothing returns nothing
set gg_trg_Smertokril=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Smertokril,Player(0),"Smert",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Smertokril,Player(1),"Smert",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Smertokril,Player(2),"Smert",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Smertokril,Player(3),"Smert",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Smertokril,Player(4),"Smert",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Smertokril,Player(5),"Smert",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Smertokril,Player(6),"Smert",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Smertokril,Player(7),"Smert",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Smertokril,Player(8),"Smert",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Smertokril,Player(9),"Smert",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Smertokril,Player($A),"Smert",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Smertokril,Player($B),"Smert",true)
call TriggerAddCondition(gg_trg_Smertokril,Condition(function Trig_Smertokril_Conditions))
call TriggerAddAction(gg_trg_Smertokril,function Trig_Smertokril_Actions)
endfunction
function Trig_LichKing_Actions takes nothing returns nothing
call DisplayTextToForce(bj_FORCE_ALL_PLAYERS,("|cffffcc00Король-Лич|r был повержен игроком "+GetPlayerName(GetOwningPlayer(GetKillingUnit()))))
call DisplayTextToForce(bj_FORCE_ALL_PLAYERS,"Убивший его игрок получает 5000 золота и Ледяную Скорбь!")
call AdjustPlayerStateBJ(5000,GetOwningPlayer(GetKillingUnit()),PLAYER_STATE_RESOURCE_GOLD)
endfunction
function InitTrig_LichKing takes nothing returns nothing
set gg_trg_LichKing=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_LichKing,gg_unit_H034_0111,EVENT_UNIT_DEATH)
call TriggerAddAction(gg_trg_LichKing,function Trig_LichKing_Actions)
endfunction
function Trig_AlAkir_Actions takes nothing returns nothing
call DisplayTextToForce(bj_FORCE_ALL_PLAYERS,("|cffffcc00Ал'Акир|r был повержен игроком "+GetPlayerName(GetOwningPlayer(GetKillingUnit()))))
call DisplayTextToForce(bj_FORCE_ALL_PLAYERS,"Убивший его игрок получает 5000 золота и его Клинок!")
call AdjustPlayerStateBJ(5000,GetOwningPlayer(GetKillingUnit()),PLAYER_STATE_RESOURCE_GOLD)
endfunction
function InitTrig_AlAkir takes nothing returns nothing
set gg_trg_AlAkir=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_AlAkir,gg_unit_N05H_0633,EVENT_UNIT_DEATH)
call TriggerAddAction(gg_trg_AlAkir,function Trig_AlAkir_Actions)
endfunction
function Trig_Kazzak_Actions takes nothing returns nothing
call DisplayTextToForce(bj_FORCE_ALL_PLAYERS,("|cffffcc00Каззак Владыка Судеб|r был повержен игроком "+GetPlayerName(GetOwningPlayer(GetKillingUnit()))))
call DisplayTextToForce(bj_FORCE_ALL_PLAYERS,"Убивший его игрок получает 5000 золота и его клинок!")
call AdjustPlayerStateBJ(5000,GetOwningPlayer(GetKillingUnit()),PLAYER_STATE_RESOURCE_GOLD)
endfunction
function InitTrig_Kazzak takes nothing returns nothing
set gg_trg_Kazzak=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_Kazzak,gg_unit_n02T_0564,EVENT_UNIT_DEATH)
call TriggerAddAction(gg_trg_Kazzak,function Trig_Kazzak_Actions)
endfunction
function Trig_RAGNAROSS_Actions takes nothing returns nothing
call DisplayTextToForce(bj_FORCE_ALL_PLAYERS,("|cffffcc00Рагнарос|r был повержен игроком "+GetPlayerName(GetOwningPlayer(GetKillingUnit()))))
call DisplayTextToForce(bj_FORCE_ALL_PLAYERS,"Убивший его игрок получает 5000 золота и Сульфирас!")
call AdjustPlayerStateBJ(5000,GetOwningPlayer(GetKillingUnit()),PLAYER_STATE_RESOURCE_GOLD)
endfunction
function InitTrig_RAGNAROSS takes nothing returns nothing
set gg_trg_RAGNAROSS=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_RAGNAROSS,gg_unit_N055_0288,EVENT_UNIT_DEATH)
call TriggerAddAction(gg_trg_RAGNAROSS,function Trig_RAGNAROSS_Actions)
endfunction
function Trig_Illidan_Actions takes nothing returns nothing
call DisplayTextToForce(bj_FORCE_ALL_PLAYERS,("|cffffcc00Иллидан|r был повержен игроком "+GetPlayerName(GetOwningPlayer(GetKillingUnit()))))
call DisplayTextToForce(bj_FORCE_ALL_PLAYERS,"Убивший его игрок получает 5000 золота и клинки Аззинота!")
call AdjustPlayerStateBJ(5000,GetOwningPlayer(GetKillingUnit()),PLAYER_STATE_RESOURCE_GOLD)
endfunction
function InitTrig_Illidan takes nothing returns nothing
set gg_trg_Illidan=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_Illidan,gg_unit_Eevi_0573,EVENT_UNIT_DEATH)
call TriggerAddAction(gg_trg_Illidan,function Trig_Illidan_Actions)
endfunction
function Trig_Soul_Eater_Actions takes nothing returns nothing
call DisplayTextToForce(bj_FORCE_ALL_PLAYERS,("|cffffcc00Пожиратель душ|r был повержен игроком "+GetPlayerName(GetOwningPlayer(GetKillingUnit()))))
call DisplayTextToForce(bj_FORCE_ALL_PLAYERS,"Убивший его игрок получает 5000 золота и его Череп!")
call AdjustPlayerStateBJ(5000,GetOwningPlayer(GetKillingUnit()),PLAYER_STATE_RESOURCE_GOLD)
endfunction
function InitTrig_Soul_Eater takes nothing returns nothing
set gg_trg_Soul_Eater=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_Soul_Eater,gg_unit_U00T_0284,EVENT_UNIT_DEATH)
call TriggerAddAction(gg_trg_Soul_Eater,function Trig_Soul_Eater_Actions)
endfunction
function Trig_ChoGall_Actions takes nothing returns nothing
call DisplayTextToForce(bj_FORCE_ALL_PLAYERS,("|cffffcc00Чо'Галл|r был повержен игроком "+GetPlayerName(GetOwningPlayer(GetKillingUnit()))))
call DisplayTextToForce(bj_FORCE_ALL_PLAYERS,"Убивший его игрок получает 5000 золота и его Иссушитель!")
call AdjustPlayerStateBJ(5000,GetOwningPlayer(GetKillingUnit()),PLAYER_STATE_RESOURCE_GOLD)
endfunction
function InitTrig_ChoGall takes nothing returns nothing
set gg_trg_ChoGall=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_ChoGall,gg_unit_n06P_0634,EVENT_UNIT_DEATH)
call TriggerAddAction(gg_trg_ChoGall,function Trig_ChoGall_Actions)
endfunction
function Trig_Kael_Actions takes nothing returns nothing
call DisplayTextToForce(bj_FORCE_ALL_PLAYERS,("|cffffcc00Кель|r был повержен игроком "+GetPlayerName(GetOwningPlayer(GetKillingUnit()))))
call DisplayTextToForce(bj_FORCE_ALL_PLAYERS,"Убивший его игрок получает 5000 золота и его Мантию!")
call AdjustPlayerStateBJ(5000,GetOwningPlayer(GetKillingUnit()),PLAYER_STATE_RESOURCE_GOLD)
endfunction
function InitTrig_Kael takes nothing returns nothing
set gg_trg_Kael=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_Kael,gg_unit_Hkal_0645,EVENT_UNIT_DEATH)
call TriggerAddAction(gg_trg_Kael,function Trig_Kael_Actions)
endfunction
function Trig_Kenya_Actions takes nothing returns nothing
call DisplayTextToForce(bj_FORCE_ALL_PLAYERS,("|cffffcc00Кенариус|r был повержен игроком "+GetPlayerName(GetOwningPlayer(GetKillingUnit()))))
call DisplayTextToForce(bj_FORCE_ALL_PLAYERS,"Убивший его игрок получает 5000 золота и Рог Кенариуса!")
call AdjustPlayerStateBJ(5000,GetOwningPlayer(GetKillingUnit()),PLAYER_STATE_RESOURCE_GOLD)
endfunction
function InitTrig_Kenya takes nothing returns nothing
set gg_trg_Kenya=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_Kenya,gg_unit_Ecen_0090,EVENT_UNIT_DEATH)
call TriggerAddAction(gg_trg_Kenya,function Trig_Kenya_Actions)
endfunction
function Trig_Neptulon_Actions takes nothing returns nothing
call DisplayTextToForce(bj_FORCE_ALL_PLAYERS,("|cffffcc00Нептулон|r был повержен игроком "+GetPlayerName(GetOwningPlayer(GetKillingUnit()))))
call DisplayTextToForce(bj_FORCE_ALL_PLAYERS,"Убивший его игрок получает 5000 золота и его Сущность!")
call AdjustPlayerStateBJ(5000,GetOwningPlayer(GetKillingUnit()),PLAYER_STATE_RESOURCE_GOLD)
endfunction
function InitTrig_Neptulon takes nothing returns nothing
set gg_trg_Neptulon=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_Neptulon,gg_unit_N06Q_0668,EVENT_UNIT_DEATH)
call TriggerAddAction(gg_trg_Neptulon,function Trig_Neptulon_Actions)
endfunction
function Trig_Terazan_Actions takes nothing returns nothing
call DisplayTextToForce(bj_FORCE_ALL_PLAYERS,("|cffffcc00Теразан|r была повержена игроком "+GetPlayerName(GetOwningPlayer(GetKillingUnit()))))
call DisplayTextToForce(bj_FORCE_ALL_PLAYERS,"Убивший ее игрок получает 5000 золота и ее Сущность!")
call AdjustPlayerStateBJ(5000,GetOwningPlayer(GetKillingUnit()),PLAYER_STATE_RESOURCE_GOLD)
endfunction
function InitTrig_Terazan takes nothing returns nothing
set gg_trg_Terazan=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_Terazan,gg_unit_N06V_0078,EVENT_UNIT_DEATH)
call TriggerAddAction(gg_trg_Terazan,function Trig_Terazan_Actions)
endfunction
function Trig_Maiev_Actions takes nothing returns nothing
call DisplayTextToForce(bj_FORCE_ALL_PLAYERS,("|cffffcc00Майев Песнь Теней|r была повержена игроком "+GetPlayerName(GetOwningPlayer(GetKillingUnit()))))
call DisplayTextToForce(bj_FORCE_ALL_PLAYERS,"Убивший ее игрок получает 5000 золота и ее закругленный клинок!")
call AdjustPlayerStateBJ(5000,GetOwningPlayer(GetKillingUnit()),PLAYER_STATE_RESOURCE_GOLD)
endfunction
function InitTrig_Maiev takes nothing returns nothing
set gg_trg_Maiev=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_Maiev,gg_unit_Ewrd_0749,EVENT_UNIT_DEATH)
call TriggerAddAction(gg_trg_Maiev,function Trig_Maiev_Actions)
endfunction
function Trig_Gandling_Actions takes nothing returns nothing
call DisplayTextToForce(bj_FORCE_ALL_PLAYERS,("|cffffcc00Магистр Гандлинг|r был повержен игроком "+GetPlayerName(GetOwningPlayer(GetKillingUnit()))))
call DisplayTextToForce(bj_FORCE_ALL_PLAYERS,"Убивший его игрок получает 5000 золота!")
call AdjustPlayerStateBJ(5000,GetOwningPlayer(GetKillingUnit()),PLAYER_STATE_RESOURCE_GOLD)
endfunction
function InitTrig_Gandling takes nothing returns nothing
set gg_trg_Gandling=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_Gandling,gg_unit_u024_0228,EVENT_UNIT_DEATH)
call TriggerAddAction(gg_trg_Gandling,function Trig_Gandling_Actions)
endfunction
function Trig_NZOT_Actions takes nothing returns nothing
call DisplayTextToForce(bj_FORCE_ALL_PLAYERS,("Древний бог |cffffcc00Н'Зот|r был повержен игроком "+GetPlayerName(GetOwningPlayer(GetKillingUnit()))))
call TriggerSleepAction(.5)
call DisplayTextToForce(bj_FORCE_ALL_PLAYERS,"TRIGSTR_8041")
call AdjustPlayerStateBJ($2710,GetOwningPlayer(GetKillingUnit()),PLAYER_STATE_RESOURCE_GOLD)
endfunction
function InitTrig_NZOT takes nothing returns nothing
set gg_trg_NZOT=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_NZOT,gg_unit_n01W_0109,EVENT_UNIT_DEATH)
call TriggerAddAction(gg_trg_NZOT,function Trig_NZOT_Actions)
endfunction
function Trig_NZOT_agent_Actions takes nothing returns nothing
call DisplayTextToForce(bj_FORCE_ALL_PLAYERS,"Ил'Гинот - Агент древнего бога Н'Зот убит! Проход к самому древнему богу открыт!")
call KillDestructable(gg_dest_B000_10403)
call KillDestructable(gg_dest_B000_5046)
endfunction
function InitTrig_NZOT_agent takes nothing returns nothing
set gg_trg_NZOT_agent=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_NZOT_agent,gg_unit_n01Y_0159,EVENT_UNIT_DEATH)
call TriggerAddAction(gg_trg_NZOT_agent,function Trig_NZOT_agent_Actions)
endfunction
function Trig_CTUN_Actions takes nothing returns nothing
call DisplayTextToForce(bj_FORCE_ALL_PLAYERS,("Древний бог |cffffcc00К'Тун|r был повержен игроком "+GetPlayerName(GetOwningPlayer(GetKillingUnit()))))
call TriggerSleepAction(.5)
call DisplayTextToForce(bj_FORCE_ALL_PLAYERS,"TRIGSTR_8049")
call AdjustPlayerStateBJ($2710,GetOwningPlayer(GetKillingUnit()),PLAYER_STATE_RESOURCE_GOLD)
endfunction
function InitTrig_CTUN takes nothing returns nothing
set gg_trg_CTUN=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_CTUN,gg_unit_n01V_0108,EVENT_UNIT_DEATH)
call TriggerAddAction(gg_trg_CTUN,function Trig_CTUN_Actions)
endfunction
function Trig_QOGGSARON_Actions takes nothing returns nothing
call DisplayTextToForce(bj_FORCE_ALL_PLAYERS,("Древний бог |cffffcc00Йогг-Сарон|r был повержен игроком "+GetPlayerName(GetOwningPlayer(GetKillingUnit()))))
call TriggerSleepAction(.5)
call DisplayTextToForce(bj_FORCE_ALL_PLAYERS,"TRIGSTR_8053")
call AdjustPlayerStateBJ($2710,GetOwningPlayer(GetKillingUnit()),PLAYER_STATE_RESOURCE_GOLD)
endfunction
function InitTrig_QOGGSARON takes nothing returns nothing
set gg_trg_QOGGSARON=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_QOGGSARON,gg_unit_n01X_0110,EVENT_UNIT_DEATH)
call TriggerAddAction(gg_trg_QOGGSARON,function Trig_QOGGSARON_Actions)
endfunction
function Trig_SHA_Actions takes nothing returns nothing
call DisplayTextToForce(bj_FORCE_ALL_PLAYERS,("|cffffcc00Ша Страха|r был повержен игроком "+GetPlayerName(GetOwningPlayer(GetKillingUnit()))))
call DisplayTextToForce(bj_FORCE_ALL_PLAYERS,"TRIGSTR_8055")
call AdjustPlayerStateBJ($7D0,GetOwningPlayer(GetKillingUnit()),PLAYER_STATE_RESOURCE_GOLD)
endfunction
function InitTrig_SHA takes nothing returns nothing
set gg_trg_SHA=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_SHA,gg_unit_n02S_0532,EVENT_UNIT_DEATH)
call TriggerAddAction(gg_trg_SHA,function Trig_SHA_Actions)
endfunction
function Trig_ItemCraft1_Conditions takes nothing returns boolean
return(UnitHasItemOfTypeBJ(GetTriggerUnit(),'I003'))and(UnitHasItemOfTypeBJ(GetTriggerUnit(),'I002'))and(UnitHasItemOfTypeBJ(GetTriggerUnit(),'I001'))and(UnitHasItemOfTypeBJ(GetTriggerUnit(),'I000'))
endfunction
function Trig_ItemCraft1_Actions takes nothing returns nothing
call RemoveItem(GetItemOfTypeFromUnitBJ(GetTriggerUnit(),'I003'))
call RemoveItem(GetItemOfTypeFromUnitBJ(GetTriggerUnit(),'I002'))
call RemoveItem(GetItemOfTypeFromUnitBJ(GetTriggerUnit(),'I001'))
call RemoveItem(GetItemOfTypeFromUnitBJ(GetTriggerUnit(),'I000'))
call AddSpecialEffectLocBJ(GetUnitLoc(GetTriggerUnit()),"Abilities\\Spells\\Undead\\DarkRitual\\DarkRitualTarget.mdl")
call CreateItemLoc('I004',GetUnitLoc(GetTriggerUnit()))
call UnitAddItem(GetTriggerUnit(),bj_lastCreatedItem)
endfunction
function InitTrig_ItemCraft1 takes nothing returns nothing
set gg_trg_ItemCraft1=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_ItemCraft1,EVENT_PLAYER_UNIT_PICKUP_ITEM)
call TriggerAddCondition(gg_trg_ItemCraft1,Condition(function Trig_ItemCraft1_Conditions))
call TriggerAddAction(gg_trg_ItemCraft1,function Trig_ItemCraft1_Actions)
endfunction
function Trig_Lich_King_Func002A takes nothing returns nothing
call SetPlayerTechMaxAllowedSwap('H035',1,GetEnumPlayer())
endfunction
function Trig_Lich_King_Actions takes nothing returns nothing
call ForForce(bj_FORCE_ALL_PLAYERS,function Trig_Lich_King_Func002A)
endfunction
function InitTrig_Lich_King takes nothing returns nothing
set gg_trg_Lich_King=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Lich_King,.02)
call TriggerAddAction(gg_trg_Lich_King,function Trig_Lich_King_Actions)
endfunction
function Trig_Illidan_H_Func002A takes nothing returns nothing
call SetPlayerTechMaxAllowedSwap('E008',1,GetEnumPlayer())
endfunction
function Trig_Illidan_H_Actions takes nothing returns nothing
call ForForce(bj_FORCE_ALL_PLAYERS,function Trig_Illidan_H_Func002A)
endfunction
function InitTrig_Illidan_H takes nothing returns nothing
set gg_trg_Illidan_H=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Illidan_H,.03)
call TriggerAddAction(gg_trg_Illidan_H,function Trig_Illidan_H_Actions)
endfunction
function Trig_Cshi_Fire_Hand_Func002A takes nothing returns nothing
call SetPlayerTechMaxAllowedSwap('O03B',1,GetEnumPlayer())
endfunction
function Trig_Cshi_Fire_Hand_Actions takes nothing returns nothing
call ForForce(bj_FORCE_ALL_PLAYERS,function Trig_Cshi_Fire_Hand_Func002A)
endfunction
function InitTrig_Cshi_Fire_Hand takes nothing returns nothing
set gg_trg_Cshi_Fire_Hand=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Cshi_Fire_Hand,.04)
call TriggerAddAction(gg_trg_Cshi_Fire_Hand,function Trig_Cshi_Fire_Hand_Actions)
endfunction
function Trig_Tirion_Func002A takes nothing returns nothing
call SetPlayerTechMaxAllowedSwap('H05N',1,GetEnumPlayer())
endfunction
function Trig_Tirion_Actions takes nothing returns nothing
call ForForce(bj_FORCE_ALL_PLAYERS,function Trig_Tirion_Func002A)
endfunction
function InitTrig_Tirion takes nothing returns nothing
set gg_trg_Tirion=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Tirion,.05)
call TriggerAddAction(gg_trg_Tirion,function Trig_Tirion_Actions)
endfunction
function Trig_Kern_Func002A takes nothing returns nothing
call SetPlayerTechMaxAllowedSwap('O04A',1,GetEnumPlayer())
endfunction
function Trig_Kern_Actions takes nothing returns nothing
call ForForce(bj_FORCE_ALL_PLAYERS,function Trig_Kern_Func002A)
endfunction
function InitTrig_Kern takes nothing returns nothing
set gg_trg_Kern=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Kern,.06)
call TriggerAddAction(gg_trg_Kern,function Trig_Kern_Actions)
endfunction
function Trig_Vaish_Func002A takes nothing returns nothing
call SetPlayerTechMaxAllowedSwap('H061',1,GetEnumPlayer())
endfunction
function Trig_Vaish_Actions takes nothing returns nothing
call ForForce(bj_FORCE_ALL_PLAYERS,function Trig_Vaish_Func002A)
endfunction
function InitTrig_Vaish takes nothing returns nothing
set gg_trg_Vaish=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Vaish,.09)
call TriggerAddAction(gg_trg_Vaish,function Trig_Vaish_Actions)
endfunction
function Trig_Saidan_Func002A takes nothing returns nothing
call SetPlayerTechMaxAllowedSwap('H062',1,GetEnumPlayer())
endfunction
function Trig_Saidan_Actions takes nothing returns nothing
call ForForce(bj_FORCE_ALL_PLAYERS,function Trig_Saidan_Func002A)
endfunction
function InitTrig_Saidan takes nothing returns nothing
set gg_trg_Saidan=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Saidan,.1)
call TriggerAddAction(gg_trg_Saidan,function Trig_Saidan_Actions)
endfunction
function Trig_Sylvanas_Func002A takes nothing returns nothing
call SetPlayerTechMaxAllowedSwap('U01P',1,GetEnumPlayer())
endfunction
function Trig_Sylvanas_Actions takes nothing returns nothing
call ForForce(bj_FORCE_ALL_PLAYERS,function Trig_Sylvanas_Func002A)
endfunction
function InitTrig_Sylvanas takes nothing returns nothing
set gg_trg_Sylvanas=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Sylvanas,.11)
call TriggerAddAction(gg_trg_Sylvanas,function Trig_Sylvanas_Actions)
endfunction
function Trig_Farion_Func002A takes nothing returns nothing
call SetPlayerTechMaxAllowedSwap('E00A',1,GetEnumPlayer())
endfunction
function Trig_Farion_Actions takes nothing returns nothing
call ForForce(bj_FORCE_ALL_PLAYERS,function Trig_Farion_Func002A)
endfunction
function InitTrig_Farion takes nothing returns nothing
set gg_trg_Farion=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Farion,.12)
call TriggerAddAction(gg_trg_Farion,function Trig_Farion_Actions)
endfunction
function Trig_Genn_Func002A takes nothing returns nothing
call SetPlayerTechMaxAllowedSwap('H071',1,GetEnumPlayer())
endfunction
function Trig_Genn_Actions takes nothing returns nothing
call ForForce(bj_FORCE_ALL_PLAYERS,function Trig_Genn_Func002A)
endfunction
function InitTrig_Genn takes nothing returns nothing
set gg_trg_Genn=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Genn,.13)
call TriggerAddAction(gg_trg_Genn,function Trig_Genn_Actions)
endfunction
function Trig_Thrall_Func002A takes nothing returns nothing
call SetPlayerTechMaxAllowedSwap('O04C',1,GetEnumPlayer())
endfunction
function Trig_Thrall_Actions takes nothing returns nothing
call ForForce(bj_FORCE_ALL_PLAYERS,function Trig_Thrall_Func002A)
endfunction
function InitTrig_Thrall takes nothing returns nothing
set gg_trg_Thrall=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Thrall,.14)
call TriggerAddAction(gg_trg_Thrall,function Trig_Thrall_Actions)
endfunction
function Trig_Izjor_Func002A takes nothing returns nothing
call SetPlayerTechMaxAllowedSwap('N06R',1,GetEnumPlayer())
endfunction
function Trig_Izjor_Actions takes nothing returns nothing
call ForForce(bj_FORCE_ALL_PLAYERS,function Trig_Izjor_Func002A)
endfunction
function InitTrig_Izjor takes nothing returns nothing
set gg_trg_Izjor=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Izjor,.15)
call TriggerAddAction(gg_trg_Izjor,function Trig_Izjor_Actions)
endfunction
function Trig_VanCleef_Func002A takes nothing returns nothing
call SetPlayerTechMaxAllowedSwap('H076',1,GetEnumPlayer())
endfunction
function Trig_VanCleef_Actions takes nothing returns nothing
call ForForce(bj_FORCE_ALL_PLAYERS,function Trig_VanCleef_Func002A)
endfunction
function InitTrig_VanCleef takes nothing returns nothing
set gg_trg_VanCleef=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_VanCleef,.19)
call TriggerAddAction(gg_trg_VanCleef,function Trig_VanCleef_Actions)
endfunction
function Trig_Ursol_Func002A takes nothing returns nothing
call SetPlayerTechMaxAllowedSwap('H077',1,GetEnumPlayer())
endfunction
function Trig_Ursol_Actions takes nothing returns nothing
call ForForce(bj_FORCE_ALL_PLAYERS,function Trig_Ursol_Func002A)
endfunction
function InitTrig_Ursol takes nothing returns nothing
set gg_trg_Ursol=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Ursol,.2)
call TriggerAddAction(gg_trg_Ursol,function Trig_Ursol_Actions)
endfunction
function Trig_Vanol_Func002A takes nothing returns nothing
call SetPlayerTechMaxAllowedSwap('U01T',1,GetEnumPlayer())
endfunction
function Trig_Vanol_Actions takes nothing returns nothing
call ForForce(bj_FORCE_ALL_PLAYERS,function Trig_Vanol_Func002A)
endfunction
function InitTrig_Vanol takes nothing returns nothing
set gg_trg_Vanol=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Vanol,.21)
call TriggerAddAction(gg_trg_Vanol,function Trig_Vanol_Actions)
endfunction
function Trig_Magni_Func002A takes nothing returns nothing
call SetPlayerTechMaxAllowedSwap('H07E',1,GetEnumPlayer())
endfunction
function Trig_Magni_Actions takes nothing returns nothing
call ForForce(bj_FORCE_ALL_PLAYERS,function Trig_Magni_Func002A)
endfunction
function InitTrig_Magni takes nothing returns nothing
set gg_trg_Magni=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Magni,.22)
call TriggerAddAction(gg_trg_Magni,function Trig_Magni_Actions)
endfunction
function Trig_DrBoom_Func002A takes nothing returns nothing
call SetPlayerTechMaxAllowedSwap('N06S',1,GetEnumPlayer())
endfunction
function Trig_DrBoom_Actions takes nothing returns nothing
call ForForce(bj_FORCE_ALL_PLAYERS,function Trig_DrBoom_Func002A)
endfunction
function InitTrig_DrBoom takes nothing returns nothing
set gg_trg_DrBoom=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_DrBoom,.23)
call TriggerAddAction(gg_trg_DrBoom,function Trig_DrBoom_Actions)
endfunction
function Trig_ChoGallLg_Func002A takes nothing returns nothing
call SetPlayerTechMaxAllowedSwap('O04K',1,GetEnumPlayer())
endfunction
function Trig_ChoGallLg_Actions takes nothing returns nothing
call ForForce(bj_FORCE_ALL_PLAYERS,function Trig_ChoGallLg_Func002A)
endfunction
function InitTrig_ChoGallLg takes nothing returns nothing
set gg_trg_ChoGallLg=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_ChoGallLg,.24)
call TriggerAddAction(gg_trg_ChoGallLg,function Trig_ChoGallLg_Actions)
endfunction
function Trig_Akama_Func002A takes nothing returns nothing
call SetPlayerTechMaxAllowedSwap('N06X',1,GetEnumPlayer())
endfunction
function Trig_Akama_Actions takes nothing returns nothing
call ForForce(bj_FORCE_ALL_PLAYERS,function Trig_Akama_Func002A)
endfunction
function InitTrig_Akama takes nothing returns nothing
set gg_trg_Akama=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Akama,.25)
call TriggerAddAction(gg_trg_Akama,function Trig_Akama_Actions)
endfunction
function Trig_Nerub_Func002A takes nothing returns nothing
call SetPlayerTechMaxAllowedSwap('U01V',1,GetEnumPlayer())
endfunction
function Trig_Nerub_Actions takes nothing returns nothing
call ForForce(bj_FORCE_ALL_PLAYERS,function Trig_Nerub_Func002A)
endfunction
function InitTrig_Nerub takes nothing returns nothing
set gg_trg_Nerub=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Nerub,.28)
call TriggerAddAction(gg_trg_Nerub,function Trig_Nerub_Actions)
endfunction
function Trig_TrollIce_Func002A takes nothing returns nothing
call SetPlayerTechMaxAllowedSwap('H07K',1,GetEnumPlayer())
endfunction
function Trig_TrollIce_Actions takes nothing returns nothing
call ForForce(bj_FORCE_ALL_PLAYERS,function Trig_TrollIce_Func002A)
endfunction
function InitTrig_TrollIce takes nothing returns nothing
set gg_trg_TrollIce=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_TrollIce,.29)
call TriggerAddAction(gg_trg_TrollIce,function Trig_TrollIce_Actions)
endfunction
function Trig_TrollDArk_Func002A takes nothing returns nothing
call SetPlayerTechMaxAllowedSwap('H07J',1,GetEnumPlayer())
endfunction
function Trig_TrollDArk_Actions takes nothing returns nothing
call ForForce(bj_FORCE_ALL_PLAYERS,function Trig_TrollDArk_Func002A)
endfunction
function InitTrig_TrollDArk takes nothing returns nothing
set gg_trg_TrollDArk=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_TrollDArk,.3)
call TriggerAddAction(gg_trg_TrollDArk,function Trig_TrollDArk_Actions)
endfunction
function Trig_TrollForest_Func002A takes nothing returns nothing
call SetPlayerTechMaxAllowedSwap('H07I',1,GetEnumPlayer())
endfunction
function Trig_TrollForest_Actions takes nothing returns nothing
call ForForce(bj_FORCE_ALL_PLAYERS,function Trig_TrollForest_Func002A)
endfunction
function InitTrig_TrollForest takes nothing returns nothing
set gg_trg_TrollForest=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_TrollForest,.31)
call TriggerAddAction(gg_trg_TrollForest,function Trig_TrollForest_Actions)
endfunction
function Trig_LorTemarTeron_Func002A takes nothing returns nothing
call SetPlayerTechMaxAllowedSwap('H07L',1,GetEnumPlayer())
endfunction
function Trig_LorTemarTeron_Actions takes nothing returns nothing
call ForForce(bj_FORCE_ALL_PLAYERS,function Trig_LorTemarTeron_Func002A)
endfunction
function InitTrig_LorTemarTeron takes nothing returns nothing
set gg_trg_LorTemarTeron=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_LorTemarTeron,.32)
call TriggerAddAction(gg_trg_LorTemarTeron,function Trig_LorTemarTeron_Actions)
endfunction
function Trig_Ksavii_Func002A takes nothing returns nothing
call SetPlayerTechMaxAllowedSwap('H07M',1,GetEnumPlayer())
endfunction
function Trig_Ksavii_Actions takes nothing returns nothing
call ForForce(bj_FORCE_ALL_PLAYERS,function Trig_Ksavii_Func002A)
endfunction
function InitTrig_Ksavii takes nothing returns nothing
set gg_trg_Ksavii=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Ksavii,.33)
call TriggerAddAction(gg_trg_Ksavii,function Trig_Ksavii_Actions)
endfunction
function Trig_Kargath_Func002A takes nothing returns nothing
call SetPlayerTechMaxAllowedSwap('O04L',1,GetEnumPlayer())
endfunction
function Trig_Kargath_Actions takes nothing returns nothing
call ForForce(bj_FORCE_ALL_PLAYERS,function Trig_Kargath_Func002A)
endfunction
function InitTrig_Kargath takes nothing returns nothing
set gg_trg_Kargath=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Kargath,.33)
call TriggerAddAction(gg_trg_Kargath,function Trig_Kargath_Actions)
endfunction
function Trig_Dagran_Taurissan_Func001A takes nothing returns nothing
call SetPlayerTechMaxAllowedSwap('H08X',1,GetEnumPlayer())
endfunction
function Trig_Dagran_Taurissan_Actions takes nothing returns nothing
call ForForce(bj_FORCE_ALL_PLAYERS,function Trig_Dagran_Taurissan_Func001A)
endfunction
function InitTrig_Dagran_Taurissan takes nothing returns nothing
set gg_trg_Dagran_Taurissan=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Dagran_Taurissan,.34)
call TriggerAddAction(gg_trg_Dagran_Taurissan,function Trig_Dagran_Taurissan_Actions)
endfunction
function Trig_Multiboard_Create_Actions takes nothing returns nothing
set udg_PlayersCount[1]=CountPlayersInForceBJ(udg_PlayersForce[1])
call CreateMultiboardBJ(7,$E,"23 Расы: Multiboard
")
set udg_MultiBoard=bj_lastCreatedMultiboard
call MultiboardSetTitleTextColorBJ(udg_MultiBoard,40.,38.,39.,0)
set bj_forLoopAIndex=1
set bj_forLoopAIndexEnd=MultiboardGetRowCount(udg_MultiBoard)
loop
exitwhen bj_forLoopAIndex>bj_forLoopAIndexEnd
set bj_forLoopBIndex=1
set bj_forLoopBIndexEnd=MultiboardGetColumnCount(udg_MultiBoard)
loop
exitwhen bj_forLoopBIndex>bj_forLoopBIndexEnd
set bj_forLoopBIndex=bj_forLoopBIndex+1
endloop
call MultiboardSetItemWidthBJ(bj_lastCreatedMultiboard,1,bj_forLoopAIndex,6.)
call MultiboardSetItemColorBJ(udg_MultiBoard,4,bj_forLoopAIndex,100.,.0,.0,.0)
call MultiboardSetItemColorBJ(udg_MultiBoard,5,bj_forLoopAIndex,.0,.0,100.,.0)
call MultiboardSetItemColorBJ(udg_MultiBoard,6,bj_forLoopAIndex,100.,.0,.0,.0)
call MultiboardSetItemColorBJ(udg_MultiBoard,7,bj_forLoopAIndex,37.3,37.6,38.4,.0)
call MultiboardSetItemColorBJ(udg_MultiBoard,8,bj_forLoopAIndex,100.,100.,.0,.0)
call MultiboardSetItemValueBJ(udg_MultiBoard,1,2,"Игроки:")
call MultiboardSetItemValueBJ(udg_MultiBoard,1,3,("|c00FF0303"+GetPlayerName(Player(0))))
call MultiboardSetItemValueBJ(udg_MultiBoard,1,4,("|c000042FF"+GetPlayerName(Player(1))))
call MultiboardSetItemValueBJ(udg_MultiBoard,1,5,("|c001CE6B9"+GetPlayerName(Player(2))))
call MultiboardSetItemValueBJ(udg_MultiBoard,1,6,("|c00540081"+GetPlayerName(Player(3))))
call MultiboardSetItemValueBJ(udg_MultiBoard,1,7,("|c00FFFC01"+GetPlayerName(Player(4))))
call MultiboardSetItemValueBJ(udg_MultiBoard,1,8,("|c00fEBA0E"+GetPlayerName(Player(5))))
call MultiboardSetItemValueBJ(udg_MultiBoard,1,9,("|c0020C000"+GetPlayerName(Player(6))))
call MultiboardSetItemValueBJ(udg_MultiBoard,1,$A,("|c00E55BB0"+GetPlayerName(Player(7))))
call MultiboardSetItemValueBJ(udg_MultiBoard,1,$B,("|c00959697"+GetPlayerName(Player(8))))
call MultiboardSetItemValueBJ(udg_MultiBoard,1,$C,("|c007EBFF1"+GetPlayerName(Player(9))))
call MultiboardSetItemValueBJ(udg_MultiBoard,1,$D,("|c00106246"+GetPlayerName(Player($A))))
call MultiboardSetItemValueBJ(udg_MultiBoard,1,$E,("|c004E2A04"+GetPlayerName(Player($B))))
call MultiboardSetItemValueBJ(udg_MultiBoard,4,1,"K")
call MultiboardSetItemValueBJ(udg_MultiBoard,5,1,"D")
call MultiboardSetItemValueBJ(udg_MultiBoard,6,1,"K(H)")
call MultiboardSetItemValueBJ(udg_MultiBoard,7,1,"D(H)")
call MultiboardSetItemStyleBJ(bj_lastCreatedMultiboard,0,0,true,false)
set udg_List=3
set bj_forLoopAIndex=bj_forLoopAIndex+1
endloop
endfunction
function InitTrig_Multiboard_Create takes nothing returns nothing
set gg_trg_Multiboard_Create=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Multiboard_Create,.3)
call TriggerAddAction(gg_trg_Multiboard_Create,function Trig_Multiboard_Create_Actions)
endfunction
function Trig_K_Actions takes nothing returns nothing
set udg_Kill[(1+GetPlayerId(GetOwningPlayer(GetKillingUnit())))]=(udg_Kill[(1+GetPlayerId(GetOwningPlayer(GetKillingUnit())))]+1)
set udg_Death[(1+GetPlayerId(GetOwningPlayer(GetTriggerUnit())))]=(udg_Death[(1+GetPlayerId(GetOwningPlayer(GetTriggerUnit())))]+1)
endfunction
function InitTrig_K takes nothing returns nothing
set gg_trg_K=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_K,EVENT_PLAYER_UNIT_DEATH)
call TriggerAddAction(gg_trg_K,function Trig_K_Actions)
endfunction
function Trig_KH_Conditions takes nothing returns boolean
return(IsUnitType(GetDyingUnit(),UNIT_TYPE_HERO))!=null
endfunction
function Trig_KH_Actions takes nothing returns nothing
set udg_Kills[(1+GetPlayerId(GetOwningPlayer(GetKillingUnit())))]=(udg_Kills[(1+GetPlayerId(GetOwningPlayer(GetKillingUnit())))]+1)
set udg_Deaths[(1+GetPlayerId(GetOwningPlayer(GetTriggerUnit())))]=(udg_Deaths[(1+GetPlayerId(GetOwningPlayer(GetTriggerUnit())))]+1)
endfunction
function InitTrig_KH takes nothing returns nothing
set gg_trg_KH=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_KH,EVENT_PLAYER_UNIT_DEATH)
call TriggerAddCondition(gg_trg_KH,Condition(function Trig_KH_Conditions))
call TriggerAddAction(gg_trg_KH,function Trig_KH_Actions)
endfunction
function Trig_Update_Actions takes nothing returns nothing
set bj_forLoopAIndex=1
set bj_forLoopAIndexEnd=$C
loop
exitwhen bj_forLoopAIndex>bj_forLoopAIndexEnd
call MultiboardSetItemValueBJ(udg_MultiBoard,4,(bj_forLoopAIndex+2),I2S(udg_Kill[bj_forLoopAIndex]))
set bj_forLoopAIndex=bj_forLoopAIndex+1
endloop
set bj_forLoopAIndex=1
set bj_forLoopAIndexEnd=$C
loop
exitwhen bj_forLoopAIndex>bj_forLoopAIndexEnd
call MultiboardSetItemValueBJ(udg_MultiBoard,5,(bj_forLoopAIndex+2),I2S(udg_Death[bj_forLoopAIndex]))
set bj_forLoopAIndex=bj_forLoopAIndex+1
endloop
endfunction
function InitTrig_Update takes nothing returns nothing
set gg_trg_Update=CreateTrigger()
call TriggerRegisterTimerEventPeriodic(gg_trg_Update,1.)
call TriggerAddAction(gg_trg_Update,function Trig_Update_Actions)
endfunction
function Trig_Update2_Actions takes nothing returns nothing
set bj_forLoopAIndex=1
set bj_forLoopAIndexEnd=$C
loop
exitwhen bj_forLoopAIndex>bj_forLoopAIndexEnd
call MultiboardSetItemValueBJ(udg_MultiBoard,6,(bj_forLoopAIndex+2),I2S(udg_Kills[bj_forLoopAIndex]))
set bj_forLoopAIndex=bj_forLoopAIndex+1
endloop
set bj_forLoopAIndex=1
set bj_forLoopAIndexEnd=$C
loop
exitwhen bj_forLoopAIndex>bj_forLoopAIndexEnd
call MultiboardSetItemValueBJ(udg_MultiBoard,7,(bj_forLoopAIndex+2),I2S(udg_Deaths[bj_forLoopAIndex]))
set bj_forLoopAIndex=bj_forLoopAIndex+1
endloop
endfunction
function InitTrig_Update2 takes nothing returns nothing
set gg_trg_Update2=CreateTrigger()
call TriggerRegisterTimerEventPeriodic(gg_trg_Update2,1.)
call TriggerAddAction(gg_trg_Update2,function Trig_Update2_Actions)
endfunction
function Trig_AutoAlly_Copier_____________________u_Func004003003001 takes nothing returns boolean
return(bj_forLoopAIndex!=bj_forLoopBIndex)
endfunction
function Trig_AutoAlly_Copier_____________________u_Func005003003001 takes nothing returns boolean
return(bj_forLoopAIndex!=bj_forLoopBIndex)
endfunction
function Trig_AutoAlly_Copier_____________________u_Actions takes nothing returns nothing
call SetMapFlag(MAP_LOCK_ALLIANCE_CHANGES,false)
call SetMapFlag(MAP_ALLIANCE_CHANGES_HIDDEN,true)
set bj_forLoopAIndex=1
set bj_forLoopAIndexEnd=$C
loop
exitwhen bj_forLoopAIndex>bj_forLoopAIndexEnd
set bj_forLoopBIndex=1
set bj_forLoopBIndexEnd=$C
loop
exitwhen bj_forLoopBIndex>bj_forLoopBIndexEnd
if(Trig_AutoAlly_Copier_____________________u_Func004003003001())then
call SetPlayerAllianceStateBJ(Player(-1+(bj_forLoopAIndex)),Player(-1+(bj_forLoopBIndex)),2)
endif
set bj_forLoopBIndex=bj_forLoopBIndex+1
endloop
set bj_forLoopAIndex=bj_forLoopAIndex+1
endloop
set bj_forLoopAIndex=1
set bj_forLoopAIndexEnd=$C
loop
exitwhen bj_forLoopAIndex>bj_forLoopAIndexEnd
set bj_forLoopBIndex=1
set bj_forLoopBIndexEnd=$C
loop
exitwhen bj_forLoopBIndex>bj_forLoopBIndexEnd
if(Trig_AutoAlly_Copier_____________________u_Func005003003001())then
call SetPlayerAllianceStateBJ(Player(-1+(bj_forLoopAIndex)),Player(-1+(bj_forLoopBIndex)),2)
endif
set bj_forLoopBIndex=bj_forLoopBIndex+1
endloop
set bj_forLoopAIndex=bj_forLoopAIndex+1
endloop
call TriggerExecute(gg_trg_Turn_On)
endfunction
function InitTrig_AutoAlly_Copier_____________________u takes nothing returns nothing
set gg_trg_AutoAlly_Copier_____________________u=CreateTrigger()
call TriggerAddAction(gg_trg_AutoAlly_Copier_____________________u,function Trig_AutoAlly_Copier_____________________u_Actions)
endfunction
function Trig_Declare_War_1_____________________u_Func003001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_1_____________________u_Func003002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_1_____________________u_Func003002 takes nothing returns nothing
if(Trig_Declare_War_1_____________________u_Func003002001())then
call DisplayTimedTextToForce(GetForceOfPlayer(GetEnumPlayer()),10.,(GetPlayerName(udg_Instagator)+"|c00FF0000Обьявил вам войну|r !"))
endif
endfunction
function Trig_Declare_War_1_____________________u_Func004001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_1_____________________u_Func004002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_1_____________________u_Func004002 takes nothing returns nothing
if(Trig_Declare_War_1_____________________u_Func004002001())then
call SetPlayerAllianceStateBJ(GetEnumPlayer(),udg_Instagator,0)
endif
endfunction
function Trig_Declare_War_1_____________________u_Actions takes nothing returns nothing
call TriggerExecute(gg_trg_Turn_Off)
set udg_Instagator=Player(0)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_1_____________________u_Func003001001)),function Trig_Declare_War_1_____________________u_Func003002)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_1_____________________u_Func004001001)),function Trig_Declare_War_1_____________________u_Func004002)
call TriggerExecute(gg_trg_Turn_On)
endfunction
function InitTrig_Declare_War_1_____________________u takes nothing returns nothing
set gg_trg_Declare_War_1_____________________u=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_1_____________________u)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_1_____________________u,Player(0))
call TriggerAddAction(gg_trg_Declare_War_1_____________________u,function Trig_Declare_War_1_____________________u_Actions)
endfunction
function Trig_Declare_War_2_____________________u_Func004001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_2_____________________u_Func004002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_2_____________________u_Func004002 takes nothing returns nothing
if(Trig_Declare_War_2_____________________u_Func004002001())then
call DisplayTimedTextToForce(GetForceOfPlayer(GetEnumPlayer()),10.,(GetPlayerName(udg_Instagator)+"|c00FF0000Обьявил вам войну|r !"))
endif
endfunction
function Trig_Declare_War_2_____________________u_Func005001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_2_____________________u_Func005002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_2_____________________u_Func005002 takes nothing returns nothing
if(Trig_Declare_War_2_____________________u_Func005002001())then
call SetPlayerAllianceStateBJ(GetEnumPlayer(),udg_Instagator,0)
endif
endfunction
function Trig_Declare_War_2_____________________u_Actions takes nothing returns nothing
call TriggerExecute(gg_trg_Turn_Off)
set udg_Instagator=Player(1)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_2_____________________u_Func004001001)),function Trig_Declare_War_2_____________________u_Func004002)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_2_____________________u_Func005001001)),function Trig_Declare_War_2_____________________u_Func005002)
call TriggerExecute(gg_trg_Turn_On)
endfunction
function InitTrig_Declare_War_2_____________________u takes nothing returns nothing
set gg_trg_Declare_War_2_____________________u=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_2_____________________u)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_2_____________________u,Player(1))
call TriggerAddAction(gg_trg_Declare_War_2_____________________u,function Trig_Declare_War_2_____________________u_Actions)
endfunction
function Trig_Declare_War_3_____________________u_Func003001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_3_____________________u_Func003002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_3_____________________u_Func003002 takes nothing returns nothing
if(Trig_Declare_War_3_____________________u_Func003002001())then
call DisplayTimedTextToForce(GetForceOfPlayer(GetEnumPlayer()),10.,(GetPlayerName(udg_Instagator)+"|c00FF0000Обьявил вам войну|r !"))
endif
endfunction
function Trig_Declare_War_3_____________________u_Func004001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_3_____________________u_Func004002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_3_____________________u_Func004002 takes nothing returns nothing
if(Trig_Declare_War_3_____________________u_Func004002001())then
call SetPlayerAllianceStateBJ(GetEnumPlayer(),udg_Instagator,0)
endif
endfunction
function Trig_Declare_War_3_____________________u_Actions takes nothing returns nothing
call TriggerExecute(gg_trg_Turn_Off)
set udg_Instagator=Player(2)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_3_____________________u_Func003001001)),function Trig_Declare_War_3_____________________u_Func003002)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_3_____________________u_Func004001001)),function Trig_Declare_War_3_____________________u_Func004002)
call TriggerExecute(gg_trg_Turn_On)
endfunction
function InitTrig_Declare_War_3_____________________u takes nothing returns nothing
set gg_trg_Declare_War_3_____________________u=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_3_____________________u)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_3_____________________u,Player(2))
call TriggerAddAction(gg_trg_Declare_War_3_____________________u,function Trig_Declare_War_3_____________________u_Actions)
endfunction
function Trig_Declare_War_4_____________________u_Func003001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_4_____________________u_Func003002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_4_____________________u_Func003002 takes nothing returns nothing
if(Trig_Declare_War_4_____________________u_Func003002001())then
call DisplayTimedTextToForce(GetForceOfPlayer(GetEnumPlayer()),10.,(GetPlayerName(udg_Instagator)+"|c00FF0000Обьявил вам войну|r !"))
endif
endfunction
function Trig_Declare_War_4_____________________u_Func004001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_4_____________________u_Func004002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_4_____________________u_Func004002 takes nothing returns nothing
if(Trig_Declare_War_4_____________________u_Func004002001())then
call SetPlayerAllianceStateBJ(GetEnumPlayer(),udg_Instagator,0)
endif
endfunction
function Trig_Declare_War_4_____________________u_Actions takes nothing returns nothing
call TriggerExecute(gg_trg_Turn_Off)
set udg_Instagator=Player(3)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_4_____________________u_Func003001001)),function Trig_Declare_War_4_____________________u_Func003002)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_4_____________________u_Func004001001)),function Trig_Declare_War_4_____________________u_Func004002)
call TriggerExecute(gg_trg_Turn_On)
endfunction
function InitTrig_Declare_War_4_____________________u takes nothing returns nothing
set gg_trg_Declare_War_4_____________________u=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_4_____________________u)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_4_____________________u,Player(3))
call TriggerAddAction(gg_trg_Declare_War_4_____________________u,function Trig_Declare_War_4_____________________u_Actions)
endfunction
function Trig_Declare_War_5_____________________u_Func003001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_5_____________________u_Func003002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_5_____________________u_Func003002 takes nothing returns nothing
if(Trig_Declare_War_5_____________________u_Func003002001())then
call DisplayTimedTextToForce(GetForceOfPlayer(GetEnumPlayer()),10.,(GetPlayerName(udg_Instagator)+"|c00FF0000Обьявил вам войну|r !"))
endif
endfunction
function Trig_Declare_War_5_____________________u_Func004001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_5_____________________u_Func004002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_5_____________________u_Func004002 takes nothing returns nothing
if(Trig_Declare_War_5_____________________u_Func004002001())then
call SetPlayerAllianceStateBJ(GetEnumPlayer(),udg_Instagator,0)
endif
endfunction
function Trig_Declare_War_5_____________________u_Actions takes nothing returns nothing
call TriggerExecute(gg_trg_Turn_Off)
set udg_Instagator=Player(4)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_5_____________________u_Func003001001)),function Trig_Declare_War_5_____________________u_Func003002)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_5_____________________u_Func004001001)),function Trig_Declare_War_5_____________________u_Func004002)
call TriggerExecute(gg_trg_Turn_On)
endfunction
function InitTrig_Declare_War_5_____________________u takes nothing returns nothing
set gg_trg_Declare_War_5_____________________u=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_5_____________________u)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_5_____________________u,Player(4))
call TriggerAddAction(gg_trg_Declare_War_5_____________________u,function Trig_Declare_War_5_____________________u_Actions)
endfunction
function Trig_Declare_War_6_____________________u_Func003001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_6_____________________u_Func003002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_6_____________________u_Func003002 takes nothing returns nothing
if(Trig_Declare_War_6_____________________u_Func003002001())then
call DisplayTimedTextToForce(GetForceOfPlayer(GetEnumPlayer()),10.,(GetPlayerName(udg_Instagator)+"|c00FF0000Обьявил вам войну|r !"))
endif
endfunction
function Trig_Declare_War_6_____________________u_Func004001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_6_____________________u_Func004002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_6_____________________u_Func004002 takes nothing returns nothing
if(Trig_Declare_War_6_____________________u_Func004002001())then
call SetPlayerAllianceStateBJ(GetEnumPlayer(),udg_Instagator,0)
endif
endfunction
function Trig_Declare_War_6_____________________u_Actions takes nothing returns nothing
call TriggerExecute(gg_trg_Turn_Off)
set udg_Instagator=Player(5)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_6_____________________u_Func003001001)),function Trig_Declare_War_6_____________________u_Func003002)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_6_____________________u_Func004001001)),function Trig_Declare_War_6_____________________u_Func004002)
call TriggerExecute(gg_trg_Turn_On)
endfunction
function InitTrig_Declare_War_6_____________________u takes nothing returns nothing
set gg_trg_Declare_War_6_____________________u=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_6_____________________u)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_6_____________________u,Player(5))
call TriggerAddAction(gg_trg_Declare_War_6_____________________u,function Trig_Declare_War_6_____________________u_Actions)
endfunction
function Trig_Declare_War_7_____________________u_Func003001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_7_____________________u_Func003002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_7_____________________u_Func003002 takes nothing returns nothing
if(Trig_Declare_War_7_____________________u_Func003002001())then
call DisplayTimedTextToForce(GetForceOfPlayer(GetEnumPlayer()),10.,(GetPlayerName(udg_Instagator)+"|c00FF0000Обьявил вам войну|r !"))
endif
endfunction
function Trig_Declare_War_7_____________________u_Func004001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_7_____________________u_Func004002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_7_____________________u_Func004002 takes nothing returns nothing
if(Trig_Declare_War_7_____________________u_Func004002001())then
call SetPlayerAllianceStateBJ(GetEnumPlayer(),udg_Instagator,0)
endif
endfunction
function Trig_Declare_War_7_____________________u_Actions takes nothing returns nothing
call TriggerExecute(gg_trg_Turn_Off)
set udg_Instagator=Player(6)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_7_____________________u_Func003001001)),function Trig_Declare_War_7_____________________u_Func003002)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_7_____________________u_Func004001001)),function Trig_Declare_War_7_____________________u_Func004002)
call TriggerExecute(gg_trg_Turn_On)
endfunction
function InitTrig_Declare_War_7_____________________u takes nothing returns nothing
set gg_trg_Declare_War_7_____________________u=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_7_____________________u)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_7_____________________u,Player(6))
call TriggerAddAction(gg_trg_Declare_War_7_____________________u,function Trig_Declare_War_7_____________________u_Actions)
endfunction
function Trig_Declare_War_8_____________________u_Func003001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_8_____________________u_Func003002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_8_____________________u_Func003002 takes nothing returns nothing
if(Trig_Declare_War_8_____________________u_Func003002001())then
call DisplayTimedTextToForce(GetForceOfPlayer(GetEnumPlayer()),10.,(GetPlayerName(udg_Instagator)+"|c00FF0000Обьявил вам войну|r !"))
endif
endfunction
function Trig_Declare_War_8_____________________u_Func004001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_8_____________________u_Func004002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_8_____________________u_Func004002 takes nothing returns nothing
if(Trig_Declare_War_8_____________________u_Func004002001())then
call SetPlayerAllianceStateBJ(GetEnumPlayer(),udg_Instagator,0)
endif
endfunction
function Trig_Declare_War_8_____________________u_Actions takes nothing returns nothing
call TriggerExecute(gg_trg_Turn_Off)
set udg_Instagator=Player(7)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_8_____________________u_Func003001001)),function Trig_Declare_War_8_____________________u_Func003002)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_8_____________________u_Func004001001)),function Trig_Declare_War_8_____________________u_Func004002)
call TriggerExecute(gg_trg_Turn_On)
endfunction
function InitTrig_Declare_War_8_____________________u takes nothing returns nothing
set gg_trg_Declare_War_8_____________________u=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_8_____________________u)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_8_____________________u,Player(7))
call TriggerAddAction(gg_trg_Declare_War_8_____________________u,function Trig_Declare_War_8_____________________u_Actions)
endfunction
function Trig_Declare_War_9_____________________u_Func003001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_9_____________________u_Func003002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_9_____________________u_Func003002 takes nothing returns nothing
if(Trig_Declare_War_9_____________________u_Func003002001())then
call DisplayTimedTextToForce(GetForceOfPlayer(GetEnumPlayer()),10.,(GetPlayerName(udg_Instagator)+"|c00FF0000Обьявил вам войну|r !"))
endif
endfunction
function Trig_Declare_War_9_____________________u_Func004001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_9_____________________u_Func004002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_9_____________________u_Func004002 takes nothing returns nothing
if(Trig_Declare_War_9_____________________u_Func004002001())then
call SetPlayerAllianceStateBJ(GetEnumPlayer(),udg_Instagator,0)
endif
endfunction
function Trig_Declare_War_9_____________________u_Actions takes nothing returns nothing
call TriggerExecute(gg_trg_Turn_Off)
set udg_Instagator=Player(8)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_9_____________________u_Func003001001)),function Trig_Declare_War_9_____________________u_Func003002)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_9_____________________u_Func004001001)),function Trig_Declare_War_9_____________________u_Func004002)
call TriggerExecute(gg_trg_Turn_On)
endfunction
function InitTrig_Declare_War_9_____________________u takes nothing returns nothing
set gg_trg_Declare_War_9_____________________u=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_9_____________________u)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_9_____________________u,Player(8))
call TriggerAddAction(gg_trg_Declare_War_9_____________________u,function Trig_Declare_War_9_____________________u_Actions)
endfunction
function Trig_Declare_War_10_____________________u_Func003001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_10_____________________u_Func003002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_10_____________________u_Func003002 takes nothing returns nothing
if(Trig_Declare_War_10_____________________u_Func003002001())then
call DisplayTimedTextToForce(GetForceOfPlayer(GetEnumPlayer()),10.,(GetPlayerName(udg_Instagator)+"|c00FF0000Обьявил вам войну|r !"))
endif
endfunction
function Trig_Declare_War_10_____________________u_Func004001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_10_____________________u_Func004002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_10_____________________u_Func004002 takes nothing returns nothing
if(Trig_Declare_War_10_____________________u_Func004002001())then
call SetPlayerAllianceStateBJ(GetEnumPlayer(),udg_Instagator,0)
endif
endfunction
function Trig_Declare_War_10_____________________u_Actions takes nothing returns nothing
call TriggerExecute(gg_trg_Turn_Off)
set udg_Instagator=Player(9)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_10_____________________u_Func003001001)),function Trig_Declare_War_10_____________________u_Func003002)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_10_____________________u_Func004001001)),function Trig_Declare_War_10_____________________u_Func004002)
call TriggerExecute(gg_trg_Turn_On)
endfunction
function InitTrig_Declare_War_10_____________________u takes nothing returns nothing
set gg_trg_Declare_War_10_____________________u=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_10_____________________u)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_10_____________________u,Player(9))
call TriggerAddAction(gg_trg_Declare_War_10_____________________u,function Trig_Declare_War_10_____________________u_Actions)
endfunction
function Trig_Declare_War_11_____________________u_Func003001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_11_____________________u_Func003002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_11_____________________u_Func003002 takes nothing returns nothing
if(Trig_Declare_War_11_____________________u_Func003002001())then
call DisplayTimedTextToForce(GetForceOfPlayer(GetEnumPlayer()),10.,(GetPlayerName(udg_Instagator)+"|c00FF0000Обьявил вам войну|r !"))
endif
endfunction
function Trig_Declare_War_11_____________________u_Func004001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_11_____________________u_Func004002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_11_____________________u_Func004002 takes nothing returns nothing
if(Trig_Declare_War_11_____________________u_Func004002001())then
call SetPlayerAllianceStateBJ(GetEnumPlayer(),udg_Instagator,0)
endif
endfunction
function Trig_Declare_War_11_____________________u_Actions takes nothing returns nothing
call TriggerExecute(gg_trg_Turn_Off)
set udg_Instagator=Player($A)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_11_____________________u_Func003001001)),function Trig_Declare_War_11_____________________u_Func003002)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_11_____________________u_Func004001001)),function Trig_Declare_War_11_____________________u_Func004002)
call TriggerExecute(gg_trg_Turn_On)
endfunction
function InitTrig_Declare_War_11_____________________u takes nothing returns nothing
set gg_trg_Declare_War_11_____________________u=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_11_____________________u)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_11_____________________u,Player($A))
call TriggerAddAction(gg_trg_Declare_War_11_____________________u,function Trig_Declare_War_11_____________________u_Actions)
endfunction
function Trig_Declare_War_12_____________________u_Func003001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_12_____________________u_Func003002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_12_____________________u_Func003002 takes nothing returns nothing
if(Trig_Declare_War_12_____________________u_Func003002001())then
call DisplayTimedTextToForce(GetForceOfPlayer(GetEnumPlayer()),10.,(GetPlayerName(udg_Instagator)+"|c00FF0000Обьявил вам войну|r !"))
endif
endfunction
function Trig_Declare_War_12_____________________u_Func004001001 takes nothing returns boolean
return(GetPlayerAlliance(udg_Instagator,GetFilterPlayer(),ALLIANCE_PASSIVE)==false)
endfunction
function Trig_Declare_War_12_____________________u_Func004002001 takes nothing returns boolean
return(GetPlayerAlliance(GetEnumPlayer(),udg_Instagator,ALLIANCE_PASSIVE))
endfunction
function Trig_Declare_War_12_____________________u_Func004002 takes nothing returns nothing
if(Trig_Declare_War_12_____________________u_Func004002001())then
call SetPlayerAllianceStateBJ(GetEnumPlayer(),udg_Instagator,0)
endif
endfunction
function Trig_Declare_War_12_____________________u_Actions takes nothing returns nothing
call TriggerExecute(gg_trg_Turn_Off)
set udg_Instagator=Player($B)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_12_____________________u_Func003001001)),function Trig_Declare_War_12_____________________u_Func003002)
call ForForce(GetPlayersMatching(Condition(function Trig_Declare_War_12_____________________u_Func004001001)),function Trig_Declare_War_12_____________________u_Func004002)
call TriggerExecute(gg_trg_Turn_On)
endfunction
function InitTrig_Declare_War_12_____________________u takes nothing returns nothing
set gg_trg_Declare_War_12_____________________u=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_12_____________________u)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_12_____________________u,Player($B))
call TriggerAddAction(gg_trg_Declare_War_12_____________________u,function Trig_Declare_War_12_____________________u_Actions)
endfunction
function Trig_Turn_On_____________________u_Actions takes nothing returns nothing
call EnableTrigger(gg_trg_Declare_War_1)
call EnableTrigger(gg_trg_Declare_War_2)
call EnableTrigger(gg_trg_Declare_War_3)
call EnableTrigger(gg_trg_Declare_War_4)
call EnableTrigger(gg_trg_Declare_War_5)
call EnableTrigger(gg_trg_Declare_War_6)
call EnableTrigger(gg_trg_Declare_War_7)
call EnableTrigger(gg_trg_Declare_War_8)
call EnableTrigger(gg_trg_Declare_War_9)
call EnableTrigger(gg_trg_Declare_War_10)
call EnableTrigger(gg_trg_Declare_War_11)
call EnableTrigger(gg_trg_Declare_War_12)
endfunction
function InitTrig_Turn_On_____________________u takes nothing returns nothing
set gg_trg_Turn_On_____________________u=CreateTrigger()
call TriggerAddAction(gg_trg_Turn_On_____________________u,function Trig_Turn_On_____________________u_Actions)
endfunction
function Trig_Turn_Off_____________________u_Actions takes nothing returns nothing
call DisableTrigger(gg_trg_Declare_War_1)
call DisableTrigger(gg_trg_Declare_War_2)
call DisableTrigger(gg_trg_Declare_War_3)
call DisableTrigger(gg_trg_Declare_War_4)
call DisableTrigger(gg_trg_Declare_War_5)
call DisableTrigger(gg_trg_Declare_War_6)
call DisableTrigger(gg_trg_Declare_War_7)
call DisableTrigger(gg_trg_Declare_War_8)
call DisableTrigger(gg_trg_Declare_War_9)
call DisableTrigger(gg_trg_Declare_War_10)
call DisableTrigger(gg_trg_Declare_War_11)
call DisableTrigger(gg_trg_Declare_War_12)
endfunction
function InitTrig_Turn_Off_____________________u takes nothing returns nothing
set gg_trg_Turn_Off_____________________u=CreateTrigger()
call TriggerAddAction(gg_trg_Turn_Off_____________________u,function Trig_Turn_Off_____________________u_Actions)
endfunction
function Trig_Voina23_Func004C takes nothing returns boolean
return(GetPlayerName(GetTriggerPlayer())=="Voina23")
endfunction
function Trig_Voina23_Conditions takes nothing returns boolean
return(Trig_Voina23_Func004C())
endfunction
function Trig_Voina23_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(1,'H090',GetTriggerPlayer(),GetRectCenter(gg_rct_HeroByCommand1),bj_UNIT_FACING)
call TriggerSleepAction(.05)
call DisableTrigger(GetTriggeringTrigger())
endfunction
function InitTrig_Voina23 takes nothing returns nothing
set gg_trg_Voina23=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Voina23,Player(0),"-Egor",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Voina23,Player(1),"-Egor",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Voina23,Player(2),"-Egor",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Voina23,Player(3),"-Egor",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Voina23,Player(4),"-Egor",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Voina23,Player(5),"-Egor",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Voina23,Player(6),"-Egor",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Voina23,Player(7),"-Egor",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Voina23,Player(8),"-Egor",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Voina23,Player(9),"-Egor",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Voina23,Player($A),"-Egor",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Voina23,Player($B),"-Egor",true)
call TriggerAddCondition(gg_trg_Voina23,Condition(function Trig_Voina23_Conditions))
call TriggerAddAction(gg_trg_Voina23,function Trig_Voina23_Actions)
endfunction
function Trig_NochangeName6_Actions takes nothing returns nothing
call TriggerSleepAction(.1)
call SetPlayerName(GetTriggerPlayer(),"Ошибка")
endfunction
function InitTrig_NochangeName6 takes nothing returns nothing
set gg_trg_NochangeName6=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName6,Player(0),"-name Voina23",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName6,Player(1),"-name Voina23",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName6,Player(2),"-name Voina23",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName6,Player(3),"-name Voina23",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName6,Player(4),"-name Voina23",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName6,Player(5),"-name Voina23",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName6,Player(6),"-name Voina23",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName6,Player(7),"-name Voina23",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName6,Player(8),"-name Voina23",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName6,Player(9),"-name Voina23",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName6,Player($A),"-name Voina23",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName6,Player($B),"-name Voina23",true)
call TriggerAddAction(gg_trg_NochangeName6,function Trig_NochangeName6_Actions)
endfunction
function Trig_gordik0101_Func004C takes nothing returns boolean
return(GetPlayerName(GetTriggerPlayer())=="gordik0101")
endfunction
function Trig_gordik0101_Conditions takes nothing returns boolean
return(Trig_gordik0101_Func004C())
endfunction
function Trig_gordik0101_Actions takes nothing returns nothing
call CreateNUnitsAtLoc(1,'E00G',GetTriggerPlayer(),GetRectCenter(gg_rct_HeroByCommand2),bj_UNIT_FACING)
call TriggerSleepAction(.05)
call DisableTrigger(GetTriggeringTrigger())
endfunction
function InitTrig_gordik0101 takes nothing returns nothing
set gg_trg_gordik0101=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_gordik0101,Player(0),"-Dima",true)
call TriggerRegisterPlayerChatEvent(gg_trg_gordik0101,Player(1),"-Dima",true)
call TriggerRegisterPlayerChatEvent(gg_trg_gordik0101,Player(2),"-Dima",true)
call TriggerRegisterPlayerChatEvent(gg_trg_gordik0101,Player(3),"-Dima",true)
call TriggerRegisterPlayerChatEvent(gg_trg_gordik0101,Player(4),"-Dima",true)
call TriggerRegisterPlayerChatEvent(gg_trg_gordik0101,Player(5),"-Dima",true)
call TriggerRegisterPlayerChatEvent(gg_trg_gordik0101,Player(6),"-Dima",true)
call TriggerRegisterPlayerChatEvent(gg_trg_gordik0101,Player(7),"-Dima",true)
call TriggerRegisterPlayerChatEvent(gg_trg_gordik0101,Player(8),"-Dima",true)
call TriggerRegisterPlayerChatEvent(gg_trg_gordik0101,Player(9),"-Dima",true)
call TriggerRegisterPlayerChatEvent(gg_trg_gordik0101,Player($A),"-Dima",true)
call TriggerRegisterPlayerChatEvent(gg_trg_gordik0101,Player($B),"-Dima",true)
call TriggerAddCondition(gg_trg_gordik0101,Condition(function Trig_gordik0101_Conditions))
call TriggerAddAction(gg_trg_gordik0101,function Trig_gordik0101_Actions)
endfunction
function InitCustomTriggers takes nothing returns nothing
call InitTrig_Information()
call InitTrig_Tekst()
call InitTrig_Start()
call InitTrig_Time_f1()
call InitTrig_Time_f2()
call InitTrig_Time_f4()
call InitTrig_Time_f5()
call InitTrig_Time_f6()
call InitTrig_Time_f7()
call InitTrig_Time_f8()
call InitTrig_Liver_Player()
call InitTrig_AuthorVision()
call InitTrig_SpawnVision()
call InitTrig_NochangeName1()
call InitTrig_NochangeName2()
call InitTrig_NochangeName3()
call InitTrig_NochangeName4()
call InitTrig_NochangeName5()
call InitTrig_NochangeName8()
call InitTrig_Human()
call InitTrig_Orc()
call InitTrig_Undead()
call InitTrig_NightElf()
call InitTrig_Nerubian()
call InitTrig_Dwarfen()
call InitTrig_Naga()
call InitTrig_ScorgedElf()
call InitTrig_Demon()
call InitTrig_HighElf()
call InitTrig_ForestTroll()
call InitTrig_DarkTroll()
call InitTrig_IceTroll()
call InitTrig_FelOrc()
call InitTrig_Kobold()
call InitTrig_ScarletCrusade()
call InitTrig_Futborg()
call InitTrig_Gnoll()
call InitTrig_Faceless()
call InitTrig_Ogre()
call InitTrig_Draenei()
call InitTrig_Bandite()
call InitTrig_Tauren()
call InitTrig_Pandaren()
call InitTrig_Goblin()
call InitTrig_Murloc()
call InitTrig_Centaur()
call InitTrig_Illidari()
call InitTrig_Worgen()
call InitTrig_Forsaken()
call InitTrig_Elemental()
call InitTrig_Quraji()
call InitTrig_DarkDwarf()
call InitTrig_TwilightHammer()
call InitTrig_Hostkick1()
call InitTrig_Hostkick2()
call InitTrig_Hostkick3()
call InitTrig_Hostkick4()
call InitTrig_Hostkick5()
call InitTrig_Hostkick6()
call InitTrig_Hostkick7()
call InitTrig_Hostkick8()
call InitTrig_Hostkick9()
call InitTrig_Hostkick10()
call InitTrig_Hostkick11()
call InitTrig_Hostkick12()
call InitTrig_destroy_1()
call InitTrig_Timedestroy()
call InitTrig_Debut()
call InitTrig_Revenus()
call InitTrig_ND1()
call InitTrig_ND2()
call InitTrig_ND3()
call InitTrig_ND4()
call InitTrig_ND5()
call InitTrig_ND6()
call InitTrig_ND7()
call InitTrig_ND8()
call InitTrig_ND9()
call InitTrig_KL1()
call InitTrig_KL2()
call InitTrig_KL3()
call InitTrig_KL4()
call InitTrig_KL5()
call InitTrig_KL6()
call InitTrig_KL7()
call InitTrig_KL8()
call InitTrig_KL9()
call InitTrig_KL10()
call InitTrig_KL11()
call InitTrig_KL12()
call InitTrig_KL13()
call InitTrig_KL14()
call InitTrig_PA1()
call InitTrig_PA2()
call InitTrig_PA3()
call InitTrig_PA4()
call InitTrig_PA5()
call InitTrig_BI1()
call InitTrig_BI2()
call InitTrig_BI3()
call InitTrig_BI4()
call InitTrig_BI5()
call InitTrig_Bl6()
call InitTrig_BI7()
call InitTrig_BI8()
call InitTrig_BI9()
call InitTrig_BI10()
call InitTrig_EK1()
call InitTrig_EK2()
call InitTrig_EK3()
call InitTrig_EK4()
call InitTrig_EK5()
call InitTrig_EK6()
call InitTrig_EK7()
call InitTrig_EK8()
call InitTrig_EK9()
call InitTrig_EK10()
call InitTrig_EK11()
call InitTrig_EK12()
call InitTrig_EK13()
call InitTrig_EK14()
call InitTrig_EK15()
call InitTrig_EK16()
call InitTrig_EK17()
call InitTrig_EK18()
call InitTrig_EK19()
call InitTrig_EK20()
call InitTrig_EK21()
call InitTrig_EK22()
call InitTrig_OUT1()
call InitTrig_OUT2()
call InitTrig_OUT3()
call InitTrig_OUT4()
call InitTrig_OUT5()
call InitTrig_OUT6()
call InitTrig_OUT7()
call InitTrig_ZN1()
call InitTrig_VE1()
call InitTrig_KT()
call InitTrig_Managorn1()
call InitTrig_Managorn2()
call InitTrig_Managorn3()
call InitTrig_Managorn4()
call InitTrig_Production_en_chaine()
call InitTrig_Camera_command()
call InitTrig_Name_command()
call InitTrig_Red_color()
call InitTrig_Blue_color()
call InitTrig_Lightblue_color()
call InitTrig_Viol_color()
call InitTrig_Yelow_color()
call InitTrig_Orange_color()
call InitTrig_Green_color()
call InitTrig_Rose_color()
call InitTrig_Grey_color()
call InitTrig_Cyan_color()
call InitTrig_Dark_green_color()
call InitTrig_Brown_color()
call InitTrig_Black_color()
call InitTrig_Turn_On()
call InitTrig_Turn_Off()
call InitTrig_Declare_War_1()
call InitTrig_Declare_War_2()
call InitTrig_Declare_War_5()
call InitTrig_Declare_War_3()
call InitTrig_Declare_War_4()
call InitTrig_Declare_War_6()
call InitTrig_Declare_War_7()
call InitTrig_Declare_War_8()
call InitTrig_Declare_War_9()
call InitTrig_Declare_War_10()
call InitTrig_Declare_War_11()
call InitTrig_Declare_War_12()
call InitTrig_Buildings()
call InitTrig_Heroes()
call InitTrig_Ship()
call InitTrig_Select()
call InitTrig_Race()
call InitTrig_RandomInfo()
call InitTrig_RaceSelect1()
call InitTrig_RaceSelect2()
call InitTrig_RaceSelect3()
call InitTrig_RaceSelect4()
call InitTrig_RaceSelect5()
call InitTrig_RaceSelect6()
call InitTrig_RaceSelect7()
call InitTrig_RaceSelect8()
call InitTrig_RaceSelect9()
call InitTrig_RaceSelect10()
call InitTrig_RaceSelect11()
call InitTrig_RaceSelect12()
call InitTrig_Kil()
call InitTrig_Smertokril()
call InitTrig_LichKing()
call InitTrig_AlAkir()
call InitTrig_Kazzak()
call InitTrig_RAGNAROSS()
call InitTrig_Illidan()
call InitTrig_Soul_Eater()
call InitTrig_ChoGall()
call InitTrig_Kael()
call InitTrig_Kenya()
call InitTrig_Neptulon()
call InitTrig_Terazan()
call InitTrig_Maiev()
call InitTrig_Gandling()
call InitTrig_NZOT()
call InitTrig_NZOT_agent()
call InitTrig_CTUN()
call InitTrig_QOGGSARON()
call InitTrig_SHA()
call InitTrig_ItemCraft1()
call InitTrig_Lich_King()
call InitTrig_Illidan_H()
call InitTrig_Cshi_Fire_Hand()
call InitTrig_Tirion()
call InitTrig_Kern()
call InitTrig_Vaish()
call InitTrig_Saidan()
call InitTrig_Sylvanas()
call InitTrig_Farion()
call InitTrig_Genn()
call InitTrig_Thrall()
call InitTrig_Izjor()
call InitTrig_VanCleef()
call InitTrig_Ursol()
call InitTrig_Vanol()
call InitTrig_Magni()
call InitTrig_DrBoom()
call InitTrig_ChoGallLg()
call InitTrig_Akama()
call InitTrig_Nerub()
call InitTrig_TrollIce()
call InitTrig_TrollDArk()
call InitTrig_TrollForest()
call InitTrig_LorTemarTeron()
call InitTrig_Ksavii()
call InitTrig_Kargath()
call InitTrig_Dagran_Taurissan()
call InitTrig_Multiboard_Create()
call InitTrig_K()
call InitTrig_KH()
call InitTrig_Update()
call InitTrig_Update2()
call InitTrig_AutoAlly_Copier_____________________u()
call InitTrig_Declare_War_1_____________________u()
call InitTrig_Declare_War_2_____________________u()
call InitTrig_Declare_War_3_____________________u()
call InitTrig_Declare_War_4_____________________u()
call InitTrig_Declare_War_5_____________________u()
call InitTrig_Declare_War_6_____________________u()
call InitTrig_Declare_War_7_____________________u()
call InitTrig_Declare_War_8_____________________u()
call InitTrig_Declare_War_9_____________________u()
call InitTrig_Declare_War_10_____________________u()
call InitTrig_Declare_War_11_____________________u()
call InitTrig_Declare_War_12_____________________u()
call InitTrig_Turn_On_____________________u()
call InitTrig_Turn_Off_____________________u()
call InitTrig_Voina23()
call InitTrig_NochangeName6()
call InitTrig_gordik0101()
endfunction
function RunInitializationTriggers takes nothing returns nothing
call ConditionalTriggerExecute(gg_trg_AutoAlly_Copier_____________________u)
endfunction
function InitCustomPlayerSlots takes nothing returns nothing
call SetPlayerStartLocation(Player(0),0)
call ForcePlayerStartLocation(Player(0),0)
call SetPlayerColor(Player(0),ConvertPlayerColor(0))
call SetPlayerRacePreference(Player(0),RACE_PREF_RANDOM)
call SetPlayerRaceSelectable(Player(0),true)
call SetPlayerController(Player(0),MAP_CONTROL_USER)
call SetPlayerStartLocation(Player(1),1)
call ForcePlayerStartLocation(Player(1),1)
call SetPlayerColor(Player(1),ConvertPlayerColor(1))
call SetPlayerRacePreference(Player(1),RACE_PREF_RANDOM)
call SetPlayerRaceSelectable(Player(1),true)
call SetPlayerController(Player(1),MAP_CONTROL_USER)
call SetPlayerStartLocation(Player(2),2)
call ForcePlayerStartLocation(Player(2),2)
call SetPlayerColor(Player(2),ConvertPlayerColor(2))
call SetPlayerRacePreference(Player(2),RACE_PREF_RANDOM)
call SetPlayerRaceSelectable(Player(2),true)
call SetPlayerController(Player(2),MAP_CONTROL_USER)
call SetPlayerStartLocation(Player(3),3)
call ForcePlayerStartLocation(Player(3),3)
call SetPlayerColor(Player(3),ConvertPlayerColor(3))
call SetPlayerRacePreference(Player(3),RACE_PREF_RANDOM)
call SetPlayerRaceSelectable(Player(3),true)
call SetPlayerController(Player(3),MAP_CONTROL_USER)
call SetPlayerStartLocation(Player(4),4)
call ForcePlayerStartLocation(Player(4),4)
call SetPlayerColor(Player(4),ConvertPlayerColor(4))
call SetPlayerRacePreference(Player(4),RACE_PREF_RANDOM)
call SetPlayerRaceSelectable(Player(4),true)
call SetPlayerController(Player(4),MAP_CONTROL_USER)
call SetPlayerStartLocation(Player(5),5)
call ForcePlayerStartLocation(Player(5),5)
call SetPlayerColor(Player(5),ConvertPlayerColor(5))
call SetPlayerRacePreference(Player(5),RACE_PREF_RANDOM)
call SetPlayerRaceSelectable(Player(5),true)
call SetPlayerController(Player(5),MAP_CONTROL_USER)
call SetPlayerStartLocation(Player(6),6)
call ForcePlayerStartLocation(Player(6),6)
call SetPlayerColor(Player(6),ConvertPlayerColor(6))
call SetPlayerRacePreference(Player(6),RACE_PREF_RANDOM)
call SetPlayerRaceSelectable(Player(6),true)
call SetPlayerController(Player(6),MAP_CONTROL_USER)
call SetPlayerStartLocation(Player(7),7)
call ForcePlayerStartLocation(Player(7),7)
call SetPlayerColor(Player(7),ConvertPlayerColor(7))
call SetPlayerRacePreference(Player(7),RACE_PREF_RANDOM)
call SetPlayerRaceSelectable(Player(7),true)
call SetPlayerController(Player(7),MAP_CONTROL_USER)
call SetPlayerStartLocation(Player(8),8)
call ForcePlayerStartLocation(Player(8),8)
call SetPlayerColor(Player(8),ConvertPlayerColor(8))
call SetPlayerRacePreference(Player(8),RACE_PREF_RANDOM)
call SetPlayerRaceSelectable(Player(8),true)
call SetPlayerController(Player(8),MAP_CONTROL_USER)
call SetPlayerStartLocation(Player(9),9)
call ForcePlayerStartLocation(Player(9),9)
call SetPlayerColor(Player(9),ConvertPlayerColor(9))
call SetPlayerRacePreference(Player(9),RACE_PREF_RANDOM)
call SetPlayerRaceSelectable(Player(9),true)
call SetPlayerController(Player(9),MAP_CONTROL_USER)
call SetPlayerStartLocation(Player($A),$A)
call ForcePlayerStartLocation(Player($A),$A)
call SetPlayerColor(Player($A),ConvertPlayerColor($A))
call SetPlayerRacePreference(Player($A),RACE_PREF_RANDOM)
call SetPlayerRaceSelectable(Player($A),true)
call SetPlayerController(Player($A),MAP_CONTROL_USER)
call SetPlayerStartLocation(Player($B),$B)
call ForcePlayerStartLocation(Player($B),$B)
call SetPlayerColor(Player($B),ConvertPlayerColor($B))
call SetPlayerRacePreference(Player($B),RACE_PREF_RANDOM)
call SetPlayerRaceSelectable(Player($B),true)
call SetPlayerController(Player($B),MAP_CONTROL_USER)
endfunction
function InitCustomTeams takes nothing returns nothing
call SetPlayerTeam(Player(0),0)
call SetPlayerTeam(Player(1),1)
call SetPlayerTeam(Player(2),1)
call SetPlayerTeam(Player(3),1)
call SetPlayerTeam(Player(4),1)
call SetPlayerTeam(Player(5),1)
call SetPlayerTeam(Player(6),1)
call SetPlayerTeam(Player(7),1)
call SetPlayerTeam(Player(8),1)
call SetPlayerTeam(Player(9),1)
call SetPlayerTeam(Player($A),1)
call SetPlayerTeam(Player($B),1)
endfunction
function InitAllyPriorities takes nothing returns nothing
call SetStartLocPrioCount(0,2)
call SetStartLocPrio(0,0,1,MAP_LOC_PRIO_HIGH)
call SetStartLocPrio(0,1,$B,MAP_LOC_PRIO_LOW)
call SetStartLocPrioCount(1,1)
call SetStartLocPrio(1,0,0,MAP_LOC_PRIO_HIGH)
call SetStartLocPrioCount(2,2)
call SetStartLocPrio(2,0,3,MAP_LOC_PRIO_HIGH)
call SetStartLocPrio(2,1,4,MAP_LOC_PRIO_LOW)
call SetStartLocPrioCount(3,2)
call SetStartLocPrio(3,0,2,MAP_LOC_PRIO_HIGH)
call SetStartLocPrio(3,1,4,MAP_LOC_PRIO_HIGH)
call SetStartLocPrioCount(4,3)
call SetStartLocPrio(4,0,2,MAP_LOC_PRIO_LOW)
call SetStartLocPrio(4,1,3,MAP_LOC_PRIO_HIGH)
call SetStartLocPrio(4,2,5,MAP_LOC_PRIO_HIGH)
call SetStartLocPrioCount(5,3)
call SetStartLocPrio(5,0,4,MAP_LOC_PRIO_HIGH)
call SetStartLocPrio(5,1,6,MAP_LOC_PRIO_HIGH)
call SetStartLocPrio(5,2,7,MAP_LOC_PRIO_LOW)
call SetStartLocPrioCount(6,2)
call SetStartLocPrio(6,0,5,MAP_LOC_PRIO_HIGH)
call SetStartLocPrio(6,1,7,MAP_LOC_PRIO_HIGH)
call SetStartLocPrioCount(7,3)
call SetStartLocPrio(7,0,5,MAP_LOC_PRIO_LOW)
call SetStartLocPrio(7,1,6,MAP_LOC_PRIO_HIGH)
call SetStartLocPrio(7,2,8,MAP_LOC_PRIO_LOW)
call SetStartLocPrioCount(8,3)
call SetStartLocPrio(8,0,7,MAP_LOC_PRIO_HIGH)
call SetStartLocPrio(8,1,9,MAP_LOC_PRIO_HIGH)
call SetStartLocPrio(8,2,$A,MAP_LOC_PRIO_HIGH)
call SetStartLocPrioCount(9,1)
call SetStartLocPrio(9,0,$A,MAP_LOC_PRIO_HIGH)
call SetStartLocPrioCount($A,2)
call SetStartLocPrio($A,0,9,MAP_LOC_PRIO_HIGH)
call SetStartLocPrio($A,1,$B,MAP_LOC_PRIO_LOW)
call SetStartLocPrioCount($B,2)
call SetStartLocPrio($B,0,0,MAP_LOC_PRIO_LOW)
call SetStartLocPrio($B,1,$A,MAP_LOC_PRIO_HIGH)
endfunction
function main takes nothing returns nothing
local weathereffect we
local destructable d
local trigger t
local real life
local integer i
call SetCameraBounds(-27904.+GetCameraMargin(CAMERA_MARGIN_LEFT),-28672.+GetCameraMargin(CAMERA_MARGIN_BOTTOM),27904.-GetCameraMargin(CAMERA_MARGIN_RIGHT),30720.-GetCameraMargin(CAMERA_MARGIN_TOP),-27904.+GetCameraMargin(CAMERA_MARGIN_LEFT),30720.-GetCameraMargin(CAMERA_MARGIN_TOP),27904.-GetCameraMargin(CAMERA_MARGIN_RIGHT),-28672.+GetCameraMargin(CAMERA_MARGIN_BOTTOM))
call SetDayNightModels("Environment\\DNC\\DNCLordaeron\\DNCLordaeronTerrain\\DNCLordaeronTerrain.mdl","Environment\\DNC\\DNCLordaeron\\DNCLordaeronUnit\\DNCLordaeronUnit.mdl")
call NewSoundEnvironment("Default")
call SetAmbientDaySound("VillageDay")
call SetAmbientNightSound("VillageNight")
call SetMapMusic("Music",true,0)
set gg_snd_ArtilleryCorpseExplodeDeath1=CreateSound("Sound\\Units\\Death\\ArtilleryCorpseExplodeDeath1.wav",false,true,true,$A,$A,"DefaultEAXON")
call SetSoundParamsFromLabel(gg_snd_ArtilleryCorpseExplodeDeath1,"ArtilleryExplodeDeath")
call SetSoundDuration(gg_snd_ArtilleryCorpseExplodeDeath1,$5CE)
set gg_snd_PeasantWarcry1=CreateSound("Units\\Human\\Peasant\\PeasantWarcry1.wav",false,true,true,$A,$A,"DefaultEAXON")
call SetSoundParamsFromLabel(gg_snd_PeasantWarcry1,"PeasantWarcry")
call SetSoundDuration(gg_snd_PeasantWarcry1,$49E)
set gg_snd_PeasantYes1=CreateSound("Units\\Human\\Peasant\\PeasantYes1.wav",false,true,true,$A,$A,"DefaultEAXON")
call SetSoundParamsFromLabel(gg_snd_PeasantYes1,"PeasantYes")
call SetSoundDuration(gg_snd_PeasantYes1,373)
set gg_snd_PeasantYesAttack4=CreateSound("Units\\Human\\Peasant\\PeasantYesAttack4.wav",false,true,true,$A,$A,"DefaultEAXON")
call SetSoundParamsFromLabel(gg_snd_PeasantYesAttack4,"PeasantYesAttack")
call SetSoundDuration(gg_snd_PeasantYesAttack4,$75E)
set gg_snd_HeroFarseerPissed1=CreateSound("Units\\Orc\\HeroFarseer\\HeroFarseerPissed1.wav",false,true,true,$A,$A,"HeroAcksEAX")
call SetSoundParamsFromLabel(gg_snd_HeroFarseerPissed1,"HeroFarseerPissed")
call SetSoundDuration(gg_snd_HeroFarseerPissed1,$F11)
set gg_snd_HPitLordYesAttack1=CreateSound("Units\\Demon\\HeroPitLord\\HPitLordYesAttack1.wav",false,true,true,$A,$A,"HeroAcksEAX")
call SetSoundParamsFromLabel(gg_snd_HPitLordYesAttack1,"HeroPitLordYesAttack")
call SetSoundDuration(gg_snd_HPitLordYesAttack1,$67A)
set gg_snd_A07Kiljaeden30=CreateSound("Sound\\Dialogue\\HumanExpCamp\\Human07xInterlude\\A07Kiljaeden30.mp3",false,false,false,$A,$A,"")
call SetSoundParamsFromLabel(gg_snd_A07Kiljaeden30,"A07Kiljaeden30")
call SetSoundDuration(gg_snd_A07Kiljaeden30,$43DB)
set gg_snd_zsukdarkportal=CreateSound("war3mapImported\\zsukdarkportal.mp3",false,false,false,$A,$A,"")
call SetSoundChannel(gg_snd_zsukdarkportal,0)
call SetSoundVolume(gg_snd_zsukdarkportal,$7F)
call SetSoundPitch(gg_snd_zsukdarkportal,1.)
set gg_snd_U02KelThuzad27=CreateSound("Sound\\Dialogue\\UndeadCampaign\\Undead02\\U02KelThuzad27.mp3",false,false,false,$A,$A,"")
call SetSoundParamsFromLabel(gg_snd_U02KelThuzad27,"U02KelThuzad27")
call SetSoundDuration(gg_snd_U02KelThuzad27,8594)
set gg_rct_NerubianA1Ext=Rect(-5504.,26688.,-4832.,27424.)
set gg_rct_NerubianA1move=Rect(-6624.,-17152.,-5952.,-16416.)
set gg_rct_NerubianB2Ext=Rect(1216.,28736.,1888.,29472.)
set gg_rct_NerubianB2move=Rect(-3232.,-13888.,-2560.,-13152.)
set gg_rct_NerubianC3Ext=Rect(5184.,23040.,5856.,23776.)
set gg_rct_NerubianC3move=Rect(-1088.,-15680.,-416.,-14944.)
set gg_rct_NorthrendSnow=Rect(-11328.,23840.,7648.,30688.)
set we=AddWeatherEffect(gg_rct_NorthrendSnow,'SNbs')
call EnableWeatherEffect(we,true)
set gg_rct_NorthrendSnow2=Rect(-3360.,22048.,4704.,23968.)
set we=AddWeatherEffect(gg_rct_NorthrendSnow2,'SNbs')
call EnableWeatherEffect(we,true)
set gg_rct_OutlandExt=Rect(22880.,-3328.,23552.,-2688.)
set gg_rct_OutlandMove=Rect(-11648.,-21728.,-10976.,-21088.)
set gg_rct_SpawnPoint_Broken_isles=Rect(4448.,11904.,4832.,12288.)
set gg_rct_SpawnPoint_EasternKingdom1=Rect(15808.,-2080.,16128.,-1760.)
set gg_rct_SpawnPoint_EasternKingdom2=Rect(18464.,11680.,18784.,12000.)
set gg_rct_SpawnPoint_Kalimdor1=Rect(-20864.,2048.,-20480.,2432.)
set gg_rct_SpawnPoint_Kalimdor2=Rect(-14720.,10624.,-14336.,11008.)
set gg_rct_SpawnPoint_Northland1=Rect(-4416.,25024.,-4032.,25408.)
set gg_rct_SpawnPoint_Northland2=Rect(7232.,24352.,7616.,24736.)
set gg_rct_SpawnPoint_Pandaria=Rect(-4096.,-5888.,-3712.,-5504.)
set gg_rct_SpawnVision=Rect(23872.,-28448.,27648.,-24480.)
set gg_rct_KTunRaideExt=Rect(-21888.,-6080.,-21248.,-5440.)
set gg_rct_KTunRaideMove=Rect(-3072.,-21536.,-2336.,-20672.)
set gg_rct_QogSaronMove=Rect(-4032.,-26560.,-3200.,-25664.)
set gg_rct_QogSaronExt=Rect(4800.,29792.,5312.,30368.)
set gg_rct_NZotMove=Rect(832.,-27680.,1664.,-26784.)
set gg_rct_NZotExt=Rect(3424.,960.,4064.,1568.)
set gg_rct_Raide01Move=Rect(480.,-23232.,1312.,-22624.)
set gg_rct_Raide01Ext=Rect(21120.,10176.,21824.,10656.)
set gg_rct_QOGGSARON=Rect(-6816.,-27424.,-3168.,-24864.)
set we=AddWeatherEffect(gg_rct_QOGGSARON,'WNcw')
call EnableWeatherEffect(we,true)
set gg_rct_TEXTKalimdor1=Rect(24320.,-26048.,24576.,-25888.)
set gg_rct_TEXTKalimdor2=Rect(24320.,-27456.,24576.,-27296.)
set gg_rct_TEXTPandaria=Rect(25216.,-27456.,25472.,-27296.)
set gg_rct_TEXTBrokenIsles=Rect(26112.,-27456.,26368.,-27296.)
set gg_rct_TEXTEastKingdom2=Rect(27008.,-27488.,27264.,-27328.)
set gg_rct_TEXTEastKingdom1=Rect(27008.,-26048.,27264.,-25888.)
set gg_rct_TEXTNorth1=Rect(26112.,-26048.,26368.,-25888.)
set gg_rct_TEXTNorth2=Rect(25216.,-26016.,25472.,-25856.)
set gg_rct_SpawnLocation=Rect(25312.,-27232.,26336.,-26208.)
set gg_rct_RAGNAROSS=Rect(4000.,-26976.,4576.,-26240.)
set gg_rct_RAGNAROSS_EXT=Rect(18048.,1984.,18464.,2336.)
set gg_rct_HeroSpawn=Rect(13728.,-28192.,14144.,-27872.)
set gg_rct_VAICHmove=Rect(1664.,-15296.,2432.,-14432.)
set gg_rct_VAICHext=Rect(8288.,1728.,8800.,2304.)
set gg_rct_EarthExt=Rect(-1888.,3264.,-1312.,3712.)
set gg_rct_EarthMove=Rect(8128.,-25184.,8864.,-24512.)
set gg_rct_KazemateMove=Rect(3488.,-21696.,3936.,-21280.)
set gg_rct_KazemateExt=Rect(-192.,6016.,256.,6432.)
set gg_rct_Necrositetext=Rect(19360.,13856.,19712.,14208.)
set gg_rct_Necrositemove=Rect(4992.,-15328.,5600.,-14752.)
set gg_rct_DalaranMove=Rect(13600.,-16064.,14208.,-15552.)
set gg_rct_DalaranExt=Rect(2208.,26688.,2816.,27200.)
set gg_rct_Effect1=Rect(21600.,18016.,22432.,18144.)
set we=AddWeatherEffect(gg_rct_Effect1,'FDrh')
call EnableWeatherEffect(we,true)
set gg_rct_Effect1_____________________u=Rect(19808.,17408.,19872.,17760.)
set we=AddWeatherEffect(gg_rct_Effect1_____________________u,'FDrh')
call EnableWeatherEffect(we,true)
set gg_rct_DalaranEffect=Rect(11424.,-16960.,14144.,-14368.)
set we=AddWeatherEffect(gg_rct_DalaranEffect,'MEds')
call EnableWeatherEffect(we,true)
set gg_rct_UlduarEffect=Rect(1088.,27520.,6368.,30688.)
set we=AddWeatherEffect(gg_rct_UlduarEffect,'WNcw')
call EnableWeatherEffect(we,true)
set gg_rct_Effect=Rect(-24640.,7680.,-21664.,11904.)
set gg_rct_NaxxramasSpellUsePoint=Rect(-1664.,24896.,-1088.,25568.)
set gg_rct_NaxxramasSpawn=Rect(-1536.,25280.,-1344.,25472.)
set gg_rct_Naxxramas=Rect(7808.,-23456.,10144.,-20960.)
set gg_rct_TEXTOutland=Rect(26720.,-26752.,26976.,-26624.)
set gg_rct_Outland=Rect(-20160.,-21792.,-19648.,-21376.)
set gg_rct_NaxxramasEXT=Rect(23008.,16288.,23360.,16640.)
set gg_rct_NaxxramasMOVE=Rect(8768.,-21888.,9120.,-21536.)
set gg_rct_HeroByCommand1=Rect(19136.,-3616.,19392.,-3360.)
set gg_rct_HeroByCommand2=Rect(-15680.,-25312.,-15232.,-24992.)
set gg_dest_B000_5046=CreateDestructable('B000',4096.,1088.,318.,.938,3)
set gg_dest_B000_10403=CreateDestructable('B000',4096.,1216.,318.,.938,3)
call CreateNeutralHostileBuildings()
call CreateNeutralPassiveBuildings()
call CreatePlayerBuildings()
call CreateNeutralHostile()
call CreateNeutralPassive()
call InitBlizzard()
set i=0
set udg_Compteur1=CreateTimer()
set i=0
loop
exitwhen(i>1)
set udg_Col_vo_units[i]=0
set udg_Can_pick[i]=false
set udg_PlayersCount[i]=0
set udg_PlayersForce[i]=CreateForce()
set udg_Kill[i]=0
set udg_Death[i]=0
set udg_Kills[i]=0
set udg_Deaths[i]=0
set i=i+1
endloop
set udg_Group=CreateForce()
set udg_Players_hero=CreateForce()
set udg_MultiBoard=CreateMultiboard()
set gg_trg_Information=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Information,.1)
call TriggerAddAction(gg_trg_Information,function Trig_Information_Actions)
set gg_trg_Tekst=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Tekst,30.)
call TriggerAddAction(gg_trg_Tekst,function Trig_Tekst_Actions)
set gg_trg_Start=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Start,.01)
call TriggerAddAction(gg_trg_Start,function Trig_Start_Actions)
set gg_trg_Time_f1=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Time_f1,900.)
call TriggerAddAction(gg_trg_Time_f1,function Trig_Time_f1_Actions)
set gg_trg_Time_f2=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Time_f2,1800.)
call TriggerAddAction(gg_trg_Time_f2,function Trig_Time_f2_Actions)
set gg_trg_Time_f4=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Time_f4,3600.)
call TriggerAddAction(gg_trg_Time_f4,function Trig_Time_f4_Actions)
set gg_trg_Time_f5=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Time_f5,4500.)
call TriggerAddAction(gg_trg_Time_f5,function Trig_Time_f5_Actions)
set gg_trg_Time_f6=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Time_f6,5400.)
call TriggerAddAction(gg_trg_Time_f6,function Trig_Time_f6_Actions)
set gg_trg_Time_f7=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Time_f7,6300.)
call TriggerAddAction(gg_trg_Time_f7,function Trig_Time_f7_Actions)
set gg_trg_Time_f8=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Time_f8,7200.)
call TriggerAddAction(gg_trg_Time_f8,function Trig_Time_f8_Actions)
set gg_trg_Liver_Player=CreateTrigger()
call TriggerRegisterPlayerEventLeave(gg_trg_Liver_Player,Player(0))
call TriggerRegisterPlayerEventLeave(gg_trg_Liver_Player,Player(1))
call TriggerRegisterPlayerEventLeave(gg_trg_Liver_Player,Player(2))
call TriggerRegisterPlayerEventLeave(gg_trg_Liver_Player,Player(3))
call TriggerRegisterPlayerEventLeave(gg_trg_Liver_Player,Player(4))
call TriggerRegisterPlayerEventLeave(gg_trg_Liver_Player,Player(5))
call TriggerRegisterPlayerEventLeave(gg_trg_Liver_Player,Player(6))
call TriggerRegisterPlayerEventLeave(gg_trg_Liver_Player,Player(7))
call TriggerRegisterPlayerEventLeave(gg_trg_Liver_Player,Player(8))
call TriggerRegisterPlayerEventLeave(gg_trg_Liver_Player,Player(9))
call TriggerRegisterPlayerEventLeave(gg_trg_Liver_Player,Player($A))
call TriggerRegisterPlayerEventLeave(gg_trg_Liver_Player,Player($B))
call TriggerAddAction(gg_trg_Liver_Player,function Trig_Liver_Player_Actions)
set gg_trg_AuthorVision=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_AuthorVision,Player(0)," 1",true)
call TriggerRegisterPlayerChatEvent(gg_trg_AuthorVision,Player(1)," 1",true)
call TriggerRegisterPlayerChatEvent(gg_trg_AuthorVision,Player(2)," 1",true)
call TriggerRegisterPlayerChatEvent(gg_trg_AuthorVision,Player(3)," 1",true)
call TriggerRegisterPlayerChatEvent(gg_trg_AuthorVision,Player(4)," 1",true)
call TriggerRegisterPlayerChatEvent(gg_trg_AuthorVision,Player(5)," 1",true)
call TriggerRegisterPlayerChatEvent(gg_trg_AuthorVision,Player(6)," 1",true)
call TriggerRegisterPlayerChatEvent(gg_trg_AuthorVision,Player(7)," 1",true)
call TriggerRegisterPlayerChatEvent(gg_trg_AuthorVision,Player(8)," 1",true)
call TriggerRegisterPlayerChatEvent(gg_trg_AuthorVision,Player(9)," 1",true)
call TriggerRegisterPlayerChatEvent(gg_trg_AuthorVision,Player($A)," 1",true)
call TriggerRegisterPlayerChatEvent(gg_trg_AuthorVision,Player($B)," 1",true)
call TriggerAddCondition(gg_trg_AuthorVision,Condition(function Trig_AuthorVision_Conditions))
call TriggerAddAction(gg_trg_AuthorVision,function Trig_AuthorVision_Actions)
set gg_trg_SpawnVision=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_SpawnVision,1.)
call TriggerAddAction(gg_trg_SpawnVision,function Trig_SpawnVision_Actions)
set gg_trg_NochangeName1=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName1,Player(0),"-name bigwolf2000",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName1,Player(1),"-name bigwolf2000",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName1,Player(2),"-name bigwolf2000",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName1,Player(3),"-name bigwolf2000",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName1,Player(4),"-name bigwolf2000",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName1,Player(5),"-name bigwolf2000",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName1,Player(6),"-name bigwolf2000",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName1,Player(7),"-name bigwolf2000",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName1,Player(8),"-name bigwolf2000",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName1,Player(9),"-name bigwolf2000",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName1,Player($A),"-name bigwolf2000",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName1,Player($B),"-name bigwolf2000",true)
call TriggerAddAction(gg_trg_NochangeName1,function Trig_NochangeName1_Actions)
set gg_trg_NochangeName2=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName2,Player(0),"-name Shushpanchig",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName2,Player(1),"-name Shushpanchig",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName2,Player(2),"-name Shushpanchig",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName2,Player(3),"-name Shushpanchig",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName2,Player(4),"-name Shushpanchig",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName2,Player(5),"-name Shushpanchig",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName2,Player(6),"-name Shushpanchig",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName2,Player(7),"-name Shushpanchig",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName2,Player(8),"-name Shushpanchig",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName2,Player(9),"-name Shushpanchig",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName2,Player($A),"-name Shushpanchig",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName2,Player($B),"-name Shushpanchig",true)
call TriggerAddAction(gg_trg_NochangeName2,function Trig_NochangeName2_Actions)
set gg_trg_NochangeName3=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName3,Player(0),"-name gordik0101",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName3,Player(1),"-name gordik0101",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName3,Player(2),"-name gordik0101",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName3,Player(3),"-name gordik0101",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName3,Player(4),"-name gordik0101",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName3,Player(5),"-name gordik0101",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName3,Player(6),"-name gordik0101",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName3,Player(7),"-name gordik0101",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName3,Player(8),"-name gordik0101",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName3,Player(9),"-name gordik0101",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName3,Player($A),"-name gordik0101",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName3,Player($B),"-name gordik0101",true)
call TriggerAddAction(gg_trg_NochangeName3,function Trig_NochangeName3_Actions)
set gg_trg_NochangeName4=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName4,Player(0),"-name Old_Helm",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName4,Player(1),"-name Old_Helm",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName4,Player(2),"-name Old_Helm",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName4,Player(3),"-name Old_Helm",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName4,Player(4),"-name Old_Helm",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName4,Player(5),"-name Old_Helm",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName4,Player(6),"-name Old_Helm",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName4,Player(7),"-name Old_Helm",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName4,Player(8),"-name Old_Helm",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName4,Player(9),"-name Old_Helm",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName4,Player($A),"-name Old_Helm",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName4,Player($B),"-name Old_Helm",true)
call TriggerAddAction(gg_trg_NochangeName4,function Trig_NochangeName4_Actions)
set gg_trg_NochangeName5=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName5,Player(0),"-name YaHLoS",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName5,Player(1),"-name YaHLoS",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName5,Player(2),"-name YaHLoS",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName5,Player(3),"-name YaHLoS",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName5,Player(4),"-name YaHLoS",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName5,Player(5),"-name YaHLoS",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName5,Player(6),"-name YaHLoS",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName5,Player(7),"-name YaHLoS",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName5,Player(8),"-name YaHLoS",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName5,Player(9),"-name YaHLoS",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName5,Player($A),"-name YaHLoS",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName5,Player($B),"-name YaHLoS",true)
call TriggerAddAction(gg_trg_NochangeName5,function Trig_NochangeName5_Actions)
set gg_trg_NochangeName8=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName8,Player(0),"-name fgjkoi",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName8,Player(1),"-name fgjkoi",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName8,Player(2),"-name fgjkoi",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName8,Player(3),"-name fgjkoi",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName8,Player(4),"-name fgjkoi",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName8,Player(5),"-name fgjkoi",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName8,Player(6),"-name fgjkoi",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName8,Player(7),"-name fgjkoi",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName8,Player(8),"-name fgjkoi",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName8,Player(9),"-name fgjkoi",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName8,Player($A),"-name fgjkoi",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName8,Player($B),"-name fgjkoi",true)
call TriggerAddAction(gg_trg_NochangeName8,function Trig_NochangeName8_Actions)
set gg_trg_Human=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Human,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Human,Condition(function Trig_Human_Conditions))
call TriggerAddAction(gg_trg_Human,function Trig_Human_Actions)
set gg_trg_Orc=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Orc,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Orc,Condition(function Trig_Orc_Conditions))
call TriggerAddAction(gg_trg_Orc,function Trig_Orc_Actions)
set gg_trg_Undead=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Undead,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Undead,Condition(function Trig_Undead_Conditions))
call TriggerAddAction(gg_trg_Undead,function Trig_Undead_Actions)
set gg_trg_NightElf=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_NightElf,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_NightElf,Condition(function Trig_NightElf_Conditions))
call TriggerAddAction(gg_trg_NightElf,function Trig_NightElf_Actions)
set gg_trg_Nerubian=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Nerubian,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Nerubian,Condition(function Trig_Nerubian_Conditions))
call TriggerAddAction(gg_trg_Nerubian,function Trig_Nerubian_Actions)
set gg_trg_Dwarfen=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Dwarfen,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Dwarfen,Condition(function Trig_Dwarfen_Conditions))
call TriggerAddAction(gg_trg_Dwarfen,function Trig_Dwarfen_Actions)
set gg_trg_Naga=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Naga,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Naga,Condition(function Trig_Naga_Conditions))
call TriggerAddAction(gg_trg_Naga,function Trig_Naga_Actions)
set gg_trg_ScorgedElf=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_ScorgedElf,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_ScorgedElf,Condition(function Trig_ScorgedElf_Conditions))
call TriggerAddAction(gg_trg_ScorgedElf,function Trig_ScorgedElf_Actions)
set gg_trg_Demon=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Demon,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Demon,Condition(function Trig_Demon_Conditions))
call TriggerAddAction(gg_trg_Demon,function Trig_Demon_Actions)
set gg_trg_HighElf=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_HighElf,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_HighElf,Condition(function Trig_HighElf_Conditions))
call TriggerAddAction(gg_trg_HighElf,function Trig_HighElf_Actions)
set gg_trg_ForestTroll=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_ForestTroll,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_ForestTroll,Condition(function Trig_ForestTroll_Conditions))
call TriggerAddAction(gg_trg_ForestTroll,function Trig_ForestTroll_Actions)
set gg_trg_DarkTroll=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_DarkTroll,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_DarkTroll,Condition(function Trig_DarkTroll_Conditions))
call TriggerAddAction(gg_trg_DarkTroll,function Trig_DarkTroll_Actions)
set gg_trg_IceTroll=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_IceTroll,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_IceTroll,Condition(function Trig_IceTroll_Conditions))
call TriggerAddAction(gg_trg_IceTroll,function Trig_IceTroll_Actions)
set gg_trg_FelOrc=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_FelOrc,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_FelOrc,Condition(function Trig_FelOrc_Conditions))
call TriggerAddAction(gg_trg_FelOrc,function Trig_FelOrc_Actions)
set gg_trg_Kobold=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Kobold,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Kobold,Condition(function Trig_Kobold_Conditions))
call TriggerAddAction(gg_trg_Kobold,function Trig_Kobold_Actions)
set gg_trg_ScarletCrusade=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_ScarletCrusade,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_ScarletCrusade,Condition(function Trig_ScarletCrusade_Conditions))
call TriggerAddAction(gg_trg_ScarletCrusade,function Trig_ScarletCrusade_Actions)
set gg_trg_Futborg=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Futborg,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Futborg,Condition(function Trig_Futborg_Conditions))
call TriggerAddAction(gg_trg_Futborg,function Trig_Futborg_Actions)
set gg_trg_Gnoll=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Gnoll,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Gnoll,Condition(function Trig_Gnoll_Conditions))
call TriggerAddAction(gg_trg_Gnoll,function Trig_Gnoll_Actions)
set gg_trg_Faceless=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Faceless,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Faceless,Condition(function Trig_Faceless_Conditions))
call TriggerAddAction(gg_trg_Faceless,function Trig_Faceless_Actions)
set gg_trg_Ogre=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Ogre,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Ogre,Condition(function Trig_Ogre_Conditions))
call TriggerAddAction(gg_trg_Ogre,function Trig_Ogre_Actions)
set gg_trg_Draenei=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Draenei,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Draenei,Condition(function Trig_Draenei_Conditions))
call TriggerAddAction(gg_trg_Draenei,function Trig_Draenei_Actions)
set gg_trg_Bandite=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Bandite,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Bandite,Condition(function Trig_Bandite_Conditions))
call TriggerAddAction(gg_trg_Bandite,function Trig_Bandite_Actions)
set gg_trg_Tauren=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Tauren,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Tauren,Condition(function Trig_Tauren_Conditions))
call TriggerAddAction(gg_trg_Tauren,function Trig_Tauren_Actions)
set gg_trg_Pandaren=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Pandaren,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Pandaren,Condition(function Trig_Pandaren_Conditions))
call TriggerAddAction(gg_trg_Pandaren,function Trig_Pandaren_Actions)
set gg_trg_Goblin=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Goblin,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Goblin,Condition(function Trig_Goblin_Conditions))
call TriggerAddAction(gg_trg_Goblin,function Trig_Goblin_Actions)
set gg_trg_Murloc=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Murloc,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Murloc,Condition(function Trig_Murloc_Conditions))
call TriggerAddAction(gg_trg_Murloc,function Trig_Murloc_Actions)
set gg_trg_Centaur=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Centaur,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Centaur,Condition(function Trig_Centaur_Conditions))
call TriggerAddAction(gg_trg_Centaur,function Trig_Centaur_Actions)
set gg_trg_Illidari=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Illidari,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Illidari,Condition(function Trig_Illidari_Conditions))
call TriggerAddAction(gg_trg_Illidari,function Trig_Illidari_Actions)
set gg_trg_Worgen=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Worgen,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Worgen,Condition(function Trig_Worgen_Conditions))
call TriggerAddAction(gg_trg_Worgen,function Trig_Worgen_Actions)
set gg_trg_Forsaken=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Forsaken,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Forsaken,Condition(function Trig_Forsaken_Conditions))
call TriggerAddAction(gg_trg_Forsaken,function Trig_Forsaken_Actions)
set gg_trg_Elemental=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Elemental,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Elemental,Condition(function Trig_Elemental_Conditions))
call TriggerAddAction(gg_trg_Elemental,function Trig_Elemental_Actions)
set gg_trg_Quraji=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Quraji,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_Quraji,Condition(function Trig_Quraji_Conditions))
call TriggerAddAction(gg_trg_Quraji,function Trig_Quraji_Actions)
set gg_trg_DarkDwarf=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_DarkDwarf,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_DarkDwarf,Condition(function Trig_DarkDwarf_Conditions))
call TriggerAddAction(gg_trg_DarkDwarf,function Trig_DarkDwarf_Actions)
set gg_trg_TwilightHammer=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_TwilightHammer,EVENT_PLAYER_UNIT_RESEARCH_FINISH)
call TriggerAddCondition(gg_trg_TwilightHammer,Condition(function Trig_TwilightHammer_Conditions))
call TriggerAddAction(gg_trg_TwilightHammer,function Trig_TwilightHammer_Actions)
set gg_trg_Hostkick1=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick1,Player(0),"-akick 1",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick1,Player(1),"-akick 1",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick1,Player(2),"-akick 1",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick1,Player(3),"-akick 1",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick1,Player(4),"-akick 1",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick1,Player(5),"-akick 1",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick1,Player(6),"-akick 1",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick1,Player(7),"-akick 1",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick1,Player(8),"-akick 1",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick1,Player(9),"-akick 1",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick1,Player($A),"-akick 1",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick1,Player($B),"-akick 1",true)
call TriggerAddCondition(gg_trg_Hostkick1,Condition(function Trig_Hostkick1_Conditions))
call TriggerAddAction(gg_trg_Hostkick1,function Trig_Hostkick1_Actions)
set gg_trg_Hostkick2=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick2,Player(0),"-akick 2",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick2,Player(1),"-akick 2",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick2,Player(2),"-akick 2",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick2,Player(3),"-akick 2",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick2,Player(4),"-akick 2",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick2,Player(5),"-akick 2",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick2,Player(6),"-akick 2",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick2,Player(7),"-akick 2",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick2,Player(8),"-akick 2",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick2,Player(9),"-akick 2",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick2,Player($A),"-akick 2",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick2,Player($B),"-akick 2",true)
call TriggerAddCondition(gg_trg_Hostkick2,Condition(function Trig_Hostkick2_Conditions))
call TriggerAddAction(gg_trg_Hostkick2,function Trig_Hostkick2_Actions)
set gg_trg_Hostkick3=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick3,Player(0),"-akick 3",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick3,Player(1),"-akick 3",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick3,Player(2),"-akick 3",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick3,Player(3),"-akick 3",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick3,Player(4),"-akick 3",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick3,Player(5),"-akick 3",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick3,Player(6),"-akick 3",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick3,Player(7),"-akick 3",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick3,Player(8),"-akick 3",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick3,Player(9),"-akick 3",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick3,Player($A),"-akick 3",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick3,Player($B),"-akick 3",true)
call TriggerAddCondition(gg_trg_Hostkick3,Condition(function Trig_Hostkick3_Conditions))
call TriggerAddAction(gg_trg_Hostkick3,function Trig_Hostkick3_Actions)
set gg_trg_Hostkick4=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick4,Player(0),"-akick 4",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick4,Player(1),"-akick 4",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick4,Player(2),"-akick 4",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick4,Player(3),"-akick 4",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick4,Player(4),"-akick 4",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick4,Player(5),"-akick 4",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick4,Player(6),"-akick 4",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick4,Player(7),"-akick 4",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick4,Player(8),"-akick 4",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick4,Player(9),"-akick 4",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick4,Player($A),"-akick 4",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick4,Player($B),"-akick 4",true)
call TriggerAddCondition(gg_trg_Hostkick4,Condition(function Trig_Hostkick4_Conditions))
call TriggerAddAction(gg_trg_Hostkick4,function Trig_Hostkick4_Actions)
set gg_trg_Hostkick5=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick5,Player(0),"-akick 5",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick5,Player(1),"-akick 5",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick5,Player(2),"-akick 5",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick5,Player(3),"-akick 5",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick5,Player(4),"-akick 5",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick5,Player(5),"-akick 5",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick5,Player(6),"-akick 5",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick5,Player(7),"-akick 5",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick5,Player(8),"-akick 5",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick5,Player(9),"-akick 5",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick5,Player($A),"-akick 5",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick5,Player($B),"-akick 5",true)
call TriggerAddCondition(gg_trg_Hostkick5,Condition(function Trig_Hostkick5_Conditions))
call TriggerAddAction(gg_trg_Hostkick5,function Trig_Hostkick5_Actions)
set gg_trg_Hostkick6=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick6,Player(0),"-akick 6",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick6,Player(1),"-akick 6",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick6,Player(2),"-akick 6",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick6,Player(3),"-akick 6",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick6,Player(4),"-akick 6",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick6,Player(5),"-akick 6",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick6,Player(6),"-akick 6",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick6,Player(7),"-akick 6",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick6,Player(8),"-akick 6",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick6,Player(9),"-akick 6",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick6,Player($A),"-akick 6",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick6,Player($B),"-akick 6",true)
call TriggerAddCondition(gg_trg_Hostkick6,Condition(function Trig_Hostkick6_Conditions))
call TriggerAddAction(gg_trg_Hostkick6,function Trig_Hostkick6_Actions)
set gg_trg_Hostkick7=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick7,Player(0),"-akick 7",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick7,Player(1),"-akick 7",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick7,Player(2),"-akick 7",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick7,Player(3),"-akick 7",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick7,Player(4),"-akick 7",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick7,Player(5),"-akick 7",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick7,Player(6),"-akick 7",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick7,Player(7),"-akick 7",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick7,Player(8),"-akick 7",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick7,Player(9),"-akick 7",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick7,Player($A),"-akick 7",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick7,Player($B),"-akick 7",true)
call TriggerAddCondition(gg_trg_Hostkick7,Condition(function Trig_Hostkick7_Conditions))
call TriggerAddAction(gg_trg_Hostkick7,function Trig_Hostkick7_Actions)
set gg_trg_Hostkick8=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick8,Player(0),"-akick 8",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick8,Player(1),"-akick 8",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick8,Player(2),"-akick 8",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick8,Player(3),"-akick 8",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick8,Player(4),"-akick 8",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick8,Player(5),"-akick 8",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick8,Player(6),"-akick 8",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick8,Player(7),"-akick 8",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick8,Player(8),"-akick 8",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick8,Player(9),"-akick 8",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick8,Player($A),"-akick 8",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick8,Player($B),"-akick 8",true)
call TriggerAddCondition(gg_trg_Hostkick8,Condition(function Trig_Hostkick8_Conditions))
call TriggerAddAction(gg_trg_Hostkick8,function Trig_Hostkick8_Actions)
set gg_trg_Hostkick9=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick9,Player(0),"-akick 9",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick9,Player(1),"-akick 9",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick9,Player(2),"-akick 9",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick9,Player(3),"-akick 9",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick9,Player(4),"-akick 9",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick9,Player(5),"-akick 9",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick9,Player(6),"-akick 9",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick9,Player(7),"-akick 9",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick9,Player(8),"-akick 9",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick9,Player(9),"-akick 9",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick9,Player($A),"-akick 9",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick9,Player($B),"-akick 9",true)
call TriggerAddCondition(gg_trg_Hostkick9,Condition(function Trig_Hostkick9_Conditions))
call TriggerAddAction(gg_trg_Hostkick9,function Trig_Hostkick9_Actions)
set gg_trg_Hostkick10=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick10,Player(0),"-akick 10",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick10,Player(1),"-akick 10",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick10,Player(2),"-akick 10",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick10,Player(3),"-akick 10",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick10,Player(4),"-akick 10",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick10,Player(5),"-akick 10",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick10,Player(6),"-akick 10",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick10,Player(7),"-akick 10",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick10,Player(8),"-akick 10",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick10,Player(9),"-akick 10",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick10,Player($A),"-akick 10",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick10,Player($B),"-akick 10",true)
call TriggerAddCondition(gg_trg_Hostkick10,Condition(function Trig_Hostkick10_Conditions))
call TriggerAddAction(gg_trg_Hostkick10,function Trig_Hostkick10_Actions)
set gg_trg_Hostkick11=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick11,Player(0),"-akick 11",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick11,Player(1),"-akick 11",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick11,Player(2),"-akick 11",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick11,Player(3),"-akick 11",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick11,Player(4),"-akick 11",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick11,Player(5),"-akick 11",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick11,Player(6),"-akick 11",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick11,Player(7),"-akick 11",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick11,Player(8),"-akick 11",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick11,Player(9),"-akick 11",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick11,Player($A),"-akick 11",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick11,Player($B),"-akick 11",true)
call TriggerAddCondition(gg_trg_Hostkick11,Condition(function Trig_Hostkick11_Conditions))
call TriggerAddAction(gg_trg_Hostkick11,function Trig_Hostkick11_Actions)
set gg_trg_Hostkick12=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick12,Player(0),"-akick 12",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick12,Player(1),"-akick 12",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick12,Player(2),"-akick 12",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick12,Player(3),"-akick 12",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick12,Player(4),"-akick 12",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick12,Player(5),"-akick 12",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick12,Player(6),"-akick 12",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick12,Player(7),"-akick 12",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick12,Player(8),"-akick 12",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick12,Player(9),"-akick 12",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick12,Player($A),"-akick 12",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Hostkick12,Player($B),"-akick 12",true)
call TriggerAddCondition(gg_trg_Hostkick12,Condition(function Trig_Hostkick12_Conditions))
call TriggerAddAction(gg_trg_Hostkick12,function Trig_Hostkick12_Actions)
set gg_trg_destroy_1=CreateTrigger()
call DisableTrigger(gg_trg_destroy_1)
call TriggerRegisterPlayerEventLeave(gg_trg_destroy_1,Player(0))
call TriggerRegisterPlayerEventLeave(gg_trg_destroy_1,Player(1))
call TriggerRegisterPlayerEventLeave(gg_trg_destroy_1,Player(2))
call TriggerRegisterPlayerEventLeave(gg_trg_destroy_1,Player(3))
call TriggerRegisterPlayerEventLeave(gg_trg_destroy_1,Player(4))
call TriggerRegisterPlayerEventLeave(gg_trg_destroy_1,Player(5))
call TriggerRegisterPlayerEventLeave(gg_trg_destroy_1,Player(6))
call TriggerRegisterPlayerEventLeave(gg_trg_destroy_1,Player(7))
call TriggerRegisterPlayerEventLeave(gg_trg_destroy_1,Player(8))
call TriggerRegisterPlayerEventLeave(gg_trg_destroy_1,Player(9))
call TriggerRegisterPlayerEventLeave(gg_trg_destroy_1,Player($A))
call TriggerRegisterPlayerEventLeave(gg_trg_destroy_1,Player($B))
call TriggerAddAction(gg_trg_destroy_1,function Trig_destroy_1_Actions)
set gg_trg_Timedestroy=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Timedestroy,10.)
call TriggerAddAction(gg_trg_Timedestroy,function Trig_Timedestroy_Actions)
set gg_trg_Debut=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Debut,.1)
call TriggerAddAction(gg_trg_Debut,function Trig_Debut_Actions)
set gg_trg_Revenus=CreateTrigger()
call DisableTrigger(gg_trg_Revenus)
call TriggerRegisterTimerExpireEvent(gg_trg_Revenus,udg_Compteur1)
call TriggerAddAction(gg_trg_Revenus,function Trig_Revenus_Actions)
set gg_trg_ND1=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_ND1,gg_unit_h00M_0033,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_ND1,Condition(function Trig_ND1_Conditions))
call TriggerAddAction(gg_trg_ND1,function Trig_ND1_Actions)
set gg_trg_ND2=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_ND2,gg_unit_h00L_0032,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_ND2,Condition(function Trig_ND2_Conditions))
call TriggerAddAction(gg_trg_ND2,function Trig_ND2_Actions)
set gg_trg_ND3=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_ND3,gg_unit_h00K_0031,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_ND3,Condition(function Trig_ND3_Conditions))
call TriggerAddAction(gg_trg_ND3,function Trig_ND3_Actions)
set gg_trg_ND4=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_ND4,gg_unit_h00N_0034,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_ND4,Condition(function Trig_ND4_Conditions))
call TriggerAddAction(gg_trg_ND4,function Trig_ND4_Actions)
set gg_trg_ND5=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_ND5,gg_unit_h00O_0035,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_ND5,Condition(function Trig_ND5_Conditions))
call TriggerAddAction(gg_trg_ND5,function Trig_ND5_Actions)
set gg_trg_ND6=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_ND6,gg_unit_h00P_0036,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_ND6,Condition(function Trig_ND6_Conditions))
call TriggerAddAction(gg_trg_ND6,function Trig_ND6_Actions)
set gg_trg_ND7=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_ND7,gg_unit_h00R_0038,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_ND7,Condition(function Trig_ND7_Conditions))
call TriggerAddAction(gg_trg_ND7,function Trig_ND7_Actions)
set gg_trg_ND8=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_ND8,gg_unit_h00Q_0037,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_ND8,Condition(function Trig_ND8_Conditions))
call TriggerAddAction(gg_trg_ND8,function Trig_ND8_Actions)
set gg_trg_ND9=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_ND9,gg_unit_h01M_0069,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_ND9,Condition(function Trig_ND9_Conditions))
call TriggerAddAction(gg_trg_ND9,function Trig_ND9_Actions)
set gg_trg_KL1=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_KL1,gg_unit_h00U_0041,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_KL1,Condition(function Trig_KL1_Conditions))
call TriggerAddAction(gg_trg_KL1,function Trig_KL1_Actions)
set gg_trg_KL2=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_KL2,gg_unit_h00S_0039,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_KL2,Condition(function Trig_KL2_Conditions))
call TriggerAddAction(gg_trg_KL2,function Trig_KL2_Actions)
set gg_trg_KL3=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_KL3,gg_unit_h00T_0040,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_KL3,Condition(function Trig_KL3_Conditions))
call TriggerAddAction(gg_trg_KL3,function Trig_KL3_Actions)
set gg_trg_KL4=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_KL4,gg_unit_h00W_0043,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_KL4,Condition(function Trig_KL4_Conditions))
call TriggerAddAction(gg_trg_KL4,function Trig_KL4_Actions)
set gg_trg_KL5=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_KL5,gg_unit_h00V_0042,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_KL5,Condition(function Trig_KL5_Conditions))
call TriggerAddAction(gg_trg_KL5,function Trig_KL5_Actions)
set gg_trg_KL6=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_KL6,gg_unit_h00X_0044,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_KL6,Condition(function Trig_KL6_Conditions))
call TriggerAddAction(gg_trg_KL6,function Trig_KL6_Actions)
set gg_trg_KL7=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_KL7,gg_unit_h012_0049,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_KL7,Condition(function Trig_KL7_Conditions))
call TriggerAddAction(gg_trg_KL7,function Trig_KL7_Actions)
set gg_trg_KL8=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_KL8,gg_unit_h010_0047,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_KL8,Condition(function Trig_KL8_Conditions))
call TriggerAddAction(gg_trg_KL8,function Trig_KL8_Actions)
set gg_trg_KL9=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_KL9,gg_unit_h011_0048,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_KL9,Condition(function Trig_KL9_Conditions))
call TriggerAddAction(gg_trg_KL9,function Trig_KL9_Actions)
set gg_trg_KL10=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_KL10,gg_unit_h013_0050,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_KL10,Condition(function Trig_KL10_Conditions))
call TriggerAddAction(gg_trg_KL10,function Trig_KL10_Actions)
set gg_trg_KL11=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_KL11,gg_unit_h014_0051,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_KL11,Condition(function Trig_KL11_Conditions))
call TriggerAddAction(gg_trg_KL11,function Trig_KL11_Actions)
set gg_trg_KL12=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_KL12,gg_unit_h00Z_0046,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_KL12,Condition(function Trig_KL12_Conditions))
call TriggerAddAction(gg_trg_KL12,function Trig_KL12_Actions)
set gg_trg_KL13=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_KL13,gg_unit_h00Y_0045,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_KL13,Condition(function Trig_KL13_Conditions))
call TriggerAddAction(gg_trg_KL13,function Trig_KL13_Actions)
set gg_trg_KL14=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_KL14,gg_unit_h046_0405,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_KL14,Condition(function Trig_KL14_Conditions))
call TriggerAddAction(gg_trg_KL14,function Trig_KL14_Actions)
set gg_trg_PA1=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_PA1,gg_unit_h015_0052,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_PA1,Condition(function Trig_PA1_Conditions))
call TriggerAddAction(gg_trg_PA1,function Trig_PA1_Actions)
set gg_trg_PA2=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_PA2,gg_unit_h016_0053,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_PA2,Condition(function Trig_PA2_Conditions))
call TriggerAddAction(gg_trg_PA2,function Trig_PA2_Actions)
set gg_trg_PA3=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_PA3,gg_unit_h017_0054,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_PA3,Condition(function Trig_PA3_Conditions))
call TriggerAddAction(gg_trg_PA3,function Trig_PA3_Actions)
set gg_trg_PA4=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_PA4,gg_unit_h018_0055,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_PA4,Condition(function Trig_PA4_Conditions))
call TriggerAddAction(gg_trg_PA4,function Trig_PA4_Actions)
set gg_trg_PA5=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_PA5,gg_unit_h088_0545,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_PA5,Condition(function Trig_PA5_Conditions))
call TriggerAddAction(gg_trg_PA5,function Trig_PA5_Actions)
set gg_trg_BI1=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_BI1,gg_unit_h01K_0057,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_BI1,Condition(function Trig_BI1_Conditions))
call TriggerAddAction(gg_trg_BI1,function Trig_BI1_Actions)
set gg_trg_BI2=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_BI2,gg_unit_h01C_0059,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_BI2,Condition(function Trig_BI2_Conditions))
call TriggerAddAction(gg_trg_BI2,function Trig_BI2_Actions)
set gg_trg_BI3=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_BI3,gg_unit_h019_0056,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_BI3,Condition(function Trig_BI3_Conditions))
call TriggerAddAction(gg_trg_BI3,function Trig_BI3_Actions)
set gg_trg_BI4=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_BI4,gg_unit_h01B_0058,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_BI4,Condition(function Trig_BI4_Conditions))
call TriggerAddAction(gg_trg_BI4,function Trig_BI4_Actions)
set gg_trg_BI5=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_BI5,gg_unit_h01A_0060,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_BI5,Condition(function Trig_BI5_Conditions))
call TriggerAddAction(gg_trg_BI5,function Trig_BI5_Actions)
set gg_trg_Bl6=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_Bl6,gg_unit_h07N_0415,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_Bl6,Condition(function Trig_Bl6_Conditions))
call TriggerAddAction(gg_trg_Bl6,function Trig_Bl6_Actions)
set gg_trg_BI7=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_BI7,gg_unit_h07O_0416,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_BI7,Condition(function Trig_BI7_Conditions))
call TriggerAddAction(gg_trg_BI7,function Trig_BI7_Actions)
set gg_trg_BI8=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_BI8,gg_unit_h07R_0791,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_BI8,Condition(function Trig_BI8_Conditions))
call TriggerAddAction(gg_trg_BI8,function Trig_BI8_Actions)
set gg_trg_BI9=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_BI9,gg_unit_h07Q_0422,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_BI9,Condition(function Trig_BI9_Conditions))
call TriggerAddAction(gg_trg_BI9,function Trig_BI9_Actions)
set gg_trg_BI10=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_BI10,gg_unit_h07S_0202,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_BI10,Condition(function Trig_BI10_Conditions))
call TriggerAddAction(gg_trg_BI10,function Trig_BI10_Actions)
set gg_trg_EK1=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_EK1,gg_unit_h001_0011,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_EK1,Condition(function Trig_EK1_Conditions))
call TriggerAddAction(gg_trg_EK1,function Trig_EK1_Actions)
set gg_trg_EK2=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_EK2,gg_unit_h004_0023,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_EK2,Condition(function Trig_EK2_Conditions))
call TriggerAddAction(gg_trg_EK2,function Trig_EK2_Actions)
set gg_trg_EK3=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_EK3,gg_unit_h003_0022,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_EK3,Condition(function Trig_EK3_Conditions))
call TriggerAddAction(gg_trg_EK3,function Trig_EK3_Actions)
set gg_trg_EK4=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_EK4,gg_unit_h002_0018,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_EK4,Condition(function Trig_EK4_Conditions))
call TriggerAddAction(gg_trg_EK4,function Trig_EK4_Actions)
set gg_trg_EK5=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_EK5,gg_unit_h005_0024,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_EK5,Condition(function Trig_EK5_Conditions))
call TriggerAddAction(gg_trg_EK5,function Trig_EK5_Actions)
set gg_trg_EK6=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_EK6,gg_unit_h006_0025,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_EK6,Condition(function Trig_EK6_Conditions))
call TriggerAddAction(gg_trg_EK6,function Trig_EK6_Actions)
set gg_trg_EK7=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_EK7,gg_unit_h007_0026,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_EK7,Condition(function Trig_EK7_Conditions))
call TriggerAddAction(gg_trg_EK7,function Trig_EK7_Actions)
set gg_trg_EK8=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_EK8,gg_unit_h008_0027,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_EK8,Condition(function Trig_EK8_Conditions))
call TriggerAddAction(gg_trg_EK8,function Trig_EK8_Actions)
set gg_trg_EK9=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_EK9,gg_unit_h00B_0013,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_EK9,Condition(function Trig_EK9_Conditions))
call TriggerAddAction(gg_trg_EK9,function Trig_EK9_Actions)
set gg_trg_EK10=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_EK10,gg_unit_h009_0029,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_EK10,Condition(function Trig_EK10_Conditions))
call TriggerAddAction(gg_trg_EK10,function Trig_EK10_Actions)
set gg_trg_EK11=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_EK11,gg_unit_h00A_0028,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_EK11,Condition(function Trig_EK11_Conditions))
call TriggerAddAction(gg_trg_EK11,function Trig_EK11_Actions)
set gg_trg_EK12=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_EK12,gg_unit_h00E_0016,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_EK12,Condition(function Trig_EK12_Conditions))
call TriggerAddAction(gg_trg_EK12,function Trig_EK12_Actions)
set gg_trg_EK13=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_EK13,gg_unit_h00C_0014,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_EK13,Condition(function Trig_EK13_Conditions))
call TriggerAddAction(gg_trg_EK13,function Trig_EK13_Actions)
set gg_trg_EK14=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_EK14,gg_unit_h00D_0015,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_EK14,Condition(function Trig_EK14_Conditions))
call TriggerAddAction(gg_trg_EK14,function Trig_EK14_Actions)
set gg_trg_EK15=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_EK15,gg_unit_h00F_0017,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_EK15,Condition(function Trig_EK15_Conditions))
call TriggerAddAction(gg_trg_EK15,function Trig_EK15_Actions)
set gg_trg_EK16=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_EK16,gg_unit_h00G_0019,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_EK16,Condition(function Trig_EK16_Conditions))
call TriggerAddAction(gg_trg_EK16,function Trig_EK16_Actions)
set gg_trg_EK17=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_EK17,gg_unit_h00J_0030,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_EK17,Condition(function Trig_EK17_Conditions))
call TriggerAddAction(gg_trg_EK17,function Trig_EK17_Actions)
set gg_trg_EK18=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_EK18,gg_unit_h00H_0020,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_EK18,Condition(function Trig_EK18_Conditions))
call TriggerAddAction(gg_trg_EK18,function Trig_EK18_Actions)
set gg_trg_EK19=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_EK19,gg_unit_h00I_0021,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_EK19,Condition(function Trig_EK19_Conditions))
call TriggerAddAction(gg_trg_EK19,function Trig_EK19_Actions)
set gg_trg_EK20=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_EK20,gg_unit_h05M_0632,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_EK20,Condition(function Trig_EK20_Conditions))
call TriggerAddAction(gg_trg_EK20,function Trig_EK20_Actions)
set gg_trg_EK21=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_EK21,gg_unit_h078_0695,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_EK21,Condition(function Trig_EK21_Conditions))
call TriggerAddAction(gg_trg_EK21,function Trig_EK21_Actions)
set gg_trg_EK22=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_EK22,gg_unit_h07F_0793,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_EK22,Condition(function Trig_EK22_Conditions))
call TriggerAddAction(gg_trg_EK22,function Trig_EK22_Actions)
set gg_trg_OUT1=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_OUT1,gg_unit_h01E_0010,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_OUT1,Condition(function Trig_OUT1_Conditions))
call TriggerAddAction(gg_trg_OUT1,function Trig_OUT1_Actions)
set gg_trg_OUT2=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_OUT2,gg_unit_h01F_0062,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_OUT2,Condition(function Trig_OUT2_Conditions))
call TriggerAddAction(gg_trg_OUT2,function Trig_OUT2_Actions)
set gg_trg_OUT3=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_OUT3,gg_unit_h01J_0068,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_OUT3,Condition(function Trig_OUT3_Conditions))
call TriggerAddAction(gg_trg_OUT3,function Trig_OUT3_Actions)
set gg_trg_OUT4=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_OUT4,gg_unit_h01I_0067,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_OUT4,Condition(function Trig_OUT4_Conditions))
call TriggerAddAction(gg_trg_OUT4,function Trig_OUT4_Actions)
set gg_trg_OUT5=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_OUT5,gg_unit_h01G_0064,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_OUT5,Condition(function Trig_OUT5_Conditions))
call TriggerAddAction(gg_trg_OUT5,function Trig_OUT5_Actions)
set gg_trg_OUT6=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_OUT6,gg_unit_h01N_0065,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_OUT6,Condition(function Trig_OUT6_Conditions))
call TriggerAddAction(gg_trg_OUT6,function Trig_OUT6_Actions)
set gg_trg_OUT7=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_OUT7,gg_unit_h01H_0066,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_OUT7,Condition(function Trig_OUT7_Conditions))
call TriggerAddAction(gg_trg_OUT7,function Trig_OUT7_Actions)
set gg_trg_ZN1=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_ZN1,gg_unit_h01D_0061,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_ZN1,Condition(function Trig_ZN1_Conditions))
call TriggerAddAction(gg_trg_ZN1,function Trig_ZN1_Actions)
set gg_trg_VE1=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_VE1,gg_unit_h052_0627,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_VE1,Condition(function Trig_VE1_Conditions))
call TriggerAddAction(gg_trg_VE1,function Trig_VE1_Actions)
set gg_trg_KT=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_KT,gg_unit_h053_0628,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_KT,Condition(function Trig_KT_Conditions))
call TriggerAddAction(gg_trg_KT,function Trig_KT_Actions)
set gg_trg_Managorn1=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_Managorn1,gg_unit_h07P_0417,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_Managorn1,Condition(function Trig_Managorn1_Conditions))
call TriggerAddAction(gg_trg_Managorn1,function Trig_Managorn1_Actions)
set gg_trg_Managorn2=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_Managorn2,gg_unit_h07P_0419,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_Managorn2,Condition(function Trig_Managorn2_Conditions))
call TriggerAddAction(gg_trg_Managorn2,function Trig_Managorn2_Actions)
set gg_trg_Managorn3=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_Managorn3,gg_unit_h07P_0418,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_Managorn3,Condition(function Trig_Managorn3_Conditions))
call TriggerAddAction(gg_trg_Managorn3,function Trig_Managorn3_Actions)
set gg_trg_Managorn4=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_Managorn4,gg_unit_h07P_0420,EVENT_UNIT_ATTACKED)
call TriggerAddCondition(gg_trg_Managorn4,Condition(function Trig_Managorn4_Conditions))
call TriggerAddAction(gg_trg_Managorn4,function Trig_Managorn4_Actions)
set gg_trg_Production_en_chaine=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Production_en_chaine,EVENT_PLAYER_UNIT_TRAIN_FINISH)
call TriggerAddCondition(gg_trg_Production_en_chaine,Condition(function Trig_Production_en_chaine_Conditions))
call TriggerAddAction(gg_trg_Production_en_chaine,function Trig_Production_en_chaine_Actions)
set gg_trg_Camera_command=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Camera_command,Player(0),"-cam",false)
call TriggerRegisterPlayerChatEvent(gg_trg_Camera_command,Player(1),"-cam",false)
call TriggerRegisterPlayerChatEvent(gg_trg_Camera_command,Player(2),"-cam",false)
call TriggerRegisterPlayerChatEvent(gg_trg_Camera_command,Player(3),"-cam",false)
call TriggerRegisterPlayerChatEvent(gg_trg_Camera_command,Player(4),"-cam",false)
call TriggerRegisterPlayerChatEvent(gg_trg_Camera_command,Player(5),"-cam",false)
call TriggerRegisterPlayerChatEvent(gg_trg_Camera_command,Player(6),"-cam",false)
call TriggerRegisterPlayerChatEvent(gg_trg_Camera_command,Player(7),"-cam",false)
call TriggerRegisterPlayerChatEvent(gg_trg_Camera_command,Player(8),"-cam",false)
call TriggerRegisterPlayerChatEvent(gg_trg_Camera_command,Player(9),"-cam",false)
call TriggerRegisterPlayerChatEvent(gg_trg_Camera_command,Player($A),"-cam",false)
call TriggerRegisterPlayerChatEvent(gg_trg_Camera_command,Player($B),"-cam",false)
call TriggerAddAction(gg_trg_Camera_command,function Trig_Camera_command_Actions)
set gg_trg_Name_command=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Name_command,Player(0),"-name ",false)
call TriggerRegisterPlayerChatEvent(gg_trg_Name_command,Player(1),"-name ",false)
call TriggerRegisterPlayerChatEvent(gg_trg_Name_command,Player(2),"-name ",false)
call TriggerRegisterPlayerChatEvent(gg_trg_Name_command,Player(3),"-name ",false)
call TriggerRegisterPlayerChatEvent(gg_trg_Name_command,Player(4),"-name ",false)
call TriggerRegisterPlayerChatEvent(gg_trg_Name_command,Player(5),"-name ",false)
call TriggerRegisterPlayerChatEvent(gg_trg_Name_command,Player(6),"-name ",false)
call TriggerRegisterPlayerChatEvent(gg_trg_Name_command,Player(7),"-name ",false)
call TriggerRegisterPlayerChatEvent(gg_trg_Name_command,Player(8),"-name ",false)
call TriggerRegisterPlayerChatEvent(gg_trg_Name_command,Player(9),"-name ",false)
call TriggerRegisterPlayerChatEvent(gg_trg_Name_command,Player($A),"-name ",false)
call TriggerRegisterPlayerChatEvent(gg_trg_Name_command,Player($B),"-name ",false)
call TriggerAddCondition(gg_trg_Name_command,Condition(function Trig_Name_command_Conditions))
call TriggerAddAction(gg_trg_Name_command,function Trig_Name_command_Actions)
set gg_trg_Red_color=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Red_color,Player(0),"-цвет красный",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Red_color,Player(1),"-цвет красный",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Red_color,Player(2),"-цвет красный",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Red_color,Player(3),"-цвет красный",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Red_color,Player(4),"-цвет красный",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Red_color,Player(5),"-цвет красный",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Red_color,Player(6),"-цвет красный",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Red_color,Player(7),"-цвет красный",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Red_color,Player(8),"-цвет красный",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Red_color,Player(9),"-цвет красный",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Red_color,Player($A),"-цвет красный",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Red_color,Player($B),"-цвет красный",true)
call TriggerAddAction(gg_trg_Red_color,function Trig_Red_color_Actions)
set gg_trg_Blue_color=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Blue_color,Player(0),"-цвет синий",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Blue_color,Player(1),"-цвет синий",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Blue_color,Player(2),"-цвет синий",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Blue_color,Player(3),"-цвет синий",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Blue_color,Player(4),"-цвет синий",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Blue_color,Player(5),"-цвет синий",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Blue_color,Player(6),"-цвет синий",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Blue_color,Player(7),"-цвет синий",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Blue_color,Player(8),"-цвет синий",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Blue_color,Player(9),"-цвет синий",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Blue_color,Player($A),"-цвет синий",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Blue_color,Player($B),"-цвет синий",true)
call TriggerAddAction(gg_trg_Blue_color,function Trig_Blue_color_Actions)
set gg_trg_Lightblue_color=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Lightblue_color,Player(0),"-цвет сине-зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Lightblue_color,Player(1),"-цвет сине-зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Lightblue_color,Player(2),"-цвет сине-зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Lightblue_color,Player(3),"-цвет сине-зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Lightblue_color,Player(4),"-цвет сине-зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Lightblue_color,Player(5),"-цвет сине-зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Lightblue_color,Player(6),"-цвет сине-зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Lightblue_color,Player(7),"-цвет сине-зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Lightblue_color,Player(8),"-цвет сине-зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Lightblue_color,Player(9),"-цвет сине-зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Lightblue_color,Player($A),"-цвет сине-зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Lightblue_color,Player($B),"-цвет сине-зеленый",true)
call TriggerAddAction(gg_trg_Lightblue_color,function Trig_Lightblue_color_Actions)
set gg_trg_Viol_color=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Viol_color,Player(0),"-цвет фиолетовый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Viol_color,Player(1),"-цвет фиолетовый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Viol_color,Player(2),"-цвет фиолетовый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Viol_color,Player(3),"-цвет фиолетовый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Viol_color,Player(4),"-цвет фиолетовый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Viol_color,Player(5),"-цвет фиолетовый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Viol_color,Player(6),"-цвет фиолетовый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Viol_color,Player(7),"-цвет фиолетовый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Viol_color,Player(8),"-цвет фиолетовый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Viol_color,Player(9),"-цвет фиолетовый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Viol_color,Player($A),"-цвет фиолетовый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Viol_color,Player($B),"-цвет фиолетовый",true)
call TriggerAddAction(gg_trg_Viol_color,function Trig_Viol_color_Actions)
set gg_trg_Yelow_color=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Yelow_color,Player(0),"-цвет желтый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Yelow_color,Player(1),"-цвет желтый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Yelow_color,Player(2),"-цвет желтый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Yelow_color,Player(3),"-цвет желтый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Yelow_color,Player(4),"-цвет желтый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Yelow_color,Player(5),"-цвет желтый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Yelow_color,Player(6),"-цвет желтый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Yelow_color,Player(7),"-цвет желтый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Yelow_color,Player(8),"-цвет желтый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Yelow_color,Player(9),"-цвет желтый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Yelow_color,Player($A),"-цвет желтый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Yelow_color,Player($B),"-цвет желтый",true)
call TriggerAddAction(gg_trg_Yelow_color,function Trig_Yelow_color_Actions)
set gg_trg_Orange_color=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Orange_color,Player(0),"-цвет оранжевый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Orange_color,Player(1),"-цвет оранжевый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Orange_color,Player(2),"-цвет оранжевый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Orange_color,Player(3),"-цвет оранжевый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Orange_color,Player(4),"-цвет оранжевый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Orange_color,Player(5),"-цвет оранжевый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Orange_color,Player(6),"-цвет оранжевый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Orange_color,Player(7),"-цвет оранжевый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Orange_color,Player(8),"-цвет оранжевый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Orange_color,Player(9),"-цвет оранжевый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Orange_color,Player($A),"-цвет оранжевый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Orange_color,Player($B),"-цвет оранжевый",true)
call TriggerAddAction(gg_trg_Orange_color,function Trig_Orange_color_Actions)
set gg_trg_Green_color=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Green_color,Player(0),"-цвет зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Green_color,Player(1),"-цвет зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Green_color,Player(2),"-цвет зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Green_color,Player(3),"-цвет зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Green_color,Player(4),"-цвет зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Green_color,Player(5),"-цвет зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Green_color,Player(6),"-цвет зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Green_color,Player(7),"-цвет зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Green_color,Player(8),"-цвет зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Green_color,Player(9),"-цвет зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Green_color,Player($A),"-цвет зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Green_color,Player($B),"-цвет зеленый",true)
call TriggerAddAction(gg_trg_Green_color,function Trig_Green_color_Actions)
set gg_trg_Rose_color=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Rose_color,Player(0),"-цвет розовый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Rose_color,Player(1),"-цвет розовый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Rose_color,Player(2),"-цвет розовый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Rose_color,Player(3),"-цвет розовый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Rose_color,Player(4),"-цвет розовый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Rose_color,Player(5),"-цвет розовый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Rose_color,Player(6),"-цвет розовый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Rose_color,Player(7),"-цвет розовый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Rose_color,Player(8),"-цвет розовый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Rose_color,Player(9),"-цвет розовый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Rose_color,Player($A),"-цвет розовый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Rose_color,Player($B),"-цвет розовый",true)
call TriggerAddAction(gg_trg_Rose_color,function Trig_Rose_color_Actions)
set gg_trg_Grey_color=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Grey_color,Player(0),"-цвет серый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Grey_color,Player(1),"-цвет серый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Grey_color,Player(2),"-цвет серый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Grey_color,Player(3),"-цвет серый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Grey_color,Player(4),"-цвет серый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Grey_color,Player(5),"-цвет серый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Grey_color,Player(6),"-цвет серый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Grey_color,Player(7),"-цвет серый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Grey_color,Player(8),"-цвет серый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Grey_color,Player(9),"-цвет серый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Grey_color,Player($A),"-цвет серый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Grey_color,Player($B),"-цвет серый",true)
call TriggerAddAction(gg_trg_Grey_color,function Trig_Grey_color_Actions)
set gg_trg_Cyan_color=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Cyan_color,Player(0),"-цвет светло-синий",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Cyan_color,Player(1),"-цвет светло-синий",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Cyan_color,Player(2),"-цвет светло-синий",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Cyan_color,Player(3),"-цвет светло-синий",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Cyan_color,Player(4),"-цвет светло-синий",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Cyan_color,Player(5),"-цвет светло-синий",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Cyan_color,Player(6),"-цвет светло-синий",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Cyan_color,Player(7),"-цвет светло-синий",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Cyan_color,Player(8),"-цвет светло-синий",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Cyan_color,Player(9),"-цвет светло-синий",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Cyan_color,Player($A),"-цвет светло-синий",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Cyan_color,Player($B),"-цвет светло-синий",true)
call TriggerAddAction(gg_trg_Cyan_color,function Trig_Cyan_color_Actions)
set gg_trg_Dark_green_color=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Dark_green_color,Player(0),"-цвет темно-зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Dark_green_color,Player(1),"-цвет темно-зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Dark_green_color,Player(2),"-цвет темно-зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Dark_green_color,Player(3),"-цвет темно-зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Dark_green_color,Player(4),"-цвет темно-зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Dark_green_color,Player(5),"-цвет темно-зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Dark_green_color,Player(6),"-цвет темно-зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Dark_green_color,Player(7),"-цвет темно-зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Dark_green_color,Player(8),"-цвет темно-зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Dark_green_color,Player(9),"-цвет темно-зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Dark_green_color,Player($A),"-цвет темно-зеленый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Dark_green_color,Player($B),"-цвет темно-зеленый",true)
call TriggerAddAction(gg_trg_Dark_green_color,function Trig_Dark_green_color_Actions)
set gg_trg_Brown_color=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Brown_color,Player(0),"-цвет коричневый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Brown_color,Player(1),"-цвет коричневый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Brown_color,Player(2),"-цвет коричневый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Brown_color,Player(3),"-цвет коричневый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Brown_color,Player(4),"-цвет коричневый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Brown_color,Player(5),"-цвет коричневый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Brown_color,Player(6),"-цвет коричневый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Brown_color,Player(7),"-цвет коричневый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Brown_color,Player(8),"-цвет коричневый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Brown_color,Player(9),"-цвет коричневый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Brown_color,Player($A),"-цвет коричневый",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Brown_color,Player($B),"-цвет коричневый",true)
call TriggerAddAction(gg_trg_Brown_color,function Trig_Brown_color_Actions)
set gg_trg_Black_color=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Black_color,Player(0),"-цвет черный",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Black_color,Player(1),"-цвет черный",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Black_color,Player(2),"-цвет черный",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Black_color,Player(3),"-цвет черный",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Black_color,Player(4),"-цвет черный",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Black_color,Player(5),"-цвет черный",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Black_color,Player(6),"-цвет черный",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Black_color,Player(7),"-цвет черный",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Black_color,Player(8),"-цвет черный",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Black_color,Player(9),"-цвет черный",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Black_color,Player($A),"-цвет черный",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Black_color,Player($B),"-цвет черный",true)
call TriggerAddAction(gg_trg_Black_color,function Trig_Black_color_Actions)
set gg_trg_Turn_On=CreateTrigger()
call TriggerAddAction(gg_trg_Turn_On,function Trig_Turn_On_Actions)
set gg_trg_Turn_Off=CreateTrigger()
call TriggerAddAction(gg_trg_Turn_Off,function Trig_Turn_Off_Actions)
set gg_trg_Declare_War_1=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_1)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_1,Player(0))
call TriggerAddAction(gg_trg_Declare_War_1,function Trig_Declare_War_1_Actions)
set gg_trg_Declare_War_2=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_2)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_2,Player(1))
call TriggerAddAction(gg_trg_Declare_War_2,function Trig_Declare_War_2_Actions)
set gg_trg_Declare_War_5=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_5)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_5,Player(4))
call TriggerAddAction(gg_trg_Declare_War_5,function Trig_Declare_War_5_Actions)
set gg_trg_Declare_War_3=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_3)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_3,Player(2))
call TriggerAddAction(gg_trg_Declare_War_3,function Trig_Declare_War_3_Actions)
set gg_trg_Declare_War_4=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_4)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_4,Player(3))
call TriggerAddAction(gg_trg_Declare_War_4,function Trig_Declare_War_4_Actions)
set gg_trg_Declare_War_6=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_6)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_6,Player(5))
call TriggerAddAction(gg_trg_Declare_War_6,function Trig_Declare_War_6_Actions)
set gg_trg_Declare_War_7=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_7)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_7,Player(6))
call TriggerAddAction(gg_trg_Declare_War_7,function Trig_Declare_War_7_Actions)
set gg_trg_Declare_War_8=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_8)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_8,Player(7))
call TriggerAddAction(gg_trg_Declare_War_8,function Trig_Declare_War_8_Actions)
set gg_trg_Declare_War_9=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_9)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_9,Player(8))
call TriggerAddAction(gg_trg_Declare_War_9,function Trig_Declare_War_9_Actions)
set gg_trg_Declare_War_10=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_10)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_10,Player(9))
call TriggerAddAction(gg_trg_Declare_War_10,function Trig_Declare_War_10_Actions)
set gg_trg_Declare_War_11=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_11)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_11,Player($A))
call TriggerAddAction(gg_trg_Declare_War_11,function Trig_Declare_War_11_Actions)
set gg_trg_Declare_War_12=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_12)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_12,Player($B))
call TriggerAddAction(gg_trg_Declare_War_12,function Trig_Declare_War_12_Actions)
set gg_trg_Buildings=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Buildings,EVENT_PLAYER_UNIT_CONSTRUCT_START)
call TriggerAddAction(gg_trg_Buildings,function Trig_Buildings_Actions)
set gg_trg_Heroes=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Heroes,EVENT_PLAYER_UNIT_TRAIN_START)
call TriggerAddAction(gg_trg_Heroes,function Trig_Heroes_Actions)
set gg_trg_Ship=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Ship,3.)
call TriggerAddAction(gg_trg_Ship,function Trig_Ship_Actions)
set gg_trg_Select=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Select,1.)
call TriggerAddAction(gg_trg_Select,function Trig_Select_Actions)
set gg_trg_Race=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_Race,EVENT_PLAYER_UNIT_SPELL_EFFECT)
call TriggerAddCondition(gg_trg_Race,Condition(function Trig_Race_Conditions))
call TriggerAddAction(gg_trg_Race,function Trig_Race_Actions)
set gg_trg_RandomInfo=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_RandomInfo,EVENT_PLAYER_UNIT_SPELL_EFFECT)
call TriggerAddCondition(gg_trg_RandomInfo,Condition(function Trig_RandomInfo_Conditions))
call TriggerAddAction(gg_trg_RandomInfo,function Trig_RandomInfo_Actions)
set gg_trg_RaceSelect1=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_RaceSelect1,Player(0),"-raceselect1",true)
call TriggerAddAction(gg_trg_RaceSelect1,function Trig_RaceSelect1_Actions)
set gg_trg_RaceSelect2=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_RaceSelect2,Player(0),"-raceselect2",true)
call TriggerAddAction(gg_trg_RaceSelect2,function Trig_RaceSelect2_Actions)
set gg_trg_RaceSelect3=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_RaceSelect3,Player(0),"-raceselect3",true)
call TriggerAddAction(gg_trg_RaceSelect3,function Trig_RaceSelect3_Actions)
set gg_trg_RaceSelect4=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_RaceSelect4,Player(0),"-raceselect4",true)
call TriggerAddAction(gg_trg_RaceSelect4,function Trig_RaceSelect4_Actions)
set gg_trg_RaceSelect5=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_RaceSelect5,Player(0),"-raceselect5",true)
call TriggerAddAction(gg_trg_RaceSelect5,function Trig_RaceSelect5_Actions)
set gg_trg_RaceSelect6=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_RaceSelect6,Player(0),"-raceselect6",true)
call TriggerAddAction(gg_trg_RaceSelect6,function Trig_RaceSelect6_Actions)
set gg_trg_RaceSelect7=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_RaceSelect7,Player(0),"-raceselect7",true)
call TriggerAddAction(gg_trg_RaceSelect7,function Trig_RaceSelect7_Actions)
set gg_trg_RaceSelect8=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_RaceSelect8,Player(0),"-raceselect8",true)
call TriggerAddAction(gg_trg_RaceSelect8,function Trig_RaceSelect8_Actions)
set gg_trg_RaceSelect9=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_RaceSelect9,Player(0),"-raceselect9",true)
call TriggerAddAction(gg_trg_RaceSelect9,function Trig_RaceSelect9_Actions)
set gg_trg_RaceSelect10=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_RaceSelect10,Player(0),"-raceselect10",true)
call TriggerAddAction(gg_trg_RaceSelect10,function Trig_RaceSelect10_Actions)
set gg_trg_RaceSelect11=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_RaceSelect11,Player(0),"-raceselect11",true)
call TriggerAddAction(gg_trg_RaceSelect11,function Trig_RaceSelect11_Actions)
set gg_trg_RaceSelect12=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_RaceSelect12,Player(0),"-raceselect12",true)
call TriggerAddAction(gg_trg_RaceSelect12,function Trig_RaceSelect12_Actions)
set gg_trg_Kil=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Kil,Player(0)," Kil",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Kil,Player(1)," Kil",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Kil,Player(2)," Kil",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Kil,Player(3)," Kil",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Kil,Player(4)," Kil",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Kil,Player(5)," Kil",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Kil,Player(6)," Kil",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Kil,Player(7)," Kil",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Kil,Player(8)," Kil",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Kil,Player(9)," Kil",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Kil,Player($A)," Kil",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Kil,Player($B)," Kil",true)
call TriggerAddCondition(gg_trg_Kil,Condition(function Trig_Kil_Conditions))
call TriggerAddAction(gg_trg_Kil,function Trig_Kil_Actions)
set gg_trg_Smertokril=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Smertokril,Player(0),"Smert",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Smertokril,Player(1),"Smert",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Smertokril,Player(2),"Smert",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Smertokril,Player(3),"Smert",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Smertokril,Player(4),"Smert",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Smertokril,Player(5),"Smert",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Smertokril,Player(6),"Smert",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Smertokril,Player(7),"Smert",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Smertokril,Player(8),"Smert",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Smertokril,Player(9),"Smert",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Smertokril,Player($A),"Smert",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Smertokril,Player($B),"Smert",true)
call TriggerAddCondition(gg_trg_Smertokril,Condition(function Trig_Smertokril_Conditions))
call TriggerAddAction(gg_trg_Smertokril,function Trig_Smertokril_Actions)
set gg_trg_LichKing=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_LichKing,gg_unit_H034_0111,EVENT_UNIT_DEATH)
call TriggerAddAction(gg_trg_LichKing,function Trig_LichKing_Actions)
set gg_trg_AlAkir=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_AlAkir,gg_unit_N05H_0633,EVENT_UNIT_DEATH)
call TriggerAddAction(gg_trg_AlAkir,function Trig_AlAkir_Actions)
set gg_trg_Kazzak=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_Kazzak,gg_unit_n02T_0564,EVENT_UNIT_DEATH)
call TriggerAddAction(gg_trg_Kazzak,function Trig_Kazzak_Actions)
set gg_trg_RAGNAROSS=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_RAGNAROSS,gg_unit_N055_0288,EVENT_UNIT_DEATH)
call TriggerAddAction(gg_trg_RAGNAROSS,function Trig_RAGNAROSS_Actions)
set gg_trg_Illidan=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_Illidan,gg_unit_Eevi_0573,EVENT_UNIT_DEATH)
call TriggerAddAction(gg_trg_Illidan,function Trig_Illidan_Actions)
set gg_trg_Soul_Eater=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_Soul_Eater,gg_unit_U00T_0284,EVENT_UNIT_DEATH)
call TriggerAddAction(gg_trg_Soul_Eater,function Trig_Soul_Eater_Actions)
set gg_trg_ChoGall=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_ChoGall,gg_unit_n06P_0634,EVENT_UNIT_DEATH)
call TriggerAddAction(gg_trg_ChoGall,function Trig_ChoGall_Actions)
set gg_trg_Kael=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_Kael,gg_unit_Hkal_0645,EVENT_UNIT_DEATH)
call TriggerAddAction(gg_trg_Kael,function Trig_Kael_Actions)
set gg_trg_Kenya=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_Kenya,gg_unit_Ecen_0090,EVENT_UNIT_DEATH)
call TriggerAddAction(gg_trg_Kenya,function Trig_Kenya_Actions)
set gg_trg_Neptulon=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_Neptulon,gg_unit_N06Q_0668,EVENT_UNIT_DEATH)
call TriggerAddAction(gg_trg_Neptulon,function Trig_Neptulon_Actions)
set gg_trg_Terazan=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_Terazan,gg_unit_N06V_0078,EVENT_UNIT_DEATH)
call TriggerAddAction(gg_trg_Terazan,function Trig_Terazan_Actions)
set gg_trg_Maiev=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_Maiev,gg_unit_Ewrd_0749,EVENT_UNIT_DEATH)
call TriggerAddAction(gg_trg_Maiev,function Trig_Maiev_Actions)
set gg_trg_Gandling=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_Gandling,gg_unit_u024_0228,EVENT_UNIT_DEATH)
call TriggerAddAction(gg_trg_Gandling,function Trig_Gandling_Actions)
set gg_trg_NZOT=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_NZOT,gg_unit_n01W_0109,EVENT_UNIT_DEATH)
call TriggerAddAction(gg_trg_NZOT,function Trig_NZOT_Actions)
set gg_trg_NZOT_agent=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_NZOT_agent,gg_unit_n01Y_0159,EVENT_UNIT_DEATH)
call TriggerAddAction(gg_trg_NZOT_agent,function Trig_NZOT_agent_Actions)
set gg_trg_CTUN=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_CTUN,gg_unit_n01V_0108,EVENT_UNIT_DEATH)
call TriggerAddAction(gg_trg_CTUN,function Trig_CTUN_Actions)
set gg_trg_QOGGSARON=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_QOGGSARON,gg_unit_n01X_0110,EVENT_UNIT_DEATH)
call TriggerAddAction(gg_trg_QOGGSARON,function Trig_QOGGSARON_Actions)
set gg_trg_SHA=CreateTrigger()
call TriggerRegisterUnitEvent(gg_trg_SHA,gg_unit_n02S_0532,EVENT_UNIT_DEATH)
call TriggerAddAction(gg_trg_SHA,function Trig_SHA_Actions)
set gg_trg_ItemCraft1=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_ItemCraft1,EVENT_PLAYER_UNIT_PICKUP_ITEM)
call TriggerAddCondition(gg_trg_ItemCraft1,Condition(function Trig_ItemCraft1_Conditions))
call TriggerAddAction(gg_trg_ItemCraft1,function Trig_ItemCraft1_Actions)
set gg_trg_Lich_King=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Lich_King,.02)
call TriggerAddAction(gg_trg_Lich_King,function Trig_Lich_King_Actions)
set gg_trg_Illidan_H=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Illidan_H,.03)
call TriggerAddAction(gg_trg_Illidan_H,function Trig_Illidan_H_Actions)
set gg_trg_Cshi_Fire_Hand=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Cshi_Fire_Hand,.04)
call TriggerAddAction(gg_trg_Cshi_Fire_Hand,function Trig_Cshi_Fire_Hand_Actions)
set gg_trg_Tirion=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Tirion,.05)
call TriggerAddAction(gg_trg_Tirion,function Trig_Tirion_Actions)
set gg_trg_Kern=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Kern,.06)
call TriggerAddAction(gg_trg_Kern,function Trig_Kern_Actions)
set gg_trg_Vaish=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Vaish,.09)
call TriggerAddAction(gg_trg_Vaish,function Trig_Vaish_Actions)
set gg_trg_Saidan=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Saidan,.1)
call TriggerAddAction(gg_trg_Saidan,function Trig_Saidan_Actions)
set gg_trg_Sylvanas=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Sylvanas,.11)
call TriggerAddAction(gg_trg_Sylvanas,function Trig_Sylvanas_Actions)
set gg_trg_Farion=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Farion,.12)
call TriggerAddAction(gg_trg_Farion,function Trig_Farion_Actions)
set gg_trg_Genn=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Genn,.13)
call TriggerAddAction(gg_trg_Genn,function Trig_Genn_Actions)
set gg_trg_Thrall=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Thrall,.14)
call TriggerAddAction(gg_trg_Thrall,function Trig_Thrall_Actions)
set gg_trg_Izjor=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Izjor,.15)
call TriggerAddAction(gg_trg_Izjor,function Trig_Izjor_Actions)
set gg_trg_VanCleef=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_VanCleef,.19)
call TriggerAddAction(gg_trg_VanCleef,function Trig_VanCleef_Actions)
set gg_trg_Ursol=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Ursol,.2)
call TriggerAddAction(gg_trg_Ursol,function Trig_Ursol_Actions)
set gg_trg_Vanol=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Vanol,.21)
call TriggerAddAction(gg_trg_Vanol,function Trig_Vanol_Actions)
set gg_trg_Magni=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Magni,.22)
call TriggerAddAction(gg_trg_Magni,function Trig_Magni_Actions)
set gg_trg_DrBoom=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_DrBoom,.23)
call TriggerAddAction(gg_trg_DrBoom,function Trig_DrBoom_Actions)
set gg_trg_ChoGallLg=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_ChoGallLg,.24)
call TriggerAddAction(gg_trg_ChoGallLg,function Trig_ChoGallLg_Actions)
set gg_trg_Akama=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Akama,.25)
call TriggerAddAction(gg_trg_Akama,function Trig_Akama_Actions)
set gg_trg_Nerub=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Nerub,.28)
call TriggerAddAction(gg_trg_Nerub,function Trig_Nerub_Actions)
set gg_trg_TrollIce=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_TrollIce,.29)
call TriggerAddAction(gg_trg_TrollIce,function Trig_TrollIce_Actions)
set gg_trg_TrollDArk=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_TrollDArk,.3)
call TriggerAddAction(gg_trg_TrollDArk,function Trig_TrollDArk_Actions)
set gg_trg_TrollForest=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_TrollForest,.31)
call TriggerAddAction(gg_trg_TrollForest,function Trig_TrollForest_Actions)
set gg_trg_LorTemarTeron=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_LorTemarTeron,.32)
call TriggerAddAction(gg_trg_LorTemarTeron,function Trig_LorTemarTeron_Actions)
set gg_trg_Ksavii=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Ksavii,.33)
call TriggerAddAction(gg_trg_Ksavii,function Trig_Ksavii_Actions)
set gg_trg_Kargath=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Kargath,.33)
call TriggerAddAction(gg_trg_Kargath,function Trig_Kargath_Actions)
set gg_trg_Dagran_Taurissan=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Dagran_Taurissan,.34)
call TriggerAddAction(gg_trg_Dagran_Taurissan,function Trig_Dagran_Taurissan_Actions)
set gg_trg_Multiboard_Create=CreateTrigger()
call TriggerRegisterTimerEventSingle(gg_trg_Multiboard_Create,.3)
call TriggerAddAction(gg_trg_Multiboard_Create,function Trig_Multiboard_Create_Actions)
set gg_trg_K=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_K,EVENT_PLAYER_UNIT_DEATH)
call TriggerAddAction(gg_trg_K,function Trig_K_Actions)
set gg_trg_KH=CreateTrigger()
call TriggerRegisterAnyUnitEventBJ(gg_trg_KH,EVENT_PLAYER_UNIT_DEATH)
call TriggerAddCondition(gg_trg_KH,Condition(function Trig_KH_Conditions))
call TriggerAddAction(gg_trg_KH,function Trig_KH_Actions)
set gg_trg_Update=CreateTrigger()
call TriggerRegisterTimerEventPeriodic(gg_trg_Update,1.)
call TriggerAddAction(gg_trg_Update,function Trig_Update_Actions)
set gg_trg_Update2=CreateTrigger()
call TriggerRegisterTimerEventPeriodic(gg_trg_Update2,1.)
call TriggerAddAction(gg_trg_Update2,function Trig_Update2_Actions)
set gg_trg_AutoAlly_Copier_____________________u=CreateTrigger()
call TriggerAddAction(gg_trg_AutoAlly_Copier_____________________u,function Trig_AutoAlly_Copier_____________________u_Actions)
set gg_trg_Declare_War_1_____________________u=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_1_____________________u)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_1_____________________u,Player(0))
call TriggerAddAction(gg_trg_Declare_War_1_____________________u,function Trig_Declare_War_1_____________________u_Actions)
set gg_trg_Declare_War_2_____________________u=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_2_____________________u)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_2_____________________u,Player(1))
call TriggerAddAction(gg_trg_Declare_War_2_____________________u,function Trig_Declare_War_2_____________________u_Actions)
set gg_trg_Declare_War_3_____________________u=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_3_____________________u)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_3_____________________u,Player(2))
call TriggerAddAction(gg_trg_Declare_War_3_____________________u,function Trig_Declare_War_3_____________________u_Actions)
set gg_trg_Declare_War_4_____________________u=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_4_____________________u)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_4_____________________u,Player(3))
call TriggerAddAction(gg_trg_Declare_War_4_____________________u,function Trig_Declare_War_4_____________________u_Actions)
set gg_trg_Declare_War_5_____________________u=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_5_____________________u)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_5_____________________u,Player(4))
call TriggerAddAction(gg_trg_Declare_War_5_____________________u,function Trig_Declare_War_5_____________________u_Actions)
set gg_trg_Declare_War_6_____________________u=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_6_____________________u)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_6_____________________u,Player(5))
call TriggerAddAction(gg_trg_Declare_War_6_____________________u,function Trig_Declare_War_6_____________________u_Actions)
set gg_trg_Declare_War_7_____________________u=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_7_____________________u)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_7_____________________u,Player(6))
call TriggerAddAction(gg_trg_Declare_War_7_____________________u,function Trig_Declare_War_7_____________________u_Actions)
set gg_trg_Declare_War_8_____________________u=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_8_____________________u)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_8_____________________u,Player(7))
call TriggerAddAction(gg_trg_Declare_War_8_____________________u,function Trig_Declare_War_8_____________________u_Actions)
set gg_trg_Declare_War_9_____________________u=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_9_____________________u)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_9_____________________u,Player(8))
call TriggerAddAction(gg_trg_Declare_War_9_____________________u,function Trig_Declare_War_9_____________________u_Actions)
set gg_trg_Declare_War_10_____________________u=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_10_____________________u)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_10_____________________u,Player(9))
call TriggerAddAction(gg_trg_Declare_War_10_____________________u,function Trig_Declare_War_10_____________________u_Actions)
set gg_trg_Declare_War_11_____________________u=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_11_____________________u)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_11_____________________u,Player($A))
call TriggerAddAction(gg_trg_Declare_War_11_____________________u,function Trig_Declare_War_11_____________________u_Actions)
set gg_trg_Declare_War_12_____________________u=CreateTrigger()
call DisableTrigger(gg_trg_Declare_War_12_____________________u)
call TriggerRegisterPlayerEventAllianceChanged(gg_trg_Declare_War_12_____________________u,Player($B))
call TriggerAddAction(gg_trg_Declare_War_12_____________________u,function Trig_Declare_War_12_____________________u_Actions)
set gg_trg_Turn_On_____________________u=CreateTrigger()
call TriggerAddAction(gg_trg_Turn_On_____________________u,function Trig_Turn_On_____________________u_Actions)
set gg_trg_Turn_Off_____________________u=CreateTrigger()
call TriggerAddAction(gg_trg_Turn_Off_____________________u,function Trig_Turn_Off_____________________u_Actions)
set gg_trg_Voina23=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_Voina23,Player(0),"-Egor",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Voina23,Player(1),"-Egor",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Voina23,Player(2),"-Egor",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Voina23,Player(3),"-Egor",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Voina23,Player(4),"-Egor",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Voina23,Player(5),"-Egor",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Voina23,Player(6),"-Egor",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Voina23,Player(7),"-Egor",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Voina23,Player(8),"-Egor",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Voina23,Player(9),"-Egor",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Voina23,Player($A),"-Egor",true)
call TriggerRegisterPlayerChatEvent(gg_trg_Voina23,Player($B),"-Egor",true)
call TriggerAddCondition(gg_trg_Voina23,Condition(function Trig_Voina23_Conditions))
call TriggerAddAction(gg_trg_Voina23,function Trig_Voina23_Actions)
set gg_trg_NochangeName6=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName6,Player(0),"-name Voina23",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName6,Player(1),"-name Voina23",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName6,Player(2),"-name Voina23",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName6,Player(3),"-name Voina23",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName6,Player(4),"-name Voina23",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName6,Player(5),"-name Voina23",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName6,Player(6),"-name Voina23",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName6,Player(7),"-name Voina23",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName6,Player(8),"-name Voina23",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName6,Player(9),"-name Voina23",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName6,Player($A),"-name Voina23",true)
call TriggerRegisterPlayerChatEvent(gg_trg_NochangeName6,Player($B),"-name Voina23",true)
call TriggerAddAction(gg_trg_NochangeName6,function Trig_NochangeName6_Actions)
set gg_trg_gordik0101=CreateTrigger()
call TriggerRegisterPlayerChatEvent(gg_trg_gordik0101,Player(0),"-Dima",true)
call TriggerRegisterPlayerChatEvent(gg_trg_gordik0101,Player(1),"-Dima",true)
call TriggerRegisterPlayerChatEvent(gg_trg_gordik0101,Player(2),"-Dima",true)
call TriggerRegisterPlayerChatEvent(gg_trg_gordik0101,Player(3),"-Dima",true)
call TriggerRegisterPlayerChatEvent(gg_trg_gordik0101,Player(4),"-Dima",true)
call TriggerRegisterPlayerChatEvent(gg_trg_gordik0101,Player(5),"-Dima",true)
call TriggerRegisterPlayerChatEvent(gg_trg_gordik0101,Player(6),"-Dima",true)
call TriggerRegisterPlayerChatEvent(gg_trg_gordik0101,Player(7),"-Dima",true)
call TriggerRegisterPlayerChatEvent(gg_trg_gordik0101,Player(8),"-Dima",true)
call TriggerRegisterPlayerChatEvent(gg_trg_gordik0101,Player(9),"-Dima",true)
call TriggerRegisterPlayerChatEvent(gg_trg_gordik0101,Player($A),"-Dima",true)
call TriggerRegisterPlayerChatEvent(gg_trg_gordik0101,Player($B),"-Dima",true)
call TriggerAddCondition(gg_trg_gordik0101,Condition(function Trig_gordik0101_Conditions))
call TriggerAddAction(gg_trg_gordik0101,function Trig_gordik0101_Actions)
call ConditionalTriggerExecute(gg_trg_AutoAlly_Copier_____________________u)
endfunction
function config takes nothing returns nothing
call SetMapName("TRIGSTR_001")
call SetMapDescription("")
call SetPlayers($C)
call SetTeams($C)
call SetGamePlacement(MAP_PLACEMENT_TEAMS_TOGETHER)
call DefineStartLocation(0,25472.,-27072.)
call DefineStartLocation(1,25472.,-26880.)
call DefineStartLocation(2,25472.,-26560.)
call DefineStartLocation(3,25472.,-26368.)
call DefineStartLocation(4,25664.,-26368.)
call DefineStartLocation(5,25856.,-26368.)
call DefineStartLocation(6,26048.,-26368.)
call DefineStartLocation(7,26048.,-26560.)
call DefineStartLocation(8,26176.,-26816.)
call DefineStartLocation(9,26048.,-27072.)
call DefineStartLocation($A,25920.,-27008.)
call DefineStartLocation($B,25728.,-27072.)
call SetPlayerStartLocation(Player(0),0)
call ForcePlayerStartLocation(Player(0),0)
call SetPlayerColor(Player(0),ConvertPlayerColor(0))
call SetPlayerRacePreference(Player(0),RACE_PREF_RANDOM)
call SetPlayerRaceSelectable(Player(0),true)
call SetPlayerController(Player(0),MAP_CONTROL_USER)
call SetPlayerStartLocation(Player(1),1)
call ForcePlayerStartLocation(Player(1),1)
call SetPlayerColor(Player(1),ConvertPlayerColor(1))
call SetPlayerRacePreference(Player(1),RACE_PREF_RANDOM)
call SetPlayerRaceSelectable(Player(1),true)
call SetPlayerController(Player(1),MAP_CONTROL_USER)
call SetPlayerStartLocation(Player(2),2)
call ForcePlayerStartLocation(Player(2),2)
call SetPlayerColor(Player(2),ConvertPlayerColor(2))
call SetPlayerRacePreference(Player(2),RACE_PREF_RANDOM)
call SetPlayerRaceSelectable(Player(2),true)
call SetPlayerController(Player(2),MAP_CONTROL_USER)
call SetPlayerStartLocation(Player(3),3)
call ForcePlayerStartLocation(Player(3),3)
call SetPlayerColor(Player(3),ConvertPlayerColor(3))
call SetPlayerRacePreference(Player(3),RACE_PREF_RANDOM)
call SetPlayerRaceSelectable(Player(3),true)
call SetPlayerController(Player(3),MAP_CONTROL_USER)
call SetPlayerStartLocation(Player(4),4)
call ForcePlayerStartLocation(Player(4),4)
call SetPlayerColor(Player(4),ConvertPlayerColor(4))
call SetPlayerRacePreference(Player(4),RACE_PREF_RANDOM)
call SetPlayerRaceSelectable(Player(4),true)
call SetPlayerController(Player(4),MAP_CONTROL_USER)
call SetPlayerStartLocation(Player(5),5)
call ForcePlayerStartLocation(Player(5),5)
call SetPlayerColor(Player(5),ConvertPlayerColor(5))
call SetPlayerRacePreference(Player(5),RACE_PREF_RANDOM)
call SetPlayerRaceSelectable(Player(5),true)
call SetPlayerController(Player(5),MAP_CONTROL_USER)
call SetPlayerStartLocation(Player(6),6)
call ForcePlayerStartLocation(Player(6),6)
call SetPlayerColor(Player(6),ConvertPlayerColor(6))
call SetPlayerRacePreference(Player(6),RACE_PREF_RANDOM)
call SetPlayerRaceSelectable(Player(6),true)
call SetPlayerController(Player(6),MAP_CONTROL_USER)
call SetPlayerStartLocation(Player(7),7)
call ForcePlayerStartLocation(Player(7),7)
call SetPlayerColor(Player(7),ConvertPlayerColor(7))
call SetPlayerRacePreference(Player(7),RACE_PREF_RANDOM)
call SetPlayerRaceSelectable(Player(7),true)
call SetPlayerController(Player(7),MAP_CONTROL_USER)
call SetPlayerStartLocation(Player(8),8)
call ForcePlayerStartLocation(Player(8),8)
call SetPlayerColor(Player(8),ConvertPlayerColor(8))
call SetPlayerRacePreference(Player(8),RACE_PREF_RANDOM)
call SetPlayerRaceSelectable(Player(8),true)
call SetPlayerController(Player(8),MAP_CONTROL_USER)
call SetPlayerStartLocation(Player(9),9)
call ForcePlayerStartLocation(Player(9),9)
call SetPlayerColor(Player(9),ConvertPlayerColor(9))
call SetPlayerRacePreference(Player(9),RACE_PREF_RANDOM)
call SetPlayerRaceSelectable(Player(9),true)
call SetPlayerController(Player(9),MAP_CONTROL_USER)
call SetPlayerStartLocation(Player($A),$A)
call ForcePlayerStartLocation(Player($A),$A)
call SetPlayerColor(Player($A),ConvertPlayerColor($A))
call SetPlayerRacePreference(Player($A),RACE_PREF_RANDOM)
call SetPlayerRaceSelectable(Player($A),true)
call SetPlayerController(Player($A),MAP_CONTROL_USER)
call SetPlayerStartLocation(Player($B),$B)
call ForcePlayerStartLocation(Player($B),$B)
call SetPlayerColor(Player($B),ConvertPlayerColor($B))
call SetPlayerRacePreference(Player($B),RACE_PREF_RANDOM)
call SetPlayerRaceSelectable(Player($B),true)
call SetPlayerController(Player($B),MAP_CONTROL_USER)
call InitCustomTeams()
call SetStartLocPrioCount(0,2)
call SetStartLocPrio(0,0,1,MAP_LOC_PRIO_HIGH)
call SetStartLocPrio(0,1,$B,MAP_LOC_PRIO_LOW)
call SetStartLocPrioCount(1,1)
call SetStartLocPrio(1,0,0,MAP_LOC_PRIO_HIGH)
call SetStartLocPrioCount(2,2)
call SetStartLocPrio(2,0,3,MAP_LOC_PRIO_HIGH)
call SetStartLocPrio(2,1,4,MAP_LOC_PRIO_LOW)
call SetStartLocPrioCount(3,2)
call SetStartLocPrio(3,0,2,MAP_LOC_PRIO_HIGH)
call SetStartLocPrio(3,1,4,MAP_LOC_PRIO_HIGH)
call SetStartLocPrioCount(4,3)
call SetStartLocPrio(4,0,2,MAP_LOC_PRIO_LOW)
call SetStartLocPrio(4,1,3,MAP_LOC_PRIO_HIGH)
call SetStartLocPrio(4,2,5,MAP_LOC_PRIO_HIGH)
call SetStartLocPrioCount(5,3)
call SetStartLocPrio(5,0,4,MAP_LOC_PRIO_HIGH)
call SetStartLocPrio(5,1,6,MAP_LOC_PRIO_HIGH)
call SetStartLocPrio(5,2,7,MAP_LOC_PRIO_LOW)
call SetStartLocPrioCount(6,2)
call SetStartLocPrio(6,0,5,MAP_LOC_PRIO_HIGH)
call SetStartLocPrio(6,1,7,MAP_LOC_PRIO_HIGH)
call SetStartLocPrioCount(7,3)
call SetStartLocPrio(7,0,5,MAP_LOC_PRIO_LOW)
call SetStartLocPrio(7,1,6,MAP_LOC_PRIO_HIGH)
call SetStartLocPrio(7,2,8,MAP_LOC_PRIO_LOW)
call SetStartLocPrioCount(8,3)
call SetStartLocPrio(8,0,7,MAP_LOC_PRIO_HIGH)
call SetStartLocPrio(8,1,9,MAP_LOC_PRIO_HIGH)
call SetStartLocPrio(8,2,$A,MAP_LOC_PRIO_HIGH)
call SetStartLocPrioCount(9,1)
call SetStartLocPrio(9,0,$A,MAP_LOC_PRIO_HIGH)
call SetStartLocPrioCount($A,2)
call SetStartLocPrio($A,0,9,MAP_LOC_PRIO_HIGH)
call SetStartLocPrio($A,1,$B,MAP_LOC_PRIO_LOW)
call SetStartLocPrioCount($B,2)
call SetStartLocPrio($B,0,0,MAP_LOC_PRIO_LOW)
call SetStartLocPrio($B,1,$A,MAP_LOC_PRIO_HIGH)
endfunction
