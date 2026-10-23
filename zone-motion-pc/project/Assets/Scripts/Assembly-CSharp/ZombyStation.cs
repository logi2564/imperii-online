using UnityEngine;

public class ZombyStation : ConstructorPoints
{
	public ZombyStation()
	{
		base.CurMap = "Agroprom";
		base.namePoint = "Бродячие зомби";
		base.pointTypes = PointTypes.None;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Со стороны озера ''Янтарь'', к северному комплексу, бредут толпы зомбированных. Случается, что в окресностях Агропрома, с севера, и шагу нельзя ступить, чтобы не наткнуться на ходячего трупика...";
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[577];
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
