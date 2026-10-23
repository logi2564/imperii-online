using UnityEngine;

public class AAAAAAAAAAAAAAAAba : AAAAAAAAAAAAAAAy
{
	public AAAAAAAAAAAAAAAAba()
	{
		base.NameSubject = "Слюда";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Artefacts/sluda");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
		base.CostSubject = 8000;
		base.DescriptionSubject = "Останавливает кровотечение практически полностью. Крайне полезен в условиях зоны, к тому же его можно продать за хорошую цену.";
		base.WeightSubject = 0.4f;
		base.TypeSubj = TypeSubject.Artefact;
		base.Bleeding = -7f;
		base.Sanitation = 3f;
		base.XrayNegatife = 2;
	}
}
