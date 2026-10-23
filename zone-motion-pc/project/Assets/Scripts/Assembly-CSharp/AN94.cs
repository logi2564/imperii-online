using UnityEngine;

public class AN94 : ConstructorWeapon
{
	public AN94()
	{
		base.NameSubject = "АН-94 Абакан";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Weapon/AN-94");
		base.TextureSubjectSniper = (Texture2D)Resources.Load("Sprites/Weapon/AN-94");
		base.FireButton = (Texture2D)Resources.Load("Sprites/Weapon/AN94Fire");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/Cartridges/5-45x39");
		base.AudioFire = (AudioClip)Resources.Load("Sound/weapons/ak74_shot_2");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/ak74_draw");
		base.AudioReload = (AudioClip)Resources.Load("Sound/weapons/ak74_reload");
		base.CostSubject = 11000;
		base.CartridgeType = "5,45x39 мм";
		base.DescriptionSubject = "Оружие элитных боевых подразделений. В Абакане подвижны не только внутренние механизмы, но и вся ствольная коробка, что позволяет снизить отдачу, тем самым значительно повысить кучность боя. Калибр 5.45. Установлен несъемный оптический прицел. Патроны: " + base.CartridgeType;
		base.Damage = 13f;
		base.Range = 5;
		base.MinRange = 1;
		base.PossibilityOfInstallation = true;
		base.SightInstallation = true;
		base.Type_Weapon = TypeWeapon.Weapon;
		base.CartridgeInMagazineFull = 30;
		base.Cartridge = base.CartridgeInMagazineFull;
		base.AutomaticFire = true;
		base.WeightSubject = 4.2f;
		base.TypeSubj = TypeSubject.Weapon;
		base.Wear = 0.2f;
		base.RateOfFire = 0.4f;
	}
}
