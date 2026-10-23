using UnityEngine;

public class Emerald : ConstructorPoints
{
	public Emerald()
	{
		base.CurMap = "Backwater";
		base.namePoint = "Изумрудное";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.Мутанты;
		base.DescriptionPoint = "Изумрудное представляет собой несколько полуразрушенных строений на холме. В дальней части находится сцена. Это место предназначалось для летнего отдыха детей, здесь был пионерский лагерь.";
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
		base.ControlInt = 9;
		base.DealerInt = 9;
		base.exchange = false;
		base.Repair = false;
		base.TaskChoise = false;
		base.XRay = 0;
		base.Burn = 0;
		base.ChemicalBurn = 0;
		base.curGexPoint = Gexa.GexLib[348];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
	}
}
