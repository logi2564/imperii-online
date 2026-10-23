using UnityEngine;

public class AAAAAAAAAAAAAAAAbf : AAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAbf()
	{
		base.NameSubject = "Часть тела контролера";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Subject/ControlerHand");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_ruck");
		base.CostSubject = 1900;
		base.DescriptionSubject = "Часть тела мутанта-телепата, представляет особый интерес для ученых. Так как встречается редко, ученые готовы платить больше... ";
		base.WeightSubject = 0.4f;
		base.TypeSubj = TypeSubject.MutantsSubject;
	}
}
