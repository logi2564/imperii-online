using UnityEngine;

public class TaskAdditionalReturnBearMod0 : ConstructorTasks
{
	public TaskAdditionalReturnBearMod0()
	{
		base.NameTask = "Найти Копченого";
		base.TextTask = "Найдена записка с рукописным текстом: \n''Хмурый, после нашего гоп-стопа, сталкерня на агропроме громкий кипеш учинила. Пока не уляжется, сховал остатки хабара в наш тайник, ты знаешь о чем я... Как шум утихнет, скинем добытое или распилим между собой, поровну.\nДумаю надобно ховаться, до времени. Я теряюсь в центре Зоны. Как вернешься со свалки, не мозоль глаза на Агропроме, дуй за мной, тебя учить не надо...\nБывай, свидимся.\nКопченый.''\nКак видно Хмурого я уже не догоню, время упущено. Ждать Копченого здесь небезопасно, но на Свалке, вполне можно его найти. ";
		base.DescriptionTask = "Добраться до Свалки. Найти Копченого.";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		if (Data.CharacterD.Count > 0)
		{
			base.ImageTask = Data.CharacterD[0].SuitChar.IconCharacter;
		}
		else
		{
			base.ImageTask = (Texture2D)Resources.Load("Sprites/QuestSubject/netrals0");
		}
		base.AdditionalTask = true;
	}
}
