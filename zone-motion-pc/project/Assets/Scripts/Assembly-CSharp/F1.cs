using UnityEngine;

public class F1 : ConstructorGrenade
{
	public F1()
	{
		base.NameSubject = "Ф1";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Weapon/F1");
		base.FireButton = (Texture2D)Resources.Load("Sprites/Weapon/F1");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/OtherSprite/Slot128");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/mine_on");
		base.AudioFire = (AudioClip)Resources.Load("Sound/weapons/f1_explode");
		base.AudioReload = (AudioClip)Resources.Load("Sound/weapons/mine_on");
		base.CostSubject = 300;
		base.DescriptionSubject = "Ручная противопехотная оборонительная граната. Наносит повреждения одновременно всем персонажам, находящемся в точке.";
		base.Damage = 38f;
		base.Range = 1;
		base.CartridgeInMagazineFull = 1;
		base.Cartridge = base.CartridgeInMagazineFull;
		base.AutomaticFire = false;
		base.WeightSubject = 0.5f;
		base.TypeSubj = TypeSubject.Grenade;
		base.Wear = 0.3f;
	}
}
