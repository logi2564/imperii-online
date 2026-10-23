using UnityEngine;

public class TaskAdditionalArmFood : ConstructorTasks
{
	public TaskAdditionalArmFood()
	{
		base.NameTask = "Принести съедобные припасы";
		base.TextTask = "Сидим здесь уже вторую неделю. Ни тебе поспать нормально, ни помыться! Да что уж там, консервы уже на исходе. Если найдешь, к примеру, тушенку, банок пять, так тащи сюда, а то пока паек доставят, мои солдатики ноги протянут. Лады?";
		base.DescriptionTask = "Принести ";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAba();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharBerill128");
		base.AdditionalTask = true;
		base.SubjectQuest = true;
	}
}
