using UnityEngine;

public class AAAAAAAAAAAAAAAAbc : AAAAAAAAAAAAAAAy
{
	public AAAAAAAAAAAAAAAAbc()
	{
		base.NameSubject = "Пузырь";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Artefacts/BubbleArt");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
		base.CostSubject = 10000;
		base.DescriptionSubject = "Артефакт представляет из себя несколько соединенных полых образований органической природы. Выделяет газообразное вещество, способное нейтрализовать радиоактивные частицы в организме человека. Ввиду высокой эффективности пользуется огромным спросом.";
		base.WeightSubject = 0.7f;
		base.TypeSubj = TypeSubject.Artefact;
		base.XRaySanitation = 5;
	}
}
