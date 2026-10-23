using UnityEngine;

public class AAAAAAAAAAAAAAAAAAcb : AAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAAAcb()
	{
		base.NameSubject = "Ящик динамита";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Subject/dinamit");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_ruck");
		base.CostSubject = 3000;
		base.DescriptionSubject = "Тяжёлый деревянный ящик, с надписями ''Взрывоопасно'' на нескольких языках. Колоссальная мощность взрыва содержимого, сравнится с авиационной бомбой. Бандиты интересуются подобными вещами.";
		base.WeightSubject = 4f;
		base.TypeSubj = TypeSubject.QuestSubject;
	}
}
