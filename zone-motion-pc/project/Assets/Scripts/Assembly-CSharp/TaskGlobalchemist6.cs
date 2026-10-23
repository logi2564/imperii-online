using UnityEngine;

public class TaskGlobalchemist6 : ConstructorTasks
{
	public TaskGlobalchemist6()
	{
		base.NameTask = "Снова наемники";
		base.TextTask = "Снова Радар! Во всей зоне надо еще поискать местечко опаснее... И где тут найти пропавший отряд. Придется обходить все точки и обыскивать каждый камень... Эх знать бы что они тут делали и место бы отыскалось быстрее.";
		base.DescriptionTask = "Отыскать на Радаре пропавший отряд";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/QuestSubject/pda");
		if (Data.CharacterD.Count > 0)
		{
			base.ImageTask = Data.CharacterD[0].SuitChar.IconCharacter;
		}
		else
		{
			base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconStalkerSuit128");
		}
		base.NamePointTask = "Стоянка на камнях";
		base.MapName = "Radar";
	}
}
