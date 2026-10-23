using UnityEngine;

public class TaskAdditionalSpareParts01 : ConstructorTasks
{
	public TaskAdditionalSpareParts01()
	{
		base.NameTask = "''Разговор'' о деталях";
		base.TextTask = "Привет, горемычный!\nСтой, где стоишь, а не то пару новых дырок в башке проделаю!\nДетальки нам самим пригодятся, но мы можем уступить их тебе за небольшую плату, 2000 ru. Гони деньги или проваливай, пока цел...";
		base.DescriptionTask = "Уничтожить бандитов, забрать детали в тайнике";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAAAAbs();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharCloak128");
		base.AdditionalTask = true;
		base.NamePointTask = "Блокпост ''Север''";
		base.MapName = "RedForest";
	}
}
