using UnityEngine;

public class TaskAdditionalFindSuitBox0 : ConstructorTasks
{
	public TaskAdditionalFindSuitBox0()
	{
		base.NameTask = "Братва экипирована";
		base.TextTask = "От души тебе... Ой времена настанут! Как поговаривал Женя Гардероб: Была власть советская, а стала соловетская! Не жизнь - малина! Теперь Бугор тебя уж точно в бригаду примет.";
		base.DescriptionTask = string.Empty;
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 5000;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharCloak128");
		base.AdditionalTask = true;
		base.SubjectQuest = true;
	}
}
