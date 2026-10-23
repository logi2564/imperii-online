using UnityEngine;

public class SubBunker : ConstructorPoints
{
	public SubBunker()
	{
		base.CurMap = "Radar";
		base.namePoint = "Вход в подземный бункер";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.Зомби;
		base.DescriptionPoint = "Вход в подземный бункер, закрытый мощными электронными дверями. Имеет немногочисленные тоннели и небольшие помещения. Один из тоннелей ведет в неизвестном направлении. Бывалые сталкеры поговаривали, что по нему можно добраться к Мосту им. Преображенского, на Затоне.";
		base.DealerInt = 10;
		base.exchange = false;
		base.XRay = 3;
		base.curGexPoint = Gexa.GexLib[578];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		base.Teleport = "Backwater";
		base.TeleportName = " на Затон";
		base.TeleportGex = Gexa.GexLib[198];
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
	}
}
