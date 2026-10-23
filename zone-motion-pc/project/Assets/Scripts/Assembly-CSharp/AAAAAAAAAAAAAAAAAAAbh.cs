using UnityEngine;

public class AAAAAAAAAAAAAAAAAAAbh : AAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAAAAbh()
	{
		base.NameSubject = "Ящик с оружием";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Subject/weaponBox");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_ruck");
		base.CostSubject = 20000;
		base.DescriptionSubject = "Тяжёлый деревянный ящик с законсервированным оружием. Таким количеством можно вооружить целый отряд. Бандиты интересуются подобными вещами...";
		base.WeightSubject = 6f;
		base.TypeSubj = TypeSubject.QuestSubject;
	}
}
