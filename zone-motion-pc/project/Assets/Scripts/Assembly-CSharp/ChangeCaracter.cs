using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeCaracter : MonoBehaviour
{
	public static AAAAAAAAAAAAAAAAf.TypeCharacter typeDeathChar;

	public static int GroupOfCupture;

	public static void AAAAAAAAAAAAAAAAAAAu()
	{
		if (GroupOfCupture <= 0)
		{
			if (typeDeathChar == AAAAAAAAAAAAAAAAf.TypeCharacter.Бандиты)
			{
				Data.CharacterD[CharacterMotion._curCharacter] = new AAAAAAAAAAAAAAAAAs();
			}
			if (typeDeathChar == AAAAAAAAAAAAAAAAf.TypeCharacter.Одиночки)
			{
				Data.CharacterD[CharacterMotion._curCharacter] = new AAAAAAAAAAAAAAAAAAAz();
			}
			if (typeDeathChar == AAAAAAAAAAAAAAAAf.TypeCharacter.Военные)
			{
				Data.CharacterD[CharacterMotion._curCharacter] = new AAAAAAAAAAAAAAAAAAAAAAu();
			}
			if (typeDeathChar == AAAAAAAAAAAAAAAAf.TypeCharacter.Свобода)
			{
				Data.CharacterD[CharacterMotion._curCharacter] = new AAAAAAAAAAAAAAAi();
			}
			if (typeDeathChar == AAAAAAAAAAAAAAAAf.TypeCharacter.Долг)
			{
				Data.CharacterD[CharacterMotion._curCharacter] = new AAAAAAAAAAAAAAAAAAAAAw();
			}
			if (typeDeathChar == AAAAAAAAAAAAAAAAf.TypeCharacter.Монолит)
			{
				Data.CharacterD[CharacterMotion._curCharacter] = new AAAAAAAAAAAAAAAj();
			}
			if (typeDeathChar == AAAAAAAAAAAAAAAAf.TypeCharacter.Наемники)
			{
				Data.CharacterD[CharacterMotion._curCharacter] = new AAAAAAAAAAAAAAAAAAAAq();
			}
			if (typeDeathChar == AAAAAAAAAAAAAAAAf.TypeCharacter.Чистое_небо)
			{
				Data.CharacterD[CharacterMotion._curCharacter] = new AAAAAAAAAAAAAAAAAAAAAy();
			}
			if (typeDeathChar == AAAAAAAAAAAAAAAAf.TypeCharacter.Кабан)
			{
				Data.CharacterD[CharacterMotion._curCharacter] = new AAAAAAAAAAAAAAAAAt();
			}
			if (typeDeathChar == AAAAAAAAAAAAAAAAf.TypeCharacter.Псевдособака)
			{
				Data.CharacterD[CharacterMotion._curCharacter] = new AAAAAAAAAAAAAAAAAAAAs();
			}
			if (typeDeathChar == AAAAAAAAAAAAAAAAf.TypeCharacter.Плоть)
			{
				Data.CharacterD[CharacterMotion._curCharacter] = new AAAAAAAAAAAAAAAAAAAAt();
			}
			if (typeDeathChar == AAAAAAAAAAAAAAAAf.TypeCharacter.Пес)
			{
				int num = Random.Range(0, 5);
				if (num == 0)
				{
					Data.CharacterD[CharacterMotion._curCharacter] = new AAAAAAAAAAAAAAAAAAba();
				}
				if (num > 0)
				{
					Data.CharacterD[CharacterMotion._curCharacter] = new AAAAAAAAAAAAAAAAAAAAr();
				}
			}
			if (typeDeathChar == AAAAAAAAAAAAAAAAf.TypeCharacter.Зомби)
			{
				int num2 = Random.Range(0, 5);
				if (num2 == 0)
				{
					if (SceneManager.GetActiveScene().name != "Bar" && SceneManager.GetActiveScene().name != "Military" && SceneManager.GetActiveScene().name != "Marsh")
					{
						Data.CharacterD[CharacterMotion._curCharacter] = new AAAAAAAAAAAAAAAAAs();
					}
					if (SceneManager.GetActiveScene().name == "Bar")
					{
						Data.CharacterD[CharacterMotion._curCharacter] = new AAAAAAAAAAAAAAAi();
					}
					if (SceneManager.GetActiveScene().name == "Military")
					{
						Data.CharacterD[CharacterMotion._curCharacter] = new AAAAAAAAAAAAAAAAAAAAAw();
					}
					if (SceneManager.GetActiveScene().name == "Marsh")
					{
						Data.CharacterD[CharacterMotion._curCharacter] = new AAAAAAAAAAAAAAAAAAAAAx();
					}
				}
				if (num2 == 1)
				{
					if (SceneManager.GetActiveScene().name != "Bar" && SceneManager.GetActiveScene().name != "Military" && SceneManager.GetActiveScene().name != "Marsh")
					{
						Data.CharacterD[CharacterMotion._curCharacter] = new AAAAAAAAAAAAAAAAAAAz();
					}
					if (SceneManager.GetActiveScene().name == "Bar")
					{
						Data.CharacterD[CharacterMotion._curCharacter] = new AAAAAAAAAAAAAAAi();
					}
					if (SceneManager.GetActiveScene().name == "Military")
					{
						Data.CharacterD[CharacterMotion._curCharacter] = new AAAAAAAAAAAAAAAAAAAAAw();
					}
					if (SceneManager.GetActiveScene().name == "Marsh")
					{
						Data.CharacterD[CharacterMotion._curCharacter] = new AAAAAAAAAAAAAAAAAAAAAy();
					}
				}
				if (num2 >= 2)
				{
					Data.CharacterD[CharacterMotion._curCharacter] = new AAAAAAAAAAAAAAAAAAj();
				}
			}
			if (typeDeathChar == AAAAAAAAAAAAAAAAf.TypeCharacter.Снорк)
			{
				int num3 = Random.Range(0, 6);
				if (num3 == 1)
				{
					Data.CharacterD[CharacterMotion._curCharacter] = new AAAAAAAAAAAAAAAAAAba();
				}
				if (num3 == 0)
				{
					Data.CharacterD[CharacterMotion._curCharacter] = new AAAAAAAAAAAAAAAAAAbb();
				}
				if (num3 > 1)
				{
					Data.CharacterD[CharacterMotion._curCharacter] = new AAAAAAAAAAAAAAAAAAAAAAv();
				}
			}
			if (typeDeathChar == AAAAAAAAAAAAAAAAf.TypeCharacter.Ученые)
			{
				int num4 = Random.Range(0, 4);
				if (num4 == 0)
				{
					Data.CharacterD[CharacterMotion._curCharacter] = new AAAAAAAAAAAAAAAAAAba();
				}
				if (num4 == 1)
				{
					Data.CharacterD[CharacterMotion._curCharacter] = new AAAAAAAAAAAAAAAAAAbb();
				}
				if (num4 > 1)
				{
					Data.CharacterD[CharacterMotion._curCharacter] = new AAAAAAAAAAAAAAAAAAj();
				}
			}
			if (typeDeathChar == AAAAAAAAAAAAAAAAf.TypeCharacter.Кровосос)
			{
				Data.CharacterD[CharacterMotion._curCharacter] = new AAAAAAAAAAAAAAAAAAi();
			}
			if (typeDeathChar == AAAAAAAAAAAAAAAAf.TypeCharacter.Контролер)
			{
				Data.CharacterD[CharacterMotion._curCharacter] = new AAAAAAAAAAAAAAAAAAi();
			}
			if (typeDeathChar == AAAAAAAAAAAAAAAAf.TypeCharacter.Ренегаты)
			{
				Data.CharacterD[CharacterMotion._curCharacter] = new AAAAAAAAAAAAAAAAAAAAAx();
			}
		}
		else
		{
			if (GroupOfCupture == 1)
			{
				Data.CharacterD[CharacterMotion._curCharacter] = new AAAAAAAAAAAAAAAAAs();
			}
			if (GroupOfCupture == 2)
			{
				Data.CharacterD[CharacterMotion._curCharacter] = new AAAAAAAAAAAAAAAAAAAz();
			}
			if (GroupOfCupture == 3)
			{
				Data.CharacterD[CharacterMotion._curCharacter] = new AAAAAAAAAAAAAAAAAAAAq();
			}
			if (GroupOfCupture == 4)
			{
				Data.CharacterD[CharacterMotion._curCharacter] = new AAAAAAAAAAAAAAAi();
			}
			if (GroupOfCupture == 6)
			{
				Data.CharacterD[CharacterMotion._curCharacter] = new AAAAAAAAAAAAAAAAAAAAAw();
			}
			if (GroupOfCupture == 8)
			{
				Data.CharacterD[CharacterMotion._curCharacter] = new AAAAAAAAAAAAAAAj();
			}
			if (GroupOfCupture == 7)
			{
				Data.CharacterD[CharacterMotion._curCharacter] = new AAAAAAAAAAAAAAAAAAAAAx();
			}
			if (GroupOfCupture == 5)
			{
				Data.CharacterD[CharacterMotion._curCharacter] = new AAAAAAAAAAAAAAAAAAAAAAu();
			}
			if (GroupOfCupture == 9)
			{
				Data.CharacterD[CharacterMotion._curCharacter] = new AAAAAAAAAAAAAAAAAt();
			}
			if (GroupOfCupture == 10)
			{
				Data.CharacterD[CharacterMotion._curCharacter] = new AAAAAAAAAAAAAAAAAAAAAAv();
			}
			if (GroupOfCupture == 11)
			{
				Data.CharacterD[CharacterMotion._curCharacter] = new AAAAAAAAAAAAAAAAAAi();
			}
			if (GroupOfCupture == 12)
			{
				Data.CharacterD[CharacterMotion._curCharacter] = new AAAAAAAAAAAAAAAAAAAAAy();
			}
			GroupOfCupture = 0;
		}
		for (int i = 0; i < Data.CharacterD.Count; i++)
		{
			if (i != CharacterMotion._curCharacter && Data.CharacterD[i].CharUnits.name == Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name)
			{
				Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name += "..";
				Data.CharacterD[CharacterMotion._curCharacter].NameU = Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name;
			}
		}
		AAAAAAAAAAAAAAAAAAAAg();
		Data.CharacterD[CharacterMotion._curCharacter].CharUnits.GetComponent<AudioSource>().mute = bool.Parse(PlayerPrefs.GetString("Mute"));
		Data.CharacterD[CharacterMotion._curCharacter].CharUnits.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume");
		bool flag = false;
		for (int j = 0; j < Data.Points.Count; j++)
		{
			if (Data.Points[j].ControlInt == Data.CharacterD[CharacterMotion._curCharacter].TypeChInt)
			{
				Data.CharacterD[CharacterMotion._curCharacter].CurGexChar = Data.Points[j].curGexPoint;
				Data.CharacterD[CharacterMotion._curCharacter].CharUnits.transform.position = Data.Points[j].curGexPoint.GexGO.transform.position;
				Data.CharacterD[CharacterMotion._curCharacter].TaskGexChar = Gexa.GexLib[Random.Range(0, Gexa.GexLib.Count - 1)];
				Debug.Log(Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name + " " + Data.Points[j].namePoint);
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			List<ConstructorPoints> list = new List<ConstructorPoints>();
			for (int k = 0; k < Data.Points.Count; k++)
			{
				if (Data.Points[k].Teleport != "None")
				{
					list.Add(Data.Points[k]);
				}
			}
			Debug.Log(list.Count + " _teleportPoint");
			int index = Random.Range(0, list.Count - 1);
			Data.CharacterD[CharacterMotion._curCharacter].CurGexChar = list[index].curGexPoint;
			Data.CharacterD[CharacterMotion._curCharacter].CharUnits.transform.position = list[index].curGexPoint.GexGO.transform.position;
			Data.CharacterD[CharacterMotion._curCharacter].TaskGexChar = Data.CharacterD[CharacterMotion._curCharacter].CurGexChar;
			Debug.Log(Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name + " " + list[index].namePoint);
		}
		CharacterMotion.AAAAAAAAAAAAAAAAAAAAi();
		CharacterMotion.PositionCurChar = Data.CharacterD[CharacterMotion._curCharacter].CharUnits.transform.position;
		CharacterMotion.SortInPoint = new bool[7];
		for (int l = 0; l < Inventory._CurrentCharUnit.Count; l++)
		{
			if (Data.CharacterD[Inventory._CurrentCharUnit[l]].CharUnits.transform.position == Data.CharacterD[CharacterMotion._curCharacter].CharUnits.transform.position && Data.CharacterD[Inventory._CurrentCharUnit[l]].CharUnits.name != Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name)
			{
				CharacterMotion.SortInPoint[0] = true;
			}
			if (Data.CharacterD[Inventory._CurrentCharUnit[l]].CharUnits.transform.position == Data.CharacterD[CharacterMotion._curCharacter].CharUnits.transform.position + new Vector3(-0.3f, 0.2f, 0f) && Data.CharacterD[Inventory._CurrentCharUnit[l]].CharUnits.name != Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name)
			{
				CharacterMotion.SortInPoint[1] = true;
			}
			if (Data.CharacterD[Inventory._CurrentCharUnit[l]].CharUnits.transform.position == Data.CharacterD[CharacterMotion._curCharacter].CharUnits.transform.position + new Vector3(0.3f, 0.2f, 0f) && Data.CharacterD[Inventory._CurrentCharUnit[l]].CharUnits.name != Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name)
			{
				CharacterMotion.SortInPoint[2] = true;
			}
			if (Data.CharacterD[Inventory._CurrentCharUnit[l]].CharUnits.transform.position == Data.CharacterD[CharacterMotion._curCharacter].CharUnits.transform.position + new Vector3(0.3f, -0.2f, 0f) && Data.CharacterD[Inventory._CurrentCharUnit[l]].CharUnits.name != Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name)
			{
				CharacterMotion.SortInPoint[3] = true;
			}
			if (Data.CharacterD[Inventory._CurrentCharUnit[l]].CharUnits.transform.position == Data.CharacterD[CharacterMotion._curCharacter].CharUnits.transform.position + new Vector3(-0.3f, -0.2f, 0f) && Data.CharacterD[Inventory._CurrentCharUnit[l]].CharUnits.name != Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name)
			{
				CharacterMotion.SortInPoint[4] = true;
			}
			if (Data.CharacterD[Inventory._CurrentCharUnit[l]].CharUnits.transform.position == Data.CharacterD[CharacterMotion._curCharacter].CharUnits.transform.position + new Vector3(0.3f, 0f, 0f) && Data.CharacterD[Inventory._CurrentCharUnit[l]].CharUnits.name != Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name)
			{
				CharacterMotion.SortInPoint[5] = true;
			}
			if (Data.CharacterD[Inventory._CurrentCharUnit[l]].CharUnits.transform.position == Data.CharacterD[CharacterMotion._curCharacter].CharUnits.transform.position + new Vector3(-0.3f, 0f, 0f) && Data.CharacterD[Inventory._CurrentCharUnit[l]].CharUnits.name != Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name)
			{
				CharacterMotion.SortInPoint[6] = true;
			}
		}
		for (int m = 0; m < CharacterMotion.SortInPoint.Length; m++)
		{
			if (CharacterMotion.SortInPoint[m])
			{
				continue;
			}
			if (m == 0)
			{
				CharacterMotion.PositionCurChar = Data.CharacterD[CharacterMotion._curCharacter].CharUnits.transform.position;
				break;
			}
			if (m == 1)
			{
				CharacterMotion.PositionCurChar = Data.CharacterD[CharacterMotion._curCharacter].CharUnits.transform.position + new Vector3(-0.3f, 0.2f, 0f);
				break;
			}
			if (m == 2)
			{
				CharacterMotion.PositionCurChar = Data.CharacterD[CharacterMotion._curCharacter].CharUnits.transform.position + new Vector3(0.3f, 0.2f, 0f);
				break;
			}
			if (m == 3)
			{
				CharacterMotion.PositionCurChar = Data.CharacterD[CharacterMotion._curCharacter].CharUnits.transform.position + new Vector3(0.3f, -0.2f, 0f);
				break;
			}
			if (m == 4)
			{
				CharacterMotion.PositionCurChar = Data.CharacterD[CharacterMotion._curCharacter].CharUnits.transform.position + new Vector3(-0.3f, -0.2f, 0f);
			}
			switch (m)
			{
			case 5:
				CharacterMotion.PositionCurChar = Data.CharacterD[CharacterMotion._curCharacter].CharUnits.transform.position + new Vector3(0.3f, 0f, 0f);
				break;
			case 6:
				CharacterMotion.PositionCurChar = Data.CharacterD[CharacterMotion._curCharacter].CharUnits.transform.position + new Vector3(-0.3f, 0f, 0f);
				break;
			}
			break;
		}
		Data.CharacterD[CharacterMotion._curCharacter].CharUnits.transform.position = CharacterMotion.PositionCurChar;
	}

	public static void AAAAAAAAAAAAAAAAAAAAg()
	{
		for (int i = 0; i < Data.CharacterD.Count; i++)
		{
			if (!(Data.CharacterD[i].NameU == Data.CharacterD[CharacterMotion._curCharacter].NameU) || i == CharacterMotion._curCharacter)
			{
				continue;
			}
			if (Data.CharacterD[i].TypeChInt == 1)
			{
				Data.CharacterD[i].NameU = NameCharacter.NameCharLib[Random.Range(0, NameCharacter.NameCharLib.Length - 1)] + " " + NameCharacter.NickCharLib[Random.Range(0, NameCharacter.NickCharLib.Length - 1)] + ", Одиночки";
				Data._character.CharUnits.name = Data.CharacterD[i].NameU;
			}
			if (Data.CharacterD[i].TypeChInt == 2)
			{
				Data.CharacterD[i].NameU = NameCharacter.NameCharLib[Random.Range(0, NameCharacter.NameCharLib.Length - 1)] + " " + NameCharacter.NickCharLib[Random.Range(0, NameCharacter.NickCharLib.Length - 1)] + ", Бандит";
				Data._character.CharUnits.name = Data.CharacterD[i].NameU;
			}
			if (Data.CharacterD[i].TypeChInt == 3)
			{
				Data.CharacterD[i].NameU = NameCharacter.RankLib[Random.Range(0, NameCharacter.RankLib.Length - 1)] + " " + NameCharacter.SurnameCharLib[Random.Range(0, NameCharacter.SurnameCharLib.Length - 1)] + ", Военный";
				Data._character.CharUnits.name = Data.CharacterD[i].NameU;
			}
			if (Data.CharacterD[i].TypeChInt == 4)
			{
				Data.CharacterD[i].NameU = NameCharacter.NameCharLib[Random.Range(0, NameCharacter.NameCharLib.Length - 1)] + " " + NameCharacter.NickCharLib[Random.Range(0, NameCharacter.NickCharLib.Length - 1)] + ", Долг";
				Data._character.CharUnits.name = Data.CharacterD[i].NameU;
			}
			if (Data.CharacterD[i].TypeChInt == 5)
			{
				Data.CharacterD[i].NameU = NameCharacter.NameCharLib[Random.Range(0, NameCharacter.NameCharLib.Length - 1)] + " " + NameCharacter.NickCharLib[Random.Range(0, NameCharacter.NickCharLib.Length - 1)] + ", Наемник";
				Data._character.CharUnits.name = Data.CharacterD[i].NameU;
			}
			if (Data.CharacterD[i].TypeChInt == 6)
			{
				Data.CharacterD[i].NameU = NameCharacter.NameCharLib[Random.Range(0, NameCharacter.NameCharLib.Length - 1)] + " " + NameCharacter.NickCharLib[Random.Range(0, NameCharacter.NickCharLib.Length - 1)] + ", Свобода";
				Data._character.CharUnits.name = Data.CharacterD[i].NameU;
			}
			if (Data.CharacterD[i].TypeChInt == 7)
			{
				Data.CharacterD[i].NameU = NameCharacter.NameCharLib[Random.Range(0, NameCharacter.NameCharLib.Length - 1)] + " " + NameCharacter.NickCharLib[Random.Range(0, NameCharacter.NickCharLib.Length - 1)] + ", Чистое небо";
				Data._character.CharUnits.name = Data.CharacterD[i].NameU;
			}
			if (Data.CharacterD[i].TypeChInt == 8)
			{
				Data.CharacterD[i].NameU = NameCharacter.NameCharLib[Random.Range(0, NameCharacter.NameCharLib.Length - 1)] + " " + NameCharacter.NickCharLib[Random.Range(0, NameCharacter.NickCharLib.Length - 1)] + ", Монолит";
				Data._character.CharUnits.name = Data.CharacterD[i].NameU;
			}
			if (Data.CharacterD[i].TypeChInt == 9 || Data.CharacterD[i].TypeChInt == 10)
			{
				if (Data.CharacterD[i].TypeChar == AAAAAAAAAAAAAAAAf.TypeCharacter.Плоть)
				{
					Data.CharacterD[i].NameU = "Плоть, " + NameCharacter.NameMutantFemenineLib[Random.Range(0, NameCharacter.NameMutantFemenineLib.Length - 1)] + ", " + NameCharacter.NameMutantFemenineLib[Random.Range(0, NameCharacter.NameMutantFemenineLib.Length - 1)];
					Data._character.CharUnits.name = Data.CharacterD[i].NameU;
				}
				if (Data.CharacterD[i].TypeChar == AAAAAAAAAAAAAAAAf.TypeCharacter.Кабан)
				{
					Data.CharacterD[i].NameU = "Кабан, " + NameCharacter.NameMutantLib[Random.Range(0, NameCharacter.NameMutantLib.Length - 1)] + ", " + NameCharacter.NameMutantLib[Random.Range(0, NameCharacter.NameMutantLib.Length - 1)];
					Data._character.CharUnits.name = Data.CharacterD[i].NameU;
				}
				if (Data.CharacterD[i].TypeChar == AAAAAAAAAAAAAAAAf.TypeCharacter.Пес)
				{
					Data.CharacterD[i].NameU = "Слепой пес, " + NameCharacter.NameMutantLib[Random.Range(0, NameCharacter.NameMutantLib.Length - 1)] + ", " + NameCharacter.NameMutantLib[Random.Range(0, NameCharacter.NameMutantLib.Length - 1)];
					Data._character.CharUnits.name = Data.CharacterD[i].NameU;
				}
				if (Data.CharacterD[i].TypeChar == AAAAAAAAAAAAAAAAf.TypeCharacter.Псевдособака)
				{
					Data.CharacterD[i].NameU = "Псевдособака, " + NameCharacter.NameMutantFemenineLib[Random.Range(0, NameCharacter.NameMutantFemenineLib.Length - 1)] + ", " + NameCharacter.NameMutantFemenineLib[Random.Range(0, NameCharacter.NameMutantFemenineLib.Length - 1)];
					Data._character.CharUnits.name = Data.CharacterD[i].NameU;
				}
				if (Data.CharacterD[i].TypeChar == AAAAAAAAAAAAAAAAf.TypeCharacter.Снорк)
				{
					Data.CharacterD[i].NameU = "Снорк, " + NameCharacter.NameMutantLib[Random.Range(0, NameCharacter.NameMutantLib.Length - 1)] + ", " + NameCharacter.NameMutantLib[Random.Range(0, NameCharacter.NameMutantLib.Length - 1)];
					Data._character.CharUnits.name = Data.CharacterD[i].NameU;
				}
				if (Data.CharacterD[i].TypeChar == AAAAAAAAAAAAAAAAf.TypeCharacter.Зомби)
				{
					Data.CharacterD[i].NameU = "Зомби, " + NameCharacter.NameCharLib[Random.Range(0, NameCharacter.NameCharLib.Length - 1)] + " " + NameCharacter.NickCharLib[Random.Range(0, NameCharacter.NickCharLib.Length - 1)];
					Data._character.CharUnits.name = Data.CharacterD[i].NameU;
				}
				if (Data.CharacterD[i].TypeChar == AAAAAAAAAAAAAAAAf.TypeCharacter.Кровосос)
				{
					Data.CharacterD[i].NameU = "Кровосос, " + NameCharacter.NameMutantLib[Random.Range(0, NameCharacter.NameMutantLib.Length - 1)];
					Data._character.CharUnits.name = Data.CharacterD[i].NameU;
				}
				if (Data.CharacterD[i].TypeChar == AAAAAAAAAAAAAAAAf.TypeCharacter.Контролер)
				{
					Data.CharacterD[i].NameU = "Контролер, " + NameCharacter.NameMutantLib[Random.Range(0, NameCharacter.NameMutantLib.Length - 1)];
					Data._character.CharUnits.name = Data.CharacterD[i].NameU;
				}
			}
			if (Data.CharacterD[i].TypeChInt == 11)
			{
				Data.CharacterD[i].NameU = NameCharacter.SurnameCharLib[Random.Range(0, NameCharacter.SurnameCharLib.Length - 1)] + ", Ученые";
				Data._character.CharUnits.name = Data.CharacterD[i].NameU;
			}
			if (Data.CharacterD[i].TypeChInt == 12)
			{
				Data.CharacterD[i].NameU = NameCharacter.NameCharLib[Random.Range(0, NameCharacter.NameCharLib.Length - 1)] + " " + NameCharacter.NickCharLib[Random.Range(0, NameCharacter.NickCharLib.Length - 1)] + ", Ренегат";
				Data._character.CharUnits.name = Data.CharacterD[i].NameU;
			}
			Debug.Log("!!!" + Data._character.CharUnits.name + "!!!");
		}
	}
}
