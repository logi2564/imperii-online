using UnityEngine;

public class TaskAdditional5 : ConstructorTasks
{
	public TaskAdditional5()
	{
		base.NameTask = "Бывай, ЧН";
		base.TextTask = "Спасибо, Сталкер! Выручил моих бойцов! Без твоей помощи, они бы не вернулись... Заглядывай к нам почаще, здесь тебе всегда рады!";
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharChN_2_128");
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new LR300ML();
		base.RewardMoney = 2000;
	}
}
