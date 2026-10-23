using UnityEngine;

public class DogParking : ConstructorPoints
{
	public DogParking()
	{
		base.CurMap = "RedForest";
		base.namePoint = "Собачья стоянка";
		base.pointTypes = PointTypes.Field;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Название говорит само за себя. Сюда часто забегают слепые псы, которые нападают на любого непрошеного гостя. Поговаривают, что отсюда можно пробраться прямо к Выжигателю мозгов...";
		base.ControlInt = 11;
		base.DealerInt = 11;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[419];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		base.Teleport = "Radar";
		base.TeleportName = " к Радару";
		base.TeleportGex = Gexa.GexLib[161];
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
	}
}
