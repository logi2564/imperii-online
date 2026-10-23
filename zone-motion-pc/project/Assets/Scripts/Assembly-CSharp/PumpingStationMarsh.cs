using UnityEngine;

public class PumpingStationMarsh : ConstructorPoints
{
	public PumpingStationMarsh()
	{
		base.CurMap = "Marsh";
		base.namePoint = "Насосная Станция";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.None;
		base.DescriptionPoint = "К северу от Рыбацкого хутора и Россыпи камней расположена старая насосная станция. Обветшалое деревянное строение, стоящее над водой на деревянных сваях, окутано сплетениями ржавых труб; рядом установлено множество резервуаров. К насосной станции пристроена наблюдательная вышка. В самом помещении находится насос, который, судя по звуку, работает. Вблизи одной из труб, идущей от насоса, у самого дна можно услышать чавкающие звуки, что также свидетельствует о функционировании станции.";
		base.TexturePoint = (Texture2D)Resources.Load("Sprites/PointsTexture/" + base.CurMap + "/" + base.namePoint);
		base.ControlInt = 0;
		base.DealerInt = 0;
		base.exchange = false;
		base.Repair = false;
		base.TaskChoise = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[285];
		base.PointUnits = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Point"));
		base.PointUnits.name = base.namePoint;
		base.PointUnits.transform.position = base.curGexPoint.GexGO.transform.position;
		for (int i = 0; i < base.Cache.Length; i++)
		{
			base.Cache[i] = new AAAAAAAAAAAAAAAAAAbi();
		}
	}
}
