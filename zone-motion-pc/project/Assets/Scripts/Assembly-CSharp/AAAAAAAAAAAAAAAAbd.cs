using UnityEngine;

public class AAAAAAAAAAAAAAAAbd : AAAAAAAAAAAAAAAAAAk
{
	public AAAAAAAAAAAAAAAAbd()
	{
		base.NameSubject = "Аптечка армейская";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Subject/aptechkaArm");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_ruck");
		base.AudioFire = (AudioClip)Resources.Load("Sound/Suit/inv_properties");
		base.CostSubject = 325;
		base.DescriptionSubject = "Специализированный армейский медицинский набор.";
		base.WeightSubject = 0.25f;
		base.Sanitation = 33f;
		base.Bleeding = -3f;
		base.TypeSubj = TypeSubject.OtherSubject;
	}
}
