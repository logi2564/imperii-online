using UnityEngine;

public class BaseRadar : ConstructorPoints
{
	public BaseRadar()
	{
		base.CurMap = "Radar";
		base.namePoint = "База выжигателя";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.Монолит;
		base.DescriptionPoint = "Бункер — центр управления излучателем. Его прикрывают многочисленные и хорошо вооружённые отряды Монолита. Здесь же находится их полевой лагерь.";
		base.ControlInt = 8;
		base.DealerInt = 8;
		base.exchange = true;
		base.Repair = true;
		base.TaskChoise = true;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[460];
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
