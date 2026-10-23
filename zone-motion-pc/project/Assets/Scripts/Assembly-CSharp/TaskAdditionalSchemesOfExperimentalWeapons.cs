using UnityEngine;

public class TaskAdditionalSchemesOfExperimentalWeapons : ConstructorTasks
{
	public TaskAdditionalSchemesOfExperimentalWeapons()
	{
		base.NameTask = "Добыть схемы оружия";
		base.TextTask = "В последнее время все только и говорят о каком-то сверхмощном оружии и схемах его изготовления. Все как будто с цепи сорвались, чтобы их отыскать. На юго-западе Затона, за информацию о них, были серьезнейшие разборки, естественно с трупами. Если ты принесешь нам эти схемы, мы прилично тебе заплатим, и твой авторитет у нашей группировки поднимется до предела...";
		base.DescriptionTask = "Принести схемы экспериментального оружия";
		base.QuestSubject = new AAAAAAAAAAAAAAbd();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/QuestSubject/dokuments_1");
		base.AdditionalTask = true;
	}
}
