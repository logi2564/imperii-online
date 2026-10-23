using UnityEngine;

public class BaseClearSky : ConstructorPoints
{
	public BaseClearSky()
	{
		base.CurMap = "Marsh";
		base.namePoint = "База Чистого Неба";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.Чистое_небо;
		base.DescriptionPoint = "Основные силы группировки Чистое небо расположились на небольшом затопленном хуторе, скрытом густыми зарослями от внешнего мира, в юго-западном уголке Болот. Лагерь оснащён оборудованием и приборами, предназначенными для различных исследований и замеров.";
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
		base.ControlInt = 7;
		base.DealerInt = 7;
		base.exchange = true;
		base.Repair = true;
		base.TaskChoise = true;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[120];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
	}
}
