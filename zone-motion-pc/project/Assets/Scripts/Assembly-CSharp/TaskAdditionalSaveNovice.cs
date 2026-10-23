using UnityEngine;

public class TaskAdditionalSaveNovice : ConstructorTasks
{
	public TaskAdditionalSaveNovice()
	{
		base.NameTask = "Спасти новичка";
		base.TextTask = "Привет, сталкер. Есть для тебя работенка...\nНовичок, наш, Баламут, запропастился куда-то. Говорили ему, никуда носа не высовывать, так нет же, то к элеватору рванет, то к ферме. Самостоятельный, видите ли, а опыта в Зоне никакого... Теперь вот, вторые сутки ни слухи, ни духу, только КПК в районе перевернутого тепловоза отслеживается. Последнее сообщение с просьбой о помощи. Сгоняй, разведай, что да как... За наградой дело не встанет.";
		base.DescriptionTask = "Добраться до точки: Перевернутый тепловоз, Кордон. Отыскать Баламута.";
		base.NamePointTask = "Перевернутый тепловоз";
		base.MapName = "Kordon";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/QuestSubject/novice");
		base.AdditionalTask = true;
		base.GetToPointQuest = true;
	}
}
