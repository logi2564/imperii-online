using UnityEngine;

public class AAAAAAAAAAAAAAAAAAAAAbo : AAAAAAAAAAAAAAAy
{
	public AAAAAAAAAAAAAAAAAAAAAbo()
	{
		base.NameSubject = "Кристальная колючка";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Artefacts/crystalkol");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
		base.CostSubject = 4000;
		base.DescriptionSubject = "Увеличивает защиту и останавливает кровь.\nРезультат взаимодействия аномалии ''Ржавые волосы'' и тела невнимательного сталкера. Шипастый артефакт колет тело владельца, как бы его не крепить. Довольно распространённый и дешёвый.";
		base.WeightSubject = 0.4f;
		base.TypeSubj = TypeSubject.Artefact;
		base.Protection = 6f;
		base.Bleeding = -2f;
		base.XrayNegatife = 1;
	}
}
