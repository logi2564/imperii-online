using UnityEngine;

public class WaltherP99 : ConstructorWeapon
{
	public WaltherP99()
	{
		base.NameSubject = "Walther P99";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Weapon/WaltherP99");
		base.FireButton = (Texture2D)Resources.Load("Sprites/Weapon/pmFire");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/Cartridges/9x19zmo");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/walther_draw");
		base.AudioFire = (AudioClip)Resources.Load("Sound/weapons/t_walther_shot");
		base.AudioReload = (AudioClip)Resources.Load("Sound/weapons/walther_reload");
		base.CostSubject = 900;
		base.CartridgeType = "9х19 мм";
		base.DescriptionSubject = "Отличный пистолет немецкого производства, отличающийся надёжностью, ёмким магазином и хорошей точностью боя. Патроны: " + base.CartridgeType;
		base.Damage = 7f;
		base.Range = 2;
		base.Type_Weapon = TypeWeapon.Gun;
		base.CartridgeInMagazineFull = 16;
		base.Cartridge = base.CartridgeInMagazineFull;
		base.AutomaticFire = false;
		base.WeightSubject = 0.75f;
		base.TypeSubj = TypeSubject.Weapon;
		base.Wear = 0.2f;
		base.PossibilityOfInstallation = false;
	}
}
