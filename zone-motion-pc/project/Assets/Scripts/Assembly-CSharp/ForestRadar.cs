using UnityEngine;

public class ForestRadar : ConstructorPoints
{
	public ForestRadar()
	{
		base.CurMap = "Radar";
		base.namePoint = "Лесной привал";
		base.pointTypes = PointTypes.Field;
		base.pointControl = PointControl.Чистое_небо;
		base.DescriptionPoint = "Относительно тихое место, неподалеку от Выжигателя. Холмы с четырех сторон обеспечивают естественную защиту от ветра, а немногочисленная растительность позволяет укрыться небольшому отряду.";
		base.ControlInt = 7;
		base.DealerInt = 7;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[26];
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
