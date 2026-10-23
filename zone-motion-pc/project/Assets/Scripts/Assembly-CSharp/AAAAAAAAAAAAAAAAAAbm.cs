using UnityEngine;

public class AAAAAAAAAAAAAAAAAAbm : AAAAAAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAAAbm()
	{
		base.NameSubject = "Эколог СПП99";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Suit/Ecolog");
		base.IconCharacter = (Texture2D)Resources.Load("Sprites/IconChar/iconEcolog128");
		base.IconCharacterDead = (Texture2D)Resources.Load("Sprites/IconChar/iconCharDead128");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/generic_draw");
		base.CostSubject = 4300;
		base.DescriptionSubject = "Созданный для работы в условиях Зоны костюм защиты ССП-99. Используется экспедициями учёных и сотрудничающих с ними сталкеров-экологов. Встроенная система фильтрации воздуха и кондиционирования. Не рассчитан на ведение боевых действий.";
		base.WeightSubject = 4.2f;
		base.Protection = 28f;
		base.XRayProtection = 25;
		base.ProtectionFromEject = 10;
		base.Force = 3f;
		base.TypeSubj = TypeSubject.Suit;
		base.ArtContainer = 2;
	}
}
