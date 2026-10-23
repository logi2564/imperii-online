using UnityEngine;

public class WeaPseudoDog : ConstructorWeapon
{
	public WeaPseudoDog()
	{
		base.NameSubject = "Клыки и когти псевдособаки";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/OtherSprite/Slot128");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/OtherSprite/Slot128");
		base.AudioFire = (AudioClip)Resources.Load("Sound/monsters/pdog_attack_hit_0");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
		base.Damage = 16f;
		base.Range = 0;
		base.Type_Weapon = TypeWeapon.Gun;
		base.CartridgeInMagazineFull = 1000000;
		base.Cartridge = base.CartridgeInMagazineFull;
		base.WeightSubject = 0f;
		base.TypeSubj = TypeSubject.Weapon;
		base.Wear = 0f;
	}
}
