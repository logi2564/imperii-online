using UnityEngine;

public class TaskGlobalchemist18 : ConstructorTasks
{
	public TaskGlobalchemist18()
	{
		base.NameTask = "Схемы оружия";
		base.TextTask = "Еще одно мрачное местечко в Зоне. Пробраться внутрь стоило немалых трудов... Как обычно в подземных лабораториях полно старого оборудования, проржавевшего до основания. Разбросаны листы бумаги и части механизмов, истлевшие трупы мутантов и... останки сталкера! Осмотрим... медикаменты и консервы с истекшим сроком годности, стопки пожелтевшей бумаги. На листах хорошо сохранились схемы и рисунки. Берем схемы и проваливаем отсюда...";
		base.DescriptionTask = "Доставить схемы на ближайшую базу экологов, в Лесничество.";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAcc();
		base.RewardSubject = new AAAAAAAAAAAAAAbd();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/QuestSubject/dokuments_1");
		if (Data.CharacterD.Count > 0)
		{
			base.ImageTask = Data.CharacterD[0].SuitChar.IconCharacter;
		}
		else
		{
			base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconStalkerSuit128");
		}
		base.NamePointTask = "Испытательный цех";
		base.MapName = "Backwater";
	}
}
