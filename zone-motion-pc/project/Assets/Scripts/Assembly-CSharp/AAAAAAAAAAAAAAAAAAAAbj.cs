using UnityEngine;

public class AAAAAAAAAAAAAAAAAAAAbj : AAAAAAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAAAAAbj()
	{
		base.NameSubject = "Шкура псевдособаки";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/IconChar/PseudoDogSkin");
		base.IconCharacter = (Texture2D)Resources.Load("Sprites/IconChar/PseudoDogSkin");
		base.IconCharacterDead = (Texture2D)Resources.Load("Sprites/IconChar/Mutant128Dead");
		base.AudioSlot = (AudioClip)Resources.Load("Sprites/Sound/Suit/inv_ruck");
		base.CostSubject = 1000;
		base.WeightSubject = 7f;
		base.Protection = 34f;
		base.XRayProtection = 2;
		base.ProtectionFromEject = 10;
		base.TypeSubj = TypeSubject.Suit;
	}
}
