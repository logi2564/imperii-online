using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TaskChoise : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public void OnPointerClick(PointerEventData eventData)
	{
		Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/pda/contact_1");
		Inventory.SoundMenu.Play();
		foreach (Transform item in Inventory.TaskPanelGO.transform)
		{
			if (item.name == "TaskCurrentPanel")
			{
				Object.Destroy(item.gameObject);
			}
		}
		Inventory.TaskPanelGO.GetComponentInChildren<Text>().color = new Color(0.67f, 0.67f, 0.67f, 0.79f);
		foreach (Transform item2 in Inventory.TaskPanelGO.transform.GetChild(2).transform.GetChild(0).transform)
		{
			item2.gameObject.transform.GetChild(1).GetComponent<Text>().color = new Color(0.67f, 0.67f, 0.67f, 0.79f);
			item2.gameObject.transform.GetChild(2).GetComponent<Text>().color = new Color(0.67f, 0.67f, 0.67f, 0.79f);
		}
		if (Inventory.TaskPanelGO.transform.GetChild(1).GetComponent<Text>().text == "Работа:")
		{
			Inventory._NewTaskNum = int.Parse(base.gameObject.name);
		}
		if (Inventory.TaskPanelGO.transform.GetChild(1).GetComponent<Text>().text == "Задачи:")
		{
			Inventory._TaskNum = int.Parse(base.gameObject.name);
		}
		Inventory.CurTaskIcon.transform.SetParent(base.gameObject.transform.GetChild(3).transform);
		Inventory.CurTaskIcon.transform.localPosition = new Vector3(0f, 0f);
		base.gameObject.transform.GetChild(1).GetComponent<Text>().color = new Color(0.3f, 0.7f, 0.3f, 0.8f);
		base.gameObject.transform.GetChild(2).GetComponent<Text>().color = new Color(0.3f, 0.7f, 0.3f, 0.8f);
	}

	public static void AAAAAAAAAAAAAAAAAAdj()
	{
		Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/pda/pda_tip");
		Inventory.SoundMenu.Play();
		GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/TaskCurrentPanel"));
		gameObject.name = "TaskCurrentPanel";
		gameObject.transform.SetParent(Inventory.TaskPanelGO.transform);
		gameObject.transform.localPosition = new Vector3(0f, 0f);
		if (Inventory.TaskPanelGO.transform.GetChild(1).GetComponent<Text>().text == "Работа:")
		{
			gameObject.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<RawImage>().texture = Data.TaskCurrentCharacter[Inventory._NewTaskNum].ImageTask;
			if (Data.TaskCurrentCharacter[Inventory._NewTaskNum].ImageTask != null)
			{
				gameObject.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
				if (gameObject.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<RectTransform>().rect.height < 50f)
				{
					gameObject.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).transform.localScale = new Vector3(gameObject.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.localScale.x * 1.5f, gameObject.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.localScale.y * 1.5f);
				}
			}
			gameObject.transform.GetChild(1).transform.GetChild(1).GetComponent<Text>().text = Data.TaskCurrentCharacter[Inventory._NewTaskNum].NameTask;
			gameObject.transform.GetChild(1).transform.GetChild(2).GetComponent<Text>().text = Data.TaskCurrentCharacter[Inventory._NewTaskNum].DescriptionTask;
			if (Data.TaskCurrentCharacter[Inventory._NewTaskNum].BalansQuest)
			{
				Text component = gameObject.transform.GetChild(1).transform.GetChild(2).GetComponent<Text>();
				component.text = component.text + Data.TaskCurrentCharacter[Inventory._NewTaskNum].GroupName + ". Район: " + Data.TaskCurrentCharacter[Inventory._NewTaskNum].NamePointTask;
			}
			if (Data.TaskCurrentCharacter[Inventory._NewTaskNum].SubjectQuest)
			{
				if (Data.TaskCurrentCharacter[Inventory._NewTaskNum].QuestSubject.NameSubject != "None")
				{
					gameObject.transform.GetChild(1).transform.GetChild(2).GetComponent<Text>().text += ": ";
					Text component2 = gameObject.transform.GetChild(1).transform.GetChild(2).GetComponent<Text>();
					component2.text = component2.text + Data.TaskCurrentCharacter[Inventory._NewTaskNum].QuestSubject.NameSubject + ".";
				}
				Text component3 = gameObject.transform.GetChild(1).transform.GetChild(2).GetComponent<Text>();
				component3.text = component3.text + " Заказчик на точке: " + Data.TaskCurrentCharacter[Inventory._NewTaskNum].NamePointTask;
			}
			if (Data.TaskCurrentCharacter[Inventory._NewTaskNum].KillQuest)
			{
				Text component4 = gameObject.transform.GetChild(1).transform.GetChild(2).GetComponent<Text>();
				component4.text = component4.text + " Цель: " + Data.TaskCurrentCharacter[Inventory._NewTaskNum].KillCharacterName;
			}
			if (Data.TaskCurrentCharacter[Inventory._NewTaskNum].GuideQuest)
			{
				Text component5 = gameObject.transform.GetChild(1).transform.GetChild(2).GetComponent<Text>();
				string text = component5.text;
				component5.text = text + " Заказчик: " + Data.TaskCurrentCharacter[Inventory._NewTaskNum].KillCharacterName + ". Цель: " + Data.TaskCurrentCharacter[Inventory._NewTaskNum].NamePointTask;
			}
			if (Data.TaskCurrentCharacter[Inventory._NewTaskNum].CaptureQuest)
			{
				Text component6 = gameObject.transform.GetChild(1).transform.GetChild(2).GetComponent<Text>();
				component6.text = component6.text + Data.TaskCurrentCharacter[Inventory._NewTaskNum].NamePointTask + ". Заказчик: " + Data.TaskCurrentCharacter[Inventory._NewTaskNum].GroupName;
			}
			gameObject.transform.GetChild(1).transform.GetChild(3).GetComponent<Text>().text = Data.TaskCurrentCharacter[Inventory._NewTaskNum].TextTask;
			gameObject.transform.GetChild(1).transform.GetChild(4).gameObject.SetActive(true);
			gameObject.transform.GetChild(1).transform.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = "Принять";
		}
		if (Inventory.TaskPanelGO.transform.GetChild(1).GetComponent<Text>().text == "Задачи:")
		{
			gameObject.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<RawImage>().texture = Data.TaskAll[Inventory._TaskNum].ImageTask;
			if (Data.TaskAll[Inventory._TaskNum].ImageTask != null)
			{
				gameObject.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<RawImage>().texture = Data.TaskAll[Inventory._TaskNum].ImageTask;
				gameObject.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
				if (gameObject.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<RectTransform>().rect.height < 50f)
				{
					gameObject.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).transform.localScale = new Vector3(gameObject.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.localScale.x * 1.5f, gameObject.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.localScale.y * 1.5f);
				}
			}
			gameObject.transform.GetChild(1).transform.GetChild(1).GetComponent<Text>().text = Data.TaskAll[Inventory._TaskNum].NameTask;
			gameObject.transform.GetChild(1).transform.GetChild(2).GetComponent<Text>().text = Data.TaskAll[Inventory._TaskNum].DescriptionTask;
			if (Data.TaskAll[Inventory._TaskNum].BalansQuest)
			{
				Text component7 = gameObject.transform.GetChild(1).transform.GetChild(2).GetComponent<Text>();
				component7.text = component7.text + Data.TaskAll[Inventory._TaskNum].GroupName + ". Район: " + Data.TaskAll[Inventory._TaskNum].NamePointTask;
			}
			if (Data.TaskAll[Inventory._TaskNum].SubjectQuest)
			{
				if (Data.TaskAll[Inventory._TaskNum].QuestSubject.NameSubject != "None")
				{
					gameObject.transform.GetChild(1).transform.GetChild(2).GetComponent<Text>().text += ": ";
					Text component8 = gameObject.transform.GetChild(1).transform.GetChild(2).GetComponent<Text>();
					component8.text = component8.text + Data.TaskCurrentCharacter[Inventory._NewTaskNum].QuestSubject.NameSubject + ".";
				}
				Text component9 = gameObject.transform.GetChild(1).transform.GetChild(2).GetComponent<Text>();
				component9.text = component9.text + " Заказчик на точке: " + Data.TaskCurrentCharacter[Inventory._NewTaskNum].NamePointTask;
			}
			if (Data.TaskAll[Inventory._TaskNum].KillQuest)
			{
				Text component10 = gameObject.transform.GetChild(1).transform.GetChild(2).GetComponent<Text>();
				component10.text = component10.text + " Цель: " + Data.TaskAll[Inventory._TaskNum].KillCharacterName;
			}
			if (Data.TaskAll[Inventory._TaskNum].GuideQuest)
			{
				Text component11 = gameObject.transform.GetChild(1).transform.GetChild(2).GetComponent<Text>();
				string text = component11.text;
				component11.text = text + " Заказчик: " + Data.TaskAll[Inventory._TaskNum].KillCharacterName + ". Цель: " + Data.TaskAll[Inventory._TaskNum].NamePointTask;
			}
			if (Data.TaskAll[Inventory._TaskNum].CaptureQuest)
			{
				Text component12 = gameObject.transform.GetChild(1).transform.GetChild(2).GetComponent<Text>();
				component12.text = component12.text + Data.TaskAll[Inventory._TaskNum].NamePointTask + ". Заказчик: " + Data.TaskAll[Inventory._TaskNum].GroupName;
			}
			gameObject.transform.GetChild(1).transform.GetChild(3).GetComponent<Text>().text = Data.TaskAll[Inventory._TaskNum].TextTask;
			if (Data.TaskAll[Inventory._TaskNum].AdditionalTask && !Data.TaskAll[Inventory._TaskNum].KillQuest)
			{
				gameObject.transform.GetChild(1).transform.GetChild(4).gameObject.SetActive(true);
			}
			else
			{
				gameObject.transform.GetChild(1).transform.GetChild(4).gameObject.SetActive(false);
			}
		}
		float num = Screen.width;
		num /= 1000f;
		gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * num, gameObject.transform.localScale.x * num);
	}
}
