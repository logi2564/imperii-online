using UnityEngine;

public class WeaBloodsucker : ConstructorWeapon
{
	public WeaBloodsucker()
	{
		base.NameSubject = "Щупальца и когти кровососа";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/OtherSprite/Slot128");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/OtherSprite/Slot128");
		base.AudioFire = (AudioClip)Resources.Load("Sound/monsters/vampire_grasp");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
		base.Damage = 26f;
		base.Range = 0;
		base.Type_Weapon = TypeWeapon.Gun;
		base.CartridgeInMagazineFull = 1000000;
		base.Cartridge = base.CartridgeInMagazineFull;
		base.WeightSubject = 0f;
		base.TypeSubj = TypeSubject.Weapon;
		base.Wear = 0f;
	}
}
