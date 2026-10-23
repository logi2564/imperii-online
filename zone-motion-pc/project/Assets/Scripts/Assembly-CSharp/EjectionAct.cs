using UnityEngine;
using UnityEngine.UI;

public class EjectionAct : MonoBehaviour
{
	public static GameObject mineCamera;

	public static float aColorRRR;

	public static float aColorGGG;

	public static float aColorBBB;

	public static float aColorAAA;

	private bool AAAAAAAAAAAAAAbl;

	private bool AAAAAAAAAAAAAAAAAAAAAbw;

	private bool AAAAAAAAAAAAAAbm;

	private bool AAAAAAAAAAAAAAAAbl;

	public static float RotXXX;

	public static float RotYYY = 0.03f;

	public static float RotZZZ;

	private bool AAAAAAAAAAAAAAbn;

	private bool AAAAAAAAAAAAAAAAAbm;

	private bool AAAAAAAAAAAAAAAAbm;

	public static Vector3 CameraNewPosition;

	private void Start()
	{
		mineCamera = GameObject.Find("Main Camera");
		aColorRRR = 1f;
		aColorGGG = 0.15f;
		aColorBBB = 0f;
		aColorAAA = 0.34f;
		CameraNewPosition = mineCamera.transform.position;
	}

	private void Update()
	{
		if (AAAAAAAAAAAAAAbl)
		{
			aColorRRR += 0.005f;
		}
		else
		{
			aColorRRR -= 0.005f;
		}
		if (aColorRRR >= 0.85f)
		{
			AAAAAAAAAAAAAAbl = false;
		}
		if (aColorRRR <= 0.15f)
		{
			AAAAAAAAAAAAAAbl = true;
		}
		if (AAAAAAAAAAAAAAAAAAAAAbw)
		{
			aColorGGG += 0.0034f;
		}
		else
		{
			aColorGGG -= 0.0034f;
		}
		if ((double)aColorGGG >= 0.55)
		{
			AAAAAAAAAAAAAAAAAAAAAbw = false;
		}
		if (aColorGGG <= 0.15f)
		{
			AAAAAAAAAAAAAAAAAAAAAbw = true;
		}
		if (AAAAAAAAAAAAAAbm)
		{
			aColorBBB += 0.0034f;
		}
		else
		{
			aColorBBB -= 0.0034f;
		}
		if ((double)aColorBBB >= 0.55)
		{
			AAAAAAAAAAAAAAbm = false;
		}
		if (aColorBBB <= 0.15f)
		{
			AAAAAAAAAAAAAAbm = true;
		}
		if (AAAAAAAAAAAAAAAAbl)
		{
			aColorAAA += 0.001f;
		}
		else
		{
			aColorAAA -= 0.001f;
		}
		if ((double)aColorAAA >= 0.5)
		{
			AAAAAAAAAAAAAAAAbl = false;
		}
		if (aColorAAA <= 0.005f)
		{
			AAAAAAAAAAAAAAAAbl = true;
		}
		base.gameObject.GetComponent<RawImage>().color = new Color(aColorRRR, aColorGGG, aColorBBB, aColorAAA);
		if (AAAAAAAAAAAAAAAAbm)
		{
			RotZZZ += 0.0005f;
			if (RotZZZ <= -0.4f && RotZZZ > -0.45f)
			{
				RotZZZ += 0.006f;
			}
			if (RotZZZ <= -0.45f)
			{
				RotZZZ += 0.001f;
			}
			if (RotZZZ > -0.4f && RotZZZ < 0.4f)
			{
				RotZZZ += 0.02f;
			}
			if (RotZZZ >= 0.4f && RotZZZ < 0.45f)
			{
				RotZZZ += 0.006f;
			}
			if (RotZZZ >= 0.45f)
			{
				RotZZZ += 0.001f;
			}
		}
		else
		{
			RotZZZ -= 0.0001f;
			if (RotZZZ <= -0.75f)
			{
				RotZZZ -= 0.001f;
			}
			if (RotZZZ <= -0.5f && RotZZZ > -0.75f)
			{
				RotZZZ -= 0.006f;
			}
			if (RotZZZ > -0.5f && RotZZZ < 0.5f)
			{
				RotZZZ -= 0.03f;
			}
			if (RotZZZ >= 0.5f && RotZZZ <= 0.8f)
			{
				RotZZZ -= 0.009f;
			}
			if (RotZZZ >= 0.8f)
			{
				RotZZZ -= 0.002f;
			}
		}
		if (RotZZZ >= 1.35f)
		{
			AAAAAAAAAAAAAAAAbm = false;
		}
		if (RotZZZ <= -1.2f)
		{
			AAAAAAAAAAAAAAAAbm = true;
		}
		if (AAAAAAAAAAAAAAbn)
		{
			RotXXX += 0.02f;
		}
		else
		{
			RotXXX -= 0.3f;
		}
		if (RotXXX >= 0.37f)
		{
			AAAAAAAAAAAAAAbn = false;
			RotXXX = Random.Range(0.008f, 0.03f);
		}
		if (RotXXX <= -0.37f)
		{
			AAAAAAAAAAAAAAbn = true;
			RotXXX = Random.Range(0.003f, 0.001f);
		}
		if (AAAAAAAAAAAAAAAAAbm)
		{
			RotYYY += 0.04f;
		}
		else
		{
			RotYYY -= 0.3f;
		}
		if (RotYYY >= 0.51f)
		{
			AAAAAAAAAAAAAAAAAbm = false;
			RotYYY = Random.Range(0.003f, 0.015f);
		}
		if (RotYYY <= -0.55f)
		{
			AAAAAAAAAAAAAAAAAbm = true;
			RotYYY = Random.Range(0.008f, 0.03f);
		}
		mineCamera.transform.rotation = Quaternion.Euler(RotXXX, RotYYY, RotZZZ);
	}
}
