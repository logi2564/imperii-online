using System.Collections.Generic;
using UnityEngine;

public class AAAAAAAAAAAAAAAAAAAAq : AAAAAAAAAAAAAAAAf
{
	public AAAAAAAAAAAAAAAAAAAAq()
	{
		base.ControlGamer = false;
		base.NameCharac = "Военные";
		base.CurGexChar = Gexa.GexLib[36];
		base.TaskGexChar = Gexa.GexLib[36];
		base.CharUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/CharacterIcon"));
		base.CharUnits.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/IconGroup/Army64");
		base.CharUnits.transform.position = base.CurGexChar.GexGO.transform.position;
		base.CharUnits.name = NameCharacter.RankLib[Random.Range(0, NameCharacter.RankLib.Length - 1)] + " " + NameCharacter.SurnameCharLib[Random.Range(0, NameCharacter.SurnameCharLib.Length - 1)] + ", Военный";
		base.NameU = base.CharUnits.name;
		base.TypeChar = TypeCharacter.Военные;
		base.TextureChar = (Texture2D)Resources.Load("Sprites/IconGroup/Army64");
		base.Skill = 0;
		for (int i = 0; i < base.ArtContainers.Length; i++)
		{
			base.ArtContainers[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		for (int j = 0; j < base.CharBackpack.Length; j++)
		{
			base.CharBackpack[j] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.SuitChar = new AAAAAAAAAAAAAAAs();
		base.WeaponChar = new AKSy();
		base.CharBackpack[0] = new AAAAAAAAAAAAAAAAAAbs();
		base.ArtChar = new AAAAAAAAAAAAAAAAAAbi();
		base.DetectorChar = new AAAAAAAAAAAAAAAAAAbi();
		base.TypeChInt = 3;
		base.AudioDeath = (AudioClip)Resources.Load("Sound/human/deathArmy");
		base.AudioStep_L = (AudioClip)Resources.Load("Sound/human/new_gravel1");
		base.AudioStep_R = (AudioClip)Resources.Load("Sound/human/new_gravel2");
		base.AudioPain_L = NameCharacter.PainHuman[Random.Range(0, NameCharacter.PainHuman.Length - 1)];
		base.AudioPain_R = NameCharacter.PainHuman[Random.Range(0, NameCharacter.PainHuman.Length - 1)];
		base.NPSattackVoice = new List<AudioClip>();
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/army/attack/attack_1"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/army/attack/attack_2"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/army/attack/attack_many_1"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/army/attack/attack_many_2"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/army/attack/attack_many_3"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/army/attack/attack_many_4"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/army/attack/attack_many_5"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/army/attack/attack_many_6"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/army/attack/attack_one_1"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/army/attack/attack_one_2"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/army/attack/attack_one_3"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/army/attack/attack_one_4"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/army/attack/attack_one_5"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/army/fire/fire_1"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/army/fire/fire_2"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/army/fire/fire_3"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/army/fire/fire_4"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/army/fire/fire_5"));
	}
}
