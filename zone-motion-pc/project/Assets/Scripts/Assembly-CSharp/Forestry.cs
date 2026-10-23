using UnityEngine;

public class Forestry : ConstructorPoints
{
	public Forestry()
	{
		base.CurMap = "Backwater";
		base.namePoint = "Лесничество";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Когда-то здесь было Лесничество, но теперь только пустые цеха и административный корпус. Вольные сталкеры и бандиты регулярно пытались установить здесь свой контроль. После достаточно ожесточенных стычек, точка стала нетральна. Теперь эту территорию стараются обходить стороной, лишь экологи захаживают сюда. Также рядом расположен мост им. Преображенского.";
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
		base.ControlInt = 11;
		base.DealerInt = 11;
		base.exchange = false;
		base.Repair = false;
		base.TaskChoise = false;
		base.XRay = 0;
		base.Burn = 0;
		base.ChemicalBurn = 0;
		base.curGexPoint = Gexa.GexLib[338];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
	}
}
