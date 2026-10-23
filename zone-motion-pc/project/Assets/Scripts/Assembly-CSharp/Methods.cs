using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Methods : MonoBehaviour
{
	public static bool GOMessaegeTask;

	public static bool SchemesOfExperimentalWeapons;

	public static bool TaskGlobalchemist10;

	public static void AAAAAAAAAAAAAAAce()
	{
		if (Data.CharacterD[Inventory._currentCharacterNumber].TypeChInt == 1)
		{
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 2]++;
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[2, 0]++;
			if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 2] > 9)
			{
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 2] = 9;
			}
			if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[2, 0] > 9)
			{
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[2, 0] = 9;
			}
		}
		if (Data.CharacterD[Inventory._currentCharacterNumber].TypeChInt == 2)
		{
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 1]++;
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[1, 0]++;
			if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 1] > 9)
			{
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 1] = 9;
			}
			if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[1, 0] > 9)
			{
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[1, 0] = 9;
			}
		}
		if (Data.CharacterD[Inventory._currentCharacterNumber].TypeChInt == 4)
		{
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 6]++;
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[6, 0]++;
			if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 6] > 9)
			{
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 6] = 9;
			}
			if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[6, 0] > 9)
			{
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[6, 0] = 9;
			}
		}
		if (Data.CharacterD[Inventory._currentCharacterNumber].TypeChInt == 6)
		{
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 4]++;
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[4, 0]++;
			if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 4] > 9)
			{
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 4] = 9;
			}
			if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[4, 0] > 9)
			{
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[4, 0] = 9;
			}
		}
		if (Data.CharacterD[Inventory._currentCharacterNumber].TypeChInt == 10)
		{
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 11]++;
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[11, 0]++;
			if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 11] > 9)
			{
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 11] = 9;
			}
			if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[11, 0] > 9)
			{
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[11, 0] = 9;
			}
		}
		if (Data.CharacterD[Inventory._currentCharacterNumber].TypeChInt == 5)
		{
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 7]++;
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[7, 0]++;
			if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 7] > 9)
			{
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 7] = 9;
			}
			if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[7, 0] > 9)
			{
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[7, 0] = 9;
			}
		}
		if (Data.CharacterD[Inventory._currentCharacterNumber].TypeChInt == 7)
		{
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 5]++;
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[5, 0]++;
			if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 5] > 9)
			{
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 5] = 9;
			}
			if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[5, 0] > 9)
			{
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[5, 0] = 9;
			}
		}
	}

	public static void AAAAAAAAAAAAAAcm()
	{
		if (Data.CharacterD[Inventory._currentCharacterNumber].TypeChInt == 9 || (Data.CharacterD[Inventory._currentCharacterNumber].TypeChInt == 10 && Data.CharacterD[Inventory._currentCharacterNumber].SuitChar.NameSubject != "Тряпье зомби"))
		{
			for (int i = 0; i < 20; i++)
			{
				Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[i] = new AAAAAAAAAAAAAAAAAAbi();
			}
		}
		if (Data.CharacterD[Inventory._currentCharacterNumber].TypeChar == AAAAAAAAAAAAAAAAf.TypeCharacter.Плоть)
		{
			Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[1] = new AAAAAAAAAAAAAAAAAAbt();
			Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[2] = new AAAAAAAAAAAAAAAAAbe();
		}
		if (Data.CharacterD[Inventory._currentCharacterNumber].TypeChar == AAAAAAAAAAAAAAAAf.TypeCharacter.Кабан)
		{
			Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[1] = new AAAAAAAAAAAAAAAAAbc();
		}
		if (Data.CharacterD[Inventory._currentCharacterNumber].TypeChar == AAAAAAAAAAAAAAAAf.TypeCharacter.Пес)
		{
			Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[1] = new AAAAAAAAAAAAAAAAAAbu();
		}
		if (Data.CharacterD[Inventory._currentCharacterNumber].TypeChar == AAAAAAAAAAAAAAAAf.TypeCharacter.Псевдособака)
		{
			Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[1] = new AAAAAAAAAAAAAAAAAbd();
		}
		if (Data.CharacterD[Inventory._currentCharacterNumber].TypeChar == AAAAAAAAAAAAAAAAf.TypeCharacter.Снорк)
		{
			Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[1] = new AAAAAAAAAAAAAAbc();
		}
		if (Data.CharacterD[Inventory._currentCharacterNumber].TypeChar == AAAAAAAAAAAAAAAAf.TypeCharacter.Зомби)
		{
			Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[9] = new AAAAAAAAAAAAAAAAAAbv();
		}
		if (Data.CharacterD[Inventory._currentCharacterNumber].TypeChar == AAAAAAAAAAAAAAAAf.TypeCharacter.Кровосос)
		{
			Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[1] = new AAAAAAAAAAAAAAAba();
		}
		if (Data.CharacterD[Inventory._currentCharacterNumber].TypeChar == AAAAAAAAAAAAAAAAf.TypeCharacter.Контролер)
		{
			Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[1] = new AAAAAAAAAAAAAAAAbf();
		}
		if (Data.CharacterD[Inventory._currentCharacterNumber].TypeChInt != 9 && Data.CharacterD[Inventory._currentCharacterNumber].TypeChInt != 10)
		{
			if (!Data.CharacterD[Inventory._currentCharacterNumber].ControlGamer)
			{
				Data.CharacterD[Inventory._currentCharacterNumber].Cash = Random.Range(20, 350);
				Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[8] = new AAAAAAAAAAAAAAAAAAbw();
				if (Data.CharacterD[Inventory._currentCharacterNumber].Cash < 150)
				{
					Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[9] = new AAAAAAAAAAAAAAAAAAAAbo();
				}
				if (Data.CharacterD[Inventory._currentCharacterNumber].WeaponChar.CartridgeType == "9х18 мм")
				{
					Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[10] = new Cartridge9x18();
					Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[10].Stack = Random.Range(12, 50);
				}
				if (Data.CharacterD[Inventory._currentCharacterNumber].WeaponChar.CartridgeType == ".45 АСР")
				{
					Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[10] = new Cartridge45АСР();
					Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[10].Stack = Random.Range(12, 50);
				}
				if (Data.CharacterD[Inventory._currentCharacterNumber].WeaponChar.CartridgeType == "12х70 дробь")
				{
					Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[10] = new Cartridge12x70();
					Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[10].Stack = Random.Range(12, 50);
				}
				if (Data.CharacterD[Inventory._currentCharacterNumber].WeaponChar.CartridgeType == "9х19 мм")
				{
					Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[10] = new Cartridge9x19();
					Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[10].Stack = Random.Range(12, 50);
				}
				if (Data.CharacterD[Inventory._currentCharacterNumber].WeaponChar.CartridgeType == "5,45x39 мм")
				{
					Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[10] = new Cartridge_5_45x39();
					Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[10].Stack = Random.Range(12, 50);
				}
				if (Data.CharacterD[Inventory._currentCharacterNumber].WeaponChar.CartridgeType == "9х39 мм СП-5")
				{
					Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[10] = new Cartridge_9x39_sp5();
					Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[10].Stack = Random.Range(12, 50);
				}
				if (Data.CharacterD[Inventory._currentCharacterNumber].WeaponChar.CartridgeType == "5,56x45 мм")
				{
					Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[10] = new Cartridge_5_56x45();
					Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[10].Stack = Random.Range(12, 50);
				}
				if (Data.CharacterD[Inventory._currentCharacterNumber].WeaponChar.CartridgeType == "7,62x54 мм 7H1")
				{
					Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[10] = new Cartridge_5_56x45();
					Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[10].Stack = Random.Range(12, 40);
				}
				if (Data.CharacterD[Inventory._currentCharacterNumber].WeaponChar.CartridgeType == "Аккумуляторы")
				{
					Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[10] = new Cartridge_5_56x45();
					Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[10].Stack = Random.Range(12, 40);
				}
				if (Data.CharacterD[Inventory._currentCharacterNumber].Skill > 6 && Data.CharacterD[Inventory._currentCharacterNumber].Skill < 11)
				{
					Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[11] = new WaltherP99();
					Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[11].State = Random.Range(12, 80);
					Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[12] = new Cartridge9x19();
					Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[12].Stack = Random.Range(12, 30);
				}
				if (Data.CharacterD[Inventory._currentCharacterNumber].Skill >= 11 && Data.CharacterD[Inventory._currentCharacterNumber].Skill < 15)
				{
					Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[11] = new M1911A1();
					Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[11].State = Random.Range(12, 80);
					Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[12] = new Cartridge45АСР();
					Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[12].Stack = Random.Range(12, 30);
				}
				if (Data.CharacterD[Inventory._currentCharacterNumber].Skill >= 15)
				{
					Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[11] = new USP45Compact();
					Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[11].State = Random.Range(12, 80);
					Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[12] = new Cartridge45АСР();
					Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[12].Stack = Random.Range(12, 30);
				}
			}
		}
		else
		{
			Data.CharacterD[Inventory._currentCharacterNumber].Cash = 0;
		}
	}

	public static void AAAAAAAAAAAAAAAAAAAAAcr()
	{
		if (Data.TaskCurrentCharacter[Inventory._NewTaskNum].GuideQuest)
		{
			Data.TaskCurrentCharacter[Inventory._NewTaskNum].KillCharacterName = Data.CharacterD[Data.TaskCurrentCharacter[Inventory._NewTaskNum].NumberTurgetInData].CharUnits.name;
			Data.CharacterD[Data.TaskCurrentCharacter[Inventory._NewTaskNum].NumberTurgetInData].ControlGamer = true;
			Data.CharacterD[Data.TaskCurrentCharacter[Inventory._NewTaskNum].NumberTurgetInData].Bleeding = 0f;
			Data.CharacterD[Data.TaskCurrentCharacter[Inventory._NewTaskNum].NumberTurgetInData].DiseaseXRay = 0;
			Data.CharacterD[Data.TaskCurrentCharacter[Inventory._NewTaskNum].NumberTurgetInData].CurHealth += 8f;
			Data.CharacterD[Data.TaskCurrentCharacter[Inventory._NewTaskNum].NumberTurgetInData].Satiety = 50;
			Data.CharacterD[Data.TaskCurrentCharacter[Inventory._NewTaskNum].NumberTurgetInData].Thirst = 50;
		}
	}

	public static void AAAAAAAAAAAAAAAAAAAcm()
	{
		for (int i = 0; i < Data.TaskAll.Count; i++)
		{
			if (Data.TaskAll[i].NameTask == "Заказчик на месте")
			{
				Inventory._EmptyTask = Data.TaskAll[i];
				Data.TaskAll[i] = new TaskAdditionalGuide3();
				Data.TaskAll[i].ImageTask = Inventory._EmptyTask.ImageTask;
				Inventory.AAAAAAAAAAAAAAAAAAAAci();
				Inventory._TaskNum = i;
				Inventory._taskText = true;
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(true);
				Inventory._CurtainGUIEquipment.SetActive(false);
				Inventory._CurtainIconCharacterU.SetActive(false);
			}
		}
	}

	public static void AAAAAAAAAAAAAAAAAch()
	{
		for (int i = 0; i < Data.TaskAll.Count; i++)
		{
			if (Data.TaskAll[i].NameTask == Inventory._currentTask.NameTask)
			{
				Data.TaskAll.RemoveAt(i);
			}
		}
		Data.TaskAll.Add(Inventory._currentTask);
		if (Data.TaskAll[Data.TaskAll.Count - 1].GuideQuest)
		{
		}
		if (Data.TaskAll[Data.TaskAll.Count - 1].CaptureQuest)
		{
		}
		if (Data.TaskAll[Data.TaskAll.Count - 1].KillQuest || Data.TaskAll[Data.TaskAll.Count - 1].BalansQuest || Data.TaskAll[Data.TaskAll.Count - 1].SubjectQuest)
		{
			Data.TaskAll[Data.TaskAll.Count - 1].NamePointTask = Data.Points[Inventory._CurrentPoint[0]].namePoint;
		}
		Data.TaskAll[Data.TaskAll.Count - 1].NumberDealer = Data.Points[Inventory._CurrentPoint[0]].ControlInt;
		Data.TaskAll[Data.TaskAll.Count - 1].NumberEnemy = Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].Enemy0;
		Data.TaskAll[Data.TaskAll.Count - 1].MapName = SceneManager.GetActiveScene().name;
		if (Data.TaskAll[Data.TaskAll.Count - 1].NameTask == "Принести Схемы Выжигателя")
		{
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 1] = 0;
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 2] = 0;
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 3] = 0;
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 4] = 0;
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 5] = 0;
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 6] = 0;
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 7] = 0;
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 8] = 2;
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 9] = 2;
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 10] = 2;
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 11] = 0;
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[1, 0] = 0;
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[2, 0] = 0;
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[3, 0] = 0;
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[4, 0] = 0;
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[5, 0] = 0;
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[6, 0] = 0;
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[7, 0] = 0;
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[8, 0] = 2;
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[9, 0] = 2;
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[10, 0] = 2;
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[11, 0] = 0;
			Inventory.AAAAAAAAAAAAAAAAbt();
		}
		if (Data.TaskAll[Data.TaskAll.Count - 1].NameTask == "Найти отряд разведчиков")
		{
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.Points[Inventory._CurrentPoint[0]].ControlInt]++;
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.Points[Inventory._CurrentPoint[0]].ControlInt, 0]++;
			if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.Points[Inventory._CurrentPoint[0]].ControlInt] > 9)
			{
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.Points[Inventory._CurrentPoint[0]].ControlInt] = 9;
			}
			if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.Points[Inventory._CurrentPoint[0]].ControlInt, 0] > 9)
			{
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.Points[Inventory._CurrentPoint[0]].ControlInt, 0] = 9;
			}
		}
	}

	public static void AAAAAAAAAAAAAAAAAAAAAcs()
	{
		if (CharacterMotion._curCharacter != 0 || Inventory._CurrentPoint.Count <= 0)
		{
			return;
		}
		Data.TaskCurrentCharacter.Clear();
		if (Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == Data.Points[Inventory._CurrentPoint[0]].ControlInt && Data.Points[Inventory._CurrentPoint[0]].ControlInt != 9 && Data.Points[Inventory._CurrentPoint[0]].ControlInt != 10)
		{
			foreach (ConstructorPoints point in Data.Points)
			{
				if ((point.pointTypes == ConstructorPoints.PointTypes.Construction && point.ControlInt != Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].Enemy0 && Data.Points[Inventory._CurrentPoint[0]].ControlInt != point.ControlInt) || (point.pointTypes == ConstructorPoints.PointTypes.Field && point.ControlInt != Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].Enemy0 && Data.Points[Inventory._CurrentPoint[0]].ControlInt != point.ControlInt))
				{
					Data.TaskCurrentCharacter.Add(new TaskAdditionalCapturePoint0());
					Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].NamePointTask = point.namePoint;
					Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].ImageTask = Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].ImageChar;
					Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].MapName = SceneManager.GetActiveScene().name;
					Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].GroupName = Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].NameGroup;
					break;
				}
				if (point.ControlInt != 0 && point.ControlInt == Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].Enemy0)
				{
					Data.TaskCurrentCharacter.Add(new TaskAdditionalCaptureEnemyPoint0());
					Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].NamePointTask = point.namePoint;
					Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].ImageTask = Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].ImageChar;
					Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].MapName = SceneManager.GetActiveScene().name;
					Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].GroupName = Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].NameGroup;
					break;
				}
			}
		}
		for (int i = 0; i < 20; i++)
		{
			if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].NameSubject == "Схемы экспериментального оружия")
			{
				Data.TaskCurrentCharacter.Add(new TaskAdditionalSchemesOfExperimentalWeapons());
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].NamePointTask = Data.Points[Inventory._CurrentPoint[0]].namePoint;
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].ImageTask = Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].ImageChar;
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].MapName = SceneManager.GetActiveScene().name;
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].QuestSubject = new AAAAAAAAAAAAAAAAAAAbi();
				break;
			}
		}
		if (Data.Points[Inventory._CurrentPoint[0]].ControlInt == 7 && CharacterMotion._curCharacter == 0 && AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 7] >= 1)
		{
			bool flag = false;
			foreach (string item in Data.OldTask)
			{
				if (item == "Найти информацию об экспериментах")
				{
					flag = true;
					break;
				}
			}
			foreach (ConstructorTasks item2 in Data.TaskAll)
			{
				if (item2.NameTask == "Найти информацию об экспериментах")
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				Data.TaskCurrentCharacter.Add(new TaskAdditionalВocumentation());
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].NamePointTask = Data.Points[Inventory._CurrentPoint[0]].namePoint;
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].MapName = SceneManager.GetActiveScene().name;
				AAAAAAAAAAAAAAAcf();
			}
		}
		if (Data.Points[Inventory._CurrentPoint[0]].ControlInt == 3)
		{
			bool flag2 = false;
			foreach (string item3 in Data.OldTask)
			{
				if (item3 == "Найти отряд разведчиков")
				{
					flag2 = true;
					break;
				}
			}
			if (!flag2 && CharacterMotion._curCharacter == 0)
			{
				Data.TaskCurrentCharacter.Add(new TaskAdditionalScoutReport());
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].NamePointTask = Data.Points[Inventory._CurrentPoint[0]].namePoint;
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].ImageTask = Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].ImageChar;
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].MapName = SceneManager.GetActiveScene().name;
			}
			bool flag3 = false;
			foreach (string item4 in Data.OldTask)
			{
				if (item4 == "Принести съедобные припасы")
				{
					flag3 = true;
					break;
				}
			}
			if (!flag3 && flag2 && CharacterMotion._curCharacter == 0)
			{
				Data.TaskCurrentCharacter.Add(new TaskAdditionalArmFood());
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].NamePointTask = Data.Points[Inventory._CurrentPoint[0]].namePoint;
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].ImageTask = Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].ImageChar;
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].MapName = SceneManager.GetActiveScene().name;
			}
		}
		if (Data.Points[Inventory._CurrentPoint[0]].ControlInt == 4)
		{
			bool flag4 = false;
			foreach (string item5 in Data.OldTask)
			{
				if (item5 == "Разведка на насосной станции")
				{
					flag4 = true;
					break;
				}
			}
			if (!flag4 && CharacterMotion._curCharacter == 0)
			{
				Data.TaskCurrentCharacter.Add(new TaskAdditionalDutyKillBloodsuсker());
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].NamePointTask = Data.Points[Inventory._CurrentPoint[0]].namePoint;
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].MapName = SceneManager.GetActiveScene().name;
			}
		}
		if (Data.Points[Inventory._CurrentPoint[0]].ControlInt == 8)
		{
			if (Data.CharacterD[0].TypeChInt != 8 && CharacterMotion._curCharacter == 0 && AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 8] == 0)
			{
				Debug.Log(Data.CharacterD[0].TypeChInt);
				Data.TaskCurrentCharacter.Add(new TaskAdditionalEmptyMonolith());
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].NamePointTask = Data.Points[Inventory._CurrentPoint[0]].namePoint;
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].ImageTask = Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].ImageChar;
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].MapName = SceneManager.GetActiveScene().name;
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].QuestSubject = new AAAAAAAAAAAAAAAAbg();
			}
			if (Data.CharacterD[0].TypeChInt == 8 && CharacterMotion._curCharacter == 0 && AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 8] == 3)
			{
				Debug.Log(Data.CharacterD[0].TypeChInt);
				Data.TaskCurrentCharacter.Add(new TaskAdditionalDecoderMonolith());
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].NamePointTask = Data.Points[Inventory._CurrentPoint[0]].namePoint;
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].ImageTask = Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].ImageChar;
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].MapName = SceneManager.GetActiveScene().name;
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].QuestSubject = new AAAAAAAAAAAAAAAAAAAAbq();
			}
		}
		if (Data.Points[Inventory._CurrentPoint[0]].ControlInt == 2)
		{
			if (Data.CharacterD[0].TypeChInt != 2 && CharacterMotion._curCharacter == 0 && AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 2] == 0)
			{
				Data.TaskCurrentCharacter.Add(new TaskAdditionalFindDinamit());
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].NamePointTask = Data.Points[Inventory._CurrentPoint[0]].namePoint;
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].ImageTask = Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].ImageChar;
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].MapName = SceneManager.GetActiveScene().name;
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].QuestSubject = new AAAAAAAAAAAAAAAAAAcb();
			}
			if (Data.CharacterD[0].TypeChInt != 2 && CharacterMotion._curCharacter == 0 && AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 2] == 1)
			{
				Debug.Log(Data.CharacterD[0].TypeChInt);
				Data.TaskCurrentCharacter.Add(new TaskAdditionalFindWeaponBox());
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].NamePointTask = Data.Points[Inventory._CurrentPoint[0]].namePoint;
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].ImageTask = Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].ImageChar;
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].MapName = SceneManager.GetActiveScene().name;
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].QuestSubject = new AAAAAAAAAAAAAAAAAAAbh();
			}
			if (Data.CharacterD[0].TypeChInt != 2 && CharacterMotion._curCharacter == 0 && AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 2] == 2)
			{
				Debug.Log(Data.CharacterD[0].TypeChInt);
				Data.TaskCurrentCharacter.Add(new TaskAdditionalFindSuitBox());
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].NamePointTask = Data.Points[Inventory._CurrentPoint[0]].namePoint;
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].ImageTask = Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].ImageChar;
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].MapName = SceneManager.GetActiveScene().name;
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].QuestSubject = new AAAAAAAAAAAAAAAAAAAAAbr();
			}
			if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAcd[Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].Enemy0] > 1 && CharacterMotion._curCharacter == 0 && AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 2] == 3 && Data.Points[Inventory._CurrentPoint[0]].ControlInt > 0)
			{
				Debug.Log(Data.Points[Inventory._CurrentPoint[0]].ControlInt);
				Data.TaskCurrentCharacter.Add(new TaskAdditionalBalans0());
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].NamePointTask = Data.Points[Inventory._CurrentPoint[0]].namePoint;
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].MapName = SceneManager.GetActiveScene().name;
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].GroupName = Data.Dealers[Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].Enemy0].NameGroup;
			}
		}
		if (Data.Points[Inventory._CurrentPoint[0]].ControlInt == 1)
		{
			bool flag5 = false;
			foreach (string item6 in Data.OldTask)
			{
				if (item6 == "Спасти новичка")
				{
					flag5 = true;
					break;
				}
			}
			if (!flag5 && SceneManager.GetActiveScene().name == "Kordon")
			{
				Data.TaskCurrentCharacter.Add(new TaskAdditionalSaveNovice());
			}
			bool flag6 = false;
			foreach (string item7 in Data.OldTask)
			{
				if (item7 == "Найти кольт")
				{
					flag6 = true;
					break;
				}
			}
			if (!flag6)
			{
				Data.TaskCurrentCharacter.Add(new TaskAdditionalColt());
			}
			bool flag7 = false;
			foreach (string item8 in Data.OldTask)
			{
				if (item8 == "Найти Следопыта")
				{
					flag7 = true;
					break;
				}
			}
			if (!flag7 && SceneManager.GetActiveScene().name != "Kordon")
			{
				Data.TaskCurrentCharacter.Add(new TaskAdditionalquestPathfinder0());
			}
			bool flag8 = false;
			foreach (string item9 in Data.OldTask)
			{
				if (item9 == "Разведать планы военных")
				{
					flag8 = true;
					break;
				}
			}
			if (!flag8 && SceneManager.GetActiveScene().name != "Kordon" && SceneManager.GetActiveScene().name != "Dump")
			{
				Data.TaskCurrentCharacter.Add(new TaskAdditionalOperationPlan());
			}
			bool flag9 = false;
			foreach (string item10 in Data.OldTask)
			{
				if (item10 == "Найти награбленный хабар")
				{
					flag9 = true;
					break;
				}
			}
			if ((!flag9 && SceneManager.GetActiveScene().name == "Agroprom") || SceneManager.GetActiveScene().name == "Amber")
			{
				Data.TaskCurrentCharacter.Add(new TaskAdditionalReturnBearMod());
			}
		}
		if (Data.Points[Inventory._CurrentPoint[0]].ControlInt == 5)
		{
			if (CharacterMotion._curCharacter == 0)
			{
				bool flag10 = false;
				foreach (string item11 in Data.OldTask)
				{
					if (item11 == "Найти детали")
					{
						flag10 = true;
						break;
					}
				}
				if (!flag10)
				{
					Data.TaskCurrentCharacter.Add(new TaskAdditionalSpareParts());
					Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].NamePointTask = Data.Points[Inventory._CurrentPoint[0]].namePoint;
					Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].MapName = SceneManager.GetActiveScene().name;
				}
			}
			bool flag11 = false;
			foreach (string item12 in Data.OldTask)
			{
				if (item12 == "Найти детали")
				{
					flag11 = true;
					break;
				}
			}
			bool flag12 = false;
			foreach (string item13 in Data.OldTask)
			{
				if (item13 == "Схемы для наемников")
				{
					flag12 = true;
					break;
				}
			}
			if (flag11 && !flag12)
			{
				Data.TaskCurrentCharacter.Add(new TaskAdditionalMercenarySchemeOfBurner0());
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].NamePointTask = Data.Points[Inventory._CurrentPoint[0]].namePoint;
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].MapName = SceneManager.GetActiveScene().name;
			}
			bool flag13 = false;
			foreach (string item14 in Data.OldTask)
			{
				if (item14 == "Найти детали")
				{
					flag13 = true;
					break;
				}
			}
			bool flag14 = false;
			foreach (string item15 in Data.OldTask)
			{
				if (item15 == "Вернуть детектор")
				{
					flag14 = true;
					break;
				}
			}
			if (flag13 && !flag14)
			{
				Data.TaskCurrentCharacter.Add(new TaskAdditionalMercenaryLifeDetector());
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].NamePointTask = Data.Points[Inventory._CurrentPoint[0]].namePoint;
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].MapName = SceneManager.GetActiveScene().name;
			}
			bool flag15 = false;
			foreach (string item16 in Data.OldTask)
			{
				if (item16 == "Вернуть детектор")
				{
					flag15 = true;
					break;
				}
			}
			bool flag16 = false;
			foreach (string item17 in Data.OldTask)
			{
				if (item17 == "Пропавший отряд")
				{
					flag16 = true;
					break;
				}
			}
			if (flag15 && !flag16)
			{
				Data.TaskCurrentCharacter.Add(new TaskAdditionalMercenaryGroup());
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].NamePointTask = Data.Points[Inventory._CurrentPoint[0]].namePoint;
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].MapName = SceneManager.GetActiveScene().name;
			}
		}
		if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAcd[Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].Enemy0] > 1 && Data.Points[Inventory._CurrentPoint[0]].ControlInt != 2 && Data.Points[Inventory._CurrentPoint[0]].ControlInt > 0)
		{
			Data.TaskCurrentCharacter.Add(new TaskAdditionalBalans0());
			Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].NamePointTask = Data.Points[Inventory._CurrentPoint[0]].namePoint;
			Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].MapName = SceneManager.GetActiveScene().name;
			Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].GroupName = Data.Dealers[Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].Enemy0].NameGroup;
		}
		if (Data.Points[Inventory._CurrentPoint[0]].ControlInt != 3 && Data.Points[Inventory._CurrentPoint[0]].ControlInt != 8 && Data.Points[Inventory._CurrentPoint[0]].ControlInt != 2)
		{
			if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.Points[Inventory._CurrentPoint[0]].ControlInt, 0] > 0)
			{
				Data.TaskCurrentCharacter.Add(new TaskAdditionalEmptySubj1());
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].ImageTask = Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].ImageChar;
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].QuestSubject = Data.Artefacts[Random.Range(0, Data.Artefacts.Count - 1)];
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].NamePointTask = Data.Points[Inventory._CurrentPoint[0]].namePoint;
				for (int j = 0; j < 20; j++)
				{
					if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[j].NameSubject == Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].QuestSubject.NameSubject)
					{
						Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].QuestSubject = Data.Artefacts[Random.Range(0, Data.Artefacts.Count - 1)];
						break;
					}
				}
				if (Data.Points[Inventory._CurrentPoint[0]].ControlInt != 0)
				{
					for (int k = 0; k < 20; k++)
					{
						if (Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].Product[AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.Points[Inventory._CurrentPoint[0]].ControlInt], k] != null && Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].Product[AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.Points[Inventory._CurrentPoint[0]].ControlInt], k].NameSubject == Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].QuestSubject.NameSubject)
						{
							Debug.Log(Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].QuestSubject.NameSubject);
							Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].Product[AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.Points[Inventory._CurrentPoint[0]].ControlInt], k] = Data.Artefacts[Random.Range(0, Data.Artefacts.Count - 1)];
						}
					}
				}
			}
			if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.Points[Inventory._CurrentPoint[0]].ControlInt, 0] > 1)
			{
				Data.TaskCurrentCharacter.Add(new TaskAdditionalEmptyWeapon1());
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].ImageTask = Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].ImageChar;
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].QuestSubject = Data.Weapons[Random.Range(0, Data.Weapons.Count)];
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].NamePointTask = Data.Points[Inventory._CurrentPoint[0]].namePoint;
				for (int l = 0; l < 20; l++)
				{
					if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[l].NameSubject == Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].QuestSubject.NameSubject)
					{
						Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].QuestSubject = Data.Weapons[Random.Range(0, Data.Weapons.Count)];
						break;
					}
				}
				if (Data.Points[Inventory._CurrentPoint[0]].ControlInt != 0)
				{
					for (int m = 0; m < 25; m++)
					{
						if (Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].Product[AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.Points[Inventory._CurrentPoint[0]].ControlInt], m] != null && Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].Product[AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.Points[Inventory._CurrentPoint[0]].ControlInt], m].NameSubject == Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].QuestSubject.NameSubject)
						{
							Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].Product[AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.Points[Inventory._CurrentPoint[0]].ControlInt], m] = Data.Weapons[Random.Range(0, Data.Weapons.Count - 1)];
						}
					}
				}
				if (Data.Points[Inventory._CurrentPoint[0]].ControlInt != 0)
				{
					for (int n = 0; n < 20; n++)
					{
						if (Data.Points[Inventory._CurrentPoint[0]].Cache[n].NameSubject == Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].QuestSubject.NameSubject)
						{
							Debug.Log("Remove " + Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].QuestSubject.NameSubject);
							Data.TaskCurrentCharacter.RemoveAt(Data.TaskCurrentCharacter.Count - 1);
							break;
						}
					}
				}
			}
			if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.Points[Inventory._CurrentPoint[0]].ControlInt, 0] > 2 && CharacterMotion._curCharacter == 0)
			{
				for (int num = 0; num < Data.CharacterD.Count; num++)
				{
					if (Data.CharacterD[num].TypeChInt != Data.Points[Inventory._CurrentPoint[0]].ControlInt || !Data.CharacterD[num].Life || Data.CharacterD[num].ControlGamer)
					{
						continue;
					}
					Data.TaskCurrentCharacter.Add(new TaskAdditionalGuide1());
					Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].NumberTurgetInData = num;
					Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].KillCharacterName = Data.CharacterD[num].CharUnits.name;
					Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].ImageTask = Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].ImageChar;
					Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].MapName = SceneManager.GetActiveScene().name;
					float num2 = 0f;
					for (int num3 = 0; num3 < Data.Points.Count; num3++)
					{
						if (Vector3.Distance(Data.Points[num3].curGexPoint.GexGO.transform.position, Data.CharacterD[num].CurGexChar.GexGO.transform.position) >= num2)
						{
							num2 = Vector3.Distance(Data.Points[num3].curGexPoint.GexGO.transform.position, Data.CharacterD[num].CurGexChar.GexGO.transform.position);
							Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].NumberPointOfGuide = num3;
							Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].NamePointTask = Data.Points[Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].NumberPointOfGuide].namePoint;
						}
					}
					if (num2 > 0f)
					{
						break;
					}
				}
			}
			if (Data.Points[Inventory._CurrentPoint[0]].ControlInt == 11 && AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAcd[Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].Enemy0] > 0)
			{
				bool flag17 = false;
				for (int num4 = 0; num4 < 20; num4++)
				{
					if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num4].TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.MutantsSubject)
					{
						flag17 = true;
						break;
					}
					if (Data.Points[Inventory._CurrentPoint[0]].Cache[num4].TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.MutantsSubject)
					{
						flag17 = true;
						break;
					}
				}
				if (!flag17)
				{
					Data.TaskCurrentCharacter.Add(new TaskAdditionalEmptyMutantPart());
					Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].ImageTask = Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].ImageChar;
					Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].QuestSubject = Data.PartsOfMutants[Random.Range(0, Data.PartsOfMutants.Count - 1)];
					Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].NamePointTask = Data.Points[Inventory._CurrentPoint[0]].namePoint;
				}
			}
			if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.Points[Inventory._CurrentPoint[0]].ControlInt, 0] > 3)
			{
				Data.TaskCurrentCharacter.Add(new TaskAdditionalEmptySuit1());
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].ImageTask = Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].ImageChar;
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].QuestSubject = Data.Suits[Random.Range(0, Data.Suits.Count - 1)];
				Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].NamePointTask = Data.Points[Inventory._CurrentPoint[0]].namePoint;
				for (int num5 = 0; num5 < 20; num5++)
				{
					if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num5].NameSubject == Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].QuestSubject.NameSubject)
					{
						Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].QuestSubject = Data.Suits[Random.Range(0, Data.Suits.Count - 1)];
						break;
					}
				}
				if (Data.Points[Inventory._CurrentPoint[0]].ControlInt != 0)
				{
					for (int num6 = 0; num6 < 25; num6++)
					{
						if (Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].Product[AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.Points[Inventory._CurrentPoint[0]].ControlInt], num6] != null && Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].Product[AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.Points[Inventory._CurrentPoint[0]].ControlInt], num6].NameSubject == Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].QuestSubject.NameSubject)
						{
							Debug.Log(Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].QuestSubject.NameSubject);
							Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].Product[AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.Points[Inventory._CurrentPoint[0]].ControlInt], num6] = Data.Suits[Random.Range(0, Data.Suits.Count - 1)];
						}
					}
				}
				if (Data.Points[Inventory._CurrentPoint[0]].ControlInt != 0)
				{
					for (int num7 = 0; num7 < 20; num7++)
					{
						if (Data.Points[Inventory._CurrentPoint[0]].Cache[num7].NameSubject == Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].QuestSubject.NameSubject)
						{
							Debug.Log("Remove " + Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].QuestSubject.NameSubject);
							Data.TaskCurrentCharacter.RemoveAt(Data.TaskCurrentCharacter.Count - 1);
							break;
						}
					}
				}
			}
			if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.Points[Inventory._CurrentPoint[0]].ControlInt, 0] > 4)
			{
				for (int num8 = 0; num8 < Data.CharacterD.Count; num8++)
				{
					if (Data.CharacterD[num8].TypeChInt == Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].Enemy0 && Data.CharacterD[num8].Life)
					{
						Data.TaskCurrentCharacter.Add(new TaskAdditionalKiller1());
						Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].ImageTask = Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].ImageChar;
						Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].KillCharacterName = Data.CharacterD[num8].CharUnits.name;
						Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].NumberTurgetInData = num8;
						break;
					}
				}
				if (Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].NameTask != "Ликвидатор")
				{
					for (int num9 = 0; num9 < Data.CharacterD.Count; num9++)
					{
						if (Data.CharacterD[num9].TypeChInt == Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].Enemy0 && Data.CharacterD[num9].Life)
						{
							Data.TaskCurrentCharacter.Add(new TaskAdditionalKiller1());
							Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].ImageTask = Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].ImageChar;
							Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].KillCharacterName = Data.CharacterD[num9].CharUnits.name;
							Data.TaskCurrentCharacter[Data.TaskCurrentCharacter.Count - 1].NumberTurgetInData = num9;
							break;
						}
					}
				}
			}
		}
		for (int num10 = 0; num10 < Data.TaskAll.Count; num10++)
		{
			for (int num11 = 0; num11 < Data.TaskCurrentCharacter.Count; num11++)
			{
				if (Data.TaskAll[num10].NameTask == Data.TaskCurrentCharacter[num11].NameTask)
				{
					Data.TaskCurrentCharacter.RemoveAt(num11);
				}
			}
		}
		if (Data.TaskCurrentCharacter.Count < 1)
		{
			Data.TaskCurrentCharacter.Clear();
			Data.TaskCurrentCharacter.Add(new NoneJob());
		}
	}

	public static void AAAAAAAAAAAAAAbp()
	{
		for (int i = 0; i < Data.TaskAll.Count; i++)
		{
			if (Data.TaskAll[i].NameTask == "Награда за поддержку" && Data.TaskAll[i].NamePointTask == Data.Points[Inventory._CurrentPoint[0]].namePoint)
			{
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Inventory._EmptyTask = new TaskAdditionalBalans2();
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 3000;
				Inventory.AAAAAAAAAAAAAAAAAAAAAci(Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].ImageChar, Inventory._EmptyTask.TextTask);
				Inventory._PointInf = false;
				Inventory._capture = false;
				Inventory._CurtainInventory.SetActive(false);
				Inventory._CurtainGUIEquipment.SetActive(true);
				Inventory._CurtainIconCharacterU.SetActive(true);
				GameObject gameObject = GameObject.Find("MessaegeTask");
				float num = Screen.width;
				num /= 1280f;
				GameObject gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
				gameObject2.transform.SetParent(gameObject.transform.GetChild(5).transform.GetChild(0));
				gameObject2.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/balans");
				gameObject2.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
				gameObject2.transform.GetChild(1).GetComponent<Text>().text = "Выполнено задание: Получить награду за зачистку";
				Transform obj = gameObject2.transform;
				Vector3 localScale = new Vector3(1f, 1f);
				gameObject2.transform.localScale = localScale;
				obj.localScale = localScale;
				gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
				gameObject2.transform.SetParent(gameObject.transform.GetChild(5).transform.GetChild(0));
				gameObject2.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/Subject/Money");
				gameObject2.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
				gameObject2.transform.GetChild(1).GetComponent<Text>().text = "Получены деньги: 3000 ru";
				Transform obj2 = gameObject2.transform;
				localScale = new Vector3(1f, 1f);
				gameObject2.transform.localScale = localScale;
				obj2.localScale = localScale;
				if (Data.Points[Inventory._CurrentPoint[0]].DealerInt == 11)
				{
					GPSscript.AAAAAAAAAAAAAAAAAi("CgkI2OGbhtMLEAIQCg", 1);
				}
				Inventory._TaskNum = 0;
				Data.TaskAll.RemoveAt(i);
				break;
			}
			if (Data.TaskAll[i].NameTask == "Награда ЧН" && Data.Points[Inventory._CurrentPoint[0]].namePoint == "Тихий хутор")
			{
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Inventory._EmptyTask = Data.TaskAll[i];
				Data.TaskAll[i] = new TaskAdditional5();
				Data.TaskAll[i].KillCharacterName = Inventory._EmptyTask.KillCharacterName;
				Data.TaskAll[i].NamePointTask = Inventory._EmptyTask.NamePointTask;
				Data.TaskAll[i].ImageTask = Inventory._EmptyTask.ImageTask;
				Data.TaskAll[i].NumberDealer = Inventory._EmptyTask.NumberDealer;
				Data.TaskAll[i].NumberEnemy = Inventory._EmptyTask.NumberEnemy;
				Data.TaskAll[i].MapName = Inventory._EmptyTask.MapName;
				Inventory.AAAAAAAAAAAAAAAAAAAAci();
				Inventory._TaskNum = i;
				Inventory._taskText = true;
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(true);
				Inventory._CurtainGUIEquipment.SetActive(false);
				Inventory._CurtainIconCharacterU.SetActive(false);
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.Points[Inventory._CurrentPoint[0]].ControlInt]++;
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.Points[Inventory._CurrentPoint[0]].ControlInt, 0]++;
				if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.Points[Inventory._CurrentPoint[0]].ControlInt] > 9)
				{
					AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.Points[Inventory._CurrentPoint[0]].ControlInt] = 9;
				}
				if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.Points[Inventory._CurrentPoint[0]].ControlInt, 0] > 9)
				{
					AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.Points[Inventory._CurrentPoint[0]].ControlInt, 0] = 9;
				}
				break;
			}
			if (Data.TaskAll[i].NameTask == "Добыть схемы оружия" && Data.TaskAll[i].NamePointTask == Data.Points[Inventory._CurrentPoint[0]].namePoint)
			{
				for (int j = 0; j < 20; j++)
				{
					if (!(Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[j].NameSubject == "Схемы экспериментального оружия"))
					{
						continue;
					}
					Inventory.SoundMenu.clip = Inventory.effectNews;
					Inventory.SoundMenu.Play();
					Data.TaskAll[i] = new TaskAdditionalSchemesOfExperimentalWeapons1();
					Data.TaskAll[i].ImageTask = Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].ImageChar;
					Inventory._QuestSubject = Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[j];
					Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[j] = new AAAAAAAAAAAAAAAAAAbi();
					Inventory.AAAAAAAAAAAAAAAAAAAAci();
					Inventory._TaskNum = i;
					Inventory._taskText = true;
					Inventory._Equipment = false;
					Inventory._CurtainInventory.SetActive(true);
					Inventory._CurtainGUIEquipment.SetActive(false);
					Inventory._CurtainIconCharacterU.SetActive(false);
					if (!SchemesOfExperimentalWeapons)
					{
						if (Data.Points[Inventory._CurrentPoint[0]].DealerInt == 11)
						{
							GPSscript.AAAAAAAAAAAAAAAAAi("CgkI2OGbhtMLEAIQCg", 5);
						}
						else
						{
							AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.Points[Inventory._CurrentPoint[0]].ControlInt] = 9;
						}
						SchemesOfExperimentalWeapons = true;
					}
					return;
				}
			}
			if ((Data.TaskAll[i].NameTask == "Достать артефакт" || Data.TaskAll[i].NameTask == "Достать оружие" || Data.TaskAll[i].NameTask == "Достать комбинезон" || Data.TaskAll[i].NameTask == "Принести часть тела мутанта") && Data.TaskAll[i].NamePointTask == Data.Points[Inventory._CurrentPoint[0]].namePoint)
			{
				for (int k = 0; k < 20; k++)
				{
					if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[k].NameSubject == Data.TaskAll[i].QuestSubject.NameSubject)
					{
						Inventory.SoundMenu.clip = Inventory.effectNews;
						Inventory.SoundMenu.Play();
						Data.TaskAll[i] = new TaskAdditionalEmptySubj2();
						Data.TaskAll[i].ImageTask = Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].ImageChar;
						Data.TaskAll[i].RewardMoney = Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[k].CostSubject * 3 / 2;
						if (Data.Points[Inventory._CurrentPoint[0]].ControlInt == 11 && Data.TaskAll[i].NameTask == "Принести часть тела мутанта")
						{
							Data.TaskAll[i].RewardMoney = Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[k].CostSubject * 2;
						}
						Inventory._QuestSubject = Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[k];
						if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[k].Stack > 1)
						{
							Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[k].Stack--;
						}
						else
						{
							Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[k] = new AAAAAAAAAAAAAAAAAAbi();
						}
						k = 20;
						Inventory.AAAAAAAAAAAAAAAAAAAAci();
						Inventory._TaskNum = i;
						Inventory._taskText = true;
						Inventory._Equipment = false;
						Inventory._CurtainInventory.SetActive(true);
						Inventory._CurtainGUIEquipment.SetActive(false);
						Inventory._CurtainIconCharacterU.SetActive(false);
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.Points[Inventory._CurrentPoint[0]].ControlInt]++;
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.Points[Inventory._CurrentPoint[0]].ControlInt, 0]++;
						if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.Points[Inventory._CurrentPoint[0]].ControlInt] > 9)
						{
							AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.Points[Inventory._CurrentPoint[0]].ControlInt] = 9;
						}
						if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.Points[Inventory._CurrentPoint[0]].ControlInt, 0] > 9)
						{
							AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.Points[Inventory._CurrentPoint[0]].ControlInt, 0] = 9;
						}
						if (Data.Points[Inventory._CurrentPoint[0]].DealerInt == 11)
						{
							GPSscript.AAAAAAAAAAAAAAAAAi("CgkI2OGbhtMLEAIQCg", 1);
						}
						if (Data.Points[Inventory._CurrentPoint[0]].DealerInt == 3)
						{
							GPSscript.AAAAAAAAAAAAAAAAAi("CgkI2OGbhtMLEAIQDA", 1);
						}
						return;
					}
				}
			}
			if (Data.TaskAll[i].NameTask == "Объект уничтожен" && Data.Points[Inventory._CurrentPoint[0]].namePoint == Data.TaskAll[i].NamePointTask)
			{
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Data.TaskAll[i] = new TaskAdditionalKiller3();
				Data.TaskAll[i].ImageTask = Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].ImageChar;
				Inventory.AAAAAAAAAAAAAAAAAAAAci();
				Inventory._TaskNum = i;
				Inventory._taskText = true;
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(true);
				Inventory._CurtainGUIEquipment.SetActive(false);
				Inventory._CurtainIconCharacterU.SetActive(false);
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.Points[Inventory._CurrentPoint[0]].ControlInt]++;
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.Points[Inventory._CurrentPoint[0]].ControlInt, 0]++;
				if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.Points[Inventory._CurrentPoint[0]].ControlInt] > 9)
				{
					AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.Points[Inventory._CurrentPoint[0]].ControlInt] = 9;
				}
				if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.Points[Inventory._CurrentPoint[0]].ControlInt, 0] > 9)
				{
					AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.Points[Inventory._CurrentPoint[0]].ControlInt, 0] = 9;
				}
				if (Data.Points[Inventory._CurrentPoint[0]].DealerInt == 11)
				{
					GPSscript.AAAAAAAAAAAAAAAAAi("CgkI2OGbhtMLEAIQCg", 1);
				}
				break;
			}
			if (Data.TaskAll[i].NameTask == "Провал задания группировки" && Data.Points[Inventory._CurrentPoint[0]].namePoint == Data.TaskAll[i].NamePointTask)
			{
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Inventory._EmptyTask = new TaskAdditionalBalansFail0();
				Inventory.AAAAAAAAAAAAAAAAAAAAAci(Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].ImageChar, Inventory._EmptyTask.TextTask);
				Inventory._PointInf = false;
				Inventory._capture = false;
				Inventory._CurtainInventory.SetActive(false);
				Inventory._CurtainGUIEquipment.SetActive(true);
				Inventory._CurtainIconCharacterU.SetActive(true);
				GameObject gameObject3 = GameObject.Find("MessaegeTask");
				float num2 = Screen.width;
				num2 /= 1280f;
				GameObject gameObject4 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
				gameObject4.transform.SetParent(gameObject3.transform.GetChild(5).transform.GetChild(0));
				gameObject4.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/balans");
				gameObject4.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
				gameObject4.transform.GetChild(1).GetComponent<Text>().text = "выполнено задание: Зайти на базу заказчика";
				Transform obj3 = gameObject4.transform;
				Vector3 localScale = new Vector3(1f, 1f);
				gameObject4.transform.localScale = localScale;
				obj3.localScale = localScale;
				for (int l = 0; l < 20; l++)
				{
					if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[l].NameSubject == "None")
					{
						Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[l] = Inventory._EmptyTask.RewardSubject;
						gameObject4 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
						gameObject4.transform.SetParent(gameObject3.transform.GetChild(5).transform.GetChild(0));
						gameObject4.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/Subject/Money");
						gameObject4.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
						gameObject4.transform.GetChild(1).GetComponent<Text>().text = "Получен предмет: " + Inventory._EmptyTask.RewardSubject.NameSubject;
						Transform obj4 = gameObject4.transform;
						localScale = new Vector3(1f, 1f);
						gameObject4.transform.localScale = localScale;
						obj4.localScale = localScale;
						Inventory._TaskNum = 0;
						Data.TaskAll.RemoveAt(i);
						return;
					}
				}
				for (int m = 0; m < 25; m++)
				{
					if (Data.Points[Inventory._CurrentPoint[0]].Cache[m].NameSubject == "None")
					{
						Data.Points[Inventory._CurrentPoint[0]].Cache[m] = Inventory._EmptyTask.RewardSubject;
						gameObject4 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
						gameObject4.transform.SetParent(gameObject3.transform.GetChild(5).transform.GetChild(0));
						gameObject4.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/Subject/Money");
						gameObject4.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
						gameObject4.transform.GetChild(1).GetComponent<Text>().text = "В тайнике на текущей локации для вас оставлен предмет: " + Inventory._EmptyTask.RewardSubject.NameSubject;
						Transform obj5 = gameObject4.transform;
						localScale = new Vector3(1f, 1f);
						gameObject4.transform.localScale = localScale;
						obj5.localScale = localScale;
						Inventory._TaskNum = 0;
						Data.TaskAll.RemoveAt(i);
						return;
					}
				}
			}
			if (Data.TaskAll[i].NameTask == "Провал ликвидации" && Data.Points[Inventory._CurrentPoint[0]].namePoint == Data.TaskAll[i].NamePointTask)
			{
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Inventory._EmptyTask = Data.TaskAll[i];
				Data.TaskAll[i] = new TaskAdditionalKillerFail0();
				Data.TaskAll[i].KillCharacterName = Inventory._EmptyTask.KillCharacterName;
				Data.TaskAll[i].NamePointTask = Inventory._EmptyTask.NamePointTask;
				Data.TaskAll[i].ImageTask = Inventory._EmptyTask.ImageTask;
				Data.TaskAll[i].NumberDealer = Inventory._EmptyTask.NumberDealer;
				Data.TaskAll[i].NumberEnemy = Inventory._EmptyTask.NumberEnemy;
				Data.TaskAll[i].MapName = Inventory._EmptyTask.MapName;
				Inventory.AAAAAAAAAAAAAAAAAAAAci();
				Inventory._TaskNum = i;
				Inventory._taskText = true;
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(true);
				Inventory._CurtainGUIEquipment.SetActive(false);
				Inventory._CurtainIconCharacterU.SetActive(false);
				break;
			}
			if (Data.TaskAll[i].NameTask == "Заказчик на месте" && Data.Points[Inventory._CurrentPoint[0]].ControlInt == Data.TaskAll[i].NumberDealer)
			{
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Inventory._EmptyTask = new TaskAdditionalGuide2_5();
				Data.CharacterD[CharacterMotion._curCharacter].Cash += Inventory._EmptyTask.RewardMoney;
				Inventory.AAAAAAAAAAAAAAAAAAAAAci(Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].ImageChar, Inventory._EmptyTask.TextTask);
				Inventory._PointInf = false;
				Inventory._capture = false;
				Inventory._CurtainInventory.SetActive(false);
				Inventory._CurtainGUIEquipment.SetActive(true);
				Inventory._CurtainIconCharacterU.SetActive(true);
				GameObject gameObject5 = GameObject.Find("MessaegeTask");
				float num3 = Screen.width;
				num3 /= 1280f;
				GameObject gameObject6 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
				gameObject6.transform.SetParent(gameObject5.transform.GetChild(5).transform.GetChild(0));
				gameObject6.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/guide");
				gameObject6.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
				gameObject6.transform.GetChild(1).GetComponent<Text>().text = "Выполнено задание: Проводник";
				gameObject6.transform.localScale = new Vector3(1f, 1f);
				gameObject6 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
				gameObject6.transform.SetParent(gameObject5.transform.GetChild(5).transform.GetChild(0));
				gameObject6.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/Subject/Money");
				gameObject6.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
				gameObject6.transform.GetChild(1).GetComponent<Text>().text = "Получены деньги: " + Inventory._EmptyTask.RewardMoney + " ru";
				Transform obj6 = gameObject6.transform;
				Vector3 localScale = new Vector3(1f, 1f);
				gameObject6.transform.localScale = localScale;
				obj6.localScale = localScale;
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.Points[Inventory._CurrentPoint[0]].ControlInt]++;
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.Points[Inventory._CurrentPoint[0]].ControlInt, 0]++;
				if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.Points[Inventory._CurrentPoint[0]].ControlInt] > 9)
				{
					AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.Points[Inventory._CurrentPoint[0]].ControlInt] = 9;
				}
				if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.Points[Inventory._CurrentPoint[0]].ControlInt, 0] > 9)
				{
					AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.Points[Inventory._CurrentPoint[0]].ControlInt, 0] = 9;
				}
				Inventory._TaskNum = 0;
				Data.TaskAll.RemoveAt(i);
				break;
			}
			if (Data.TaskAll[i].NameTask == "Принести Схемы Выжигателя" && Data.TaskAll[i].NamePointTask == Data.Points[Inventory._CurrentPoint[0]].namePoint)
			{
				for (int n = 0; n < 20; n++)
				{
					if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[n].NameSubject == Data.TaskAll[i].QuestSubject.NameSubject)
					{
						Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[n] = new AAAAAAAAAAAAAAAAAAbi();
						Inventory.SoundMenu.clip = Inventory.effectNews;
						Inventory.SoundMenu.Play();
						Inventory._EmptyTask = Data.TaskAll[i];
						Data.TaskAll[i] = new TaskAdditionalEmptyMonolith1();
						Data.TaskAll[i].KillCharacterName = Inventory._EmptyTask.KillCharacterName;
						Data.TaskAll[i].NamePointTask = Inventory._EmptyTask.NamePointTask;
						Data.TaskAll[i].ImageTask = Inventory._EmptyTask.ImageTask;
						Data.TaskAll[i].NumberDealer = Inventory._EmptyTask.NumberDealer;
						Data.TaskAll[i].NumberEnemy = Inventory._EmptyTask.NumberEnemy;
						Data.TaskAll[i].MapName = Inventory._EmptyTask.MapName;
						Inventory.AAAAAAAAAAAAAAAAAAAAci();
						Inventory._TaskNum = i;
						Inventory._taskText = true;
						Inventory._Equipment = false;
						Inventory._CurtainInventory.SetActive(true);
						Inventory._CurtainGUIEquipment.SetActive(false);
						Inventory._CurtainIconCharacterU.SetActive(false);
						Inventory._heroInTask = Data.CharacterD[0].CurGexChar.NameGex;
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.Points[Inventory._CurrentPoint[0]].ControlInt]++;
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.Points[Inventory._CurrentPoint[0]].ControlInt, 0]++;
						if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.Points[Inventory._CurrentPoint[0]].ControlInt] > 9)
						{
							AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.Points[Inventory._CurrentPoint[0]].ControlInt] = 9;
						}
						if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.Points[Inventory._CurrentPoint[0]].ControlInt, 0] > 9)
						{
							AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.Points[Inventory._CurrentPoint[0]].ControlInt, 0] = 9;
						}
						break;
					}
				}
			}
			if (Data.TaskAll[i].NameTask == "Принести Декодер" && Data.TaskAll[i].NamePointTask == Data.Points[Inventory._CurrentPoint[0]].namePoint)
			{
				for (int num4 = 0; num4 < 20; num4++)
				{
					if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num4].NameSubject == Data.TaskAll[i].QuestSubject.NameSubject)
					{
						Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num4] = new AAAAAAAAAAAAAAAAAAbi();
						Inventory.SoundMenu.clip = Inventory.effectNews;
						Inventory.SoundMenu.Play();
						Inventory._EmptyTask = Data.TaskAll[i];
						Data.TaskAll[i] = new TaskAdditionalDecoderMonolith0();
						Data.TaskAll[i].KillCharacterName = Inventory._EmptyTask.KillCharacterName;
						Data.TaskAll[i].NamePointTask = Inventory._EmptyTask.NamePointTask;
						Data.TaskAll[i].ImageTask = Inventory._EmptyTask.ImageTask;
						Data.TaskAll[i].NumberDealer = Inventory._EmptyTask.NumberDealer;
						Data.TaskAll[i].NumberEnemy = Inventory._EmptyTask.NumberEnemy;
						Data.TaskAll[i].MapName = Inventory._EmptyTask.MapName;
						Inventory.AAAAAAAAAAAAAAAAAAAAci();
						Inventory._TaskNum = i;
						Inventory._taskText = true;
						Inventory._Equipment = false;
						Inventory._CurtainInventory.SetActive(true);
						Inventory._CurtainGUIEquipment.SetActive(false);
						Inventory._CurtainIconCharacterU.SetActive(false);
						Inventory._heroInTask = Data.CharacterD[0].CurGexChar.NameGex;
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.Points[Inventory._CurrentPoint[0]].ControlInt]++;
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.Points[Inventory._CurrentPoint[0]].ControlInt, 0]++;
						if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.Points[Inventory._CurrentPoint[0]].ControlInt] > 9)
						{
							AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.Points[Inventory._CurrentPoint[0]].ControlInt] = 9;
						}
						if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.Points[Inventory._CurrentPoint[0]].ControlInt, 0] > 9)
						{
							AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.Points[Inventory._CurrentPoint[0]].ControlInt, 0] = 9;
						}
						break;
					}
				}
			}
			if (Data.Points[Inventory._CurrentPoint[0]].DealerInt == 3 && Inventory._CurrentPoint.Count > 0 && CharacterMotion._curCharacter == 0 && Data.TaskAll[i].NameTask == "Доставить отчет разведчиков" && Data.Points[Inventory._CurrentPoint[0]].curGexPoint == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar)
			{
				for (int num5 = 0; num5 < 20; num5++)
				{
					if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num5].NameSubject == "Отчет разведчиков")
					{
						Inventory.SoundMenu.clip = Inventory.effectNews;
						Inventory.SoundMenu.Play();
						Inventory._EmptyTask = new TaskAdditionalScoutReport0();
						Inventory.AAAAAAAAAAAAAAAAAAAAAci(Inventory._EmptyTask.ImageTask, Inventory._EmptyTask.TextTask);
						Inventory._Equipment = false;
						Inventory._CurtainInventory.SetActive(false);
						Inventory._CurtainGUIEquipment.SetActive(true);
						Inventory._CurtainIconCharacterU.SetActive(true);
						GameObject gameObject7 = GameObject.Find("MessaegeTask");
						float num6 = Screen.width;
						num6 /= 1280f;
						GameObject gameObject8 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
						gameObject8.transform.SetParent(gameObject7.transform.GetChild(5).transform.GetChild(0));
						gameObject8.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/Army");
						gameObject8.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
						gameObject8.transform.GetChild(1).GetComponent<Text>().text = "Выполнено задание: доставить отчет разведчиков на военную точку.";
						Transform obj7 = gameObject8.transform;
						Vector3 localScale = new Vector3(1f, 1f);
						gameObject8.transform.localScale = localScale;
						obj7.localScale = localScale;
						gameObject8 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
						gameObject8.transform.SetParent(gameObject7.transform.GetChild(5).transform.GetChild(0));
						gameObject8.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/Subject/dokuments_0");
						gameObject8.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
						gameObject8.transform.GetChild(1).GetComponent<Text>().text = "Потерян предмет: Отчет разведчиков.";
						Transform obj8 = gameObject8.transform;
						localScale = new Vector3(1f, 1f);
						gameObject8.transform.localScale = localScale;
						obj8.localScale = localScale;
						gameObject8 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
						gameObject8.transform.SetParent(gameObject7.transform.GetChild(5).transform.GetChild(0));
						gameObject8.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/Subject/Money");
						gameObject8.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
						gameObject8.transform.GetChild(1).GetComponent<Text>().text = "Получены деньги: 1500ru.";
						Transform obj9 = gameObject8.transform;
						localScale = new Vector3(1f, 1f);
						gameObject8.transform.localScale = localScale;
						obj9.localScale = localScale;
						Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num5] = new AAAAAAAAAAAAAAAAAAbi();
						Data.CharacterD[CharacterMotion._curCharacter].Cash += 1500;
						GPSscript.AAAAAAAAAAAAAAAAAi("CgkI2OGbhtMLEAIQDA", 1);
						Inventory._TaskNum = 0;
						Data.TaskAll.RemoveAt(i);
						GOMessaegeTask = true;
						Inventory._PointInformation = false;
						return;
					}
				}
			}
			if (Data.TaskAll[i].NameTask == "Принести съедобные припасы" && Data.TaskAll[i].NamePointTask == Data.Points[Inventory._CurrentPoint[0]].namePoint && Inventory._CurrentPoint.Count > 0 && CharacterMotion._curCharacter == 0 && Data.Points[Inventory._CurrentPoint[0]].curGexPoint == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar)
			{
				for (int num7 = 0; num7 < 20; num7++)
				{
					if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num7].NameSubject == Data.TaskAll[i].QuestSubject.NameSubject && Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num7].Stack >= 4)
					{
						Data.OldTask.Add("Принести съедобные припасы");
						Inventory.SoundMenu.clip = Inventory.effectNews;
						Inventory.SoundMenu.Play();
						Inventory._EmptyTask = new TaskAdditionalArmFood0();
						Inventory.AAAAAAAAAAAAAAAAAAAAAci(Inventory._EmptyTask.ImageTask, Inventory._EmptyTask.TextTask);
						Inventory._Equipment = false;
						Inventory._CurtainInventory.SetActive(false);
						Inventory._CurtainGUIEquipment.SetActive(true);
						Inventory._CurtainIconCharacterU.SetActive(true);
						GameObject gameObject9 = GameObject.Find("MessaegeTask");
						float num8 = Screen.width;
						num8 /= 1280f;
						GameObject gameObject10 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
						gameObject10.transform.SetParent(gameObject9.transform.GetChild(5).transform.GetChild(0));
						gameObject10.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/Army");
						gameObject10.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
						gameObject10.transform.GetChild(1).GetComponent<Text>().text = "Выполнено задание: Принести съедобные припасы.";
						Transform obj10 = gameObject10.transform;
						Vector3 localScale = new Vector3(1f, 1f);
						gameObject10.transform.localScale = localScale;
						obj10.localScale = localScale;
						gameObject10 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
						gameObject10.transform.SetParent(gameObject9.transform.GetChild(5).transform.GetChild(0));
						gameObject10.transform.GetChild(0).GetComponent<RawImage>().texture = Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num7].TextureSubject;
						gameObject10.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
						gameObject10.transform.GetChild(1).GetComponent<Text>().text = "Потеряны предметы: Тушенка " + Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num7].Stack + "шт.";
						Transform obj11 = gameObject10.transform;
						localScale = new Vector3(1f, 1f);
						gameObject10.transform.localScale = localScale;
						obj11.localScale = localScale;
						gameObject10 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
						gameObject10.transform.SetParent(gameObject9.transform.GetChild(5).transform.GetChild(0));
						gameObject10.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/Subject/aptechkaArm");
						gameObject10.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
						gameObject10.transform.GetChild(1).GetComponent<Text>().text = "Получен предмет: Аптечка армейская.";
						Transform obj12 = gameObject10.transform;
						localScale = new Vector3(1f, 1f);
						gameObject10.transform.localScale = localScale;
						obj12.localScale = localScale;
						Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num7] = new AAAAAAAAAAAAAAAAbd();
						Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num7].Stack = 1;
						Inventory._TaskNum = 0;
						Data.TaskAll.RemoveAt(i);
						GOMessaegeTask = true;
						Inventory._PointInformation = false;
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.Points[Inventory._CurrentPoint[0]].ControlInt]++;
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.Points[Inventory._CurrentPoint[0]].ControlInt, 0]++;
						if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.Points[Inventory._CurrentPoint[0]].ControlInt] > 9)
						{
							AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.Points[Inventory._CurrentPoint[0]].ControlInt] = 9;
						}
						if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.Points[Inventory._CurrentPoint[0]].ControlInt, 0] > 9)
						{
							AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.Points[Inventory._CurrentPoint[0]].ControlInt, 0] = 9;
						}
						GPSscript.AAAAAAAAAAAAAAAAAi("CgkI2OGbhtMLEAIQDA", 1);
						return;
					}
				}
			}
			if (Data.TaskAll[i].NameTask == "Кольт" && Inventory._CurrentPoint.Count > 0 && CharacterMotion._curCharacter == 0 && Data.Points[Inventory._CurrentPoint[0]].namePoint == "Ангар" && Data.Points[Inventory._CurrentPoint[0]].curGexPoint == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar)
			{
				bool flag = false;
				for (int num9 = 0; num9 < 20; num9++)
				{
					if (Data.CharacterD[0].CharBackpack[num9].NameSubject == "Кольт сталкера")
					{
						Data.CharacterD[0].CharBackpack[num9] = new AAAAAAAAAAAAAAAAu();
						flag = true;
					}
				}
				if (flag)
				{
					Inventory.SoundMenu.clip = Inventory.effectNews;
					Inventory.SoundMenu.Play();
					Inventory._EmptyTask = new TaskAdditionalColt3();
					Data.TaskAll[i] = Inventory._EmptyTask;
					Inventory.AAAAAAAAAAAAAAAAAAAAAci(Inventory._EmptyTask.ImageTask, Inventory._EmptyTask.TextTask);
					Inventory._Equipment = false;
					Inventory._CurtainInventory.SetActive(false);
					Inventory._CurtainGUIEquipment.SetActive(true);
					Inventory._CurtainIconCharacterU.SetActive(true);
					GameObject gameObject11 = GameObject.Find("MessaegeTask");
					float num10 = Screen.width;
					num10 /= 1280f;
					GameObject gameObject12 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
					gameObject12.transform.SetParent(gameObject11.transform.GetChild(5).transform.GetChild(0));
					gameObject12.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/netrals");
					gameObject12.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
					gameObject12.transform.GetChild(1).GetComponent<Text>().text = "Выполнено задание: Доставить кольт в Ангар на Свалке.";
					Transform obj13 = gameObject12.transform;
					Vector3 localScale = new Vector3(1f, 1f);
					gameObject12.transform.localScale = localScale;
					obj13.localScale = localScale;
					gameObject12 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
					gameObject12.transform.SetParent(gameObject11.transform.GetChild(5).transform.GetChild(0));
					gameObject12.transform.GetChild(0).GetComponent<RawImage>().texture = new M1911A1unique().TextureSubject;
					gameObject12.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
					gameObject12.transform.GetChild(1).GetComponent<Text>().text = "Потерян предмет: Кольт сталкера.";
					Transform obj14 = gameObject12.transform;
					localScale = new Vector3(1f, 1f);
					gameObject12.transform.localScale = localScale;
					obj14.localScale = localScale;
					gameObject12 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
					gameObject12.transform.SetParent(gameObject11.transform.GetChild(5).transform.GetChild(0));
					gameObject12.transform.GetChild(0).GetComponent<RawImage>().texture = new AAAAAAAAAAAAAAAAu().TextureSubject;
					gameObject12.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
					gameObject12.transform.GetChild(1).GetComponent<Text>().text = "Получен предмет: Выверт.";
					Transform obj15 = gameObject12.transform;
					localScale = new Vector3(1f, 1f);
					gameObject12.transform.localScale = localScale;
					obj15.localScale = localScale;
					gameObject12 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
					gameObject12.transform.SetParent(gameObject11.transform.GetChild(5).transform.GetChild(0));
					gameObject12.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/netrals");
					gameObject12.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
					gameObject12.transform.GetChild(1).GetComponent<Text>().text = "Ваш авторитет у одиночек повысился!";
					Transform obj16 = gameObject12.transform;
					localScale = new Vector3(1f, 1f);
					gameObject12.transform.localScale = localScale;
					obj16.localScale = localScale;
					AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 1]++;
					AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[1, 0]++;
					if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 1] > 9)
					{
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 1] = 9;
					}
					if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[1, 0] > 9)
					{
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[1, 0] = 9;
					}
					Inventory._TaskNum = 0;
					Data.TaskAll.RemoveAt(i);
					GOMessaegeTask = true;
					Inventory._PointInformation = false;
					break;
				}
			}
			if (Data.TaskAll[i].NameTask == "Найти динамит" && Data.TaskAll[i].NamePointTask == Data.Points[Inventory._CurrentPoint[0]].namePoint)
			{
				for (int num11 = 0; num11 < 20; num11++)
				{
					if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num11].NameSubject == Data.TaskAll[i].QuestSubject.NameSubject)
					{
						Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num11] = new AAAAAAAAAAAAAAAAAAbi();
						Inventory.SoundMenu.clip = Inventory.effectNews;
						Inventory.SoundMenu.Play();
						Inventory._EmptyTask = Data.TaskAll[i];
						Data.TaskAll[i] = new TaskAdditionalFindDinamit0();
						Data.TaskAll[i].KillCharacterName = Inventory._EmptyTask.KillCharacterName;
						Data.TaskAll[i].NamePointTask = Inventory._EmptyTask.NamePointTask;
						Data.TaskAll[i].ImageTask = Inventory._EmptyTask.ImageTask;
						Data.TaskAll[i].NumberDealer = Inventory._EmptyTask.NumberDealer;
						Data.TaskAll[i].NumberEnemy = Inventory._EmptyTask.NumberEnemy;
						Data.TaskAll[i].MapName = Inventory._EmptyTask.MapName;
						Inventory.AAAAAAAAAAAAAAAAAAAAci();
						Inventory._TaskNum = i;
						Inventory._taskText = true;
						Inventory._Equipment = false;
						Inventory._CurtainInventory.SetActive(true);
						Inventory._CurtainGUIEquipment.SetActive(false);
						Inventory._CurtainIconCharacterU.SetActive(false);
						Inventory._heroInTask = Data.CharacterD[0].CurGexChar.NameGex;
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 2]++;
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[2, 0]++;
						if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 2] > 9)
						{
							AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 2] = 9;
						}
						if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[2, 0] > 9)
						{
							AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[2, 0] = 9;
						}
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 1] -= 3;
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[1, 0] -= 3;
						if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 1] < 0)
						{
							AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 1] = 0;
						}
						if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[1, 0] < 0)
						{
							AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[1, 0] = 0;
						}
						break;
					}
				}
			}
			if (Data.TaskAll[i].NameTask == "Доставить партию оружия" && Data.TaskAll[i].NamePointTask == Data.Points[Inventory._CurrentPoint[0]].namePoint)
			{
				for (int num12 = 0; num12 < 20; num12++)
				{
					if (!(Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num12].NameSubject == Data.TaskAll[i].QuestSubject.NameSubject))
					{
						continue;
					}
					Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num12] = new AAAAAAAAAAAAAAAAAAbi();
					Inventory.SoundMenu.clip = Inventory.effectNews;
					Inventory.SoundMenu.Play();
					Inventory._EmptyTask = Data.TaskAll[i];
					Data.TaskAll[i] = new TaskAdditionalFindWeaponBox0();
					Data.TaskAll[i].KillCharacterName = Inventory._EmptyTask.KillCharacterName;
					Data.TaskAll[i].NamePointTask = Inventory._EmptyTask.NamePointTask;
					Data.TaskAll[i].ImageTask = Inventory._EmptyTask.ImageTask;
					Data.TaskAll[i].NumberDealer = Inventory._EmptyTask.NumberDealer;
					Data.TaskAll[i].NumberEnemy = Inventory._EmptyTask.NumberEnemy;
					Data.TaskAll[i].MapName = Inventory._EmptyTask.MapName;
					Inventory.AAAAAAAAAAAAAAAAAAAAci();
					Inventory._TaskNum = i;
					Inventory._taskText = true;
					Inventory._Equipment = false;
					Inventory._CurtainInventory.SetActive(true);
					Inventory._CurtainGUIEquipment.SetActive(false);
					Inventory._CurtainIconCharacterU.SetActive(false);
					Inventory._heroInTask = Data.CharacterD[0].CurGexChar.NameGex;
					AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 2]++;
					AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[2, 0]++;
					if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 2] > 9)
					{
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 2] = 9;
					}
					if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[2, 0] > 9)
					{
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[2, 0] = 9;
					}
					AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 1] -= 3;
					AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[1, 0] -= 3;
					if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 1] < 0)
					{
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 1] = 0;
					}
					if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[1, 0] < 0)
					{
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[1, 0] = 0;
					}
					for (int num13 = 0; num13 < Data.CharacterD.Count; num13++)
					{
						if (Data.CharacterD[num13].TypeChInt == 2 && Data.CharacterD[num13].WeaponChar.CostSubject < 2900)
						{
							Data.CharacterD[num13].WeaponChar = new Winchester1300();
						}
					}
					break;
				}
			}
			if (Data.TaskAll[i].NameTask == "Доставить партию комбинезонов" && Data.TaskAll[i].NamePointTask == Data.Points[Inventory._CurrentPoint[0]].namePoint)
			{
				for (int num14 = 0; num14 < 20; num14++)
				{
					if (!(Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num14].NameSubject == Data.TaskAll[i].QuestSubject.NameSubject))
					{
						continue;
					}
					Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num14] = new AAAAAAAAAAAAAAAAAAbi();
					Inventory.SoundMenu.clip = Inventory.effectNews;
					Inventory.SoundMenu.Play();
					Inventory._EmptyTask = Data.TaskAll[i];
					Data.TaskAll[i] = new TaskAdditionalFindSuitBox0();
					Data.TaskAll[i].KillCharacterName = Inventory._EmptyTask.KillCharacterName;
					Data.TaskAll[i].NamePointTask = Inventory._EmptyTask.NamePointTask;
					Data.TaskAll[i].ImageTask = Inventory._EmptyTask.ImageTask;
					Data.TaskAll[i].NumberDealer = Inventory._EmptyTask.NumberDealer;
					Data.TaskAll[i].NumberEnemy = Inventory._EmptyTask.NumberEnemy;
					Data.TaskAll[i].MapName = Inventory._EmptyTask.MapName;
					Inventory.AAAAAAAAAAAAAAAAAAAAci();
					Inventory._TaskNum = i;
					Inventory._taskText = true;
					Inventory._Equipment = false;
					Inventory._CurtainInventory.SetActive(true);
					Inventory._CurtainGUIEquipment.SetActive(false);
					Inventory._CurtainIconCharacterU.SetActive(false);
					Inventory._heroInTask = Data.CharacterD[0].CurGexChar.NameGex;
					AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 2]++;
					AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[2, 0]++;
					if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 2] > 9)
					{
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 2] = 9;
					}
					if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[2, 0] > 9)
					{
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[2, 0] = 9;
					}
					AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 4] -= 3;
					AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[4, 0] -= 3;
					if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 4] < 0)
					{
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 4] = 0;
					}
					if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[4, 0] < 0)
					{
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[4, 0] = 0;
					}
					for (int num15 = 0; num15 < Data.CharacterD.Count; num15++)
					{
						if (Data.CharacterD[num15].TypeChInt == 2 && Data.CharacterD[num15].SuitChar.CostSubject < 6200)
						{
							Data.CharacterD[num15].SuitChar = new AAAAAAAAAAAAAAAAAAbk();
						}
					}
					break;
				}
			}
			if (Data.TaskAll[i].NameTask == "Найти детали" && Inventory._CurrentPoint.Count > 0 && Data.Points[Inventory._CurrentPoint[0]].namePoint == "Мост в Лиманск" && Data.Points[Inventory._CurrentPoint[0]].curGexPoint == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar)
			{
				for (int num16 = 0; num16 < 20; num16++)
				{
					if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num16].NameSubject == "Детали")
					{
						Data.OldTask.Add("Найти детали");
						Inventory.SoundMenu.clip = Inventory.effectNews;
						Inventory.SoundMenu.Play();
						Inventory._EmptyTask = new TaskAdditionalSpareParts0();
						Data.CharacterD[CharacterMotion._curCharacter].Cash += Inventory._EmptyTask.RewardMoney;
						Inventory.AAAAAAAAAAAAAAAAAAAAAci(Inventory._EmptyTask.ImageTask, Inventory._EmptyTask.TextTask);
						Inventory._PointInf = false;
						Inventory._capture = false;
						Inventory._CurtainInventory.SetActive(false);
						Inventory._CurtainGUIEquipment.SetActive(true);
						Inventory._CurtainIconCharacterU.SetActive(true);
						GameObject gameObject13 = GameObject.Find("MessaegeTask");
						float num17 = Screen.width;
						num17 /= 1280f;
						GameObject gameObject14 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
						gameObject14.transform.SetParent(gameObject13.transform.GetChild(5).transform.GetChild(0));
						gameObject14.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/Subject/Money");
						gameObject14.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
						gameObject14.transform.GetChild(1).GetComponent<Text>().text = "Получены деньги: " + Inventory._EmptyTask.RewardMoney + " ru";
						Transform obj17 = gameObject14.transform;
						Vector3 localScale = new Vector3(1f, 1f);
						gameObject14.transform.localScale = localScale;
						obj17.localScale = localScale;
						gameObject14 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
						gameObject14.transform.SetParent(gameObject13.transform.GetChild(5).transform.GetChild(0));
						gameObject14.transform.GetChild(0).GetComponent<RawImage>().texture = Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num16].TextureSubject;
						gameObject14.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
						gameObject14.transform.GetChild(1).GetComponent<Text>().text = "Передан предмет: " + Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num16].NameSubject;
						Transform obj18 = gameObject14.transform;
						localScale = new Vector3(1f, 1f);
						gameObject14.transform.localScale = localScale;
						obj18.localScale = localScale;
						Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num16] = new AAAAAAAAAAAAAAAAAAbi();
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 5]++;
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[5, 0]++;
						if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 5] > 9)
						{
							AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 5] = 9;
						}
						if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[5, 0] > 9)
						{
							AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[5, 0] = 9;
						}
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 7]--;
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[7, 0]--;
						if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 7] < 0)
						{
							AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 7] = 0;
						}
						if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[7, 0] < 0)
						{
							AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[7, 0] = 0;
						}
						Data.TaskAll.RemoveAt(i);
						return;
					}
				}
			}
			if (Data.TaskAll[i].NameTask == "Схемы для наемников" && Inventory._CurrentPoint.Count > 0 && Data.TaskAll[i].NamePointTask == Data.Points[Inventory._CurrentPoint[0]].namePoint && Data.Points[Inventory._CurrentPoint[0]].curGexPoint == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar)
			{
				for (int num18 = 0; num18 < 20; num18++)
				{
					if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num18].NameSubject == "Схемы Выжигателя")
					{
						Data.OldTask.Add("Схемы для наемников");
						Inventory.SoundMenu.clip = Inventory.effectNews;
						Inventory.SoundMenu.Play();
						Inventory._EmptyTask = new TaskAdditionalMercenarySchemeOfBurner1();
						Data.CharacterD[CharacterMotion._curCharacter].Cash += Inventory._EmptyTask.RewardMoney;
						Inventory.AAAAAAAAAAAAAAAAAAAAAci(Inventory._EmptyTask.ImageTask, Inventory._EmptyTask.TextTask);
						Inventory._PointInf = false;
						Inventory._capture = false;
						Inventory._CurtainInventory.SetActive(false);
						Inventory._CurtainGUIEquipment.SetActive(true);
						Inventory._CurtainIconCharacterU.SetActive(true);
						GameObject gameObject15 = GameObject.Find("MessaegeTask");
						float num19 = Screen.width;
						num19 /= 1280f;
						GameObject gameObject16 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
						gameObject16.transform.SetParent(gameObject15.transform.GetChild(5).transform.GetChild(0));
						gameObject16.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/Subject/Money");
						gameObject16.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
						gameObject16.transform.GetChild(1).GetComponent<Text>().text = "Получены деньги: " + Inventory._EmptyTask.RewardMoney + " ru";
						Transform obj19 = gameObject16.transform;
						Vector3 localScale = new Vector3(1f, 1f);
						gameObject16.transform.localScale = localScale;
						obj19.localScale = localScale;
						gameObject16 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
						gameObject16.transform.SetParent(gameObject15.transform.GetChild(5).transform.GetChild(0));
						gameObject16.transform.GetChild(0).GetComponent<RawImage>().texture = Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num18].TextureSubject;
						gameObject16.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
						gameObject16.transform.GetChild(1).GetComponent<Text>().text = "Передан предмет: " + Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num18].NameSubject;
						Transform obj20 = gameObject16.transform;
						localScale = new Vector3(1f, 1f);
						gameObject16.transform.localScale = localScale;
						obj20.localScale = localScale;
						Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num18] = new AAAAAAAAAAAAAAAAAAbi();
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 5]++;
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[5, 0]++;
						if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 5] > 9)
						{
							AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 5] = 9;
						}
						if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[5, 0] > 9)
						{
							AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[5, 0] = 9;
						}
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 7]--;
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[7, 0]--;
						if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 7] < 0)
						{
							AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 7] = 0;
						}
						if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[7, 0] < 0)
						{
							AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[7, 0] = 0;
						}
						Data.TaskAll.RemoveAt(i);
						return;
					}
				}
			}
			if (Data.TaskAll[i].NameTask == "Вернуть детектор" && Inventory._CurrentPoint.Count > 0 && Data.Points[Inventory._CurrentPoint[0]].namePoint == Data.TaskAll[i].NamePointTask && Data.Points[Inventory._CurrentPoint[0]].curGexPoint == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar)
			{
				for (int num20 = 0; num20 < 20; num20++)
				{
					if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num20].NameSubject == "ДЖФ - 4")
					{
						Data.OldTask.Add("Вернуть детектор");
						Inventory.SoundMenu.clip = Inventory.effectNews;
						Inventory.SoundMenu.Play();
						Inventory._EmptyTask = new TaskAdditionalMercenaryLifeDetector0();
						Data.CharacterD[CharacterMotion._curCharacter].Cash += Inventory._EmptyTask.RewardMoney;
						Inventory.AAAAAAAAAAAAAAAAAAAAAci(Inventory._EmptyTask.ImageTask, Inventory._EmptyTask.TextTask);
						Inventory._PointInf = false;
						Inventory._capture = false;
						Inventory._CurtainInventory.SetActive(false);
						Inventory._CurtainGUIEquipment.SetActive(true);
						Inventory._CurtainIconCharacterU.SetActive(true);
						GameObject gameObject17 = GameObject.Find("MessaegeTask");
						float num21 = Screen.width;
						num21 /= 1280f;
						GameObject gameObject18 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
						gameObject18.transform.SetParent(gameObject17.transform.GetChild(5).transform.GetChild(0));
						gameObject18.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/Subject/Money");
						gameObject18.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
						gameObject18.transform.GetChild(1).GetComponent<Text>().text = "Получены деньги: " + Inventory._EmptyTask.RewardMoney + " ru";
						Transform obj21 = gameObject18.transform;
						Vector3 localScale = new Vector3(1f, 1f);
						gameObject18.transform.localScale = localScale;
						obj21.localScale = localScale;
						gameObject18 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
						gameObject18.transform.SetParent(gameObject17.transform.GetChild(5).transform.GetChild(0));
						gameObject18.transform.GetChild(0).GetComponent<RawImage>().texture = Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num20].TextureSubject;
						gameObject18.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
						gameObject18.transform.GetChild(1).GetComponent<Text>().text = "Передан предмет: " + Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num20].NameSubject;
						Transform obj22 = gameObject18.transform;
						localScale = new Vector3(1f, 1f);
						gameObject18.transform.localScale = localScale;
						obj22.localScale = localScale;
						Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num20] = new AAAAAAAAAAAAAAAAAAbi();
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 5]++;
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[5, 0]++;
						if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 5] > 9)
						{
							AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 5] = 9;
						}
						if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[5, 0] > 9)
						{
							AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[5, 0] = 9;
						}
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 7]--;
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[7, 0]--;
						if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 7] < 0)
						{
							AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 7] = 0;
						}
						if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[7, 0] < 0)
						{
							AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[7, 0] = 0;
						}
						Data.TaskAll.RemoveAt(i);
						return;
					}
				}
			}
			if (Data.TaskAll[i].NameTask == "Возвращение хабара сталкеров" && Inventory._CurrentPoint.Count > 0 && CharacterMotion._curCharacter == 0 && Data.Points[Inventory._CurrentPoint[0]].DealerInt == 1 && Data.Points[Inventory._CurrentPoint[0]].curGexPoint == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar)
			{
				for (int num22 = 0; num22 < 20; num22++)
				{
					if (Data.CharacterD[0].CharBackpack[num22].NameSubject == "Каменный цветок" && Data.CharacterD[0].CharBackpack[num22].Stack >= 2)
					{
						AAAAAAAAAAAAAAAAAAk aAAAAAAAAAAAAAAAAAk = Data.CharacterD[0].CharBackpack[num22];
						Data.CharacterD[0].CharBackpack[num22] = new AAAAAAAAAAAAAAAAAAbi();
						Inventory.SoundMenu.clip = Inventory.effectNews;
						Inventory.SoundMenu.Play();
						Inventory._EmptyTask = new TaskAdditionalReturnBearMod3();
						Data.TaskAll[i] = Inventory._EmptyTask;
						Inventory.AAAAAAAAAAAAAAAAAAAAAci(Inventory._EmptyTask.ImageTask, Inventory._EmptyTask.TextTask);
						Inventory._Equipment = false;
						Inventory._CurtainInventory.SetActive(false);
						Inventory._CurtainGUIEquipment.SetActive(true);
						Inventory._CurtainIconCharacterU.SetActive(true);
						GameObject gameObject19 = GameObject.Find("MessaegeTask");
						float num23 = Screen.width;
						num23 /= 1280f;
						GameObject gameObject20 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
						gameObject20.transform.SetParent(gameObject19.transform.GetChild(5).transform.GetChild(0));
						gameObject20.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/netrals0");
						gameObject20.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
						gameObject20.transform.GetChild(1).GetComponent<Text>().text = "Выполнены задания: Найти награбленный хабар, возвращение хабара сталкеров.";
						Transform obj23 = gameObject20.transform;
						Vector3 localScale = new Vector3(1f, 1f);
						gameObject20.transform.localScale = localScale;
						obj23.localScale = localScale;
						gameObject20 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
						gameObject20.transform.SetParent(gameObject19.transform.GetChild(5).transform.GetChild(0));
						gameObject20.transform.GetChild(0).GetComponent<RawImage>().texture = aAAAAAAAAAAAAAAAAAk.TextureSubject;
						gameObject20.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
						gameObject20.transform.GetChild(1).GetComponent<Text>().text = "Переданы предметы: артефкты ''Каменный цветок''";
						Transform obj24 = gameObject20.transform;
						localScale = new Vector3(1f, 1f);
						gameObject20.transform.localScale = localScale;
						obj24.localScale = localScale;
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 1]++;
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[1, 0]++;
						if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 1] > 9)
						{
							AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 1] = 9;
						}
						if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[1, 0] > 9)
						{
							AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[1, 0] = 9;
						}
						Inventory._TaskNum = 0;
						Data.TaskAll.RemoveAt(i);
						Inventory._PointInformation = false;
						GOMessaegeTask = true;
						return;
					}
					if (num22 == 19 && Data.CharacterD[0].CharBackpack[num22].NameSubject != "None")
					{
						Inventory.MessagePanel("Рюкзак переполнен, необходимо освободить место для найденного предмета.");
					}
				}
			}
			if (Data.TaskAll[i].NameTask == "Кровосос убит" && Inventory._CurrentPoint.Count > 0 && CharacterMotion._curCharacter == 0 && Data.Points[Inventory._CurrentPoint[0]].DealerInt == 4 && Data.Points[Inventory._CurrentPoint[0]].curGexPoint == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar)
			{
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Inventory._EmptyTask = new TaskAdditionalDutyKillBloodsuсker4();
				Inventory.AAAAAAAAAAAAAAAAAAAAAci(Inventory._EmptyTask.ImageTask, Inventory._EmptyTask.TextTask);
				Inventory._PointInf = false;
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(false);
				Inventory._CurtainGUIEquipment.SetActive(true);
				Inventory._CurtainIconCharacterU.SetActive(true);
				GameObject gameObject21 = GameObject.Find("MessaegeTask");
				GameObject gameObject22 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
				gameObject22.transform.SetParent(gameObject21.transform.GetChild(5).transform.GetChild(0));
				gameObject22.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/DutyBloodsucker");
				gameObject22.transform.GetChild(1).GetComponent<Text>().text = "Выполнены задания: исследовать насосную станцию, убить кровососа.";
				Transform obj25 = gameObject22.transform;
				Vector3 localScale = new Vector3(1f, 1f);
				gameObject22.transform.localScale = localScale;
				obj25.localScale = localScale;
				gameObject22 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
				gameObject22.transform.SetParent(gameObject21.transform.GetChild(5).transform.GetChild(0));
				gameObject22.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/Subject/Money");
				gameObject22.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
				gameObject22.transform.GetChild(1).GetComponent<Text>().text = "Получены деньги: 2000 ru.";
				Transform obj26 = gameObject22.transform;
				localScale = new Vector3(1f, 1f);
				gameObject22.transform.localScale = localScale;
				obj26.localScale = localScale;
				gameObject22 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
				gameObject22.transform.SetParent(gameObject21.transform.GetChild(5).transform.GetChild(0));
				gameObject22.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/IconGroup/Dolg64");
				gameObject22.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
				gameObject22.transform.GetChild(1).GetComponent<Text>().text = "Ваш авторитет а группировки ''Долг'' повысился.";
				Transform obj27 = gameObject22.transform;
				localScale = new Vector3(1f, 1f);
				gameObject22.transform.localScale = localScale;
				obj27.localScale = localScale;
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 2000;
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 4]++;
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[4, 0]++;
				if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 4] > 9)
				{
					AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 4] = 9;
				}
				if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[4, 0] > 9)
				{
					AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[4, 0] = 9;
				}
				Inventory._TaskNum = 0;
				Data.TaskAll.RemoveAt(i);
				GOMessaegeTask = true;
				break;
			}
			if (Data.TaskAll[i].NameTask == "Найти информацию об экспериментах" && CharacterMotion._curCharacter == 0 && Inventory._CurrentPoint.Count > 0 && Data.Points[Inventory._CurrentPoint[0]].namePoint == Data.TaskAll[i].NamePointTask && Data.Points[Inventory._CurrentPoint[0]].curGexPoint == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar)
			{
				for (int num24 = 0; num24 < 20; num24++)
				{
					if (!(Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num24].NameSubject == "Отчет следственной группы") && !(Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num24].NameSubject == "Служебная переписка ученых") && !(Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num24].NameSubject == "Записки персонала лаборатории Х-18") && !(Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num24].NameSubject == "Отчет об испытаниях") && !(Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num24].NameSubject == "Ответ на отчет об испытаниях") && !(Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num24].NameSubject == "Приказ по лаборатории X-16") && !(Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num24].NameSubject == "Посмертная записка руководителя лаборатории") && !(Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num24].NameSubject == "Служебная переписка") && !(Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num24].NameSubject == "Документ X") && !(Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num24].NameSubject == "Документ №...") && !(Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num24].NameSubject == "Данные о происходящем в Зоне") && !(Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num24].NameSubject == "Документ XX312") && !(Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num24].NameSubject == "Записи М.А.Мизенгора") && !(Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num24].NameSubject == "Указ N563-01") && !(Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num24].NameSubject == "Газетная вырезка") && !(Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num24].NameSubject == "Неизвестный документ") && !(Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num24].NameSubject == "Записи группировки ''Монолит''") && !(Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num24].NameSubject == "Записка о дневнике") && !(Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num24].NameSubject == "Записки сталкера N0001") && !(Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num24].NameSubject == "Записки сталкера N0002") && !(Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num24].NameSubject == "Записки сталкера N0003"))
					{
						continue;
					}
					int num25 = 0;
					foreach (string item in Data.OldTask)
					{
						if (item == "Отчет следственной группы")
						{
							num25++;
						}
						if (item == "Служебная переписка ученых")
						{
							num25++;
						}
						if (item == "Записки персонала лаборатории Х-18")
						{
							num25++;
						}
						if (item == "Отчет об испытаниях")
						{
							num25++;
						}
						if (item == "Ответ на отчет об испытаниях")
						{
							num25++;
						}
						if (item == "Приказ по лаборатории X-16")
						{
							num25++;
						}
						if (item == "Посмертная записка руководителя лаборатории")
						{
							num25++;
						}
						if (item == "Служебная переписка")
						{
							num25++;
						}
						if (item == "Документ X")
						{
							num25++;
						}
						if (item == "Документ №...")
						{
							num25++;
						}
						if (item == "Данные о происходящем в Зоне")
						{
							num25++;
						}
						if (item == "Документ XX312")
						{
							num25++;
						}
						if (item == "Записи М.А.Мизенгора")
						{
							num25++;
						}
						if (item == "Указ N563-01")
						{
							num25++;
						}
						if (item == "Газетная вырезка")
						{
							num25++;
						}
						if (item == "Неизвестный документ")
						{
							num25++;
						}
						if (item == "Записи группировки ''Монолит''")
						{
							num25++;
						}
						if (item == "Записка о дневнике")
						{
							num25++;
						}
						if (item == "Записки сталкера N0001")
						{
							num25++;
						}
						if (item == "Записки сталкера N0002")
						{
							num25++;
						}
						if (item == "Записки сталкера N0003")
						{
							num25++;
						}
					}
					Inventory.SoundMenu.clip = Inventory.effectNews;
					Inventory.SoundMenu.Play();
					Data.OldTask.Add(Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num24].NameSubject);
					if (num25 < 20)
					{
						Debug.Log(num25 + " \\\\\\");
						Inventory._EmptyTask = new TaskAdditionalВocumentation0();
						Data.CharacterD[CharacterMotion._curCharacter].Cash += Inventory._EmptyTask.RewardMoney;
						Inventory.AAAAAAAAAAAAAAAAAAAAAci(Inventory._EmptyTask.ImageTask, Inventory._EmptyTask.TextTask);
						Inventory._PointInf = false;
						Inventory._capture = false;
						Inventory._CurtainInventory.SetActive(false);
						Inventory._CurtainGUIEquipment.SetActive(true);
						Inventory._CurtainIconCharacterU.SetActive(true);
						GameObject gameObject23 = GameObject.Find("MessaegeTask");
						float num26 = Screen.width;
						num26 /= 1280f;
						GameObject gameObject24 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
						gameObject24.transform.SetParent(gameObject23.transform.GetChild(5).transform.GetChild(0));
						gameObject24.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/Subject/Money");
						gameObject24.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
						gameObject24.transform.GetChild(1).GetComponent<Text>().text = "Получены деньги: " + Inventory._EmptyTask.RewardMoney + " ru";
						Transform obj28 = gameObject24.transform;
						Vector3 localScale = new Vector3(1f, 1f);
						gameObject24.transform.localScale = localScale;
						obj28.localScale = localScale;
						gameObject24 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
						gameObject24.transform.SetParent(gameObject23.transform.GetChild(5).transform.GetChild(0));
						gameObject24.transform.GetChild(0).GetComponent<RawImage>().texture = Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num24].TextureSubject;
						gameObject24.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
						gameObject24.transform.GetChild(1).GetComponent<Text>().text = "Передан предмет: " + Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num24].NameSubject;
						Transform obj29 = gameObject24.transform;
						localScale = new Vector3(1f, 1f);
						gameObject24.transform.localScale = localScale;
						obj29.localScale = localScale;
						Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num24] = new AAAAAAAAAAAAAAAAAAbi();
						return;
					}
					if (num25 >= 20)
					{
						Data.OldTask.Add("Найти информацию об экспериментах");
						Debug.Log(num25 + " \\\\\\");
						Inventory._EmptyTask = new TaskAdditionalВocumentation1();
						Data.CharacterD[CharacterMotion._curCharacter].Cash += Inventory._EmptyTask.RewardMoney;
						Inventory.AAAAAAAAAAAAAAAAAAAAAci(Inventory._EmptyTask.ImageTask, Inventory._EmptyTask.TextTask);
						Inventory._PointInf = false;
						Inventory._capture = false;
						Inventory._CurtainInventory.SetActive(false);
						Inventory._CurtainGUIEquipment.SetActive(true);
						Inventory._CurtainIconCharacterU.SetActive(true);
						GameObject gameObject25 = GameObject.Find("MessaegeTask");
						float num27 = Screen.width;
						num27 /= 1280f;
						GameObject gameObject26 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
						gameObject26.transform.SetParent(gameObject25.transform.GetChild(5).transform.GetChild(0));
						gameObject26.transform.GetChild(0).GetComponent<RawImage>().texture = Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num24].TextureSubject;
						gameObject26.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
						gameObject26.transform.GetChild(1).GetComponent<Text>().text = "Передан предмет: " + Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num24].NameSubject;
						Transform obj30 = gameObject26.transform;
						Vector3 localScale = new Vector3(1f, 1f);
						gameObject26.transform.localScale = localScale;
						obj30.localScale = localScale;
						gameObject26 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
						gameObject26.transform.SetParent(gameObject25.transform.GetChild(5).transform.GetChild(0));
						gameObject26.transform.GetChild(0).GetComponent<RawImage>().texture = Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num24].TextureSubject;
						gameObject26.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
						gameObject26.transform.GetChild(1).GetComponent<Text>().text = "Выполнено задание: Найти информацию об экспериментах";
						Transform obj31 = gameObject26.transform;
						localScale = new Vector3(1f, 1f);
						gameObject26.transform.localScale = localScale;
						obj31.localScale = localScale;
						gameObject26 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
						gameObject26.transform.SetParent(gameObject25.transform.GetChild(5).transform.GetChild(0));
						gameObject26.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/clearSky");
						gameObject26.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
						gameObject26.transform.GetChild(1).GetComponent<Text>().text = "Улучшен рейтинг у группировки: Чистое Небо";
						Transform obj32 = gameObject26.transform;
						localScale = new Vector3(1f, 1f);
						gameObject26.transform.localScale = localScale;
						obj32.localScale = localScale;
						gameObject26 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
						gameObject26.transform.SetParent(gameObject25.transform.GetChild(5).transform.GetChild(0));
						gameObject26.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/Subject/Money");
						gameObject26.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
						gameObject26.transform.GetChild(1).GetComponent<Text>().text = "Получены деньги: " + Inventory._EmptyTask.RewardMoney + " ru";
						Transform obj33 = gameObject26.transform;
						localScale = new Vector3(1f, 1f);
						gameObject26.transform.localScale = localScale;
						obj33.localScale = localScale;
						Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num24] = new AAAAAAAAAAAAAAAAAAbi();
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 7] += 2;
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[7, 0] += 2;
						if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 7] > 9)
						{
							AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 7] = 9;
						}
						if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[7, 0] > 9)
						{
							AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[7, 0] = 9;
						}
						Inventory._TaskNum = 0;
						Data.TaskAll.RemoveAt(i);
						GPSscript.AAAAAAAAAAAAAAAAAAAAe("CgkI2OGbhtMLEAIQCw");
						return;
					}
				}
			}
			if (i == Data.TaskAll.Count - 1 && !Inventory._taskText)
			{
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Inventory._PointInf = false;
				Inventory._NoneReward = true;
			}
		}
	}

	public static void AAAAAAAAAAAAAAAAAAAAAct()
	{
		Inventory._QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		for (int i = 0; i < Data.TaskAll.Count; i++)
		{
			if (Data.TaskAll[i].NameTask == "Бывай, ЧН")
			{
				Inventory.SoundMenu.clip = Inventory.effectObjective;
				Inventory.SoundMenu.Play();
				Inventory._TaskNum = 0;
				Data.TaskAll.RemoveAt(i);
				if (i >= Data.TaskAll.Count)
				{
					i = Data.TaskAll.Count - 1;
				}
			}
			if (Data.TaskAll[i].NameTask == "До встречи...")
			{
				Inventory.SoundMenu.clip = Inventory.effectObjective;
				Inventory.SoundMenu.Play();
				Inventory._TaskNum = 0;
				Data.TaskAll.RemoveAt(i);
				if (i >= Data.TaskAll.Count)
				{
					i = Data.TaskAll.Count - 1;
				}
			}
			if (Data.TaskAll[i].NameTask == "Бывай, сталкеры...")
			{
				Inventory.SoundMenu.clip = Inventory.effectObjective;
				Inventory.SoundMenu.Play();
				Inventory._TaskNum = 0;
				Data.TaskAll.RemoveAt(i);
				if (i >= Data.TaskAll.Count)
				{
					i = Data.TaskAll.Count - 1;
				}
			}
			if (Data.TaskAll[i].NameTask == "Бывай, банда...")
			{
				Inventory.SoundMenu.clip = Inventory.effectObjective;
				Inventory.SoundMenu.Play();
				Inventory._TaskNum = 0;
				Data.TaskAll.RemoveAt(i);
				if (i >= Data.TaskAll.Count)
				{
					i = Data.TaskAll.Count - 1;
				}
			}
			if (Data.TaskAll[i].NameTask == "Бывай служивые...")
			{
				Inventory.SoundMenu.clip = Inventory.effectObjective;
				Inventory.SoundMenu.Play();
				Inventory._TaskNum = 0;
				Data.TaskAll.RemoveAt(i);
				if (i >= Data.TaskAll.Count)
				{
					i = Data.TaskAll.Count - 1;
				}
			}
			if (Data.TaskAll[i].NameTask == "Получить вознаграждение")
			{
				Inventory.SoundMenu.clip = Inventory.effectObjective;
				Inventory.SoundMenu.Play();
				Inventory._TaskNum = 0;
				Data.TaskAll.RemoveAt(i);
				break;
			}
			if (Data.TaskAll[i].NameTask == "Ликвидатор. Награда")
			{
				Inventory.SoundMenu.clip = Inventory.effectObjective;
				Inventory.SoundMenu.Play();
				Inventory._TaskNum = 0;
				Data.TaskAll.RemoveAt(i);
				if (i >= Data.TaskAll.Count)
				{
					i = Data.TaskAll.Count - 1;
				}
			}
			if (Data.TaskAll[i].NameTask == "Отчет разведчиков")
			{
				Inventory.SoundMenu.clip = Inventory.effectObjective;
				Inventory.SoundMenu.Play();
				Inventory._TaskNum = 0;
				Data.TaskAll.RemoveAt(i);
				if (i >= Data.TaskAll.Count)
				{
					i = Data.TaskAll.Count - 1;
				}
			}
			if (Data.TaskAll[i].NameTask == "Динамит доставлен")
			{
				Inventory.SoundMenu.clip = Inventory.effectObjective;
				Inventory.SoundMenu.Play();
				Inventory._TaskNum = 0;
				Data.TaskAll.RemoveAt(i);
				if (i >= Data.TaskAll.Count)
				{
					i = Data.TaskAll.Count - 1;
				}
			}
			if (Data.TaskAll[i].NameTask == "Братва вооружена")
			{
				Inventory.SoundMenu.clip = Inventory.effectObjective;
				Inventory.SoundMenu.Play();
				Inventory._TaskNum = 0;
				Data.TaskAll.RemoveAt(i);
				if (i >= Data.TaskAll.Count)
				{
					i = Data.TaskAll.Count - 1;
				}
			}
			if (Data.TaskAll[i].NameTask == "Братва экипирована")
			{
				Inventory.SoundMenu.clip = Inventory.effectObjective;
				Inventory.SoundMenu.Play();
				Inventory._TaskNum = 0;
				Data.TaskAll.RemoveAt(i);
				if (i >= Data.TaskAll.Count)
				{
					i = Data.TaskAll.Count - 1;
				}
			}
			if (Data.TaskAll[i].NameTask == "Братство Монолита")
			{
				Inventory.SoundMenu.clip = Inventory.effectObjective;
				Inventory.SoundMenu.Play();
				Inventory._TaskNum = 0;
				Data.TaskAll.RemoveAt(i);
				if (i >= Data.TaskAll.Count)
				{
					i = Data.TaskAll.Count - 1;
				}
			}
			if (Data.TaskAll[i].NameTask == "Декодер доставлен")
			{
				Inventory.SoundMenu.clip = Inventory.effectObjective;
				Inventory.SoundMenu.Play();
				Inventory._TaskNum = 0;
				Data.TaskAll.RemoveAt(i);
				if (i >= Data.TaskAll.Count)
				{
					i = Data.TaskAll.Count - 1;
				}
			}
			if (Data.TaskAll[i].NameTask == "Детали у заказчика")
			{
				Inventory.SoundMenu.clip = Inventory.effectObjective;
				Inventory.SoundMenu.Play();
				Inventory._TaskNum = 0;
				Data.TaskAll.RemoveAt(i);
				if (i >= Data.TaskAll.Count)
				{
					i = Data.TaskAll.Count - 1;
				}
			}
			if (Data.TaskAll[i].NameTask == "Заказчик погиб" && CharacterMotion._curCharacter == 0)
			{
				Inventory.SoundMenu.clip = Inventory.effectObjective;
				Inventory.SoundMenu.Play();
				Inventory._TaskNum = 0;
				Data.TaskAll.RemoveAt(i);
				break;
			}
			if (Data.TaskAll[i].NameTask == "Награда проводника")
			{
				Inventory.SoundMenu.clip = Inventory.effectObjective;
				Inventory.SoundMenu.Play();
				Inventory._TaskNum = 0;
				Data.TaskAll.RemoveAt(i);
				break;
			}
			if (Data.TaskAll[i].NameTask == "Бывай...")
			{
				Inventory.SoundMenu.clip = Inventory.effectObjective;
				Inventory.SoundMenu.Play();
				Inventory._TaskNum = 0;
				Data.TaskAll.RemoveAt(i);
				break;
			}
			if (Data.TaskAll[i].NameTask == "Не оказанная помощь...")
			{
				Inventory.SoundMenu.clip = Inventory.effectObjective;
				Inventory.SoundMenu.Play();
				Inventory._TaskNum = 0;
				Data.TaskAll.RemoveAt(i);
				break;
			}
			if (Data.TaskAll[i].NameTask == "Потерянная цель" || Data.TaskAll[i].NameTask == "Потеряная цель")
			{
				Inventory.SoundMenu.clip = Inventory.effectObjective;
				Inventory.SoundMenu.Play();
				Inventory._TaskNum = 0;
				Data.TaskAll.RemoveAt(i);
				break;
			}
		}
	}

	public static void AAAAAAAAAAAAAAcn()
	{
		GOMessaegeTask = false;
		if (Inventory._CurrentPoint.Count > 0 && CharacterMotion._curCharacter == 0 && Data.TaskAll.Count > 1)
		{
			if (Data.TaskAll[1].NameTask == "Старый скряга" && Data.TaskAll[1].NamePointTask == Data.Points[Inventory._CurrentPoint[0]].namePoint && Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.ID == Data.Points[Inventory._CurrentPoint[0]].curGexPoint.ID)
			{
				Data.OldTask.Add(Data.TaskAll[1].NameTask);
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Data.TaskAll[1] = new TaskBasic1();
				Inventory.AAAAAAAAAAAAAAAAAAAAci();
				Inventory._taskText = true;
				Inventory._TaskNum = 1;
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(true);
				Inventory._CurtainGUIEquipment.SetActive(false);
				Inventory._CurtainIconCharacterU.SetActive(false);
			}
			if (Data.TaskAll[1].NameTask == "Флешка убитого сталкера" && Data.TaskAll[1].NamePointTask == Data.Points[Inventory._CurrentPoint[0]].namePoint && Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.ID == Data.Points[Inventory._CurrentPoint[0]].curGexPoint.ID)
			{
				Data.OldTask.Add(Data.TaskAll[1].NameTask);
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Data.TaskAll[1] = new TaskBasic1_5();
				Inventory.AAAAAAAAAAAAAAAAAAAAci();
				Inventory._taskText = true;
				Inventory._TaskNum = 1;
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(true);
				Inventory._CurtainGUIEquipment.SetActive(false);
				Inventory._CurtainIconCharacterU.SetActive(false);
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 1]++;
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[1, 0]++;
				if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 1] > 9)
				{
					AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 1] = 9;
				}
				if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[1, 0] > 9)
				{
					AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[1, 0] = 9;
				}
				SaveLoad.Difficulty -= 0.035f;
				Inventory._HelpBool = false;
			}
			if (CharacterMotion._curCharacter == 0 && Data.TaskAll[1].NameTask == "Курьер" && Data.TaskAll[1].NamePointTask == Data.Points[Inventory._CurrentPoint[0]].namePoint && Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.ID == Data.Points[Inventory._CurrentPoint[0]].curGexPoint.ID)
			{
				for (int i = 0; i < 20; i++)
				{
					if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].NameSubject == Data.TaskAll[1].QuestSubject.NameSubject)
					{
						Data.OldTask.Add(Data.TaskAll[1].NameTask);
						Inventory.SoundMenu.clip = Inventory.effectNews;
						Inventory.SoundMenu.Play();
						Inventory._QuestSubject = Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i];
						Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i] = new AAAAAAAAAAAAAAAAAAbi();
						Data.TaskAll[1] = new TaskBasic2();
						Inventory.AAAAAAAAAAAAAAAAAAAAci();
						Inventory._taskText = true;
						Inventory._TaskNum = 1;
						Inventory._Equipment = false;
						Inventory._CurtainInventory.SetActive(true);
						Inventory._CurtainGUIEquipment.SetActive(false);
						Inventory._CurtainIconCharacterU.SetActive(false);
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 1]++;
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[1, 0]++;
						if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 1] > 9)
						{
							AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 1] = 9;
						}
						if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[1, 0] > 9)
						{
							AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[1, 0] = 9;
						}
						SaveLoad.Difficulty -= 0.035f;
						break;
					}
				}
			}
			if (Data.TaskAll[1].NameTask == "Информация X18" && Data.TaskAll[1].NamePointTask == Data.Points[Inventory._CurrentPoint[0]].namePoint && Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.ID == Data.Points[Inventory._CurrentPoint[0]].curGexPoint.ID)
			{
				Data.OldTask.Add(Data.TaskAll[1].NameTask);
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Data.TaskAll[1] = new TaskBasic2_5();
				Inventory.AAAAAAAAAAAAAAAAAAAAci();
				Inventory._taskText = true;
				Inventory._TaskNum = 1;
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(true);
				Inventory._CurtainGUIEquipment.SetActive(false);
				Inventory._CurtainIconCharacterU.SetActive(false);
				SaveLoad.Difficulty -= 0.04f;
			}
			if (Data.TaskAll[1].NameTask == "Бар" && Data.TaskAll[1].NamePointTask == Data.Points[Inventory._CurrentPoint[0]].namePoint && Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.ID == Data.Points[Inventory._CurrentPoint[0]].curGexPoint.ID)
			{
				for (int j = 0; j < 20; j++)
				{
					if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[j].NameSubject == Data.TaskAll[1].QuestSubject.NameSubject)
					{
						Data.OldTask.Add(Data.TaskAll[1].NameTask);
						Inventory.SoundMenu.clip = Inventory.effectNews;
						Inventory.SoundMenu.Play();
						Inventory._QuestSubject = Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[j];
						Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[j] = new AAAAAAAAAAAAAAAAAAbi();
						Data.TaskAll[1] = new TaskBasic3();
						Inventory.AAAAAAAAAAAAAAAAAAAAci();
						Inventory._taskText = true;
						Inventory._TaskNum = 1;
						Inventory._Equipment = false;
						Inventory._CurtainInventory.SetActive(true);
						Inventory._CurtainGUIEquipment.SetActive(false);
						Inventory._CurtainIconCharacterU.SetActive(false);
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 1]++;
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[1, 0]++;
						if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 1] > 9)
						{
							AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 1] = 9;
						}
						if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[1, 0] > 9)
						{
							AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[1, 0] = 9;
						}
						SaveLoad.Difficulty -= 0.035f;
						break;
					}
				}
			}
			if (Data.TaskAll[1].NameTask == "Завод Янтарь" && Data.TaskAll[1].NamePointTask == Data.Points[Inventory._CurrentPoint[0]].namePoint && Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.ID == Data.Points[Inventory._CurrentPoint[0]].curGexPoint.ID)
			{
				Data.OldTask.Add(Data.TaskAll[1].NameTask);
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Data.TaskAll[1] = new TaskBasic4();
				Inventory.AAAAAAAAAAAAAAAAAAAAci();
				Inventory._taskText = true;
				Inventory._TaskNum = 1;
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(true);
				Inventory._CurtainGUIEquipment.SetActive(false);
				Inventory._CurtainIconCharacterU.SetActive(false);
				SaveLoad.Difficulty -= 0.03f;
			}
			if (Data.TaskAll[1].NameTask == "Мертвый город" && Data.TaskAll[1].NamePointTask == Data.Points[Inventory._CurrentPoint[0]].namePoint && Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.ID == Data.Points[Inventory._CurrentPoint[0]].curGexPoint.ID)
			{
				Data.OldTask.Add(Data.TaskAll[1].NameTask);
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Data.TaskAll.Add(new TaskAdditional1());
				Inventory.AAAAAAAAAAAAAAAAAAAAci();
				Data.TaskAll[1] = new TaskBasic5();
				Inventory._taskText = true;
				Inventory._TaskNum = 1;
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(true);
				Inventory._CurtainGUIEquipment.SetActive(false);
				Inventory._CurtainIconCharacterU.SetActive(false);
				SaveLoad.Difficulty -= 0.04f;
			}
			if (Data.TaskAll[1].NameTask == "База Свободы" && Data.TaskAll[1].NamePointTask == Data.Points[Inventory._CurrentPoint[0]].namePoint && Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.ID == Data.Points[Inventory._CurrentPoint[0]].curGexPoint.ID)
			{
				Data.OldTask.Add(Data.TaskAll[1].NameTask);
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Data.TaskAll[1] = new TaskBasic6();
				Inventory.AAAAAAAAAAAAAAAAAAAAci();
				Inventory._taskText = true;
				Inventory._TaskNum = 1;
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(true);
				Inventory._CurtainGUIEquipment.SetActive(false);
				Inventory._CurtainIconCharacterU.SetActive(false);
				SaveLoad.Difficulty -= 0.03f;
			}
			if (Data.TaskAll[1].NameTask == "Радар" && Data.TaskAll[1].NamePointTask == Data.Points[Inventory._CurrentPoint[0]].namePoint && Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.ID == Data.Points[Inventory._CurrentPoint[0]].curGexPoint.ID)
			{
				Data.OldTask.Add(Data.TaskAll[1].NameTask);
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Data.TaskAll[1] = new TaskBasic6_5();
				Inventory.AAAAAAAAAAAAAAAAAAAAci();
				Inventory._taskText = true;
				Inventory._TaskNum = 1;
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(true);
				Inventory._CurtainGUIEquipment.SetActive(false);
				Inventory._CurtainIconCharacterU.SetActive(false);
				SaveLoad.Difficulty -= 0.02f;
			}
			if (Data.TaskAll[1].NameTask == "Поиск на Радаре" && Data.TaskAll[1].NamePointTask == Data.Points[Inventory._CurrentPoint[0]].namePoint)
			{
				Data.OldTask.Add(Data.TaskAll[1].NameTask);
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Data.TaskAll[1] = new TaskBasic7();
				Inventory.AAAAAAAAAAAAAAAAAAAAci();
				Data.TaskAll.RemoveAt(0);
				Inventory._taskText = true;
				Inventory._TaskNum = 0;
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(true);
				Inventory._CurtainGUIEquipment.SetActive(false);
				Inventory._CurtainIconCharacterU.SetActive(false);
				SaveLoad.Difficulty -= 0.02f;
			}
		}
		for (int k = 0; k < Data.TaskAll.Count; k++)
		{
			if (Data.TaskAll[k].NameTask == "Проводник" && Data.TaskAll[k].MapName == SceneManager.GetActiveScene().name && Data.CharacterD[Data.TaskAll[k].NumberTurgetInData].Life)
			{
				if (Data.CharacterD[Data.TaskAll[k].NumberTurgetInData].CurGexChar == Data.Points[Data.TaskAll[k].NumberPointOfGuide].curGexPoint)
				{
					Inventory.SoundMenu.clip = Inventory.effectNews;
					Inventory.SoundMenu.Play();
					Inventory._EmptyTask = Data.TaskAll[k];
					Data.TaskAll[k] = new TaskAdditionalGuide2();
					Data.TaskAll[k].KillCharacterName = Inventory._EmptyTask.KillCharacterName;
					Data.TaskAll[k].NamePointTask = Inventory._EmptyTask.NamePointTask;
					Data.TaskAll[k].ImageTask = Data.CharacterD[Inventory._EmptyTask.NumberTurgetInData].SuitChar.IconCharacter;
					Data.TaskAll[k].NumberDealer = Inventory._EmptyTask.NumberDealer;
					Data.TaskAll[k].NumberTurgetInData = Inventory._EmptyTask.NumberTurgetInData;
					Data.CharacterD[Inventory._EmptyTask.NumberTurgetInData].ControlGamer = false;
					Inventory.AAAAAAAAAAAAAAAAAAAAci();
					Inventory._TaskNum = k;
					Inventory._taskText = true;
					Inventory._Equipment = false;
					Inventory._CurtainInventory.SetActive(true);
					Inventory._CurtainGUIEquipment.SetActive(false);
					Inventory._CurtainIconCharacterU.SetActive(false);
					GameObject.Find("Data").GetComponent<Inventory>().AAAAAAAAAAAAAAAAAAcg();
				}
				else
				{
					Data.CharacterD[Data.TaskAll[k].NumberTurgetInData].TaskGexChar = Data.CharacterD[Inventory._currentCharacterNumber].CurGexChar;
				}
			}
			if (Data.TaskAll[k].NameTask == "Проводник" && Data.TaskAll[k].MapName == SceneManager.GetActiveScene().name && !Data.CharacterD[Data.TaskAll[k].NumberTurgetInData].Life)
			{
				Data.CharacterD[Data.TaskAll[k].NumberTurgetInData].ControlGamer = false;
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				ConstructorTasks constructorTasks = Data.TaskAll[k];
				Inventory._EmptyTask = new TaskAdditionalGuideFail();
				Data.TaskAll[k] = Inventory._EmptyTask;
				Inventory.AAAAAAAAAAAAAAAAAAAAAci(constructorTasks.ImageTask, Inventory._EmptyTask.TextTask);
				Inventory._PointInf = false;
				Inventory._capture = false;
				Inventory._CurtainInventory.SetActive(false);
				Inventory._CurtainGUIEquipment.SetActive(true);
				Inventory._CurtainIconCharacterU.SetActive(true);
				GameObject gameObject = GameObject.Find("MessaegeTask");
				float num = Screen.width;
				num /= 1280f;
				GameObject gameObject2 = new GameObject();
				gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
				gameObject2.transform.SetParent(gameObject.transform.GetChild(5).transform.GetChild(0));
				gameObject2.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/guide");
				gameObject2.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
				gameObject2.transform.GetChild(1).GetComponent<Text>().text = "Провалено задание: Проводник";
				Transform obj = gameObject2.transform;
				Vector3 localScale = new Vector3(1f, 1f);
				gameObject2.transform.localScale = localScale;
				obj.localScale = localScale;
				Data.TaskAll.RemoveAt(k);
				Inventory._TaskNum = 0;
				break;
			}
			if (Data.TaskAll[k].NameTask == "Ликвидатор" && Data.TaskAll[k].MapName == SceneManager.GetActiveScene().name && !Data.CharacterD[Data.TaskAll[k].NumberTurgetInData].Life)
			{
				if (Data.CharacterD[CharacterMotion._curCharacter].ControlGamer)
				{
					Inventory.SoundMenu.clip = Inventory.effectNews;
					Inventory.SoundMenu.Play();
					Inventory._EmptyTask = Data.TaskAll[k];
					Data.TaskAll[k] = new TaskAdditionalKiller2();
					Data.TaskAll[k].KillCharacterName = Inventory._EmptyTask.KillCharacterName;
					Data.TaskAll[k].NamePointTask = Inventory._EmptyTask.NamePointTask;
					Data.TaskAll[k].ImageTask = Inventory._EmptyTask.ImageTask;
					Data.TaskAll[k].NumberDealer = Inventory._EmptyTask.NumberDealer;
					Inventory.AAAAAAAAAAAAAAAAAAAAci();
					Inventory._TaskNum = k;
					Inventory._taskText = true;
					Inventory._Equipment = false;
					Inventory._CurtainInventory.SetActive(true);
					Inventory._CurtainGUIEquipment.SetActive(false);
					Inventory._CurtainIconCharacterU.SetActive(false);
				}
				else
				{
					Inventory.SoundMenu.clip = Inventory.effectNews;
					Inventory.SoundMenu.Play();
					Inventory._EmptyTask = Data.TaskAll[k];
					Data.TaskAll[k] = new TaskAdditionalKillerFail();
					Data.TaskAll[k].KillCharacterName = Inventory._EmptyTask.KillCharacterName;
					Data.TaskAll[k].NamePointTask = Inventory._EmptyTask.NamePointTask;
					Data.TaskAll[k].ImageTask = Inventory._EmptyTask.ImageTask;
					Data.TaskAll[k].NumberDealer = Inventory._EmptyTask.NumberDealer;
					Inventory.AAAAAAAAAAAAAAAAAAAAci();
					Inventory._TaskNum = k;
					Inventory._taskText = true;
					Inventory._Equipment = false;
					Inventory._CurtainInventory.SetActive(true);
					Inventory._CurtainGUIEquipment.SetActive(false);
					Inventory._CurtainIconCharacterU.SetActive(false);
				}
			}
			if (Data.TaskAll[k].NameTask == "Захватить точку" && Inventory._CurrentPoint.Count > 0 && Data.CharacterD[CharacterMotion._curCharacter].ControlGamer && Data.Points[Inventory._CurrentPoint[0]].namePoint == Data.TaskAll[k].NamePointTask && Data.Points[Inventory._CurrentPoint[0]].curGexPoint == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar && Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].NameGroup == Data.TaskAll[k].GroupName)
			{
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Inventory._EmptyTask = new TaskAdditionalCapturePoint1();
				Data.TaskAll[k] = Inventory._EmptyTask;
				Data.TaskAll[k].RewardMoney = 500;
				Data.CharacterD[CharacterMotion._curCharacter].Cash += Data.TaskAll[k].RewardMoney;
				Inventory.AAAAAAAAAAAAAAAAAAAAAci(Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].ImageChar, Inventory._EmptyTask.TextTask);
				Inventory._PointInf = false;
				Inventory._capture = false;
				Inventory._CurtainInventory.SetActive(false);
				Inventory._CurtainGUIEquipment.SetActive(true);
				Inventory._CurtainIconCharacterU.SetActive(true);
				GameObject gameObject3 = GameObject.Find("MessaegeTask");
				if (Data.TaskAll[k].RewardMoney > 0)
				{
					float num2 = Screen.width;
					num2 /= 1280f;
					GameObject gameObject4 = new GameObject();
					gameObject4 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
					gameObject4.transform.SetParent(gameObject3.transform.GetChild(5).transform.GetChild(0));
					gameObject4.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/Subject/Money");
					gameObject4.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
					gameObject4.transform.GetChild(1).GetComponent<Text>().text = "Получены деньги: " + Data.TaskAll[k].RewardMoney;
					Transform obj2 = gameObject4.transform;
					Vector3 localScale = new Vector3(1f, 1f);
					gameObject4.transform.localScale = localScale;
					obj2.localScale = localScale;
				}
			}
			if (Data.TaskAll[k].NameTask == "Захватить враждебную точку" && Inventory._CurrentPoint.Count > 0 && Data.CharacterD[CharacterMotion._curCharacter].ControlGamer && Data.Points[Inventory._CurrentPoint[0]].namePoint == Data.TaskAll[k].NamePointTask && Data.Points[Inventory._CurrentPoint[0]].curGexPoint == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar && Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].NameGroup == Data.TaskAll[k].GroupName)
			{
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Inventory._EmptyTask = Data.TaskAll[k];
				Data.TaskAll[k] = new TaskAdditionalCapturePoint1();
				Data.TaskAll[k].NamePointTask = Inventory._EmptyTask.NamePointTask;
				Data.TaskAll[k].ImageTask = Inventory._EmptyTask.ImageTask;
				Data.TaskAll[k].NumberDealer = Inventory._EmptyTask.NumberDealer;
				Data.TaskAll[k].RewardMoney = 2000;
				Data.CharacterD[CharacterMotion._curCharacter].Cash += Data.TaskAll[k].RewardMoney;
				Inventory.AAAAAAAAAAAAAAAAAAAAAci(Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].ImageChar, Data.TaskAll[k].TextTask);
				Inventory._PointInf = false;
				Inventory._capture = false;
				Inventory._CurtainInventory.SetActive(false);
				Inventory._CurtainGUIEquipment.SetActive(true);
				Inventory._CurtainIconCharacterU.SetActive(true);
				GameObject gameObject5 = GameObject.Find("MessaegeTask");
				if (Data.TaskAll[k].RewardMoney > 0)
				{
					float num3 = Screen.width;
					num3 /= 1280f;
					GameObject gameObject6 = new GameObject();
					gameObject6 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
					gameObject6.transform.SetParent(gameObject5.transform.GetChild(5).transform.GetChild(0));
					gameObject6.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/Subject/Money");
					gameObject6.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
					gameObject6.transform.GetChild(1).GetComponent<Text>().text = "Получены деньги: " + Data.TaskAll[k].RewardMoney + " ru";
					Transform obj3 = gameObject6.transform;
					Vector3 localScale = new Vector3(1f, 1f);
					gameObject6.transform.localScale = localScale;
					obj3.localScale = localScale;
				}
				if (Data.Points[Inventory._CurrentPoint[0]].DealerInt == 11)
				{
					GPSscript.AAAAAAAAAAAAAAAAAi("CgkI2OGbhtMLEAIQCg", 1);
				}
			}
			if (Data.TaskAll[k].NameTask == "Брат" && SceneManager.GetActiveScene().name == "Radar" && Data.CharacterD[0].CurGexChar.NameGex != "8x14y")
			{
				Data.OldTask.Add(Data.TaskAll[k].NameTask);
				Inventory._TaskNum = k;
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Data.TaskAll[k] = new TaskBasic8();
				Inventory.AAAAAAAAAAAAAAAAAAAAci();
				Inventory._taskText = true;
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(true);
				Inventory._CurtainGUIEquipment.SetActive(false);
				Inventory._CurtainIconCharacterU.SetActive(false);
			}
			if ((Data.TaskAll[k].NameTask == "Странник" || Data.TaskAll[k].NameTask == "Вечный Странник") && Inventory._CurrentPoint.Count > 0 && Data.Points[Inventory._CurrentPoint[0]].namePoint == "Бункер ученых" && Data.Points[Inventory._CurrentPoint[0]].curGexPoint == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar)
			{
				Data.OldTask.Add(Data.TaskAll[k].NameTask);
				Inventory._TaskNum = k;
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Data.TaskAll[k] = new TaskGlobalchemist0();
				Inventory.AAAAAAAAAAAAAAAAAAAAci();
				Inventory._taskText = true;
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(true);
				Inventory._CurtainGUIEquipment.SetActive(false);
				Inventory._CurtainIconCharacterU.SetActive(false);
			}
			if (Data.TaskAll[k].NameTask == "Найти утерянный прибор" && Inventory._CurrentPoint.Count > 0 && Data.Points[Inventory._CurrentPoint[0]].namePoint == Data.TaskAll[k].NamePointTask && Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.ID == Data.Points[Inventory._CurrentPoint[0]].curGexPoint.ID)
			{
				Data.OldTask.Add(Data.TaskAll[k].NameTask);
				Inventory._TaskNum = k;
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Data.TaskAll[k] = new TaskGlobalchemist2();
				Inventory.AAAAAAAAAAAAAAAAAAAAci();
				Inventory._taskText = true;
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(true);
				Inventory._CurtainGUIEquipment.SetActive(false);
				Inventory._CurtainIconCharacterU.SetActive(false);
			}
			if (Data.TaskAll[k].NameTask == "Информация в Баре" && Inventory._CurrentPoint.Count > 0 && Data.Points[Inventory._CurrentPoint[0]].namePoint == Data.TaskAll[k].NamePointTask && Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.ID == Data.Points[Inventory._CurrentPoint[0]].curGexPoint.ID)
			{
				Data.OldTask.Add(Data.TaskAll[k].NameTask);
				Inventory._TaskNum = k;
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Data.TaskAll[k] = new TaskGlobalchemist3();
				Inventory.AAAAAAAAAAAAAAAAAAAAci();
				Inventory._taskText = true;
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(true);
				Inventory._CurtainGUIEquipment.SetActive(false);
				Inventory._CurtainIconCharacterU.SetActive(false);
				SaveLoad.Difficulty -= 0.03f;
			}
			if (Data.TaskAll[k].NameTask == "Наемники" && Inventory._CurrentPoint.Count > 0 && Data.Points[Inventory._CurrentPoint[0]].namePoint == Data.TaskAll[k].NamePointTask && Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.ID == Data.Points[Inventory._CurrentPoint[0]].curGexPoint.ID)
			{
				Data.OldTask.Add(Data.TaskAll[k].NameTask);
				Inventory._TaskNum = k;
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Data.TaskAll[k] = new TaskGlobalchemist4();
				Inventory.AAAAAAAAAAAAAAAAAAAAci();
				Inventory._taskText = true;
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(true);
				Inventory._CurtainGUIEquipment.SetActive(false);
				Inventory._CurtainIconCharacterU.SetActive(false);
				SaveLoad.Difficulty -= 0.02f;
			}
			if (Data.TaskAll[k].NameTask == "К Радару" && SceneManager.GetActiveScene().name == "Radar")
			{
				Data.OldTask.Add(Data.TaskAll[k].NameTask);
				Inventory._TaskNum = k;
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Data.TaskAll[k] = new TaskGlobalchemist6();
				Inventory.AAAAAAAAAAAAAAAAAAAAci();
				Inventory._taskText = true;
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(true);
				Inventory._CurtainGUIEquipment.SetActive(false);
				Inventory._CurtainIconCharacterU.SetActive(false);
				SaveLoad.Difficulty -= 0.02f;
			}
			if (Data.TaskAll[k].NameTask == "Снова наемники" && Inventory._CurrentPoint.Count > 0 && Data.Points[Inventory._CurrentPoint[0]].namePoint == Data.TaskAll[k].NamePointTask && Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.ID == Data.Points[Inventory._CurrentPoint[0]].curGexPoint.ID)
			{
				Data.OldTask.Add(Data.TaskAll[k].NameTask);
				Inventory._TaskNum = k;
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Data.TaskAll[k] = new TaskGlobalchemist7();
				Inventory.AAAAAAAAAAAAAAAAAAAAci();
				Inventory._taskText = true;
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(true);
				Inventory._CurtainGUIEquipment.SetActive(false);
				Inventory._CurtainIconCharacterU.SetActive(false);
			}
			if (Data.TaskAll[k].NameTask == "ПДА отряда наемников" && Inventory._CurrentPoint.Count > 0 && Data.Points[Inventory._CurrentPoint[0]].namePoint == Data.TaskAll[k].NamePointTask && Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.ID == Data.Points[Inventory._CurrentPoint[0]].curGexPoint.ID)
			{
				Inventory._TaskNum = k;
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Data.TaskAll[k] = new TaskGlobalchemist8_5();
				Inventory.AAAAAAAAAAAAAAAAAAAAci();
				Inventory._taskText = true;
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(true);
				Inventory._CurtainGUIEquipment.SetActive(false);
				Inventory._CurtainIconCharacterU.SetActive(false);
				for (int l = 0; l < 20; l++)
				{
					if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[l].NameSubject == Data.TaskAll[k].QuestSubject.NameSubject)
					{
						Data.OldTask.Add(Data.TaskAll[k].NameTask);
						Inventory._QuestSubject = Data.TaskAll[k].QuestSubject;
						Inventory._TaskNum = k;
						Inventory.SoundMenu.clip = Inventory.effectNews;
						Inventory.SoundMenu.Play();
						Data.TaskAll[k] = new TaskGlobalchemist8();
						Inventory.AAAAAAAAAAAAAAAAAAAAci();
						Inventory._taskText = true;
						Inventory._Equipment = false;
						Inventory._CurtainInventory.SetActive(true);
						Inventory._CurtainGUIEquipment.SetActive(false);
						Inventory._CurtainIconCharacterU.SetActive(false);
						Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[l] = new AAAAAAAAAAAAAAAAAAbi();
						return;
					}
				}
			}
			if (Data.TaskAll[k].NameTask == "Вернуть ПДА" && Inventory._CurrentPoint.Count > 0 && Data.Points[Inventory._CurrentPoint[0]].namePoint == Data.TaskAll[k].NamePointTask && Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.ID == Data.Points[Inventory._CurrentPoint[0]].curGexPoint.ID)
			{
				for (int m = 0; m < 20; m++)
				{
					if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[m].NameSubject == Data.TaskAll[k].QuestSubject.NameSubject)
					{
						Data.OldTask.Add(Data.TaskAll[k].NameTask);
						Inventory._QuestSubject = Data.TaskAll[k].QuestSubject;
						Inventory._TaskNum = k;
						Inventory.SoundMenu.clip = Inventory.effectNews;
						Inventory.SoundMenu.Play();
						Data.TaskAll[k] = new TaskGlobalchemist8_7();
						Inventory.AAAAAAAAAAAAAAAAAAAAci();
						Inventory._taskText = true;
						Inventory._Equipment = false;
						Inventory._CurtainInventory.SetActive(true);
						Inventory._CurtainGUIEquipment.SetActive(false);
						Inventory._CurtainIconCharacterU.SetActive(false);
						Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[m] = new AAAAAAAAAAAAAAAAAAbi();
						return;
					}
				}
			}
			if ((Data.TaskAll[k].NameTask == "Обмен и возвращение прототипа" || Data.TaskAll[k].NameTask == "Обмен") && Inventory._CurrentPoint.Count == 0)
			{
				Data.OldTask.Add(Data.TaskAll[k].NameTask);
				Inventory._TaskNum = k;
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Data.TaskAll[k] = new TaskGlobalchemist9();
				Data.TaskAll[k].ImageTask = Data.CharacterD[CharacterMotion._curCharacter].SuitChar.IconCharacter;
				Inventory.AAAAAAAAAAAAAAAAAAAAci();
				Inventory._taskText = true;
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(true);
				Inventory._CurtainGUIEquipment.SetActive(false);
				Inventory._CurtainIconCharacterU.SetActive(false);
				break;
			}
			if (Data.TaskAll[k].NameTask == "Возвращение прототипа" && Inventory._CurrentPoint.Count > 0 && Data.Points[Inventory._CurrentPoint[0]].namePoint == Data.TaskAll[k].NamePointTask && Data.Points[Inventory._CurrentPoint[0]].curGexPoint == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar)
			{
				for (int n = 0; n < 20; n++)
				{
					if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[n].NameSubject == Data.TaskAll[k].QuestSubject.NameSubject)
					{
						Data.OldTask.Add(Data.TaskAll[k].NameTask);
						Inventory._QuestSubject = Data.TaskAll[k].QuestSubject;
						Inventory._TaskNum = k;
						Inventory.SoundMenu.clip = Inventory.effectNews;
						Inventory.SoundMenu.Play();
						Data.TaskAll[k] = new TaskGlobalchemist10();
						Inventory.AAAAAAAAAAAAAAAAAAAAci();
						Inventory._taskText = true;
						Inventory._Equipment = false;
						Inventory._CurtainInventory.SetActive(true);
						Inventory._CurtainGUIEquipment.SetActive(false);
						Inventory._CurtainIconCharacterU.SetActive(false);
						Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[n] = new AAAAAAAAAAAAAAAAAAbi();
						break;
					}
				}
			}
			if (Data.TaskAll[k].NameTask == "ПСИ-шлем на базе" && Inventory._CurrentPoint.Count == 0)
			{
				Data.OldTask.Add(Data.TaskAll[k].NameTask);
				Inventory._TaskNum = k;
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Data.TaskAll[k] = new TaskGlobalchemist11();
				Inventory.AAAAAAAAAAAAAAAAAAAAci();
				Inventory._taskText = true;
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(true);
				Inventory._CurtainGUIEquipment.SetActive(false);
				Inventory._CurtainIconCharacterU.SetActive(false);
				if (!TaskGlobalchemist10)
				{
					GPSscript.AAAAAAAAAAAAAAAAAi("CgkI2OGbhtMLEAIQCg", 8);
					TaskGlobalchemist10 = true;
				}
			}
			if (Data.TaskAll[k].NameTask == "Путь на Болота" && CharacterMotion._curCharacter == 0 && Inventory._CurrentPoint.Count > 0 && Data.Points[Inventory._CurrentPoint[0]].curGexPoint == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar && Data.Points[Inventory._CurrentPoint[0]].namePoint == "База Чистого Неба")
			{
				if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.CharacterD[CharacterMotion._curCharacter].TypeChInt, 7] < 1 && Data.CharacterD[CharacterMotion._curCharacter].TypeChInt != 0)
				{
					Inventory.MessagePanel(Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].NameGroup + ": ''До тех пор, пока ты бьешься за враждебную группировку, мы не будем говорить с тобой о серьезных делах.''");
				}
				if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 7] < 1)
				{
					Inventory.MessagePanel(Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].NameGroup + ": ''До тех пор, пока мы враждебны, о разговорах не может быть и речи... Добейся доверия моих бойцов, затем приходи.''");
				}
				if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.CharacterD[CharacterMotion._curCharacter].TypeChInt, 7] >= 1 && AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 7] >= 1)
				{
					Data.OldTask.Add(Data.TaskAll[k].NameTask);
					Inventory._TaskNum = k;
					Inventory.SoundMenu.clip = Inventory.effectNews;
					Inventory.SoundMenu.Play();
					Data.TaskAll[k] = new TaskGlobalchemist12();
					Inventory.AAAAAAAAAAAAAAAAAAAAci();
					Inventory._taskText = true;
					Inventory._Equipment = false;
					Inventory._CurtainInventory.SetActive(true);
					Inventory._CurtainGUIEquipment.SetActive(false);
					Inventory._CurtainIconCharacterU.SetActive(false);
					AAAAAAAAAAAAAAAAf aAAAAAAAAAAAAAAAf = new AAAAAAAAAAAAAAAAAAAAAy();
					aAAAAAAAAAAAAAAAf.SuitChar = new AAAAAAAAAAAAAAAAAAbk();
					aAAAAAAAAAAAAAAAf.SuitChar.Protection += 30f;
					aAAAAAAAAAAAAAAAf.WeaponChar = new MP5();
					aAAAAAAAAAAAAAAAf.WeaponChar.Damage += 12f;
					aAAAAAAAAAAAAAAAf.CharBackpack[8] = new AAAAAAAAAAAAAAAAbd();
					aAAAAAAAAAAAAAAAf.CharBackpack[9] = new AAAAAAAAAAAAAAAAAAbs();
					aAAAAAAAAAAAAAAAf.CurGexChar = Gexa.GexLib[110];
					aAAAAAAAAAAAAAAAf.CharUnits.transform.position = Gexa.GexLib[110].GexGO.transform.position;
					aAAAAAAAAAAAAAAAf.Skill = 12;
					Data.CharacterD.Add(aAAAAAAAAAAAAAAAf);
					aAAAAAAAAAAAAAAAf = new AAAAAAAAAAAAAAAAAAAAAy();
					aAAAAAAAAAAAAAAAf.SuitChar = new AAAAAAAAAAAAAAAAAAbk();
					aAAAAAAAAAAAAAAAf.SuitChar.Protection += 30f;
					aAAAAAAAAAAAAAAAf.WeaponChar = new AK74();
					aAAAAAAAAAAAAAAAf.WeaponChar.Damage += 10f;
					aAAAAAAAAAAAAAAAf.CharBackpack[8] = new AAAAAAAAAAAAAAAAbd();
					aAAAAAAAAAAAAAAAf.CharBackpack[9] = new AAAAAAAAAAAAAAAAAAbs();
					aAAAAAAAAAAAAAAAf.CurGexChar = Gexa.GexLib[90];
					aAAAAAAAAAAAAAAAf.CharUnits.transform.position = Gexa.GexLib[90].GexGO.transform.position;
					aAAAAAAAAAAAAAAAf.Skill = 10;
					Data.CharacterD.Add(aAAAAAAAAAAAAAAAf);
					AAAAAAAAAAAAAAAAAAcz.AAAAAAAAAAAAAAAAAcb();
					Inventory.AAAAAAAAAAAAAAAAAbx();
					break;
				}
			}
			if (Data.TaskAll[k].NameTask == "Выбить Ренегатов с болот" && SceneManager.GetActiveScene().name == "Marsh")
			{
				Inventory.AAAAAAAAAAAAAAAAAbx();
				if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAcd[12] < 1)
				{
					Data.OldTask.Add(Data.TaskAll[k].NameTask);
					Inventory._TaskNum = k;
					Inventory.SoundMenu.clip = Inventory.effectNews;
					Inventory.SoundMenu.Play();
					Data.TaskAll[k] = new TaskGlobalchemist13();
					Inventory.AAAAAAAAAAAAAAAAAAAAci();
					Inventory._taskText = true;
					Inventory._Equipment = false;
					Inventory._CurtainInventory.SetActive(true);
					Inventory._CurtainGUIEquipment.SetActive(false);
					Inventory._CurtainIconCharacterU.SetActive(false);
					break;
				}
			}
			if (Data.TaskAll[k].NameTask == "В поисках Хищника" && CharacterMotion._curCharacter == 0 && Inventory._CurrentPoint.Count > 0 && Data.Points[Inventory._CurrentPoint[0]].namePoint == Data.TaskAll[k].NamePointTask && Data.Points[Inventory._CurrentPoint[0]].curGexPoint == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar)
			{
				Data.OldTask.Add(Data.TaskAll[k].NameTask);
				Inventory._TaskNum = k;
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Data.TaskAll[k] = new TaskGlobalchemist14();
				Inventory.AAAAAAAAAAAAAAAAAAAAci();
				Inventory._taskText = true;
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(true);
				Inventory._CurtainGUIEquipment.SetActive(false);
				Inventory._CurtainIconCharacterU.SetActive(false);
			}
			if (Data.TaskAll[k].NameTask == "Артефакт для Хищника" && Inventory._CurrentPoint.Count > 0 && Data.Points[Inventory._CurrentPoint[0]].namePoint == Data.TaskAll[k].NamePointTask && Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.ID == Data.Points[Inventory._CurrentPoint[0]].curGexPoint.ID)
			{
				for (int num4 = 0; num4 < 20; num4++)
				{
					if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num4].NameSubject == Data.TaskAll[k].QuestSubject.NameSubject)
					{
						if (Data.CharacterD[CharacterMotion._curCharacter].TypeChInt != 0)
						{
							Inventory.AAAAAAAAAAAAAAAAAAAAAci(Data.Dealers[Data.CharacterD[CharacterMotion._curCharacter].TypeChInt].ImageChar, Data.Dealers[Data.CharacterD[CharacterMotion._curCharacter].TypeChInt].NameGroup + ": ''" + PlayerPrefs.GetString("HeroName") + ", у нас напряженные отношения с бойцом, которого ты спас. Мы не может тебе больше доверять, как раньше. Кто знает, какой фокус ты еще выкинешь? Так что не взыщи, ты сам по себе, мы сами по себе. Бывай.''");
							GameObject gameObject7 = GameObject.Find("MessaegeTask");
							float num5 = Screen.width;
							num5 /= 1280f;
							GameObject gameObject8 = new GameObject();
							gameObject8 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
							gameObject8.transform.SetParent(gameObject7.transform.GetChild(5).transform.GetChild(0));
							gameObject8.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/netrals");
							gameObject8.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
							gameObject8.transform.GetChild(1).GetComponent<Text>().text = PlayerPrefs.GetString("HeroName") + " покинул группировку: " + Data.CharacterD[CharacterMotion._curCharacter].TypeChar;
							Transform obj4 = gameObject8.transform;
							Vector3 localScale = new Vector3(1f, 1f);
							gameObject8.transform.localScale = localScale;
							obj4.localScale = localScale;
							Data.CharacterD[CharacterMotion._curCharacter].TypeChInt = 0;
							Data.CharacterD[CharacterMotion._curCharacter].TypeChar = AAAAAAAAAAAAAAAAf.TypeCharacter.Странник;
							Data.CharacterD[CharacterMotion._curCharacter].NameCharac = AAAAAAAAAAAAAAAAf.TypeCharacter.Странник.ToString();
							Data.CharacterD[CharacterMotion._curCharacter].CharUnits.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/IconGroup/GasMask64A");
						}
						Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num4] = new AAAAAAAAAAAAAAAAAAbi();
						AAAAAAAAAAAAAAAAf aAAAAAAAAAAAAAAAf2 = new AAAAAAAAAAAAAAAAAAAAAx();
						aAAAAAAAAAAAAAAAf2.SuitChar.ArtContainer = 2;
						aAAAAAAAAAAAAAAAf2.ArtContainers[0] = new AAAAAAAAAAAAAAAAw();
						aAAAAAAAAAAAAAAAf2.ArtContainers[1] = new AAAAAAAAAAAAAAAAAAAbd();
						aAAAAAAAAAAAAAAAf2.WeaponChar = new LR300ML();
						aAAAAAAAAAAAAAAAf2.TypeChInt = Data.CharacterD[CharacterMotion._curCharacter].TypeChInt;
						aAAAAAAAAAAAAAAAf2.NameCharac = Data.CharacterD[CharacterMotion._curCharacter].NameCharac;
						aAAAAAAAAAAAAAAAf2.TypeChar = AAAAAAAAAAAAAAAAf.TypeCharacter.Странник;
						aAAAAAAAAAAAAAAAf2.ControlGamer = true;
						aAAAAAAAAAAAAAAAf2.CurGexChar = Data.CharacterD[CharacterMotion._curCharacter].CurGexChar;
						aAAAAAAAAAAAAAAAf2.CharUnits.transform.position = Data.CharacterD[CharacterMotion._curCharacter].CharUnits.transform.position;
						Data.CharacterD[CharacterMotion._curCharacter].CharUnits.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/IconGroup/GasMask64A");
						aAAAAAAAAAAAAAAAf2.CharUnits.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/IconGroup/GasMask64A");
						aAAAAAAAAAAAAAAAf2.NameU = "Хищник";
						aAAAAAAAAAAAAAAAf2.Skill = 15;
						aAAAAAAAAAAAAAAAf2.CharUnits.gameObject.name = "Хищник";
						aAAAAAAAAAAAAAAAf2.CharBackpack[2] = new Cartridge_5_56x45();
						aAAAAAAAAAAAAAAAf2.CharBackpack[2].Stack = 90;
						aAAAAAAAAAAAAAAAf2.CharBackpack[3] = new AAAAAAAAAAAAAAAAz();
						aAAAAAAAAAAAAAAAf2.CharBackpack[4] = new AAAAAAAAAAAAAAAAbd();
						Data.CharacterD.Add(aAAAAAAAAAAAAAAAf2);
						AAAAAAAAAAAAAAAAAAcz.AAAAAAAAAAAAAAAAAcb();
						Inventory._TaskNum = k;
						Data.TaskAll[k] = new TaskGlobalchemist15();
						Inventory.AAAAAAAAAAAAAAAAAAAAAci(Data.TaskAll[k].ImageTask, Data.TaskAll[k].TextTask);
						break;
					}
				}
			}
			if (Data.TaskAll[k].NameTask == "Путь на Скадовск" && CharacterMotion._curCharacter == 0 && Inventory._CurrentPoint.Count > 0 && Data.Points[Inventory._CurrentPoint[0]].namePoint == Data.TaskAll[k].NamePointTask && Data.Points[Inventory._CurrentPoint[0]].curGexPoint == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar)
			{
				Data.OldTask.Add(Data.TaskAll[k].NameTask);
				Inventory._TaskNum = k;
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Data.TaskAll[k] = new TaskGlobalchemist15_5();
				Inventory.AAAAAAAAAAAAAAAAAAAAci();
				Inventory._taskText = true;
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(true);
				Inventory._CurtainGUIEquipment.SetActive(false);
				Inventory._CurtainIconCharacterU.SetActive(false);
				break;
			}
			if (Data.TaskAll[k].NameTask == "Найти Фокса" && CharacterMotion._curCharacter == 0 && Inventory._CurrentPoint.Count > 0 && Data.Points[Inventory._CurrentPoint[0]].namePoint == Data.TaskAll[k].NamePointTask && Data.Points[Inventory._CurrentPoint[0]].curGexPoint == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar)
			{
				Object.Destroy(CharacterMotion.PointInform);
				Data.OldTask.Add(Data.TaskAll[k].NameTask);
				Inventory._TaskNum = k;
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Data.TaskAll[k] = new TaskGlobalchemist16();
				Inventory.AAAAAAAAAAAAAAAAAAAAci();
				Inventory._taskText = true;
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(true);
				Inventory._CurtainGUIEquipment.SetActive(false);
				Inventory._CurtainIconCharacterU.SetActive(false);
				break;
			}
			if (Data.TaskAll[k].NameTask == "Барыга Фокс" && CharacterMotion._curCharacter == 0 && Inventory._CurrentPoint.Count > 0 && Data.Points[Inventory._CurrentPoint[0]].namePoint == Data.TaskAll[k].NamePointTask && Data.Points[Inventory._CurrentPoint[0]].curGexPoint == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar && Data.CharacterD[0].Cash >= 25000)
			{
				Data.CharacterD[0].Cash -= 25000;
				bool flag = false;
				for (int num6 = 0; num6 < Data.Points.Count; num6++)
				{
					if (Data.Points[num6].namePoint == "Испытательный цех")
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					Data.Points.Add(new TestShop());
				}
				Data.OldTask.Add(Data.TaskAll[k].NameTask);
				Inventory._TaskNum = k;
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Data.TaskAll[k] = new TaskGlobalchemist17();
				Inventory.AAAAAAAAAAAAAAAAAAAAci();
				Inventory._taskText = true;
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(true);
				Inventory._CurtainGUIEquipment.SetActive(false);
				Inventory._CurtainIconCharacterU.SetActive(false);
				break;
			}
			if (Data.TaskAll[k].NameTask == "Испытательный цех" && CharacterMotion._curCharacter == 0 && Inventory._CurrentPoint.Count > 0 && Data.Points[Inventory._CurrentPoint[0]].namePoint == Data.TaskAll[k].NamePointTask && Data.Points[Inventory._CurrentPoint[0]].curGexPoint == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar)
			{
				bool flag2 = false;
				for (int num7 = 0; num7 < 20; num7++)
				{
					if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num7].NameSubject == Data.TaskAll[k].QuestSubject.NameSubject)
					{
						flag2 = true;
						break;
					}
				}
				bool flag3 = false;
				for (int num8 = 0; num8 < Data.CharacterD.Count; num8++)
				{
					if (Data.CharacterD[num8].CharUnits.name == "Хищник" && Data.CharacterD[num8].CurGexChar.ID == Data.Points[Inventory._CurrentPoint[0]].curGexPoint.ID)
					{
						flag3 = true;
					}
				}
				if (!flag2)
				{
					Inventory.MessagePanel("У вас отсутствует ключ-карта");
				}
				if (!flag3)
				{
					Inventory.MessagePanel("Вы не можеты открыть магнитную дверь без Хищника. " + PlayerPrefs.GetString("HeroName") + " и Хищник должены быть на точке.");
				}
				if (flag3 && flag2)
				{
					Data.OldTask.Add(Data.TaskAll[k].NameTask);
					Inventory._TaskNum = k;
					Inventory.SoundMenu.clip = Inventory.effectNews;
					Inventory.SoundMenu.Play();
					Data.TaskAll[k] = new TaskGlobalchemist18();
					Inventory.AAAAAAAAAAAAAAAAAAAAci();
					Inventory._taskText = true;
					Inventory._Equipment = false;
					Inventory._CurtainInventory.SetActive(true);
					Inventory._CurtainGUIEquipment.SetActive(false);
					Inventory._CurtainIconCharacterU.SetActive(false);
					break;
				}
			}
			if (Data.TaskAll[k].NameTask == "Схемы оружия")
			{
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 2] = 0;
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[2, 0] = 0;
				AAAAAAAAAAAAAAAAf aAAAAAAAAAAAAAAAf3 = new AAAAAAAAAAAAAAAAAAAz();
				aAAAAAAAAAAAAAAAf3.SuitChar = new AAAAAAAAAAAAAAAAAAbk();
				aAAAAAAAAAAAAAAAf3.SuitChar.Protection += 15f;
				aAAAAAAAAAAAAAAAf3.WeaponChar = new Val();
				aAAAAAAAAAAAAAAAf3.CharBackpack[8] = new AAAAAAAAAAAAAAAAbd();
				aAAAAAAAAAAAAAAAf3.CharBackpack[9] = new AAAAAAAAAAAAAAAAAAbs();
				aAAAAAAAAAAAAAAAf3.NameU = "Фокс";
				aAAAAAAAAAAAAAAAf3.CharUnits.gameObject.name = "Фокс";
				aAAAAAAAAAAAAAAAf3.CurGexChar = Gexa.GexLib[105];
				aAAAAAAAAAAAAAAAf3.CharUnits.transform.position = Gexa.GexLib[105].GexGO.transform.position;
				aAAAAAAAAAAAAAAAf3.Skill = 12;
				Data.CharacterD.Add(aAAAAAAAAAAAAAAAf3);
				aAAAAAAAAAAAAAAAf3 = new AAAAAAAAAAAAAAAAAAAz();
				aAAAAAAAAAAAAAAAf3.SuitChar = new AAAAAAAAAAAAAAAAAAbk();
				aAAAAAAAAAAAAAAAf3.WeaponChar = new MP5();
				aAAAAAAAAAAAAAAAf3.CharBackpack[8] = new AAAAAAAAAAAAAAAAbd();
				aAAAAAAAAAAAAAAAf3.CharBackpack[9] = new AAAAAAAAAAAAAAAAAAbs();
				aAAAAAAAAAAAAAAAf3.CurGexChar = Gexa.GexLib[84];
				aAAAAAAAAAAAAAAAf3.CharUnits.transform.position = Gexa.GexLib[84].GexGO.transform.position;
				aAAAAAAAAAAAAAAAf3.Skill = 7;
				Data.CharacterD.Add(aAAAAAAAAAAAAAAAf3);
				aAAAAAAAAAAAAAAAf3 = new AAAAAAAAAAAAAAAAAAAz();
				aAAAAAAAAAAAAAAAf3.SuitChar = new AAAAAAAAAAAAAAAAAAAAAbf();
				aAAAAAAAAAAAAAAAf3.WeaponChar = new TOZ34();
				aAAAAAAAAAAAAAAAf3.CharBackpack[8] = new AAAAAAAAAAAAAAAAbd();
				aAAAAAAAAAAAAAAAf3.CharBackpack[9] = new AAAAAAAAAAAAAAAAAAbs();
				aAAAAAAAAAAAAAAAf3.CurGexChar = Gexa.GexLib[103];
				aAAAAAAAAAAAAAAAf3.CharUnits.transform.position = Gexa.GexLib[103].GexGO.transform.position;
				aAAAAAAAAAAAAAAAf3.Skill = 1;
				Data.CharacterD.Add(aAAAAAAAAAAAAAAAf3);
				aAAAAAAAAAAAAAAAf3 = new AAAAAAAAAAAAAAAAAAAz();
				aAAAAAAAAAAAAAAAf3.SuitChar = new AAAAAAAAAAAAAAAAAAbj();
				aAAAAAAAAAAAAAAAf3.WeaponChar = new Obres();
				aAAAAAAAAAAAAAAAf3.CharBackpack[8] = new AAAAAAAAAAAAAAAAbd();
				aAAAAAAAAAAAAAAAf3.CharBackpack[9] = new AAAAAAAAAAAAAAAAAAbs();
				aAAAAAAAAAAAAAAAf3.CurGexChar = Gexa.GexLib[104];
				aAAAAAAAAAAAAAAAf3.CharUnits.transform.position = Gexa.GexLib[104].GexGO.transform.position;
				aAAAAAAAAAAAAAAAf3.Skill = 2;
				Data.CharacterD.Add(aAAAAAAAAAAAAAAAf3);
				aAAAAAAAAAAAAAAAf3 = new AAAAAAAAAAAAAAAAAAAz();
				aAAAAAAAAAAAAAAAf3.CurGexChar = Gexa.GexLib[81];
				aAAAAAAAAAAAAAAAf3.CharUnits.transform.position = Gexa.GexLib[81].GexGO.transform.position;
				aAAAAAAAAAAAAAAAf3.WeaponChar = new Obres();
				Data.CharacterD.Add(aAAAAAAAAAAAAAAAf3);
				AAAAAAAAAAAAAAAAAAcz.AAAAAAAAAAAAAAAAAcb();
				Data.OldTask.Add(Data.TaskAll[k].NameTask);
				Inventory._TaskNum = k;
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Data.TaskAll[k] = new TaskGlobalchemist18_5();
				Inventory.AAAAAAAAAAAAAAAAAAAAci();
				Inventory._taskText = true;
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(true);
				Inventory._CurtainGUIEquipment.SetActive(false);
				Inventory._CurtainIconCharacterU.SetActive(false);
				break;
			}
			if (Data.TaskAll[k].NameTask == "Засада")
			{
				for (int num9 = 0; num9 < Data.CharacterD.Count; num9++)
				{
					if (!(Data.CharacterD[num9].CharUnits.name == "Хищник"))
					{
						continue;
					}
					Data.CharacterD[num9].CurGexChar = Gexa.GexLib[83];
					Data.CharacterD[num9].CharUnits.transform.position = Gexa.GexLib[83].GexGO.transform.position;
					Data.CharacterD[num9].WeaponChar.Damage += 5f;
					CharacterMotion._curCharacter = num9;
					CharacterMotion._PointsMove = 7;
					if (CharacterMotion._NextGex.Count > 0)
					{
						for (int num10 = 0; num10 < CharacterMotion._NextGex.Count; num10++)
						{
							CharacterMotion._NextGex[num10].GexGO.GetComponent<SpriteRenderer>().color = new Color(0.45f, 0.45f, 0.25f, 0f);
						}
						CharacterMotion._NextGex.Clear();
					}
				}
				Data.OldTask.Add(Data.TaskAll[k].NameTask);
				Inventory._TaskNum = k;
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Data.TaskAll[k] = new TaskGlobalchemist18_6();
				Data.TaskAll[k].ImageTask = Data.CharacterD[CharacterMotion._curCharacter].SuitChar.IconCharacter;
				Inventory.AAAAAAAAAAAAAAAAAAAAci();
				Inventory._taskText = true;
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(true);
				Inventory._CurtainGUIEquipment.SetActive(false);
				Inventory._CurtainIconCharacterU.SetActive(false);
				break;
			}
			if (Data.TaskAll[k].NameTask == "Принять бой")
			{
				Inventory.AAAAAAAAAAAAAAAAAbx();
				if (SceneManager.GetActiveScene().name == Data.TaskAll[k].MapName && AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAcd[2] == 0)
				{
					Data.OldTask.Add(Data.TaskAll[k].NameTask);
					Inventory._TaskNum = k;
					Inventory.SoundMenu.clip = Inventory.effectNews;
					Inventory.SoundMenu.Play();
					Data.TaskAll[k] = new TaskGlobalchemist18_7();
					Inventory.AAAAAAAAAAAAAAAAAAAAci();
					Inventory._taskText = true;
					Inventory._Equipment = false;
					Inventory._CurtainInventory.SetActive(true);
					Inventory._CurtainGUIEquipment.SetActive(false);
					Inventory._CurtainIconCharacterU.SetActive(false);
					break;
				}
			}
			if (Data.TaskAll[k].NameTask == "Противник уничтожен")
			{
				Data.OldTask.Add(Data.TaskAll[k].NameTask);
				Inventory._TaskNum = k;
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Data.TaskAll[k] = new TaskGlobalchemist18_8();
				Inventory.AAAAAAAAAAAAAAAAAAAAci();
				Inventory._taskText = true;
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(true);
				Inventory._CurtainGUIEquipment.SetActive(false);
				Inventory._CurtainIconCharacterU.SetActive(false);
				for (int num11 = 0; num11 < Data.CharacterD.Count; num11++)
				{
					if (!(Data.CharacterD[num11].CharUnits.name == "Хищник"))
					{
						continue;
					}
					Data.TaskAll[k].ImageTask = Data.CharacterD[num11].SuitChar.IconCharacter;
					Object.Destroy(Data.CharacterD[num11].CharUnits);
					Data.CharacterD.RemoveAt(num11);
					CharacterMotion._curCharacter = 0;
					CharacterMotion._PointsMove = 6;
					if (CharacterMotion._NextGex.Count > 0)
					{
						for (int num12 = 0; num12 < CharacterMotion._NextGex.Count; num12++)
						{
							CharacterMotion._NextGex[num12].GexGO.GetComponent<SpriteRenderer>().color = new Color(0.45f, 0.45f, 0.25f, 0f);
						}
						CharacterMotion._NextGex.Clear();
					}
					return;
				}
			}
			if (Data.TaskAll[k].NameTask == "Бывай, Хищник")
			{
				Data.OldTask.Add(Data.TaskAll[k].NameTask);
				Inventory._TaskNum = k;
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Data.TaskAll[k] = new TaskGlobalchemist19();
				Inventory.AAAAAAAAAAAAAAAAAAAAci();
				Inventory._taskText = true;
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(true);
				Inventory._CurtainGUIEquipment.SetActive(false);
				Inventory._CurtainIconCharacterU.SetActive(false);
				break;
			}
			if (Data.TaskAll[k].NameTask == "Лагерь ЧН" && SceneManager.GetActiveScene().name == "Military")
			{
				Data.OldTask.Add(Data.TaskAll[k].NameTask);
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Data.TaskAll[k] = new TaskAdditional1_5();
				Inventory.AAAAAAAAAAAAAAAAAAAAci();
				Inventory._TaskNum = k;
				Inventory._taskText = true;
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(true);
				Inventory._CurtainGUIEquipment.SetActive(false);
				Inventory._CurtainIconCharacterU.SetActive(false);
			}
			if (Data.TaskAll[k].NameTask == "Лагерь ЧН на складах" && SceneManager.GetActiveScene().name == "Military" && Data.CharacterD[0].CurGexChar.NameGex == "-6x-7y")
			{
				Data.OldTask.Add(Data.TaskAll[k].NameTask);
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Data.TaskAll[k] = new TaskAdditional2();
				Inventory.AAAAAAAAAAAAAAAAAAAAci();
				Inventory._TaskNum = k;
				Inventory._taskText = true;
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(true);
				Inventory._CurtainGUIEquipment.SetActive(false);
				Inventory._CurtainIconCharacterU.SetActive(false);
			}
			if (Data.TaskAll[k].NameTask == "Отряд ЧН" && SceneManager.GetActiveScene().name == "Radar" && Data.CharacterD[0].CurGexChar.NameGex == "-4x-13y")
			{
				Data.OldTask.Add(Data.TaskAll[k].NameTask);
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Data.TaskAll[k] = new TaskAdditional3();
				Inventory.AAAAAAAAAAAAAAAAAAAAci();
				Inventory._TaskNum = k;
				Inventory._taskText = true;
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(true);
				Inventory._CurtainGUIEquipment.SetActive(false);
				Inventory._CurtainIconCharacterU.SetActive(false);
			}
			if (Data.TaskAll[k].NameTask == "Огневая поддержка" && SceneManager.GetActiveScene().name == "Radar" && AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAcd[5] < 1)
			{
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Data.TaskAll[k] = new TaskAdditional4();
				Inventory.AAAAAAAAAAAAAAAAAAAAci();
				Inventory._TaskNum = k;
				Inventory._taskText = true;
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(true);
				Inventory._CurtainGUIEquipment.SetActive(false);
				Inventory._CurtainIconCharacterU.SetActive(false);
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 7] = 9;
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[7, 0] = 9;
				break;
			}
			if (Data.TaskAll[k].NameTask == "Помощь группировке" && SceneManager.GetActiveScene().name == Data.TaskAll[k].MapName)
			{
				Inventory.AAAAAAAAAAAAAAAAAbx();
				if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAcd[Data.TaskAll[k].NumberEnemy] == 0)
				{
					if (Data.CharacterD[CharacterMotion._curCharacter].ControlGamer)
					{
						Inventory.SoundMenu.clip = Inventory.effectNews;
						Inventory.SoundMenu.Play();
						Inventory._EmptyTask = new TaskAdditionalBalans1();
						Inventory._EmptyTask.NamePointTask = Data.TaskAll[k].NamePointTask;
						Inventory._EmptyTask.MapName = Data.TaskAll[k].MapName;
						Data.TaskAll[k] = Inventory._EmptyTask;
						Inventory.AAAAAAAAAAAAAAAAAAAAAci(Data.Dealers[Inventory._EmptyTask.NumberDealer].ImageChar, Inventory._EmptyTask.TextTask);
						Inventory._PointInf = false;
						Inventory._capture = false;
						Inventory._CurtainInventory.SetActive(false);
						Inventory._CurtainGUIEquipment.SetActive(true);
						Inventory._CurtainIconCharacterU.SetActive(true);
						GameObject gameObject9 = GameObject.Find("MessaegeTask");
						float num13 = Screen.width;
						num13 /= 1280f;
						GameObject gameObject10 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
						gameObject10.transform.SetParent(gameObject9.transform.GetChild(5).transform.GetChild(0));
						gameObject10.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/balans");
						gameObject10.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
						gameObject10.transform.GetChild(1).GetComponent<Text>().text = "Выполнено задание: Помощь группировке";
						Transform obj5 = gameObject10.transform;
						Vector3 localScale = new Vector3(1f, 1f);
						gameObject10.transform.localScale = localScale;
						obj5.localScale = localScale;
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.Points[Inventory._CurrentPoint[0]].ControlInt]++;
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.Points[Inventory._CurrentPoint[0]].ControlInt, 0]++;
						if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.Points[Inventory._CurrentPoint[0]].ControlInt] > 9)
						{
							AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.Points[Inventory._CurrentPoint[0]].ControlInt] = 9;
						}
						if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.Points[Inventory._CurrentPoint[0]].ControlInt, 0] > 9)
						{
							AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.Points[Inventory._CurrentPoint[0]].ControlInt, 0] = 9;
						}
						Inventory._TaskNum = k;
					}
					else
					{
						Inventory.SoundMenu.clip = Inventory.effectNews;
						Inventory.SoundMenu.Play();
						Inventory._EmptyTask = new TaskAdditionalBalansFail();
						Inventory._EmptyTask.NamePointTask = Data.TaskAll[k].NamePointTask;
						Inventory._EmptyTask.MapName = Data.TaskAll[k].MapName;
						Data.TaskAll[k] = Inventory._EmptyTask;
						Inventory.AAAAAAAAAAAAAAAAAAAAAci(Data.Dealers[Inventory._EmptyTask.NumberDealer].ImageChar, Inventory._EmptyTask.TextTask);
						Inventory._PointInf = false;
						Inventory._capture = false;
						Inventory._CurtainInventory.SetActive(false);
						Inventory._CurtainGUIEquipment.SetActive(true);
						Inventory._CurtainIconCharacterU.SetActive(true);
						GameObject gameObject11 = GameObject.Find("MessaegeTask");
						float num14 = Screen.width;
						num14 /= 1280f;
						GameObject gameObject12 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
						gameObject12.transform.SetParent(gameObject11.transform.GetChild(5).transform.GetChild(0));
						gameObject12.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/balans");
						gameObject12.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
						gameObject12.transform.GetChild(1).GetComponent<Text>().text = "провалено задание: Помощь группировке";
						Transform obj6 = gameObject12.transform;
						Vector3 localScale = new Vector3(1f, 1f);
						gameObject12.transform.localScale = localScale;
						obj6.localScale = localScale;
						Inventory._TaskNum = k;
					}
					break;
				}
			}
			if (Data.TaskAll[k].NameTask == "Вернуть детектор" && SceneManager.GetActiveScene().name == "Military")
			{
				bool flag4 = false;
				foreach (string item in Data.OldTask)
				{
					if (item == "Мутный")
					{
						flag4 = true;
						break;
					}
				}
				if (!flag4)
				{
					Data.OldTask.Add("Мутный");
					AAAAAAAAAAAAAAAAf aAAAAAAAAAAAAAAAf4 = new AAAAAAAAAAAAAAAAAAAAAy();
					aAAAAAAAAAAAAAAAf4.SuitChar = new AAAAAAAAAAAAAAAAAAAAbh();
					aAAAAAAAAAAAAAAAf4.WeaponChar = new LR300ML();
					aAAAAAAAAAAAAAAAf4.WeaponChar.Damage += 5f;
					aAAAAAAAAAAAAAAAf4.CharBackpack[8] = new AAAAAAAAAAAAAAAAbd();
					aAAAAAAAAAAAAAAAf4.CharBackpack[9] = new AAAAAAAAAAAAAAAAAAbs();
					aAAAAAAAAAAAAAAAf4.CharBackpack[19] = new AAAAAAAAAAAAAAAAAAAAbr();
					aAAAAAAAAAAAAAAAf4.NameU = "Мутный";
					aAAAAAAAAAAAAAAAf4.CharUnits.gameObject.name = "Мутный";
					aAAAAAAAAAAAAAAAf4.CurGexChar = Gexa.GexLib[380];
					aAAAAAAAAAAAAAAAf4.CharUnits.transform.position = Gexa.GexLib[380].GexGO.transform.position;
					aAAAAAAAAAAAAAAAf4.Skill = 12;
					aAAAAAAAAAAAAAAAf4.Alarm = true;
					aAAAAAAAAAAAAAAAf4.AggressorGexChar = Data.CharacterD[0].CurGexChar;
					Data.CharacterD.Add(aAAAAAAAAAAAAAAAf4);
					AAAAAAAAAAAAAAAAAAcz.AAAAAAAAAAAAAAAAAcb();
					Inventory.SoundMenu.clip = Inventory.effectNews;
					Inventory.SoundMenu.Play();
					Inventory._EmptyTask = new TaskAdditionalMercenaryLifeDetector0_1();
					Data.CharacterD[CharacterMotion._curCharacter].Cash += Inventory._EmptyTask.RewardMoney;
					Inventory.AAAAAAAAAAAAAAAAAAAAAci(Inventory._EmptyTask.ImageTask, Inventory._EmptyTask.TextTask);
					Inventory._PointInf = false;
					Inventory._capture = false;
					Inventory._CurtainInventory.SetActive(false);
					Inventory._CurtainGUIEquipment.SetActive(true);
					Inventory._CurtainIconCharacterU.SetActive(true);
					float num15 = Screen.width;
					num15 /= 1280f;
					GOMessaegeTask = true;
					break;
				}
			}
			if (SceneManager.GetActiveScene().name == "Military")
			{
				bool flag5 = false;
				foreach (string item2 in Data.OldTask)
				{
					if (item2 == "Мутный убит")
					{
						flag5 = true;
						break;
					}
				}
				bool flag6 = false;
				foreach (AAAAAAAAAAAAAAAAf item3 in Data.CharacterD)
				{
					if (item3.NameU == "Мутный" && !item3.Life)
					{
						Data.OldTask.Add("Мутный убит");
						flag6 = true;
						break;
					}
				}
				if (!flag5 && flag6)
				{
					Inventory.MessagePanel("Мутный убит.\nОбыскать труп Мутного. Забрать прибор: ДЖФ - 4");
				}
			}
			if (Data.TaskAll[k].NameTask == "Пропавший отряд" && Inventory._CurrentPoint.Count > 0 && CharacterMotion._curCharacter == 0 && Data.Points[Inventory._CurrentPoint[0]].namePoint == "Т-64" && Data.Points[Inventory._CurrentPoint[0]].curGexPoint == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar)
			{
				bool flag7 = false;
				foreach (string item4 in Data.OldTask)
				{
					if (item4 == "Пространственная аномалия")
					{
						flag7 = true;
						break;
					}
				}
				if (!flag7)
				{
					Data.OldTask.Add("Пространственная аномалия");
					Inventory.SoundMenu.clip = Inventory.effectNews;
					Inventory.SoundMenu.Play();
					Inventory._EmptyTask = new TaskAdditionalMercenaryGroup0();
					Data.TaskAll.Add(Inventory._EmptyTask);
					Inventory.AAAAAAAAAAAAAAAAAAAAAci(Inventory._EmptyTask.ImageTask, Inventory._EmptyTask.TextTask);
					Inventory._Equipment = false;
					Inventory._CurtainInventory.SetActive(false);
					Inventory._CurtainGUIEquipment.SetActive(true);
					Inventory._CurtainIconCharacterU.SetActive(true);
					GameObject gameObject13 = GameObject.Find("MessaegeTask");
					float num16 = Screen.width;
					num16 /= 1280f;
					GameObject gameObject14 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
					gameObject14.transform.SetParent(gameObject13.transform.GetChild(5).transform.GetChild(0));
					gameObject14.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/scientist");
					gameObject14.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
					gameObject14.transform.GetChild(1).GetComponent<Text>().text = "Получено задание: " + Inventory._EmptyTask.NameTask + "\n" + Inventory._EmptyTask.DescriptionTask + Inventory._EmptyTask.QuestSubject.NameSubject + ". Точка: " + Inventory._EmptyTask.NamePointTask;
					Transform obj7 = gameObject14.transform;
					Vector3 localScale = new Vector3(1f, 1f);
					gameObject14.transform.localScale = localScale;
					obj7.localScale = localScale;
					GOMessaegeTask = true;
					break;
				}
			}
			if (Data.TaskAll[k].NameTask == "Пространственная аномалия" && Inventory._CurrentPoint.Count > 0 && CharacterMotion._curCharacter == 0 && Data.Points[Inventory._CurrentPoint[0]].namePoint == Data.TaskAll[k].NamePointTask && Data.Points[Inventory._CurrentPoint[0]].curGexPoint == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar)
			{
				ConstructorTasks constructorTasks2 = Data.TaskAll[k];
				bool flag8 = false;
				for (int num17 = 0; num17 < 20; num17++)
				{
					if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num17] == null || Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num17].NameSubject == "None")
					{
						Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num17] = new AAAAAAAAAAAAAAAAAAca();
						flag8 = true;
						break;
					}
				}
				if (!flag8)
				{
					Inventory.MessagePanel("В рукзаке нет места для предмета: ''" + constructorTasks2.QuestSubject.NameSubject + "''\nНеобходимо освободить для него место...");
				}
				if (flag8)
				{
					Inventory.SoundMenu.clip = Inventory.effectNews;
					Inventory.SoundMenu.Play();
					Inventory._EmptyTask = new TaskAdditionalMercenaryGroup1();
					Data.TaskAll[k] = Inventory._EmptyTask;
					Inventory.AAAAAAAAAAAAAAAAAAAAAci(Inventory._EmptyTask.ImageTask, Inventory._EmptyTask.TextTask);
					Inventory._Equipment = false;
					Inventory._CurtainInventory.SetActive(false);
					Inventory._CurtainGUIEquipment.SetActive(true);
					Inventory._CurtainIconCharacterU.SetActive(true);
					GameObject gameObject15 = GameObject.Find("MessaegeTask");
					float num18 = Screen.width;
					num18 /= 1280f;
					GameObject gameObject16 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
					gameObject16.transform.SetParent(gameObject15.transform.GetChild(5).transform.GetChild(0));
					gameObject16.transform.GetChild(0).GetComponent<RawImage>().texture = constructorTasks2.QuestSubject.TextureSubject;
					gameObject16.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
					gameObject16.transform.GetChild(1).GetComponent<Text>().text = "Получен предмет: " + constructorTasks2.QuestSubject.NameSubject;
					Transform obj8 = gameObject16.transform;
					Vector3 localScale = new Vector3(1f, 1f);
					gameObject16.transform.localScale = localScale;
					obj8.localScale = localScale;
					gameObject16 = new GameObject();
					gameObject16 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
					gameObject16.transform.SetParent(gameObject15.transform.GetChild(5).transform.GetChild(0));
					gameObject16.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/scientist");
					gameObject16.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
					gameObject16.transform.GetChild(1).GetComponent<Text>().text = "Выполнено задание: " + constructorTasks2.NameTask + "\n" + constructorTasks2.DescriptionTask + constructorTasks2.QuestSubject.NameSubject + ". Точка: " + constructorTasks2.NamePointTask;
					Transform obj9 = gameObject16.transform;
					localScale = new Vector3(1f, 1f);
					gameObject16.transform.localScale = localScale;
					obj9.localScale = localScale;
					gameObject16 = new GameObject();
					gameObject16 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
					gameObject16.transform.SetParent(gameObject15.transform.GetChild(5).transform.GetChild(0));
					gameObject16.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/scientist");
					gameObject16.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
					gameObject16.transform.GetChild(1).GetComponent<Text>().text = "Получено задание: " + Inventory._EmptyTask.NameTask + "\n" + Inventory._EmptyTask.DescriptionTask + Inventory._EmptyTask.QuestSubject.NameSubject + ". Точка: " + Inventory._EmptyTask.NamePointTask;
					Transform obj10 = gameObject16.transform;
					localScale = new Vector3(1f, 1f);
					gameObject16.transform.localScale = localScale;
					obj10.localScale = localScale;
				}
				GOMessaegeTask = true;
				break;
			}
			if (Data.TaskAll[k].NameTask == "Сканер-расщепитель" && Inventory._CurrentPoint.Count > 0 && CharacterMotion._curCharacter == 0 && Data.Points[Inventory._CurrentPoint[0]].namePoint == "Т-64" && Data.Points[Inventory._CurrentPoint[0]].curGexPoint == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar)
			{
				ConstructorTasks constructorTasks3 = Data.TaskAll[k];
				bool flag9 = false;
				for (int num19 = 0; num19 < 20; num19++)
				{
					if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num19].NameSubject == Data.TaskAll[k].QuestSubject.NameSubject)
					{
						Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num19] = new AAAAAAAAAAAAAAAAAAbi();
						flag9 = true;
						break;
					}
				}
				if (flag9)
				{
					Inventory.SoundMenu.clip = Inventory.effectNews;
					Inventory.SoundMenu.Play();
					Inventory._EmptyTask = new TaskAdditionalMercenaryGroup2();
					Data.TaskAll[k] = Inventory._EmptyTask;
					Inventory.AAAAAAAAAAAAAAAAAAAAAci(Inventory._EmptyTask.ImageTask, Inventory._EmptyTask.TextTask);
					Inventory._Equipment = false;
					Inventory._CurtainInventory.SetActive(false);
					Inventory._CurtainGUIEquipment.SetActive(true);
					Inventory._CurtainIconCharacterU.SetActive(true);
					GameObject gameObject17 = GameObject.Find("MessaegeTask");
					float num20 = Screen.width;
					num20 /= 1280f;
					GameObject gameObject18 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
					gameObject18.transform.SetParent(gameObject17.transform.GetChild(5).transform.GetChild(0));
					gameObject18.transform.GetChild(0).GetComponent<RawImage>().texture = constructorTasks3.QuestSubject.TextureSubject;
					gameObject18.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
					gameObject18.transform.GetChild(1).GetComponent<Text>().text = "Передан предмет: ''" + constructorTasks3.QuestSubject.NameSubject + "''";
					Transform obj11 = gameObject18.transform;
					Vector3 localScale = new Vector3(1f, 1f);
					gameObject18.transform.localScale = localScale;
					obj11.localScale = localScale;
					gameObject18 = new GameObject();
					gameObject18 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
					gameObject18.transform.SetParent(gameObject17.transform.GetChild(5).transform.GetChild(0));
					gameObject18.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/scientist");
					gameObject18.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
					gameObject18.transform.GetChild(1).GetComponent<Text>().text = "Выполнено задание: " + constructorTasks3.NameTask + "\n" + constructorTasks3.DescriptionTask + constructorTasks3.QuestSubject.NameSubject + ". Точка: " + constructorTasks3.NamePointTask;
					Transform obj12 = gameObject18.transform;
					localScale = new Vector3(1f, 1f);
					gameObject18.transform.localScale = localScale;
					obj12.localScale = localScale;
					gameObject18 = new GameObject();
					gameObject18 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
					gameObject18.transform.SetParent(gameObject17.transform.GetChild(5).transform.GetChild(0));
					gameObject18.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/scientist");
					gameObject18.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
					gameObject18.transform.GetChild(1).GetComponent<Text>().text = "Получено задание: " + Inventory._EmptyTask.NameTask + "\n" + Inventory._EmptyTask.DescriptionTask;
					Transform obj13 = gameObject18.transform;
					localScale = new Vector3(1f, 1f);
					gameObject18.transform.localScale = localScale;
					obj13.localScale = localScale;
					GOMessaegeTask = true;
					break;
				}
			}
			if (Data.TaskAll[k].NameTask == "Начало эксперимента" && Inventory._CurrentPoint.Count == 0)
			{
				ConstructorTasks constructorTasks4 = Data.TaskAll[k];
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Inventory._EmptyTask = new TaskAdditionalMercenaryGroup3();
				Data.TaskAll[k] = Inventory._EmptyTask;
				Inventory.AAAAAAAAAAAAAAAAAAAAAci(Inventory._EmptyTask.ImageTask, Inventory._EmptyTask.TextTask);
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(false);
				Inventory._CurtainGUIEquipment.SetActive(true);
				Inventory._CurtainIconCharacterU.SetActive(true);
				GameObject gameObject19 = GameObject.Find("MessaegeTask");
				float num21 = Screen.width;
				num21 /= 1280f;
				GameObject gameObject20 = new GameObject();
				gameObject20 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
				gameObject20.transform.SetParent(gameObject19.transform.GetChild(5).transform.GetChild(0));
				gameObject20.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/mercenary");
				gameObject20.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
				gameObject20.transform.GetChild(1).GetComponent<Text>().text = "Получено задание: " + Inventory._EmptyTask.DescriptionTask;
				Transform obj14 = gameObject20.transform;
				Vector3 localScale = new Vector3(1f, 1f);
				gameObject20.transform.localScale = localScale;
				obj14.localScale = localScale;
				AAAAAAAAAAAAAAAAf aAAAAAAAAAAAAAAAf5 = new AAAAAAAAAAAAAAAAAAAAAAu();
				aAAAAAAAAAAAAAAAf5.SuitChar = new AAAAAAAAAAAAAAAAAw();
				aAAAAAAAAAAAAAAAf5.SuitChar.Protection += 30f;
				aAAAAAAAAAAAAAAAf5.WeaponChar = new LR300ML();
				aAAAAAAAAAAAAAAAf5.WeaponChar.Damage += 5f;
				aAAAAAAAAAAAAAAAf5.CharBackpack[8] = new AAAAAAAAAAAAAAAAbd();
				aAAAAAAAAAAAAAAAf5.CharBackpack[9] = new AAAAAAAAAAAAAAAAAAbs();
				aAAAAAAAAAAAAAAAf5.CurGexChar = Gexa.GexLib[436];
				aAAAAAAAAAAAAAAAf5.CharUnits.transform.position = Gexa.GexLib[436].GexGO.transform.position + new Vector3(-0.3f, -0.2f, 0f);
				aAAAAAAAAAAAAAAAf5.Skill = 5;
				Data.CharacterD.Add(aAAAAAAAAAAAAAAAf5);
				aAAAAAAAAAAAAAAAf5 = new AAAAAAAAAAAAAAAAAAAAAAu();
				aAAAAAAAAAAAAAAAf5.CharUnits.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("Sound/backMusic/tinnitus3a");
				aAAAAAAAAAAAAAAAf5.CharUnits.GetComponent<AudioSource>().Play();
				aAAAAAAAAAAAAAAAf5.SuitChar = new AAAAAAAAAAAAAAAAAw();
				aAAAAAAAAAAAAAAAf5.SuitChar.Protection += 30f;
				aAAAAAAAAAAAAAAAf5.WeaponChar = new AK74();
				aAAAAAAAAAAAAAAAf5.WeaponChar.Damage += 5f;
				aAAAAAAAAAAAAAAAf5.CharBackpack[8] = new AAAAAAAAAAAAAAAAbd();
				aAAAAAAAAAAAAAAAf5.CharBackpack[9] = new AAAAAAAAAAAAAAAAAAbs();
				aAAAAAAAAAAAAAAAf5.CurGexChar = Gexa.GexLib[436];
				aAAAAAAAAAAAAAAAf5.CharUnits.transform.position = Gexa.GexLib[436].GexGO.transform.position + new Vector3(0.3f, 0f, 0f);
				aAAAAAAAAAAAAAAAf5.Skill = 5;
				Data.CharacterD.Add(aAAAAAAAAAAAAAAAf5);
				aAAAAAAAAAAAAAAAf5 = new AAAAAAAAAAAAAAAAAAba();
				aAAAAAAAAAAAAAAAf5.CharUnits.name = "Кровосос  ";
				aAAAAAAAAAAAAAAAf5.NameU = "Кровосос  ";
				aAAAAAAAAAAAAAAAf5.CharUnits.GetComponent<AudioSource>().clip = aAAAAAAAAAAAAAAAf5.AudioStep_R;
				aAAAAAAAAAAAAAAAf5.CharUnits.GetComponent<AudioSource>().Play();
				aAAAAAAAAAAAAAAAf5.CurGexChar = Gexa.GexLib[436];
				aAAAAAAAAAAAAAAAf5.CharUnits.transform.position = Gexa.GexLib[436].GexGO.transform.position + new Vector3(-0.3f, 0f, 0f);
				Data.CharacterD.Add(aAAAAAAAAAAAAAAAf5);
				AAAAAAAAAAAAAAAAAAcz.AAAAAAAAAAAAAAAAAcb();
				Inventory.SoundEffect.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("Sound/backMusic/thunder/thunder-1");
				Inventory.SoundEffect.GetComponent<AudioSource>().Play();
				GOMessaegeTask = true;
				break;
			}
			if (Data.TaskAll[k].NameTask == "Помощь наемникам" && SceneManager.GetActiveScene().name == "RedForest")
			{
				bool flag10 = false;
				foreach (AAAAAAAAAAAAAAAAf item5 in Data.CharacterD)
				{
					if (item5.NameU == "Кровосос  " && !item5.Life)
					{
						flag10 = true;
						break;
					}
				}
				if (flag10)
				{
					ConstructorTasks constructorTasks5 = Data.TaskAll[k];
					Inventory.SoundMenu.clip = Inventory.effectNews;
					Inventory.SoundMenu.Play();
					Inventory._EmptyTask = new TaskAdditionalMercenaryGroup4();
					Data.TaskAll[k] = Inventory._EmptyTask;
					Inventory.AAAAAAAAAAAAAAAAAAAAAci(Inventory._EmptyTask.ImageTask, Inventory._EmptyTask.TextTask);
					Inventory._Equipment = false;
					Inventory._CurtainInventory.SetActive(false);
					Inventory._CurtainGUIEquipment.SetActive(true);
					Inventory._CurtainIconCharacterU.SetActive(true);
					GameObject gameObject21 = GameObject.Find("MessaegeTask");
					float num22 = Screen.width;
					num22 /= 1280f;
					GameObject gameObject22 = new GameObject();
					gameObject22 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
					gameObject22.transform.SetParent(gameObject21.transform.GetChild(5).transform.GetChild(0));
					gameObject22.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/mercenary");
					gameObject22.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
					gameObject22.transform.GetChild(1).GetComponent<Text>().text = "Выполнено задание: " + constructorTasks5.NameTask + "\n" + constructorTasks5.DescriptionTask + ". Точка: " + constructorTasks5.NamePointTask;
					Transform obj15 = gameObject22.transform;
					Vector3 localScale = new Vector3(1f, 1f);
					gameObject22.transform.localScale = localScale;
					obj15.localScale = localScale;
					gameObject22 = new GameObject();
					gameObject22 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
					gameObject22.transform.SetParent(gameObject21.transform.GetChild(5).transform.GetChild(0));
					gameObject22.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/mercenary");
					gameObject22.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
					gameObject22.transform.GetChild(1).GetComponent<Text>().text = "Получено задание: \n" + Inventory._EmptyTask.DescriptionTask + ". Точка: " + Inventory._EmptyTask.NamePointTask;
					Transform obj16 = gameObject22.transform;
					localScale = new Vector3(1f, 1f);
					gameObject22.transform.localScale = localScale;
					obj16.localScale = localScale;
					GOMessaegeTask = true;
					break;
				}
			}
			if (Data.TaskAll[k].NameTask == "Отряд наемников найден" && Inventory._CurrentPoint.Count > 0 && CharacterMotion._curCharacter == 0 && Data.Points[Inventory._CurrentPoint[0]].namePoint == "Мост в Лиманск" && Data.Points[Inventory._CurrentPoint[0]].curGexPoint == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar)
			{
				ConstructorTasks constructorTasks6 = Data.TaskAll[k];
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Inventory._EmptyTask = new TaskAdditionalMercenaryGroup5();
				Data.TaskAll.RemoveAt(k);
				Inventory.AAAAAAAAAAAAAAAAAAAAAci(Inventory._EmptyTask.ImageTask, Inventory._EmptyTask.TextTask);
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(false);
				Inventory._CurtainGUIEquipment.SetActive(true);
				Inventory._CurtainIconCharacterU.SetActive(true);
				GameObject gameObject23 = GameObject.Find("MessaegeTask");
				float num23 = Screen.width;
				num23 /= 1280f;
				GameObject gameObject24 = new GameObject();
				gameObject24 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
				gameObject24.transform.SetParent(gameObject23.transform.GetChild(5).transform.GetChild(0));
				gameObject24.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/mercenary");
				gameObject24.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
				gameObject24.transform.GetChild(1).GetComponent<Text>().text = "Выполнено задание: Пропавший отряд";
				Transform obj17 = gameObject24.transform;
				Vector3 localScale = new Vector3(1f, 1f);
				gameObject24.transform.localScale = localScale;
				obj17.localScale = localScale;
				gameObject24 = new GameObject();
				gameObject24 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
				gameObject24.transform.SetParent(gameObject23.transform.GetChild(5).transform.GetChild(0));
				gameObject24.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/mercenary");
				gameObject24.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
				gameObject24.transform.GetChild(1).GetComponent<Text>().text = "Выполнено задание: \n" + constructorTasks6.DescriptionTask;
				Transform obj18 = gameObject24.transform;
				localScale = new Vector3(1f, 1f);
				gameObject24.transform.localScale = localScale;
				obj18.localScale = localScale;
				gameObject24 = new GameObject();
				gameObject24 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
				gameObject24.transform.SetParent(gameObject23.transform.GetChild(5).transform.GetChild(0));
				gameObject24.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/Subject/Money");
				gameObject24.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
				gameObject24.transform.GetChild(1).GetComponent<Text>().text = "Получены деньги: " + Inventory._EmptyTask.RewardMoney;
				Transform obj19 = gameObject24.transform;
				localScale = new Vector3(1f, 1f);
				gameObject24.transform.localScale = localScale;
				obj19.localScale = localScale;
				Data.CharacterD[CharacterMotion._curCharacter].Cash += Inventory._EmptyTask.RewardMoney;
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 5]++;
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[5, 0]++;
				if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 5] > 9)
				{
					AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 5] = 9;
				}
				if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[5, 0] > 9)
				{
					AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[5, 0] = 9;
				}
				SaveLoad.Difficulty -= 0.02f;
				GOMessaegeTask = true;
				for (int num24 = 0; num24 < Data.TaskAll.Count; num24++)
				{
					if (Data.TaskAll[num24].NameTask == "Пропавший отряд")
					{
						Data.TaskAll.RemoveAt(num24);
						Data.OldTask.Add("Пропавший отряд");
						break;
					}
				}
				break;
			}
			if (Data.TaskAll[k].NameTask == "Найти детали" && Inventory._CurrentPoint.Count > 0 && CharacterMotion._curCharacter == 0 && Data.Points[Inventory._CurrentPoint[0]].namePoint == "Блокпост ''Север''" && Data.Points[Inventory._CurrentPoint[0]].curGexPoint == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar)
			{
				bool flag11 = false;
				foreach (string item6 in Data.OldTask)
				{
					if (item6 == "''Разговор'' о деталях")
					{
						flag11 = true;
						break;
					}
				}
				if (!flag11)
				{
					bool flag12 = false;
					for (int num25 = 0; num25 < 20; num25++)
					{
						if (Data.Points[Inventory._CurrentPoint[0]].Cache[num25] == null || Data.Points[Inventory._CurrentPoint[0]].Cache[num25].NameSubject == "None")
						{
							Data.Points[Inventory._CurrentPoint[0]].Cache[num25] = new AAAAAAAAAAAAAAAAAAAAAbs();
							flag12 = true;
							break;
						}
					}
					if (!flag12)
					{
						Data.Points[Inventory._CurrentPoint[0]].Cache[10] = new AAAAAAAAAAAAAAAAAAAAAbs();
					}
					for (int num26 = 0; num26 < Data.TaskAll.Count; num26++)
					{
						if (Data.TaskAll[num26].NameTask == "Найти детали")
						{
							Data.TaskAll[num26].NamePointTask = "Мост в Лиманск";
							break;
						}
					}
					AAAAAAAAAAAAAAAAf aAAAAAAAAAAAAAAAf6 = new AAAAAAAAAAAAAAAAAAAz();
					aAAAAAAAAAAAAAAAf6.NameU = "Клещ, Бандит";
					aAAAAAAAAAAAAAAAf6.CharUnits.name = "Клещ, Бандит";
					aAAAAAAAAAAAAAAAf6.SuitChar = new AAAAAAAAAAAAAAAAAAbj();
					aAAAAAAAAAAAAAAAf6.SuitChar.Protection += 10f;
					aAAAAAAAAAAAAAAAf6.WeaponChar = new MP5();
					aAAAAAAAAAAAAAAAf6.WeaponChar.Damage += 5f;
					aAAAAAAAAAAAAAAAf6.CharBackpack[8] = new AAAAAAAAAAAAAAAAbd();
					aAAAAAAAAAAAAAAAf6.CharBackpack[9] = new AAAAAAAAAAAAAAAAAAbs();
					aAAAAAAAAAAAAAAAf6.CurGexChar = Data.Points[Inventory._CurrentPoint[0]].curGexPoint;
					aAAAAAAAAAAAAAAAf6.CharUnits.transform.position = Data.Points[Inventory._CurrentPoint[0]].curGexPoint.GexGO.transform.position + new Vector3(-0.3f, -0.2f, 0f);
					aAAAAAAAAAAAAAAAf6.Skill = 4;
					Data.CharacterD.Add(aAAAAAAAAAAAAAAAf6);
					aAAAAAAAAAAAAAAAf6 = new AAAAAAAAAAAAAAAAAAAz();
					aAAAAAAAAAAAAAAAf6.NameU = "Глыба, Бандит";
					aAAAAAAAAAAAAAAAf6.CharUnits.name = "Глыба, Бандит";
					aAAAAAAAAAAAAAAAf6.SuitChar = new AAAAAAAAAAAAAAAAAAAAAbf();
					aAAAAAAAAAAAAAAAf6.SuitChar.Protection += 5f;
					aAAAAAAAAAAAAAAAf6.WeaponChar = new Winchester1300();
					aAAAAAAAAAAAAAAAf6.WeaponChar.Damage += 5f;
					aAAAAAAAAAAAAAAAf6.CharBackpack[8] = new AAAAAAAAAAAAAAAAbd();
					aAAAAAAAAAAAAAAAf6.CharBackpack[9] = new AAAAAAAAAAAAAAAAAAbs();
					aAAAAAAAAAAAAAAAf6.CharUnits.GetComponent<AudioSource>().clip = aAAAAAAAAAAAAAAAf6.WeaponChar.AudioReload;
					aAAAAAAAAAAAAAAAf6.CharUnits.GetComponent<AudioSource>().Play();
					aAAAAAAAAAAAAAAAf6.CurGexChar = Data.Points[Inventory._CurrentPoint[0]].curGexPoint;
					aAAAAAAAAAAAAAAAf6.CharUnits.transform.position = Data.Points[Inventory._CurrentPoint[0]].curGexPoint.GexGO.transform.position + new Vector3(0.3f, 0f, 0f);
					aAAAAAAAAAAAAAAAf6.Skill = 3;
					Data.CharacterD.Add(aAAAAAAAAAAAAAAAf6);
					AAAAAAAAAAAAAAAAAAcz.AAAAAAAAAAAAAAAAAcb();
					Data.OldTask.Add("Найти детали");
					Data.OldTask.Add("''Разговор'' о деталях");
					ConstructorTasks constructorTasks7 = Data.TaskAll[k];
					Inventory.SoundMenu.clip = Inventory.effectNews;
					Inventory.SoundMenu.Play();
					Inventory._EmptyTask = new TaskAdditionalSpareParts01();
					Data.TaskAll.Add(Inventory._EmptyTask);
					Inventory.AAAAAAAAAAAAAAAAAAAAAci(Inventory._EmptyTask.ImageTask, Inventory._EmptyTask.TextTask);
					Inventory._Equipment = false;
					Inventory._CurtainInventory.SetActive(false);
					Inventory._CurtainGUIEquipment.SetActive(true);
					Inventory._CurtainIconCharacterU.SetActive(true);
					GameObject gameObject25 = GameObject.Find("MessaegeTask");
					float num27 = Screen.width;
					num27 /= 1280f;
					GameObject gameObject26 = new GameObject();
					gameObject26 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
					gameObject26.transform.SetParent(gameObject25.transform.GetChild(5).transform.GetChild(0));
					gameObject26.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/mercenary");
					gameObject26.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
					gameObject26.transform.GetChild(1).GetComponent<Text>().text = "Получено задание: \n" + Inventory._EmptyTask.DescriptionTask + ". Точка: " + Inventory._EmptyTask.NamePointTask;
					Transform obj20 = gameObject26.transform;
					Vector3 localScale = new Vector3(1f, 1f);
					gameObject26.transform.localScale = localScale;
					obj20.localScale = localScale;
					AAAAAAAAAAAAAAAAAAcz.AAAAAAAAAAAAAAAAAcb();
					GOMessaegeTask = true;
					break;
				}
			}
			if (Data.TaskAll[k].NameTask == "''Разговор'' о деталях")
			{
				bool flag13 = false;
				bool flag14 = false;
				foreach (AAAAAAAAAAAAAAAAf item7 in Data.CharacterD)
				{
					if (item7.NameU == "Глыба, Бандит" && !item7.Life)
					{
						flag13 = true;
					}
					if (item7.NameU == "Клещ, Бандит" && !item7.Life)
					{
						flag14 = true;
					}
				}
				if (flag13 && flag14)
				{
					Data.TaskAll.RemoveAt(k);
					for (int num28 = 0; num28 < Data.TaskAll.Count; num28++)
					{
						if (Data.TaskAll[num28].NameTask == "Найти детали")
						{
							Inventory._TaskNum = num28;
							break;
						}
					}
					Inventory.MessagePanel("Бандиты уничтожены.\nОбыскать тайник на точке, забрать запчасти и доставить их к мосту в Лиманск.");
					break;
				}
			}
			if (Data.TaskAll[k].NameTask == "Спасти новичка" && Inventory._CurrentPoint.Count > 0 && CharacterMotion._curCharacter == 0 && Data.Points[Inventory._CurrentPoint[0]].namePoint == "Перевернутый тепловоз" && Data.Points[Inventory._CurrentPoint[0]].curGexPoint == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar)
			{
				Data.OldTask.Add("Спасти новичка");
				AAAAAAAAAAAAAAAAf aAAAAAAAAAAAAAAAf7 = new AAAAAAAAAAAAAAAAAs();
				aAAAAAAAAAAAAAAAf7.NameU = "Баламут, Одиночки";
				aAAAAAAAAAAAAAAAf7.CharUnits.name = "Баламут, Одиночки";
				aAAAAAAAAAAAAAAAf7.CurGexChar = Data.Points[Inventory._CurrentPoint[0]].curGexPoint;
				aAAAAAAAAAAAAAAAf7.CharUnits.transform.position = Data.Points[Inventory._CurrentPoint[0]].curGexPoint.GexGO.transform.position + new Vector3(-0.3f, -0.2f, 0f);
				aAAAAAAAAAAAAAAAf7.Skill = 0;
				aAAAAAAAAAAAAAAAf7.ControlGamer = true;
				Data.CharacterD.Add(aAAAAAAAAAAAAAAAf7);
				AAAAAAAAAAAAAAAAAAcz.AAAAAAAAAAAAAAAAAcb();
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Inventory._EmptyTask = new TaskAdditionalSaveNovice1();
				Data.TaskAll[k] = Inventory._EmptyTask;
				Inventory.AAAAAAAAAAAAAAAAAAAAAci(Inventory._EmptyTask.ImageTask, Inventory._EmptyTask.TextTask);
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(false);
				Inventory._CurtainGUIEquipment.SetActive(true);
				Inventory._CurtainIconCharacterU.SetActive(true);
				GameObject gameObject27 = GameObject.Find("MessaegeTask");
				float num29 = Screen.width;
				num29 /= 1280f;
				GameObject gameObject28 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
				gameObject28.transform.SetParent(gameObject27.transform.GetChild(5).transform.GetChild(0));
				gameObject28.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/netrals");
				gameObject28.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
				gameObject28.transform.GetChild(1).GetComponent<Text>().text = "Выполнено задание: Спасти новичка";
				Transform obj21 = gameObject28.transform;
				Vector3 localScale = new Vector3(1f, 1f);
				gameObject28.transform.localScale = localScale;
				obj21.localScale = localScale;
				gameObject28 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
				gameObject28.transform.SetParent(gameObject27.transform.GetChild(5).transform.GetChild(0));
				gameObject28.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/guide");
				gameObject28.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
				gameObject28.transform.GetChild(1).GetComponent<Text>().text = "Получено задание: Доставить Баламута в деревню новичков.";
				Transform obj22 = gameObject28.transform;
				localScale = new Vector3(1f, 1f);
				gameObject28.transform.localScale = localScale;
				obj22.localScale = localScale;
				AAAAAAAAAAAAAAAAAAcz.AAAAAAAAAAAAAAAAAcb();
				GOMessaegeTask = true;
				break;
			}
			if (Data.TaskAll[k].NameTask == "Баламут")
			{
				for (int num30 = 0; num30 < Data.CharacterD.Count; num30++)
				{
					if (Data.CharacterD[num30].NameU == "Баламут, Одиночки" && !Data.CharacterD[num30].Life)
					{
						Inventory.MessagePanel("Провалено задание: Доставить Баламута в деревню новичков.");
						Data.TaskAll.RemoveAt(k);
						return;
					}
					if (Data.CharacterD[num30].NameU == "Баламут, Одиночки" && Data.CharacterD[num30].Life && Inventory._CurrentPoint.Count > 0 && Data.Points[Inventory._CurrentPoint[0]].namePoint == "Деревня новичков" && Data.Points[Inventory._CurrentPoint[0]].curGexPoint == Data.CharacterD[num30].CurGexChar)
					{
						Inventory.SoundMenu.clip = Inventory.effectNews;
						Inventory.SoundMenu.Play();
						Inventory._EmptyTask = new TaskAdditionalSaveNovice2();
						Inventory.AAAAAAAAAAAAAAAAAAAAAci(Inventory._EmptyTask.ImageTask, Inventory._EmptyTask.TextTask);
						Inventory._Equipment = false;
						Inventory._CurtainInventory.SetActive(false);
						Inventory._CurtainGUIEquipment.SetActive(true);
						Inventory._CurtainIconCharacterU.SetActive(true);
						GameObject gameObject29 = GameObject.Find("MessaegeTask");
						float num31 = Screen.width;
						num31 /= 1280f;
						GameObject gameObject30 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
						gameObject30.transform.SetParent(gameObject29.transform.GetChild(5).transform.GetChild(0));
						gameObject30.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/netrals");
						gameObject30.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
						gameObject30.transform.GetChild(1).GetComponent<Text>().text = "Выполнено задание: Доставить Баламута в деревню новичков";
						Transform obj23 = gameObject30.transform;
						Vector3 localScale = new Vector3(1f, 1f);
						gameObject30.transform.localScale = localScale;
						obj23.localScale = localScale;
						gameObject30 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
						gameObject30.transform.SetParent(gameObject29.transform.GetChild(5).transform.GetChild(0));
						gameObject30.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/guide");
						gameObject30.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
						gameObject30.transform.GetChild(1).GetComponent<Text>().text = "Получены деньги: 1800 ru";
						Transform obj24 = gameObject30.transform;
						localScale = new Vector3(1f, 1f);
						gameObject30.transform.localScale = localScale;
						obj24.localScale = localScale;
						gameObject30 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
						gameObject30.transform.SetParent(gameObject29.transform.GetChild(5).transform.GetChild(0));
						gameObject30.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/netrals");
						gameObject30.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
						gameObject30.transform.GetChild(1).GetComponent<Text>().text = "Ваш авторитет у одиночек повысился!";
						Transform obj25 = gameObject30.transform;
						localScale = new Vector3(1f, 1f);
						gameObject30.transform.localScale = localScale;
						obj25.localScale = localScale;
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 1]++;
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[1, 0]++;
						if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 1] > 9)
						{
							AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 1] = 9;
						}
						if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[1, 0] > 9)
						{
							AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[1, 0] = 9;
						}
						Data.CharacterD[0].Cash += 1800;
						AAAAAAAAAAAAAAAAAAcz.AAAAAAAAAAAAAAAAAcb();
						GOMessaegeTask = true;
						GameObject.Find("Data").GetComponent<Inventory>().AAAAAAAAAAAAAAAAAAcg();
						Object.Destroy(Data.CharacterD[num30].CharUnits);
						Data.CharacterD.RemoveAt(num30);
						CharacterMotion._curCharacter = 0;
						Data.TaskAll.RemoveAt(k);
						Inventory._TaskNum = 0;
						return;
					}
				}
			}
			if (Data.TaskAll[k].NameTask == "Найти кольт" && Inventory._CurrentPoint.Count > 0 && CharacterMotion._curCharacter == 0 && Data.Points[Inventory._CurrentPoint[0]].namePoint == "Барьер" && Data.Points[Inventory._CurrentPoint[0]].curGexPoint == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar)
			{
				Data.OldTask.Add("Найти кольт");
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Inventory._EmptyTask = new TaskAdditionalColt1();
				Data.TaskAll[k] = Inventory._EmptyTask;
				Inventory.AAAAAAAAAAAAAAAAAAAAAci(Inventory._EmptyTask.ImageTask, Inventory._EmptyTask.TextTask);
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(false);
				Inventory._CurtainGUIEquipment.SetActive(true);
				Inventory._CurtainIconCharacterU.SetActive(true);
				GameObject gameObject31 = GameObject.Find("MessaegeTask");
				float num32 = Screen.width;
				num32 /= 1280f;
				GameObject gameObject32 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
				gameObject32.transform.SetParent(gameObject31.transform.GetChild(5).transform.GetChild(0));
				gameObject32.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/netrals");
				gameObject32.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
				gameObject32.transform.GetChild(1).GetComponent<Text>().text = "Обновлено задание: Принести на Барьер антирадиационные препараты - 2шт. Забрать кольт.";
				Transform obj26 = gameObject32.transform;
				Vector3 localScale = new Vector3(1f, 1f);
				gameObject32.transform.localScale = localScale;
				obj26.localScale = localScale;
				AAAAAAAAAAAAAAAAAAcz.AAAAAAAAAAAAAAAAAcb();
				GOMessaegeTask = true;
				break;
			}
			if (Data.TaskAll[k].NameTask == "Антирад на барьер" && Inventory._CurrentPoint.Count > 0 && CharacterMotion._curCharacter == 0 && Data.Points[Inventory._CurrentPoint[0]].namePoint == "Барьер" && Data.Points[Inventory._CurrentPoint[0]].curGexPoint == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar)
			{
				bool flag15 = false;
				for (int num33 = 0; num33 < 20; num33++)
				{
					if (Data.CharacterD[0].CharBackpack[num33].NameSubject == "Антирадиационные препараты" && Data.CharacterD[0].CharBackpack[num33].Stack >= 2)
					{
						Data.CharacterD[0].CharBackpack[num33] = new M1911A1unique();
						flag15 = true;
						break;
					}
				}
				if (flag15)
				{
					Inventory.SoundMenu.clip = Inventory.effectNews;
					Inventory.SoundMenu.Play();
					Inventory._EmptyTask = new TaskAdditionalColt2();
					Data.TaskAll[k] = Inventory._EmptyTask;
					Inventory.AAAAAAAAAAAAAAAAAAAAAci(Inventory._EmptyTask.ImageTask, Inventory._EmptyTask.TextTask);
					Inventory._Equipment = false;
					Inventory._CurtainInventory.SetActive(false);
					Inventory._CurtainGUIEquipment.SetActive(true);
					Inventory._CurtainIconCharacterU.SetActive(true);
					GameObject gameObject33 = GameObject.Find("MessaegeTask");
					float num34 = Screen.width;
					num34 /= 1280f;
					GameObject gameObject34 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
					gameObject34.transform.SetParent(gameObject33.transform.GetChild(5).transform.GetChild(0));
					gameObject34.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/duty");
					gameObject34.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
					gameObject34.transform.GetChild(1).GetComponent<Text>().text = "Выполнено задание: Принести на Барьер антирадиационные препараты - 2шт, забрать кольт.";
					Transform obj27 = gameObject34.transform;
					Vector3 localScale = new Vector3(1f, 1f);
					gameObject34.transform.localScale = localScale;
					obj27.localScale = localScale;
					gameObject34 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
					gameObject34.transform.SetParent(gameObject33.transform.GetChild(5).transform.GetChild(0));
					gameObject34.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/netrals");
					gameObject34.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
					gameObject34.transform.GetChild(1).GetComponent<Text>().text = "Обновлено задание: Доставить кольт в Ангар на Свалке.";
					Transform obj28 = gameObject34.transform;
					localScale = new Vector3(1f, 1f);
					gameObject34.transform.localScale = localScale;
					obj28.localScale = localScale;
					gameObject34 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
					gameObject34.transform.SetParent(gameObject33.transform.GetChild(5).transform.GetChild(0));
					gameObject34.transform.GetChild(0).GetComponent<RawImage>().texture = new AAAAAAAAAAAAAAAAz().TextureSubject;
					gameObject34.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
					gameObject34.transform.GetChild(1).GetComponent<Text>().text = "Переданы предметы: Антирадиационные препараты.";
					Transform obj29 = gameObject34.transform;
					localScale = new Vector3(1f, 1f);
					gameObject34.transform.localScale = localScale;
					obj29.localScale = localScale;
					gameObject34 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
					gameObject34.transform.SetParent(gameObject33.transform.GetChild(5).transform.GetChild(0));
					gameObject34.transform.GetChild(0).GetComponent<RawImage>().texture = new M1911A1unique().TextureSubject;
					gameObject34.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
					gameObject34.transform.GetChild(1).GetComponent<Text>().text = "Получен предмет: Кольт сталкера.";
					Transform obj30 = gameObject34.transform;
					localScale = new Vector3(1f, 1f);
					gameObject34.transform.localScale = localScale;
					obj30.localScale = localScale;
					AAAAAAAAAAAAAAAAAAcz.AAAAAAAAAAAAAAAAAcb();
					GOMessaegeTask = true;
					break;
				}
			}
			if (Data.TaskAll[k].NameTask == "Найти Следопыта" && Inventory._CurrentPoint.Count > 0 && CharacterMotion._curCharacter == 0 && Data.Points[Inventory._CurrentPoint[0]].namePoint == "Дорога в темную долину" && Data.Points[Inventory._CurrentPoint[0]].curGexPoint == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar)
			{
				Data.OldTask.Add("Найти Следопыта");
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Inventory._EmptyTask = new TaskAdditionalquestPathfinder1();
				Data.TaskAll[k] = Inventory._EmptyTask;
				Inventory.AAAAAAAAAAAAAAAAAAAAAci(Inventory._EmptyTask.ImageTask, Inventory._EmptyTask.TextTask);
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(false);
				Inventory._CurtainGUIEquipment.SetActive(true);
				Inventory._CurtainIconCharacterU.SetActive(true);
				GameObject gameObject35 = GameObject.Find("MessaegeTask");
				float num35 = Screen.width;
				num35 /= 1280f;
				GameObject gameObject36 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
				gameObject36.transform.SetParent(gameObject35.transform.GetChild(5).transform.GetChild(0));
				gameObject36.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/netrals");
				gameObject36.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
				gameObject36.transform.GetChild(1).GetComponent<Text>().text = "Обновлено задание: Убить Следопыта.";
				Transform obj31 = gameObject36.transform;
				Vector3 localScale = new Vector3(1f, 1f);
				gameObject36.transform.localScale = localScale;
				obj31.localScale = localScale;
				AAAAAAAAAAAAAAAAf aAAAAAAAAAAAAAAAf8 = new AAAAAAAAAAAAAAAAAAAAAAv();
				aAAAAAAAAAAAAAAAf8.NameU = "Следопыт";
				aAAAAAAAAAAAAAAAf8.CharUnits.name = "Следопыт";
				aAAAAAAAAAAAAAAAf8.WeaponChar = new Bekas12Tactical();
				aAAAAAAAAAAAAAAAf8.WeaponChar.Damage += 7f;
				aAAAAAAAAAAAAAAAf8.CharBackpack[8] = new AAAAAAAAAAAAAAAAbd();
				aAAAAAAAAAAAAAAAf8.CharBackpack[9] = new AAAAAAAAAAAAAAAAAAbs();
				aAAAAAAAAAAAAAAAf8.CharBackpack[10] = new AAAAAAAAAAAAAAAAbd();
				aAAAAAAAAAAAAAAAf8.CharBackpack[11] = new AAAAAAAAAAAAAAAAAAbs();
				aAAAAAAAAAAAAAAAf8.CharBackpack[12] = new AAAAAAAAAAAAAAAAy();
				aAAAAAAAAAAAAAAAf8.CharBackpack[13] = new AAAAAAAAAAAAAAAAAAbs();
				aAAAAAAAAAAAAAAAf8.CurGexChar = Gexa.GexLib[559];
				aAAAAAAAAAAAAAAAf8.CharUnits.transform.position = Gexa.GexLib[559].GexGO.transform.position + new Vector3(-0.3f, 0f, 0f);
				aAAAAAAAAAAAAAAAf8.Skill = 10;
				Data.CharacterD.Add(aAAAAAAAAAAAAAAAf8);
				AAAAAAAAAAAAAAAAAAcz.AAAAAAAAAAAAAAAAAcb();
				AAAAAAAAAAAAAAAAAAcz.AAAAAAAAAAAAAAAAAcb();
				GOMessaegeTask = true;
				break;
			}
			if (Data.TaskAll[k].NameTask == "Убить Следопыта" && CharacterMotion._curCharacter == 0)
			{
				foreach (AAAAAAAAAAAAAAAAf item8 in Data.CharacterD)
				{
					if (item8.CharUnits.name == "Следопыт" && item8.CurHealth < 48f)
					{
						Inventory.SoundMenu.clip = Inventory.effectNews;
						Inventory.SoundMenu.Play();
						Inventory._EmptyTask = new TaskAdditionalquestPathfinder2();
						Data.TaskAll[k] = Inventory._EmptyTask;
						Inventory.AAAAAAAAAAAAAAAAAAAAAci(Inventory._EmptyTask.ImageTask, Inventory._EmptyTask.TextTask);
						Inventory._Equipment = false;
						Inventory._CurtainInventory.SetActive(false);
						Inventory._CurtainGUIEquipment.SetActive(true);
						Inventory._CurtainIconCharacterU.SetActive(true);
						GameObject gameObject37 = GameObject.Find("MessaegeTask");
						float num36 = Screen.width;
						num36 /= 1280f;
						GameObject gameObject38 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
						gameObject38.transform.SetParent(gameObject37.transform.GetChild(5).transform.GetChild(0));
						gameObject38.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/netrals");
						gameObject38.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
						gameObject38.transform.GetChild(1).GetComponent<Text>().text = "Обновлено задание: Найти в тайнике препараты: ПСИ-блокада. Доставить Препараты Следопыту.";
						Transform obj32 = gameObject38.transform;
						Vector3 localScale = new Vector3(1f, 1f);
						gameObject38.transform.localScale = localScale;
						obj32.localScale = localScale;
						item8.TypeChInt = 1;
						item8.TypeChar = AAAAAAAAAAAAAAAAf.TypeCharacter.Одиночки;
						item8.NameCharac = item8.TypeChar.ToString();
						item8.CharUnits.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/IconGroup/StalkerIcon64");
						item8.SuitChar.UpGrade = 50f;
						item8.SuitChar.SingModification = true;
						item8.SuitChar.WeightSubject = 24f;
						item8.Bleeding = 0f;
						item8.CurHealth = 45f;
						item8.Life = true;
						AAAAAAAAAAAAAAAAAAcz.AAAAAAAAAAAAAAAAAcb();
						GOMessaegeTask = true;
						return;
					}
				}
			}
			if (Data.TaskAll[k].NameTask == "Найти препарат: ПСИ-блокада" && Inventory._CurrentPoint.Count > 0 && CharacterMotion._curCharacter == 0 && Data.Points[Inventory._CurrentPoint[0]].namePoint == "Логово мутантов на свалке" && Data.Points[Inventory._CurrentPoint[0]].curGexPoint == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar)
			{
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Inventory._EmptyTask = new TaskAdditionalquestPathfinder3();
				Data.TaskAll[k] = Inventory._EmptyTask;
				Inventory.AAAAAAAAAAAAAAAAAAAAAci(Inventory._EmptyTask.ImageTask, Inventory._EmptyTask.TextTask);
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(false);
				Inventory._CurtainGUIEquipment.SetActive(true);
				Inventory._CurtainIconCharacterU.SetActive(true);
				GameObject gameObject39 = GameObject.Find("MessaegeTask");
				float num37 = Screen.width;
				num37 /= 1280f;
				GameObject gameObject40 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
				gameObject40.transform.SetParent(gameObject39.transform.GetChild(5).transform.GetChild(0));
				gameObject40.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/netrals");
				gameObject40.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
				gameObject40.transform.GetChild(1).GetComponent<Text>().text = "Обновлено задание: Осмотреть тайник на точке - ''Логово мутантов на свалке'', найти препарат ПСИ-блокада";
				Transform obj33 = gameObject40.transform;
				Vector3 localScale = new Vector3(1f, 1f);
				gameObject40.transform.localScale = localScale;
				obj33.localScale = localScale;
				gameObject40 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
				gameObject40.transform.SetParent(gameObject39.transform.GetChild(5).transform.GetChild(0));
				gameObject40.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/netrals");
				gameObject40.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
				gameObject40.transform.GetChild(1).GetComponent<Text>().text = "Обновлено задание: Доставить Следопыту ПСИ-блокаду";
				Transform obj34 = gameObject40.transform;
				localScale = new Vector3(1f, 1f);
				gameObject40.transform.localScale = localScale;
				obj34.localScale = localScale;
				Data.Points[Inventory._CurrentPoint[0]].Cache[7] = new AAAAAAAAAAAAAAAAAAAAAbq();
				Data.Points[Inventory._CurrentPoint[0]].Cache[7].Stack = 3;
				AAAAAAAAAAAAAAAAAAcz.AAAAAAAAAAAAAAAAAcb();
				GOMessaegeTask = true;
				break;
			}
			if ((CharacterMotion._curCharacter == 0 && Data.TaskAll[k].NameTask == "Найти препарат: ПСИ-блокада") || (CharacterMotion._curCharacter == 0 && Data.TaskAll[k].NameTask == "Доставить Следопыту ПСИ-блокаду"))
			{
				for (int num38 = 0; num38 < Data.CharacterD.Count; num38++)
				{
					if (!(Data.CharacterD[num38].NameU == "Следопыт") || Data.CharacterD[num38].CurGexChar != Data.CharacterD[0].CurGexChar)
					{
						continue;
					}
					for (int num39 = 0; num39 < 20; num39++)
					{
						if (Data.CharacterD[0].CharBackpack[num39].NameSubject == "ПСИ-блокада" && Data.CharacterD[0].CharBackpack[num39].Stack >= 2)
						{
							Inventory.SoundMenu.clip = Inventory.effectNews;
							Inventory.SoundMenu.Play();
							Inventory._EmptyTask = new TaskAdditionalquestPathfinder4();
							Data.TaskAll[k] = Inventory._EmptyTask;
							Inventory.AAAAAAAAAAAAAAAAAAAAAci(Inventory._EmptyTask.ImageTask, Inventory._EmptyTask.TextTask);
							Inventory._Equipment = false;
							Inventory._CurtainInventory.SetActive(false);
							Inventory._CurtainGUIEquipment.SetActive(true);
							Inventory._CurtainIconCharacterU.SetActive(true);
							GameObject gameObject41 = GameObject.Find("MessaegeTask");
							float num40 = Screen.width;
							num40 /= 1280f;
							GameObject gameObject42 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
							gameObject42.transform.SetParent(gameObject41.transform.GetChild(5).transform.GetChild(0));
							gameObject42.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/netrals");
							gameObject42.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
							gameObject42.transform.GetChild(1).GetComponent<Text>().text = "Выполнены задания: Найти Следопыта, найти препарат ПСИ-блокада, спасти Следопыта.";
							Transform obj35 = gameObject42.transform;
							Vector3 localScale = new Vector3(1f, 1f);
							gameObject42.transform.localScale = localScale;
							obj35.localScale = localScale;
							gameObject42 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
							gameObject42.transform.SetParent(gameObject41.transform.GetChild(5).transform.GetChild(0));
							gameObject42.transform.GetChild(0).GetComponent<RawImage>().texture = Data.CharacterD[0].CharBackpack[num39].TextureSubject;
							gameObject42.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
							gameObject42.transform.GetChild(1).GetComponent<Text>().text = "Потерян предмет: " + Data.CharacterD[0].CharBackpack[num39].NameSubject + " " + Data.CharacterD[0].CharBackpack[num39].Stack + "шт.";
							Transform obj36 = gameObject42.transform;
							localScale = new Vector3(1f, 1f);
							gameObject42.transform.localScale = localScale;
							obj36.localScale = localScale;
							gameObject42 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
							gameObject42.transform.SetParent(gameObject41.transform.GetChild(5).transform.GetChild(0));
							gameObject42.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/netrals");
							gameObject42.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
							gameObject42.transform.GetChild(1).GetComponent<Text>().text = "Получено задание: Найти аномальную куртку";
							Transform obj37 = gameObject42.transform;
							localScale = new Vector3(1f, 1f);
							gameObject42.transform.localScale = localScale;
							obj37.localScale = localScale;
							Data.CharacterD[0].CharBackpack[num39] = new AAAAAAAAAAAAAAAAAAbi();
							Object.Destroy(Data.CharacterD[num38].CharUnits);
							Data.CharacterD.RemoveAt(num38);
							Inventory._CurrentCharUnit.Clear();
							AAAAAAAAAAAAAAAAAAcz.AAAAAAAAAAAAAAAAAcb();
							GOMessaegeTask = true;
							return;
						}
					}
				}
			}
			if (Data.TaskAll[k].NameTask == "Найти препарат: ПСИ-блокада" || Data.TaskAll[k].NameTask == "Доставить Следопыту ПСИ-блокаду")
			{
				foreach (AAAAAAAAAAAAAAAAf item9 in Data.CharacterD)
				{
					if (item9.NameU == "Следопыт" && !item9.Life)
					{
						Inventory.SoundMenu.clip = Inventory.effectNews;
						Inventory.SoundMenu.Play();
						Inventory.AAAAAAAAAAAAAAAAAAAAAci((Texture2D)Resources.Load("Sprites/IconChar/iconCharDead128"), "Следопыт погиб. Вы не успели доставить Следопыту препараты.");
						Inventory._Equipment = false;
						Inventory._CurtainInventory.SetActive(false);
						Inventory._CurtainGUIEquipment.SetActive(true);
						Inventory._CurtainIconCharacterU.SetActive(true);
						GameObject gameObject43 = GameObject.Find("MessaegeTask");
						float num41 = Screen.width;
						num41 /= 1280f;
						GameObject gameObject44 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
						gameObject44.transform.SetParent(gameObject43.transform.GetChild(5).transform.GetChild(0));
						gameObject44.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/netrals");
						gameObject44.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
						gameObject44.transform.GetChild(1).GetComponent<Text>().text = "Провалено задание: " + Data.TaskAll[k].NameTask;
						Transform obj38 = gameObject44.transform;
						Vector3 localScale = new Vector3(1f, 1f);
						gameObject44.transform.localScale = localScale;
						obj38.localScale = localScale;
						AAAAAAAAAAAAAAAAAAcz.AAAAAAAAAAAAAAAAAcb();
						GOMessaegeTask = true;
						Inventory._TaskNum = 0;
						Data.TaskAll.RemoveAt(k);
						return;
					}
				}
			}
			if (Data.TaskAll[k].NameTask == "Добраться до аномальной трясины" && Inventory._CurrentPoint.Count > 0 && CharacterMotion._curCharacter == 0 && Data.Points[Inventory._CurrentPoint[0]].namePoint == "Аномальная трясина" && Data.Points[Inventory._CurrentPoint[0]].curGexPoint == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar)
			{
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Inventory._EmptyTask = new TaskAdditionalquestPathfinder5();
				Inventory.AAAAAAAAAAAAAAAAAAAAAci(Inventory._EmptyTask.ImageTask, Inventory._EmptyTask.TextTask);
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(false);
				Inventory._CurtainGUIEquipment.SetActive(true);
				Inventory._CurtainIconCharacterU.SetActive(true);
				GameObject gameObject45 = GameObject.Find("MessaegeTask");
				float num42 = Screen.width;
				num42 /= 1280f;
				GameObject gameObject46;
				Vector3 localScale;
				for (int num43 = 0; num43 < 20; num43++)
				{
					if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num43].NameSubject == "None")
					{
						Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num43] = new AAAAAAAAAAAAAAAAAAAAz();
						gameObject46 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
						gameObject46.transform.SetParent(gameObject45.transform.GetChild(5).transform.GetChild(0));
						gameObject46.transform.GetChild(0).GetComponent<RawImage>().texture = Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num43].TextureSubject;
						gameObject46.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
						gameObject46.transform.GetChild(1).GetComponent<Text>().text = "Получен предмет: " + Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num43].NameSubject;
						Transform obj39 = gameObject46.transform;
						localScale = new Vector3(1f, 1f);
						gameObject46.transform.localScale = localScale;
						obj39.localScale = localScale;
						Inventory._TaskNum = 0;
						Data.TaskAll.RemoveAt(k);
						return;
					}
				}
				Data.Points[Inventory._CurrentPoint[0]].Cache[7] = new AAAAAAAAAAAAAAAAAAAAz();
				gameObject46 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
				gameObject46.transform.SetParent(gameObject45.transform.GetChild(5).transform.GetChild(0));
				gameObject46.transform.GetChild(0).GetComponent<RawImage>().texture = Data.Points[Inventory._CurrentPoint[0]].Cache[7].TextureSubject;
				gameObject46.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
				gameObject46.transform.GetChild(1).GetComponent<Text>().text = "В аномалии обнаружен предмет: " + Data.Points[Inventory._CurrentPoint[0]].Cache[7].NameSubject;
				Transform obj40 = gameObject46.transform;
				localScale = new Vector3(1f, 1f);
				gameObject46.transform.localScale = localScale;
				obj40.localScale = localScale;
				Inventory._TaskNum = 0;
				Data.TaskAll.RemoveAt(k);
				break;
			}
			if (Data.TaskAll[k].NameTask == "Разведать планы военных" && Inventory._CurrentPoint.Count > 0 && CharacterMotion._curCharacter == 0 && Data.Points[Inventory._CurrentPoint[0]].namePoint == "Институт Агропром" && Data.Points[Inventory._CurrentPoint[0]].curGexPoint == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar)
			{
				Data.OldTask.Add("Разведать планы военных");
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Inventory._EmptyTask = new TaskAdditionalOperationPlan1();
				Data.TaskAll[k] = Inventory._EmptyTask;
				Inventory.AAAAAAAAAAAAAAAAAAAAAci(Inventory._EmptyTask.ImageTask, Inventory._EmptyTask.TextTask);
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(false);
				Inventory._CurtainGUIEquipment.SetActive(true);
				Inventory._CurtainIconCharacterU.SetActive(true);
				GameObject gameObject47 = GameObject.Find("MessaegeTask");
				float num44 = Screen.width;
				num44 /= 1280f;
				GameObject gameObject48 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
				gameObject48.transform.SetParent(gameObject47.transform.GetChild(5).transform.GetChild(0));
				gameObject48.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/netrals");
				gameObject48.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
				gameObject48.transform.GetChild(1).GetComponent<Text>().text = "Обновлено задание: Найти капитана Ширко. Добыть любым способом план операции.";
				gameObject48.transform.localScale = new Vector3(1f, 1f);
				AAAAAAAAAAAAAAAAf aAAAAAAAAAAAAAAAf9 = new AAAAAAAAAAAAAAAAAAAAq();
				aAAAAAAAAAAAAAAAf9.NameU = "Капитан Ширко, Военные";
				aAAAAAAAAAAAAAAAf9.CharUnits.name = aAAAAAAAAAAAAAAAf9.NameU;
				aAAAAAAAAAAAAAAAf9.WeaponChar.Damage += 8f;
				aAAAAAAAAAAAAAAAf9.SuitChar = new AAAAAAAAAAAAAAAAAAAAAbj();
				aAAAAAAAAAAAAAAAf9.Bonus = false;
				aAAAAAAAAAAAAAAAf9.CharBackpack[8] = new AAAAAAAAAAAAAAAAbd();
				aAAAAAAAAAAAAAAAf9.CharBackpack[9] = new AAAAAAAAAAAAAAAAAAbs();
				aAAAAAAAAAAAAAAAf9.CharBackpack[10] = new AAAAAAAAAAAAAAAAbd();
				aAAAAAAAAAAAAAAAf9.CharBackpack[11] = new AAAAAAAAAAAAAAAAAAbs();
				aAAAAAAAAAAAAAAAf9.CharBackpack[12] = new AAAAAAAAAAAAAAAAy();
				aAAAAAAAAAAAAAAAf9.CharBackpack[13] = new AAAAAAAAAAAAAAAAAAbs();
				aAAAAAAAAAAAAAAAf9.CharBackpack[13] = new AAAAAAAAAAAAAAAbf();
				aAAAAAAAAAAAAAAAf9.CurGexChar = Gexa.GexLib[86];
				aAAAAAAAAAAAAAAAf9.CharUnits.transform.position = Gexa.GexLib[86].GexGO.transform.position + new Vector3(-0.3f, 0f, 0f);
				aAAAAAAAAAAAAAAAf9.Skill = 10;
				Data.CharacterD.Add(aAAAAAAAAAAAAAAAf9);
				AAAAAAAAAAAAAAAAAAcz.AAAAAAAAAAAAAAAAAcb();
				GOMessaegeTask = true;
				break;
			}
			if (Data.TaskAll[k].NameTask == "Найти капитана Ширко" && CharacterMotion._curCharacter == 0)
			{
				bool flag16 = false;
				foreach (AAAAAAAAAAAAAAAAf item10 in Data.CharacterD)
				{
					if (item10.NameU == "Капитан Ширко, Военные" && !item10.Life)
					{
						flag16 = true;
						break;
					}
				}
				if (flag16)
				{
					Inventory.SoundMenu.clip = Inventory.effectNews;
					Inventory.SoundMenu.Play();
					Inventory._EmptyTask = new TaskAdditionalOperationPlan2();
					Data.TaskAll[k] = Inventory._EmptyTask;
					Inventory.AAAAAAAAAAAAAAAAAAAAAci(Inventory._EmptyTask.ImageTask, Inventory._EmptyTask.TextTask);
					Inventory._Equipment = false;
					Inventory._CurtainInventory.SetActive(false);
					Inventory._CurtainGUIEquipment.SetActive(true);
					Inventory._CurtainIconCharacterU.SetActive(true);
					GameObject gameObject49 = GameObject.Find("MessaegeTask");
					float num45 = Screen.width;
					num45 /= 1280f;
					GameObject gameObject50 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
					gameObject50.transform.SetParent(gameObject49.transform.GetChild(5).transform.GetChild(0));
					gameObject50.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/netrals");
					gameObject50.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
					gameObject50.transform.GetChild(1).GetComponent<Text>().text = "Обновлено задание: Найти у Капитана Ширко план операции доставить его на ближайшую базу одиночек.";
					gameObject50.transform.localScale = new Vector3(1f, 1f);
					AAAAAAAAAAAAAAAAAAcz.AAAAAAAAAAAAAAAAAcb();
					GOMessaegeTask = true;
					break;
				}
			}
			if (Data.TaskAll[k].NameTask == "Доставить план военных Одиночкам" && Inventory._CurrentPoint.Count > 0 && CharacterMotion._curCharacter == 0 && Data.Points[Inventory._CurrentPoint[0]].DealerInt == 1 && Data.Points[Inventory._CurrentPoint[0]].curGexPoint == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar)
			{
				bool flag17 = false;
				for (int num46 = 0; num46 < 20; num46++)
				{
					if (Data.CharacterD[0].CharBackpack[num46].NameSubject == "Планшет капитана Ширко")
					{
						Data.CharacterD[0].CharBackpack[num46] = new AAAAAAAAAAAAAAAAAAAbf();
						flag17 = true;
						break;
					}
				}
				if (flag17)
				{
					Data.OldTask.Add("Доставить план военных Одиночкам");
					Inventory.SoundMenu.clip = Inventory.effectNews;
					Inventory.SoundMenu.Play();
					Inventory._EmptyTask = new TaskAdditionalOperationPlan3();
					Data.TaskAll[k] = Inventory._EmptyTask;
					Inventory.AAAAAAAAAAAAAAAAAAAAAci(Inventory._EmptyTask.ImageTask, Inventory._EmptyTask.TextTask);
					Inventory._Equipment = false;
					Inventory._CurtainInventory.SetActive(false);
					Inventory._CurtainGUIEquipment.SetActive(true);
					Inventory._CurtainIconCharacterU.SetActive(true);
					GameObject gameObject51 = GameObject.Find("MessaegeTask");
					float num47 = Screen.width;
					num47 /= 1280f;
					GameObject gameObject52 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
					gameObject52.transform.SetParent(gameObject51.transform.GetChild(5).transform.GetChild(0));
					gameObject52.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/netrals");
					gameObject52.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
					gameObject52.transform.GetChild(1).GetComponent<Text>().text = "Выполнено задание: Разведать планы военных.";
					Transform obj41 = gameObject52.transform;
					Vector3 localScale = new Vector3(1f, 1f);
					gameObject52.transform.localScale = localScale;
					obj41.localScale = localScale;
					gameObject52 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
					gameObject52.transform.SetParent(gameObject51.transform.GetChild(5).transform.GetChild(0));
					gameObject52.transform.GetChild(0).GetComponent<RawImage>().texture = new AAAAAAAAAAAAAAAbf().TextureSubject;
					gameObject52.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
					gameObject52.transform.GetChild(1).GetComponent<Text>().text = "Передан предмет: Планшет капитана Ширко.";
					Transform obj42 = gameObject52.transform;
					localScale = new Vector3(1f, 1f);
					gameObject52.transform.localScale = localScale;
					obj42.localScale = localScale;
					gameObject52 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
					gameObject52.transform.SetParent(gameObject51.transform.GetChild(5).transform.GetChild(0));
					gameObject52.transform.GetChild(0).GetComponent<RawImage>().texture = new AAAAAAAAAAAAAAAAAAAbf().TextureSubject;
					gameObject52.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
					gameObject52.transform.GetChild(1).GetComponent<Text>().text = "Получен предмет: артефакт ''Пустышка''.";
					Transform obj43 = gameObject52.transform;
					localScale = new Vector3(1f, 1f);
					gameObject52.transform.localScale = localScale;
					obj43.localScale = localScale;
					gameObject52 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
					gameObject52.transform.SetParent(gameObject51.transform.GetChild(5).transform.GetChild(0));
					gameObject52.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/netrals");
					gameObject52.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
					gameObject52.transform.GetChild(1).GetComponent<Text>().text = "Техник сталкеров бесплатно отремотрировал ваше оружие и броню.";
					Transform obj44 = gameObject52.transform;
					localScale = new Vector3(1f, 1f);
					gameObject52.transform.localScale = localScale;
					obj44.localScale = localScale;
					Data.CharacterD[0].SuitChar.State = 100f;
					Data.CharacterD[0].WeaponChar.State = 100f;
					Inventory._TaskNum = 0;
					Data.TaskAll.RemoveAt(k);
					AAAAAAAAAAAAAAAAAAcz.AAAAAAAAAAAAAAAAAcb();
					GOMessaegeTask = true;
					break;
				}
			}
			if (Data.TaskAll[k].NameTask == "Найти награбленный хабар" && Inventory._CurrentPoint.Count > 0 && CharacterMotion._curCharacter == 0 && Data.Points[Inventory._CurrentPoint[0]].namePoint == "Лагерь на болоте" && Data.Points[Inventory._CurrentPoint[0]].curGexPoint == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar)
			{
				for (int num48 = 0; num48 < 20; num48++)
				{
					if (Data.CharacterD[0].CharBackpack[num48].NameSubject == "None")
					{
						Data.CharacterD[0].CharBackpack[num48] = new AAAAAAAAAAAAAAAAAAAbj();
						Data.OldTask.Add("Найти награбленный хабар");
						Inventory.SoundMenu.clip = Inventory.effectNews;
						Inventory.SoundMenu.Play();
						Inventory._EmptyTask = new TaskAdditionalReturnBearMod0();
						Data.TaskAll[k] = Inventory._EmptyTask;
						Inventory.AAAAAAAAAAAAAAAAAAAAAci(Inventory._EmptyTask.ImageTask, Inventory._EmptyTask.TextTask);
						Inventory._Equipment = false;
						Inventory._CurtainInventory.SetActive(false);
						Inventory._CurtainGUIEquipment.SetActive(true);
						Inventory._CurtainIconCharacterU.SetActive(true);
						GameObject gameObject53 = GameObject.Find("MessaegeTask");
						float num49 = Screen.width;
						num49 /= 1280f;
						GameObject gameObject54 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
						gameObject54.transform.SetParent(gameObject53.transform.GetChild(5).transform.GetChild(0));
						gameObject54.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/netrals0");
						gameObject54.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
						gameObject54.transform.GetChild(1).GetComponent<Text>().text = "Обновлено задание: Найти Копченого на Свалке.";
						Transform obj45 = gameObject54.transform;
						Vector3 localScale = new Vector3(1f, 1f);
						gameObject54.transform.localScale = localScale;
						obj45.localScale = localScale;
						gameObject54 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
						gameObject54.transform.SetParent(gameObject53.transform.GetChild(5).transform.GetChild(0));
						gameObject54.transform.GetChild(0).GetComponent<RawImage>().texture = new AAAAAAAAAAAAAAAAAAAbj().TextureSubject;
						gameObject54.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
						gameObject54.transform.GetChild(1).GetComponent<Text>().text = "Найден предмет: Записка Хмурого.";
						Transform obj46 = gameObject54.transform;
						localScale = new Vector3(1f, 1f);
						gameObject54.transform.localScale = localScale;
						obj46.localScale = localScale;
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 2] = 0;
						AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[2, 0] = 0;
						Inventory._TaskNum = 0;
						GOMessaegeTask = true;
						return;
					}
					if (num48 == 19 && Data.CharacterD[0].CharBackpack[num48].NameSubject != "None")
					{
						Inventory.MessagePanel("Рюкзак переполнен, необходимо освободить место для найденного предмета.");
					}
				}
			}
			if (Data.TaskAll[k].NameTask == "Найти Копченого" && CharacterMotion._curCharacter == 0 && SceneManager.GetActiveScene().name == "Dump")
			{
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Inventory._EmptyTask = new TaskAdditionalReturnBearMod1();
				Data.TaskAll[k] = Inventory._EmptyTask;
				Inventory.AAAAAAAAAAAAAAAAAAAAAci(Inventory._EmptyTask.ImageTask, Inventory._EmptyTask.TextTask);
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(false);
				Inventory._CurtainGUIEquipment.SetActive(true);
				Inventory._CurtainIconCharacterU.SetActive(true);
				GameObject gameObject55 = GameObject.Find("MessaegeTask");
				float num50 = Screen.width;
				num50 /= 1280f;
				GameObject gameObject56 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
				gameObject56.transform.SetParent(gameObject55.transform.GetChild(5).transform.GetChild(0));
				gameObject56.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/netrals0");
				gameObject56.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
				gameObject56.transform.GetChild(1).GetComponent<Text>().text = "Обновлено задание: Добраться до точки: ''Вентиляционная шахта'', Агропром. Забрать из тайника остатки хабара.";
				Transform obj47 = gameObject56.transform;
				Vector3 localScale = new Vector3(1f, 1f);
				gameObject56.transform.localScale = localScale;
				obj47.localScale = localScale;
				Inventory._TaskNum = 0;
				GOMessaegeTask = true;
				break;
			}
			if (Data.TaskAll[k].NameTask == "Тайник Хмурого и Копченого" && Inventory._CurrentPoint.Count > 0 && CharacterMotion._curCharacter == 0 && Data.Points[Inventory._CurrentPoint[0]].namePoint == "Вентиляционная шахта" && Data.Points[Inventory._CurrentPoint[0]].curGexPoint == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar)
			{
				Data.Points[Inventory._CurrentPoint[0]].Cache[4] = new AAAAAAAAAAAAAAAAAAbq();
				Data.Points[Inventory._CurrentPoint[0]].Cache[4].Stack = 2;
				Data.Points[Inventory._CurrentPoint[0]].Cache[5] = new AAAAAAAAAAAAAAAAAAAbk();
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Inventory._EmptyTask = new TaskAdditionalReturnBearMod2();
				Data.TaskAll[k] = Inventory._EmptyTask;
				Inventory.AAAAAAAAAAAAAAAAAAAAAci(Inventory._EmptyTask.ImageTask, Inventory._EmptyTask.TextTask);
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(false);
				Inventory._CurtainGUIEquipment.SetActive(true);
				Inventory._CurtainIconCharacterU.SetActive(true);
				GameObject gameObject57 = GameObject.Find("MessaegeTask");
				GameObject gameObject58 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
				gameObject58.transform.SetParent(gameObject57.transform.GetChild(5).transform.GetChild(0));
				gameObject58.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/netrals0");
				gameObject58.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
				gameObject58.transform.GetChild(1).GetComponent<Text>().text = "Обновлено задание: Обыскать тайник. Доставить содержимое тайника на ближайшую базу одиночек.";
				Transform obj48 = gameObject58.transform;
				Vector3 localScale = new Vector3(1f, 1f);
				gameObject58.transform.localScale = localScale;
				obj48.localScale = localScale;
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 2] = 0;
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[2, 0] = 0;
				Inventory._TaskNum = 0;
				GOMessaegeTask = true;
				break;
			}
			if (Data.TaskAll[k].NameTask == "Разведка на насосной станции" && Inventory._CurrentPoint.Count > 0 && CharacterMotion._curCharacter == 0 && Data.Points[Inventory._CurrentPoint[0]].namePoint == "Насосная станция" && Data.Points[Inventory._CurrentPoint[0]].curGexPoint == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar)
			{
				Data.OldTask.Add("Разведка на насосной станции");
				Data.Points[Inventory._CurrentPoint[0]].Cache[4] = new AAAAAAAAAAAAAAAAw();
				Data.Points[Inventory._CurrentPoint[0]].Cache[5] = new Cartridge_7_62x54();
				Data.Points[Inventory._CurrentPoint[0]].Cache[5].Stack = 10;
				Data.Points[Inventory._CurrentPoint[0]].Cache[6] = new AAAAAAAAAAAAAAAt();
				Data.Points[Inventory._CurrentPoint[0]].Cache[6].State = 2f;
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Inventory._EmptyTask = new TaskAdditionalDutyKillBloodsuсker1();
				Data.TaskAll[k] = Inventory._EmptyTask;
				Inventory.AAAAAAAAAAAAAAAAAAAAAci(Inventory._EmptyTask.ImageTask, Inventory._EmptyTask.TextTask);
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(false);
				Inventory._CurtainGUIEquipment.SetActive(true);
				Inventory._CurtainIconCharacterU.SetActive(true);
				GameObject gameObject59 = GameObject.Find("MessaegeTask");
				GameObject gameObject60 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
				gameObject60.transform.SetParent(gameObject59.transform.GetChild(5).transform.GetChild(0));
				gameObject60.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/FindArtefact");
				gameObject60.transform.GetChild(1).GetComponent<Text>().text = "Обновлено задание: Исследовать аномалию на точке ''Насосная станция'', Бар. Покинуть точку после исследования.";
				Transform obj49 = gameObject60.transform;
				Vector3 localScale = new Vector3(1f, 1f);
				gameObject60.transform.localScale = localScale;
				obj49.localScale = localScale;
				GOMessaegeTask = true;
				break;
			}
			if (Data.TaskAll[k].NameTask == "Исследовать насосную станцию" && Inventory._CurrentPoint.Count == 0 && CharacterMotion._curCharacter == 0)
			{
				Data.OldTask.Add("Разведка на насосной станции");
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Inventory._EmptyTask = new TaskAdditionalDutyKillBloodsuсker2();
				Data.TaskAll[k] = Inventory._EmptyTask;
				Inventory.AAAAAAAAAAAAAAAAAAAAAci(Inventory._EmptyTask.ImageTask, Inventory._EmptyTask.TextTask);
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(false);
				Inventory._CurtainGUIEquipment.SetActive(true);
				Inventory._CurtainIconCharacterU.SetActive(true);
				GameObject gameObject61 = GameObject.Find("MessaegeTask");
				GameObject gameObject62 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
				gameObject62.transform.SetParent(gameObject61.transform.GetChild(5).transform.GetChild(0));
				gameObject62.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/DutyBloodsucker");
				gameObject62.transform.GetChild(1).GetComponent<Text>().text = "Обновлено задание: Убить кровососа.";
				Transform obj50 = gameObject62.transform;
				Vector3 localScale = new Vector3(1f, 1f);
				gameObject62.transform.localScale = localScale;
				obj50.localScale = localScale;
				AAAAAAAAAAAAAAAAf aAAAAAAAAAAAAAAAf10 = new AAAAAAAAAAAAAAAAAAba();
				aAAAAAAAAAAAAAAAf10.NameU = "Кровосос ";
				aAAAAAAAAAAAAAAAf10.CharUnits.name = aAAAAAAAAAAAAAAAf10.NameU;
				aAAAAAAAAAAAAAAAf10.WeaponChar.Damage += 4f;
				aAAAAAAAAAAAAAAAf10.CurGexChar = Gexa.GexLib[103];
				aAAAAAAAAAAAAAAAf10.CharUnits.transform.position = Gexa.GexLib[103].GexGO.transform.position + new Vector3(-0.3f, 0f, 0f);
				aAAAAAAAAAAAAAAAf10.Skill = 6;
				Data.CharacterD.Add(aAAAAAAAAAAAAAAAf10);
				AAAAAAAAAAAAAAAAAAcz.AAAAAAAAAAAAAAAAAcb();
				aAAAAAAAAAAAAAAAf10.CharUnits.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("Sound/monsters/bloodsucker_breath_0");
				aAAAAAAAAAAAAAAAf10.CharUnits.GetComponent<AudioSource>().Play();
				GOMessaegeTask = true;
				break;
			}
			if (Data.TaskAll[k].NameTask == "Убить кровососа" && SceneManager.GetActiveScene().name == "Bar")
			{
				for (int num51 = 0; num51 < Data.CharacterD.Count; num51++)
				{
					if (Data.CharacterD[num51].NameU == "Кровосос " && !Data.CharacterD[num51].Life)
					{
						Inventory.SoundMenu.clip = Inventory.effectNews;
						Inventory.SoundMenu.Play();
						Inventory._EmptyTask = new TaskAdditionalDutyKillBloodsuсker3();
						Data.TaskAll[k] = Inventory._EmptyTask;
						Inventory.AAAAAAAAAAAAAAAAAAAAAci(Inventory._EmptyTask.ImageTask, Inventory._EmptyTask.TextTask);
						Inventory._Equipment = false;
						Inventory._CurtainInventory.SetActive(false);
						Inventory._CurtainGUIEquipment.SetActive(true);
						Inventory._CurtainIconCharacterU.SetActive(true);
						GameObject gameObject63 = GameObject.Find("MessaegeTask");
						GameObject gameObject64 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
						gameObject64.transform.SetParent(gameObject63.transform.GetChild(5).transform.GetChild(0));
						gameObject64.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/DutyBloodsucker");
						gameObject64.transform.GetChild(1).GetComponent<Text>().text = "Обновлено задание: Добраться до ближайшей базы Долга, получить вознаграждение.";
						Transform obj51 = gameObject64.transform;
						Vector3 localScale = new Vector3(1f, 1f);
						gameObject64.transform.localScale = localScale;
						obj51.localScale = localScale;
						GOMessaegeTask = true;
						return;
					}
				}
			}
			if (Inventory._CurrentPoint.Count > 0 && CharacterMotion._curCharacter == 0 && Data.TaskAll[k].NameTask == "Найти отряд разведчиков" && Data.Points[Inventory._CurrentPoint[0]].namePoint == "Стоянка на камнях" && Data.Points[Inventory._CurrentPoint[0]].curGexPoint == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar)
			{
				Data.OldTask.Add("Найти отряд разведчиков");
				bool flag18 = false;
				AAAAAAAAAAAAAAAAAAk[] cache = Data.Points[Inventory._CurrentPoint[0]].Cache;
				foreach (AAAAAAAAAAAAAAAAAAk aAAAAAAAAAAAAAAAAAk in cache)
				{
					if (aAAAAAAAAAAAAAAAAAk.NameSubject == "Отчет разведчиков")
					{
						flag18 = true;
					}
				}
				if (!flag18)
				{
					Data.Points[Inventory._CurrentPoint[0]].Cache[7] = new AAAAAAAAAAAAAAAAAAAbi();
				}
				Inventory.SoundMenu.clip = Inventory.effectNews;
				Inventory.SoundMenu.Play();
				Inventory._EmptyTask = new TaskAdditionalScoutReport0_1();
				Data.TaskAll[k] = Inventory._EmptyTask;
				Inventory.AAAAAAAAAAAAAAAAAAAAAci(Inventory._EmptyTask.ImageTask, Inventory._EmptyTask.TextTask);
				Inventory._Equipment = false;
				Inventory._CurtainInventory.SetActive(false);
				Inventory._CurtainGUIEquipment.SetActive(true);
				Inventory._CurtainIconCharacterU.SetActive(true);
				GameObject gameObject65 = GameObject.Find("MessaegeTask");
				float num53 = Screen.width;
				num53 /= 1280f;
				GameObject gameObject66 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
				gameObject66.transform.SetParent(gameObject65.transform.GetChild(5).transform.GetChild(0));
				gameObject66.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/QuestSubject/Army");
				gameObject66.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
				gameObject66.transform.GetChild(1).GetComponent<Text>().text = "Выполнено задание: найти отряд разведчиков.";
				Transform obj52 = gameObject66.transform;
				Vector3 localScale = new Vector3(1f, 1f);
				gameObject66.transform.localScale = localScale;
				obj52.localScale = localScale;
				gameObject66 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeItem"));
				gameObject66.transform.SetParent(gameObject65.transform.GetChild(5).transform.GetChild(0));
				gameObject66.transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/Subject/dokuments_0");
				gameObject66.transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
				gameObject66.transform.GetChild(1).GetComponent<Text>().text = "Получено задание: Найти на точке отчет разведчиков, доставить его на ближайшую военную точку.";
				Transform obj53 = gameObject66.transform;
				localScale = new Vector3(1f, 1f);
				gameObject66.transform.localScale = localScale;
				obj53.localScale = localScale;
				GOMessaegeTask = true;
				Inventory._PointInformation = false;
				break;
			}
			if (Data.TaskAll[k].NameTask == "Схемы переданы")
			{
				Inventory._TaskNum = 0;
				Data.TaskAll.RemoveAt(k);
				if (k >= Data.TaskAll.Count)
				{
					k = Data.TaskAll.Count - 1;
				}
			}
			if (Data.TaskAll[k].NameTask == "Награда за захват точки")
			{
				Inventory._TaskNum = 0;
				Data.TaskAll.RemoveAt(k);
				if (k >= Data.TaskAll.Count)
				{
					k = Data.TaskAll.Count - 1;
				}
			}
		}
	}

	public static void AAAAAAAAAAAAAAAcf()
	{
		bool flag = false;
		foreach (ConstructorTasks item in Data.TaskAll)
		{
			if (item.NameTask == new TaskAdditionalВocumentation0().NameTask)
			{
				flag = true;
			}
		}
		if (!flag)
		{
			return;
		}
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		bool flag5 = false;
		bool flag6 = false;
		bool flag7 = false;
		bool flag8 = false;
		bool flag9 = false;
		bool flag10 = false;
		bool flag11 = false;
		bool flag12 = false;
		bool flag13 = false;
		bool flag14 = false;
		bool flag15 = false;
		bool flag16 = false;
		bool flag17 = false;
		bool flag18 = false;
		bool flag19 = false;
		bool flag20 = false;
		bool flag21 = false;
		bool flag22 = false;
		foreach (string item2 in Data.OldTask)
		{
			if (item2 == new AAAAAAAAAAAAAAAbc().NameSubject)
			{
				flag2 = true;
			}
			if (item2 == new AAAAAAAAAAAAAAAAAAAAAbt().NameSubject)
			{
				flag3 = true;
			}
			if (item2 == new AAAAAAAAAAAAAAAAAbf().NameSubject)
			{
				flag4 = true;
			}
			if (item2 == new AAAAAAAAAAAAAAAAAbg().NameSubject)
			{
				flag5 = true;
			}
			if (item2 == new AAAAAAAAAAAAAAbe().NameSubject)
			{
				flag6 = true;
			}
			if (item2 == new AAAAAAAAAAAAAAAAAAAAAbu().NameSubject)
			{
				flag7 = true;
			}
			if (item2 == new AAAAAAAAAAAAAAAAAAAAbs().NameSubject)
			{
				flag8 = true;
			}
			if (item2 == new AAAAAAAAAAAAAAAAAAcd().NameSubject)
			{
				flag9 = true;
			}
			if (item2 == new AAAAAAAAAAAAAAAAAAAAbt().NameSubject)
			{
				flag10 = true;
			}
			if (item2 == new AAAAAAAAAAAAAAbf().NameSubject)
			{
				flag11 = true;
			}
			if (item2 == new AAAAAAAAAAAAAAAAAbh().NameSubject)
			{
				flag12 = true;
			}
			if (item2 == new AAAAAAAAAAAAAAAAbh().NameSubject)
			{
				flag13 = true;
			}
			if (item2 == new AAAAAAAAAAAAAAAAAbi().NameSubject)
			{
				flag14 = true;
			}
			if (item2 == new AAAAAAAAAAAAAAAbd().NameSubject)
			{
				flag15 = true;
			}
			if (item2 == new AAAAAAAAAAAAAAAAAAAAAbv().NameSubject)
			{
				flag16 = true;
			}
			if (item2 == new AAAAAAAAAAAAAAbg().NameSubject)
			{
				flag17 = true;
			}
			if (item2 == new AAAAAAAAAAAAAAAAAAAAbu().NameSubject)
			{
				flag18 = true;
			}
			if (item2 == new AAAAAAAAAAAAAAAAAAAAbv().NameSubject)
			{
				flag19 = true;
			}
			if (item2 == new AAAAAAAAAAAAAAbh().NameSubject)
			{
				flag20 = true;
			}
			if (item2 == new AAAAAAAAAAAAAAAbe().NameSubject)
			{
				flag21 = true;
			}
			if (item2 == new AAAAAAAAAAAAAAAAAbj().NameSubject)
			{
				flag22 = true;
			}
		}
		if (!flag2)
		{
			for (int i = 0; i < Data.Points.Count; i++)
			{
				if (!(Data.Points[i].namePoint == "Военная база"))
				{
					continue;
				}
				for (int j = 0; j < 20; j++)
				{
					if (Data.Points[i].Cache[j].NameSubject == "None")
					{
						Data.Points[i].Cache[j] = new AAAAAAAAAAAAAAAbc();
						Data.OldTask.Add(Data.Points[i].Cache[j].NameSubject);
						Debug.Log(Data.Points[i].Cache[j].NameSubject + " " + Data.Points[i].namePoint);
						break;
					}
				}
			}
		}
		if (!flag3)
		{
			for (int k = 0; k < Data.Points.Count; k++)
			{
				if (!(Data.Points[k].namePoint == "Заводской КПП"))
				{
					continue;
				}
				for (int l = 0; l < 20; l++)
				{
					if (Data.Points[k].Cache[l].NameSubject == "None")
					{
						Data.Points[k].Cache[l] = new AAAAAAAAAAAAAAAAAAAAAbt();
						Data.OldTask.Add(Data.Points[k].Cache[l].NameSubject);
						Debug.Log(Data.Points[k].Cache[l].NameSubject + " " + Data.Points[k].namePoint);
						break;
					}
				}
			}
		}
		if (!flag4)
		{
			for (int m = 0; m < Data.Points.Count; m++)
			{
				if (!(Data.Points[m].namePoint == "Хижина сумасшедшего сталкера"))
				{
					continue;
				}
				for (int n = 0; n < 20; n++)
				{
					if (Data.Points[m].Cache[n].NameSubject == "None")
					{
						Data.Points[m].Cache[n] = new AAAAAAAAAAAAAAAAAbf();
						Data.OldTask.Add(Data.Points[m].Cache[n].NameSubject);
						Debug.Log(Data.Points[m].Cache[n].NameSubject + " " + Data.Points[m].namePoint);
						break;
					}
				}
			}
		}
		if (!flag5)
		{
			for (int num = 0; num < Data.Points.Count; num++)
			{
				if (!(Data.Points[num].namePoint == "Брошенный бункер"))
				{
					continue;
				}
				for (int num2 = 0; num2 < 20; num2++)
				{
					if (Data.Points[num].Cache[num2].NameSubject == "None")
					{
						Data.Points[num].Cache[num2] = new AAAAAAAAAAAAAAAAAbg();
						Data.OldTask.Add(Data.Points[num].Cache[num2].NameSubject);
						Debug.Log(Data.Points[num].Cache[num2].NameSubject + " " + Data.Points[num].namePoint);
						break;
					}
				}
			}
		}
		if (!flag6)
		{
			for (int num3 = 0; num3 < Data.Points.Count; num3++)
			{
				if (!(Data.Points[num3].namePoint == "Сбитый вертолет"))
				{
					continue;
				}
				for (int num4 = 0; num4 < 20; num4++)
				{
					if (Data.Points[num3].Cache[num4].NameSubject == "None")
					{
						Data.Points[num3].Cache[num4] = new AAAAAAAAAAAAAAbe();
						Data.OldTask.Add(Data.Points[num3].Cache[num4].NameSubject);
						Debug.Log(Data.Points[num3].Cache[num4].NameSubject + " " + Data.Points[num3].namePoint);
						break;
					}
				}
			}
		}
		if (!flag7)
		{
			for (int num5 = 0; num5 < Data.Points.Count; num5++)
			{
				if (!(Data.Points[num5].namePoint == "Магазин промтовары"))
				{
					continue;
				}
				for (int num6 = 0; num6 < 20; num6++)
				{
					if (Data.Points[num5].Cache[num6].NameSubject == "None")
					{
						Data.Points[num5].Cache[num6] = new AAAAAAAAAAAAAAAAAAAAAbu();
						Data.OldTask.Add(Data.Points[num5].Cache[num6].NameSubject);
						Debug.Log(Data.Points[num5].Cache[num6].NameSubject + " " + Data.Points[num5].namePoint);
						break;
					}
				}
			}
		}
		if (!flag8)
		{
			for (int num7 = 0; num7 < Data.Points.Count; num7++)
			{
				if (!(Data.Points[num7].namePoint == "Насосная станция"))
				{
					continue;
				}
				for (int num8 = 0; num8 < 20; num8++)
				{
					if (Data.Points[num7].Cache[num8].NameSubject == "None")
					{
						Data.Points[num7].Cache[num8] = new AAAAAAAAAAAAAAAAAAAAbs();
						Data.OldTask.Add(Data.Points[num7].Cache[num8].NameSubject);
						Debug.Log(Data.Points[num7].Cache[num8].NameSubject + " " + Data.Points[num7].namePoint);
						break;
					}
				}
			}
		}
		if (!flag9)
		{
			for (int num9 = 0; num9 < Data.Points.Count; num9++)
			{
				if (!(Data.Points[num9].namePoint == "Старый завод"))
				{
					continue;
				}
				for (int num10 = 0; num10 < 20; num10++)
				{
					if (Data.Points[num9].Cache[num10].NameSubject == "None")
					{
						Data.Points[num9].Cache[num10] = new AAAAAAAAAAAAAAAAAAcd();
						Data.OldTask.Add(Data.Points[num9].Cache[num10].NameSubject);
						Debug.Log(Data.Points[num9].Cache[num10].NameSubject + " " + Data.Points[num9].namePoint);
						break;
					}
				}
			}
		}
		if (!flag10)
		{
			for (int num11 = 0; num11 < Data.Points.Count; num11++)
			{
				if (!(Data.Points[num11].namePoint == "Цеха старой фабрики"))
				{
					continue;
				}
				for (int num12 = 0; num12 < 20; num12++)
				{
					if (Data.Points[num11].Cache[num12].NameSubject == "None")
					{
						Data.Points[num11].Cache[num12] = new AAAAAAAAAAAAAAAAAAAAbt();
						Data.OldTask.Add(Data.Points[num11].Cache[num12].NameSubject);
						Debug.Log(Data.Points[num11].Cache[num12].NameSubject + " " + Data.Points[num11].namePoint);
						break;
					}
				}
			}
		}
		if (!flag11)
		{
			for (int num13 = 0; num13 < Data.Points.Count; num13++)
			{
				if (!(Data.Points[num13].namePoint == "Институт Агропром"))
				{
					continue;
				}
				for (int num14 = 0; num14 < 20; num14++)
				{
					if (Data.Points[num13].Cache[num14].NameSubject == "None")
					{
						Data.Points[num13].Cache[num14] = new AAAAAAAAAAAAAAbf();
						Data.OldTask.Add(Data.Points[num13].Cache[num14].NameSubject);
						Debug.Log(Data.Points[num13].Cache[num14].NameSubject + " " + Data.Points[num13].namePoint);
						break;
					}
				}
			}
		}
		if (!flag12)
		{
			for (int num15 = 0; num15 < Data.Points.Count; num15++)
			{
				if (!(Data.Points[num15].namePoint == "Привал диггеров"))
				{
					continue;
				}
				for (int num16 = 0; num16 < 20; num16++)
				{
					if (Data.Points[num15].Cache[num16].NameSubject == "None")
					{
						Data.Points[num15].Cache[num16] = new AAAAAAAAAAAAAAAAAbh();
						Data.OldTask.Add(Data.Points[num15].Cache[num16].NameSubject);
						Debug.Log(Data.Points[num15].Cache[num16].NameSubject + " " + Data.Points[num15].namePoint);
						break;
					}
				}
			}
		}
		if (!flag13)
		{
			for (int num17 = 0; num17 < Data.Points.Count; num17++)
			{
				if (!(Data.Points[num17].namePoint == "ВНЗ «Круг»"))
				{
					continue;
				}
				for (int num18 = 0; num18 < 20; num18++)
				{
					if (Data.Points[num17].Cache[num18].NameSubject == "None")
					{
						Data.Points[num17].Cache[num18] = new AAAAAAAAAAAAAAAAbh();
						Data.OldTask.Add(Data.Points[num17].Cache[num18].NameSubject);
						Debug.Log(Data.Points[num17].Cache[num18].NameSubject + " " + Data.Points[num17].namePoint);
						break;
					}
				}
			}
		}
		if (!flag14)
		{
			for (int num19 = 0; num19 < Data.Points.Count; num19++)
			{
				if (!(Data.Points[num19].namePoint == "Форпост"))
				{
					continue;
				}
				for (int num20 = 0; num20 < 20; num20++)
				{
					if (Data.Points[num19].Cache[num20].NameSubject == "None")
					{
						Data.Points[num19].Cache[num20] = new AAAAAAAAAAAAAAAAAbi();
						Data.OldTask.Add(Data.Points[num19].Cache[num20].NameSubject);
						Debug.Log(Data.Points[num19].Cache[num20].NameSubject + " " + Data.Points[num19].namePoint);
						break;
					}
				}
			}
		}
		if (!flag15)
		{
			for (int num21 = 0; num21 < Data.Points.Count; num21++)
			{
				if (!(Data.Points[num21].namePoint == "Деревня новичков"))
				{
					continue;
				}
				for (int num22 = 0; num22 < 20; num22++)
				{
					if (Data.Points[num21].Cache[num22].NameSubject == "None")
					{
						Data.Points[num21].Cache[num22] = new AAAAAAAAAAAAAAAbd();
						Data.OldTask.Add(Data.Points[num21].Cache[num22].NameSubject);
						Debug.Log(Data.Points[num21].Cache[num22].NameSubject + " " + Data.Points[num21].namePoint);
						break;
					}
				}
			}
		}
		if (!flag16)
		{
			for (int num23 = 0; num23 < Data.Points.Count; num23++)
			{
				if (!(Data.Points[num23].namePoint == "Стоянка брошенной техники"))
				{
					continue;
				}
				for (int num24 = 0; num24 < 20; num24++)
				{
					if (Data.Points[num23].Cache[num24].NameSubject == "None")
					{
						Data.Points[num23].Cache[num24] = new AAAAAAAAAAAAAAAAAAAAAbv();
						Data.OldTask.Add(Data.Points[num23].Cache[num24].NameSubject);
						Debug.Log(Data.Points[num23].Cache[num24].NameSubject + " " + Data.Points[num23].namePoint);
						break;
					}
				}
			}
		}
		if (!flag17)
		{
			for (int num25 = 0; num25 < Data.Points.Count; num25++)
			{
				if (!(Data.Points[num25].namePoint == "Лагерь на болоте"))
				{
					continue;
				}
				for (int num26 = 0; num26 < 20; num26++)
				{
					if (Data.Points[num25].Cache[num26].NameSubject == "None")
					{
						Data.Points[num25].Cache[num26] = new AAAAAAAAAAAAAAbg();
						Data.OldTask.Add(Data.Points[num25].Cache[num26].NameSubject);
						Debug.Log(Data.Points[num25].Cache[num26].NameSubject + " " + Data.Points[num25].namePoint);
						break;
					}
				}
			}
		}
		if (!flag18)
		{
			for (int num27 = 0; num27 < Data.Points.Count; num27++)
			{
				if (!(Data.Points[num27].namePoint == "Пещера с аномалиями"))
				{
					continue;
				}
				for (int num28 = 0; num28 < 20; num28++)
				{
					if (Data.Points[num27].Cache[num28].NameSubject == "None")
					{
						Data.Points[num27].Cache[num28] = new AAAAAAAAAAAAAAAAAAAAbu();
						Data.OldTask.Add(Data.Points[num27].Cache[num28].NameSubject);
						Debug.Log(Data.Points[num27].Cache[num28].NameSubject + " " + Data.Points[num27].namePoint);
						break;
					}
				}
			}
		}
		if (!flag19)
		{
			for (int num29 = 0; num29 < Data.Points.Count; num29++)
			{
				if (!(Data.Points[num29].namePoint == "Бродячие зомби"))
				{
					continue;
				}
				for (int num30 = 0; num30 < 20; num30++)
				{
					if (Data.Points[num29].Cache[num30].NameSubject == "None")
					{
						Data.Points[num29].Cache[num30] = new AAAAAAAAAAAAAAAAAAAAbv();
						Data.OldTask.Add(Data.Points[num29].Cache[num30].NameSubject);
						Debug.Log(Data.Points[num29].Cache[num30].NameSubject + " " + Data.Points[num29].namePoint);
						break;
					}
				}
			}
		}
		if (!flag20)
		{
			for (int num31 = 0; num31 < Data.Points.Count; num31++)
			{
				if (!(Data.Points[num31].namePoint == "Заводской цех"))
				{
					continue;
				}
				for (int num32 = 0; num32 < 20; num32++)
				{
					if (Data.Points[num31].Cache[num32].NameSubject == "None")
					{
						Data.Points[num31].Cache[num32] = new AAAAAAAAAAAAAAbh();
						Data.OldTask.Add(Data.Points[num31].Cache[num32].NameSubject);
						Debug.Log(Data.Points[num31].Cache[num32].NameSubject + " " + Data.Points[num31].namePoint);
						break;
					}
				}
			}
		}
		if (!flag21)
		{
			for (int num33 = 0; num33 < Data.Points.Count; num33++)
			{
				if (!(Data.Points[num33].namePoint == "Лачуга у старого пруда"))
				{
					continue;
				}
				for (int num34 = 0; num34 < 20; num34++)
				{
					if (Data.Points[num33].Cache[num34].NameSubject == "None")
					{
						Data.Points[num33].Cache[num34] = new AAAAAAAAAAAAAAAbe();
						Data.OldTask.Add(Data.Points[num33].Cache[num34].NameSubject);
						Debug.Log(Data.Points[num33].Cache[num34].NameSubject + " " + Data.Points[num33].namePoint);
						break;
					}
				}
			}
		}
		if (flag22)
		{
			return;
		}
		for (int num35 = 0; num35 < Data.Points.Count; num35++)
		{
			if (!(Data.Points[num35].namePoint == "Железнодорожный перрон"))
			{
				continue;
			}
			for (int num36 = 0; num36 < 20; num36++)
			{
				if (Data.Points[num35].Cache[num36].NameSubject == "None")
				{
					Data.Points[num35].Cache[num36] = new AAAAAAAAAAAAAAAAAbj();
					Data.OldTask.Add(Data.Points[num35].Cache[num36].NameSubject);
					Debug.Log(Data.Points[num35].Cache[num36].NameSubject + " " + Data.Points[num35].namePoint);
					break;
				}
			}
		}
	}
}
