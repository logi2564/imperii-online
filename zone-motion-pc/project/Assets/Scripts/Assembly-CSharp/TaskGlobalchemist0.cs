using UnityEngine;

public class TaskGlobalchemist0 : ConstructorTasks
{
	public TaskGlobalchemist0()
	{
		base.NameTask = "Найти утерянный прибор";
		base.TextTask = "Некоторое время назад мы сделали прототип полезнейшего прибора. Мы назвали его - ПСИ-шлем. Этот прибор был передан для испытаний одному сталкеру и утерян при невыясненных обстоятельствах. Необходимо отыскать и доставить этот прототип обратно. На его поиски уже отправляли военных, наемников, и сталкеров, но успеха это не принесло. Последний кто видел и использовал утерянный прототип, был сталкером - одиночкой. На Кордоне, на базе Одиночек, сталкеры просто обязаны знать о нем хоть что-то...";
		base.DescriptionTask = "Найти утерянный ПСИ-шлем или информацию о нем.";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconEcolog128");
		base.NamePointTask = "Деревня новичков";
		base.MapName = "Kordon";
	}
}
