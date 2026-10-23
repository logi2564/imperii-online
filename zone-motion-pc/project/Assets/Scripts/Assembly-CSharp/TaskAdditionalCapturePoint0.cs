using UnityEngine;

public class TaskAdditionalCapturePoint0 : ConstructorTasks
{
	public TaskAdditionalCapturePoint0()
	{
		base.NameTask = "Захватить точку";
		base.TextTask = "Командование поставило задачу - расширить зону влияния нашей группировки. Твоя задача установить контроль на одной из близлежащих точек.";
		base.DescriptionTask = "Захватить точку: ";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/QuestSubject/capturePoint");
		base.AdditionalTask = true;
		base.CaptureQuest = true;
	}
}
