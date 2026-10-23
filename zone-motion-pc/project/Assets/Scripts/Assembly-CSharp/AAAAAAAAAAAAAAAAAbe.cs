using UnityEngine;

public class AAAAAAAAAAAAAAAAAbe : AAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAAbe()
	{
		base.NameSubject = "Мясо плоти";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Subject/meatOfFlesh");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_ruck");
		base.CostSubject = 800;
		base.DescriptionSubject = "Мясо плоти съедобно, но вкусовые качества неизвестны. В сложной ситуации, при отсутствии нормальной пищи, можно употребить его в пищу, чтобы не погибнуть от голода...";
		base.WeightSubject = 0.4f;
		base.TypeSubj = TypeSubject.OtherSubject;
		base.Hunger = 15;
		base.XrayNegatife = 1;
	}
}
