using UnityEngine;

public class TaskGlobalchemist18_7 : ConstructorTasks
{
	public TaskGlobalchemist18_7()
	{
		base.NameTask = "Противник уничтожен";
		base.TextTask = "Привет, брат! Я так понимаю - славная была охота... Изрядно вас бандиты потрепали. Главное, что живы остались. Теперь о делах. Схемы можешь передать любой из группировок, взамен получишь деньги и высокую репутацию, сможешь вступить в нее. Распорядись схемами по своему усмотрению, а я скоро тебя найду. До встречи, брат.";
		base.DescriptionTask = string.Empty;
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/Mehanik");
		base.MapName = "Backwater";
	}
}
