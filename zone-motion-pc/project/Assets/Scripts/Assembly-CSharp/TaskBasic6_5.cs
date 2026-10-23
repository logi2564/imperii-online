using UnityEngine;

public class TaskBasic6_5 : ConstructorTasks
{
	public TaskBasic6_5()
	{
		base.NameTask = "Поиск на Радаре";
		base.TextTask = "Таких трудов стоило сюда добраться! И кроме бойцов Монолита - ни души! Но ведь, сюда он шел, значит здесь он где-то. На Радаре его и надо искать...";
		base.DescriptionTask = "Искать Механика на Радаре.";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		if (Data.CharacterD.Count > 0)
		{
			base.ImageTask = Data.CharacterD[0].SuitChar.IconCharacter;
		}
		else
		{
			base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/x18");
		}
		base.NamePointTask = "Вход в подземный бункер";
		base.MapName = "Radar";
	}
}
