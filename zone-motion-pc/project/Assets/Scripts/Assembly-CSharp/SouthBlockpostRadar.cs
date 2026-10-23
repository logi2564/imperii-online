using UnityEngine;

public class SouthBlockpostRadar : ConstructorPoints
{
	public SouthBlockpostRadar()
	{
		base.CurMap = "Radar";
		base.namePoint = "Южный блокпост радара";
		base.pointTypes = PointTypes.Field;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Ничем не примечательный блокпост, контролируемый бойцами группировки «Монолит». Имеет каморку, шлагбаум, бетонные блоки и два, фонящих радиацией микроавтобуса. Блокпост, расположенный южнее Выжигателя. Контролирует дорогу, ведущую к военным складам.";
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[39];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		base.Teleport = "Military";
		base.TeleportName = " к военным складам";
		base.TeleportGex = Gexa.GexLib[558];
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
	}
}
