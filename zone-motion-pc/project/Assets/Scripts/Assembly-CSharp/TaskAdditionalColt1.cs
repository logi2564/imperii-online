using UnityEngine;

public class TaskAdditionalColt1 : ConstructorTasks
{
	public TaskAdditionalColt1()
	{
		base.NameTask = "Антирад на барьер";
		base.TextTask = "Стой, сталкер! Кто такой? Чего здесь выискиваешь?...\nБыла такая заварушка с неделю назад, пришлось пошуметь немножко... Оружие говоришь особенное? Ну извини, что в бою добыто, то нового владельца нашло законно... Боевые трофеи никто не отменял, но в качестве исключения и жеста доброй воли к вольным сталкерам, мы можем договориться.\nВо время того боя, наш человек хватил дозу радиации, ему необходимы антирадиационные препараты... Чем больше принесешь, тем лучше, но одного ему недостаточно. Как найдешь, бегом сюда, получишь свою игрушку...";
		base.DescriptionTask = "Принести на Барьер антирадиационные препараты - 2шт. Забрать кольт.";
		base.NamePointTask = "Барьер";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharPC596_128");
		base.AdditionalTask = true;
		base.GetToPointQuest = true;
	}
}
