using UnityEngine;

public class PathToAmber : ConstructorPoints
{
	public PathToAmber()
	{
		base.CurMap = "DeadCity";
		base.namePoint = "Путь на Янтарь";
		base.pointTypes = PointTypes.Field;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Петляющая по лесу дорога. На пути встречаются зомбированные, бредущие в Мертвый город...";
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[8];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		base.Teleport = "Amber";
		base.TeleportName = " к Янтарю";
		base.TeleportGex = Gexa.GexLib[600];
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
	}
}
