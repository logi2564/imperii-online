using UnityEngine;

public class TaskAdditional1 : ConstructorTasks
{
	public TaskAdditional1()
	{
		base.NameTask = "Лагерь ЧН";
		base.TextTask = "ЧН преследует наемников, к чему бы это. При удобном случае надо перекинуться парой словечек с Чистым небом.";
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
