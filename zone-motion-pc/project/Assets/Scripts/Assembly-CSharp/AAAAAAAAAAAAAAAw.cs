using UnityEngine;

public class AAAAAAAAAAAAAAAw : AAAAAAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAw()
	{
		base.NameSubject = "Экзоскелет Наемников";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Suit/Exo_mercenary");
		base.IconCharacter = (Texture2D)Resources.Load("Sprites/IconChar/iconCharExo256Mercenary");
		base.IconCharacterDead = (Texture2D)Resources.Load("Sprites/IconChar/iconCharDead128");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/generic_draw");
		base.CostSubject = 58000;
		base.DescriptionSubject = "Экзоскелет боевиков из группировки «Наемники». За основу взят военный экзоскелет, отличается о него цветовым решением. Некоторые материалы заменены на облегченные аналоги. Экзоскелеты «Наемников» обычно носят ветераны.";
		base.WeightSubject = 10f;
		base.Protection = 73f;
		base.XRayProtection = 3;
		base.ProtectionFromEject = 3;
		base.Force = 16f;
		base.TypeSubj = TypeSubject.Suit;
		base.ArtContainer = 1;
	}
}
