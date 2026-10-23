using UnityEngine;

public class OC14Storm : ConstructorWeapon
{
	public OC14Storm()
	{
		base.NameSubject = "ОЦ-14 «Гроза»";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Weapon/OC14");
		base.FireButton = (Texture2D)Resources.Load("Sprites/Weapon/OC14Fire");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/Cartridges/9x39-PAB-9");
		base.AudioFire = (AudioClip)Resources.Load("Sound/weapons/groza_shoot");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/groza_draw");
		base.AudioReload = (AudioClip)Resources.Load("Sound/weapons/groza_reload");
		base.CostSubject = 17000;
		base.CartridgeType = "9х39 мм СП-5";
		base.DescriptionSubject = "Автоматно-гранатомётный комплекс, на 70% унифицированный с автоматами типа АКМ-74 (основные отличия — калибр 9х39 мм, компоновочная схема «булл-пап» и более широкие возможности для модернизации). Разработан для вооружения подразделений быстрого реагирования. Очень ценим военными и сталкерами за способность надёжно поражать защищённого бронежилетом или расположенного в укрытии противника. Патроны: " + base.CartridgeType;
		base.Damage = 16f;
		base.Range = 4;
		base.Type_Weapon = TypeWeapon.Weapon;
		base.CartridgeInMagazineFull = 20;
		base.Cartridge = base.CartridgeInMagazineFull;
		base.AutomaticFire = true;
		base.WeightSubject = 4.6f;
		base.TypeSubj = TypeSubject.Weapon;
		base.Wear = 0.3f;
		base.RateOfFire = 0.7f;
		base.GrenadePossibilityOfInstallation = true;
		base.GrenadeInstallation = true;
		base.TypeGren = TypeGrenade.USSR;
		base.PossibilityOfInstallation = false;
	}
}
