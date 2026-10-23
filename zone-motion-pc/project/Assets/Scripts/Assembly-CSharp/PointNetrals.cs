using UnityEngine;

public class PointNetrals : ConstructorPoints
{
	public PointNetrals()
	{
		base.CurMap = "Military";
		base.namePoint = "Укрепточка нетралов";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.Одиночки;
		base.DescriptionPoint = "Южнее водонапорной башни, в одном из крайних домов деревни, нейтралы организовали укрепточку. Место относительно спокойное, если про Зону вообще можно сказать подобное.";
		base.ControlInt = 1;
		base.DealerInt = 1;
		base.exchange = true;
		base.Repair = true;
		base.TaskChoise = true;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[303];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
	}
}
