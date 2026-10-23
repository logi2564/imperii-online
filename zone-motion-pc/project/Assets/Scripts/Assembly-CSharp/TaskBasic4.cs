using UnityEngine;

public class TaskBasic4 : ConstructorTasks
{
	public TaskBasic4()
	{
		base.NameTask = "Мертвый город";
		base.TextTask = "День добрый. Информация о схеме Выжигателя?... Нет, не сталкивался с подобным. А наемники здесь появлялись, ничего конкретного не предлагали, только от работы отвлекли. Да и еще помошник мой, Механик, куда-то после этого запропастился. Толковый парень, ... не зря его так прозвали... Ходят слухи, что наемники обосновались в Мертвом городе. Больше я ничего не знаю.";
		base.DescriptionTask = "Найти лидера наемников.";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/saharov128");
		base.NamePointTask = "Горком КПСС";
		base.MapName = "DeadCity";
	}
}
