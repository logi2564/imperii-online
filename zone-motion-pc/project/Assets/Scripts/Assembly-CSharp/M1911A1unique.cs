using UnityEngine;

public class M1911A1unique : ConstructorWeapon
{
	public M1911A1unique()
	{
		base.NameSubject = "Кольт сталкера";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Weapon/M1911A1unique");
		base.FireButton = (Texture2D)Resources.Load("Sprites/Weapon/pmFire");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/Cartridges/45ACP");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/walther_draw");
		base.AudioFire = (AudioClip)Resources.Load("Sound/weapons/colt1911_shot");
		base.AudioReload = (AudioClip)Resources.Load("Sound/weapons/colt1911_reload");
		base.CostSubject = 1500;
		base.CartridgeType = ".45 АСР";
		base.DescriptionSubject = "Классический автоматический ''кольт''. Отличается высоким качеством подгонки деталей, материалы заменены на облегченные аналоги. На затворной раме, выгравирована надпись: ''Вольные сталкеры''. Уникальный экземпляр, таких днем с огнем не сыщешь. Патроны: " + base.CartridgeType;
		base.Damage = 9f;
		base.Range = 2;
		base.Type_Weapon = TypeWeapon.Gun;
		base.CartridgeInMagazineFull = 7;
		base.Cartridge = base.CartridgeInMagazineFull;
		base.AutomaticFire = false;
		base.WeightSubject = 1.1f;
		base.WeightUpGrade = -0.3f;
		base.UpGrade = 1f;
		base.SingModification = true;
		base.TypeSubj = TypeSubject.Weapon;
		base.Wear = 0.2f;
		base.PossibilityOfInstallation = false;
	}
}
