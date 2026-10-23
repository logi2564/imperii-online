using System.Collections.Generic;
using UnityEngine;

public class AAAAAAAAAAAAAAAAAAAAAz : AAAAAAAAAAAAAAAAf
{
	public AAAAAAAAAAAAAAAAAAAAAz()
	{
		base.ControlGamer = false;
		base.NameCharac = string.Empty;
		base.TypeChar = TypeCharacter.None;
		base.Skill = 0;
		for (int i = 0; i < base.ArtContainers.Length; i++)
		{
			base.ArtContainers[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		for (int j = 0; j < base.CharBackpack.Length; j++)
		{
			base.CharBackpack[j] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.SuitChar = new AAAAAAAAAAAAAAAAAAs();
		base.WeaponChar = new NoneWeapon();
		base.ArtChar = new AAAAAAAAAAAAAAAAAAbi();
		base.DetectorChar = new AAAAAAAAAAAAAAAAAAbi();
		base.NPSattackVoice = new List<AudioClip>();
	}
}
