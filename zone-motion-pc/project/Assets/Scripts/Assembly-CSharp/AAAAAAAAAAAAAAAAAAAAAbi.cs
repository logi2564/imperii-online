using UnityEngine;

public class AAAAAAAAAAAAAAAAAAAAAbi : AAAAAAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAAAAAAbi()
	{
		base.NameSubject = "Комбинезон монолитовца";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Suit/SuitMonolith");
		base.IconCharacter = (Texture2D)Resources.Load("Sprites/IconChar/iconCharMonolit128");
		base.IconCharacterDead = (Texture2D)Resources.Load("Sprites/IconChar/iconCharDead128");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/generic_draw");
		base.CostSubject = 12000;
		base.DescriptionSubject = " Комбинезон бойцов группировки ''Монолит''. Производитель неизвестен. По защитным характеристикам немного уступает армейскому бронежилету аналогичного класса. По структуре напоминает широко распространенные среди нейтральных сталкеров комбинезоны, в которых бронежилет соединяется с костюмом противорадиационной защиты. Неплохо защищает от слабого стрелкового оружия.";
		base.WeightSubject = 5f;
		base.Protection = 56f;
		base.XRayProtection = 3;
		base.ProtectionFromEject = 6;
		base.TypeSubj = TypeSubject.Suit;
		base.ArtContainer = 1;
	}
}
