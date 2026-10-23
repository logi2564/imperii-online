using UnityEngine;

public class TaskBasic5 : ConstructorTasks
{
	public TaskBasic5()
	{
		base.NameTask = "База Свободы";
		base.TextTask = "Достал ты меня порядком, парень! Чего ты хочешь? Мы не распространяем информацию о заказчиках... Спокойно, спокойно, ... Инженер? Хм... Да его звали Механик. За хорошую плату он согласился отыскать какие-то документы в лабораториях. Мы его только сопровождали, а расстались мы на армейских складах. Там его встретила другая группа, кто они я не знаю... И,... знаешь ли, не ты один его ищешь. Все это время, по пятам, за нами шли бойцы Чистого Неба. Мы не стали их дожидаться и расспрашивать в чем дело. Ну, и наконец, отряд Свободы атаковал нас, при встрече на складах.";
		base.DescriptionTask = "Поговорить с лидером Свободы.";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/Dushman");
		base.NamePointTask = "Штаб военной базы";
		base.MapName = "Military";
	}
}
