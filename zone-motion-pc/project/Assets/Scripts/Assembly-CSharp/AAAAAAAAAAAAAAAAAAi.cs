using System.Collections.Generic;
using UnityEngine;

public class AAAAAAAAAAAAAAAAAAi : AAAAAAAAAAAAAAAAf
{
	public AAAAAAAAAAAAAAAAAAi()
	{
		base.ControlGamer = false;
		base.NameCharac = "Ученые";
		base.CurGexChar = Gexa.GexLib[250];
		base.TaskGexChar = Gexa.GexLib[250];
		base.CharUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/CharacterIcon"));
		base.CharUnits.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/IconGroup/Ecolog64");
		base.CharUnits.transform.position = base.CurGexChar.GexGO.transform.position;
		base.CharUnits.name = NameCharacter.SurnameCharLib[Random.Range(0, NameCharacter.SurnameCharLib.Length - 1)] + ", Ученые";
		base.NameU = base.CharUnits.name;
		base.TypeChar = TypeCharacter.Ученые;
		base.TextureChar = (Texture2D)Resources.Load("Sprites/IconGroup/Ecolog64");
		base.Skill = 0;
		for (int i = 0; i < base.ArtContainers.Length; i++)
		{
			base.ArtContainers[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		for (int j = 0; j < base.CharBackpack.Length; j++)
		{
			base.CharBackpack[j] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.SuitChar = new AAAAAAAAAAAAAAAAAAbm();
		base.WeaponChar = new TOZ34();
		base.CharBackpack[0] = new AAAAAAAAAAAAAAAAAAbs();
		base.ArtChar = new AAAAAAAAAAAAAAAAAAbi();
		base.DetectorChar = new AAAAAAAAAAAAAAAbg();
		base.TypeChInt = 11;
		base.AudioDeath = (AudioClip)Resources.Load("Sound/human/deathEcolog");
		base.AudioStep_L = (AudioClip)Resources.Load("Sound/human/new_gravel1");
		base.AudioStep_R = (AudioClip)Resources.Load("Sound/human/new_gravel2");
		base.AudioPain_L = NameCharacter.PainHuman[Random.Range(0, NameCharacter.PainHuman.Length - 1)];
		base.AudioPain_R = NameCharacter.PainHuman[Random.Range(0, NameCharacter.PainHuman.Length - 1)];
		base.NPSattackVoice = new List<AudioClip>();
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/ecolog/attack/attack_1"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/ecolog/attack/attack_2"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/ecolog/attack/attack_3"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/ecolog/attack/attack_many_1"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/ecolog/attack/attack_many_2"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/ecolog/attack/attack_many_3"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/ecolog/attack/attack_many_4"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/ecolog/attack/attack_one_1"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/ecolog/attack/attack_one_2"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/ecolog/attack/attack_one_3"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/ecolog/attack/attack_one_4"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/ecolog/attack/attack_one_5"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/ecolog/backup/backup_1"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/ecolog/backup/backup_2"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/ecolog/backup/backup_3"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/ecolog/backup/backup_4"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/ecolog/backup/backup_5"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/ecolog/backup/backup_6"));
	}
}
