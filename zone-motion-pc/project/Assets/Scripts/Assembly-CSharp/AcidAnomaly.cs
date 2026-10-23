using UnityEngine;

public class AcidAnomaly : ConstructorPoints
{
	public AcidAnomaly()
	{
		base.CurMap = "Marsh";
		base.namePoint = "Кислотная аномалия";
		base.pointTypes = PointTypes.Anomaly;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Кислотный туман — это область скопления ядовитых газов, стелющихся низко над землей. Облако зеленоватого цвета слабо светится в темноте, отчего достаточно хорошо заметно ночью. При контакте с живым организмом наносит химические ожоги поверхности кожи, слизистой оболочки глаз и органов дыхания. Газ ядовит. Встречается это газовое аномальное образование чаще всего в болотистой местности.";
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.Repair = false;
		base.TaskChoise = false;
		base.XRay = 3;
		base.curGexPoint = Gexa.GexLib[28];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
	}
}
