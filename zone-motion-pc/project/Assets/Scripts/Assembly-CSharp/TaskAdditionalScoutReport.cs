using UnityEngine;

public class TaskAdditionalScoutReport : ConstructorTasks
{
	public TaskAdditionalScoutReport()
	{
		base.NameTask = "Найти отряд разведчиков";
		base.TextTask = "Командование отправило группу разведчиков на Радар, после последнего выброса они перестали выходить на связь. Задача отряда: составить подробный отчет о численности противника на Радаре, его расположении... Твоя задача: найти пропавший отряд разведчиков, живыми или мертвыми, и доставить доклад на ближайшую точку, подконтрольную военным. Если ты согласишься, мои люди перестанут тебя атаковать. Выполняй поручение или проваливай!";
		base.DescriptionTask = "Принести отчет разведчиков";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharBerill128");
		base.AdditionalTask = true;
	}
}
