using System.Collections;
using UnityEngine;

public class GrenadeUse : MonoBehaviour
{
	public static string CurrentGrenadeName;

	public static float DamageOfCurrentGrenade;

	public void AAAAAAAAAAAAAAbq()
	{
		StartCoroutine(AAAAAAAAAAAAAAAbn());
	}

	public static IEnumerator AAAAAAAAAAAAAAAbn()
	{
		DamageOfCurrentGrenade = 0f;
		if (CurrentGrenadeName != "нож")
		{
			for (int i = 0; i < 20; i++)
			{
				if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].NameSubject == CurrentGrenadeName)
				{
					DamageOfCurrentGrenade = Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].Damage;
					Data.CharacterD[CharacterMotion._curCharacter].CharUnits.GetComponent<AudioSource>().clip = Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].AudioFire;
					Data.CharacterD[CharacterMotion._curCharacter].CharUnits.GetComponent<AudioSource>().Play();
					if (Data.CharacterD[CharacterMotion._curCharacter].CurGexChar == Data.CharacterD[Inventory._currentCharacterNumber].CurGexChar)
					{
						Data.CharacterD[Inventory._currentCharacterNumber].CurGexChar.GexGO.GetComponentInChildren<SpriteRenderer>().color = new Color(1f, 0f, 0f, 0.8f);
					}
					else
					{
						Data.CharacterD[Inventory._currentCharacterNumber].CurGexChar.GexGO.GetComponentInChildren<SpriteRenderer>().color = new Color(1f, 0f, 0f, 0.8f);
						Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.GetComponentInChildren<SpriteRenderer>().color = new Color(0f, 1f, 1f, 0.8f);
					}
					Debug.Log(Data.CharacterD[CharacterMotion._curCharacter].CharUnits.GetComponent<AudioSource>().clip.name);
					Debug.Log("F1");
					if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].Stack > 1)
					{
						Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].Stack--;
					}
					else
					{
						Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i] = new AAAAAAAAAAAAAAAAAAbi();
					}
					break;
				}
			}
			CharacterMotion._PointsMove--;
			if (Data.CharacterD[CharacterMotion._curCharacter].ControlGamer)
			{
				II._EnemyTarget = Data.CharacterD[Inventory._currentCharacterNumber];
			}
			Inventory._Fire.GetComponent<LineRenderer>().SetPosition(0, Data.CharacterD[CharacterMotion._curCharacter].CharUnits.transform.position);
			Inventory._Fire.GetComponent<LineRenderer>().SetPosition(1, GameObject.Find(II._EnemyTarget.CharUnits.name).transform.position);
			Data.CharacterD[Inventory._currentCharacterNumber].Alarm = true;
			Data.CharacterD[Inventory._currentCharacterNumber].Aggressor = Data.CharacterD[CharacterMotion._curCharacter].NameU;
			for (int j = 0; j < Inventory._CurrentCharUnit.Count; j++)
			{
				Inventory._CurProtectoinSuit = Data.CharacterD[Inventory._CurrentCharUnit[j]].SuitChar.Protection + Data.CharacterD[Inventory._CurrentCharUnit[j]].ArtChar.Protection;
				Inventory._CurProtectoinSuit = Inventory._CurProtectoinSuit / 1000f * Data.CharacterD[Inventory._currentCharacterNumber].SuitChar.State;
				Inventory._CurDamage = DamageOfCurrentGrenade - Inventory._CurProtectoinSuit;
				Inventory._CurDamage *= SaveLoad.Difficulty;
				if (Inventory._CurDamage < 1f)
				{
					Inventory._CurDamage = 1f;
				}
				Data.CharacterD[Inventory._CurrentCharUnit[j]].CurHealth -= Inventory._CurDamage;
				Data.CharacterD[Inventory._CurrentCharUnit[j]].Bleeding += Random.Range(0, 2);
				Inventory._CurDamageForSuit = DamageOfCurrentGrenade / 10f;
				Data.CharacterD[Inventory._CurrentCharUnit[j]].SuitChar.State -= Inventory._CurDamageForSuit;
				Data.CharacterD[Inventory._CurrentCharUnit[j]].CharUnits.transform.GetChild(0).transform.localPosition = new Vector3((Data.CharacterD[Inventory._CurrentCharUnit[j]].CurHealth / 100f - 0.5f) / 2f, 0.5f);
				Data.CharacterD[Inventory._CurrentCharUnit[j]].CharUnits.transform.GetChild(0).transform.localScale = new Vector3(Data.CharacterD[Inventory._CurrentCharUnit[j]].CurHealth / 100f, 0.3f);
				if (Data.CharacterD[Inventory._CurrentCharUnit[j]].CurHealth <= 0f)
				{
					GameObject.Find(Data.CharacterD[Inventory._CurrentCharUnit[j]].CharUnits.name).GetComponent<AudioSource>().clip = Data.CharacterD[Inventory._CurrentCharUnit[j]].AudioDeath;
					GameObject.Find(Data.CharacterD[Inventory._CurrentCharUnit[j]].CharUnits.name).GetComponent<AudioSource>().Play();
					Data.CharacterD[Inventory._CurrentCharUnit[j]].AudioDeath = (AudioClip)Resources.Load("Sound/pda/paw_earth1");
					Data.CharacterD[CharacterMotion._curCharacter].Skill++;
					Data.CharacterD[Inventory._CurrentCharUnit[j]].Life = false;
					Data.CharacterD[Inventory._CurrentCharUnit[j]].TextureChar = Inventory._textureDethChar;
					Inventory._currentCharacterNumber = Inventory._CurrentCharUnit[j];
					Inventory.AAAAAAAAAAAAAAAAAAAAAce();
					Inventory.AAAAAAAAAAAAAAAAAbx();
					Methods.AAAAAAAAAAAAAAcn();
					Methods.AAAAAAAAAAAAAAcm();
					Data.CharacterD[Inventory._currentCharacterNumber].CharUnits.GetComponent<SpriteRenderer>().sprite = Inventory._spriteDethChar;
					Data.CharacterD[Inventory._currentCharacterNumber].CharUnits.GetComponent<SpriteRenderer>().sortingOrder = 5;
					Data.CharacterD[Inventory._CurrentCharUnit[j]].CharUnits.transform.GetChild(0).transform.localPosition = new Vector3((Data.CharacterD[Inventory._CurrentCharUnit[j]].CurHealth / 100f - 0.5f) / 2f, 0.5f);
					Data.CharacterD[Inventory._CurrentCharUnit[j]].CharUnits.transform.GetChild(0).transform.localScale = new Vector3(0f, 0.3f);
					if (Data.CharacterD[Inventory._CurrentCharUnit[j]].TypeChInt == 9 || Data.CharacterD[Inventory._CurrentCharUnit[j]].TypeChInt == 10)
					{
						Data.KillingMutants_Data++;
						GPSscript.AAAAAAAAAAAAAAAAAi("CgkI2OGbhtMLEAIQAQ", 1);
						Debug.Log("KillingMutants");
					}
				}
				if (!Data.CharacterD[Inventory._currentCharacterNumber].Life)
				{
					AAAAAAAAAAAAAAAAAci.AAAAAAAAAAAAAAAAcf();
				}
			}
			yield return new WaitForSeconds(0.5f);
			Data.CharacterD[Inventory._currentCharacterNumber].CurGexChar.GexGO.GetComponentInChildren<SpriteRenderer>().color = new Color(0f, 1f, 1f, 0.8f);
			Inventory._Fire.GetComponent<LineRenderer>().SetPosition(0, CharacterMotion._CameraCM.transform.position);
			Inventory._Fire.GetComponent<LineRenderer>().SetPosition(1, CharacterMotion._CameraCM.transform.position);
			yield return new WaitForSeconds(0.4f);
		}
		else
		{
			Data.CharacterD[CharacterMotion._curCharacter].CharUnits.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("Sound/weapons/knife_2");
			Data.CharacterD[CharacterMotion._curCharacter].CharUnits.GetComponent<AudioSource>().Play();
			Data.CharacterD[Inventory._currentCharacterNumber].CurGexChar.GexGO.GetComponentInChildren<SpriteRenderer>().color = new Color(1f, 0f, 0f, 0.8f);
			CharacterMotion._PointsMove--;
			if (Data.CharacterD[CharacterMotion._curCharacter].ControlGamer)
			{
				II._EnemyTarget = Data.CharacterD[Inventory._currentCharacterNumber];
			}
			Data.CharacterD[Inventory._currentCharacterNumber].Alarm = true;
			Inventory._CurProtectoinSuit = Data.CharacterD[Inventory._currentCharacterNumber].SuitChar.Protection + Data.CharacterD[Inventory._currentCharacterNumber].ArtChar.Protection;
			Inventory._CurProtectoinSuit = Inventory._CurProtectoinSuit / 1000f * Data.CharacterD[Inventory._currentCharacterNumber].SuitChar.State;
			Inventory._CurDamage = 14f - Inventory._CurProtectoinSuit;
			Inventory._CurDamage *= SaveLoad.Difficulty;
			if (Inventory._CurDamage < 4f)
			{
				Inventory._CurDamage = 4f;
			}
			Data.CharacterD[Inventory._currentCharacterNumber].CurHealth -= Inventory._CurDamage;
			Data.CharacterD[Inventory._currentCharacterNumber].Bleeding++;
			Data.CharacterD[Inventory._currentCharacterNumber].SuitChar.State--;
			Data.CharacterD[Inventory._currentCharacterNumber].CharUnits.transform.GetChild(0).transform.localPosition = new Vector3((Data.CharacterD[Inventory._currentCharacterNumber].CurHealth / 100f - 0.5f) / 2f, 0.5f);
			Data.CharacterD[Inventory._currentCharacterNumber].CharUnits.transform.GetChild(0).transform.localScale = new Vector3(Data.CharacterD[Inventory._currentCharacterNumber].CurHealth / 100f, 0.3f);
			if (Data.CharacterD[Inventory._currentCharacterNumber].CurHealth <= 0f)
			{
				Data.CharacterD[Inventory._currentCharacterNumber].CharUnits.GetComponent<AudioSource>().clip = Data.CharacterD[Inventory._currentCharacterNumber].AudioDeath;
				Data.CharacterD[Inventory._currentCharacterNumber].CharUnits.GetComponent<AudioSource>().Play();
				Data.CharacterD[Inventory._currentCharacterNumber].AudioDeath = (AudioClip)Resources.Load("Sound/pda/paw_earth1");
				Data.CharacterD[CharacterMotion._curCharacter].Skill++;
				Data.CharacterD[Inventory._currentCharacterNumber].Life = false;
				Data.CharacterD[Inventory._currentCharacterNumber].TextureChar = Inventory._textureDethChar;
				Inventory.AAAAAAAAAAAAAAAAAAAAAce();
				Inventory.AAAAAAAAAAAAAAAAAbx();
				Methods.AAAAAAAAAAAAAAcn();
				Methods.AAAAAAAAAAAAAAcm();
				Methods.AAAAAAAAAAAAAAAce();
				Data.CharacterD[Inventory._currentCharacterNumber].CharUnits.GetComponent<SpriteRenderer>().sprite = Inventory._spriteDethChar;
				Data.CharacterD[Inventory._currentCharacterNumber].CharUnits.GetComponent<SpriteRenderer>().sortingOrder = 5;
				Data.CharacterD[Inventory._currentCharacterNumber].CharUnits.transform.GetChild(0).transform.localPosition = new Vector3((Data.CharacterD[Inventory._currentCharacterNumber].CurHealth / 100f - 0.5f) / 2f, 0.5f);
				Data.CharacterD[Inventory._currentCharacterNumber].CharUnits.transform.GetChild(0).transform.localScale = new Vector3(0f, 0.3f);
				if (Data.CharacterD[Inventory._currentCharacterNumber].TypeChInt == 9 || Data.CharacterD[Inventory._currentCharacterNumber].TypeChInt == 10)
				{
					Data.KillingMutants_Data++;
					GPSscript.AAAAAAAAAAAAAAAAAi("CgkI2OGbhtMLEAIQAQ", 1);
					Debug.Log("KillingMutants");
				}
			}
			if (!Data.CharacterD[Inventory._currentCharacterNumber].Life)
			{
				AAAAAAAAAAAAAAAAAci.AAAAAAAAAAAAAAAAcf();
			}
			yield return new WaitForSeconds(0.5f);
			Data.CharacterD[Inventory._currentCharacterNumber].CurGexChar.GexGO.GetComponentInChildren<SpriteRenderer>().color = new Color(0f, 1f, 1f, 0.8f);
			yield return new WaitForSeconds(0.4f);
		}
		if (Data.CharacterD[Inventory._currentCharacterNumber].CharUnits.name == "Следопыт")
		{
			Methods.AAAAAAAAAAAAAAcn();
		}
	}

	public void AAAAAAAAAAAAAAbr()
	{
		if (CharacterMotion.PointInform != null)
		{
			CharacterMotion.PointInform.SetActive(false);
		}
		if (CharacterMotion._NextGex.Count > 0)
		{
			for (int i = 0; i < CharacterMotion._NextGex.Count; i++)
			{
				GameObject.Find(CharacterMotion._NextGex[i].NameGex).GetComponent<SpriteRenderer>().color = new Color(0.45f, 0.45f, 0.25f, 0f);
			}
		}
		if (CharacterMotion._NextGex.Count > 0)
		{
			foreach (ConstructorGex item in CharacterMotion._NextGex)
			{
				GameObject gameObject = GameObject.Find(item.NameGex);
				if (gameObject.transform.childCount > 0)
				{
					if (gameObject.transform.childCount > 1)
					{
						Object.Destroy(gameObject.transform.GetChild(1).gameObject);
					}
					if (gameObject.transform.childCount > 0)
					{
						Object.Destroy(gameObject.transform.GetChild(0).gameObject);
					}
				}
			}
		}
		AAAAAAAAAAAAAAbq();
	}
}
