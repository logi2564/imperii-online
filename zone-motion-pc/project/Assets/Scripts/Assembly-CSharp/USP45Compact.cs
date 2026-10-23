using UnityEngine;

public class USP45Compact : ConstructorWeapon
{
	public USP45Compact()
	{
		base.NameSubject = "H&K USP.45 Compact";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Weapon/udp-compact");
		base.FireButton = (Texture2D)Resources.Load("Sprites/Weapon/pmFire");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/Cartridges/45ACP");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/usp_draw");
		base.AudioFire = (AudioClip)Resources.Load("Sound/weapons/usp_shoot");
		base.AudioReload = (AudioClip)Resources.Load("Sound/weapons/usp_reload");
		base.CostSubject = 1500;
		base.CartridgeType = ".45 АСР";
		base.DescriptionSubject = "Солидный ствол. Немецкое качество и надёжность. Компактное оружие ближнего боя. Пользуется особой популярностью среди ветеранов Зоны. Патроны: " + base.CartridgeType;
		base.Damage = 8f;
		base.Range = 2;
		base.Type_Weapon = TypeWeapon.Gun;
		base.CartridgeInMagazineFull = 8;
		base.Cartridge = base.CartridgeInMagazineFull;
		base.AutomaticFire = false;
		base.WeightSubject = 0.7f;
		base.TypeSubj = TypeSubject.Weapon;
		base.Wear = 0.1f;
		base.PossibilityOfInstallation = false;
	}
}
