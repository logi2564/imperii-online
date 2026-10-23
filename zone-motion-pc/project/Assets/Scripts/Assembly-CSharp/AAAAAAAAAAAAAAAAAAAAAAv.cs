using System.Collections.Generic;
using UnityEngine;

public class AAAAAAAAAAAAAAAAAAAAAAv : AAAAAAAAAAAAAAAAf
{
	public AAAAAAAAAAAAAAAAAAAAAAv()
	{
		base.ControlGamer = false;
		base.NameCharac = "Зомби";
		base.CurGexChar = Gexa.GexLib[150];
		base.TaskGexChar = Gexa.GexLib[150];
		base.CharUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/CharacterIcon"));
		base.CharUnits.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/IconGroup/Zomby64");
		base.CharUnits.transform.position = base.CurGexChar.GexGO.transform.position;
		base.CharUnits.name = NameCharacter.NameCharLib[Random.Range(0, NameCharacter.NameCharLib.Length - 1)] + " " + NameCharacter.NickCharLib[Random.Range(0, NameCharacter.NickCharLib.Length - 1)] + ", Зомбированный";
		base.NameU = base.CharUnits.name;
		base.TypeChar = TypeCharacter.Зомби;
		base.TextureChar = (Texture2D)Resources.Load("Sprites/IconGroup/Zomby64");
		base.Skill = 0;
		for (int i = 0; i < base.ArtContainers.Length; i++)
		{
			base.ArtContainers[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		for (int j = 0; j < base.CharBackpack.Length; j++)
		{
			base.CharBackpack[j] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.SuitChar = new AAAAAAAAAAAAAAAAAAAbc();
		base.WeaponChar = new Winchester1300();
		base.CharBackpack[0] = new AAAAAAAAAAAAAAAAAAbs();
		base.ArtChar = new AAAAAAAAAAAAAAAAAAbi();
		base.DetectorChar = new AAAAAAAAAAAAAAAAAAbi();
		base.TypeChInt = 10;
		base.AudioDeath = (AudioClip)Resources.Load("Sound/human/zombie_take_damage_3");
		base.AudioStep_L = NameCharacter.StepZomby[Random.Range(0, NameCharacter.StepZomby.Length - 1)];
		base.AudioStep_R = (AudioClip)Resources.Load("Sound/human/new_gravel2");
		base.AudioPain_L = (AudioClip)Resources.Load("Sound/monsters/zombie_take_damage_3");
		base.AudioPain_R = NameCharacter.StepZomby[Random.Range(0, NameCharacter.StepZomby.Length - 1)];
		base.NPSattackVoice = new List<AudioClip>();
	}
}
