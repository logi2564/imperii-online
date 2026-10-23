using UnityEngine;

public class AAAAAAAAAAAAAAAAAAu : AAAAAAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAAAu()
	{
		base.NameSubject = "Экзоскелет Долга";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Suit/Exo_dolg");
		base.IconCharacter = (Texture2D)Resources.Load("Sprites/IconChar/iconCharExo256Duty");
		base.IconCharacterDead = (Texture2D)Resources.Load("Sprites/IconChar/iconCharDead128");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/generic_draw");
		base.CostSubject = 58000;
		base.DescriptionSubject = "Экспериментальный образец военного экзоскелета. Пользуется популярностью у ветеранов Долга. В серийное производство так и не попал, ввиду чрезвычайной дороговизны и некоторых ошибок в проектировании. Несмотря на это, выпускается малыми партиями на подпольных предприятиях за пределами Украины. Данный экзоскелет относится к третьему поколению. В нём устранены конструктивные недостатки, кардинально снижавшие подвижность, а также усилена броня. Предоставляет великолепную защиту от пулевого и осколочного попадания, но не гарантирует стойкости к аномалиям.";
		base.WeightSubject = 12f;
		base.Protection = 76f;
		base.XRayProtection = 2;
		base.ProtectionFromEject = 2;
		base.Force = 16f;
		base.TypeSubj = TypeSubject.Suit;
		base.ArtContainer = 1;
	}
}
