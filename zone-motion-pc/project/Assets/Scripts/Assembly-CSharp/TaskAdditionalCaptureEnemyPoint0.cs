using UnityEngine;

public class TaskAdditionalCaptureEnemyPoint0 : ConstructorTasks
{
	public TaskAdditionalCaptureEnemyPoint0()
	{
		base.NameTask = "Захватить враждебную точку";
		base.TextTask = "Командование поставило задачу - выбить противника с занятой позиции. Твоя задача установить контроль на точке, при необходимости уничтожить бойцов противника.";
		base.DescriptionTask = "Захватить точку: ";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/QuestSubject/capturePoint");
		base.AdditionalTask = true;
		base.CaptureQuest = true;
	}
}
