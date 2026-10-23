using UnityEngine;

public class KPPAmber : ConstructorPoints
{
	public KPPAmber()
	{
		base.CurMap = "Amber";
		base.namePoint = "Заводской КПП";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.Зомби;
		base.DescriptionPoint = "Заводской КПП окружен снорками и зомбированными. Вляпаться в аномалию здесь проще простого. Местность усеяна останками мутантов и человеческих тел...";
		base.ControlInt = 10;
		base.DealerInt = 10;
		base.exchange = true;
		base.XRay = 6;
		base.curGexPoint = Gexa.GexLib[391];
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
