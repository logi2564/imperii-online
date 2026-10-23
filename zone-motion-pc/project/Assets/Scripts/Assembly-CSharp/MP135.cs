using UnityEngine;

public class MP135 : ConstructorWeapon
{
	public MP135()
	{
		base.NameSubject = "МР-135";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Weapon/MR135Tactical");
		base.TextureSubjectSniper = (Texture2D)Resources.Load("Sprites/Weapon/MR135Tactical-sniper");
		base.FireButton = (Texture2D)Resources.Load("Sprites/Weapon/bekas12MFire");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/Cartridges/12x70drob");
		base.AudioFire = (AudioClip)Resources.Load("Sound/weapons/mp133_shoot");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/mp133_reload_end");
		base.AudioReload = (AudioClip)Resources.Load("Sound/weapons/mp133_reload_end");
		base.CostSubject = 2300;
		base.CartridgeType = "12х70 дробь";
		base.DescriptionSubject = "Гладкостольное помповое ружье. Установлен короткий пулевой ствол, планка Weaver, классический приклад, пластиковое исполнение. В итоге недорогой  и легкий вариант тактического ружья. Патроны: " + base.CartridgeType;
		base.Damage = 12f;
		base.Range = 2;
		base.Type_Weapon = TypeWeapon.Weapon;
		base.CartridgeInMagazineFull = 5;
		base.Cartridge = base.CartridgeInMagazineFull;
		base.AutomaticFire = false;
		base.WeightSubject = 2.9f;
		base.TypeSubj = TypeSubject.Weapon;
		base.Wear = 0.1f;
		base.PossibilityOfInstallation = true;
	}
}
