using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SubjectAct : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
{
	public void OnPointerDown(PointerEventData eventData)
	{
		if (base.gameObject.transform.GetChild(0).GetComponent<Text>().text == "Открыть")
		{
			Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/pda/pda_tip");
			Inventory.SoundMenu.Play();
			GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessagePanel"));
			gameObject.name = "MessagePanel";
			gameObject.transform.SetParent(GameObject.Find("Canvas").transform);
			gameObject.transform.localPosition = new Vector3(0f, 0f);
			gameObject.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width / 2);
			gameObject.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 2);
			gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().color = new Color(0.45f, 0.45f, 0.45f, 0.9f);
			gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = CharacterMotion.SlotSubject.TextOfDocument;
			gameObject.transform.localScale = new Vector3(1.8f, 1.8f);
			gameObject.transform.GetChild(1).transform.localScale = new Vector3(0.5f, 0.5f);
		}
		if (base.gameObject.transform.GetChild(0).GetComponent<Text>().text == "Выбросить")
		{
			if (CharacterMotion.ItemGG)
			{
				if (CharacterMotion.SlotEquipment >= 0)
				{
					Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].Stack -= CharacterMotion.SlotSubject.Stack;
					if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].Stack < 1)
					{
						Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment] = new AAAAAAAAAAAAAAAAAAbi();
					}
					Object.Destroy(GameObject.Find("InventoryInformation"));
				}
				if (CharacterMotion.SlotEquipment == -1)
				{
					Data.CharacterD[CharacterMotion._curCharacter].SuitChar = new AAAAAAAAAAAAAAAAr();
					Object.Destroy(GameObject.Find("InventoryInformation"));
				}
				if (CharacterMotion.SlotEquipment == -2)
				{
					Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new AAAAAAAAAAAAAAAAAAbi();
					Object.Destroy(GameObject.Find("InventoryInformation"));
				}
				if (CharacterMotion.SlotEquipment == -3)
				{
					Data.CharacterD[CharacterMotion._curCharacter].DetectorChar = new AAAAAAAAAAAAAAAAAAbi();
					Object.Destroy(GameObject.Find("InventoryInformation"));
				}
				if (CharacterMotion.SlotEquipment == -4)
				{
					Data.CharacterD[CharacterMotion._curCharacter].ArtChar = new AAAAAAAAAAAAAAAAAAbi();
					Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[0] = new AAAAAAAAAAAAAAAAAAbi();
					Object.Destroy(GameObject.Find("InventoryInformation"));
				}
				if (CharacterMotion.SlotEquipment == -5)
				{
					Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[1] = new AAAAAAAAAAAAAAAAAAbi();
					Object.Destroy(GameObject.Find("InventoryInformation"));
				}
				if (CharacterMotion.SlotEquipment == -6)
				{
					Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[2] = new AAAAAAAAAAAAAAAAAAbi();
					Object.Destroy(GameObject.Find("InventoryInformation"));
				}
				if (CharacterMotion.SlotEquipment == -7)
				{
					Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[3] = new AAAAAAAAAAAAAAAAAAbi();
					Object.Destroy(GameObject.Find("InventoryInformation"));
				}
			}
			else if (CharacterMotion.CachePanel && CharacterMotion.SlotEquipment >= 0)
			{
				Data.Points[Inventory._CurrentPoint[0]].Cache[CharacterMotion.SlotEquipment].Stack -= CharacterMotion.SlotSubject.Stack;
				if (Data.Points[Inventory._CurrentPoint[0]].Cache[CharacterMotion.SlotEquipment].Stack < 1)
				{
					Data.Points[Inventory._CurrentPoint[0]].Cache[CharacterMotion.SlotEquipment] = new AAAAAAAAAAAAAAAAAAbi();
				}
				Object.Destroy(GameObject.Find("InventoryInformation"));
			}
			AAAAAAAAAAAAAAAAAAAAbz();
		}
		if (base.gameObject.transform.GetChild(0).GetComponent<Text>().text == "Использовать" && CharacterMotion.SlotEquipment >= 0)
		{
			if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.OtherSubject)
			{
				Inventory._currentSubject = Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment];
				II.AAAAAAAAAAAAAAAAAAAAca();
				Inventory._currentSubject = new AAAAAAAAAAAAAAAAAAbi();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].Stack--;
				if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].Stack < 1)
				{
					Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment] = new AAAAAAAAAAAAAAAAAAbi();
				}
				Object.Destroy(GameObject.Find("InventoryInformation"));
			}
			if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Suit)
			{
				if (Data.CharacterD[CharacterMotion._curCharacter].SuitChar.NameSubject == "Свитер")
				{
					Data.CharacterD[CharacterMotion._curCharacter].SuitChar = Inventory._currentSubject;
					if (Inventory._currentSubject.State < 75f)
					{
						Inventory.MessagePanel("Костюм сильно изношен, его защитные свейства существенно ниже...");
					}
					Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].Stack--;
					if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].Stack < 1)
					{
						Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment] = new AAAAAAAAAAAAAAAAAAbi();
					}
					Inventory._currentSubject = new AAAAAAAAAAAAAAAAAAbi();
					Object.Destroy(GameObject.Find("InventoryInformation"));
				}
				else if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].Stack <= 1)
				{
					if (Inventory._currentSubject.NameSubject != "None")
					{
						Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment] = Data.CharacterD[CharacterMotion._curCharacter].SuitChar;
						Data.CharacterD[CharacterMotion._curCharacter].SuitChar = Inventory._currentSubject;
						if (Inventory._currentSubject.State < 75f)
						{
							Inventory.MessagePanel("Костюм сильно изношен, его защитные свейства существенно ниже...");
						}
						Inventory._currentSubject = new AAAAAAAAAAAAAAAAAAbi();
						Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
						Inventory.SoundMenu.Play();
						Object.Destroy(GameObject.Find("InventoryInformation"));
					}
					if (Inventory._currentSubject.NameSubject != "None")
					{
						Inventory.MessagePanel("В рюкзаке недостаточно места.");
					}
				}
				else
				{
					if (Inventory._currentSubject.NameSubject != "None")
					{
						for (int i = 0; i < 20; i++)
						{
							if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].NameSubject == "None" || Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i] == null)
							{
								Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i] = Data.CharacterD[CharacterMotion._curCharacter].SuitChar;
								Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].Stack--;
								Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
								Inventory.SoundMenu.Play();
								Data.CharacterD[CharacterMotion._curCharacter].SuitChar = Inventory._currentSubject;
								if (Inventory._currentSubject.State < 75f)
								{
									Inventory.MessagePanel("Костюм сильно изношен, его защитные свейства существенно ниже...");
								}
								Inventory._currentSubject = new AAAAAAAAAAAAAAAAAAbi();
								Object.Destroy(GameObject.Find("InventoryInformation"));
								break;
							}
						}
					}
					if (Inventory._currentSubject.NameSubject != "None")
					{
						Inventory.MessagePanel("В рюкзаке недостаточно места.");
					}
				}
			}
			if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Weapon)
			{
				if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].Stack <= 1)
				{
					if (Inventory._currentSubject.NameSubject != "None")
					{
						Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment] = Data.CharacterD[CharacterMotion._curCharacter].WeaponChar;
						Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = Inventory._currentSubject;
						if (Inventory._currentSubject.State < 75f)
						{
							Inventory.MessagePanel("Оружие сильно изношено, урон от него будет существенно меньше...");
						}
						Inventory._currentSubject = new AAAAAAAAAAAAAAAAAAbi();
						Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
						Inventory.SoundMenu.Play();
						Object.Destroy(GameObject.Find("InventoryInformation"));
					}
					if (Inventory._currentSubject.NameSubject != "None")
					{
						Inventory.MessagePanel("В рюкзаке недостаточно места.");
					}
				}
				else
				{
					if (Inventory._currentSubject.NameSubject != "None")
					{
						for (int j = 0; j < 20; j++)
						{
							if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[j].NameSubject == "None" || Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[j] == null)
							{
								Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[j] = Data.CharacterD[CharacterMotion._curCharacter].WeaponChar;
								Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].Stack--;
								Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
								Inventory.SoundMenu.Play();
								Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = Inventory._currentSubject;
								if (Inventory._currentSubject.State < 75f)
								{
									Inventory.MessagePanel("Оружие сильно изношено, урон от него будет существенно меньше...");
								}
								Inventory._currentSubject = new AAAAAAAAAAAAAAAAAAbi();
								Object.Destroy(GameObject.Find("InventoryInformation"));
								break;
							}
						}
					}
					if (Inventory._currentSubject.NameSubject != "None")
					{
						Inventory.MessagePanel("В рюкзаке недостаточно места.");
					}
				}
			}
			if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Detector)
			{
				if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].Stack <= 1)
				{
					for (int k = 0; k < 20; k++)
					{
						if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[k] == Data.CharacterD[CharacterMotion._curCharacter].DetectorChar)
						{
							Data.CharacterD[CharacterMotion._curCharacter].DetectorChar = Inventory._currentSubject;
							Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[k].Stack++;
							Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].Stack--;
							if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].Stack < 1)
							{
								Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment] = new AAAAAAAAAAAAAAAAAAbi();
							}
							Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
							Inventory.SoundMenu.Play();
							Inventory._currentSubject = new AAAAAAAAAAAAAAAAAAbi();
							Object.Destroy(GameObject.Find("InventoryInformation"));
							break;
						}
					}
					if (Inventory._currentSubject.NameSubject != "None")
					{
						Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment] = Data.CharacterD[CharacterMotion._curCharacter].DetectorChar;
						Data.CharacterD[CharacterMotion._curCharacter].DetectorChar = Inventory._currentSubject;
						Inventory._currentSubject = new AAAAAAAAAAAAAAAAAAbi();
						Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
						Inventory.SoundMenu.Play();
						Object.Destroy(GameObject.Find("InventoryInformation"));
					}
					if (Inventory._currentSubject.NameSubject != "None")
					{
						Inventory.MessagePanel("В рюкзаке недостаточно места.");
					}
				}
				else
				{
					for (int l = 0; l < 20; l++)
					{
						if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[l] == Data.CharacterD[CharacterMotion._curCharacter].DetectorChar)
						{
							Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[l].Stack++;
							Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].Stack--;
							Data.CharacterD[CharacterMotion._curCharacter].DetectorChar = Inventory._currentSubject;
							Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
							Inventory.SoundMenu.Play();
							Inventory._currentSubject = new AAAAAAAAAAAAAAAAAAbi();
							Object.Destroy(GameObject.Find("InventoryInformation"));
							break;
						}
					}
					if (Inventory._currentSubject.NameSubject != "None")
					{
						for (int m = 0; m < 20; m++)
						{
							if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[m].NameSubject == "None" || Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[m] == null)
							{
								Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[m] = Data.CharacterD[CharacterMotion._curCharacter].DetectorChar;
								Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].Stack--;
								Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
								Inventory.SoundMenu.Play();
								Data.CharacterD[CharacterMotion._curCharacter].DetectorChar = Inventory._currentSubject;
								Inventory._currentSubject = new AAAAAAAAAAAAAAAAAAbi();
								Object.Destroy(GameObject.Find("InventoryInformation"));
								break;
							}
						}
					}
					if (Inventory._currentSubject.NameSubject != "None")
					{
						Inventory.MessagePanel("В рюкзаке недостаточно места.");
					}
				}
			}
			if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Artefact)
			{
				GameObject gameObject2 = GameObject.Find("InventoryInformation");
				GameObject gameObject3 = Object.Instantiate(gameObject2.transform.GetChild(3).gameObject);
				for (int n = 0; n < gameObject3.transform.childCount; n++)
				{
					Object.Destroy(gameObject3.transform.GetChild(n).gameObject);
				}
				gameObject3.transform.SetParent(gameObject2.transform);
				gameObject3.transform.position = new Vector3(Screen.width / 2, Screen.height / 2);
				gameObject3.GetComponent<GridLayoutGroup>().cellSize = new Vector2(180f, 120f);
				for (int num = 0; num < Data.CharacterD[CharacterMotion._curCharacter].SuitChar.ArtContainer; num++)
				{
					GameObject gameObject4 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/BattonOfDescriptionPanel"));
					gameObject4.transform.SetParent(gameObject3.transform);
					gameObject4.transform.GetChild(0).GetComponent<Text>().text = "Использовать Контейнер №" + (num + 1);
					gameObject4.transform.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 170f);
					gameObject4.transform.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 110f);
					gameObject4.transform.SetParent(gameObject3.transform);
				}
				if (Data.CharacterD[CharacterMotion._curCharacter].SuitChar.ArtContainer == 0)
				{
					Inventory.MessagePanel("Нет контейнеров для артефактов!");
				}
			}
		}
		for (int num2 = 1; num2 < 5; num2++)
		{
			if (!(base.gameObject.transform.GetChild(0).GetComponent<Text>().text == "Использовать Контейнер №" + num2))
			{
				continue;
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].Stack <= 1)
			{
				for (int num3 = 0; num3 < 20; num3++)
				{
					if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num3] == Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[num2 - 1])
					{
						Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[num2 - 1] = Inventory._currentSubject;
						Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num3].Stack++;
						Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].Stack--;
						if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].Stack < 1)
						{
							Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment] = new AAAAAAAAAAAAAAAAAAbi();
						}
						Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
						Inventory.SoundMenu.Play();
						Inventory._currentSubject = new AAAAAAAAAAAAAAAAAAbi();
						Object.Destroy(GameObject.Find("InventoryInformation"));
						break;
					}
				}
				if (Inventory._currentSubject.NameSubject != "None")
				{
					Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment] = Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[num2 - 1];
					Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[num2 - 1] = Inventory._currentSubject;
					Inventory._currentSubject = new AAAAAAAAAAAAAAAAAAbi();
					Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
					Inventory.SoundMenu.Play();
					Object.Destroy(GameObject.Find("InventoryInformation"));
				}
				if (Inventory._currentSubject.NameSubject != "None")
				{
					Inventory.MessagePanel("В рюкзаке недостаточно места.");
				}
				continue;
			}
			for (int num4 = 0; num4 < 20; num4++)
			{
				if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num4] == Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[num2 - 1])
				{
					Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num4].Stack++;
					Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].Stack--;
					Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[num2 - 1] = Inventory._currentSubject;
					Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
					Inventory.SoundMenu.Play();
					Inventory._currentSubject = new AAAAAAAAAAAAAAAAAAbi();
					Object.Destroy(GameObject.Find("InventoryInformation"));
					break;
				}
			}
			if (Inventory._currentSubject.NameSubject != "None")
			{
				for (int num5 = 0; num5 < 20; num5++)
				{
					if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num5].NameSubject == "None" || Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num5] == null)
					{
						Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num5] = Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[num2 - 1];
						Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].Stack--;
						Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
						Inventory.SoundMenu.Play();
						Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[num2 - 1] = Inventory._currentSubject;
						Inventory._currentSubject = new AAAAAAAAAAAAAAAAAAbi();
						Object.Destroy(GameObject.Find("InventoryInformation"));
						break;
					}
				}
			}
			if (Inventory._currentSubject.NameSubject != "None")
			{
				Inventory.MessagePanel("В рюкзаке недостаточно места.");
			}
		}
		if (base.gameObject.transform.GetChild(0).GetComponent<Text>().text == "Убрать")
		{
			if (Inventory._currentSubject.TypeSubj != AAAAAAAAAAAAAAAAAAk.TypeSubject.Suit && Inventory._currentSubject.TypeSubj != AAAAAAAAAAAAAAAAAAk.TypeSubject.Weapon)
			{
				for (int num6 = 0; num6 < 20; num6++)
				{
					if (!(Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num6].NameSubject == Inventory._currentSubject.NameSubject))
					{
						continue;
					}
					Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num6].Stack++;
					if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Suit)
					{
						Data.CharacterD[CharacterMotion._curCharacter].SuitChar = new AAAAAAAAAAAAAAAAr();
					}
					if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Weapon)
					{
						Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new AAAAAAAAAAAAAAAAAAbi();
					}
					if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Detector)
					{
						Data.CharacterD[CharacterMotion._curCharacter].DetectorChar = new AAAAAAAAAAAAAAAAAAbi();
					}
					if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Artefact)
					{
						Data.CharacterD[CharacterMotion._curCharacter].ArtChar = new AAAAAAAAAAAAAAAAAAbi();
						if (CharacterMotion.SlotEquipment == -4)
						{
							Data.CharacterD[CharacterMotion._curCharacter].ArtChar = new AAAAAAAAAAAAAAAAAAbi();
							Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[0] = new AAAAAAAAAAAAAAAAAAbi();
						}
						if (CharacterMotion.SlotEquipment == -5)
						{
							Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[1] = new AAAAAAAAAAAAAAAAAAbi();
						}
						if (CharacterMotion.SlotEquipment == -6)
						{
							Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[2] = new AAAAAAAAAAAAAAAAAAbi();
						}
						if (CharacterMotion.SlotEquipment == -7)
						{
							Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[3] = new AAAAAAAAAAAAAAAAAAbi();
						}
					}
					Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
					Inventory.SoundMenu.Play();
					Inventory._currentSubject = new AAAAAAAAAAAAAAAAAAbi();
					Object.Destroy(GameObject.Find("InventoryInformation"));
					break;
				}
			}
			if (Inventory._currentSubject.NameSubject != "None")
			{
				for (int num7 = 0; num7 < 20; num7++)
				{
					if (!(Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num7].NameSubject == "None") && Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num7] != null)
					{
						continue;
					}
					Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num7] = Inventory._currentSubject;
					if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Suit)
					{
						Data.CharacterD[CharacterMotion._curCharacter].SuitChar = new AAAAAAAAAAAAAAAAr();
					}
					if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Weapon)
					{
						Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new AAAAAAAAAAAAAAAAAAbi();
					}
					if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Detector)
					{
						Data.CharacterD[CharacterMotion._curCharacter].DetectorChar = new AAAAAAAAAAAAAAAAAAbi();
					}
					if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Artefact)
					{
						Data.CharacterD[CharacterMotion._curCharacter].ArtChar = new AAAAAAAAAAAAAAAAAAbi();
						if (CharacterMotion.SlotEquipment == -4)
						{
							Data.CharacterD[CharacterMotion._curCharacter].ArtChar = new AAAAAAAAAAAAAAAAAAbi();
							Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[0] = new AAAAAAAAAAAAAAAAAAbi();
						}
						if (CharacterMotion.SlotEquipment == -5)
						{
							Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[1] = new AAAAAAAAAAAAAAAAAAbi();
						}
						if (CharacterMotion.SlotEquipment == -6)
						{
							Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[2] = new AAAAAAAAAAAAAAAAAAbi();
						}
						if (CharacterMotion.SlotEquipment == -7)
						{
							Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[3] = new AAAAAAAAAAAAAAAAAAbi();
						}
					}
					Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
					Inventory.SoundMenu.Play();
					Inventory._currentSubject = new AAAAAAAAAAAAAAAAAAbi();
					Object.Destroy(GameObject.Find("InventoryInformation"));
					break;
				}
			}
			if (Inventory._currentSubject.NameSubject != "None")
			{
				Inventory.MessagePanel("В рюкзаке недостаточно места.");
			}
		}
		if (base.gameObject.transform.GetChild(0).GetComponent<Text>().text == "Купить")
		{
			if (CharacterMotion.NPSPanel)
			{
				if (Inventory._TradeCost <= (float)Data.CharacterD[CharacterMotion._curCharacter].Cash)
				{
					if (Inventory._currentSubject.TypeSubj != AAAAAAAAAAAAAAAAAAk.TypeSubject.Suit && Inventory._currentSubject.TypeSubj != AAAAAAAAAAAAAAAAAAk.TypeSubject.Weapon)
					{
						for (int num8 = 0; num8 < 20; num8++)
						{
							if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num8].NameSubject == Inventory._currentSubject.NameSubject)
							{
								Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num8].Stack += CharacterMotion.SlotSubject.Stack;
								Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
								Inventory.SoundMenu.Play();
								Inventory._currentSubject = new AAAAAAAAAAAAAAAAAAbi();
								Object.Destroy(GameObject.Find("InventoryInformation"));
								if (Data.CharacterD[Inventory._currentCharacterNumber].Life)
								{
									Data.CharacterD[Inventory._currentCharacterNumber].Cash += (int)Inventory._TradeCost;
									Data.CharacterD[CharacterMotion._curCharacter].Cash -= (int)Inventory._TradeCost;
								}
								Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[CharacterMotion.SlotEquipment].Stack -= CharacterMotion.SlotSubject.Stack;
								if (Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[CharacterMotion.SlotEquipment].Stack < 1)
								{
									Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[CharacterMotion.SlotEquipment] = new AAAAAAAAAAAAAAAAAAbi();
								}
								Inventory._currentSubject = new AAAAAAAAAAAAAAAAAAbi();
								AAAAAAAAAAAAAAAAAAAAbz();
								break;
							}
						}
					}
					if (Inventory._currentSubject.NameSubject != "None")
					{
						for (int num9 = 0; num9 < 20; num9++)
						{
							if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num9].NameSubject == "None" || Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num9] == null)
							{
								Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num9] = CharacterMotion.SlotSubject;
								Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
								Inventory.SoundMenu.Play();
								Inventory._currentSubject = new AAAAAAAAAAAAAAAAAAbi();
								Object.Destroy(GameObject.Find("InventoryInformation"));
								if (Data.CharacterD[Inventory._currentCharacterNumber].Life)
								{
									Data.CharacterD[Inventory._currentCharacterNumber].Cash += (int)Inventory._TradeCost;
									Data.CharacterD[CharacterMotion._curCharacter].Cash -= (int)Inventory._TradeCost;
								}
								Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[CharacterMotion.SlotEquipment].Stack -= CharacterMotion.SlotSubject.Stack;
								if (Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[CharacterMotion.SlotEquipment].Stack < 1)
								{
									Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[CharacterMotion.SlotEquipment] = new AAAAAAAAAAAAAAAAAAbi();
								}
								AAAAAAAAAAAAAAAAAAAAbz();
								break;
							}
						}
					}
					if (Inventory._currentSubject.NameSubject != "None")
					{
						Inventory.MessagePanel("В рюкзаке недостаточно места.");
					}
				}
				else
				{
					Inventory.MessagePanel("Недостаточно денег.");
				}
			}
			if (CharacterMotion.DealerPanel)
			{
				if (Inventory._TradeCost <= (float)Data.CharacterD[CharacterMotion._curCharacter].Cash)
				{
					if (Inventory._currentSubject.TypeSubj != AAAAAAAAAAAAAAAAAAk.TypeSubject.Suit && Inventory._currentSubject.TypeSubj != AAAAAAAAAAAAAAAAAAk.TypeSubject.Weapon)
					{
						for (int num10 = 0; num10 < 20; num10++)
						{
							if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num10].NameSubject == Inventory._currentSubject.NameSubject && Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num10].State == Inventory._currentSubject.State)
							{
								Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num10].Stack += CharacterMotion.SlotSubject.Stack;
								Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
								Inventory.SoundMenu.Play();
								Inventory._currentSubject = new AAAAAAAAAAAAAAAAAAbi();
								Object.Destroy(GameObject.Find("InventoryInformation"));
								Data.CharacterD[CharacterMotion._curCharacter].Cash -= (int)Inventory._TradeCost;
								AAAAAAAAAAAAAAAAAAAAbz();
								break;
							}
						}
					}
					if (Inventory._currentSubject.NameSubject != "None")
					{
						for (int num11 = 0; num11 < 20; num11++)
						{
							if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num11].NameSubject == "None" || Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num11] == null)
							{
								Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num11] = CharacterMotion.SlotSubject;
								Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
								Inventory.SoundMenu.Play();
								Inventory._currentSubject = new AAAAAAAAAAAAAAAAAAbi();
								CharacterMotion.SlotSubject = new AAAAAAAAAAAAAAAAAAbi();
								Object.Destroy(GameObject.Find("InventoryInformation"));
								Data.CharacterD[CharacterMotion._curCharacter].Cash -= (int)Inventory._TradeCost;
								AAAAAAAAAAAAAAAAAAAAbz();
								break;
							}
						}
					}
					if (Inventory._currentSubject.NameSubject != "None")
					{
						Inventory.MessagePanel("В рюкзаке недостаточно места.");
					}
				}
				else
				{
					Inventory.MessagePanel("Недостаточно денег.");
				}
			}
		}
		if (base.gameObject.transform.GetChild(0).GetComponent<Text>().text == "Продать")
		{
			if (CharacterMotion.NPSPanel)
			{
				if ((float)Data.CharacterD[Inventory._currentCharacterNumber].Cash >= Inventory._TradeCost || !Data.CharacterD[Inventory._currentCharacterNumber].Life)
				{
					if (Inventory._currentSubject.TypeSubj != AAAAAAAAAAAAAAAAAAk.TypeSubject.Suit && Inventory._currentSubject.TypeSubj != AAAAAAAAAAAAAAAAAAk.TypeSubject.Weapon)
					{
						for (int num12 = 0; num12 < 20; num12++)
						{
							if (!(Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[num12].NameSubject == Inventory._currentSubject.NameSubject) || Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[num12].State != Inventory._currentSubject.State)
							{
								continue;
							}
							Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[num12].Stack += CharacterMotion.SlotSubject.Stack;
							if (Data.CharacterD[Inventory._currentCharacterNumber].Life)
							{
								Data.CharacterD[Inventory._currentCharacterNumber].Cash -= (int)Inventory._TradeCost;
								Data.CharacterD[CharacterMotion._curCharacter].Cash += (int)Inventory._TradeCost;
							}
							Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
							Inventory.SoundMenu.Play();
							Inventory._currentSubject = new AAAAAAAAAAAAAAAAAAbi();
							Object.Destroy(GameObject.Find("InventoryInformation"));
							if (CharacterMotion.SlotEquipment >= 0)
							{
								Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].Stack -= CharacterMotion.SlotSubject.Stack;
								if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].Stack < 1)
								{
									Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment] = new AAAAAAAAAAAAAAAAAAbi();
								}
							}
							if (CharacterMotion.SlotEquipment == -1)
							{
								Data.CharacterD[CharacterMotion._curCharacter].SuitChar = new AAAAAAAAAAAAAAAAr();
							}
							if (CharacterMotion.SlotEquipment == -2)
							{
								Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new AAAAAAAAAAAAAAAAAAbi();
							}
							if (CharacterMotion.SlotEquipment == -3)
							{
								Data.CharacterD[CharacterMotion._curCharacter].DetectorChar = new AAAAAAAAAAAAAAAAAAbi();
							}
							if (CharacterMotion.SlotEquipment == -4)
							{
								Data.CharacterD[CharacterMotion._curCharacter].ArtChar = new AAAAAAAAAAAAAAAAAAbi();
								Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[0] = new AAAAAAAAAAAAAAAAAAbi();
							}
							if (CharacterMotion.SlotEquipment == -5)
							{
								Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[1] = new AAAAAAAAAAAAAAAAAAbi();
							}
							if (CharacterMotion.SlotEquipment == -6)
							{
								Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[2] = new AAAAAAAAAAAAAAAAAAbi();
							}
							if (CharacterMotion.SlotEquipment == -7)
							{
								Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[3] = new AAAAAAAAAAAAAAAAAAbi();
							}
							AAAAAAAAAAAAAAAAAAAAbz();
							break;
						}
					}
					if (Inventory._currentSubject.NameSubject != "None")
					{
						for (int num13 = 0; num13 < 20; num13++)
						{
							if (!(Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[num13].NameSubject == "None") && Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[num13] != null)
							{
								continue;
							}
							Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[num13] = CharacterMotion.SlotSubject;
							if (Data.CharacterD[Inventory._currentCharacterNumber].Life)
							{
								Data.CharacterD[Inventory._currentCharacterNumber].Cash -= (int)Inventory._TradeCost;
								Data.CharacterD[CharacterMotion._curCharacter].Cash += (int)Inventory._TradeCost;
							}
							Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
							Inventory.SoundMenu.Play();
							Inventory._currentSubject = new AAAAAAAAAAAAAAAAAAbi();
							Object.Destroy(GameObject.Find("InventoryInformation"));
							if (CharacterMotion.SlotEquipment >= 0)
							{
								Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].Stack--;
								if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].Stack < 1)
								{
									Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment] = new AAAAAAAAAAAAAAAAAAbi();
								}
							}
							if (CharacterMotion.SlotEquipment == -1)
							{
								Data.CharacterD[CharacterMotion._curCharacter].SuitChar = new AAAAAAAAAAAAAAAAr();
							}
							if (CharacterMotion.SlotEquipment == -2)
							{
								Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new AAAAAAAAAAAAAAAAAAbi();
							}
							if (CharacterMotion.SlotEquipment == -3)
							{
								Data.CharacterD[CharacterMotion._curCharacter].DetectorChar = new AAAAAAAAAAAAAAAAAAbi();
							}
							if (CharacterMotion.SlotEquipment == -4)
							{
								Data.CharacterD[CharacterMotion._curCharacter].ArtChar = new AAAAAAAAAAAAAAAAAAbi();
								Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[0] = new AAAAAAAAAAAAAAAAAAbi();
							}
							if (CharacterMotion.SlotEquipment == -5)
							{
								Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[1] = new AAAAAAAAAAAAAAAAAAbi();
							}
							if (CharacterMotion.SlotEquipment == -6)
							{
								Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[2] = new AAAAAAAAAAAAAAAAAAbi();
							}
							if (CharacterMotion.SlotEquipment == -7)
							{
								Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[3] = new AAAAAAAAAAAAAAAAAAbi();
							}
							AAAAAAAAAAAAAAAAAAAAbz();
							break;
						}
					}
					if (Inventory._currentSubject.NameSubject != "None")
					{
						Inventory.MessagePanel("Для предмета нет места");
					}
				}
				else if (Data.CharacterD[Inventory._currentCharacterNumber].TypeChInt != 9 && Data.CharacterD[Inventory._currentCharacterNumber].TypeChInt != 10 && Data.CharacterD[Inventory._currentCharacterNumber].Life)
				{
					Inventory.MessagePanel("У персонажа недостаточно денег");
				}
			}
			if (CharacterMotion.DealerPanel)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += (int)Inventory._TradeCost;
				Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
				Inventory.SoundMenu.Play();
				Inventory._currentSubject = new AAAAAAAAAAAAAAAAAAbi();
				Object.Destroy(GameObject.Find("InventoryInformation"));
				if (CharacterMotion.SlotEquipment >= 0)
				{
					Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].Stack -= CharacterMotion.SlotSubject.Stack;
					if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].Stack < 1)
					{
						Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment] = new AAAAAAAAAAAAAAAAAAbi();
					}
				}
				if (CharacterMotion.SlotEquipment == -1)
				{
					Data.CharacterD[CharacterMotion._curCharacter].SuitChar = new AAAAAAAAAAAAAAAAr();
				}
				if (CharacterMotion.SlotEquipment == -2)
				{
					Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new AAAAAAAAAAAAAAAAAAbi();
				}
				if (CharacterMotion.SlotEquipment == -3)
				{
					Data.CharacterD[CharacterMotion._curCharacter].DetectorChar = new AAAAAAAAAAAAAAAAAAbi();
				}
				if (CharacterMotion.SlotEquipment == -4)
				{
					Data.CharacterD[CharacterMotion._curCharacter].ArtChar = new AAAAAAAAAAAAAAAAAAbi();
					Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[0] = new AAAAAAAAAAAAAAAAAAbi();
				}
				if (CharacterMotion.SlotEquipment == -5)
				{
					Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[1] = new AAAAAAAAAAAAAAAAAAbi();
				}
				if (CharacterMotion.SlotEquipment == -6)
				{
					Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[2] = new AAAAAAAAAAAAAAAAAAbi();
				}
				if (CharacterMotion.SlotEquipment == -7)
				{
					Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[3] = new AAAAAAAAAAAAAAAAAAbi();
				}
				AAAAAAAAAAAAAAAAAAAAbz();
			}
		}
		if (base.gameObject.transform.GetChild(0).GetComponent<Text>().text == "Оставить")
		{
			if (CharacterMotion.NPSPanel)
			{
				if (Inventory._currentSubject.TypeSubj != AAAAAAAAAAAAAAAAAAk.TypeSubject.Suit && Inventory._currentSubject.TypeSubj != AAAAAAAAAAAAAAAAAAk.TypeSubject.Weapon)
				{
					for (int num14 = 0; num14 < 20; num14++)
					{
						if (!(Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[num14].NameSubject == Inventory._currentSubject.NameSubject))
						{
							continue;
						}
						Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[num14].Stack += CharacterMotion.SlotSubject.Stack;
						Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
						Inventory.SoundMenu.Play();
						Inventory._currentSubject = new AAAAAAAAAAAAAAAAAAbi();
						Object.Destroy(GameObject.Find("InventoryInformation"));
						if (CharacterMotion.SlotEquipment >= 0)
						{
							Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].Stack -= CharacterMotion.SlotSubject.Stack;
							if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].Stack < 1)
							{
								Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment] = new AAAAAAAAAAAAAAAAAAbi();
							}
						}
						if (CharacterMotion.SlotEquipment == -1)
						{
							Data.CharacterD[CharacterMotion._curCharacter].SuitChar = new AAAAAAAAAAAAAAAAr();
						}
						if (CharacterMotion.SlotEquipment == -2)
						{
							Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new AAAAAAAAAAAAAAAAAAbi();
						}
						if (CharacterMotion.SlotEquipment == -3)
						{
							Data.CharacterD[CharacterMotion._curCharacter].DetectorChar = new AAAAAAAAAAAAAAAAAAbi();
						}
						if (CharacterMotion.SlotEquipment == -4)
						{
							Data.CharacterD[CharacterMotion._curCharacter].ArtChar = new AAAAAAAAAAAAAAAAAAbi();
							Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[0] = new AAAAAAAAAAAAAAAAAAbi();
						}
						if (CharacterMotion.SlotEquipment == -5)
						{
							Data.CharacterD[CharacterMotion._curCharacter].ArtChar = new AAAAAAAAAAAAAAAAAAbi();
							Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[1] = new AAAAAAAAAAAAAAAAAAbi();
						}
						if (CharacterMotion.SlotEquipment == -6)
						{
							Data.CharacterD[CharacterMotion._curCharacter].ArtChar = new AAAAAAAAAAAAAAAAAAbi();
							Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[2] = new AAAAAAAAAAAAAAAAAAbi();
						}
						if (CharacterMotion.SlotEquipment == -7)
						{
							Data.CharacterD[CharacterMotion._curCharacter].ArtChar = new AAAAAAAAAAAAAAAAAAbi();
							Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[3] = new AAAAAAAAAAAAAAAAAAbi();
						}
						AAAAAAAAAAAAAAAAAAAAbz();
						break;
					}
				}
				if (Inventory._currentSubject.NameSubject != "None")
				{
					for (int num15 = 0; num15 < 20; num15++)
					{
						if (!(Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[num15].NameSubject == "None") && Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[num15] != null)
						{
							continue;
						}
						Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[num15] = CharacterMotion.SlotSubject;
						Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
						Inventory.SoundMenu.Play();
						Inventory._currentSubject = new AAAAAAAAAAAAAAAAAAbi();
						Object.Destroy(GameObject.Find("InventoryInformation"));
						if (CharacterMotion.SlotEquipment >= 0)
						{
							Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].Stack -= CharacterMotion.SlotSubject.Stack;
							if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].Stack < 1)
							{
								Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment] = new AAAAAAAAAAAAAAAAAAbi();
							}
						}
						if (CharacterMotion.SlotEquipment == -1)
						{
							Data.CharacterD[CharacterMotion._curCharacter].SuitChar = new AAAAAAAAAAAAAAAAr();
						}
						if (CharacterMotion.SlotEquipment == -2)
						{
							Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new AAAAAAAAAAAAAAAAAAbi();
						}
						if (CharacterMotion.SlotEquipment == -3)
						{
							Data.CharacterD[CharacterMotion._curCharacter].DetectorChar = new AAAAAAAAAAAAAAAAAAbi();
						}
						if (CharacterMotion.SlotEquipment == -4)
						{
							Data.CharacterD[CharacterMotion._curCharacter].ArtChar = new AAAAAAAAAAAAAAAAAAbi();
							Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[0] = new AAAAAAAAAAAAAAAAAAbi();
						}
						if (CharacterMotion.SlotEquipment == -5)
						{
							Data.CharacterD[CharacterMotion._curCharacter].ArtChar = new AAAAAAAAAAAAAAAAAAbi();
							Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[1] = new AAAAAAAAAAAAAAAAAAbi();
						}
						if (CharacterMotion.SlotEquipment == -6)
						{
							Data.CharacterD[CharacterMotion._curCharacter].ArtChar = new AAAAAAAAAAAAAAAAAAbi();
							Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[2] = new AAAAAAAAAAAAAAAAAAbi();
						}
						if (CharacterMotion.SlotEquipment == -7)
						{
							Data.CharacterD[CharacterMotion._curCharacter].ArtChar = new AAAAAAAAAAAAAAAAAAbi();
							Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[3] = new AAAAAAAAAAAAAAAAAAbi();
						}
						AAAAAAAAAAAAAAAAAAAAbz();
						break;
					}
				}
				if (Inventory._currentSubject.NameSubject != "None")
				{
					Inventory.MessagePanel("Для предмета нет места");
				}
			}
			if (CharacterMotion.CachePanel)
			{
				if (Inventory._currentSubject.TypeSubj != AAAAAAAAAAAAAAAAAAk.TypeSubject.Suit && Inventory._currentSubject.TypeSubj != AAAAAAAAAAAAAAAAAAk.TypeSubject.Weapon)
				{
					for (int num16 = 0; num16 < 20; num16++)
					{
						if (!(Data.Points[Inventory._CurrentPoint[0]].Cache[num16].NameSubject == Inventory._currentSubject.NameSubject))
						{
							continue;
						}
						Data.Points[Inventory._CurrentPoint[0]].Cache[num16].Stack += CharacterMotion.SlotSubject.Stack;
						Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
						Inventory.SoundMenu.Play();
						Inventory._currentSubject = new AAAAAAAAAAAAAAAAAAbi();
						Object.Destroy(GameObject.Find("InventoryInformation"));
						if (CharacterMotion.SlotEquipment >= 0)
						{
							Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].Stack -= CharacterMotion.SlotSubject.Stack;
							if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].Stack < 1)
							{
								Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment] = new AAAAAAAAAAAAAAAAAAbi();
							}
						}
						if (CharacterMotion.SlotEquipment == -1)
						{
							Data.CharacterD[CharacterMotion._curCharacter].SuitChar = new AAAAAAAAAAAAAAAAr();
						}
						if (CharacterMotion.SlotEquipment == -2)
						{
							Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new AAAAAAAAAAAAAAAAAAbi();
						}
						if (CharacterMotion.SlotEquipment == -3)
						{
							Data.CharacterD[CharacterMotion._curCharacter].DetectorChar = new AAAAAAAAAAAAAAAAAAbi();
						}
						if (CharacterMotion.SlotEquipment == -4)
						{
							Data.CharacterD[CharacterMotion._curCharacter].ArtChar = new AAAAAAAAAAAAAAAAAAbi();
							Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[0] = new AAAAAAAAAAAAAAAAAAbi();
						}
						if (CharacterMotion.SlotEquipment == -5)
						{
							Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[1] = new AAAAAAAAAAAAAAAAAAbi();
						}
						if (CharacterMotion.SlotEquipment == -6)
						{
							Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[2] = new AAAAAAAAAAAAAAAAAAbi();
						}
						if (CharacterMotion.SlotEquipment == -7)
						{
							Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[3] = new AAAAAAAAAAAAAAAAAAbi();
						}
						AAAAAAAAAAAAAAAAAAAAbz();
						break;
					}
				}
				if (Inventory._currentSubject.NameSubject != "None")
				{
					for (int num17 = 0; num17 < 20; num17++)
					{
						if (!(Data.Points[Inventory._CurrentPoint[0]].Cache[num17].NameSubject == "None") && Data.Points[Inventory._CurrentPoint[0]].Cache[num17] != null)
						{
							continue;
						}
						Data.Points[Inventory._CurrentPoint[0]].Cache[num17] = CharacterMotion.SlotSubject;
						Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
						Inventory.SoundMenu.Play();
						Inventory._currentSubject = new AAAAAAAAAAAAAAAAAAbi();
						Object.Destroy(GameObject.Find("InventoryInformation"));
						if (CharacterMotion.SlotEquipment >= 0)
						{
							Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].Stack -= CharacterMotion.SlotSubject.Stack;
							if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].Stack < 1)
							{
								Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment] = new AAAAAAAAAAAAAAAAAAbi();
							}
						}
						if (CharacterMotion.SlotEquipment == -1)
						{
							Data.CharacterD[CharacterMotion._curCharacter].SuitChar = new AAAAAAAAAAAAAAAAr();
						}
						if (CharacterMotion.SlotEquipment == -2)
						{
							Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new AAAAAAAAAAAAAAAAAAbi();
						}
						if (CharacterMotion.SlotEquipment == -3)
						{
							Data.CharacterD[CharacterMotion._curCharacter].DetectorChar = new AAAAAAAAAAAAAAAAAAbi();
						}
						if (CharacterMotion.SlotEquipment == -4)
						{
							Data.CharacterD[CharacterMotion._curCharacter].ArtChar = new AAAAAAAAAAAAAAAAAAbi();
							Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[0] = new AAAAAAAAAAAAAAAAAAbi();
						}
						if (CharacterMotion.SlotEquipment == -5)
						{
							Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[1] = new AAAAAAAAAAAAAAAAAAbi();
						}
						if (CharacterMotion.SlotEquipment == -6)
						{
							Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[2] = new AAAAAAAAAAAAAAAAAAbi();
						}
						if (CharacterMotion.SlotEquipment == -7)
						{
							Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[3] = new AAAAAAAAAAAAAAAAAAbi();
						}
						AAAAAAAAAAAAAAAAAAAAbz();
						break;
					}
				}
				if (Inventory._currentSubject.NameSubject != "None")
				{
					Inventory.MessagePanel("Для предмета нет места");
				}
			}
		}
		if (base.gameObject.transform.GetChild(0).GetComponent<Text>().text == "Забрать")
		{
			if (CharacterMotion.NPSPanel)
			{
				if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Money)
				{
					Data.CharacterD[CharacterMotion._curCharacter].Cash += Data.CharacterD[Inventory._currentCharacterNumber].Cash;
					Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[CharacterMotion.SlotEquipment] = new AAAAAAAAAAAAAAAAAAbi();
					Data.CharacterD[Inventory._currentCharacterNumber].Cash = 0;
					Object.Destroy(GameObject.Find("InventoryInformation"));
					AAAAAAAAAAAAAAAAAAAAbz();
				}
				else
				{
					if (Inventory._currentSubject.TypeSubj != AAAAAAAAAAAAAAAAAAk.TypeSubject.Suit && Inventory._currentSubject.TypeSubj != AAAAAAAAAAAAAAAAAAk.TypeSubject.Weapon)
					{
						for (int num18 = 0; num18 < 20; num18++)
						{
							if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num18].NameSubject == Inventory._currentSubject.NameSubject)
							{
								Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num18].Stack += CharacterMotion.SlotSubject.Stack;
								Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
								Inventory.SoundMenu.Play();
								Inventory._currentSubject = new AAAAAAAAAAAAAAAAAAbi();
								Object.Destroy(GameObject.Find("InventoryInformation"));
								Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[CharacterMotion.SlotEquipment].Stack -= CharacterMotion.SlotSubject.Stack;
								if (Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[CharacterMotion.SlotEquipment].Stack < 1)
								{
									Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[CharacterMotion.SlotEquipment] = new AAAAAAAAAAAAAAAAAAbi();
								}
								AAAAAAAAAAAAAAAAAAAAbz();
								break;
							}
						}
					}
					if (Inventory._currentSubject.NameSubject != "None")
					{
						for (int num19 = 0; num19 < 20; num19++)
						{
							if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num19].NameSubject == "None" || Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num19] == null)
							{
								Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num19] = CharacterMotion.SlotSubject;
								Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
								Inventory.SoundMenu.Play();
								Inventory._currentSubject = new AAAAAAAAAAAAAAAAAAbi();
								Object.Destroy(GameObject.Find("InventoryInformation"));
								Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[CharacterMotion.SlotEquipment].Stack -= CharacterMotion.SlotSubject.Stack;
								if (Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[CharacterMotion.SlotEquipment].Stack < 1)
								{
									Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[CharacterMotion.SlotEquipment] = new AAAAAAAAAAAAAAAAAAbi();
								}
								AAAAAAAAAAAAAAAAAAAAbz();
								break;
							}
						}
					}
					if (Inventory._currentSubject.NameSubject != "None")
					{
						Inventory.MessagePanel("В рюкзаке недостаточно места.");
					}
				}
			}
			if (CharacterMotion.CachePanel)
			{
				if (Inventory._currentSubject.TypeSubj != AAAAAAAAAAAAAAAAAAk.TypeSubject.Suit && Inventory._currentSubject.TypeSubj != AAAAAAAAAAAAAAAAAAk.TypeSubject.Weapon)
				{
					for (int num20 = 0; num20 < 20; num20++)
					{
						if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num20].NameSubject == Inventory._currentSubject.NameSubject)
						{
							Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num20].Stack += CharacterMotion.SlotSubject.Stack;
							Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
							Inventory.SoundMenu.Play();
							Inventory._currentSubject = new AAAAAAAAAAAAAAAAAAbi();
							Object.Destroy(GameObject.Find("InventoryInformation"));
							Data.Points[Inventory._CurrentPoint[0]].Cache[CharacterMotion.SlotEquipment].Stack -= CharacterMotion.SlotSubject.Stack;
							if (Data.Points[Inventory._CurrentPoint[0]].Cache[CharacterMotion.SlotEquipment].Stack < 1)
							{
								Data.Points[Inventory._CurrentPoint[0]].Cache[CharacterMotion.SlotEquipment] = new AAAAAAAAAAAAAAAAAAbi();
							}
							AAAAAAAAAAAAAAAAAAAAbz();
							break;
						}
					}
				}
				if (Inventory._currentSubject.NameSubject != "None")
				{
					for (int num21 = 0; num21 < 20; num21++)
					{
						if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num21].NameSubject == "None" || Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num21] == null)
						{
							Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num21] = CharacterMotion.SlotSubject;
							Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
							Inventory.SoundMenu.Play();
							Inventory._currentSubject = new AAAAAAAAAAAAAAAAAAbi();
							Object.Destroy(GameObject.Find("InventoryInformation"));
							Data.Points[Inventory._CurrentPoint[0]].Cache[CharacterMotion.SlotEquipment].Stack -= CharacterMotion.SlotSubject.Stack;
							if (Data.Points[Inventory._CurrentPoint[0]].Cache[CharacterMotion.SlotEquipment].Stack < 1)
							{
								Data.Points[Inventory._CurrentPoint[0]].Cache[CharacterMotion.SlotEquipment] = new AAAAAAAAAAAAAAAAAAbi();
							}
							AAAAAAAAAAAAAAAAAAAAbz();
							break;
						}
					}
				}
				if (Inventory._currentSubject.NameSubject != "None")
				{
					Inventory.MessagePanel("В рюкзаке недостаточно места.");
				}
			}
			if (CharacterMotion.RewardPanel)
			{
				if (Inventory._currentSubject.TypeSubj != AAAAAAAAAAAAAAAAAAk.TypeSubject.Suit && Inventory._currentSubject.TypeSubj != AAAAAAAAAAAAAAAAAAk.TypeSubject.Weapon)
				{
					for (int num22 = 0; num22 < 20; num22++)
					{
						if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num22].NameSubject == Inventory._currentSubject.NameSubject && Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num22].State == Inventory._currentSubject.State)
						{
							Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num22].Stack++;
							Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
							Inventory.SoundMenu.Play();
							Inventory._currentSubject = new AAAAAAAAAAAAAAAAAAbi();
							Object.Destroy(GameObject.Find("InventoryInformation"));
							Inventory._RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
							AAAAAAAAAAAAAAAAAAAAbz();
							break;
						}
					}
				}
				if (Inventory._currentSubject.NameSubject != "None")
				{
					for (int num23 = 0; num23 < 20; num23++)
					{
						if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num23].NameSubject == "None" || Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num23] == null)
						{
							Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num23] = CharacterMotion.SlotSubject;
							Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
							Inventory.SoundMenu.Play();
							Inventory._currentSubject = new AAAAAAAAAAAAAAAAAAbi();
							Object.Destroy(GameObject.Find("InventoryInformation"));
							Inventory._RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
							AAAAAAAAAAAAAAAAAAAAbz();
							break;
						}
					}
				}
				if (Inventory._currentSubject.NameSubject != "None")
				{
					Inventory.MessagePanel("В рюкзаке недостаточно места.");
				}
			}
		}
		if (base.gameObject.transform.GetChild(0).GetComponent<Text>().text == "Ремонтировать" && Data.CharacterD[CharacterMotion._curCharacter].Cash >= (int)Inventory._TradeCost)
		{
			Data.CharacterD[CharacterMotion._curCharacter].Cash -= (int)Inventory._TradeCost;
			if (CharacterMotion.SlotEquipment >= 0)
			{
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].State = 100f;
			}
			if (CharacterMotion.SlotEquipment == -1)
			{
				Data.CharacterD[CharacterMotion._curCharacter].SuitChar.State = 100f;
			}
			if (CharacterMotion.SlotEquipment == -2)
			{
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.State = 100f;
			}
			if (CharacterMotion.SlotEquipment == -3)
			{
				Data.CharacterD[CharacterMotion._curCharacter].DetectorChar.State = 100f;
			}
			if (CharacterMotion.SlotEquipment == -4)
			{
				Data.CharacterD[CharacterMotion._curCharacter].ArtChar.State = 100f;
			}
			if (CharacterMotion.SlotEquipment == -4)
			{
				Data.CharacterD[CharacterMotion._curCharacter].ArtChar.State = 100f;
				Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[0].State = 100f;
			}
			if (CharacterMotion.SlotEquipment == -5)
			{
				Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[1].State = 100f;
			}
			if (CharacterMotion.SlotEquipment == -6)
			{
				Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[2].State = 100f;
			}
			if (CharacterMotion.SlotEquipment == -7)
			{
				Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[3].State = 100f;
			}
			if (Inventory._currentSubject.AudioReload != null)
			{
				Inventory.SoundMenu.clip = Inventory._currentSubject.AudioReload;
			}
			else
			{
				Inventory.SoundMenu.clip = Inventory._currentSubject.AudioSlot;
			}
			Inventory.SoundMenu.Play();
			Object.Destroy(GameObject.Find("InventoryInformation"));
		}
		if (base.gameObject.transform.GetChild(0).GetComponent<Text>().text == "Улучшить" && Inventory._currentSubject.NameSubject != "Свитер")
		{
			GameObject gameObject5 = GameObject.Find("InventoryInformation");
			GameObject gameObject6 = Object.Instantiate(gameObject5.transform.GetChild(3).gameObject);
			for (int num24 = 0; num24 < gameObject6.transform.childCount; num24++)
			{
				Object.Destroy(gameObject6.transform.GetChild(num24).gameObject);
			}
			gameObject6.transform.SetParent(gameObject5.transform);
			gameObject6.transform.position = new Vector3(Screen.width / 2, Screen.height / 2);
			gameObject6.GetComponent<GridLayoutGroup>().cellSize = new Vector2(820f, 90f);
			gameObject6.GetComponent<GridLayoutGroup>().spacing = new Vector2(10f, 1f);
			gameObject6.GetComponent<GridLayoutGroup>().constraint = GridLayoutGroup.Constraint.FixedColumnCount;
			if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Suit)
			{
				if (Inventory._currentSubject.ArtContainer <= 3)
				{
					GameObject gameObject7 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/ButtonUpGrade"));
					gameObject7.transform.SetParent(gameObject6.transform);
					gameObject7.transform.GetChild(0).GetComponent<Text>().text = "Установить контейнер для артефактов: 10000 ru";
					gameObject7.transform.GetChild(1).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/Upgrade/SuitUpGradeAddContainer");
					gameObject7.transform.SetParent(gameObject6.transform);
				}
				if (Inventory._currentSubject.WeightUpGrade == 0f)
				{
					GameObject gameObject7 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/ButtonUpGrade"));
					gameObject7.transform.SetParent(gameObject6.transform);
					gameObject7.transform.GetChild(0).GetComponent<Text>().text = "Заменить материалы и элементы на облегченные аналоги (вес -1 кг): 6000 ru";
					gameObject7.transform.GetChild(1).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/Upgrade/SuitUpGradeWeight");
					gameObject7.transform.SetParent(gameObject6.transform);
				}
				if (Inventory._currentSubject.UpGrade == 0f)
				{
					GameObject gameObject7 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/ButtonUpGrade"));
					gameObject7.transform.SetParent(gameObject6.transform);
					gameObject7.transform.GetChild(0).GetComponent<Text>().text = "Установить кевларовые пластины (защита +8): 6000 ru";
					gameObject7.transform.GetChild(1).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/Upgrade/SuitUpGradeProtection");
					gameObject7.transform.SetParent(gameObject6.transform);
				}
			}
			if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Weapon)
			{
				if (Inventory._currentSubject.PossibilityOfInstallation && !Inventory._currentSubject.SightInstallation)
				{
					GameObject gameObject7 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/ButtonUpGrade"));
					gameObject7.transform.SetParent(gameObject6.transform);
					gameObject7.transform.GetChild(0).GetComponent<Text>().text = "Установить улучшенный прицел (дальность +1): 8000 ru";
					gameObject7.transform.GetChild(1).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/Upgrade/WeaponUpGradeSightInstallation");
					gameObject7.transform.SetParent(gameObject6.transform);
				}
				if (Inventory._currentSubject.WeightUpGrade == 0f)
				{
					if (Inventory._currentSubject.WeightSubject > 1.5f)
					{
						GameObject gameObject7 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/ButtonUpGrade"));
						gameObject7.transform.SetParent(gameObject6.transform);
						gameObject7.transform.GetChild(0).GetComponent<Text>().text = "Заменить материалы и элементы на облегченные аналоги (вес -0.5 кг): 6000 ru";
						gameObject7.transform.GetChild(1).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/Upgrade/WeaponUpGradeWeight");
						gameObject7.transform.SetParent(gameObject6.transform);
					}
					else
					{
						GameObject gameObject7 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/ButtonUpGrade"));
						gameObject7.transform.SetParent(gameObject6.transform);
						gameObject7.transform.GetChild(0).GetComponent<Text>().text = "Заменить материалы и элементы на облегченные аналоги (вес -0.2 кг): 1500 ru";
						gameObject7.transform.GetChild(1).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/Upgrade/WeaponUpGradeWeight");
						gameObject7.transform.SetParent(gameObject6.transform);
					}
				}
				if (Inventory._currentSubject.UpGrade == 0f)
				{
					if (Inventory._currentSubject.WeightSubject > 1.5f)
					{
						GameObject gameObject7 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/ButtonUpGrade"));
						gameObject7.transform.SetParent(gameObject6.transform);
						gameObject7.transform.GetChild(0).GetComponent<Text>().text = "Увеличить настильность (повреждение +2): 8000 ru";
						gameObject7.transform.GetChild(1).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/Upgrade/WeaponUpGradeDamage");
						gameObject7.transform.SetParent(gameObject6.transform);
					}
					else
					{
						GameObject gameObject7 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/ButtonUpGrade"));
						gameObject7.transform.SetParent(gameObject6.transform);
						gameObject7.transform.GetChild(0).GetComponent<Text>().text = "Увеличить настильность (повреждение +1): 2000 ru";
						gameObject7.transform.GetChild(1).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/Upgrade/WeaponUpGradeDamage");
						gameObject7.transform.SetParent(gameObject6.transform);
					}
				}
			}
		}
		if (base.gameObject.transform.GetChild(0).GetComponent<Text>().text == "Разрядить")
		{
			for (int num25 = 0; num25 < 20; num25++)
			{
				if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num25].NameSubject == Inventory._currentSubject.CartridgeType)
				{
					Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num25].Stack += CharacterMotion.SlotSubject.Cartridge;
					CharacterMotion.SlotSubject.Cartridge = 0;
					if (CharacterMotion.SlotEquipment >= 0)
					{
						Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].Cartridge = 0;
					}
					if (CharacterMotion.SlotEquipment == -2)
					{
						Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Cartridge = 0;
					}
					Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
					Inventory.SoundMenu.Play();
					Inventory._currentSubject = new AAAAAAAAAAAAAAAAAAbi();
					Object.Destroy(GameObject.Find("InventoryInformation"));
					AAAAAAAAAAAAAAAAAAAbo();
					break;
				}
			}
			if (Inventory._currentSubject.NameSubject != "None")
			{
				for (int num26 = 0; num26 < 20; num26++)
				{
					if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num26].NameSubject == "None" || Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num26] == null)
					{
						AAAAAAAAAAAAAAAAbo();
						Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num26] = CharacterMotion.SlotSubject;
						CharacterMotion.SlotSubject.Cartridge = 0;
						if (CharacterMotion.SlotEquipment >= 0)
						{
							Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num26].Stack += Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].Cartridge;
							Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].Cartridge = 0;
						}
						if (CharacterMotion.SlotEquipment == -2)
						{
							Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[num26].Stack += Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Cartridge;
							Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Cartridge = 0;
						}
						Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
						Inventory.SoundMenu.Play();
						Inventory._currentSubject = new AAAAAAAAAAAAAAAAAAbi();
						Object.Destroy(GameObject.Find("InventoryInformation"));
						AAAAAAAAAAAAAAAAAAAbo();
						break;
					}
				}
			}
			if (Inventory._currentSubject.NameSubject != "None")
			{
				Inventory.MessagePanel("В рюкзаке недостаточно места.");
			}
		}
		if (base.gameObject.transform.GetChild(0).GetComponent<Text>().text == "Установить контейнер для артефактов: 10000 ru")
		{
			if (Data.CharacterD[CharacterMotion._curCharacter].Cash >= 10000)
			{
				if (CharacterMotion.SlotEquipment == -1)
				{
					Data.CharacterD[CharacterMotion._curCharacter].SuitChar.ArtContainer++;
					Data.CharacterD[CharacterMotion._curCharacter].SuitChar.SingModification = true;
				}
				if (CharacterMotion.SlotEquipment >= 0)
				{
					Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].ArtContainer++;
					Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].SingModification = true;
				}
				Data.CharacterD[CharacterMotion._curCharacter].Cash -= 10000;
			}
			else
			{
				Inventory.MessagePanel("Недостаточно денег.");
			}
			Object.Destroy(GameObject.Find("InventoryInformation"));
		}
		if (base.gameObject.transform.GetChild(0).GetComponent<Text>().text == "Заменить материалы и элементы на облегченные аналоги (вес -1 кг): 6000 ru")
		{
			if (Data.CharacterD[CharacterMotion._curCharacter].Cash >= 6000)
			{
				if (CharacterMotion.SlotEquipment == -1)
				{
					Data.CharacterD[CharacterMotion._curCharacter].SuitChar.WeightUpGrade--;
					Data.CharacterD[CharacterMotion._curCharacter].SuitChar.SingModification = true;
				}
				if (CharacterMotion.SlotEquipment >= 0)
				{
					Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].WeightUpGrade--;
					Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].SingModification = true;
				}
				Data.CharacterD[CharacterMotion._curCharacter].Cash -= 6000;
			}
			else
			{
				Inventory.MessagePanel("Недостаточно денег.");
			}
			Object.Destroy(GameObject.Find("InventoryInformation"));
		}
		if (base.gameObject.transform.GetChild(0).GetComponent<Text>().text == "Установить кевларовые пластины (защита +8): 6000 ru")
		{
			if (Data.CharacterD[CharacterMotion._curCharacter].Cash >= 6000)
			{
				if (CharacterMotion.SlotEquipment == -1)
				{
					Data.CharacterD[CharacterMotion._curCharacter].SuitChar.UpGrade = 8f;
					Data.CharacterD[CharacterMotion._curCharacter].SuitChar.SingModification = true;
				}
				if (CharacterMotion.SlotEquipment >= 0)
				{
					Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].UpGrade = 10f;
					Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].SingModification = true;
				}
				Data.CharacterD[CharacterMotion._curCharacter].Cash -= 6000;
			}
			else
			{
				Inventory.MessagePanel("Недостаточно денег.");
			}
			Object.Destroy(GameObject.Find("InventoryInformation"));
		}
		if (base.gameObject.transform.GetChild(0).GetComponent<Text>().text == "Установить улучшенный прицел (дальность +1): 8000 ru")
		{
			if (Data.CharacterD[CharacterMotion._curCharacter].Cash >= 8000)
			{
				if (CharacterMotion.SlotEquipment == -2)
				{
					Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.SightInstallation = true;
					Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.SingModification = true;
					Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.TextureSubject = Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.TextureSubjectSniper;
				}
				if (CharacterMotion.SlotEquipment >= 0)
				{
					Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].SightInstallation = true;
					Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].SingModification = true;
					Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].TextureSubject = Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].TextureSubjectSniper;
				}
				Data.CharacterD[CharacterMotion._curCharacter].Cash -= 8000;
			}
			else
			{
				Inventory.MessagePanel("Недостаточно денег.");
			}
			Object.Destroy(GameObject.Find("InventoryInformation"));
		}
		if (base.gameObject.transform.GetChild(0).GetComponent<Text>().text == "Заменить материалы и элементы на облегченные аналоги (вес -0.5 кг): 6000 ru")
		{
			if (Data.CharacterD[CharacterMotion._curCharacter].Cash >= 6000)
			{
				if (CharacterMotion.SlotEquipment == -2)
				{
					Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.WeightUpGrade -= 0.5f;
					Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.SingModification = true;
				}
				if (CharacterMotion.SlotEquipment >= 0)
				{
					Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].WeightUpGrade -= 0.5f;
					Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].SingModification = true;
				}
				Data.CharacterD[CharacterMotion._curCharacter].Cash -= 6000;
			}
			else
			{
				Inventory.MessagePanel("Недостаточно денег.");
			}
			Object.Destroy(GameObject.Find("InventoryInformation"));
		}
		if (base.gameObject.transform.GetChild(0).GetComponent<Text>().text == "Заменить материалы и элементы на облегченные аналоги (вес -0.2 кг): 1500 ru")
		{
			if (Data.CharacterD[CharacterMotion._curCharacter].Cash >= 1500)
			{
				if (CharacterMotion.SlotEquipment == -2)
				{
					Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.WeightUpGrade -= 0.2f;
					Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.SingModification = true;
				}
				if (CharacterMotion.SlotEquipment >= 0)
				{
					Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].WeightUpGrade -= 0.2f;
					Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].SingModification = true;
				}
				Data.CharacterD[CharacterMotion._curCharacter].Cash -= 1500;
			}
			else
			{
				Inventory.MessagePanel("Недостаточно денег.");
			}
			Object.Destroy(GameObject.Find("InventoryInformation"));
		}
		if (base.gameObject.transform.GetChild(0).GetComponent<Text>().text == "Увеличить настильность (повреждение +2): 8000 ru")
		{
			if (Data.CharacterD[CharacterMotion._curCharacter].Cash >= 8000)
			{
				if (CharacterMotion.SlotEquipment == -2)
				{
					Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.UpGrade = 2f;
					Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.SingModification = true;
				}
				if (CharacterMotion.SlotEquipment >= 0)
				{
					Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].UpGrade = 2f;
					Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].SingModification = true;
				}
				Data.CharacterD[CharacterMotion._curCharacter].Cash -= 8000;
			}
			else
			{
				Inventory.MessagePanel("Недостаточно денег.");
			}
			Object.Destroy(GameObject.Find("InventoryInformation"));
		}
		if (base.gameObject.transform.GetChild(0).GetComponent<Text>().text == "Увеличить настильность (повреждение +1): 2000 ru")
		{
			if (Data.CharacterD[CharacterMotion._curCharacter].Cash >= 2000)
			{
				if (CharacterMotion.SlotEquipment == -2)
				{
					Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.UpGrade = 1f;
					Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.SingModification = true;
				}
				if (CharacterMotion.SlotEquipment >= 0)
				{
					Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].UpGrade = 1f;
					Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[CharacterMotion.SlotEquipment].SingModification = true;
				}
				Data.CharacterD[CharacterMotion._curCharacter].Cash -= 2000;
			}
			else
			{
				Inventory.MessagePanel("Недостаточно денег.");
			}
			Object.Destroy(GameObject.Find("InventoryInformation"));
		}
		AAAAAAAAAAAAAAAAAAAbo();
	}

	public static void AAAAAAAAAAAAAAAAAAAbo()
	{
		GameObject.Find("NameAndImageGG").GetComponent<RectTransform>().transform.GetChild(1).GetComponent<RawImage>().texture = Data.CharacterD[CharacterMotion._curCharacter].SuitChar.IconCharacter;
		GameObject gameObject = GameObject.Find("InfOfGG");
		gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<Text>().text = Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name;
		gameObject.GetComponent<RectTransform>().transform.GetChild(1).GetComponent<Text>().text = Data.CharacterD[CharacterMotion._curCharacter].Cash + " Ru";
		if (Data.CharacterD[CharacterMotion._curCharacter].SuitChar.NameSubject != "None")
		{
			GameObject.Find("SuitGG").transform.GetChild(0).GetComponent<RawImage>().texture = Data.CharacterD[CharacterMotion._curCharacter].SuitChar.TextureSubject;
			if (!Data.CharacterD[CharacterMotion._curCharacter].SuitChar.SingModification)
			{
				GameObject.Find("SuitGG").GetComponent<RectTransform>().transform.GetChild(1).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/OtherSprite/Slot128");
			}
			else
			{
				GameObject.Find("SuitGG").GetComponent<RectTransform>().transform.GetChild(1).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/Upgrade/UG");
			}
		}
		else
		{
			GameObject.Find("SuitGG").transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/OtherSprite/Slot128");
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.NameSubject != "None")
		{
			GameObject.Find("WeaponGG").transform.GetChild(0).GetComponent<RawImage>().texture = Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.TextureSubject;
			if (!Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.SingModification)
			{
				GameObject.Find("WeaponGG").GetComponent<RectTransform>().transform.GetChild(1).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/OtherSprite/Slot128");
			}
			else
			{
				GameObject.Find("WeaponGG").GetComponent<RectTransform>().transform.GetChild(1).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/Upgrade/UG");
			}
		}
		else
		{
			GameObject.Find("WeaponGG").transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/OtherSprite/Slot128");
			GameObject.Find("WeaponGG").GetComponent<RectTransform>().transform.GetChild(1).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/OtherSprite/Slot128");
		}
		GameObject gameObject2 = GameObject.Find("ArtPanelGG");
		if (Data.CharacterD[CharacterMotion._curCharacter].SuitChar.ArtContainer >= 1)
		{
			gameObject2.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RectTransform>().GetComponent<RawImage>()
				.texture = (Texture2D)Resources.Load("Sprites/OtherSprite/ArtSlot");
		}
		else
		{
			gameObject2.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RectTransform>().GetComponent<RawImage>()
				.texture = (Texture2D)Resources.Load("Sprites/OtherSprite/unusedSlot");
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].SuitChar.ArtContainer >= 2)
		{
			gameObject2.GetComponent<RectTransform>().transform.GetChild(1).GetComponent<RectTransform>().GetComponent<RawImage>()
				.texture = (Texture2D)Resources.Load("Sprites/OtherSprite/ArtSlot");
		}
		else
		{
			gameObject2.GetComponent<RectTransform>().transform.GetChild(1).GetComponent<RectTransform>().GetComponent<RawImage>()
				.texture = (Texture2D)Resources.Load("Sprites/OtherSprite/unusedSlot");
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].SuitChar.ArtContainer >= 3)
		{
			gameObject2.GetComponent<RectTransform>().transform.GetChild(2).GetComponent<RectTransform>().GetComponent<RawImage>()
				.texture = (Texture2D)Resources.Load("Sprites/OtherSprite/ArtSlot");
		}
		else
		{
			gameObject2.GetComponent<RectTransform>().transform.GetChild(2).GetComponent<RectTransform>().GetComponent<RawImage>()
				.texture = (Texture2D)Resources.Load("Sprites/OtherSprite/unusedSlot");
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].SuitChar.ArtContainer >= 4)
		{
			gameObject2.GetComponent<RectTransform>().transform.GetChild(3).GetComponent<RectTransform>().GetComponent<RawImage>()
				.texture = (Texture2D)Resources.Load("Sprites/OtherSprite/ArtSlot");
		}
		else
		{
			gameObject2.GetComponent<RectTransform>().transform.GetChild(3).GetComponent<RectTransform>().GetComponent<RawImage>()
				.texture = (Texture2D)Resources.Load("Sprites/OtherSprite/unusedSlot");
		}
		bool flag = false;
		gameObject2.transform.GetChild(0).transform.GetChild(0).GetComponent<RawImage>().texture = Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[0].TextureSubject;
		if (Data.CharacterD[CharacterMotion._curCharacter].SuitChar.ArtContainer == 0 && Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[0].NameSubject != "None" && Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[0].NameSubject != string.Empty && Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[0].NameSubject != null)
		{
			gameObject2.transform.GetChild(0).transform.GetChild(0).GetComponent<RawImage>().color = new Color(0.5f, 0.2f, 0.2f, 0.8f);
			gameObject2.transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().text = "радиация + 5";
			gameObject2.transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().fontSize = Screen.height / 56;
			flag = true;
		}
		else
		{
			gameObject2.transform.GetChild(0).transform.GetChild(0).GetComponent<RawImage>().color = new Color(1f, 1f, 1f, 1f);
			gameObject2.transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().text = string.Empty;
			gameObject2.transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().fontSize = Screen.height / 56;
		}
		gameObject2.transform.GetChild(1).transform.GetChild(0).GetComponent<RawImage>().texture = Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[1].TextureSubject;
		if (Data.CharacterD[CharacterMotion._curCharacter].SuitChar.ArtContainer <= 1 && Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[1].NameSubject != "None" && Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[1].NameSubject != string.Empty && Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[1].NameSubject != null)
		{
			gameObject2.transform.GetChild(1).transform.GetChild(0).GetComponent<RawImage>().color = new Color(0.5f, 0.2f, 0.2f, 0.8f);
			gameObject2.transform.GetChild(1).transform.GetChild(1).GetComponent<Text>().text = "радиация + 5";
			gameObject2.transform.GetChild(1).transform.GetChild(1).GetComponent<Text>().fontSize = Screen.height / 56;
			flag = true;
		}
		else
		{
			gameObject2.transform.GetChild(1).transform.GetChild(0).GetComponent<RawImage>().color = new Color(1f, 1f, 1f, 1f);
			gameObject2.transform.GetChild(1).transform.GetChild(1).GetComponent<Text>().text = string.Empty;
			gameObject2.transform.GetChild(1).transform.GetChild(1).GetComponent<Text>().fontSize = Screen.height / 56;
		}
		gameObject2.transform.GetChild(2).transform.GetChild(0).GetComponent<RawImage>().texture = Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[2].TextureSubject;
		if (Data.CharacterD[CharacterMotion._curCharacter].SuitChar.ArtContainer <= 2 && Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[2].NameSubject != "None" && Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[2].NameSubject != string.Empty && Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[2].NameSubject != null)
		{
			gameObject2.transform.GetChild(2).transform.GetChild(0).GetComponent<RawImage>().color = new Color(0.5f, 0.2f, 0.2f, 0.8f);
			gameObject2.transform.GetChild(2).transform.GetChild(1).GetComponent<Text>().text = "радиация + 5";
			gameObject2.transform.GetChild(2).transform.GetChild(1).GetComponent<Text>().fontSize = Screen.height / 56;
			flag = true;
		}
		else
		{
			gameObject2.transform.GetChild(2).transform.GetChild(0).GetComponent<RawImage>().color = new Color(1f, 1f, 1f, 1f);
			gameObject2.transform.GetChild(2).transform.GetChild(1).GetComponent<Text>().text = string.Empty;
			gameObject2.transform.GetChild(2).transform.GetChild(1).GetComponent<Text>().fontSize = Screen.height / 56;
		}
		gameObject2.transform.GetChild(3).transform.GetChild(0).GetComponent<RawImage>().texture = Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[3].TextureSubject;
		if (Data.CharacterD[CharacterMotion._curCharacter].SuitChar.ArtContainer <= 3 && Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[3].NameSubject != "None" && Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[3].NameSubject != string.Empty && Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[3].NameSubject != null)
		{
			gameObject2.transform.GetChild(3).transform.GetChild(0).GetComponent<RawImage>().color = new Color(0.5f, 0.2f, 0.2f, 0.8f);
			gameObject2.transform.GetChild(3).transform.GetChild(1).GetComponent<Text>().text = "радиация + 5";
			gameObject2.transform.GetChild(3).transform.GetChild(1).GetComponent<Text>().fontSize = Screen.height / 56;
			flag = true;
		}
		else
		{
			gameObject2.transform.GetChild(3).transform.GetChild(0).GetComponent<RawImage>().color = new Color(1f, 1f, 1f, 1f);
			gameObject2.transform.GetChild(3).transform.GetChild(1).GetComponent<Text>().text = string.Empty;
			gameObject2.transform.GetChild(3).transform.GetChild(1).GetComponent<Text>().fontSize = Screen.height / 56;
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].DetectorChar.NameSubject != "None")
		{
			GameObject.Find("DetectorGG").transform.GetChild(0).GetComponent<RawImage>().texture = Data.CharacterD[CharacterMotion._curCharacter].DetectorChar.TextureSubject;
		}
		else
		{
			GameObject.Find("DetectorGG").transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/OtherSprite/Slot128");
		}
		if (flag)
		{
			Inventory.MessagePanel("Артефакт используется без контейнера! Радицация + 5.");
		}
		Inventory.AAAAAAAAAAAAAAAAAAAAch();
		Inventory.AAAAAAAAAAAAAAAAAbw();
		gameObject = GameObject.Find("Inf");
		gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<Text>().text = "max ходов: " + Inventory._CalcWeigh;
		gameObject.GetComponent<RectTransform>().transform.GetChild(1).GetComponent<Text>().text = "вес экипировки: " + (int)Inventory._CurWeigh + " кг";
		GameObject gameObject3 = GameObject.Find("ItamPanel");
		for (int i = 0; i < 20; i++)
		{
			gameObject3.transform.GetChild(i).transform.GetChild(0).GetComponent<RawImage>().texture = Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].TextureSubject;
			gameObject3.transform.GetChild(i).transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
			gameObject3.transform.GetChild(i).transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].Stack.ToString();
			if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].Stack <= 1 && Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].TypeSubj != AAAAAAAAAAAAAAAAAAk.TypeSubject.Catridge)
			{
				gameObject3.transform.GetChild(i).transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = string.Empty;
			}
			gameObject3.transform.GetChild(i).transform.GetChild(0).transform.GetChild(1).transform.localPosition = new Vector3(Screen.height / 24, -Screen.height / 18);
			if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Weapon)
			{
				gameObject3.transform.GetChild(i).transform.GetChild(0).transform.GetChild(1).transform.localPosition = new Vector3(Screen.height / 16, -Screen.height / 30);
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].SingModification)
			{
				gameObject3.transform.GetChild(i).transform.GetChild(0).transform.GetChild(1).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/Upgrade/UG");
			}
			else
			{
				gameObject3.transform.GetChild(i).transform.GetChild(0).transform.GetChild(1).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/OtherSprite/Slot128");
			}
		}
		gameObject = GameObject.Find("InfState");
		gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<Text>().text = "HP : " + (int)Data.CharacterD[CharacterMotion._curCharacter].CurHealth;
		if (Data.CharacterD[CharacterMotion._curCharacter].Bleeding > 0f)
		{
			gameObject.GetComponent<RectTransform>().transform.GetChild(1).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/IconGUI/BleedingRed");
			gameObject.GetComponent<RectTransform>().transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = Data.CharacterD[CharacterMotion._curCharacter].Bleeding.ToString();
		}
		else
		{
			gameObject.GetComponent<RectTransform>().transform.GetChild(1).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/IconGUI/Bleeding");
			gameObject.GetComponent<RectTransform>().transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = string.Empty;
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].DiseaseXRay > 0)
		{
			gameObject.GetComponent<RectTransform>().transform.GetChild(2).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/IconGUI/xRayRed");
			gameObject.GetComponent<RectTransform>().transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = Data.CharacterD[CharacterMotion._curCharacter].DiseaseXRay.ToString();
		}
		else
		{
			gameObject.GetComponent<RectTransform>().transform.GetChild(2).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/IconGUI/xRayNew");
			gameObject.GetComponent<RectTransform>().transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = string.Empty;
		}
	}

	public static void AAAAAAAAAAAAAAAAAAAAbz()
	{
		if (CharacterMotion.NPSPanel)
		{
			GameObject gameObject = GameObject.Find("ContragentPanel");
			gameObject.transform.GetChild(1).transform.GetChild(0).GetComponent<RawImage>().texture = Data.CharacterD[Inventory._currentCharacterNumber].SuitChar.IconCharacter;
			if (!Data.CharacterD[Inventory._currentCharacterNumber].Life)
			{
				gameObject.transform.GetChild(1).transform.GetChild(0).GetComponent<RawImage>().texture = Data.CharacterD[Inventory._currentCharacterNumber].SuitChar.IconCharacterDead;
			}
			gameObject = GameObject.Find("InfOfCA");
			gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<Text>().text = Data.CharacterD[Inventory._currentCharacterNumber].CharUnits.name;
			gameObject.GetComponent<RectTransform>().transform.GetChild(1).GetComponent<Text>().text = Data.CharacterD[Inventory._currentCharacterNumber].Cash + " Ru";
			for (int i = 0; i < 20; i++)
			{
				gameObject = GameObject.Find("CAEquipmentBackpack" + i);
				gameObject.GetComponent<NewChoiseSubjectCA>().slotID = i;
				gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RawImage>().texture = Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[i].TextureSubject;
				gameObject.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
				gameObject.GetComponent<RectTransform>().transform.GetComponentInChildren<Text>().text = Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[i].Stack + string.Empty;
				if (Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[i].Stack <= 1 && Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[i].TypeSubj != AAAAAAAAAAAAAAAAAAk.TypeSubject.Catridge)
				{
					gameObject.GetComponent<RectTransform>().transform.GetComponentInChildren<Text>().text = string.Empty;
				}
				gameObject.transform.GetComponentInChildren<Text>().fontSize = Screen.height / 28;
				gameObject.transform.GetChild(0).transform.GetChild(0).localPosition = new Vector3(Inventory._posY10, Inventory._posY32);
				gameObject.transform.GetChild(0).transform.GetChild(1).localPosition = new Vector3(Screen.height / 24, -Screen.height / 18);
				if (Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[i].TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Weapon)
				{
					gameObject.transform.GetChild(0).transform.GetChild(1).localPosition = new Vector3(Screen.height / 16, -Screen.height / 30);
				}
				if (Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[i].SingModification)
				{
					gameObject.transform.GetChild(0).transform.GetChild(1).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/Upgrade/UG");
				}
				else
				{
					gameObject.transform.GetChild(0).transform.GetChild(1).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/OtherSprite/Slot128");
				}
			}
		}
		if (CharacterMotion.DealerPanel)
		{
			GameObject gameObject2 = GameObject.Find("ContragentPanel");
			gameObject2.transform.GetChild(1).transform.GetChild(0).GetComponent<RawImage>().texture = Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].DealerInt].ImageChar;
			gameObject2 = GameObject.Find("InfOfCA");
			gameObject2.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<Text>().text = Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].DealerInt].NameDealer;
			gameObject2.GetComponent<RectTransform>().transform.GetChild(1).GetComponent<Text>().text = string.Empty;
			for (int j = 0; j < 25; j++)
			{
				gameObject2 = GameObject.Find("CAEquipmentBackpack" + j);
				gameObject2.GetComponent<NewChoiseSubjectCA>().slotID = j;
				gameObject2.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RawImage>().texture = Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].DealerInt].Product[AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.CharacterD[CharacterMotion._curCharacter].TypeChInt, Data.Points[Inventory._CurrentPoint[0]].ControlInt], j].TextureSubject;
				gameObject2.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
				gameObject2.GetComponent<RectTransform>().transform.GetComponentInChildren<Text>().text = string.Empty;
				gameObject2.GetComponent<RectTransform>().transform.GetComponentInChildren<Text>().fontSize = Screen.height / 28;
				gameObject2.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RectTransform>().transform.GetChild(0).localPosition = new Vector3(Inventory._posY10, Inventory._posY32);
				gameObject2.transform.GetChild(0).transform.GetChild(1).localPosition = new Vector3(Screen.height / 24, -Screen.height / 18);
				if (Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].DealerInt].Product[AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.CharacterD[CharacterMotion._curCharacter].TypeChInt, Data.Points[Inventory._CurrentPoint[0]].ControlInt], j].TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Weapon)
				{
					gameObject2.transform.GetChild(0).transform.GetChild(1).localPosition = new Vector3(Screen.height / 16, -Screen.height / 30);
				}
				if (Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].DealerInt].Product[AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.CharacterD[CharacterMotion._curCharacter].TypeChInt, Data.Points[Inventory._CurrentPoint[0]].ControlInt], j].SingModification)
				{
					gameObject2.transform.GetChild(0).transform.GetChild(1).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/Upgrade/UG");
				}
				else
				{
					gameObject2.transform.GetChild(0).transform.GetChild(1).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/OtherSprite/Slot128");
				}
			}
		}
		if (CharacterMotion.CachePanel)
		{
			GameObject gameObject3 = GameObject.Find("ContragentPanel");
			for (int k = 0; k < 20; k++)
			{
				gameObject3 = GameObject.Find("CAEquipmentBackpack" + k);
				gameObject3.GetComponent<NewChoiseSubjectCA>().slotID = k;
				gameObject3.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RawImage>().texture = Data.Points[Inventory._CurrentPoint[0]].Cache[k].TextureSubject;
				gameObject3.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
				gameObject3.GetComponent<RectTransform>().transform.GetComponentInChildren<Text>().text = Data.Points[Inventory._CurrentPoint[0]].Cache[k].Stack.ToString();
				if (Data.Points[Inventory._CurrentPoint[0]].Cache[k].Stack <= 1 && Data.Points[Inventory._CurrentPoint[0]].Cache[k].TypeSubj != AAAAAAAAAAAAAAAAAAk.TypeSubject.Catridge)
				{
					gameObject3.GetComponent<RectTransform>().transform.GetComponentInChildren<Text>().text = string.Empty;
				}
				gameObject3.GetComponent<RectTransform>().transform.GetComponentInChildren<Text>().fontSize = Screen.height / 28;
				gameObject3.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RectTransform>().transform.GetChild(0).localPosition = new Vector3(Inventory._posY10, Inventory._posY32);
				gameObject3.transform.GetChild(0).transform.GetChild(1).localPosition = new Vector3(Screen.height / 24, -Screen.height / 18);
				if (Data.Points[Inventory._CurrentPoint[0]].Cache[k].TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Weapon)
				{
					gameObject3.transform.GetChild(0).transform.GetChild(1).localPosition = new Vector3(Screen.height / 16, -Screen.height / 30);
				}
				if (Data.Points[Inventory._CurrentPoint[0]].Cache[k].SingModification)
				{
					gameObject3.transform.GetChild(0).transform.GetChild(1).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/Upgrade/UG");
				}
				else
				{
					gameObject3.transform.GetChild(0).transform.GetChild(1).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/OtherSprite/Slot128");
				}
			}
		}
		if (CharacterMotion.RewardPanel)
		{
			GameObject gameObject4 = GameObject.Find("ContragentPanel");
			gameObject4 = GameObject.Find("CAEquipmentBackpack0");
			gameObject4.GetComponent<NewChoiseSubjectCA>().slotID = 0;
			gameObject4.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RawImage>().texture = Inventory._currentSubject.TextureSubject;
			gameObject4.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
			gameObject4.GetComponent<RectTransform>().transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = string.Empty;
			if (Inventory._currentSubject.Stack > 1)
			{
				gameObject4.GetComponent<RectTransform>().transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = Inventory._currentSubject.Stack.ToString();
			}
			gameObject4.GetComponent<RectTransform>().transform.GetComponentInChildren<Text>().fontSize = Screen.height / 28;
			gameObject4.GetComponent<RectTransform>().transform.GetChild(0).GetComponent<RectTransform>().transform.GetChild(0).localPosition = new Vector3(Inventory._posY10, Inventory._posY32);
			gameObject4.transform.GetChild(0).transform.GetChild(1).localPosition = new Vector3(Screen.height / 24, -Screen.height / 18);
			if (Inventory._currentSubject.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Weapon)
			{
				gameObject4.transform.GetChild(0).transform.GetChild(1).localPosition = new Vector3(Screen.height / 16, -Screen.height / 30);
			}
			if (Inventory._currentSubject.SingModification)
			{
				gameObject4.transform.GetChild(0).transform.GetChild(1).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/Upgrade/UG");
			}
			else
			{
				gameObject4.transform.GetChild(0).transform.GetChild(1).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/OtherSprite/Slot128");
			}
		}
	}

	public static void AAAAAAAAAAAAAAAAbo()
	{
		if (Inventory._currentSubject.CartridgeType == "9х18 мм")
		{
			CharacterMotion.SlotSubject = new Cartridge9x18();
		}
		if (Inventory._currentSubject.CartridgeType == "12х70 дробь")
		{
			CharacterMotion.SlotSubject = new Cartridge12x70();
		}
		if (Inventory._currentSubject.CartridgeType == "9х19 мм")
		{
			CharacterMotion.SlotSubject = new Cartridge9x19();
		}
		if (Inventory._currentSubject.CartridgeType == ".45 АСР")
		{
			CharacterMotion.SlotSubject = new Cartridge45АСР();
		}
		if (Inventory._currentSubject.CartridgeType == "5,45x39 мм")
		{
			CharacterMotion.SlotSubject = new Cartridge_5_45x39();
		}
		if (Inventory._currentSubject.CartridgeType == "9х39 мм СП-5")
		{
			CharacterMotion.SlotSubject = new Cartridge_9x39_sp5();
		}
		if (Inventory._currentSubject.CartridgeType == "5,56x45 мм")
		{
			CharacterMotion.SlotSubject = new Cartridge_5_56x45();
		}
		if (Inventory._currentSubject.CartridgeType == "7,62x54 мм 7H1")
		{
			CharacterMotion.SlotSubject = new Cartridge_7_62x54();
		}
		if (Inventory._currentSubject.CartridgeType == "Аккумуляторы")
		{
			CharacterMotion.SlotSubject = new GausAccumulator();
		}
		CharacterMotion.SlotSubject.Stack = 0;
	}
}
