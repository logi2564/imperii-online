using UnityEngine;

public class AAAAAAAAAAAAAAAAy : AAAAAAAAAAAAAAAAAAk
{
	public AAAAAAAAAAAAAAAAy()
	{
		base.NameSubject = "Аптечка научная";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Subject/aptechkaNeo");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_ruck");
		base.AudioFire = (AudioClip)Resources.Load("Sound/Suit/inv_properties");
		base.CostSubject = 420;
		base.DescriptionSubject = "Специализированный медицинский набор, разработанный для условий зоны.";
		base.WeightSubject = 0.25f;
		base.Sanitation = 30f;
		base.XRaySanitation = -2;
		base.Bleeding = -2f;
		base.TypeSubj = TypeSubject.OtherSubject;
	}
}
