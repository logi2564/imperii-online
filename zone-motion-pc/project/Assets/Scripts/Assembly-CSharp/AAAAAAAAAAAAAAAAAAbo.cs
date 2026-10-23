using UnityEngine;

public class AAAAAAAAAAAAAAAAAAbo : AAAAAAAAAAAAAAAy
{
	public AAAAAAAAAAAAAAAAAAbo()
	{
		base.NameSubject = "Кровь камня";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Artefacts/stoneblood");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
		base.CostSubject = 2000;
		base.DescriptionSubject = "Представляет собой довольно уродливое красноватое образование из спресованных и причудливо изогнутых полимеризированных останков растений, почвы и костей. Помогает заживлению ран.";
		base.WeightSubject = 0.5f;
		base.TypeSubj = TypeSubject.Artefact;
		base.Sanitation = 2f;
	}
}
