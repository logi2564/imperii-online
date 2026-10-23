using UnityEngine;

public class TruckBroken : ConstructorPoints
{
	public TruckBroken()
	{
		base.CurMap = "Kordon";
		base.namePoint = "Разбитый грузовик";
		base.pointTypes = PointTypes.Anomaly;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "«Грузовиками смерти» сталкеры называют грузовики, выезжающие из центра Зоны и везущие полуживых или мёртвых сталкеров. Кто ими управляет, никому не известно. Один из таких перевернулся...";
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.XRay = 3;
		base.curGexPoint = Gexa.GexLib[578];
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
