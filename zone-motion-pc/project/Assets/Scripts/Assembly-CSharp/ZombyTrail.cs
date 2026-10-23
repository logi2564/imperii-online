using UnityEngine;

public class ZombyTrail : ConstructorPoints
{
	public ZombyTrail()
	{
		base.CurMap = "DarkValley";
		base.namePoint = "Тропинка зомби";
		base.pointTypes = PointTypes.Field;
		base.pointControl = PointControl.Зомби;
		base.DescriptionPoint = "Тропа на юго-востоке Долины. На ней всегда полно зомбированных. Даже бывалые сталкеры не решались пройти по ней...";
		base.ControlInt = 10;
		base.DealerInt = 10;
		base.exchange = false;
		base.Repair = false;
		base.XRay = 1;
		base.curGexPoint = Gexa.GexLib[118];
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
