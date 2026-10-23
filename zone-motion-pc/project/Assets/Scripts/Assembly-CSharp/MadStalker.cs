using UnityEngine;

public class MadStalker : ConstructorPoints
{
	public MadStalker()
	{
		base.CurMap = "Military";
		base.namePoint = "Хижина сумасшедшего сталкера";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "В центре болота, расположенного около военной базы на Армейских складах, стоит ветхая избушка. Поговаривают, здесь обосновался сумасшедший сталкер. Западнее болота находится минное поле, севернее бродит стая мутантов.";
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[298];
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
