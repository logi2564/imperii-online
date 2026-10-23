using UnityEngine;

public class AAAAAAAAAAAAAAAAAAAAbo : AAAAAAAAAAAAAAAAAAk
{
	public AAAAAAAAAAAAAAAAAAAAbo()
	{
		base.NameSubject = "Бутылка воды";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Subject/water");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_ruck");
		base.AudioFire = (AudioClip)Resources.Load("Sound/Suit/inv_properties");
		base.CostSubject = 80;
		base.DescriptionSubject = "Полулитровая бутылка питьевой воды.";
		base.WeightSubject = 0.4f;
		base.Sanitation = 0f;
		base.XRayProtection = 0;
		base.Bleeding = 0f;
		base.TypeSubj = TypeSubject.OtherSubject;
		base.Hunger = 0;
		base.Thirst = 25;
	}
}
