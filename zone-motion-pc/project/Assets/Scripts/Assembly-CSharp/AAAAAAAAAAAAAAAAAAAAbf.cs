using UnityEngine;

public class AAAAAAAAAAAAAAAAAAAAbf : AAAAAAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAAAAAbf()
	{
		base.NameSubject = "Кожаная куртка";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Suit/LeatherJacket");
		base.IconCharacter = (Texture2D)Resources.Load("Sprites/IconChar/iconCharJacket256");
		base.IconCharacterDead = (Texture2D)Resources.Load("Sprites/IconChar/iconCharDead128");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/generic_draw");
		base.CostSubject = 900;
		base.DescriptionSubject = "Обычная одежда начинающего сталкера. Практически не спасает носителя ни от пуль, ни от аномалий, ни от остальных напастей зоны, но удобна в ношении. Контейнер для артефактов доступен после модернизации.";
		base.WeightSubject = 1.8f;
		base.Protection = 10f;
		base.ProtectionFromEject = 1;
		base.TypeSubj = TypeSubject.Suit;
	}
}
