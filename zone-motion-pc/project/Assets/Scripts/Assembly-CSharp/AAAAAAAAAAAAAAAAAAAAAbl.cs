using UnityEngine;

public class AAAAAAAAAAAAAAAAAAAAAbl : AAAAAAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAAAAAAbl()
	{
		base.NameSubject = "Тряпье снорка";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Suit/zomby_s");
		base.IconCharacter = (Texture2D)Resources.Load("Sprites/IconChar/SnorkSkin");
		base.IconCharacterDead = (Texture2D)Resources.Load("Sprites/IconChar/iconCharDead128");
		base.CostSubject = 0;
		base.DescriptionSubject = "Лохмотья, бывшие когда-то одеждой.";
		base.WeightSubject = 6f;
		base.Protection = 22f;
		base.ProtectionFromEject = 15;
		base.XRayProtection = 2;
		base.TypeSubj = TypeSubject.Suit;
	}
}
