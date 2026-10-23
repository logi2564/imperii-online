using UnityEngine;

public class TaskAdditionalBalans1 : ConstructorTasks
{
	public TaskAdditionalBalans1()
	{
		base.NameTask = "Награда за поддержку";
		base.TextTask = "Ну вот! Другое дело! Теперь мы их... Заглядивай на нашу базу. Получишь награду, снарягу поправишь,... тебе всегда рады.";
		base.DescriptionTask = "Получить награду за зачистку";
		base.BalansQuest = true;
		base.AdditionalTask = true;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/QuestSubject/supportFire");
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
	}
}
