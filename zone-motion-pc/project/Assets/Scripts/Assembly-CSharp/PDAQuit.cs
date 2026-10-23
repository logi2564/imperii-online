using UnityEngine;
using UnityEngine.EventSystems;

public class PDAQuit : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
{
	public void OnPointerDown(PointerEventData eventData)
	{
		if (Data.CharacterD[CharacterMotion._curCharacter].Cash >= 300000)
		{
			GPSscript.AAAAAAAAAAAAAAAAAAAAe("CgkI2OGbhtMLEAIQAg");
		}
		Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/contact_1");
		Inventory.SoundMenu.Play();
		Object.Destroy(GameObject.Find("PDApanel"));
		Inventory._Equipment = true;
		Inventory._CurtainGUIEquipment.SetActive(true);
		Inventory._CurtainIconCharacterU.SetActive(true);
		Inventory._CurtainState.SetActive(true);
		Inventory._CurtainInventory.SetActive(false);
	}
}
