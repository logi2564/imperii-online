using UnityEngine;

public class AAAAAAAAAAAAAAAAAw : AAAAAAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAAw()
	{
		base.NameSubject = "Комбинезон наемника";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Suit/SuitMercenar");
		base.IconCharacter = (Texture2D)Resources.Load("Sprites/IconChar/iconCharMersenary128");
		base.IconCharacterDead = (Texture2D)Resources.Load("Sprites/IconChar/iconCharDead128");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/generic_draw");
		base.CostSubject = 6800;
		base.DescriptionSubject = "Комбинезон сталкера из группировки ''Наёмники''. За основу взяты образцы экипировки спецназа западных армий. За счёт специальной обработки ткани усилена устойчивость брони при физическом смещении пластин. По защитным характеристикам немного превосходит армейские бронежилеты в своем классе.";
		base.WeightSubject = 3.7f;
		base.Protection = 35f;
		base.ProtectionFromEject = 2;
		base.XRayProtection = 1;
		base.TypeSubj = TypeSubject.Suit;
	}
}
