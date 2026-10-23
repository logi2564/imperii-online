using UnityEngine;

public class RoadToAmber : ConstructorPoints
{
	public RoadToAmber()
	{
		base.CurMap = "WildTerritory";
		base.namePoint = "Дорога к озеру";
		base.pointTypes = PointTypes.Field;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Дорога, ведущая  заводу ''Янтарь'' и одноименному, пересохшему озеру. Со стороны озера доносятся одиночные выстрелы. Датчики аномальной активности указывают на близость аномалий, но при приближении их не обнаруживает. Гайки и болты также не помогают их обнаружить. Видимо, аномалии находятся под землей или высоко в воздухе, так что проходить можно без опасений.";
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[14];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		base.Teleport = "Amber";
		base.TeleportName = " к Янтарю";
		base.TeleportGex = Gexa.GexLib[39];
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
	}
}
