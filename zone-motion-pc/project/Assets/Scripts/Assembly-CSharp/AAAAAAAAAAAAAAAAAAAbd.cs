using UnityEngine;

public class AAAAAAAAAAAAAAAAAAAbd : AAAAAAAAAAAAAAAy
{
	public AAAAAAAAAAAAAAAAAAAbd()
	{
		base.NameSubject = "Бенгальский огонь";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Artefacts/bengalfire1");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
		base.CostSubject = 2000;
		base.DescriptionSubject = "Немного увеличивет пулевую и радиационную защиту. Довольно распространённый и недорогой артефакт. Тем не менее ценится среди исследователей Зоны за его свойства.";
		base.WeightSubject = 0.4f;
		base.TypeSubj = TypeSubject.Artefact;
		base.Protection = 2f;
		base.XRayProtection = 1;
	}
}
