using UnityEngine;

public class IsletOnLake : ConstructorPoints
{
	public IsletOnLake()
	{
		base.CurMap = "Amber";
		base.namePoint = "Островок на высохшем озере";
		base.pointTypes = PointTypes.Anomaly;
		base.pointControl = PointControl.Мутанты;
		base.DescriptionPoint = "Островок на высохшем озере ''Янтарь''. Все, кто приближаются к озеру, попадают под неизвестный контроль и уходят по звенящему от радиации мелкому дну в туман к центру озера. Расчёты показывают, что из центра озера испускаются необъяснимые телепатические «волны», которые зомбируют случайных жертв.";
		base.ControlInt = 9;
		base.DealerInt = 9;
		base.exchange = false;
		base.XRay = 2;
		base.curGexPoint = Gexa.GexLib[104];
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
