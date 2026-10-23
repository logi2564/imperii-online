using UnityEngine;

public class AAAAAAAAAAAAAAAAx : AAAAAAAAAAAAAAAAAAk
{
	public AAAAAAAAAAAAAAAAx()
	{
		base.NameSubject = "Водка";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Subject/vodka");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_ruck");
		base.CostSubject = 150;
		base.DescriptionSubject = "Обыкновенная водка. Вроде не паленая...";
		base.WeightSubject = 0.4f;
		base.TypeSubj = TypeSubject.OtherSubject;
		base.XRaySanitation = -1;
		base.Hunger = -2;
		base.Thirst = -1;
	}
}
