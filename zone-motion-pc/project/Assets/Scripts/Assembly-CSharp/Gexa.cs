using System.Collections.Generic;
using UnityEngine;

public class Gexa : MonoBehaviour
{
	public GameObject _gex;

	public static List<ConstructorGex> GexLib;

	private void Awake()
	{
		GexLib = new List<ConstructorGex>();
		for (int i = -14; i < 17; i++)
		{
			for (int j = -10; j < 10; j++)
			{
				_gex = (GameObject)Object.Instantiate(Resources.Load("Prefabs/Gex"));
				ConstructorGex constructorGex = new ConstructorGex();
				constructorGex.NameGex = j + "x" + i + "y";
				constructorGex._YGex = i;
				constructorGex._XGex = j;
				constructorGex.ID = GexLib.Count;
				constructorGex.GexGO = _gex;
				if (i % 2 == 0)
				{
					_gex.transform.position = new Vector3((float)j * 0.9f + 0.44f, (float)i * 0.78f, 0f);
				}
				else
				{
					_gex.transform.position = new Vector3((float)j * 0.9f, (float)i * 0.78f, 0f);
				}
				_gex.GetComponent<SpriteRenderer>().color = new Color(0.45f, 0.45f, 0.25f, 0f);
				_gex.name = j + "x" + i + "y";
				GexLib.Add(constructorGex);
			}
		}
	}
}
