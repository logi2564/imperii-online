using UnityEngine;

public class HaltNetrals : ConstructorPoints
{
	public HaltNetrals()
	{
		base.CurMap = "Bar";
		base.namePoint = "Привал нейтралов";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.Одиночки;
		base.DescriptionPoint = "Лагерь нетралов на территории Бара. Относительно спокойное место, где можно отдохнуть...";
		base.ControlInt = 1;
		base.DealerInt = 1;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[249];
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
