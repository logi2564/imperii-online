using System.Collections.Generic;
using UnityEngine;

public class AAAAAAAAAAAAAAAAAAba : AAAAAAAAAAAAAAAAf
{
	public AAAAAAAAAAAAAAAAAAba()
	{
		base.ControlGamer = false;
		base.NameCharac = "Кровосос";
		base.CurGexChar = Gexa.GexLib[150];
		base.TaskGexChar = Gexa.GexLib[150];
		base.CharUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/CharacterIcon"));
		base.CharUnits.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/IconGroup/BloodsuckerVar");
		base.CharUnits.transform.position = base.CurGexChar.GexGO.transform.position;
		base.CharUnits.name = base.NameCharac + ", " + NameCharacter.NameMutantLib[Random.Range(0, NameCharacter.NameMutantLib.Length - 1)];
		base.NameU = base.CharUnits.name;
		base.TypeChar = TypeCharacter.Кровосос;
		base.TextureChar = (Texture2D)Resources.Load("Sprites/IconGroup/BloodsuckerVar");
		base.Skill = 0;
		for (int i = 0; i < base.ArtContainers.Length; i++)
		{
			base.ArtContainers[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		for (int j = 0; j < base.CharBackpack.Length; j++)
		{
			base.CharBackpack[j] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.SuitChar = new AAAAAAAAAAAAAAAAAz();
		base.WeaponChar = new LegSnork();
		base.ArtChar = new AAAAAAAAAAAAAAAAAAbi();
		base.DetectorChar = new AAAAAAAAAAAAAAAAAAbi();
		base.TypeChInt = 10;
		base.Cash = 0;
		base.AudioDeath = (AudioClip)Resources.Load("Sound/monsters/Bloodsucker_die_0");
		base.AudioStep_L = (AudioClip)Resources.Load("Sound/monsters/Bloodsucker_idle_0");
		base.AudioStep_R = (AudioClip)Resources.Load("Sound/monsters/bloodsucker_script_attack_0");
		base.AudioPain_L = (AudioClip)Resources.Load("Sound/monsters/Bloodsucker_hit_2");
		base.AudioPain_R = (AudioClip)Resources.Load("Sound/monsters/Bloodsucker_eat_1");
		base.NPSattackVoice = new List<AudioClip>();
	}
}
