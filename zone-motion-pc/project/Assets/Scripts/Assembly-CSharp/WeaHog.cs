using UnityEngine;

public class WeaHog : ConstructorWeapon
{
	public WeaHog()
	{
		base.NameSubject = "Клыки кабана";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/OtherSprite/Slot128");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/OtherSprite/Slot128");
		base.AudioFire = (AudioClip)Resources.Load("Sound/monsters/boar_aggressive_1");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
		base.Damage = 14f;
		base.Range = 0;
		base.Type_Weapon = TypeWeapon.Gun;
		base.CartridgeInMagazineFull = 1000000;
		base.Cartridge = base.CartridgeInMagazineFull;
		base.WeightSubject = 0f;
		base.TypeSubj = TypeSubject.Weapon;
		base.Wear = 0f;
	}
}
