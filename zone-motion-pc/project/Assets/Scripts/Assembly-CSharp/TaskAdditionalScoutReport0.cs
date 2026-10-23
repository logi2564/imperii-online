using UnityEngine;

public class TaskAdditionalScoutReport0 : ConstructorTasks
{
	public TaskAdditionalScoutReport0()
	{
		base.NameTask = "Отчет разведчиков";
		base.TextTask = "Печально. Ребятки сделали свое дело, но заплатили за это своими жизнями... Спасибо тебе за помощь, сталкер. Я доложил командованию о твоей помощи и теперь наши бойцы перестанут тебя атаковать. Заглядывай к нам, может быть еще найдется для тебя работенка. Может со временем ты станешь Военным Сталкером...";
		base.DescriptionTask = "...";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 2000;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharBerill128");
	}
}
