using UnityEngine;

public class TaskAdditionalBalans2 : ConstructorTasks
{
	public TaskAdditionalBalans2()
	{
		base.NameTask = "До встречи...";
		base.TextTask = "Спасибо, за помощь, сталкер! Заглядывай к нам, здесь тебе всегда рады!";
		base.DescriptionTask = "...";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAAbg();
		base.RewardMoney = 3000;
		base.AdditionalTask = true;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/QuestSubject/supportFire");
	}
}
