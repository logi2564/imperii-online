using UnityEngine;

public class TaskBasic2 : ConstructorTasks
{
	public TaskBasic2()
	{
		base.NameTask = "Информация X18";
		base.TextTask = "Ну, в общем, дела печальные. Здесь только часть информации. Но то, что удалось расшифровать, указывает на схему подключения Выжигателя. Видимо кто-то пытается его запустить. На курьера напали наемники из темной долины. Необходимо достать у них оставшуюся часть информации и доставить ее в бар. Долг разберется, что с ней делать. У долга имеется информация о Механике - запросишь ее в награду. Да, чуть не забыл... Мы тут на схрон наткнулись, ... ну и поживились немного. Среди прочего хлама костюмчик сносный оказался...";
		base.DescriptionTask = "Добыть недостающую часть информации у наемников Темной долины.";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAs();
		base.RewardMoney = 1500;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/Valerian128");
		base.NamePointTask = "Старый завод";
		base.MapName = "DarkValley";
	}
}
