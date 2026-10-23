using UnityEngine;

public class HaltOnPlates : ConstructorPoints
{
	public HaltOnPlates()
	{
		base.CurMap = "Military";
		base.namePoint = "Привал на плитах";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.Мутанты;
		base.DescriptionPoint = "Стоянка сталкеров, расположена прямо на брошенных бетонных плитах. Время от времени, сюда заходят одинокие сталкеры, чтобы передохнуть.";
		base.ControlInt = 9;
		base.DealerInt = 9;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[350];
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
