using UnityEngine;

public class TaskAdditionalSaveNovice1 : ConstructorTasks
{
	public TaskAdditionalSaveNovice1()
	{
		base.NameTask = "Баламут";
		base.TextTask = "Эй, сталкер! помоги! Придавило меня кучей ржавого железа...\nСпасибо, дружище, выручил...\nПрознал я в деревне, будто в аномалии рядом с тепловозом, артефактов полным полно! Родятся, как грибы, собирать не успевают... \nПравда, это или шутка какая, разбираться не стал, так как хабара путевого, еще в глаза не видел. Я в Зоне не долго, ни снаряжения, ни оружия толкового. Мне бы выручка за артефакты, очень даже кстати...\nДобрался до тепловоза, как бывалые учили, с болтами и детектором... Как только получил сигнал об артефакте, как нарочно, пара слепых псов из кустов, и прямиком ко мне. Спасло, что они в аномалию вляпались,... шум, визг, хлопки со всех сторон и как шандарахнет... Очнулся, псы в клочья, а меня железом, что от тепловоза оторвало, придавило. Только сил и хватило, что сигнал о помощи отправить.\nМне бы теперь до деревни добраться, да измотан я сильно, не дойду сам. Помоги, братуха, во век не забуду?";
		base.DescriptionTask = "Доставить Баламута в деревню новичков.";
		base.NamePointTask = "Деревня новичков";
		base.KillCharacterName = "Баламут, Одиночки";
		base.MapName = "Kordon";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconCharJacket128");
		base.AdditionalTask = true;
		base.GuideQuest = true;
	}
}
