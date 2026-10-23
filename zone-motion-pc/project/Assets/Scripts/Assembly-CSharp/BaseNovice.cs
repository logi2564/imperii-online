using UnityEngine;

public class BaseNovice : ConstructorPoints
{
	public BaseNovice()
	{
		base.CurMap = "Kordon";
		base.namePoint = "Деревня новичков";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.Одиночки;
		base.DescriptionPoint = "База находится на месте бывшей деревушки из семи домов. Эта деревня служит пристанищем для новичков, идущих с «большой земли» в Зону. Часто новички становятся добычей для бандитов.";
		base.ControlInt = 1;
		base.DealerInt = 1;
		base.exchange = true;
		base.Repair = true;
		base.TaskChoise = true;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[81];
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
