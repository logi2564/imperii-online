using System.Collections.Generic;
using UnityEngine;

public class AAAAAAAAAAAAAAAAAAAAAAs : AAAAAAAAAAAAAAAAf
{
	public AAAAAAAAAAAAAAAAAAAAAAs()
	{
		base.ControlGamer = true;
		base.CurGexChar = Gexa.GexLib[203];
		base.TaskGexChar = base.CurGexChar;
		base.CharUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/CharacterIcon"));
		base.CharUnits.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/IconGroup/GasMask64A");
		base.CharUnits.transform.position = base.CurGexChar.GexGO.transform.position;
		base.NameCharac = "Странник";
		base.CharUnits.name = "Странник";
		base.NameU = base.CharUnits.name;
		base.TypeChar = TypeCharacter.Странник;
		base.TextureChar = (Texture2D)Resources.Load("Sprites/IconGroup/GasMask64A");
		base.Skill = 0;
		base.SuitChar = new AAAAAAAAAAAAAAAAAAAAbf();
		base.WeaponChar = new PM();
		base.ArtChar = new AAAAAAAAAAAAAAAAAAbi();
		base.DetectorChar = new AAAAAAAAAAAAAAAAAAbi();
		base.TypeChInt = 0;
		for (int i = 0; i < base.ArtContainers.Length; i++)
		{
			base.ArtContainers[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		for (int j = 0; j < base.CharBackpack.Length; j++)
		{
			base.CharBackpack[j] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.CharBackpack[0] = new AAAAAAAAAAAAAAAAAbb();
		base.AudioDeath = (AudioClip)Resources.Load("Sound/human/die2");
		base.AudioStep_L = (AudioClip)Resources.Load("Sound/human/new_gravel1");
		base.AudioStep_R = (AudioClip)Resources.Load("Sound/human/new_gravel2");
		base.AudioPain_L = NameCharacter.PainHuman[Random.Range(0, NameCharacter.PainHuman.Length - 1)];
		base.AudioPain_R = NameCharacter.PainHuman[Random.Range(0, NameCharacter.PainHuman.Length - 1)];
		base.NPSattackVoice = new List<AudioClip>();
	}
}
