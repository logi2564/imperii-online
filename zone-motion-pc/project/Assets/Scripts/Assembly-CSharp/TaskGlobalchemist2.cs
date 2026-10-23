using UnityEngine;

public class TaskGlobalchemist2 : ConstructorTasks
{
	public TaskGlobalchemist2()
	{
		base.NameTask = "Информация в Баре";
		base.TextTask = "Ну, Здорово! Я помню интересующего тебя сталкера. Он работал на меня какое-то время. Насколько я слышал, он ушел глубоко в зону... Ух и шум тогда поднялся! Я не знаю что с ним случилось, может Зона его поглотила... Направляйся в Бар на базу Долга, там еще остались сталкеры, знавшие его лично. У них ты найдешь больше информации о нем,  может и о своем чудо-приборе что узнаешь. Бывай...";
		base.DescriptionTask = "Собрать информацию у сталкеров в Баре, на базе Долга";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/Sidor128");
		base.NamePointTask = "База Долга";
		base.MapName = "Bar";
	}
}
