using UnityEngine;

public class WadingTrail : ConstructorPoints
{
	public WadingTrail()
	{
		base.CurMap = "Agroprom";
		base.namePoint = "Болотная тропа";
		base.pointTypes = PointTypes.None;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Узкая тропинка в непроходимых зарослях. Сходить с тропы - смертельно опасно, так как можно угодить в аномалию или попасть в трясину.";
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[12];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		base.Teleport = "Marsh";
		base.TeleportName = " на Болото";
		base.TeleportGex = Gexa.GexLib[612];
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
	}
}
