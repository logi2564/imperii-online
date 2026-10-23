using UnityEngine;

public class TaskAdditionalSpareParts0 : ConstructorTasks
{
	public TaskAdditionalSpareParts0()
	{
		base.NameTask = "Детали у заказчика";
		base.TextTask = "Неожидал от тебя, паря, такой ловкости! Думал разорвут тебя бандиты! Бывай, мои ребятки тебя не тронут ... до поры... А если работенка нужна будет, приходи, обеспечим!";
		base.DescriptionTask = "...";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 1000;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharMersenary128");
		base.AdditionalTask = true;
		base.SubjectQuest = true;
		base.NamePointTask = "Мост в Лиманск";
		base.MapName = "RedForest";
	}
}
