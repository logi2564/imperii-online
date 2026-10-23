using UnityEngine;

public class BunkerOfScientists : ConstructorPoints
{
	public BunkerOfScientists()
	{
		base.CurMap = "Amber";
		base.namePoint = "Бункер ученых";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.Ученые;
		base.DescriptionPoint = "Мобильная лаборатория выглядит как небольшой металлический бункер с маленькими тонированными окошками. Способна выдержать почти все известные человеку повреждения любого характера. Может быть переведена в полностью автономный режим на несколько месяцев, для чего снабжена надёжными системами жизнеобеспечения. В Зону доставляется грузовым вертолётом.";
		base.ControlInt = 11;
		base.DealerInt = 11;
		base.exchange = true;
		base.Repair = true;
		base.TaskChoise = true;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[69];
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
