using UnityEngine;

public class BarrierMonolith : ConstructorPoints
{
	public BarrierMonolith()
	{
		base.CurMap = "Military";
		base.namePoint = "Барьер монолита";
		base.pointTypes = PointTypes.Field;
		base.pointControl = PointControl.Монолит;
		base.DescriptionPoint = "Изначально блокпост был основан военными для защиты от мутантов, следовавших из Мёртвого леса, но когда группировка «Свобода» захватила Армейские склады и устроила там вторую базу, Барьер использовался для защиты от Монолита. В последнее время точка регулярно и попеременно переходит под контроль Монолита и Свободы.";
		base.ControlInt = 8;
		base.DealerInt = 8;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[558];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		base.Teleport = "Radar";
		base.TeleportName = " к радару";
		base.TeleportGex = Gexa.GexLib[39];
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
	}
}
