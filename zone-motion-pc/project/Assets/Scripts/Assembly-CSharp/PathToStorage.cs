using UnityEngine;

public class PathToStorage : ConstructorPoints
{
	public PathToStorage()
	{
		base.CurMap = "DeadCity";
		base.namePoint = "Путь на военные склады";
		base.pointTypes = PointTypes.Field;
		base.pointControl = PointControl.Военные;
		base.DescriptionPoint = "Бывалые сталкеры, поговаривали, что на северо-востоке Мертвого города, есть тропа, прямиком ведущая к Военным складам.";
		base.ControlInt = 3;
		base.DealerInt = 3;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[578];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		base.Teleport = "Military";
		base.TeleportName = " на военные склады";
		base.TeleportGex = Gexa.GexLib[500];
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
	}
}
