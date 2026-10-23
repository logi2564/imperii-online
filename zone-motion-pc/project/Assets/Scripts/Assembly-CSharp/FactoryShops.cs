using UnityEngine;

public class FactoryShops : ConstructorPoints
{
	public FactoryShops()
	{
		base.CurMap = "DarkValley";
		base.namePoint = "Цеха старой фабрики";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.Бандиты;
		base.DescriptionPoint = "Комплекс старых построек, который хорошо заметен практически из любой точки Тёмной долины. Что здесь производили раньше — никому не известно. Цеха сохранились плохо, а все оборудование давным-давно вынесли мародёры.";
		base.ControlInt = 2;
		base.DealerInt = 2;
		base.exchange = true;
		base.Repair = true;
		base.TaskChoise = true;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[510];
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
