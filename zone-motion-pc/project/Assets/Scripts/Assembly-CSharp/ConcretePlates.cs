using UnityEngine;

public class ConcretePlates : ConstructorPoints
{
	public ConcretePlates()
	{
		base.CurMap = "Dump";
		base.namePoint = "Бетонные плиты";
		base.pointTypes = PointTypes.Field;
		base.pointControl = PointControl.Бандиты;
		base.DescriptionPoint = "Небольшой лагерь в центре Свалки, расположенный непосредственно на разбросанных около дороги бетонных плитах и прямо под открытым небом. Лагерь укреплен по периметру, для непродолжительной обороны.";
		base.ControlInt = 2;
		base.DealerInt = 2;
		base.exchange = true;
		base.Repair = true;
		base.TaskChoise = true;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[194];
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
