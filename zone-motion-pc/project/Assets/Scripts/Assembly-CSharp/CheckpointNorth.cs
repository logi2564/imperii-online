using UnityEngine;

public class CheckpointNorth : ConstructorPoints
{
	public CheckpointNorth()
	{
		base.CurMap = "RedForest";
		base.namePoint = "Блокпост ''Север''";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.Свобода;
		base.DescriptionPoint = "Блокпост на севере Рыжего леса. Дорога теряется в непроходимом лесном массиве, кишащем мутантами и аномалиями. Опытные сталкеры рассказывали, что дорога ведет к станции ''Янов'' и заводу ''Юпитер'', но сейчас она непроходима.";
		base.ControlInt = 6;
		base.DealerInt = 6;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[603];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
	}
}
