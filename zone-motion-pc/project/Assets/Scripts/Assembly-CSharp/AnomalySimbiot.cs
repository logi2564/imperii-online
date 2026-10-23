using UnityEngine;

public class AnomalySimbiot : ConstructorPoints
{
	public AnomalySimbiot()
	{
		base.CurMap = "RedForest";
		base.namePoint = "Аномалия Симбиот";
		base.pointTypes = PointTypes.Anomaly;
		base.pointControl = PointControl.Мутанты;
		base.DescriptionPoint = "Эта архианомалия представляет собой дальнейшее развитие «Загребущих рук». Основной поражающий фактор — сильное пси-воздействие на фоне высоких температур и высочайшего гравитационного давления. Масштабы аномальной зоны поражают: средний радиус влияния колеблется от 20 до 30 метров. Аномалия хорошо заметна в любое время суток по волнообразному искривлению воздуха, поднимающегося высоко в небо. Находится в единственном экземпляре в Рыжем лесу.";
		base.ControlInt = 9;
		base.DealerInt = 9;
		base.exchange = false;
		base.XRay = 2;
		base.curGexPoint = Gexa.GexLib[339];
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
