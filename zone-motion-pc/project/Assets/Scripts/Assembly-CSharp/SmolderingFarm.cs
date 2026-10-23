using UnityEngine;

public class SmolderingFarm : ConstructorPoints
{
	public SmolderingFarm()
	{
		base.CurMap = "Backwater";
		base.namePoint = "Тлеющий хутор";
		base.pointTypes = PointTypes.Anomaly;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Это место представляет из себя несколько полуразрушенных, тлеющих бревенчатых изб. Хутор изобилует большим количеством «жарок». Здесь часто можно найти артефакты, часто рядом с аномалиями можно увидеть вольных сталкеров и бандитов.";
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.Repair = false;
		base.TaskChoise = false;
		base.XRay = 0;
		base.Burn = 2;
		base.curGexPoint = Gexa.GexLib[529];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
	}
}
