using UnityEngine;

public class TaskGlobalchemist19 : ConstructorTasks
{
	public TaskGlobalchemist19()
	{
		base.NameTask = "Временная передышка";
		base.TextTask = "Уж больно нервное выдалось последнее приключение. Вот сбагрю эти схемы и спрячусь где-нибудь в глубинах Зоны, пока Механик новую работенку не подкинет... (конечный квест на данный момент)";
		base.DescriptionTask = "Свободное  перемещение по Зоне (фриплей)";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/QuestSubject/stancia");
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
