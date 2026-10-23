using UnityEngine;

public class AZS : ConstructorPoints
{
	public AZS()
	{
		base.CurMap = "DarkValley";
		base.namePoint = "АЗС";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Бензоколонка (Диспетчерская АЗС) — автозаправка в Тёмной долине. Располагается восточнее старой фабрики. Состоит из двухэтажного здания, будки, цистерн и забора.";
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.Repair = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[474];
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
