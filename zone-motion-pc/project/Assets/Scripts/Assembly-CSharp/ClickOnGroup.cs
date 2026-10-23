using UnityEngine;
using UnityEngine.UI;

public class ClickOnGroup : MonoBehaviour
{
	public void ClickOnButtonGroup()
	{
		for (int i = 0; i < 13; i++)
		{
			if (base.gameObject.transform.GetChild(0).GetComponent<RawImage>().texture.name == Data.Dealers[i].IconGroup.name)
			{
				base.gameObject.transform.parent.parent.parent.GetComponent<Diplomacy>().AAAAAAAAAAAAAAAAAAAg(i);
				break;
			}
		}
	}
}
