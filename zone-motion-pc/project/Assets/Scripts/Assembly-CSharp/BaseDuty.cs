using UnityEngine;

public class BaseDuty : ConstructorPoints
{
	public BaseDuty()
	{
		base.CurMap = "Bar";
		base.namePoint = "База Долга";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.Долг;
		base.DescriptionPoint = "Эта территория включает в себя ангар, бункер и пристройку к другому ангару. Доступ на базу посторонним запрещён из-за войны с группировкой «Свобода». У входа на базу находится КПП. В пристройке к ангару находится склад. В бункере располагается штаб, в котором находится лидер группировки.";
		base.ControlInt = 4;
		base.DealerInt = 4;
		base.exchange = true;
		base.Repair = true;
		base.TaskChoise = true;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[325];
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
