using UnityEngine;

public class SIG550 : ConstructorWeapon
{
	public SIG550()
	{
		base.NameSubject = "SIG 550";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Weapon/sig550");
		base.TextureSubjectSniper = (Texture2D)Resources.Load("Sprites/Weapon/sig550-sniper");
		base.FireButton = (Texture2D)Resources.Load("Sprites/Weapon/sigFire");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/Cartridges/5-56x45");
		base.AudioFire = (AudioClip)Resources.Load("Sound/weapons/t_sig550_shot");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/lr300_draw");
		base.AudioReload = (AudioClip)Resources.Load("Sound/weapons/sig550_reload");
		base.CostSubject = 10000;
		base.CartridgeType = "5,56x45 мм";
		base.DescriptionSubject = "Швецарская винтовка, орентированная на дальнюю дистанцию ведения огня. Точность, мягкая отдача и высокая надёжность данного оружия быстро завоевали ему самую широкую популярность. Патроны: " + base.CartridgeType;
		base.Damage = 13f;
		base.Range = 5;
		base.MinRange = 1;
		base.Type_Weapon = TypeWeapon.Weapon;
		base.CartridgeInMagazineFull = 30;
		base.Cartridge = base.CartridgeInMagazineFull;
		base.AutomaticFire = true;
		base.WeightSubject = 4.2f;
		base.TypeSubj = TypeSubject.Weapon;
		base.Wear = 0.3f;
		base.RateOfFire = 0.6f;
		base.PossibilityOfInstallation = true;
	}
}
