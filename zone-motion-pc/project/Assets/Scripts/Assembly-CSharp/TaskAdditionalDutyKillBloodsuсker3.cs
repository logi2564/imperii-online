using UnityEngine;

public class TaskAdditionalDutyKillBloodsuсker3 : ConstructorTasks
{
	public TaskAdditionalDutyKillBloodsuсker3()
	{
		base.NameTask = "Кровосос убит";
		base.TextTask = "Думал, прикончит меня кровосос!\nОднако моя взяла... \nТеперь необходимо добраться до ближайшей базы Долга, раны зализывать...";
		base.DescriptionTask = "Добраться до ближайшей базы Долга. Получить вознаграждение.";
		base.MapName = "Bar";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		if (Data.CharacterD.Count > 0)
		{
			base.ImageTask = Data.CharacterD[0].SuitChar.IconCharacter;
		}
		else
		{
			base.ImageTask = (Texture2D)Resources.Load("Sprites/QuestSubject/DutyBloodsucker");
		}
		base.AdditionalTask = true;
		base.GetToPointQuest = true;
	}
}
