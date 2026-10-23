using UnityEngine;

public class ATP : ConstructorPoints
{
	public ATP()
	{
		base.CurMap = "Kordon";
		base.namePoint = "АТП";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.Бандиты;
		base.DescriptionPoint = "АТП состоит из четырёх небольших построек, у всех обваленная крыша. С нескольких сторон территория ограждена низким деревянным забором. Между строениями находится двор, в нём стоит брошенная техника типа тракторов и грузовиков.";
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
		base.ControlInt = 2;
		base.DealerInt = 2;
		base.exchange = true;
		base.Repair = true;
		base.TaskChoise = true;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[270];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = GameObject.Find(base.curGexPoint.NameGex).transform.position;
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
	}
}
