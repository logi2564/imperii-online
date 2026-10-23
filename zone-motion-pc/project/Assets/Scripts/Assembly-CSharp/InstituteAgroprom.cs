using UnityEngine;

public class InstituteAgroprom : ConstructorPoints
{
	public InstituteAgroprom()
	{
		base.CurMap = "Agroprom";
		base.namePoint = "Институт Агропром";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.Военные;
		base.DescriptionPoint = "Институт «Агропром» — институт, появившийся в начале 2002 года. Является явно военно-ориентированным: это можно понять по железным ангарам, смотровым вышкам и небольшому зданию с медицинской комнатой для оперирования в полевых условиях. Внутри основного здания находятся разбросанное по разным комнатам ржавое медицинское, научно-техническое и военное оборудование.На крыше располагается вертолётная площадка.Недалеко от НИИ лежит разбитый Ми-24, судя по всему не сумевший туда приземлиться.";
		base.ControlInt = 3;
		base.DealerInt = 3;
		base.exchange = true;
		base.Repair = true;
		base.TaskChoise = true;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[163];
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
