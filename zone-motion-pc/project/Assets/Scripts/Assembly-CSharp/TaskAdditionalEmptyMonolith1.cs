using UnityEngine;

public class TaskAdditionalEmptyMonolith1 : ConstructorTasks
{
	public TaskAdditionalEmptyMonolith1()
	{
		base.NameTask = "Братство Монолита";
		base.TextTask = "Слава Великому Монолиту, тебе удалось достать схемы! Теперь мы можем тебе доверять... Ты можешь оставаться в любом из наших лагерей, присоединится к любому нашему отряду! Настанет время и мы сможем позволить тебе отправиться к Нему...";
		base.DescriptionTask = "Оберегать путь к Радару, уничтожать отряды сталкеров";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharMonolit128");
		base.AdditionalTask = true;
		base.SubjectQuest = false;
	}
}
