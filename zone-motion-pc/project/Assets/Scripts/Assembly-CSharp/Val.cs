using UnityEngine;

public class Val : ConstructorWeapon
{
	public Val()
	{
		base.NameSubject = "ВАЛ";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Weapon/Val");
		base.TextureSubjectSniper = (Texture2D)Resources.Load("Sprites/Weapon/Val-sniper");
		base.FireButton = (Texture2D)Resources.Load("Sprites/Weapon/aksuFire");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/Cartridges/9x39-PAB-9");
		base.AudioFire = (AudioClip)Resources.Load("Sound/weapons/vintorez_shoot2");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/vintorez_draw");
		base.AudioReload = (AudioClip)Resources.Load("Sound/weapons/vintorez_reload");
		base.CostSubject = 12000;
		base.CartridgeType = "9х39 мм СП-5";
		base.DescriptionSubject = "Создан на базе бесшумной снайперской винтовки «Винторез», от которой отличается складным прикладом, штатной возможностью вести огонь очередями, а также более ёмким магазином. Изначально предназначался для применения спецподразделениями в условиях, требующих бесшумной и беспламенной стрельбы. Патроны: " + base.CartridgeType;
		base.Damage = 16f;
		base.Range = 4;
		base.PossibilityOfInstallation = false;
		base.SightInstallation = true;
		base.Type_Weapon = TypeWeapon.Weapon;
		base.CartridgeInMagazineFull = 20;
		base.Cartridge = base.CartridgeInMagazineFull;
		base.AutomaticFire = true;
		base.WeightSubject = 2.5f;
		base.TypeSubj = TypeSubject.Weapon;
		base.Wear = 0.2f;
		base.RateOfFire = 0.7f;
	}
}
