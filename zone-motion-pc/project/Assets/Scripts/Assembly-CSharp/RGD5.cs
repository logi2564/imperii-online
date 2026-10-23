using UnityEngine;

public class RGD5 : ConstructorGrenade
{
	public RGD5()
	{
		base.NameSubject = "РГД-5";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Weapon/RGD5");
		base.FireButton = (Texture2D)Resources.Load("Sprites/Weapon/RGD5");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/OtherSprite/Slot128");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/mine_on");
		base.AudioFire = (AudioClip)Resources.Load("Sound/weapons/rgd5_explode");
		base.AudioReload = (AudioClip)Resources.Load("Sound/weapons/mine_on");
		base.CostSubject = 250;
		base.DescriptionSubject = "Ручная противопехотная наступательная граната. Наносит повреждения одновременно всем персонажам, находящемся в точке.";
		base.Damage = 30f;
		base.Range = 2;
		base.CartridgeInMagazineFull = 1;
		base.Cartridge = base.CartridgeInMagazineFull;
		base.AutomaticFire = false;
		base.WeightSubject = 0.3f;
		base.TypeSubj = TypeSubject.Grenade;
		base.Wear = 0.3f;
	}
}
