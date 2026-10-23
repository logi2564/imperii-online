using UnityEngine;

public class TaskAdditionalMercenarySchemeOfBurner1 : ConstructorTasks
{
	public TaskAdditionalMercenarySchemeOfBurner1()
	{
		base.NameTask = "Схемы у наемников";
		base.TextTask = "Ну дела! Достал таки! Я думаю, с тобой можно иметь дело. Принимай оплату... Как появится стоящая работенка, для тебя придержу. Бывай.";
		base.DescriptionTask = "...";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 20000;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharMersenary128");
		base.AdditionalTask = true;
		base.SubjectQuest = true;
	}
}
