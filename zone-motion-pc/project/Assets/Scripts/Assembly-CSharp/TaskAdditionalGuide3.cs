using UnityEngine;

public class TaskAdditionalGuide3 : ConstructorTasks
{
	public TaskAdditionalGuide3()
	{
		base.NameTask = "Бывай...";
		base.TextTask = "Спасибо, за помощь, сталкер! ...";
		base.DescriptionTask = "...";
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/QuestSubject/bye");
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
	}
}
