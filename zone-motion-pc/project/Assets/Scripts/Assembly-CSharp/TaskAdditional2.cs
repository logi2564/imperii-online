using UnityEngine;

public class TaskAdditional2 : ConstructorTasks
{
	public TaskAdditional2()
	{
		base.NameTask = "Отряд ЧН";
		base.TextTask = "Привет, Сталкер! Отряд наемников?... Ну,... в общем,... было у нас задание из штаба, уничтожить эту группу. Что, по чем не знаю. Мое дело приказы выполнять. Тем более, что мы их не догнали. Да и вообще, знаешь ли, с наемниками, в последнее время, мы не очень то дружим... Механик? Нет не слышали. Из новостей вот еще что: - отряды Монолита в последнее время оживились. Разведку к Радару направили, но от нее пока ни слуха, ни духа. Если будешь в тех местах, передай, чтобы на связь вышли. Удачи тебе, сталкер.";
		base.DescriptionTask = "Встретиться с бойцами Чистого Неба на Радаре.";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbs();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharChN_1_128");
	}
}
