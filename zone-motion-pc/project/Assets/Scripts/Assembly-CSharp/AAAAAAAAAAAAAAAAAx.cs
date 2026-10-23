using UnityEngine;

public class AAAAAAAAAAAAAAAAAx : AAAAAAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAAx()
	{
		base.NameSubject = "Комбинезон Заря";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Suit/SuitStalker");
		base.IconCharacter = (Texture2D)Resources.Load("Sprites/IconChar/iconStalkerSuit128");
		base.IconCharacterDead = (Texture2D)Resources.Load("Sprites/IconChar/iconCharDead128");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/generic_draw");
		base.CostSubject = 15000;
		base.DescriptionSubject = "Производимый умельцами в зоне, комбинезон сталкера представляет собой эффективное сочетание лёгкого армейского бронежилета комбинезона из прорезиненой ткани. Усилен за счёт встроенных кевларовых пластин. Неплохо защищает от слабого стрелкового оружия. В целом крайне недостаточен для глубоких рейдов и серьёзных операций в узлах Зоны.";
		base.WeightSubject = 5f;
		base.Protection = 50f;
		base.XRayProtection = 2;
		base.ProtectionFromEject = 4;
		base.TypeSubj = TypeSubject.Suit;
		base.ArtContainer = 1;
	}
}
