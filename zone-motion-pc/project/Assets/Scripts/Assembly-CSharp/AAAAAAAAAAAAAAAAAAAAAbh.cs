using UnityEngine;

public class AAAAAAAAAAAAAAAAAAAAAbh : AAAAAAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAAAAAAbh()
	{
		base.NameSubject = "Страж свободы";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Suit/GuardianOfFreedom");
		base.IconCharacter = (Texture2D)Resources.Load("Sprites/IconChar/iconCharGuardianOfFreedom128");
		base.IconCharacterDead = (Texture2D)Resources.Load("Sprites/IconChar/iconCharDead128");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/generic_draw");
		base.CostSubject = 13000;
		base.DescriptionSubject = "Производимый мастерами группировки ''Свобода'' усиленный комбинезон сталкера. Средний армейский бронежилет плюс накладные усиливающие циркониевые элементы дают неплохую защиту от автоматных пуль и осколков на различных дистанциях. Материал костюма состоит из двух слоёв: специально обработанной кожи и ткани с асбестовой нитью. Даёт некоторую защиту от различных аномальных воздействий и радиации.";
		base.WeightSubject = 5.2f;
		base.Protection = 53f;
		base.XRayProtection = 2;
		base.ProtectionFromEject = 4;
		base.TypeSubj = TypeSubject.Suit;
		base.ArtContainer = 1;
	}
}
