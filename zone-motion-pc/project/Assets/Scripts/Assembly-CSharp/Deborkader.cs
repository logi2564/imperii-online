using UnityEngine;

public class Deborkader : ConstructorPoints
{
	public Deborkader()
	{
		base.CurMap = "RedForest";
		base.namePoint = "Деборкадер";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.Одиночки;
		base.DescriptionPoint = "Элемент транспортной и складской инфраструктуры, предназначенный для выгрузки или погрузки пассажиров и грузов. Внутри находится оборудование, непонятного назначения. Прекрасно защищает от воздействия Зоны. Сталкеры частенько разбивают здесь лагерь...";
		base.ControlInt = 1;
		base.DealerInt = 1;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[599];
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
