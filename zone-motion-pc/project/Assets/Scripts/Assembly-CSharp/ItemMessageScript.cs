using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ItemMessageScript : MonoBehaviour
{
	private float AAAAAAAAAAAAAAAAAAAAAk = 1f;

	private void Start()
	{
		StartCoroutine(AAAAAAAAAAAAAAAAAAAs());
	}

	private IEnumerator AAAAAAAAAAAAAAAAAAAs()
	{
		while (AAAAAAAAAAAAAAAAAAAAAk > 0f)
		{
			AAAAAAAAAAAAAAAAAAAAAk -= 0.002f;
			Inventory.InstantMessage.transform.GetChild(0).GetChild(1).GetComponent<Text>()
				.color = new Color(Inventory.InstantMessage.transform.GetChild(0).GetChild(1).GetComponent<Text>()
				.color.r, Inventory.InstantMessage.transform.GetChild(0).GetChild(1).GetComponent<Text>()
				.color.g, Inventory.InstantMessage.transform.GetChild(0).GetChild(1).GetComponent<Text>()
				.color.b, AAAAAAAAAAAAAAAAAAAAAk);
			Inventory.InstantMessage.transform.GetChild(0).GetChild(0).GetComponent<RawImage>()
				.color = new Color(Inventory.InstantMessage.transform.GetChild(0).GetChild(0).GetComponent<RawImage>()
				.color.r, Inventory.InstantMessage.transform.GetChild(0).GetChild(0).GetComponent<RawImage>()
				.color.g, Inventory.InstantMessage.transform.GetChild(0).GetChild(0).GetComponent<RawImage>()
				.color.b, AAAAAAAAAAAAAAAAAAAAAk);
			yield return null;
		}
		Object.Destroy(base.gameObject);
	}
}
