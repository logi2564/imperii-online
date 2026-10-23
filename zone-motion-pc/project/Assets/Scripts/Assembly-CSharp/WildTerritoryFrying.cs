using UnityEngine;

public class WildTerritoryFrying : ConstructorPoints
{
	public WildTerritoryFrying()
	{
		base.CurMap = "WildTerritory";
		base.namePoint = "Жарка на дикой территории";
		base.pointTypes = PointTypes.Anomaly;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "В неактивном состоянии выглядит как едва видимое облако горячего воздуха, однако при попадании в зону действия любого предмета или живого существа образует компактную зону, разогретую до температуры около 1230 °C.";
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.XRay = 1;
		base.curGexPoint = Gexa.GexLib[543];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
	}
}
