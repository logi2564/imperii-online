using UnityEngine;

public class FaultAnomaly : ConstructorPoints
{
	public FaultAnomaly()
	{
		base.CurMap = "Marsh";
		base.namePoint = "Разлом";
		base.pointTypes = PointTypes.Anomaly;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Разлом — это ближайшая к периметру Зоны архианомалия. Расположена она на болотах около механизаторского двора. По непонятным причинам в этом месте Жарки образовались неглубоко под землей, что заставило землю пойти трещинами, образовавшими крупный разлом. Всё, что попадет в этот разлом, подвергнется воздействию высоких температур. Разлом легко обнаруживается в дневное время суток, но ночью опасный провал в земле может служить причиной смерти неосторожного сталкера.";
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.Repair = false;
		base.TaskChoise = false;
		base.XRay = 3;
		base.curGexPoint = Gexa.GexLib[473];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
	}
}
