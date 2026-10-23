using UnityEngine;

public class DestroyedHelicopter : ConstructorPoints
{
	public DestroyedHelicopter()
	{
		base.CurMap = "Radar";
		base.namePoint = "Сбитый вертолет";
		base.pointTypes = PointTypes.Anomaly;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Ми-24, совершивший аварийную посадку. Фюзеляж баз серьезных повреждений. Ржавчина на металле, однозначно указывает на давность аварии.";
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.XRay = 3;
		base.curGexPoint = Gexa.GexLib[454];
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
