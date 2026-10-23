using UnityEngine;

public class ZombiePark : ConstructorPoints
{
	public ZombiePark()
	{
		base.CurMap = "DeadCity";
		base.namePoint = "Квартал зомби";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.Зомби;
		base.DescriptionPoint = "По непонятной причине, зомбированные облюбовали несколько старых советских хрущевок. Здесь они, как будто, живут нормальной жизнью, разговаривают с видимыми только им близкими, ходят в магазин и, как будто, приобретают продукты... При виде обыкновенного человека, незамедлительно его атакуют.";
		base.ControlInt = 10;
		base.DealerInt = 10;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[154];
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
