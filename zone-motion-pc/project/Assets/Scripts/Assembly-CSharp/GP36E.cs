using UnityEngine;

public class GP36E : ConstructorWeapon
{
	public GP36E()
	{
		base.NameSubject = "G36E";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Weapon/gp37");
		base.TextureSubjectSniper = (Texture2D)Resources.Load("Sprites/Weapon/gp37");
		base.FireButton = (Texture2D)Resources.Load("Sprites/Weapon/GP37Fire");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/Cartridges/5-56x45");
		base.AudioFire = (AudioClip)Resources.Load("Sound/weapons/g36_shot");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/g36_empty");
		base.AudioReload = (AudioClip)Resources.Load("Sound/weapons/g36_reload");
		base.CostSubject = 17000;
		base.CartridgeType = "5,56x45 мм";
		base.DescriptionSubject = "''Heckler - Koch G36E''. Воплощение новых тенденций в автоматическом оружии западного производства: работа механизма основана теперь не на полусвободном затворе, а на коротком ходе газового поршня. Нужно сказать, изменения явно пошли на пользу: данная штурмовая винтовка представляет собой первоклассный образец современного оружия - лёгкого, надёжного и эргономичного. Патроны: " + base.CartridgeType;
		base.Damage = 13f;
		base.Range = 5;
		base.MinRange = 1;
		base.Type_Weapon = TypeWeapon.Weapon;
		base.CartridgeInMagazineFull = 30;
		base.Cartridge = base.CartridgeInMagazineFull;
		base.AutomaticFire = true;
		base.WeightSubject = 3.7f;
		base.TypeSubj = TypeSubject.Weapon;
		base.Wear = 0.4f;
		base.RateOfFire = 0.5f;
		base.PossibilityOfInstallation = true;
		base.SightInstallation = true;
	}
}
