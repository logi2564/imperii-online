using UnityEngine;

public class TaskAdditional1_5 : ConstructorTasks
{
	public TaskAdditional1_5()
	{
		base.NameTask = "Лагерь ЧН на складах";
		base.TextTask = "ЧН преследует наемников, к чему бы это. При удобном случае надо перекинуться парой словечек с Чистым Небом.";
		base.DescriptionTask = "Найти отряд Чистого неба и поговорить с лидером.";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/QuestSubject/clearSky");
		if (Data.CharacterD.Count > 0)
		{
			base.ImageTask = Data.CharacterD[0].SuitChar.IconCharacter;
		}
		else
		{
			base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconStalkerSuit128");
		}
	}
}
