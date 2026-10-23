using UnityEngine;

public class AAAAAAAAAAAAAAAAAAt : AAAAAAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAAAt()
	{
		base.NameSubject = "Броня долга";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Suit/ps3-d9");
		base.IconCharacter = (Texture2D)Resources.Load("Sprites/IconChar/iconCharPC3-9d2");
		base.IconCharacterDead = (Texture2D)Resources.Load("Sprites/IconChar/iconCharDead128");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/generic_draw");
		base.CostSubject = 18000;
		base.DescriptionSubject = "Ранняя модель комбинезона «Долга» - бронежилет спецназа серии ПС3-9, приспособленный для использования в условиях Зоны. Способен защитить от автоматной пули, но очень громоздкий и почти не обеспечивает защиту от аномальных воздействий.";
		base.WeightSubject = 6.3f;
		base.Protection = 60f;
		base.XRayProtection = 0;
		base.ProtectionFromEject = 0;
		base.TypeSubj = TypeSubject.Suit;
		base.ArtContainer = 0;
	}
}
