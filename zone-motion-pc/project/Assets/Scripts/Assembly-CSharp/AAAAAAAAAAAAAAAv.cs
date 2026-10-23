using UnityEngine;

public class AAAAAAAAAAAAAAAv : AAAAAAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAv()
	{
		base.NameSubject = "Бронежилет ЧН-3а";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Suit/ChN3");
		base.IconCharacter = (Texture2D)Resources.Load("Sprites/IconChar/iconCharChN_3_128");
		base.IconCharacterDead = (Texture2D)Resources.Load("Sprites/IconChar/iconCharDead128");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/generic_draw");
		base.CostSubject = 30000;
		base.DescriptionSubject = "Штатная экипировка штурмовых отрядов «Чистого неба». Бронежилет способен остановить пистолетную пулю, а встроеный противогаз и брезентовый комбинезон с особой пропиткой обеспечивает хорошую защиту от аномальных воздействий.";
		base.WeightSubject = 5.8f;
		base.Protection = 54f;
		base.XRayProtection = 2;
		base.ProtectionFromEject = 2;
		base.TypeSubj = TypeSubject.Suit;
		base.ArtContainer = 2;
	}
}
