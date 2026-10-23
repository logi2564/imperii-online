using UnityEngine;

public class TaskAdditionalColt : ConstructorTasks
{
	public TaskAdditionalColt()
	{
		base.NameTask = "Найти кольт";
		base.TextTask = "В общем, история такая:\nС неделю назад, на агропроме, в районе барьера, схлестнулись отряды Долга и Свободы. Пощипали друг друга и, вроде бы, без потерь разбежались. Все бы ничего, но во время заварухи, пара наших сталкеров, двигалась в направлении Бара. Соответственно ребята  под замес попали. И от одних досталось и вторые разбираться не стали, кто к ним проскочить пытается. В общем пришлось улепетывать, чтобы шальную пулю не поймать. В той спешке, мой боец оружие выронил, кольт... Кольт этот не простой, доработан нашими умельцами, в свое время от отца Валериана достался, за особые заслуги.\nХотелось бы вернуть оружие законному владельцу...\nКак добудешь, тащи в Ангар на Свалке, нечего с ним по всей Зоне таскаться... Там и награду получишь.";
		base.DescriptionTask = "Добраться до Барьера, Свалка. Найти кольт сталкера.";
		base.NamePointTask = "Барьер";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (base.ImageTask = (Texture2D)Resources.Load("Sprites/QuestSubject/GarbageColt"));
		base.AdditionalTask = true;
		base.GetToPointQuest = true;
	}
}
