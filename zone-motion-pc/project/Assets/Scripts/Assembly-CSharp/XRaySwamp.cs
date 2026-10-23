using UnityEngine;

public class XRaySwamp : ConstructorPoints
{
	public XRaySwamp()
	{
		base.CurMap = "Kordon";
		base.namePoint = "Болото радиоактивных отходов";
		base.pointTypes = PointTypes.Anomaly;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Болотистая местность севернее деревни новичков. Кто-то сбросил в болото несколько бочек с радиоактивными отходами и теперь это и без того неприятное местечко стало смертельно опасным.";
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.Repair = false;
		base.XRay = 3;
		base.curGexPoint = Gexa.GexLib[260];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = GameObject.Find(base.curGexPoint.NameGex).transform.position;
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
	}
}
