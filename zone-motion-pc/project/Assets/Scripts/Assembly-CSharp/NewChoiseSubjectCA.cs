using UnityEngine;
using UnityEngine.UI;

public class NewChoiseSubjectCA : MonoBehaviour
{
	public int slotID;

	public void ClickOnButtonSubjectCA()
	{
		if (CharacterMotion.NPSPanel)
		{
			Inventory._currentSubject = Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[slotID];
		}
		if (CharacterMotion.DealerPanel)
		{
			Inventory._currentSubject = Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].DealerInt].Product[AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.CharacterD[CharacterMotion._curCharacter].TypeChInt, Data.Points[Inventory._CurrentPoint[0]].ControlInt], slotID];
		}
		if (CharacterMotion.CachePanel)
		{
			Inventory._currentSubject = Data.Points[Inventory._CurrentPoint[0]].Cache[slotID];
		}
		if (CharacterMotion.RewardPanel)
		{
			Inventory._currentSubject = Inventory._RewardSubject;
		}
		CharacterMotion.SlotEquipment = slotID;
		CharacterMotion.ItemGG = false;
		AAAAAAAAAAAAAAAAAci.AAAAAAAAAAAAAAAAAcj();
		AAAAAAAAAAAAAAAbm();
	}

	public static void AAAAAAAAAAAAAAAbm()
	{
		if (Inventory._currentSubject == null || !(Inventory._currentSubject.NameSubject != "None") || !(Inventory._currentSubject.NameSubject != string.Empty))
		{
			return;
		}
		if (CharacterMotion.NPSPanel)
		{
			Object.Destroy(GameObject.Find("InventoryInformation"));
			GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/InventoryInformation"));
			gameObject.name = "InventoryInformation";
			gameObject.transform.SetParent(GameObject.Find("NewEquipmentPanel").transform);
			gameObject.transform.localPosition = new Vector3(-Inventory._posX3 / 2, 0f);
			gameObject.transform.GetChild(1).GetComponent<RawImage>().texture = CharacterMotion.SlotSubject.TextureSubject;
			if (CharacterMotion.SlotSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Weapon)
			{
				gameObject.transform.GetChild(1).transform.rotation *= Quaternion.Euler(0f, 0f, 90f);
			}
			gameObject.transform.GetChild(1).GetComponent<RawImage>().SetNativeSize();
			gameObject.transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = CharacterMotion.SlotSubject.NameSubject;
			gameObject.transform.GetChild(2).transform.GetChild(1).GetComponent<Text>().text = CharacterMotion.SlotSubject.DescriptionSubject;
			if (CharacterMotion.SlotSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Money)
			{
				gameObject.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>().text = Data.CharacterD[Inventory._currentCharacterNumber].Cash + " Ru";
			}
			else
			{
				gameObject.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>().text = "Вес: " + CharacterMotion.SlotSubject.WeightSubject + " кг. ";
			}
			if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Suit)
			{
				Text component = gameObject.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
				string text = component.text;
				component.text = text + "Защита: max - " + (int)Inventory._currentSubject.Protection + ", текущая - " + (int)(Inventory._currentSubject.Protection / 100f * Inventory._currentSubject.State) + ". Радиохимическая защита: " + Inventory._currentSubject.XRayProtection + ". Исправность: " + (int)Inventory._currentSubject.State + "%. Контейнеры для артефактов: " + Inventory._currentSubject.ArtContainer + ".";
			}
			if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Weapon || Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Grenade)
			{
				Text component2 = gameObject.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
				string text = component2.text;
				component2.text = text + "Повреждение: " + Inventory._currentSubject.Damage + " Дальность: " + Inventory._currentSubject.MinRange + "-" + Inventory._currentSubject.Range + ". Исправность: " + (int)Inventory._currentSubject.State + "%. Кол-во патронов: " + Inventory._currentSubject.CartridgeInMagazineFull + " шт.";
			}
			if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Catridge)
			{
				Text component3 = gameObject.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
				string text = component3.text;
				component3.text = text + "Количество: " + CharacterMotion.SlotSubject.Stack + " шт. Вес: " + (float)CharacterMotion.SlotSubject.Stack * CharacterMotion.SlotSubject.WeightSubject + " кг.";
			}
			if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Artefact || Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.OtherSubject)
			{
				if (Inventory._currentSubject.Protection != 0f)
				{
					Text component4 = gameObject.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
					string text = component4.text;
					component4.text = text + "Защита: " + Inventory._currentSubject.Protection + ". ";
				}
				if (Inventory._currentSubject.Sanitation != 0f)
				{
					Text component5 = gameObject.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
					string text = component5.text;
					component5.text = text + "Лечение: " + Inventory._currentSubject.Sanitation + ". ";
				}
				if (Inventory._currentSubject.Bleeding != 0f)
				{
					Text component6 = gameObject.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
					string text = component6.text;
					component6.text = text + "Кровотечение: " + Inventory._currentSubject.Bleeding + ". ";
				}
				if (Inventory._currentSubject.Force != 0f)
				{
					Text component7 = gameObject.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
					string text = component7.text;
					component7.text = text + "Выносливость: +" + Inventory._currentSubject.Force + " кг. ";
				}
				if (Inventory._currentSubject.Hunger > 0)
				{
					Text component8 = gameObject.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
					string text = component8.text;
					component8.text = text + "Утоление голода: " + Inventory._currentSubject.Hunger + ". ";
				}
				if (Inventory._currentSubject.Thirst > 0)
				{
					Text component9 = gameObject.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
					string text = component9.text;
					component9.text = text + "Утоление жажды: " + Inventory._currentSubject.Thirst + ". ";
				}
				if (Inventory._currentSubject.XRayProtection != 0)
				{
					Text component10 = gameObject.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
					string text = component10.text;
					component10.text = text + "Защита от радиации: " + Inventory._currentSubject.XRayProtection + ". ";
				}
				if (Inventory._currentSubject.XRaySanitation != 0)
				{
					Text component11 = gameObject.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
					string text = component11.text;
					component11.text = text + "Лечение радиации: " + Inventory._currentSubject.XRaySanitation + ". ";
				}
				if (Inventory._currentSubject.ProtectionFromEject != 0)
				{
					Text component12 = gameObject.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
					string text = component12.text;
					component12.text = text + "Защита от выброса: " + Inventory._currentSubject.ProtectionFromEject + ". ";
				}
				if (Inventory._currentSubject.PsiProtection != 0)
				{
					Text component13 = gameObject.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
					string text = component13.text;
					component13.text = text + "ПСИ-Защита: " + Inventory._currentSubject.PsiProtection + ". ";
				}
				if (Inventory._currentSubject.Hunger < 0)
				{
					Text component14 = gameObject.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>();
					string text = component14.text;
					component14.text = text + "Голод: + " + Inventory._currentSubject.Hunger * -1 + ". ";
					gameObject.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>().color = new Color(0.5f, 0.2f, 0.2f, 1f);
				}
				if (Inventory._currentSubject.Thirst < 0)
				{
					Text component15 = gameObject.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>();
					string text = component15.text;
					component15.text = text + "Жажда: +" + Inventory._currentSubject.Thirst * -1 + ". ";
					gameObject.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>().color = new Color(0.5f, 0.2f, 0.2f, 1f);
				}
				if (Inventory._currentSubject.XrayNegatife != 0)
				{
					Text component16 = gameObject.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>();
					string text = component16.text;
					component16.text = text + "Радиация: + " + Inventory._currentSubject.XrayNegatife + ". ";
					gameObject.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>().color = new Color(0.5f, 0.2f, 0.2f, 1f);
				}
			}
			if (Data.CharacterD[Inventory._currentCharacterNumber].Life)
			{
				Inventory._TradeCost = (float)Inventory._currentSubject.CostSubject / SaveLoad.Difficulty * (float)(int)Inventory._currentSubject.State / 100f;
				Inventory._TradeCost *= 4f;
				if (Data.CharacterD[Inventory._currentCharacterNumber].TypeChInt == Data.CharacterD[CharacterMotion._curCharacter].TypeChInt)
				{
					Inventory._TradeCost = Inventory._currentSubject.CostSubject * (int)Inventory._currentSubject.State / 100;
					Inventory._TradeCost /= 3f;
				}
				if (Inventory._currentSubject.WeightUpGrade != 0f)
				{
					Inventory._TradeCost *= 1.1f;
				}
				if (Inventory._currentSubject.UpGrade != 0f)
				{
					Inventory._TradeCost *= 1.1f;
				}
				if (Inventory._currentSubject.SightInstallation)
				{
					Inventory._TradeCost *= 1.1f;
				}
				if (CharacterMotion.SlotSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Catridge)
				{
					Inventory._TradeCost *= CharacterMotion.SlotSubject.Stack;
				}
				GameObject gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/BattonOfDescriptionPanel"));
				gameObject2.transform.SetParent(gameObject.transform.GetChild(3).transform);
				GameObject.Find("ButtonPanel").transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/OtherSprite/Slot128");
				gameObject2.GetComponentInChildren<Text>().text = "Цена: " + (int)Inventory._TradeCost + " Ru";
				gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/BattonOfDescriptionPanel"));
				gameObject2.transform.SetParent(gameObject.transform.GetChild(3).transform);
				gameObject2.GetComponentInChildren<Text>().text = "Купить";
			}
			else
			{
				Inventory._TradeCost = Inventory._currentSubject.CostSubject;
				GameObject gameObject3 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/BattonOfDescriptionPanel"));
				gameObject3.transform.SetParent(gameObject.transform.GetChild(3).transform);
				gameObject3.GetComponentInChildren<Text>().text = "Забрать";
			}
			if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Suit)
			{
				if (Inventory._currentSubject.Sanitation > 0f)
				{
					Text component17 = gameObject.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>();
					string text = component17.text;
					component17.text = text + "Заживление ран: +" + Inventory._currentSubject.Sanitation + ". ";
				}
				if (Inventory._currentSubject.WeightUpGrade != 0f)
				{
					Text component18 = gameObject.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>();
					string text = component18.text;
					component18.text = text + "Вес: " + Inventory._currentSubject.WeightUpGrade + " кг. ";
				}
				if (Inventory._currentSubject.UpGrade != 0f)
				{
					Text component19 = gameObject.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>();
					string text = component19.text;
					component19.text = text + "Защита: + " + Inventory._currentSubject.UpGrade + ". ";
				}
			}
			if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Weapon)
			{
				if (Inventory._currentSubject.WeightUpGrade != 0f)
				{
					Text component20 = gameObject.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>();
					string text = component20.text;
					component20.text = text + "Вес: " + Inventory._currentSubject.WeightUpGrade + " кг. ";
				}
				if (Inventory._currentSubject.UpGrade != 0f)
				{
					Text component21 = gameObject.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>();
					string text = component21.text;
					component21.text = text + "Повреждение: + " + Inventory._currentSubject.UpGrade + ". ";
				}
				if (Inventory._currentSubject.SightInstallation)
				{
					gameObject.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>().text += "Дальность: + 1";
				}
			}
		}
		if (CharacterMotion.DealerPanel)
		{
			Inventory._currentSubject = CharacterMotion.SlotSubject;
			Object.Destroy(GameObject.Find("InventoryInformation"));
			GameObject gameObject4 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/InventoryInformation"));
			gameObject4.name = "InventoryInformation";
			gameObject4.transform.SetParent(GameObject.Find("NewEquipmentPanel").transform);
			gameObject4.transform.localPosition = new Vector3(-Inventory._posX3 / 2, 0f);
			gameObject4.transform.GetChild(1).GetComponent<RawImage>().texture = Inventory._currentSubject.TextureSubject;
			if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Weapon)
			{
				gameObject4.transform.GetChild(1).transform.rotation *= Quaternion.Euler(0f, 0f, 90f);
			}
			gameObject4.transform.GetChild(1).GetComponent<RawImage>().SetNativeSize();
			gameObject4.transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = Inventory._currentSubject.NameSubject;
			gameObject4.transform.GetChild(2).transform.GetChild(1).GetComponent<Text>().text = Inventory._currentSubject.DescriptionSubject;
			if (CharacterMotion.SlotSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Catridge)
			{
				CharacterMotion.SlotSubject.Stack = 30;
				gameObject4.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>().text = "Количество: " + CharacterMotion.SlotSubject.Stack + " шт. Вес: " + Inventory._currentSubject.WeightSubject * (float)CharacterMotion.SlotSubject.Stack + " кг. ";
			}
			else
			{
				gameObject4.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>().text = "Вес: " + Inventory._currentSubject.WeightSubject + " кг. ";
			}
			if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Suit)
			{
				Text component22 = gameObject4.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
				string text = component22.text;
				component22.text = text + "Защита: max - " + (int)Inventory._currentSubject.Protection + ", текущая - " + (int)(Inventory._currentSubject.Protection / 100f * Inventory._currentSubject.State) + ". Радиохимическая защита: " + Inventory._currentSubject.XRayProtection + ". Исправность: " + (int)Inventory._currentSubject.State + "%. Контейнеры для артефактов: " + Inventory._currentSubject.ArtContainer + ".";
			}
			if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Weapon || Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Grenade)
			{
				Text component23 = gameObject4.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
				string text = component23.text;
				component23.text = text + "Повреждение: " + Inventory._currentSubject.Damage + " Дальность: " + Inventory._currentSubject.MinRange + "-" + Inventory._currentSubject.Range + ". Исправность: " + (int)Inventory._currentSubject.State + "%. Кол-во патронов: " + Inventory._currentSubject.CartridgeInMagazineFull + " шт.";
			}
			if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Artefact || Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.OtherSubject)
			{
				if (Inventory._currentSubject.Protection != 0f)
				{
					Text component24 = gameObject4.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
					string text = component24.text;
					component24.text = text + "Защита: " + Inventory._currentSubject.Protection + ". ";
				}
				if (Inventory._currentSubject.Sanitation != 0f)
				{
					Text component25 = gameObject4.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
					string text = component25.text;
					component25.text = text + "Лечение: " + Inventory._currentSubject.Sanitation + ". ";
				}
				if (Inventory._currentSubject.Bleeding != 0f)
				{
					Text component26 = gameObject4.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
					string text = component26.text;
					component26.text = text + "Кровотечение: " + Inventory._currentSubject.Bleeding + ". ";
				}
				if (Inventory._currentSubject.Force != 0f)
				{
					Text component27 = gameObject4.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
					string text = component27.text;
					component27.text = text + "Выносливость: +" + Inventory._currentSubject.Force + " кг. ";
				}
				if (Inventory._currentSubject.Hunger > 0)
				{
					Text component28 = gameObject4.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
					string text = component28.text;
					component28.text = text + "Утоление голода: " + Inventory._currentSubject.Hunger + ". ";
				}
				if (Inventory._currentSubject.Thirst > 0)
				{
					Text component29 = gameObject4.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
					string text = component29.text;
					component29.text = text + "Утоление жажды: " + Inventory._currentSubject.Thirst + ". ";
				}
				if (Inventory._currentSubject.XRayProtection != 0)
				{
					Text component30 = gameObject4.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
					string text = component30.text;
					component30.text = text + "Защита от радиации: " + Inventory._currentSubject.XRayProtection + ". ";
				}
				if (Inventory._currentSubject.XRaySanitation != 0)
				{
					Text component31 = gameObject4.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
					string text = component31.text;
					component31.text = text + "Лечение радиации: " + Inventory._currentSubject.XRaySanitation + ". ";
				}
				if (Inventory._currentSubject.ProtectionFromEject != 0)
				{
					Text component32 = gameObject4.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
					string text = component32.text;
					component32.text = text + "Защита от выброса: " + Inventory._currentSubject.ProtectionFromEject + ". ";
				}
				if (Inventory._currentSubject.PsiProtection != 0)
				{
					Text component33 = gameObject4.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
					string text = component33.text;
					component33.text = text + "ПСИ-Защита: " + Inventory._currentSubject.PsiProtection + ". ";
				}
				if (Inventory._currentSubject.Hunger < 0)
				{
					Text component34 = gameObject4.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>();
					string text = component34.text;
					component34.text = text + "Голод: + " + Inventory._currentSubject.Hunger * -1 + ". ";
					gameObject4.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>().color = new Color(0.5f, 0.2f, 0.2f, 1f);
				}
				if (Inventory._currentSubject.Thirst < 0)
				{
					Text component35 = gameObject4.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>();
					string text = component35.text;
					component35.text = text + "Жажда: +" + Inventory._currentSubject.Thirst * -1 + ". ";
					gameObject4.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>().color = new Color(0.5f, 0.2f, 0.2f, 1f);
				}
				if (Inventory._currentSubject.XrayNegatife != 0)
				{
					Text component36 = gameObject4.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>();
					string text = component36.text;
					component36.text = text + "Радиация: + " + Inventory._currentSubject.XrayNegatife + ". ";
					gameObject4.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>().color = new Color(0.5f, 0.2f, 0.2f, 1f);
				}
			}
			if (Inventory._currentSubject.TypeSubj != AAAAAAAAAAAAAAAAAAk.TypeSubject.None)
			{
				Inventory._TradeCost = (float)Inventory._currentSubject.CostSubject / SaveLoad.Difficulty * (float)(int)Inventory._currentSubject.State / 100f;
				Inventory._TradeCost *= 2.1f;
				if (Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == Data.Points[Inventory._CurrentPoint[0]].ControlInt)
				{
					Inventory._TradeCost /= 1.5f;
				}
				Inventory._TradeCost -= Inventory._TradeCost * (float)AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.Points[Inventory._CurrentPoint[0]].ControlInt, Data.CharacterD[CharacterMotion._curCharacter].TypeChInt] / 24f;
				if (Inventory._currentSubject.WeightUpGrade != 0f)
				{
					Inventory._TradeCost *= 1.1f;
				}
				if (Inventory._currentSubject.UpGrade != 0f)
				{
					Inventory._TradeCost *= 1.1f;
				}
				if (Inventory._currentSubject.SightInstallation)
				{
					Inventory._TradeCost *= 1.1f;
				}
				if (CharacterMotion.SlotSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Catridge)
				{
					Inventory._TradeCost *= CharacterMotion.SlotSubject.Stack;
				}
				GameObject gameObject5 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/BattonOfDescriptionPanel"));
				gameObject5.transform.SetParent(gameObject4.transform.GetChild(3).transform);
				GameObject.Find("ButtonPanel").transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/OtherSprite/Slot128");
				gameObject5.GetComponentInChildren<Text>().text = "Цена: " + (int)Inventory._TradeCost + " Ru";
				gameObject5 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/BattonOfDescriptionPanel"));
				gameObject5.transform.SetParent(gameObject4.transform.GetChild(3).transform);
				gameObject5.GetComponentInChildren<Text>().text = "Купить";
			}
			if (Inventory._currentSubject.SingModification)
			{
				if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Suit)
				{
					if (Inventory._currentSubject.Sanitation > 0f)
					{
						Text component37 = gameObject4.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>();
						string text = component37.text;
						component37.text = text + "Заживление ран: +" + Inventory._currentSubject.Sanitation + ". ";
					}
					if (Inventory._currentSubject.WeightUpGrade != 0f)
					{
						Text component38 = gameObject4.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>();
						string text = component38.text;
						component38.text = text + "Вес: " + Inventory._currentSubject.WeightUpGrade + " кг. ";
					}
					if (Inventory._currentSubject.UpGrade != 0f)
					{
						Text component39 = gameObject4.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>();
						string text = component39.text;
						component39.text = text + "Защита: + " + Inventory._currentSubject.UpGrade + ". ";
					}
				}
				if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Weapon)
				{
					if (Inventory._currentSubject.WeightUpGrade != 0f)
					{
						Text component40 = gameObject4.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>();
						string text = component40.text;
						component40.text = text + "Вес: " + Inventory._currentSubject.WeightUpGrade + " кг. ";
					}
					if (Inventory._currentSubject.UpGrade != 0f)
					{
						Text component41 = gameObject4.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>();
						string text = component41.text;
						component41.text = text + "Повреждение: + " + Inventory._currentSubject.UpGrade + ". ";
					}
					if (Inventory._currentSubject.SightInstallation)
					{
						gameObject4.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>().text += "Дальность: + 1";
					}
				}
			}
		}
		if (CharacterMotion.CachePanel)
		{
			Object.Destroy(GameObject.Find("InventoryInformation"));
			GameObject gameObject6 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/InventoryInformation"));
			gameObject6.name = "InventoryInformation";
			gameObject6.transform.SetParent(GameObject.Find("NewEquipmentPanel").transform);
			gameObject6.transform.localPosition = new Vector3(-Inventory._posX3 / 2, 0f);
			gameObject6.transform.GetChild(1).GetComponent<RawImage>().texture = Inventory._currentSubject.TextureSubject;
			if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Weapon)
			{
				gameObject6.transform.GetChild(1).transform.rotation *= Quaternion.Euler(0f, 0f, 90f);
			}
			gameObject6.transform.GetChild(1).GetComponent<RawImage>().SetNativeSize();
			gameObject6.transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = Inventory._currentSubject.NameSubject;
			gameObject6.transform.GetChild(2).transform.GetChild(1).GetComponent<Text>().text = Inventory._currentSubject.DescriptionSubject;
			if (CharacterMotion.SlotSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Catridge)
			{
				gameObject6.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>().text = "Количество: " + CharacterMotion.SlotSubject.Stack + " шт. Вес: " + Inventory._currentSubject.WeightSubject * (float)CharacterMotion.SlotSubject.Stack + " кг. ";
			}
			else
			{
				gameObject6.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>().text = "Вес: " + Inventory._currentSubject.WeightSubject + " кг. ";
			}
			if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Suit)
			{
				Text component42 = gameObject6.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
				string text = component42.text;
				component42.text = text + "Защита: max - " + (int)Inventory._currentSubject.Protection + ", текущая - " + (int)(Inventory._currentSubject.Protection / 100f * Inventory._currentSubject.State) + ". Радиохимическая защита: " + Inventory._currentSubject.XRayProtection + ". Исправность: " + (int)Inventory._currentSubject.State + "%. Контейнеры для артефактов: " + Inventory._currentSubject.ArtContainer + ".";
			}
			if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Weapon || Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Grenade)
			{
				Text component43 = gameObject6.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
				string text = component43.text;
				component43.text = text + "Повреждение: " + Inventory._currentSubject.Damage + " Дальность: " + Inventory._currentSubject.MinRange + "-" + Inventory._currentSubject.Range + ". Исправность: " + (int)Inventory._currentSubject.State + "%. Кол-во патронов: " + Inventory._currentSubject.CartridgeInMagazineFull + " шт.";
			}
			if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Artefact || Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.OtherSubject)
			{
				if (Inventory._currentSubject.Protection != 0f)
				{
					Text component44 = gameObject6.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
					string text = component44.text;
					component44.text = text + "Защита: " + Inventory._currentSubject.Protection + ". ";
				}
				if (Inventory._currentSubject.Sanitation != 0f)
				{
					Text component45 = gameObject6.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
					string text = component45.text;
					component45.text = text + "Лечение: " + Inventory._currentSubject.Sanitation + ". ";
				}
				if (Inventory._currentSubject.Bleeding != 0f)
				{
					Text component46 = gameObject6.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
					string text = component46.text;
					component46.text = text + "Кровотечение: " + Inventory._currentSubject.Bleeding + ". ";
				}
				if (Inventory._currentSubject.Force != 0f)
				{
					Text component47 = gameObject6.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
					string text = component47.text;
					component47.text = text + "Выносливость: +" + Inventory._currentSubject.Force + " кг. ";
				}
				if (Inventory._currentSubject.Hunger < 0)
				{
					Text component48 = gameObject6.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
					string text = component48.text;
					component48.text = text + "Утоление голода: " + Inventory._currentSubject.Hunger + ". ";
				}
				if (Inventory._currentSubject.Thirst > 0)
				{
					Text component49 = gameObject6.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
					string text = component49.text;
					component49.text = text + "Утоление жажды: " + Inventory._currentSubject.Thirst + ". ";
				}
				if (Inventory._currentSubject.XRayProtection != 0)
				{
					Text component50 = gameObject6.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
					string text = component50.text;
					component50.text = text + "Защита от радиации: " + Inventory._currentSubject.XRayProtection + ". ";
				}
				if (Inventory._currentSubject.XRaySanitation != 0)
				{
					Text component51 = gameObject6.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
					string text = component51.text;
					component51.text = text + "Лечение радиации: " + Inventory._currentSubject.XRaySanitation + ". ";
				}
				if (Inventory._currentSubject.ProtectionFromEject != 0)
				{
					Text component52 = gameObject6.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
					string text = component52.text;
					component52.text = text + "Защита от выброса: " + Inventory._currentSubject.ProtectionFromEject + ". ";
				}
				if (Inventory._currentSubject.PsiProtection != 0)
				{
					Text component53 = gameObject6.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
					string text = component53.text;
					component53.text = text + "ПСИ-Защита: " + Inventory._currentSubject.PsiProtection + ". ";
				}
				if (Inventory._currentSubject.Hunger < 0)
				{
					Text component54 = gameObject6.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>();
					string text = component54.text;
					component54.text = text + "Голод: + " + Inventory._currentSubject.Hunger * -1 + ". ";
					gameObject6.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>().color = new Color(0.5f, 0.2f, 0.2f, 1f);
				}
				if (Inventory._currentSubject.Thirst < 0)
				{
					Text component55 = gameObject6.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>();
					string text = component55.text;
					component55.text = text + "Жажда: +" + Inventory._currentSubject.Thirst * -1 + ". ";
					gameObject6.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>().color = new Color(0.5f, 0.2f, 0.2f, 1f);
				}
				if (Inventory._currentSubject.XrayNegatife != 0)
				{
					Text component56 = gameObject6.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>();
					string text = component56.text;
					component56.text = text + "Радиация: + " + Inventory._currentSubject.XrayNegatife + ". ";
					gameObject6.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>().color = new Color(0.5f, 0.2f, 0.2f, 1f);
				}
			}
			if (Inventory._currentSubject.TypeSubj != AAAAAAAAAAAAAAAAAAk.TypeSubject.QuestSubject)
			{
				Inventory._TradeCost = Inventory._currentSubject.CostSubject;
				GameObject gameObject7 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/BattonOfDescriptionPanel"));
				gameObject7.transform.SetParent(gameObject6.transform.GetChild(3).transform);
				gameObject7.GetComponentInChildren<Text>().text = "Забрать";
				gameObject7 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/BattonOfDescriptionPanel"));
				gameObject7.transform.SetParent(gameObject6.transform.GetChild(3).transform);
				gameObject7.GetComponentInChildren<Text>().text = "Выбросить";
				gameObject7.GetComponentInChildren<Text>().color = new Color(0.5f, 0.2f, 0.2f, 1f);
			}
			if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.QuestSubject && CharacterMotion.SlotEquipment >= 0)
			{
				GameObject gameObject8 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/BattonOfDescriptionPanel"));
				gameObject8.transform.SetParent(gameObject6.transform.GetChild(3).transform);
				gameObject8.GetComponentInChildren<Text>().text = "Забрать";
			}
			if (Inventory._currentSubject.SingModification)
			{
				if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Suit)
				{
					if (Inventory._currentSubject.Sanitation > 0f)
					{
						Text component57 = gameObject6.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>();
						string text = component57.text;
						component57.text = text + "Заживление ран: +" + Inventory._currentSubject.Sanitation + ". ";
					}
					if (Inventory._currentSubject.WeightUpGrade != 0f)
					{
						Text component58 = gameObject6.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>();
						string text = component58.text;
						component58.text = text + "Вес: " + Inventory._currentSubject.WeightUpGrade + " кг. ";
					}
					if (Inventory._currentSubject.UpGrade != 0f)
					{
						Text component59 = gameObject6.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>();
						string text = component59.text;
						component59.text = text + "Защита: + " + Inventory._currentSubject.UpGrade + ". ";
					}
				}
				if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Weapon)
				{
					if (Inventory._currentSubject.WeightUpGrade != 0f)
					{
						Text component60 = gameObject6.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>();
						string text = component60.text;
						component60.text = text + "Вес: " + Inventory._currentSubject.WeightUpGrade + " кг. ";
					}
					if (Inventory._currentSubject.UpGrade != 0f)
					{
						Text component61 = gameObject6.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>();
						string text = component61.text;
						component61.text = text + "Повреждение: + " + Inventory._currentSubject.UpGrade + ". ";
					}
					if (Inventory._currentSubject.SightInstallation)
					{
						gameObject6.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>().text += "Дальность: + 1";
					}
				}
			}
		}
		if (CharacterMotion.RewardPanel)
		{
			Object.Destroy(GameObject.Find("InventoryInformation"));
			GameObject gameObject9 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/InventoryInformation"));
			gameObject9.name = "InventoryInformation";
			gameObject9.transform.SetParent(GameObject.Find("NewEquipmentPanel").transform);
			gameObject9.transform.localPosition = new Vector3(-Inventory._posX3 / 2, 0f);
			gameObject9.transform.GetChild(1).GetComponent<RawImage>().texture = Inventory._currentSubject.TextureSubject;
			if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Weapon)
			{
				gameObject9.transform.GetChild(1).transform.rotation *= Quaternion.Euler(0f, 0f, 90f);
			}
			gameObject9.transform.GetChild(1).GetComponent<RawImage>().SetNativeSize();
			gameObject9.transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = Inventory._currentSubject.NameSubject;
			gameObject9.transform.GetChild(2).transform.GetChild(1).GetComponent<Text>().text = Inventory._currentSubject.DescriptionSubject;
			gameObject9.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>().text = "Вес: " + Inventory._currentSubject.WeightSubject + " кг. ";
			if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Suit)
			{
				Text component62 = gameObject9.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
				string text = component62.text;
				component62.text = text + "Защита: max - " + (int)Inventory._currentSubject.Protection + ", текущая - " + (int)(Inventory._currentSubject.Protection / 100f * Inventory._currentSubject.State) + ". Радиохимическая защита: " + Inventory._currentSubject.XRayProtection + ". Исправность: " + (int)Inventory._currentSubject.State + "%. Контейнеры для артефактов: " + Inventory._currentSubject.ArtContainer + ".";
			}
			if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Weapon || Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Grenade)
			{
				Text component63 = gameObject9.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
				string text = component63.text;
				component63.text = text + "Повреждение: " + Inventory._currentSubject.Damage + " Дальность: " + Inventory._currentSubject.MinRange + "-" + Inventory._currentSubject.Range + ". Исправность: " + (int)Inventory._currentSubject.State + "%. Кол-во патронов: " + Inventory._currentSubject.CartridgeInMagazineFull + " шт.";
			}
			if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Artefact || Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.OtherSubject)
			{
				if (Inventory._currentSubject.Protection != 0f)
				{
					Text component64 = gameObject9.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
					string text = component64.text;
					component64.text = text + "Защита: " + Inventory._currentSubject.Protection + ". ";
				}
				if (Inventory._currentSubject.Sanitation != 0f)
				{
					Text component65 = gameObject9.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
					string text = component65.text;
					component65.text = text + "Лечение: " + Inventory._currentSubject.Sanitation + ". ";
				}
				if (Inventory._currentSubject.Bleeding != 0f)
				{
					Text component66 = gameObject9.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
					string text = component66.text;
					component66.text = text + "Кровотечение: " + Inventory._currentSubject.Bleeding + ". ";
				}
				if (Inventory._currentSubject.Force != 0f)
				{
					Text component67 = gameObject9.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
					string text = component67.text;
					component67.text = text + "Выносливость: +" + Inventory._currentSubject.Force + " кг. ";
				}
				if (Inventory._currentSubject.Hunger < 0)
				{
					Text component68 = gameObject9.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
					string text = component68.text;
					component68.text = text + "Утоление голода: " + Inventory._currentSubject.Hunger + ". ";
				}
				if (Inventory._currentSubject.Thirst > 0)
				{
					Text component69 = gameObject9.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
					string text = component69.text;
					component69.text = text + "Утоление жажды: " + Inventory._currentSubject.Thirst + ". ";
				}
				if (Inventory._currentSubject.XRayProtection != 0)
				{
					Text component70 = gameObject9.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
					string text = component70.text;
					component70.text = text + "Защита от радиации: " + Inventory._currentSubject.XRayProtection + ". ";
				}
				if (Inventory._currentSubject.XRaySanitation != 0)
				{
					Text component71 = gameObject9.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
					string text = component71.text;
					component71.text = text + "Лечение радиации: " + Inventory._currentSubject.XRaySanitation + ". ";
				}
				if (Inventory._currentSubject.ProtectionFromEject != 0)
				{
					Text component72 = gameObject9.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
					string text = component72.text;
					component72.text = text + "Защита от выброса: " + Inventory._currentSubject.ProtectionFromEject + ". ";
				}
				if (Inventory._currentSubject.PsiProtection != 0)
				{
					Text component73 = gameObject9.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
					string text = component73.text;
					component73.text = text + "ПСИ-Защита: " + Inventory._currentSubject.PsiProtection + ". ";
				}
				if (Inventory._currentSubject.Hunger < 0)
				{
					Text component74 = gameObject9.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>();
					string text = component74.text;
					component74.text = text + "Голод: + " + Inventory._currentSubject.Hunger * -1 + ". ";
					gameObject9.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>().color = new Color(0.5f, 0.2f, 0.2f, 1f);
				}
				if (Inventory._currentSubject.Thirst < 0)
				{
					Text component75 = gameObject9.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>();
					string text = component75.text;
					component75.text = text + "Жажда: +" + Inventory._currentSubject.Thirst * -1 + ". ";
					gameObject9.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>().color = new Color(0.5f, 0.2f, 0.2f, 1f);
				}
				if (Inventory._currentSubject.XrayNegatife != 0)
				{
					Text component76 = gameObject9.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>();
					string text = component76.text;
					component76.text = text + "Радиация: + " + Inventory._currentSubject.XrayNegatife + ". ";
					gameObject9.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>().color = new Color(0.5f, 0.2f, 0.2f, 1f);
				}
			}
			if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.QuestSubject)
			{
				if (CharacterMotion.SlotEquipment >= 0)
				{
					GameObject gameObject10 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/BattonOfDescriptionPanel"));
					gameObject10.transform.SetParent(gameObject9.transform.GetChild(3).transform);
					gameObject10.GetComponentInChildren<Text>().text = "Забрать";
				}
			}
			else if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Catridge || Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Grenade || Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Suit || Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Weapon || Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Detector || Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Artefact || Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.OtherSubject)
			{
				Inventory._TradeCost = Inventory._currentSubject.CostSubject;
				GameObject gameObject11 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/BattonOfDescriptionPanel"));
				gameObject11.transform.SetParent(gameObject9.transform.GetChild(3).transform);
				gameObject11.GetComponentInChildren<Text>().text = "Забрать";
				gameObject11 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/BattonOfDescriptionPanel"));
				gameObject11.transform.SetParent(gameObject9.transform.GetChild(3).transform);
				gameObject11.GetComponentInChildren<Text>().text = "Выбросить";
				gameObject11.GetComponentInChildren<Text>().color = new Color(0.5f, 0.2f, 0.2f, 1f);
			}
			if (Inventory._currentSubject.SingModification)
			{
				if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Suit)
				{
					if (Inventory._currentSubject.Sanitation > 0f)
					{
						Text component77 = gameObject9.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>();
						string text = component77.text;
						component77.text = text + "Заживление ран: +" + Inventory._currentSubject.Sanitation + ". ";
					}
					if (Inventory._currentSubject.WeightUpGrade != 0f)
					{
						Text component78 = gameObject9.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>();
						string text = component78.text;
						component78.text = text + "Вес: " + Inventory._currentSubject.WeightUpGrade + " кг. ";
					}
					if (Inventory._currentSubject.UpGrade != 0f)
					{
						Text component79 = gameObject9.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>();
						string text = component79.text;
						component79.text = text + "Защита: + " + Inventory._currentSubject.UpGrade + ". ";
					}
				}
				if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Weapon)
				{
					if (Inventory._currentSubject.WeightUpGrade != 0f)
					{
						Text component80 = gameObject9.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>();
						string text = component80.text;
						component80.text = text + "Вес: " + Inventory._currentSubject.WeightUpGrade + " кг. ";
					}
					if (Inventory._currentSubject.UpGrade != 0f)
					{
						Text component81 = gameObject9.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>();
						string text = component81.text;
						component81.text = text + "Повреждение: + " + Inventory._currentSubject.UpGrade + ". ";
					}
					if (Inventory._currentSubject.SightInstallation)
					{
						gameObject9.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>().text += "Дальность: + 1";
					}
				}
			}
		}
		if (Inventory._currentSubject.TextOfDocument != null)
		{
			GameObject gameObject12 = GameObject.Find("InventoryInformation");
			GameObject gameObject13 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/BattonOfDescriptionPanel"));
			gameObject13.transform.SetParent(gameObject12.transform.GetChild(3).transform);
			gameObject13.GetComponentInChildren<Text>().text = "Открыть";
		}
		if (Inventory._currentSubject.NameSubject != "None")
		{
			Inventory.SoundMenu.clip = Inventory._currentSubject.AudioSlot;
			Inventory.SoundMenu.Play();
		}
		float num = Screen.width;
		num /= 920f;
		GameObject.Find("InventoryInformation").transform.localScale = new Vector3(num, num);
	}
}
