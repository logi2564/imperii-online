using UnityEngine;

public class AAAAAAAAAAAAAAAAAAbl : AAAAAAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAAAbl()
	{
		base.NameSubject = "Научный комбинезон «Свободы»";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Suit/SevaFreedom");
		base.IconCharacter = (Texture2D)Resources.Load("Sprites/IconChar/iconCharSevaFreedom");
		base.IconCharacterDead = (Texture2D)Resources.Load("Sprites/IconChar/iconCharDead128");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/generic_draw");
		base.CostSubject = 29000;
		base.DescriptionSubject = "Комбинезон серии ПСЗ-9М, родственник серии ''СЕВА'', отличающийся от последних материалами на порядок хуже для условий Зоны Отчуждения. Производится кустарным способом в поселке Мирный, зачастую на такие ставят бывшие в употреблении «Заслоны».";
		base.WeightSubject = 6.25f;
		base.Protection = 54f;
		base.ProtectionFromEject = 10;
		base.XRayProtection = 5;
		base.TypeSubj = TypeSubject.Suit;
		base.ArtContainer = 2;
		base.PsiProtection = 1;
	}
}
