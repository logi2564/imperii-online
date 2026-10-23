using UnityEngine;

public class AAAAAAAAAAAAAAAAAAAbj : AAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAAAAbj()
	{
		base.NameSubject = "Записка Хмурого";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Subject/FrownNote");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_ruck");
		base.CostSubject = 1000;
		base.DescriptionSubject = "Записка бандита Хмурого подельнику Копченому. Потертый лист с корявым рукописным текстом\nЭту информацию можно продать бандитам и одиночкам, а может и еще кто заинтересуется...";
		base.WeightSubject = 0.01f;
		base.TypeSubj = TypeSubject.InformationSubject;
		base.TextOfDocument = "''Хмурый, после нашего гоп - стопа, сталкерня на агропроме громкий кипеш учинила. Пока не уляжется, сховал остатки хабара в наш тайник, ты знаешь о чем я... Как шум утихнет, скинем добытое или распилим между собой, поровну.\nДумаю надобно ховаться, до времени. Я теряюсь в центре Зоны. Как вернешься со свалки, не мозоль глаза на Агропроме, дуй за мной, тебя учить не надо...\n Бывай, свидимся.\nКопченый.''";
	}
}
