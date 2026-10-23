using UnityEngine;
using UnityEngine.UI;

public class NewEquipment : MonoBehaviour
{
	public static GameObject NewEquipmentPanel;

	public static GameObject NewCharPanel;

	public static GameObject NewCharSuit;

	public static GameObject NewCharWeapon;

	public static GameObject NewCharArtefact;

	public static GameObject NewCharDetector;

	public static GameObject NewBackpack;

	public static GameObject NewBackpackPanel;

	private void Start()
	{
		GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width / 3 * 2);
		GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height);
		GetComponent<RectTransform>().localPosition = new Vector3(Screen.width / 6, 0f, 0f);
		GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width / 3);
		GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height);
		GetComponent<RectTransform>().transform.GetChild(0).localPosition = new Vector3(Screen.width / 6, 0f, 0f);
		GetComponent<RectTransform>().transform.GetChild(1).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width / 3);
		GetComponent<RectTransform>().transform.GetChild(1).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height);
		GetComponent<RectTransform>().transform.GetChild(1).localPosition = new Vector3(-Screen.width / 6, 0f, 0f);
		GameObject gameObject = GameObject.Find("FieldBackpack");
		gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width / 3 - Inventory._posY16);
		gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height - Inventory._posY4);
		gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width / 3 - Inventory._posY16);
		gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, (float)Screen.width * 1.4f);
		gameObject.GetComponent<RectTransform>().localPosition = new Vector3(0f, -Inventory._posY7, 0f);
		gameObject.transform.GetChild(0).transform.position = new Vector3(gameObject.transform.GetChild(0).transform.position.x, -40000f);
		for (int i = 0; i < 20; i++)
		{
			gameObject = GameObject.Find("EquipmentBackpack" + i);
			gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RawImage>().texture = Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].TextureSubject;
			gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
			gameObject.GetComponent<RectTransform>().transform.GetComponentInChildren<Text>().text = Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].Stack + string.Empty;
			if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].Stack <= 1)
			{
				gameObject.GetComponent<RectTransform>().transform.GetComponentInChildren<Text>().text = string.Empty;
			}
			gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RectTransform>().transform.GetChild(1).transform.localPosition = new Vector3(Screen.height / 24, -Screen.height / 18);
			gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 13);
			gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RectTransform>().transform.GetChild(1).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 26);
			if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Weapon)
			{
				gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RectTransform>().transform.GetChild(1).transform.localPosition = new Vector3(Screen.height / 16, -Screen.height / 30);
			}
			gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RectTransform>().transform.GetChild(1).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 26);
			gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RectTransform>().transform.GetChild(1).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 26);
			if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].SingModification)
			{
				gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RectTransform>().transform.GetChild(1).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/Upgrade/UG");
			}
			else
			{
				gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RectTransform>().transform.GetChild(1).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/OtherSprite/Slot128");
			}
			gameObject.GetComponent<RectTransform>().transform.GetComponentInChildren<Text>().fontSize = Screen.height / 28;
			gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RectTransform>().transform.GetChild(0).localPosition = new Vector3(Inventory._posY10, Inventory._posY32);
		}
		gameObject = GameObject.Find("NameAndImageGG");
		gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width / 3 - Inventory._posY16);
		gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 4);
		gameObject.GetComponent<RectTransform>().localPosition = new Vector3(0f, Screen.height / 3, 0f);
		gameObject.GetComponent<RectTransform>().GetComponent<GridLayoutGroup>().cellSize = new Vector2(Screen.width / 8, Screen.width / 8);
		gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<GridLayoutGroup>().spacing = new Vector2(Screen.width / 64, 0f);
		gameObject.GetComponent<RectTransform>().transform.GetChild(1).GetComponent<RawImage>().texture = Data.CharacterD[CharacterMotion._curCharacter].SuitChar.IconCharacter;
		gameObject = GameObject.Find("InfOfGG");
		gameObject.GetComponent<GridLayoutGroup>().cellSize = new Vector2(Screen.width / 8, Screen.width / 16);
		gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<Text>().fontSize = Screen.height / 26;
		if (CharacterMotion._curCharacter != 0)
		{
			gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<Text>().text = Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name;
		}
		else
		{
			gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<Text>().text = PlayerPrefs.GetString("HeroName");
		}
		gameObject.GetComponent<RectTransform>().transform.GetChild(1).GetComponent<Text>().fontSize = Screen.height / 26;
		gameObject.GetComponent<RectTransform>().transform.GetChild(1).GetComponent<Text>().text = Data.CharacterD[CharacterMotion._curCharacter].Cash + " Ru";
		Inventory.AAAAAAAAAAAAAAAAAAAAch();
		Inventory.AAAAAAAAAAAAAAAAAbw();
		gameObject = GameObject.Find("Inf");
		gameObject.transform.position = new Vector3(Screen.width / 2, Screen.height - Screen.width / 30);
		gameObject.GetComponent<GridLayoutGroup>().cellSize = new Vector2(Screen.width / 6 - Inventory._posY64, Screen.width / 12);
		gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<Text>().fontSize = Screen.height / 30;
		gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<Text>().text = "max ходов: " + Inventory._CalcWeigh;
		gameObject.GetComponent<RectTransform>().transform.GetChild(1).GetComponent<Text>().fontSize = Screen.height / 30;
		gameObject.GetComponent<RectTransform>().transform.GetChild(1).GetComponent<Text>().text = "вес экипировки: " + (int)Inventory._CurWeigh + " кг";
		gameObject = GameObject.Find("InfState");
		gameObject.transform.position = new Vector3(Screen.width / 2, Screen.height - Screen.width / 11);
		gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Inventory._posX3 - Inventory._posY16);
		gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Inventory._posY7);
		gameObject.GetComponent<GridLayoutGroup>().cellSize = new Vector2(Inventory._posY10, Inventory._posY10);
		gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<Text>().fontSize = Screen.height / 30;
		gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<Text>().text = "HP : " + (int)Data.CharacterD[CharacterMotion._curCharacter].CurHealth;
		gameObject.GetComponent<RectTransform>().transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().fontSize = Screen.height / 30;
		gameObject.GetComponent<RectTransform>().transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().fontSize = Screen.height / 30;
		gameObject.GetComponent<RectTransform>().transform.GetChild(1).transform.GetChild(0).transform.localPosition = new Vector3(Inventory._posY32, Inventory._posY32);
		gameObject.GetComponent<RectTransform>().transform.GetChild(2).transform.GetChild(0).transform.localPosition = new Vector3(Inventory._posY32, Inventory._posY32);
		if (Data.CharacterD[CharacterMotion._curCharacter].Bleeding > 0f)
		{
			gameObject.GetComponent<RectTransform>().transform.GetChild(1).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/IconGUI/BleedingRed");
			gameObject.GetComponent<RectTransform>().transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = string.Empty + (int)Data.CharacterD[CharacterMotion._curCharacter].Bleeding;
		}
		else
		{
			gameObject.GetComponent<RectTransform>().transform.GetChild(1).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/IconGUI/Bleeding");
			gameObject.GetComponent<RectTransform>().transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = string.Empty;
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].DiseaseXRay > 0)
		{
			gameObject.GetComponent<RectTransform>().transform.GetChild(2).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/IconGUI/xRayRed");
			gameObject.GetComponent<RectTransform>().transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = string.Empty + Data.CharacterD[CharacterMotion._curCharacter].DiseaseXRay;
		}
		else
		{
			gameObject.GetComponent<RectTransform>().transform.GetChild(2).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/IconGUI/xRayNew");
			gameObject.GetComponent<RectTransform>().transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = string.Empty;
		}
		gameObject = (NewCharSuit = GameObject.Find("SuitGG"));
		gameObject.GetComponent<NewChoiseSubject>().slotID = -1;
		gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Inventory._posY4);
		gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Inventory._posY3);
		gameObject.transform.localPosition = new Vector3(-Screen.height / 7, -Screen.height / 12, 0f);
		gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Inventory._posY4);
		gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Inventory._posY4);
		gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RectTransform>().localPosition = new Vector3(0f, 0f, 0f);
		gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RawImage>().texture = Data.CharacterD[CharacterMotion._curCharacter].SuitChar.TextureSubject;
		gameObject.GetComponent<RectTransform>().transform.GetChild(1).transform.position = new Vector3(Screen.width / 3 + Inventory._posY16, Screen.height / 3 * 2 - Inventory._posY8);
		gameObject.GetComponent<RectTransform>().transform.GetChild(1).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Inventory._posY12 / 2);
		gameObject.GetComponent<RectTransform>().transform.GetChild(1).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Inventory._posY12 / 2);
		if (!Data.CharacterD[CharacterMotion._curCharacter].SuitChar.SingModification)
		{
			gameObject.GetComponent<RectTransform>().transform.GetChild(1).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/OtherSprite/Slot128");
		}
		else
		{
			gameObject.GetComponent<RectTransform>().transform.GetChild(1).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/Upgrade/UG");
		}
		gameObject = (NewCharWeapon = GameObject.Find("WeaponGG"));
		gameObject.GetComponent<NewChoiseSubject>().slotID = -2;
		gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Inventory._posY4);
		gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Inventory._posY2);
		gameObject.transform.localPosition = new Vector3(Screen.height / 7, 0f, 0f);
		gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Inventory._posY3);
		gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, (float)Inventory._posY3 / 2.66f);
		gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RectTransform>().localPosition = new Vector3(0f, 0f, 0f);
		gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RawImage>().texture = Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.TextureSubject;
		gameObject.GetComponent<RectTransform>().transform.GetChild(1).transform.position = new Vector3(Screen.width / 2 + Inventory._posY20, Screen.height / 4 * 3 - Inventory._posY20);
		gameObject.GetComponent<RectTransform>().transform.GetChild(1).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Inventory._posY12 / 2);
		gameObject.GetComponent<RectTransform>().transform.GetChild(1).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Inventory._posY12 / 2);
		if (!Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.SingModification)
		{
			gameObject.GetComponent<RectTransform>().transform.GetChild(1).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/OtherSprite/Slot128");
		}
		else
		{
			gameObject.GetComponent<RectTransform>().transform.GetChild(1).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/Upgrade/UG");
		}
		gameObject = (NewCharDetector = GameObject.Find("DetectorGG"));
		gameObject.GetComponent<NewChoiseSubject>().slotID = -3;
		gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Inventory._posY4);
		gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Inventory._posY7);
		gameObject.transform.localPosition = new Vector3(-Screen.height / 7, Screen.width / 10, 0f);
		gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Inventory._posY12);
		gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Inventory._posY12);
		gameObject = (NewCharArtefact = GameObject.Find("ArtPanelGG"));
		gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width / 3);
		gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Inventory._posY6);
		gameObject.transform.localPosition = new Vector3(0f, -Screen.height / 2 + Inventory._posY7, 0f);
		gameObject.GetComponent<GridLayoutGroup>().cellSize = new Vector2(Inventory._posY12, Inventory._posY12);
		if (Data.CharacterD[CharacterMotion._curCharacter].SuitChar.ArtContainer == 1)
		{
			gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RectTransform>().GetComponent<RawImage>()
				.texture = (Texture2D)Resources.Load("Sprites/OtherSprite/ArtSlot");
		}
		gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Inventory._posY16);
		gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Inventory._posY16);
		gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RectTransform>().GetComponent<NewChoiseSubject>()
			.slotID = -4;
		if (Data.CharacterD[CharacterMotion._curCharacter].SuitChar.ArtContainer == 2)
		{
			gameObject.GetComponent<RectTransform>().transform.GetChild(1).GetComponent<RectTransform>().GetComponent<RawImage>()
				.texture = (Texture2D)Resources.Load("Sprites/OtherSprite/ArtSlot");
		}
		gameObject.GetComponent<RectTransform>().transform.GetChild(1).GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Inventory._posY16);
		gameObject.GetComponent<RectTransform>().transform.GetChild(1).GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Inventory._posY16);
		gameObject.GetComponent<RectTransform>().transform.GetChild(1).GetComponent<RectTransform>().GetComponent<NewChoiseSubject>()
			.slotID = -5;
		if (Data.CharacterD[CharacterMotion._curCharacter].SuitChar.ArtContainer == 3)
		{
			gameObject.GetComponent<RectTransform>().transform.GetChild(2).GetComponent<RectTransform>().GetComponent<RawImage>()
				.texture = (Texture2D)Resources.Load("Sprites/OtherSprite/ArtSlot");
		}
		gameObject.GetComponent<RectTransform>().transform.GetChild(2).GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Inventory._posY16);
		gameObject.GetComponent<RectTransform>().transform.GetChild(2).GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Inventory._posY16);
		gameObject.GetComponent<RectTransform>().transform.GetChild(2).GetComponent<RectTransform>().GetComponent<NewChoiseSubject>()
			.slotID = -6;
		if (Data.CharacterD[CharacterMotion._curCharacter].SuitChar.ArtContainer == 4)
		{
			gameObject.GetComponent<RectTransform>().transform.GetChild(3).GetComponent<RectTransform>().GetComponent<RawImage>()
				.texture = (Texture2D)Resources.Load("Sprites/OtherSprite/ArtSlot");
		}
		gameObject.GetComponent<RectTransform>().transform.GetChild(3).GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Inventory._posY16);
		gameObject.GetComponent<RectTransform>().transform.GetChild(3).GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Inventory._posY16);
		gameObject.GetComponent<RectTransform>().transform.GetChild(3).GetComponent<RectTransform>().GetComponent<NewChoiseSubject>()
			.slotID = -7;
		gameObject = GameObject.Find("QuitGG");
		gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width / 4);
		gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Inventory._posY12);
		gameObject.transform.localPosition = new Vector3(0f, -Screen.height / 2 + Inventory._posY12, 0f);
		gameObject.transform.GetComponentInChildren<Text>().fontSize = Screen.height / 26;
	}
}
