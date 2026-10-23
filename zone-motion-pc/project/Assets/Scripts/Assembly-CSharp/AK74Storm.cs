using UnityEngine;

public class AK74Storm : ConstructorWeapon
{
	public AK74Storm()
	{
		base.NameSubject = "АК 74 Штурмовой";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Weapon/akm-74-Storm");
		base.FireButton = (Texture2D)Resources.Load("Sprites/Weapon/akmFire");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/Cartridges/5-45x39");
		base.AudioFire = (AudioClip)Resources.Load("Sound/weapons/ak74_shot_2");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/ak74_draw");
		base.AudioReload = (AudioClip)Resources.Load("Sound/weapons/ak74_reload");
		base.CostSubject = 3800;
		base.CartridgeType = "5,45x39 мм";
		base.DescriptionSubject = "Автомат Калашникова образца 1974 года, калибр 5.45. Оснащен несъемным подствольным гранатометом. Патроны: " + base.CartridgeType;
		base.Damage = 13f;
		base.Range = 4;
		base.Type_Weapon = TypeWeapon.Weapon;
		base.CartridgeInMagazineFull = 30;
		base.Cartridge = base.CartridgeInMagazineFull;
		base.AutomaticFire = true;
		base.WeightSubject = 4.6f;
		base.TypeSubj = TypeSubject.Weapon;
		base.Wear = 0.1f;
		base.RateOfFire = 0.6f;
		base.GrenadePossibilityOfInstallation = true;
		base.GrenadeInstallation = true;
		base.TypeGren = TypeGrenade.USSR;
		base.PossibilityOfInstallation = false;
	}
}
