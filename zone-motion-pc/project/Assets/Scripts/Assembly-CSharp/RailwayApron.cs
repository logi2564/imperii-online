using UnityEngine;

public class RailwayApron : ConstructorPoints
{
	public RailwayApron()
	{
		base.CurMap = "WildTerritory";
		base.namePoint = "Железнодорожный перрон";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Железнодорожный перрон, рядом располагаются складские помещения. На путях стоят два подвижных состава. По непонятной причине, мутанты облюбовали это местечко, и даже если кому-то удастся их выбить отсюда, то это ненадолго...";
		base.ControlInt = 10;
		base.DealerInt = 10;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[331];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
	}
}
