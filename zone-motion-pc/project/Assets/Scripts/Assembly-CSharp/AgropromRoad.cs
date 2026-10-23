using UnityEngine;

public class AgropromRoad : ConstructorPoints
{
	public AgropromRoad()
	{
		base.CurMap = "Dump";
		base.namePoint = "Дорога на НИИ Агропром";
		base.pointTypes = PointTypes.Field;
		base.pointControl = PointControl.Свобода;
		base.DescriptionPoint = "Представляет собой укрепления из бетонных блоков. По бокам дороги - искусственная насыпь, видимо еще со времен советского союза. Располагается западнее Депо. Является переходом на НИИ «Агропром».";
		base.ControlInt = 6;
		base.DealerInt = 6;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[301];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = GameObject.Find(base.curGexPoint.NameGex).transform.position;
		base.Teleport = "Agroprom";
		base.TeleportName = " на Агропром";
		base.TeleportGex = Gexa.GexLib[359];
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
	}
}
