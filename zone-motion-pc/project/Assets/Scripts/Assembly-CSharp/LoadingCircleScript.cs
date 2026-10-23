using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingCircleScript : MonoBehaviour
{
	private IEnumerator AAAAAAAAAAAAAAAAAAAt(string AAAAAAAAAAAAAAAAAAAAf, GameObject AAAAAAAAAAAAAAAAAAAAAl)
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync(AAAAAAAAAAAAAAAAAAAAf);
		while (!operation.isDone)
		{
			float progress = operation.progress / 0.92f;
			AAAAAAAAAAAAAAAAAAAAAl.transform.GetChild(0).GetComponent<Image>().fillAmount = progress;
			AAAAAAAAAAAAAAAAAAAAAl.transform.GetChild(1).GetComponent<Text>().text = string.Format("{0:0}%", progress * 100f);
			yield return null;
		}
	}

	public void AAAAAAAAAAAAAAAAe(string AAAAAAAAAAAAAAAAAl, string AAAAAAAAAAAAAAAAAAAAAm)
	{
		GameObject gameObject = (GameObject)Object.Instantiate(Resources.Load("Prefabs/LoadingImage/LoadingCircle"));
		gameObject.transform.SetParent(GameObject.Find("Canvas").transform);
		gameObject.transform.localPosition = new Vector3(0f, 0f);
		float num = Screen.width;
		num /= 1280f;
		gameObject.transform.localScale = new Vector3(num, num);
		SaveLoad.SaveName = AAAAAAAAAAAAAAAAAAAAAm;
		StartCoroutine(AAAAAAAAAAAAAAAAAAAt(AAAAAAAAAAAAAAAAAl, gameObject));
	}
}
