using UnityEngine;

public class ArmBase : ConstructorPoints
{
	public ArmBase()
	{
		base.CurMap = "Kordon";
		base.namePoint = "Военная база";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.Военные;
		base.DescriptionPoint = "Является постоянным местом дислокации военных на кордоне. Дорога к блокпосту регулярно патрулируется. Солдаты открывают огонь на поражение без предупреждения.";
		base.ControlInt = 3;
		base.DealerInt = 3;
		base.exchange = true;
		base.Repair = true;
		base.TaskChoise = true;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[36];
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
