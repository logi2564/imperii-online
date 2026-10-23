public class NoneJob : ConstructorTasks
{
	public NoneJob()
	{
		base.NameTask = "Работы пока нет";
		base.TextTask = "Извиняй, работы пока нет.";
		base.DescriptionTask = "...";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = Data.Dealers[Data.Points[Inventory._CurrentPoint[0]].ControlInt].ImageChar;
		base.AdditionalTask = true;
	}
}
