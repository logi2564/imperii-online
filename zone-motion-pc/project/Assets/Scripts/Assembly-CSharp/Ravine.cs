using UnityEngine;

public class Ravine : ConstructorPoints
{
	public Ravine()
	{
		base.CurMap = "Radar";
		base.namePoint = "Мертвый овраг";
		base.pointTypes = PointTypes.Anomaly;
		base.pointControl = PointControl.Мутанты;
		base.DescriptionPoint = "Название оврага однозначно характеризует местность. В нем много зомбированных, снорков, слепых псов, псевдособак, кровососов.";
		base.ControlInt = 9;
		base.DealerInt = 9;
		base.exchange = false;
		base.XRay = 3;
		base.curGexPoint = Gexa.GexLib[211];
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
