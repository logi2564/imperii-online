using UnityEngine;

public class AAAAAAAAAAAAAAAAu : AAAAAAAAAAAAAAAy
{
	public AAAAAAAAAAAAAAAAu()
	{
		base.NameSubject = "Выверт";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Artefacts/vivert");
		base.CostSubject = 2000;
		base.DescriptionSubject = "При контакте с телом, помогает заживлению ран и немного улучшает защиту";
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
		base.WeightSubject = 0.4f;
		base.TypeSubj = TypeSubject.Artefact;
		base.Sanitation = 1f;
		base.Protection = 5f;
	}
}
