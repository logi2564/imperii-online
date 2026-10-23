using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AAAAAAAAAAAAAAAAAAAAAx : AAAAAAAAAAAAAAAAf
{
	public AAAAAAAAAAAAAAAAAAAAAx()
	{
		base.ControlGamer = false;
		base.NameCharac = "Чистое небо";
		base.CurGexChar = Gexa.GexLib[250];
		base.TaskGexChar = Gexa.GexLib[250];
		base.CharUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/CharacterIcon"));
		base.CharUnits.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/IconGroup/ClearSky64A");
		base.CharUnits.transform.position = base.CurGexChar.GexGO.transform.position;
		base.CharUnits.name = NameCharacter.NameCharLib[Random.Range(0, NameCharacter.NameCharLib.Length - 1)] + " " + NameCharacter.NickCharLib[Random.Range(0, NameCharacter.NickCharLib.Length - 1)] + ", Чистое небо";
		base.NameU = base.CharUnits.name;
		base.TypeChar = TypeCharacter.Чистое_небо;
		base.TextureChar = (Texture2D)Resources.Load("Sprites/IconGroup/ClearSky64A");
		base.Skill = 0;
		for (int i = 0; i < base.ArtContainers.Length; i++)
		{
			base.ArtContainers[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		for (int j = 0; j < base.CharBackpack.Length; j++)
		{
			base.CharBackpack[j] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.SuitChar = new AAAAAAAAAAAAAAAAAAAAbf();
		base.WeaponChar = new TOZ34();
		if (SceneManager.GetActiveScene().name == "Bar" || SceneManager.GetActiveScene().name == "DeadCity" || SceneManager.GetActiveScene().name == "Military" || SceneManager.GetActiveScene().name == "DarkValley" || SceneManager.GetActiveScene().name == "RedForest")
		{
			base.SuitChar = new AAAAAAAAAAAAAAAt();
			base.WeaponChar = new AKSy();
		}
		if (SceneManager.GetActiveScene().name == "Radar")
		{
			base.SuitChar = new AAAAAAAAAAAAAAAu();
			base.WeaponChar = new LR300ML();
		}
		base.CharBackpack[0] = new AAAAAAAAAAAAAAAAAAbs();
		base.ArtChar = new AAAAAAAAAAAAAAAAAAbi();
		base.DetectorChar = new AAAAAAAAAAAAAAAbg();
		base.TypeChInt = 7;
		base.AudioDeath = (AudioClip)Resources.Load("Sound/human/deathChN");
		base.AudioStep_L = (AudioClip)Resources.Load("Sound/human/new_gravel1");
		base.AudioStep_R = (AudioClip)Resources.Load("Sound/human/new_gravel2");
		base.AudioPain_L = NameCharacter.PainHuman[Random.Range(0, NameCharacter.PainHuman.Length - 1)];
		base.AudioPain_R = NameCharacter.PainHuman[Random.Range(0, NameCharacter.PainHuman.Length - 1)];
		base.NPSattackVoice = new List<AudioClip>();
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/attack/attack_1"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/attack/attack_2"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/attack/attack_3"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/attack/attack_4"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/attack/attack_many_1"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/attack/attack_many_2"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/attack/attack_many_3"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/attack/attack_many_4"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/attack/attack_one_1"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/attack/attack_one_2"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/attack/attack_one_3"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/attack/attack_one_4"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/attack/attack_one_5"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/attack0/attack_1"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/attack0/attack_2"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/attack0/attack_3"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/attack0/attack_4"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/attack0/attack_5"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/attack0/attack_6"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/attack0/attack_many_1"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/attack0/attack_many_2"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/attack0/attack_many_3"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/attack0/attack_many_5"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/attack0/attack_one_1"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/attack0/attack_one_2"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/attack0/attack_one_3"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/attack0/attack_one_4"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/attack0/attack_one_5"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/backup/backup_1"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/backup/backup_2"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/backup/backup_3"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/backup/backup_4"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/backup/backup_5"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/backup/backup_6"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/backup0/backup_1"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/backup0/backup_2"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/backup0/backup_3"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/backup0/backup_4"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/backup0/backup_5"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/backup0/backup_6"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/enemy/enemy_1"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/enemy/enemy_2"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/enemy/enemy_3"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/enemy/enemy_4"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/enemy/enemy_5"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/enemy/enemy_6"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/enemy/enemy_7"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/fire/fire_1"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/fire/fire_2"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/fire/fire_3"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/fire/fire_4"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/fire/fire_5"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/stalker/fire/fire_6"));
	}
}
