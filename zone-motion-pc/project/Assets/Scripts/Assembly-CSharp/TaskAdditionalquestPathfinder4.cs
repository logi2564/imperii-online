using UnityEngine;

public class TaskAdditionalquestPathfinder4 : ConstructorTasks
{
	public TaskAdditionalquestPathfinder4()
	{
		base.NameTask = "Добраться до аномальной трясины";
		base.TextTask = "Спасибо, дружище, теперь я на Кордон, раны зализывать.\nБез твоей помощи, мои извилины, спеклись бы безвозвратно. В награду, можешь забрать мою счастливую куртку из аномалии в Аномальная трясине. Куртка эта не простая, пролежав долгое время в аномалии, она обрела свойство ускорять метаболизм, тем самым помогает быстрее затягивать раны. К тому же в ней установлен контейнер для артефактов. Ни в жизнь бы с ней не расстался, но для тебя не пожалею. Бывай, брат.";
		base.DescriptionTask = "Добраться до аномальной трясины, Свалка. Найти в аномалии куртку.";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconZombySuit128");
		base.AdditionalTask = true;
	}
}
