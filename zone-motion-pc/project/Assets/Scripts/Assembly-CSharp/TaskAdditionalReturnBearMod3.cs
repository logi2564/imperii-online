using UnityEngine;

public class TaskAdditionalReturnBearMod3 : ConstructorTasks
{
	public TaskAdditionalReturnBearMod3()
	{
		base.NameTask = "Хабар сталкеров доставлен";
		base.TextTask = "Молодчина, " + PlayerPrefs.GetString("HeroName") + "! Сдается мне, что Хмурый и Копченый, еще не скоро появятся на Агропроме.\nСпасибо за артефакты. Детектор и остальное, что нашел, можешь себе оставить в качестве платы за труд.\nДетектор, что нашел, особенный. Второго такого, во всей Зоне не сыщешь...\nБывай, дружище!";
		base.DescriptionTask = "...";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		if (Data.CharacterD.Count > 0)
		{
			base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconStalkerSuit128");
		}
		else
		{
			base.ImageTask = (Texture2D)Resources.Load("Sprites/QuestSubject/netrals0");
		}
		base.AdditionalTask = true;
	}
}
