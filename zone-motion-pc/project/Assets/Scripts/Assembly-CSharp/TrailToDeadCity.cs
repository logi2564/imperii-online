using UnityEngine;

public class TrailToDeadCity : ConstructorPoints
{
	public TrailToDeadCity()
	{
		base.CurMap = "Amber";
		base.namePoint = "Тайная тропа в мертвый город";
		base.pointTypes = PointTypes.Field;
		base.pointControl = PointControl.Наемники;
		base.DescriptionPoint = "Бывалые сталкеры поговаривают, что на северо-западе от завода есть тропа. Тропу протоптали зомбированные, по непонятным причинам, стремящиеся пройти в Мертвый город.";
		base.ControlInt = 5;
		base.DealerInt = 5;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[600];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		base.Teleport = "DeadCity";
		base.TeleportName = " в Мертвый город";
		base.TeleportGex = Gexa.GexLib[8];
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
	}
}
