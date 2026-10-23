using UnityEngine;

public class QuitCIP : MonoBehaviour
{
	public void DestroyCharacterInformationPanel()
	{
		Object.Destroy(base.gameObject);
		Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/pda/pda_tip");
		Inventory.SoundMenu.Play();
	}
}
