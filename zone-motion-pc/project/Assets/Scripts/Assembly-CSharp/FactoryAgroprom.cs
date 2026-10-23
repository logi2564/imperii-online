using UnityEngine;

public class FactoryAgroprom : ConstructorPoints
{
	public FactoryAgroprom()
	{
		base.CurMap = "Agroprom";
		base.namePoint = "Завод Агропром";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.Одиночки;
		base.DescriptionPoint = "Представляет из себя комплекс железо-бетонных сооружений, соединённых между собой надземными и подземными переходами, а также железнодорожной платформой для разгрузки угля.";
		base.ControlInt = 1;
		base.DealerInt = 1;
		base.exchange = true;
		base.Repair = true;
		base.TaskChoise = true;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[371];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = GameObject.Find(base.curGexPoint.NameGex).transform.position;
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
	}
}
