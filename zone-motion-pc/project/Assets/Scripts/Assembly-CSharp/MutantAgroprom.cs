using UnityEngine;

public class MutantAgroprom : ConstructorPoints
{
	public MutantAgroprom()
	{
		base.CurMap = "Agroprom";
		base.namePoint = "Логово мутантов на Агропроме";
		base.pointTypes = PointTypes.Anomaly;
		base.pointControl = PointControl.Мутанты;
		base.DescriptionPoint = "Пустынная местность на юго-востоке Агропрома. Мрачный пейзаж дополняют гниющие остатки мутантов и ржавое оружие...";
		base.ControlInt = 9;
		base.DealerInt = 9;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[58];
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
