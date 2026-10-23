using UnityEngine;

public class DeadFarmstead : ConstructorPoints
{
	public DeadFarmstead()
	{
		base.CurMap = "DeadCity";
		base.namePoint = "Мертвый хутор";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.Чистое_небо;
		base.DescriptionPoint = "Севернее Мертвого города, расположен хутор. По непонятным причинам, шанс погибнуть рядом с ним увеличивается многократно. Сталкеры прозвали его ''Мертвым хутором''. Здесь же находится начало пути  к Рыжему лесу. Без хорошей подготовки и снаряги, лучше не двигаться в этом направлении...";
		base.ControlInt = 7;
		base.DealerInt = 7;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[582];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		base.Teleport = "RedForest";
		base.TeleportName = " в Рыжий лес";
		base.TeleportGex = Gexa.GexLib[29];
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
	}
}
