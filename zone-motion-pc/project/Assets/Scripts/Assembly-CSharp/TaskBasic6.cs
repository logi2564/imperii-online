using UnityEngine;

public class TaskBasic6 : ConstructorTasks
{
	public TaskBasic6()
	{
		base.NameTask = "Радар";
		base.TextTask = "Привет, " + PlayerPrefs.GetString("HeroName") + "! Сколько лет, сколько зим... Слышал ты завел тесную дружбу с Долгом? Чего тебе нужно? ... Выжигатель?!... Включить? Ну дела! Ни догнать, ни остановить мы его уже не сможем - барьер отбил отряд Монолита. Ты можешь попробовать протиснуться в одиночку. Бывай.";
		base.DescriptionTask = "Пробраться на Радар.";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/LiderFreedom");
		base.NamePointTask = "База выжигателя";
		base.MapName = "Radar";
	}
}
