using UnityEngine;

public class AAAAAAAAAAAAAAAbb : AAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAbb()
	{
		base.NameSubject = "ПДА наемника";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Subject/pda");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_ruck");
		base.CostSubject = 1000;
		base.DescriptionSubject = "Содержит информацию о задачах отряда наемнмков";
		base.WeightSubject = 0.2f;
		base.TypeSubj = TypeSubject.QuestSubject;
	}
}
