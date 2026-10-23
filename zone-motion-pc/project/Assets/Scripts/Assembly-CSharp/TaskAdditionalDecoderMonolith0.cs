using UnityEngine;

public class TaskAdditionalDecoderMonolith0 : ConstructorTasks
{
	public TaskAdditionalDecoderMonolith0()
	{
		base.NameTask = "Декодер доставлен";
		base.TextTask = "Ты делаешь успехи! Братья довольны твоей работой. Отдохни, почини снаряжение. Скоро твоя помощь опять может понадобиться.";
		base.DescriptionTask = string.Empty;
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 1000;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharMonolit128");
		base.AdditionalTask = true;
		base.SubjectQuest = true;
	}
}
