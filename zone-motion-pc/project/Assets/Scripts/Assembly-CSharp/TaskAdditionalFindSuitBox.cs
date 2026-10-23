using UnityEngine;

public class TaskAdditionalFindSuitBox : ConstructorTasks
{
	public TaskAdditionalFindSuitBox()
	{
		base.NameTask = "Доставить партию комбинезонов";
		base.TextTask = "Для полного счастья братве снаряги не хватает. Комбинезоны сносные добыть придется, а коли сделаешь, то тогда с вояками потягаться сможем!";
		base.DescriptionTask = "Принести ";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharCloak128");
		base.AdditionalTask = true;
		base.SubjectQuest = true;
	}
}
