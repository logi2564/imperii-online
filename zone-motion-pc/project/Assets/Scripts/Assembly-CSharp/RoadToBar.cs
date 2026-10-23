using UnityEngine;

public class RoadToBar : ConstructorPoints
{
	public RoadToBar()
	{
		base.CurMap = "WildTerritory";
		base.namePoint = "Дорога к Бару";
		base.pointTypes = PointTypes.Field;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Дорога, проходящая по огромной территории разрушенного завода, ведущая на территорию, контролируемую  долгом. Иногда, здесь стоят бойцы Долга.";
		base.ControlInt = 4;
		base.DealerInt = 4;
		base.exchange = true;
		base.TaskChoise = true;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[379];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		base.Teleport = "Bar";
		base.TeleportName = " к бару";
		base.TeleportGex = Gexa.GexLib[300];
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
	}
}
