using UnityEngine;

public class AbandonedMachinery : ConstructorPoints
{
	public AbandonedMachinery()
	{
		base.CurMap = "Dump";
		base.namePoint = "Стоянка брошенной техники";
		base.pointTypes = PointTypes.Field;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Небольшая территория, огражденная забором с колючей проволокой. У входа стоит будочка, горит костер. Со всех сторон место ограждено колючей проволкой, в нескольких местах есть выходы. Много брошенной техники, откуда и название.";
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[127];
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
