using UnityEngine;

public class TaskBasic2_5 : ConstructorTasks
{
	public TaskBasic2_5()
	{
		base.NameTask = "Бар";
		base.TextTask = " Темно,... сыро... Тусклый, мерцающий свет, звуки скрипящих дверей,... Шорохи в темноте,... Рычание, сковывающее страхом в груди,... Мерзкий запах разлагающейся плоти,...  останки костей под ногами... Мрачное место. Нет, обычному сталкеру тут делать нечего. Аномалий полно, мутанты стаями бегают. Жутковато... Вот не в жизнь бы без крайней надобности, сюда не сунулся. Эх ... Ага, следы недавней перестрелки и... Погибший боец в костюме наемника... следы укусов и разорванный комбинезон... В ПДА какие-то записи и схемы.";
		base.DescriptionTask = "Доставить информацию Долгу.";
		base.NamePointTask = "База Долга";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.QuestSubject.NameSubject = "Информация X18";
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAAAbp();
		if (Data.CharacterD.Count > 0)
		{
			base.ImageTask = Data.CharacterD[0].SuitChar.IconCharacter;
		}
		else
		{
			base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/x18");
		}
		base.NamePointTask = "База Долга";
		base.MapName = "Bar";
	}
}
