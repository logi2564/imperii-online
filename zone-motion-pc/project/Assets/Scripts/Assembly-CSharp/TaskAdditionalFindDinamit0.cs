using UnityEngine;

public class TaskAdditionalFindDinamit0 : ConstructorTasks
{
	public TaskAdditionalFindDinamit0()
	{
		base.NameTask = "Динамит доставлен";
		base.TextTask = "Ну ты красава! Уважил! Бугор дело помнит, под ним ходить будешь. Братва тоже в курсе, претензий не имеет... Захаживай, как будешь в здешних местах, чайку попьем, о делах наших скорбных погутарим. Может работенка не пыльная подвернется...";
		base.DescriptionTask = string.Empty;
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 1000;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/Subject/Money");
		base.AdditionalTask = true;
		base.SubjectQuest = true;
	}
}
