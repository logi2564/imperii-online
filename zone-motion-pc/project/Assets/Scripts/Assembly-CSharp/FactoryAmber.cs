using UnityEngine;

public class FactoryAmber : ConstructorPoints
{
	public FactoryAmber()
	{
		base.CurMap = "Amber";
		base.namePoint = "Завод ''Янтарь''";
		base.pointTypes = PointTypes.Anomaly;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Старый заводской комплекс, состоящий из нескольких зданий. Поговаривают, что где-то в нем расположен вход в лабораторию X16. Местность усеяна аномалиями и радиоактивными очагами.";
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.XRay = 2;
		base.curGexPoint = Gexa.GexLib[403];
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
