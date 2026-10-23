using UnityEngine;

public class AAAAAAAAAAAAAAAAAAv : AAAAAAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAAAv()
	{
		base.NameSubject = "Экзоскелет Свободы";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Suit/Exo_freedom");
		base.IconCharacter = (Texture2D)Resources.Load("Sprites/IconChar/iconCharExo256Freedom");
		base.IconCharacterDead = (Texture2D)Resources.Load("Sprites/IconChar/iconCharDead128");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/generic_draw");
		base.CostSubject = 52000;
		base.DescriptionSubject = "Модернизация обычного экзоскелета. Применение более лёгких материалов позволило снизить массу самого костюма, а также повысить его износоустойчивость.";
		base.WeightSubject = 11f;
		base.Protection = 74f;
		base.XRayProtection = 2;
		base.ProtectionFromEject = 2;
		base.Force = 16f;
		base.TypeSubj = TypeSubject.Suit;
		base.ArtContainer = 1;
	}
}
