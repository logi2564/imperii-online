using UnityEngine;

public class TaskAdditionalFindDinamit : ConstructorTasks
{
	public TaskAdditionalFindDinamit()
	{
		base.NameTask = "Найти динамит";
		base.TextTask = "В общем, сталкерня по Зоне шастает, как пчёлы по лугу. Поприжали братву. Ни товар сбыть, ни порядочным разбоем разжиться... Бугор порешил, на корню весь муравейник уничтожить. С тебя, значит ящик динамита, а всю грязную работу мы сами сделаем. Коли доставишь нам груз, так ты в почете. Ну а пока товара нет, не ровен час, ребятки и пошалить могут, не зевай! А поискать его можно у военных...";
		base.DescriptionTask = "Принести ";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharCloak128");
		base.AdditionalTask = true;
		base.SubjectQuest = true;
	}
}
