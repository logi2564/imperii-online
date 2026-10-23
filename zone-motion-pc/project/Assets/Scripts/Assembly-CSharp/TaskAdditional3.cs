using UnityEngine;

public class TaskAdditional3 : ConstructorTasks
{
	public TaskAdditional3()
	{
		base.NameTask = "Огневая поддержка";
		base.TextTask = "О как! Ты кто еще такой? Откуда еще взялся? ... Вольный сталкер говоришь? У нас тут проблемки небольшие... Бойцы Монолита и так спокойствием не отличались, а тут вообще озверели... Восточнее нас отряд наемников стоит, шмаляют во все стороны, без разбору. Помощь запросить тоже не могу, кто-то канал глушит. В общем, обложили нас плотно. Такие дела... Нам бы наемников выбить, а там и путь к складам, и к базе Монолита откроется. Глядишь, и подмога подоспеет. Подсоби наемников размазать? Сами они от радиации к праотцам отправятся или ты им поможешь, неважно. Мы уж в долгу не останемся?";
		base.DescriptionTask = "Уничтожить отряд наемников.";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAy();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharChN_2_128");
	}
}
