using UnityEngine;

public class TailInForest : ConstructorPoints
{
	public TailInForest()
	{
		base.CurMap = "Amber";
		base.namePoint = "Укрытие в лесу";
		base.pointTypes = PointTypes.Field;
		base.pointControl = PointControl.Бандиты;
		base.DescriptionPoint = "Относительно спокойное местечко в лесном массиве, восточнее завода ''Янтарь''.";
		base.ControlInt = 2;
		base.DealerInt = 2;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[218];
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
