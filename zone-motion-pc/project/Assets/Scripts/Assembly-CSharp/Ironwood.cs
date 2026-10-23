using UnityEngine;

public class Ironwood : ConstructorPoints
{
	public Ironwood()
	{
		base.CurMap = "Backwater";
		base.namePoint = "Железный лес";
		base.pointTypes = PointTypes.Anomaly;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "На юго-западе Затона есть старая электроподстанция. В этом месте электричество «вышло» из проводов и трансформаторов, образовав большое поле аномалий «электра». Название опасная подстанция получила, видимо, из-за многочисленных металлических опор линий электропередачи на территории. В некоторых местах этой архианомалии наблюдается повышенный радиационный фон.";
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.Repair = false;
		base.TaskChoise = false;
		base.XRay = 3;
		base.Burn = 0;
		base.ChemicalBurn = 0;
		base.curGexPoint = Gexa.GexLib[125];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
	}
}
