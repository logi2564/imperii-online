using UnityEngine;

public class TaskAdditionalDutyKillBloodsuсker4 : ConstructorTasks
{
	public TaskAdditionalDutyKillBloodsuсker4()
	{
		base.NameTask = "Награда за кровососа";
		base.TextTask = "Молодчина!\nУложил-таки зверюгу!\nТеперь понятно, куда сталкеры пропадали. Печально, не вернешь их уже...\nПринимай награду, чистая работа!";
		base.DescriptionTask = "...";
		base.MapName = "Bar";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharPC3-9d2");
		base.AdditionalTask = true;
		base.GetToPointQuest = true;
	}
}
