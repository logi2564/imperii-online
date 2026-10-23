using UnityEngine;

public class Remington870Tactical : ConstructorWeapon
{
	public Remington870Tactical()
	{
		base.NameSubject = "Remington 870 Tactical";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Weapon/Remington870Tactical");
		base.TextureSubjectSniper = (Texture2D)Resources.Load("Sprites/Weapon/Remington870Tactical-sniper");
		base.FireButton = (Texture2D)Resources.Load("Sprites/Weapon/bekas12tacticalFire");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/Cartridges/12x70drob");
		base.AudioFire = (AudioClip)Resources.Load("Sound/weapons/mp133_shoot");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/mp133_reload_end");
		base.AudioReload = (AudioClip)Resources.Load("Sound/weapons/mp133_reload_end");
		base.CostSubject = 3800;
		base.CartridgeType = "12х70 дробь";
		base.DescriptionSubject = "Тактический вариант легендарного, классического ружья американского производства. Состоит на вооружении армии и полиции штатов и других стран. Патроны: " + base.CartridgeType;
		base.Damage = 13f;
		base.Range = 2;
		base.Type_Weapon = TypeWeapon.Weapon;
		base.CartridgeInMagazineFull = 6;
		base.Cartridge = base.CartridgeInMagazineFull;
		base.AutomaticFire = false;
		base.WeightSubject = 3.1f;
		base.TypeSubj = TypeSubject.Weapon;
		base.Wear = 0.1f;
		base.PossibilityOfInstallation = true;
	}
}
