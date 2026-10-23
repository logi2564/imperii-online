public class TaskAdditionalEmptyWeapon1 : ConstructorTasks
{
	public TaskAdditionalEmptyWeapon1()
	{
		base.NameTask = "Достать оружие";
		base.TextTask = "Нужен ствол. Клиент готов платить хорошие деньги, но и состояние должно быть на уровне. Как ты его достанешь, никому не интересно. Удачи.";
		base.DescriptionTask = "Добыть оружие";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = base.QuestSubject.TextureSubject;
		base.AdditionalTask = true;
		base.SubjectQuest = true;
	}
}
