using UnityEngine;

public class Shevchenko : ConstructorPoints
{
	public Shevchenko()
	{
		base.CurMap = "Backwater";
		base.namePoint = "Шевченко";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.Бандиты;
		base.DescriptionPoint = "Один из двух сухогрузов, находящихся на Затоне, южнее «Скадовска». На верхней палубе стоят контейнеры, в районе кормы имеется разлом. Правый борт сильно повреждён. При входе внутрь, повернувшись направо, можно увидеть лестницу, которая ведёт в рубку, где разведён костёр и устроен временный привал.";
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
		base.ControlInt = 2;
		base.DealerInt = 2;
		base.exchange = true;
		base.Repair = true;
		base.TaskChoise = true;
		base.XRay = 0;
		base.Burn = 0;
		base.ChemicalBurn = 0;
		base.curGexPoint = Gexa.GexLib[289];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
	}
}
