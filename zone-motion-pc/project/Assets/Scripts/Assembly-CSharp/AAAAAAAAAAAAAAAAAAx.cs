using UnityEngine;

public class AAAAAAAAAAAAAAAAAAx : AAAAAAAAAAAAAAAy
{
	public AAAAAAAAAAAAAAAAAAx()
	{
		base.NameSubject = "Слизь";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Artefacts/slime");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
		base.CostSubject = 2000;
		base.DescriptionSubject = "При ношении его на поясе раны меньше кровоточат, что способствует скорейшему выздоровлению.";
		base.WeightSubject = 0.4f;
		base.TypeSubj = TypeSubject.Artefact;
		base.Bleeding = -2f;
		base.Sanitation = 1f;
	}
}
