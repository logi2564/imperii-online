using UnityEngine;

public class ShackAtTheOldPond : ConstructorPoints
{
	public ShackAtTheOldPond()
	{
		base.CurMap = "WildTerritory";
		base.namePoint = "Лачуга у старого пруда";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "Обманчивое своим спокойствием, на первый взгляд, тихое местечко. Расположено юго-западнее Дикой территории. Сталкеры поговаривали, что здесь обитает контролер, по тому то и мутанты сюда забегают не часто.  От пруда исходит жуткий смрад, разлагающихся тел, но останков не видно.";
		base.ControlInt = 10;
		base.DealerInt = 10;
		base.exchange = true;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[22];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
	}
}
