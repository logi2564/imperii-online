using UnityEngine;

public class MechanizationYard : ConstructorPoints
{
	public MechanizationYard()
	{
		base.CurMap = "Marsh";
		base.namePoint = "Механизаторский двор";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Небольшое предприятие, занимавшееся когда-то починкой автотранспорта, стоит на северо-востоке Болот. На территории расположено кирпичное Г-образное здание и несколько ржавых машин под навесом. Раньше Механизаторский двор являлся главной базой Ренегатов.";
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.Repair = false;
		base.TaskChoise = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[394];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
	}
}
