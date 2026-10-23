using UnityEngine;

public class IntersectionRoad : ConstructorPoints
{
	public IntersectionRoad()
	{
		base.CurMap = "Military";
		base.namePoint = "Перекресток";
		base.pointTypes = PointTypes.Field;
		base.pointControl = PointControl.Зомби;
		base.DescriptionPoint = "Дороги от него ведут к барьеру, базе Свободы и по направлению к Бару. Весьма неспокойное место. Частенько сюда забегают мутанты и приходят снорки.";
		base.ControlInt = 10;
		base.DealerInt = 10;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[293];
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
