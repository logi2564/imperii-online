using UnityEngine;

public class ElectraNorthWildTerritory : ConstructorPoints
{
	public ElectraNorthWildTerritory()
	{
		base.CurMap = "WildTerritory";
		base.namePoint = "Электра на севере Дикой территории";
		base.pointTypes = PointTypes.Anomaly;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Аномалия Электра, расположена на севере Дикой территории. Частенько сталкеры возвращаются отсюда с хорошим товаром.";
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.XRay = 1;
		base.curGexPoint = Gexa.GexLib[519];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
	}
}
