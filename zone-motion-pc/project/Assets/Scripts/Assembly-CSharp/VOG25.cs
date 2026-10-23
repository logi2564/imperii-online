using UnityEngine;

public class VOG25 : ConstructorGrenade
{
	public VOG25()
	{
		base.NameSubject = "ВОГ 25";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Weapon/vog25");
		base.FireButton = (Texture2D)Resources.Load("Sprites/Weapon/F1");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/OtherSprite/Slot128");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/mine_on");
		base.AudioFire = (AudioClip)Resources.Load("Sound/weapons/f1_explode");
		base.AudioReload = (AudioClip)Resources.Load("Sound/weapons/mine_on");
		base.CostSubject = 300;
		base.DescriptionSubject = "Осколочный боеприпас для подствольного гранатомета ''Костер'' или ''Бульдог''. Наносит повреждения одновременно всем персонажам, находящемся в точке.";
		base.Damage = 30f;
		base.Range = 4;
		base.CartridgeInMagazineFull = 1;
		base.Cartridge = base.CartridgeInMagazineFull;
		base.AutomaticFire = false;
		base.WeightSubject = 0.2f;
		base.TypeSubj = TypeSubject.Grenade;
		base.Wear = 0.3f;
		base.TypeGren = TypeGrenade.USSR;
	}
}
