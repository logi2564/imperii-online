using UnityEngine;
using UnityEngine.UI;

public class NewChoiseSubject : MonoBehaviour
{
	public int slotID;

	public void ClickOnButtonSubject()
	{
		if (slotID >= 0)
		{
			Inventory._currentSubject = Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[slotID];
		}
		if (slotID == -1)
		{
			Inventory._currentSubject = Data.CharacterD[CharacterMotion._curCharacter].SuitChar;
		}
		if (slotID == -2)
		{
			Inventory._currentSubject = Data.CharacterD[CharacterMotion._curCharacter].WeaponChar;
		}
		if (slotID == -3)
		{
			Inventory._currentSubject = Data.CharacterD[CharacterMotion._curCharacter].DetectorChar;
		}
		if (slotID == -4)
		{
			Inventory._currentSubject = Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[0];
		}
		if (slotID == -5)
		{
			Inventory._currentSubject = Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[1];
		}
		if (slotID == -6)
		{
			Inventory._currentSubject = Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[2];
		}
		if (slotID == -7)
		{
			Inventory._currentSubject = Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[3];
		}
		if (slotID <= -8)
		{
			Inventory._currentSubject = new AAAAAAAAAAAAAAAAAAbi();
		}
		CharacterMotion.SlotEquipment = slotID;
		CharacterMotion.ItemGG = true;
		AAAAAAAAAAAAAAAAAci.AAAAAAAAAAAAAAAAAcj();
		AAAAAAAAAAAAAAAbl();
	}

	public static void AAAAAAAAAAAAAAAbl()
	{
		if (Inventory._currentSubject == null || !(Inventory._currentSubject.NameSubject != "None") || !(Inventory._currentSubject.NameSubject != string.Empty))
		{
			return;
		}
		Object.Destroy(GameObject.Find("InventoryInformation"));
		GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/InventoryInformation"));
		gameObject.name = "InventoryInformation";
		gameObject.transform.SetParent(GameObject.Find("NewEquipmentPanel").transform);
		gameObject.transform.localPosition = new Vector3(-Inventory._posX3 / 2, 0f);
		gameObject.transform.GetChild(1).GetComponent<RawImage>().texture = Inventory._currentSubject.TextureSubject;
		if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Weapon)
		{
			gameObject.transform.GetChild(1).transform.rotation *= Quaternion.Euler(0f, 0f, 90f);
		}
		gameObject.transform.GetChild(1).GetComponent<RawImage>().SetNativeSize();
		gameObject.transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = Inventory._currentSubject.NameSubject;
		gameObject.transform.GetChild(2).transform.GetChild(1).GetComponent<Text>().text = Inventory._currentSubject.DescriptionSubject;
		if (CharacterMotion.SlotSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Catridge)
		{
			gameObject.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>().text = "Количество: " + CharacterMotion.SlotSubject.Stack + " шт. Вес: " + Inventory._currentSubject.WeightSubject * (float)CharacterMotion.SlotSubject.Stack + " кг. ";
		}
		else
		{
			gameObject.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>().text = "Вес: " + Inventory._currentSubject.WeightSubject + " кг. ";
		}
		if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Suit)
		{
			Text component = gameObject.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
			string text = component.text;
			component.text = text + "Защита: max - " + (int)Inventory._currentSubject.Protection + ", текущая - " + (int)(Inventory._currentSubject.Protection / 100f * Inventory._currentSubject.State) + ". Радиохимическая защита: " + Inventory._currentSubject.XRayProtection + ". Исправность: " + (int)Inventory._currentSubject.State + "%. Контейнеры для артефактов: " + Inventory._currentSubject.ArtContainer + ". ПСИ-защита: " + Inventory._currentSubject.PsiProtection + ".";
		}
		if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Weapon || Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Grenade)
		{
			Text component2 = gameObject.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
			string text = component2.text;
			component2.text = text + "Повреждение: " + Inventory._currentSubject.Damage + " Дальность: " + Inventory._currentSubject.MinRange + "-" + Inventory._currentSubject.Range + ". Исправность: " + (int)Inventory._currentSubject.State + "%. Кол-во патронов: " + Inventory._currentSubject.CartridgeInMagazineFull + " шт.";
		}
		if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Suit)
		{
			if (Inventory._currentSubject.Sanitation > 0f)
			{
				Text component3 = gameObject.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>();
				string text = component3.text;
				component3.text = text + "Заживление ран: +" + Inventory._currentSubject.Sanitation + ". ";
			}
			if (Inventory._currentSubject.WeightUpGrade != 0f)
			{
				Text component4 = gameObject.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>();
				string text = component4.text;
				component4.text = text + "Вес: " + Inventory._currentSubject.WeightUpGrade + " кг. ";
			}
			if (Inventory._currentSubject.UpGrade != 0f)
			{
				Text component5 = gameObject.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>();
				string text = component5.text;
				component5.text = text + "Защита: + " + Inventory._currentSubject.UpGrade + ". ";
			}
		}
		if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Weapon)
		{
			if (Inventory._currentSubject.WeightUpGrade != 0f)
			{
				Text component6 = gameObject.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>();
				string text = component6.text;
				component6.text = text + "Вес: " + Inventory._currentSubject.WeightUpGrade + " кг. ";
			}
			if (Inventory._currentSubject.UpGrade != 0f)
			{
				Text component7 = gameObject.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>();
				string text = component7.text;
				component7.text = text + "Повреждение: + " + Inventory._currentSubject.UpGrade + ". ";
			}
			if (Inventory._currentSubject.SightInstallation)
			{
				gameObject.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>().text += "Дальность: + 1";
			}
		}
		if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Artefact || Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.OtherSubject)
		{
			if (Inventory._currentSubject.Protection != 0f)
			{
				Text component8 = gameObject.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
				string text = component8.text;
				component8.text = text + "Защита: " + Inventory._currentSubject.Protection + ". ";
			}
			if (Inventory._currentSubject.Sanitation != 0f)
			{
				Text component9 = gameObject.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
				string text = component9.text;
				component9.text = text + "Лечение: " + Inventory._currentSubject.Sanitation + ". ";
			}
			if (Inventory._currentSubject.Bleeding != 0f)
			{
				Text component10 = gameObject.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
				string text = component10.text;
				component10.text = text + "Кровотечение: " + Inventory._currentSubject.Bleeding + ". ";
			}
			if (Inventory._currentSubject.Force != 0f)
			{
				Text component11 = gameObject.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
				string text = component11.text;
				component11.text = text + "Выносливость: +" + Inventory._currentSubject.Force + " кг. ";
			}
			if (Inventory._currentSubject.Hunger > 0)
			{
				Text component12 = gameObject.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
				string text = component12.text;
				component12.text = text + "Утоление голода: " + Inventory._currentSubject.Hunger + ". ";
			}
			if (Inventory._currentSubject.Thirst > 0)
			{
				Text component13 = gameObject.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
				string text = component13.text;
				component13.text = text + "Утоление жажды: " + Inventory._currentSubject.Thirst + ". ";
			}
			if (Inventory._currentSubject.XRayProtection != 0)
			{
				Text component14 = gameObject.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
				string text = component14.text;
				component14.text = text + "Защита от радиации: " + Inventory._currentSubject.XRayProtection + ". ";
			}
			if (Inventory._currentSubject.XRaySanitation != 0)
			{
				Text component15 = gameObject.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
				string text = component15.text;
				component15.text = text + "Лечение радиации: " + Inventory._currentSubject.XRaySanitation + ". ";
			}
			if (Inventory._currentSubject.ProtectionFromEject != 0)
			{
				Text component16 = gameObject.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
				string text = component16.text;
				component16.text = text + "Защита от выброса: " + Inventory._currentSubject.ProtectionFromEject + ". ";
			}
			if (Inventory._currentSubject.PsiProtection != 0)
			{
				Text component17 = gameObject.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
				string text = component17.text;
				component17.text = text + "ПСИ-Защита: " + Inventory._currentSubject.PsiProtection + ". ";
			}
			if (Inventory._currentSubject.Hunger < 0)
			{
				Text component18 = gameObject.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>();
				string text = component18.text;
				component18.text = text + "Голод: + " + Inventory._currentSubject.Hunger * -1 + ". ";
				gameObject.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>().color = new Color(0.5f, 0.2f, 0.2f, 1f);
			}
			if (Inventory._currentSubject.Thirst < 0)
			{
				Text component19 = gameObject.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>();
				string text = component19.text;
				component19.text = text + "Жажда: +" + Inventory._currentSubject.Thirst * -1 + ". ";
				gameObject.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>().color = new Color(0.5f, 0.2f, 0.2f, 1f);
			}
			if (Inventory._currentSubject.XrayNegatife != 0)
			{
				Text component20 = gameObject.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>();
				string text = component20.text;
				component20.text = text + "Радиация: + " + Inventory._currentSubject.XrayNegatife + ". ";
				gameObject.transform.GetChild(2).transform.GetChild(3).GetComponent<Text>().color = new Color(0.5f, 0.2f, 0.2f, 1f);
			}
		}
		if (Inventory._currentSubject.TypeSubj != AAAAAAAAAAAAAAAAAAk.TypeSubject.QuestSubject)
		{
			if (CharacterMotion.RepairPanel && (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Suit || Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Weapon))
			{
				if (Inventory._currentSubject.State < 100f)
				{
					Inventory._TradeCost = (int)((Inventory._currentSubject.State - 100f) * -1f * (float)Inventory._currentSubject.CostSubject / 95f);
					GameObject gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/BattonOfDescriptionPanel"));
					gameObject2.transform.SetParent(gameObject.transform.GetChild(3).transform);
					gameObject2.GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/OtherSprite/Slot128");
					gameObject2.GetComponentInChildren<Text>().text = "Ремонт: " + Inventory._TradeCost + " Ru";
					gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/BattonOfDescriptionPanel"));
					gameObject2.transform.SetParent(gameObject.transform.GetChild(3).transform);
					gameObject2.GetComponentInChildren<Text>().text = "Ремонтировать";
				}
				else
				{
					GameObject gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/BattonOfDescriptionPanel"));
					gameObject2.transform.SetParent(gameObject.transform.GetChild(3).transform);
					gameObject2.GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/OtherSprite/Slot128");
					gameObject2.GetComponentInChildren<Text>().text = "Исправно";
				}
			}
			if ((CharacterMotion.NPSPanel && Data.CharacterD[Inventory._currentCharacterNumber].Life) || CharacterMotion.DealerPanel)
			{
				Inventory._TradeCost = (float)Inventory._currentSubject.CostSubject * SaveLoad.Difficulty * (float)(int)Inventory._currentSubject.State / 100f;
				Inventory._TradeCost /= 3f;
				if (CharacterMotion.DealerPanel)
				{
					if (Data.Points[Inventory._CurrentPoint[0]].ControlInt == 11)
					{
						if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.MutantsSubject || Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Artefact)
						{
							Inventory._TradeCost *= 1.7f;
						}
					}
					else if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.MutantsSubject || Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Artefact)
					{
						Inventory._TradeCost *= 1.2f;
					}
				}
				if (CharacterMotion.NPSPanel)
				{
					Inventory._TradeCost /= 1.2f;
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
				gameObject2.GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/OtherSprite/Slot128");
				gameObject2.GetComponentInChildren<Text>().text = "Цена: " + (int)Inventory._TradeCost + " Ru";
			}
			if (CharacterMotion.SlotEquipment >= 0 && (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Suit || Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Weapon || Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Detector || Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Artefact || Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.OtherSubject))
			{
				GameObject gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/BattonOfDescriptionPanel"));
				gameObject2.transform.SetParent(gameObject.transform.GetChild(3).transform);
				gameObject2.GetComponentInChildren<Text>().text = "Использовать";
			}
			if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Weapon && Inventory._currentSubject.Cartridge > 0)
			{
				GameObject gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/BattonOfDescriptionPanel"));
				gameObject2.transform.SetParent(gameObject.transform.GetChild(3).transform);
				gameObject2.GetComponentInChildren<Text>().text = "Разрядить";
			}
			if (CharacterMotion.SlotEquipment < 0 && CharacterMotion.SlotEquipment >= -7)
			{
				Debug.Log("189");
				GameObject gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/BattonOfDescriptionPanel"));
				gameObject2.transform.SetParent(gameObject.transform.GetChild(3).transform);
				gameObject2.GetComponentInChildren<Text>().text = "Убрать";
			}
			if (CharacterMotion.CApanel && Inventory._currentSubject.NameSubject != "Свитер")
			{
				if (CharacterMotion.NPSPanel && CharacterMotion._curCharacter == 0)
				{
					GameObject gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/BattonOfDescriptionPanel"));
					gameObject2.transform.SetParent(gameObject.transform.GetChild(3).transform);
					if (Data.CharacterD[Inventory._currentCharacterNumber].Life)
					{
						gameObject2.GetComponentInChildren<Text>().text = "Продать";
					}
					else
					{
						gameObject2.GetComponentInChildren<Text>().text = "Оставить";
					}
				}
				if (CharacterMotion.DealerPanel)
				{
					GameObject gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/BattonOfDescriptionPanel"));
					gameObject2.transform.SetParent(gameObject.transform.GetChild(3).transform);
					gameObject2.GetComponentInChildren<Text>().text = "Продать";
				}
				if (CharacterMotion.CachePanel && CharacterMotion._curCharacter == 0)
				{
					GameObject gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/BattonOfDescriptionPanel"));
					gameObject2.transform.SetParent(gameObject.transform.GetChild(3).transform);
					gameObject2.GetComponentInChildren<Text>().text = "Оставить";
				}
			}
			if ((Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Suit && CharacterMotion.RepairPanel && Inventory._currentSubject.NameSubject != "Свитер") || (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Weapon && CharacterMotion.RepairPanel))
			{
				GameObject gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/BattonOfDescriptionPanel"));
				gameObject2.transform.SetParent(gameObject.transform.GetChild(3).transform);
				gameObject2.GetComponentInChildren<Text>().text = "Улучшить";
			}
			else
			{
				GameObject gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/BattonOfDescriptionPanel"));
				gameObject2.transform.SetParent(gameObject.transform.GetChild(3).transform);
				gameObject2.GetComponentInChildren<Text>().text = "Выбросить";
				gameObject2.GetComponentInChildren<Text>().color = new Color(0.5f, 0.2f, 0.2f, 1f);
			}
		}
		if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.QuestSubject && CharacterMotion.CachePanel && CharacterMotion.SlotEquipment >= 0)
		{
			GameObject gameObject3 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/BattonOfDescriptionPanel"));
			gameObject3.transform.SetParent(gameObject.transform.GetChild(3).transform);
			gameObject3.GetComponentInChildren<Text>().text = "Оставить";
		}
		if (Inventory._currentSubject.TextOfDocument != null)
		{
			GameObject gameObject4 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/BattonOfDescriptionPanel"));
			gameObject4.transform.SetParent(gameObject.transform.GetChild(3).transform);
			gameObject4.GetComponentInChildren<Text>().text = "Открыть";
		}
		if (Inventory._currentSubject.NameSubject != "None")
		{
			Inventory.SoundMenu.clip = Inventory._currentSubject.AudioSlot;
			Inventory.SoundMenu.Play();
		}
		float num = Screen.width;
		num /= 920f;
		gameObject.transform.localScale = new Vector3(num, num);
	}
}
