using UnityEngine;

public class TaskAdditionalReturnBearMod1 : ConstructorTasks
{
	public TaskAdditionalReturnBearMod1()
	{
		base.NameTask = "Тайник Хмурого и Копченого";
		base.TextTask = "Стой, сталкер, не стреляй.\nМеня зовут, Хмурый. Я под паханом работаю. Подранили меня твои дружки, нейтралы, дотянуть бы до своих.\nНе будь редиской, уйди с дороги. У тебя свой путь, у меня свой. Даст бог, не встретимся больше...\nНа агропроме говоришь, хабар у сталкеров отжали?\nДа, было дело, пару недотеп обчистили. Ну да это дело житейское, вчера нам свезло, сегодня, как видишь, тебе... Но коли, перегнули чуть, так извиняйте, не со зла.\nПосторонись, мил человек, не гоже правильному сталкеру с полудохлым бандюгой, счета сводить, а я так и быть, скажу, где Копченый, ваш хабар припрятал.\nНаш тайник находится вентиляционной шахте, южнее завода ''Агропром''.\nБывай, сталкер.";
		base.DescriptionTask = "Добраться до точки: ''Вентиляционная шахта'', Агропром. Забрать из тайника остатки хабара.";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		if (Data.CharacterD.Count > 0)
		{
			base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharCloak128");
		}
		else
		{
			base.ImageTask = (Texture2D)Resources.Load("Sprites/QuestSubject/netrals0");
		}
		base.AdditionalTask = true;
	}
}
