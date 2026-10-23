using System.Collections.Generic;
using UnityEngine;

public class AAAAAAAAAAAAAAAAAt : AAAAAAAAAAAAAAAAf
{
	public AAAAAAAAAAAAAAAAAt()
	{
		base.ControlGamer = false;
		base.NameCharac = "Псевдособака";
		base.CurGexChar = Gexa.GexLib[Random.Range(0, Gexa.GexLib.Count - 1)];
		base.TaskGexChar = base.CurGexChar;
		base.CharUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/CharacterIcon"));
		base.CharUnits.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/IconGroup/PseudoDog64");
		base.CharUnits.transform.position = base.CurGexChar.GexGO.transform.position;
		base.CharUnits.name = base.NameCharac + ", " + NameCharacter.NameMutantFemenineLib[Random.Range(0, NameCharacter.NameMutantFemenineLib.Length - 1)] + ", " + NameCharacter.NameMutantFemenineLib[Random.Range(0, NameCharacter.NameMutantFemenineLib.Length - 1)];
		base.NameU = base.CharUnits.name;
		base.TypeChar = TypeCharacter.Псевдособака;
		base.Skill = 0;
		for (int i = 0; i < base.ArtContainers.Length; i++)
		{
			base.ArtContainers[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		for (int j = 0; j < base.CharBackpack.Length; j++)
		{
			base.CharBackpack[j] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.SuitChar = new AAAAAAAAAAAAAAAAAAAAbj();
		base.WeaponChar = new WeaPseudoDog();
		base.ArtChar = new AAAAAAAAAAAAAAAAAAbi();
		base.DetectorChar = new AAAAAAAAAAAAAAAAAAbi();
		base.TypeChInt = 9;
		base.Cash = 0;
		base.AudioDeath = (AudioClip)Resources.Load("Sound/monsters/pdog_death_1");
		base.AudioStep_L = (AudioClip)Resources.Load("Sound/monsters/pdog_aggression_1");
		base.AudioStep_R = (AudioClip)Resources.Load("Sound/monsters/pdog_idle_2");
		base.AudioPain_L = (AudioClip)Resources.Load("Sound/monsters/pdog_howl_0");
		base.AudioPain_R = (AudioClip)Resources.Load("Sound/monsters/pdog_howl_2");
		base.NPSattackVoice = new List<AudioClip>();
	}
}
