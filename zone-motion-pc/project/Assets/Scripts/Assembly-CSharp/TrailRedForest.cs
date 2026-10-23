using UnityEngine;

public class TrailRedForest : ConstructorPoints
{
	public TrailRedForest()
	{
		base.CurMap = "Military";
		base.namePoint = "Тропа в рыжий лес";
		base.pointTypes = PointTypes.Field;
		base.pointControl = PointControl.Бандиты;
		base.DescriptionPoint = "На северо-западе от военной базы, среди камней и непроходимого лесного массива, протоптана узкая тропа к Рыжему лесу.";
		base.ControlInt = 2;
		base.DealerInt = 2;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[582];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		base.Teleport = "RedForest";
		base.TeleportName = " в Рыжий лес";
		base.TeleportGex = Gexa.GexLib[39];
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
	}
}
