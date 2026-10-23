using UnityEngine;

public class AnomalyRing : ConstructorPoints
{
	public AnomalyRing()
	{
		base.CurMap = "Bar";
		base.namePoint = "Аномалия Кольцо";
		base.pointTypes = PointTypes.Anomaly;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Аномалия на северо-востоке бара. Обычно опытные сталкеры отсюда без добычи не возвращаются.";
		base.ControlInt = 0;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[598];
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
