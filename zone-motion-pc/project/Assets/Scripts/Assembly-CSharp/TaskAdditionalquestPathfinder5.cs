using UnityEngine;

public class TaskAdditionalquestPathfinder5 : ConstructorTasks
{
	public TaskAdditionalquestPathfinder5()
	{
		base.NameTask = "...";
		base.TextTask = "Неплохо!\nЭто конечно не экзоскелет, но на первое время, очень даже может сгодится... Спасибо Следопыту за подарочек!";
		base.DescriptionTask = string.Empty;
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		if (Data.CharacterD.Count > 0)
		{
			base.ImageTask = Data.CharacterD[0].SuitChar.IconCharacter;
		}
		else
		{
			base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconStalkerSuit128");
		}
		base.AdditionalTask = true;
	}
}
