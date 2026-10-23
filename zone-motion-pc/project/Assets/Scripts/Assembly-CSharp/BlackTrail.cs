using UnityEngine;

public class BlackTrail : ConstructorPoints
{
	public BlackTrail()
	{
		base.CurMap = "WildTerritory";
		base.namePoint = "Черная тропа";
		base.pointTypes = PointTypes.Field;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Тропа, ведущая в Мертвый город. По обе стороны, непроходимый лес. Избежать боевого столкновения, здесь не получится. Весь путь усеян трупами зомбированных и стаями слепых псов, рвущих их останки. Мрачное, дурно пахнущее место. Сталкеры называют эту дорогу - Черной тропой.";
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[260];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		base.Teleport = "DeadCity";
		base.TeleportName = " в Мертвый город";
		base.TeleportGex = Gexa.GexLib[19];
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
	}
}
