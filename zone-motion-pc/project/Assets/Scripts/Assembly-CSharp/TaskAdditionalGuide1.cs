using UnityEngine;

public class TaskAdditionalGuide1 : ConstructorTasks
{
	public TaskAdditionalGuide1()
	{
		base.NameTask = "Проводник";
		base.TextTask = "Один персонаж запрашивает помощь. Ему требуется проводник и телохранитель, чтобы добраться до нужного места... ";
		base.DescriptionTask = "Провести персонажа до цели. Персонаж должен выжить.";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/QuestSubject/guide");
		base.AdditionalTask = true;
		base.GuideQuest = true;
	}
}
