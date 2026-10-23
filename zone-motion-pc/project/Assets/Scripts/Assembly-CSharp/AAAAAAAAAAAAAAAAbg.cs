using UnityEngine;

public class AAAAAAAAAAAAAAAAbg : AAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAbg()
	{
		base.NameSubject = "Схемы Выжигателя";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Subject/Case");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_ruck");
		base.CostSubject = 100000;
		base.DescriptionSubject = "Научная и техническая документация, содержит информацию о Выжигателе мозгов";
		base.WeightSubject = 1f;
		base.TypeSubj = TypeSubject.QuestSubject;
	}
}
