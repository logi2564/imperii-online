using UnityEngine;

public class GorkomKPSS : ConstructorPoints
{
	public GorkomKPSS()
	{
		base.CurMap = "DeadCity";
		base.namePoint = "Горком КПСС";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.Наемники;
		base.DescriptionPoint = "Старое здание, советской постройки. Неплохо сохранилось, не смотря на разрушительное влияние зоны. На крыше здания красуется лозунг: ''Слава труду'', как отголосок старой эпохи, огромной страны...";
		base.ControlInt = 5;
		base.DealerInt = 5;
		base.exchange = true;
		base.Repair = true;
		base.TaskChoise = true;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[268];
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
