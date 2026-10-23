using UnityEngine;

public class TaskAdditionalMercenaryGroup2 : ConstructorTasks
{
	public TaskAdditionalMercenaryGroup2()
	{
		base.NameTask = "Начало эксперимента";
		base.TextTask = "Вы доставили оборудование?\nПрекрасно! Последние исследования показали, что перед нами разновидность пространственной аномалии. Мы можем возобновить наши работы, но рекомендую покинуть эту точку на время эксперимента. Кто знает, что сюда вывалится с ''той'' стороны!";
		base.DescriptionTask = "Покинуть аномалию на время эксперимента";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconEcologGreen256");
		base.AdditionalTask = true;
		base.NamePointTask = "Т-64";
		base.MapName = "RedForest";
	}
}
