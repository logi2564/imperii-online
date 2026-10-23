using UnityEngine;

public class AAAAAAAAAAAAAAAz : AAAAAAAAAAAAAAAy
{
	public AAAAAAAAAAAAAAAz()
	{
		base.NameSubject = "Слизняк";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Artefacts/slimer");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
		base.CostSubject = 4000;
		base.DescriptionSubject = "Негативные свойства этого артефакта компенсируются тем, что он повышает свёртываемость крови. Такой артефакт нечасто можно встретить, и за него дают неплохую цену.";
		base.WeightSubject = 0.4f;
		base.TypeSubj = TypeSubject.Artefact;
		base.Bleeding = -4f;
		base.Sanitation = 2f;
		base.XrayNegatife = 1;
	}
}
