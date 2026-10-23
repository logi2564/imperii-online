using UnityEngine;

public class CampOnSwamp : ConstructorPoints
{
	public CampOnSwamp()
	{
		base.CurMap = "Agroprom";
		base.namePoint = "Лагерь на болоте";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.Бандиты;
		base.DescriptionPoint = "Небольшое болото, расположенное у перехода на Янтарь. В иногда на северном берегу здесь бродят зомбированные, в южной части расположена небольшая избушка, окружённая аномалиями Кислотный туман.";
		base.ControlInt = 2;
		base.DealerInt = 2;
		base.exchange = true;
		base.Repair = true;
		base.TaskChoise = true;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[481];
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
