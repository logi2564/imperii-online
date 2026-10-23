using UnityEngine;

public class TaskAdditionalMercenaryGroup : ConstructorTasks
{
	public TaskAdditionalMercenaryGroup()
	{
		base.NameTask = "Пропавший отряд";
		base.TextTask = "Привет, " + PlayerPrefs.GetString("HeroName") + "! Работенка для тебя нашлась.\nОдин из наших отрядов пропал при выполнении очередной работы. Следа от них не осталось, будто сквозь землю провалились! Необходимо выяснить, что с ними случилось. Последний раз их видели в районе брошенного танка Т-64, в глубине Рыжего леса. И поторопись, дружище, возможно от твоей расторопности могут зависеть их жизни...";
		base.DescriptionTask = "Отыскать пропавший отряд наемников или информацию о нем.";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharMersenary128");
		base.AdditionalTask = true;
		base.NamePointTask = "Т-64";
		base.MapName = "RedForest";
	}
}
