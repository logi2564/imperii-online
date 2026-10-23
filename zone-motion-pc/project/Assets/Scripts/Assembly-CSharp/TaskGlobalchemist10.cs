using UnityEngine;

public class TaskGlobalchemist10 : ConstructorTasks
{
	public TaskGlobalchemist10()
	{
		base.NameTask = "ПСИ-шлем на базе";
		base.TextTask = "Да, да? Это вы мой друг! Как продвигаются поиски? Вы нашли прототип! Действительно этот прибор помогает сопротивляться ПСИ-излучению. Он уникален и в недобрых руках может доставить много бед обитателям зоны, сталкерам, и в конце концов, науке. К сожалению прибор сильно поврежден и потребуется много времени на его востановление. В любом случае мы вам очень признательны, а вас за пределами бункера ожидает наш сталкер.";
		base.DescriptionTask = "Свободное перемещение по зоне";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 30000;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/saharov128");
		base.NamePointTask = "Бункер ученых";
		base.MapName = "Amber";
	}
}
