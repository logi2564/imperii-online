using UnityEngine;

public class TaskAdditionalMercenaryLifeDetector0_1 : ConstructorTasks
{
	public TaskAdditionalMercenaryLifeDetector0_1()
	{
		base.NameTask = "Мутный";
		base.TextTask = "Зачем ты меня преследуешь, " + PlayerPrefs.GetString("HeroName") + "?\nЗа этот прибор можно получить неплохие деньги! Слишком много сталкеров гонялись за ним в последнее время и все они погибли! Они конечно знали, на что они идут, но не предполагали, какую именно цену за это заплатят... Снорки, кровосос, слепые псы! Я потратил кучу времени и сил, на его поиски. Короче, он достался мне слишком дорого и я не отдам его кому бы то ни было, за здорово живешь!\nЕсли ты будешь меня преследовать, мне придется убить и тебя! Выбирай, сталкер...";
		base.DescriptionTask = "...";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharMersenary128");
		base.AdditionalTask = true;
		base.SubjectQuest = true;
		base.MapName = "Military";
	}
}
