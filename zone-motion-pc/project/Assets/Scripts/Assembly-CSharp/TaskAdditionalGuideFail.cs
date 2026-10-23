using UnityEngine;

public class TaskAdditionalGuideFail : ConstructorTasks
{
	public TaskAdditionalGuideFail()
	{
		base.NameTask = "Заказчик погиб";
		base.TextTask = "Печален результат твоей работы. Заказчик погиб, так и работать не с кем будет...";
		base.DescriptionTask = "...";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.ImageTask = (Texture2D)Resources.Load("Sprites/QuestSubject/guide");
		base.RewardMoney = 0;
		base.AdditionalTask = true;
		base.GuideQuest = true;
	}
}
