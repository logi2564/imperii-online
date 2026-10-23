using UnityEngine;

public class AAAAAAAAAAAAAAAAAAAAz : AAAAAAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAAAAAz()
	{
		base.NameSubject = "Аномальная куртка";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Suit/LeatherJacket");
		base.IconCharacter = (Texture2D)Resources.Load("Sprites/IconChar/iconCharJacket256");
		base.IconCharacterDead = (Texture2D)Resources.Load("Sprites/IconChar/iconCharDead128");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/generic_draw");
		base.CostSubject = 2000;
		base.DescriptionSubject = "Кожаная куртка, длительное время, пролежавшая в аномалии. Поговаривали, что она была снята с погибшего в аномалии сталкера. Обрела свойство ускорять метаболизм, тем самым помогает быстрее затягивать раны. Установлен контейнер для артефактов. Уникальный экземпляр.";
		base.WeightSubject = 1.6f;
		base.Protection = 10f;
		base.ProtectionFromEject = 1;
		base.TypeSubj = TypeSubject.Suit;
		base.PsiProtection = 1;
		base.ArtContainer = 1;
		base.Sanitation = 1f;
		base.SingModification = true;
	}
}
