using UnityEngine;

public class HoleMutants : ConstructorPoints
{
	public HoleMutants()
	{
		base.CurMap = "Bar";
		base.namePoint = "Нора мутантов";
		base.pointTypes = PointTypes.Anomaly;
		base.pointControl = PointControl.Мутанты;
		base.DescriptionPoint = "Даже Бывалые сталкеры не решаются приходить сюда в одиночку. Спасают ситуацию регулярные зачистки отрядов долга.";
		base.ControlInt = 9;
		base.DealerInt = 9;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[550];
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
