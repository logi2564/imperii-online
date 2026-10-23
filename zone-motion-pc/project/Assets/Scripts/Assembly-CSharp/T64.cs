using UnityEngine;

public class T64 : ConstructorPoints
{
	public T64()
	{
		base.CurMap = "RedForest";
		base.namePoint = "Т-64";
		base.pointTypes = PointTypes.Anomaly;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Лесной массив, в котором стоит брошенный советский ОБТ Т-64. По словам бывалых сталкеров, танк появился в Рыжем лесу после Большого выброса.";
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.XRay = 4;
		base.curGexPoint = Gexa.GexLib[436];
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
