using UnityEngine;

public class AAAAAAAAAAAAAAAAAAw : AAAAAAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAAAw()
	{
		base.NameSubject = "Экзоскелет Монолита";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Suit/Exo_monolith");
		base.IconCharacter = (Texture2D)Resources.Load("Sprites/IconChar/iconCharExo256Monolith");
		base.IconCharacterDead = (Texture2D)Resources.Load("Sprites/IconChar/iconCharDead128");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/generic_draw");
		base.CostSubject = 60000;
		base.DescriptionSubject = "Экзоскелет боевиков из группировки «Монолит». Данная модель превосходно защищает от всех видов повреждений, однако встречается крайне редко. Экзоскелеты «Монолита» носят так называемые «танки» Монолита. Является практически наилучшим Экзоскелетом";
		base.WeightSubject = 12f;
		base.Protection = 77f;
		base.XRayProtection = 3;
		base.ProtectionFromEject = 3;
		base.Force = 16f;
		base.TypeSubj = TypeSubject.Suit;
		base.ArtContainer = 1;
	}
}
