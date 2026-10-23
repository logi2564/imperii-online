using UnityEngine;

public class TaskAdditionalKiller1 : ConstructorTasks
{
	public TaskAdditionalKiller1()
	{
		base.NameTask = "Ликвидатор";
		base.TextTask = "В общем, думаю тебе можно доверять. Есть особое задание. Первому встречному такое не доверишь. Дело деликатное, но и оплата достойная. Необходимо убрать одного персонажа, жутко он нам мешает. Но я должен быть уверен, что он мертв, и поэтому исполнителем должен быть именно ты. Если же его грохнет кто-то другой, то не взыщи, денег ты не получишь. Дерзай.";
		base.DescriptionTask = "Убрать человека.";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/QuestSubject/killer0");
		base.AdditionalTask = true;
		base.KillQuest = true;
	}
}
