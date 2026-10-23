using UnityEngine;

public class MutantDarkValley : ConstructorPoints
{
	public MutantDarkValley()
	{
		base.CurMap = "DarkValley";
		base.namePoint = "Лежка мутантов";
		base.pointTypes = PointTypes.Field;
		base.pointControl = PointControl.Мутанты;
		base.DescriptionPoint = "Расположенна между фермой и заводом в Тёмной долине, на болоте. Болото разделено мостом на две части. На каждой из них расположены по острову с полуразрушенными мостиками, мусором и брошенным транспортом. Рядом бродят стаи мутантов.";
		base.ControlInt = 9;
		base.DealerInt = 9;
		base.exchange = false;
		base.XRay = 2;
		base.curGexPoint = Gexa.GexLib[248];
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
