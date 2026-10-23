using UnityEngine;

public class AAAAAAAAAAAAAAAAr : AAAAAAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAr()
	{
		base.NameSubject = "Свитер";
		base.IconCharacter = (Texture2D)Resources.Load("Sprites/IconChar/iconCharSweater");
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Suit/Sweater");
		base.IconCharacterDead = (Texture2D)Resources.Load("Sprites/IconChar/iconCharDead128");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/generic_draw");
		base.CostSubject = 0;
		base.DescriptionSubject = "Старый, изношенный свитер. Правда, еще неплохо греет, ...";
		base.WeightSubject = 0.3f;
		base.Protection = 0f;
		base.ProtectionFromEject = 1;
		base.TypeSubj = TypeSubject.Suit;
		base.Wear = 0f;
	}
}
