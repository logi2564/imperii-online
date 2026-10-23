using UnityEngine;

public class MutantBaseDump : ConstructorPoints
{
	public MutantBaseDump()
	{
		base.CurMap = "Dump";
		base.namePoint = "Логово мутантов на свалке";
		base.pointTypes = PointTypes.Field;
		base.pointControl = PointControl.Мутанты;
		base.DescriptionPoint = "На северо-западе Свалки мутанты особенно агрессивны. Бывалые сталкеры поговаривают, что там есть глубокая пещера, откуда мутанты буквально вываливаются в огромном количестве...";
		base.ControlInt = 9;
		base.DealerInt = 9;
		base.exchange = false;
		base.XRay = 2;
		base.curGexPoint = Gexa.GexLib[561];
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
