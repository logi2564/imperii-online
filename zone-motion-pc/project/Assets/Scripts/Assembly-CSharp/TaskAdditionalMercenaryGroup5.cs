using UnityEngine;

public class TaskAdditionalMercenaryGroup5 : ConstructorTasks
{
	public TaskAdditionalMercenaryGroup5()
	{
		base.NameTask = "Отряд наемников найден";
		base.TextTask = "Здорово, боец!\nТы вытащил моих людей, отличная работа. Жаль только, толковых ребят мало осталось.\nТеперь о делах насущных. После последних событий нам необходимо пополнение. Если есть желание, вступай в мой отряд и за работу. Бойцы тебя примут... Работы будет предостаточно, например по захвату и удержанию близлежащих точек, но это работенка для членов группировки.\nНу? Что скажешь?";
		base.DescriptionTask = "...";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 3000;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharMersenary128");
		base.AdditionalTask = true;
		base.NamePointTask = "Мост в Лиманск";
		base.MapName = "RedForest";
	}
}
