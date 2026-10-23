using UnityEngine;

public class BarracksInTheMine : ConstructorPoints
{
	public BarracksInTheMine()
	{
		base.CurMap = "RedForest";
		base.namePoint = "Казармы в шахте";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.Долг;
		base.DescriptionPoint = "До катастрофы использовалась для добычи каких-то полезных ископаемых. Имеется глубокая яма в шахте. Там много химических, электрических и термальных аномалий. Поговаривают, что там обитают полтергейсты.";
		base.ControlInt = 4;
		base.DealerInt = 4;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[29];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		base.Teleport = "DeadCity";
		base.TeleportName = " в Мертвый город";
		base.TeleportGex = Gexa.GexLib[582];
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
	}
}
