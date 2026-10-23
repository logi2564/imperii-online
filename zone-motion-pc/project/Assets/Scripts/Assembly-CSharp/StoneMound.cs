using UnityEngine;

public class StoneMound : ConstructorPoints
{
	public StoneMound()
	{
		base.CurMap = "WildTerritory";
		base.namePoint = "Каменная насыпь";
		base.pointTypes = PointTypes.Field;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Пара искусственных холмов камня и щебенки, привезенных для строительных нужд в лучшие времена. Использовать по назначению, видимо не успели... Безлюдное местечко с унылым пейзажем, которое облюбовали мутанты.";
		base.ControlInt = 9;
		base.DealerInt = 9;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[341];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
	}
}
