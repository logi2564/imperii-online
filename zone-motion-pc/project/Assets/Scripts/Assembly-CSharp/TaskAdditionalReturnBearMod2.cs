using UnityEngine;

public class TaskAdditionalReturnBearMod2 : ConstructorTasks
{
	public TaskAdditionalReturnBearMod2()
	{
		base.NameTask = "Возвращение хабара сталкеров";
		base.TextTask = "Тайник найден, осталось его обыскать и доставить найденное на ближайшую базу одиночек, и как можно скорее. Что-то подсказывает мне, что местечко, между базами враждующих группировок, по определению не может быть спокойным.";
		base.DescriptionTask = "Доставить остатки хабара на ближайшую базу одиночек.";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		if (Data.CharacterD.Count > 0)
		{
			base.ImageTask = Data.CharacterD[0].SuitChar.IconCharacter;
		}
		else
		{
			base.ImageTask = (Texture2D)Resources.Load("Sprites/QuestSubject/netrals0");
		}
		base.AdditionalTask = true;
	}
}
