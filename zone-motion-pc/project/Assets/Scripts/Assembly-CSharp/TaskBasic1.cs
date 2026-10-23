using UnityEngine;

public class TaskBasic1 : ConstructorTasks
{
	public TaskBasic1()
	{
		base.NameTask = "Флешка убитого сталкера";
		base.TextTask = "О! Кого я вижу? С возвращением, Сталкер! Давненько тебя не видели в здешних местах! Соскучился по мутантам и аномалиям? Ну, тогда могу подкинуть тебе работенку... Шутки в сторону. Я отправил курьера с информацией на базу нейтралов на Агропром. На севере Кордона, попал он в засаду, то ли бандитов, то ли наемников... В общем, информацию надо, доставить по адресу. Там и награду получишь, и по своим делам справишься. Лады?";
		base.DescriptionTask = "Найти погибшего сталкера и забрать у него флешку.";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/Sidor128");
		base.NamePointTask = "Дорога на свалку";
		base.MapName = "Kordon";
	}
}
