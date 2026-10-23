using UnityEngine;

public class AAAAAAAAAAAAAAAAAAAAAbr : AAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAAAAAAbr()
	{
		base.NameSubject = "Ящик с комбинезонами";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Subject/suitBox");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_ruck");
		base.CostSubject = 18000;
		base.DescriptionSubject = "Тяжёлый деревянный ящик с новыми комбинезонами. Таким количеством можно экипировать целый отряд. Бандиты интересуются подобными вещами.";
		base.WeightSubject = 6f;
		base.TypeSubj = TypeSubject.QuestSubject;
	}
}
