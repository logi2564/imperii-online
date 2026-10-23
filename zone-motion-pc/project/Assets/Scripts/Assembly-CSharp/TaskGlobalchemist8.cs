using UnityEngine;

public class TaskGlobalchemist8 : ConstructorTasks
{
	public TaskGlobalchemist8()
	{
		base.NameTask = "Обмен и возвращение прототипа";
		base.TextTask = "Чего тебе? Наш командир погиб и задание провалено. Возвратится на базу в Мертвый город мы не смогли... Прибор? Он поврежден и уже не представляет никакой ценности. Верни ПДА командира,  забирай прибор, если он тебе так необходим, и проваливай отсюда, мои люди начинают нервничать.";
		base.DescriptionTask = "Доставить прототип профессору";
		base.QuestSubject = new AAAAAAAAAAAAAAAbb();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharMersenary128");
		base.NamePointTask = "Бункер ученых";
		base.MapName = "Amber";
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbz();
	}
}
