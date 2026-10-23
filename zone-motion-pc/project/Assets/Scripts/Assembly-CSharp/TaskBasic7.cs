using UnityEngine;

public class TaskBasic7 : ConstructorTasks
{
	public TaskBasic7()
	{
		base.NameTask = "Брат";
		base.TextTask = "Привет, брат! Знаю, у тебя куча вопросов. Но ответы я могу дать, только на некоторые. Моя цель - окончательное уничтожение Выжигателя. Я добрался сюда, под предлогом его ремонта, по договоренности с Монолитом. Был почти у цели, но кто-то перебил отряды, южнее Радара и лабораторию запечатали. Добраться к оборудованию я не смог. У меня полная инструкция по ремонту Выжигателя и созданию его с нуля. Эта информация не должна попасть к Монолиту. Сохрани ее в безопасном месте. А сейчас выбираемся отсюда, здесь небезопасно... ";
		base.DescriptionTask = "Добраться до безопасного места.";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAbg();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/Mehanik");
	}
}
