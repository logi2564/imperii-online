using UnityEngine;

public class AAAAAAAAAAAAAAAAw : AAAAAAAAAAAAAAAy
{
	public AAAAAAAAAAAAAAAAw()
	{
		base.NameSubject = "Душа";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Artefacts/soul1");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
		base.CostSubject = 9000;
		base.DescriptionSubject = "Способствует быстрому заживлению ран.  Найти такой артефакт удается лишь единицам, и мало кто его вообще видел. Он имеет приятную форму и не менее приятную цену. Многие сталкеры оставляют его для себя, так как при серьезном ренении, очень может пригодиться...";
		base.WeightSubject = 1f;
		base.TypeSubj = TypeSubject.Artefact;
		base.Sanitation = 7f;
		base.XrayNegatife = 2;
	}
}
