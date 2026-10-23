using UnityEngine;

public class AAAAAAAAAAAAAAAAAAAAAbk : AAAAAAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAAAAAAbk()
	{
		base.NameSubject = "ПСЗ-9Мд «Универсальная защита»";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Suit/SevaDuty");
		base.IconCharacter = (Texture2D)Resources.Load("Sprites/IconChar/iconCharSevaDuty");
		base.IconCharacterDead = (Texture2D)Resources.Load("Sprites/IconChar/iconCharDead128");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/generic_draw");
		base.CostSubject = 32000;
		base.DescriptionSubject = "Модифицированный комбинезон ''Сева'' для группировки Долг. Отличный защитный костюм для Зоны. Сталкеры ценят его за сочетание отличных противоаномальных качеств и противопулевой защиты.  Представляет качественную защиту от пулевого и осколочного попадания. Представляет из себя отличное сочетание бронировонного комбинезона, системы дыхания с замкнутым циклом, а также встроенной системой подавления действия аномальных полей.";
		base.WeightSubject = 7.5f;
		base.Protection = 64f;
		base.ProtectionFromEject = 10;
		base.XRayProtection = 4;
		base.TypeSubj = TypeSubject.Suit;
		base.ArtContainer = 2;
		base.PsiProtection = 1;
	}
}
