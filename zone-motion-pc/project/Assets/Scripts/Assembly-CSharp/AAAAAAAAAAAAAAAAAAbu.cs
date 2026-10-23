using UnityEngine;

public class AAAAAAAAAAAAAAAAAAbu : AAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAAAbu()
	{
		base.NameSubject = "Хвост слепого пса";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Subject/hvost");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_ruck");
		base.CostSubject = 1000;
		base.DescriptionSubject = "Устойчивость кожи мутировавших собак к химическому и электрическому воздействию давно обратила на себя внимание учёных. Из-за отсутствия жировых отложений хвосты собак наиболее подходят для лабораторных исследований.";
		base.WeightSubject = 0.4f;
		base.TypeSubj = TypeSubject.MutantsSubject;
	}
}
