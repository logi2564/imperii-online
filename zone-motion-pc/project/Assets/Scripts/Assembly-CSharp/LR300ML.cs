using UnityEngine;

public class LR300ML : ConstructorWeapon
{
	public LR300ML()
	{
		base.NameSubject = "LR-300ML";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Weapon/LR-300ML");
		base.TextureSubjectSniper = (Texture2D)Resources.Load("Sprites/Weapon/LR-300ML-sniper");
		base.FireButton = (Texture2D)Resources.Load("Sprites/Weapon/LR-300MLFire");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/Cartridges/5-56x45");
		base.AudioFire = (AudioClip)Resources.Load("Sound/weapons/t_lr300_shot");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/weapons/lr300_draw");
		base.AudioReload = (AudioClip)Resources.Load("Sound/weapons/lr300_reload");
		base.CostSubject = 9000;
		base.CartridgeType = "5,56x45 мм";
		base.DescriptionSubject = "Штурмовая винтовка американского производства. Имеет сравнительно небольшой вес, хорошую точность и эргономику. Очень чувствительна к загрязнениям, поэтому не очень подходит для сложных условий Зоны. Используется в основном наёмниками, одиночками и бойцами «Свободы». Патроны: " + base.CartridgeType;
		base.Damage = 14f;
		base.Range = 4;
		base.Type_Weapon = TypeWeapon.Weapon;
		base.CartridgeInMagazineFull = 30;
		base.Cartridge = base.CartridgeInMagazineFull;
		base.AutomaticFire = true;
		base.WeightSubject = 2.7f;
		base.TypeSubj = TypeSubject.Weapon;
		base.Wear = 0.4f;
		base.RateOfFire = 0.5f;
		base.PossibilityOfInstallation = true;
	}
}
