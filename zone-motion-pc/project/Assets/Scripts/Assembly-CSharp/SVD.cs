using UnityEngine;

public class SVD : ConstructorWeapon
{
	public SVD()
	{
		base.NameSubject = "СВД";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Weapon/svd80");
		base.TextureSubjectSniper = (Texture2D)Resources.Load("Sprites/Weapon/svd80");
		base.FireButton = (Texture2D)Resources.Load("Sprites/Weapon/svdFire");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/Cartridges/7.62x54-7H1");
		base.AudioFire = (AudioClip)Resources.Load("Sound/weapons/svd_shoot");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/svd_draw");
		base.AudioReload = (AudioClip)Resources.Load("Sound/weapons/svd_reload");
		base.CostSubject = 32000;
		base.CartridgeType = "7,62x54 мм 7H1";
		base.DescriptionSubject = "Снайперская винтовка Драгунова. Широко использовалась во всех боевых операциях, проводившихся советской и российской армиями с 1960-х. Зарекомендовала себя как исключительно надёжное и удобное в обращении оружие. Патроны: " + base.CartridgeType;
		base.Damage = 16f;
		base.Range = 6;
		base.MinRange = 2;
		base.PossibilityOfInstallation = true;
		base.SightInstallation = true;
		base.Type_Weapon = TypeWeapon.Weapon;
		base.CartridgeInMagazineFull = 10;
		base.Cartridge = base.CartridgeInMagazineFull;
		base.AutomaticFire = false;
		base.WeightSubject = 4.9f;
		base.TypeSubj = TypeSubject.Weapon;
		base.Wear = 0.2f;
	}
}
