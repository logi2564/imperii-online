using UnityEngine;

public class DumpRoad : ConstructorPoints
{
	public DumpRoad()
	{
		base.CurMap = "Kordon";
		base.namePoint = "Дорога на свалку";
		base.pointTypes = PointTypes.Field;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Дорога ведет к небольшому блокпосту на севере Кордона, состоящему из дома, смотровой вышки, брошенного БТРа и грузовика. Блокпост ведёт на Свалку.";
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[591];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = GameObject.Find(base.curGexPoint.NameGex).transform.position;
		base.Teleport = "Dump";
		base.TeleportName = " на Свалку";
		base.TeleportGex = Gexa.GexLib[32];
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
	}
}
