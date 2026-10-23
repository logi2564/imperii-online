using UnityEngine;

public class QuietCountryside : ConstructorPoints
{
	public QuietCountryside()
	{
		base.CurMap = "Military";
		base.namePoint = "Тихий хутор";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.Чистое_небо;
		base.DescriptionPoint = "Хутор, состоящий из трёх зданий, одно жилое и две хозяйственной постройки. Все здание в плачевном состоянии, но в них вполне можно укрыться от непогоды или остановиться на стоянку.";
		base.ControlInt = 7;
		base.DealerInt = 7;
		base.exchange = true;
		base.Repair = true;
		base.TaskChoise = true;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[144];
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
