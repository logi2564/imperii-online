using UnityEngine;

public class PM : ConstructorWeapon
{
	public PM()
	{
		base.NameSubject = "ПМ";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Weapon/pm");
		base.FireButton = (Texture2D)Resources.Load("Sprites/Weapon/pmFire");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/Cartridges/9x18");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/pm_draw");
		base.AudioFire = (AudioClip)Resources.Load("Sound/weapons/pm_shoot");
		base.AudioReload = (AudioClip)Resources.Load("Sound/weapons/pm_reload");
		base.CostSubject = 250;
		base.CartridgeType = "9х18 мм";
		base.DescriptionSubject = "Старый пистолет советского производства, наиболее распространённый в зоне. Достаточно надёжный и дешёвый, отличается невысокой ёмкостью магазина при недостаточной мощности и неудовлетворительной кучности патрона. Основное оружие сталкера-новичка. Патроны: " + base.CartridgeType;
		base.Damage = 7f;
		base.Range = 2;
		base.Type_Weapon = TypeWeapon.Gun;
		base.CartridgeInMagazineFull = 8;
		base.Cartridge = base.CartridgeInMagazineFull;
		base.AutomaticFire = false;
		base.WeightSubject = 0.7f;
		base.TypeSubj = TypeSubject.Weapon;
		base.Wear = 0.2f;
		base.PossibilityOfInstallation = false;
	}
}
