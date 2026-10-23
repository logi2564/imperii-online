using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuitMessage : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
{
	public void OnPointerDown(PointerEventData eventData)
	{
		if (base.gameObject.transform.parent.gameObject.name == "MessaegeTask")
		{
			Inventory._Equipment = true;
		}
		if (base.gameObject.transform.parent.gameObject.name == "TaskPanel" && base.gameObject.transform.parent.transform.childCount > 1 && base.gameObject.transform.parent.transform.GetChild(1).GetComponent<Text>().text == "Работа:")
		{
			Inventory._PointInf = true;
			Inventory._Equipment = false;
			Inventory._CurtainGUIEquipment.SetActive(false);
			Inventory._CurtainIconCharacterU.SetActive(false);
			Inventory._CurtainState.SetActive(false);
			Inventory._CurtainInventory.SetActive(true);
		}
		if (SceneManager.GetActiveScene().name != "Menu")
		{
			Inventory.showAdv = false;
			Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/pda/pda_objective");
			Inventory.SoundMenu.Play();
		}
		Object.Destroy(base.gameObject.transform.parent.gameObject);
	}
}
