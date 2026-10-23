using UnityEngine;

public class Vintores : ConstructorWeapon
{
	public Vintores()
	{
		base.NameSubject = "Винторез";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Weapon/vintores2008");
		base.TextureSubjectSniper = (Texture2D)Resources.Load("Sprites/Weapon/vintores2008");
		base.FireButton = (Texture2D)Resources.Load("Sprites/Weapon/vintores64Fire");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/Cartridges/9x39-PAB-9");
		base.AudioFire = (AudioClip)Resources.Load("Sound/weapons/vintorez_shoot2");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/vintorez_draw");
		base.AudioReload = (AudioClip)Resources.Load("Sound/weapons/vintorez_reload");
		base.CostSubject = 15000;
		base.CartridgeType = "9х39 мм СП-5";
		base.DescriptionSubject = "ВСС ''Винторез''. Винтовка специальная снайперская, предназначена для бесшумной и беспламенной снайперской стрельбы и снабжена интегрированным глушителем. С расстояния 400 метров пробивает бронежилет любой степени защиты. Очень ценимое сталкерами любого уровня оружие. Патроны: " + base.CartridgeType;
		base.Damage = 16f;
		base.Range = 5;
		base.MinRange = 1;
		base.PossibilityOfInstallation = false;
		base.SightInstallation = true;
		base.Type_Weapon = TypeWeapon.Weapon;
		base.CartridgeInMagazineFull = 10;
		base.Cartridge = base.CartridgeInMagazineFull;
		base.AutomaticFire = false;
		base.WeightSubject = 3f;
		base.TypeSubj = TypeSubject.Weapon;
		base.Wear = 0.2f;
		base.RateOfFire = 0.6f;
	}
}
