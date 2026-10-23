using UnityEngine;

public class AAAAAAAAAAAAAAAAAAAAAbf : AAAAAAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAAAAAAbf()
	{
		base.NameSubject = "Бандитская куртка";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Suit/BanditJacket");
		base.IconCharacter = (Texture2D)Resources.Load("Sprites/IconChar/iconCharBanditJacket128");
		base.IconCharacterDead = (Texture2D)Resources.Load("Sprites/IconChar/iconCharDead128");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/generic_draw");
		base.CostSubject = 1500;
		base.DescriptionSubject = "Традиционная одежда бандита и ренегата. Кожаная куртка со вшитыми броневыми элементами. Обеспечивает некоторую защиту владельца от вредных воздействий - впрочем, крайне недостаточную в суровых условиях Зоны. Контейнер для артефактов доступен после модернизации.";
		base.WeightSubject = 2.3f;
		base.Protection = 15f;
		base.ProtectionFromEject = 1;
		base.TypeSubj = TypeSubject.Suit;
	}
}
