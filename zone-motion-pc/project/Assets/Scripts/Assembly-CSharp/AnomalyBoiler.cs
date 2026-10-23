using UnityEngine;

public class AnomalyBoiler : ConstructorPoints
{
	public AnomalyBoiler()
	{
		base.CurMap = "Backwater";
		base.namePoint = "Аномалия ''Котел''";
		base.pointTypes = PointTypes.Anomaly;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Разновидность аномалии «Разлом», образовавшаяся в заболоченной местности. В трещинах глубиной до нескольких метров и в более глубоких слоях влажной почвы скопившаяся вода разогревается до высоких температур, периодически вырываясь под высоким давлением наружу струями пара, из-за чего и получила такое название.";
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.Repair = false;
		base.TaskChoise = false;
		base.XRay = 0;
		base.Burn = 2;
		base.curGexPoint = Gexa.GexLib[578];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
	}
}
