using UnityEngine;

public class WasteProcessingPlant : ConstructorPoints
{
	public WasteProcessingPlant()
	{
		base.CurMap = "Backwater";
		base.namePoint = "Станция переработки отходов";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Станция переработки отходов — комплекс строений, расположенный на юге Затона. Судя по всему раньше предназначался для очистки загрязнённой воды, с последующим сбросом в реку уже очищенной.";
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
		base.ControlInt = 5;
		base.DealerInt = 5;
		base.exchange = true;
		base.Repair = true;
		base.TaskChoise = true;
		base.XRay = 0;
		base.Burn = 0;
		base.ChemicalBurn = 0;
		base.curGexPoint = Gexa.GexLib[95];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
	}
}
