using UnityEngine;

public class guideToMilitary : ConstructorPoints
{
	public guideToMilitary()
	{
		base.CurMap = "Amber";
		base.namePoint = "Проводник к военным складам";
		base.pointTypes = PointTypes.Field;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "На северо-востоке от завода ''Янтарь'', можно найти молчаливого сталкера, который проведет прямо к военным складам.";
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[578];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		base.Teleport = "Military";
		base.TeleportName = " к военным складам";
		base.TeleportGex = Gexa.GexLib[300];
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
	}
}
