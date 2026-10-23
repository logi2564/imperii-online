using UnityEngine;

public class FactoryFloor : ConstructorPoints
{
	public FactoryFloor()
	{
		base.CurMap = "WildTerritory";
		base.namePoint = "Заводской цех";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Заводской цех, с частично сохранившимся оборудованием. Представляет собой неплохую укреп точку на Дикой территории. Многие группировки пытаются установить здесь свой контроль. Радиационный фон в норме.";
		base.ControlInt = 5;
		base.DealerInt = 5;
		base.exchange = true;
		base.TaskChoise = true;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[228];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
	}
}
