using UnityEngine;

public class TaskAdditionalGuide2 : ConstructorTasks
{
	public TaskAdditionalGuide2()
	{
		base.NameTask = "Заказчик на месте";
		base.TextTask = "Спасибо, братан! Выручил! Если бы не твоя помощь, не добраться бы мне до этого места. Твоя награда ждет тебя на базе. Бывай, может свидимся еще.";
		base.DescriptionTask = "...";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/QuestSubject/guide");
		base.AdditionalTask = true;
	}
}
