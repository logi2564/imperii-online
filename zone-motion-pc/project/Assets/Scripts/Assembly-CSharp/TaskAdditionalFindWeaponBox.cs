using UnityEngine;

public class TaskAdditionalFindWeaponBox : ConstructorTasks
{
	public TaskAdditionalFindWeaponBox()
	{
		base.NameTask = "Доставить партию оружия";
		base.TextTask = "Бугор решил покончить со сталкерами на нашей территории, но для этого нам необходимо подходящее оружие. Где-то на армейских складах, имеется схрон Свободы, там куча дробовиков, как раз нам подходящих. Если доставишь ящик с оружием, то и деньгами не обидим и авторитет твой поднимется...";
		base.DescriptionTask = "Принести ";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharCloak128");
		base.AdditionalTask = true;
		base.SubjectQuest = true;
	}
}
