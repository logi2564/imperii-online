using UnityEngine;

public class Dredger : ConstructorPoints
{
	public Dredger()
	{
		base.CurMap = "Backwater";
		base.namePoint = "Земснаряд";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Старый, давно заброшенный земснаряд стоит в небольшой заводи, образованной руслом пересохшей реки. Палуба и трехэтажная корабельная надстройка судна уже давно покрылись толстым слоем ржавчины. К левому борту земснаряда прибиты небольшая баржа и деревянная плавучая платформа, заваленные большим количеством различных ящиков и прочего строительного мусора. ";
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.Repair = false;
		base.TaskChoise = false;
		base.XRay = 0;
		base.Burn = 0;
		base.curGexPoint = Gexa.GexLib[459];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
	}
}
