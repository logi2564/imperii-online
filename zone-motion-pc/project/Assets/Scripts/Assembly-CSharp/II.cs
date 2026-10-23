using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class II : MonoBehaviour
{
	public static List<float> SortingEnemys;

	public static List<AAAAAAAAAAAAAAAAf> Enemys;

	public static List<AAAAAAAAAAAAAAAAf> NearEnemysInRange;

	public static List<AAAAAAAAAAAAAAAAf> FarEnemys;

	public static AAAAAAAAAAAAAAAAf _EnemyTarget;

	public static AAAAAAAAAAAAAAAAAAk _CurSubject;

	public static ConstructorGex _PointFight;

	public static AAAAAAAAAAAAAAAAf nearestChar;

	public static ConstructorGex _IICurGex;

	public static List<ConstructorGex> _IINextGex;

	public static ConstructorGex[] IIGexNears = new ConstructorGex[6];

	public static int _IIDistansMove = 0;

	public static int nearestN;

	public static GameObject _Fire;

	private static GameObject AAAAAAAAAAAAAAAAAAck;

	private void Start()
	{
		SortingEnemys = new List<float>();
		Enemys = new List<AAAAAAAAAAAAAAAAf>();
		NearEnemysInRange = new List<AAAAAAAAAAAAAAAAf>();
		FarEnemys = new List<AAAAAAAAAAAAAAAAf>();
		_EnemyTarget = new AAAAAAAAAAAAAAAAAAAAAz();
		_IICurGex = new ConstructorGex();
		_IINextGex = new List<ConstructorGex>();
		_Fire = GameObject.Find("Fire");
	}

	public static IEnumerator AAAAAAAAAAAAAAbs()
	{
		yield return new WaitForSeconds(0.005f);
		if (Data.CharacterD[CharacterMotion._curCharacter].Life)
		{
			while (true)
			{
				if (CharacterMotion._PointsMove <= 0)
				{
					yield return GameObject.Find("Data").GetComponent<CoroutinsAll>().AAAAAAAAAAAAAAAAAAcg();
					yield break;
				}
				if (EjectTimeSc.Ejection <= 2 && EjectTimeSc.Ejection >= -1)
				{
					CharacterMotion.AAAAAAAAAAAAAAAAAAAAi();
					if (Inventory._CurrentPoint.Count == 0)
					{
						AAAAAAAAAAAAAAAAAbq();
						AAAAAAAAAAAAAAAAAAch();
						yield return new WaitForSeconds(8f / AAAAAAAAAAAAAAAAAAAAct.GameSpeed);
						yield return GameObject.Find("Data").GetComponent<CoroutinsAll>().AAAAAAAAAAAAAAAAAAcg();
						yield break;
					}
					if (CharacterMotion._PointsMove > 0)
					{
						if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Cartridge == 0)
						{
							Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Cartridge = Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.CartridgeInMagazineFull;
							CharacterMotion._PointsMove--;
							yield return new WaitForSeconds(0.4f);
							continue;
						}
						if (CharacterMotion._PointsMove > 0)
						{
							AAAAAAAAAAAAAAAAbp();
							if (Enemys.Count > 0)
							{
								AAAAAAAAAAAAAAbt();
								AAAAAAAAAAAAAAAAAAAAAbx();
								Debug.Log("0082");
							}
							if (NearEnemysInRange.Count > 0)
							{
								Debug.Log("0087");
								yield return GameObject.Find("Data").GetComponent<CoroutinsAll>().AAAAAAAAAAAAAAAAAbl();
							}
							else
							{
								yield return GameObject.Find("Data").GetComponent<CoroutinsAll>().AAAAAAAAAAAAAAAAAAcg();
							}
							yield break;
						}
						break;
					}
					yield return GameObject.Find("Data").GetComponent<CoroutinsAll>().AAAAAAAAAAAAAAAAAAcg();
					yield break;
				}
				if (CharacterMotion._PointsMove > 0 && Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Cartridge == 0)
				{
					Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Cartridge = Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.CartridgeInMagazineFull;
					CharacterMotion._PointsMove--;
					yield return new WaitForSeconds(0.4f);
					continue;
				}
				if (CharacterMotion._PointsMove <= 0)
				{
					break;
				}
				AAAAAAAAAAAAAAAAbp();
				if (Enemys.Count > 0)
				{
					AAAAAAAAAAAAAAbt();
					AAAAAAAAAAAAAAAAAAAAAbx();
				}
				if (NearEnemysInRange.Count > 0 && CharacterMotion._PointsMove > 0)
				{
					yield return GameObject.Find("Data").GetComponent<CoroutinsAll>().AAAAAAAAAAAAAAAAAbl();
					yield break;
				}
				if (NearEnemysInRange.Count == 0 && FarEnemys.Count > 0 && CharacterMotion._PointsMove > 0)
				{
					yield return GameObject.Find("Data").GetComponent<CoroutinsAll>().AAAAAAAAAAAAAAAAbk();
					yield break;
				}
				if (NearEnemysInRange.Count == 0 && FarEnemys.Count == 0 && CharacterMotion._PointsMove > 0)
				{
					if (!Data.CharacterD[CharacterMotion._curCharacter].Alarm)
					{
						yield return GameObject.Find("Data").GetComponent<CoroutinsAll>().AAAAAAAAAAAAAAAAAAch();
						yield break;
					}
					if (Data.CharacterD[CharacterMotion._curCharacter].Alarm)
					{
						_EnemyTarget = new AAAAAAAAAAAAAAAAAAAAAz();
						foreach (AAAAAAAAAAAAAAAAf item in Data.CharacterD)
						{
							if (item.NameU == Data.CharacterD[CharacterMotion._curCharacter].Aggressor)
							{
								_EnemyTarget = item;
								break;
							}
						}
						if (_EnemyTarget.NameCharac == string.Empty)
						{
							Data.CharacterD[CharacterMotion._curCharacter].Alarm = false;
							Debug.Log("126 ii ");
							yield return GameObject.Find("Data").GetComponent<CoroutinsAll>().AAAAAAAAAAAAAAAAAAch();
							yield break;
						}
						if (_EnemyTarget.Life)
						{
							yield return GameObject.Find("Data").GetComponent<CoroutinsAll>().AAAAAAAAAAAAAAAAAAAAbx();
							yield break;
						}
						if (!_EnemyTarget.Life)
						{
							Data.CharacterD[CharacterMotion._curCharacter].Alarm = false;
							Debug.Log("138 ii ");
							yield return GameObject.Find("Data").GetComponent<CoroutinsAll>().AAAAAAAAAAAAAAAAAAch();
							yield break;
						}
					}
				}
				if (CharacterMotion._PointsMove > 0)
				{
					break;
				}
				yield return GameObject.Find("Data").GetComponent<CoroutinsAll>().AAAAAAAAAAAAAAAAAAcg();
				yield break;
			}
			yield return GameObject.Find("Data").GetComponent<CoroutinsAll>().AAAAAAAAAAAAAAAAAAcg();
		}
		else
		{
			yield return GameObject.Find("Data").GetComponent<CoroutinsAll>().AAAAAAAAAAAAAAAAAAcg();
		}
	}

	public static void AAAAAAAAAAAAAAAAAAAbp()
	{
		_EnemyTarget = NearEnemysInRange[0];
		foreach (AAAAAAAAAAAAAAAAf item in NearEnemysInRange)
		{
			if (item.SuitChar.Protection < NearEnemysInRange[0].SuitChar.Protection)
			{
				_EnemyTarget = item;
			}
		}
		Inventory._CurrentCharUnit.Clear();
		Inventory._CurrentPoint.Clear();
		CharacterMotion._Turget.transform.position = _EnemyTarget.CurGexChar.GexGO.transform.position;
		for (int i = 0; i < Data.CharacterD.Count; i++)
		{
			if (Data.CharacterD[i].CurGexChar == _EnemyTarget.CurGexChar)
			{
				Inventory._CurrentCharUnit.Add(i);
			}
		}
		for (int j = 0; j < Data.CharacterD.Count; j++)
		{
			if (!(Data.CharacterD[j].CharUnits.name == _EnemyTarget.CharUnits.name))
			{
				continue;
			}
			Inventory._currentCharacterNumber = j;
			for (int k = 0; k < Inventory._CurrentCharUnit.Count; k++)
			{
				if (Inventory._CurrentCharUnit[k] == Inventory._currentCharacterNumber)
				{
					Inventory._curNumb = k;
				}
			}
		}
		for (int l = 0; l < Data.Points.Count; l++)
		{
			if (Data.Points[l].curGexPoint == _EnemyTarget.CurGexChar)
			{
				Inventory._CurrentPoint.Add(l);
			}
		}
		Inventory._CurtainIconCharacterU.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, (Inventory._CurrentCharUnit.Count + Inventory._CurrentPoint.Count) * Inventory._posY8);
	}

	public static void AAAAAAAAAAAAAAAAAAcl()
	{
		if (FarEnemys.Count > 0)
		{
			_EnemyTarget = FarEnemys[0];
			for (int i = 0; i < FarEnemys.Count; i++)
			{
				if (FarEnemys[i].SuitChar.Protection < FarEnemys[0].SuitChar.Protection)
				{
					_EnemyTarget = FarEnemys[i];
				}
			}
			Inventory._CurrentCharUnit.Clear();
			Inventory._CurrentPoint.Clear();
			CharacterMotion._Turget.transform.position = GameObject.Find(_EnemyTarget.CharUnits.name).transform.position;
			for (int j = 0; j < Data.CharacterD.Count; j++)
			{
				if (Data.CharacterD[j].CurGexChar == _EnemyTarget.CurGexChar)
				{
					Inventory._CurrentCharUnit.Add(j);
				}
			}
			for (int k = 0; k < Data.CharacterD.Count; k++)
			{
				if (!(Data.CharacterD[k].CharUnits.name == _EnemyTarget.CharUnits.name))
				{
					continue;
				}
				Inventory._currentCharacterNumber = k;
				for (int l = 0; l < Inventory._CurrentCharUnit.Count; l++)
				{
					if (Inventory._CurrentCharUnit[l] == Inventory._currentCharacterNumber)
					{
						Inventory._curNumb = l;
					}
				}
			}
			for (int m = 0; m < Data.Points.Count; m++)
			{
				if (Data.Points[m].curGexPoint == _EnemyTarget.CurGexChar)
				{
					Inventory._CurrentPoint.Add(m);
				}
			}
		}
		Inventory._CurtainIconCharacterU.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, (Inventory._CurrentCharUnit.Count + Inventory._CurrentPoint.Count) * Inventory._posY8);
	}

	public static void AAAAAAAAAAAAAAAAbp()
	{
		NearEnemysInRange.Clear();
		FarEnemys.Clear();
		Enemys.Clear();
		foreach (AAAAAAAAAAAAAAAAf item in Data.CharacterD)
		{
			if (item.CharUnits != null && item.Life && AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.CharacterD[CharacterMotion._curCharacter].TypeChInt, item.TypeChInt] == 0)
			{
				Enemys.Add(item);
			}
		}
	}

	public static void AAAAAAAAAAAAAAbt()
	{
		float num = 30f;
		SortingEnemys.Clear();
		nearestChar = new AAAAAAAAAAAAAAAAAAAAAz();
		foreach (AAAAAAAAAAAAAAAAf enemy in Enemys)
		{
			if (enemy.CharUnits != null && Data.CharacterD[CharacterMotion._curCharacter].CharUnits != null)
			{
				SortingEnemys.Add(Vector3.Distance(enemy.CharUnits.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CharUnits.transform.position));
			}
			else
			{
				Debug.Log(enemy.NameU + " " + Data.CharacterD[CharacterMotion._curCharacter].NameU);
			}
		}
		for (int i = 0; i < SortingEnemys.Count; i++)
		{
			if (SortingEnemys[i] < num)
			{
				num = SortingEnemys[i];
				nearestN = i;
			}
		}
		if (Enemys[nearestN] != null)
		{
			nearestChar = Enemys[nearestN];
			Enemys.Clear();
			Enemys.Add(nearestChar);
		}
	}

	public static void AAAAAAAAAAAAAAAAAAAAAbx()
	{
		NearEnemysInRange.Clear();
		FarEnemys.Clear();
		_IINextGex.Clear();
		foreach (AAAAAAAAAAAAAAAAf enemy in Enemys)
		{
			_IIDistansMove = 0;
			_IINextGex.Add(enemy.CurGexChar);
			_IICurGex = enemy.CurGexChar;
			if (_IICurGex != Data.CharacterD[CharacterMotion._curCharacter].CurGexChar)
			{
				while (true)
				{
					_IIDistansMove++;
					if (_IICurGex._YGex % 2 == 0)
					{
						foreach (ConstructorGex item in Gexa.GexLib)
						{
							if (item.NameGex == _IICurGex._XGex + "x" + (_IICurGex._YGex + 1) + "y")
							{
								IIGexNears[0] = item;
								if (Vector3.Distance(IIGexNears[0].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position) < Vector3.Distance(_IINextGex[_IINextGex.Count - 1].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position))
								{
									_IINextGex[_IINextGex.Count - 1] = IIGexNears[0];
									break;
								}
							}
						}
						foreach (ConstructorGex item2 in Gexa.GexLib)
						{
							if (item2.NameGex == _IICurGex._XGex - 1 + "x" + _IICurGex._YGex + "y")
							{
								IIGexNears[1] = item2;
								if (Vector3.Distance(IIGexNears[1].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position) < Vector3.Distance(_IINextGex[_IINextGex.Count - 1].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position))
								{
									_IINextGex[_IINextGex.Count - 1] = IIGexNears[1];
									break;
								}
							}
						}
						foreach (ConstructorGex item3 in Gexa.GexLib)
						{
							if (item3.NameGex == _IICurGex._XGex + "x" + (_IICurGex._YGex - 1) + "y")
							{
								IIGexNears[2] = item3;
								if (Vector3.Distance(IIGexNears[2].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position) < Vector3.Distance(_IINextGex[_IINextGex.Count - 1].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position))
								{
									_IINextGex[_IINextGex.Count - 1] = IIGexNears[2];
									break;
								}
							}
						}
						foreach (ConstructorGex item4 in Gexa.GexLib)
						{
							if (item4.NameGex == _IICurGex._XGex + 1 + "x" + (_IICurGex._YGex + 1) + "y")
							{
								IIGexNears[3] = item4;
								if (Vector3.Distance(IIGexNears[3].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position) < Vector3.Distance(_IINextGex[_IINextGex.Count - 1].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position))
								{
									_IINextGex[_IINextGex.Count - 1] = IIGexNears[3];
									break;
								}
							}
						}
						foreach (ConstructorGex item5 in Gexa.GexLib)
						{
							if (item5.NameGex == _IICurGex._XGex + 1 + "x" + _IICurGex._YGex + "y")
							{
								IIGexNears[4] = item5;
								if (Vector3.Distance(IIGexNears[4].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position) < Vector3.Distance(_IINextGex[_IINextGex.Count - 1].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position))
								{
									_IINextGex[_IINextGex.Count - 1] = IIGexNears[4];
									break;
								}
							}
						}
						foreach (ConstructorGex item6 in Gexa.GexLib)
						{
							if (item6.NameGex == _IICurGex._XGex + 1 + "x" + (_IICurGex._YGex - 1) + "y")
							{
								IIGexNears[5] = item6;
								if (Vector3.Distance(IIGexNears[5].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position) < Vector3.Distance(_IINextGex[_IINextGex.Count - 1].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position))
								{
									_IINextGex[_IINextGex.Count - 1] = IIGexNears[5];
									break;
								}
							}
						}
					}
					else
					{
						foreach (ConstructorGex item7 in Gexa.GexLib)
						{
							if (item7.NameGex == _IICurGex._XGex - 1 + "x" + (_IICurGex._YGex + 1) + "y")
							{
								IIGexNears[0] = item7;
								if (Vector3.Distance(IIGexNears[0].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position) < Vector3.Distance(_IINextGex[_IINextGex.Count - 1].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position))
								{
									_IINextGex[_IINextGex.Count - 1] = IIGexNears[0];
									break;
								}
							}
						}
						foreach (ConstructorGex item8 in Gexa.GexLib)
						{
							if (item8.NameGex == _IICurGex._XGex - 1 + "x" + _IICurGex._YGex + "y")
							{
								IIGexNears[1] = item8;
								if (Vector3.Distance(IIGexNears[1].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position) < Vector3.Distance(_IINextGex[_IINextGex.Count - 1].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position))
								{
									_IINextGex[_IINextGex.Count - 1] = IIGexNears[1];
									break;
								}
							}
						}
						foreach (ConstructorGex item9 in Gexa.GexLib)
						{
							if (item9.NameGex == _IICurGex._XGex - 1 + "x" + (_IICurGex._YGex - 1) + "y")
							{
								IIGexNears[2] = item9;
								if (Vector3.Distance(IIGexNears[2].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position) < Vector3.Distance(_IINextGex[_IINextGex.Count - 1].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position))
								{
									_IINextGex[_IINextGex.Count - 1] = IIGexNears[2];
									break;
								}
							}
						}
						foreach (ConstructorGex item10 in Gexa.GexLib)
						{
							if (item10.NameGex == _IICurGex._XGex + "x" + (_IICurGex._YGex + 1) + "y")
							{
								IIGexNears[3] = item10;
								if (Vector3.Distance(IIGexNears[3].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position) < Vector3.Distance(_IINextGex[_IINextGex.Count - 1].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position))
								{
									_IINextGex[_IINextGex.Count - 1] = IIGexNears[3];
									break;
								}
							}
						}
						foreach (ConstructorGex item11 in Gexa.GexLib)
						{
							if (item11.NameGex == _IICurGex._XGex + 1 + "x" + _IICurGex._YGex + "y")
							{
								IIGexNears[4] = item11;
								if (Vector3.Distance(IIGexNears[4].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position) < Vector3.Distance(_IINextGex[_IINextGex.Count - 1].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position))
								{
									_IINextGex[_IINextGex.Count - 1] = IIGexNears[4];
									break;
								}
							}
						}
						foreach (ConstructorGex item12 in Gexa.GexLib)
						{
							if (item12.NameGex == _IICurGex._XGex + "x" + (_IICurGex._YGex - 1) + "y")
							{
								IIGexNears[5] = item12;
								if (Vector3.Distance(IIGexNears[5].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position) < Vector3.Distance(_IINextGex[_IINextGex.Count - 1].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position))
								{
									_IINextGex[_IINextGex.Count - 1] = IIGexNears[5];
									break;
								}
							}
						}
					}
					if (!(_IINextGex[_IINextGex.Count - 1].NameGex != Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.NameGex))
					{
						break;
					}
					_IICurGex = _IINextGex[_IINextGex.Count - 1];
					_IINextGex.Add(_IINextGex[_IINextGex.Count - 1]);
				}
				int num = Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Range;
				if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.SightInstallation)
				{
					num++;
				}
				if (num >= _IIDistansMove)
				{
					NearEnemysInRange.Add(enemy);
				}
				if (num < _IIDistansMove && num + CharacterMotion._PointsMove >= _IIDistansMove)
				{
					FarEnemys.Add(enemy);
				}
			}
			if (_IICurGex == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar)
			{
				NearEnemysInRange.Add(enemy);
			}
		}
	}

	public static void AAAAAAAAAAAAAAAAAAAAca()
	{
		if (Data.CharacterD[CharacterMotion._curCharacter].Life)
		{
			Data.CharacterD[CharacterMotion._curCharacter].Bleeding += Inventory._currentSubject.Bleeding;
			Data.CharacterD[CharacterMotion._curCharacter].CurHealth += Inventory._currentSubject.Sanitation;
			Data.CharacterD[CharacterMotion._curCharacter].DiseaseXRay += Inventory._currentSubject.XrayNegatife;
			Data.CharacterD[CharacterMotion._curCharacter].DiseaseXRay += Inventory._currentSubject.XRaySanitation;
			Data.CharacterD[CharacterMotion._curCharacter].Satiety += Inventory._currentSubject.Hunger;
			Data.CharacterD[CharacterMotion._curCharacter].Thirst += Inventory._currentSubject.Thirst;
			Data.CharacterD[CharacterMotion._curCharacter].PritectionEjectEffect += Inventory._currentSubject.ProtectionFromEject;
			Data.CharacterD[CharacterMotion._curCharacter].PSIprotection += Inventory._currentSubject.PsiProtection;
			CharacterMotion._PointsMove += Inventory._currentSubject.Doping;
			Inventory.SoundMenu.clip = Inventory._currentSubject.AudioFire;
			Inventory.SoundMenu.Play();
			Inventory._currentSubject = new AAAAAAAAAAAAAAAAAAbi();
			Inventory.AAAAAAAAAAAAAAAAAAcw();
			Data.CharacterD[CharacterMotion._curCharacter].CharUnits.transform.GetChild(0).transform.localPosition = new Vector3((Data.CharacterD[CharacterMotion._curCharacter].CurHealth / 100f - 0.5f) / 2f, 0.5f);
			Data.CharacterD[CharacterMotion._curCharacter].CharUnits.transform.GetChild(0).transform.localScale = new Vector3(Data.CharacterD[CharacterMotion._curCharacter].CurHealth / 100f, 0.3f);
		}
	}

	public static void AAAAAAAAAAAAAAAAAAcm()
	{
		for (int i = 0; i < 20; i++)
		{
			if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].NameSubject == "Бинт")
			{
				Inventory._currentSubject = Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i];
				if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].Stack > 1)
				{
					Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].Stack--;
				}
				else
				{
					Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i] = new AAAAAAAAAAAAAAAAAAbi();
				}
				AAAAAAAAAAAAAAAAAAAAca();
				break;
			}
		}
	}

	public static void AAAAAAAAAAAAAAbu()
	{
		for (int i = 0; i < 20; i++)
		{
			if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].NameSubject == "Аптечка" || Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].NameSubject == "Аптечка армейская" || Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].NameSubject == "Аптечка научная")
			{
				Inventory._currentSubject = Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i];
				if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].Stack > 1)
				{
					Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].Stack--;
				}
				else
				{
					Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i] = new AAAAAAAAAAAAAAAAAAbi();
				}
				AAAAAAAAAAAAAAAAAAAAca();
				break;
			}
		}
	}

	public static void AAAAAAAAAAAAAAAAAAAAAby()
	{
		for (int i = 0; i < 20; i++)
		{
			if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].NameSubject == "Антирадиационные препараты")
			{
				Inventory._currentSubject = Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i];
				if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].Stack > 1)
				{
					Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].Stack--;
				}
				else
				{
					Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i] = new AAAAAAAAAAAAAAAAAAbi();
				}
				AAAAAAAAAAAAAAAAAAAAca();
				break;
			}
		}
	}

	public static void AAAAAAAAAAAAAAAAAAAAAbz()
	{
		if (CharacterMotion._PointsMove > 0)
		{
			CharacterMotion._PointsMove--;
			Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Cartridge = Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.CartridgeInMagazineFull;
			Data.CharacterD[CharacterMotion._curCharacter].CharUnits.GetComponent<AudioSource>().clip = Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.AudioReload;
			Data.CharacterD[CharacterMotion._curCharacter].CharUnits.GetComponent<AudioSource>().Play();
		}
	}

	public static void AAAAAAAAAAAAAAAAAAcn()
	{
		for (int i = 0; i < 20; i++)
		{
			if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Weapon && Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].CostSubject > Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.CostSubject)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.CostSubject;
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = (ConstructorWeapon)Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i];
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i] = new AAAAAAAAAAAAAAAAAAbi();
				Data.CharacterD[CharacterMotion._curCharacter].CharUnits.GetComponent<AudioSource>().clip = Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.AudioReload;
				Data.CharacterD[CharacterMotion._curCharacter].CharUnits.GetComponent<AudioSource>().Play();
				break;
			}
		}
	}

	public static void AAAAAAAAAAAAAAAAAbp()
	{
		for (int i = 0; i < 20; i++)
		{
			if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Suit && Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].Protection > Data.CharacterD[CharacterMotion._curCharacter].SuitChar.Protection)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += Data.CharacterD[CharacterMotion._curCharacter].SuitChar.CostSubject;
				Data.CharacterD[CharacterMotion._curCharacter].SuitChar = (AAAAAAAAAAAAAAAAAAAAbe)Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i];
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i] = new AAAAAAAAAAAAAAAAAAbi();
				Data.CharacterD[CharacterMotion._curCharacter].CharUnits.GetComponent<AudioSource>().clip = Data.CharacterD[CharacterMotion._curCharacter].SuitChar.AudioSlot;
				Data.CharacterD[CharacterMotion._curCharacter].CharUnits.GetComponent<AudioSource>().Play();
				break;
			}
		}
	}

	public static void AAAAAAAAAAAAAAAAAAAbq()
	{
		if (Data.CharacterD[CharacterMotion._curCharacter].TypeChar == AAAAAAAAAAAAAAAAf.TypeCharacter.Снорк || Data.CharacterD[CharacterMotion._curCharacter].SuitChar.ArtContainer <= 0)
		{
			return;
		}
		for (int i = 0; i < 20; i++)
		{
			if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Artefact && Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[0].NameSubject == "None")
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[0].CostSubject;
				Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[0] = (AAAAAAAAAAAAAAAy)Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i];
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i] = new AAAAAAAAAAAAAAAAAAbi();
				Data.CharacterD[CharacterMotion._curCharacter].CharUnits.GetComponent<AudioSource>().clip = Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[0].AudioSlot;
				Data.CharacterD[CharacterMotion._curCharacter].CharUnits.GetComponent<AudioSource>().Play();
				break;
			}
		}
	}

	public static void AAAAAAAAAAAAAAAAAAAbr()
	{
		if (Data.CharacterD[CharacterMotion._curCharacter].DetectorChar == null)
		{
			return;
		}
		for (int i = 0; i < 20; i++)
		{
			if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i] != null && Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Detector && Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].CostSubject > Data.CharacterD[CharacterMotion._curCharacter].DetectorChar.CostSubject)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += Data.CharacterD[CharacterMotion._curCharacter].DetectorChar.CostSubject;
				Data.CharacterD[CharacterMotion._curCharacter].DetectorChar = Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i];
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i] = new AAAAAAAAAAAAAAAAAAbi();
				break;
			}
		}
	}

	public static void AAAAAAAAAAAAAAAAAAch()
	{
		if (Data.CharacterD[CharacterMotion._curCharacter].CurGexChar == Data.CharacterD[CharacterMotion._curCharacter].TaskGexChar)
		{
			return;
		}
		CharacterMotion._DistansMove = 0;
		if (CharacterMotion._NextGex.Count > 0)
		{
			foreach (ConstructorGex item in CharacterMotion._NextGex)
			{
				GameObject.Find(item.NameGex).GetComponent<SpriteRenderer>().color = new Color(0.45f, 0.45f, 0.25f, 0.25f);
			}
			CharacterMotion._NextGex.Clear();
		}
		CharacterMotion._NextGex.Add(Data.CharacterD[CharacterMotion._curCharacter].TaskGexChar);
		CharacterMotion._NextGex.Add(Data.CharacterD[CharacterMotion._curCharacter].TaskGexChar);
		CharacterMotion._CurGex = Data.CharacterD[CharacterMotion._curCharacter].TaskGexChar;
		AAAAAAAAAAAAAAAAAAck = Gexa.GexLib[Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.ID].GexGO;
		while (true)
		{
			if (CharacterMotion._CurGex._YGex % 2 == 0)
			{
				foreach (ConstructorGex item2 in Gexa.GexLib)
				{
					if (item2.NameGex == CharacterMotion._CurGex._XGex + "x" + (CharacterMotion._CurGex._YGex + 1) + "y")
					{
						CharacterMotion.GexNears[0] = item2;
						if (Vector3.Distance(CharacterMotion.GexNears[0].GexGO.transform.position, AAAAAAAAAAAAAAAAAAck.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, AAAAAAAAAAAAAAAAAAck.transform.position))
						{
							CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[0];
						}
						break;
					}
				}
				foreach (ConstructorGex item3 in Gexa.GexLib)
				{
					if (item3.NameGex == CharacterMotion._CurGex._XGex - 1 + "x" + CharacterMotion._CurGex._YGex + "y")
					{
						CharacterMotion.GexNears[1] = item3;
						if (Vector3.Distance(CharacterMotion.GexNears[1].GexGO.transform.position, AAAAAAAAAAAAAAAAAAck.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, AAAAAAAAAAAAAAAAAAck.transform.position))
						{
							CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[1];
						}
						break;
					}
				}
				foreach (ConstructorGex item4 in Gexa.GexLib)
				{
					if (item4.NameGex == CharacterMotion._CurGex._XGex + "x" + (CharacterMotion._CurGex._YGex - 1) + "y")
					{
						CharacterMotion.GexNears[2] = item4;
						if (Vector3.Distance(CharacterMotion.GexNears[2].GexGO.transform.position, AAAAAAAAAAAAAAAAAAck.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, AAAAAAAAAAAAAAAAAAck.transform.position))
						{
							CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[2];
						}
						break;
					}
				}
				foreach (ConstructorGex item5 in Gexa.GexLib)
				{
					if (item5.NameGex == CharacterMotion._CurGex._XGex + 1 + "x" + (CharacterMotion._CurGex._YGex + 1) + "y")
					{
						CharacterMotion.GexNears[3] = item5;
						if (Vector3.Distance(CharacterMotion.GexNears[3].GexGO.transform.position, AAAAAAAAAAAAAAAAAAck.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, AAAAAAAAAAAAAAAAAAck.transform.position))
						{
							CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[3];
						}
						break;
					}
				}
				foreach (ConstructorGex item6 in Gexa.GexLib)
				{
					if (item6.NameGex == CharacterMotion._CurGex._XGex + 1 + "x" + CharacterMotion._CurGex._YGex + "y")
					{
						CharacterMotion.GexNears[4] = item6;
						if (Vector3.Distance(CharacterMotion.GexNears[4].GexGO.transform.position, AAAAAAAAAAAAAAAAAAck.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, AAAAAAAAAAAAAAAAAAck.transform.position))
						{
							CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[4];
						}
						break;
					}
				}
				foreach (ConstructorGex item7 in Gexa.GexLib)
				{
					if (item7.NameGex == CharacterMotion._CurGex._XGex + 1 + "x" + (CharacterMotion._CurGex._YGex - 1) + "y")
					{
						CharacterMotion.GexNears[5] = item7;
						if (Vector3.Distance(CharacterMotion.GexNears[5].GexGO.transform.position, AAAAAAAAAAAAAAAAAAck.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, AAAAAAAAAAAAAAAAAAck.transform.position))
						{
							CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[5];
						}
						break;
					}
				}
			}
			else
			{
				foreach (ConstructorGex item8 in Gexa.GexLib)
				{
					if (item8.NameGex == CharacterMotion._CurGex._XGex - 1 + "x" + (CharacterMotion._CurGex._YGex + 1) + "y")
					{
						CharacterMotion.GexNears[0] = item8;
						if (Vector3.Distance(CharacterMotion.GexNears[0].GexGO.transform.position, AAAAAAAAAAAAAAAAAAck.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, AAAAAAAAAAAAAAAAAAck.transform.position))
						{
							CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[0];
						}
						break;
					}
				}
				foreach (ConstructorGex item9 in Gexa.GexLib)
				{
					if (item9.NameGex == CharacterMotion._CurGex._XGex - 1 + "x" + CharacterMotion._CurGex._YGex + "y")
					{
						CharacterMotion.GexNears[1] = item9;
						if (Vector3.Distance(CharacterMotion.GexNears[1].GexGO.transform.position, AAAAAAAAAAAAAAAAAAck.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, AAAAAAAAAAAAAAAAAAck.transform.position))
						{
							CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[1];
						}
						break;
					}
				}
				foreach (ConstructorGex item10 in Gexa.GexLib)
				{
					if (item10.NameGex == CharacterMotion._CurGex._XGex - 1 + "x" + (CharacterMotion._CurGex._YGex - 1) + "y")
					{
						CharacterMotion.GexNears[2] = item10;
						if (Vector3.Distance(CharacterMotion.GexNears[2].GexGO.transform.position, AAAAAAAAAAAAAAAAAAck.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, AAAAAAAAAAAAAAAAAAck.transform.position))
						{
							CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[2];
						}
						break;
					}
				}
				foreach (ConstructorGex item11 in Gexa.GexLib)
				{
					if (item11.NameGex == CharacterMotion._CurGex._XGex + "x" + (CharacterMotion._CurGex._YGex + 1) + "y")
					{
						CharacterMotion.GexNears[3] = item11;
						if (Vector3.Distance(CharacterMotion.GexNears[3].GexGO.transform.position, AAAAAAAAAAAAAAAAAAck.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, AAAAAAAAAAAAAAAAAAck.transform.position))
						{
							CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[3];
						}
						break;
					}
				}
				foreach (ConstructorGex item12 in Gexa.GexLib)
				{
					if (item12.NameGex == CharacterMotion._CurGex._XGex + 1 + "x" + CharacterMotion._CurGex._YGex + "y")
					{
						CharacterMotion.GexNears[4] = item12;
						if (Vector3.Distance(CharacterMotion.GexNears[4].GexGO.transform.position, AAAAAAAAAAAAAAAAAAck.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, AAAAAAAAAAAAAAAAAAck.transform.position))
						{
							CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[4];
						}
						break;
					}
				}
				foreach (ConstructorGex item13 in Gexa.GexLib)
				{
					if (item13.NameGex == CharacterMotion._CurGex._XGex + "x" + (CharacterMotion._CurGex._YGex - 1) + "y")
					{
						CharacterMotion.GexNears[5] = item13;
						if (Vector3.Distance(CharacterMotion.GexNears[5].GexGO.transform.position, AAAAAAAAAAAAAAAAAAck.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, AAAAAAAAAAAAAAAAAAck.transform.position))
						{
							CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[5];
						}
						break;
					}
				}
			}
			if (!(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].NameGex != Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.NameGex))
			{
				break;
			}
			CharacterMotion._CurGex = CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1];
			CharacterMotion._NextGex.Add(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1]);
			CharacterMotion._DistansMove++;
		}
		foreach (ConstructorGex item14 in CharacterMotion._NextGex)
		{
			item14.GexGO.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 1f, 0.8f);
		}
		if (CharacterMotion._NextGex.Count > 0)
		{
			for (int i = 0; i < CharacterMotion._NextGex.Count - 1 - CharacterMotion._PointsMove; i++)
			{
				GameObject.Find(CharacterMotion._NextGex[i].NameGex).GetComponent<SpriteRenderer>().color = new Color(0.65f, 0.65f, 0.5f, 0.8f);
			}
		}
		Inventory._CurrentCharUnit.Clear();
		Inventory._CurrentPoint.Clear();
		Inventory._CurtainIconCharacterU.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, (Inventory._CurrentCharUnit.Count + Inventory._CurrentPoint.Count) * Inventory._posY8);
		if (CharacterMotion._PointsMove > 0)
		{
			Inventory._GGActive = true;
			return;
		}
		Debug.Log("критичное завершение хода");
		GameObject.Find("Data").GetComponent<Inventory>().AAAAAAAAAAAAAAAAAAcg();
	}

	public static void AAAAAAAAAAAAAAAAAAAAbx()
	{
		CharacterMotion._DistansMove = 0;
		if (CharacterMotion._NextGex.Count > 0)
		{
			foreach (ConstructorGex item in CharacterMotion._NextGex)
			{
				item.GexGO.GetComponent<SpriteRenderer>().color = new Color(0.45f, 0.45f, 0.25f, 0.25f);
			}
			CharacterMotion._NextGex.Clear();
		}
		CharacterMotion._NextGex.Add(_EnemyTarget.CurGexChar);
		CharacterMotion._NextGex.Add(_EnemyTarget.CurGexChar);
		CharacterMotion._CurGex = _EnemyTarget.CurGexChar;
		while (true)
		{
			if (CharacterMotion._CurGex._YGex % 2 == 0)
			{
				foreach (ConstructorGex item2 in Gexa.GexLib)
				{
					if (item2.NameGex == CharacterMotion._CurGex._XGex + "x" + (CharacterMotion._CurGex._YGex + 1) + "y")
					{
						CharacterMotion.GexNears[0] = item2;
						if (Vector3.Distance(CharacterMotion.GexNears[0].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position))
						{
							CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[0];
							break;
						}
					}
				}
				foreach (ConstructorGex item3 in Gexa.GexLib)
				{
					if (item3.NameGex == CharacterMotion._CurGex._XGex - 1 + "x" + CharacterMotion._CurGex._YGex + "y")
					{
						CharacterMotion.GexNears[1] = item3;
						if (Vector3.Distance(CharacterMotion.GexNears[1].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position))
						{
							CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[1];
							break;
						}
					}
				}
				foreach (ConstructorGex item4 in Gexa.GexLib)
				{
					if (item4.NameGex == CharacterMotion._CurGex._XGex + "x" + (CharacterMotion._CurGex._YGex - 1) + "y")
					{
						CharacterMotion.GexNears[2] = item4;
						if (Vector3.Distance(CharacterMotion.GexNears[2].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position))
						{
							CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[2];
							break;
						}
					}
				}
				foreach (ConstructorGex item5 in Gexa.GexLib)
				{
					if (item5.NameGex == CharacterMotion._CurGex._XGex + 1 + "x" + (CharacterMotion._CurGex._YGex + 1) + "y")
					{
						CharacterMotion.GexNears[3] = item5;
						if (Vector3.Distance(CharacterMotion.GexNears[3].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position))
						{
							CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[3];
							break;
						}
					}
				}
				foreach (ConstructorGex item6 in Gexa.GexLib)
				{
					if (item6.NameGex == CharacterMotion._CurGex._XGex + 1 + "x" + CharacterMotion._CurGex._YGex + "y")
					{
						CharacterMotion.GexNears[4] = item6;
						if (Vector3.Distance(CharacterMotion.GexNears[4].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position))
						{
							CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[4];
							break;
						}
					}
				}
				foreach (ConstructorGex item7 in Gexa.GexLib)
				{
					if (item7.NameGex == CharacterMotion._CurGex._XGex + 1 + "x" + (CharacterMotion._CurGex._YGex - 1) + "y")
					{
						CharacterMotion.GexNears[5] = item7;
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
				foreach (ConstructorGex item8 in Gexa.GexLib)
				{
					if (item8.NameGex == CharacterMotion._CurGex._XGex - 1 + "x" + (CharacterMotion._CurGex._YGex + 1) + "y")
					{
						CharacterMotion.GexNears[0] = item8;
						if (Vector3.Distance(CharacterMotion.GexNears[0].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position))
						{
							CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[0];
							break;
						}
					}
				}
				foreach (ConstructorGex item9 in Gexa.GexLib)
				{
					if (item9.NameGex == CharacterMotion._CurGex._XGex - 1 + "x" + CharacterMotion._CurGex._YGex + "y")
					{
						CharacterMotion.GexNears[1] = item9;
						if (Vector3.Distance(CharacterMotion.GexNears[1].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position))
						{
							CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[1];
							break;
						}
					}
				}
				foreach (ConstructorGex item10 in Gexa.GexLib)
				{
					if (item10.NameGex == CharacterMotion._CurGex._XGex - 1 + "x" + (CharacterMotion._CurGex._YGex - 1) + "y")
					{
						CharacterMotion.GexNears[2] = item10;
						if (Vector3.Distance(CharacterMotion.GexNears[2].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position))
						{
							CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[2];
							break;
						}
					}
				}
				foreach (ConstructorGex item11 in Gexa.GexLib)
				{
					if (item11.NameGex == CharacterMotion._CurGex._XGex + "x" + (CharacterMotion._CurGex._YGex + 1) + "y")
					{
						CharacterMotion.GexNears[3] = item11;
						if (Vector3.Distance(CharacterMotion.GexNears[3].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position))
						{
							CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[3];
							break;
						}
					}
				}
				foreach (ConstructorGex item12 in Gexa.GexLib)
				{
					if (item12.NameGex == CharacterMotion._CurGex._XGex + 1 + "x" + CharacterMotion._CurGex._YGex + "y")
					{
						CharacterMotion.GexNears[4] = item12;
						if (Vector3.Distance(CharacterMotion.GexNears[4].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position))
						{
							CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[4];
							break;
						}
					}
				}
				foreach (ConstructorGex item13 in Gexa.GexLib)
				{
					if (item13.NameGex == CharacterMotion._CurGex._XGex + "x" + (CharacterMotion._CurGex._YGex - 1) + "y")
					{
						CharacterMotion.GexNears[5] = item13;
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
		for (int i = 0; i < Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Range; i++)
		{
			if (CharacterMotion._NextGex.Count > 0)
			{
				CharacterMotion._NextGex.Remove(CharacterMotion._NextGex[0]);
			}
		}
		if (CharacterMotion._NextGex.Count > 0)
		{
			CharacterMotion._Turget.transform.position = CharacterMotion._NextGex[0].GexGO.transform.position;
		}
		else
		{
			CharacterMotion._Turget.transform.position = Data.CharacterD[CharacterMotion._curCharacter].CharUnits.transform.position;
		}
		foreach (ConstructorGex item14 in CharacterMotion._NextGex)
		{
			item14.GexGO.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 1f, 0.8f);
		}
		if (CharacterMotion._DistansMove < CharacterMotion._PointsMove)
		{
			Inventory._StateCharacter = true;
		}
		else
		{
			Inventory._StateCharacter = false;
		}
		Inventory._CurrentCharUnit.Clear();
		Inventory._CurrentPoint.Clear();
		Inventory._CurtainIconCharacterU.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, (Inventory._CurrentCharUnit.Count + Inventory._CurrentPoint.Count) * Inventory._posY8);
		Inventory._GGActive = true;
	}

	public static void AAAAAAAAAAAAAAAAAbq()
	{
		float num = 20000f;
		ConstructorGex taskGexChar = Data.CharacterD[CharacterMotion._curCharacter].TaskGexChar;
		foreach (ConstructorPoints point in Data.Points)
		{
			if (Vector3.Distance(point.curGexPoint.GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CharUnits.transform.position) < num)
			{
				taskGexChar = point.curGexPoint;
				num = Vector3.Distance(point.curGexPoint.GexGO.transform.position, Data.CharacterD[CharacterMotion._curCharacter].CharUnits.transform.position);
			}
		}
		Data.CharacterD[CharacterMotion._curCharacter].TaskGexChar = taskGexChar;
		Debug.Log(Data.CharacterD[CharacterMotion._curCharacter].NameU + " выбрал укрытие");
	}
}
