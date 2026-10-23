using UnityEngine;

public class AAAAAAAAAAAAAAAAAAbv : AAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAAAbv()
	{
		base.NameSubject = "Рука зомби";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Subject/zombiehand");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_ruck");
		base.CostSubject = 1200;
		base.DescriptionSubject = "Практической пользы не представляет, однако ее можно продать ученым...";
		base.WeightSubject = 0.3f;
		base.TypeSubj = TypeSubject.MutantsSubject;
	}
}
