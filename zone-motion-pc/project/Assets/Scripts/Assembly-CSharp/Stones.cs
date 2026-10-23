using UnityEngine;

public class Stones : ConstructorPoints
{
	public Stones()
	{
		base.CurMap = "DarkValley";
		base.namePoint = "Груда камней";
		base.pointTypes = PointTypes.Anomaly;
		base.pointControl = PointControl.Чистое_небо;
		base.DescriptionPoint = "Оборудованная для недолгосрочной обороны стоянка на комнях, расположена на северо-востоке долины.";
		base.ControlInt = 7;
		base.DealerInt = 7;
		base.exchange = false;
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
