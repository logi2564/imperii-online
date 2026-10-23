public class TaskAdditionalEmptySubj1 : ConstructorTasks
{
	public TaskAdditionalEmptySubj1()
	{
		base.NameTask = "Достать артефакт";
		base.TextTask = "Одному клиенту позарез нужен редкий артефакт. Всех кого посылал, с пустыми руками возвращаются. Клиент хорошо платит, но ждать не любит, нервничает. Все просто - ему арт, тебе деньги.";
		base.DescriptionTask = "Принести артефакт";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = base.QuestSubject.TextureSubject;
		base.AdditionalTask = true;
		base.SubjectQuest = true;
	}
}
