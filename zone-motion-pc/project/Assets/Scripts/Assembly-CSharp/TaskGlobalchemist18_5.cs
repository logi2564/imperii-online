using UnityEngine;

public class TaskGlobalchemist18_5 : ConstructorTasks
{
	public TaskGlobalchemist18_5()
	{
		base.NameTask = "Засада";
		base.TextTask = "Фокс: ''Ну, привет, горемычные! Нашли, что искали? Тогда стволы на землю и выворачивай карманы по одному, а не то проделаю в башке пару новых дырок... Всю черную работу вы за меня сделали, а гонорара за схемы мне хватит на всю оставшуюся жизнь... Подорвали, пацаны!''";
		base.DescriptionTask = string.Empty;
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharBandinVeteran128");
		base.NamePointTask = "Испытательный цех";
		base.MapName = "Backwater";
	}
}
