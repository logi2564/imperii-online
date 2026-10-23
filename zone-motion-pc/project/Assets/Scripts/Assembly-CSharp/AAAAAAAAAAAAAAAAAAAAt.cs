using System.Collections.Generic;
using UnityEngine;

public class AAAAAAAAAAAAAAAAAAAAt : AAAAAAAAAAAAAAAAf
{
	public AAAAAAAAAAAAAAAAAAAAt()
	{
		base.ControlGamer = false;
		base.NameCharac = "Слепой пес";
		base.CurGexChar = Gexa.GexLib[Random.Range(0, Gexa.GexLib.Count - 1)];
		base.TaskGexChar = base.CurGexChar;
		base.CharUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/CharacterIcon"));
		base.CharUnits.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/IconGroup/Dog64");
		base.CharUnits.transform.position = base.CurGexChar.GexGO.transform.position;
		base.CharUnits.name = base.NameCharac + ", " + NameCharacter.NameMutantLib[Random.Range(0, NameCharacter.NameMutantLib.Length - 1)] + ", " + NameCharacter.NameMutantLib[Random.Range(0, NameCharacter.NameMutantLib.Length - 1)];
		base.NameU = base.CharUnits.name;
		base.TypeChar = TypeCharacter.Пес;
		base.Skill = 0;
		for (int i = 0; i < base.ArtContainers.Length; i++)
		{
			base.ArtContainers[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		for (int j = 0; j < base.CharBackpack.Length; j++)
		{
			base.CharBackpack[j] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.SuitChar = new AAAAAAAAAAAAAAAAAAAAbk();
		base.WeaponChar = new WeaDog();
		base.ArtChar = new AAAAAAAAAAAAAAAAAAbi();
		base.DetectorChar = new AAAAAAAAAAAAAAAAAAbi();
		base.TypeChInt = 9;
		base.Cash = 0;
		base.AudioDeath = (AudioClip)Resources.Load("Sound/monsters/bdog_hurt_0");
		base.AudioStep_L = (AudioClip)Resources.Load("Sound/monsters/bdog_groan_0");
		base.AudioStep_R = (AudioClip)Resources.Load("Sound/monsters/bdog_idle_1");
		base.AudioPain_L = (AudioClip)Resources.Load("Sound/monsters/bdog_hurt_0");
		base.AudioPain_R = (AudioClip)Resources.Load("Sound/monsters/bdog_panic_0");
		base.NPSattackVoice = new List<AudioClip>();
	}
}
