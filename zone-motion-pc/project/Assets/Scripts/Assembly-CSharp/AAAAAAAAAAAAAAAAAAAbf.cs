using UnityEngine;

public class AAAAAAAAAAAAAAAAAAAbf : AAAAAAAAAAAAAAAy
{
	public AAAAAAAAAAAAAAAAAAAbf()
	{
		base.NameSubject = "Пустышка";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Artefacts/dummy");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
		base.CostSubject = 4000;
		base.DescriptionSubject = "Ранее этот артефакт считался хламом Зоны, лишённым каких-либо определённых свойств или характеристик. Но недавно было открыто, что при постоянном контакте с телом человека данный артефакт оказывает позитивное стимулирующее воздействие на нервную систему. Радиоактивен.";
		base.WeightSubject = 0.4f;
		base.Force = 7f;
		base.TypeSubj = TypeSubject.Artefact;
		base.XrayNegatife = 1;
	}
}
