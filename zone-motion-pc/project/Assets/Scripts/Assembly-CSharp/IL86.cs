using UnityEngine;

public class IL86 : ConstructorWeapon
{
	public IL86()
	{
		base.NameSubject = "Enfield SA-80";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Weapon/il86");
		base.TextureSubjectSniper = (Texture2D)Resources.Load("Sprites/Weapon/il86");
		base.FireButton = (Texture2D)Resources.Load("Sprites/Weapon/il86Fire");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/Cartridges/5-56x45");
		base.AudioFire = (AudioClip)Resources.Load("Sound/weapons/t_l85_shot");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/lr300_draw");
		base.AudioReload = (AudioClip)Resources.Load("Sound/weapons/l85_reload");
		base.CostSubject = 6800;
		base.CartridgeType = "5,56x45 мм";
		base.DescriptionSubject = "Автоматичесская винтовка, стояла на вооружении в Великобритании. Установлен оптический прицел. Патроны: " + base.CartridgeType;
		base.Damage = 13f;
		base.Range = 4;
		base.PossibilityOfInstallation = true;
		base.SightInstallation = true;
		base.Type_Weapon = TypeWeapon.Weapon;
		base.CartridgeInMagazineFull = 30;
		base.Cartridge = base.CartridgeInMagazineFull;
		base.AutomaticFire = true;
		base.WeightSubject = 5.5f;
		base.TypeSubj = TypeSubject.Weapon;
		base.Wear = 0.4f;
		base.RateOfFire = 0.6f;
	}
}
