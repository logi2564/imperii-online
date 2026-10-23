using UnityEngine;

public class RoadMilitary : ConstructorPoints
{
	public RoadMilitary()
	{
		base.CurMap = "Bar";
		base.namePoint = "Дорога на военные склады";
		base.pointTypes = PointTypes.Field;
		base.pointControl = PointControl.Свобода;
		base.DescriptionPoint = "Дорога, начинается от центра бара и ведущая на северо-запад, к военным складам.";
		base.ControlInt = 6;
		base.DealerInt = 6;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[560];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = GameObject.Find(base.curGexPoint.NameGex).transform.position;
		base.Teleport = "Military";
		base.TeleportName = " на военные склады";
		base.TeleportGex = Gexa.GexLib[180];
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
