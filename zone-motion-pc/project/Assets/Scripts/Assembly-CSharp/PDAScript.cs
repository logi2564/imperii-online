using UnityEngine;
using UnityEngine.UI;

public class PDAScript : MonoBehaviour
{
	public void OpenListOfCharacters()
	{
		Inventory.AAAAAAAAAAAAAAcb();
	}

	public void OpenTaskList()
	{
		Inventory.AAAAAAAAAAAAAAAAAAAAck();
	}

	public void OpenDiplomacy()
	{
		DiplomacyShow();
	}

	public void DiplomacyShow()
	{
		Inventory.AAAAAAAAAAAAAAAAAAAAAcf();
		GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Diplomacy/DiplomacyShow"));
		gameObject.name = "DiplomacyShow";
		gameObject.transform.SetParent(GameObject.Find("Canvas").transform);
		gameObject.transform.localPosition = new Vector3(0f, 0f);
		gameObject.transform.GetChild(3).transform.GetChild(0).GetComponent<RawImage>().texture = Data.Dealers[0].IconGroup;
		gameObject.transform.GetChild(3).transform.GetChild(1).GetComponent<Text>().text = PlayerPrefs.GetString("HeroName") + "\n" + Data.Dealers[0].DescriptionGroup;
		for (int i = 0; i < 13; i++)
		{
			gameObject.transform.GetChild(1).transform.GetChild(0).transform.GetChild(i).transform.GetChild(0).GetComponent<RawImage>().texture = Data.Dealers[i].IconGroup;
			gameObject.transform.GetChild(1).transform.GetChild(0).transform.GetChild(i).transform.GetChild(1).GetComponent<Text>().text = Data.Dealers[i].NameGroup + "\n" + Data.Dealers[i].DescriptionGroup;
			if (i == 0)
			{
				gameObject.transform.GetChild(1).transform.GetChild(0).transform.GetChild(i).transform.GetChild(1).GetComponent<Text>().text = PlayerPrefs.GetString("HeroName") + "\n" + Data.Dealers[i].DescriptionGroup;
			}
			for (int j = 0; j < 10; j++)
			{
				if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, i] == 0)
				{
					if (j <= 0)
					{
						gameObject.transform.GetChild(3).transform.GetChild(2).transform.GetChild(i).transform.GetChild(1).GetChild(j).GetComponent<RawImage>()
							.color = new Color(0.9f, 0.2f, 0.2f, 1f);
					}
					else
					{
						gameObject.transform.GetChild(3).transform.GetChild(2).transform.GetChild(i).transform.GetChild(1).GetChild(j).GetComponent<RawImage>()
							.color = new Color(0.75f, 0.75f, 0.75f, 0.6f);
					}
				}
				if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, i] == 1)
				{
					if (j <= 1)
					{
						gameObject.transform.GetChild(3).transform.GetChild(2).transform.GetChild(i).transform.GetChild(1).GetChild(j).GetComponent<RawImage>()
							.color = new Color(0.9f, 0.8f, 0.2f, 1f);
					}
					else
					{
						gameObject.transform.GetChild(3).transform.GetChild(2).transform.GetChild(i).transform.GetChild(1).GetChild(j).GetComponent<RawImage>()
							.color = new Color(0.75f, 0.75f, 0.75f, 0.6f);
					}
				}
				if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, i] > 1)
				{
					if (j <= AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, i])
					{
						gameObject.transform.GetChild(3).transform.GetChild(2).transform.GetChild(i).transform.GetChild(1).GetChild(j).GetComponent<RawImage>()
							.color = new Color(0.2f, 0.94f, 0.1f, 1f);
					}
					else
					{
						gameObject.transform.GetChild(3).transform.GetChild(2).transform.GetChild(i).transform.GetChild(1).GetChild(j).GetComponent<RawImage>()
							.color = new Color(0.75f, 0.75f, 0.75f, 0.6f);
					}
				}
			}
		}
		gameObject.transform.GetChild(3).transform.GetChild(3).gameObject.SetActive(false);
		if (Data.CharacterD[CharacterMotion._curCharacter].TypeChInt != 0 && CharacterMotion._curCharacter == 0)
		{
			gameObject.transform.GetChild(3).transform.GetChild(4).gameObject.SetActive(true);
			gameObject.transform.GetChild(3).transform.GetChild(4).GetChild(0).GetComponent<Text>()
				.text = "Покинуть группировку: " + Data.CharacterD[CharacterMotion._curCharacter].TypeChar;
		}
		else
		{
			gameObject.transform.GetChild(3).transform.GetChild(4).gameObject.SetActive(false);
		}
		float num = Screen.width;
		num /= 1280f;
		gameObject.transform.localScale = new Vector3(num, num);
	}

	public void SettingsShow()
	{
		Inventory.AAAAAAAAAAAAAAAAAAAAAcf();
		GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Settings/SettingsGameShow"));
		gameObject.name = "SettingsPanelShow";
		gameObject.transform.SetParent(GameObject.Find("Canvas").transform);
		gameObject.transform.localPosition = new Vector3(0f, 0f);
		gameObject.transform.GetChild(0).GetChild(0).GetComponent<Text>()
			.text = "Скорость игры: " + (int)(AAAAAAAAAAAAAAAAAAAAct.GameSpeed * 13.4f);
		gameObject.gameObject.transform.GetChild(1).GetChild(0).GetComponent<Text>()
			.text = "Громкость: " + (int)(Inventory.AudioGame.volume * 100f);
		gameObject.gameObject.transform.GetChild(2).GetChild(0).GetComponent<Text>()
			.text = "Громкость фоновой музыки: " + (int)(Inventory.SoundBG.volume * 100f);
		if (Inventory.AudioGame.mute)
		{
			gameObject.gameObject.transform.GetChild(3).GetChild(0).GetComponent<Text>()
				.text = "Mute";
			gameObject.gameObject.transform.GetChild(3).GetChild(1).GetChild(0)
				.GetComponent<RawImage>()
				.texture = (Texture2D)Resources.Load("Sprites/IconGUI/mute64w");
		}
		else
		{
			gameObject.gameObject.transform.GetChild(3).GetChild(0).GetComponent<Text>()
				.text = "Mute off";
			gameObject.gameObject.transform.GetChild(3).GetChild(1).GetChild(0)
				.GetComponent<RawImage>()
				.texture = (Texture2D)Resources.Load("Sprites/IconGUI/muteOff64w");
		}
		if (Inventory._HelpBool)
		{
			gameObject.gameObject.transform.GetChild(4).GetChild(1).GetChild(0)
				.GetComponent<RawImage>()
				.texture = (Texture2D)Resources.Load("Sprites/IconGUI/Help64W");
		}
		else
		{
			gameObject.gameObject.transform.GetChild(4).GetChild(1).GetChild(0)
				.GetComponent<RawImage>()
				.texture = (Texture2D)Resources.Load("Sprites/IconGUI/Help64offW");
		}
		float num = Screen.width;
		num /= 1280f;
		gameObject.transform.localScale = new Vector3(num, num);
	}

	public void ExitMenu()
	{
		SaveLoad.AAAAAAAAAAAAAAAAAAde("AutoSave", false);
		GameObject.Find("Main Camera").GetComponent<LoadingCircleScript>().AAAAAAAAAAAAAAAAe("Menu", string.Empty);
	}

	public void ShowLeaderboard()
	{
		GPSscript.AAAAAAAAAAAAAAAAAAAp();
	}

	public void ShowAchievement()
	{
		GPSscript.AAAAAAAAAAAAAAAAAk();
	}

	public void SaveLoadPanelShow()
	{
		Inventory.AAAAAAAAAAAAAAAAAAAAAcf();
		GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/SaveLoad/PanelSaveLoad"));
		gameObject.name = "PanelSaveLoad";
		gameObject.transform.SetParent(GameObject.Find("Canvas").transform);
		gameObject.transform.localPosition = new Vector3(0f, 0f);
		float num = Screen.width;
		num /= 1920f;
		gameObject.transform.localScale = new Vector3(num, num);
	}

	public void EncyclopediaPanelShow()
	{
		Inventory.AAAAAAAAAAAAAAAAAAAAAcf();
		GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Encyclopedia/Encyclopedia"));
		gameObject.name = "Encyclopedia";
		gameObject.transform.SetParent(base.gameObject.transform);
		gameObject.transform.localPosition = new Vector3(0f, 0f);
		float num = Screen.width;
		num /= 1280f;
		gameObject.transform.localScale = new Vector3(1f, 1f);
	}
}
