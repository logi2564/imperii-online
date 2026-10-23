using UnityEngine;

public class TaskGlobalchemist8_5 : ConstructorTasks
{
	public TaskGlobalchemist8_5()
	{
		base.NameTask = "Вернуть ПДА";
		base.TextTask = "Чего тебе? Наш командир погиб и задание провалено, возвратится на базу в Мертвый город мы не смогли... Прибор? Он поврежден и уже не представляет никакой ценности. Ты получишь его только в обмен на ПДА нашего командира...";
		base.DescriptionTask = "Вернуть ПДА и забрать ПСИ-шлем";
		base.QuestSubject = new AAAAAAAAAAAAAAAbb();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharMersenary128");
		base.NamePointTask = "Старый завод";
		base.MapName = "DarkValley";
	}
}
