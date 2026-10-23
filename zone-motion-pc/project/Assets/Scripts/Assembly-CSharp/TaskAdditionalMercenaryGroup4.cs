using UnityEngine;

public class TaskAdditionalMercenaryGroup4 : ConstructorTasks
{
	public TaskAdditionalMercenaryGroup4()
	{
		base.NameTask = "Отряд наемников найден";
		base.TextTask = "Спасибо, дружище! Во век не забудем твоей помощи!\nМы выполняли очередную работу в этом районе, ну и как бывает в Зоне, на нас напала стая слепых псов. Валили на нас десятками. Ближайшим укрытием оказался этот танк, будь он не ладен! Как только мы к нему приблизились, случился выброс, нас подбросило и затянуло в неизвестную до этого местность. Аномальной активности там не было, от выброса не осталось и следа... Но вот мутантов, пруд пруди!  Не знаю, сколько времени мы провели в этом адском месте... Половина группы погибла, вторая половина измотана до предела. Как выбраться сумели, понять не могу!\nТеперь мы будем пробиваться к Мосту на Лиманск. Бывай, " + PlayerPrefs.GetString("HeroName") + "! Может свидимся еще... ";
		base.DescriptionTask = "Получить награду на точке ''Мост в Лиманск''";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharMersenary128");
		base.AdditionalTask = true;
		base.NamePointTask = "Мост в Лиманск";
		base.MapName = "RedForest";
	}
}
