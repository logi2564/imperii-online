using UnityEngine;

public class TaskAdditionalScoutReport0_1 : ConstructorTasks
{
	public TaskAdditionalScoutReport0_1()
	{
		base.NameTask = "Доставить отчет разведчиков";
		base.TextTask = "Как видно ''Стоянка на камнях'' проклята всеми мутантами Зоны... Уж слишком часто тут гибнут бойцы. Среди трупов наемников, пара погибших солдат. Как видно это наши разведчики. Необходимо осмотреть тайник на точке, отыскать доклад и доставить его разведчиков на ближайшую точку, подконтрольную военным.";
		base.DescriptionTask = "Найти на точке отчет разведчиков, доставить его на ближайшую военную точку.";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		if (Data.CharacterD.Count > 0)
		{
			base.ImageTask = Data.CharacterD[0].SuitChar.IconCharacter;
		}
		else
		{
			base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharBerill128");
		}
		base.AdditionalTask = true;
	}
}
