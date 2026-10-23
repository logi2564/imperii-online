using UnityEngine;

public class AAAAAAAAAAAAAAAAAAAba : AAAAAAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAAAAba()
	{
		base.NameSubject = "Бронекостюм ''Булат''";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Suit/Bulat");
		base.IconCharacter = (Texture2D)Resources.Load("Sprites/IconChar/iconCharBulat");
		base.IconCharacterDead = (Texture2D)Resources.Load("Sprites/IconChar/iconCharDead128");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/generic_draw");
		base.CostSubject = 25000;
		base.DescriptionSubject = "Современный армейский бронекостюм для проведения штурмовых операций в зонах аномальной активности. Компоненты: тяжёлый бронежилет серии ПСЗ-12п, комбинезон аномальной защиты и компенсационный костюм. Предоставляет великолепную защиту от пуль и осколков и при этом удобен, почти не ограничивает подвижность носителя.";
		base.WeightSubject = 6.2f;
		base.Protection = 63f;
		base.XRayProtection = 1;
		base.ProtectionFromEject = 1;
		base.TypeSubj = TypeSubject.Suit;
		base.ArtContainer = 0;
	}
}
