using UnityEngine;

public class MarshTrampoline : ConstructorPoints
{
	public MarshTrampoline()
	{
		base.CurMap = "Marsh";
		base.namePoint = "Болотный трамплин";
		base.pointTypes = PointTypes.Anomaly;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Трамплином называется аномальная область диаметром около пяти метров, в которой действуют силы, предположительно, гравитационной природы. Животное или человек, попав в эту область, рискует получить сильные повреждения от ударной волны, образуемой в Трамплине. Аномалия воздействует на объект до тех пор, пока тот не покинет ее или не пройдет некоторое время. Надо заметить, что если не переступать через границу Трамплина, то он, «чувствуя» что-то в себе, будет работать вхолостую.";
		base.TexturePoint = (base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/болотный трамплин"));
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.Repair = false;
		base.TaskChoise = false;
		base.XRay = 2;
		base.curGexPoint = Gexa.GexLib[262];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
	}
}
