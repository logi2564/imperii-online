using UnityEngine;

public class NorthCamp : ConstructorPoints
{
	public NorthCamp()
	{
		base.CurMap = "WildTerritory";
		base.namePoint = "Северный лагерь";
		base.pointTypes = PointTypes.Field;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Стоянка сталкеров, севернее Дикой территории. Здесь относительно спокойно днем, но оставаться на ночлег здесь крайне опасно. От выброса тут не спрятаться. Изредка сюда может забежать стая слепых псов или кабан.";
		base.ControlInt = 1;
		base.DealerInt = 1;
		base.exchange = true;
		base.TaskChoise = true;
		base.Repair = true;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[615];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		base.Teleport = "Military";
		base.TeleportName = " на военные слады";
		base.TeleportGex = Gexa.GexLib[180];
		base.TeleportDouble = "Bar";
		base.TeleportNameDouble = " к бару";
		base.TeleportGexDouble = Gexa.GexLib[560];
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
	}
}
