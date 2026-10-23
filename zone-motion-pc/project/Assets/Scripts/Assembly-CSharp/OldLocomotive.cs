using UnityEngine;

public class OldLocomotive : ConstructorPoints
{
	public OldLocomotive()
	{
		base.CurMap = "WildTerritory";
		base.namePoint = "Старый локомотив";
		base.pointTypes = PointTypes.Field;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Железнодорожный состав, брошенный прямо на рельсах. Таких в Зоне отчуждения полным полно. Радиационный фон в норме.";
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[409];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
	}
}
