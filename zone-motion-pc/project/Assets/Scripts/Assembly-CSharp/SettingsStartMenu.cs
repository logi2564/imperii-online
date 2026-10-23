using GooglePlayGames;
using UnityEngine;
using UnityEngine.UI;

public class SettingsStartMenu : MonoBehaviour
{
	private AudioSource AAAAAAAAAAAAAAAAAAAAAAh;

	private AudioSource AAAAAAAAAAAAAAAAAAAAAAi;

	private AudioSource SoundBG;

	private void Start()
	{
		AAAAAAAAAAAAAAAAAAAAAAh = GameObject.Find("Main Camera").GetComponent<AudioSource>();
		AAAAAAAAAAAAAAAAAAAAAAi = GameObject.Find("SoundEffect").GetComponent<AudioSource>();
		SoundBG = GameObject.Find("SoundBG").GetComponent<AudioSource>();
	}

	public void VolumeIncrease()
	{
		AAAAAAAAAAAAAAAAAAAAAAh.volume += 0.05f;
		AAAAAAAAAAAAAAAAAAAAAAi.volume += 0.05f;
		base.gameObject.transform.GetChild(0).GetChild(0).GetComponent<Text>()
			.text = "Громкость: " + (int)(AAAAAAAAAAAAAAAAAAAAAAh.volume * 100f);
		AAAAAAAAAAAAAAAAAAcz.AAAAAAAAAAAAAAAbs();
		Menu.AAAAAAAAAAAAAAAAbz();
	}

	public void VolumeReduce()
	{
		AAAAAAAAAAAAAAAAAAAAAAh.volume -= 0.05f;
		AAAAAAAAAAAAAAAAAAAAAAi.volume -= 0.05f;
		base.gameObject.transform.GetChild(0).GetChild(0).GetComponent<Text>()
			.text = "Громкость: " + (int)(AAAAAAAAAAAAAAAAAAAAAAh.volume * 100f);
		AAAAAAAAAAAAAAAAAAcz.AAAAAAAAAAAAAAAbs();
		Menu.AAAAAAAAAAAAAAAAbz();
	}

	public void BGVolumeIncrease()
	{
		SoundBG.volume += 0.05f;
		base.gameObject.transform.GetChild(1).GetChild(0).GetComponent<Text>()
			.text = "Громкость фоновой музыки: " + (int)(SoundBG.volume * 100f);
		AAAAAAAAAAAAAAAAAAcz.AAAAAAAAAAAAAAAbs();
		Menu.AAAAAAAAAAAAAAAAbz();
	}

	public void BGVolumeReduce()
	{
		SoundBG.volume -= 0.05f;
		base.gameObject.transform.GetChild(1).GetChild(0).GetComponent<Text>()
			.text = "Громкость фоновой музыки: " + (int)(SoundBG.volume * 100f);
		AAAAAAAAAAAAAAAAAAcz.AAAAAAAAAAAAAAAbs();
		Menu.AAAAAAAAAAAAAAAAbz();
	}

	public void Mute()
	{
		if (AAAAAAAAAAAAAAAAAAAAAAh.mute)
		{
			AAAAAAAAAAAAAAAAAAAAAAh.mute = false;
			AAAAAAAAAAAAAAAAAAAAAAi.mute = false;
			SoundBG.mute = false;
			base.gameObject.transform.GetChild(2).GetChild(0).GetComponent<Text>()
				.text = "Mute off";
			base.gameObject.transform.GetChild(2).GetChild(1).GetChild(0)
				.GetComponent<RawImage>()
				.texture = (Texture2D)Resources.Load("Sprites/IconGUI/muteOff64w");
		}
		else
		{
			AAAAAAAAAAAAAAAAAAAAAAh.mute = true;
			AAAAAAAAAAAAAAAAAAAAAAi.mute = true;
			SoundBG.mute = true;
			base.gameObject.transform.GetChild(2).GetChild(0).GetComponent<Text>()
				.text = "Mute";
			base.gameObject.transform.GetChild(2).GetChild(1).GetChild(0)
				.GetComponent<RawImage>()
				.texture = (Texture2D)Resources.Load("Sprites/IconGUI/mute64w");
		}
		AAAAAAAAAAAAAAAAAAcz.AAAAAAAAAAAAAAAbs();
		Menu.AAAAAAAAAAAAAAAAbz();
	}

	public void AAAAAAAAAAAAAAAAAAd()
	{
		if (PlayerPrefs.GetInt("GPSusing") == 0)
		{
			GPSscript.AAAAAAAAAAAAAAAAAAAo();
			PlayerPrefs.SetInt("GPSusing", 1);
			base.gameObject.transform.GetChild(3).GetChild(0).GetChild(0)
				.GetComponent<Text>()
				.text = "Отключить серви\nGooglePlayGames";
		}
		else
		{
			PlayGamesPlatform.Instance.SignOut();
			PlayerPrefs.SetInt("GPSusing", 0);
			base.gameObject.transform.GetChild(3).GetChild(0).GetChild(0)
				.GetComponent<Text>()
				.text = "Отключить сервис\nGooglePlayGames";
		}
	}

	public void RenameHeroInMenu()
	{
		GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/RenameHero/RenameHero"));
		gameObject.name = "RenameHero";
		gameObject.transform.SetParent(GameObject.Find("Canvas").transform);
		gameObject.transform.localPosition = new Vector3(0f, 100f);
		if (PlayerPrefs.HasKey("HeroName"))
		{
			gameObject.transform.GetChild(0).GetComponent<InputField>().text = PlayerPrefs.GetString("HeroName");
		}
		else
		{
			gameObject.transform.GetChild(0).GetComponent<InputField>().text = "Странник";
		}
		Menu.AAAAAAAAAAAAAAAAbz();
	}

	public void QuitPanel()
	{
		GameObject gameObject = GameObject.Find("SoundEffect");
		gameObject.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("Sound/pda/contact_1");
		gameObject.GetComponent<AudioSource>().Play();
		Object.Destroy(base.gameObject);
	}
}
