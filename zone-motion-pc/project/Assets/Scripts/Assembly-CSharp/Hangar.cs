using UnityEngine;

public class Hangar : ConstructorPoints
{
	public Hangar()
	{
		base.CurMap = "Dump";
		base.namePoint = "Ангар";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.Одиночки;
		base.DescriptionPoint = "Заброшенное депо в центре Свалки. Раньше имелось железнодорожное соединение с фабрикой около НИИ «Агропром». К сожалению сейчас железнодорожный тоннель завален. Туда же, а также к самому институту, от территории ангара проложена автомобильная дорога. Другая дорога, начинающаяся с восточной стороны, ведёт от завода «Росток» (минуя барахолку) на Кордон.";
		base.ControlInt = 1;
		base.DealerInt = 1;
		base.exchange = true;
		base.Repair = true;
		base.TaskChoise = true;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[327];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = GameObject.Find(base.curGexPoint.NameGex).transform.position;
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
	}
}
