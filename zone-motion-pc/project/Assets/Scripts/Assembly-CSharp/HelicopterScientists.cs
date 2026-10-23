using UnityEngine;

public class HelicopterScientists : ConstructorPoints
{
	public HelicopterScientists()
	{
		base.CurMap = "WildTerritory";
		base.namePoint = "Вертолет ученых";
		base.pointTypes = PointTypes.Field;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Разбившийся Ми-24, на котором группа ученых возвращалась с Янтаря на Большую землю. Место падения усеяно останками погибшего экипажа.";
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[369];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
	}
}
