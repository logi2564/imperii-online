using System.Collections;
using UnityEngine;

public class CoroutinsAll : MonoBehaviour
{
	public IEnumerator AAAAAAAAAAAAAAAAAAcg()
	{
		yield return new WaitForSeconds(0.001f);
		GameObject.Find("Data").GetComponent<Inventory>().AAAAAAAAAAAAAAAAAAcg();
	}

	public IEnumerator AAAAAAAAAAAAAAAAAAch()
	{
		yield return new WaitForSeconds(0.001f);
		int otm = Random.Range(0, 3);
		if (otm == 1)
		{
			II.AAAAAAAAAAAAAAAAAAch();
			StartCoroutine(AAAAAAAAAAAAAAAAAAAbm());
		}
		else
		{
			yield return AAAAAAAAAAAAAAAAAAcg();
		}
	}

	public IEnumerator AAAAAAAAAAAAAAAAAAAbm()
	{
		yield return new WaitForSeconds(10f / AAAAAAAAAAAAAAAAAAAAct.GameSpeed);
		StartCoroutine(AAAAAAAAAAAAAAAAAAcg());
	}

	public IEnumerator AAAAAAAAAAAAAAAAAAAbn()
	{
		yield return new WaitForSeconds(Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.RateOfFire / AAAAAAAAAAAAAAAAAAAAct.GameSpeed * 3f);
		Inventory.SoundEffect.GetComponent<AudioSource>().clip = Data.CharacterD[CharacterMotion._curCharacter].NPSattackVoice[Random.Range(0, Data.CharacterD[CharacterMotion._curCharacter].NPSattackVoice.Count - 1)];
		Inventory.SoundEffect.GetComponent<AudioSource>().Play();
	}

	public IEnumerator AAAAAAAAAAAAAAAAAbl()
	{
		yield return new WaitForSeconds(0.001f);
		Data.CharacterD[CharacterMotion._curCharacter].Alarm = false;
		II.AAAAAAAAAAAAAAAAAAAbp();
		if (Random.Range(0, 3) == 0 && !Inventory.SoundEffect.GetComponent<AudioSource>().isPlaying && Data.CharacterD[CharacterMotion._curCharacter].TypeChInt != 9 && Data.CharacterD[CharacterMotion._curCharacter].TypeChInt != 10 && Data.CharacterD[Inventory._currentCharacterNumber].TypeChInt != 9 && Data.CharacterD[Inventory._currentCharacterNumber].TypeChInt != 10 && Data.CharacterD[CharacterMotion._curCharacter].NPSattackVoice.Count > 0)
		{
			yield return AAAAAAAAAAAAAAAAAAAbn();
		}
		AAAAAAAAAAAAAAbj();
		if (CharacterMotion._DistansMove < Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.MinRange)
		{
			Debug.Log("CharacterMotion._DistansMove < minRange///" + CharacterMotion._DistansMove);
			Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[19] = Data.CharacterD[CharacterMotion._curCharacter].WeaponChar;
			Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new PM();
			Data.CharacterD[CharacterMotion._curCharacter].CharUnits.GetComponent<AudioSource>().clip = Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.AudioFire;
			Data.CharacterD[CharacterMotion._curCharacter].CharUnits.GetComponent<AudioSource>().Play();
			yield return new WaitForSeconds(0.6f / AAAAAAAAAAAAAAAAAAAAct.GameSpeed);
			CharacterMotion._PointsMove--;
			if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Cartridge > 0)
			{
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Cartridge--;
				if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Cartridge < 1)
				{
					Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Cartridge = 0;
				}
				II._Fire.GetComponent<LineRenderer>().SetPosition(0, Data.CharacterD[CharacterMotion._curCharacter].CharUnits.transform.position);
				II._Fire.GetComponent<LineRenderer>().SetPosition(1, GameObject.Find(II._EnemyTarget.CharUnits.name).transform.position);
				GameObject.Find(II._EnemyTarget.CurGexChar.NameGex).GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 0.8f);
				Data.CharacterD[Inventory._currentCharacterNumber].Alarm = true;
				Data.CharacterD[Inventory._currentCharacterNumber].Aggressor = Data.CharacterD[CharacterMotion._curCharacter].NameU;
				Inventory._CurProtectoinSuit = Data.CharacterD[Inventory._currentCharacterNumber].SuitChar.Protection + Data.CharacterD[Inventory._currentCharacterNumber].ArtContainers[0].Protection + Data.CharacterD[Inventory._currentCharacterNumber].ArtContainers[1].Protection + Data.CharacterD[Inventory._currentCharacterNumber].ArtContainers[2].Protection + Data.CharacterD[Inventory._currentCharacterNumber].ArtContainers[3].Protection;
				Inventory._CurProtectoinSuit += Data.CharacterD[Inventory._currentCharacterNumber].SuitChar.UpGrade;
				Inventory._CurProtectoinSuit += Data.CharacterD[Inventory._currentCharacterNumber].SuitChar.UpGrade;
				Inventory._CurProtectoinSuit = Inventory._CurProtectoinSuit / 1000f * Data.CharacterD[Inventory._currentCharacterNumber].SuitChar.State;
				Inventory._CurDamage = Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Damage - Inventory._CurProtectoinSuit;
				if (Data.CharacterD[Inventory._currentCharacterNumber].ControlGamer)
				{
					Inventory._CurDamage /= SaveLoad.Difficulty;
				}
				Inventory._CurDamage += Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.UpGrade;
				if (Data.CharacterD[CharacterMotion._curCharacter].TypeChar == AAAAAAAAAAAAAAAAf.TypeCharacter.Контролер)
				{
					Inventory._CurDamage -= Data.CharacterD[Inventory._currentCharacterNumber].PSIprotection;
					Inventory._CurDamage -= Data.CharacterD[Inventory._currentCharacterNumber].SuitChar.PsiProtection;
					for (int i = 0; i < 4; i++)
					{
						Inventory._CurDamage -= Data.CharacterD[Inventory._currentCharacterNumber].ArtContainers[i].PsiProtection;
					}
				}
				if (Inventory._CurDamage < 1f)
				{
					Inventory._CurDamage = 1f;
				}
				Data.CharacterD[Inventory._currentCharacterNumber].CurHealth -= Inventory._CurDamage;
				Data.CharacterD[Inventory._currentCharacterNumber].Bleeding += Random.Range(0, 2);
				Inventory._CurDamageForSuit = Inventory._CurDamage / 10f;
				Data.CharacterD[Inventory._currentCharacterNumber].SuitChar.State -= Inventory._CurDamageForSuit;
				if (Data.CharacterD[Inventory._currentCharacterNumber].SuitChar.SingModification)
				{
					Data.CharacterD[Inventory._currentCharacterNumber].SuitChar.State -= Inventory._CurDamageForSuit;
				}
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.State -= Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Wear;
				Data.CharacterD[Inventory._currentCharacterNumber].CharUnits.transform.GetChild(0).transform.localPosition = new Vector3((Data.CharacterD[Inventory._currentCharacterNumber].CurHealth / 100f - 0.5f) / 2f, 0.5f);
				Data.CharacterD[Inventory._currentCharacterNumber].CharUnits.transform.GetChild(0).transform.localScale = new Vector3(Data.CharacterD[Inventory._currentCharacterNumber].CurHealth / 100f, 0.3f);
				AAAAAAAAAAAAAAAAAAci();
				if (!Data.CharacterD[Inventory._currentCharacterNumber].ControlGamer && !Data.CharacterD[Inventory._currentCharacterNumber].Life)
				{
					AAAAAAAAAAAAAAAAAci.AAAAAAAAAAAAAAAAcf();
				}
				yield return new WaitForSeconds(0.16f);
				GameObject.Find(II._EnemyTarget.CurGexChar.NameGex).GetComponent<SpriteRenderer>().color = new Color(0.45f, 0.45f, 0.25f, 0.25f);
				II._Fire.GetComponent<LineRenderer>().SetPosition(0, CharacterMotion._CameraCM.transform.position);
				II._Fire.GetComponent<LineRenderer>().SetPosition(1, CharacterMotion._CameraCM.transform.position);
				Inventory.AAAAAAAAAAAAAAAAAAAAAce();
				Inventory.AAAAAAAAAAAAAAAAAbx();
				Methods.AAAAAAAAAAAAAAcn();
				if (CharacterMotion._PointsMove > 0)
				{
					yield return II.AAAAAAAAAAAAAAbs();
					yield break;
				}
				if (CharacterMotion._PointsMove <= 0)
				{
					yield return AAAAAAAAAAAAAAAAAAcg();
					yield break;
				}
			}
			Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[20];
			Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[20] = new AAAAAAAAAAAAAAAAAAbi();
		}
		if (CharacterMotion._DistansMove < Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.MinRange)
		{
			yield break;
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.AutomaticFire)
		{
			Data.CharacterD[CharacterMotion._curCharacter].CharUnits.GetComponent<AudioSource>().clip = Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.AudioFire;
			Data.CharacterD[CharacterMotion._curCharacter].CharUnits.GetComponent<AudioSource>().Play();
			yield return new WaitForSeconds(Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.RateOfFire / AAAAAAAAAAAAAAAAAAAAct.GameSpeed);
			Data.CharacterD[CharacterMotion._curCharacter].CharUnits.GetComponent<AudioSource>().Play();
			yield return new WaitForSeconds(Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.RateOfFire / AAAAAAAAAAAAAAAAAAAAct.GameSpeed);
			Data.CharacterD[CharacterMotion._curCharacter].CharUnits.GetComponent<AudioSource>().Play();
			yield return new WaitForSeconds(Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.RateOfFire / AAAAAAAAAAAAAAAAAAAAct.GameSpeed);
		}
		if (!Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.AutomaticFire)
		{
			Data.CharacterD[CharacterMotion._curCharacter].CharUnits.GetComponent<AudioSource>().clip = Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.AudioFire;
			Data.CharacterD[CharacterMotion._curCharacter].CharUnits.GetComponent<AudioSource>().Play();
			yield return new WaitForSeconds(0.6f / AAAAAAAAAAAAAAAAAAAAct.GameSpeed);
		}
		CharacterMotion._PointsMove--;
		if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Cartridge <= 0)
		{
			yield break;
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.AutomaticFire)
		{
			Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Cartridge -= 3;
			if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Cartridge < 1)
			{
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Cartridge = 0;
			}
		}
		else
		{
			Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Cartridge--;
			if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Cartridge < 1)
			{
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Cartridge = 0;
			}
		}
		II._Fire.GetComponent<LineRenderer>().SetPosition(0, Data.CharacterD[CharacterMotion._curCharacter].CharUnits.transform.position);
		II._Fire.GetComponent<LineRenderer>().SetPosition(1, GameObject.Find(II._EnemyTarget.CharUnits.name).transform.position);
		GameObject.Find(II._EnemyTarget.CurGexChar.NameGex).GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 0.8f);
		Data.CharacterD[Inventory._currentCharacterNumber].Alarm = true;
		Data.CharacterD[Inventory._currentCharacterNumber].Aggressor = Data.CharacterD[CharacterMotion._curCharacter].NameU;
		Inventory._CurProtectoinSuit = Data.CharacterD[Inventory._currentCharacterNumber].SuitChar.Protection + Data.CharacterD[Inventory._currentCharacterNumber].ArtContainers[0].Protection + Data.CharacterD[Inventory._currentCharacterNumber].ArtContainers[1].Protection + Data.CharacterD[Inventory._currentCharacterNumber].ArtContainers[2].Protection + Data.CharacterD[Inventory._currentCharacterNumber].ArtContainers[3].Protection;
		Inventory._CurProtectoinSuit += Data.CharacterD[Inventory._currentCharacterNumber].SuitChar.UpGrade;
		Inventory._CurProtectoinSuit += Data.CharacterD[Inventory._currentCharacterNumber].SuitChar.UpGrade;
		Inventory._CurProtectoinSuit = Inventory._CurProtectoinSuit / 1000f * Data.CharacterD[Inventory._currentCharacterNumber].SuitChar.State;
		Inventory._CurDamage = Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Damage - Inventory._CurProtectoinSuit;
		if (Data.CharacterD[Inventory._currentCharacterNumber].ControlGamer)
		{
			Inventory._CurDamage /= SaveLoad.Difficulty;
		}
		Inventory._CurDamage += Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.UpGrade;
		if (Inventory._CurDamage < 1f)
		{
			Inventory._CurDamage = 1f;
		}
		Data.CharacterD[Inventory._currentCharacterNumber].CurHealth -= Inventory._CurDamage;
		Data.CharacterD[Inventory._currentCharacterNumber].Bleeding += Random.Range(0, 2);
		Inventory._CurDamageForSuit = Inventory._CurDamage / 10f;
		Data.CharacterD[Inventory._currentCharacterNumber].SuitChar.State -= Inventory._CurDamageForSuit;
		if (Data.CharacterD[Inventory._currentCharacterNumber].SuitChar.SingModification)
		{
			Data.CharacterD[Inventory._currentCharacterNumber].SuitChar.State -= Inventory._CurDamageForSuit;
		}
		Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.State -= Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Wear;
		Data.CharacterD[Inventory._currentCharacterNumber].CharUnits.transform.GetChild(0).transform.localPosition = new Vector3((Data.CharacterD[Inventory._currentCharacterNumber].CurHealth / 100f - 0.5f) / 2f, 0.5f);
		Data.CharacterD[Inventory._currentCharacterNumber].CharUnits.transform.GetChild(0).transform.localScale = new Vector3(Data.CharacterD[Inventory._currentCharacterNumber].CurHealth / 100f, 0.3f);
		AAAAAAAAAAAAAAAAAAci();
		if (!Data.CharacterD[Inventory._currentCharacterNumber].ControlGamer && !Data.CharacterD[Inventory._currentCharacterNumber].Life)
		{
			AAAAAAAAAAAAAAAAAci.AAAAAAAAAAAAAAAAcf();
		}
		yield return new WaitForSeconds(0.16f);
		II._EnemyTarget.CurGexChar.GexGO.GetComponent<SpriteRenderer>().color = new Color(0.45f, 0.45f, 0.25f, 0.25f);
		II._Fire.GetComponent<LineRenderer>().SetPosition(0, CharacterMotion._CameraCM.transform.position);
		II._Fire.GetComponent<LineRenderer>().SetPosition(1, CharacterMotion._CameraCM.transform.position);
		Inventory.AAAAAAAAAAAAAAAAAAAAAce();
		Inventory.AAAAAAAAAAAAAAAAAbx();
		Methods.AAAAAAAAAAAAAAcn();
		if (CharacterMotion._PointsMove > 0)
		{
			yield return II.AAAAAAAAAAAAAAbs();
		}
		else if (CharacterMotion._PointsMove <= 0)
		{
			yield return AAAAAAAAAAAAAAAAAAcg();
		}
	}

	public IEnumerator AAAAAAAAAAAAAAAAbk()
	{
		yield return new WaitForSeconds(0.001f);
		Data.CharacterD[CharacterMotion._curCharacter].Alarm = false;
		II.AAAAAAAAAAAAAAAAAAcl();
		II.AAAAAAAAAAAAAAAAAAAAbx();
		yield return new WaitForSeconds(9f / AAAAAAAAAAAAAAAAAAAAct.GameSpeed);
		if (CharacterMotion._PointsMove > 0)
		{
			yield return II.AAAAAAAAAAAAAAbs();
		}
		else if (CharacterMotion._PointsMove <= 0)
		{
			yield return AAAAAAAAAAAAAAAAAAcg();
		}
	}

	public IEnumerator AAAAAAAAAAAAAAAAAAAAbx()
	{
		yield return new WaitForSeconds(0.001f);
		II.AAAAAAAAAAAAAAAAAAAAbx();
		foreach (ConstructorGex item in CharacterMotion._NextGex)
		{
			GameObject.Find(item.NameGex).GetComponent<SpriteRenderer>().color = new Color(0.45f, 0.45f, 0.25f, 0.25f);
		}
		yield return new WaitForSeconds(10f / AAAAAAAAAAAAAAAAAAAAct.GameSpeed);
		Inventory._GGActive = false;
		CharacterMotion.AAAAAAAAAAAAAAAAAAAAi();
		Data.CharacterD[CharacterMotion._curCharacter].Alarm = false;
		if (CharacterMotion._PointsMove > 0)
		{
			yield return II.AAAAAAAAAAAAAAbs();
		}
		else if (CharacterMotion._PointsMove <= 0)
		{
			yield return AAAAAAAAAAAAAAAAAAcg();
		}
	}

	public static void AAAAAAAAAAAAAAbj()
	{
		CharacterMotion._DistansMove = 0;
		if (Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.ID == II._EnemyTarget.CurGexChar.ID)
		{
			return;
		}
		CharacterMotion._NextGex.Add(II._EnemyTarget.CurGexChar);
		CharacterMotion._NextGex.Add(II._EnemyTarget.CurGexChar);
		CharacterMotion._CurGex = II._EnemyTarget.CurGexChar;
		while (true)
		{
			if (CharacterMotion._CurGex._YGex % 2 == 0)
			{
				foreach (ConstructorGex item in Gexa.GexLib)
				{
					if (item.NameGex == CharacterMotion._CurGex._XGex + "x" + (CharacterMotion._CurGex._YGex + 1) + "y")
					{
						CharacterMotion.GexNears[0] = item;
						if (Vector3.Distance(CharacterMotion.GexNears[0].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position))
						{
							CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[0];
							break;
						}
					}
				}
				foreach (ConstructorGex item2 in Gexa.GexLib)
				{
					if (item2.NameGex == CharacterMotion._CurGex._XGex - 1 + "x" + CharacterMotion._CurGex._YGex + "y")
					{
						CharacterMotion.GexNears[1] = item2;
						if (Vector3.Distance(CharacterMotion.GexNears[1].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position))
						{
							CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[1];
							break;
						}
					}
				}
				foreach (ConstructorGex item3 in Gexa.GexLib)
				{
					if (item3.NameGex == CharacterMotion._CurGex._XGex + "x" + (CharacterMotion._CurGex._YGex - 1) + "y")
					{
						CharacterMotion.GexNears[2] = item3;
						if (Vector3.Distance(CharacterMotion.GexNears[2].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position))
						{
							CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[2];
							break;
						}
					}
				}
				foreach (ConstructorGex item4 in Gexa.GexLib)
				{
					if (item4.NameGex == CharacterMotion._CurGex._XGex + 1 + "x" + (CharacterMotion._CurGex._YGex + 1) + "y")
					{
						CharacterMotion.GexNears[3] = item4;
						if (Vector3.Distance(CharacterMotion.GexNears[3].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position))
						{
							CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[3];
							break;
						}
					}
				}
				foreach (ConstructorGex item5 in Gexa.GexLib)
				{
					if (item5.NameGex == CharacterMotion._CurGex._XGex + 1 + "x" + CharacterMotion._CurGex._YGex + "y")
					{
						CharacterMotion.GexNears[4] = item5;
						if (Vector3.Distance(CharacterMotion.GexNears[4].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position))
						{
							CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[4];
							break;
						}
					}
				}
				foreach (ConstructorGex item6 in Gexa.GexLib)
				{
					if (item6.NameGex == CharacterMotion._CurGex._XGex + 1 + "x" + (CharacterMotion._CurGex._YGex - 1) + "y")
					{
						CharacterMotion.GexNears[5] = item6;
						if (Vector3.Distance(CharacterMotion.GexNears[5].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position))
						{
							CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[5];
							break;
						}
					}
				}
			}
			else
			{
				foreach (ConstructorGex item7 in Gexa.GexLib)
				{
					if (item7.NameGex == CharacterMotion._CurGex._XGex - 1 + "x" + (CharacterMotion._CurGex._YGex + 1) + "y")
					{
						CharacterMotion.GexNears[0] = item7;
						if (Vector3.Distance(CharacterMotion.GexNears[0].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position))
						{
							CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[0];
							break;
						}
					}
				}
				foreach (ConstructorGex item8 in Gexa.GexLib)
				{
					if (item8.NameGex == CharacterMotion._CurGex._XGex - 1 + "x" + CharacterMotion._CurGex._YGex + "y")
					{
						CharacterMotion.GexNears[1] = item8;
						if (Vector3.Distance(CharacterMotion.GexNears[1].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position))
						{
							CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[1];
							break;
						}
					}
				}
				foreach (ConstructorGex item9 in Gexa.GexLib)
				{
					if (item9.NameGex == CharacterMotion._CurGex._XGex - 1 + "x" + (CharacterMotion._CurGex._YGex - 1) + "y")
					{
						CharacterMotion.GexNears[2] = item9;
						if (Vector3.Distance(CharacterMotion.GexNears[2].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position))
						{
							CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[2];
							break;
						}
					}
				}
				foreach (ConstructorGex item10 in Gexa.GexLib)
				{
					if (item10.NameGex == CharacterMotion._CurGex._XGex + "x" + (CharacterMotion._CurGex._YGex + 1) + "y")
					{
						CharacterMotion.GexNears[3] = item10;
						if (Vector3.Distance(CharacterMotion.GexNears[3].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position))
						{
							CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[3];
							break;
						}
					}
				}
				foreach (ConstructorGex item11 in Gexa.GexLib)
				{
					if (item11.NameGex == CharacterMotion._CurGex._XGex + 1 + "x" + CharacterMotion._CurGex._YGex + "y")
					{
						CharacterMotion.GexNears[4] = item11;
						if (Vector3.Distance(CharacterMotion.GexNears[4].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position))
						{
							CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[4];
							break;
						}
					}
				}
				foreach (ConstructorGex item12 in Gexa.GexLib)
				{
					if (item12.NameGex == CharacterMotion._CurGex._XGex + "x" + (CharacterMotion._CurGex._YGex - 1) + "y")
					{
						CharacterMotion.GexNears[5] = item12;
						if (Vector3.Distance(CharacterMotion.GexNears[5].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position))
						{
							CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[5];
							break;
						}
					}
				}
			}
			if (CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar)
			{
				break;
			}
			CharacterMotion._CurGex = CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1];
			CharacterMotion._NextGex.Add(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1]);
			CharacterMotion._DistansMove++;
		}
		CharacterMotion._DistansMove++;
	}

	public static void AAAAAAAAAAAAAAAAAAci()
	{
		if (!(Data.CharacterD[Inventory._currentCharacterNumber].CurHealth <= 0f))
		{
			return;
		}
		Data.CharacterD[Inventory._currentCharacterNumber].CharUnits.GetComponent<AudioSource>().clip = Data.CharacterD[Inventory._currentCharacterNumber].AudioDeath;
		Data.CharacterD[Inventory._currentCharacterNumber].CharUnits.GetComponent<AudioSource>().Play();
		Methods.AAAAAAAAAAAAAAcm();
		Data.CharacterD[CharacterMotion._curCharacter].Skill++;
		Data.CharacterD[CharacterMotion._curCharacter].Bonus = true;
		if (Inventory._currentCharacterNumber != 0 && Data.CharacterD[Inventory._currentCharacterNumber].CharUnits.name != "Хищник")
		{
			if (Data.CharacterD[CharacterMotion._curCharacter].TypeChar != AAAAAAAAAAAAAAAAf.TypeCharacter.Контролер)
			{
				Data.CharacterD[Inventory._currentCharacterNumber].Life = false;
				Data.CharacterD[Inventory._currentCharacterNumber].TextureChar = Inventory._textureDethChar;
				Data.CharacterD[Inventory._currentCharacterNumber].CharUnits.GetComponent<SpriteRenderer>().sprite = Inventory._spriteDethChar;
				Data.CharacterD[Inventory._currentCharacterNumber].CharUnits.GetComponent<SpriteRenderer>().sortingOrder = 5;
				Data.CharacterD[Inventory._currentCharacterNumber].CharUnits.transform.GetChild(0).transform.localScale = new Vector3(0f, 0.3f);
				return;
			}
			Data.CharacterD[CharacterMotion._curCharacter].Skill++;
			SaveLoad.Difficulty -= 0.0002f;
			AAAAAAAAAAAAAAAAf aAAAAAAAAAAAAAAAf = Data.CharacterD[Inventory._currentCharacterNumber];
			Data.CharacterD[Inventory._currentCharacterNumber] = new AAAAAAAAAAAAAAAAAAAAAAv();
			Data.CharacterD[Inventory._currentCharacterNumber].NameU = NameCharacter.NameCharLib[Random.Range(0, NameCharacter.NameCharLib.Length - 1)] + ", Зомбированный";
			Data.CharacterD[Inventory._currentCharacterNumber].CharUnits.name = Data.CharacterD[Inventory._currentCharacterNumber].NameU;
			Data.CharacterD[Inventory._currentCharacterNumber].WeaponChar = aAAAAAAAAAAAAAAAf.WeaponChar;
			for (int i = 0; i < 4; i++)
			{
				Data.CharacterD[Inventory._currentCharacterNumber].ArtContainers[i] = aAAAAAAAAAAAAAAAf.ArtContainers[i];
			}
			for (int j = 0; j < 20; j++)
			{
				Data.CharacterD[Inventory._currentCharacterNumber].CharBackpack[j] = aAAAAAAAAAAAAAAAf.CharBackpack[j];
			}
			Data.CharacterD[Inventory._currentCharacterNumber].CharUnits.transform.position = aAAAAAAAAAAAAAAAf.CharUnits.transform.position;
			Data.CharacterD[Inventory._currentCharacterNumber].CurGexChar = aAAAAAAAAAAAAAAAf.CurGexChar;
			Data.CharacterD[Inventory._currentCharacterNumber].TaskGexChar = aAAAAAAAAAAAAAAAf.TaskGexChar;
			Inventory.AAAAAAAAAAAAAAAAAbx();
			Methods.AAAAAAAAAAAAAAcn();
			Data.CharacterD[Inventory._currentCharacterNumber].CharUnits.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume");
			Data.CharacterD[Inventory._currentCharacterNumber].CharUnits.GetComponent<AudioSource>().mute = bool.Parse(PlayerPrefs.GetString("Mute"));
			Data.CharacterD[Inventory._currentCharacterNumber].CharUnits.GetComponent<AudioSource>().clip = NameCharacter.StepZomby[Random.Range(0, NameCharacter.StepZomby.Length - 1)];
			Data.CharacterD[Inventory._currentCharacterNumber].CharUnits.GetComponent<AudioSource>().Play();
			Object.Destroy(aAAAAAAAAAAAAAAAf.CharUnits);
		}
		else
		{
			Data.CharacterD[Inventory._currentCharacterNumber].Life = false;
			Data.CharacterD[Inventory._currentCharacterNumber].TextureChar = Inventory._textureDethChar;
			Data.CharacterD[Inventory._currentCharacterNumber].CharUnits.GetComponent<SpriteRenderer>().sprite = Inventory._spriteDethChar;
			Data.CharacterD[Inventory._currentCharacterNumber].CharUnits.GetComponent<SpriteRenderer>().sortingOrder = 5;
			Data.CharacterD[Inventory._currentCharacterNumber].CharUnits.transform.GetChild(0).transform.localScale = new Vector3(0f, 0.3f);
			if (Inventory._currentCharacterNumber == 0)
			{
				II._EnemyTarget.CurGexChar.GexGO.GetComponent<SpriteRenderer>().color = new Color(0.45f, 0.45f, 0.25f, 0.25f);
				II._Fire.GetComponent<LineRenderer>().SetPosition(0, CharacterMotion._CameraCM.transform.position);
				II._Fire.GetComponent<LineRenderer>().SetPosition(1, CharacterMotion._CameraCM.transform.position);
				CharacterMotion._curCharacter = 0;
				GameObject.Find("Data").GetComponent<Inventory>().AAAAAAAAAAAAAAby();
			}
			if (Data.CharacterD[Inventory._currentCharacterNumber].CharUnits.name == "Хищник" && Data.CharacterD[Inventory._currentCharacterNumber].ControlGamer)
			{
				II._EnemyTarget.CurGexChar.GexGO.GetComponent<SpriteRenderer>().color = new Color(0.45f, 0.45f, 0.25f, 0.25f);
				II._Fire.GetComponent<LineRenderer>().SetPosition(0, CharacterMotion._CameraCM.transform.position);
				II._Fire.GetComponent<LineRenderer>().SetPosition(1, CharacterMotion._CameraCM.transform.position);
				CharacterMotion._curCharacter = Inventory._currentCharacterNumber;
				Debug.Log("Хищник " + CharacterMotion._curCharacter);
				GameObject.Find("Data").GetComponent<Inventory>().AAAAAAAAAAAAAAby();
			}
		}
	}
}
