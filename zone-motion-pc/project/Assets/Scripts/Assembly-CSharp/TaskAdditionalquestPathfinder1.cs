using UnityEngine;

public class TaskAdditionalquestPathfinder1 : ConstructorTasks
{
	public TaskAdditionalquestPathfinder1()
	{
		base.NameTask = "Убить Следопыта";
		base.TextTask = "Похоже, тот зомбированный, что бредет по дороге к Темной Долине, и есть наш Следопыт! \nПодойти к нему без риска для жизни, как видно, не получится. Шмаляет во все стороны, без разбора! Помочь ему уже не возможно, жаль парня...";
		base.DescriptionTask = "Убить Зомбированного Следопыта.";
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
