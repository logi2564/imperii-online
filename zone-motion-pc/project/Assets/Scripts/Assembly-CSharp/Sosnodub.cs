using UnityEngine;

public class Sosnodub : ConstructorPoints
{
	public Sosnodub()
	{
		base.CurMap = "Backwater";
		base.namePoint = "Соснодуб";
		base.pointTypes = PointTypes.Anomaly;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Достаточно новая разновидность симбиотической аномалии, образовавшаяся в результате «сплавления» некоторых видов деревьев, как правило дуба и сосны. Хорошо различима издалека по необычной форме «купола» из стволов деревьев, которые сами по себе безвредны, в отличие от скапливающихся опасных химических веществ под ним, нередко концентрирующихся в аномалию «Газировка».";
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.Repair = false;
		base.TaskChoise = false;
		base.XRay = 1;
		base.Burn = 1;
		base.ChemicalBurn = 0;
		base.curGexPoint = Gexa.GexLib[192];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
	}
}
