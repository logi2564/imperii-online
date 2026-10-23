using UnityEngine;

public class TaskAdditionalFindWeaponBox0 : ConstructorTasks
{
	public TaskAdditionalFindWeaponBox0()
	{
		base.NameTask = "Братва вооружена";
		base.TextTask = "Да ты в почете, братуха! Теперь мы сталкеров, как куропаток постреляем!... Давай к нам, если Бугор одобрит? Серьезные дела ворочить сможем. И работенка посерьезней появится может.";
		base.DescriptionTask = string.Empty;
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 5000;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/Subject/Money");
		base.AdditionalTask = true;
		base.SubjectQuest = true;
	}
}
