using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AAAAAAAAAAAAAAAAAAAAAw : AAAAAAAAAAAAAAAAf
{
	public AAAAAAAAAAAAAAAAAAAAAw()
	{
		base.ControlGamer = false;
		base.NameCharac = "Свобода";
		base.CurGexChar = Gexa.GexLib[250];
		base.TaskGexChar = Gexa.GexLib[250];
		base.CharUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/CharacterIcon"));
		base.CharUnits.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/IconGroup/Freedom64new");
		base.CharUnits.transform.position = base.CurGexChar.GexGO.transform.position;
		base.CharUnits.name = NameCharacter.NameCharLib[Random.Range(0, NameCharacter.NameCharLib.Length - 1)] + " " + NameCharacter.NickCharLib[Random.Range(0, NameCharacter.NickCharLib.Length - 1)] + ", Свобода";
		base.NameU = base.CharUnits.name;
		base.TypeChar = TypeCharacter.Свобода;
		base.TextureChar = (Texture2D)Resources.Load("Sprites/IconGroup/Freedom64new");
		base.Skill = 0;
		for (int i = 0; i < base.ArtContainers.Length; i++)
		{
			base.ArtContainers[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		for (int j = 0; j < base.CharBackpack.Length; j++)
		{
			base.CharBackpack[j] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.SuitChar = new AAAAAAAAAAAAAAAAt();
		base.WeaponChar = new Winchester1300();
		if (SceneManager.GetActiveScene().name == "Military" || SceneManager.GetActiveScene().name == "DarkValley" || SceneManager.GetActiveScene().name == "Radar" || SceneManager.GetActiveScene().name == "RedForest")
		{
			base.Skill = 2;
			base.WeaponChar = new IL86();
		}
		base.CharBackpack[0] = new AAAAAAAAAAAAAAAAAAbs();
		base.ArtChar = new AAAAAAAAAAAAAAAAAAbi();
		base.DetectorChar = new AAAAAAAAAAAAAAAbg();
		base.TypeChInt = 6;
		base.AudioDeath = (AudioClip)Resources.Load("Sound/human/deathFreedom");
		base.AudioStep_L = (AudioClip)Resources.Load("Sound/human/new_gravel1");
		base.AudioStep_R = (AudioClip)Resources.Load("Sound/human/new_gravel2");
		base.AudioPain_L = NameCharacter.PainHuman[Random.Range(0, NameCharacter.PainHuman.Length - 1)];
		base.AudioPain_R = NameCharacter.PainHuman[Random.Range(0, NameCharacter.PainHuman.Length - 1)];
		base.NPSattackVoice = new List<AudioClip>();
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/freedom/attack/attack_1"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/freedom/attack/attack_2"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/freedom/attack/attack_3"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/freedom/attack/attack_4"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/freedom/attack/attack_5"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/freedom/attack/attack_6"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/freedom/attack/attack_7"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/freedom/attack/attack_many_1"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/freedom/attack/attack_many_2"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/freedom/attack/attack_many_3"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/freedom/attack/attack_many_4"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/freedom/attack/attack_one_1"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/freedom/attack/attack_one_2"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/freedom/attack/attack_one_3"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/freedom/attack/attack_one_4"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/freedom/attack/attack_one_5"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/freedom/backup/backup_1"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/freedom/backup/backup_2"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/freedom/backup/backup_3"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/freedom/backup/backup_4"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/freedom/backup/backup_5"));
	}
}
