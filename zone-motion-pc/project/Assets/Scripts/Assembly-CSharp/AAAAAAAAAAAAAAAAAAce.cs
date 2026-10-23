using UnityEngine;

public class AAAAAAAAAAAAAAAAAAce : AAAAAAAAAAAAAAAAbe
{
	public AAAAAAAAAAAAAAAAAAce()
	{
		base.NameSubject = "Детектор ''Медведь''";
		base.TextureSubject = (Texture2D)Resources.Load("Sprites/Subject/medved");
		base.AudioSlot = (AudioClip)Resources.Load("Sound/Suit/inv_ruck");
		base.CostSubject = 6000;
		base.DescriptionSubject = "Детектор аномальной активности прошлого поколения. Снабжён локатором аномальных образований и светодиодным таблом для отображения направления к артефакту. К сожалению, несколько устаревший список обнаруженных артефактов зашит в прибор на аппаратном уровне. Обнаруживает артефакт автоматически.";
		base.WeightSubject = 0.2f;
		base.TypeSubj = TypeSubject.Detector;
	}
}
