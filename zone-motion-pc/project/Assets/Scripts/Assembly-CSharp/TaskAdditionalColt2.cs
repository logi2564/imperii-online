using UnityEngine;

public class TaskAdditionalColt2 : ConstructorTasks
{
	public TaskAdditionalColt2()
	{
		base.NameTask = "Кольт";
		base.TextTask = "Что с антирадами? Добыл? Молодчина!\nКак говорится: Уговор, дороже денег! Держи игрушку и тащи к хозяину, нам она без надобности.\nЕсли работенка нужна будет, давай к нам! Свободные руки всегда пригодятся...";
		base.DescriptionTask = "Доставить кольт в Ангар на Свалке.";
		base.NamePointTask = "Ангар";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharPC596_128");
		base.AdditionalTask = true;
		base.GetToPointQuest = true;
	}
}
