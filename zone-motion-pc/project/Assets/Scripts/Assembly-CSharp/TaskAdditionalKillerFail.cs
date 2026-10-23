using UnityEngine;

public class TaskAdditionalKillerFail : ConstructorTasks
{
	public TaskAdditionalKillerFail()
	{
		base.NameTask = "Провал ликвидации";
		base.TextTask = "Вот ты растяпа! Сам он к праотцам отправился или ему помог кто-то другой? А может он еще по Зоне бегает? Я не могу быть уверен, что он мертв! Подвел ты меня... Бегом на базу!";
		base.DescriptionTask = "Вернуться на базу. Потеряна цель: ";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/QuestSubject/killer0");
		base.AdditionalTask = true;
		base.KillQuest = true;
	}
}
