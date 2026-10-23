using UnityEngine;
using UnityEngine.EventSystems;

public class DescriptionQuit : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
{
	public void OnPointerDown(PointerEventData eventData)
	{
		Object.Destroy(GameObject.Find("InventoryInformation"));
	}
}
