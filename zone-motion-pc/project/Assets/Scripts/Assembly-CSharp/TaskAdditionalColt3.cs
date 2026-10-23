using UnityEngine;

public class TaskAdditionalColt3 : ConstructorTasks
{
	public TaskAdditionalColt3()
	{
		base.NameTask = "Кольт сталкера";
		base.TextTask = "Вот, молодчина! Нашел таки!\nВещица дорога как память! Славные были денечки...\nА ты, как я посмотрю, шустрый парень! Бьюсь об заклад, иголку в стоге сена найдешь, и без всяких преувеличений! Держи взамен... артефакт, он хоть и распространен повсеместно, но всегда пригодится!\nКак будешь на нашей базе, заходи, твоя помощь всегда пригодится...";
		base.DescriptionTask = "Доставить кольт в Ангар на Свалке.";
		base.NamePointTask = "Ангар";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconStalkerSuit128");
		base.AdditionalTask = true;
		base.GetToPointQuest = true;
	}
}
