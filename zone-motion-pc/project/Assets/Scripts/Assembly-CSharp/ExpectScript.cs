using System.Collections;
using UnityEngine;

public class ExpectScript : MonoBehaviour
{
	private void Start()
	{
		StartCoroutine(AAAAAAAAAAAAAAAAAAAh());
	}

	private IEnumerator AAAAAAAAAAAAAAAAAAAh()
	{
		base.gameObject.transform.GetChild(0).transform.Rotate(0f, 0f, -2f);
		yield return null;
	}
}
