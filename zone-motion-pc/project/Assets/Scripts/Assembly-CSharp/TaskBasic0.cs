using UnityEngine;

public class TaskBasic0 : ConstructorTasks
{
	public TaskBasic0()
	{
		base.NameTask = "Старый скряга";
		base.TextTask = "Теперь вот бегай по всей Зоне! Ищи, свищи! Да что уж там... Необходимо добыть сносную экипировку для глубокого похода в Зону. ... Проведаю старого скрягу в деревне сталкеров.";
		base.DescriptionTask = "Добраться до деревни новичков.";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharJacket128");
		base.NamePointTask = "Деревня новичков";
		base.MapName = "Kordon";
	}
}
