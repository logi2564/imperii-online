using UnityEngine;

public class DogsTrail : ConstructorPoints
{
	public DogsTrail()
	{
		base.CurMap = "Bar";
		base.namePoint = "Собачья тропа";
		base.pointTypes = PointTypes.Field;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Дорога от Свалки к Бару. Обычно здесь очень много слепых псов, встречаются псевдособаки.";
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[35];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = GameObject.Find(base.curGexPoint.NameGex).transform.position;
		base.Teleport = "Dump";
		base.TeleportName = " на Свалку";
		base.TeleportGex = Gexa.GexLib[532];
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
	}
}
