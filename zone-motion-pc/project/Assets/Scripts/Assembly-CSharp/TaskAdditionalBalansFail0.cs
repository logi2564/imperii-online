using UnityEngine;

public class TaskAdditionalBalansFail0 : ConstructorTasks
{
	public TaskAdditionalBalansFail0()
	{
		base.NameTask = "Не оказанная помощь...";
		base.TextTask = "Осмотрись, поменяй оружие, прокачай экипировку, может тогда ты сможешь нам помочь. Держи вот, для поднятия настроения...";
		base.DescriptionTask = "...";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAx();
		base.AdditionalTask = true;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/QuestSubject/supportFire");
	}
}
