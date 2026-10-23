using UnityEngine;

public class BlockpostFarm : ConstructorPoints
{
	public BlockpostFarm()
	{
		base.CurMap = "DarkValley";
		base.namePoint = "Блокпост у фермы";
		base.pointTypes = PointTypes.Field;
		base.pointControl = PointControl.Свобода;
		base.DescriptionPoint = "Оборудованный блокпост на юге долины, контролирует дорогу на Кордон.";
		base.ControlInt = 6;
		base.DealerInt = 6;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[28];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = GameObject.Find(base.curGexPoint.NameGex).transform.position;
		base.Teleport = "Kordon";
		base.TeleportName = " на Кордон";
		base.TeleportGex = Gexa.GexLib[279];
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
	}
}
