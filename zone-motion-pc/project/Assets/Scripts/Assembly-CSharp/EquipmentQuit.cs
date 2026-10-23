using UnityEngine;
using UnityEngine.EventSystems;

public class EquipmentQuit : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
{
	public void OnPointerDown(PointerEventData eventData)
	{
		Methods.AAAAAAAAAAAAAAAAAAAAAct();
		if (CharacterMotion.RewardPanel && Inventory._RewardSubject.NameSubject != "None")
		{
			for (int i = 0; i < 20; i++)
			{
				if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].NameSubject == "None")
				{
					Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i] = Inventory._RewardSubject;
					Inventory._RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
					Inventory._currentSubject = new AAAAAAAAAAAAAAAAAAbi();
					Inventory.MessagePanel("Предмет перемещен в рюкзак");
					SubjectAct.AAAAAAAAAAAAAAAAAAAAbz();
					SubjectAct.AAAAAAAAAAAAAAAAAAAbo();
					break;
				}
			}
			if (Inventory._RewardSubject.NameSubject != "None" && Inventory._CurrentPoint.Count > 0)
			{
				for (int j = 0; j < 20; j++)
				{
					if (Data.Points[Inventory._CurrentPoint[0]].Cache[j].NameSubject == "None")
					{
						Data.Points[Inventory._CurrentPoint[0]].Cache[j] = Inventory._RewardSubject;
						Inventory._RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
						Inventory._currentSubject = new AAAAAAAAAAAAAAAAAAbi();
						Inventory.MessagePanel("Предмет перемещен в тайник на точке: " + Data.Points[Inventory._CurrentPoint[0]].namePoint);
						SubjectAct.AAAAAAAAAAAAAAAAAAAAbz();
						SubjectAct.AAAAAAAAAAAAAAAAAAAbo();
						break;
					}
				}
			}
			if (Inventory._RewardSubject.NameSubject != "None")
			{
				Inventory.MessagePanel("В рюкзаке нет места! Необходимо освободить место для полученного предмета");
			}
			return;
		}
		Object.Destroy(GameObject.Find("NewEquipmentPanel"));
		Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_open");
		Inventory.SoundMenu.Play();
		Inventory._Equipment = true;
		Inventory._CurtainGUIEquipment.SetActive(true);
		Inventory._CurtainIconCharacterU.SetActive(true);
		Inventory._CurtainState.SetActive(true);
		Inventory._CurtainInventory.SetActive(false);
		Inventory._currentSubject = Data._NoneSubject;
		Inventory._Range = Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Range;
		if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.SightInstallation)
		{
			Inventory._Range++;
		}
		if (Inventory._CurrentCharUnit.Count > 0 && CharacterMotion._DistansMove < Inventory._Range)
		{
			Inventory._fireButton = true;
		}
		else
		{
			Inventory._fireButton = false;
		}
		if (CharacterMotion.DealerPanel || CharacterMotion.CachePanel || CharacterMotion.RepairPanel || CharacterMotion.RewardPanel)
		{
			Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_ruck");
			Inventory.SoundMenu.Play();
			if (CharacterMotion.PointInform != null)
			{
				CharacterMotion.PointInform.SetActive(false);
			}
			Methods.AAAAAAAAAAAAAAAAAAAAAcs();
			Inventory._Equipment = false;
			Inventory._PointInformation = true;
			Inventory._PointInf = true;
			Inventory._CurtainGUIEquipment.SetActive(false);
			Inventory._CurtainIconCharacterU.SetActive(false);
			Inventory._CurtainState.SetActive(false);
			Inventory._CurtainInventory.SetActive(true);
			Inventory._currentSubject = Data._NoneSubject;
		}
		CharacterMotion.CApanel = false;
		CharacterMotion.NPSPanel = false;
		CharacterMotion.DealerPanel = false;
		CharacterMotion.CachePanel = false;
		CharacterMotion.RepairPanel = false;
		CharacterMotion.RewardPanel = false;
	}
}
