using UnityEngine;

public class AAAAAAAAAAAAAAAbg : AAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAbg()
	{
		base.NameSubject = "Детектор ''Отклик''";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Subject/otklik");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_ruck");
		base.CostSubject = 1000;
		base.DescriptionSubject = "Устаревшая модель детектора аномальной активности. Реагирует звуковым сигналом на попадание аномальных частичек в специальную камеру, при приближении к аномалиям. Ввиду простоты конструкции способен находить только самые распространённые артефакты.";
		base.WeightSubject = 0.2f;
		base.TypeSubj = TypeSubject.Detector;
	}
}
