using UnityEngine;

public class BusStation : ConstructorPoints
{
	public BusStation()
	{
		base.CurMap = "Agroprom";
		base.namePoint = "Автобусная остановка";
		base.pointTypes = PointTypes.Field;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Старая автобусная остановка оборудована под блокпост. С востока на запад тянется дорога со Свалки к НИИ ''Агропром''.";
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[359];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = GameObject.Find(base.curGexPoint.NameGex).transform.position;
		base.Teleport = "Dump";
		base.TeleportName = " на Свалку";
		base.TeleportGex = Gexa.GexLib[301];
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
	}
}
