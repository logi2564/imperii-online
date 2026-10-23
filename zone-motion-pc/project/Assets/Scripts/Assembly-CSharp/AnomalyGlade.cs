using UnityEngine;

public class AnomalyGlade : ConstructorPoints
{
	public AnomalyGlade()
	{
		base.CurMap = "RedForest";
		base.namePoint = "Аномальная поляна";
		base.pointTypes = PointTypes.Anomaly;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Полностью безжизненный клочок местности, посередине и без того мрачного леса. Датчики аномальной активности здесь зашкаливают. Встретить на поляне мутанта или зомбированного - пара пустяков.";
		base.ControlInt = 10;
		base.DealerInt = 10;
		base.exchange = false;
		base.XRay = 2;
		base.curGexPoint = Gexa.GexLib[226];
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
