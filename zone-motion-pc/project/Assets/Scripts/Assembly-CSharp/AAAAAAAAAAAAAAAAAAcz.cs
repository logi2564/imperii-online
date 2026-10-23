using UnityEngine;
using UnityEngine.SceneManagement;

public class AAAAAAAAAAAAAAAAAAcz
{
	public static void AAAAAAAAAAAAAAAbs()
	{
		PlayerPrefs.SetString("Mute", GameObject.Find("Main Camera").GetComponent<AudioSource>().mute.ToString());
		PlayerPrefs.SetFloat("Volume", GameObject.Find("Main Camera").GetComponent<AudioSource>().volume);
		PlayerPrefs.SetFloat("VolumeBGmusic", GameObject.Find("SoundBG").GetComponent<AudioSource>().volume);
		PlayerPrefs.SetFloat("DefaultVolume", 1f);
		PlayerPrefs.Save();
	}

	public static void AAAAAAAAAAAAAAAAAcb()
	{
		if (PlayerPrefs.HasKey("DefaultVolume"))
		{
			if (!PlayerPrefs.HasKey("Mute"))
			{
				return;
			}
			GameObject.Find("Main Camera").GetComponent<AudioSource>().mute = bool.Parse(PlayerPrefs.GetString("Mute"));
			GameObject.Find("SoundEffect").GetComponent<AudioSource>().mute = bool.Parse(PlayerPrefs.GetString("Mute"));
			GameObject.Find("SoundBG").GetComponent<AudioSource>().mute = bool.Parse(PlayerPrefs.GetString("Mute"));
			GameObject.Find("Main Camera").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume");
			GameObject.Find("SoundEffect").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume");
			GameObject.Find("SoundBG").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("VolumeBGmusic");
			if (!(SceneManager.GetActiveScene().name != "Menu"))
			{
				return;
			}
			GameObject.Find("SoundEffect").GetComponent<AudioSource>().mute = bool.Parse(PlayerPrefs.GetString("Mute"));
			GameObject.Find("SoundBG").GetComponent<AudioSource>().mute = bool.Parse(PlayerPrefs.GetString("Mute"));
			GameObject.Find("SoundEffect").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume");
			GameObject.Find("Backgrownd").GetComponent<AudioSource>().mute = bool.Parse(PlayerPrefs.GetString("Mute"));
			GameObject.Find("Backgrownd").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume");
			if (Data.CharacterD.Count > 0)
			{
				for (int i = 0; i < Data.CharacterD.Count; i++)
				{
					GameObject.Find(Data.CharacterD[i].CharUnits.name).GetComponent<AudioSource>().mute = bool.Parse(PlayerPrefs.GetString("Mute"));
					GameObject.Find(Data.CharacterD[i].CharUnits.name).GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume");
				}
			}
		}
		else
		{
			PlayerPrefs.SetString("Mute", "false");
			PlayerPrefs.SetFloat("Volume", 0.5f);
			PlayerPrefs.SetFloat("VolumeBGmusic", 0.2f);
			PlayerPrefs.SetFloat("DefaultVolume", 1f);
			PlayerPrefs.Save();
			GameObject.Find("Main Camera").GetComponent<AudioSource>().mute = bool.Parse(PlayerPrefs.GetString("Mute"));
			GameObject.Find("SoundEffect").GetComponent<AudioSource>().mute = bool.Parse(PlayerPrefs.GetString("Mute"));
			GameObject.Find("Main Camera").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume");
			GameObject.Find("SoundEffect").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume");
			GameObject.Find("SoundBG").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("VolumeBGmusic");
		}
	}
}
