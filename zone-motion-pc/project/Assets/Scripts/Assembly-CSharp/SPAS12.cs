using UnityEngine;

public class SPAS12 : ConstructorWeapon
{
	public SPAS12()
	{
		base.NameSubject = "SPAS-12";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Weapon/spas12");
		base.FireButton = (Texture2D)Resources.Load("Sprites/Weapon/cheyzer13Fire");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/Cartridges/12x70drob");
		base.AudioFire = (AudioClip)Resources.Load("Sound/weapons/spas12_shot");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/spas12_open");
		base.AudioReload = (AudioClip)Resources.Load("Sound/weapons/spas12_reload_end");
		base.CostSubject = 2500;
		base.CartridgeType = "12х70 дробь";
		base.DescriptionSubject = "Гладкоствольное ружьё, разработано в конце 1970-х в качестве универсального боевого оружия для полиции и штурмовых подразделений армии. Данное оружие отличают высокая надёжность и гибкость применения. С другой стороны, оно довольно массивно, сложно в устройстве и дорого. Пожалуй, лучшего ствола для ближнего боя в Зоне не найти. Патроны: " + base.CartridgeType;
		base.Damage = 15f;
		base.Range = 1;
		base.Type_Weapon = TypeWeapon.Weapon;
		base.CartridgeInMagazineFull = 8;
		base.Cartridge = base.CartridgeInMagazineFull;
		base.AutomaticFire = false;
		base.WeightSubject = 4.4f;
		base.TypeSubj = TypeSubject.Weapon;
		base.Wear = 0.1f;
		base.PossibilityOfInstallation = false;
	}
}
