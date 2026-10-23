using UnityEngine;

public class Overpass : ConstructorPoints
{
	public Overpass()
	{
		base.CurMap = "WildTerritory";
		base.namePoint = "Путепровод";
		base.pointTypes = PointTypes.Anomaly;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Автомобильная дорога под железнодорожным мостом. На дороге находятся многочисленные, но небольшие по мощности жарки. Встречаются  одиночные, бредущие с озера Янтарь, зомбированные.";
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[153];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
	}
}
