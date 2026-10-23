using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;
using UnityEngine.UI;

public class GPSscript : MonoBehaviour
{
	public const string achiv1 = "CgkI2OGbhtMLEAIQAQ";

	public const string achiv2 = "CgkI2OGbhtMLEAIQAg";

	public const string achiv3 = "CgkI2OGbhtMLEAIQAw";

	public const string achiv4 = "CgkI2OGbhtMLEAIQBA";

	public const string achiv5 = "CgkI2OGbhtMLEAIQBQ";

	public const string achiv6 = "CgkI2OGbhtMLEAIQCA";

	public const string achiv7 = "CgkI2OGbhtMLEAIQCQ";

	public const string achiv8 = "CgkI2OGbhtMLEAIQCg";

	public const string achiv9 = "CgkI2OGbhtMLEAIQBw";

	public const string achiv10 = "CgkI2OGbhtMLEAIQCw";

	public const string achiv11 = "CgkI2OGbhtMLEAIQDA";

	public const string score1 = "CgkI2OGbhtMLEAIQBg";

	private const string AAAAAAAAAAAAAAAAAAAAAf = "CloudGameProgress";

	public static GPSscript Instance { get; private set; }

	private void Start()
	{
		Object.DontDestroyOnLoad(base.gameObject);
		Instance = this;
		AAAAAAAAAAAAAAAAAAAo();
	}

	public static void AAAAAAAAAAAAAAAAAAAo()
	{
		PlayGamesClientConfiguration configuration = new PlayGamesClientConfiguration.Builder().EnableSavedGames().Build();
		PlayGamesPlatform.InitializeInstance(configuration);
		PlayGamesPlatform.DebugLogEnabled = true;
		PlayGamesPlatform.Activate();
		if (PlayGamesPlatform.Instance.localUser.authenticated)
		{
			return;
		}
		Social.localUser.Authenticate((bool success) =>
		{
			if (success)
			{
				PlayerPrefs.SetInt("GPSusing", 1);
			}
			else
			{
				PlayerPrefs.SetInt("GPSusing", 0);
			}
		});
	}

	public static void AAAAAAAAAAAAAAAAAAAAe(string AAAAAAAAAAAAAAAAAAAAAAf)
	{
		if (PlayerPrefs.GetInt("GPSusing") != 0)
		{
			Social.ReportProgress(AAAAAAAAAAAAAAAAAAAAAAf, 100.0, (bool success) =>
			{
			});
		}
	}

	public static void AAAAAAAAAAAAAAAAAi(string AAAAAAAAAAAAAAAAAAAAAi, int AAAAAAAAAAAAAAAAd)
	{
		if (PlayerPrefs.GetInt("GPSusing") != 0)
		{
			PlayGamesPlatform.Instance.IncrementAchievement(AAAAAAAAAAAAAAAAAAAAAi, AAAAAAAAAAAAAAAAd, (bool success) =>
			{
			});
		}
	}

	public static void AAAAAAAAAAAAAAAAAAAAAj(string AAAAAAAAAAAAAAAAAj, long AAAAAAAAAAAAAAAAAAAAAAg)
	{
		if (PlayerPrefs.GetInt("GPSusing") != 0)
		{
			Social.ReportScore(AAAAAAAAAAAAAAAAAAAAAAg, AAAAAAAAAAAAAAAAAj, (bool success) =>
			{
			});
		}
	}

	public static void AAAAAAAAAAAAAAAAAk()
	{
		if (PlayerPrefs.GetInt("GPSusing") != 0)
		{
			Social.ShowAchievementsUI();
			return;
		}
		AAAAAAAAAAAAAAAAAAAq("Сервисы GooglePlayGames не подключены. Проверьте подключение к интернету.");
		AAAAAAAAAAAAAAAAAAAo();
	}

	public static void AAAAAAAAAAAAAAAAAAAp()
	{
		if (PlayerPrefs.GetInt("GPSusing") != 0)
		{
			AAAAAAAAAAAAAAAAAAAq("Сервис временно недоступен.");
			return;
		}
		AAAAAAAAAAAAAAAAAAAq("Сервисы GooglePlayGames не подключены. Проверьте подключение к интернету.");
		AAAAAAAAAAAAAAAAAAAo();
	}

	public static void AAAAAAAAAAAAAAAAAAAq(string AAAAAAAAAAAAAAAAAAAr)
	{
		GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessagePanel"));
		gameObject.name = "MessagePanel";
		gameObject.transform.SetParent(GameObject.Find("Canvas").transform);
		gameObject.transform.localPosition = new Vector3(0f, 0f);
		gameObject.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width / 2);
		gameObject.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 2);
		gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().fontSize = Screen.height / 24;
		gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().color = new Color(0.85f, 0.72f, 0.48f, 0.95f);
		gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = AAAAAAAAAAAAAAAAAAAr;
	}
}
