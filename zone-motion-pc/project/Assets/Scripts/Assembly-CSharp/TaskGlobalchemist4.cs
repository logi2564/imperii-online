using UnityEngine;

public class TaskGlobalchemist4 : ConstructorTasks
{
	public TaskGlobalchemist4()
	{
		base.NameTask = "К Радару";
		base.TextTask = "И что вам тут, медом помазано? Прибор ему подавай! Я выкупил это прибор за большие деньги. Он помогал моим бойцам при выполнении сложных заданий... До поры, до времени... Отряд, которому я его доверил пропал на Радаре. Больше я ничего не знаю. Проваливай...";
		base.DescriptionTask = "Двигаться на Радар";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/Dushman");
		base.NamePointTask = "Южный блокпост радара";
		base.MapName = "Radar";
	}
}
