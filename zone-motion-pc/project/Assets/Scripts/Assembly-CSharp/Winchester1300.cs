using UnityEngine;

public class Winchester1300 : ConstructorWeapon
{
	public Winchester1300()
	{
		base.NameSubject = "Винчестер 1300";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Weapon/cheyzer13");
		base.FireButton = (Texture2D)Resources.Load("Sprites/Weapon/cheyzer13Fire");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/Cartridges/12x70drob");
		base.AudioFire = (AudioClip)Resources.Load("Sound/weapons/mp133_shoot");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/mp133_reload_end");
		base.AudioReload = (AudioClip)Resources.Load("Sound/weapons/mp133_reload_end");
		base.CostSubject = 3000;
		base.CartridgeType = "12х70 дробь";
		base.DescriptionSubject = "Гладкоствольное помповое ружье американского производства. Пистолетная рукоятка исключает прицельную стрельбу на дальних дистанциях. Обладает высокой надежностью. Патронник на 6 патронов. Патроны: " + base.CartridgeType;
		base.Damage = 14f;
		base.Range = 1;
		base.Type_Weapon = TypeWeapon.Weapon;
		base.CartridgeInMagazineFull = 6;
		base.Cartridge = base.CartridgeInMagazineFull;
		base.AutomaticFire = false;
		base.WeightSubject = 3f;
		base.TypeSubj = TypeSubject.Weapon;
		base.Wear = 0.1f;
		base.PossibilityOfInstallation = false;
	}
}
