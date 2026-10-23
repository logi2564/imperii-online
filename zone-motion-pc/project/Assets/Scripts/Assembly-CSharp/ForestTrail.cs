using UnityEngine;

public class ForestTrail : ConstructorPoints
{
	public ForestTrail()
	{
		base.CurMap = "DarkValley";
		base.namePoint = "Лесная тропа";
		base.pointTypes = PointTypes.Field;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Лесная тропа, расположена на севере Темной долины. Бывалые сталкеры расказывали, что она ведет к Бару...";
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[583];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = GameObject.Find(base.curGexPoint.NameGex).transform.position;
		base.Teleport = "Bar";
		base.TeleportName = " на локацию Бар";
		base.TeleportGex = Gexa.GexLib[478];
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
	}
}
