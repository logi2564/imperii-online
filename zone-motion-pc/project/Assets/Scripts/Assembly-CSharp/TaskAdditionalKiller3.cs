using UnityEngine;

public class TaskAdditionalKiller3 : ConstructorTasks
{
	public TaskAdditionalKiller3()
	{
		base.NameTask = "Ликвидатор. Награда";
		base.TextTask = "Чистая работа. Держи обещаное. Будь на связи, может опять понадобится твои услуги, в скором времени...";
		base.DescriptionTask = "...";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 8000;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/QuestSubject/killer0");
		base.AdditionalTask = true;
		base.KillQuest = true;
	}
}
