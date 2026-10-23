using UnityEngine;

public class WitchCircle : ConstructorPoints
{
	public WitchCircle()
	{
		base.CurMap = "RedForest";
		base.namePoint = "Ведьмин круг";
		base.pointTypes = PointTypes.Anomaly;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Скопление в западной части заповедника небольшого количества камней в форме круга. Место относительно спокойное, однако порой сюда забегают псевдособаки, реже - снорки, иногда забредает кровосос.";
		base.ControlInt = 8;
		base.DealerInt = 8;
		base.exchange = false;
		base.XRay = 0;
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
