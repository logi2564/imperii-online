using UnityEngine;

public class TaskAdditionalKiller2 : ConstructorTasks
{
	public TaskAdditionalKiller2()
	{
		base.NameTask = "Объект уничтожен";
		base.TextTask = "Ну дела! Справился! Да ты опасный тип! Оплату получишь на базе. Я свяжусь с тобой, когда потребуется.";
		base.DescriptionTask = "Убрать человека. Цель: ";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/QuestSubject/killer0");
		base.AdditionalTask = true;
		base.KillQuest = true;
	}
}
