using UnityEngine;

public class TaskBasic3 : ConstructorTasks
{
	public TaskBasic3()
	{
		base.NameTask = "Завод Янтарь";
		base.TextTask = "Ну здорово, сталкер. Принес информацию?... Давай посмотрим, что там наемники задумали... Так вот значит: неизвестный заказчик, платит серьезные деньги за информацию о схеме включения Выжигателя мозгов. Наемники охраняют и сопровождают какого-то инженера, который собирает эту схему по остаткам записей в секретных лабораториях. Теперь они направляются на Завод Янтарь. Кстати, мои люди, с неделю назад, там видели интересующего тебя человека. И еще прими презент от Долга...";
		base.DescriptionTask = "Добраться до завода Янтарь.";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAs();
		base.RewardMoney = 2000;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/Barmen");
		base.NamePointTask = "Бункер ученых";
		base.MapName = "Amber";
	}
}
