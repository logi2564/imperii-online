using UnityEngine;

public class Sawmill : ConstructorPoints
{
	public Sawmill()
	{
		base.CurMap = "Backwater";
		base.namePoint = "Лесопилка";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.Зомби;
		base.DescriptionPoint = "Старая, давно заброшенная лесопилка, в северо-западной части Затона. Непонятно, по каким причинам стала излюбленным местом зомбированных.";
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
		base.ControlInt = 10;
		base.DealerInt = 10;
		base.exchange = true;
		base.Repair = true;
		base.TaskChoise = true;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[561];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
	}
}
