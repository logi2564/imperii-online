using System.Collections.Generic;
using UnityEngine;

public class AAAAAAAAAAAAAAAAAAbb : AAAAAAAAAAAAAAAAf
{
	public AAAAAAAAAAAAAAAAAAbb()
	{
		base.ControlGamer = false;
		base.NameCharac = "Контролер";
		base.CurGexChar = Gexa.GexLib[150];
		base.TaskGexChar = Gexa.GexLib[150];
		base.CharUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/CharacterIcon"));
		base.CharUnits.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/IconGroup/Controler64");
		base.CharUnits.transform.position = base.CurGexChar.GexGO.transform.position;
		base.CharUnits.name = base.NameCharac + ", " + NameCharacter.NameMutantLib[Random.Range(0, NameCharacter.NameMutantLib.Length - 1)];
		base.NameU = base.CharUnits.name;
		base.TypeChar = TypeCharacter.Контролер;
		base.TextureChar = (Texture2D)Resources.Load("Sprites/IconGroup/Controler64");
		base.Skill = 0;
		for (int i = 0; i < base.ArtContainers.Length; i++)
		{
			base.ArtContainers[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		for (int j = 0; j < base.CharBackpack.Length; j++)
		{
			base.CharBackpack[j] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.SuitChar = new AAAAAAAAAAAAAAAx();
		base.WeaponChar = new ControlerArm();
		base.ArtChar = new AAAAAAAAAAAAAAAAAAbi();
		base.DetectorChar = new AAAAAAAAAAAAAAAAAAbi();
		base.TypeChInt = 10;
		base.Cash = 0;
		base.AudioDeath = (AudioClip)Resources.Load("Sound/monsters/controller_die_0");
		base.AudioStep_L = (AudioClip)Resources.Load("Sound/monsters/controller_presence_1_l");
		base.AudioStep_R = (AudioClip)Resources.Load("Sound/monsters/controller_tube_prepare");
		base.AudioPain_L = NameCharacter.PainControler[Random.Range(0, NameCharacter.PainControler.Count - 1)];
		base.AudioPain_R = NameCharacter.PainControler[Random.Range(0, NameCharacter.PainControler.Count - 1)];
		base.NPSattackVoice = new List<AudioClip>();
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/monsters/controller_script_attack_0"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/monsters/controller_script_attack_1"));
	}
}
