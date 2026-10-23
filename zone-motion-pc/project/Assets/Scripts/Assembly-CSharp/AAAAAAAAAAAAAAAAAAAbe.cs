using UnityEngine;

public class AAAAAAAAAAAAAAAAAAAbe : AAAAAAAAAAAAAAAy
{
	public AAAAAAAAAAAAAAAAAAAbe()
	{
		base.NameSubject = "Лунный свет";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Artefacts/moonlight");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
		base.CostSubject = 8000;
		base.DescriptionSubject = "Существенно увеличивает пулевую и радиационную защиту.\nВырожденный случай активности аномалии ''Электра''. Видимо, такую замечательную округлую форму можно получить, если подвергнуть аномалию термовоздействию. Дорогой артефакт.";
		base.WeightSubject = 0.4f;
		base.Protection = 6f;
		base.TypeSubj = TypeSubject.Artefact;
		base.XrayNegatife = 2;
		base.XRayProtection = 3;
	}
}
