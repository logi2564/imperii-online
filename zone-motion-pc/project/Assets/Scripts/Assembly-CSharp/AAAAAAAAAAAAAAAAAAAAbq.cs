using UnityEngine;

public class AAAAAAAAAAAAAAAAAAAAbq : AAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAAAAAbq()
	{
		base.NameSubject = "Декодер";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Subject/decoder");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_ruck");
		base.CostSubject = 1000;
		base.DescriptionSubject = "Нечто вроде мощной электронной отмычки. Похоже, создан с целью взломать какой-то специфический электронный замок. Как ни странно, конструкция не подразумевает универсальности - он создавался для вскрытия конкретного замка. Бывалые сталкеры поговаривали, что Монолит охотился за подобными устройствами.";
		base.WeightSubject = 0.3f;
		base.TypeSubj = TypeSubject.QuestSubject;
	}
}
