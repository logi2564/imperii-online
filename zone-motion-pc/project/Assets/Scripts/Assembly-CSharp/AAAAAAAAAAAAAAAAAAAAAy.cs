using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AAAAAAAAAAAAAAAAAAAAAy : AAAAAAAAAAAAAAAAf
{
	public AAAAAAAAAAAAAAAAAAAAAy()
	{
		base.ControlGamer = false;
		base.NameCharac = "Ренегаты";
		base.CurGexChar = Gexa.GexLib[250];
		base.TaskGexChar = Gexa.GexLib[250];
		base.CharUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/CharacterIcon"));
		base.CharUnits.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/IconGroup/Renegade64");
		base.CharUnits.transform.position = base.CurGexChar.GexGO.transform.position;
		base.CharUnits.name = NameCharacter.NameCharLib[Random.Range(0, NameCharacter.NameCharLib.Length - 1)] + " " + NameCharacter.NickCharLib[Random.Range(0, NameCharacter.NickCharLib.Length - 1)] + ", Ренегат";
		base.NameU = base.CharUnits.name;
		base.TypeChar = TypeCharacter.Ренегаты;
		base.TextureChar = (Texture2D)Resources.Load("Sprites/IconGroup/Renegade64");
		base.Skill = 0;
		base.SuitChar = new AAAAAAAAAAAAAAAAAAAAAbf();
		base.WeaponChar = new Obres();
		for (int i = 0; i < base.ArtContainers.Length; i++)
		{
			base.ArtContainers[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		for (int j = 0; j < base.CharBackpack.Length; j++)
		{
			base.CharBackpack[j] = new AAAAAAAAAAAAAAAAAAbi();
		}
		if (SceneManager.GetActiveScene().name != "Marsh")
		{
			base.Skill = 2;
			base.SuitChar = new AAAAAAAAAAAAAAAAAAbj();
			base.WeaponChar = new Winchester1300();
		}
		base.CharBackpack[0] = new AAAAAAAAAAAAAAAAAAbs();
		base.ArtChar = new AAAAAAAAAAAAAAAAAAbi();
		base.DetectorChar = new AAAAAAAAAAAAAAAAAAbi();
		base.TypeChInt = 12;
		base.AudioDeath = (AudioClip)Resources.Load("Sound/human/deathBandit");
		base.AudioStep_L = (AudioClip)Resources.Load("Sound/human/new_gravel1");
		base.AudioStep_R = (AudioClip)Resources.Load("Sound/human/new_gravel2");
		base.AudioPain_L = NameCharacter.PainHuman[Random.Range(0, NameCharacter.PainHuman.Length - 1)];
		base.AudioPain_R = NameCharacter.PainHuman[Random.Range(0, NameCharacter.PainHuman.Length - 1)];
		base.NPSattackVoice = new List<AudioClip>();
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/bandit/attack/attack_1"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/bandit/attack/attack_2"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/bandit/attack/attack_3"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/bandit/attack/attack_4"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/bandit/attack/attack_5"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/bandit/attack/attack_6"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/bandit/attack/attack_7"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/bandit/attack/attack_8"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/bandit/attack/attack_9"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/bandit/detour/detour_1"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/bandit/detour/detour_2"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/bandit/detour/detour_3"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/bandit/detour/detour_4"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/bandit/detour/detour_5"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/bandit/detour/detour_6"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/bandit/detour/detour_7"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/bandit/detour/detour_8"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/bandit/detour/detour_9"));
		base.NPSattackVoice.Add((AudioClip)Resources.Load("Sound/humanAttack/bandit/detour/detour_10"));
	}
}
