using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AAAAAAAAAAAAAAAj : AAAAAAAAAAAAAAAAf
{
	public AAAAAAAAAAAAAAAj()
	{
		base.ControlGamer = false;
		base.NameCharac = "Монолит";
		base.CurGexChar = Gexa.GexLib[250];
		base.TaskGexChar = Gexa.GexLib[250];
		base.CharUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/CharacterIcon"));
		base.CharUnits.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/IconGroup/Monolith64Var");
		base.CharUnits.transform.position = base.CurGexChar.GexGO.transform.position;
		base.CharUnits.name = NameCharacter.NameCharLib[Random.Range(0, NameCharacter.NameCharLib.Length - 1)] + " " + NameCharacter.NickCharLib[Random.Range(0, NameCharacter.NickCharLib.Length - 1)] + ", Монолит";
		base.NameU = base.CharUnits.name;
		base.TypeChar = TypeCharacter.Монолит;
		base.TextureChar = (Texture2D)Resources.Load("Sprites/IconGroup/Monolith64Var");
		base.Skill = 0;
		for (int i = 0; i < base.ArtContainers.Length; i++)
		{
			base.ArtContainers[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		for (int j = 0; j < base.CharBackpack.Length; j++)
		{
			base.CharBackpack[j] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.SuitChar = new AAAAAAAAAAAAAAAAAAAAAbi();
		base.WeaponChar = new Remington870Tactical();
		if (SceneManager.GetActiveScene().name == "DarkValley" || SceneManager.GetActiveScene().name == "Radar" || SceneManager.GetActiveScene().name == "RedForest")
		{
			base.WeaponChar = new AKSy();
			base.Skill = 1;
		}
		base.CharBackpack[0] = new AAAAAAAAAAAAAAAAAAbs();
		base.ArtChar = new AAAAAAAAAAAAAAAAAAbi();
		base.DetectorChar = new AAAAAAAAAAAAAAAbg();
		base.TypeChInt = 8;
		base.AudioDeath = (AudioClip)Resources.Load("Sound/human/deathMonolith");
		base.AudioStep_L = (AudioClip)Resources.Load("Sound/human/new_gravel1");
		base.AudioStep_R = (AudioClip)Resources.Load("Sound/human/new_gravel2");
		base.AudioPain_L = NameCharacter.PainHuman[Random.Range(0, NameCharacter.PainHuman.Length - 1)];
		base.AudioPain_R = NameCharacter.PainHuman[Random.Range(0, NameCharacter.PainHuman.Length - 1)];
		base.NPSattackVoice = new List<AudioClip>();
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/monolith/attack/attack_1"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/monolith/attack/attack_2"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/monolith/attack/attack_3"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/monolith/attack/attack_4"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/monolith/attack/attack_many_1"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/monolith/attack/attack_many_2"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/monolith/attack/attack_many_3"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/monolith/attack/attack_many_4"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/monolith/attack/attack_many_5"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/monolith/attack/attack_one_1"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/monolith/attack/attack_one_2"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/monolith/attack/attack_one_3"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/monolith/attack/attack_one_4"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/monolith/attack/attack_one_5"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/monolith/backup/backup_1"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/monolith/backup/backup_2"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/monolith/backup/backup_3"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/monolith/backup/backup_4"));
	}
}
