using UnityEngine;

public class AAAAAAAAAAAAAAAAAAbs : AAAAAAAAAAAAAAAAAAk
{
	public AAAAAAAAAAAAAAAAAAbs()
	{
		base.NameSubject = "Бинт";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Subject/bint");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_ruck");
		base.CostSubject = 25;
		base.DescriptionSubject = "Перевязочный материал.";
		base.WeightSubject = 0.1f;
		base.Sanitation = 5f;
		base.Bleeding = -5f;
		base.TypeSubj = TypeSubject.OtherSubject;
	}
}
