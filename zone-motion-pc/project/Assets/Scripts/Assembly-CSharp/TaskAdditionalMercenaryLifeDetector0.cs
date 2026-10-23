using UnityEngine;

public class TaskAdditionalMercenaryLifeDetector0 : ConstructorTasks
{
	public TaskAdditionalMercenaryLifeDetector0()
	{
		base.NameTask = "Детектор наемников";
		base.TextTask = "Здоров! \nКак дела с вещицей нашей? Доставил? Неплохо! Неисправна, это конечно, хуже, но наши мастера ее в жизнь вернуть на раз... А, Мутный, значит к праотцам отправился? Ну, туда ему и дорога, моим людям меньше мороки будет, да и остальным наука.\nПринимай оплату, бродяга. Как появится, работенка, для тебя - придержу. Бывай!";
		base.DescriptionTask = "...";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 1500;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharMersenary128");
		base.AdditionalTask = true;
		base.SubjectQuest = true;
	}
}
