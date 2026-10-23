using UnityEngine;

public class TaskDirectGroup2 : ConstructorTasks
{
	public TaskDirectGroup2()
	{
		base.NameTask = "Повышение";
		base.TextTask = "Твой авторитет в группировке растет. Ты можешь принять под свое руковдство несколько бойцов.";
		base.DescriptionTask = "Выбрать бойцов под свое упрадение.";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbs();
		base.RewardMoney = 0;
		if (Data.CharacterD.Count > 0)
		{
			base.ImageTask = Data.CharacterD[0].SuitChar.IconCharacter;
		}
		else
		{
			base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconStalkerSuit128");
		}
	}
}
