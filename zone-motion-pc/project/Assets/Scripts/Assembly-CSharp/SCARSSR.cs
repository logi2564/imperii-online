using UnityEngine;

public class SCARSSR : ConstructorWeapon
{
	public SCARSSR()
	{
		base.NameSubject = "SCAR SSR-14";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Weapon/scarSn");
		base.TextureSubjectSniper = (Texture2D)Resources.Load("Sprites/Weapon/scarSn");
		base.FireButton = (Texture2D)Resources.Load("Sprites/Weapon/sigFire");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/Cartridges/5-56x45");
		base.AudioFire = (AudioClip)Resources.Load("Sound/weapons/t_l85_shot");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/lr300_draw");
		base.AudioReload = (AudioClip)Resources.Load("Sound/weapons/sig550_reload");
		base.CostSubject = 12000;
		base.CartridgeType = "5,56x45 мм";
		base.DescriptionSubject = "Боевая штурмовая винтовка для сил специальных операций, орентирована на дальние дистанции ведения огня. Установлен несъемный оптический прицел. Патроны: " + base.CartridgeType;
		base.Damage = 14f;
		base.Range = 5;
		base.MinRange = 1;
		base.PossibilityOfInstallation = true;
		base.SightInstallation = true;
		base.Type_Weapon = TypeWeapon.Weapon;
		base.CartridgeInMagazineFull = 25;
		base.Cartridge = base.CartridgeInMagazineFull;
		base.AutomaticFire = true;
		base.WeightSubject = 4f;
		base.TypeSubj = TypeSubject.Weapon;
		base.Wear = 0.3f;
		base.RateOfFire = 0.5f;
	}
}
