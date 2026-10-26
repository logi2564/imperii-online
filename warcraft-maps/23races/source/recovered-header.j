function R23_InitializeDeclarations takes nothing returns nothing

set udg_R23_udg_wawt=0

set udg_R23_udg_Instagator=null

set udg_R23_udg_CountForTournamet=0

set udg_R23_udg_Compteur1=null

set udg_R23_udg_Tableaudescore=null

set udg_R23_udg_Group=null

set udg_R23_udg_Total_hero=0

set udg_R23_udg_Players_hero=null

set udg_R23_udg_Random_Hero=0

set udg_R23_udg_MultiBoard=null

set udg_R23_udg_List=0

set udg_R23_udg_i=0

set udg_R23_udg_Otbor=0

set udg_R23_udg_oj=0

set udg_R23_gg_rct_NerubianA1Ext=null

set udg_R23_gg_rct_NerubianA1move=null

set udg_R23_gg_rct_NerubianB2Ext=null

set udg_R23_gg_rct_NerubianB2move=null

set udg_R23_gg_rct_NerubianC3Ext=null

set udg_R23_gg_rct_NerubianC3move=null

set udg_R23_gg_rct_NorthrendSnow=null

set udg_R23_gg_rct_NorthrendSnow2=null

set udg_R23_gg_rct_OutlandExt=null

set udg_R23_gg_rct_OutlandMove=null

set udg_R23_gg_rct_SpawnPoint_Broken_isles=null

set udg_R23_gg_rct_SpawnPoint_EasternKingdom1=null

set udg_R23_gg_rct_SpawnPoint_EasternKingdom2=null

set udg_R23_gg_rct_SpawnPoint_Kalimdor1=null

set udg_R23_gg_rct_SpawnPoint_Kalimdor2=null

set udg_R23_gg_rct_SpawnPoint_Northland1=null

set udg_R23_gg_rct_SpawnPoint_Northland2=null

set udg_R23_gg_rct_SpawnPoint_Pandaria=null

set udg_R23_gg_rct_SpawnVision=null

set udg_R23_gg_rct_KTunRaideExt=null

set udg_R23_gg_rct_KTunRaideMove=null

set udg_R23_gg_rct_QogSaronMove=null

set udg_R23_gg_rct_QogSaronExt=null

set udg_R23_gg_rct_NZotMove=null

set udg_R23_gg_rct_NZotExt=null

set udg_R23_gg_rct_Raide01Move=null

set udg_R23_gg_rct_Raide01Ext=null

set udg_R23_gg_rct_QOGGSARON=null

set udg_R23_gg_rct_TEXTKalimdor1=null

set udg_R23_gg_rct_TEXTKalimdor2=null

set udg_R23_gg_rct_TEXTPandaria=null

set udg_R23_gg_rct_TEXTBrokenIsles=null

set udg_R23_gg_rct_TEXTEastKingdom2=null

set udg_R23_gg_rct_TEXTEastKingdom1=null

set udg_R23_gg_rct_TEXTNorth1=null

set udg_R23_gg_rct_TEXTNorth2=null

set udg_R23_gg_rct_SpawnLocation=null

set udg_R23_gg_rct_RAGNAROSS=null

set udg_R23_gg_rct_RAGNAROSS_EXT=null

set udg_R23_gg_rct_HeroSpawn=null

set udg_R23_gg_rct_VAICHmove=null

set udg_R23_gg_rct_VAICHext=null

set udg_R23_gg_rct_EarthExt=null

set udg_R23_gg_rct_EarthMove=null

set udg_R23_gg_rct_KazemateMove=null

set udg_R23_gg_rct_KazemateExt=null

set udg_R23_gg_rct_Necrositetext=null

set udg_R23_gg_rct_Necrositemove=null

set udg_R23_gg_rct_DalaranMove=null

set udg_R23_gg_rct_DalaranExt=null

set udg_R23_gg_rct_Effect1=null

set udg_R23_gg_rct_Effect1_____________________u=null

set udg_R23_gg_rct_DalaranEffect=null

set udg_R23_gg_rct_UlduarEffect=null

set udg_R23_gg_rct_Effect=null

set udg_R23_gg_rct_NaxxramasSpellUsePoint=null

set udg_R23_gg_rct_NaxxramasSpawn=null

set udg_R23_gg_rct_Naxxramas=null

set udg_R23_gg_rct_TEXTOutland=null

set udg_R23_gg_rct_Outland=null

set udg_R23_gg_rct_NaxxramasEXT=null

set udg_R23_gg_rct_NaxxramasMOVE=null

set udg_R23_gg_rct_HeroByCommand1=null

set udg_R23_gg_rct_HeroByCommand2=null

set udg_R23_gg_snd_ArtilleryCorpseExplodeDeath1=null

set udg_R23_gg_snd_UndeadVictory="Sound\\Music\\mp3Music\\UndeadVictory.mp3"

set udg_R23_gg_snd_OrcVictory="Sound\\Music\\mp3Music\\OrcVictory.mp3"

set udg_R23_gg_snd_NightElfVictory="Sound\\Music\\mp3Music\\NightElfVictory.mp3"

set udg_R23_gg_snd_HumanVictory="Sound\\Music\\mp3Music\\HumanVictory.mp3"

set udg_R23_gg_snd_ArthasTheme="Sound\\Music\\mp3Music\\ArthasTheme.mp3"

set udg_R23_gg_snd_PeasantWarcry1=null

set udg_R23_gg_snd_PeasantYes1=null

set udg_R23_gg_snd_PeasantYesAttack4=null

set udg_R23_gg_snd_HeroFarseerPissed1=null

set udg_R23_gg_snd_Doom="Sound\\Music\\mp3Music\\Doom.mp3"

set udg_R23_gg_snd_HPitLordYesAttack1=null

set udg_R23_gg_snd_Credits01="Sound\\Music\\mp3Music\\Credits.mp3"

set udg_R23_gg_snd_BloodElfTheme="Sound\\Music\\mp3Music\\BloodElfTheme.mp3"

set udg_R23_gg_snd_IllidansTheme="Sound\\Music\\mp3Music\\IllidansTheme.mp3"

set udg_R23_gg_snd_A07Kiljaeden30=null

set udg_R23_gg_snd_zsukdarkportal=null

set udg_R23_gg_snd_TragicConfrontation="Sound\\Music\\mp3Music\\TragicConfrontation.mp3"

set udg_R23_gg_snd_DarkVictory="Sound\\Music\\mp3Music\\DarkVictory.mp3"

set udg_R23_gg_snd_U05AArthas02="Sound\\Dialogue\\UndeadCampaign\\Undead05A\\U05AArthas02.mp3"

set udg_R23_gg_snd_L01LichKing44="Sound\\Dialogue\\UndeadExpCamp\\Undead01x\\L01LichKing44.mp3"

set udg_R23_gg_snd_U02KelThuzad27=null

set udg_R23_gg_snd_Kel_Thuzad="Kel'Thuzad.mp3"

set udg_R23_gg_snd_Chivalry="war3mapImported\\Chivalry.mp3"

set udg_R23_gg_snd_GloryGnoms="war3mapImported\\GloryGnoms.mp3"

set udg_R23_gg_trg_Information=null

set udg_R23_gg_trg_Tekst=null

set udg_R23_gg_trg_Start=null

set udg_R23_gg_trg_Time_f1=null

set udg_R23_gg_trg_Time_f2=null

set udg_R23_gg_trg_Time_f4=null

set udg_R23_gg_trg_Time_f5=null

set udg_R23_gg_trg_Time_f6=null

set udg_R23_gg_trg_Time_f7=null

set udg_R23_gg_trg_Time_f8=null

set udg_R23_gg_trg_Liver_Player=null

set udg_R23_gg_trg_AuthorVision=null

set udg_R23_gg_trg_GiveNeutal=null

set udg_R23_gg_trg_SpawnVision=null

set udg_R23_gg_trg_NochangeName1=null

set udg_R23_gg_trg_NochangeName2=null

set udg_R23_gg_trg_NochangeName3=null

set udg_R23_gg_trg_NochangeName4=null

set udg_R23_gg_trg_NochangeName5=null

set udg_R23_gg_trg_NochangeName8=null

set udg_R23_gg_trg_Human=null

set udg_R23_gg_trg_Orc=null

set udg_R23_gg_trg_Undead=null

set udg_R23_gg_trg_NightElf=null

set udg_R23_gg_trg_Nerubian=null

set udg_R23_gg_trg_Dwarfen=null

set udg_R23_gg_trg_Naga=null

set udg_R23_gg_trg_ScorgedElf=null

set udg_R23_gg_trg_Demon=null

set udg_R23_gg_trg_HighElf=null

set udg_R23_gg_trg_ForestTroll=null

set udg_R23_gg_trg_DarkTroll=null

set udg_R23_gg_trg_IceTroll=null

set udg_R23_gg_trg_FelOrc=null

set udg_R23_gg_trg_Kobold=null

set udg_R23_gg_trg_ScarletCrusade=null

set udg_R23_gg_trg_Futborg=null

set udg_R23_gg_trg_Gnoll=null

set udg_R23_gg_trg_Faceless=null

set udg_R23_gg_trg_Ogre=null

set udg_R23_gg_trg_Draenei=null

set udg_R23_gg_trg_Bandite=null

set udg_R23_gg_trg_Tauren=null

set udg_R23_gg_trg_Pandaren=null

set udg_R23_gg_trg_Goblin=null

set udg_R23_gg_trg_Murloc=null

set udg_R23_gg_trg_Centaur=null

set udg_R23_gg_trg_Illidari=null

set udg_R23_gg_trg_Worgen=null

set udg_R23_gg_trg_Forsaken=null

set udg_R23_gg_trg_Elemental=null

set udg_R23_gg_trg_Quraji=null

set udg_R23_gg_trg_DarkDwarf=null

set udg_R23_gg_trg_TwilightHammer=null

set udg_R23_gg_trg_Hostkick1=null

set udg_R23_gg_trg_Hostkick2=null

set udg_R23_gg_trg_Hostkick3=null

set udg_R23_gg_trg_Hostkick4=null

set udg_R23_gg_trg_Hostkick5=null

set udg_R23_gg_trg_Hostkick6=null

set udg_R23_gg_trg_Hostkick7=null

set udg_R23_gg_trg_Hostkick8=null

set udg_R23_gg_trg_Hostkick9=null

set udg_R23_gg_trg_Hostkick10=null

set udg_R23_gg_trg_Hostkick11=null

set udg_R23_gg_trg_Hostkick12=null

set udg_R23_gg_trg_destroy_1=null

set udg_R23_gg_trg_Timedestroy=null

set udg_R23_gg_trg_Debut=null

set udg_R23_gg_trg_Revenus=null

set udg_R23_gg_trg_ND1=null

set udg_R23_gg_trg_ND2=null

set udg_R23_gg_trg_ND3=null

set udg_R23_gg_trg_ND4=null

set udg_R23_gg_trg_ND5=null

set udg_R23_gg_trg_ND6=null

set udg_R23_gg_trg_ND7=null

set udg_R23_gg_trg_ND8=null

set udg_R23_gg_trg_ND9=null

set udg_R23_gg_trg_KL1=null

set udg_R23_gg_trg_KL2=null

set udg_R23_gg_trg_KL3=null

set udg_R23_gg_trg_KL4=null

set udg_R23_gg_trg_KL5=null

set udg_R23_gg_trg_KL6=null

set udg_R23_gg_trg_KL7=null

set udg_R23_gg_trg_KL8=null

set udg_R23_gg_trg_KL9=null

set udg_R23_gg_trg_KL10=null

set udg_R23_gg_trg_KL11=null

set udg_R23_gg_trg_KL12=null

set udg_R23_gg_trg_KL13=null

set udg_R23_gg_trg_KL14=null

set udg_R23_gg_trg_PA1=null

set udg_R23_gg_trg_PA2=null

set udg_R23_gg_trg_PA3=null

set udg_R23_gg_trg_PA4=null

set udg_R23_gg_trg_PA5=null

set udg_R23_gg_trg_BI1=null

set udg_R23_gg_trg_BI2=null

set udg_R23_gg_trg_BI3=null

set udg_R23_gg_trg_BI4=null

set udg_R23_gg_trg_BI5=null

set udg_R23_gg_trg_Bl6=null

set udg_R23_gg_trg_BI7=null

set udg_R23_gg_trg_BI8=null

set udg_R23_gg_trg_BI9=null

set udg_R23_gg_trg_BI10=null

set udg_R23_gg_trg_EK1=null

set udg_R23_gg_trg_EK2=null

set udg_R23_gg_trg_EK3=null

set udg_R23_gg_trg_EK4=null

set udg_R23_gg_trg_EK5=null

set udg_R23_gg_trg_EK6=null

set udg_R23_gg_trg_EK7=null

set udg_R23_gg_trg_EK8=null

set udg_R23_gg_trg_EK9=null

set udg_R23_gg_trg_EK10=null

set udg_R23_gg_trg_EK11=null

set udg_R23_gg_trg_EK12=null

set udg_R23_gg_trg_EK13=null

set udg_R23_gg_trg_EK14=null

set udg_R23_gg_trg_EK15=null

set udg_R23_gg_trg_EK16=null

set udg_R23_gg_trg_EK17=null

set udg_R23_gg_trg_EK18=null

set udg_R23_gg_trg_EK19=null

set udg_R23_gg_trg_EK20=null

set udg_R23_gg_trg_EK21=null

set udg_R23_gg_trg_EK22=null

set udg_R23_gg_trg_OUT1=null

set udg_R23_gg_trg_OUT2=null

set udg_R23_gg_trg_OUT3=null

set udg_R23_gg_trg_OUT4=null

set udg_R23_gg_trg_OUT5=null

set udg_R23_gg_trg_OUT6=null

set udg_R23_gg_trg_OUT7=null

set udg_R23_gg_trg_ZN1=null

set udg_R23_gg_trg_VE1=null

set udg_R23_gg_trg_KT=null

set udg_R23_gg_trg_Managorn1=null

set udg_R23_gg_trg_Managorn2=null

set udg_R23_gg_trg_Managorn3=null

set udg_R23_gg_trg_Managorn4=null

set udg_R23_gg_trg_Production_en_chaine=null

set udg_R23_gg_trg_Camera_command=null

set udg_R23_gg_trg_Name_command=null

set udg_R23_gg_trg_Red_color=null

set udg_R23_gg_trg_Blue_color=null

set udg_R23_gg_trg_Lightblue_color=null

set udg_R23_gg_trg_Viol_color=null

set udg_R23_gg_trg_Yelow_color=null

set udg_R23_gg_trg_Orange_color=null

set udg_R23_gg_trg_Green_color=null

set udg_R23_gg_trg_Rose_color=null

set udg_R23_gg_trg_Grey_color=null

set udg_R23_gg_trg_Cyan_color=null

set udg_R23_gg_trg_Dark_green_color=null

set udg_R23_gg_trg_Brown_color=null

set udg_R23_gg_trg_Black_color=null

set udg_R23_gg_trg_Turn_On=null

set udg_R23_gg_trg_Turn_Off=null

set udg_R23_gg_trg_Declare_War_1=null

set udg_R23_gg_trg_Declare_War_2=null

set udg_R23_gg_trg_Declare_War_5=null

set udg_R23_gg_trg_Declare_War_3=null

set udg_R23_gg_trg_Declare_War_4=null

set udg_R23_gg_trg_Declare_War_6=null

set udg_R23_gg_trg_Declare_War_7=null

set udg_R23_gg_trg_Declare_War_8=null

set udg_R23_gg_trg_Declare_War_9=null

set udg_R23_gg_trg_Declare_War_10=null

set udg_R23_gg_trg_Declare_War_11=null

set udg_R23_gg_trg_Declare_War_12=null

set udg_R23_gg_trg_Buildings=null

set udg_R23_gg_trg_Heroes=null

set udg_R23_gg_trg_Ship=null

set udg_R23_gg_trg_Select=null

set udg_R23_gg_trg_Race=null

set udg_R23_gg_trg_RandomInfo=null

set udg_R23_gg_trg_RaceSelect1=null

set udg_R23_gg_trg_RaceSelect2=null

set udg_R23_gg_trg_RaceSelect3=null

set udg_R23_gg_trg_RaceSelect4=null

set udg_R23_gg_trg_RaceSelect5=null

set udg_R23_gg_trg_RaceSelect6=null

set udg_R23_gg_trg_RaceSelect7=null

set udg_R23_gg_trg_RaceSelect8=null

set udg_R23_gg_trg_RaceSelect9=null

set udg_R23_gg_trg_RaceSelect10=null

set udg_R23_gg_trg_RaceSelect11=null

set udg_R23_gg_trg_RaceSelect12=null

set udg_R23_gg_trg_Kil=null

set udg_R23_gg_trg_Smertokril=null

set udg_R23_gg_trg_OldGodsPower=null

set udg_R23_gg_trg_LichKing=null

set udg_R23_gg_trg_AlAkir=null

set udg_R23_gg_trg_Kazzak=null

set udg_R23_gg_trg_RAGNAROSS=null

set udg_R23_gg_trg_Illidan=null

set udg_R23_gg_trg_Soul_Eater=null

set udg_R23_gg_trg_ChoGall=null

set udg_R23_gg_trg_Kael=null

set udg_R23_gg_trg_Kenya=null

set udg_R23_gg_trg_Neptulon=null

set udg_R23_gg_trg_Terazan=null

set udg_R23_gg_trg_Maiev=null

set udg_R23_gg_trg_Gandling=null

set udg_R23_gg_trg_NZOT=null

set udg_R23_gg_trg_NZOT_agent=null

set udg_R23_gg_trg_CTUN=null

set udg_R23_gg_trg_QOGGSARON=null

set udg_R23_gg_trg_SHA=null

set udg_R23_gg_trg_ItemCraft1=null

set udg_R23_gg_trg_Lich_King=null

set udg_R23_gg_trg_Illidan_H=null

set udg_R23_gg_trg_Cshi_Fire_Hand=null

set udg_R23_gg_trg_Tirion=null

set udg_R23_gg_trg_Kern=null

set udg_R23_gg_trg_Vaish=null

set udg_R23_gg_trg_Saidan=null

set udg_R23_gg_trg_Sylvanas=null

set udg_R23_gg_trg_Farion=null

set udg_R23_gg_trg_Genn=null

set udg_R23_gg_trg_Thrall=null

set udg_R23_gg_trg_Izjor=null

set udg_R23_gg_trg_VanCleef=null

set udg_R23_gg_trg_Ursol=null

set udg_R23_gg_trg_Vanol=null

set udg_R23_gg_trg_Magni=null

set udg_R23_gg_trg_DrBoom=null

set udg_R23_gg_trg_ChoGallLg=null

set udg_R23_gg_trg_Akama=null

set udg_R23_gg_trg_Nerub=null

set udg_R23_gg_trg_TrollIce=null

set udg_R23_gg_trg_TrollDArk=null

set udg_R23_gg_trg_TrollForest=null

set udg_R23_gg_trg_LorTemarTeron=null

set udg_R23_gg_trg_Ksavii=null

set udg_R23_gg_trg_Kargath=null

set udg_R23_gg_trg_Dagran_Taurissan=null

set udg_R23_gg_trg_Multiboard_Create=null

set udg_R23_gg_trg_K=null

set udg_R23_gg_trg_KH=null

set udg_R23_gg_trg_Update=null

set udg_R23_gg_trg_Update2=null

set udg_R23_gg_trg_AutoAlly_Copier_____________________u=null

set udg_R23_gg_trg_Declare_War_1_____________________u=null

set udg_R23_gg_trg_Declare_War_2_____________________u=null

set udg_R23_gg_trg_Declare_War_3_____________________u=null

set udg_R23_gg_trg_Declare_War_4_____________________u=null

set udg_R23_gg_trg_Declare_War_5_____________________u=null

set udg_R23_gg_trg_Declare_War_6_____________________u=null

set udg_R23_gg_trg_Declare_War_7_____________________u=null

set udg_R23_gg_trg_Declare_War_8_____________________u=null

set udg_R23_gg_trg_Declare_War_9_____________________u=null

set udg_R23_gg_trg_Declare_War_10_____________________u=null

set udg_R23_gg_trg_Declare_War_11_____________________u=null

set udg_R23_gg_trg_Declare_War_12_____________________u=null

set udg_R23_gg_trg_Turn_On_____________________u=null

set udg_R23_gg_trg_Turn_Off_____________________u=null

set udg_R23_gg_trg_lb_DyuingUnit=null

set udg_R23_gg_trg_RemoveUnitAntiLag=null

set udg_R23_gg_trg_Voina23=null

set udg_R23_gg_trg_NochangeName6=null

set udg_R23_gg_trg_gordik0101=null

set udg_R23_gg_trg_heavyboy2005=null

set udg_R23_gg_trg_NochangeName7=null

set udg_R23_gg_unit_h01M_0069=null

set udg_R23_gg_unit_h01K_0057=null

set udg_R23_gg_unit_h01I_0067=null

set udg_R23_gg_unit_h01H_0066=null

set udg_R23_gg_unit_h01G_0064=null

set udg_R23_gg_unit_h01F_0062=null

set udg_R23_gg_unit_h01E_0010=null

set udg_R23_gg_unit_h01D_0061=null

set udg_R23_gg_unit_h01A_0060=null

set udg_R23_gg_unit_h01C_0059=null

set udg_R23_gg_unit_h01B_0058=null

set udg_R23_gg_unit_h001_0011=null

set udg_R23_gg_unit_h00A_0028=null

set udg_R23_gg_unit_h009_0029=null

set udg_R23_gg_unit_h008_0027=null

set udg_R23_gg_unit_h007_0026=null

set udg_R23_gg_unit_h006_0025=null

set udg_R23_gg_unit_h002_0018=null

set udg_R23_gg_unit_h005_0024=null

set udg_R23_gg_unit_h004_0023=null

set udg_R23_gg_unit_h003_0022=null

set udg_R23_gg_unit_h00B_0013=null

set udg_R23_gg_unit_h00C_0014=null

set udg_R23_gg_unit_h00D_0015=null

set udg_R23_gg_unit_h00E_0016=null

set udg_R23_gg_unit_h00F_0017=null

set udg_R23_gg_unit_h00G_0019=null

set udg_R23_gg_unit_h00H_0020=null

set udg_R23_gg_unit_h00I_0021=null

set udg_R23_gg_unit_h00J_0030=null

set udg_R23_gg_unit_h00K_0031=null

set udg_R23_gg_unit_h00L_0032=null

set udg_R23_gg_unit_h00M_0033=null

set udg_R23_gg_unit_h00N_0034=null

set udg_R23_gg_unit_h00O_0035=null

set udg_R23_gg_unit_h00P_0036=null

set udg_R23_gg_unit_h00Q_0037=null

set udg_R23_gg_unit_h00R_0038=null

set udg_R23_gg_unit_h00S_0039=null

set udg_R23_gg_unit_h00T_0040=null

set udg_R23_gg_unit_h00U_0041=null

set udg_R23_gg_unit_h00V_0042=null

set udg_R23_gg_unit_h00W_0043=null

set udg_R23_gg_unit_h00X_0044=null

set udg_R23_gg_unit_h00Y_0045=null

set udg_R23_gg_unit_h00Z_0046=null

set udg_R23_gg_unit_h010_0047=null

set udg_R23_gg_unit_h011_0048=null

set udg_R23_gg_unit_h012_0049=null

set udg_R23_gg_unit_h013_0050=null

set udg_R23_gg_unit_h014_0051=null

set udg_R23_gg_unit_h015_0052=null

set udg_R23_gg_unit_h016_0053=null

set udg_R23_gg_unit_h017_0054=null

set udg_R23_gg_unit_h018_0055=null

set udg_R23_gg_unit_h019_0056=null

set udg_R23_gg_unit_h01J_0068=null

set udg_R23_gg_unit_h01N_0065=null

set udg_R23_gg_unit_n01V_0108=null

set udg_R23_gg_unit_n01W_0109=null

set udg_R23_gg_unit_n01X_0110=null

set udg_R23_gg_unit_n01Y_0159=null

set udg_R23_gg_unit_h07P_0420=null

set udg_R23_gg_unit_h07P_0419=null

set udg_R23_gg_unit_h07P_0418=null

set udg_R23_gg_unit_h07P_0417=null

set udg_R23_gg_unit_h07O_0416=null

set udg_R23_gg_unit_h07R_0791=null

set udg_R23_gg_unit_h07Q_0422=null

set udg_R23_gg_unit_h07S_0202=null

set udg_R23_gg_unit_h07N_0415=null

set udg_R23_gg_unit_U00T_0284=null

set udg_R23_gg_unit_H034_0111=null

set udg_R23_gg_unit_Ewrd_0749=null

set udg_R23_gg_unit_Eevi_0573=null

set udg_R23_gg_unit_h07F_0793=null

set udg_R23_gg_unit_h046_0405=null

set udg_R23_gg_unit_n02S_0532=null

set udg_R23_gg_unit_h088_0545=null

set udg_R23_gg_unit_n02T_0564=null

set udg_R23_gg_unit_Ecen_0090=null

set udg_R23_gg_unit_N055_0288=null

set udg_R23_gg_unit_h052_0627=null

set udg_R23_gg_unit_h053_0628=null

set udg_R23_gg_unit_N05H_0633=null

set udg_R23_gg_unit_h05M_0632=null

set udg_R23_gg_unit_n06P_0634=null

set udg_R23_gg_unit_Hkal_0645=null

set udg_R23_gg_unit_N06Q_0668=null

set udg_R23_gg_unit_h078_0695=null

set udg_R23_gg_unit_N06V_0078=null

set udg_R23_gg_unit_u024_0228=null

set udg_R23_gg_dest_B000_10403=null

set udg_R23_gg_dest_B000_5046=null

endfunction

function R23_InitGlobals takes nothing returns nothing
local integer i=0
set udg_R23_udg_Compteur1=CreateTimer()
set i=0
loop
exitwhen(i>1)
set udg_R23_udg_Col_vo_units[i]=0
set udg_R23_udg_Can_pick[i]=false
set udg_R23_udg_PlayersCount[i]=0
set udg_R23_udg_PlayersForce[i]=CreateForce()
set udg_R23_udg_Kill[i]=0
set udg_R23_udg_Death[i]=0
set udg_R23_udg_Kills[i]=0
set udg_R23_udg_Deaths[i]=0
set i=i+1
endloop
set udg_R23_udg_Group=CreateForce()
set udg_R23_udg_Players_hero=CreateForce()
set udg_R23_udg_MultiBoard=CreateMultiboard()
endfunction

function R23_ItemTable000000_DropItems takes nothing returns nothing
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
set canDrop=(GetChangingUnitPrevOwner()==Player(12))
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

function R23_ItemTable000001_DropItems takes nothing returns nothing
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
set canDrop=(GetChangingUnitPrevOwner()==Player(12))
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

function R23_ItemTable000002_DropItems takes nothing returns nothing
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
set canDrop=(GetChangingUnitPrevOwner()==Player(12))
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

function R23_ItemTable000003_DropItems takes nothing returns nothing
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
set canDrop=(GetChangingUnitPrevOwner()==Player(12))
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

function R23_ItemTable000004_DropItems takes nothing returns nothing
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
set canDrop=(GetChangingUnitPrevOwner()==Player(12))
endif
endif
if(canDrop)then
call RandomDistReset()
call RandomDistAddItem('I00B',10)
call RandomDistAddItem('I005',10)
call RandomDistAddItem('I00D',10)
call RandomDistAddItem('I00A',10)
call RandomDistAddItem('I00C',10)
call RandomDistAddItem('I009',10)
call RandomDistAddItem('I007',10)
call RandomDistAddItem('I006',10)
call RandomDistAddItem('I00E',10)
call RandomDistAddItem('I006',10)
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

function R23_Unit000284_DropItems takes nothing returns nothing
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
set canDrop=(GetChangingUnitPrevOwner()==Player(12))
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

function R23_Unit000306_DropItems takes nothing returns nothing
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
set canDrop=(GetChangingUnitPrevOwner()==Player(12))
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

function R23_Unit000382_DropItems takes nothing returns nothing
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
set canDrop=(GetChangingUnitPrevOwner()==Player(12))
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

function R23_Unit000384_DropItems takes nothing returns nothing
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
set canDrop=(GetChangingUnitPrevOwner()==Player(12))
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

function R23_Unit000564_DropItems takes nothing returns nothing
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
set canDrop=(GetChangingUnitPrevOwner()==Player(12))
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

function R23_Unit000565_DropItems takes nothing returns nothing
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
set canDrop=(GetChangingUnitPrevOwner()==Player(12))
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

function R23_Unit000599_DropItems takes nothing returns nothing
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
set canDrop=(GetChangingUnitPrevOwner()==Player(12))
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

function R23_Unit000631_DropItems takes nothing returns nothing
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
set canDrop=(GetChangingUnitPrevOwner()==Player(12))
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

function R23_Unit000634_DropItems takes nothing returns nothing
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
set canDrop=(GetChangingUnitPrevOwner()==Player(12))
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

function R23_Unit000645_DropItems takes nothing returns nothing
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
set canDrop=(GetChangingUnitPrevOwner()==Player(12))
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

function R23_Unit000668_DropItems takes nothing returns nothing
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
set canDrop=(GetChangingUnitPrevOwner()==Player(12))
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

function R23_Unit000702_DropItems takes nothing returns nothing
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
set canDrop=(GetChangingUnitPrevOwner()==Player(12))
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

function R23_InitSounds takes nothing returns nothing
set udg_R23_gg_snd_ArtilleryCorpseExplodeDeath1=CreateSound("Sound\\Units\\Death\\ArtilleryCorpseExplodeDeath1.wav",false,true,true,10,10,"DefaultEAXON")
call SetSoundParamsFromLabel(udg_R23_gg_snd_ArtilleryCorpseExplodeDeath1,"ArtilleryExplodeDeath")
call SetSoundDuration(udg_R23_gg_snd_ArtilleryCorpseExplodeDeath1,1486)
set udg_R23_gg_snd_PeasantWarcry1=CreateSound("Units\\Human\\Peasant\\PeasantWarcry1.wav",false,true,true,10,10,"DefaultEAXON")
call SetSoundParamsFromLabel(udg_R23_gg_snd_PeasantWarcry1,"PeasantWarcry")
call SetSoundDuration(udg_R23_gg_snd_PeasantWarcry1,1182)
set udg_R23_gg_snd_PeasantYes1=CreateSound("Units\\Human\\Peasant\\PeasantYes1.wav",false,true,true,10,10,"DefaultEAXON")
call SetSoundParamsFromLabel(udg_R23_gg_snd_PeasantYes1,"PeasantYes")
call SetSoundDuration(udg_R23_gg_snd_PeasantYes1,373)
set udg_R23_gg_snd_PeasantYesAttack4=CreateSound("Units\\Human\\Peasant\\PeasantYesAttack4.wav",false,true,true,10,10,"DefaultEAXON")
call SetSoundParamsFromLabel(udg_R23_gg_snd_PeasantYesAttack4,"PeasantYesAttack")
call SetSoundDuration(udg_R23_gg_snd_PeasantYesAttack4,1886)
set udg_R23_gg_snd_HeroFarseerPissed1=CreateSound("Units\\Orc\\HeroFarseer\\HeroFarseerPissed1.wav",false,true,true,10,10,"HeroAcksEAX")
call SetSoundParamsFromLabel(udg_R23_gg_snd_HeroFarseerPissed1,"HeroFarseerPissed")
call SetSoundDuration(udg_R23_gg_snd_HeroFarseerPissed1,3857)
set udg_R23_gg_snd_HPitLordYesAttack1=CreateSound("Units\\Demon\\HeroPitLord\\HPitLordYesAttack1.wav",false,true,true,10,10,"HeroAcksEAX")
call SetSoundParamsFromLabel(udg_R23_gg_snd_HPitLordYesAttack1,"HeroPitLordYesAttack")
call SetSoundDuration(udg_R23_gg_snd_HPitLordYesAttack1,1658)
set udg_R23_gg_snd_A07Kiljaeden30=CreateSound("Sound\\Dialogue\\HumanExpCamp\\Human07xInterlude\\A07Kiljaeden30.mp3",false,false,false,10,10,"")
call SetSoundParamsFromLabel(udg_R23_gg_snd_A07Kiljaeden30,"A07Kiljaeden30")
call SetSoundDuration(udg_R23_gg_snd_A07Kiljaeden30,17371)
set udg_R23_gg_snd_zsukdarkportal=CreateSound("war3mapImported\\zsukdarkportal.mp3",false,false,false,10,10,"")
call SetSoundChannel(udg_R23_gg_snd_zsukdarkportal,0)
call SetSoundVolume(udg_R23_gg_snd_zsukdarkportal,127)
call SetSoundPitch(udg_R23_gg_snd_zsukdarkportal,1.)
set udg_R23_gg_snd_U02KelThuzad27=CreateSound("Sound\\Dialogue\\UndeadCampaign\\Undead02\\U02KelThuzad27.mp3",false,false,false,10,10,"")
call SetSoundParamsFromLabel(udg_R23_gg_snd_U02KelThuzad27,"U02KelThuzad27")
call SetSoundDuration(udg_R23_gg_snd_U02KelThuzad27,8594)
endfunction

function R23_CreateAllDestructables takes nothing returns nothing
local destructable d
local trigger t
local real life
set udg_R23_gg_dest_B000_5046=CreateDestructable('B000',4096.,1088.,318.,.938,3)
set udg_R23_gg_dest_B000_10403=CreateDestructable('B000',4096.,1216.,318.,.938,3)
endfunction

function R23_CreateBuildingsForPlayer0 takes nothing returns nothing
local player p=Player(0)
local unit u
local integer unitID
local trigger t
local real life
set u=CreateUnit(p,'n00B',25440.,-27104.,270.)
endfunction

function R23_CreateBuildingsForPlayer1 takes nothing returns nothing
local player p=Player(1)
local unit u
local integer unitID
local trigger t
local real life
set u=CreateUnit(p,'n00B',25440.,-26848.,270.)
endfunction

function R23_CreateBuildingsForPlayer2 takes nothing returns nothing
local player p=Player(2)
local unit u
local integer unitID
local trigger t
local real life
set u=CreateUnit(p,'n00B',25440.,-26592.,270.)
endfunction

function R23_CreateBuildingsForPlayer3 takes nothing returns nothing
local player p=Player(3)
local unit u
local integer unitID
local trigger t
local real life
set u=CreateUnit(p,'n00B',25440.,-26336.,270.)
endfunction

function R23_CreateBuildingsForPlayer4 takes nothing returns nothing
local player p=Player(4)
local unit u
local integer unitID
local trigger t
local real life
set u=CreateUnit(p,'n00B',25696.,-26336.,270.)
endfunction

function R23_CreateBuildingsForPlayer5 takes nothing returns nothing
local player p=Player(5)
local unit u
local integer unitID
local trigger t
local real life
set u=CreateUnit(p,'n00B',25952.,-26336.,270.)
endfunction

function R23_CreateBuildingsForPlayer6 takes nothing returns nothing
local player p=Player(6)
local unit u
local integer unitID
local trigger t
local real life
set u=CreateUnit(p,'n00B',26208.,-26336.,270.)
endfunction

function R23_CreateBuildingsForPlayer7 takes nothing returns nothing
local player p=Player(7)
local unit u
local integer unitID
local trigger t
local real life
set u=CreateUnit(p,'n00B',26208.,-26592.,270.)
endfunction

function R23_CreateBuildingsForPlayer8 takes nothing returns nothing
local player p=Player(8)
local unit u
local integer unitID
local trigger t
local real life
set u=CreateUnit(p,'n00B',26208.,-26848.,270.)
endfunction

function R23_CreateBuildingsForPlayer9 takes nothing returns nothing
local player p=Player(9)
local unit u
local integer unitID
local trigger t
local real life
set u=CreateUnit(p,'n00B',26208.,-27104.,270.)
endfunction

function R23_CreateBuildingsForPlayer10 takes nothing returns nothing
local player p=Player(10)
local unit u
local integer unitID
local trigger t
local real life
set u=CreateUnit(p,'n00B',25952.,-27104.,270.)
endfunction

function R23_CreateBuildingsForPlayer11 takes nothing returns nothing
local player p=Player(11)
local unit u
local integer unitID
local trigger t
local real life
set u=CreateUnit(p,'n00B',25696.,-27104.,270.)
endfunction

function R23_CreateNeutralHostileBuildings takes nothing returns nothing
local player p=Player(12)
local unit u
local integer unitID
local trigger t
local real life
set udg_R23_gg_unit_h01E_0010=gg_unit_h01E_0010
set life=GetUnitState(udg_R23_gg_unit_h01E_0010,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h001_0011=gg_unit_h001_0011
set life=GetUnitState(udg_R23_gg_unit_h001_0011,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h00B_0013=gg_unit_h00B_0013
set life=GetUnitState(udg_R23_gg_unit_h00B_0013,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h00C_0014=gg_unit_h00C_0014
set life=GetUnitState(udg_R23_gg_unit_h00C_0014,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h00D_0015=gg_unit_h00D_0015
set life=GetUnitState(udg_R23_gg_unit_h00D_0015,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h00E_0016=gg_unit_h00E_0016
set life=GetUnitState(udg_R23_gg_unit_h00E_0016,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h00F_0017=gg_unit_h00F_0017
set life=GetUnitState(udg_R23_gg_unit_h00F_0017,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h002_0018=gg_unit_h002_0018
set life=GetUnitState(udg_R23_gg_unit_h002_0018,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h00G_0019=gg_unit_h00G_0019
set life=GetUnitState(udg_R23_gg_unit_h00G_0019,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h00H_0020=gg_unit_h00H_0020
set life=GetUnitState(udg_R23_gg_unit_h00H_0020,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h00I_0021=gg_unit_h00I_0021
set life=GetUnitState(udg_R23_gg_unit_h00I_0021,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h003_0022=gg_unit_h003_0022
set life=GetUnitState(udg_R23_gg_unit_h003_0022,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h004_0023=gg_unit_h004_0023
set life=GetUnitState(udg_R23_gg_unit_h004_0023,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h005_0024=gg_unit_h005_0024
set life=GetUnitState(udg_R23_gg_unit_h005_0024,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h006_0025=gg_unit_h006_0025
set life=GetUnitState(udg_R23_gg_unit_h006_0025,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h007_0026=gg_unit_h007_0026
set life=GetUnitState(udg_R23_gg_unit_h007_0026,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h008_0027=gg_unit_h008_0027
set life=GetUnitState(udg_R23_gg_unit_h008_0027,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h00A_0028=gg_unit_h00A_0028
set life=GetUnitState(udg_R23_gg_unit_h00A_0028,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h009_0029=gg_unit_h009_0029
set life=GetUnitState(udg_R23_gg_unit_h009_0029,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h00J_0030=gg_unit_h00J_0030
set life=GetUnitState(udg_R23_gg_unit_h00J_0030,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h00K_0031=gg_unit_h00K_0031
set life=GetUnitState(udg_R23_gg_unit_h00K_0031,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h00L_0032=gg_unit_h00L_0032
set life=GetUnitState(udg_R23_gg_unit_h00L_0032,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h00M_0033=gg_unit_h00M_0033
set life=GetUnitState(udg_R23_gg_unit_h00M_0033,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h00N_0034=gg_unit_h00N_0034
set life=GetUnitState(udg_R23_gg_unit_h00N_0034,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h00O_0035=gg_unit_h00O_0035
set life=GetUnitState(udg_R23_gg_unit_h00O_0035,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h00P_0036=gg_unit_h00P_0036
set life=GetUnitState(udg_R23_gg_unit_h00P_0036,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h00Q_0037=gg_unit_h00Q_0037
set life=GetUnitState(udg_R23_gg_unit_h00Q_0037,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h00R_0038=gg_unit_h00R_0038
set life=GetUnitState(udg_R23_gg_unit_h00R_0038,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h00S_0039=gg_unit_h00S_0039
set life=GetUnitState(udg_R23_gg_unit_h00S_0039,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h00T_0040=gg_unit_h00T_0040
set life=GetUnitState(udg_R23_gg_unit_h00T_0040,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h00U_0041=gg_unit_h00U_0041
set life=GetUnitState(udg_R23_gg_unit_h00U_0041,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h00V_0042=gg_unit_h00V_0042
set life=GetUnitState(udg_R23_gg_unit_h00V_0042,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h00W_0043=gg_unit_h00W_0043
set life=GetUnitState(udg_R23_gg_unit_h00W_0043,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h00X_0044=gg_unit_h00X_0044
set life=GetUnitState(udg_R23_gg_unit_h00X_0044,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h00Y_0045=gg_unit_h00Y_0045
set life=GetUnitState(udg_R23_gg_unit_h00Y_0045,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h00Z_0046=gg_unit_h00Z_0046
set life=GetUnitState(udg_R23_gg_unit_h00Z_0046,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h010_0047=gg_unit_h010_0047
set life=GetUnitState(udg_R23_gg_unit_h010_0047,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h011_0048=gg_unit_h011_0048
set life=GetUnitState(udg_R23_gg_unit_h011_0048,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h012_0049=gg_unit_h012_0049
set life=GetUnitState(udg_R23_gg_unit_h012_0049,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h013_0050=gg_unit_h013_0050
set life=GetUnitState(udg_R23_gg_unit_h013_0050,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h014_0051=gg_unit_h014_0051
set life=GetUnitState(udg_R23_gg_unit_h014_0051,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h015_0052=gg_unit_h015_0052
set life=GetUnitState(udg_R23_gg_unit_h015_0052,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h016_0053=gg_unit_h016_0053
set life=GetUnitState(udg_R23_gg_unit_h016_0053,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h017_0054=gg_unit_h017_0054
set life=GetUnitState(udg_R23_gg_unit_h017_0054,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h018_0055=gg_unit_h018_0055
set life=GetUnitState(udg_R23_gg_unit_h018_0055,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h019_0056=gg_unit_h019_0056
set life=GetUnitState(udg_R23_gg_unit_h019_0056,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h01K_0057=gg_unit_h01K_0057
set life=GetUnitState(udg_R23_gg_unit_h01K_0057,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h01B_0058=gg_unit_h01B_0058
set life=GetUnitState(udg_R23_gg_unit_h01B_0058,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h01C_0059=gg_unit_h01C_0059
set life=GetUnitState(udg_R23_gg_unit_h01C_0059,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h01A_0060=gg_unit_h01A_0060
set life=GetUnitState(udg_R23_gg_unit_h01A_0060,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h01D_0061=gg_unit_h01D_0061
set life=GetUnitState(udg_R23_gg_unit_h01D_0061,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h01F_0062=gg_unit_h01F_0062
set life=GetUnitState(udg_R23_gg_unit_h01F_0062,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h01G_0064=gg_unit_h01G_0064
set life=GetUnitState(udg_R23_gg_unit_h01G_0064,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h01N_0065=gg_unit_h01N_0065
set life=GetUnitState(udg_R23_gg_unit_h01N_0065,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h01H_0066=gg_unit_h01H_0066
set life=GetUnitState(udg_R23_gg_unit_h01H_0066,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h01I_0067=gg_unit_h01I_0067
set life=GetUnitState(udg_R23_gg_unit_h01I_0067,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h01J_0068=gg_unit_h01J_0068
set life=GetUnitState(udg_R23_gg_unit_h01J_0068,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h01M_0069=gg_unit_h01M_0069
set life=GetUnitState(udg_R23_gg_unit_h01M_0069,UNIT_STATE_LIFE)
set udg_R23_gg_unit_n01V_0108=gg_unit_n01V_0108
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,udg_R23_gg_unit_n01V_0108,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,udg_R23_gg_unit_n01V_0108,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_ItemTable000002_DropItems)
set udg_R23_gg_unit_n01W_0109=gg_unit_n01W_0109
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,udg_R23_gg_unit_n01W_0109,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,udg_R23_gg_unit_n01W_0109,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_ItemTable000000_DropItems)
set udg_R23_gg_unit_n01X_0110=gg_unit_n01X_0110
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,udg_R23_gg_unit_n01X_0110,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,udg_R23_gg_unit_n01X_0110,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_ItemTable000001_DropItems)
set udg_R23_gg_unit_n01Y_0159=gg_unit_n01Y_0159
set udg_R23_gg_unit_h07S_0202=gg_unit_h07S_0202
set life=GetUnitState(udg_R23_gg_unit_h07S_0202,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h046_0405=gg_unit_h046_0405
set life=GetUnitState(udg_R23_gg_unit_h046_0405,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h07N_0415=gg_unit_h07N_0415
set life=GetUnitState(udg_R23_gg_unit_h07N_0415,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h07O_0416=gg_unit_h07O_0416
set life=GetUnitState(udg_R23_gg_unit_h07O_0416,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h07P_0417=gg_unit_h07P_0417
set udg_R23_gg_unit_h07P_0418=gg_unit_h07P_0418
set udg_R23_gg_unit_h07P_0419=gg_unit_h07P_0419
set udg_R23_gg_unit_h07P_0420=gg_unit_h07P_0420
set udg_R23_gg_unit_h07Q_0422=gg_unit_h07Q_0422
set life=GetUnitState(udg_R23_gg_unit_h07Q_0422,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h088_0545=gg_unit_h088_0545
set life=GetUnitState(udg_R23_gg_unit_h088_0545,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h052_0627=gg_unit_h052_0627
set life=GetUnitState(udg_R23_gg_unit_h052_0627,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h053_0628=gg_unit_h053_0628
set life=GetUnitState(udg_R23_gg_unit_h053_0628,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h05M_0632=gg_unit_h05M_0632
set life=GetUnitState(udg_R23_gg_unit_h05M_0632,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h078_0695=gg_unit_h078_0695
set life=GetUnitState(udg_R23_gg_unit_h078_0695,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h07R_0791=gg_unit_h07R_0791
set life=GetUnitState(udg_R23_gg_unit_h07R_0791,UNIT_STATE_LIFE)
set udg_R23_gg_unit_h07F_0793=gg_unit_h07F_0793
set life=GetUnitState(udg_R23_gg_unit_h07F_0793,UNIT_STATE_LIFE)
endfunction

function R23_CreateNeutralHostile takes nothing returns nothing
local player p=Player(12)
local unit u
local integer unitID
local trigger t
local real life
set udg_R23_gg_unit_N06V_0078=gg_unit_N06V_0078
call SetHeroStr(udg_R23_gg_unit_N06V_0078,161,true)
call SetHeroAgi(udg_R23_gg_unit_N06V_0078,155,true)
call SetHeroInt(udg_R23_gg_unit_N06V_0078,126,true)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,udg_R23_gg_unit_N06V_0078,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,udg_R23_gg_unit_N06V_0078,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_Unit000702_DropItems)
set udg_R23_gg_unit_Ecen_0090=gg_unit_Ecen_0090
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,udg_R23_gg_unit_Ecen_0090,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,udg_R23_gg_unit_Ecen_0090,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_Unit000565_DropItems)
set u=gg_unit_ninf_0144
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_ItemTable000004_DropItems)
set udg_R23_gg_unit_H034_0111=gg_unit_H034_0111
call SetHeroStr(udg_R23_gg_unit_H034_0111,180,true)
call SetHeroAgi(udg_R23_gg_unit_H034_0111,'s',true)
call SetHeroInt(udg_R23_gg_unit_H034_0111,'t',true)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,udg_R23_gg_unit_H034_0111,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,udg_R23_gg_unit_H034_0111,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_Unit000306_DropItems)
set u=gg_unit_uabo_0145
set u=gg_unit_uabo_0146
set u=gg_unit_uabo_0147
set u=gg_unit_uabo_0148
set u=gg_unit_uabo_0149
set u=gg_unit_uabo_0150
set u=gg_unit_unec_0151
set u=gg_unit_unec_0152
set u=gg_unit_unec_0153
set u=gg_unit_uske_0154
set u=gg_unit_uske_0155
set u=gg_unit_uske_0156
set u=gg_unit_uske_0157
set u=gg_unit_uske_0158
set u=gg_unit_uske_0160
set u=gg_unit_uske_0161
set u=gg_unit_uske_0162
set u=gg_unit_uske_0163
set u=gg_unit_uske_0164
set u=gg_unit_h01U_0165
set u=gg_unit_h01U_0166
set u=gg_unit_h01U_0167
set u=gg_unit_h01U_0168
set u=gg_unit_h01U_0169
set u=gg_unit_unec_0170
set u=gg_unit_unec_0171
set u=gg_unit_unec_0172
set u=gg_unit_nrvd_0173
set u=gg_unit_nrvd_0174
set u=gg_unit_nrvd_0175
set u=gg_unit_nrvd_0176
set u=gg_unit_nrvd_0177
set u=gg_unit_nrvd_0178
set u=gg_unit_nrvd_0179
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_ItemTable000004_DropItems)
set u=gg_unit_nrvd_0180
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_ItemTable000004_DropItems)
set u=gg_unit_nskg_0181
set u=gg_unit_nskg_0182
set u=gg_unit_nskg_0183
set u=gg_unit_nskg_0184
set u=gg_unit_nskg_0185
set u=gg_unit_nskg_0186
set u=gg_unit_unec_0187
set u=gg_unit_unec_0188
set u=gg_unit_unec_0189
set u=gg_unit_unec_0190
set u=gg_unit_unec_0191
set u=gg_unit_unec_0192
set u=gg_unit_nfor_0193
set u=gg_unit_nfor_0194
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_ItemTable000004_DropItems)
set u=gg_unit_nubk_0195
set u=gg_unit_nubk_0196
set u=gg_unit_nubk_0197
set u=gg_unit_nubk_0198
set u=gg_unit_nitw_0199
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_ItemTable000004_DropItems)
set u=gg_unit_nith_0200
set u=gg_unit_nith_0201
set u=gg_unit_nits_0203
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_ItemTable000004_DropItems)
set u=gg_unit_nits_0204
set u=gg_unit_nith_0205
set u=gg_unit_nith_0206
set u=gg_unit_nith_0207
set u=gg_unit_nmit_0208
set u=gg_unit_nmit_0209
set u=gg_unit_nmam_0210
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_ItemTable000004_DropItems)
set u=gg_unit_nmam_0211
set u=gg_unit_nmam_0212
set u=gg_unit_nbdo_0213
set u=gg_unit_nbdo_0214
set u=gg_unit_nbdo_0215
set u=gg_unit_nbdo_0216
set u=gg_unit_nbds_0217
set u=gg_unit_nbds_0218
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_ItemTable000004_DropItems)
set u=gg_unit_nbds_0219
set u=gg_unit_nbds_0220
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_ItemTable000004_DropItems)
set u=gg_unit_nnwq_0221
set u=gg_unit_nnwq_0222
set u=gg_unit_nnwr_0223
set u=gg_unit_nnwr_0224
set u=gg_unit_nnwr_0225
set u=gg_unit_nnwr_0226
set u=gg_unit_nbal_0227
set u=gg_unit_nbal_0229
set u=gg_unit_nfgb_0230
set u=gg_unit_nfgb_0231
set u=gg_unit_nfgb_0232
set u=gg_unit_nfgb_0233
set u=gg_unit_nbal_0234
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_ItemTable000004_DropItems)
set u=gg_unit_nfel_0235
set u=gg_unit_nfel_0236
set u=gg_unit_nsrw_0237
set u=gg_unit_nsrn_0238
set u=gg_unit_nsra_0239
set u=gg_unit_nsrw_0240
set u=gg_unit_nsrh_0241
set u=gg_unit_nsrh_0242
set u=gg_unit_nsog_0243
set u=gg_unit_nsog_0244
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_ItemTable000004_DropItems)
set u=gg_unit_nsko_0245
set u=gg_unit_nsog_0246
set u=gg_unit_nsog_0247
set u=gg_unit_nsog_0248
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_ItemTable000004_DropItems)
set u=gg_unit_nfpu_0249
set u=gg_unit_nfpt_0250
set u=gg_unit_nfpt_0251
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_ItemTable000004_DropItems)
set u=gg_unit_nrvd_0252
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_ItemTable000004_DropItems)
set u=gg_unit_nrvl_0253
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_ItemTable000004_DropItems)
set u=gg_unit_nrvl_0254
set u=gg_unit_nrvl_0255
set u=gg_unit_nrvl_0256
set u=gg_unit_n021_0257
set u=gg_unit_n021_0258
set u=gg_unit_n020_0259
set u=gg_unit_n020_0260
set u=gg_unit_n020_0261
set udg_R23_gg_unit_u024_0228=gg_unit_u024_0228
set u=gg_unit_unec_0262
set u=gg_unit_unec_0263
set u=gg_unit_unec_0264
set u=gg_unit_h084_0265
set u=gg_unit_h084_0266
set u=gg_unit_h084_0267
set u=gg_unit_n07N_0268
set u=gg_unit_n07N_0269
set u=gg_unit_n07N_0270
set u=gg_unit_n07N_0271
set u=gg_unit_n07N_0272
set u=gg_unit_n07N_0273
set u=gg_unit_n07N_0274
set u=gg_unit_n07N_0275
set u=gg_unit_n07N_0276
set u=gg_unit_n07N_0277
set u=gg_unit_n07N_0278
set u=gg_unit_n07N_0279
set u=gg_unit_n07H_0280
set u=gg_unit_n07H_0281
set u=gg_unit_ugho_0282
set u=gg_unit_ugho_0283
set u=gg_unit_ugho_0285
set u=gg_unit_ugho_0286
set u=gg_unit_ugho_0287
set u=gg_unit_ugho_0289
set u=gg_unit_ugho_0290
set u=gg_unit_ugho_0291
set u=gg_unit_ugho_0292
set u=gg_unit_ugho_0293
set u=gg_unit_ugho_0294
set u=gg_unit_ugho_0295
set u=gg_unit_ugho_0296
set u=gg_unit_ugho_0297
set u=gg_unit_ugho_0298
set u=gg_unit_ugho_0299
set u=gg_unit_n07H_0300
set u=gg_unit_n07H_0301
set u=gg_unit_n07H_0302
set u=gg_unit_n07H_0303
set u=gg_unit_ngh2_0304
set u=gg_unit_ngh2_0305
set u=gg_unit_nrvd_0306
set u=gg_unit_nrvd_0307
set u=gg_unit_nrvd_0308
set u=gg_unit_nrvd_0309
set u=gg_unit_nrvd_0310
set u=gg_unit_nrvd_0311
set u=gg_unit_nrvd_0312
set u=gg_unit_nrvd_0313
set u=gg_unit_nrvd_0314
set u=gg_unit_nrvd_0315
set u=gg_unit_nrvd_0316
set u=gg_unit_nrvd_0317
set u=gg_unit_nrvd_0318
set udg_R23_gg_unit_U00T_0284=gg_unit_U00T_0284
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,udg_R23_gg_unit_U00T_0284,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,udg_R23_gg_unit_U00T_0284,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_Unit000284_DropItems)
set udg_R23_gg_unit_N055_0288=gg_unit_N055_0288
call SetHeroStr(udg_R23_gg_unit_N055_0288,190,true)
call SetHeroAgi(udg_R23_gg_unit_N055_0288,'d',true)
call SetHeroInt(udg_R23_gg_unit_N055_0288,130,true)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,udg_R23_gg_unit_N055_0288,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,udg_R23_gg_unit_N055_0288,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_Unit000599_DropItems)
set u=gg_unit_nftk_0319
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_ItemTable000004_DropItems)
set u=gg_unit_nftr_0320
set u=gg_unit_nftr_0321
set u=gg_unit_nftr_0322
set u=gg_unit_nftr_0323
set u=gg_unit_nftk_0324
set u=gg_unit_nftk_0325
set u=gg_unit_N01R_0326
call SetUnitState(u,UNIT_STATE_MANA,'d')
set u=gg_unit_n01E_0327
set u=gg_unit_n01E_0328
set u=gg_unit_n01E_0329
set u=gg_unit_nggr_0330
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_ItemTable000004_DropItems)
set u=gg_unit_ngst_0331
set u=gg_unit_ngst_0332
set u=gg_unit_nmrr_0333
set u=gg_unit_nmrr_0334
set u=gg_unit_nmrr_0335
set u=gg_unit_nmrr_0336
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_ItemTable000004_DropItems)
set u=gg_unit_nmrr_0337
set u=gg_unit_nogm_0338
set u=gg_unit_nogm_0339
set u=gg_unit_nogm_0340
set u=gg_unit_nchg_0341
set u=gg_unit_nogl_0342
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_ItemTable000004_DropItems)
set u=gg_unit_nogl_0343
set u=gg_unit_nogl_0344
set u=gg_unit_nogm_0345
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_ItemTable000004_DropItems)
set u=gg_unit_nogm_0346
set u=gg_unit_nogm_0347
set u=gg_unit_ninf_0348
set u=gg_unit_nbal_0349
set u=gg_unit_nchg_0350
set u=gg_unit_ninf_0351
set u=gg_unit_nvdw_0352
set u=gg_unit_nvdw_0353
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_ItemTable000004_DropItems)
set u=gg_unit_nvdw_0354
set u=gg_unit_nvdw_0355
set u=gg_unit_nvde_0356
set u=gg_unit_nvdg_0357
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_ItemTable000004_DropItems)
set u=gg_unit_nvdg_0358
set u=gg_unit_nvdg_0359
set u=gg_unit_nina_0360
set u=gg_unit_nina_0361
set u=gg_unit_nbal_0362
set u=gg_unit_nbal_0363
set u=gg_unit_nchg_0364
set u=gg_unit_nchg_0365
set u=gg_unit_nchg_0366
set u=gg_unit_nchg_0367
set u=gg_unit_h083_0368
set u=gg_unit_h083_0369
set u=gg_unit_h083_0370
set u=gg_unit_h083_0371
set u=gg_unit_h083_0372
set u=gg_unit_h083_0373
set u=gg_unit_n07N_0374
set u=gg_unit_n07N_0375
set u=gg_unit_n07N_0376
set u=gg_unit_n07N_0377
set u=gg_unit_ncnk_0378
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_ItemTable000004_DropItems)
set u=gg_unit_ncim_0379
set u=gg_unit_ncim_0380
set u=gg_unit_ncen_0381
set u=gg_unit_ncen_0382
set u=gg_unit_ncen_0383
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_ItemTable000004_DropItems)
set u=gg_unit_ndrs_0384
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_ItemTable000004_DropItems)
set u=gg_unit_ndrs_0385
set u=gg_unit_ndrs_0386
set u=gg_unit_ndrs_0387
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_ItemTable000004_DropItems)
set u=gg_unit_ndrw_0388
set u=gg_unit_ndrw_0389
set u=gg_unit_ndrw_0390
set u=gg_unit_ndrh_0391
set u=gg_unit_ndrh_0392
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_ItemTable000004_DropItems)
set u=gg_unit_ndrd_0393
set u=gg_unit_nwzr_0394
set u=gg_unit_nwzr_0395
set u=gg_unit_nban_0396
set u=gg_unit_nban_0397
set u=gg_unit_nban_0398
set u=gg_unit_nban_0399
set u=gg_unit_nass_0400
set u=gg_unit_nass_0401
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_ItemTable000004_DropItems)
set u=gg_unit_nass_0402
set u=gg_unit_ncen_0403
set u=gg_unit_ncer_0404
set u=gg_unit_ncer_0406
set u=gg_unit_ncer_0407
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_ItemTable000004_DropItems)
set u=gg_unit_ncer_0408
set u=gg_unit_ncer_0409
set u=gg_unit_ncen_0410
set u=gg_unit_ncea_0411
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_ItemTable000004_DropItems)
set u=gg_unit_ncea_0412
set u=gg_unit_nsat_0413
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_ItemTable000004_DropItems)
set u=gg_unit_nsat_0414
set u=gg_unit_nstl_0421
set u=gg_unit_ugho_0423
set u=gg_unit_ugho_0424
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_ItemTable000004_DropItems)
set u=gg_unit_n03T_0425
set u=gg_unit_n03T_0426
set u=gg_unit_ugho_0427
set u=gg_unit_ugho_0428
set u=gg_unit_n03T_0429
set u=gg_unit_n03T_0430
set u=gg_unit_n03T_0431
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_ItemTable000004_DropItems)
set u=gg_unit_nfod_0432
set u=gg_unit_nfod_0433
set u=gg_unit_nfod_0434
set u=gg_unit_nfod_0435
set u=gg_unit_nfod_0436
set u=gg_unit_nfot_0437
set u=gg_unit_nfot_0438
set u=gg_unit_nfot_0439
set u=gg_unit_nfot_0440
set u=gg_unit_nfod_0441
set u=gg_unit_nfod_0442
set u=gg_unit_nfod_0443
set u=gg_unit_nfod_0444
set u=gg_unit_nfod_0445
set u=gg_unit_nfot_0446
set u=gg_unit_nfot_0447
set u=gg_unit_nfot_0448
set u=gg_unit_nfot_0449
set u=gg_unit_nubw_0450
set u=gg_unit_nubw_0451
set u=gg_unit_nubw_0452
set u=gg_unit_nubw_0453
set u=gg_unit_nubw_0454
set u=gg_unit_nubw_0455
set u=gg_unit_nubw_0456
set u=gg_unit_nubw_0457
set u=gg_unit_nfod_0458
set u=gg_unit_nfod_0459
set u=gg_unit_nfod_0460
set u=gg_unit_nfod_0461
set u=gg_unit_nfot_0462
set u=gg_unit_nfot_0463
set u=gg_unit_nfot_0464
set u=gg_unit_nfod_0465
set u=gg_unit_nfod_0466
set u=gg_unit_nfod_0467
set u=gg_unit_nfod_0468
set u=gg_unit_nfod_0469
set u=gg_unit_nfod_0470
set u=gg_unit_nfod_0471
set u=gg_unit_nfod_0472
set u=gg_unit_nfod_0473
set u=gg_unit_nfod_0474
set u=gg_unit_nfod_0475
set u=gg_unit_nfod_0476
set u=gg_unit_nfod_0477
set u=gg_unit_nfod_0478
set u=gg_unit_esen_0479
set u=gg_unit_esen_0480
set u=gg_unit_esen_0481
set u=gg_unit_nfod_0482
set u=gg_unit_nfod_0483
set u=gg_unit_nfot_0484
set u=gg_unit_nfot_0485
set u=gg_unit_nfot_0486
set u=gg_unit_nfot_0487
set u=gg_unit_nfot_0488
set u=gg_unit_nfot_0489
set u=gg_unit_nfot_0490
set u=gg_unit_nfot_0491
set u=gg_unit_nfot_0492
set u=gg_unit_nfot_0493
set u=gg_unit_nfot_0494
set u=gg_unit_esen_0495
set u=gg_unit_esen_0496
set u=gg_unit_esen_0497
set u=gg_unit_emtg_0498
set u=gg_unit_emtg_0499
set u=gg_unit_emtg_0500
set u=gg_unit_nnrg_0501
set u=gg_unit_nnrg_0502
set u=gg_unit_nnrg_0503
set u=gg_unit_nnrg_0504
set u=gg_unit_nnrg_0505
set u=gg_unit_emtg_0506
set u=gg_unit_edot_0507
set u=gg_unit_edot_0508
set u=gg_unit_nnmg_0509
set u=gg_unit_nnmg_0510
set u=gg_unit_nnmg_0511
set u=gg_unit_nnmg_0512
set u=gg_unit_nnmg_0513
set u=gg_unit_edot_0514
set u=gg_unit_edot_0515
set u=gg_unit_edot_0516
set u=gg_unit_edot_0517
set u=gg_unit_edry_0518
set u=gg_unit_H085_0519
set u=gg_unit_h083_0520
set u=gg_unit_h083_0521
set u=gg_unit_u023_0522
set u=gg_unit_u023_0523
set u=gg_unit_unec_0524
set u=gg_unit_unec_0525
set u=gg_unit_unec_0526
set u=gg_unit_uabo_0527
set u=gg_unit_uabo_0528
set u=gg_unit_uabo_0529
set u=gg_unit_uabo_0530
set u=gg_unit_uabo_0531
set u=gg_unit_uabo_0533
set u=gg_unit_umtw_0534
set u=gg_unit_umtw_0535
set u=gg_unit_uban_0536
set u=gg_unit_uban_0537
set u=gg_unit_n02O_0538
set u=gg_unit_n02Q_0539
set u=gg_unit_n02O_0540
set u=gg_unit_n02O_0541
set udg_R23_gg_unit_n02S_0532=gg_unit_n02S_0532
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,udg_R23_gg_unit_n02S_0532,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,udg_R23_gg_unit_n02S_0532,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_ItemTable000003_DropItems)
set u=gg_unit_n02R_0542
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_ItemTable000004_DropItems)
set u=gg_unit_n02R_0543
set u=gg_unit_n02Q_0544
set u=gg_unit_n02Q_0546
set u=gg_unit_n02Q_0547
set u=gg_unit_n02Q_0548
set u=gg_unit_n02Q_0549
set u=gg_unit_n02Q_0550
set u=gg_unit_n02Q_0551
set u=gg_unit_n02Q_0552
set u=gg_unit_n02R_0553
set u=gg_unit_n02R_0554
set u=gg_unit_n02R_0555
set u=gg_unit_n02Q_0556
set u=gg_unit_n02Q_0557
set u=gg_unit_n02R_0558
set u=gg_unit_n02R_0559
set u=gg_unit_n02R_0560
set u=gg_unit_n07O_0561
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_ItemTable000004_DropItems)
set u=gg_unit_n07O_0562
set u=gg_unit_n07O_0563
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_ItemTable000004_DropItems)
set u=gg_unit_n07O_0565
set u=gg_unit_n07O_0566
set u=gg_unit_n07P_0567
set u=gg_unit_n07P_0568
set udg_R23_gg_unit_n02T_0564=gg_unit_n02T_0564
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,udg_R23_gg_unit_n02T_0564,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,udg_R23_gg_unit_n02T_0564,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_Unit000564_DropItems)
set u=gg_unit_ndrd_0569
set u=gg_unit_ndrd_0570
set u=gg_unit_ndrd_0571
set u=gg_unit_ndrd_0572
set u=gg_unit_ndrd_0574
set u=gg_unit_ndrd_0575
set u=gg_unit_ndrs_0576
set u=gg_unit_ndrs_0577
set udg_R23_gg_unit_Eevi_0573=gg_unit_Eevi_0573
call SetHeroStr(udg_R23_gg_unit_Eevi_0573,155,true)
call SetHeroAgi(udg_R23_gg_unit_Eevi_0573,132,true)
call SetHeroInt(udg_R23_gg_unit_Eevi_0573,'o',true)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,udg_R23_gg_unit_Eevi_0573,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,udg_R23_gg_unit_Eevi_0573,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_Unit000384_DropItems)
set u=gg_unit_n03T_0578
set u=gg_unit_n03T_0579
set u=gg_unit_n03T_0580
set u=gg_unit_n03T_0581
set u=gg_unit_n03T_0582
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,u,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_ItemTable000004_DropItems)
set u=gg_unit_n03T_0583
set u=gg_unit_n03T_0584
set u=gg_unit_n03T_0585
set u=gg_unit_n03T_0586
set u=gg_unit_edry_0587
set u=gg_unit_edry_0588
set u=gg_unit_edry_0589
set u=gg_unit_earc_0590
set u=gg_unit_earc_0591
set u=gg_unit_earc_0592
set u=gg_unit_earc_0593
set u=gg_unit_earc_0594
set u=gg_unit_n00G_0595
set u=gg_unit_n00G_0596
set u=gg_unit_n00G_0597
set u=gg_unit_n00G_0598
set u=gg_unit_e000_0599
set u=gg_unit_e000_0600
set u=gg_unit_e000_0601
set u=gg_unit_e000_0602
set u=gg_unit_e000_0603
set u=gg_unit_nlv3_0604
set u=gg_unit_nlv3_0605
set u=gg_unit_nlv3_0606
set u=gg_unit_nlv3_0607
set u=gg_unit_nlv3_0608
set u=gg_unit_nlv3_0609
set u=gg_unit_nlv3_0610
set u=gg_unit_nlv3_0611
set u=gg_unit_nlv3_0612
set u=gg_unit_nlv3_0613
set u=gg_unit_n01E_0614
set u=gg_unit_n07O_0615
set u=gg_unit_n07O_0616
set u=gg_unit_n07Q_0617
set u=gg_unit_nlv3_0618
set u=gg_unit_nlv3_0619
set u=gg_unit_ucry_0620
set udg_R23_gg_unit_N05H_0633=gg_unit_N05H_0633
call SetHeroStr(udg_R23_gg_unit_N05H_0633,166,true)
call SetHeroAgi(udg_R23_gg_unit_N05H_0633,'x',true)
call SetHeroInt(udg_R23_gg_unit_N05H_0633,130,true)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,udg_R23_gg_unit_N05H_0633,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,udg_R23_gg_unit_N05H_0633,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_Unit000631_DropItems)
set udg_R23_gg_unit_n06P_0634=gg_unit_n06P_0634
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,udg_R23_gg_unit_n06P_0634,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,udg_R23_gg_unit_n06P_0634,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_Unit000634_DropItems)
set u=gg_unit_n04D_0621
set u=gg_unit_n04D_0622
set u=gg_unit_n04G_0623
set u=gg_unit_n04G_0624
set u=gg_unit_nchg_0625
set u=gg_unit_nchg_0626
set u=gg_unit_nchg_0629
set u=gg_unit_nchg_0630
set u=gg_unit_nchg_0631
set u=gg_unit_nchg_0635
set udg_R23_gg_unit_Hkal_0645=gg_unit_Hkal_0645
call SetHeroStr(udg_R23_gg_unit_Hkal_0645,'l',true)
call SetHeroAgi(udg_R23_gg_unit_Hkal_0645,129,true)
call SetHeroInt(udg_R23_gg_unit_Hkal_0645,194,true)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,udg_R23_gg_unit_Hkal_0645,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,udg_R23_gg_unit_Hkal_0645,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_Unit000645_DropItems)
set u=gg_unit_h02Z_0636
set u=gg_unit_h02Z_0637
set u=gg_unit_h02Z_0638
set u=gg_unit_h02Z_0639
set u=gg_unit_h02Z_0640
set u=gg_unit_h02Z_0641
set u=gg_unit_h02P_0642
set u=gg_unit_h02P_0643
set u=gg_unit_h02P_0644
set u=gg_unit_h02P_0646
set u=gg_unit_h02P_0647
set u=gg_unit_h02P_0648
set u=gg_unit_h02P_0649
set u=gg_unit_h02P_0650
set u=gg_unit_n026_0651
set u=gg_unit_n026_0652
set u=gg_unit_n026_0653
set u=gg_unit_n026_0654
set u=gg_unit_h030_0655
set u=gg_unit_h030_0656
set u=gg_unit_h030_0657
set u=gg_unit_h030_0658
set udg_R23_gg_unit_N06Q_0668=gg_unit_N06Q_0668
call SetHeroStr(udg_R23_gg_unit_N06Q_0668,215,true)
call SetHeroAgi(udg_R23_gg_unit_N06Q_0668,'d',true)
call SetHeroInt(udg_R23_gg_unit_N06Q_0668,130,true)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,udg_R23_gg_unit_N06Q_0668,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,udg_R23_gg_unit_N06Q_0668,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_Unit000668_DropItems)
set u=gg_unit_nsel_0659
set u=gg_unit_nsel_0660
set u=gg_unit_nsel_0661
set u=gg_unit_nsel_0662
set u=gg_unit_nrel_0663
set u=gg_unit_nrel_0664
set u=gg_unit_nrel_0665
set u=gg_unit_nrel_0666
set u=gg_unit_nrel_0667
set u=gg_unit_nrel_0669
set u=gg_unit_ntrd_0670
set u=gg_unit_ntrd_0671
set u=gg_unit_nsel_0672
set u=gg_unit_nsel_0673
set u=gg_unit_nsel_0674
set u=gg_unit_nsel_0675
set u=gg_unit_nsel_0676
set u=gg_unit_nsel_0677
set u=gg_unit_nsel_0678
set u=gg_unit_nsel_0679
set u=gg_unit_nsel_0680
set u=gg_unit_nsel_0681
set u=gg_unit_nsel_0682
set u=gg_unit_nsel_0683
set u=gg_unit_ngh2_0684
set u=gg_unit_n06W_0685
set u=gg_unit_n06W_0686
set u=gg_unit_n06W_0687
set u=gg_unit_n06W_0688
set u=gg_unit_n06W_0689
set u=gg_unit_n06W_0690
set u=gg_unit_n06W_0691
set u=gg_unit_n06W_0692
set u=gg_unit_n06W_0693
set u=gg_unit_n06W_0694
set u=gg_unit_n06W_0696
set u=gg_unit_n06W_0697
set u=gg_unit_n06W_0698
set u=gg_unit_n06W_0699
set u=gg_unit_n06W_0700
set u=gg_unit_n06W_0701
set u=gg_unit_ngst_0702
set u=gg_unit_ngst_0703
set u=gg_unit_ngst_0704
set u=gg_unit_ngst_0705
set u=gg_unit_ngst_0706
set u=gg_unit_ngst_0707
set u=gg_unit_ngst_0708
set u=gg_unit_ngst_0709
set u=gg_unit_ngst_0710
set u=gg_unit_ngst_0711
set u=gg_unit_ngst_0712
set u=gg_unit_nggr_0713
set u=gg_unit_nggr_0714
set u=gg_unit_nggr_0715
set u=gg_unit_nggr_0716
set u=gg_unit_nggr_0717
set u=gg_unit_ngst_0718
set u=gg_unit_ngst_0719
set u=gg_unit_ngst_0720
set u=gg_unit_ucry_0721
set u=gg_unit_ngh1_0722
set u=gg_unit_ngh1_0723
set u=gg_unit_ngh1_0724
set u=gg_unit_ngh1_0725
set u=gg_unit_ngh1_0726
set u=gg_unit_ngh2_0727
set u=gg_unit_ngh2_0728
set u=gg_unit_ngh2_0729
set udg_R23_gg_unit_Ewrd_0749=gg_unit_Ewrd_0749
call SetHeroStr(udg_R23_gg_unit_Ewrd_0749,128,true)
call SetHeroAgi(udg_R23_gg_unit_Ewrd_0749,200,true)
call SetHeroInt(udg_R23_gg_unit_Ewrd_0749,'j',true)
set t=CreateTrigger()
call TriggerRegisterUnitEvent(t,udg_R23_gg_unit_Ewrd_0749,EVENT_UNIT_DEATH)
call TriggerRegisterUnitEvent(t,udg_R23_gg_unit_Ewrd_0749,EVENT_UNIT_CHANGE_OWNER)
call TriggerAddAction(t,function R23_Unit000382_DropItems)
set u=gg_unit_nssn_0730
set u=gg_unit_nssn_0731
set u=gg_unit_nssn_0732
set u=gg_unit_nssn_0733
set u=gg_unit_nssn_0734
set u=gg_unit_nssn_0735
set u=gg_unit_nssn_0736
set u=gg_unit_nssn_0737
set u=gg_unit_nssn_0738
set u=gg_unit_nssn_0739
set u=gg_unit_nssn_0740
set u=gg_unit_nssn_0741
set u=gg_unit_nssn_0742
set u=gg_unit_nssn_0743
set u=gg_unit_nssn_0744
set u=gg_unit_nssn_0745
set u=gg_unit_nowk_0746
set u=gg_unit_nowk_0747
set u=gg_unit_nowk_0748
set u=gg_unit_nowk_0750
set u=gg_unit_nowk_0751
set u=gg_unit_nowk_0752
set u=gg_unit_nowk_0753
set u=gg_unit_earc_0754
set u=gg_unit_earc_0755
set u=gg_unit_earc_0756
set u=gg_unit_earc_0757
set u=gg_unit_earc_0758
set u=gg_unit_earc_0759
set u=gg_unit_earc_0760
set u=gg_unit_earc_0761
set u=gg_unit_earc_0762
set u=gg_unit_ebal_0763
set u=gg_unit_ebal_0764
set u=gg_unit_ebal_0765
set u=gg_unit_ebal_0766
set u=gg_unit_ebal_0767
set u=gg_unit_ebal_0768
set u=gg_unit_emtg_0769
set u=gg_unit_emtg_0770
set u=gg_unit_emtg_0771
set u=gg_unit_nsra_0772
set u=gg_unit_uban_0773
set u=gg_unit_uban_0774
set u=gg_unit_nnws_0775
set u=gg_unit_nnws_0776
set u=gg_unit_nnwq_0777
set u=gg_unit_nnwl_0778
set u=gg_unit_nnwl_0779
set u=gg_unit_nnwl_0780
set u=gg_unit_n01E_0781
set u=gg_unit_n01E_0782
set u=gg_unit_n01M_0783
call SetUnitState(u,UNIT_STATE_MANA,'d')
set u=gg_unit_n01M_0784
call SetUnitState(u,UNIT_STATE_MANA,'d')
set u=gg_unit_u028_0785
set u=gg_unit_u028_0786
set u=gg_unit_uske_0787
set u=gg_unit_uske_0788
set u=gg_unit_uske_0789
set u=gg_unit_ugho_0790
set u=gg_unit_unec_0792
set u=gg_unit_uske_0794
set u=gg_unit_uske_0795
set u=gg_unit_uske_0796
set u=gg_unit_uske_0797
set u=gg_unit_uske_0798
set u=gg_unit_n07O_0799
set u=gg_unit_ugho_0800
set u=gg_unit_ucry_0801
set u=gg_unit_unec_0802
set u=gg_unit_unec_0803
set u=gg_unit_uban_0804
set u=gg_unit_n01O_0805
set u=gg_unit_n01O_0806
set u=gg_unit_n01M_0807
set u=gg_unit_n01M_0808
set u=gg_unit_n01M_0809
set u=gg_unit_n01M_0810
set u=gg_unit_n01Q_0811
set u=gg_unit_n01N_0812
set u=gg_unit_n01N_0813
set u=gg_unit_n01E_0814
set u=gg_unit_n01E_0815
set u=gg_unit_n01E_0816
set u=gg_unit_n01E_0817
set u=gg_unit_n01P_0818
set u=gg_unit_n01P_0819
endfunction

function R23_CreateNeutralPassiveBuildings takes nothing returns nothing
local player p=Player(15)
local unit u
local integer unitID
local trigger t
local real life
set u=gg_unit_n004_0000
call WaygateSetDestination(u,GetRectCenterX(udg_R23_gg_rct_SpawnPoint_EasternKingdom1),GetRectCenterY(udg_R23_gg_rct_SpawnPoint_EasternKingdom1))
call WaygateActivate(u,true)
set u=gg_unit_n003_0001
call WaygateSetDestination(u,GetRectCenterX(udg_R23_gg_rct_SpawnPoint_EasternKingdom2),GetRectCenterY(udg_R23_gg_rct_SpawnPoint_EasternKingdom2))
call WaygateActivate(u,true)
set u=gg_unit_n006_0002
call WaygateSetDestination(u,GetRectCenterX(udg_R23_gg_rct_SpawnPoint_Kalimdor1),GetRectCenterY(udg_R23_gg_rct_SpawnPoint_Kalimdor1))
call WaygateActivate(u,true)
set u=gg_unit_n005_0003
call WaygateSetDestination(u,GetRectCenterX(udg_R23_gg_rct_SpawnPoint_Kalimdor2),GetRectCenterY(udg_R23_gg_rct_SpawnPoint_Kalimdor2))
call WaygateActivate(u,true)
set u=gg_unit_n007_0004
call WaygateSetDestination(u,GetRectCenterX(udg_R23_gg_rct_SpawnPoint_Northland1),GetRectCenterY(udg_R23_gg_rct_SpawnPoint_Northland1))
call WaygateActivate(u,true)
set u=gg_unit_n008_0005
call WaygateSetDestination(u,GetRectCenterX(udg_R23_gg_rct_SpawnPoint_Northland2),GetRectCenterY(udg_R23_gg_rct_SpawnPoint_Northland2))
call WaygateActivate(u,true)
set u=gg_unit_n009_0006
call WaygateSetDestination(u,GetRectCenterX(udg_R23_gg_rct_SpawnPoint_Pandaria),GetRectCenterY(udg_R23_gg_rct_SpawnPoint_Pandaria))
call WaygateActivate(u,true)
set u=gg_unit_n00A_0007
call WaygateSetDestination(u,GetRectCenterX(udg_R23_gg_rct_SpawnPoint_Broken_isles),GetRectCenterY(udg_R23_gg_rct_SpawnPoint_Broken_isles))
call WaygateActivate(u,true)
set u=gg_unit_n00C_0008
call WaygateSetDestination(u,GetRectCenterX(udg_R23_gg_rct_NZotMove),GetRectCenterY(udg_R23_gg_rct_NZotMove))
call WaygateActivate(u,true)
set u=gg_unit_n00C_0009
call WaygateSetDestination(u,GetRectCenterX(udg_R23_gg_rct_Raide01Move),GetRectCenterY(udg_R23_gg_rct_Raide01Move))
call WaygateActivate(u,true)
set u=gg_unit_n00C_0012
call WaygateSetDestination(u,GetRectCenterX(udg_R23_gg_rct_Raide01Ext),GetRectCenterY(udg_R23_gg_rct_Raide01Ext))
call WaygateActivate(u,true)
set u=gg_unit_n00C_0063
call WaygateSetDestination(u,GetRectCenterX(udg_R23_gg_rct_QogSaronExt),GetRectCenterY(udg_R23_gg_rct_QogSaronExt))
call WaygateActivate(u,true)
set u=gg_unit_n00C_0070
call WaygateSetDestination(u,GetRectCenterX(udg_R23_gg_rct_EarthMove),GetRectCenterY(udg_R23_gg_rct_EarthMove))
call WaygateActivate(u,true)
set u=gg_unit_n00C_0071
call WaygateSetDestination(u,GetRectCenterX(udg_R23_gg_rct_KTunRaideExt),GetRectCenterY(udg_R23_gg_rct_KTunRaideExt))
call WaygateActivate(u,true)
set u=gg_unit_n00C_0072
call WaygateSetDestination(u,GetRectCenterX(udg_R23_gg_rct_KTunRaideMove),GetRectCenterY(udg_R23_gg_rct_KTunRaideMove))
call WaygateActivate(u,true)
set u=gg_unit_n00C_0073
call WaygateSetDestination(u,GetRectCenterX(udg_R23_gg_rct_NerubianB2Ext),GetRectCenterY(udg_R23_gg_rct_NerubianB2Ext))
call WaygateActivate(u,true)
set u=gg_unit_n00C_0074
call WaygateSetDestination(u,GetRectCenterX(udg_R23_gg_rct_QogSaronMove),GetRectCenterY(udg_R23_gg_rct_QogSaronMove))
call WaygateActivate(u,true)
set u=gg_unit_n00C_0075
call WaygateSetDestination(u,GetRectCenterX(udg_R23_gg_rct_NerubianC3move),GetRectCenterY(udg_R23_gg_rct_NerubianC3move))
call WaygateActivate(u,true)
set u=gg_unit_n00C_0076
call WaygateSetDestination(u,GetRectCenterX(udg_R23_gg_rct_NerubianC3Ext),GetRectCenterY(udg_R23_gg_rct_NerubianC3Ext))
call WaygateActivate(u,true)
set u=gg_unit_n00C_0077
call WaygateSetDestination(u,GetRectCenterX(udg_R23_gg_rct_NerubianA1Ext),GetRectCenterY(udg_R23_gg_rct_NerubianA1Ext))
call WaygateActivate(u,true)
set u=gg_unit_n00C_0079
call WaygateSetDestination(u,GetRectCenterX(udg_R23_gg_rct_NerubianA1move),GetRectCenterY(udg_R23_gg_rct_NerubianA1move))
call WaygateActivate(u,true)
set u=gg_unit_n00D_0080
call WaygateSetDestination(u,GetRectCenterX(udg_R23_gg_rct_OutlandMove),GetRectCenterY(udg_R23_gg_rct_OutlandMove))
call WaygateActivate(u,true)
set u=gg_unit_n00D_0081
call WaygateSetDestination(u,GetRectCenterX(udg_R23_gg_rct_OutlandExt),GetRectCenterY(udg_R23_gg_rct_OutlandExt))
call WaygateActivate(u,true)
set u=gg_unit_h02K_0082
set u=gg_unit_ngme_0083
set u=gg_unit_n00C_0084
call WaygateSetDestination(u,GetRectCenterX(udg_R23_gg_rct_NZotExt),GetRectCenterY(udg_R23_gg_rct_NZotExt))
call WaygateActivate(u,true)
set u=gg_unit_ngme_0085
set u=gg_unit_nmoo_0086
set u=gg_unit_nfoh_0087
set u=gg_unit_nfoh_0088
set u=gg_unit_nmoo_0089
set u=gg_unit_n00C_0091
call WaygateSetDestination(u,GetRectCenterX(udg_R23_gg_rct_RAGNAROSS),GetRectCenterY(udg_R23_gg_rct_RAGNAROSS))
call WaygateActivate(u,true)
set u=gg_unit_n07S_0092
call WaygateSetDestination(u,GetRectCenterX(udg_R23_gg_rct_NaxxramasEXT),GetRectCenterY(udg_R23_gg_rct_NaxxramasEXT))
call WaygateActivate(u,true)
set u=gg_unit_n07S_0093
call WaygateSetDestination(u,GetRectCenterX(udg_R23_gg_rct_NaxxramasMOVE),GetRectCenterY(udg_R23_gg_rct_NaxxramasMOVE))
call WaygateActivate(u,true)
set u=gg_unit_ngme_0094
set u=gg_unit_n070_0095
call WaygateSetDestination(u,GetRectCenterX(udg_R23_gg_rct_Necrositemove),GetRectCenterY(udg_R23_gg_rct_Necrositemove))
call WaygateActivate(u,true)
set u=gg_unit_n00C_0096
call WaygateSetDestination(u,GetRectCenterX(udg_R23_gg_rct_Necrositetext),GetRectCenterY(udg_R23_gg_rct_Necrositetext))
call WaygateActivate(u,true)
set u=gg_unit_n00C_0097
call WaygateSetDestination(u,GetRectCenterX(udg_R23_gg_rct_KazemateMove),GetRectCenterY(udg_R23_gg_rct_KazemateMove))
call WaygateActivate(u,true)
set u=gg_unit_n057_0098
set u=gg_unit_ngme_0099
set u=gg_unit_n056_0100
set u=gg_unit_n00C_0101
call WaygateSetDestination(u,GetRectCenterX(udg_R23_gg_rct_NerubianB2move),GetRectCenterY(udg_R23_gg_rct_NerubianB2move))
call WaygateActivate(u,true)
set u=gg_unit_n00C_0102
call WaygateSetDestination(u,GetRectCenterX(udg_R23_gg_rct_RAGNAROSS_EXT),GetRectCenterY(udg_R23_gg_rct_RAGNAROSS_EXT))
call WaygateActivate(u,true)
set u=gg_unit_ngme_0103
set u=gg_unit_ngme_0104
set u=gg_unit_n056_0105
set u=gg_unit_n056_0106
set u=gg_unit_n057_0107
set u=gg_unit_n057_0112
set u=gg_unit_n056_0113
set u=gg_unit_n057_0114
set u=gg_unit_ngme_0115
set u=gg_unit_ngme_0116
set u=gg_unit_n057_0117
set u=gg_unit_n056_0118
set u=gg_unit_n00C_0119
call WaygateSetDestination(u,GetRectCenterX(udg_R23_gg_rct_VAICHext),GetRectCenterY(udg_R23_gg_rct_VAICHext))
call WaygateActivate(u,true)
set u=gg_unit_n00C_0120
call WaygateSetDestination(u,GetRectCenterX(udg_R23_gg_rct_VAICHmove),GetRectCenterY(udg_R23_gg_rct_VAICHmove))
call WaygateActivate(u,true)
set u=gg_unit_nmer_0121
set u=gg_unit_nmer_0122
set u=gg_unit_nmer_0123
set u=gg_unit_nmer_0124
set u=gg_unit_nmer_0125
set u=gg_unit_n07R_0126
call WaygateSetDestination(u,GetRectCenterX(udg_R23_gg_rct_DalaranExt),GetRectCenterY(udg_R23_gg_rct_DalaranExt))
call WaygateActivate(u,true)
set u=gg_unit_n00C_0127
call WaygateSetDestination(u,GetRectCenterX(udg_R23_gg_rct_EarthExt),GetRectCenterY(udg_R23_gg_rct_EarthExt))
call WaygateActivate(u,true)
set u=gg_unit_n00C_0128
call WaygateSetDestination(u,GetRectCenterX(udg_R23_gg_rct_KazemateExt),GetRectCenterY(udg_R23_gg_rct_KazemateExt))
call WaygateActivate(u,true)
set u=gg_unit_n07T_0129
call WaygateSetDestination(u,GetRectCenterX(udg_R23_gg_rct_Outland),GetRectCenterY(udg_R23_gg_rct_Outland))
call WaygateActivate(u,true)
set u=gg_unit_n07R_0130
call WaygateSetDestination(u,GetRectCenterX(udg_R23_gg_rct_DalaranExt),GetRectCenterY(udg_R23_gg_rct_DalaranExt))
call WaygateActivate(u,true)
set u=gg_unit_nmer_0131
endfunction

function R23_CreateNeutralPassive takes nothing returns nothing
local player p=Player(15)
local unit u
local integer unitID
local trigger t
local real life
set u=gg_unit_n05G_0820
endfunction

function R23_CreatePlayerBuildings takes nothing returns nothing
local player p
local unit u
local integer unitID
local trigger t
local real life
set p=Player(0)
set u=gg_unit_n00B_0132
set p=Player(1)
set u=gg_unit_n00B_0133
set p=Player(2)
set u=gg_unit_n00B_0134
set p=Player(3)
set u=gg_unit_n00B_0135
set p=Player(4)
set u=gg_unit_n00B_0136
set p=Player(5)
set u=gg_unit_n00B_0137
set p=Player(6)
set u=gg_unit_n00B_0138
set p=Player(7)
set u=gg_unit_n00B_0139
set p=Player(8)
set u=gg_unit_n00B_0140
set p=Player(9)
set u=gg_unit_n00B_0141
set p=Player(10)
set u=gg_unit_n00B_0142
set p=Player(11)
set u=gg_unit_n00B_0143
endfunction

function R23_CreatePlayerUnits takes nothing returns nothing
endfunction

function R23_CreateAllUnits takes nothing returns nothing
call R23_CreateNeutralHostileBuildings()
call R23_CreateNeutralPassiveBuildings()
call R23_CreatePlayerBuildings()
call R23_CreateNeutralHostile()
call R23_CreateNeutralPassive()
call R23_CreatePlayerUnits()
endfunction

function R23_CreateRegions takes nothing returns nothing
local weathereffect we
set udg_R23_gg_rct_NerubianA1Ext=Rect(-5504.,26688.,-4832.,27424.)
set udg_R23_gg_rct_NerubianA1move=Rect(-6624.,-17152.,-5952.,-16416.)
set udg_R23_gg_rct_NerubianB2Ext=Rect(1216.,28736.,1888.,29472.)
set udg_R23_gg_rct_NerubianB2move=Rect(-3232.,-13888.,-2560.,-13152.)
set udg_R23_gg_rct_NerubianC3Ext=Rect(5184.,23040.,5856.,23776.)
set udg_R23_gg_rct_NerubianC3move=Rect(-1088.,-15680.,-416.,-14944.)
set udg_R23_gg_rct_NorthrendSnow=Rect(-11328.,23840.,7648.,30688.)
set we=AddWeatherEffect(udg_R23_gg_rct_NorthrendSnow,'SNbs')
call EnableWeatherEffect(we,true)
set udg_R23_gg_rct_NorthrendSnow2=Rect(-3360.,22048.,4704.,23968.)
set we=AddWeatherEffect(udg_R23_gg_rct_NorthrendSnow2,'SNbs')
call EnableWeatherEffect(we,true)
set udg_R23_gg_rct_OutlandExt=Rect(22880.,-3328.,23552.,-2688.)
set udg_R23_gg_rct_OutlandMove=Rect(-11648.,-21728.,-10976.,-21088.)
set udg_R23_gg_rct_SpawnPoint_Broken_isles=Rect(4448.,11904.,4832.,12288.)
set udg_R23_gg_rct_SpawnPoint_EasternKingdom1=Rect(15808.,-2080.,16128.,-1760.)
set udg_R23_gg_rct_SpawnPoint_EasternKingdom2=Rect(18464.,11680.,18784.,12000.)
set udg_R23_gg_rct_SpawnPoint_Kalimdor1=Rect(-20864.,2048.,-20480.,2432.)
set udg_R23_gg_rct_SpawnPoint_Kalimdor2=Rect(-14720.,10624.,-14336.,11008.)
set udg_R23_gg_rct_SpawnPoint_Northland1=Rect(-4416.,25024.,-4032.,25408.)
set udg_R23_gg_rct_SpawnPoint_Northland2=Rect(7232.,24352.,7616.,24736.)
set udg_R23_gg_rct_SpawnPoint_Pandaria=Rect(-4096.,-5888.,-3712.,-5504.)
set udg_R23_gg_rct_SpawnVision=Rect(23872.,-28448.,27648.,-24480.)
set udg_R23_gg_rct_KTunRaideExt=Rect(-21888.,-6080.,-21248.,-5440.)
set udg_R23_gg_rct_KTunRaideMove=Rect(-3072.,-21536.,-2336.,-20672.)
set udg_R23_gg_rct_QogSaronMove=Rect(-4032.,-26560.,-3200.,-25664.)
set udg_R23_gg_rct_QogSaronExt=Rect(4800.,29792.,5312.,30368.)
set udg_R23_gg_rct_NZotMove=Rect(832.,-27680.,1664.,-26784.)
set udg_R23_gg_rct_NZotExt=Rect(3424.,960.,4064.,1568.)
set udg_R23_gg_rct_Raide01Move=Rect(480.,-23232.,1312.,-22624.)
set udg_R23_gg_rct_Raide01Ext=Rect(21120.,10176.,21824.,10656.)
set udg_R23_gg_rct_QOGGSARON=Rect(-6816.,-27424.,-3168.,-24864.)
set we=AddWeatherEffect(udg_R23_gg_rct_QOGGSARON,'WNcw')
call EnableWeatherEffect(we,true)
set udg_R23_gg_rct_TEXTKalimdor1=Rect(24320.,-26048.,24576.,-25888.)
set udg_R23_gg_rct_TEXTKalimdor2=Rect(24320.,-27456.,24576.,-27296.)
set udg_R23_gg_rct_TEXTPandaria=Rect(25216.,-27456.,25472.,-27296.)
set udg_R23_gg_rct_TEXTBrokenIsles=Rect(26112.,-27456.,26368.,-27296.)
set udg_R23_gg_rct_TEXTEastKingdom2=Rect(27008.,-27488.,27264.,-27328.)
set udg_R23_gg_rct_TEXTEastKingdom1=Rect(27008.,-26048.,27264.,-25888.)
set udg_R23_gg_rct_TEXTNorth1=Rect(26112.,-26048.,26368.,-25888.)
set udg_R23_gg_rct_TEXTNorth2=Rect(25216.,-26016.,25472.,-25856.)
set udg_R23_gg_rct_SpawnLocation=Rect(25312.,-27232.,26336.,-26208.)
set udg_R23_gg_rct_RAGNAROSS=Rect(4000.,-26976.,4576.,-26240.)
set udg_R23_gg_rct_RAGNAROSS_EXT=Rect(18048.,1984.,18464.,2336.)
set udg_R23_gg_rct_HeroSpawn=Rect(13728.,-28192.,14144.,-27872.)
set udg_R23_gg_rct_VAICHmove=Rect(1664.,-15296.,2432.,-14432.)
set udg_R23_gg_rct_VAICHext=Rect(8288.,1728.,8800.,2304.)
set udg_R23_gg_rct_EarthExt=Rect(-1888.,3264.,-1312.,3712.)
set udg_R23_gg_rct_EarthMove=Rect(8128.,-25184.,8864.,-24512.)
set udg_R23_gg_rct_KazemateMove=Rect(3488.,-21696.,3936.,-21280.)
set udg_R23_gg_rct_KazemateExt=Rect(-192.,6016.,256.,6432.)
set udg_R23_gg_rct_Necrositetext=Rect(19360.,13856.,19712.,14208.)
set udg_R23_gg_rct_Necrositemove=Rect(4992.,-15328.,5600.,-14752.)
set udg_R23_gg_rct_DalaranMove=Rect(13600.,-16064.,14208.,-15552.)
set udg_R23_gg_rct_DalaranExt=Rect(2208.,26688.,2816.,27200.)
set udg_R23_gg_rct_Effect1=Rect(21600.,18016.,22432.,18144.)
set we=AddWeatherEffect(udg_R23_gg_rct_Effect1,'FDrh')
call EnableWeatherEffect(we,true)
set udg_R23_gg_rct_Effect1_____________________u=Rect(19808.,17408.,19872.,17760.)
set we=AddWeatherEffect(udg_R23_gg_rct_Effect1_____________________u,'FDrh')
call EnableWeatherEffect(we,true)
set udg_R23_gg_rct_DalaranEffect=Rect(11424.,-16960.,14144.,-14368.)
set we=AddWeatherEffect(udg_R23_gg_rct_DalaranEffect,'MEds')
call EnableWeatherEffect(we,true)
set udg_R23_gg_rct_UlduarEffect=Rect(1088.,27520.,6368.,30688.)
set we=AddWeatherEffect(udg_R23_gg_rct_UlduarEffect,'WNcw')
call EnableWeatherEffect(we,true)
set udg_R23_gg_rct_Effect=Rect(-24640.,7680.,-21664.,11904.)
set udg_R23_gg_rct_NaxxramasSpellUsePoint=Rect(-1664.,24896.,-1088.,25568.)
set udg_R23_gg_rct_NaxxramasSpawn=Rect(-1536.,25280.,-1344.,25472.)
set udg_R23_gg_rct_Naxxramas=Rect(7808.,-23456.,10144.,-20960.)
set udg_R23_gg_rct_TEXTOutland=Rect(26720.,-26752.,26976.,-26624.)
set udg_R23_gg_rct_Outland=Rect(-20160.,-21792.,-19648.,-21376.)
set udg_R23_gg_rct_NaxxramasEXT=Rect(23008.,16288.,23360.,16640.)
set udg_R23_gg_rct_NaxxramasMOVE=Rect(8768.,-21888.,9120.,-21536.)
set udg_R23_gg_rct_HeroByCommand1=Rect(19136.,-3616.,19392.,-3360.)
set udg_R23_gg_rct_HeroByCommand2=Rect(-15680.,-25312.,-15232.,-24992.)
endfunction

function R23_PrepareGame takes nothing returns nothing
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
set udg_R23_gg_snd_ArtilleryCorpseExplodeDeath1=gg_snd_ArtilleryCorpseExplodeDeath1
call SetSoundParamsFromLabel(udg_R23_gg_snd_ArtilleryCorpseExplodeDeath1,"ArtilleryExplodeDeath")
call SetSoundDuration(udg_R23_gg_snd_ArtilleryCorpseExplodeDeath1,1486)
set udg_R23_gg_snd_PeasantWarcry1=gg_snd_PeasantWarcry1
call SetSoundParamsFromLabel(udg_R23_gg_snd_PeasantWarcry1,"PeasantWarcry")
call SetSoundDuration(udg_R23_gg_snd_PeasantWarcry1,1182)
set udg_R23_gg_snd_PeasantYes1=gg_snd_PeasantYes1
call SetSoundParamsFromLabel(udg_R23_gg_snd_PeasantYes1,"PeasantYes")
call SetSoundDuration(udg_R23_gg_snd_PeasantYes1,373)
set udg_R23_gg_snd_PeasantYesAttack4=gg_snd_PeasantYesAttack4
call SetSoundParamsFromLabel(udg_R23_gg_snd_PeasantYesAttack4,"PeasantYesAttack")
call SetSoundDuration(udg_R23_gg_snd_PeasantYesAttack4,1886)
set udg_R23_gg_snd_HeroFarseerPissed1=gg_snd_HeroFarseerPissed1
call SetSoundParamsFromLabel(udg_R23_gg_snd_HeroFarseerPissed1,"HeroFarseerPissed")
call SetSoundDuration(udg_R23_gg_snd_HeroFarseerPissed1,3857)
set udg_R23_gg_snd_HPitLordYesAttack1=gg_snd_HPitLordYesAttack1
call SetSoundParamsFromLabel(udg_R23_gg_snd_HPitLordYesAttack1,"HeroPitLordYesAttack")
call SetSoundDuration(udg_R23_gg_snd_HPitLordYesAttack1,1658)
set udg_R23_gg_snd_A07Kiljaeden30=gg_snd_A07Kiljaeden30
call SetSoundParamsFromLabel(udg_R23_gg_snd_A07Kiljaeden30,"A07Kiljaeden30")
call SetSoundDuration(udg_R23_gg_snd_A07Kiljaeden30,17371)
set udg_R23_gg_snd_zsukdarkportal=gg_snd_zsukdarkportal
call SetSoundChannel(udg_R23_gg_snd_zsukdarkportal,0)
call SetSoundVolume(udg_R23_gg_snd_zsukdarkportal,127)
call SetSoundPitch(udg_R23_gg_snd_zsukdarkportal,1.)
set udg_R23_gg_snd_U02KelThuzad27=gg_snd_U02KelThuzad27
call SetSoundParamsFromLabel(udg_R23_gg_snd_U02KelThuzad27,"U02KelThuzad27")
call SetSoundDuration(udg_R23_gg_snd_U02KelThuzad27,8594)
set udg_R23_gg_rct_NerubianA1Ext=gg_rct_NerubianA1Ext
set udg_R23_gg_rct_NerubianA1move=gg_rct_NerubianA1move
set udg_R23_gg_rct_NerubianB2Ext=gg_rct_NerubianB2Ext
set udg_R23_gg_rct_NerubianB2move=gg_rct_NerubianB2move
set udg_R23_gg_rct_NerubianC3Ext=gg_rct_NerubianC3Ext
set udg_R23_gg_rct_NerubianC3move=gg_rct_NerubianC3move
set udg_R23_gg_rct_NorthrendSnow=gg_rct_NorthrendSnow
set udg_R23_gg_rct_NorthrendSnow2=gg_rct_NorthrendSnow2
set udg_R23_gg_rct_OutlandExt=gg_rct_OutlandExt
set udg_R23_gg_rct_OutlandMove=gg_rct_OutlandMove
set udg_R23_gg_rct_SpawnPoint_Broken_isles=gg_rct_SpawnPoint_Broken_isles
set udg_R23_gg_rct_SpawnPoint_EasternKingdom1=gg_rct_SpawnPoint_EasternKingdom1
set udg_R23_gg_rct_SpawnPoint_EasternKingdom2=gg_rct_SpawnPoint_EasternKingdom2
set udg_R23_gg_rct_SpawnPoint_Kalimdor1=gg_rct_SpawnPoint_Kalimdor1
set udg_R23_gg_rct_SpawnPoint_Kalimdor2=gg_rct_SpawnPoint_Kalimdor2
set udg_R23_gg_rct_SpawnPoint_Northland1=gg_rct_SpawnPoint_Northland1
set udg_R23_gg_rct_SpawnPoint_Northland2=gg_rct_SpawnPoint_Northland2
set udg_R23_gg_rct_SpawnPoint_Pandaria=gg_rct_SpawnPoint_Pandaria
set udg_R23_gg_rct_SpawnVision=gg_rct_SpawnVision
set udg_R23_gg_rct_KTunRaideExt=gg_rct_KTunRaideExt
set udg_R23_gg_rct_KTunRaideMove=gg_rct_KTunRaideMove
set udg_R23_gg_rct_QogSaronMove=gg_rct_QogSaronMove
set udg_R23_gg_rct_QogSaronExt=gg_rct_QogSaronExt
set udg_R23_gg_rct_NZotMove=gg_rct_NZotMove
set udg_R23_gg_rct_NZotExt=gg_rct_NZotExt
set udg_R23_gg_rct_Raide01Move=gg_rct_Raide01Move
set udg_R23_gg_rct_Raide01Ext=gg_rct_Raide01Ext
set udg_R23_gg_rct_QOGGSARON=gg_rct_QOGGSARON
set udg_R23_gg_rct_TEXTKalimdor1=gg_rct_TEXTKalimdor1
set udg_R23_gg_rct_TEXTKalimdor2=gg_rct_TEXTKalimdor2
set udg_R23_gg_rct_TEXTPandaria=gg_rct_TEXTPandaria
set udg_R23_gg_rct_TEXTBrokenIsles=gg_rct_TEXTBrokenIsles
set udg_R23_gg_rct_TEXTEastKingdom2=gg_rct_TEXTEastKingdom2
set udg_R23_gg_rct_TEXTEastKingdom1=gg_rct_TEXTEastKingdom1
set udg_R23_gg_rct_TEXTNorth1=gg_rct_TEXTNorth1
set udg_R23_gg_rct_TEXTNorth2=gg_rct_TEXTNorth2
set udg_R23_gg_rct_SpawnLocation=gg_rct_SpawnLocation
set udg_R23_gg_rct_RAGNAROSS=gg_rct_RAGNAROSS
set udg_R23_gg_rct_RAGNAROSS_EXT=gg_rct_RAGNAROSS_EXT
set udg_R23_gg_rct_HeroSpawn=gg_rct_HeroSpawn
set udg_R23_gg_rct_VAICHmove=gg_rct_VAICHmove
set udg_R23_gg_rct_VAICHext=gg_rct_VAICHext
set udg_R23_gg_rct_EarthExt=gg_rct_EarthExt
set udg_R23_gg_rct_EarthMove=gg_rct_EarthMove
set udg_R23_gg_rct_KazemateMove=gg_rct_KazemateMove
set udg_R23_gg_rct_KazemateExt=gg_rct_KazemateExt
set udg_R23_gg_rct_Necrositetext=gg_rct_Necrositetext
set udg_R23_gg_rct_Necrositemove=gg_rct_Necrositemove
set udg_R23_gg_rct_DalaranMove=gg_rct_DalaranMove
set udg_R23_gg_rct_DalaranExt=gg_rct_DalaranExt
set udg_R23_gg_rct_Effect1=gg_rct_Effect1
set udg_R23_gg_rct_Effect1_____________________u=gg_rct_Effect1_____________________u
set udg_R23_gg_rct_DalaranEffect=gg_rct_DalaranEffect
set udg_R23_gg_rct_UlduarEffect=gg_rct_UlduarEffect
set udg_R23_gg_rct_Effect=gg_rct_Effect
set udg_R23_gg_rct_NaxxramasSpellUsePoint=gg_rct_NaxxramasSpellUsePoint
set udg_R23_gg_rct_NaxxramasSpawn=gg_rct_NaxxramasSpawn
set udg_R23_gg_rct_Naxxramas=gg_rct_Naxxramas
set udg_R23_gg_rct_TEXTOutland=gg_rct_TEXTOutland
set udg_R23_gg_rct_Outland=gg_rct_Outland
set udg_R23_gg_rct_NaxxramasEXT=gg_rct_NaxxramasEXT
set udg_R23_gg_rct_NaxxramasMOVE=gg_rct_NaxxramasMOVE
set udg_R23_gg_rct_HeroByCommand1=gg_rct_HeroByCommand1
set udg_R23_gg_rct_HeroByCommand2=gg_rct_HeroByCommand2
set udg_R23_gg_dest_B000_5046=gg_dest_B000_5046
set udg_R23_gg_dest_B000_10403=gg_dest_B000_10403
call R23_CreateNeutralHostileBuildings()
call R23_CreateNeutralPassiveBuildings()
call R23_CreatePlayerBuildings()
call R23_CreateNeutralHostile()
call R23_CreateNeutralPassive()
set i=0
set udg_R23_udg_Compteur1=CreateTimer()
set i=0
loop
exitwhen(i>1)
set udg_R23_udg_Col_vo_units[i]=0
set udg_R23_udg_Can_pick[i]=false
set udg_R23_udg_PlayersCount[i]=0
set udg_R23_udg_PlayersForce[i]=CreateForce()
set udg_R23_udg_Kill[i]=0
set udg_R23_udg_Death[i]=0
set udg_R23_udg_Kills[i]=0
set udg_R23_udg_Deaths[i]=0
set i=i+1
endloop
set udg_R23_udg_Group=CreateForce()
set udg_R23_udg_Players_hero=CreateForce()
set udg_R23_udg_MultiBoard=CreateMultiboard()
endfunction
