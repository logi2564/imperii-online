using UnityEngine;

public class Slough : ConstructorPoints
{
	public Slough()
	{
		base.CurMap = "Backwater";
		base.namePoint = "Топь";
		base.pointTypes = PointTypes.Anomaly;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Болотистая местность, усеянная аномалиями «Трамплин» и «Кислотный туман». В Топь угодил падающий военный вертолёт.";
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.Repair = false;
		base.TaskChoise = false;
		base.XRay = 2;
		base.Burn = 0;
		base.ChemicalBurn = 2;
		base.curGexPoint = Gexa.GexLib[362];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
	}
}
