using UnityEngine;

public class FamasF1 : ConstructorWeapon
{
	public FamasF1()
	{
		base.NameSubject = "FAMAS F1";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Weapon/FAMAS-F1");
		base.FireButton = (Texture2D)Resources.Load("Sprites/Weapon/FAMAS-F1Fire");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/Cartridges/5-56x45");
		base.AudioFire = (AudioClip)Resources.Load("Sound/weapons/t_l85_shot");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/lr300_draw");
		base.AudioReload = (AudioClip)Resources.Load("Sound/weapons/l85_reload");
		base.CostSubject = 7500;
		base.CartridgeType = "5,56x45 мм";
		base.DescriptionSubject = "Автомат французской разработки. Высокая скорострельность и схема ''булл-пап'' сделали его популярным, среди любителей западного оружия. Из недостатков, пожалуй, можно отметить, только высокую отдачу... Патроны: " + base.CartridgeType;
		base.Damage = 13f;
		base.Range = 4;
		base.Type_Weapon = TypeWeapon.Weapon;
		base.CartridgeInMagazineFull = 25;
		base.Cartridge = base.CartridgeInMagazineFull;
		base.AutomaticFire = true;
		base.WeightSubject = 3.8f;
		base.TypeSubj = TypeSubject.Weapon;
		base.Wear = 0.4f;
		base.RateOfFire = 0.5f;
		base.PossibilityOfInstallation = false;
	}
}
