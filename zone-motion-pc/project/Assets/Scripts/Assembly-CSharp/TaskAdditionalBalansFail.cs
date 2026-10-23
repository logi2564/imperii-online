using UnityEngine;

public class TaskAdditionalBalansFail : ConstructorTasks
{
	public TaskAdditionalBalansFail()
	{
		base.NameTask = "Провал задания группировки";
		base.TextTask = "Эк, ты, размазня! Пока ты раскачаешься, враги сами передохнут! В следующий раз, будь расторопней... И загляни к нам на базу, есть для тебя кое-что...";
		base.DescriptionTask = "Зайти на базу заказчика";
		base.AdditionalTask = true;
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.ImageTask = (Texture2D)Resources.Load("Sprites/QuestSubject/supportFire");
	}
}
