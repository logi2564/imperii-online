using UnityEngine;

public class AAAAAAAAAAAAAAba : AAAAAAAAAAAAAAAAAAk
{
	public AAAAAAAAAAAAAAba()
	{
		base.NameSubject = "Хлеб";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Subject/bread");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
		base.CostSubject = 20;
		base.DescriptionSubject = "Кто-то умудряется печь батоны на территории зоны.";
		base.WeightSubject = 0.2f;
		base.Sanitation = 0f;
		base.TypeSubj = TypeSubject.OtherSubject;
		base.Hunger = 15;
	}
}
