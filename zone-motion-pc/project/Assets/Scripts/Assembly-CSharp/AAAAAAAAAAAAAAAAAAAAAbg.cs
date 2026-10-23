using UnityEngine;

public class AAAAAAAAAAAAAAAAAAAAAbg : AAAAAAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAAAAAAbg()
	{
		base.NameSubject = "Комбинезон ''Закат''";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Suit/sunset");
		base.IconCharacter = (Texture2D)Resources.Load("Sprites/IconChar/sunset96var");
		base.IconCharacterDead = (Texture2D)Resources.Load("Sprites/IconChar/iconCharDead128");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/generic_draw");
		base.CostSubject = 17000;
		base.DescriptionSubject = "Переделанная версия копии сталкерского комбинезона - ''Заря'' умелыми техниками из группировки ''Наёмники''. Такие в основном надевают новички группировки. Характеристики немного лучше, чем у ''донора''. Пользуется популярностью у некоторых ренегатов";
		base.WeightSubject = 5.2f;
		base.Protection = 52f;
		base.ProtectionFromEject = 2;
		base.XRayProtection = 1;
		base.TypeSubj = TypeSubject.Suit;
		base.ArtContainer = 1;
	}
}
