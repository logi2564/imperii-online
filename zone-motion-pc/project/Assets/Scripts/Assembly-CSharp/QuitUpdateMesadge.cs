using UnityEngine;
using UnityEngine.EventSystems;

public class QuitUpdateMesadge : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
{
	public void OnPointerDown(PointerEventData eventData)
	{
		Menu.SoundMenu.clip = (AudioClip)Resources.Load("Sound/pda/pda_tip");
		Menu.SoundMenu.Play();
		Object.Destroy(Menu.MessadgePanel);
	}
}
