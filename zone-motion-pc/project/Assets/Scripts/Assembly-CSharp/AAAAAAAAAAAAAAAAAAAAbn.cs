using UnityEngine;

public class AAAAAAAAAAAAAAAAAAAAbn : AAAAAAAAAAAAAAAy
{
	public AAAAAAAAAAAAAAAAAAAAbn()
	{
		base.NameSubject = "Серый мох";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Artefacts/grayMoss");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
		base.CostSubject = 6000;
		base.DescriptionSubject = "Артефакт представляет из себя образование органической природы, внешне похожее на обыкновенный мох. При воздействии радиации, меняет изначальный зеленый цвет на серый и излучает свечение изнутри. Нейтрализует радиоактивные частицы в организме человека. Ввиду эффективности пользуется хорошим спросом.";
		base.WeightSubject = 0.7f;
		base.TypeSubj = TypeSubject.Artefact;
		base.XRaySanitation = 2;
	}
}
