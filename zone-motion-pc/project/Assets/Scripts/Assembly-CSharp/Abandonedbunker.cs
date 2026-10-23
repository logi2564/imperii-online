using UnityEngine;

public class Abandonedbunker : ConstructorPoints
{
	public Abandonedbunker()
	{
		base.CurMap = "RedForest";
		base.namePoint = "Брошенный бункер";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.Военные;
		base.DescriptionPoint = "Непонятно по каким причинам, ученые бросили бункер без присмотра и охраны. Системы жизнеобеспечения полностью исправны. Источники тока также работают. Одновременно несколько группировок пытаются взять бункер под контроль...";
		base.ControlInt = 3;
		base.DealerInt = 3;
		base.exchange = true;
		base.Repair = true;
		base.TaskChoise = true;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[320];
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
