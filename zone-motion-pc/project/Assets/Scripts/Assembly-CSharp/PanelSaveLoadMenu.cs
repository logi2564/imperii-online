using UnityEngine;

public class PanelSaveLoadMenu : MonoBehaviour
{
	public void Load0()
	{
		SaveLoad.AAAAAAAAAAAAAAAAcd("Save");
	}

	public void Load1()
	{
		SaveLoad.AAAAAAAAAAAAAAAAcd("Save1");
	}

	public void Load2()
	{
		SaveLoad.AAAAAAAAAAAAAAAAcd("Save2");
	}

	public void Load3()
	{
		SaveLoad.AAAAAAAAAAAAAAAAcd("Save3");
	}

	public void LoadAiutosave()
	{
		SaveLoad.AAAAAAAAAAAAAAAAcd("AutoSave");
	}

	public void QuitLoadPanel()
	{
		GameObject gameObject = GameObject.Find("SoundEffect");
		gameObject.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("Sound/pda/contact_1");
		gameObject.GetComponent<AudioSource>().Play();
		Object.Destroy(base.gameObject);
	}
}
