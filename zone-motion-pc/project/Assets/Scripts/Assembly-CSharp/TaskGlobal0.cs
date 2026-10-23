using UnityEngine;

public class TaskGlobal0 : ConstructorTasks
{
	public TaskGlobal0()
	{
		base.NameTask = "Найти Механика";
		base.TextTask = "Ну вот не сиделось ему в бункере экологов, ... тепло, ... спокойно, ...платили хорошо, военные работенку подкидывали. Паяй свои микросхемы, да ремонтируй, что дадут. Так нет, рванул он куда-то... И вот сказал бы, что ли! Куда? Зачем? На сколько?";
		base.DescriptionTask = "Найти Механика или информацию о нем.";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharJacket128");
	}
}
