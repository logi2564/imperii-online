using UnityEngine;

public class AAAAAAAAAAAAAAAu : AAAAAAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAu()
	{
		base.NameSubject = "Бронежилет ЧН-2";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Suit/ChN2");
		base.IconCharacter = (Texture2D)Resources.Load("Sprites/IconChar/iconCharChN_2_128");
		base.IconCharacterDead = (Texture2D)Resources.Load("Sprites/IconChar/iconCharDead128");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/generic_draw");
		base.CostSubject = 17000;
		base.DescriptionSubject = "Экипировка бойцов ''Чистого Неба''. Представляет собой модификачию ЧН-1, усиленную кевларовыми пластинами, и как следствие имеет больший вес.";
		base.WeightSubject = 5f;
		base.Protection = 44f;
		base.XRayProtection = 2;
		base.ProtectionFromEject = 2;
		base.TypeSubj = TypeSubject.Suit;
		base.ArtContainer = 1;
	}
}
