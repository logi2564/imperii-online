using UnityEngine;

public class TaskAdditionalMercenaryGroup1 : ConstructorTasks
{
	public TaskAdditionalMercenaryGroup1()
	{
		base.NameTask = "Сканер-расщепитель";
		base.TextTask = "Добрый день!\nВас прислал мой аспирант? Как продвигается исследование? Ну что же, запасное оборудование, конечно же, имеется... Однако передайте коллегам, что если и оно выйдет из строя из-за перегрузок, то все работы придется приостановить... В противном случае никто не решится предсказать результат эксперимента с попыткой расщепления материи. В конце концов, это может привести к новой катастрофе...";
		base.DescriptionTask = "Доставить: ";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAca();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/saharov128");
		base.AdditionalTask = true;
		base.SubjectQuest = true;
		base.NamePointTask = "Т-64";
		base.MapName = "RedForest";
	}
}
