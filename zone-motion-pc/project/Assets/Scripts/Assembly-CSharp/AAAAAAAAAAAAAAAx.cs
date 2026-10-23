using UnityEngine;

public class AAAAAAAAAAAAAAAx : AAAAAAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAx()
	{
		base.NameSubject = "Защита контролера";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/IconChar/Controler128");
		base.IconCharacter = (Texture2D)Resources.Load("Sprites/IconChar/Controler128");
		base.IconCharacterDead = (Texture2D)Resources.Load("Sprites/IconChar/Mutant128Dead");
		base.AudioSlot = (AudioClip)Resources.Load("Sprites/Sound/Suit/inv_ruck");
		base.CostSubject = 1000;
		base.WeightSubject = 7f;
		base.Protection = 80f;
		base.XRayProtection = 10;
		base.ProtectionFromEject = 30;
		base.TypeSubj = TypeSubject.Suit;
	}
}
