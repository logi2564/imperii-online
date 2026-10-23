using UnityEngine;

public class FromAmberToAgroprom : ConstructorPoints
{
	public FromAmberToAgroprom()
	{
		base.CurMap = "Amber";
		base.namePoint = "Переход к НИИ Агропром";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Среди холмов и камней, в непроходимом лесу, можно пройти к НИИ Агропром. Дорога усложняется часто встречающимися зомбированными, бредущими в обоих направлениях.";
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.XRay = 2;
		base.curGexPoint = Gexa.GexLib[2];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		base.Teleport = "Agroprom";
		base.TeleportName = " к НИИ Агропром";
		base.TeleportGex = Gexa.GexLib[587];
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
	}
}
