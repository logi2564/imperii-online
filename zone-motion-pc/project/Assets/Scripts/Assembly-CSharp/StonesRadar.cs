using UnityEngine;

public class StonesRadar : ConstructorPoints
{
	public StonesRadar()
	{
		base.CurMap = "Radar";
		base.namePoint = "Стоянка на камнях";
		base.pointTypes = PointTypes.Field;
		base.pointControl = PointControl.Наемники;
		base.DescriptionPoint = "Груда камней, рядом с дорогой, образует естественное укрытие от осадков и ветра. Следы недавней перестрелки указывают на серьезный бой...";
		base.ControlInt = 5;
		base.DealerInt = 5;
		base.exchange = false;
		base.XRay = 2;
		base.curGexPoint = Gexa.GexLib[279];
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
