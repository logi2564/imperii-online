using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuitRenamePanel : MonoBehaviour
{
	public void DestroyRenamePanel()
	{
		PlayerPrefs.SetString("HeroName", base.transform.GetChild(0).GetComponent<InputField>().text);
		Object.Destroy(base.gameObject);
		if (SceneManager.GetActiveScene().name == "Menu")
		{
			Menu.SoundMenu.clip = (AudioClip)Resources.Load("Sound/pda/pda_tip");
			Menu.SoundMenu.Play();
		}
		else
		{
			Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/pda/pda_tip");
			Inventory.SoundMenu.Play();
		}
	}
}
