using UnityEngine;

public class Bekas12 : ConstructorWeapon
{
	public Bekas12()
	{
		base.NameSubject = "Бекас 12 М";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Weapon/bekas12m");
		base.TextureSubjectSniper = (Texture2D)Resources.Load("Sprites/Weapon/bekas12m-sniper");
		base.FireButton = (Texture2D)Resources.Load("Sprites/Weapon/bekas12MFire");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/Cartridges/12x70drob");
		base.AudioFire = (AudioClip)Resources.Load("Sound/weapons/mp133_shoot");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/mp133_reload_end");
		base.AudioReload = (AudioClip)Resources.Load("Sound/weapons/mp133_reload_end");
		base.CostSubject = 2400;
		base.CartridgeType = "12х70 дробь";
		base.DescriptionSubject = "Гладкоствольное помповое ружье, практически безотказное. Установлен короткий пулевой ствол, для стрельбы по крупному зверю. Максимальная дистанция выстрела 150 м. Патроны: " + base.CartridgeType;
		base.Damage = 12f;
		base.Range = 2;
		base.Type_Weapon = TypeWeapon.Weapon;
		base.CartridgeInMagazineFull = 6;
		base.Cartridge = base.CartridgeInMagazineFull;
		base.AutomaticFire = false;
		base.WeightSubject = 3.5f;
		base.TypeSubj = TypeSubject.Weapon;
		base.Wear = 0.1f;
		base.PossibilityOfInstallation = true;
	}
}
