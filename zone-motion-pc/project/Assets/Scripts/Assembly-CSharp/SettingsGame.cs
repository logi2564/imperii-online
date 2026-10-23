using UnityEngine;
using UnityEngine.UI;

public class SettingsGame : MonoBehaviour
{
	public void DestroySettingsPanel()
	{
		Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/contact_1");
		Inventory.SoundMenu.Play();
		Object.Destroy(base.gameObject);
	}

	public void RenameHero()
	{
		Inventory.RenameHero();
	}

	public void SpeedGameIncrease()
	{
		AAAAAAAAAAAAAAAAAAAAct.GameSpeed += 0.2f;
		base.gameObject.transform.GetChild(0).GetChild(0).GetComponent<Text>()
			.text = "Скорость игры: " + (int)(AAAAAAAAAAAAAAAAAAAAct.GameSpeed * 13.4f);
		AAAAAAAAAAAAAAAAAAcz.AAAAAAAAAAAAAAAbs();
	}

	public void SpeedGameReduce()
	{
		AAAAAAAAAAAAAAAAAAAAct.GameSpeed -= 0.2f;
		base.gameObject.transform.GetChild(0).GetChild(0).GetComponent<Text>()
			.text = "Скорость игры: " + (int)(AAAAAAAAAAAAAAAAAAAAct.GameSpeed * 13.4f);
		AAAAAAAAAAAAAAAAAAcz.AAAAAAAAAAAAAAAbs();
	}

	public void VolumeIncrease()
	{
		Inventory.AudioGame.volume += 0.05f;
		Inventory.SoundMenu.volume = Inventory.AudioGame.volume / 3f;
		Inventory.SoundEffect.mute = Inventory.AudioGame.mute;
		Inventory.SoundEffect.volume = Inventory.AudioGame.volume;
		Inventory.AAAAAAAAAAAAAAAAAAAAAcf();
		if (Data.CharacterD.Count > 0)
		{
			for (int i = 0; i < Data.CharacterD.Count; i++)
			{
				GameObject.Find(Data.CharacterD[i].CharUnits.name).GetComponent<AudioSource>().volume -= 0.05f;
			}
		}
		base.gameObject.transform.GetChild(1).GetChild(0).GetComponent<Text>()
			.text = "Громкость: " + (int)(Inventory.AudioGame.volume * 100f);
		AAAAAAAAAAAAAAAAAAcz.AAAAAAAAAAAAAAAbs();
	}

	public void VolumeReduce()
	{
		Inventory.AudioGame.volume -= 0.05f;
		Inventory.SoundMenu.volume = Inventory.AudioGame.volume / 3f;
		Inventory.SoundEffect.mute = Inventory.AudioGame.mute;
		Inventory.SoundEffect.volume = Inventory.AudioGame.volume;
		Inventory.AAAAAAAAAAAAAAAAAAAAAcf();
		if (Data.CharacterD.Count > 0)
		{
			for (int i = 0; i < Data.CharacterD.Count; i++)
			{
				GameObject.Find(Data.CharacterD[i].CharUnits.name).GetComponent<AudioSource>().volume -= 0.05f;
			}
		}
		base.gameObject.transform.GetChild(1).GetChild(0).GetComponent<Text>()
			.text = "Громкость: " + (int)(Inventory.AudioGame.volume * 100f);
		AAAAAAAAAAAAAAAAAAcz.AAAAAAAAAAAAAAAbs();
	}

	public void VolumeBGIncrease()
	{
		Inventory.SoundBG.volume += 0.05f;
		Inventory.AAAAAAAAAAAAAAAAAAAAAcf();
		base.gameObject.transform.GetChild(2).GetChild(0).GetComponent<Text>()
			.text = "Громкость фоновой музыки: " + (int)(Inventory.SoundBG.volume * 100f);
		AAAAAAAAAAAAAAAAAAcz.AAAAAAAAAAAAAAAbs();
	}

	public void VolumeBGReduce()
	{
		Inventory.SoundBG.volume -= 0.05f;
		Inventory.AAAAAAAAAAAAAAAAAAAAAcf();
		base.gameObject.transform.GetChild(2).GetChild(0).GetComponent<Text>()
			.text = "Громкость фоновой музыки: " + (int)(Inventory.SoundBG.volume * 100f);
		AAAAAAAAAAAAAAAAAAcz.AAAAAAAAAAAAAAAbs();
	}

	public void Mute()
	{
		if (Inventory.AudioGame.mute)
		{
			Inventory.AudioGame.mute = false;
			Inventory.SoundMenu.mute = false;
			Inventory.SoundBG.mute = false;
			Inventory.SoundEffect.mute = Inventory.AudioGame.mute;
			Inventory.SoundEffect.volume = Inventory.AudioGame.volume;
			Inventory.AAAAAAAAAAAAAAAAAAAAAcf();
			if (Data.CharacterD.Count > 0)
			{
				for (int i = 0; i < Data.CharacterD.Count; i++)
				{
					Data.CharacterD[i].CharUnits.GetComponent<AudioSource>().mute = false;
				}
			}
			base.gameObject.transform.GetChild(3).GetChild(0).GetComponent<Text>()
				.text = "Mute off";
			base.gameObject.transform.GetChild(3).GetChild(1).GetChild(0)
				.GetComponent<RawImage>()
				.texture = (Texture2D)Resources.Load("Sprites/IconGUI/muteOff64w");
		}
		else
		{
			Inventory.AudioGame.mute = true;
			Inventory.SoundMenu.mute = true;
			Inventory.SoundBG.mute = true;
			Inventory.SoundEffect.mute = Inventory.AudioGame.mute;
			Inventory.SoundEffect.volume = Inventory.AudioGame.volume;
			Inventory.AAAAAAAAAAAAAAAAAAAAAcf();
			if (Data.CharacterD.Count > 0)
			{
				for (int j = 0; j < Data.CharacterD.Count; j++)
				{
					Data.CharacterD[j].CharUnits.GetComponent<AudioSource>().mute = true;
				}
			}
			base.gameObject.transform.GetChild(3).GetChild(0).GetComponent<Text>()
				.text = "Mute";
			base.gameObject.transform.GetChild(3).GetChild(1).GetChild(0)
				.GetComponent<RawImage>()
				.texture = (Texture2D)Resources.Load("Sprites/IconGUI/mute64w");
		}
		AAAAAAAAAAAAAAAAAAcz.AAAAAAAAAAAAAAAbs();
	}

	public void Hacking()
	{
		Inventory._HelpBool = !Inventory._HelpBool;
		if (Inventory._HelpBool)
		{
			base.gameObject.transform.GetChild(4).GetChild(1).GetChild(0)
				.GetComponent<RawImage>()
				.texture = (Texture2D)Resources.Load("Sprites/IconGUI/Help64W");
		}
		else
		{
			base.gameObject.transform.GetChild(4).GetChild(1).GetChild(0)
				.GetComponent<RawImage>()
				.texture = (Texture2D)Resources.Load("Sprites/IconGUI/Help64offW");
		}
	}
}
