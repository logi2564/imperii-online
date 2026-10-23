using UnityEngine;

public class MP5 : ConstructorWeapon
{
	public MP5()
	{
		base.NameSubject = "МП5";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Weapon/MP5");
		base.TextureSubjectSniper = (Texture2D)Resources.Load("Sprites/Weapon/MP5-sniper");
		base.FireButton = (Texture2D)Resources.Load("Sprites/Weapon/mp5Fire");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/Cartridges/9x19zmo");
		base.AudioFire = (AudioClip)Resources.Load("Sound/weapons/t_mp53_shot");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/lr300_draw");
		base.AudioReload = (AudioClip)Resources.Load("Sound/weapons/mp5_reload");
		base.CostSubject = 2200;
		base.CartridgeType = "9х19 мм";
		base.DescriptionSubject = "Одно из самых лучших в классе пистолетов-пулемётов оружие. В течении последних десятилетий ХХ века был принят на вооружение спецподразделений армии и полиции во многих странах мира. С началом его постепенной замены более современными моделями стал часто появляться на чёрном рынке, откуда массово попал и в Зону. Патроны: " + base.CartridgeType;
		base.Damage = 12f;
		base.Range = 3;
		base.Type_Weapon = TypeWeapon.Weapon;
		base.CartridgeInMagazineFull = 25;
		base.Cartridge = base.CartridgeInMagazineFull;
		base.AutomaticFire = true;
		base.WeightSubject = 2.7f;
		base.TypeSubj = TypeSubject.Weapon;
		base.Wear = 0.4f;
		base.RateOfFire = 0.6f;
		base.PossibilityOfInstallation = true;
	}
}
