using UnityEngine;

public class RoadToTheRedForest : ConstructorPoints
{
	public RoadToTheRedForest()
	{
		base.CurMap = "WildTerritory";
		base.namePoint = "Дорога к Рыжему лесу";
		base.pointTypes = PointTypes.Field;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Железнодорожное сообщение, проходящее около Рыжего леса. По пути встречаются многочисленные аномалии и стаи голодных слепых псов...";
		base.ControlInt = 3;
		base.DealerInt = 3;
		base.exchange = true;
		base.TaskChoise = true;
		base.Repair = true;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[586];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		base.Teleport = "RedForest";
		base.TeleportName = " в Рыжий лес";
		base.TeleportGex = Gexa.GexLib[39];
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
	}
}
