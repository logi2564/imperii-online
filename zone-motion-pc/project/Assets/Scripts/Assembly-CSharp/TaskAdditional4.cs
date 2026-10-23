using UnityEngine;

public class TaskAdditional4 : ConstructorTasks
{
	public TaskAdditional4()
	{
		base.NameTask = "Награда ЧН";
		base.TextTask = "Спасибо, Братуха! У Чистого Неба всегда для тебя найдется кусок хлеба, теплый ночлег и веселая компания... Забеги на Тихий хутор на Складах, там тебя дожидается твое вознаграждение.";
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharChN_2_128");
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
	}
}
