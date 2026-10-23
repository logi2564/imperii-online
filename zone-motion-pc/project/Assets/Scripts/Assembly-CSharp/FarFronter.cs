using UnityEngine;

public class FarFronter : ConstructorPoints
{
	public FarFronter()
	{
		base.CurMap = "Amber";
		base.namePoint = "Дальний рубеж";
		base.pointTypes = PointTypes.Field;
		base.pointControl = PointControl.Одиночки;
		base.DescriptionPoint = "Лагерь сталкеров на северо-востоке Янтаря. Если нет по близости мутантов и зомбированных, сталкеры задерживаются здесь на стоянку.";
		base.ControlInt = 1;
		base.DealerInt = 1;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[493];
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
