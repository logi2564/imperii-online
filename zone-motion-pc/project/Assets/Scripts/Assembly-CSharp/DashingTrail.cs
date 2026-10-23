using UnityEngine;

public class DashingTrail : ConstructorPoints
{
	public DashingTrail()
	{
		base.CurMap = "RedForest";
		base.namePoint = "Лихая тропа";
		base.pointTypes = PointTypes.Field;
		base.pointControl = PointControl.Бандиты;
		base.DescriptionPoint = "Крайне опасная тропа к военным складам. Дорога проходит через выжженный излучением лес. Напороться здесь на мутантов, проще простого.";
		base.ControlInt = 2;
		base.DealerInt = 2;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[39];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		base.Teleport = "Military";
		base.TeleportName = " к военным складам";
		base.TeleportGex = Gexa.GexLib[582];
		base.TeleportDouble = "WildTerritory";
		base.TeleportNameDouble = " к дикой территории";
		base.TeleportGexDouble = Gexa.GexLib[586];
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
	}
}
