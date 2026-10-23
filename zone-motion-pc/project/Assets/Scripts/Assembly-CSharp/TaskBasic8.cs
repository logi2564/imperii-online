using UnityEngine;

public class TaskBasic8 : ConstructorTasks
{
	public TaskBasic8()
	{
		base.NameTask = "Вечный Странник";
		base.TextTask = "Прости, брат. Я не закончил свое дело. До безопасного места ты доберешься и без меня. Ученым на янтаре требуется помощь опытного сталкера. Я думаю, ты справишься. Как выполнишь поручение экологов, я найду тебя. А сейчас, не пытайся следовать за мной или искать меня. До встречи.";
		base.DescriptionTask = "Добраться до бункера экологов.";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/Mehanik");
		base.NamePointTask = "Бункер ученых";
		base.MapName = "Amber";
	}
}
