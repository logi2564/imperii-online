using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AAAAAAAAAAAAAAAAAAAz : AAAAAAAAAAAAAAAAf
{
	public AAAAAAAAAAAAAAAAAAAz()
	{
		base.ControlGamer = false;
		base.NameCharac = "Бандиты";
		base.CurGexChar = Gexa.GexLib[272];
		base.TaskGexChar = Gexa.GexLib[272];
		base.CharUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/CharacterIcon"));
		base.CharUnits.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/IconGroup/Bandit64C");
		base.CharUnits.transform.position = base.CurGexChar.GexGO.transform.position;
		base.CharUnits.name = NameCharacter.NameCharLib[Random.Range(0, NameCharacter.NameCharLib.Length - 1)] + " " + NameCharacter.NickCharLib[Random.Range(0, NameCharacter.NickCharLib.Length - 1)] + ", Бандит";
		base.NameU = base.CharUnits.name;
		base.TypeChar = TypeCharacter.Бандиты;
		base.TextureChar = (Texture2D)Resources.Load("Sprites/IconGroup/Bandit64C");
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
		if (SceneManager.GetActiveScene().name == "Dump")
		{
			base.Skill = 0;
			base.WeaponChar = new TOZ34();
		}
		if (SceneManager.GetActiveScene().name != "Kordon" && SceneManager.GetActiveScene().name == "Dump")
		{
			base.Skill = 2;
			base.SuitChar = new AAAAAAAAAAAAAAAAAAbj();
			base.WeaponChar = new Winchester1300();
		}
		if (SceneManager.GetActiveScene().name == "DarkValley")
		{
			base.Skill = 4;
			base.SuitChar = new AAAAAAAAAAAAAAAAAAbj();
			base.WeaponChar = new MP5();
		}
		base.CharBackpack[0] = new AAAAAAAAAAAAAAAAAAbs();
		base.ArtChar = new AAAAAAAAAAAAAAAAAAbi();
		base.DetectorChar = new AAAAAAAAAAAAAAAAAAbi();
		base.TypeChInt = 2;
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
