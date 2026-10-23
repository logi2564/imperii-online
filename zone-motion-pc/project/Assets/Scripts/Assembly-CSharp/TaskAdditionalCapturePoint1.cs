using UnityEngine;

public class TaskAdditionalCapturePoint1 : ConstructorTasks
{
	public TaskAdditionalCapturePoint1()
	{
		base.NameTask = "Награда за захват точки";
		base.TextTask = "Неплохо! Да ты прирожденный Штурмовик! Принимай награду, добротно отработано...";
		base.DescriptionTask = "...";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 500;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/QuestSubject/capturePoint");
		base.AdditionalTask = true;
	}
}
