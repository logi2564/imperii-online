using UnityEngine;

public class SwampRoad : ConstructorPoints
{
	public SwampRoad()
	{
		base.CurMap = "Dump";
		base.namePoint = "Дорога на болото";
		base.pointTypes = PointTypes.Anomaly;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Небольшой лагерь, расположенный на юго-западе Свалки. Место относительно спокойное, разве что стая собак забежит. Здесь находится переход на Болото.";
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[22];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = GameObject.Find(base.curGexPoint.NameGex).transform.position;
		base.Teleport = "Marsh";
		base.TeleportName = " на Болото";
		base.TeleportGex = Gexa.GexLib[537];
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
	}
}
