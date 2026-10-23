using UnityEngine;

public class AAAAAAAAAAAAAAAAAAbx : AAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAAAbx()
	{
		base.NameSubject = "Флешка погибшего сталкера";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Subject/flashdisc-film");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_ruck");
		base.CostSubject = 100;
		base.DescriptionSubject = "Содержит информацию, необходимую для лидера нейтралов на Агропроме";
		base.WeightSubject = 0.05f;
		base.TypeSubj = TypeSubject.QuestSubject;
	}
}
