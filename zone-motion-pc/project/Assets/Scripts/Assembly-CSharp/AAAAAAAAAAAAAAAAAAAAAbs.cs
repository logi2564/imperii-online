using UnityEngine;

public class AAAAAAAAAAAAAAAAAAAAAbs : AAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAAAAAAbs()
	{
		base.NameSubject = "Детали";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Subject/SpareParts");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_ruck");
		base.CostSubject = 1000;
		base.DescriptionSubject = "Снятые с какого-то механизма детали. Назначение непонятно. Наемники в Рыжем лесу разыскивали пару бандитов, укравших, что-то подобное... ";
		base.WeightSubject = 1f;
		base.TypeSubj = TypeSubject.QuestSubject;
	}
}
