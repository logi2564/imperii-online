using UnityEngine;

public class TaskAdditionalВocumentation : ConstructorTasks
{
	public TaskAdditionalВocumentation()
	{
		base.NameTask = "Найти информацию об экспериментах";
		base.TextTask = "В последнее время мы работаем над исследованием причин возникновения отдельных явлений Зоны. Мы собрали много документов и сведений, но не имеем абсолютно никакой информации о деятельности секретных лабораторий, на территории Зоны. Твоя задача состоит в том, чтобы проникнуть в лаборатории Х16 и Х18 и раздобыть там документы, проливающие свет на работы и эксперименты, которые там проводились. Документы могут находиться и в других местах, порой даже самых неожиданных... Естественно, документов может оказаться достаточно много, точное количество никто сказать не может. Ты можешь приносить документы по раздельности или в большом количестве, неважно. Оплата будет производиться за каждый  документ. Нам важна любая информация. Дерзай, сталкер.";
		base.DescriptionTask = "Отыскать несколько документов о деятельности лабораторий Х16 и Х18.";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/Lebedev128");
		base.AdditionalTask = true;
		base.ManySubjectsQuest = true;
		base.SubjectQuest = true;
	}
}
