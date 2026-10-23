using UnityEngine;

public class AAAAAAAAAAAAAAAAAbc : AAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAAbc()
	{
		base.NameSubject = "Копыто кабана";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Subject/kabanleg");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_ruck");
		base.CostSubject = 800;
		base.DescriptionSubject = "Испольуется учеными для изготовления ряда лекарств, одно из которых - противорадиационные препараты.";
		base.WeightSubject = 0.4f;
		base.TypeSubj = TypeSubject.MutantsSubject;
	}
}
