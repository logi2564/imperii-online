using UnityEngine;

public class AAAAAAAAAAAAAAAAs : AAAAAAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAs()
	{
		base.NameSubject = "Универсальная защита";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Suit/PS5");
		base.IconCharacter = (Texture2D)Resources.Load("Sprites/IconChar/iconCharPC596_128");
		base.IconCharacterDead = (Texture2D)Resources.Load("Sprites/IconChar/iconCharDead128");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/generic_draw");
		base.CostSubject = 13000;
		base.DescriptionSubject = "Современная, доработанная модель комбинезона «Долга». Больше подходит новобранцам из сталкеров, которые привыкли к относительно лёгким костюмам. В отличие от серии ПС3, обеспечивает хорошую защиту от аномального воздействия и при этом способен остановить пистолетную пулю. ";
		base.WeightSubject = 5f;
		base.Protection = 50f;
		base.XRayProtection = 2;
		base.ProtectionFromEject = 2;
		base.TypeSubj = TypeSubject.Suit;
		base.ArtContainer = 1;
	}
}
