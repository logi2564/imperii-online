using UnityEngine;

public class ShopPromtovari : ConstructorPoints
{
	public ShopPromtovari()
	{
		base.CurMap = "DeadCity";
		base.namePoint = "Магазин промтовары";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.Бандиты;
		base.DescriptionPoint = "В одном из развалившихся зданий, на первом этаже располагался магазин промтоваров, о чем свидетельствует сохранившаяся вывеска на входе. Относительно безопасное место в городе.";
		base.ControlInt = 2;
		base.DealerInt = 2;
		base.exchange = true;
		base.Repair = true;
		base.TaskChoise = true;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[184];
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
