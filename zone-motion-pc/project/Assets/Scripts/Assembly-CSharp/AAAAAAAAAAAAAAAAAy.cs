using UnityEngine;

public class AAAAAAAAAAAAAAAAAy : AAAAAAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAAy()
	{
		base.NameSubject = "СПП99м";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Suit/EcologGreen");
		base.IconCharacter = (Texture2D)Resources.Load("Sprites/IconChar/iconEcologGreen256");
		base.IconCharacterDead = (Texture2D)Resources.Load("Sprites/IconChar/iconCharDead128");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/generic_draw");
		base.CostSubject = 8000;
		base.DescriptionSubject = "Высококачественный модифицированный комбинезон ССП-99. Добавлена защита торса от пулевого и осколочного повреждения. Предназначен для экипировки охраны научных экспедиций! Эффективная защита от радиации и биологических аномалий. Стойкий к химически-агрессивным средам и другим вредным для организма воздействиям.";
		base.WeightSubject = 4.2f;
		base.Protection = 42f;
		base.XRayProtection = 25;
		base.ProtectionFromEject = 10;
		base.Force = 3f;
		base.TypeSubj = TypeSubject.Suit;
		base.ArtContainer = 2;
		base.PsiProtection = 1;
	}
}
