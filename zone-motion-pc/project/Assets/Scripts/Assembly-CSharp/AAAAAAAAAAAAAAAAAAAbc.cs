using UnityEngine;

public class AAAAAAAAAAAAAAAAAAAbc : AAAAAAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAAAAbc()
	{
		base.NameSubject = "Тряпье зомби";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Suit/zomby_s");
		base.IconCharacter = (Texture2D)Resources.Load("Sprites/IconChar/iconZombySuit128");
		base.IconCharacterDead = (Texture2D)Resources.Load("Sprites/IconChar/iconCharDead128");
		base.CostSubject = 0;
		base.DescriptionSubject = "Лохмотья, бывшие когда-то одеждой.";
		base.WeightSubject = 8f;
		base.Protection = 20f;
		base.ProtectionFromEject = 10;
		base.XRayProtection = 10;
		base.TypeSubj = TypeSubject.Suit;
	}
}
