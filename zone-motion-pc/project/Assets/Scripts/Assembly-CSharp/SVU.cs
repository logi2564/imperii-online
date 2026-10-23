using UnityEngine;

public class SVU : ConstructorWeapon
{
	public SVU()
	{
		base.NameSubject = "СВУ";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Weapon/svu-mk2");
		base.TextureSubjectSniper = (Texture2D)Resources.Load("Sprites/Weapon/svu-mk2");
		base.FireButton = (Texture2D)Resources.Load("Sprites/Weapon/svu-mk2Fire");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/Cartridges/7.62x54-7H1");
		base.AudioFire = (AudioClip)Resources.Load("Sound/weapons/svd_shoot");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/svd_draw");
		base.AudioReload = (AudioClip)Resources.Load("Sound/weapons/svd_reload");
		base.CostSubject = 23000;
		base.CartridgeType = "7,62x54 мм 7H1";
		base.DescriptionSubject = "Самозарядная снайперская винтовка компоновки булл-пап, разработанная на основе СВД. По кучности стрельбы на малые и средние дальности примерно аналогична прародителю. Патроны: " + base.CartridgeType;
		base.Damage = 14f;
		base.Range = 6;
		base.MinRange = 2;
		base.PossibilityOfInstallation = true;
		base.SightInstallation = true;
		base.Type_Weapon = TypeWeapon.Weapon;
		base.CartridgeInMagazineFull = 10;
		base.Cartridge = base.CartridgeInMagazineFull;
		base.AutomaticFire = false;
		base.WeightSubject = 4.9f;
		base.TypeSubj = TypeSubject.Weapon;
		base.Wear = 0.2f;
	}
}
