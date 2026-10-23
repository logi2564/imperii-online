using UnityEngine;

public class AAAAAAAAAAAAAAAAAAAAbi : AAAAAAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAAAAAbi()
	{
		base.NameSubject = "Шкура кабана";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/IconChar/HogSkin");
		base.IconCharacter = (Texture2D)Resources.Load("Sprites/IconChar/HogSkin");
		base.IconCharacterDead = (Texture2D)Resources.Load("Sprites/IconChar/Mutant128Dead");
		base.CostSubject = 1000;
		base.WeightSubject = 15f;
		base.Protection = 32f;
		base.XRayProtection = 2;
		base.ProtectionFromEject = 8;
		base.TypeSubj = TypeSubject.Suit;
	}
}
