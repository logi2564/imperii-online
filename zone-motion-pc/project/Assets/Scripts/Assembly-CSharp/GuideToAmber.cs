using UnityEngine;

public class GuideToAmber : ConstructorPoints
{
	public GuideToAmber()
	{
		base.CurMap = "Military";
		base.namePoint = "Проводник к Янтарю";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Поговаривают, на юго-западе от водонапорной башни, в одном из ветхих домов, можно найти проводника, который может провести прямо к Янтарю.";
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[300];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		base.Teleport = "Amber";
		base.TeleportName = " к Янтарю";
		base.TeleportGex = Gexa.GexLib[578];
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
	}
}
