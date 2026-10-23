using UnityEngine;

public class Spring : ConstructorPoints
{
	public Spring()
	{
		base.CurMap = "DeadCity";
		base.namePoint = "Родник";
		base.pointTypes = PointTypes.Field;
		base.pointControl = PointControl.Мутанты;
		base.DescriptionPoint = "На берегу небольшой реки, на севере города, бьет родник. На удивление, вода в нем чистейшая, без намека на химические примеси и радиацию. Даже мутанты ведут себя спокойнее, рядом с этим местечком.";
		base.ControlInt = 9;
		base.DealerInt = 9;
		base.exchange = false;
		base.XRay = 0;
		base.curGexPoint = Gexa.GexLib[488];
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
