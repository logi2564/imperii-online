using UnityEngine;

public class TaskAdditionalEmptySubj2 : ConstructorTasks
{
	public TaskAdditionalEmptySubj2()
	{
		base.NameTask = "Получить вознаграждение";
		base.TextTask = "Хороший товар - хорошие деньги. До встречи, сталкер.";
		base.DescriptionTask = "...";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/Subject/Money");
		base.AdditionalTask = true;
		base.SubjectQuest = true;
	}
}
