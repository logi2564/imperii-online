using UnityEngine;

public class TaskAdditionalSaveNovice2 : ConstructorTasks
{
	public TaskAdditionalSaveNovice2()
	{
		base.NameTask = "Баламут, на базе";
		base.TextTask = "Спасибо, дружище, выручил нашего человека!\nИ что с этими новичками делать, ума не приложу? Как только в Зону попадают, так хабар им подавай! Учишь их, учишь, все без толку, пропадают пачками. Тут и бывалый то сталкер, сто раз осмотрится, чтобы шаг ступить, а эти... Как очухается, подзатыльников ему навешаю, чтобы на тот свет не торопился.\nЗаглядывай к нам почаще, работенка у нас найдется!";
		base.DescriptionTask = "...";
		base.NamePointTask = "Деревня новичков";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconStalkerSuit128");
		base.AdditionalTask = true;
	}
}
