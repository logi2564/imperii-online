using UnityEngine;

public class TaskAdditionalDutyKillBloodsuсker2 : ConstructorTasks
{
	public TaskAdditionalDutyKillBloodsuсker2()
	{
		base.NameTask = "Убить кровососа";
		base.TextTask = "Вот и хозяин станции нарисовался!\nОгроменный, как псевдогигант!\nУбежать, видимо не получится... Придется вступить в схватку.";
		base.DescriptionTask = "Убить кровососа в районе насосной станции, Бар.";
		base.NamePointTask = "Насосная станция";
		base.MapName = "Bar";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/Bloodsucker128");
		base.AdditionalTask = true;
		base.GetToPointQuest = true;
	}
}
