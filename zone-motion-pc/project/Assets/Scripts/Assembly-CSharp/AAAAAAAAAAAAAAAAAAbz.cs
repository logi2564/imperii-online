using UnityEngine;

public class AAAAAAAAAAAAAAAAAAbz : AAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAAAbz()
	{
		base.NameSubject = "Неисправный ПСИ-шлем";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Subject/psyhelm");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_ruck");
		base.CostSubject = 50000;
		base.DescriptionSubject = "Прототип устройства защиты от ПСИ-излучения. Бесценный научный прибор. К сожалению неисправен, но умелый мастер сможет заставить его работать...";
		base.WeightSubject = 0.8f;
		base.TypeSubj = TypeSubject.QuestSubject;
	}
}
