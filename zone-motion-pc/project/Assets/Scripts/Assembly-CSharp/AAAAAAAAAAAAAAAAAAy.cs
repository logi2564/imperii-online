using UnityEngine;

public class AAAAAAAAAAAAAAAAAAy : AAAAAAAAAAAAAAAy
{
	public AAAAAAAAAAAAAAAAAAy()
	{
		base.NameSubject = "Батарейка";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Artefacts/batareyka");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
		base.CostSubject = 2000;
		base.DescriptionSubject = "Известно, что в состав этого артефакта входят диэлектрические элементы, однако при каких физических условиях он формируется, науке пока не известно. Ценится среди жителей и гостей Зоны за способность оказывать на организм человека тонизирующее воздействие.";
		base.WeightSubject = 0.4f;
		base.Force = 4f;
		base.TypeSubj = TypeSubject.Artefact;
	}
}
