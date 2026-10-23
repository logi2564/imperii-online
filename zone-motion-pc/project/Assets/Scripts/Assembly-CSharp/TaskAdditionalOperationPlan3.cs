using UnityEngine;

public class TaskAdditionalOperationPlan3 : ConstructorTasks
{
	public TaskAdditionalOperationPlan3()
	{
		base.NameTask = "План военных у Одиночек";
		base.TextTask = "Привет, головорез.\nКак видно, навел ты шороху на базе военных. Доставленные тобой документы, сорвали план военных по зачистке агропрома от вольных сталкеров. В ближайшее время можно не опасаться нападения. А там, как карта ляжет, поживем увидим. Бывай.";
		base.DescriptionTask = "...";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconStalkerSuit128");
		base.AdditionalTask = true;
	}
}
