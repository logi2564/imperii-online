using UnityEngine;

public class Barrier : ConstructorPoints
{
	public Barrier()
	{
		base.CurMap = "Dump";
		base.namePoint = "Барьер";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.Долг;
		base.DescriptionPoint = "Блокпост, контролирующий путь к Бару. Одна из ключевых точек на Свалке. По периметру блокпоста, расставлены бетонные блоки, с северо-запада натянута рабица и установлены сдвижные ворота. На территории блокпоста имеется вагончик для отдыха.";
		base.ControlInt = 4;
		base.DealerInt = 4;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[532];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = GameObject.Find(base.curGexPoint.NameGex).transform.position;
		base.Teleport = "Bar";
		base.TeleportName = " на локацию Бар";
		base.TeleportGex = Gexa.GexLib[35];
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
	}
}
