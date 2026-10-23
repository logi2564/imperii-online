using UnityEngine;

public class ItemPanelScript : MonoBehaviour
{
	public void QuitItemPanel()
	{
		Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/contact_1");
		Inventory.SoundMenu.Play();
		Object.Destroy(base.gameObject);
	}
}
