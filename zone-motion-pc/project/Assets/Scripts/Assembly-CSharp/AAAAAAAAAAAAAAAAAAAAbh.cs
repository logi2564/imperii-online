using UnityEngine;

public class AAAAAAAAAAAAAAAAAAAAbh : AAAAAAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAAAAAbh()
	{
		base.NameSubject = "Экзоскелет";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Suit/Exo");
		base.IconCharacter = (Texture2D)Resources.Load("Sprites/IconChar/iconCharExo128");
		base.IconCharacterDead = (Texture2D)Resources.Load("Sprites/IconChar/iconCharDead128");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/generic_draw");
		base.CostSubject = 54000;
		base.DescriptionSubject = "Эксперементальный образец военного экзоскелета. Пользуется популярностью у ветеранов зоны. Великолепная защита от пулевого и осколочного попадания. В серийное производство так и не попал, в виду чрезвычайной дороговизны и некоторых ошибок в проектировании. Не смотря на это, выпускается малыми партиями на подпольных предприятиях разных стран.";
		base.WeightSubject = 12f;
		base.Protection = 75f;
		base.XRayProtection = 2;
		base.ProtectionFromEject = 4;
		base.Force = 16f;
		base.TypeSubj = TypeSubject.Suit;
		base.ArtContainer = 1;
	}
}
