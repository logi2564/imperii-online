using UnityEngine;

public class TaskAdditionalArmFood0 : ConstructorTasks
{
	public TaskAdditionalArmFood0()
	{
		base.NameTask = "Солдатский паек";
		base.TextTask = "Душевно, брат! На сытый желудок и в Зоне веселее. Захаживай к нам, если, что...";
		base.DescriptionTask = string.Empty;
		base.QuestSubject = new AAAAAAAAAAAAAAAAAba();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharBerill128");
		base.AdditionalTask = true;
		base.SubjectQuest = true;
	}
}
