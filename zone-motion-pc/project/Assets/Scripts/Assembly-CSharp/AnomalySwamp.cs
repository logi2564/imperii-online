using UnityEngine;

public class AnomalySwamp : ConstructorPoints
{
	public AnomalySwamp()
	{
		base.CurMap = "Dump";
		base.namePoint = "Аномальная трясина";
		base.pointTypes = PointTypes.Anomaly;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Маленькое болотце, наполненное аномалиями, расположенно на юго-востоке Свалки. Сталкеры поговаривали, что здесь можно разжиться артефактами...";
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.XRay = 3;
		base.curGexPoint = Gexa.GexLib[79];
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
