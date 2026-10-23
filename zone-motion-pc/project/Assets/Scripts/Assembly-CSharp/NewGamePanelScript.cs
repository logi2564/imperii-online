using UnityEngine;

public class NewGamePanelScript : MonoBehaviour
{
	public void Novice()
	{
		SaveLoad.Difficulty = 1.3f;
		SaveLoad.AAAAAAAAAAAAAAAAAAAAAcp("NewGame", "Kordon");
	}

	public void Stalker()
	{
		SaveLoad.Difficulty = 1f;
		SaveLoad.AAAAAAAAAAAAAAAAAAAAAcp("NewGame", "Kordon");
	}

	public void Veteran()
	{
		SaveLoad.Difficulty = 0.8f;
		SaveLoad.AAAAAAAAAAAAAAAAAAAAAcp("NewGame", "Kordon");
	}

	public void Berserk()
	{
		SaveLoad.Difficulty = 0.6f;
		SaveLoad.AAAAAAAAAAAAAAAAAAAAAcp("NewGame", "Kordon");
	}

	public void QuitPanel()
	{
		GameObject gameObject = GameObject.Find("SoundEffect");
		gameObject.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("Sound/pda/contact_1");
		gameObject.GetComponent<AudioSource>().Play();
		Object.Destroy(base.gameObject);
	}
}
