using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
[ExecuteInEditMode]
public class SaveLoad
{
	public static string SaveName = "NewGame";

	public static float Difficulty;

	public static void AAAAAAAAAAAAAAAAAAde(string AAAAAAAAAAAAAAAAAAdf, bool AAAAAAAAAAAAAAck)
	{
		if (!AAAAAAAAAAAAAAck)
		{
			Inventory.AAAAAAAAAAAAAAAAAAcy(AAAAAAAAAAAAAAAAAAdf);
		}
		PlayerPrefs.SetString(AAAAAAAAAAAAAAAAAAdf + "CurrentScene", SceneManager.GetActiveScene().name);
		string path = Path.Combine(Application.persistentDataPath, "CipherAutoSave.json");
		SaveOneMap saveOneMap;
		if (!File.Exists(path))
		{
			saveOneMap = AAAAAAAAAAAAAAAbw.AAAAAAAAAAAAAAcd;
		}
		else
		{
			string text = File.ReadAllText(path);
			int length = text.Length;
			byte[] array = new byte[length / 2];
			for (int i = 0; i < length; i += 2)
			{
				array[i / 2] = Convert.ToByte(text.Substring(i, 2), 16);
			}
			text = Encoding.UTF8.GetString(array, 0, array.Length);
			saveOneMap = JsonUtility.FromJson<SaveOneMap>(text);
		}
		saveOneMap.staS.helpBool = Inventory._HelpBool;
		saveOneMap.staS.CurrentScene = SceneManager.GetActiveScene().name;
		saveOneMap.staS.gameSpeed = AAAAAAAAAAAAAAAAAAAAct.GameSpeed;
		saveOneMap.staS.sizeMap = AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAcf;
		saveOneMap.staS._curCharacter = CharacterMotion._curCharacter;
		saveOneMap.staS._PointsMove = CharacterMotion._PointsMove;
		saveOneMap.staS._difficultyLevel = Difficulty;
		saveOneMap.staS._ejectTime = EjectTimeSc.Ejection;
		if (saveOneMap.staS.statusG.Length == 13)
		{
			for (int j = 0; j < 13; j++)
			{
				saveOneMap.staS.statusG[j] = AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[j, 0];
			}
			saveOneMap.staS.statusGroups.Clear();
			for (int k = 0; k < 13; k++)
			{
				for (int l = 0; l < 13; l++)
				{
					saveOneMap.staS.statusGroups.Add(AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[k, l]);
				}
			}
		}
		while (true)
		{
			int num = 0;
			while (true)
			{
				if (num < saveOneMap.charactersAndPionts.Count)
				{
					if (saveOneMap.charactersAndPionts[num]._curMap == SceneManager.GetActiveScene().name)
					{
						break;
					}
					num++;
					continue;
				}
				saveOneMap.staS._task.Clear();
				foreach (ConstructorTasks item in Data.TaskAll)
				{
					TaskForSave taskForSave = new TaskForSave();
					taskForSave._nameTask = item.NameTask;
					if (item.QuestSubject != null)
					{
						taskForSave._questSubjectName = item.QuestSubject.NameSubject;
					}
					if (item.KillCharacterName != null)
					{
						taskForSave._killCharacterName = item.KillCharacterName;
					}
					if (item.NamePointTask != null)
					{
						taskForSave._namePointTask = item.NamePointTask;
					}
					taskForSave._numberDealer = item.NumberDealer;
					taskForSave._numberTurgetInData = item.NumberTurgetInData;
					taskForSave._numberPointOfGuide = item.NumberPointOfGuide;
					if (item.MapName != null)
					{
						taskForSave._mapName = item.MapName;
					}
					if (item.GroupName != null)
					{
						taskForSave._groupName = item.GroupName;
					}
					taskForSave._numberEnemy = item.NumberEnemy;
					saveOneMap.staS._task.Add(taskForSave);
				}
				saveOneMap.staS.ListOldTask.Clear();
				foreach (string item2 in Data.OldTask)
				{
					if (item2 != null)
					{
						saveOneMap.staS.ListOldTask.Add(item2);
					}
				}
				for (int m = 0; m < Data.CharacterD.Count; m++)
				{
					if (Data.CharacterD[m] == null)
					{
						continue;
					}
					CharacterAndPoint characterAndPoint = new CharacterAndPoint();
					characterAndPoint._curMap = SceneManager.GetActiveScene().name;
					if (Data.CharacterD[m].NameU != null)
					{
						characterAndPoint._nameU = Data.CharacterD[m].NameU;
					}
					if (Data.CharacterD[m].NameCharac != null)
					{
						characterAndPoint._nameCharac = Data.CharacterD[m].NameCharac;
					}
					characterAndPoint._typeCharInt = Data.CharacterD[m].TypeChInt;
					characterAndPoint._controlGamer = Data.CharacterD[m].ControlGamer;
					characterAndPoint._life = Data.CharacterD[m].Life;
					if (Data.CharacterD[m].CurGexChar != null)
					{
						characterAndPoint._curGexCharName = Data.CharacterD[m].CurGexChar.NameGex;
					}
					characterAndPoint._skill = Data.CharacterD[m].Skill;
					if (Data.CharacterD[m].SuitChar != null)
					{
						characterAndPoint._suitCharName = Data.CharacterD[m].SuitChar.NameSubject;
						characterAndPoint._suitCharState = Data.CharacterD[m].SuitChar.State;
						characterAndPoint.WeightUpGrade = Data.CharacterD[m].SuitChar.WeightUpGrade;
						characterAndPoint.UpGrade = Data.CharacterD[m].SuitChar.UpGrade;
						characterAndPoint.SingUG_suit = Data.CharacterD[m].SuitChar.SingModification;
					}
					else
					{
						Inventory.MessagePanel("Ошибка сохранения, приносим извинения за неудобства. Если Вас не затруднит, напишите о ней разработчику, это поможет быстрее устранить причину ошибки. Спасибо.\n" + SceneManager.GetActiveScene().name + ", " + characterAndPoint._nameU + ", , suit\n");
						characterAndPoint._suitCharName = "None";
						characterAndPoint._suitCharState = 0f;
						characterAndPoint.WeightUpGrade = 0f;
						characterAndPoint.UpGrade = 0f;
						characterAndPoint.SingUG_suit = false;
					}
					characterAndPoint._suitCharContainer = Data.CharacterD[m].SuitChar.ArtContainer;
					if (Data.CharacterD[m].ArtContainers[0] != null)
					{
						characterAndPoint._ArtContainer[0] = Data.CharacterD[m].ArtContainers[0].NameSubject;
					}
					else
					{
						Inventory.MessagePanel("Ошибка сохранения, приносим извинения за неудобства. Если Вас не затруднит, напишите о ней разработчику, это поможет быстрее устранить причину ошибки. Спасибо.\n" + SceneManager.GetActiveScene().name + ", " + characterAndPoint._nameU + ", , art0\n");
						characterAndPoint._ArtContainer[0] = "None";
					}
					if (Data.CharacterD[m].ArtContainers[1] != null)
					{
						characterAndPoint._ArtContainer[1] = Data.CharacterD[m].ArtContainers[1].NameSubject;
					}
					else
					{
						Inventory.MessagePanel("Ошибка сохранения, приносим извинения за неудобства. Если Вас не затруднит, напишите о ней разработчику, это поможет быстрее устранить причину ошибки. Спасибо.\n" + SceneManager.GetActiveScene().name + ", " + characterAndPoint._nameU + ", , art1\n");
						characterAndPoint._ArtContainer[1] = "None";
					}
					if (Data.CharacterD[m].ArtContainers[2] != null)
					{
						characterAndPoint._ArtContainer[2] = Data.CharacterD[m].ArtContainers[2].NameSubject;
					}
					else
					{
						Inventory.MessagePanel("Ошибка сохранения, приносим извинения за неудобства. Если Вас не затруднит, напишите о ней разработчику, это поможет быстрее устранить причину ошибки. Спасибо.\n" + SceneManager.GetActiveScene().name + ", " + characterAndPoint._nameU + ", , art2\n");
						characterAndPoint._ArtContainer[2] = "None";
					}
					if (Data.CharacterD[m].ArtContainers[3] != null)
					{
						characterAndPoint._ArtContainer[3] = Data.CharacterD[m].ArtContainers[3].NameSubject;
					}
					else
					{
						Inventory.MessagePanel("Ошибка сохранения, приносим извинения за неудобства. Если Вас не затруднит, напишите о ней разработчику, это поможет быстрее устранить причину ошибки. Спасибо.\n" + SceneManager.GetActiveScene().name + ", " + characterAndPoint._nameU + ", , art3\n");
						characterAndPoint._ArtContainer[3] = "None";
					}
					if (Data.CharacterD[m].WeaponChar != null)
					{
						characterAndPoint._weaponCharName = Data.CharacterD[m].WeaponChar.NameSubject;
						characterAndPoint._weaponCharState = Data.CharacterD[m].WeaponChar.State;
						characterAndPoint.WeightUpGradeWeapon = Data.CharacterD[m].WeaponChar.WeightUpGrade;
						characterAndPoint.WeaponUpGrade = Data.CharacterD[m].WeaponChar.UpGrade;
						characterAndPoint.SingUG_weapon = Data.CharacterD[m].WeaponChar.SingModification;
						characterAndPoint._weaponCharSightInstallation = Data.CharacterD[m].WeaponChar.SightInstallation;
						characterAndPoint.CartridgeInt = Data.CharacterD[m].WeaponChar.Cartridge;
					}
					else
					{
						Inventory.MessagePanel("Ошибка сохранения, приносим извинения за неудобства. Если Вас не затруднит, напишите о ней разработчику, это поможет быстрее устранить причину ошибки. Спасибо.\n" + SceneManager.GetActiveScene().name + ", " + characterAndPoint._nameU + ", , weapon\n");
						characterAndPoint._weaponCharName = "None";
						characterAndPoint._weaponCharState = 0f;
						characterAndPoint.WeightUpGradeWeapon = 0f;
						characterAndPoint.WeaponUpGrade = 0f;
						characterAndPoint.SingUG_weapon = false;
						characterAndPoint._weaponCharSightInstallation = false;
						characterAndPoint.CartridgeInt = 0;
					}
					if (Data.CharacterD[m].DetectorChar != null)
					{
						characterAndPoint._detectorCharName = Data.CharacterD[m].DetectorChar.NameSubject;
					}
					else
					{
						characterAndPoint._detectorCharName = "None";
					}
					characterAndPoint._cash = Data.CharacterD[m].Cash;
					characterAndPoint._curHealth = Data.CharacterD[m].CurHealth;
					characterAndPoint._bleeding = Data.CharacterD[m].Bleeding;
					characterAndPoint._diseaseXRay = Data.CharacterD[m].DiseaseXRay;
					characterAndPoint._chemicalBurn = Data.CharacterD[m].ChemicalBurnCh;
					characterAndPoint._burn = Data.CharacterD[m].BurnCh;
					characterAndPoint._bonus = Data.CharacterD[m].Bonus;
					characterAndPoint._ageOfDeath = Data.CharacterD[m].AgeOfDeath;
					characterAndPoint._satietyCh = Data.CharacterD[m].Satiety;
					characterAndPoint._thirst = Data.CharacterD[m].Thirst;
					for (int n = 0; n < 20; n++)
					{
						if (Data.CharacterD[m].CharBackpack[n] != null)
						{
							characterAndPoint._CharBackpack[n] = Data.CharacterD[m].CharBackpack[n].NameSubject;
							characterAndPoint._StateCharBackpack[n] = (int)Data.CharacterD[m].CharBackpack[n].State;
							characterAndPoint._StackCharBackpack[n] = Data.CharacterD[m].CharBackpack[n].Stack;
							characterAndPoint._StackCharBackpackWSI[n] = Data.CharacterD[m].CharBackpack[n].SightInstallation;
							characterAndPoint._StackCharBackpackContainer[n] = Data.CharacterD[m].CharBackpack[n].ArtContainer;
							characterAndPoint._StackCharWeightUpGrade[n] = Data.CharacterD[m].CharBackpack[n].WeightUpGrade;
							characterAndPoint._StackCharUpGrade[n] = Data.CharacterD[m].CharBackpack[n].UpGrade;
							characterAndPoint._SingUG[n] = Data.CharacterD[m].CharBackpack[n].SingModification;
							characterAndPoint._StackCartridge[n] = Data.CharacterD[m].CharBackpack[n].Cartridge;
						}
						else
						{
							Inventory.MessagePanel("Ошибка сохранения, приносим извинения за неудобства. Если Вас не затруднит, напишите о ней разработчику, это поможет быстрее устранить причину ошибки. Спасибо.\n" + SceneManager.GetActiveScene().name + ", " + characterAndPoint._nameU + ", , backpack[" + n + "]\n");
							characterAndPoint._CharBackpack[n] = "None";
							characterAndPoint._StateCharBackpack[n] = 0;
							characterAndPoint._StackCharBackpack[n] = 0;
							characterAndPoint._StackCharBackpackWSI[n] = false;
							characterAndPoint._StackCharBackpackContainer[n] = 0;
							characterAndPoint._StackCharWeightUpGrade[n] = 0f;
							characterAndPoint._StackCharUpGrade[n] = 0f;
							characterAndPoint._SingUG[n] = false;
							characterAndPoint._StackCartridge[n] = 0;
						}
					}
					characterAndPoint.Accuracy = Data.CharacterD[m].Accuracy;
					characterAndPoint.Andurance = Data.CharacterD[m].Andurance;
					characterAndPoint.HealthAdditional = Data.CharacterD[m].HealthAdditional;
					characterAndPoint.PSIprotection = Data.CharacterD[m].PSIprotection;
					saveOneMap.charactersAndPionts.Add(characterAndPoint);
				}
				for (int num2 = 0; num2 < Data.Points.Count; num2++)
				{
					if (Data.Points[num2] == null)
					{
						continue;
					}
					CharacterAndPoint characterAndPoint2 = new CharacterAndPoint();
					characterAndPoint2._curMap = SceneManager.GetActiveScene().name;
					if (Data.Points[num2].namePoint != null)
					{
						characterAndPoint2._nameU = Data.Points[num2].namePoint;
					}
					characterAndPoint2._typeCharInt = Data.Points[num2].ControlInt;
					characterAndPoint2._exchange = Data.Points[num2].exchange;
					characterAndPoint2._repair = Data.Points[num2].Repair;
					characterAndPoint2._medic = Data.Points[num2].Medic;
					characterAndPoint2._taskChoise = Data.Points[num2].TaskChoise;
					for (int num3 = 0; num3 < 20; num3++)
					{
						if (Data.Points[num2].Cache[num3] != null)
						{
							characterAndPoint2._CharBackpack[num3] = Data.Points[num2].Cache[num3].NameSubject;
							characterAndPoint2._StateCharBackpack[num3] = (int)Data.Points[num2].Cache[num3].State;
							characterAndPoint2._StackCharBackpack[num3] = Data.Points[num2].Cache[num3].Stack;
							characterAndPoint2._StackCharBackpackWSI[num3] = Data.Points[num2].Cache[num3].SightInstallation;
							characterAndPoint2._StackCharBackpackContainer[num3] = Data.Points[num2].Cache[num3].ArtContainer;
							characterAndPoint2._StackCharWeightUpGrade[num3] = Data.Points[num2].Cache[num3].WeightUpGrade;
							characterAndPoint2._StackCharUpGrade[num3] = Data.Points[num2].Cache[num3].UpGrade;
							characterAndPoint2._SingUG[num3] = Data.Points[num2].Cache[num3].SingModification;
							characterAndPoint2._StackCartridge[num3] = Data.Points[num2].Cache[num3].Cartridge;
						}
						else
						{
							Inventory.MessagePanel("Ошибка сохранения, приносим извинения за неудобства. Если Вас не затруднит, напишите о ней разработчику, это поможет быстрее устранить причину ошибки. Спасибо.\n" + SceneManager.GetActiveScene().name + ", " + characterAndPoint2._nameU + ", cache[" + num3 + "], ");
							characterAndPoint2._CharBackpack[num3] = "None";
							characterAndPoint2._StateCharBackpack[num3] = 0;
							characterAndPoint2._StackCharBackpack[num3] = 0;
							characterAndPoint2._StackCharBackpackWSI[num3] = false;
							characterAndPoint2._StackCharBackpackContainer[num3] = 0;
							characterAndPoint2._StackCharWeightUpGrade[num3] = 0f;
							characterAndPoint2._StackCharUpGrade[num3] = 0f;
							characterAndPoint2._SingUG[num3] = false;
							characterAndPoint2._StackCartridge[num3] = 0;
						}
					}
					saveOneMap.charactersAndPionts.Add(characterAndPoint2);
				}
				path = Path.Combine(Application.persistentDataPath, "Cipher" + AAAAAAAAAAAAAAAAAAdf + ".json");
				string text = JsonUtility.ToJson(saveOneMap);
				byte[] array = Encoding.UTF8.GetBytes(text);
				string text2 = BitConverter.ToString(array);
				File.WriteAllText(path, text2.Replace("-", string.Empty));
				return;
			}
			saveOneMap.charactersAndPionts.RemoveAt(num);
		}
	}

	public static void AAAAAAAAAAAAAAAAAAAAAcp(string AAAAAAAAAAAAAAAAcc, string AAAAAAAAAAAAAAAAAAAAcr)
	{
		if (AAAAAAAAAAAAAAAAcc == "NewGame")
		{
			GameObject.Find("Main Camera").GetComponent<LoadingCircleScript>().AAAAAAAAAAAAAAAAe("Kordon", AAAAAAAAAAAAAAAAcc);
			CharacterMotion._curCharacter = 0;
		}
		else
		{
			GameObject.Find("Main Camera").GetComponent<LoadingCircleScript>().AAAAAAAAAAAAAAAAe(AAAAAAAAAAAAAAAAAAAAcr, AAAAAAAAAAAAAAAAcc);
		}
	}

	public static void AAAAAAAAAAAAAAAAAAAci(string AAAAAAAAAAAAAAAAAAAcj)
	{
		if (!(AAAAAAAAAAAAAAAAAAAcj != "NewGame"))
		{
			return;
		}
		Debug.Log("!newGame");
		Inventory._TaskNum = 0;
		string path = Path.Combine(Application.persistentDataPath, "Cipher" + AAAAAAAAAAAAAAAAAAAcj + ".json");
		SaveOneMap saveOneMap;
		string text;
		byte[] array;
		if (!File.Exists(path))
		{
			saveOneMap = AAAAAAAAAAAAAAAbw.AAAAAAAAAAAAAAcd;
			Debug.Log("Сохранения не существует");
		}
		else
		{
			text = File.ReadAllText(path);
			int length = text.Length;
			array = new byte[length / 2];
			for (int i = 0; i < length; i += 2)
			{
				array[i / 2] = Convert.ToByte(text.Substring(i, 2), 16);
			}
			text = Encoding.UTF8.GetString(array, 0, array.Length);
			saveOneMap = JsonUtility.FromJson<SaveOneMap>(text);
		}
		Inventory._HelpBool = saveOneMap.staS.helpBool;
		AAAAAAAAAAAAAAAAAAAAct.GameSpeed = saveOneMap.staS.gameSpeed;
		AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAcf = saveOneMap.staS.sizeMap;
		CharacterMotion._curCharacter = saveOneMap.staS._curCharacter;
		CharacterMotion._PointsMove = saveOneMap.staS._PointsMove;
		Difficulty = saveOneMap.staS._difficultyLevel;
		if (Difficulty == 0f)
		{
			Difficulty = 1f;
		}
		EjectTimeSc.Ejection = saveOneMap.staS._ejectTime;
		if (saveOneMap.staS.statusG.Length == 13)
		{
			bool flag = false;
			foreach (int statusGroup in saveOneMap.staS.statusGroups)
			{
				if (statusGroup > 0)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				for (int j = 0; j < 13; j++)
				{
					AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[j, 0] = saveOneMap.staS.statusG[j];
					if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[j, 0] > 9)
					{
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[j, 0] = 9;
					}
					AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, j] = saveOneMap.staS.statusG[j];
					if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, j] > 9)
					{
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, j] = 9;
					}
				}
			}
			else
			{
				for (int k = 0; k < 13; k++)
				{
					for (int l = 0; l < 13; l++)
					{
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[k, l] = saveOneMap.staS.statusGroups[k * 13 + l];
					}
				}
			}
		}
		Data.TaskAll.Clear();
		foreach (TaskForSave item in saveOneMap.staS._task)
		{
			if (item._nameTask == "Найти Механика")
			{
				Data._tasks = new TaskGlobal0();
			}
			if (item._nameTask == "Старый скряга")
			{
				Data._tasks = new TaskBasic0();
			}
			if (item._nameTask == "Флешка убитого сталкера")
			{
				Data._tasks = new TaskBasic1();
			}
			if (item._nameTask == "Курьер")
			{
				Data._tasks = new TaskBasic1_5();
			}
			if (item._nameTask == "Информация X18")
			{
				Data._tasks = new TaskBasic2();
			}
			if (item._nameTask == "Бар")
			{
				Data._tasks = new TaskBasic2_5();
			}
			if (item._nameTask == "Завод Янтарь")
			{
				Data._tasks = new TaskBasic3();
			}
			if (item._nameTask == "Мертвый город")
			{
				Data._tasks = new TaskBasic4();
			}
			if (item._nameTask == "База Свободы")
			{
				Data._tasks = new TaskBasic5();
			}
			if (item._nameTask == "Радар")
			{
				Data._tasks = new TaskBasic6();
			}
			if (item._nameTask == "Поиск на Радаре")
			{
				Data._tasks = new TaskBasic6_5();
			}
			if (item._nameTask == "Брат")
			{
				Data._tasks = new TaskBasic7();
			}
			if (item._nameTask == "Странник" || item._nameTask == "Вечный Странник")
			{
				Data._tasks = new TaskBasic8();
			}
			if (item._nameTask == "Лагерь ЧН")
			{
				Data._tasks = new TaskAdditional1();
			}
			if (item._nameTask == "Лагерь ЧН на складах")
			{
				Data._tasks = new TaskAdditional1_5();
			}
			if (item._nameTask == "Отряд ЧН")
			{
				Data._tasks = new TaskAdditional2();
			}
			if (item._nameTask == "Огневая поддержка")
			{
				Data._tasks = new TaskAdditional3();
			}
			if (item._nameTask == "Награда ЧН")
			{
				Data._tasks = new TaskAdditional4();
			}
			if (item._nameTask == "Бывай, ЧН")
			{
				Data._tasks = new TaskAdditional5();
			}
			if (item._nameTask == "Достать артефакт")
			{
				Data._tasks = new TaskAdditionalEmptySubj1();
			}
			if (item._nameTask == "Принести Схемы Выжигателя")
			{
				Data._tasks = new TaskAdditionalEmptyMonolith();
			}
			if (item._nameTask == "Братство Монолита")
			{
				Data._tasks = new TaskAdditionalEmptyMonolith1();
			}
			if (item._nameTask == "Найти отряд разведчиков")
			{
				Data._tasks = new TaskAdditionalScoutReport();
			}
			if (item._nameTask == "Доставить отчет разведчиков")
			{
				Data._tasks = new TaskAdditionalScoutReport0_1();
			}
			if (item._nameTask == "Отчет разведчиков")
			{
				Data._tasks = new TaskAdditionalScoutReport0();
			}
			if (item._nameTask == "Найти динамит")
			{
				Data._tasks = new TaskAdditionalFindDinamit();
			}
			if (item._nameTask == "Динамит доставлен")
			{
				Data._tasks = new TaskAdditionalFindDinamit0();
			}
			if (item._nameTask == "Доставить партию оружия")
			{
				Data._tasks = new TaskAdditionalFindWeaponBox();
			}
			if (item._nameTask == "Братва вооружена")
			{
				Data._tasks = new TaskAdditionalFindWeaponBox0();
			}
			if (item._nameTask == "Доставить партию комбинезонов")
			{
				Data._tasks = new TaskAdditionalFindSuitBox();
			}
			if (item._nameTask == "Братва экипирована")
			{
				Data._tasks = new TaskAdditionalFindSuitBox0();
			}
			if (item._nameTask == "Принести Декодер")
			{
				Data._tasks = new TaskAdditionalDecoderMonolith();
			}
			if (item._nameTask == "Принести съедобные припасы")
			{
				Data._tasks = new TaskAdditionalArmFood();
			}
			if (item._nameTask == "Солдатский паек")
			{
				Data._tasks = new TaskAdditionalArmFood0();
			}
			if (item._nameTask == "Спасти новичка")
			{
				Data._tasks = new TaskAdditionalSaveNovice();
			}
			if (item._nameTask == "Баламут")
			{
				Data._tasks = new TaskAdditionalSaveNovice1();
			}
			if (item._nameTask == "Найти кольт")
			{
				Data._tasks = new TaskAdditionalColt();
			}
			if (item._nameTask == "Антирад на барьер")
			{
				Data._tasks = new TaskAdditionalColt1();
			}
			if (item._nameTask == "Кольт")
			{
				Data._tasks = new TaskAdditionalColt2();
			}
			if (item._nameTask == "Найти Следопыта")
			{
				Data._tasks = new TaskAdditionalquestPathfinder0();
			}
			if (item._nameTask == "Убить Следопыта")
			{
				Data._tasks = new TaskAdditionalquestPathfinder1();
			}
			if (item._nameTask == "Найти препарат: ПСИ-блокада")
			{
				Data._tasks = new TaskAdditionalquestPathfinder2();
			}
			if (item._nameTask == "Доставить Следопыту ПСИ-блокаду")
			{
				Data._tasks = new TaskAdditionalquestPathfinder3();
			}
			if (item._nameTask == "Добраться до аномальной трясины")
			{
				Data._tasks = new TaskAdditionalquestPathfinder4();
			}
			if (item._nameTask == "Разведать планы военных")
			{
				Data._tasks = new TaskAdditionalOperationPlan();
			}
			if (item._nameTask == "Найти капитана Ширко")
			{
				Data._tasks = new TaskAdditionalOperationPlan1();
			}
			if (item._nameTask == "Доставить план военных Одиночкам")
			{
				Data._tasks = new TaskAdditionalOperationPlan2();
			}
			if (item._nameTask == "Найти награбленный хабар")
			{
				Data._tasks = new TaskAdditionalReturnBearMod();
			}
			if (item._nameTask == "Найти Копченого")
			{
				Data._tasks = new TaskAdditionalReturnBearMod0();
			}
			if (item._nameTask == "Тайник Хмурого и Копченого")
			{
				Data._tasks = new TaskAdditionalReturnBearMod1();
			}
			if (item._nameTask == "Возвращение хабара сталкеров")
			{
				Data._tasks = new TaskAdditionalReturnBearMod2();
			}
			if (item._nameTask == "Разведка на насосной станции")
			{
				Data._tasks = new TaskAdditionalDutyKillBloodsuсker();
			}
			if (item._nameTask == "Исследовать насосную станцию")
			{
				Data._tasks = new TaskAdditionalDutyKillBloodsuсker1();
			}
			if (item._nameTask == "Убить кровососа")
			{
				Data._tasks = new TaskAdditionalDutyKillBloodsuсker2();
			}
			if (item._nameTask == "Кровосос убит")
			{
				Data._tasks = new TaskAdditionalDutyKillBloodsuсker3();
			}
			if (item._nameTask == "Найти детали")
			{
				Data._tasks = new TaskAdditionalSpareParts();
			}
			if (item._nameTask == "''Разговор'' о деталях")
			{
				Data._tasks = new TaskAdditionalSpareParts01();
			}
			if (item._nameTask == "Детали у заказчика")
			{
				Data._tasks = new TaskAdditionalSpareParts0();
			}
			if (item._nameTask == "Схемы для наемников")
			{
				Data._tasks = new TaskAdditionalMercenarySchemeOfBurner0();
			}
			if (item._nameTask == "Вернуть детектор")
			{
				Data._tasks = new TaskAdditionalMercenaryLifeDetector();
			}
			if (item._nameTask == "Пропавший отряд")
			{
				Data._tasks = new TaskAdditionalMercenaryGroup();
			}
			if (item._nameTask == "Пространственная аномалия")
			{
				Data._tasks = new TaskAdditionalMercenaryGroup0();
			}
			if (item._nameTask == "Сканер-расщепитель")
			{
				Data._tasks = new TaskAdditionalMercenaryGroup1();
			}
			if (item._nameTask == "Начало эксперимента")
			{
				Data._tasks = new TaskAdditionalMercenaryGroup2();
			}
			if (item._nameTask == "Помощь наемникам")
			{
				Data._tasks = new TaskAdditionalMercenaryGroup3();
			}
			if (item._nameTask == "Отряд наемников найден")
			{
				Data._tasks = new TaskAdditionalMercenaryGroup4();
			}
			if (item._nameTask == "Достать оружие")
			{
				Data._tasks = new TaskAdditionalEmptyWeapon1();
			}
			if (item._nameTask == "Достать комбинезон")
			{
				Data._tasks = new TaskAdditionalEmptySuit1();
			}
			if (item._nameTask == "Принести часть тела мутанта")
			{
				Data._tasks = new TaskAdditionalEmptyMutantPart();
			}
			if (item._nameTask == "Добыть схемы оружия")
			{
				Data._tasks = new TaskAdditionalSchemesOfExperimentalWeapons();
			}
			if (item._nameTask == "Схемы переданы")
			{
				Data._tasks = new TaskAdditionalSchemesOfExperimentalWeapons1();
			}
			if (item._nameTask == "Захватить точку")
			{
				Data._tasks = new TaskAdditionalCapturePoint0();
			}
			if (item._nameTask == "Захватить враждебную точку")
			{
				Data._tasks = new TaskAdditionalCaptureEnemyPoint0();
			}
			if (item._nameTask == "Ликвидатор")
			{
				Data._tasks = new TaskAdditionalKiller1();
			}
			if (item._nameTask == "Провал ликвидации")
			{
				Data._tasks = new TaskAdditionalKillerFail();
			}
			if (item._nameTask == "Потерянная цель" || item._nameTask == "Потеряная цель")
			{
				Data._tasks = new TaskAdditionalKillerFail0();
			}
			if (item._nameTask == "Объект уничтожен")
			{
				Data._tasks = new TaskAdditionalKiller2();
			}
			if (item._nameTask == "Ликвидатор. Награда")
			{
				Data._tasks = new TaskAdditionalKiller3();
			}
			if (item._nameTask == "Проводник")
			{
				Data._tasks = new TaskAdditionalGuide1();
			}
			if (item._nameTask == "Заказчик на месте")
			{
				Data._tasks = new TaskAdditionalGuide2();
			}
			if (item._nameTask == "Награда проводника")
			{
				Data._tasks = new TaskAdditionalGuide2_5();
			}
			if (item._nameTask == "Заказчик погиб")
			{
				Data._tasks = new TaskAdditionalGuideFail();
			}
			if (item._nameTask == "Помощь группировке")
			{
				Data._tasks = new TaskAdditionalBalans0();
			}
			if (item._nameTask == "Награда за поддержку")
			{
				Data._tasks = new TaskAdditionalBalans1();
			}
			if (item._nameTask == "Провал задания группировки")
			{
				Data._tasks = new TaskAdditionalBalansFail();
			}
			if (item._nameTask == "Не оказанная помощь...")
			{
				Data._tasks = new TaskAdditionalBalansFail0();
			}
			if (item._nameTask == "Найти утерянный прибор")
			{
				Data._tasks = new TaskGlobalchemist0();
			}
			if (item._nameTask == "Информация в Баре")
			{
				Data._tasks = new TaskGlobalchemist2();
			}
			if (item._nameTask == "Наемники")
			{
				Data._tasks = new TaskGlobalchemist3();
			}
			if (item._nameTask == "К Радару")
			{
				Data._tasks = new TaskGlobalchemist4();
			}
			if (item._nameTask == "Снова наемники")
			{
				Data._tasks = new TaskGlobalchemist6();
			}
			if (item._nameTask == "ПДА отряда наемников")
			{
				Data._tasks = new TaskGlobalchemist7();
			}
			if (item._nameTask == "Обмен и возвращение прототипа")
			{
				Data._tasks = new TaskGlobalchemist8();
			}
			if (item._nameTask == "Вернуть ПДА")
			{
				Data._tasks = new TaskGlobalchemist8_5();
			}
			if (item._nameTask == "Обмен")
			{
				Data._tasks = new TaskGlobalchemist8_7();
			}
			if (item._nameTask == "Возвращение прототипа")
			{
				Data._tasks = new TaskGlobalchemist9();
			}
			if (item._nameTask == "ПСИ-шлем на базе")
			{
				Data._tasks = new TaskGlobalchemist10();
			}
			if (item._nameTask == "Личное время" || item._nameTask == "Путь на Болота")
			{
				Data._tasks = new TaskGlobalchemist11();
			}
			if (item._nameTask == "Выбить Ренегатов с болот")
			{
				Data._tasks = new TaskGlobalchemist12();
			}
			if (item._nameTask == "В поисках Хищника")
			{
				Data._tasks = new TaskGlobalchemist13();
			}
			if (item._nameTask == "Артефакт для Хищника")
			{
				Data._tasks = new TaskGlobalchemist14();
			}
			if (item._nameTask == "Путь на Скадовск")
			{
				Data._tasks = new TaskGlobalchemist15();
			}
			if (item._nameTask == "Найти Фокса")
			{
				Data._tasks = new TaskGlobalchemist15_5();
			}
			if (item._nameTask == "Барыга Фокс")
			{
				Data._tasks = new TaskGlobalchemist16();
			}
			if (item._nameTask == "Испытательный цех")
			{
				Data._tasks = new TaskGlobalchemist17();
			}
			if (item._nameTask == "Схемы оружия")
			{
				Data._tasks = new TaskGlobalchemist18();
			}
			if (item._nameTask == "Засада")
			{
				Data._tasks = new TaskGlobalchemist18_5();
			}
			if (item._nameTask == "Принять бой")
			{
				Data._tasks = new TaskGlobalchemist18_6();
			}
			if (item._nameTask == "Противник уничтожен")
			{
				Data._tasks = new TaskGlobalchemist18_7();
			}
			if (item._nameTask == "Бывай, Хищник")
			{
				Data._tasks = new TaskGlobalchemist18_8();
			}
			if (item._nameTask == "Временная передышка")
			{
				Data._tasks = new TaskGlobalchemist19();
			}
			if (item._nameTask == "Найти информацию об экспериментах")
			{
				Data._tasks = new TaskAdditionalВocumentation();
			}
			Data._tasks.MapName = item._mapName;
			Data._tasks.NamePointTask = item._namePointTask;
			Data._tasks.QuestSubject.NameSubject = item._questSubjectName;
			Data._tasks.KillCharacterName = item._killCharacterName;
			Data._tasks.NumberTurgetInData = item._numberTurgetInData;
			Data._tasks.NumberPointOfGuide = item._numberPointOfGuide;
			Data._tasks.NumberEnemy = item._numberEnemy;
			Data._tasks.GroupName = item._groupName;
			Data._tasks.NumberDealer = item._numberDealer;
			if (Data._tasks.NumberDealer == 1)
			{
				Data._tasks.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconStalkerSuit128");
			}
			if (Data._tasks.NumberDealer == 2)
			{
				Data._tasks.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharCloak128");
			}
			if (Data._tasks.NumberDealer == 3)
			{
				Data._tasks.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharBerill128");
			}
			if (Data._tasks.NumberDealer == 4)
			{
				Data._tasks.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharPC596_128");
			}
			if (Data._tasks.NumberDealer == 5)
			{
				Data._tasks.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharMersenary128");
			}
			if (Data._tasks.NumberDealer == 6)
			{
				Data._tasks.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharWindFreedom128");
			}
			if (Data._tasks.NumberDealer == 7)
			{
				Data._tasks.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharChN_1_128");
			}
			if (Data._tasks.NumberDealer == 8)
			{
				Data._tasks.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharMonolit128");
			}
			if (Data._tasks.NumberDealer == 9)
			{
				Data._tasks.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharSweater128");
			}
			if (Data._tasks.NumberDealer == 10)
			{
				Data._tasks.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharSweater128");
			}
			if (Data._tasks.NumberDealer == 11)
			{
				Data._tasks.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/saharov128");
			}
			if (Data._tasks.NumberDealer == 12)
			{
				Data._tasks.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharJacket128");
			}
			Data.TaskAll.Add(Data._tasks);
		}
		foreach (string item2 in saveOneMap.staS.ListOldTask)
		{
			Data.OldTask.Add(item2);
		}
		foreach (CharacterAndPoint charactersAndPiont in saveOneMap.charactersAndPionts)
		{
			if (!(charactersAndPiont._curMap == SceneManager.GetActiveScene().name))
			{
				continue;
			}
			if (charactersAndPiont._nameCharac != string.Empty)
			{
				if (charactersAndPiont._nameCharac == "Странник")
				{
					Data._character = new AAAAAAAAAAAAAAAAAAAAAAs();
				}
				if (charactersAndPiont._nameCharac == "Плоть")
				{
					Data._character = new AAAAAAAAAAAAAAAAAAAAr();
				}
				if (charactersAndPiont._nameCharac == "Кабан")
				{
					Data._character = new AAAAAAAAAAAAAAAAAAAAs();
				}
				if (charactersAndPiont._nameCharac == "Слепой пес")
				{
					Data._character = new AAAAAAAAAAAAAAAAAAAAt();
				}
				if (charactersAndPiont._nameCharac == "Псевдособака")
				{
					Data._character = new AAAAAAAAAAAAAAAAAt();
				}
				if (charactersAndPiont._nameCharac == "Кровосос")
				{
					Data._character = new AAAAAAAAAAAAAAAAAAba();
				}
				if (charactersAndPiont._nameCharac == "Контролер")
				{
					Data._character = new AAAAAAAAAAAAAAAAAAbb();
				}
				if (charactersAndPiont._nameCharac == "Нетралы" || charactersAndPiont._nameCharac == "Одиночки")
				{
					Data._character = new AAAAAAAAAAAAAAAAAs();
				}
				if (charactersAndPiont._nameCharac == "Бандиты")
				{
					Data._character = new AAAAAAAAAAAAAAAAAAAz();
				}
				if (charactersAndPiont._nameCharac == "Военные")
				{
					Data._character = new AAAAAAAAAAAAAAAAAAAAq();
				}
				if (charactersAndPiont._nameCharac == "Долг")
				{
					Data._character = new AAAAAAAAAAAAAAAi();
				}
				if (charactersAndPiont._nameCharac == "Чистое небо" || charactersAndPiont._nameCharac == "Чистое_небо")
				{
					Data._character = new AAAAAAAAAAAAAAAAAAAAAx();
				}
				if (charactersAndPiont._nameCharac == "Наемники")
				{
					Data._character = new AAAAAAAAAAAAAAAAAAAAAAu();
				}
				if (charactersAndPiont._nameCharac == "Свобода")
				{
					Data._character = new AAAAAAAAAAAAAAAAAAAAAw();
				}
				if (charactersAndPiont._nameCharac == "Зомби")
				{
					Data._character = new AAAAAAAAAAAAAAAAAAAAAAv();
				}
				if (charactersAndPiont._nameCharac == "Снорк")
				{
					Data._character = new AAAAAAAAAAAAAAAAAAj();
				}
				if (charactersAndPiont._nameCharac == "Монолит")
				{
					Data._character = new AAAAAAAAAAAAAAAj();
				}
				if (charactersAndPiont._nameCharac == "Ученые")
				{
					Data._character = new AAAAAAAAAAAAAAAAAAi();
				}
				if (charactersAndPiont._nameCharac == "Ренегаты")
				{
					Data._character = new AAAAAAAAAAAAAAAAAAAAAy();
				}
				Data._character.ControlGamer = charactersAndPiont._controlGamer;
				if (charactersAndPiont._suitCharName != string.Empty)
				{
					Data._character.SuitChar.NameSubject = charactersAndPiont._suitCharName;
					Data._character.SuitChar.State = charactersAndPiont._suitCharState;
					Data._character.SuitChar.ArtContainer = charactersAndPiont._suitCharContainer;
					Data._character.SuitChar.WeightUpGrade = charactersAndPiont.WeightUpGrade;
					Data._character.SuitChar.UpGrade = charactersAndPiont.UpGrade;
					Data._character.SuitChar.SingModification = charactersAndPiont.SingUG_suit;
				}
				if (charactersAndPiont._weaponCharName != string.Empty)
				{
					Data._character.WeaponChar.NameSubject = charactersAndPiont._weaponCharName;
					Data._character.WeaponChar.State = charactersAndPiont._weaponCharState;
					Data._character.WeaponChar.SightInstallation = charactersAndPiont._weaponCharSightInstallation;
					Data._character.WeaponChar.WeightUpGrade = charactersAndPiont.WeightUpGradeWeapon;
					Data._character.WeaponChar.UpGrade = charactersAndPiont.WeaponUpGrade;
					Data._character.WeaponChar.SingModification = charactersAndPiont.SingUG_weapon;
					Data._character.WeaponChar.Cartridge = charactersAndPiont.CartridgeInt;
				}
				for (int m = 0; m < 4; m++)
				{
					Data._character.ArtContainers[m].NameSubject = charactersAndPiont._ArtContainer[m];
				}
				if (Data._character.DetectorChar != null && charactersAndPiont._detectorCharName != string.Empty)
				{
					Data._character.DetectorChar.NameSubject = charactersAndPiont._detectorCharName;
				}
				if (charactersAndPiont._CharBackpack.Length == 10)
				{
					for (int n = 0; n < 10; n++)
					{
						if (charactersAndPiont._CharBackpack[n] == null)
						{
							charactersAndPiont._CharBackpack[n] = string.Empty;
						}
						if (charactersAndPiont._CharBackpack[n] != string.Empty)
						{
							Data._character.CharBackpack[n].NameSubject = charactersAndPiont._CharBackpack[n];
							Data._character.CharBackpack[n].State = charactersAndPiont._StateCharBackpack[n];
							Data._character.CharBackpack[n].Stack = charactersAndPiont._StackCharBackpack[n];
							if (Data._character.CharBackpack[n].Stack == 0)
							{
								Data._character.CharBackpack[n].Stack = 1;
							}
							Data._character.CharBackpack[n].SightInstallation = charactersAndPiont._StackCharBackpackWSI[n];
							Data._character.CharBackpack[n].ArtContainer = charactersAndPiont._StackCharBackpackContainer[n];
							Data._character.CharBackpack[n].WeightUpGrade = charactersAndPiont._StackCharWeightUpGrade[n];
							Data._character.CharBackpack[n].UpGrade = charactersAndPiont._StackCharUpGrade[n];
							Data._character.CharBackpack[n].SingModification = charactersAndPiont._SingUG[n];
							Data._character.CharBackpack[n].Cartridge = charactersAndPiont._StackCartridge[n];
						}
					}
				}
				if (charactersAndPiont._CharBackpack.Length == 20)
				{
					for (int num = 0; num < 20; num++)
					{
						if (charactersAndPiont._CharBackpack[num] == null)
						{
							charactersAndPiont._CharBackpack[num] = string.Empty;
						}
						if (charactersAndPiont._CharBackpack[num] != string.Empty)
						{
							Data._character.CharBackpack[num].NameSubject = charactersAndPiont._CharBackpack[num];
							Data._character.CharBackpack[num].State = charactersAndPiont._StateCharBackpack[num];
							Data._character.CharBackpack[num].Stack = charactersAndPiont._StackCharBackpack[num];
							if (Data._character.CharBackpack[num].Stack == 0)
							{
								Data._character.CharBackpack[num].Stack = 1;
							}
							Data._character.CharBackpack[num].SightInstallation = charactersAndPiont._StackCharBackpackWSI[num];
							Data._character.CharBackpack[num].ArtContainer = charactersAndPiont._StackCharBackpackContainer[num];
							Data._character.CharBackpack[num].WeightUpGrade = charactersAndPiont._StackCharWeightUpGrade[num];
							Data._character.CharBackpack[num].UpGrade = charactersAndPiont._StackCharUpGrade[num];
							Data._character.CharBackpack[num].SingModification = charactersAndPiont._SingUG[num];
							Data._character.CharBackpack[num].Cartridge = charactersAndPiont._StackCartridge[num];
						}
					}
				}
				Data._character.CurHealth = charactersAndPiont._curHealth;
				if (charactersAndPiont._life)
				{
					Data._character.CharUnits.transform.GetChild(0).transform.localPosition = new Vector3((Data._character.CurHealth / 100f - 0.5f) / 2f, 0.5f);
					Data._character.CharUnits.transform.GetChild(0).transform.localScale = new Vector3(Data._character.CurHealth / 100f, 0.3f);
				}
				else
				{
					Data._character.CurHealth = 0f;
					Data._character.CharUnits.transform.GetChild(0).transform.localScale = new Vector3(0f, 0.3f);
				}
				if (Data._character.Skill < charactersAndPiont._skill)
				{
					Data._character.Skill = charactersAndPiont._skill;
				}
				for (int num2 = 0; num2 < Gexa.GexLib.Count; num2++)
				{
					if (Gexa.GexLib[num2].NameGex == charactersAndPiont._curGexCharName)
					{
						Data._character.CurGexChar = Gexa.GexLib[num2];
						Data._character.TaskGexChar = Gexa.GexLib[num2];
					}
				}
				Data._character.NameU = charactersAndPiont._nameU;
				Data._character.CharUnits.name = charactersAndPiont._nameU;
				if (Data._character.NameU == "Слепой пес, бледный")
				{
					Data._character.NameU = "Слепой пес, бледный, " + NameCharacter.NameMutantLib[UnityEngine.Random.Range(0, NameCharacter.NameMutantLib.Length - 1)];
					Data._character.CharUnits.name = Data._character.NameU;
				}
				if (charactersAndPiont._nameCharac == "Странник")
				{
					Data._character.TypeChInt = charactersAndPiont._typeCharInt;
				}
				Data._character.CharUnits.transform.position = Data._character.CurGexChar.GexGO.transform.position;
				Data._character.Bonus = charactersAndPiont._bonus;
				Data._character.Bleeding = charactersAndPiont._bleeding;
				Data._character.DiseaseXRay = charactersAndPiont._diseaseXRay;
				Data._character.Cash = charactersAndPiont._cash;
				Data._character.Life = charactersAndPiont._life;
				Data._character.AgeOfDeath = charactersAndPiont._ageOfDeath;
				Data._character.Satiety = charactersAndPiont._satietyCh;
				Data._character.Thirst = charactersAndPiont._thirst;
				if (!charactersAndPiont._controlGamer)
				{
					Data._character.Satiety = 50;
					Data._character.Thirst = 50;
				}
				Data._character.PSIprotection = charactersAndPiont.PSIprotection;
				Data.CharacterD.Add(Data._character);
				AAAAAAAAAAAAAAAAAAAAcs();
			}
			if (!(charactersAndPiont._nameCharac == string.Empty))
			{
				continue;
			}
			if (charactersAndPiont._nameU == "Лесопилка")
			{
				Data.point = new Sawmill();
			}
			if (charactersAndPiont._nameU == "Тлеющий хутор")
			{
				Data.point = new SmolderingFarm();
			}
			if (charactersAndPiont._nameU == "Аномалия ''Котел''")
			{
				Data.point = new AnomalyBoiler();
			}
			if (charactersAndPiont._nameU == "Скадовск")
			{
				Data.point = new Skadovsk();
			}
			if (charactersAndPiont._nameU == "Земснаряд")
			{
				Data.point = new Dredger();
			}
			if (charactersAndPiont._nameU == "Топь")
			{
				Data.point = new Slough();
			}
			if (charactersAndPiont._nameU == "Изумрудное")
			{
				Data.point = new Emerald();
			}
			if (charactersAndPiont._nameU == "Шевченко")
			{
				Data.point = new Shevchenko();
			}
			if (charactersAndPiont._nameU == "Портовые краны")
			{
				Data.point = new PortCranes();
			}
			if (charactersAndPiont._nameU == "Лесничество")
			{
				Data.point = new Forestry();
			}
			if (charactersAndPiont._nameU == "ВНЗ «Круг»")
			{
				Data.point = new VNZcircle();
			}
			if (charactersAndPiont._nameU == "Железный лес")
			{
				Data.point = new Ironwood();
			}
			if (charactersAndPiont._nameU == "Испытательный цех")
			{
				Data.point = new TestShop();
			}
			if (charactersAndPiont._nameU == "Заправка")
			{
				Data.point = new Refueling();
			}
			if (charactersAndPiont._nameU == "Соснодуб")
			{
				Data.point = new Sosnodub();
			}
			if (charactersAndPiont._nameU == "Аномалия ''Цирк''")
			{
				Data.point = new AnomalyCircus();
			}
			if (charactersAndPiont._nameU == "Станция переработки отходов")
			{
				Data.point = new WasteProcessingPlant();
			}
			if (charactersAndPiont._nameU == "Мост им. Преображенского")
			{
				Data.point = new BridgePreobrazhensky();
			}
			if (charactersAndPiont._nameU == "Форпост")
			{
				Data.point = new Outpost();
			}
			if (charactersAndPiont._nameU == "Товарный состав")
			{
				Data.point = new CommodityComposition();
			}
			if (charactersAndPiont._nameU == "Тоннель ''Тузла''")
			{
				Data.point = new TunnelTuzla();
			}
			if (charactersAndPiont._nameU == "Лодочная станция")
			{
				Data.point = new BoatStation();
			}
			if (charactersAndPiont._nameU == "Южный хутор")
			{
				Data.point = new SouthFarm();
			}
			if (charactersAndPiont._nameU == "Северный хутор")
			{
				Data.point = new NorthFarm();
			}
			if (charactersAndPiont._nameU == "Механизаторский двор")
			{
				Data.point = new MechanizationYard();
			}
			if (charactersAndPiont._nameU == "Руины деревни")
			{
				Data.point = new RuinsOfTheVillage();
			}
			if (charactersAndPiont._nameU == "Болотный трамплин")
			{
				Data.point = new MarshTrampoline();
			}
			if (charactersAndPiont._nameU == "Кислотная аномалия")
			{
				Data.point = new AcidAnomaly();
			}
			if (charactersAndPiont._nameU == "Сгоревший хутор")
			{
				Data.point = new BurntFarm();
			}
			if (charactersAndPiont._nameU == "Старая церковь")
			{
				Data.point = new OldChurch();
			}
			if (charactersAndPiont._nameU == "Смотровая вышка")
			{
				Data.point = new Sighthole();
			}
			if (charactersAndPiont._nameU == "Рыбацкий хутор")
			{
				Data.point = new FishermansFarm();
			}
			if (charactersAndPiont._nameU == "База Чистого Неба")
			{
				Data.point = new BaseClearSky();
			}
			if (charactersAndPiont._nameU == "Насосная Станция")
			{
				Data.point = new PumpingStationMarsh();
			}
			if (charactersAndPiont._nameU == "Разлом")
			{
				Data.point = new FaultAnomaly();
			}
			if (charactersAndPiont._nameU == "АТП")
			{
				Data.point = new ATP();
			}
			if (charactersAndPiont._nameU == "Элеватор")
			{
				Data.point = new Elevator();
			}
			if (charactersAndPiont._nameU == "Деревня новичков")
			{
				Data.point = new BaseNovice();
			}
			if (charactersAndPiont._nameU == "Болото радиоактивных отходов")
			{
				Data.point = new XRaySwamp();
			}
			if (charactersAndPiont._nameU == "Перевернутый тепловоз")
			{
				Data.point = new Locomotive();
			}
			if (charactersAndPiont._nameU == "Разбитый грузовик")
			{
				Data.point = new TruckBroken();
			}
			if (charactersAndPiont._nameU == "Военная база")
			{
				Data.point = new ArmBase();
			}
			if (charactersAndPiont._nameU == "Перевернутый УАЗик")
			{
				Data.point = new UAZBroken();
			}
			if (charactersAndPiont._nameU == "Логово мутантов на кордоне")
			{
				Data.point = new MutantBaseKordon();
			}
			if (charactersAndPiont._nameU == "Дорога на свалку")
			{
				Data.point = new DumpRoad();
			}
			if (charactersAndPiont._nameU == "Блок-пост приемник")
			{
				Data.point = new BlockPost();
			}
			if (charactersAndPiont._nameU == "Стоянка брошенной техники")
			{
				Data.point = new AbandonedMachinery();
			}
			if (charactersAndPiont._nameU == "Аномальная трясина")
			{
				Data.point = new AnomalySwamp();
			}
			if (charactersAndPiont._nameU == "Дорога на болото")
			{
				Data.point = new SwampRoad();
			}
			if (charactersAndPiont._nameU == "Ангар")
			{
				Data.point = new Hangar();
			}
			if (charactersAndPiont._nameU == "Дорога на НИИ Агропром")
			{
				Data.point = new AgropromRoad();
			}
			if (charactersAndPiont._nameU == "Бетонные плиты")
			{
				Data.point = new ConcretePlates();
			}
			if (charactersAndPiont._nameU == "Привал диггеров")
			{
				Data.point = new HaltDiggers();
			}
			if (charactersAndPiont._nameU == "Барьер")
			{
				Data.point = new Barrier();
			}
			if (charactersAndPiont._nameU == "Дорога в темную долину")
			{
				Data.point = new DarkValleyRoad();
			}
			if (charactersAndPiont._nameU == "Брошенный экскаватор")
			{
				Data.point = new ExcavatorBroken();
			}
			if (charactersAndPiont._nameU == "Логово мутантов на свалке")
			{
				Data.point = new MutantBaseDump();
			}
			if (charactersAndPiont._nameU == "Автобусная остановка")
			{
				Data.point = new BusStation();
			}
			if (charactersAndPiont._nameU == "Завод Агропром")
			{
				Data.point = new FactoryAgroprom();
			}
			if (charactersAndPiont._nameU == "Лагерь на болоте")
			{
				Data.point = new CampOnSwamp();
			}
			if (charactersAndPiont._nameU == "Институт Агропром")
			{
				Data.point = new InstituteAgroprom();
			}
			if (charactersAndPiont._nameU == "Болотная тропа")
			{
				Data.point = new WadingTrail();
			}
			if (charactersAndPiont._nameU == "Пещера с аномалиями")
			{
				Data.point = new AnomalyCave();
			}
			if (charactersAndPiont._nameU == "Вентиляционная шахта")
			{
				Data.point = new AirShaft();
			}
			if (charactersAndPiont._nameU == "Логово мутантов на Агропроме")
			{
				Data.point = new MutantAgroprom();
			}
			if (charactersAndPiont._nameU == "Бронетранспортер")
			{
				Data.point = new BTR();
			}
			if (charactersAndPiont._nameU == "Лежка кровососов")
			{
				Data.point = new CampBloodsucker();
			}
			if (charactersAndPiont._nameU == "Бродячие зомби")
			{
				Data.point = new ZombyStation();
			}
			if (charactersAndPiont._nameU == "Переход на янтарь")
			{
				Data.point = new RoadAmber();
			}
			if (charactersAndPiont._nameU == "Дальний блокпост")
			{
				Data.point = new FarBlockpost();
			}
			if (charactersAndPiont._nameU == "Лежка мутантов")
			{
				Data.point = new MutantDarkValley();
			}
			if (charactersAndPiont._nameU == "Ферма")
			{
				Data.point = new FarmDarkValley();
			}
			if (charactersAndPiont._nameU == "АЗС")
			{
				Data.point = new AZS();
			}
			if (charactersAndPiont._nameU == "Аномалия темной долины")
			{
				Data.point = new AnomalyDarkValley();
			}
			if (charactersAndPiont._nameU == "Старый завод")
			{
				Data.point = new OldFactory();
			}
			if (charactersAndPiont._nameU == "Тропинка зомби")
			{
				Data.point = new ZombyTrail();
			}
			if (charactersAndPiont._nameU == "Цеха старой фабрики")
			{
				Data.point = new FactoryShops();
			}
			if (charactersAndPiont._nameU == "Груда камней")
			{
				Data.point = new Stones();
			}
			if (charactersAndPiont._nameU == "Блокпост у фермы")
			{
				Data.point = new BlockpostFarm();
			}
			if (charactersAndPiont._nameU == "Лесная тропа")
			{
				Data.point = new ForestTrail();
			}
			if (charactersAndPiont._nameU == "Собачья тропа")
			{
				Data.point = new DogsTrail();
			}
			if (charactersAndPiont._nameU == "Блокпост Юго-восток")
			{
				Data.point = new BlockpostSouthEast();
			}
			if (charactersAndPiont._nameU == "Насосная станция")
			{
				Data.point = new PumpingStation();
			}
			if (charactersAndPiont._nameU == "База Долга")
			{
				Data.point = new BaseDuty();
			}
			if (charactersAndPiont._nameU == "Блокпост Северо-запад")
			{
				Data.point = new BlockpostNorthWest();
			}
			if (charactersAndPiont._nameU == "Дорога на военные склады")
			{
				Data.point = new RoadMilitary();
			}
			if (charactersAndPiont._nameU == "Старая дорога")
			{
				Data.point = new OldRoad();
			}
			if (charactersAndPiont._nameU == "Привал нейтралов" || charactersAndPiont._nameU == "Привал нейтралов")
			{
				Data.point = new HaltNetrals();
			}
			if (charactersAndPiont._nameU == "Нора мутантов")
			{
				Data.point = new HoleMutants();
			}
			if (charactersAndPiont._nameU == "Аномалия Кольцо")
			{
				Data.point = new AnomalyRing();
			}
			if (charactersAndPiont._nameU == "Разбитая дорога")
			{
				Data.point = new BrokenRoad();
			}
			if (charactersAndPiont._nameU == "Путь на Янтарь")
			{
				Data.point = new PathToAmber();
			}
			if (charactersAndPiont._nameU == "Путь на военные склады")
			{
				Data.point = new PathToStorage();
			}
			if (charactersAndPiont._nameU == "Горком КПСС")
			{
				Data.point = new GorkomKPSS();
			}
			if (charactersAndPiont._nameU == "Мертвый хутор")
			{
				Data.point = new DeadFarmstead();
			}
			if (charactersAndPiont._nameU == "Квартал зомби")
			{
				Data.point = new ZombiePark();
			}
			if (charactersAndPiont._nameU == "Березовая роща")
			{
				Data.point = new BirchGrove();
			}
			if (charactersAndPiont._nameU == "Магазин промтовары")
			{
				Data.point = new ShopPromtovari();
			}
			if (charactersAndPiont._nameU == "Аномалия Пустыня")
			{
				Data.point = new AnomalyDesert();
			}
			if (charactersAndPiont._nameU == "Родник")
			{
				Data.point = new Spring();
			}
			if (charactersAndPiont._nameU == "Переход к черной тропе")
			{
				Data.point = new MoveToTheBlackTrail();
			}
			if (charactersAndPiont._nameU == "Хижина сумашедшего сталкера" || charactersAndPiont._nameU == "Хижина сумасшедшего сталкера")
			{
				Data.point = new MadStalker();
			}
			if (charactersAndPiont._nameU == "Штаб военной базы")
			{
				Data.point = new HeadquartersBase();
			}
			if (charactersAndPiont._nameU == "Барьер монолита")
			{
				Data.point = new BarrierMonolith();
			}
			if (charactersAndPiont._nameU == "Упавший вертолет")
			{
				Data.point = new FallenHelicopter();
			}
			if (charactersAndPiont._nameU == "Тропа в рыжий лес")
			{
				Data.point = new TrailRedForest();
			}
			if (charactersAndPiont._nameU == "Блокпост наемников")
			{
				Data.point = new BlockpostMercenary();
			}
			if (charactersAndPiont._nameU == "Тихий хутор")
			{
				Data.point = new QuietCountryside();
			}
			if (charactersAndPiont._nameU == "Дорога между холмами")
			{
				Data.point = new RoadBetweenHills();
			}
			if (charactersAndPiont._nameU == "Привал на плитах")
			{
				Data.point = new HaltOnPlates();
			}
			if (charactersAndPiont._nameU == "Перекресток")
			{
				Data.point = new IntersectionRoad();
			}
			if (charactersAndPiont._nameU == "Водонапорная башня")
			{
				Data.point = new WaterTower();
			}
			if (charactersAndPiont._nameU == "Укрепточка нетралов")
			{
				Data.point = new PointNetrals();
			}
			if (charactersAndPiont._nameU == "Тайная тропа в мертвый город")
			{
				Data.point = new TrailToDeadCity();
			}
			if (charactersAndPiont._nameU == "Дорога через дикую территорию")
			{
				Data.point = new RoadFromWildTerritory();
			}
			if (charactersAndPiont._nameU == "Путь к дикой территории")
			{
				Data.point = new WildTerritory();
			}
			if (charactersAndPiont._nameU == "Бункер ученых")
			{
				Data.point = new BunkerOfScientists();
			}
			if (charactersAndPiont._nameU == "Переход к НИИ Агропром")
			{
				Data.point = new FromAmberToAgroprom();
			}
			if (charactersAndPiont._nameU == "Заводской КПП")
			{
				Data.point = new KPPAmber();
			}
			if (charactersAndPiont._nameU == "Островок на высохшем озере")
			{
				Data.point = new IsletOnLake();
			}
			if (charactersAndPiont._nameU == "Проводник к военным складам")
			{
				Data.point = new guideToMilitary();
			}
			if (charactersAndPiont._nameU == "Проводник к Янтарю")
			{
				Data.point = new GuideToAmber();
			}
			if (charactersAndPiont._nameU == "Завод Янтарь" || charactersAndPiont._nameU == "Завод ''Янтарь''")
			{
				Data.point = new FactoryAmber();
			}
			if (charactersAndPiont._nameU == "Тунель с аномалиями")
			{
				Data.point = new TunnelAnomaly();
			}
			if (charactersAndPiont._nameU == "Дальний рубеж")
			{
				Data.point = new FarFronter();
			}
			if (charactersAndPiont._nameU == "Укрытие в лесу")
			{
				Data.point = new TailInForest();
			}
			if (charactersAndPiont._nameU == "Южный блокпост радара")
			{
				Data.point = new SouthBlockpostRadar();
			}
			if (charactersAndPiont._nameU == "Аномалии")
			{
				Data.point = new AnomalyRadar();
			}
			if (charactersAndPiont._nameU == "Вход в подземный бункер")
			{
				Data.point = new SubBunker();
			}
			if (charactersAndPiont._nameU == "База выжигателя")
			{
				Data.point = new BaseRadar();
			}
			if (charactersAndPiont._nameU == "Мертвый овраг")
			{
				Data.point = new Ravine();
			}
			if (charactersAndPiont._nameU == "Разрушенный НИИ")
			{
				Data.point = new DestroyedInstitut();
			}
			if (charactersAndPiont._nameU == "Сбитый вертолет")
			{
				Data.point = new DestroyedHelicopter();
			}
			if (charactersAndPiont._nameU == "Стоянка на камнях")
			{
				Data.point = new StonesRadar();
			}
			if (charactersAndPiont._nameU == "Лесной привал")
			{
				Data.point = new ForestRadar();
			}
			if (charactersAndPiont._nameU == "Мертвый лес")
			{
				Data.point = new DeadFofest();
			}
			if (charactersAndPiont._nameU == "Старый капер" || charactersAndPiont._nameU == "Шахтный копер")
			{
				Data.point = new OldCaper();
			}
			if (charactersAndPiont._nameU == "Казармы в шахте")
			{
				Data.point = new BarracksInTheMine();
			}
			if (charactersAndPiont._nameU == "Лихая тропа")
			{
				Data.point = new DashingTrail();
			}
			if (charactersAndPiont._nameU == "Мост в Лиманск")
			{
				Data.point = new BridgeToLimansk();
			}
			if (charactersAndPiont._nameU == "Аномалия Симбиот")
			{
				Data.point = new AnomalySimbiot();
			}
			if (charactersAndPiont._nameU == "Брошенный бункер")
			{
				Data.point = new Abandonedbunker();
			}
			if (charactersAndPiont._nameU == "Аномальная поляна")
			{
				Data.point = new AnomalyGlade();
			}
			if (charactersAndPiont._nameU == "Ведьмин круг")
			{
				Data.point = new WitchCircle();
			}
			if (charactersAndPiont._nameU == "Т-64")
			{
				Data.point = new T64();
			}
			if (charactersAndPiont._nameU == "Деборкадер")
			{
				Data.point = new Deborkader();
			}
			if (charactersAndPiont._nameU == "Блокпост ''Север''")
			{
				Data.point = new CheckpointNorth();
			}
			if (charactersAndPiont._nameU == "Собачья стоянка")
			{
				Data.point = new DogParking();
			}
			if (charactersAndPiont._nameU == "Жарка на дикой территории")
			{
				Data.point = new WildTerritoryFrying();
			}
			if (charactersAndPiont._nameU == "Дорога к Рыжему лесу")
			{
				Data.point = new RoadToTheRedForest();
			}
			if (charactersAndPiont._nameU == "Северный лагерь")
			{
				Data.point = new NorthCamp();
			}
			if (charactersAndPiont._nameU == "Каменная насыпь")
			{
				Data.point = new StoneMound();
			}
			if (charactersAndPiont._nameU == "Старый локомотив")
			{
				Data.point = new OldLocomotive();
			}
			if (charactersAndPiont._nameU == "Вертолет ученых")
			{
				Data.point = new HelicopterScientists();
			}
			if (charactersAndPiont._nameU == "Черная тропа")
			{
				Data.point = new BlackTrail();
			}
			if (charactersAndPiont._nameU == "Лачуга у старого пруда")
			{
				Data.point = new ShackAtTheOldPond();
			}
			if (charactersAndPiont._nameU == "Путепровод")
			{
				Data.point = new Overpass();
			}
			if (charactersAndPiont._nameU == "Заводской цех")
			{
				Data.point = new FactoryFloor();
			}
			if (charactersAndPiont._nameU == "Дорога к озеру")
			{
				Data.point = new RoadToAmber();
			}
			if (charactersAndPiont._nameU == "Дорога к Бару")
			{
				Data.point = new RoadToBar();
			}
			if (charactersAndPiont._nameU == "Железнодорожный перрон")
			{
				Data.point = new RailwayApron();
			}
			if (charactersAndPiont._nameU == "Электра на севере Дикой территории")
			{
				Data.point = new ElectraNorthWildTerritory();
			}
			if (charactersAndPiont._typeCharInt != 0)
			{
				Data.point.ControlInt = charactersAndPiont._typeCharInt;
				Data.point.DealerInt = charactersAndPiont._typeCharInt;
			}
			if (charactersAndPiont._typeCharInt == 0)
			{
				Data.point.pointControl = ConstructorPoints.PointControl.None;
			}
			if (charactersAndPiont._typeCharInt == 1)
			{
				Data.point.pointControl = ConstructorPoints.PointControl.Одиночки;
			}
			if (charactersAndPiont._typeCharInt == 2)
			{
				Data.point.pointControl = ConstructorPoints.PointControl.Бандиты;
			}
			if (charactersAndPiont._typeCharInt == 3)
			{
				Data.point.pointControl = ConstructorPoints.PointControl.Военные;
			}
			if (charactersAndPiont._typeCharInt == 4)
			{
				Data.point.pointControl = ConstructorPoints.PointControl.Долг;
			}
			if (charactersAndPiont._typeCharInt == 5)
			{
				Data.point.pointControl = ConstructorPoints.PointControl.Наемники;
			}
			if (charactersAndPiont._typeCharInt == 6)
			{
				Data.point.pointControl = ConstructorPoints.PointControl.Свобода;
			}
			if (charactersAndPiont._typeCharInt == 7)
			{
				Data.point.pointControl = ConstructorPoints.PointControl.Чистое_небо;
			}
			if (charactersAndPiont._typeCharInt == 8)
			{
				Data.point.pointControl = ConstructorPoints.PointControl.Монолит;
			}
			if (charactersAndPiont._typeCharInt == 9)
			{
				Data.point.pointControl = ConstructorPoints.PointControl.Мутанты;
			}
			if (charactersAndPiont._typeCharInt == 10)
			{
				Data.point.pointControl = ConstructorPoints.PointControl.Зомби;
			}
			if (charactersAndPiont._typeCharInt == 11)
			{
				Data.point.pointControl = ConstructorPoints.PointControl.Ученые;
			}
			if (charactersAndPiont._typeCharInt == 12)
			{
				Data.point.pointControl = ConstructorPoints.PointControl.Ренегаты;
			}
			if (charactersAndPiont._CharBackpack.Length == 10)
			{
				for (int num3 = 0; num3 < 10; num3++)
				{
					if (charactersAndPiont._CharBackpack[num3] != string.Empty)
					{
						Data.point.Cache[num3].NameSubject = charactersAndPiont._CharBackpack[num3];
						Data.point.Cache[num3].State = charactersAndPiont._StateCharBackpack[num3];
						Data.point.Cache[num3].Stack = charactersAndPiont._StackCharBackpack[num3];
						if (Data.point.Cache[num3].Stack == 0)
						{
							Data.point.Cache[num3].Stack = 1;
						}
						Data.point.Cache[num3].SightInstallation = charactersAndPiont._StackCharBackpackWSI[num3];
						Data.point.Cache[num3].ArtContainer = charactersAndPiont._StackCharBackpackContainer[num3];
						Data.point.Cache[num3].WeightUpGrade = charactersAndPiont._StackCharWeightUpGrade[num3];
						Data.point.Cache[num3].UpGrade = charactersAndPiont._StackCharUpGrade[num3];
						Data.point.Cache[num3].SingModification = charactersAndPiont._SingUG[num3];
						Data.point.Cache[num3].Cartridge = charactersAndPiont._StackCartridge[num3];
					}
				}
			}
			if (charactersAndPiont._CharBackpack.Length == 20)
			{
				for (int num4 = 0; num4 < 20; num4++)
				{
					if (charactersAndPiont._CharBackpack[num4] != string.Empty)
					{
						Data.point.Cache[num4].NameSubject = charactersAndPiont._CharBackpack[num4];
						Data.point.Cache[num4].State = charactersAndPiont._StateCharBackpack[num4];
						Data.point.Cache[num4].Stack = charactersAndPiont._StackCharBackpack[num4];
						if (Data.point.Cache[num4].Stack == 0)
						{
							Data.point.Cache[num4].Stack = 1;
						}
						Data.point.Cache[num4].SightInstallation = charactersAndPiont._StackCharBackpackWSI[num4];
						Data.point.Cache[num4].ArtContainer = charactersAndPiont._StackCharBackpackContainer[num4];
						Data.point.Cache[num4].WeightUpGrade = charactersAndPiont._StackCharWeightUpGrade[num4];
						Data.point.Cache[num4].UpGrade = charactersAndPiont._StackCharUpGrade[num4];
						Data.point.Cache[num4].SingModification = charactersAndPiont._SingUG[num4];
						Data.point.Cache[num4].Cartridge = charactersAndPiont._StackCartridge[num4];
					}
				}
			}
			Data.point.exchange = charactersAndPiont._exchange;
			Data.point.Repair = charactersAndPiont._repair;
			Data.point.Medic = charactersAndPiont._medic;
			Data.Points.Add(Data.point);
		}
		if (EjectTimeSc.Ejection == 0 || EjectTimeSc.Ejection == 1 || EjectTimeSc.Ejection == -1)
		{
			Inventory.AAAAAAAAAAAAAAAAAAAbz();
		}
		else
		{
			CharacterMotion.EjectIsActive = false;
		}
		path = Path.Combine(Application.persistentDataPath, "CipherAutoSave.json");
		text = JsonUtility.ToJson(saveOneMap);
		array = Encoding.UTF8.GetBytes(text);
		string text2 = BitConverter.ToString(array);
		File.WriteAllText(path, text2.Replace("-", string.Empty));
	}

	public static void AAAAAAAAAAAAAAAAAAAck(string AAAAAAAAAAAAAAAAAAAAAcq, string AAAAAAAAAAAAAAAcc, AAAAAAAAAAAAAAAAf AAAAAAAAAAAAAAcl)
	{
		Debug.Log(AAAAAAAAAAAAAAcl);
		PlayerPrefs.SetString("AutoSaveCurrentScene", AAAAAAAAAAAAAAAAAAAAAcq);
		string path = Path.Combine(Application.persistentDataPath, "CipherAutoSave.json");
		SaveOneMap saveOneMap;
		if (!File.Exists(path))
		{
			saveOneMap = AAAAAAAAAAAAAAAbw.AAAAAAAAAAAAAAcd;
			Debug.Log("2077");
		}
		else
		{
			string text = File.ReadAllText(path);
			int length = text.Length;
			byte[] array = new byte[length / 2];
			for (int i = 0; i < length; i += 2)
			{
				array[i / 2] = Convert.ToByte(text.Substring(i, 2), 16);
			}
			text = Encoding.UTF8.GetString(array, 0, array.Length);
			saveOneMap = JsonUtility.FromJson<SaveOneMap>(text);
		}
		saveOneMap.staS.helpBool = Inventory._HelpBool;
		saveOneMap.staS.CurrentScene = AAAAAAAAAAAAAAAAAAAAAcq;
		saveOneMap.staS.gameSpeed = AAAAAAAAAAAAAAAAAAAAct.GameSpeed;
		saveOneMap.staS.sizeMap = AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAcf;
		saveOneMap.staS._curCharacter = CharacterMotion._curCharacter;
		saveOneMap.staS._PointsMove = CharacterMotion._PointsMove;
		saveOneMap.staS._difficultyLevel = Difficulty;
		saveOneMap.staS._task.Clear();
		saveOneMap.staS._ejectTime = EjectTimeSc.Ejection;
		if (saveOneMap.staS.statusG.Length == 13)
		{
			for (int j = 0; j < 13; j++)
			{
				saveOneMap.staS.statusG[j] = AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[j, 0];
				if (saveOneMap.staS.statusG[j] > 9)
				{
					saveOneMap.staS.statusG[j] = 9;
				}
			}
			saveOneMap.staS.statusGroups.Clear();
			for (int k = 0; k < 13; k++)
			{
				for (int l = 0; l < 13; l++)
				{
					saveOneMap.staS.statusGroups.Add(AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[k, l]);
				}
			}
		}
		foreach (ConstructorTasks item in Data.TaskAll)
		{
			TaskForSave taskForSave = new TaskForSave();
			taskForSave._nameTask = item.NameTask;
			taskForSave._questSubjectName = item.QuestSubject.NameSubject;
			taskForSave._killCharacterName = item.KillCharacterName;
			taskForSave._namePointTask = item.NamePointTask;
			taskForSave._numberDealer = item.NumberDealer;
			taskForSave._numberTurgetInData = item.NumberTurgetInData;
			taskForSave._numberPointOfGuide = item.NumberPointOfGuide;
			taskForSave._mapName = item.MapName;
			taskForSave._groupName = item.GroupName;
			taskForSave._numberEnemy = item.NumberEnemy;
			saveOneMap.staS._task.Add(taskForSave);
		}
		saveOneMap.staS.ListOldTask.Clear();
		foreach (string item2 in Data.OldTask)
		{
			saveOneMap.staS.ListOldTask.Add(item2);
		}
		int num = 0;
		foreach (CharacterAndPoint charactersAndPiont in saveOneMap.charactersAndPionts)
		{
			if (charactersAndPiont._curMap == AAAAAAAAAAAAAAAAAAAAAcq)
			{
				num++;
			}
		}
		if (num == 0)
		{
			foreach (CharacterAndPoint charactersAndPiont2 in AAAAAAAAAAAAAAAbw.AAAAAAAAAAAAAAcd.charactersAndPionts)
			{
				if (charactersAndPiont2._curMap == AAAAAAAAAAAAAAAAAAAAAcq)
				{
					charactersAndPiont2._curHealth = 50f;
					charactersAndPiont2._bleeding = 0f;
					charactersAndPiont2._thirst = 50;
					charactersAndPiont2._satietyCh = 50;
					charactersAndPiont2._suitCharState = 100f;
					charactersAndPiont2._weaponCharState = 100f;
					for (int m = 0; m < charactersAndPiont2._StateCharBackpack.Length; m++)
					{
						charactersAndPiont2._StateCharBackpack[m] = 100;
					}
					saveOneMap.charactersAndPionts.Add(charactersAndPiont2);
				}
			}
		}
		while (true)
		{
			int num2 = 0;
			while (true)
			{
				if (num2 < saveOneMap.charactersAndPionts.Count)
				{
					if (saveOneMap.charactersAndPionts[num2]._curMap == SceneManager.GetActiveScene().name)
					{
						break;
					}
					num2++;
					continue;
				}
				for (int n = 0; n < Data.CharacterD.Count; n++)
				{
					if (Data.CharacterD[n] == null || Data.CharacterD[n] == AAAAAAAAAAAAAAcl)
					{
						continue;
					}
					CharacterAndPoint characterAndPoint = new CharacterAndPoint();
					characterAndPoint._curMap = SceneManager.GetActiveScene().name;
					if (Data.CharacterD[n].NameU != null)
					{
						characterAndPoint._nameU = Data.CharacterD[n].NameU;
					}
					if (Data.CharacterD[n].NameCharac != null)
					{
						characterAndPoint._nameCharac = Data.CharacterD[n].NameCharac;
					}
					characterAndPoint._typeCharInt = Data.CharacterD[n].TypeChInt;
					characterAndPoint._controlGamer = Data.CharacterD[n].ControlGamer;
					characterAndPoint._life = Data.CharacterD[n].Life;
					if (Data.CharacterD[n].CurGexChar != null)
					{
						characterAndPoint._curGexCharName = Data.CharacterD[n].CurGexChar.NameGex;
					}
					characterAndPoint._skill = Data.CharacterD[n].Skill;
					if (Data.CharacterD[n].SuitChar != null)
					{
						characterAndPoint._suitCharName = Data.CharacterD[n].SuitChar.NameSubject;
						characterAndPoint._suitCharState = Data.CharacterD[n].SuitChar.State;
						characterAndPoint.WeightUpGrade = Data.CharacterD[n].SuitChar.WeightUpGrade;
						characterAndPoint.UpGrade = Data.CharacterD[n].SuitChar.UpGrade;
						characterAndPoint.SingUG_suit = Data.CharacterD[n].SuitChar.SingModification;
					}
					else
					{
						Inventory.MessagePanel("Ошибка сохранения, приносим извинения за неудобства. Если Вас не затруднит, напишите о ней разработчику, это поможет быстрее устранить причину ошибки. Спасибо.\n" + SceneManager.GetActiveScene().name + ", " + characterAndPoint._nameU + ", , suit\n");
						characterAndPoint._suitCharName = "None";
						characterAndPoint._suitCharState = 0f;
						characterAndPoint.WeightUpGrade = 0f;
						characterAndPoint.UpGrade = 0f;
						characterAndPoint.SingUG_suit = false;
					}
					characterAndPoint._suitCharContainer = Data.CharacterD[n].SuitChar.ArtContainer;
					if (Data.CharacterD[n].ArtContainers[0] != null)
					{
						characterAndPoint._ArtContainer[0] = Data.CharacterD[n].ArtContainers[0].NameSubject;
					}
					else
					{
						Inventory.MessagePanel("Ошибка сохранения, приносим извинения за неудобства. Если Вас не затруднит, напишите о ней разработчику, это поможет быстрее устранить причину ошибки. Спасибо.\n" + SceneManager.GetActiveScene().name + ", " + characterAndPoint._nameU + ", , art0\n");
						characterAndPoint._ArtContainer[0] = "None";
					}
					if (Data.CharacterD[n].ArtContainers[1] != null)
					{
						characterAndPoint._ArtContainer[1] = Data.CharacterD[n].ArtContainers[1].NameSubject;
					}
					else
					{
						Inventory.MessagePanel("Ошибка сохранения, приносим извинения за неудобства. Если Вас не затруднит, напишите о ней разработчику, это поможет быстрее устранить причину ошибки. Спасибо.\n" + SceneManager.GetActiveScene().name + ", " + characterAndPoint._nameU + ", , art1\n");
						characterAndPoint._ArtContainer[1] = "None";
					}
					if (Data.CharacterD[n].ArtContainers[2] != null)
					{
						characterAndPoint._ArtContainer[2] = Data.CharacterD[n].ArtContainers[2].NameSubject;
					}
					else
					{
						Inventory.MessagePanel("Ошибка сохранения, приносим извинения за неудобства. Если Вас не затруднит, напишите о ней разработчику, это поможет быстрее устранить причину ошибки. Спасибо.\n" + SceneManager.GetActiveScene().name + ", " + characterAndPoint._nameU + ", , art2\n");
						characterAndPoint._ArtContainer[2] = "None";
					}
					if (Data.CharacterD[n].ArtContainers[3] != null)
					{
						characterAndPoint._ArtContainer[3] = Data.CharacterD[n].ArtContainers[3].NameSubject;
					}
					else
					{
						Inventory.MessagePanel("Ошибка сохранения, приносим извинения за неудобства. Если Вас не затруднит, напишите о ней разработчику, это поможет быстрее устранить причину ошибки. Спасибо.\n" + SceneManager.GetActiveScene().name + ", " + characterAndPoint._nameU + ", , art3\n");
						characterAndPoint._ArtContainer[3] = "None";
					}
					if (Data.CharacterD[n].WeaponChar != null)
					{
						characterAndPoint._weaponCharName = Data.CharacterD[n].WeaponChar.NameSubject;
						characterAndPoint._weaponCharState = Data.CharacterD[n].WeaponChar.State;
						characterAndPoint.WeightUpGradeWeapon = Data.CharacterD[n].WeaponChar.WeightUpGrade;
						characterAndPoint.WeaponUpGrade = Data.CharacterD[n].WeaponChar.UpGrade;
						characterAndPoint.SingUG_weapon = Data.CharacterD[n].WeaponChar.SingModification;
						characterAndPoint._weaponCharSightInstallation = Data.CharacterD[n].WeaponChar.SightInstallation;
						characterAndPoint.CartridgeInt = Data.CharacterD[n].WeaponChar.Cartridge;
					}
					else
					{
						Inventory.MessagePanel("Ошибка сохранения, приносим извинения за неудобства. Если Вас не затруднит, напишите о ней разработчику, это поможет быстрее устранить причину ошибки. Спасибо.\n" + SceneManager.GetActiveScene().name + ", " + characterAndPoint._nameU + ", , weapon\n");
						characterAndPoint._weaponCharName = "None";
						characterAndPoint._weaponCharState = 0f;
						characterAndPoint.WeightUpGradeWeapon = 0f;
						characterAndPoint.WeaponUpGrade = 0f;
						characterAndPoint.SingUG_weapon = false;
						characterAndPoint._weaponCharSightInstallation = false;
						characterAndPoint.CartridgeInt = 0;
					}
					if (Data.CharacterD[n].DetectorChar != null)
					{
						characterAndPoint._detectorCharName = Data.CharacterD[n].DetectorChar.NameSubject;
					}
					else
					{
						characterAndPoint._detectorCharName = "None";
					}
					characterAndPoint._cash = Data.CharacterD[n].Cash;
					characterAndPoint._curHealth = Data.CharacterD[n].CurHealth;
					characterAndPoint._bleeding = Data.CharacterD[n].Bleeding;
					characterAndPoint._diseaseXRay = Data.CharacterD[n].DiseaseXRay;
					characterAndPoint._chemicalBurn = Data.CharacterD[n].ChemicalBurnCh;
					characterAndPoint._burn = Data.CharacterD[n].BurnCh;
					characterAndPoint._bonus = Data.CharacterD[n].Bonus;
					characterAndPoint._ageOfDeath = Data.CharacterD[n].AgeOfDeath;
					characterAndPoint._satietyCh = Data.CharacterD[n].Satiety;
					characterAndPoint._thirst = Data.CharacterD[n].Thirst;
					for (int num3 = 0; num3 < 20; num3++)
					{
						if (Data.CharacterD[n].CharBackpack[num3] != null)
						{
							characterAndPoint._CharBackpack[num3] = Data.CharacterD[n].CharBackpack[num3].NameSubject;
							characterAndPoint._StateCharBackpack[num3] = (int)Data.CharacterD[n].CharBackpack[num3].State;
							characterAndPoint._StackCharBackpack[num3] = Data.CharacterD[n].CharBackpack[num3].Stack;
							characterAndPoint._StackCharBackpackWSI[num3] = Data.CharacterD[n].CharBackpack[num3].SightInstallation;
							characterAndPoint._StackCharBackpackContainer[num3] = Data.CharacterD[n].CharBackpack[num3].ArtContainer;
							characterAndPoint._StackCharWeightUpGrade[num3] = Data.CharacterD[n].CharBackpack[num3].WeightUpGrade;
							characterAndPoint._StackCharUpGrade[num3] = Data.CharacterD[n].CharBackpack[num3].UpGrade;
							characterAndPoint._SingUG[num3] = Data.CharacterD[n].CharBackpack[num3].SingModification;
							characterAndPoint._StackCartridge[num3] = Data.CharacterD[n].CharBackpack[num3].Cartridge;
						}
						else
						{
							Inventory.MessagePanel("Ошибка сохранения, приносим извинения за неудобства. Если Вас не затруднит, напишите о ней разработчику, это поможет быстрее устранить причину ошибки. Спасибо.\n" + SceneManager.GetActiveScene().name + ", " + characterAndPoint._nameU + ", , backpack[" + num3 + "]\n");
							characterAndPoint._CharBackpack[num3] = "None";
							characterAndPoint._StateCharBackpack[num3] = 0;
							characterAndPoint._StackCharBackpack[num3] = 0;
							characterAndPoint._StackCharBackpackWSI[num3] = false;
							characterAndPoint._StackCharBackpackContainer[num3] = 0;
							characterAndPoint._StackCharWeightUpGrade[num3] = 0f;
							characterAndPoint._StackCharUpGrade[num3] = 0f;
							characterAndPoint._SingUG[num3] = false;
							characterAndPoint._StackCartridge[num3] = 0;
						}
					}
					characterAndPoint.Accuracy = Data.CharacterD[n].Accuracy;
					characterAndPoint.Andurance = Data.CharacterD[n].Andurance;
					characterAndPoint.HealthAdditional = Data.CharacterD[n].HealthAdditional;
					characterAndPoint.PSIprotection = Data.CharacterD[n].PSIprotection;
					saveOneMap.charactersAndPionts.Add(characterAndPoint);
				}
				for (int num4 = 0; num4 < Data.Points.Count; num4++)
				{
					if (Data.Points[num4] == null)
					{
						continue;
					}
					CharacterAndPoint characterAndPoint2 = new CharacterAndPoint();
					characterAndPoint2._curMap = SceneManager.GetActiveScene().name;
					if (Data.Points[num4].namePoint != null)
					{
						characterAndPoint2._nameU = Data.Points[num4].namePoint;
					}
					characterAndPoint2._typeCharInt = Data.Points[num4].ControlInt;
					characterAndPoint2._exchange = Data.Points[num4].exchange;
					characterAndPoint2._repair = Data.Points[num4].Repair;
					characterAndPoint2._medic = Data.Points[num4].Medic;
					characterAndPoint2._taskChoise = Data.Points[num4].TaskChoise;
					for (int num5 = 0; num5 < 20; num5++)
					{
						if (Data.Points[num4].Cache[num5] != null)
						{
							characterAndPoint2._CharBackpack[num5] = Data.Points[num4].Cache[num5].NameSubject;
							characterAndPoint2._StateCharBackpack[num5] = (int)Data.Points[num4].Cache[num5].State;
							characterAndPoint2._StackCharBackpack[num5] = Data.Points[num4].Cache[num5].Stack;
							characterAndPoint2._StackCharBackpackWSI[num5] = Data.Points[num4].Cache[num5].SightInstallation;
							characterAndPoint2._StackCharBackpackContainer[num5] = Data.Points[num4].Cache[num5].ArtContainer;
							characterAndPoint2._StackCharWeightUpGrade[num5] = Data.Points[num4].Cache[num5].WeightUpGrade;
							characterAndPoint2._StackCharUpGrade[num5] = Data.Points[num4].Cache[num5].UpGrade;
							characterAndPoint2._SingUG[num5] = Data.Points[num4].Cache[num5].SingModification;
							characterAndPoint2._StackCartridge[num5] = Data.Points[num4].Cache[num5].Cartridge;
						}
						else
						{
							Inventory.MessagePanel("Ошибка сохранения, приносим извинения за неудобства. Если Вас не затруднит, напишите о ней разработчику, это поможет быстрее устранить причину ошибки. Спасибо.\n" + SceneManager.GetActiveScene().name + ", " + characterAndPoint2._nameU + ", cache[" + num5 + "], ");
							characterAndPoint2._CharBackpack[num5] = "None";
							characterAndPoint2._StateCharBackpack[num5] = 0;
							characterAndPoint2._StackCharBackpack[num5] = 0;
							characterAndPoint2._StackCharBackpackWSI[num5] = false;
							characterAndPoint2._StackCharBackpackContainer[num5] = 0;
							characterAndPoint2._StackCharWeightUpGrade[num5] = 0f;
							characterAndPoint2._StackCharUpGrade[num5] = 0f;
							characterAndPoint2._SingUG[num5] = false;
							characterAndPoint2._StackCartridge[num5] = 0;
						}
					}
					saveOneMap.charactersAndPionts.Add(characterAndPoint2);
				}
				foreach (CharacterAndPoint charactersAndPiont3 in saveOneMap.charactersAndPionts)
				{
					if (charactersAndPiont3._nameU == "Странник" && charactersAndPiont3._curMap == AAAAAAAAAAAAAAAAAAAAAcq)
					{
						charactersAndPiont3._nameCharac = Data.CharacterD[0].NameCharac;
						charactersAndPiont3._typeCharInt = Data.CharacterD[0].TypeChInt;
						charactersAndPiont3._controlGamer = Data.CharacterD[0].ControlGamer;
						charactersAndPiont3._curHealth = Data.CharacterD[0].CurHealth;
						charactersAndPiont3._suitCharName = Data.CharacterD[0].SuitChar.NameSubject;
						charactersAndPiont3._suitCharState = Data.CharacterD[0].SuitChar.State;
						charactersAndPiont3._suitCharContainer = Data.CharacterD[0].SuitChar.ArtContainer;
						charactersAndPiont3.WeightUpGrade = Data.CharacterD[0].SuitChar.WeightUpGrade;
						charactersAndPiont3.UpGrade = Data.CharacterD[0].SuitChar.UpGrade;
						charactersAndPiont3.SingUG_suit = Data.CharacterD[0].SuitChar.SingModification;
						charactersAndPiont3._weaponCharName = Data.CharacterD[0].WeaponChar.NameSubject;
						charactersAndPiont3._weaponCharState = Data.CharacterD[0].WeaponChar.State;
						charactersAndPiont3._weaponCharSightInstallation = Data.CharacterD[0].WeaponChar.SightInstallation;
						charactersAndPiont3.CartridgeInt = Data.CharacterD[0].WeaponChar.Cartridge;
						charactersAndPiont3.WeightUpGradeWeapon = Data.CharacterD[0].WeaponChar.WeightUpGrade;
						charactersAndPiont3.WeaponUpGrade = Data.CharacterD[0].WeaponChar.UpGrade;
						charactersAndPiont3.SingUG_weapon = Data.CharacterD[0].WeaponChar.SingModification;
						for (int num6 = 0; num6 < 4; num6++)
						{
							charactersAndPiont3._ArtContainer[num6] = Data.CharacterD[0].ArtContainers[num6].NameSubject;
						}
						charactersAndPiont3._detectorCharName = Data.CharacterD[0].DetectorChar.NameSubject;
						charactersAndPiont3._skill = Data.CharacterD[0].Skill;
						charactersAndPiont3._bonus = Data.CharacterD[0].Bonus;
						charactersAndPiont3._bleeding = Data.CharacterD[0].Bleeding;
						charactersAndPiont3._diseaseXRay = Data.CharacterD[0].DiseaseXRay;
						charactersAndPiont3._cash = Data.CharacterD[0].Cash;
						charactersAndPiont3._life = Data.CharacterD[0].Life;
						charactersAndPiont3._ageOfDeath = Data.CharacterD[0].AgeOfDeath;
						charactersAndPiont3._satietyCh = Data.CharacterD[0].Satiety;
						charactersAndPiont3._thirst = Data.CharacterD[0].Thirst;
						charactersAndPiont3._curGexCharName = AAAAAAAAAAAAAAAcc;
						charactersAndPiont3._CharBackpack = new string[20];
						charactersAndPiont3._StateCharBackpack = new int[20];
						charactersAndPiont3._StackCharBackpack = new int[20];
						charactersAndPiont3._StackCharBackpackWSI = new bool[20];
						for (int num7 = 0; num7 < 20; num7++)
						{
							charactersAndPiont3._CharBackpack[num7] = Data.CharacterD[0].CharBackpack[num7].NameSubject;
							charactersAndPiont3._StateCharBackpack[num7] = (int)Data.CharacterD[0].CharBackpack[num7].State;
							charactersAndPiont3._StackCharBackpack[num7] = Data.CharacterD[0].CharBackpack[num7].Stack;
							charactersAndPiont3._StackCharBackpackWSI[num7] = Data.CharacterD[0].CharBackpack[num7].SightInstallation;
							charactersAndPiont3._StackCharBackpackContainer[num7] = Data.CharacterD[0].CharBackpack[num7].ArtContainer;
							charactersAndPiont3._StackCharWeightUpGrade[num7] = Data.CharacterD[0].CharBackpack[num7].WeightUpGrade;
							charactersAndPiont3._StackCharUpGrade[num7] = Data.CharacterD[0].CharBackpack[num7].UpGrade;
							charactersAndPiont3._SingUG[num7] = Data.CharacterD[0].CharBackpack[num7].SingModification;
							charactersAndPiont3._StackCartridge[num7] = Data.CharacterD[0].CharBackpack[num7].Cartridge;
						}
						charactersAndPiont3.PSIprotection = Data.CharacterD[0].PSIprotection;
					}
				}
				if (AAAAAAAAAAAAAAcl != null)
				{
					CharacterAndPoint characterAndPoint3 = new CharacterAndPoint();
					characterAndPoint3._curMap = AAAAAAAAAAAAAAAAAAAAAcq;
					characterAndPoint3._curGexCharName = AAAAAAAAAAAAAAAcc;
					characterAndPoint3._nameCharac = AAAAAAAAAAAAAAcl.NameCharac;
					characterAndPoint3._nameU = AAAAAAAAAAAAAAcl.CharUnits.name;
					characterAndPoint3._typeCharInt = AAAAAAAAAAAAAAcl.TypeChInt;
					characterAndPoint3._nameU = AAAAAAAAAAAAAAcl.CharUnits.name;
					characterAndPoint3._controlGamer = AAAAAAAAAAAAAAcl.ControlGamer;
					characterAndPoint3._curHealth = AAAAAAAAAAAAAAcl.CurHealth;
					characterAndPoint3._suitCharName = AAAAAAAAAAAAAAcl.SuitChar.NameSubject;
					characterAndPoint3._suitCharState = AAAAAAAAAAAAAAcl.SuitChar.State;
					characterAndPoint3._suitCharContainer = AAAAAAAAAAAAAAcl.SuitChar.ArtContainer;
					characterAndPoint3.WeightUpGrade = AAAAAAAAAAAAAAcl.SuitChar.WeightUpGrade;
					characterAndPoint3.UpGrade = AAAAAAAAAAAAAAcl.SuitChar.UpGrade;
					characterAndPoint3.SingUG_suit = AAAAAAAAAAAAAAcl.SuitChar.SingModification;
					characterAndPoint3._weaponCharName = AAAAAAAAAAAAAAcl.WeaponChar.NameSubject;
					characterAndPoint3._weaponCharState = AAAAAAAAAAAAAAcl.WeaponChar.State;
					characterAndPoint3.WeaponUpGrade = AAAAAAAAAAAAAAcl.WeaponChar.UpGrade;
					characterAndPoint3.SingUG_weapon = AAAAAAAAAAAAAAcl.WeaponChar.SingModification;
					characterAndPoint3._weaponCharSightInstallation = AAAAAAAAAAAAAAcl.WeaponChar.SightInstallation;
					characterAndPoint3.WeightUpGradeWeapon = AAAAAAAAAAAAAAcl.WeaponChar.WeightUpGrade;
					characterAndPoint3.CartridgeInt = AAAAAAAAAAAAAAcl.WeaponChar.Cartridge;
					for (int num8 = 0; num8 < 4; num8++)
					{
						characterAndPoint3._ArtContainer[num8] = AAAAAAAAAAAAAAcl.ArtContainers[num8].NameSubject;
					}
					characterAndPoint3._detectorCharName = AAAAAAAAAAAAAAcl.DetectorChar.NameSubject;
					characterAndPoint3._skill = AAAAAAAAAAAAAAcl.Skill;
					characterAndPoint3._bonus = AAAAAAAAAAAAAAcl.Bonus;
					characterAndPoint3._bleeding = AAAAAAAAAAAAAAcl.Bleeding;
					characterAndPoint3._diseaseXRay = AAAAAAAAAAAAAAcl.DiseaseXRay;
					characterAndPoint3._cash = AAAAAAAAAAAAAAcl.Cash;
					characterAndPoint3._life = AAAAAAAAAAAAAAcl.Life;
					characterAndPoint3._ageOfDeath = AAAAAAAAAAAAAAcl.AgeOfDeath;
					characterAndPoint3._satietyCh = AAAAAAAAAAAAAAcl.Satiety;
					characterAndPoint3._thirst = AAAAAAAAAAAAAAcl.Thirst;
					for (int num9 = 0; num9 < 20; num9++)
					{
						characterAndPoint3._CharBackpack[num9] = AAAAAAAAAAAAAAcl.CharBackpack[num9].NameSubject;
						characterAndPoint3._StateCharBackpack[num9] = (int)AAAAAAAAAAAAAAcl.CharBackpack[num9].State;
						characterAndPoint3._StackCharBackpack[num9] = AAAAAAAAAAAAAAcl.CharBackpack[num9].Stack;
						characterAndPoint3._StackCharBackpackWSI[num9] = AAAAAAAAAAAAAAcl.CharBackpack[num9].SightInstallation;
						characterAndPoint3._StackCharBackpackContainer[num9] = AAAAAAAAAAAAAAcl.CharBackpack[num9].ArtContainer;
						characterAndPoint3._StackCharWeightUpGrade[num9] = AAAAAAAAAAAAAAcl.CharBackpack[num9].WeightUpGrade;
						characterAndPoint3._StackCharUpGrade[num9] = AAAAAAAAAAAAAAcl.CharBackpack[num9].UpGrade;
						characterAndPoint3._SingUG[num9] = AAAAAAAAAAAAAAcl.CharBackpack[num9].SingModification;
						characterAndPoint3._StackCartridge[num9] = AAAAAAAAAAAAAAcl.CharBackpack[num9].Cartridge;
					}
					characterAndPoint3.PSIprotection = AAAAAAAAAAAAAAcl.PSIprotection;
					saveOneMap.charactersAndPionts.Add(characterAndPoint3);
				}
				string text = JsonUtility.ToJson(saveOneMap);
				byte[] array = Encoding.UTF8.GetBytes(text);
				string text2 = BitConverter.ToString(array);
				File.WriteAllText(path, text2.Replace("-", string.Empty));
				return;
			}
			saveOneMap.charactersAndPionts.RemoveAt(num2);
		}
	}

	public static void AAAAAAAAAAAAAAAAAAdg()
	{
		Debug.Log("newGame");
		Data.TaskAll.Clear();
		Data.TaskAll.Add(new TaskGlobal0());
		Data.TaskAll.Add(new TaskBasic0());
		Inventory._HelpBool = true;
		AAAAAAAAAAAAAAAAAAAAct.GameSpeed = 6.4f;
		AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAcf = 6f;
		CharacterMotion._curCharacter = 0;
		CharacterMotion._PointsMove = 5;
		for (int i = 0; i < 13; i++)
		{
			for (int j = 0; j < 13; j++)
			{
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[i, j] = AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAcg[i, j];
			}
		}
		foreach (CharacterAndPoint charactersAndPiont in AAAAAAAAAAAAAAAbw.AAAAAAAAAAAAAAcd.charactersAndPionts)
		{
			for (int k = 0; k < 20; k++)
			{
				charactersAndPiont._StateCharBackpack[k] = 100;
				charactersAndPiont._StackCharBackpack[k] = 1;
			}
			if (!(charactersAndPiont._curMap == "Kordon"))
			{
				continue;
			}
			if (charactersAndPiont._nameCharac != string.Empty)
			{
				if (charactersAndPiont._nameCharac == "Странник")
				{
					Data._character = new AAAAAAAAAAAAAAAAAAAAAAs();
				}
				if (charactersAndPiont._nameCharac == "Плоть")
				{
					Data._character = new AAAAAAAAAAAAAAAAAAAAr();
				}
				if (charactersAndPiont._nameCharac == "Кабан")
				{
					Data._character = new AAAAAAAAAAAAAAAAAAAAs();
				}
				if (charactersAndPiont._nameCharac == "Слепой пес")
				{
					Data._character = new AAAAAAAAAAAAAAAAAAAAt();
				}
				if (charactersAndPiont._nameCharac == "Псевдособака")
				{
					Data._character = new AAAAAAAAAAAAAAAAAt();
				}
				if (charactersAndPiont._nameCharac == "Кровосос")
				{
					Data._character = new AAAAAAAAAAAAAAAAAAba();
				}
				if (charactersAndPiont._nameCharac == "Контролер")
				{
					Data._character = new AAAAAAAAAAAAAAAAAAbb();
				}
				if (charactersAndPiont._nameCharac == "Нетралы" || charactersAndPiont._nameCharac == "Одиночки")
				{
					Data._character = new AAAAAAAAAAAAAAAAAs();
				}
				if (charactersAndPiont._nameCharac == "Бандиты")
				{
					Data._character = new AAAAAAAAAAAAAAAAAAAz();
				}
				if (charactersAndPiont._nameCharac == "Военные")
				{
					Data._character = new AAAAAAAAAAAAAAAAAAAAq();
				}
				if (charactersAndPiont._nameCharac == "Долг")
				{
					Data._character = new AAAAAAAAAAAAAAAi();
				}
				if (charactersAndPiont._nameCharac == "Чистое небо")
				{
					Data._character = new AAAAAAAAAAAAAAAAAAAAAx();
				}
				if (charactersAndPiont._nameCharac == "Наемники")
				{
					Data._character = new AAAAAAAAAAAAAAAAAAAAAAu();
				}
				if (charactersAndPiont._nameCharac == "Свобода")
				{
					Data._character = new AAAAAAAAAAAAAAAAAAAAAw();
				}
				if (charactersAndPiont._nameCharac == "Зомби")
				{
					Data._character = new AAAAAAAAAAAAAAAAAAAAAAv();
				}
				if (charactersAndPiont._nameCharac == "Монолит")
				{
					Data._character = new AAAAAAAAAAAAAAAj();
				}
				if (charactersAndPiont._nameCharac == "Ученые")
				{
					Data._character = new AAAAAAAAAAAAAAAAAAi();
				}
				if (charactersAndPiont._nameCharac == "Ренегаты")
				{
					Data._character = new AAAAAAAAAAAAAAAAAAAAAy();
				}
				Data._character.ControlGamer = charactersAndPiont._controlGamer;
				for (int l = 0; l < 20; l++)
				{
					Data._character.CharBackpack[l].NameSubject = charactersAndPiont._CharBackpack[l];
				}
				if (Difficulty >= 1f && charactersAndPiont._nameCharac == "Странник")
				{
					Data._character.CharBackpack[8].NameSubject = "Аптечка армейская";
					Data._character.CharBackpack[9].NameSubject = "Детектор Отклик";
				}
				if (charactersAndPiont._nameCharac == "Странник")
				{
					Data._character.CharBackpack[10].NameSubject = "9х18 мм";
					Data._character.CharBackpack[10].Stack = 30;
					Data._character.CurHealth = charactersAndPiont._curHealth;
				}
				if (charactersAndPiont._life)
				{
					Data._character.CharUnits.transform.GetChild(0).transform.localPosition = new Vector3((Data._character.CurHealth / 100f - 0.5f) / 2f, 0.5f);
					Data._character.CharUnits.transform.GetChild(0).transform.localScale = new Vector3(Data._character.CurHealth / 100f, 0.3f);
				}
				else
				{
					Data._character.CharUnits.transform.GetChild(0).transform.localScale = new Vector3(0f, 0.3f);
				}
				Data._character.Skill = charactersAndPiont._skill;
				for (int m = 0; m < Gexa.GexLib.Count; m++)
				{
					if (Gexa.GexLib[m].NameGex == charactersAndPiont._curGexCharName)
					{
						Data._character.CurGexChar = Gexa.GexLib[m];
						Data._character.TaskGexChar = Gexa.GexLib[m];
					}
				}
				Data._character.CharUnits.transform.position = Data._character.CurGexChar.GexGO.transform.position;
				Data._character.NameU = charactersAndPiont._nameU;
				Data._character.CharUnits.name = charactersAndPiont._nameU;
				if (Difficulty >= 1f && Data._character.CharUnits.name == "Капитан Пулин, Военный")
				{
					Data._character = new AAAAAAAAAAAAAAAAAs();
					Data._character.SuitChar = new AAAAAAAAAAAAAAAAAx();
					Data._character.WeaponChar = new TOZ34();
					Data._character.CharBackpack[1] = new AAAAAAAAAAAAAAAAAAAbg();
					Data._character.CharBackpack[2] = new AAAAAAAAAAAAAAAAz();
					Data._character.CharBackpack[3] = new AAAAAAAAAAAAAAAAAAbs();
				}
				Data._character.Bonus = charactersAndPiont._bonus;
				Data._character.Bleeding = charactersAndPiont._bleeding;
				Data._character.DiseaseXRay = charactersAndPiont._diseaseXRay;
				Data._character.Cash = charactersAndPiont._cash;
				if (Difficulty >= 1.1f && charactersAndPiont._nameCharac == "Странник")
				{
					Data._character.Cash = 2500;
				}
				Data._character.Life = charactersAndPiont._life;
				Data._character.AgeOfDeath = charactersAndPiont._ageOfDeath;
				Data.CharacterD.Add(Data._character);
				AAAAAAAAAAAAAAAAAAAAcs();
			}
			if (charactersAndPiont._nameCharac == string.Empty)
			{
				if (charactersAndPiont._nameU == "Лесопилка")
				{
					Data.point = new Sawmill();
				}
				if (charactersAndPiont._nameU == "Тлеющий хутор")
				{
					Data.point = new SmolderingFarm();
				}
				if (charactersAndPiont._nameU == "Аномалия ''Котел''")
				{
					Data.point = new AnomalyBoiler();
				}
				if (charactersAndPiont._nameU == "Скадовск")
				{
					Data.point = new Skadovsk();
				}
				if (charactersAndPiont._nameU == "Земснаряд")
				{
					Data.point = new Dredger();
				}
				if (charactersAndPiont._nameU == "Топь")
				{
					Data.point = new Slough();
				}
				if (charactersAndPiont._nameU == "Изумрудное")
				{
					Data.point = new Emerald();
				}
				if (charactersAndPiont._nameU == "Шевченко")
				{
					Data.point = new Shevchenko();
				}
				if (charactersAndPiont._nameU == "Портовые краны")
				{
					Data.point = new PortCranes();
				}
				if (charactersAndPiont._nameU == "Лесничество")
				{
					Data.point = new Forestry();
				}
				if (charactersAndPiont._nameU == "ВНЗ «Круг»")
				{
					Data.point = new VNZcircle();
				}
				if (charactersAndPiont._nameU == "Железный лес")
				{
					Data.point = new Ironwood();
				}
				if (charactersAndPiont._nameU == "Испытательный цех")
				{
					Data.point = new TestShop();
				}
				if (charactersAndPiont._nameU == "Заправка")
				{
					Data.point = new Refueling();
				}
				if (charactersAndPiont._nameU == "Соснодуб")
				{
					Data.point = new Sosnodub();
				}
				if (charactersAndPiont._nameU == "Аномалия ''Цирк''")
				{
					Data.point = new AnomalyCircus();
				}
				if (charactersAndPiont._nameU == "Станция переработки отходов")
				{
					Data.point = new WasteProcessingPlant();
				}
				if (charactersAndPiont._nameU == "Мост им. Преображенского")
				{
					Data.point = new BridgePreobrazhensky();
				}
				if (charactersAndPiont._nameU == "Форпост")
				{
					Data.point = new Outpost();
				}
				if (charactersAndPiont._nameU == "Товарный состав")
				{
					Data.point = new CommodityComposition();
				}
				if (charactersAndPiont._nameU == "Тоннель ''Тузла''")
				{
					Data.point = new TunnelTuzla();
				}
				if (charactersAndPiont._nameU == "Лодочная станция")
				{
					Data.point = new BoatStation();
				}
				if (charactersAndPiont._nameU == "Южный хутор")
				{
					Data.point = new SouthFarm();
				}
				if (charactersAndPiont._nameU == "Северный хутор")
				{
					Data.point = new NorthFarm();
				}
				if (charactersAndPiont._nameU == "Механизаторский двор")
				{
					Data.point = new MechanizationYard();
				}
				if (charactersAndPiont._nameU == "Руины деревни")
				{
					Data.point = new RuinsOfTheVillage();
				}
				if (charactersAndPiont._nameU == "Болотный трамплин")
				{
					Data.point = new MarshTrampoline();
				}
				if (charactersAndPiont._nameU == "Кислотная аномалия")
				{
					Data.point = new AcidAnomaly();
				}
				if (charactersAndPiont._nameU == "Сгоревший хутор")
				{
					Data.point = new BurntFarm();
				}
				if (charactersAndPiont._nameU == "Старая церковь")
				{
					Data.point = new OldChurch();
				}
				if (charactersAndPiont._nameU == "Смотровая вышка")
				{
					Data.point = new Sighthole();
				}
				if (charactersAndPiont._nameU == "Рыбацкий хутор")
				{
					Data.point = new FishermansFarm();
				}
				if (charactersAndPiont._nameU == "База Чистого Неба")
				{
					Data.point = new BaseClearSky();
				}
				if (charactersAndPiont._nameU == "Насосная Станция")
				{
					Data.point = new PumpingStationMarsh();
				}
				if (charactersAndPiont._nameU == "Разлом")
				{
					Data.point = new FaultAnomaly();
				}
				if (charactersAndPiont._nameU == "АТП")
				{
					Data.point = new ATP();
				}
				if (charactersAndPiont._nameU == "Элеватор")
				{
					Data.point = new Elevator();
				}
				if (charactersAndPiont._nameU == "Деревня новичков")
				{
					Data.point = new BaseNovice();
				}
				if (charactersAndPiont._nameU == "Болото радиоактивных отходов")
				{
					Data.point = new XRaySwamp();
				}
				if (charactersAndPiont._nameU == "Перевернутый тепловоз")
				{
					Data.point = new Locomotive();
				}
				if (charactersAndPiont._nameU == "Разбитый грузовик")
				{
					Data.point = new TruckBroken();
				}
				if (charactersAndPiont._nameU == "Военная база")
				{
					Data.point = new ArmBase();
				}
				if (charactersAndPiont._nameU == "Перевернутый УАЗик")
				{
					Data.point = new UAZBroken();
				}
				if (charactersAndPiont._nameU == "Логово мутантов на кордоне")
				{
					Data.point = new MutantBaseKordon();
				}
				if (charactersAndPiont._nameU == "Дорога на свалку")
				{
					Data.point = new DumpRoad();
				}
				if (charactersAndPiont._nameU == "Блок-пост приемник")
				{
					Data.point = new BlockPost();
				}
				if (charactersAndPiont._nameU == "Стоянка брошенной техники")
				{
					Data.point = new AbandonedMachinery();
				}
				if (charactersAndPiont._nameU == "Аномальная трясина")
				{
					Data.point = new AnomalySwamp();
				}
				if (charactersAndPiont._nameU == "Дорога на болото")
				{
					Data.point = new SwampRoad();
				}
				if (charactersAndPiont._nameU == "Ангар")
				{
					Data.point = new Hangar();
				}
				if (charactersAndPiont._nameU == "Дорога на НИИ Агропром")
				{
					Data.point = new AgropromRoad();
				}
				if (charactersAndPiont._nameU == "Бетонные плиты")
				{
					Data.point = new ConcretePlates();
				}
				if (charactersAndPiont._nameU == "Привал диггеров")
				{
					Data.point = new HaltDiggers();
				}
				if (charactersAndPiont._nameU == "Барьер")
				{
					Data.point = new Barrier();
				}
				if (charactersAndPiont._nameU == "Дорога в темную долину")
				{
					Data.point = new DarkValleyRoad();
				}
				if (charactersAndPiont._nameU == "Брошенный экскаватор")
				{
					Data.point = new ExcavatorBroken();
				}
				if (charactersAndPiont._nameU == "Логово мутантов на свалке")
				{
					Data.point = new MutantBaseDump();
				}
				if (charactersAndPiont._nameU == "Автобусная остановка")
				{
					Data.point = new BusStation();
				}
				if (charactersAndPiont._nameU == "Завод Агропром")
				{
					Data.point = new FactoryAgroprom();
				}
				if (charactersAndPiont._nameU == "Лагерь на болоте")
				{
					Data.point = new CampOnSwamp();
				}
				if (charactersAndPiont._nameU == "Институт Агропром")
				{
					Data.point = new InstituteAgroprom();
				}
				if (charactersAndPiont._nameU == "Болотная тропа")
				{
					Data.point = new WadingTrail();
				}
				if (charactersAndPiont._nameU == "Пещера с аномалиями")
				{
					Data.point = new AnomalyCave();
				}
				if (charactersAndPiont._nameU == "Вентиляционная шахта")
				{
					Data.point = new AirShaft();
				}
				if (charactersAndPiont._nameU == "Логово мутантов на Агропроме")
				{
					Data.point = new MutantAgroprom();
				}
				if (charactersAndPiont._nameU == "Бронетранспортер")
				{
					Data.point = new BTR();
				}
				if (charactersAndPiont._nameU == "Лежка кровососов")
				{
					Data.point = new CampBloodsucker();
				}
				if (charactersAndPiont._nameU == "Бродячие зомби")
				{
					Data.point = new ZombyStation();
				}
				if (charactersAndPiont._nameU == "Переход на янтарь")
				{
					Data.point = new RoadAmber();
				}
				if (charactersAndPiont._nameU == "Дальний блокпост")
				{
					Data.point = new FarBlockpost();
				}
				if (charactersAndPiont._nameU == "Лежка мутантов")
				{
					Data.point = new MutantDarkValley();
				}
				if (charactersAndPiont._nameU == "Ферма")
				{
					Data.point = new FarmDarkValley();
				}
				if (charactersAndPiont._nameU == "АЗС")
				{
					Data.point = new AZS();
				}
				if (charactersAndPiont._nameU == "Аномалия темной долины")
				{
					Data.point = new AnomalyDarkValley();
				}
				if (charactersAndPiont._nameU == "Старый завод")
				{
					Data.point = new OldFactory();
				}
				if (charactersAndPiont._nameU == "Тропинка зомби")
				{
					Data.point = new ZombyTrail();
				}
				if (charactersAndPiont._nameU == "Цеха старой фабрики")
				{
					Data.point = new FactoryShops();
				}
				if (charactersAndPiont._nameU == "Груда камней")
				{
					Data.point = new Stones();
				}
				if (charactersAndPiont._nameU == "Блокпост у фермы")
				{
					Data.point = new BlockpostFarm();
				}
				if (charactersAndPiont._nameU == "Лесная тропа")
				{
					Data.point = new ForestTrail();
				}
				if (charactersAndPiont._nameU == "Собачья тропа")
				{
					Data.point = new DogsTrail();
				}
				if (charactersAndPiont._nameU == "Блокпост Юго-восток")
				{
					Data.point = new BlockpostSouthEast();
				}
				if (charactersAndPiont._nameU == "Насосная станция")
				{
					Data.point = new PumpingStation();
				}
				if (charactersAndPiont._nameU == "База Долга")
				{
					Data.point = new BaseDuty();
				}
				if (charactersAndPiont._nameU == "Блокпост Северо-запад")
				{
					Data.point = new BlockpostNorthWest();
				}
				if (charactersAndPiont._nameU == "Дорога на военные склады")
				{
					Data.point = new RoadMilitary();
				}
				if (charactersAndPiont._nameU == "Старая дорога")
				{
					Data.point = new OldRoad();
				}
				if (charactersAndPiont._nameU == "Привал нетралов" || charactersAndPiont._nameU == "Привал нейтралов")
				{
					Data.point = new HaltNetrals();
				}
				if (charactersAndPiont._nameU == "Нора мутантов")
				{
					Data.point = new HoleMutants();
				}
				if (charactersAndPiont._nameU == "Аномалия Кольцо")
				{
					Data.point = new AnomalyRing();
				}
				if (charactersAndPiont._nameU == "Разбитая дорога")
				{
					Data.point = new BrokenRoad();
				}
				if (charactersAndPiont._nameU == "Путь на Янтарь")
				{
					Data.point = new PathToAmber();
				}
				if (charactersAndPiont._nameU == "Путь на военные склады")
				{
					Data.point = new PathToStorage();
				}
				if (charactersAndPiont._nameU == "Горком КПСС")
				{
					Data.point = new GorkomKPSS();
				}
				if (charactersAndPiont._nameU == "Мертвый хутор")
				{
					Data.point = new DeadFarmstead();
				}
				if (charactersAndPiont._nameU == "Квартал зомби")
				{
					Data.point = new ZombiePark();
				}
				if (charactersAndPiont._nameU == "Березовая роща")
				{
					Data.point = new BirchGrove();
				}
				if (charactersAndPiont._nameU == "Магазин промтовары")
				{
					Data.point = new ShopPromtovari();
				}
				if (charactersAndPiont._nameU == "Аномалия Пустыня")
				{
					Data.point = new AnomalyDesert();
				}
				if (charactersAndPiont._nameU == "Родник")
				{
					Data.point = new Spring();
				}
				if (charactersAndPiont._nameU == "Переход к черной тропе")
				{
					Data.point = new MoveToTheBlackTrail();
				}
				if (charactersAndPiont._nameU == "Хижина сумашедшего сталкера" || charactersAndPiont._nameU == "Хижина сумасшедшего сталкера")
				{
					Data.point = new MadStalker();
				}
				if (charactersAndPiont._nameU == "Штаб военной базы")
				{
					Data.point = new HeadquartersBase();
				}
				if (charactersAndPiont._nameU == "Барьер монолита")
				{
					Data.point = new BarrierMonolith();
				}
				if (charactersAndPiont._nameU == "Упавший вертолет")
				{
					Data.point = new FallenHelicopter();
				}
				if (charactersAndPiont._nameU == "Тропа в рыжий лес")
				{
					Data.point = new TrailRedForest();
				}
				if (charactersAndPiont._nameU == "Блокпост наемников")
				{
					Data.point = new BlockpostMercenary();
				}
				if (charactersAndPiont._nameU == "Тихий хутор")
				{
					Data.point = new QuietCountryside();
				}
				if (charactersAndPiont._nameU == "Дорога между холмами")
				{
					Data.point = new RoadBetweenHills();
				}
				if (charactersAndPiont._nameU == "Привал на плитах")
				{
					Data.point = new HaltOnPlates();
				}
				if (charactersAndPiont._nameU == "Перекресток")
				{
					Data.point = new IntersectionRoad();
				}
				if (charactersAndPiont._nameU == "Водонапорная башня")
				{
					Data.point = new WaterTower();
				}
				if (charactersAndPiont._nameU == "Укрепточка нетралов")
				{
					Data.point = new PointNetrals();
				}
				if (charactersAndPiont._nameU == "Тайная тропа в мертвый город")
				{
					Data.point = new TrailToDeadCity();
				}
				if (charactersAndPiont._nameU == "Дорога через дикую территорию")
				{
					Data.point = new RoadFromWildTerritory();
				}
				if (charactersAndPiont._nameU == "Путь к дикой территории")
				{
					Data.point = new WildTerritory();
				}
				if (charactersAndPiont._nameU == "Бункер ученых")
				{
					Data.point = new BunkerOfScientists();
				}
				if (charactersAndPiont._nameU == "Переход к НИИ Агропром")
				{
					Data.point = new FromAmberToAgroprom();
				}
				if (charactersAndPiont._nameU == "Заводской КПП")
				{
					Data.point = new KPPAmber();
				}
				if (charactersAndPiont._nameU == "Островок на высохшем озере")
				{
					Data.point = new IsletOnLake();
				}
				if (charactersAndPiont._nameU == "Проводник к военным складам")
				{
					Data.point = new guideToMilitary();
				}
				if (charactersAndPiont._nameU == "Проводник к Янтарю")
				{
					Data.point = new GuideToAmber();
				}
				if (charactersAndPiont._nameU == "Завод Янтарь")
				{
					Data.point = new FactoryAmber();
				}
				if (charactersAndPiont._nameU == "Тунель с аномалиями")
				{
					Data.point = new TunnelAnomaly();
				}
				if (charactersAndPiont._nameU == "Дальний рубеж")
				{
					Data.point = new FarFronter();
				}
				if (charactersAndPiont._nameU == "Укрытие в лесу")
				{
					Data.point = new TailInForest();
				}
				if (charactersAndPiont._nameU == "Южный блокпост радара")
				{
					Data.point = new SouthBlockpostRadar();
				}
				if (charactersAndPiont._nameU == "Аномалии")
				{
					Data.point = new AnomalyRadar();
				}
				if (charactersAndPiont._nameU == "Вход в подземный бункер")
				{
					Data.point = new SubBunker();
				}
				if (charactersAndPiont._nameU == "База выжигателя")
				{
					Data.point = new BaseRadar();
				}
				if (charactersAndPiont._nameU == "Мертвый овраг")
				{
					Data.point = new Ravine();
				}
				if (charactersAndPiont._nameU == "Разрушенный НИИ")
				{
					Data.point = new DestroyedInstitut();
				}
				if (charactersAndPiont._nameU == "Сбитый вертолет")
				{
					Data.point = new DestroyedHelicopter();
				}
				if (charactersAndPiont._nameU == "Стоянка на камнях")
				{
					Data.point = new StonesRadar();
				}
				if (charactersAndPiont._nameU == "Лесной привал")
				{
					Data.point = new ForestRadar();
				}
				if (charactersAndPiont._nameU == "Мертвый лес")
				{
					Data.point = new DeadFofest();
				}
				if (charactersAndPiont._nameU == "Старый капер")
				{
					Data.point = new OldCaper();
				}
				if (charactersAndPiont._nameU == "Казармы в шахте")
				{
					Data.point = new BarracksInTheMine();
				}
				if (charactersAndPiont._nameU == "Лихая тропа")
				{
					Data.point = new DashingTrail();
				}
				if (charactersAndPiont._nameU == "Мост в Лиманск")
				{
					Data.point = new BridgeToLimansk();
				}
				if (charactersAndPiont._nameU == "Аномалия Симбиот")
				{
					Data.point = new AnomalySimbiot();
				}
				if (charactersAndPiont._nameU == "Брошенный бункер")
				{
					Data.point = new Abandonedbunker();
				}
				if (charactersAndPiont._nameU == "Аномальная поляна")
				{
					Data.point = new AnomalyGlade();
				}
				if (charactersAndPiont._nameU == "Ведьмин круг")
				{
					Data.point = new WitchCircle();
				}
				if (charactersAndPiont._nameU == "Т-64")
				{
					Data.point = new T64();
				}
				if (charactersAndPiont._nameU == "Деборкадер")
				{
					Data.point = new Deborkader();
				}
				if (charactersAndPiont._nameU == "Блокпост ''Север''")
				{
					Data.point = new CheckpointNorth();
				}
				if (charactersAndPiont._nameU == "Собачья стоянка")
				{
					Data.point = new DogParking();
				}
				if (charactersAndPiont._nameU == "Жарка на дикой территории")
				{
					Data.point = new WildTerritoryFrying();
				}
				if (charactersAndPiont._nameU == "Дорога к Рыжему лесу")
				{
					Data.point = new RoadToTheRedForest();
				}
				if (charactersAndPiont._nameU == "Северный лагерь")
				{
					Data.point = new NorthCamp();
				}
				if (charactersAndPiont._nameU == "Каменная насыпь")
				{
					Data.point = new StoneMound();
				}
				if (charactersAndPiont._nameU == "Старый локомотив")
				{
					Data.point = new OldLocomotive();
				}
				if (charactersAndPiont._nameU == "Вертолет ученых")
				{
					Data.point = new HelicopterScientists();
				}
				if (charactersAndPiont._nameU == "Черная тропа")
				{
					Data.point = new BlackTrail();
				}
				if (charactersAndPiont._nameU == "Лачуга у старого пруда")
				{
					Data.point = new ShackAtTheOldPond();
				}
				if (charactersAndPiont._nameU == "Путепровод")
				{
					Data.point = new Overpass();
				}
				if (charactersAndPiont._nameU == "Заводской цех")
				{
					Data.point = new FactoryFloor();
				}
				if (charactersAndPiont._nameU == "Дорога к озеру")
				{
					Data.point = new RoadToAmber();
				}
				if (charactersAndPiont._nameU == "Дорога к Бару")
				{
					Data.point = new RoadToBar();
				}
				if (charactersAndPiont._nameU == "Железнодорожный перрон")
				{
					Data.point = new RailwayApron();
				}
				if (charactersAndPiont._nameU == "Электра на севере Дикой территории")
				{
					Data.point = new ElectraNorthWildTerritory();
				}
				for (int n = 0; n < 20; n++)
				{
					Data.point.Cache[n].NameSubject = charactersAndPiont._CharBackpack[n];
				}
				Data.Points.Add(Data.point);
			}
		}
		AAAAAAAAAAAAAAAAAAde("AutoSave", true);
	}

	public static void AAAAAAAAAAAAAAAAAAAAcs()
	{
		List<int> list = new List<int>();
		for (int i = 0; i < Data.CharacterD.Count; i++)
		{
			if (Data.CharacterD[i].CurGexChar == Data.CharacterD[Data.CharacterD.Count - 1].CurGexChar && Data.CharacterD[i].NameU != Data.CharacterD[Data.CharacterD.Count - 1].NameU)
			{
				list.Add(i);
			}
		}
		if (list.Count == 1)
		{
			Data.CharacterD[Data.CharacterD.Count - 1].CharUnits.transform.position += new Vector3(-0.3f, 0.2f, 0f);
		}
		if (list.Count == 2)
		{
			Data.CharacterD[Data.CharacterD.Count - 1].CharUnits.transform.position += new Vector3(0.3f, 0.2f, 0f);
		}
		if (list.Count == 3)
		{
			Data.CharacterD[Data.CharacterD.Count - 1].CharUnits.transform.position += new Vector3(0.3f, -0.2f, 0f);
		}
		if (list.Count == 4)
		{
			Data.CharacterD[Data.CharacterD.Count - 1].CharUnits.transform.position += new Vector3(-0.3f, -0.2f, 0f);
		}
		if (list.Count == 5)
		{
			Data.CharacterD[Data.CharacterD.Count - 1].CharUnits.transform.position += new Vector3(0.3f, 0f, 0f);
		}
		if (list.Count == 6)
		{
			Data.CharacterD[Data.CharacterD.Count - 1].CharUnits.transform.position += new Vector3(-0.3f, 0f, 0f);
		}
	}

	public static void AAAAAAAAAAAAAAAAcd(string AAAAAAAAAAAAAAAAce)
	{
		string path = Path.Combine(Application.persistentDataPath, "Cipher" + AAAAAAAAAAAAAAAAce + ".json");
		if (!File.Exists(path))
		{
			if (SceneManager.GetActiveScene().name == "Menu")
			{
				Menu.AAAAAAAAAAAAAAAAca("Слот еще не сохранялся");
			}
			else
			{
				Inventory.MessagePanel("Слот еще не сохранялся");
			}
			return;
		}
		string text = File.ReadAllText(path);
		int length = text.Length;
		byte[] array = new byte[length / 2];
		for (int i = 0; i < length; i += 2)
		{
			array[i / 2] = Convert.ToByte(text.Substring(i, 2), 16);
		}
		text = Encoding.UTF8.GetString(array, 0, array.Length);
		SaveOneMap saveOneMap = JsonUtility.FromJson<SaveOneMap>(text);
		AAAAAAAAAAAAAAAAAAAAAcp(AAAAAAAAAAAAAAAAce, saveOneMap.staS.CurrentScene);
	}
}
