using UnityEngine;

public class AAAAAAAAAAAAAAAAAAbw : AAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAAAbw()
	{
		base.NameSubject = "Деньги";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Subject/Money");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_ruck");
		base.CostSubject = 1;
		base.DescriptionSubject = "Основной ресурс при купле-продаже, металлические и бумажные знаки...";
		base.WeightSubject = 0f;
		base.TypeSubj = TypeSubject.Money;
	}
}
