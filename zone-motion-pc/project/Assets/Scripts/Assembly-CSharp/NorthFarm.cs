using UnityEngine;

public class NorthFarm : ConstructorPoints
{
	public NorthFarm()
	{
		base.CurMap = "Marsh";
		base.namePoint = "Северный хутор";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Небольшое поселение в северо-восточной точке Болот. Здесь есть два сарая, одни их которых Г-образный, и два бывших жилых дома. На территории поселка стоит каменная маленькая подстанция. Также здесь расположен переход на Свалку.";
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.Repair = false;
		base.TaskChoise = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[537];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		base.Teleport = "Dump";
		base.TeleportName = " на Свалку";
		base.TeleportGex = Gexa.GexLib[22];
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
	}
}
