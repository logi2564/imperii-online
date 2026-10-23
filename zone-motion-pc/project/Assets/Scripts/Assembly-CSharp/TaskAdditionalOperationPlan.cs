using UnityEngine;

public class TaskAdditionalOperationPlan : ConstructorTasks
{
	public TaskAdditionalOperationPlan()
	{
		base.NameTask = "Разведать планы военных";
		base.TextTask = "В последнее время в районе института ''Агропром'', серьезно оживились военные. Подобное движение, обычно  не сулит ничего хорошего. Неплохо бы нам разведать, не готовится ли очередная боевая операция по зачистке близлежащей территории Агропрома. Ох и натерпелся наш брат сталкер от штурмовых операций...\nНеобходимо пробраться в здание института и добыть любые сведения, лучше документы, о ближайших планах вояк на Агропроме.";
		base.DescriptionTask = "Добраться до точки: ''Институт Агропром''. Добыть сведения о планах военных на агропроме.";
		base.NamePointTask = "Институт Агропром";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/QuestSubject/netrals");
		base.AdditionalTask = true;
	}
}
