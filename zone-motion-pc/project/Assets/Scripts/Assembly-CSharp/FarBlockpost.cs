using UnityEngine;

public class FarBlockpost : ConstructorPoints
{
	public FarBlockpost()
	{
		base.CurMap = "DarkValley";
		base.namePoint = "Дальний блокпост";
		base.pointTypes = PointTypes.Field;
		base.pointControl = PointControl.Долг;
		base.DescriptionPoint = "Блокпост неплохо укреплён. Присутствуют мешки с песком, деревянные ящики и большие валуны. Но всё же их будет недостаточно, если блокпост атакуют штурмовые отряды...";
		base.ControlInt = 4;
		base.DealerInt = 4;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[320];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = GameObject.Find(base.curGexPoint.NameGex).transform.position;
		base.Teleport = "Dump";
		base.TeleportName = " на Свалку";
		base.TeleportGex = Gexa.GexLib[559];
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
	}
}
