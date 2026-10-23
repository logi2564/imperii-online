using UnityEngine;

public class FishermansFarm : ConstructorPoints
{
	public FishermansFarm()
	{
		base.CurMap = "Marsh";
		base.namePoint = "Рыбацкий хутор";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Бывший хутор рыбаков, состоящий из двух деревянных строений, полуразрушенного сарая и лодочного причала, расположен восточнее базы Чистого неба. Это место используется Чистым небом в качестве плацдарма в самом начале боевых действий против ренегатов, поэтому на Рыбацком хуторе базируются большие силы группировки. Несмотря на это, ренегаты периодически предпринимают попытки захватить хутор.";
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.Repair = false;
		base.TaskChoise = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[42];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
	}
}
