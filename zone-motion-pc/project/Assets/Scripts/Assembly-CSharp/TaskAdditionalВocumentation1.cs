using UnityEngine;

public class TaskAdditionalВocumentation1 : ConstructorTasks
{
	public TaskAdditionalВocumentation1()
	{
		base.NameTask = "Иформация об экспериментах";
		base.TextTask = "Ну что же. Теперь мы имеем представление о деятельности этих, с позволения сказать ученых.\nКак видно, их вдохновляло, отнюдь не стремление к науке, а жажда неограниченной власти и как следствие наживы. Кто знает, чем это могло закончиться, если бы эксперименты не вышли из под контроля.\nНадеюсь, обитатели научных бункеров на Янтаре и Юпитере, не последуют их примеру...";
		base.DescriptionTask = "...";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 3000;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/Lebedev128");
		base.AdditionalTask = true;
		base.ManySubjectsQuest = true;
	}
}
