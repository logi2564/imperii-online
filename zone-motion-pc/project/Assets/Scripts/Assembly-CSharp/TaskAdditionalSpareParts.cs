using UnityEngine;

public class TaskAdditionalSpareParts : ConstructorTasks
{
	public TaskAdditionalSpareParts()
	{
		base.NameTask = "Найти детали";
		base.TextTask = "Вчера, около моста в Лиманск, пробегала шайка бандитов, так эти криворукие разобрали часть подъемного механизма моста, на кой он им сдался, и двинули в сторону Блокпоста ''Север''... Теперь мост, как видно, не работает. Нам позарез необходимо отправить группу в Лиманск. Наши спецы могут починить подъемный механизм, но нужны детали. Необходимо выкупить эти детали у бандитов, ну а если они не согласятся на сделку по доброму, мне тебя учить не надо... Принесешь детали на мост в Лиманск, мои люди тебя атаковать не будут, ну по крайней мере некоторое время, а пока не принесешь необходимое, без обид, бойцы могут и пальнуть случайно!";
		base.DescriptionTask = "Принести";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAAAAbs();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharMersenary128");
		base.AdditionalTask = true;
		base.SubjectQuest = true;
		base.NamePointTask = "Мост в Лиманск";
		base.MapName = "RedForest";
	}
}
