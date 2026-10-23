using UnityEngine;

public class NoneWeapon : ConstructorWeapon
{
	public NoneWeapon()
	{
		base.NameSubject = "None";
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/OtherSprite/Slot128");
		base.TextureSubjectSniper = (Texture2D)Resources.Load("Sprites/OtherSprite/Slot128");
		base.CartridgesImage = (Texture2D)Resources.Load("Sprites/OtherSprite/Slot128");
		base.CostSubject = 0;
		base.DescriptionSubject = string.Empty;
		base.Damage = 0f;
		base.Range = 0;
		base.Type_Weapon = TypeWeapon.None;
		base.WeightSubject = 0f;
		base.Wear = 0f;
	}
}
