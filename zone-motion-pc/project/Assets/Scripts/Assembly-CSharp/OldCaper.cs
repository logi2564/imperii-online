using UnityEngine;

public class OldCaper : ConstructorPoints
{
	public OldCaper()
	{
		base.CurMap = "RedForest";
		base.namePoint = "Шахтный копер";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.Чистое_небо;
		base.DescriptionPoint = "Старый кирпичный копёр, некогда использовавшийся для подъема и опускания грузов в шахту. Имеет грузовой лифт, судя по мотору и самой конструкции лифта можно сказать, что он рассчитан на очень большую грузоподъёмность, только не ясно, что с таким весом и куда он мог поднимать или опускать; скорее всего использовался для каких-то подземных сооружений. Вокруг копра валяется строительный мусор и простаивает множество контейнеров.";
		base.ControlInt = 7;
		base.DealerInt = 7;
		base.exchange = true;
		base.Repair = true;
		base.TaskChoise = true;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[509];
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
