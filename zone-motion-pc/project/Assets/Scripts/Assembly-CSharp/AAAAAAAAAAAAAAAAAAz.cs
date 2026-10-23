using UnityEngine;

public class AAAAAAAAAAAAAAAAAAz : AAAAAAAAAAAAAAAy
{
	public AAAAAAAAAAAAAAAAAAz()
	{
		base.NameSubject = "Медуза";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Artefacts/medusa");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
		base.CostSubject = 2000;
		base.DescriptionSubject = "Обладает положительными эффектами увеличения силы, защиты и остановки кровотечения.";
		base.WeightSubject = 0.4f;
		base.TypeSubj = TypeSubject.Artefact;
		base.Protection = 2.5f;
		base.Bleeding = -1f;
		base.Force = 3f;
	}
}
