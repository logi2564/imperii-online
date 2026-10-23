using UnityEngine;

public class TaskAdditionalDutyKillBloodsuсker1 : ConstructorTasks
{
	public TaskAdditionalDutyKillBloodsuсker1()
	{
		base.NameTask = "Исследовать насосную станцию";
		base.TextTask = "Обманчивая тишина, в районе станции.\nВороны не каркают... Ни псина, ни плоть не пробежит...\nДонесение разведки Долга подтвердились, окрестности станции усеяны останками сталкеров, различных группировок. Попадаются даже фрагменты комбинезона ''Монолита''.\nКак видно, причина этому отнюдь не стая слепых шавок.\nГде же виновник этой резни? Пока хозяина нет дома, осмотрю аномалию, может повезет с каким артефактом или найду что-нибудь стоящее, а затем сматываюсь отсюда, пока цел...";
		base.DescriptionTask = "Исследовать аномалию на точке: Насосная станция, Бар. Покинуть точку после исследования.";
		base.NamePointTask = "Насосная станция";
		base.MapName = "Bar";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/QuestSubject/FindArtefact");
		base.AdditionalTask = true;
		base.GetToPointQuest = true;
	}
}
