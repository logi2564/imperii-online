using UnityEngine;

public class BridgeToLimansk : ConstructorPoints
{
	public BridgeToLimansk()
	{
		base.CurMap = "RedForest";
		base.namePoint = "Мост в Лиманск";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.Наемники;
		base.DescriptionPoint = "Этот мост — своеобразное препятствие на пути к городу Лиманску. Мост разрушен. На нём установлен старый аварийный мост, предназначенный лишь для пешехода.";
		base.ControlInt = 5;
		base.DealerInt = 5;
		base.exchange = true;
		base.Repair = true;
		base.TaskChoise = true;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[100];
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
