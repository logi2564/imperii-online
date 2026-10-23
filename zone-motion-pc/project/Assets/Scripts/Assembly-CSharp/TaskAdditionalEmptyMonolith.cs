using UnityEngine;

public class TaskAdditionalEmptyMonolith : ConstructorTasks
{
	public TaskAdditionalEmptyMonolith()
	{
		base.NameTask = "Принести Схемы Выжигателя";
		base.TextTask = "Великий Монолит призывает тебя, Сталкер! У тебя есть возможность послужить нашему братству! Тогда мы примем тебя, ты станешь одним из нас!... Согласен ли ты помочь нашему делу? Так вот, мы долго искали способ подключения выжигателя, но все было безуспешно, до тех пор, пока некий ''Механик'' не согласился оказать нам помощь. Операция была на последней стадии завершения, группа была на подходе к Радару, но неизвестный противник уничтожил бойцов отряда, а Механик исчез... Твоя задача - принести Схемы Выжигателя. Мы сможем включить его снова и сталкеры перестанут беспокоить нас и наши тайны... Если ты согласен, то братья окажут тебе помощь, мутанты не будут тебя атаковать, но твои старые друзья от тебя откажутся...";
		base.DescriptionTask = "Принести ";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharMonolit128");
		base.AdditionalTask = true;
		base.SubjectQuest = true;
	}
}
