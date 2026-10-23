using UnityEngine;

public class TaskAdditionalDecoderMonolith : ConstructorTasks
{
	public TaskAdditionalDecoderMonolith()
	{
		base.NameTask = "Принести Декодер";
		base.TextTask = "Привет брат! Наши дела продвигаются неплохо. Сталкеров на подступах Радара стало меньше. Однако многое еще надо сделать. Наши разведчики в глубинах лаборатории наткнулись на дверь, открыть или взорвать которую не получится. Документация описывает способ взлома двери, однако необходим декодер. Подобный декодер был похищен из лаборатории О-Сознания. Последние следы прибора терялись в районе озера янтарь. Твоя задача найти прибор и доставить его сюда, во имя Великого Монолита!";
		base.DescriptionTask = "Принести ";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharMonolit128");
		base.AdditionalTask = true;
		base.SubjectQuest = true;
	}
}
