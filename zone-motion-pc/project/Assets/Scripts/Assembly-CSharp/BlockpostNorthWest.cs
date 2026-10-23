using UnityEngine;

public class BlockpostNorthWest : ConstructorPoints
{
	public BlockpostNorthWest()
	{
		base.CurMap = "Bar";
		base.namePoint = "Блокпост Северо-запад";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Блокпост, контролирующий бар с запада. Важная для группировок, стратегическая точка.";
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[361];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = GameObject.Find(base.curGexPoint.NameGex).transform.position;
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
	}
}
