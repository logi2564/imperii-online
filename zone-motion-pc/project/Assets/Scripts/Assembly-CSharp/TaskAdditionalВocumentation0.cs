using UnityEngine;

public class TaskAdditionalВocumentation0 : ConstructorTasks
{
	public TaskAdditionalВocumentation0()
	{
		base.NameTask = "Найти информацию об экспериментах";
		base.TextTask = "Неплохо. Эти данные немного проливают свет на темные делишки ученых, но этого недостаточно. Еще не найдено все необходимые сведения. Получай заслуженную награду за найденное и снова за работу.";
		base.DescriptionTask = "Отыскать недостающие документы о деятельности лабораторий Х16 и Х18.";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 1000;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/Lebedev128");
		base.AdditionalTask = true;
		base.ManySubjectsQuest = true;
	}
}
