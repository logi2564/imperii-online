using UnityEngine;
using UnityEngine.UI;

public class Diplomacy : MonoBehaviour
{
	private int AAAAAAAAAAAAAAAb;

	private int AAAAAAAAAAAAAAAAAAb;

	public void QuitDiplomacy()
	{
		bool flag = true;
		for (int i = 0; i < 12; i++)
		{
			if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.CharacterD[CharacterMotion._curCharacter].TypeChInt, i] == 0)
			{
				flag = false;
				break;
			}
		}
		if (flag)
		{
			GPSscript.AAAAAAAAAAAAAAAAAAAAe("CgkI2OGbhtMLEAIQBw");
		}
		else
		{
			Debug.Log("NOdip");
		}
		Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/contact_1");
		Inventory.SoundMenu.Play();
		Object.Destroy(GameObject.Find("DiplomacyShow"));
	}

	public void AAAAAAAAAAAAAAAAAAAg(int AAAAAAAAAAAAAAAAAh)
	{
		AAAAAAAAAAAAAAAb = AAAAAAAAAAAAAAAAAh;
		Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/contact_1");
		Inventory.SoundMenu.Play();
		GameObject gameObject = base.gameObject;
		gameObject.transform.GetChild(3).transform.GetChild(0).GetComponent<RawImage>().texture = Data.Dealers[AAAAAAAAAAAAAAAAAh].IconGroup;
		gameObject.transform.GetChild(3).transform.GetChild(1).GetComponent<Text>().text = Data.Dealers[AAAAAAAAAAAAAAAAAh].NameGroup + "\n" + Data.Dealers[AAAAAAAAAAAAAAAAAh].DescriptionGroup;
		if (AAAAAAAAAAAAAAAAAh == 0)
		{
			gameObject.transform.GetChild(3).transform.GetChild(1).GetComponent<Text>().text = PlayerPrefs.GetString("HeroName") + "\n" + Data.Dealers[AAAAAAAAAAAAAAAAAh].DescriptionGroup;
		}
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
				if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[AAAAAAAAAAAAAAAAAh, i] == 0)
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
				if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[AAAAAAAAAAAAAAAAAh, i] == 1)
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
				if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[AAAAAAAAAAAAAAAAAh, i] > 1)
				{
					if (j <= AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[AAAAAAAAAAAAAAAAAh, i])
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
			if (AAAAAAAAAAAAAAAAAh == Data.CharacterD[CharacterMotion._curCharacter].TypeChInt || AAAAAAAAAAAAAAAAAh == 0)
			{
				gameObject.transform.GetChild(3).transform.GetChild(3).gameObject.SetActive(false);
			}
			else
			{
				gameObject.transform.GetChild(3).transform.GetChild(3).gameObject.SetActive(true);
				if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.CharacterD[CharacterMotion._curCharacter].TypeChInt, AAAAAAAAAAAAAAAAAh] <= 0)
				{
					gameObject.transform.GetChild(3).transform.GetChild(3).GetChild(0).GetComponent<Text>()
						.text = "Улучшить отношения за " + 150000 + "ru";
					AAAAAAAAAAAAAAAAAAb = 150000;
				}
				if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.CharacterD[CharacterMotion._curCharacter].TypeChInt, AAAAAAAAAAAAAAAAAh] == 1)
				{
					gameObject.transform.GetChild(3).transform.GetChild(3).GetChild(0).GetComponent<Text>()
						.text = "Улучшить отношения за " + 100000 + "ru";
					AAAAAAAAAAAAAAAAAAb = 100000;
				}
				if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.CharacterD[CharacterMotion._curCharacter].TypeChInt, AAAAAAAAAAAAAAAAAh] > 1)
				{
					gameObject.transform.GetChild(3).transform.GetChild(3).GetChild(0).GetComponent<Text>()
						.text = "Улучшить отношения за " + 50000 + "ru";
					AAAAAAAAAAAAAAAAAAb = 50000;
				}
			}
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
		}
	}

	public void ImproveRelationships()
	{
		if (Data.CharacterD[CharacterMotion._curCharacter].Cash >= AAAAAAAAAAAAAAAAAAb)
		{
			if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.CharacterD[CharacterMotion._curCharacter].TypeChInt, AAAAAAAAAAAAAAAb] <= 0)
			{
				Inventory.MessagePanel(string.Concat("\nУлучшены отношения между группировками: ", Data.CharacterD[CharacterMotion._curCharacter].TypeChar, " и ", Data.Dealers[AAAAAAAAAAAAAAAb].NameGroup, "\n", Data.Dealers[AAAAAAAAAAAAAAAb].NameGroup, ":\nНаши бойцы перестанут вас атаковать, пока вы не нарушите перемирие..."));
			}
			if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.CharacterD[CharacterMotion._curCharacter].TypeChInt, AAAAAAAAAAAAAAAb] == 1)
			{
				Inventory.MessagePanel(string.Concat("\nУлучшены отношения между группировками: ", Data.CharacterD[CharacterMotion._curCharacter].TypeChar, " и ", Data.Dealers[AAAAAAAAAAAAAAAb].NameGroup, "\n", Data.Dealers[AAAAAAAAAAAAAAAb].NameGroup, ":\nНеплохо! Наши отношения крепнут, бойцы довольны..."));
			}
			if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.CharacterD[CharacterMotion._curCharacter].TypeChInt, AAAAAAAAAAAAAAAb] > 1)
			{
				Inventory.MessagePanel(string.Concat("\nУлучшены отношения между группировками: ", Data.CharacterD[CharacterMotion._curCharacter].TypeChar, " и ", Data.Dealers[AAAAAAAAAAAAAAAb].NameGroup, "\n", Data.Dealers[AAAAAAAAAAAAAAAb].NameGroup, ":\nНам определенно нравится ваш подход к дипломатии!..."));
			}
			Data.CharacterD[CharacterMotion._curCharacter].Cash -= AAAAAAAAAAAAAAAAAAb;
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.CharacterD[CharacterMotion._curCharacter].TypeChInt, AAAAAAAAAAAAAAAb]++;
			if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.CharacterD[CharacterMotion._curCharacter].TypeChInt, AAAAAAAAAAAAAAAb] > 9)
			{
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.CharacterD[CharacterMotion._curCharacter].TypeChInt, AAAAAAAAAAAAAAAb] = 9;
			}
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[AAAAAAAAAAAAAAAb, Data.CharacterD[CharacterMotion._curCharacter].TypeChInt]++;
			if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[AAAAAAAAAAAAAAAb, Data.CharacterD[CharacterMotion._curCharacter].TypeChInt] > 9)
			{
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[AAAAAAAAAAAAAAAb, Data.CharacterD[CharacterMotion._curCharacter].TypeChInt] = 9;
			}
			AAAAAAAAAAAAAAAAAAAg(AAAAAAAAAAAAAAAb);
		}
		else
		{
			Inventory.MessagePanel("Для улучшения отношений группировок недостаточно средств...");
		}
	}

	public void LeaveGroup()
	{
		int typeChInt = Data.CharacterD[CharacterMotion._curCharacter].TypeChInt;
		Data.CharacterD[CharacterMotion._curCharacter].TypeChar = AAAAAAAAAAAAAAAAf.TypeCharacter.Странник;
		Data.CharacterD[CharacterMotion._curCharacter].NameCharac = AAAAAAAAAAAAAAAAf.TypeCharacter.Странник.ToString();
		GameObject.Find(Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/IconGroup/GasMask64A");
		for (int i = 1; i < Data.CharacterD.Count; i++)
		{
			if (Data.CharacterD[i].TypeChInt == Data.CharacterD[CharacterMotion._curCharacter].TypeChInt)
			{
				Data.CharacterD[i].ControlGamer = false;
			}
		}
		AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.CharacterD[CharacterMotion._curCharacter].TypeChInt] -= 3;
		if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.CharacterD[CharacterMotion._curCharacter].TypeChInt] <= 1)
		{
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.CharacterD[CharacterMotion._curCharacter].TypeChInt] = 1;
		}
		AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.CharacterD[CharacterMotion._curCharacter].TypeChInt, 0] -= 3;
		if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.CharacterD[CharacterMotion._curCharacter].TypeChInt, 0] <= 1)
		{
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.CharacterD[CharacterMotion._curCharacter].TypeChInt, 0] = 1;
		}
		Data.CharacterD[CharacterMotion._curCharacter].TypeChInt = 0;
		AAAAAAAAAAAAAAAAAAAg(0);
		Inventory.MessagePanel("\n" + PlayerPrefs.GetString("HeroName") + " покинул группировку: " + Data.Dealers[typeChInt].NameGroup);
	}
}
