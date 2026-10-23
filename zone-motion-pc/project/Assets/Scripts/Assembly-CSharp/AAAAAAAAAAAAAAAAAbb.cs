using UnityEngine;

public class AAAAAAAAAAAAAAAAAbb : AAAAAAAAAAAAAAAAAAk
{
	public AAAAAAAAAAAAAAAAAbb()
	{
		base.NameSubject = "Энергетический напиток";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Subject/nonstop");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_ruck");
		base.CostSubject = 250;
		base.DescriptionSubject = "Позволяет сделать силовой рывок, когда силы уже на исходе.";
		base.WeightSubject = 0.6f;
		base.Doping = 1;
		base.Hunger = -4;
		base.TypeSubj = TypeSubject.OtherSubject;
	}
}
