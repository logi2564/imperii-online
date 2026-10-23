using UnityEngine;

public class TaskGlobalchemist14 : ConstructorTasks
{
	public TaskGlobalchemist14()
	{
		base.NameTask = "Артефакт для Хищника";
		base.TextTask = "Привет! Милости просим, если с миром пришел. Да ты ищешь нашего командира! Дела, значит такие, при выполнении очередной задачи он был сильно ранен. Чтобы сохранить ему жизнь мы доставили его до ближайшего укрытия, и буквально обложили его артефактами, поддерживающими в нем остатки жизни. Оставить его на погибель мы не можем, но и помощи ждать неоткуда. В сознание он не приходит. Необходим артефакт, быстро заживляющий раны. Бывалые сталкеры рассказывали об одном из таких чудо-артефактов, сильнейшем в своем роде. Они называли его - ''Душа''. Необходимо его найти и доставить Хищнику, это его последний шанс выжить...";
		base.DescriptionTask = "Доставить Хищнику артефакт ''Душа''";
		base.QuestSubject = new AAAAAAAAAAAAAAAAw();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharChN_2_128");
		base.NamePointTask = "Аномальная поляна";
		base.MapName = "RedForest";
	}
}
