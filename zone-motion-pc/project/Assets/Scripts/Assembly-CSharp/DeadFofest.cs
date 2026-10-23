using UnityEngine;

public class DeadFofest : ConstructorPoints
{
	public DeadFofest()
	{
		base.CurMap = "Radar";
		base.namePoint = "Мертвый лес";
		base.pointTypes = PointTypes.Field;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Бывалые сталкеры поговаривали, что юго-западнее выжигателя берет свое начало Рыжий лес. Местность здесь выжжена до основания, лишь изредка, среди мертвых стволов деревьев, можно заметить пожелтевшую листву...";
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.XRay = 2;
		base.curGexPoint = Gexa.GexLib[161];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		base.Teleport = "RedForest";
		base.TeleportName = " в Рыжий лес";
		base.TeleportGex = Gexa.GexLib[419];
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
	}
}
