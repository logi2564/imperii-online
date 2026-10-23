using UnityEngine;

public class HeadquartersBase : ConstructorPoints
{
	public HeadquartersBase()
	{
		base.CurMap = "Military";
		base.namePoint = "Штаб военной базы";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.Свобода;
		base.DescriptionPoint = "Изначально являлась базой военных. Во время Большого Выброса большинство военнослужащих погибли, а выслать подкрепление или эвакуировать оставшихся со складов не могли. Зомбированные и мутанты с Радара атаковали эту базу, постепенно оттесняя военных, а затем контроль над базой получила группировка «Свобода».";
		base.ControlInt = 6;
		base.DealerInt = 6;
		base.exchange = true;
		base.Repair = true;
		base.TaskChoise = true;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[53];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
	}
}
