using UnityEngine;

public class TunnelAnomaly : ConstructorPoints
{
	public TunnelAnomaly()
	{
		base.CurMap = "Amber";
		base.namePoint = "Тунель с аномалиями";
		base.pointTypes = PointTypes.Anomaly;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Туннель представляет собой сточную трубу такого диаметра, что там свободно может разойтись два человека. По верху проходит дорога, ведущая от дикой территории к заводу.";
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.XRay = 2;
		base.curGexPoint = Gexa.GexLib[134];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
	}
}
