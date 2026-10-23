using UnityEngine;

public class Elevator : ConstructorPoints
{
	public Elevator()
	{
		base.CurMap = "Kordon";
		base.namePoint = "Элеватор";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Элеватор — представляет собой здание заброшенной мельницы и прилегающего к ней склада. Находится севернее деревни новичков. Как и другие хозяйственные постройки, является частью некогда массивного предприятия.";
		base.ControlInt = 10;
		base.DealerInt = 10;
		base.exchange = false;
		base.Repair = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[364];
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
