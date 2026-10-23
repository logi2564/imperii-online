using UnityEngine;

public class AAAAAAAAAAAAAAAAz : AAAAAAAAAAAAAAAAAAk
{
	public AAAAAAAAAAAAAAAAz()
	{
		base.NameSubject = "Антирадиационные препараты";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Subject/antiXray");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_ruck");
		base.AudioFire = (AudioClip)Resources.Load("Sound/Suit/inv_properties");
		base.CostSubject = 450;
		base.DescriptionSubject = "Снижают воздействие радиации на организм.";
		base.WeightSubject = 0.1f;
		base.Sanitation = 0f;
		base.XRaySanitation = -4;
		base.Bleeding = 0f;
		base.TypeSubj = TypeSubject.OtherSubject;
		base.Hunger = 0;
		base.Thirst = -1;
	}
}
