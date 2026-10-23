using UnityEngine;

public class AAAAAAAAAAAAAAAAAAAAAbn : AAAAAAAAAAAAAAAy
{
	public AAAAAAAAAAAAAAAAAAAAAbn()
	{
		base.NameSubject = "Ночная звезда";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Artefacts/nightstar");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
		base.CostSubject = 8000;
		base.DescriptionSubject = "Увеличивает силу, защиту и остановливает кровотечение.\nИспользование артефакта требует нейтрализации смертельного радиоактивного излучения. Дорогой и редкостный, но чрезвычайно интересный для научных экспедиций и прочих исследователей активности Зоны.";
		base.WeightSubject = 0.4f;
		base.TypeSubj = TypeSubject.Artefact;
		base.Protection = 8f;
		base.Bleeding = -3f;
		base.Force = 8f;
		base.XrayNegatife = 2;
	}
}
