using UnityEngine;
using UnityEngine.SceneManagement;

public class Bonus : MonoBehaviour
{
	public static void AAAAAAAAAAAAAAAAAAdh()
	{
		if (!Data.CharacterD[CharacterMotion._curCharacter].Life)
		{
			return;
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].Bonus && Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 1)
		{
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 1)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.CostSubject < 2100)
				{
					Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new TOZ34();
				}
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[4] = new AAAAAAAAAAAAAAba();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 2)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.CostSubject < 2100)
				{
					Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new MP135();
				}
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 3)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.CostSubject < 2100)
				{
					Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new Bekas12();
				}
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[4] = new AAAAAAAAAAAAAAba();
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 4)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				if (Data.CharacterD[CharacterMotion._curCharacter].SuitChar.CostSubject < 14000)
				{
					Data.CharacterD[CharacterMotion._curCharacter].SuitChar = new AAAAAAAAAAAAAAAAAx();
				}
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[4] = new AAAAAAAAAAAAAAAAAAAAAbp();
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 5)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = Data.Artefacts[Random.Range(0, Data.Artefacts.Count - 1)];
				if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.CostSubject < 2500)
				{
					Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new AK74();
				}
				Data.CharacterD[CharacterMotion._curCharacter].DetectorChar = new AAAAAAAAAAAAAAAAAAce();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[4] = new AAAAAAAAAAAAAAAAAAAbg();
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 6)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[8] = Data.Artefacts[Random.Range(0, Data.Artefacts.Count - 1)];
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[4] = new AAAAAAAAAAAAAAAAAAAAAbp();
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 8)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.CostSubject < 15000)
				{
					Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new AN94();
				}
				Data.CharacterD[CharacterMotion._curCharacter].DetectorChar = new AAAAAAAAAAAAAAAAbi();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 12)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				if (Data.CharacterD[CharacterMotion._curCharacter].SuitChar.CostSubject < 16000)
				{
					Data.CharacterD[CharacterMotion._curCharacter].SuitChar = new AAAAAAAAAAAAAAAAAAAbb();
				}
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 18)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				if (Data.CharacterD[CharacterMotion._curCharacter].SuitChar.CostSubject < 48000)
				{
					Data.CharacterD[CharacterMotion._curCharacter].SuitChar = new AAAAAAAAAAAAAAAAAAAAbh();
				}
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 20)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.CostSubject < 15000)
				{
					Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new SVD();
				}
				Data.CharacterD[CharacterMotion._curCharacter].DetectorChar = new AAAAAAAAAAAAAAAAbi();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
			}
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].Bonus && Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 2)
		{
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 1)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.CostSubject < new TOZ34().CostSubject)
				{
					Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new TOZ34();
				}
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAba();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 2)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.CostSubject < new Winchester1300().CostSubject)
				{
					Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new Winchester1300();
				}
				if (Data.CharacterD[CharacterMotion._curCharacter].SuitChar.CostSubject < new AAAAAAAAAAAAAAAAAAbj().CostSubject)
				{
					Data.CharacterD[CharacterMotion._curCharacter].SuitChar = new AAAAAAAAAAAAAAAAAAbj();
				}
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAAbg();
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 3)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.CostSubject < new MP5().CostSubject)
				{
					Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new MP5();
				}
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAAbg();
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 4)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].SuitChar = new AAAAAAAAAAAAAAAAAAbk();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[4] = new AAAAAAAAAAAAAAba();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 5)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 6)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].SuitChar = new AAAAAAAAAAAAAAAAAAbk();
				if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.CostSubject < new AK74().CostSubject)
				{
					Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new AK74();
				}
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 10)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].SuitChar = new AAAAAAAAAAAAAAAAAAbk();
				if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.CostSubject < new Val().CostSubject)
				{
					Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new Val();
				}
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
			}
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].Bonus && Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 3)
		{
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 1)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAbd();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAba();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 2)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.CostSubject < new AK74().CostSubject && SceneManager.GetActiveScene().name != "Kordon")
				{
					Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new AK74();
				}
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAbd();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 3)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].SuitChar = new AAAAAAAAAAAAAAAAAAAAAbj();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAbd();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 5)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.CostSubject < new Val().CostSubject && SceneManager.GetActiveScene().name != "Kordon")
				{
					Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new Val();
				}
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAbd();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 8)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.CostSubject < new AN94().CostSubject && SceneManager.GetActiveScene().name != "Kordon")
				{
					Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new AN94();
				}
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAbd();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 14)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].SuitChar = new AAAAAAAAAAAAAAAAAAAba();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAbd();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 15)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].SuitChar.ArtContainer = 2;
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAbd();
			}
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].Bonus && Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 4)
		{
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 1)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.CostSubject < new Bekas12Tactical().CostSubject)
				{
					Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new Bekas12Tactical();
				}
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[4] = new AAAAAAAAAAAAAAAAAba();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 2)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.CostSubject < new AKSy().CostSubject)
				{
					Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new AKSy();
				}
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 3)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.CostSubject < new AK74().CostSubject)
				{
					Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new AK74();
				}
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = Data.Artefacts[Random.Range(0, Data.Artefacts.Count - 1)];
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[4] = new AAAAAAAAAAAAAAAAAAAbg();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[5] = new VOG25();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 6)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.CostSubject < new Val().CostSubject)
				{
					Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new Val();
				}
				Data.CharacterD[CharacterMotion._curCharacter].DetectorChar = new AAAAAAAAAAAAAAAAAAce();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[4] = new AAAAAAAAAAAAAAAAAAAAAbp();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 7)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.CostSubject < new AN94().CostSubject)
				{
					Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new AN94();
				}
				Data.CharacterD[CharacterMotion._curCharacter].DetectorChar = new AAAAAAAAAAAAAAAAAAce();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[4] = new AAAAAAAAAAAAAAAAAAAAAbp();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 8)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				if (Data.CharacterD[CharacterMotion._curCharacter].SuitChar.CostSubject < new AAAAAAAAAAAAAAAAAAt().CostSubject)
				{
					Data.CharacterD[CharacterMotion._curCharacter].SuitChar = new AAAAAAAAAAAAAAAAAAt();
				}
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[4] = new AAAAAAAAAAAAAAAAAAAAAbp();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 10)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				if (Data.CharacterD[CharacterMotion._curCharacter].SuitChar.CostSubject < new AAAAAAAAAAAAAAAAAAAAAbk().CostSubject)
				{
					Data.CharacterD[CharacterMotion._curCharacter].SuitChar = new AAAAAAAAAAAAAAAAAAAAAbk();
				}
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[4] = new AAAAAAAAAAAAAAAAAAAAAbp();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 14)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.CostSubject < new SVD().CostSubject)
				{
					Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new SVD();
				}
				Data.CharacterD[CharacterMotion._curCharacter].DetectorChar = new AAAAAAAAAAAAAAAAbi();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 15)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].SuitChar = new AAAAAAAAAAAAAAAAAAu();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
			}
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].Bonus && Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 5)
		{
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 1)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new Bekas12();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 2)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new AKSy();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 3)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new AK74();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = Data.Artefacts[Random.Range(0, Data.Artefacts.Count - 1)];
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[4] = new AAAAAAAAAAAAAAAAAAAbg();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[5] = new AAAAAAAAAAAAAAAAAAAAAbp();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 5)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new LR300ML();
				Data.CharacterD[CharacterMotion._curCharacter].DetectorChar = new AAAAAAAAAAAAAAAAAAce();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 8)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new SIG550();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 9)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].SuitChar = new AAAAAAAAAAAAAAAw();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[4] = new AAAAAAAAAAAAAAAAAAAAAbp();
			}
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].Bonus && Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 6)
		{
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 1)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new Winchester1300();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[4] = new AAAAAAAAAAAAAAba();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 2)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new MP5();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[5] = new VOG25();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 3)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new IL86();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = Data.Artefacts[Random.Range(0, Data.Artefacts.Count - 1)];
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[4] = new AAAAAAAAAAAAAAAAAAAbg();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 5)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].SuitChar = new AAAAAAAAAAAAAAAAAAAAAbh();
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new LR300ML();
				Data.CharacterD[CharacterMotion._curCharacter].DetectorChar = new AAAAAAAAAAAAAAAAAAce();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 8)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.UpGrade = 2f;
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.SingModification = true;
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.State = 100f;
				Data.CharacterD[CharacterMotion._curCharacter].DetectorChar = new AAAAAAAAAAAAAAAAbi();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[4] = new AAAAAAAAAAAAAAAAAAAAAbp();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 10)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].SuitChar = new AAAAAAAAAAAAAAAAAAbl();
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.SightInstallation = true;
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.SingModification = true;
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.State = 100f;
				Data.CharacterD[CharacterMotion._curCharacter].DetectorChar = new AAAAAAAAAAAAAAAAAAce();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 14)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].SuitChar = new AAAAAAAAAAAAAAAAAAv();
				Data.CharacterD[CharacterMotion._curCharacter].DetectorChar = new AAAAAAAAAAAAAAAAbi();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 16)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new GP36E();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
			}
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].Bonus && Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 7)
		{
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 1)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.CostSubject < 1450)
				{
					Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new MP135();
				}
				Data.CharacterD[CharacterMotion._curCharacter].SuitChar = new AAAAAAAAAAAAAAAt();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 2)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.CostSubject < 2000)
				{
					Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new MP5();
				}
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 3)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = Data.Artefacts[Random.Range(0, Data.Artefacts.Count - 1)];
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[4] = new AAAAAAAAAAAAAAAAAAAbg();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[5] = new VOG25();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 5)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.CostSubject < 2500)
				{
					Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new AK74();
				}
				Data.CharacterD[CharacterMotion._curCharacter].DetectorChar = new AAAAAAAAAAAAAAAAAAce();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 6)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].SuitChar = new AAAAAAAAAAAAAAAu();
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new LR300ML();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 8)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new SIG550();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 10)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].SuitChar = new AAAAAAAAAAAAAAAv();
				Data.CharacterD[CharacterMotion._curCharacter].DetectorChar = new AAAAAAAAAAAAAAAAbi();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
			}
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].Bonus && Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 8)
		{
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 1)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new MP5();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[4] = new AAAAAAAAAAAAAAba();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 2)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new AK74();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[4] = new AAAAAAAAAAAAAAAAAAAAAbp();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[5] = new VOG25();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 3)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = Data.Artefacts[Random.Range(0, Data.Artefacts.Count - 1)];
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[4] = new AAAAAAAAAAAAAAAAAAAbg();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 5)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new LR300ML();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[4] = new AAAAAAAAAAAAAAAAAAAAAbp();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 8)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new SIG550();
				Data.CharacterD[CharacterMotion._curCharacter].DetectorChar = new AAAAAAAAAAAAAAAAAAce();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 9)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].SuitChar = new AAAAAAAAAAAAAAAAAAAAbh();
				Data.CharacterD[CharacterMotion._curCharacter].DetectorChar = new AAAAAAAAAAAAAAAAbi();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 10)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].SuitChar = new AAAAAAAAAAAAAAAAAAAAbg();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 12)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new GaussGun();
				Data.CharacterD[CharacterMotion._curCharacter].DetectorChar = new AAAAAAAAAAAAAAAAbi();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 14)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].SuitChar = new AAAAAAAAAAAAAAAAAAw();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 16)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new SVD();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
			}
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].Bonus && Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 9)
		{
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 1)
			{
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Damage += 0.5f;
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.State = 100f;
				Data.CharacterD[CharacterMotion._curCharacter].CurHealth += 5f;
				Data.CharacterD[CharacterMotion._curCharacter].Bleeding -= 2f;
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 2)
			{
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Damage += 0.5f;
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.State = 100f;
				Data.CharacterD[CharacterMotion._curCharacter].CurHealth += 5f;
				Data.CharacterD[CharacterMotion._curCharacter].Bleeding -= 2f;
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 3)
			{
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Damage += 1.5f;
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.State = 100f;
				Data.CharacterD[CharacterMotion._curCharacter].CurHealth += 5f;
				Data.CharacterD[CharacterMotion._curCharacter].Bleeding -= 2f;
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 4)
			{
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Damage += 0.5f;
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.State = 100f;
				Data.CharacterD[CharacterMotion._curCharacter].CurHealth += 10f;
				Data.CharacterD[CharacterMotion._curCharacter].Bleeding -= 4f;
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 5)
			{
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Damage += 0.5f;
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.State = 100f;
				Data.CharacterD[CharacterMotion._curCharacter].CurHealth += 5f;
				Data.CharacterD[CharacterMotion._curCharacter].Bleeding -= 2f;
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 6)
			{
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Damage += 0.5f;
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.State = 100f;
				Data.CharacterD[CharacterMotion._curCharacter].CurHealth += 5f;
				Data.CharacterD[CharacterMotion._curCharacter].Bleeding -= 2f;
			}
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].Bonus && Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 10 && Data.CharacterD[CharacterMotion._curCharacter].TypeChar == AAAAAAAAAAAAAAAAf.TypeCharacter.Зомби)
		{
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 1)
			{
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[8] = Data.Artefacts[Random.Range(0, Data.Artefacts.Count - 1)];
				Data.CharacterD[CharacterMotion._curCharacter].CurHealth += 5f;
				Data.CharacterD[CharacterMotion._curCharacter].Bleeding -= 2f;
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[4] = new AAAAAAAAAAAAAAAAAAAAAbp();
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 2)
			{
				Data.CharacterD[CharacterMotion._curCharacter].CurHealth += 5f;
				Data.CharacterD[CharacterMotion._curCharacter].Bleeding -= 2f;
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = Data.Artefacts[Random.Range(0, Data.Artefacts.Count - 1)];
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[4] = new AAAAAAAAAAAAAAAAAAAbg();
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 3)
			{
				Data.CharacterD[CharacterMotion._curCharacter].CurHealth += 5f;
				Data.CharacterD[CharacterMotion._curCharacter].Bleeding -= 2f;
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = Data.Artefacts[Random.Range(0, Data.Artefacts.Count - 1)];
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[4] = new AAAAAAAAAAAAAAAAAAAbg();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[5] = new AAAAAAAAAAAAAAAAAba();
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 4)
			{
				Data.CharacterD[CharacterMotion._curCharacter].CurHealth += 5f;
				Data.CharacterD[CharacterMotion._curCharacter].Bleeding -= 2f;
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = Data.Artefacts[Random.Range(0, Data.Artefacts.Count - 1)];
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[4] = new AAAAAAAAAAAAAAAAAAAbg();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 5)
			{
				Data.CharacterD[CharacterMotion._curCharacter].CurHealth += 5f;
				Data.CharacterD[CharacterMotion._curCharacter].Bleeding -= 2f;
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = Data.Artefacts[Random.Range(0, Data.Artefacts.Count - 1)];
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[4] = new AAAAAAAAAAAAAAAAAAAbg();
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new SPAS12();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 6)
			{
				Data.CharacterD[CharacterMotion._curCharacter].CurHealth += 5f;
				Data.CharacterD[CharacterMotion._curCharacter].Bleeding -= 2f;
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = Data.Artefacts[Random.Range(0, Data.Artefacts.Count - 1)];
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[4] = new AAAAAAAAAAAAAAAAAAAbg();
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
			}
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].Bonus && Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 11)
		{
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 1)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].SuitChar = new AAAAAAAAAAAAAAAAAAbm();
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new MP135();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[4] = new AAAAAAAAAAAAAAba();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 2)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new MP5();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 3)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = Data.Artefacts[Random.Range(0, Data.Artefacts.Count - 1)];
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[4] = new AAAAAAAAAAAAAAAAAAAbg();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[5] = new AAAAAAAAAAAAAAAAAAAAAbp();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 5)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new AK74();
				Data.CharacterD[CharacterMotion._curCharacter].DetectorChar = new AAAAAAAAAAAAAAAAAAce();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 5)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new SIG550();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 6)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].SuitChar = new AAAAAAAAAAAAAAAAAy();
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new AN94();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 8)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new Vintores();
				Data.CharacterD[CharacterMotion._curCharacter].DetectorChar = new AAAAAAAAAAAAAAAAbi();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 11)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].SuitChar = new AAAAAAAAAAAAAAAAAAAbb();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 14)
			{
				Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
				Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new SVD();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
				Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
			}
		}
		if (!Data.CharacterD[CharacterMotion._curCharacter].Bonus || Data.CharacterD[CharacterMotion._curCharacter].TypeChInt != 12)
		{
			return;
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 1)
		{
			Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
			Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
			if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.CostSubject < new TOZ34().CostSubject)
			{
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new TOZ34();
			}
			Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
			Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
			Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAba();
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 2)
		{
			Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
			if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.CostSubject < new Winchester1300().CostSubject)
			{
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new Winchester1300();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].SuitChar.CostSubject < new AAAAAAAAAAAAAAAAAAbj().CostSubject)
			{
				Data.CharacterD[CharacterMotion._curCharacter].SuitChar = new AAAAAAAAAAAAAAAAAAbj();
			}
			Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAAAbs();
			Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAAbg();
			Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 3)
		{
			Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
			if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.CostSubject < new MP5().CostSubject)
			{
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new MP5();
			}
			Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAAAbs();
			Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAAbg();
			Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 4)
		{
			Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
			Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
			Data.CharacterD[CharacterMotion._curCharacter].SuitChar = new AAAAAAAAAAAAAAAAAAbk();
			Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
			Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
			Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
			Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[4] = new AAAAAAAAAAAAAAba();
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 5)
		{
			Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
			Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
			Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
			Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
			Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 6)
		{
			Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
			Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
			Data.CharacterD[CharacterMotion._curCharacter].SuitChar = new AAAAAAAAAAAAAAAAAAbk();
			if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.CostSubject < new AK74().CostSubject)
			{
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new AK74();
			}
			Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
			Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
			Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].Skill == 15)
		{
			Data.CharacterD[CharacterMotion._curCharacter].Cash += 500;
			Data.CharacterD[CharacterMotion._curCharacter].Bonus = false;
			Data.CharacterD[CharacterMotion._curCharacter].SuitChar = new AAAAAAAAAAAAAAAAAAAAAbg();
			if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.CostSubject < new Vintores().CostSubject)
			{
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar = new Vintores();
			}
			Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[1] = new AAAAAAAAAAAAAAAAz();
			Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[2] = new AAAAAAAAAAAAAAAAAAbs();
			Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[3] = new AAAAAAAAAAAAAAAAAAAbg();
		}
	}
}
