using UnityEngine;

public class AK74 : ConstructorWeapon
{
	public AK74()
	{
		base.NameSubject = "АК 74";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Weapon/akm-74");
		base.TextureSubjectSniper = (Texture2D)Resources.Load("Sprites/Weapon/akm-74-sniper");
		base.FireButton = (Texture2D)Resources.Load("Sprites/Weapon/akmFire");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/Cartridges/5-45x39");
		base.AudioFire = (AudioClip)Resources.Load("Sound/weapons/ak74_shot_2");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/ak74_draw");
		base.AudioReload = (AudioClip)Resources.Load("Sound/weapons/ak74_reload");
		base.CostSubject = 2600;
		base.CartridgeType = "5,45x39 мм";
		base.DescriptionSubject = "Автомат складной образца 1974 года. Представляет собой простое и надёжное оружие, хотя дешевизна в производстве несколько сказалась на удобстве использования и точности боя. В Зоне это основное оружие военных сталкеров и многих одиночек. Патроны: " + base.CartridgeType;
		base.Damage = 13f;
		base.Range = 4;
		base.Type_Weapon = TypeWeapon.Weapon;
		base.CartridgeInMagazineFull = 30;
		base.Cartridge = base.CartridgeInMagazineFull;
		base.AutomaticFire = true;
		base.WeightSubject = 3.3f;
		base.TypeSubj = TypeSubject.Weapon;
		base.Wear = 0.1f;
		base.RateOfFire = 0.6f;
		base.PossibilityOfInstallation = true;
	}
}
