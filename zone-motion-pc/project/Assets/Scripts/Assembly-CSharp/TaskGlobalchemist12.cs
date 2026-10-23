using UnityEngine;

public class TaskGlobalchemist12 : ConstructorTasks
{
	public TaskGlobalchemist12()
	{
		base.NameTask = "Выбить Ренегатов с болот";
		base.TextTask = "Привет, сталкер. Мы не скажем тебе ни слова о своих людях, до тех пор, пока не убедимся в чистоте твоих намерений. Давай так, ты помогаешь уничтожить всех Ренегатов с болот, а там посмотрим...";
		base.DescriptionTask = "Выбыть Ренегатов с болот";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharChN_1_128");
		base.NamePointTask = "База Чистого Неба";
		base.MapName = "Marsh";
	}
}
