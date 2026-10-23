using UnityEngine;

public class AAAAAAAAAAAAAAAAAAbq : AAAAAAAAAAAAAAAy
{
	public AAAAAAAAAAAAAAAAAAbq()
	{
		base.NameSubject = "Каменный цветок";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Artefacts/stoneflower");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
		base.CostSubject = 4000;
		base.DescriptionSubject = "Способствует увеличению силы, защиты и остановке кровотечения.\nТакой артефакт можно найти в немногих участакх Зоны. Вкрапления металлических соединений дают красивую игру света. Рассматривание этого артефакта в свете костра ночью замечательно успокаивает.";
		base.WeightSubject = 0.4f;
		base.TypeSubj = TypeSubject.Artefact;
		base.Protection = 5f;
		base.Bleeding = -2f;
		base.Force = 5f;
		base.XrayNegatife = 1;
	}
}
