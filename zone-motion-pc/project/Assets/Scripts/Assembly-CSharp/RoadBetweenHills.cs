using UnityEngine;

public class RoadBetweenHills : ConstructorPoints
{
	public RoadBetweenHills()
	{
		base.CurMap = "Military";
		base.namePoint = "Дорога между холмами";
		base.pointTypes = PointTypes.Field;
		base.pointControl = PointControl.Долг;
		base.DescriptionPoint = "Эта дорога напрямую соединяет Бар с Военными складами, и по этой причине, является местом частых столкновений Долга и Свободы. ";
		base.ControlInt = 4;
		base.DealerInt = 4;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[180];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		base.Teleport = "Bar";
		base.TeleportName = " к бару";
		base.TeleportGex = Gexa.GexLib[560];
		base.TeleportDouble = "WildTerritory";
		base.TeleportNameDouble = " к дикой территории";
		base.TeleportGexDouble = Gexa.GexLib[615];
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
	}
}
