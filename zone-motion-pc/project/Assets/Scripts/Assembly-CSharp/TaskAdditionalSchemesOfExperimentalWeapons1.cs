using UnityEngine;

public class TaskAdditionalSchemesOfExperimentalWeapons1 : ConstructorTasks
{
	public TaskAdditionalSchemesOfExperimentalWeapons1()
	{
		base.NameTask = "Схемы переданы";
		base.TextTask = "Ну ты уважил! Не буду спрашивать, как они у тебя оказались, уж больно многие за ними сейчас охотятся. Клянусь всеми артефактами Зоны, ты самый полезный добытчик из всех, кого я знал! Вступай в наши ряды, такой молодчик нам позарез необходим...";
		base.DescriptionTask = "...";
		base.QuestSubject = new AAAAAAAAAAAAAAbd();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 40000;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/QuestSubject/dokuments_1");
		base.AdditionalTask = true;
	}
}
