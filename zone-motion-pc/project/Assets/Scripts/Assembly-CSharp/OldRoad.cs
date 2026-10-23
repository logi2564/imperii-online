using UnityEngine;

public class OldRoad : ConstructorPoints
{
	public OldRoad()
	{
		base.CurMap = "Bar";
		base.namePoint = "Старая дорога";
		base.pointTypes = PointTypes.Field;
		base.pointControl = PointControl.Бандиты;
		base.DescriptionPoint = "Старая дорога, ведущая в Темную  долину. Обычно на ней часто встречаются бандиты и стаи слепых псов.";
		base.ControlInt = 2;
		base.DealerInt = 2;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[478];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = GameObject.Find(base.curGexPoint.NameGex).transform.position;
		base.Teleport = "DarkValley";
		base.TeleportName = " в Тёмную долину";
		base.TeleportGex = Gexa.GexLib[583];
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
	}
}
