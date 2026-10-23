using UnityEngine;

public class TaskAdditionalBalans0 : ConstructorTasks
{
	public TaskAdditionalBalans0()
	{
		base.NameTask = "Помощь группировке";
		base.TextTask = "Как на счет немножко пострелять? Вокруг базы имеется большое сосредоточение сил противника. Необходимо зачистить близлежащую территорию от неприятеля и склонить баланс сил в пользу нашей группировки.";
		base.DescriptionTask = "Уничтожить бойцов группировки: ";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/QuestSubject/supportFire");
		base.AdditionalTask = true;
		base.BalansQuest = true;
	}
}
