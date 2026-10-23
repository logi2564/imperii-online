using UnityEngine;

public class AAAAAAAAAAAAAAAAAAAAbl : AAAAAAAAAAAAAAAy
{
	public AAAAAAAAAAAAAAAAAAAAbl()
	{
		base.NameSubject = "Вспышка";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Artefacts/flash");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
		base.CostSubject = 4000;
		base.DescriptionSubject = "Увеличивает пулевую и радиационную защиту. Сталкеры используют его с большой охотой из-за его неплохих качеств. Неплохая цена и приятный внешний вид делают его интересным для коллекционеров.";
		base.WeightSubject = 0.4f;
		base.Protection = 4f;
		base.TypeSubj = TypeSubject.Artefact;
		base.XrayNegatife = 1;
		base.XRayProtection = 2;
	}
}
