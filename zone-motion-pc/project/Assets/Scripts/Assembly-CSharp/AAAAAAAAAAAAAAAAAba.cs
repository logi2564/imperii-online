using UnityEngine;

public class AAAAAAAAAAAAAAAAAba : AAAAAAAAAAAAAAAAAAk
{
	public AAAAAAAAAAAAAAAAAba()
	{
		base.NameSubject = "Тушенка";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Subject/stew");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_ruck");
		base.CostSubject = 120;
		base.DescriptionSubject = "Консервы с растащенного сталкерами армейского склада.";
		base.WeightSubject = 0.4f;
		base.Sanitation = 0f;
		base.TypeSubj = TypeSubject.OtherSubject;
		base.Hunger = 25;
		base.Thirst = 0;
	}
}
