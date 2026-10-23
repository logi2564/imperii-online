using UnityEngine;

public class TaskAdditionalDutyKillBloodsuсker : ConstructorTasks
{
	public TaskAdditionalDutyKillBloodsuсker()
	{
		base.NameTask = "Разведка на насосной станции";
		base.TextTask = "Здорово, сталкер!\nЮжнее бара имеется заброшенная насосная станция, окруженная аномалиями. Радиационный фон там повышенный и сталкеры туда захаживают не часто. Раньше там было тихое местечко, но в последнее время, те кто отваживался туда направиться, обратно не возвращались.\nНаши разведчики доложили, что в поблизости станции, стали попадаться высохшие до основания и обглоданные останки сталкеров.\nОбычно, такие останки, оставляет кровосос, высасывая у бедолаги всю кровь, без остатка. После такой процедуры, от человека остается лишь высохшая оболочка.\nНеобходимо добраться до станции, разузнать, что, по чем... Может останки притащили слепые псы, что мало вероятно, а может и действительно, кровосос завелся, тогда его необходимо уничтожить.\nРаботенка непростая...\nВозьмешься?";
		base.DescriptionTask = "Добраться до точки: Насосная станция, Бар.\nОсмотреть местность, найти и уничтожить кровососа или стаю слепых псов.";
		base.NamePointTask = "Насосная станция";
		base.MapName = "Bar";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/QuestSubject/DutyBloodsucker");
		base.AdditionalTask = true;
		base.GetToPointQuest = true;
	}
}
