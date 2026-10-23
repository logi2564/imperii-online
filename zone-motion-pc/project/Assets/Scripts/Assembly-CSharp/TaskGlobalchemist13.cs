using UnityEngine;

public class TaskGlobalchemist13 : ConstructorTasks
{
	public TaskGlobalchemist13()
	{
		base.NameTask = "В поисках Хищника";
		base.TextTask = "Неплохо, нам бы не помешал такой боец как ты! Я думаю, мы можем тебе доверять. Интересующего тебя бойца зовут Хищник. Он ветеран Зоны и не ко всем группировкам относится положительно. Он окажет тебе необходимую помощь, если ты с ним договоришься, и не будешь принадлежать ни к какой группировке... Ты найдешь его в Рыжем Лесу, там он выполняет наше поручение. Бывай.";
		base.DescriptionTask = "Найти Хищиника в Рыжем Лесу";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharChN_1_128");
		base.NamePointTask = "Шахтный копер";
		base.MapName = "RedForest";
	}
}
