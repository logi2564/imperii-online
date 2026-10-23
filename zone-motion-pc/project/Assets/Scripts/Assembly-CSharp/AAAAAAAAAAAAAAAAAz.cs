using UnityEngine;

public class AAAAAAAAAAAAAAAAAz : AAAAAAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAAz()
	{
		base.NameSubject = "Шкура кровососа";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/IconChar/Bloodsucker128");
		base.IconCharacter = (Texture2D)Resources.Load("Sprites/IconChar/Bloodsucker128");
		base.IconCharacterDead = (Texture2D)Resources.Load("Sprites/IconChar/Mutant128Dead");
		base.AudioSlot = (AudioClip)Resources.Load("Sprites/Sound/Suit/inv_ruck");
		base.CostSubject = 1000;
		base.WeightSubject = 1f;
		base.Protection = 65f;
		base.XRayProtection = 10;
		base.ProtectionFromEject = 30;
		base.TypeSubj = TypeSubject.Suit;
	}
}
