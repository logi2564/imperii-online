using UnityEngine;

public class AAAAAAAAAAAAAAAAAAbp : AAAAAAAAAAAAAAAy
{
	public AAAAAAAAAAAAAAAAAAbp()
	{
		base.NameSubject = "Ломоть мяса";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Artefacts/meat");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
		base.CostSubject = 4000;
		base.DescriptionSubject = "Стимулирует усиленный рост клеток, тем самым хорошо способствует заживлению ран. С другой стороны, молодые клетки организма более восприимчивы ко многим видам физического урона. Артефакт попадается нечасто, но его нельзя назвать уникальным.";
		base.WeightSubject = 0.4f;
		base.TypeSubj = TypeSubject.Artefact;
		base.Sanitation = 4f;
		base.XrayNegatife = 1;
	}
}
