using UnityEngine;

public class AnomalyCave : ConstructorPoints
{
	public AnomalyCave()
	{
		base.CurMap = "Agroprom";
		base.namePoint = "Пещера с аномалиями";
		base.pointTypes = PointTypes.Anomaly;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Скопление аномалий на юго-западе Агропрома. Отсюда бавалые сталкеры без хабара не возвращаются...";
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.XRay = 2;
		base.curGexPoint = Gexa.GexLib[22];
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
