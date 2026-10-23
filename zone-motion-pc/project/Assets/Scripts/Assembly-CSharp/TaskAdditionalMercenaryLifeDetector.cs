using UnityEngine;

public class TaskAdditionalMercenaryLifeDetector : ConstructorTasks
{
	public TaskAdditionalMercenaryLifeDetector()
	{
		base.NameTask = "Вернуть детектор";
		base.TextTask = "Был среди нас боец, звали его - Мутный. Толковый парень, никогда не подводил, вроде... Одно за ним замечалось: слишком жаден до денег и хабара. Одним словом, не любил он делиться. Так вот... Поручили ему работенку, не пыльную, добыть одну вещицу, весьма не дешевую. Добыть ее он видимо сумел, но почему-то с ренегатами спутался и до нашего заказчика доставить не удосужился. Как видно решил сбросить ее подороже на стороне. Так вот, необходимо доставить нам эту вещицу. А с бойцом нашим бывшим сам решай, что делать. Ну а если так случится, что он живой останется, уж мои ребятки с ним ''пообщаются''. Его следы теряются в районе Военных складов. Бывай.";
		base.DescriptionTask = "Принести";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAAAbr();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharMersenary128");
		base.AdditionalTask = true;
		base.SubjectQuest = true;
	}
}
