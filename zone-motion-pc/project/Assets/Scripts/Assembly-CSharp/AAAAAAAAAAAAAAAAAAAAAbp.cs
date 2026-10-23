using UnityEngine;

public class AAAAAAAAAAAAAAAAAAAAAbp : AAAAAAAAAAAAAAAAAAk
{
	public AAAAAAAAAAAAAAAAAAAAAbp()
	{
		base.NameSubject = "Колбаса";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Subject/kolbasa");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_ruck");
		base.CostSubject = 50;
		base.DescriptionSubject = "Дешевая колбаса из смеси соевого заменителя и курятины. За неимением лучшего сойдет...";
		base.WeightSubject = 0.3f;
		base.Sanitation = 0f;
		base.TypeSubj = TypeSubject.OtherSubject;
		base.Hunger = 20;
		base.Thirst = 0;
	}
}
