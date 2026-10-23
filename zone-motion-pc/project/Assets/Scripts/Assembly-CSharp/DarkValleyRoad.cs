using UnityEngine;

public class DarkValleyRoad : ConstructorPoints
{
	public DarkValleyRoad()
	{
		base.CurMap = "Dump";
		base.namePoint = "Дорога в темную долину";
		base.pointTypes = PointTypes.Field;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Раньше здесь располагался блокпост, но сейчас эта местность, полностью непригодна для лагеря или стоянки. Появился приличный радиационный фон, а чуть южнее часто бродят голодные собаки.";
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[559];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = GameObject.Find(base.curGexPoint.NameGex).transform.position;
		base.Teleport = "DarkValley";
		base.TeleportName = " в Тёмную долину";
		base.TeleportGex = Gexa.GexLib[320];
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
	}
}
