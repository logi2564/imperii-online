public class TaskAdditionalEmptyMutantPart : ConstructorTasks
{
	public TaskAdditionalEmptyMutantPart()
	{
		base.NameTask = "Принести часть тела мутанта";
		base.TextTask = "Нам необходимо изучать причину мутаций живых существ в Зоне. Для этого мы собираем части тел мутантов. Необходимо принести часть тела мутанта. Оплата будет достойная. Кроме того, твоя репутация выростет, и мы сможем предложить тебе более интересные товары. До встречи.";
		base.DescriptionTask = "Добыть предмет";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = base.QuestSubject.TextureSubject;
		base.AdditionalTask = true;
		base.SubjectQuest = true;
	}
}
