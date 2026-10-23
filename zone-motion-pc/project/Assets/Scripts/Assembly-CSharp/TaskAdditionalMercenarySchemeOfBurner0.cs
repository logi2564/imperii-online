using UnityEngine;

public class TaskAdditionalMercenarySchemeOfBurner0 : ConstructorTasks
{
	public TaskAdditionalMercenarySchemeOfBurner0()
	{
		base.NameTask = "Схемы для наемников";
		base.TextTask = "Короче дела такие. Серьезный клиент платит хорошие деньги за схемы подключения Выжигателя. Работа непростая, но и оплата достойная. В придачу, если принесешь схемы, у моих бойцов повысится твой авторитет.";
		base.DescriptionTask = "Принести";
		base.QuestSubject = new AAAAAAAAAAAAAAAAbg();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharMersenary128");
		base.AdditionalTask = true;
		base.SubjectQuest = true;
	}
}
