using UnityEngine;

public class TaskAdditionalReturnBearMod : ConstructorTasks
{
	public TaskAdditionalReturnBearMod()
	{
		base.NameTask = "Найти награбленный хабар";
		base.TextTask = "С неделю назад, пара наших сталкеров возвращалась на базу на Агропроме, со стороны Янтаря. Добыли достойный хабар и на радостях, в безмятежности, прошляпили засаду бандитов. Одним словом, разули их, до ботинок...\nМы, как прознали, про разбой, кинулись на поиски беспредельщиков. Постреляли, пошумели, часть хабара удалось вернуть, а остальное, как в воду кануло. Никакие поиски результатов не дают.\nСгоняй до бандитского лагеря на болоте, пошукай там... Одним словом найди следы пропавшего хабара.";
		base.DescriptionTask = "Добраться до точки: ''Лагерь на болоте'', Агропром. Найти оставшуюся часть хабара сталкеров.";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/QuestSubject/netrals0");
		base.AdditionalTask = true;
	}
}
