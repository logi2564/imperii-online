using UnityEngine;

public class AAAAAAAAAAAAAAAAAAAAAbj : AAAAAAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAAAAAAbj()
	{
		base.NameSubject = "Бронекостюм ''Берилл''";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Suit/Berill");
		base.IconCharacter = (Texture2D)Resources.Load("Sprites/IconChar/iconCharBerill128");
		base.IconCharacterDead = (Texture2D)Resources.Load("Sprites/IconChar/iconCharDead128");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/generic_draw");
		base.CostSubject = 12000;
		base.DescriptionSubject = "Экипировка армейского спецназа, модифицированная для работы в условиях Зоны. В составе: армейский бронежилет с бериллиевым напылением, шлем. Предназначен для штуровых операций в областях с повышенным радиационным фоном. Слабоэффективен в условиях высокой аномальной активности.";
		base.WeightSubject = 7f;
		base.Protection = 63f;
		base.ProtectionFromEject = 1;
		base.XRayProtection = 1;
		base.TypeSubj = TypeSubject.Suit;
	}
}
