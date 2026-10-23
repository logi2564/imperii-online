using UnityEngine;

public class M1911A1 : ConstructorWeapon
{
	public M1911A1()
	{
		base.NameSubject = "Кора 919";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Weapon/M1911A1");
		base.FireButton = (Texture2D)Resources.Load("Sprites/Weapon/pmFire");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/Cartridges/45ACP");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/walther_draw");
		base.AudioFire = (AudioClip)Resources.Load("Sound/weapons/colt1911_shot");
		base.AudioReload = (AudioClip)Resources.Load("Sound/weapons/colt1911_reload");
		base.CostSubject = 1200;
		base.CartridgeType = ".45 АСР";
		base.DescriptionSubject = "Классический автоматический ''кольт'', с честью прошедший все вооружённые конфликты ХХ века и уверенно вошедший в новое столетие. Невысокая ёмкость магазина в определённой степени компенсируется использованием мощного патрона. Патроны: " + base.CartridgeType;
		base.Damage = 9f;
		base.Range = 2;
		base.Type_Weapon = TypeWeapon.Gun;
		base.CartridgeInMagazineFull = 7;
		base.Cartridge = base.CartridgeInMagazineFull;
		base.AutomaticFire = false;
		base.WeightSubject = 1.1f;
		base.TypeSubj = TypeSubject.Weapon;
		base.Wear = 0.2f;
		base.PossibilityOfInstallation = false;
	}
}
