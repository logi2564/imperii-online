using UnityEngine;

public class Obres : ConstructorWeapon
{
	public Obres()
	{
		base.NameSubject = "Обрез";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Weapon/obrez");
		base.FireButton = (Texture2D)Resources.Load("Sprites/Weapon/obrezFire");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/Cartridges/12x70drob");
		base.AudioFire = (AudioClip)Resources.Load("Sound/weapons/toz34_shoot");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/toz34_reload_one");
		base.AudioReload = (AudioClip)Resources.Load("Sound/weapons/toz34_reload");
		base.CostSubject = 400;
		base.CartridgeType = "12х70 дробь";
		base.DescriptionSubject = "Обрез старого ружъя с горизонтальным расположением стволов. Значительно компактней и легче новой двустволки, но эффективен только в ближнем бою. Один из самых распространённых видов оружия у новичков. Патроны: " + base.CartridgeType;
		base.Damage = 11f;
		base.Range = 1;
		base.Type_Weapon = TypeWeapon.Weapon;
		base.CartridgeInMagazineFull = 2;
		base.Cartridge = base.CartridgeInMagazineFull;
		base.AutomaticFire = false;
		base.WeightSubject = 2f;
		base.TypeSubj = TypeSubject.Weapon;
		base.Wear = 0.3f;
		base.PossibilityOfInstallation = false;
	}
}
