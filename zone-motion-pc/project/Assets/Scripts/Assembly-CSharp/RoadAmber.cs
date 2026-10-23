using UnityEngine;

public class RoadAmber : ConstructorPoints
{
	public RoadAmber()
	{
		base.CurMap = "Agroprom";
		base.namePoint = "Переход на янтарь";
		base.pointTypes = PointTypes.None;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Узкая тропинка между холмов, часто можно встретить зомбированных.";
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[587];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = GameObject.Find(base.curGexPoint.NameGex).transform.position;
		base.Teleport = "Amber";
		base.TeleportName = " к Янтарю";
		base.TeleportGex = Gexa.GexLib[2];
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
	}
}
