using UnityEngine;

public class TaskGlobalchemist7 : ConstructorTasks
{
	public TaskGlobalchemist7()
	{
		base.NameTask = "ПДА отряда наемников";
		base.TextTask = "Здесь видимо был нешуточный бой! Мутанты растащили остатки трупов, но вещи нетронуты... Удача мне улыбнулась, ПДА командира отряда наемников! Файлы конечно же закодированы, но помечена точка: Старый завод в Темной долине.";
		base.DescriptionTask = "Добраться до точки Старый завод в Темной долине";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/QuestSubject/pda");
		base.NamePointTask = "Старый завод";
		base.MapName = "DarkValley";
		base.RewardSubject = new AAAAAAAAAAAAAAAbb();
	}
}
