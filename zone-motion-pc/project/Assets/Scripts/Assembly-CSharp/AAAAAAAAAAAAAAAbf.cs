using UnityEngine;

public class AAAAAAAAAAAAAAAbf : AAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAbf()
	{
		base.NameSubject = "Планшет капитана Ширко";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Subject/tablet");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_ruck");
		base.CostSubject = 3000;
		base.DescriptionSubject = "Старый потертый офицерский планшет. Содержит план боевой операции военных на агропроме.";
		base.WeightSubject = 0.03f;
		base.TypeSubj = TypeSubject.QuestSubject;
	}
}
