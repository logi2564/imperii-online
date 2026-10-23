using UnityEngine;

public class AAAAAAAAAAAAAAAAAAAAbm : AAAAAAAAAAAAAAAy
{
	public AAAAAAAAAAAAAAAAAAAAbm()
	{
		base.NameSubject = "Морской ёж";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Artefacts/seahog");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
		base.CostSubject = 8000;
		base.DescriptionSubject = "Существенно увеличивает защиту и останавливает кровь. Ученые заметили, что состав этого формирования обладает критической стабильностью, и добиться создания такого артефакта в условиях лаборатории в ближайшие десятилетия нереально.";
		base.WeightSubject = 0.4f;
		base.TypeSubj = TypeSubject.Artefact;
		base.Protection = 8f;
		base.Bleeding = -3f;
		base.XrayNegatife = 2;
	}
}
