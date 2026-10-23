using UnityEngine;

public class MutantBaseKordon : ConstructorPoints
{
	public MutantBaseKordon()
	{
		base.CurMap = "Kordon";
		base.namePoint = "Логово мутантов на кордоне";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Два старых заброшенных строения, расположенных на северо-западе Кордона. Раньше служила базой для одиночек, но со временем мутанты вытеснили сталкеров...";
		base.ControlInt = 9;
		base.DealerInt = 9;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[564];
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
