using UnityEngine;

public class RoadFromWildTerritory : ConstructorPoints
{
	public RoadFromWildTerritory()
	{
		base.CurMap = "Amber";
		base.namePoint = "Дорога через дикую территорию";
		base.pointTypes = PointTypes.Field;
		base.pointControl = PointControl.Чистое_небо;
		base.DescriptionPoint = "Дорога, ведущая через дикую территорию к бару. Крайне неспокойный путь, на котором то и дело попадаются мутанты и зомбированные, радиационные очаги и аномалии...";
		base.ControlInt = 7;
		base.DealerInt = 7;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[39];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		base.Teleport = "WildTerritory";
		base.TeleportName = " к Дикой территории";
		base.TeleportGex = Gexa.GexLib[14];
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
	}
}
