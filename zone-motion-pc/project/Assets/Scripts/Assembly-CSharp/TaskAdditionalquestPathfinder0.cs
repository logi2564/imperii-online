using UnityEngine;

public class TaskAdditionalquestPathfinder0 : ConstructorTasks
{
	public TaskAdditionalquestPathfinder0()
	{
		base.NameTask = "Найти Следопыта";
		base.TextTask = "Был у нас сталкер, Следопытом его звали. \nСмышленый паренек, в любую аномалию мог без детектера зайти и без царапины выбраться. Раны на нем, как на собаке заживали, мутанты стороной обходили.\nПродвинутой снарягой в жизни не пользоваться, сталкерскую куртку ни на какой комбинезон менять не хотел. Одним словом, с секретами паренек.\nПодался он как-то в глубину Зоны, да попал толи по контролера, толи под действие локального пси-излучения. В итоге видели похожего сталкера, умишком тронувшегося,... бродит бесцельнопо свалке, мычит, что-то хрипит, слюна изо рта стекает,... по всей видимости зомбирован.\nНадо бы проверить, он или еще какой бедолага. Если сможешь в чувство его привести, так будь любезен, постарайся, а не сумеешь, так избавь сталкера от мучений...";
		base.DescriptionTask = "Добраться до точки: Дорога в темную долину, Свалка. Найти Следопыта.";
		base.NamePointTask = "Дорога в темную долину";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconStalkerSuit128");
		base.AdditionalTask = true;
		base.GetToPointQuest = true;
	}
}
