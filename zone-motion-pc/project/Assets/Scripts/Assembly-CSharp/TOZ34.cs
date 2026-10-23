using UnityEngine;

public class TOZ34 : ConstructorWeapon
{
	public TOZ34()
	{
		base.NameSubject = "ТОЗ 34";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Weapon/toz34");
		base.FireButton = (Texture2D)Resources.Load("Sprites/Weapon/toz34Fire");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/Cartridges/12x70drob");
		base.AudioFire = (AudioClip)Resources.Load("Sound/weapons/toz34_shoot");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/toz34_reload_one");
		base.AudioReload = (AudioClip)Resources.Load("Sound/weapons/toz34_reload");
		base.CostSubject = 1400;
		base.CartridgeType = "12х70 дробь";
		base.DescriptionSubject = "Внутрикурковое двуствольное охотничье ружье с вертикально расположенными стволами ''ТОЗ 34''. Широко распространённое и ничем особо не примечательное охотничье ружьё - ''вертикалка''. Патроны: " + base.CartridgeType;
		base.Damage = 14f;
		base.Range = 2;
		base.Type_Weapon = TypeWeapon.Weapon;
		base.CartridgeInMagazineFull = 2;
		base.Cartridge = base.CartridgeInMagazineFull;
		base.AutomaticFire = false;
		base.WeightSubject = 3.2f;
		base.TypeSubj = TypeSubject.Weapon;
		base.Wear = 0.3f;
		base.PossibilityOfInstallation = false;
	}
}
