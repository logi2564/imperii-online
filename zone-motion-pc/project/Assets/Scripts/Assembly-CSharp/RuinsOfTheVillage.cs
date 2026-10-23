using UnityEngine;

public class RuinsOfTheVillage : ConstructorPoints
{
	public RuinsOfTheVillage()
	{
		base.CurMap = "Marsh";
		base.namePoint = "Руины деревни";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "На северо-западе локации расположено полуразрушенное и полузатопленное поселение, именуемое Руинами деревни. Здесь есть несколько домов, часть их которых находятся в критическом состоянии, а другая часть развалена до основания. Одно из зданий уничтожено гравитационной аномалией. На территории деревни есть подвал и водонапорная башня.";
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.Repair = false;
		base.TaskChoise = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[257];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		base.Teleport = "Kordon";
		base.TeleportName = " на Кордон";
		base.TeleportGex = Gexa.GexLib[5];
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
	}
}
