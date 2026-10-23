using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ActTask : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public void OnPointerClick(PointerEventData eventData)
	{
		if (base.gameObject.transform.GetChild(0).GetComponent<Text>().text == "Отказаться" && Data.TaskAll[Inventory._TaskNum].AdditionalTask && !Data.TaskAll[Inventory._TaskNum].KillQuest)
		{
			Object.Destroy(Inventory.TaskPanelGO);
			Inventory.MessagePanel("Провалено задание: " + Data.TaskAll[Inventory._TaskNum].NameTask);
			if (Data.TaskAll[Inventory._TaskNum].NameTask == "Найти отряд разведчиков")
			{
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 3]--;
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[3, 0]--;
				if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 3] < 0)
				{
					AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 3] = 0;
				}
				if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[3, 0] < 0)
				{
					AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[3, 0] = 0;
				}
			}
			if (Data.TaskAll[Inventory._TaskNum].NameTask == "Принести Схемы Выжигателя")
			{
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 8]--;
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[8, 0]--;
				if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 8] < 0)
				{
					AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 8] = 0;
				}
				if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[8, 0] < 0)
				{
					AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[8, 0] = 0;
				}
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 9]--;
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[9, 0]--;
				if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 9] < 0)
				{
					AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 9] = 0;
				}
				if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[9, 0] < 0)
				{
					AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[9, 0] = 0;
				}
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 10]--;
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[10, 0]--;
				if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 10] < 0)
				{
					AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, 10] = 0;
				}
				if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[10, 0] < 0)
				{
					AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[10, 0] = 0;
				}
			}
			if (Data.TaskAll[Inventory._TaskNum].GuideQuest)
			{
				for (int i = 0; i < Data.CharacterD.Count; i++)
				{
					if (Data.CharacterD[i].NameU == Data.TaskAll[Inventory._TaskNum].KillCharacterName)
					{
						Data.CharacterD[i].ControlGamer = false;
						CharacterMotion._curCharacter = 0;
					}
				}
			}
			Data.TaskAll.RemoveAt(Inventory._TaskNum);
			Inventory._TaskNum = 0;
		}
		if (base.gameObject.transform.GetChild(0).GetComponent<Text>().text == "Принять")
		{
			Inventory._currentTask = Data.TaskCurrentCharacter[Inventory._NewTaskNum];
			Inventory.SoundMenu.clip = Inventory.effectObjective;
			Inventory.SoundMenu.Play();
			Methods.AAAAAAAAAAAAAAAAAch();
			Methods.AAAAAAAAAAAAAAAAAAAAAcr();
			Methods.AAAAAAAAAAAAAAAAAAAAAcs();
			Inventory._NewTaskNum = 0;
			Object.Destroy(base.gameObject.transform.parent.transform.parent.transform.parent.gameObject);
			Inventory.AAAAAAAAAAAAAAAAAAAcb();
		}
	}
}
