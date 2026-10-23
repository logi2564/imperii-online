using UnityEngine;

public class TaskAdditionalGuide2_5 : ConstructorTasks
{
	public TaskAdditionalGuide2_5()
	{
		base.NameTask = "Награда проводника";
		base.TextTask = "Ты выручил моего человека. Заказчик доволен, я тебе благодарен. Держи, заслуженная награда...";
		base.DescriptionTask = "...";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 1500;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/QuestSubject/guide");
		base.AdditionalTask = true;
	}
}
