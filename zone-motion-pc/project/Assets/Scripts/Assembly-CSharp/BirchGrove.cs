using UnityEngine;

public class BirchGrove : ConstructorPoints
{
	public BirchGrove()
	{
		base.CurMap = "DeadCity";
		base.namePoint = "Березовая роща";
		base.pointTypes = PointTypes.Field;
		base.pointControl = PointControl.Одиночки;
		base.DescriptionPoint = "Относительно безопасное местечко, вблизи города. Обыкновенному сталкеру безопаснее остановиться на отдых именно здесь.";
		base.ControlInt = 1;
		base.DealerInt = 1;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[416];
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
