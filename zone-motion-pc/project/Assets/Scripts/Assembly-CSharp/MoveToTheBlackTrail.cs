using UnityEngine;

public class MoveToTheBlackTrail : ConstructorPoints
{
	public MoveToTheBlackTrail()
	{
		base.CurMap = "DeadCity";
		base.namePoint = "Переход к черной тропе";
		base.pointTypes = PointTypes.Field;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Тропа, ведущая от Мертвого города к Дикой территории. В паре километров от города начинается непроходимый лес, по обе стороны дороги. Избежать боевого столкновения, здесь не получится. Весь путь усеян трупами зомбированных и стаями слепых псов, рвущих их останки. Мрачное, дурно пахнущее место. Сталкеры называют эту дорогу - Черной тропой.";
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[19];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		base.Teleport = "WildTerritory";
		base.TeleportName = " к Дикой территории";
		base.TeleportGex = Gexa.GexLib[260];
	}
}
