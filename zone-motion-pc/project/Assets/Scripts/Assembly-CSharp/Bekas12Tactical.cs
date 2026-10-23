using UnityEngine;

public class Bekas12Tactical : ConstructorWeapon
{
	public Bekas12Tactical()
	{
		base.NameSubject = "Бекас 12М Tactical";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Weapon/bekas12tactical");
		base.TextureSubjectSniper = (Texture2D)Resources.Load("Sprites/Weapon/bekas12tactical-sniper");
		base.FireButton = (Texture2D)Resources.Load("Sprites/Weapon/bekas12tacticalFire");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/Cartridges/12x70drob");
		base.AudioFire = (AudioClip)Resources.Load("Sound/weapons/mp133_shoot");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/mp133_reload_end");
		base.AudioReload = (AudioClip)Resources.Load("Sound/weapons/mp133_reload_end");
		base.CostSubject = 3000;
		base.CartridgeType = "12х70 дробь";
		base.DescriptionSubject = "Доработанный Бекас12М. Установлена пистолетная рукоятка и пластиковый приклад, что повышает удобство обращения и уменьшает вес. Патроны: " + base.CartridgeType;
		base.Damage = 12f;
		base.Range = 2;
		base.Type_Weapon = TypeWeapon.Weapon;
		base.CartridgeInMagazineFull = 6;
		base.Cartridge = base.CartridgeInMagazineFull;
		base.AutomaticFire = false;
		base.WeightSubject = 3.4f;
		base.TypeSubj = TypeSubject.Weapon;
		base.Wear = 0.1f;
		base.PossibilityOfInstallation = true;
	}
}
