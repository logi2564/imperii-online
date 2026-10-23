using UnityEngine;

public class TaskAdditionalKillerFail0 : ConstructorTasks
{
	public TaskAdditionalKillerFail0()
	{
		base.NameTask = "Потерянная цель";
		base.TextTask = "Для деликатных поручений ты еще не подходишь. Мне нужны люди с хорошей подготовкой. Раздобудь себе подходящий для таких дел ствол и снарягу, а сейчас проваливай...";
		base.DescriptionTask = "Потеряна цель: ";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAx();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/QuestSubject/killer0");
		base.AdditionalTask = true;
		base.KillQuest = true;
	}
}
