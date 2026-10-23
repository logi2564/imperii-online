using UnityEngine;

public class AAAAAAAAAAAAAAAAt : AAAAAAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAt()
	{
		base.NameSubject = "Ветер свободы";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Suit/Veter");
		base.IconCharacter = (Texture2D)Resources.Load("Sprites/IconChar/iconCharWindFreedom128");
		base.IconCharacterDead = (Texture2D)Resources.Load("Sprites/IconChar/iconCharDead128");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/generic_draw");
		base.CostSubject = 10500;
		base.DescriptionSubject = "Модернизированный ремесленниками группировки ''Свобода'', облегчённый комбинезон сталкера. Лёгкий армейский бронежилет плюс накладные усиливающие кевларовые пластины. Способен защитить от слабого оружия. Ткань комбинезона обработана специальным составом, повышающим сопротивление аномальной активности.";
		base.WeightSubject = 3.5f;
		base.Protection = 40f;
		base.XRayProtection = 1;
		base.ProtectionFromEject = 2;
		base.TypeSubj = TypeSubject.Suit;
		base.ArtContainer = 1;
	}
}
