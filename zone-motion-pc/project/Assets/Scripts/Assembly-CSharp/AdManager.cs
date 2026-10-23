using UnityEngine;

public class AdManager : MonoBehaviour
{
	private void Update()
	{
		base.gameObject.transform.GetChild(1).transform.Rotate(0f, 0f, Time.deltaTime * -140f);
	}
}
