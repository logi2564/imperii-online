using UnityEngine;

public class AAAAAAAAAAAAAAAt : AAAAAAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAt()
	{
		base.NameSubject = "Бронежилет ЧН-1";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Suit/ChN1");
		base.IconCharacter = (Texture2D)Resources.Load("Sprites/IconChar/iconCharChN_1_128");
		base.IconCharacterDead = (Texture2D)Resources.Load("Sprites/IconChar/iconCharDead128");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/generic_draw");
		base.CostSubject = 8500;
		base.DescriptionSubject = "Экипировка бойцов ''Чистого Неба''. Данный бронежилет разрабатывался для проведения поисковых операций в областях с низкой аномальной активностью. Использование довольно качественных материалов повысило устойчивость к износу. Снабжён контейнером для артефактов.";
		base.WeightSubject = 4f;
		base.Protection = 36f;
		base.XRayProtection = 1;
		base.ProtectionFromEject = 2;
		base.TypeSubj = TypeSubject.Suit;
		base.ArtContainer = 1;
	}
}
