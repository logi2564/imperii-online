using UnityEngine;

public class AAAAAAAAAAAAAAAAAAAAbk : AAAAAAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAAAAAbk()
	{
		base.NameSubject = "Шкура слепого пса";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/IconChar/DogSkin128");
		base.IconCharacter = (Texture2D)Resources.Load("Sprites/IconChar/DogSkin128");
		base.IconCharacterDead = (Texture2D)Resources.Load("Sprites/IconChar/Mutant128Dead");
		base.CostSubject = 1000;
		base.WeightSubject = 10f;
		base.Protection = 25f;
		base.XRayProtection = 2;
		base.ProtectionFromEject = 10;
		base.TypeSubj = TypeSubject.Suit;
	}
}
