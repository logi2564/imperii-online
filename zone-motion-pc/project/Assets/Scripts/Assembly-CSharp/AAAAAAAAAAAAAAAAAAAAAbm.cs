using UnityEngine;

public class AAAAAAAAAAAAAAAAAAAAAbm : AAAAAAAAAAAAAAAy
{
	public AAAAAAAAAAAAAAAAAAAAAbm()
	{
		base.NameSubject = "Золотая рыбка";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Artefacts/goldfish");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
		base.CostSubject = 8000;
		base.DescriptionSubject = "Существенно помогает заживлению ран и ощутимо увеличивет защиту. Решай, что хуже - радиация или ножевые ранения, и выбирай из двух зол меньшее. Во всяком случае артефакт можно дорого продать.";
		base.WeightSubject = 0.4f;
		base.TypeSubj = TypeSubject.Artefact;
		base.Sanitation = 3f;
		base.Protection = 12f;
		base.XrayNegatife = 2;
	}
}
