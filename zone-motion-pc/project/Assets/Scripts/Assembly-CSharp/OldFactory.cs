using UnityEngine;

public class OldFactory : ConstructorPoints
{
	public OldFactory()
	{
		base.CurMap = "DarkValley";
		base.namePoint = "Старый завод";
		base.pointTypes = PointTypes.Construction;
		base.pointControl = PointControl.Наемники;
		base.DescriptionPoint = "Старый небольшой завод. В составе: 2-3 здания, склад, водонапорная башня, кран и длинный забор. Ранее использовался наемниками как аванпост. На нём располагался секретный тоннель, по которому головорезы перебрасывали свои отряды неизвестно откуда в Тёмную долину. Бывалые сталкеры поговаривают, что там имеется вход в лабораторию X18.";
		base.ControlInt = 5;
		base.DealerInt = 5;
		base.exchange = true;
		base.Repair = true;
		base.TaskChoise = true;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[275];
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
