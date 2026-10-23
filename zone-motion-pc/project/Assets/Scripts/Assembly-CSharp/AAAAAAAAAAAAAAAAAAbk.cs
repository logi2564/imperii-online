using UnityEngine;

public class AAAAAAAAAAAAAAAAAAbk : AAAAAAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAAAbk()
	{
		base.NameSubject = "Бандитский комбинезон";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Suit/BanditVeteran");
		base.IconCharacter = (Texture2D)Resources.Load("Sprites/IconChar/iconCharBandinVeteran128");
		base.IconCharacterDead = (Texture2D)Resources.Load("Sprites/IconChar/iconCharDead128");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/generic_draw");
		base.CostSubject = 6500;
		base.DescriptionSubject = "От комбинезона наемников отличается лишь цветовым решением. Характеристики немного хуже и отсутствует противогаз. Среди сталкеров носит неофициальное название - Змей. Обычно его носят ветераны криминального мира.";
		base.WeightSubject = 3.6f;
		base.Protection = 30f;
		base.XRayProtection = 1;
		base.ProtectionFromEject = 2;
		base.TypeSubj = TypeSubject.Suit;
	}
}
