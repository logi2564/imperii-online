using UnityEngine;

public class TaskGlobalchemist17 : ConstructorTasks
{
	public TaskGlobalchemist17()
	{
		base.NameTask = "Испытательный цех";
		base.TextTask = "Денежки счет любят! Две, три... пятнадцать... С вами приятно иметь дело, господа хорошие! Держите товар. Фокс уговор помнит. А теперь проваливайте побыренькому, а то у братвы, от одного вашего вида руки сами к стволу тянутся...";
		base.DescriptionTask = "Добыть схемы экспериментального оружия в испытательном цехе";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAcc();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharBandinVeteran128");
		base.NamePointTask = "Испытательный цех";
		base.MapName = "Backwater";
	}
}
