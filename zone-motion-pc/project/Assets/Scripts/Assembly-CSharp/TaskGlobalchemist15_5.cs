using UnityEngine;

public class TaskGlobalchemist15_5 : ConstructorTasks
{
	public TaskGlobalchemist15_5()
	{
		base.NameTask = "Найти Фокса";
		base.TextTask = "Здорово, заходи, заходи... Каким ветром тебя занесло вглубь Зоны? Испытательный цех... Ключ-карта? Помнится, был у нас техник, жуткий пьяница, к слову говоря, так вот в похмельном бреду он что-то говорил об электронном ключе, который у него выкрал один из бандитов, кажется, его звали Фокс. Поспрашивай о нем на ''Шевченко'', но будь осторожен, бандиты - народ ненадежный. Удачи тебе.";
		base.DescriptionTask = "Добраться до ''Шевченко'' и найти Фокса";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/Beard128");
		base.NamePointTask = "Шевченко";
		base.MapName = "Backwater";
	}
}
