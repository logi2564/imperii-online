using UnityEngine;

public class GaussGun : ConstructorWeapon
{
	public GaussGun()
	{
		base.NameSubject = "Гаусс пушка";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Weapon/gauss");
		base.TextureSubjectSniper = (Texture2D)Resources.Load("Sprites/Weapon/gauss");
		base.FireButton = (Texture2D)Resources.Load("Sprites/Weapon/gaussFire");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/Cartridges/accumulator");
		base.AudioFire = (AudioClip)Resources.Load("Sound/weapons/gauss_shoot");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/generic_draw");
		base.AudioReload = (AudioClip)Resources.Load("Sound/weapons/gauss_reload");
		base.CostSubject = 32000;
		base.CartridgeType = "Аккумуляторы";
		base.DescriptionSubject = "Сверхточное оружие, которое собрали конструкторы в Зоне. Работает почти бесшумно, поскольку для стрельбы используется энергия артефактов, а не пороховых газов. Несмотря на колоссальную мощность выстрела, отдача у гаусс-пушки очень невелика. По точности и убойной силе превосходит любое классическое стрелковое оружие. Питание: " + base.CartridgeType;
		base.Damage = 20f;
		base.Range = 7;
		base.MinRange = 3;
		base.PossibilityOfInstallation = true;
		base.SightInstallation = true;
		base.Type_Weapon = TypeWeapon.Weapon;
		base.CartridgeInMagazineFull = 6;
		base.Cartridge = base.CartridgeInMagazineFull;
		base.AutomaticFire = false;
		base.WeightSubject = 5.5f;
		base.TypeSubj = TypeSubject.Weapon;
		base.Wear = 0.3f;
	}
}
