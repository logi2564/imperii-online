using UnityEngine;

public class Refueling : ConstructorPoints
{
	public Refueling()
	{
		base.CurMap = "Backwater";
		base.namePoint = "Заправка";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Обычная советская заправка, каких много. Располагается на юго-западе Затона. На заправке часто собираются кабаны, плоти, слепые псы, изредка могут быть кровососы и ещё реже химера. Здесь часто происходят стычки между сталкерами и мутантами. Рядом с заправкой находится разлом в земле.";
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.Repair = false;
		base.TaskChoise = false;
		base.XRay = 1;
		base.Burn = 0;
		base.ChemicalBurn = 0;
		base.curGexPoint = Gexa.GexLib[188];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
	}
}
