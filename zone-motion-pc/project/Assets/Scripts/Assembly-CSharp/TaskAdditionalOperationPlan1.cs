using UnityEngine;

public class TaskAdditionalOperationPlan1 : ConstructorTasks
{
	public TaskAdditionalOperationPlan1()
	{
		base.NameTask = "Найти капитана Ширко";
		base.TextTask = "Вылазка в знание института принесла свои плоды. Среди хлама и ржавого мусора, был обнаружен старый насыпной сейф, в котором находился пакет с рапортом исполняющего обязанности командира боевой группы военных, капитана Ширко, вышестоящему руководству.\nВ рапорте описаны результаты разведки на территории комплекса Агропром. Указывается сведения о получении плана проведения боевой операции.\nКак видно, мне теперь необходимо найти этого капитана и добыть у него план операции любым способом.";
		base.DescriptionTask = "Найти капитана Ширко. Добыть любым способом план операции.";
		base.QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		base.RewardMoney = 0;
		if (Data.CharacterD.Count > 0)
		{
			base.ImageTask = Data.CharacterD[0].SuitChar.IconCharacter;
		}
		else
		{
			base.ImageTask = (Texture2D)Resources.Load("Sprites/IconChar/iconStalkerSuit128");
		}
		base.AdditionalTask = true;
	}
}
