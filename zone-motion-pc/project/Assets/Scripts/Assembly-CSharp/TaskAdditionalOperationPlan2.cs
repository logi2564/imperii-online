using UnityEngine;

public class TaskAdditionalOperationPlan2 : ConstructorTasks
{
	public TaskAdditionalOperationPlan2()
	{
		base.NameTask = "Доставить план военных Одиночкам";
		base.TextTask = "Капитан, бывалый вояка, жаль парня, но в бою либо ты, либо тебя...\nСведения о боевой операции военных у Ширко в рюкзаке, теперь бы мигом найти в нем документы и бегом на ближайшую базу Одиночек. Сдается служивые так просто это дело не оставят...";
		base.DescriptionTask = "Найти у Капитана Ширко план операции доставить его на ближайшую базу одиночек.";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		if (Data.CharacterD.Count > 0)
		{
			base.ImageTask = Data.CharacterD[0].SuitChar.IconCharacter;
		}
		else
		{
			base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconStalkerSuit128");
		}
		base.AdditionalTask = true;
	}
}
