using UnityEngine;

public class Skadovsk : ConstructorPoints
{
	public Skadovsk()
	{
		base.CurMap = "Backwater";
		base.namePoint = "Скадовск";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "«Скадовск» — заброшенный сухогруз, расположенный приблизительно в центре локации. Носовая часть корабля серьезно повреждена: отсутствуют большие куски обшивки, палубы, сам нос повернут в сторону относительно остального судна. Однако остальная часть сухогруза герметична и используется людьми как база и прочное убежище.";
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
		base.ControlInt = 1;
		base.DealerInt = 1;
		base.exchange = true;
		base.Repair = true;
		base.TaskChoise = true;
		base.XRay = 0;
		base.Burn = 0;
		base.curGexPoint = Gexa.GexLib[452];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
	}
}
