using UnityEngine;

public class TaskAdditionalquestPathfinder3 : ConstructorTasks
{
	public TaskAdditionalquestPathfinder3()
	{
		base.NameTask = "Доставить Следопыту ПСИ-блокаду";
		base.TextTask = "Неуютное местечко! Видимо, Следопыт, спокойнее места для схрона найти не смог,... ну или не захотел. \nДа бог с ним, необходимо доставить препараты Следопыту, пока он окончательно умишком не тронулся.";
		base.DescriptionTask = "Доставить Препараты Следопыту.";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		if (Data.CharacterD.Count > 0)
		{
			base.ImageTask = Data.CharacterD[0].SuitChar.IconCharacter;
		}
		else
		{
			base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconStalkerSuit128");
		}
		base.AdditionalTask = true;
	}
}
