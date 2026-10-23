using UnityEngine;

public class AAAAAAAAAAAAAAAba : AAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAba()
	{
		base.NameSubject = "Щупальца кровососа";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Subject/bloodsuckersArm");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_ruck");
		base.CostSubject = 1750;
		base.DescriptionSubject = "У сталкеров есть поверье, что зуб кровососа, находящийся на его щупальцах, приносит удачу: «того, кто на шее носит такой зуб, аномалии отпускают, и артефакты сами в руки идут». Также щупальца имеют большое внимание со стороны учёных, возможно, в области медицины.";
		base.WeightSubject = 0.5f;
		base.TypeSubj = TypeSubject.MutantsSubject;
	}
}
