using UnityEngine;

public class AAAAAAAAAAAAAAAAbi : AAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAbi()
	{
		base.NameSubject = "Детектор ''Велес''";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Subject/veles");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_ruck");
		base.CostSubject = 15000;
		base.DescriptionSubject = "Детектор-сканер нового поколения, используемый учёными. Благодаря трём усовершенствованным регистрационным камерам расположение артефакта относительно детектора показывается на специальном экране. Способен фиксировать излучение и присутствие аномалий на расстоянии";
		base.WeightSubject = 0.2f;
		base.TypeSubj = TypeSubject.Detector;
	}
}
