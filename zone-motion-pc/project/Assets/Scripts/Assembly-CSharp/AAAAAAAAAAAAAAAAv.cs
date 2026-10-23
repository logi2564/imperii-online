using UnityEngine;

public class AAAAAAAAAAAAAAAAv : AAAAAAAAAAAAAAAy
{
	public AAAAAAAAAAAAAAAAv()
	{
		base.NameSubject = "Грави";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Artefacts/gravy");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
		base.CostSubject = 4000;
		base.DescriptionSubject = "При ношении, раны затягиваются быстрее, увеличивает защиту.";
		base.WeightSubject = 0.4f;
		base.TypeSubj = TypeSubject.Artefact;
		base.Sanitation = 2f;
		base.Protection = 8f;
		base.XrayNegatife = 1;
	}
}
