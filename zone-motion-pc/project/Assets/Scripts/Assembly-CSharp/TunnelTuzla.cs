using UnityEngine;

public class TunnelTuzla : ConstructorPoints
{
	public TunnelTuzla()
	{
		base.CurMap = "Marsh";
		base.namePoint = "Тоннель ''Тузла''";
		base.pointTypes = PointTypes.Anomaly;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Железная дорога на западе локации уходит через разрушенный мост в тоннель под названием «Тузла», о чем свидетельствуют ржавые буквы над въездом в тоннель. Что значит название над тоннелем, неизвестно.";
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.Repair = false;
		base.TaskChoise = false;
		base.XRay = 5;
		base.curGexPoint = Gexa.GexLib[561];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
	}
}
