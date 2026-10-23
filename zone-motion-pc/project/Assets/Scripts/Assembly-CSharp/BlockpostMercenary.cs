using UnityEngine;

public class BlockpostMercenary : ConstructorPoints
{
	public BlockpostMercenary()
	{
		base.CurMap = "Military";
		base.namePoint = "Блокпост наемников";
		base.pointTypes = PointTypes.Field;
		base.pointControl = PointControl.Наемники;
		base.DescriptionPoint = "Блокпост является заброшенной автобусной остановкой. Рядом расположен брошенный автобус ЛАЗ-4202. Блокпост неплохо укреплён. Здесь присутствуют баррикады, за которыми можно держать оборону. Помимо них, укрытиями также могут послужить деревянные ящики, на которых нарисована эмблема Наёмников.";
		base.ControlInt = 5;
		base.DealerInt = 5;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[500];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		base.Teleport = "DeadCity";
		base.TeleportName = " в мертвый город";
		base.TeleportGex = Gexa.GexLib[578];
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
	}
}
