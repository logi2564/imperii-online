using UnityEngine;

public class AAAAAAAAAAAAAAAAAAAbb : AAAAAAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAAAAbb()
	{
		base.NameSubject = "Комбинезон Сева";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Suit/Seva");
		base.IconCharacter = (Texture2D)Resources.Load("Sprites/IconChar/iconCharSeva128");
		base.IconCharacterDead = (Texture2D)Resources.Load("Sprites/IconChar/iconCharDead128");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/generic_draw");
		base.CostSubject = 32000;
		base.DescriptionSubject = "Производится за пределами зоны и специально для условий зоны. Сочетает отличную броню и замкнутую систему дыхания. Хороший выбор для глубокого похода в зону.";
		base.WeightSubject = 7f;
		base.Protection = 58f;
		base.ProtectionFromEject = 10;
		base.XRayProtection = 5;
		base.TypeSubj = TypeSubject.Suit;
		base.ArtContainer = 2;
		base.PsiProtection = 1;
	}
}
