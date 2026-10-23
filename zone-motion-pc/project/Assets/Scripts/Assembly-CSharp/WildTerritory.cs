using UnityEngine;

public class WildTerritory : ConstructorPoints
{
	public WildTerritory()
	{
		base.CurMap = "Bar";
		base.namePoint = "Путь к дикой территории";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Часть заброшенного завода «Росток», именуемая Дикой территорией, в отличие от Бара, по-настоящему дикая. Местность является прибежищем различных мутантов.";
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[300];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		base.Teleport = "WildTerritory";
		base.TeleportName = " к Дикой территории";
		base.TeleportGex = Gexa.GexLib[379];
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
	}
}
