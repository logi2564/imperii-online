using UnityEngine;

public class AAAAAAAAAAAAAAAAAAAbg : AAAAAAAAAAAAAAAAAAk
{
	public AAAAAAAAAAAAAAAAAAAbg()
	{
		base.NameSubject = "Аптечка";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Subject/aptechka");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_ruck");
		base.AudioFire = (AudioClip)Resources.Load("Sound/Suit/inv_properties");
		base.CostSubject = 270;
		base.DescriptionSubject = "Универсальный медицинский набор.";
		base.WeightSubject = 0.25f;
		base.Sanitation = 25f;
		base.Bleeding = -1f;
		base.TypeSubj = TypeSubject.OtherSubject;
	}
}
