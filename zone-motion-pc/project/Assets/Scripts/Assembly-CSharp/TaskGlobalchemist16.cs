using UnityEngine;

public class TaskGlobalchemist16 : ConstructorTasks
{
	public TaskGlobalchemist16()
	{
		base.NameTask = "Барыга Фокс";
		base.TextTask = "Какого лешего вам от меня надо? Ключ-карта! Хе, хе... Кое-кто предлагал мне за нее кругленькую сумму, но я смогу уступить вам ее тысяч так за... 25, и деньги вперед... Как говорил один персонаж по кличке ''Монтёр'': утром деньги - вечером товар, вечером деньги - утром товар...";
		base.DescriptionTask = "Принести 25000 ru для Фокса";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharBandinVeteran128");
		base.NamePointTask = "Шевченко";
		base.MapName = "Backwater";
	}
}
