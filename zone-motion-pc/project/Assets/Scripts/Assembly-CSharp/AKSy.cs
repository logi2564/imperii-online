using UnityEngine;

public class AKSy : ConstructorWeapon
{
	public AKSy()
	{
		base.NameSubject = "АКС 74у";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Weapon/aks-y");
		base.TextureSubjectSniper = (Texture2D)Resources.Load("Sprites/Weapon/aks-y-sniper");
		base.FireButton = (Texture2D)Resources.Load("Sprites/Weapon/aksuFire");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/Cartridges/5-45x39");
		base.AudioFire = (AudioClip)Resources.Load("Sound/weapons/ak74u_shot_3");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/ak74_draw");
		base.AudioReload = (AudioClip)Resources.Load("Sound/weapons/ak74u_reload");
		base.CostSubject = 1500;
		base.CartridgeType = "5,45x39 мм";
		base.DescriptionSubject = "По своим габаритам и массе близок к пистолетам-пулемётам, однако он является представителем автоматов. Достоинства: малые габариты и довольно высокая пробивающая способность. Главные недостатки - малая прицельная дальность и склонность к быстрому перегреву при стрельбе очередями. Патроны: " + base.CartridgeType;
		base.Damage = 12f;
		base.Range = 3;
		base.Type_Weapon = TypeWeapon.Weapon;
		base.CartridgeInMagazineFull = 30;
		base.Cartridge = base.CartridgeInMagazineFull;
		base.AutomaticFire = true;
		base.WeightSubject = 2.7f;
		base.TypeSubj = TypeSubject.Weapon;
		base.Wear = 0.1f;
		base.RateOfFire = 0.6f;
		base.PossibilityOfInstallation = true;
	}
}
