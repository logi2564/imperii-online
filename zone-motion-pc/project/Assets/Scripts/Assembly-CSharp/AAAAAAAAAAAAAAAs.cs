using UnityEngine;

public class AAAAAAAAAAAAAAAs : AAAAAAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAs()
	{
		base.NameSubject = "Бронежилет 6Б5";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Suit/SuitArmy");
		base.IconCharacter = (Texture2D)Resources.Load("Sprites/IconChar/iconCharArmy128");
		base.IconCharacterDead = (Texture2D)Resources.Load("Sprites/IconChar/iconCharDead128");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/generic_draw");
		base.CostSubject = 4300;
		base.DescriptionSubject = " Армейский бронежилет. Был на вооруженнии в Советском Союзе с 1986 года. Защита от аномальной активности отсутствует. ";
		base.WeightSubject = 6.5f;
		base.Protection = 40f;
		base.ProtectionFromEject = 1;
		base.TypeSubj = TypeSubject.Suit;
	}
}
