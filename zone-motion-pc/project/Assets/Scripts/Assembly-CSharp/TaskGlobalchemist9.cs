using UnityEngine;

public class TaskGlobalchemist9 : ConstructorTasks
{
	public TaskGlobalchemist9()
	{
		base.NameTask = "Возвращение прототипа";
		base.TextTask = "Ну что же, исправен он или нет, это уже дело профессора. Гланое, что прибор найден, теперь мое дело доставить его в бункер на Янтаре.";
		base.DescriptionTask = "Доставить прототип профессору";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbz();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/QuestSubject/scientist");
		if (Data.CharacterD.Count > 0)
		{
			base.ImageTask = Data.CharacterD[0].SuitChar.IconCharacter;
		}
		else
		{
			base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconStalkerSuit128");
		}
		base.NamePointTask = "Бункер ученых";
		base.MapName = "Amber";
	}
}
