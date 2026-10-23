using UnityEngine;

public class CommodityComposition : ConstructorPoints
{
	public CommodityComposition()
	{
		base.CurMap = "Marsh";
		base.namePoint = "Товарный состав";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Товарный состав из нескольких старых вагонов, один из которых искорежен гравитационной аномалией. Расположен на железнодорожном пути около перехода на Агропром.";
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.Repair = false;
		base.TaskChoise = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[612];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		base.Teleport = "Agroprom";
		base.TeleportName = " на Агропром";
		base.TeleportGex = Gexa.GexLib[12];
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
	}
}
