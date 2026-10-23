using UnityEngine;

public class VNZcircle : ConstructorPoints
{
	public VNZcircle()
	{
		base.CurMap = "Backwater";
		base.namePoint = "ВНЗ «Круг»";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Станция Возвратно-Наклонного Зондирования Ионосферы. Это вспомогательная система для ЗГРЛС (Загоризонтная Радиолокационная станция). Система имеет вид двух кругов диаметром 300 метров, состоящих из 240 десятиметровых антенн. В центре круга находится низкое одноэтажное здание с приемной аппаратурой, на крыше здания находится центральная антенна. Это своеобразный целеуказатель для «больших» антенн ЗГРЛС. По своему прямому назначению эта система не использовалась, зато на ней проводились разнообразные эксперименты по пассивной радиолокации в коротко-волновом диапазоне.";
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.Repair = false;
		base.TaskChoise = false;
		base.XRay = 0;
		base.Burn = 0;
		base.ChemicalBurn = 0;
		base.curGexPoint = Gexa.GexLib[243];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
	}
}
