using UnityEngine;

public class AnomalyCircus : ConstructorPoints
{
	public AnomalyCircus()
	{
		base.CurMap = "Backwater";
		base.namePoint = "Аномалия ''Цирк''";
		base.pointTypes = PointTypes.Anomaly;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "«Цирк» — интересная аномалия, располагающаяся на Затоне. В результате неизвестных процессов в земле образовалось некое углубление, в центре которого оказались «жарки». На высоте около десяти метров находится «карусель». Свое название, видимо, получила из-за схожести с ареной цирка. Внутри кружатся две подвижные огненные аномалии, которые могут причинить существенный урон. Но и хабар здесь можно найти отличный.";
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.Repair = false;
		base.TaskChoise = false;
		base.XRay = 1;
		base.Burn = 3;
		base.ChemicalBurn = 0;
		base.curGexPoint = Gexa.GexLib[50];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
	}
}
