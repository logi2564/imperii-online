using UnityEngine;

public class AAAAAAAAAAAAAAAAAAbr : AAAAAAAAAAAAAAAy
{
	public AAAAAAAAAAAAAAAAAAbr()
	{
		base.NameSubject = "Колючка";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Artefacts/koluchka");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
		base.CostSubject = 2000;
		base.DescriptionSubject = "Увеличивает защиту и немного останавливает кровь.";
		base.WeightSubject = 0.4f;
		base.TypeSubj = TypeSubject.Artefact;
		base.Protection = 4f;
		base.Bleeding = -1f;
	}
}
