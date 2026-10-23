using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PointAndChar : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
{
	public static Vector2 PlaseButtonFire;

	public static string MapNameForButton;

	public void OnPointerDown(PointerEventData eventData)
	{
		if (CharacterMotion.BGofPointAndChar != null)
		{
			Object.Destroy(CharacterMotion.BGofPointAndChar);
		}
		if (CharacterMotion.ActPointAndChar != null)
		{
			Object.Destroy(CharacterMotion.ActPointAndChar);
		}
		if (Inventory._CurrentPoint.Count > 0)
		{
			if (base.gameObject.transform.GetComponentInChildren<Text>().text == "Перейти" + Data.Points[Inventory._CurrentPoint[0]].TeleportName)
			{
				Inventory._PointInf = false;
				SaveLoad.AAAAAAAAAAAAAAAAAAAck(Data.Points[Inventory._CurrentPoint[0]].Teleport, Data.Points[Inventory._CurrentPoint[0]].TeleportGex.NameGex, null);
				Inventory._CurrentCharUnit.Clear();
				GameObject.Find("Main Camera").GetComponent<LoadingCircleScript>().AAAAAAAAAAAAAAAAe(Data.Points[Inventory._CurrentPoint[0]].Teleport, "AutoSave");
				return;
			}
			if (base.gameObject.transform.GetComponentInChildren<Text>().text == "Перейти" + Data.Points[Inventory._CurrentPoint[0]].TeleportNameDouble)
			{
				Inventory._PointInf = false;
				SaveLoad.AAAAAAAAAAAAAAAAAAAck(Data.Points[Inventory._CurrentPoint[0]].TeleportDouble, Data.Points[Inventory._CurrentPoint[0]].TeleportGexDouble.NameGex, null);
				Inventory._CurrentCharUnit.Clear();
				GameObject.Find("Main Camera").GetComponent<LoadingCircleScript>().AAAAAAAAAAAAAAAAe(Data.Points[Inventory._CurrentPoint[0]].TeleportDouble, "AutoSave");
				return;
			}
			if (base.gameObject.transform.GetComponentInChildren<Text>().text == "Перейти с союзником" + Data.Points[Inventory._CurrentPoint[0]].TeleportName)
			{
				Inventory._PointInf = false;
				for (int i = 0; i < Inventory._CurrentCharUnit.Count; i++)
				{
					if (Inventory._CurrentCharUnit[i] != 0 && Data.CharacterD[Inventory._CurrentCharUnit[i]].ControlGamer)
					{
						AAAAAAAAAAAAAAAAf aAAAAAAAAAAAAAcl = Data.CharacterD[Inventory._CurrentCharUnit[i]];
						SaveLoad.AAAAAAAAAAAAAAAAAAAck(Data.Points[Inventory._CurrentPoint[0]].Teleport, Data.Points[Inventory._CurrentPoint[0]].TeleportGex.NameGex, aAAAAAAAAAAAAAcl);
						Inventory._CurrentCharUnit.Clear();
						GameObject.Find("Main Camera").GetComponent<LoadingCircleScript>().AAAAAAAAAAAAAAAAe(Data.Points[Inventory._CurrentPoint[0]].Teleport, "AutoSave");
						return;
					}
				}
			}
			if (base.gameObject.transform.GetComponentInChildren<Text>().text == "Перейти с союзником" + Data.Points[Inventory._CurrentPoint[0]].TeleportNameDouble)
			{
				Inventory._PointInf = false;
				for (int j = 0; j < Inventory._CurrentCharUnit.Count; j++)
				{
					if (Inventory._CurrentCharUnit[j] != 0 && Data.CharacterD[Inventory._CurrentCharUnit[j]].ControlGamer)
					{
						AAAAAAAAAAAAAAAAf aAAAAAAAAAAAAAcl2 = Data.CharacterD[Inventory._CurrentCharUnit[j]];
						SaveLoad.AAAAAAAAAAAAAAAAAAAck(Data.Points[Inventory._CurrentPoint[0]].TeleportDouble, Data.Points[Inventory._CurrentPoint[0]].TeleportGexDouble.NameGex, aAAAAAAAAAAAAAcl2);
						Inventory._CurrentCharUnit.Clear();
						GameObject.Find("Main Camera").GetComponent<LoadingCircleScript>().AAAAAAAAAAAAAAAAe(Data.Points[Inventory._CurrentPoint[0]].TeleportDouble, "AutoSave");
						return;
					}
				}
			}
		}
		if (base.gameObject.transform.GetComponentInChildren<Text>().text == "Торговать" || base.gameObject.transform.GetComponentInChildren<Text>().text == "Обыскать")
		{
			AAAAAAAAAAAAAAAca();
			return;
		}
		if (base.gameObject.transform.GetComponentInChildren<Text>().text == "Экипировка")
		{
			AAAAAAAAAAAAAAAcb();
			return;
		}
		if (base.gameObject.transform.GetComponentInChildren<Text>().text == "Исследовать аномалию" || base.gameObject.transform.GetComponentInChildren<Text>().text == "Найден артефакт")
		{
			if (Data.CharacterD[CharacterMotion._curCharacter].CurGexChar == CharacterMotion._TurGex)
			{
				Inventory.AAAAAAAAAAAAAAAAAAAAch();
				Inventory.AAAAAAAAAAAAAAAAAbw();
				if (CharacterMotion.PointInform != null)
				{
					CharacterMotion.PointInform.SetActive(false);
				}
				Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
				Inventory.SoundMenu.Play();
				Inventory._Equipment = false;
				CharacterMotion.CachePanel = true;
				Inventory._CurtainGUIEquipment.SetActive(false);
				Inventory._CurtainIconCharacterU.SetActive(false);
				Inventory._CurtainState.SetActive(false);
				Inventory._currentSubject = Data._NoneSubject;
				ContragentInstanse.AAAAAAAAAAAAAAAAAAAAby();
			}
			return;
		}
		if (base.gameObject.transform.GetComponentInChildren<Text>().text == "Осмотреть")
		{
			if (CharacterMotion.PointInform != null)
			{
				CharacterMotion.PointInform.SetActive(false);
			}
			Inventory.AAAAAAAAAAAAAAAAAAAAAcf();
			Methods.AAAAAAAAAAAAAAAAAAAAAcs();
			Inventory._Equipment = false;
			Inventory._PointInformation = true;
			Inventory._PointInf = true;
			Inventory._CurtainGUIEquipment.SetActive(false);
			Inventory._CurtainIconCharacterU.SetActive(false);
			Inventory._CurtainState.SetActive(false);
			Inventory._CurtainInventory.SetActive(true);
			Inventory._currentSubject = Data._NoneSubject;
			return;
		}
		if (base.gameObject.transform.GetComponentInChildren<Text>().text == "Идти")
		{
			Inventory._GGActive = true;
			Inventory._CurrentCharUnit.Clear();
			Inventory._CurrentPoint.Clear();
			Inventory._CurtainIconCharacterU.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 0f);
			return;
		}
		if (base.gameObject.transform.GetComponentInChildren<Text>().text == "Использовать нож")
		{
			Object.Destroy(base.gameObject);
			GrenadeUse.CurrentGrenadeName = "нож";
			GameObject.Find("Data").GetComponent<GrenadeUse>().AAAAAAAAAAAAAAbr();
			AAAAAAAAAAAAAAAAAAAAcq();
		}
		if (base.gameObject.transform.GetComponentInChildren<Text>().text == "Использовать Ф1")
		{
			Object.Destroy(base.gameObject);
			GrenadeUse.CurrentGrenadeName = "Ф1";
			GameObject.Find("Data").GetComponent<GrenadeUse>().AAAAAAAAAAAAAAbr();
		}
		if (base.gameObject.transform.GetComponentInChildren<Text>().text == "Использовать РГД-5")
		{
			Object.Destroy(base.gameObject);
			GrenadeUse.CurrentGrenadeName = "РГД-5";
			GameObject.Find("Data").GetComponent<GrenadeUse>().AAAAAAAAAAAAAAbr();
		}
		if (base.gameObject.transform.GetComponentInChildren<Text>().text == "Использовать гранатомет")
		{
			Object.Destroy(base.gameObject);
			for (int k = 0; k < 20; k++)
			{
				if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[k].TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Grenade && Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[k].TypeGren == Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.TypeGren)
				{
					GrenadeUse.CurrentGrenadeName = Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[k].NameSubject;
					GameObject.Find("Data").GetComponent<GrenadeUse>().AAAAAAAAAAAAAAbr();
					break;
				}
			}
		}
		if (base.gameObject.transform.GetComponentInChildren<Text>().text == "Атаковать")
		{
			GameObject.Find("Data").GetComponent<Inventory>().AAAAAAAAAAAAAAAAAAct();
			Object.Destroy(CharacterMotion.PointInform);
			AAAAAAAAAAAAAAAAAAAAcq();
			return;
		}
		if (base.gameObject.transform.GetComponentInChildren<Text>().text == "Завершить ход" || base.gameObject.transform.GetComponentInChildren<RawImage>().texture.name == "CompleteMoveWhite")
		{
			Inventory.AAAAAAAAAAAAAAAAAAAAAcf();
			GameObject.Find("Data").GetComponent<Inventory>().AAAAAAAAAAAAAAAAAAcg();
			return;
		}
		if (base.gameObject.transform.GetComponentInChildren<RawImage>().texture.name == "Star")
		{
			CharacterMotion.BGofPointAndChar = (GameObject)Object.Instantiate(Resources.Load("Prefabs/BGofPointAndChar"));
			CharacterMotion.BGofPointAndChar.transform.SetParent(base.gameObject.transform, false);
			CharacterMotion.BGofPointAndChar.GetComponent<Image>().color = new Color(0.2f, 0.7f, 0.8f, 0.4f);
			CharacterMotion.ActPointAndChar = (GameObject)Object.Instantiate(Resources.Load("Prefabs/PointInformation"));
			CharacterMotion.ActPointAndChar.transform.SetParent(base.gameObject.transform, false);
			CharacterMotion.ActPointAndChar.transform.localPosition = new Vector2(Screen.height / 10, 0f);
			CharacterMotion.PointInform.transform.GetChild(0).GetComponent<GridLayoutGroup>().cellSize = new Vector2(Screen.height / 3, Screen.height / 10);
			CharacterMotion.PointInform.transform.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 3);
			AAAAAAAAAAAAAAAAAAAAAco();
			Methods.AAAAAAAAAAAAAAcn();
		}
		if (base.gameObject.transform.GetComponentInChildren<RawImage>().texture.name != "Star" && base.gameObject.transform.GetComponentInChildren<RawImage>().texture.name != "Tasks0" && base.gameObject.transform.GetComponentInChildren<Text>().text != "Перезарядить оружие" && base.gameObject.transform.GetComponentInChildren<Text>().text != "Найден артефакт")
		{
			CharacterMotion.BGofPointAndChar = (GameObject)Object.Instantiate(Resources.Load("Prefabs/BGofPointAndChar"));
			CharacterMotion.BGofPointAndChar.transform.SetParent(base.gameObject.transform, false);
			CharacterMotion.BGofPointAndChar.GetComponent<Image>().color = new Color(0.2f, 0.7f, 0.8f, 0.4f);
			CharacterMotion.ActPointAndChar = (GameObject)Object.Instantiate(Resources.Load("Prefabs/PointInformation"));
			CharacterMotion.ActPointAndChar.transform.SetParent(base.gameObject.transform, false);
			CharacterMotion.ActPointAndChar.transform.localPosition = new Vector2(Screen.height / 10, 0f);
			CharacterMotion.PointInform.transform.GetChild(0).GetComponent<GridLayoutGroup>().cellSize = new Vector2(Screen.height / 3, Screen.height / 10);
			CharacterMotion.PointInform.transform.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 3);
			for (int l = 0; l < Inventory._CurrentCharUnit.Count; l++)
			{
				if (Data.CharacterD[Inventory._CurrentCharUnit[l]].CharUnits.name == base.gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text)
				{
					Inventory._currentCharacterNumber = Inventory._CurrentCharUnit[l];
					Inventory._curNumb = l;
				}
			}
			if (Data.CharacterD[Inventory._currentCharacterNumber].ControlGamer)
			{
				AAAAAAAAAAAAAAch();
			}
			if (!Data.CharacterD[Inventory._currentCharacterNumber].ControlGamer)
			{
				AAAAAAAAAAAAAAAAAcd();
				AAAAAAAAAAAAAAAAAAAAAcn();
			}
		}
		if (base.gameObject.transform.GetComponentInChildren<RawImage>().texture.name == "Tasks0")
		{
			CharacterMotion.BGofPointAndChar = (GameObject)Object.Instantiate(Resources.Load("Prefabs/BGofPointAndChar"));
			CharacterMotion.BGofPointAndChar.transform.SetParent(base.gameObject.transform, false);
			CharacterMotion.BGofPointAndChar.GetComponent<Image>().color = new Color(0.2f, 0.7f, 0.8f, 0.4f);
			CharacterMotion.ActPointAndChar = (GameObject)Object.Instantiate(Resources.Load("Prefabs/PointInformation"));
			CharacterMotion.ActPointAndChar.transform.SetParent(base.gameObject.transform, false);
			CharacterMotion.ActPointAndChar.transform.localPosition = new Vector2(Screen.height / 10, 0f);
			CharacterMotion.PointInform.transform.GetChild(0).GetComponent<GridLayoutGroup>().cellSize = new Vector2(Screen.height / 3, Screen.height / 10);
			CharacterMotion.PointInform.transform.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 3);
			AAAAAAAAAAAAAAAAAAAAcp();
		}
		if (base.gameObject.transform.GetComponentInChildren<Text>().text == "Перезарядить оружие")
		{
			Inventory.AAAAAAAAAAAAAAAAbx();
			Object.Destroy(base.gameObject);
		}
		if (base.gameObject.transform.GetComponentInChildren<RawImage>().texture.name == "compass")
		{
			if (Data.TaskAll[Inventory._TaskNum].KillQuest || Data.TaskAll[Inventory._TaskNum].BalansQuest || Data.TaskAll[Inventory._TaskNum].SubjectQuest || Data.TaskAll[Inventory._TaskNum].GuideQuest || Data.TaskAll[Inventory._TaskNum].GetToPointQuest)
			{
				Object.Destroy(base.gameObject);
			}
			else
			{
				AAAAAAAAAAAAAAcj();
			}
		}
	}

	public static void AAAAAAAAAAAAAAcg()
	{
		if (Data.CharacterD[CharacterMotion._curCharacter].CurGexChar != CharacterMotion._TurGex && CharacterMotion._PointsMove > 0)
		{
			CharacterMotion.PanelInfChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/PointInfChild"));
			CharacterMotion.PanelInfChild.transform.SetParent(CharacterMotion.PointInform.transform.GetChild(0));
			CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().texture = Inventory._Run;
			CharacterMotion.PanelInfChild.GetComponentInChildren<GridLayoutGroup>().cellSize = new Vector2(Inventory._posY9, Inventory._posY9);
			CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 9);
			CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 9);
			CharacterMotion.NameChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/NameChild"));
			CharacterMotion.NameChild.transform.SetParent(CharacterMotion.PanelInfChild.transform.Find("RawImage").transform);
			CharacterMotion.NameChild.GetComponent<Text>().text = "Идти";
			CharacterMotion.NameChild.transform.localPosition = new Vector2(Screen.height / 5, 0f);
			CharacterMotion.NameChild.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 6);
		}
	}

	public static void AAAAAAAAAAAAAAAAAAAch()
	{
		if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Cartridge * 2 <= Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.CartridgeInMagazineFull && CharacterMotion._PointsMove > 0)
		{
			CharacterMotion.PanelInfChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/PointInfChild"));
			CharacterMotion.PanelInfChild.transform.SetParent(CharacterMotion.PointInform.transform.GetChild(0));
			CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().texture = Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.CartridgesImage;
			CharacterMotion.PanelInfChild.GetComponentInChildren<GridLayoutGroup>().cellSize = new Vector2(Inventory._posY9, Inventory._posY9);
			CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 9);
			CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 9);
			CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().SetNativeSize();
			CharacterMotion.NameChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/NameChild"));
			CharacterMotion.NameChild.transform.SetParent(CharacterMotion.PanelInfChild.transform.Find("RawImage").transform);
			CharacterMotion.NameChild.GetComponent<Text>().text = "Перезарядить оружие";
			if (CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().texture.name == "Slot128")
			{
				CharacterMotion.NameChild.GetComponent<Text>().text = "Нет оружия";
			}
			CharacterMotion.NameChild.transform.localPosition = new Vector2(Screen.height / 5, 0f);
			CharacterMotion.NameChild.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 6);
		}
	}

	public static void AAAAAAAAAAAAAAAAAAAAAcm()
	{
		CharacterMotion.PanelInfChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/PointInfChild"));
		CharacterMotion.PanelInfChild.transform.SetParent(CharacterMotion.PointInform.transform.GetChild(0));
		CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().texture = Inventory._CompleteMove;
		CharacterMotion.PanelInfChild.GetComponentInChildren<GridLayoutGroup>().cellSize = new Vector2(Inventory._posY9, Inventory._posY9);
		CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 9);
		CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 9);
		CharacterMotion.NameChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/NameChild"));
		CharacterMotion.NameChild.transform.SetParent(CharacterMotion.PanelInfChild.transform.Find("RawImage").transform);
		if (CharacterMotion._PointsMove > 0)
		{
			CharacterMotion.NameChild.GetComponent<Text>().text = "Завершить ход";
		}
		else
		{
			CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().texture = (Texture2D)Resources.Load("Sprites/IconGUI/CompleteMoveWhite");
			CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().color = new Color(0.85f, 0f, 0f, 0.9f);
			CharacterMotion.NameChild.GetComponent<Text>().color = new Color(0.85f, 0f, 0f, 0.9f);
			CharacterMotion.NameChild.GetComponent<Text>().text = "Очки хода закончились. Завершите ход.";
		}
		CharacterMotion.NameChild.transform.localPosition = new Vector2(Screen.height / 5, 0f);
		CharacterMotion.NameChild.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 6);
		CharacterMotion.NameChild.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 12);
	}

	public static void AAAAAAAAAAAAAAAAAAAAAcn()
	{
		if (CharacterMotion._PointsMove > 0 && Data.CharacterD[Inventory._currentCharacterNumber].Life)
		{
			CharacterMotion.PanelInfChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/PointInfChild"));
			CharacterMotion.PanelInfChild.transform.SetParent(CharacterMotion.ActPointAndChar.transform.GetChild(0).transform);
			if (Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 9 && Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 10)
			{
				CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().texture = Inventory._FireTurI;
			}
			else
			{
				CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().texture = Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.FireButton;
			}
			CharacterMotion.PanelInfChild.GetComponentInChildren<GridLayoutGroup>().cellSize = new Vector2(Inventory._posY9, Inventory._posY9);
			CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 9);
			CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 9);
			CharacterMotion.NameChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/NameChild"));
			CharacterMotion.NameChild.transform.SetParent(CharacterMotion.PanelInfChild.transform.Find("RawImage").transform);
			if (CharacterMotion._DistansMove <= Inventory._Range && CharacterMotion._DistansMove >= Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.MinRange)
			{
				CharacterMotion.NameChild.GetComponent<Text>().text = "Атаковать";
			}
			if (CharacterMotion._DistansMove > Inventory._Range)
			{
				CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().color = new Color(0.75f, 0f, 0f, 1f);
				CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().texture = (Texture)Resources.Load("Sprites/IconGUI/Quit64");
				CharacterMotion.NameChild.GetComponent<Text>().text = "Цель вне зоны выстрела";
				CharacterMotion.NameChild.GetComponent<Text>().color = new Color(0.85f, 0f, 0f, 0.9f);
			}
			if (CharacterMotion._DistansMove < Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.MinRange)
			{
				CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().color = new Color(0.75f, 0f, 0f, 1f);
				CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().texture = (Texture)Resources.Load("Sprites/IconGUI/Quit64");
				CharacterMotion.NameChild.GetComponent<Text>().text = "Оружие не для ближнего боя";
				CharacterMotion.NameChild.GetComponent<Text>().color = new Color(0.85f, 0f, 0f, 0.9f);
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == Data.CharacterD[Inventory._CurrentCharUnit[Inventory._curNumb]].TypeChInt)
			{
				CharacterMotion.NameChild.GetComponent<Text>().text = "Дружественный персонаж, атаковать нельзя";
				CharacterMotion.NameChild.GetComponent<Text>().color = new Color(0.85f, 0f, 0f, 0.9f);
			}
			CharacterMotion.NameChild.transform.localPosition = new Vector2(Screen.height / 5, 0f);
			CharacterMotion.NameChild.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 6);
			CharacterMotion.ActPointAndChar.GetComponentInChildren<GridLayoutGroup>().cellSize = new Vector2(Screen.height / 3, Screen.height / 10);
			CharacterMotion.ActPointAndChar.transform.GetChild(0).GetComponent<GridLayoutGroup>().padding.left = Inventory._posX32;
			AAAAAAAAAAAAAAci();
			AAAAAAAAAAAAAAAAAAdd();
		}
	}

	public static void AAAAAAAAAAAAAAAAAAAAAco()
	{
		if (Data.Points[Inventory._CurrentPoint[0]].curGexPoint.ID == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.ID)
		{
			CharacterMotion.PanelInfChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/PointInfChild"));
			CharacterMotion.PanelInfChild.transform.SetParent(CharacterMotion.ActPointAndChar.transform.GetChild(0).transform);
			CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().texture = (Texture2D)Resources.Load("Sprites/IconGUI/Join96");
			CharacterMotion.PanelInfChild.GetComponentInChildren<GridLayoutGroup>().cellSize = new Vector2(Inventory._posY9, Inventory._posY9);
			CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 9);
			CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 9);
			CharacterMotion.NameChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/NameChild"));
			CharacterMotion.NameChild.transform.SetParent(CharacterMotion.PanelInfChild.transform.Find("RawImage").transform);
			CharacterMotion.NameChild.GetComponent<Text>().text = "Осмотреть";
			CharacterMotion.NameChild.transform.localPosition = new Vector2(Screen.height / 5, 0f);
			CharacterMotion.NameChild.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 5);
			if (Data.Points[Inventory._CurrentPoint[0]].pointTypes == ConstructorPoints.PointTypes.Anomaly && Data.CharacterD[CharacterMotion._curCharacter].DetectorChar.NameSubject != "None")
			{
				CharacterMotion.PanelInfChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/PointInfChild"));
				CharacterMotion.PanelInfChild.transform.SetParent(CharacterMotion.ActPointAndChar.transform.GetChild(0).transform);
				CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().texture = Data.CharacterD[CharacterMotion._curCharacter].DetectorChar.TextureSubject;
				CharacterMotion.PanelInfChild.GetComponentInChildren<GridLayoutGroup>().cellSize = new Vector2(Inventory._posY9, Inventory._posY9);
				CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 9);
				CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 9);
				CharacterMotion.NameChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/NameChild"));
				CharacterMotion.NameChild.transform.SetParent(CharacterMotion.PanelInfChild.transform.Find("RawImage").transform);
				CharacterMotion.NameChild.GetComponent<Text>().text = "Исследовать аномалию";
				CharacterMotion.NameChild.transform.localPosition = new Vector2(Screen.height / 5, 0f);
				CharacterMotion.NameChild.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 5);
			}
			if (Data.Points[Inventory._CurrentPoint[0]].TeleportName != "None" && CharacterMotion._curCharacter == 0)
			{
				CharacterMotion.PanelInfChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/PointInfChild"));
				CharacterMotion.PanelInfChild.transform.SetParent(CharacterMotion.ActPointAndChar.transform.GetChild(0).transform);
				CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().texture = (Texture2D)Resources.Load("Sprites/IconGUI/OverloadMove");
				CharacterMotion.PanelInfChild.GetComponentInChildren<GridLayoutGroup>().cellSize = new Vector2(Inventory._posY9, Inventory._posY9);
				CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 9);
				CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 9);
				CharacterMotion.NameChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/NameChild"));
				CharacterMotion.NameChild.transform.SetParent(CharacterMotion.PanelInfChild.transform.Find("RawImage").transform);
				CharacterMotion.NameChild.GetComponent<Text>().text = "Перейти" + Data.Points[Inventory._CurrentPoint[0]].TeleportName;
				CharacterMotion.NameChild.transform.localPosition = new Vector2(Screen.height / 5, 0f);
				CharacterMotion.NameChild.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 5);
				if (Inventory._CurrentCharUnit.Count > 1 && Data.CharacterD.Count > 13)
				{
					for (int i = 0; i < Inventory._CurrentCharUnit.Count; i++)
					{
						if (Inventory._CurrentCharUnit[i] != 0 && Data.CharacterD[Inventory._CurrentCharUnit[i]].ControlGamer)
						{
							CharacterMotion.PanelInfChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/PointInfChild"));
							CharacterMotion.PanelInfChild.transform.SetParent(CharacterMotion.ActPointAndChar.transform.GetChild(0).transform);
							CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().texture = (Texture2D)Resources.Load("Sprites/IconGUI/Move2x");
							CharacterMotion.PanelInfChild.GetComponentInChildren<GridLayoutGroup>().cellSize = new Vector2(Inventory._posY9, Inventory._posY9);
							CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 9);
							CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 9);
							CharacterMotion.NameChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/NameChild"));
							CharacterMotion.NameChild.transform.SetParent(CharacterMotion.PanelInfChild.transform.Find("RawImage").transform);
							CharacterMotion.NameChild.GetComponent<Text>().text = "Перейти с союзником" + Data.Points[Inventory._CurrentPoint[0]].TeleportName;
							CharacterMotion.NameChild.transform.localPosition = new Vector2(Screen.height / 5, 0f);
							CharacterMotion.NameChild.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 5);
							break;
						}
					}
				}
			}
			if (Data.Points[Inventory._CurrentPoint[0]].TeleportNameDouble != "None" && CharacterMotion._curCharacter == 0)
			{
				CharacterMotion.PanelInfChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/PointInfChild"));
				CharacterMotion.PanelInfChild.transform.SetParent(CharacterMotion.ActPointAndChar.transform.GetChild(0).transform);
				CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().texture = (Texture2D)Resources.Load("Sprites/IconGUI/OverloadMove");
				CharacterMotion.PanelInfChild.GetComponentInChildren<GridLayoutGroup>().cellSize = new Vector2(Inventory._posY9, Inventory._posY9);
				CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 9);
				CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 9);
				CharacterMotion.NameChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/NameChild"));
				CharacterMotion.NameChild.transform.SetParent(CharacterMotion.PanelInfChild.transform.Find("RawImage").transform);
				CharacterMotion.NameChild.GetComponent<Text>().text = "Перейти" + Data.Points[Inventory._CurrentPoint[0]].TeleportNameDouble;
				CharacterMotion.NameChild.transform.localPosition = new Vector2(Screen.height / 5, 0f);
				CharacterMotion.NameChild.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 5);
				if (Inventory._CurrentCharUnit.Count > 1 && Data.CharacterD.Count > 13)
				{
					for (int j = 0; j < Inventory._CurrentCharUnit.Count; j++)
					{
						if (Inventory._CurrentCharUnit[j] != 0 && Data.CharacterD[Inventory._CurrentCharUnit[j]].ControlGamer)
						{
							CharacterMotion.PanelInfChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/PointInfChild"));
							CharacterMotion.PanelInfChild.transform.SetParent(CharacterMotion.ActPointAndChar.transform.GetChild(0).transform);
							CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().texture = (Texture2D)Resources.Load("Sprites/IconGUI/Move2x");
							CharacterMotion.PanelInfChild.GetComponentInChildren<GridLayoutGroup>().cellSize = new Vector2(Inventory._posY9, Inventory._posY9);
							CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 9);
							CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 9);
							CharacterMotion.NameChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/NameChild"));
							CharacterMotion.NameChild.transform.SetParent(CharacterMotion.PanelInfChild.transform.Find("RawImage").transform);
							CharacterMotion.NameChild.GetComponent<Text>().text = "Перейти с союзником" + Data.Points[Inventory._CurrentPoint[0]].TeleportNameDouble;
							CharacterMotion.NameChild.transform.localPosition = new Vector2(Screen.height / 5, 0f);
							CharacterMotion.NameChild.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 5);
							break;
						}
					}
				}
			}
			CharacterMotion.ActPointAndChar.GetComponentInChildren<GridLayoutGroup>().cellSize = new Vector2(Screen.height / 3, Screen.height / 10);
			CharacterMotion.ActPointAndChar.transform.GetChild(0).GetComponent<GridLayoutGroup>().padding.left = Inventory._posX32;
		}
		else
		{
			CharacterMotion.PanelInfChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/PointInfChild"));
			CharacterMotion.PanelInfChild.transform.SetParent(CharacterMotion.ActPointAndChar.transform.GetChild(0).transform);
			CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().texture = (Texture2D)Resources.Load("Sprites/Subject/binoculars");
			CharacterMotion.PanelInfChild.GetComponentInChildren<GridLayoutGroup>().cellSize = new Vector2(Inventory._posY9, Inventory._posY9);
			CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 9);
			CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 9);
			CharacterMotion.NameChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/NameChild"));
			CharacterMotion.NameChild.transform.SetParent(CharacterMotion.PanelInfChild.transform.Find("RawImage").transform);
			CharacterMotion.NameChild.GetComponent<Text>().text = "Осмотреть";
			CharacterMotion.NameChild.transform.localPosition = new Vector2(Screen.height / 5, 0f);
			CharacterMotion.NameChild.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 6);
			CharacterMotion.ActPointAndChar.GetComponentInChildren<GridLayoutGroup>().cellSize = new Vector2(Screen.height / 3, Screen.height / 10);
			CharacterMotion.ActPointAndChar.transform.GetChild(0).GetComponent<GridLayoutGroup>().padding.left = Inventory._posX32;
		}
	}

	public static void AAAAAAAAAAAAAAAAAcd()
	{
		if (Data.CharacterD[Inventory._currentCharacterNumber].CurGexChar.ID == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.ID)
		{
			CharacterMotion.PanelInfChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/PointInfChild"));
			CharacterMotion.PanelInfChild.transform.SetParent(CharacterMotion.ActPointAndChar.transform.GetChild(0).transform);
			CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().texture = (Texture2D)Resources.Load("Sprites/IconGUI/Change0");
			CharacterMotion.PanelInfChild.GetComponentInChildren<GridLayoutGroup>().cellSize = new Vector2(Inventory._posY9, Inventory._posY9);
			CharacterMotion.ActPointAndChar.GetComponentInChildren<GridLayoutGroup>().cellSize = new Vector2(Screen.height / 3, Screen.height / 10);
			CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 9);
			CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 9);
			CharacterMotion.NameChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/NameChild"));
			CharacterMotion.NameChild.transform.SetParent(CharacterMotion.PanelInfChild.transform.Find("RawImage").transform);
			CharacterMotion.NameChild.GetComponent<Text>().text = "Торговать";
			if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.CharacterD[CharacterMotion._curCharacter].TypeChInt, Data.CharacterD[Inventory._currentCharacterNumber].TypeChInt] == 0)
			{
				CharacterMotion.NameChild.GetComponent<Text>().text = "Враждебные персонажи не торгуют";
			}
			if (!Data.CharacterD[Inventory._currentCharacterNumber].Life)
			{
				CharacterMotion.NameChild.GetComponent<Text>().text = "Обыскать";
			}
			CharacterMotion.NameChild.transform.localPosition = new Vector2(Screen.height / 5, 0f);
			CharacterMotion.NameChild.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 6);
			CharacterMotion.ActPointAndChar.transform.GetChild(0).GetComponent<GridLayoutGroup>().padding.left = Inventory._posX32;
		}
	}

	public static void AAAAAAAAAAAAAAAca()
	{
		if (Inventory._GGActive || Inventory._CurrentCharUnit.Count <= 1 || !(Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.NameGex == Data.CharacterD[Inventory._currentCharacterNumber].CurGexChar.NameGex) || Inventory._currentCharacterNumber == 0)
		{
			return;
		}
		if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.CharacterD[CharacterMotion._curCharacter].TypeChInt, Data.CharacterD[Inventory._currentCharacterNumber].TypeChInt] != 0 || !Data.CharacterD[Inventory._currentCharacterNumber].Life)
		{
			if (CharacterMotion.PointInform != null)
			{
				CharacterMotion.PointInform.SetActive(false);
			}
			Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_close");
			Inventory.SoundMenu.Play();
			Inventory._Equipment = false;
			Inventory._CurtainGUIEquipment.SetActive(false);
			Inventory._CurtainIconCharacterU.SetActive(false);
			Inventory._CurtainState.SetActive(false);
			Inventory._currentSubject = Data._NoneSubject;
			ContragentInstanse.AAAAAAAAAAAAAAAAAbo();
		}
		else
		{
			Inventory.MessagePanel("Враждебные персонажи не торгуют");
		}
	}

	public static void AAAAAAAAAAAAAAch()
	{
		CharacterMotion.PanelInfChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/PointInfChild"));
		CharacterMotion.PanelInfChild.transform.SetParent(CharacterMotion.ActPointAndChar.transform.GetChild(0).transform);
		CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().texture = Inventory._curInventory;
		CharacterMotion.PanelInfChild.GetComponentInChildren<GridLayoutGroup>().cellSize = new Vector2(Inventory._posY9, Inventory._posY9);
		CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 9);
		CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 9);
		CharacterMotion.NameChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/NameChild"));
		CharacterMotion.NameChild.transform.SetParent(CharacterMotion.PanelInfChild.transform.Find("RawImage").transform);
		CharacterMotion.NameChild.GetComponent<Text>().text = "Экипировка";
		CharacterMotion.NameChild.transform.localPosition = new Vector2(Screen.height / 5, 0f);
		CharacterMotion.NameChild.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 6);
		if (CharacterMotion._curCharacter != Inventory._currentCharacterNumber)
		{
			CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().texture = (Texture2D)Resources.Load("Sprites/IconGUI/Change0");
			CharacterMotion.PanelInfChild.GetComponentInChildren<GridLayoutGroup>().cellSize = new Vector2(Inventory._posY9, Inventory._posY9);
			CharacterMotion.NameChild.GetComponent<Text>().text = "Торговать";
		}
		CharacterMotion.ActPointAndChar.GetComponentInChildren<GridLayoutGroup>().cellSize = new Vector2(Screen.height / 3, Screen.height / 10);
		CharacterMotion.ActPointAndChar.transform.GetChild(0).GetComponent<GridLayoutGroup>().padding.left = Inventory._posX32;
	}

	public static void AAAAAAAAAAAAAAAAAAAAcp()
	{
		CharacterMotion.PanelInfChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/PointInfChild"));
		CharacterMotion.PanelInfChild.transform.SetParent(CharacterMotion.ActPointAndChar.transform.GetChild(0).transform);
		CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().texture = (Texture2D)Resources.Load("Sprites/IconGUI/compass");
		CharacterMotion.PanelInfChild.GetComponentInChildren<GridLayoutGroup>().cellSize = new Vector2(Inventory._posY9, Inventory._posY9);
		CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 9);
		CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 9);
		CharacterMotion.NameChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/NameChild"));
		CharacterMotion.NameChild.transform.SetParent(CharacterMotion.PanelInfChild.transform.Find("RawImage").transform);
		CharacterMotion.NameChild.GetComponent<Text>().text = "Проложить маршрут";
		if (Data.TaskAll[Inventory._TaskNum].KillQuest || Data.TaskAll[Inventory._TaskNum].BalansQuest || Data.TaskAll[Inventory._TaskNum].SubjectQuest || Data.TaskAll[Inventory._TaskNum].GuideQuest || Data.TaskAll[Inventory._TaskNum].GetToPointQuest)
		{
			CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().texture = Data.TaskAll[Inventory._TaskNum].ImageTask;
			CharacterMotion.PanelInfChild.GetComponentInChildren<GridLayoutGroup>().cellSize = new Vector2(Inventory._posY9, Inventory._posY9);
			MapNameForButton = Data.TaskAll[Inventory._TaskNum].MapName;
			AAAAAAAAAAAAAAAAAce();
			if (Data.TaskAll[Inventory._TaskNum].GuideQuest || Data.TaskAll[Inventory._TaskNum].GetToPointQuest)
			{
				CharacterMotion.NameChild.GetComponent<Text>().text = "Точка назначения: " + Data.TaskAll[Inventory._TaskNum].NamePointTask + ", " + MapNameForButton;
			}
			else
			{
				CharacterMotion.NameChild.GetComponent<Text>().text = "Заказчик в точке: " + Data.TaskAll[Inventory._TaskNum].NamePointTask + ", " + MapNameForButton;
			}
		}
		CharacterMotion.NameChild.transform.localPosition = new Vector2(Screen.height / 5, 0f);
		CharacterMotion.NameChild.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 6);
		CharacterMotion.ActPointAndChar.GetComponentInChildren<GridLayoutGroup>().cellSize = new Vector2(Screen.height / 3, Screen.height / 10);
		CharacterMotion.ActPointAndChar.transform.GetChild(0).GetComponent<GridLayoutGroup>().padding.left = Inventory._posX32;
	}

	public static void AAAAAAAAAAAAAAAAAAdc()
	{
		if (CharacterMotion._curCharacter != 0 || Data.TaskAll[Inventory._TaskNum].NamePointTask == null || !(Data.TaskAll[Inventory._TaskNum].NamePointTask != string.Empty))
		{
			return;
		}
		CharacterMotion.PanelInfChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/PointInfChild"));
		CharacterMotion.PanelInfChild.transform.SetParent(CharacterMotion.PointInform.transform.GetChild(0));
		CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().texture = (Texture2D)Resources.Load("Sprites/IconGUI/Tasks0");
		CharacterMotion.PanelInfChild.GetComponentInChildren<GridLayoutGroup>().cellSize = new Vector2(Inventory._posY9, Inventory._posY9);
		CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 9);
		CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 9);
		CharacterMotion.NameChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/NameChild"));
		CharacterMotion.NameChild.transform.SetParent(CharacterMotion.PanelInfChild.transform.Find("RawImage").transform);
		CharacterMotion.NameChild.GetComponent<Text>().text = "Добраться до точки: " + Data.TaskAll[Inventory._TaskNum].NamePointTask;
		if (Data.TaskAll[Inventory._TaskNum].AdditionalTask)
		{
			if (Data.TaskAll[Inventory._TaskNum].KillQuest)
			{
				CharacterMotion.NameChild.GetComponent<Text>().text = "Ликвидировать персонажа: " + Data.TaskAll[Inventory._TaskNum].KillCharacterName;
			}
			if (Data.TaskAll[Inventory._TaskNum].BalansQuest)
			{
				CharacterMotion.NameChild.GetComponent<Text>().text = "Уничтожить бойцов группировки: " + Data.TaskAll[Inventory._TaskNum].GroupName;
			}
			if (Data.TaskAll[Inventory._TaskNum].GuideQuest)
			{
				CharacterMotion.NameChild.GetComponent<Text>().text = "Проводник персонажа: " + Data.TaskAll[Inventory._TaskNum].KillCharacterName;
			}
			if (Data.TaskAll[Inventory._TaskNum].SubjectQuest)
			{
				CharacterMotion.NameChild.GetComponent<Text>().text = "Принести заказчику товар: " + Data.TaskAll[Inventory._TaskNum].QuestSubject.NameSubject;
			}
		}
		CharacterMotion.NameChild.transform.localPosition = new Vector2(Screen.height / 5, 0f);
		CharacterMotion.NameChild.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 6);
		CharacterMotion.NameChild.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 12);
	}

	public static void AAAAAAAAAAAAAAAcb()
	{
		if (CharacterMotion.PointInform != null)
		{
			CharacterMotion.PointInform.SetActive(false);
		}
		Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_close");
		Inventory.SoundMenu.Play();
		Inventory._Equipment = false;
		Inventory._CurtainGUIEquipment.SetActive(false);
		Inventory._CurtainIconCharacterU.SetActive(false);
		Inventory._CurtainState.SetActive(false);
		Inventory._currentSubject = Data._NoneSubject;
		GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/NewEquipmentPanel"));
		gameObject.name = "NewEquipmentPanel";
		gameObject.transform.SetParent(GameObject.Find("Canvas").transform);
		SubjectAct.AAAAAAAAAAAAAAAAAAAbo();
	}

	public static void AAAAAAAAAAAAAAAAAAAAcq()
	{
		if (!Inventory._GGActive && Inventory._fireButton && CharacterMotion._PointsMove > 0 && Data.CharacterD[CharacterMotion._curCharacter].ControlGamer && Data.CharacterD[CharacterMotion._curCharacter].Life && Inventory._CurrentCharUnit.Count > 0 && Data.CharacterD[Inventory._currentCharacterNumber].Life)
		{
			CharacterMotion.PointInform = (GameObject)Object.Instantiate(Resources.Load("Prefabs/PointInformation"));
			CharacterMotion.PointInform.transform.SetParent(GameObject.Find("Canvas").transform);
			CharacterMotion.PointInform.transform.GetChild(0).GetComponent<GridLayoutGroup>().cellSize = new Vector2(Screen.height / 3, Screen.height / 10);
			CharacterMotion.PointInform.transform.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 3);
			CharacterMotion.PointInform.transform.position = PlaseButtonFire;
			CharacterMotion.PanelInfChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/PointInfChild"));
			CharacterMotion.PanelInfChild.transform.SetParent(CharacterMotion.PointInform.transform.GetChild(0));
			if (Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 9 && Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 10)
			{
				CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().texture = Inventory._FireTurI;
			}
			else
			{
				CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().texture = Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.FireButton;
			}
			CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 9);
			CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 9);
			CharacterMotion.NameChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/NameChild"));
			CharacterMotion.NameChild.transform.SetParent(CharacterMotion.PanelInfChild.transform.Find("RawImage").transform);
			if (CharacterMotion._DistansMove <= Inventory._Range && CharacterMotion._DistansMove >= Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.MinRange)
			{
				CharacterMotion.NameChild.GetComponent<Text>().text = "Атаковать";
			}
			if (CharacterMotion._DistansMove > Inventory._Range)
			{
				CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().color = new Color(0.75f, 0f, 0f, 1f);
				CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().texture = (Texture)Resources.Load("Sprites/IconGUI/Quit64");
				CharacterMotion.NameChild.GetComponent<Text>().text = "Цель вне зоны выстрела";
				CharacterMotion.NameChild.GetComponent<Text>().color = new Color(0.85f, 0f, 0f, 0.9f);
			}
			if (CharacterMotion._DistansMove < Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.MinRange)
			{
				CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().color = new Color(0.75f, 0f, 0f, 1f);
				CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().texture = (Texture)Resources.Load("Sprites/IconGUI/Quit64");
				CharacterMotion.NameChild.GetComponent<Text>().text = "Оружие не для ближнего боя";
				CharacterMotion.NameChild.GetComponent<Text>().color = new Color(0.85f, 0f, 0f, 0.9f);
			}
			CharacterMotion.NameChild.transform.localPosition = new Vector2(Screen.height / 5, 0f);
			CharacterMotion.NameChild.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 5);
			CharacterMotion.PanelInfChild.GetComponentInChildren<GridLayoutGroup>().cellSize = new Vector2(Inventory._posY9, Inventory._posY9);
			if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Cartridge * 2 <= Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.CartridgeInMagazineFull && CharacterMotion._PointsMove > 0)
			{
				CharacterMotion.PanelInfChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/PointInfChild"));
				CharacterMotion.PanelInfChild.transform.SetParent(CharacterMotion.PointInform.transform.GetChild(0));
				CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().texture = Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.CartridgesImage;
				CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 9);
				CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 9);
				CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().SetNativeSize();
				CharacterMotion.NameChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/NameChild"));
				CharacterMotion.NameChild.transform.SetParent(CharacterMotion.PanelInfChild.transform.Find("RawImage").transform);
				CharacterMotion.NameChild.GetComponent<Text>().text = "Перезарядить оружие";
				if (CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().texture.name == "Slot128")
				{
					CharacterMotion.NameChild.GetComponent<Text>().text = "Нет оружия";
				}
				CharacterMotion.NameChild.transform.localPosition = new Vector2(Screen.height / 5, 0f);
				CharacterMotion.NameChild.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 5);
				CharacterMotion.PanelInfChild.GetComponentInChildren<GridLayoutGroup>().cellSize = new Vector2(Inventory._posY9, Inventory._posY9);
			}
			if (CharacterMotion._PointsMove > 0 && CharacterMotion._curCharacter != Inventory._currentCharacterNumber && Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.ID == Data.CharacterD[Inventory._currentCharacterNumber].CurGexChar.ID)
			{
				CharacterMotion.PanelInfChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/PointInfChild"));
				CharacterMotion.PanelInfChild.transform.SetParent(CharacterMotion.PointInform.transform.GetChild(0));
				CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().texture = (Texture2D)Resources.Load("Sprites/Weapon/knife");
				CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 9);
				CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 9);
				CharacterMotion.NameChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/NameChild"));
				CharacterMotion.NameChild.transform.SetParent(CharacterMotion.PanelInfChild.transform.Find("RawImage").transform);
				CharacterMotion.NameChild.GetComponent<Text>().text = "Использовать нож";
				CharacterMotion.NameChild.transform.localPosition = new Vector2(Screen.height / 5, 0f);
				CharacterMotion.NameChild.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 5);
				CharacterMotion.PanelInfChild.GetComponentInChildren<GridLayoutGroup>().cellSize = new Vector2(Inventory._posY9, Inventory._posY9);
			}
			CharacterMotion.PointInform.GetComponentInChildren<GridLayoutGroup>().cellSize = new Vector2(Screen.height / 3, Screen.height / 10);
			CharacterMotion.PointInform.transform.GetChild(0).GetComponent<GridLayoutGroup>().padding.left = Inventory._posY4;
		}
		if (CharacterMotion._PointsMove == 0)
		{
			CharacterMotion.PointInform = (GameObject)Object.Instantiate(Resources.Load("Prefabs/PointInformation"));
			CharacterMotion.PointInform.transform.SetParent(GameObject.Find("Canvas").transform);
			CharacterMotion.PointInform.transform.GetChild(0).GetComponent<GridLayoutGroup>().cellSize = new Vector2(Screen.height / 3, Screen.height / 10);
			CharacterMotion.PointInform.transform.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 3);
			CharacterMotion.PointInform.transform.GetChild(0).GetComponent<GridLayoutGroup>().padding.left = Inventory._posY4;
			CharacterMotion.PointInform.transform.position = PlaseButtonFire;
			CharacterMotion.PanelInfChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/PointInfChild"));
			CharacterMotion.PanelInfChild.transform.SetParent(CharacterMotion.PointInform.transform.GetChild(0));
			CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().texture = Inventory._CompleteMove;
			CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 9);
			CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 9);
			CharacterMotion.NameChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/NameChild"));
			CharacterMotion.NameChild.transform.SetParent(CharacterMotion.PanelInfChild.transform.Find("RawImage").transform);
			CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().texture = (Texture2D)Resources.Load("Sprites/IconGUI/CompleteMoveWhite");
			CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().color = new Color(0.85f, 0f, 0f, 0.9f);
			CharacterMotion.NameChild.GetComponent<Text>().color = new Color(0.85f, 0f, 0f, 0.9f);
			CharacterMotion.NameChild.GetComponent<Text>().text = "Очки хода закончились. Завершите ход.";
			CharacterMotion.NameChild.transform.localPosition = new Vector2(Screen.height / 5, 0f);
			CharacterMotion.NameChild.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 5);
			CharacterMotion.NameChild.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 12);
		}
	}

	public static void AAAAAAAAAAAAAAci()
	{
		if (CharacterMotion._PointsMove > 0 && CharacterMotion._curCharacter != Inventory._currentCharacterNumber && Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.ID == Data.CharacterD[Inventory._currentCharacterNumber].CurGexChar.ID)
		{
			CharacterMotion.PanelInfChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/PointInfChild"));
			CharacterMotion.PanelInfChild.transform.SetParent(CharacterMotion.ActPointAndChar.transform.GetChild(0).transform);
			if (Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 9 && Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 10)
			{
				CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().texture = Inventory._FireTurI;
			}
			else
			{
				CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().texture = (Texture2D)Resources.Load("Sprites/Weapon/knife");
			}
			CharacterMotion.PanelInfChild.GetComponentInChildren<GridLayoutGroup>().cellSize = new Vector2(Inventory._posY9, Inventory._posY9);
			CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 9);
			CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 9);
			CharacterMotion.NameChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/NameChild"));
			CharacterMotion.NameChild.transform.SetParent(CharacterMotion.PanelInfChild.transform.Find("RawImage").transform);
			CharacterMotion.NameChild.GetComponent<Text>().text = "Использовать нож";
			if (Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == Data.CharacterD[Inventory._CurrentCharUnit[Inventory._curNumb]].TypeChInt)
			{
				CharacterMotion.NameChild.GetComponent<Text>().text = "Дружественный персонаж, атаковать нельзя";
				CharacterMotion.NameChild.GetComponent<Text>().color = new Color(0.85f, 0f, 0f, 0.9f);
			}
			CharacterMotion.NameChild.transform.localPosition = new Vector2(Screen.height / 5, 0f);
			CharacterMotion.NameChild.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 6);
			CharacterMotion.ActPointAndChar.GetComponentInChildren<GridLayoutGroup>().cellSize = new Vector2(Screen.height / 3, Screen.height / 10);
			CharacterMotion.ActPointAndChar.transform.GetChild(0).GetComponent<GridLayoutGroup>().padding.left = Inventory._posX32;
		}
	}

	public static void AAAAAAAAAAAAAAAAAAdd()
	{
		if (CharacterMotion._DistansMove <= 1 && CharacterMotion._PointsMove > 0)
		{
			for (int i = 0; i < 20; i++)
			{
				if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].NameSubject == "Ф1")
				{
					CharacterMotion.PanelInfChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/PointInfChild"));
					CharacterMotion.PanelInfChild.transform.SetParent(CharacterMotion.ActPointAndChar.transform.GetChild(0).transform);
					CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().texture = Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].TextureSubject;
					CharacterMotion.PanelInfChild.GetComponentInChildren<GridLayoutGroup>().cellSize = new Vector2(Inventory._posY9, Inventory._posY9);
					CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 9);
					CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 9);
					CharacterMotion.NameChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/NameChild"));
					CharacterMotion.NameChild.transform.SetParent(CharacterMotion.PanelInfChild.transform.Find("RawImage").transform);
					CharacterMotion.NameChild.GetComponent<Text>().text = "Использовать Ф1";
					CharacterMotion.NameChild.transform.localPosition = new Vector2(Screen.height / 5, 0f);
					CharacterMotion.NameChild.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 6);
					CharacterMotion.ActPointAndChar.GetComponentInChildren<GridLayoutGroup>().cellSize = new Vector2(Screen.height / 3, Screen.height / 10);
					CharacterMotion.ActPointAndChar.transform.GetChild(0).GetComponent<GridLayoutGroup>().padding.left = Inventory._posX32;
					break;
				}
			}
		}
		if (CharacterMotion._DistansMove <= 2 && CharacterMotion._PointsMove > 0)
		{
			for (int j = 0; j < 20; j++)
			{
				if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[j].NameSubject == "РГД-5")
				{
					CharacterMotion.PanelInfChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/PointInfChild"));
					CharacterMotion.PanelInfChild.transform.SetParent(CharacterMotion.ActPointAndChar.transform.GetChild(0).transform);
					CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().texture = Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[j].TextureSubject;
					CharacterMotion.PanelInfChild.GetComponentInChildren<GridLayoutGroup>().cellSize = new Vector2(Inventory._posY9, Inventory._posY9);
					CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 9);
					CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 9);
					CharacterMotion.NameChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/NameChild"));
					CharacterMotion.NameChild.transform.SetParent(CharacterMotion.PanelInfChild.transform.Find("RawImage").transform);
					CharacterMotion.NameChild.GetComponent<Text>().text = "Использовать РГД-5";
					CharacterMotion.NameChild.transform.localPosition = new Vector2(Screen.height / 5, 0f);
					CharacterMotion.NameChild.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 6);
					CharacterMotion.ActPointAndChar.GetComponentInChildren<GridLayoutGroup>().cellSize = new Vector2(Screen.height / 3, Screen.height / 10);
					CharacterMotion.ActPointAndChar.transform.GetChild(0).GetComponent<GridLayoutGroup>().padding.left = Inventory._posX32;
					break;
				}
			}
		}
		if (!Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.GrenadeInstallation || CharacterMotion._DistansMove >= 5 || CharacterMotion._PointsMove <= 0)
		{
			return;
		}
		for (int k = 0; k < 20; k++)
		{
			if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[k].TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Grenade && Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[k].TypeGren == Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.TypeGren)
			{
				CharacterMotion.PanelInfChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/PointInfChild"));
				CharacterMotion.PanelInfChild.transform.SetParent(CharacterMotion.ActPointAndChar.transform.GetChild(0).transform);
				CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().texture = Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[k].TextureSubject;
				CharacterMotion.PanelInfChild.GetComponentInChildren<GridLayoutGroup>().cellSize = new Vector2(Inventory._posY9, Inventory._posY9);
				CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 9);
				CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 9);
				CharacterMotion.NameChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/NameChild"));
				CharacterMotion.NameChild.transform.SetParent(CharacterMotion.PanelInfChild.transform.Find("RawImage").transform);
				CharacterMotion.NameChild.GetComponent<Text>().text = "Использовать гранатомет";
				CharacterMotion.NameChild.transform.localPosition = new Vector2(Screen.height / 5, 0f);
				CharacterMotion.NameChild.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 6);
				CharacterMotion.ActPointAndChar.GetComponentInChildren<GridLayoutGroup>().cellSize = new Vector2(Screen.height / 3, Screen.height / 10);
				CharacterMotion.ActPointAndChar.transform.GetChild(0).GetComponent<GridLayoutGroup>().padding.left = Inventory._posX32;
				break;
			}
		}
	}

	public static void AAAAAAAAAAAAAAcj()
	{
		if (CharacterMotion._NextGex.Count > 0)
		{
			foreach (ConstructorGex item in CharacterMotion._NextGex)
			{
				GameObject gameObject = GameObject.Find(item.NameGex);
				if (gameObject.transform.childCount > 0)
				{
					Object.Destroy(gameObject.transform.GetChild(0).gameObject);
				}
			}
		}
		CharacterMotion._DistansMove = 0;
		if (CharacterMotion._NextGex.Count > 0)
		{
			for (int i = 0; i < CharacterMotion._NextGex.Count; i++)
			{
				CharacterMotion._NextGex[i].GexGO.GetComponent<SpriteRenderer>().color = new Color(0.45f, 0.45f, 0.25f, 0f);
			}
			CharacterMotion._NextGex.Clear();
		}
		for (int j = 0; j < Data.Points.Count; j++)
		{
			if (Data.Points[j].curGexPoint.GexGO.transform.position == CharacterMotion.taskIcon.transform.position)
			{
				CharacterMotion._NextGex.Add(Data.Points[j].curGexPoint);
				CharacterMotion._NextGex.Add(Data.Points[j].curGexPoint);
				CharacterMotion._CurGex = Data.Points[j].curGexPoint;
			}
		}
		if (CharacterMotion._CurGex.NameGex != Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.NameGex)
		{
			while (true)
			{
				GameObject gexGO = Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO;
				if (CharacterMotion._CurGex._YGex % 2 == 0)
				{
					for (int k = 0; k < Gexa.GexLib.Count; k++)
					{
						if (Gexa.GexLib[k].NameGex == CharacterMotion._CurGex._XGex + "x" + (CharacterMotion._CurGex._YGex + 1) + "y")
						{
							CharacterMotion.GexNears[0] = Gexa.GexLib[k];
							if (Vector3.Distance(CharacterMotion.GexNears[0].GexGO.transform.position, gexGO.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, gexGO.transform.position))
							{
								CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[0];
								break;
							}
						}
					}
					for (int l = 0; l < Gexa.GexLib.Count; l++)
					{
						if (Gexa.GexLib[l].NameGex == CharacterMotion._CurGex._XGex - 1 + "x" + CharacterMotion._CurGex._YGex + "y")
						{
							CharacterMotion.GexNears[1] = Gexa.GexLib[l];
							if (Vector3.Distance(CharacterMotion.GexNears[1].GexGO.transform.position, gexGO.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, gexGO.transform.position))
							{
								CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[1];
								break;
							}
						}
					}
					for (int m = 0; m < Gexa.GexLib.Count; m++)
					{
						if (Gexa.GexLib[m].NameGex == CharacterMotion._CurGex._XGex + "x" + (CharacterMotion._CurGex._YGex - 1) + "y")
						{
							CharacterMotion.GexNears[2] = Gexa.GexLib[m];
							if (Vector3.Distance(CharacterMotion.GexNears[2].GexGO.transform.position, gexGO.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, gexGO.transform.position))
							{
								CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[2];
								break;
							}
						}
					}
					for (int n = 0; n < Gexa.GexLib.Count; n++)
					{
						if (Gexa.GexLib[n].NameGex == CharacterMotion._CurGex._XGex + 1 + "x" + (CharacterMotion._CurGex._YGex + 1) + "y")
						{
							CharacterMotion.GexNears[3] = Gexa.GexLib[n];
							if (Vector3.Distance(CharacterMotion.GexNears[3].GexGO.transform.position, gexGO.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, gexGO.transform.position))
							{
								CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[3];
								break;
							}
						}
					}
					for (int num = 0; num < Gexa.GexLib.Count; num++)
					{
						if (Gexa.GexLib[num].NameGex == CharacterMotion._CurGex._XGex + 1 + "x" + CharacterMotion._CurGex._YGex + "y")
						{
							CharacterMotion.GexNears[4] = Gexa.GexLib[num];
							if (Vector3.Distance(CharacterMotion.GexNears[4].GexGO.transform.position, gexGO.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, gexGO.transform.position))
							{
								CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[4];
								break;
							}
						}
					}
					for (int num2 = 0; num2 < Gexa.GexLib.Count; num2++)
					{
						if (Gexa.GexLib[num2].NameGex == CharacterMotion._CurGex._XGex + 1 + "x" + (CharacterMotion._CurGex._YGex - 1) + "y")
						{
							CharacterMotion.GexNears[5] = Gexa.GexLib[num2];
							if (Vector3.Distance(CharacterMotion.GexNears[5].GexGO.transform.position, gexGO.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, gexGO.transform.position))
							{
								CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[5];
								break;
							}
						}
					}
				}
				else
				{
					for (int num3 = 0; num3 < Gexa.GexLib.Count; num3++)
					{
						if (Gexa.GexLib[num3].NameGex == CharacterMotion._CurGex._XGex - 1 + "x" + (CharacterMotion._CurGex._YGex + 1) + "y")
						{
							CharacterMotion.GexNears[0] = Gexa.GexLib[num3];
							CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[0];
							break;
						}
					}
					for (int num4 = 0; num4 < Gexa.GexLib.Count; num4++)
					{
						if (Gexa.GexLib[num4].NameGex == CharacterMotion._CurGex._XGex - 1 + "x" + CharacterMotion._CurGex._YGex + "y")
						{
							CharacterMotion.GexNears[1] = Gexa.GexLib[num4];
							if (Vector3.Distance(CharacterMotion.GexNears[1].GexGO.transform.position, gexGO.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, gexGO.transform.position))
							{
								CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[1];
								break;
							}
						}
					}
					for (int num5 = 0; num5 < Gexa.GexLib.Count; num5++)
					{
						if (Gexa.GexLib[num5].NameGex == CharacterMotion._CurGex._XGex - 1 + "x" + (CharacterMotion._CurGex._YGex - 1) + "y")
						{
							CharacterMotion.GexNears[2] = Gexa.GexLib[num5];
							if (Vector3.Distance(CharacterMotion.GexNears[2].GexGO.transform.position, gexGO.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, gexGO.transform.position))
							{
								CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[2];
								break;
							}
						}
					}
					for (int num6 = 0; num6 < Gexa.GexLib.Count; num6++)
					{
						if (Gexa.GexLib[num6].NameGex == CharacterMotion._CurGex._XGex + "x" + (CharacterMotion._CurGex._YGex + 1) + "y")
						{
							CharacterMotion.GexNears[3] = Gexa.GexLib[num6];
							if (Vector3.Distance(CharacterMotion.GexNears[3].GexGO.transform.position, gexGO.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, gexGO.transform.position))
							{
								CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[3];
								break;
							}
						}
					}
					for (int num7 = 0; num7 < Gexa.GexLib.Count; num7++)
					{
						if (Gexa.GexLib[num7].NameGex == CharacterMotion._CurGex._XGex + 1 + "x" + CharacterMotion._CurGex._YGex + "y")
						{
							CharacterMotion.GexNears[4] = Gexa.GexLib[num7];
							if (Vector3.Distance(CharacterMotion.GexNears[4].GexGO.transform.position, gexGO.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, gexGO.transform.position))
							{
								CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[4];
								break;
							}
						}
					}
					for (int num8 = 0; num8 < Gexa.GexLib.Count; num8++)
					{
						if (Gexa.GexLib[num8].NameGex == CharacterMotion._CurGex._XGex + "x" + (CharacterMotion._CurGex._YGex - 1) + "y")
						{
							CharacterMotion.GexNears[5] = Gexa.GexLib[num8];
							if (Vector3.Distance(CharacterMotion.GexNears[5].GexGO.transform.position, gexGO.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, gexGO.transform.position))
							{
								CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[5];
								break;
							}
						}
					}
				}
				if (!(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].NameGex != Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.NameGex))
				{
					break;
				}
				CharacterMotion._CurGex = CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1];
				CharacterMotion._NextGex.Add(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1]);
				CharacterMotion._DistansMove++;
			}
		}
		for (int num9 = 0; num9 < CharacterMotion._NextGex.Count; num9++)
		{
			CharacterMotion._NextGex[num9].GexGO.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 1f, 0.8f);
		}
		for (int num10 = 0; num10 < CharacterMotion._NextGex.Count - 1 - CharacterMotion._PointsMove; num10++)
		{
			CharacterMotion._NextGex[num10].GexGO.GetComponent<SpriteRenderer>().color = new Color(0.65f, 0.65f, 0.5f, 0.8f);
		}
		if (CharacterMotion._DistansMove < CharacterMotion._PointsMove)
		{
			Inventory._StateCharacter = true;
		}
		else
		{
			Inventory._StateCharacter = false;
		}
		CharacterMotion._Turget.transform.position = Gexa.GexLib[Data.TaskAll[Inventory._TaskNum].NumberInLib].GexGO.transform.position;
		CharacterMotion._TurgetGexName = Gexa.GexLib[Data.TaskAll[Inventory._TaskNum].NumberInLib].GexGO.name;
		CharacterMotion._TurGex = Gexa.GexLib[Data.TaskAll[Inventory._TaskNum].NumberInLib];
		Inventory._CurrentCharUnit.Clear();
		Inventory._CurrentPoint.Clear();
		Object.Destroy(CharacterMotion.PointInform);
		if (CharacterMotion._PointsMove > 0)
		{
			Inventory._StateCharacter = true;
		}
		else
		{
			Inventory._StateCharacter = false;
		}
		Inventory._StateCharacter = false;
	}

	public static void AAAAAAAAAAAAAAAAAce()
	{
		if (MapNameForButton == "Kordon")
		{
			MapNameForButton = "Кордон";
		}
		if (MapNameForButton == "Dump")
		{
			MapNameForButton = "Свалка";
		}
		if (MapNameForButton == "Agroprom")
		{
			MapNameForButton = "Агропром";
		}
		if (MapNameForButton == "DarkValley")
		{
			MapNameForButton = "Темная долина";
		}
		if (MapNameForButton == "Bar")
		{
			MapNameForButton = "Бар";
		}
		if (MapNameForButton == "WildTerritory")
		{
			MapNameForButton = "Дикая территория";
		}
		if (MapNameForButton == "DeadCity")
		{
			MapNameForButton = "Мертвый город";
		}
		if (MapNameForButton == "Military")
		{
			MapNameForButton = "Военные склады";
		}
		if (MapNameForButton == "Amber")
		{
			MapNameForButton = "Янтарь";
		}
		if (MapNameForButton == "Radar")
		{
			MapNameForButton = "Радар";
		}
		if (MapNameForButton == "Marsh")
		{
			MapNameForButton = "Болото";
		}
		if (MapNameForButton == "RedForest")
		{
			MapNameForButton = "Рыжий лес";
		}
		if (MapNameForButton == "Backwater")
		{
			MapNameForButton = "Затон";
		}
	}
}
