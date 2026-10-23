using UnityEngine;

public class TaskGlobalchemist3 : ConstructorTasks
{
	public TaskGlobalchemist3()
	{
		base.NameTask = "Наемники";
		base.TextTask = "Привет, сталкер. Славные тогда были денечки! Я прорывался в центр Припяти вместе с этим сталкером... Ему зачем-то было необходимо попасть к ЧАЭС. Вместе мы дошли практически до стадиона. Там мы нарвались на засаду бойцов Монолита и наши пути разошлись... Больше я его не видел. Мои бойцы поговаривали, что у главаря наемников в Мертвом городе появился какой-то прибор, который помогает сопротивляться ПСИ-излучению, может быть это то, что ты ищешь? Удачи тебе, ...";
		base.DescriptionTask = "Добраться до базы наемников в Мертвом городе";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharPC596_128");
		base.NamePointTask = "Горком КПСС";
		base.MapName = "DeadCity";
	}
}
