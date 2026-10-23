using UnityEngine;

public class TaskGlobalchemist18_6 : ConstructorTasks
{
	public TaskGlobalchemist18_6()
	{
		base.NameTask = "Принять бой";
		base.TextTask = "Хищник: ''Ты, " + PlayerPrefs.GetString("HeroName") + ", как хочешь, а мне, как бойцу с приличным стажем, не пристало шарахаться от бандюганов с хлопушками. Может быть, это будет мой последний бой, но я приму его с честью. Я вперед, прикрой мне спину...''";
		base.DescriptionTask = "Принять бой, уничтожить бандитов";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/QuestSubject/killer0");
		if (Data.CharacterD.Count > 0)
		{
			base.ImageTask = Data.CharacterD[0].SuitChar.IconCharacter;
		}
		else
		{
			base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconStalkerSuit128");
		}
		base.NamePointTask = "Испытательный цех";
		base.MapName = "Backwater";
	}
}
