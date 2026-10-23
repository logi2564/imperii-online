using UnityEngine;

public class AAAAAAAAAAAAAAAAAAbj : AAAAAAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAAAbj()
	{
		base.NameSubject = "Кожанный плащ";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Suit/Cloak");
		base.IconCharacter = (Texture2D)Resources.Load("Sprites/IconChar/iconCharCloak128");
		base.IconCharacterDead = (Texture2D)Resources.Load("Sprites/IconChar/iconCharDead128");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/generic_draw");
		base.CostSubject = 2000;
		base.DescriptionSubject = "Обычный плащ из чёрной кожи. Особенной защиты носителю не обеспечивает, разве что не даст замёрзнуть ночью и смягчит укус слепой собаки. Достаточно неудобен, но, тем не менее, часто используется бандитами - возможно, исключительно из-за внешнего вида.";
		base.WeightSubject = 3f;
		base.Protection = 20f;
		base.ProtectionFromEject = 2;
		base.TypeSubj = TypeSubject.Suit;
	}
}
