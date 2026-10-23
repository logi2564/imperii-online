using UnityEngine;

public class AAAAAAAAAAAAAAbc : AAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAbc()
	{
		base.NameSubject = "Стопа снорка";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Subject/snorkleg");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_ruck");
		base.CostSubject = 1250;
		base.DescriptionSubject = "В отличии от человеческой, обладает большим количеством сухожилий...";
		base.WeightSubject = 0.4f;
		base.TypeSubj = TypeSubject.MutantsSubject;
	}
}
