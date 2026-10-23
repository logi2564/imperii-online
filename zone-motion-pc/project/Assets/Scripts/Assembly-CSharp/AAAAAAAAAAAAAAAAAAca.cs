using UnityEngine;

public class AAAAAAAAAAAAAAAAAAca : AAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAAAca()
	{
		base.NameSubject = "Сканер-расщепитель";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Subject/ScannerSplitter");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_ruck");
		base.CostSubject = 10000;
		base.DescriptionSubject = "Научное оборудование, точное назначение и принцип работы которого известно только ученым, его сконструировавшим.";
		base.WeightSubject = 1f;
		base.TypeSubj = TypeSubject.QuestSubject;
	}
}
