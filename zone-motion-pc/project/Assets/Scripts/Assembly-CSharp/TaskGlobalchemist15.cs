using UnityEngine;

public class TaskGlobalchemist15 : ConstructorTasks
{
	public TaskGlobalchemist15()
	{
		base.NameTask = "Путь на Скадовск";
		base.TextTask = "Привет сталкер! У некоторых группировок отношение ко мне, мягко говоря, недружелюбное. Узнав о том, что ты меня выручил, они разорвут с тобой отношения. Но, я обязан тебе своим спасением и буду сопровождать до тех пор, пока это будет необходимо. Раз уж тебе так нужно попасть в инструментальный цех, то я доставлю тебя к нему, но есть одна проблема. Цех запечатан электронным замком, чтобы его открыть, необходима ключ-карта. На Скадовске сталкеры подскажут, где ее можно раздобыть.";
		base.DescriptionTask = "Найти нформацию о ключ-карте на Скадовске";
		base.QuestSubject = new AAAAAAAAAAAAAAAAw();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharChN_1_128");
		base.NamePointTask = "Скадовск";
		base.MapName = "Backwater";
	}
}
