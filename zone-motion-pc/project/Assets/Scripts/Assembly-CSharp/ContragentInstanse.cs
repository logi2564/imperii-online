using UnityEngine;
using UnityEngine.UI;

public class ContragentInstanse : MonoBehaviour
{
	private void Start()
	{
		CharacterMotion.CApanel = true;
		GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width / 3);
		GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height);
		GetComponent<RectTransform>().localPosition = new Vector3((float)(-Inventory._posX3) * 1.5f, 0f, 0f);
		GetComponent<RectTransform>().transform.GetChild(1).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width / 3 - Inventory._posY16);
		GetComponent<RectTransform>().transform.GetChild(1).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 4);
		GetComponent<RectTransform>().transform.GetChild(1).localPosition = new Vector3(0f, Screen.height / 3, 0f);
		GetComponent<RectTransform>().transform.GetChild(1).GetComponent<GridLayoutGroup>().cellSize = new Vector2(Screen.width / 8, Screen.width / 8);
		GetComponent<RectTransform>().transform.GetChild(1).GetComponent<GridLayoutGroup>().spacing = new Vector2(Screen.width / 64, 0f);
		GetComponent<RectTransform>().transform.GetChild(1).transform.GetChild(1).GetComponent<GridLayoutGroup>().cellSize = new Vector2(Screen.width / 8, Screen.width / 16);
		GetComponent<RectTransform>().transform.GetChild(1).transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().fontSize = Screen.height / 26;
		GetComponent<RectTransform>().transform.GetChild(1).transform.GetChild(1).transform.GetChild(1).GetComponent<Text>().fontSize = Screen.height / 26;
		GameObject gameObject = GameObject.Find("CAFieldBackpack");
		gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width / 3 - Inventory._posY16);
		gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height - Inventory._posY4);
		gameObject.GetComponent<RectTransform>().localPosition = new Vector3(0f, -Inventory._posY7, 0f);
		gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width / 3 - Inventory._posY16);
		gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, (float)Screen.width * 1.6f);
		gameObject.transform.GetChild(0).transform.position = new Vector3(gameObject.transform.GetChild(0).transform.position.x, -40000f);
		for (int i = 0; i < 20; i++)
		{
			gameObject = GameObject.Find("CAEquipmentBackpack" + i);
			gameObject.GetComponent<RectTransform>().transform.GetComponentInChildren<Text>().fontSize = Screen.height / 28;
			gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RectTransform>().transform.GetChild(0).localPosition = new Vector3(Inventory._posY10, Inventory._posY32);
		}
	}

	public static void AAAAAAAAAAAAAAAAAbo()
	{
		for (int num = 19; num >= 0; num--)
		{
			if (Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[num].NameSubject == "None")
			{
				for (int num2 = 19; num2 >= 0; num2--)
				{
					if (Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[num2].NameSubject != "None")
					{
						Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[num] = Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[num2];
						Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[num2] = new AAAAAAAAAAAAAAAAAAbi();
						break;
					}
				}
			}
		}
		CharacterMotion.NPSPanel = true;
		GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/NewEquipmentPanel"));
		gameObject.name = "NewEquipmentPanel";
		gameObject.transform.SetParent(GameObject.Find("Canvas").transform);
		SubjectAct.AAAAAAAAAAAAAAAAAAAbo();
		gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/ContragentPanel"));
		gameObject.name = "ContragentPanel";
		gameObject.transform.SetParent(GameObject.Find("NewEquipmentPanel").transform);
		SubjectAct.AAAAAAAAAAAAAAAAAAAAbz();
	}

	public static void AAAAAAAAAAAAAAAbj()
	{
		CharacterMotion.DealerPanel = true;
		GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/NewEquipmentPanel"));
		gameObject.name = "NewEquipmentPanel";
		gameObject.transform.SetParent(GameObject.Find("Canvas").transform);
		SubjectAct.AAAAAAAAAAAAAAAAAAAbo();
		gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/ContragentPanel"));
		gameObject.name = "ContragentPanel";
		gameObject.transform.SetParent(GameObject.Find("NewEquipmentPanel").transform);
		gameObject.transform.GetChild(1).transform.GetChild(0).GetComponent<RawImage>().texture = Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].DealerInt].ImageChar;
		gameObject = GameObject.Find("InfOfCA");
		gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<Text>().text = Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].DealerInt].NameDealer;
		gameObject.GetComponent<RectTransform>().transform.GetChild(1).GetComponent<Text>().text = Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].DealerInt].NameGroup;
		gameObject = GameObject.Find("CAEquipmentBackpack19");
		for (int i = 20; i < 25; i++)
		{
			GameObject gameObject2 = Object.Instantiate(gameObject);
			gameObject2.name = "CAEquipmentBackpack" + i;
			gameObject2.transform.SetParent(gameObject.transform.parent);
		}
		SubjectAct.AAAAAAAAAAAAAAAAAAAAbz();
	}

	public static void AAAAAAAAAAAAAAAAAAAAby()
	{
		CharacterMotion.CachePanel = true;
		GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/NewEquipmentPanel"));
		gameObject.name = "NewEquipmentPanel";
		gameObject.transform.SetParent(GameObject.Find("Canvas").transform);
		SubjectAct.AAAAAAAAAAAAAAAAAAAbo();
		gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/ContragentPanel"));
		gameObject.name = "ContragentPanel";
		gameObject.transform.SetParent(GameObject.Find("NewEquipmentPanel").transform);
		gameObject.transform.GetChild(1).transform.GetChild(0).GetComponent<RawImage>().texture = (Texture)Resources.Load("Sprites/OtherSprite/unusedSlot");
		gameObject = GameObject.Find("InfOfCA");
		gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<Text>().text = Data.Points[Inventory._CurrentPoint[0]].namePoint;
		if (Data.Points[Inventory._CurrentPoint[0]].pointTypes == ConstructorPoints.PointTypes.Anomaly)
		{
			gameObject.GetComponent<RectTransform>().transform.GetChild(1).GetComponent<Text>().text = "Аномалия";
		}
		else
		{
			gameObject.GetComponent<RectTransform>().transform.GetChild(1).GetComponent<Text>().text = "Тайник";
		}
		SubjectAct.AAAAAAAAAAAAAAAAAAAAbz();
	}

	public static void AAAAAAAAAAAAAAbo()
	{
		CharacterMotion.RepairPanel = true;
		GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/NewEquipmentPanel"));
		gameObject.name = "NewEquipmentPanel";
		gameObject.transform.SetParent(GameObject.Find("Canvas").transform);
		SubjectAct.AAAAAAAAAAAAAAAAAAAbo();
		gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/ContragentPanel"));
		gameObject.name = "ContragentPanel";
		gameObject.transform.SetParent(GameObject.Find("NewEquipmentPanel").transform);
		gameObject.transform.GetChild(1).transform.GetChild(0).GetComponent<RawImage>().texture = Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].DealerInt].ImageChar;
		gameObject = GameObject.Find("InfOfCA");
		gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<Text>().text = "Техник";
		gameObject.GetComponent<RectTransform>().transform.GetChild(1).GetComponent<Text>().text = Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].DealerInt].NameGroup;
		Object.Destroy(GameObject.Find("CAFieldBackpack"));
		Inventory.MessagePanel("Учти, оружие и снарягу я чиню на раз, но кривые руки хозяина... Выбирай, что тебе необходимо ремонтировать!");
	}

	public static void AAAAAAAAAAAAAAAbk()
	{
		CharacterMotion.RewardPanel = true;
		GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/NewEquipmentPanel"));
		gameObject.name = "NewEquipmentPanel";
		gameObject.transform.SetParent(GameObject.Find("Canvas").transform);
		SubjectAct.AAAAAAAAAAAAAAAAAAAbo();
		gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/ContragentPanel"));
		gameObject.name = "ContragentPanel";
		gameObject.transform.SetParent(GameObject.Find("NewEquipmentPanel").transform);
		gameObject.transform.GetChild(1).transform.GetChild(0).GetComponent<RawImage>().texture = (Texture)Resources.Load("Sprites/OtherSprite/unusedSlot");
		gameObject = GameObject.Find("InfOfCA");
		gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<Text>().text = string.Empty;
		gameObject.GetComponent<RectTransform>().transform.GetChild(1).GetComponent<Text>().text = "Получен предмет";
		gameObject = GameObject.Find("CAEquipmentBackpack0");
		gameObject.GetComponent<NewChoiseSubjectCA>().slotID = 0;
		gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RawImage>().texture = Inventory._RewardSubject.TextureSubject;
		gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
		gameObject.GetComponent<RectTransform>().transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = string.Empty;
		if (Inventory._RewardSubject.Stack > 1)
		{
			gameObject.GetComponent<RectTransform>().transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = Inventory._RewardSubject.Stack.ToString();
		}
		gameObject.GetComponent<RectTransform>().transform.GetComponentInChildren<Text>().fontSize = Screen.height / 28;
		gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RectTransform>().transform.GetChild(0).localPosition = new Vector3(Inventory._posY10, Inventory._posY32);
		gameObject.transform.GetChild(0).transform.GetChild(1).localPosition = new Vector3(Screen.height / 24, -Screen.height / 18);
		if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Weapon)
		{
			gameObject.transform.GetChild(0).transform.GetChild(1).localPosition = new Vector3(Screen.height / 16, -Screen.height / 30);
		}
		if (Inventory._currentSubject.SingModification)
		{
			gameObject.transform.GetChild(0).transform.GetChild(1).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/Upgrade/UG");
		}
		else
		{
			gameObject.transform.GetChild(0).transform.GetChild(1).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/OtherSprite/Slot128");
		}
		for (int i = 1; i < 20; i++)
		{
			Object.Destroy(GameObject.Find("CAEquipmentBackpack" + i));
		}
		if (Inventory._RewardSubject.NameSubject != "None")
		{
			Inventory.MessagePanel("Получен предмет: " + Inventory._RewardSubject.NameSubject + ".");
		}
		if (Data.TaskAll[Inventory._TaskNum].RewardMoney > 0 && !Inventory.showAdv)
		{
			Inventory.MessagePanel("Получены деньги: " + Data.TaskAll[Inventory._TaskNum].RewardMoney + " Ru.");
		}
		if (Inventory._QuestSubject.NameSubject != "None" && !Inventory.showAdv)
		{
			Inventory.MessagePanel("Передано: " + Inventory._QuestSubject.NameSubject);
		}
	}

	public static void AAAAAAAAAAAAAAbp(AAAAAAAAAAAAAAAAAAk AAAAAAAAAAAAAAAAbn)
	{
		CharacterMotion.RewardPanel = true;
		GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/NewEquipmentPanel"));
		gameObject.name = "NewEquipmentPanel";
		gameObject.transform.SetParent(GameObject.Find("Canvas").transform);
		SubjectAct.AAAAAAAAAAAAAAAAAAAbo();
		gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/ContragentPanel"));
		gameObject.name = "ContragentPanel";
		gameObject.transform.SetParent(GameObject.Find("NewEquipmentPanel").transform);
		gameObject.transform.GetChild(1).transform.GetChild(0).GetComponent<RawImage>().texture = (Texture)Resources.Load("Sprites/OtherSprite/unusedSlot");
		gameObject = GameObject.Find("InfOfCA");
		gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<Text>().text = string.Empty;
		gameObject.GetComponent<RectTransform>().transform.GetChild(1).GetComponent<Text>().text = "Получен предмет";
		gameObject = GameObject.Find("CAEquipmentBackpack0");
		gameObject.GetComponent<NewChoiseSubjectCA>().slotID = 0;
		gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RawImage>().texture = AAAAAAAAAAAAAAAAbn.TextureSubject;
		gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
		gameObject.GetComponent<RectTransform>().transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = string.Empty;
		if (AAAAAAAAAAAAAAAAbn.Stack > 1)
		{
			gameObject.GetComponent<RectTransform>().transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = AAAAAAAAAAAAAAAAbn.Stack.ToString();
		}
		gameObject.GetComponent<RectTransform>().transform.GetComponentInChildren<Text>().fontSize = Screen.height / 28;
		gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RectTransform>().transform.GetChild(0).localPosition = new Vector3(Inventory._posY10, Inventory._posY32);
		gameObject.transform.GetChild(0).transform.GetChild(1).localPosition = new Vector3(Screen.height / 24, -Screen.height / 18);
		if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Weapon)
		{
			gameObject.transform.GetChild(0).transform.GetChild(1).localPosition = new Vector3(Screen.height / 16, -Screen.height / 30);
		}
		if (Inventory._currentSubject.SingModification)
		{
			gameObject.transform.GetChild(0).transform.GetChild(1).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/Upgrade/UG");
		}
		else
		{
			gameObject.transform.GetChild(0).transform.GetChild(1).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/OtherSprite/Slot128");
		}
		for (int i = 1; i < 20; i++)
		{
			Object.Destroy(GameObject.Find("CAEquipmentBackpack" + i));
		}
	}
}
