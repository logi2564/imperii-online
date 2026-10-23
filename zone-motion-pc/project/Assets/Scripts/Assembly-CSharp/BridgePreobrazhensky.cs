using UnityEngine;

public class BridgePreobrazhensky : ConstructorPoints
{
	public BridgePreobrazhensky()
	{
		base.CurMap = "Backwater";
		base.namePoint = "Мост им. Преображенского";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Мост им. Преображенского — старый, частично разрушенный мост, расположенный на востоке Затона.";
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.Repair = false;
		base.TaskChoise = false;
		base.XRay = 0;
		base.Burn = 0;
		base.ChemicalBurn = 0;
		base.curGexPoint = Gexa.GexLib[198];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		base.Teleport = "Radar";
		base.TeleportName = " на Радар";
		base.TeleportGex = Gexa.GexLib[578];
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
	}
}
