using UnityEngine;

public class EjectTimeSc : MonoBehaviour
{
	private static int AAAAAAAAAAAAAAAAAbn = 25;

	public static int Ejection
	{
		get
		{
			return AAAAAAAAAAAAAAAAAbn;
		}
		set
		{
			if (value >= -2)
			{
				AAAAAAAAAAAAAAAAAbn = value;
			}
			if (value < -2)
			{
				AAAAAAAAAAAAAAAAAbn = Random.Range(25, 45);
			}
		}
	}

	private void Start()
	{
		Object.DontDestroyOnLoad(base.gameObject);
	}
}
