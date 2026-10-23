public class TaskAdditionalEmptySuit1 : ConstructorTasks
{
	public TaskAdditionalEmptySuit1()
	{
		base.NameTask = "Достать комбинезон";
		base.TextTask = "Необходимо достать сносный комбинезон. Рванье нести не надо. Найдешь что-то приличное, заходи. До встречи.";
		base.DescriptionTask = "Добыть комбинезон";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = base.QuestSubject.TextureSubject;
		base.AdditionalTask = true;
		base.SubjectQuest = true;
	}
}
