using UnityEngine;

public class Locomotive : ConstructorPoints
{
	public Locomotive()
	{
		base.CurMap = "Kordon";
		base.namePoint = "Перевернутый тепловоз";
		base.pointTypes = PointTypes.Anomaly;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Сошедший с рельс старый тепловоз, находящийся на востоке Кордона. Датчики регистрируют сильнейший радиационный фон и аномальную активность. В деревне поговаривают, что здесь можео разжитья артефатами.";
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.XRay = 3;
		base.curGexPoint = Gexa.GexLib[396];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = GameObject.Find(base.curGexPoint.NameGex).transform.position;
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
	}
}
