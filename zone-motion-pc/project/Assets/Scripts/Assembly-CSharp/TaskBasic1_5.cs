using UnityEngine;

public class TaskBasic1_5 : ConstructorTasks
{
	public TaskBasic1_5()
	{
		base.NameTask = "Курьер";
		base.TextTask = "Да,... не повезло тебе браток,... Ну, без обид, тебе на этом свете уже ничего не пригодится... И кто же это тебя так? ...";
		base.DescriptionTask = "Отнести флешку на базу нейтралов на Агропроме.";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbx();
		if (Data.CharacterD.Count > 0)
		{
			base.ImageTask = Data.CharacterD[0].SuitChar.IconCharacter;
		}
		else
		{
			base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/Sidor128");
		}
		base.NamePointTask = "Завод Агропром";
		base.QuestSubject.NameSubject = "Флешка погибшего сталкера";
		base.NamePointTask = "Завод Агропром";
		base.MapName = "Agroprom";
	}
}
