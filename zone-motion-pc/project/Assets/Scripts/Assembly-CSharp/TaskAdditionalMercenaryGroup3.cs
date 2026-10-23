using UnityEngine;

public class TaskAdditionalMercenaryGroup3 : ConstructorTasks
{
	public TaskAdditionalMercenaryGroup3()
	{
		base.NameTask = "Помощь наемникам";
		base.TextTask = "А, мля!.. Где мы?\nВот, блин, чудеса Зоны!\nВнимание! Мутанты! Бей их!\nЭй, " + PlayerPrefs.GetString("HeroName") + "!\nНаши бойцы изранены, здесь кровосос! Помоги нам отбиться!";
		base.DescriptionTask = "Помочь наемникам отбиться от кровососа";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharMersenary128");
		base.AdditionalTask = true;
		base.NamePointTask = "Т-64";
		base.MapName = "RedForest";
	}
}
