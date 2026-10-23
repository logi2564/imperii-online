using GooglePlayGames;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
	public GameObject Camera;

	private bool AAAAAAAAAAAAAAAbt = true;

	private bool AAAAAAAAAAAAAAAAAAAAcm;

	private Vector3 AAAAAAAAAAAAAAAAAAAcd = new Vector3(1f, 1f, -10f);

	private Vector3 AAAAAAAAAAAAAAAbu = new Vector3(-1f, 1f, -10f);

	public GameObject Lighting;

	private float AAAAAAAAAAAAAAAAAAAce;

	private bool AAAAAAAAAAAAAAAAAAda;

	public GUIStyle _guiEquipment;

	public GUIStyle _guiIconGroup;

	public GUIStyle _StateCh;

	public GUIStyle _StateH;

	public GUIStyle _StateW;

	public static int _posY;

	public static int _posY2;

	public static int _posY3;

	public static int _posX3;

	public static int _posY4;

	public static int _posX5;

	public static int _posX2_3;

	public static int _posY5;

	public static int _posY6;

	public static int _posY7;

	public static int _posY8;

	public static int _posY9;

	public static int _posX8;

	public static int _posX9;

	public static int _posX10;

	public static int _posY10;

	public static int _posY16;

	public static int _posY32;

	public static int _posY64;

	public static int _posY96;

	private int AAAAAAAAAAAAAAcc;

	private int AAAAAAAAAAAAAAAAAbs;

	private int AAAAAAAAAAAAAAAAAAco;

	private int AAAAAAAAAAAAAAAAAAAbs;

	public static bool _hasKey;

	public static bool _messadge;

	private Texture2D AAAAAAAAAAAAAAAAAAAbv;

	private Texture2D AAAAAAAAAAAAAAAAbr;

	private Texture2D AAAAAAAAAAAAAAAAAAcs;

	private Texture2D AAAAAAAAAAAAAAAAAAAAAcd;

	public Texture2D _exit;

	public static AudioSource AudioGame;

	public static AudioSource SoundMenu;

	public static AudioSource SoundBG;

	public static AudioClip effectBip;

	public static GameObject MessadgePanel;

	public GameObject PanelMenu;

	private void Start()
	{
		Screen.orientation = ScreenOrientation.AutoRotation;
		Screen.autorotateToLandscapeLeft = true;
		Screen.autorotateToLandscapeRight = true;
		Screen.autorotateToPortrait = false;
		Screen.autorotateToPortraitUpsideDown = false;
		Camera = GameObject.Find("Main Camera");
		AudioGame = GameObject.Find("Main Camera").GetComponent<AudioSource>();
		SoundMenu = GameObject.Find("SoundEffect").GetComponent<AudioSource>();
		SoundBG = GameObject.Find("SoundBG").GetComponent<AudioSource>();
		effectBip = (AudioClip)Resources.Load("Sound/pda/contact_1");
		AAAAAAAAAAAAAAAbw.AAAAAAAAAAAAAAAAAcc();
		_posY = Screen.height;
		_posY2 = Screen.height / 2;
		_posX2_3 = Screen.width / 3 * 2;
		_posX3 = Screen.width / 3;
		_posY3 = Screen.height / 3;
		_posX5 = Screen.width / 5;
		_posY4 = Screen.height / 4;
		_posY5 = Screen.height / 5;
		_posY6 = Screen.height / 6;
		_posY7 = Screen.height / 7;
		_posY8 = Screen.height / 8;
		_posY9 = Screen.height / 9;
		_posX8 = Screen.width / 8;
		_posX9 = Screen.width / 9;
		_posX10 = Screen.width / 10;
		_posY10 = Screen.height / 10;
		_posY16 = Screen.height / 16;
		_posY32 = Screen.height / 32;
		_posY64 = Screen.height / 64;
		_posY96 = Screen.height / 96;
		AAAAAAAAAAAAAAAAAbs = Screen.height - _posY4;
		AAAAAAAAAAAAAAAAAAco = Screen.height - _posY8;
		AAAAAAAAAAAAAAAAAAAbs = Screen.width - _posY8;
		AAAAAAAAAAAAAAAAAAAbv = (Texture2D)Resources.Load("Sprites/IconGUI/minus64");
		AAAAAAAAAAAAAAAAbr = (Texture2D)Resources.Load("Sprites/IconGUI/plus64");
		AAAAAAAAAAAAAAAAAAcs = (Texture2D)Resources.Load("Sprites/IconGUI/mute64");
		AAAAAAAAAAAAAAAAAAAAAcd = (Texture2D)Resources.Load("Sprites/IconGUI/muteOff64");
		_exit = (Texture2D)Resources.Load("Sprites/IconGUI/Exit64");
		_StateW.fontSize = _posY8;
		_StateCh.fontSize = _posY16 - _posY64;
		_guiEquipment.fontSize = _posY16;
		_guiIconGroup.fontSize = _posY16;
		AAAAAAAAAAAAAAAAAAcz.AAAAAAAAAAAAAAAAAcb();
		if (Application.platform == RuntimePlatform.Android && Advertisement.isSupported)
		{
			Advertisement.Initialize("1587463", false);
			Advertisement.IsReady();
		}
		bool flag = false;
		if ((bool)GameObject.Find("GPSgameObject"))
		{
			flag = true;
		}
		if (!flag)
		{
			GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/GPSobjects/GPSgameObject"));
			gameObject.name = "GPSgameObject";
		}
		if (!PlayerPrefs.HasKey("HeroName"))
		{
			PlayerPrefs.SetString("HeroName", "Странник");
		}
		if (PlayerPrefs.GetString("HeroName") == string.Empty)
		{
			PlayerPrefs.SetString("HeroName", "Странник");
		}
		if (!PlayerPrefs.HasKey("GPSusing"))
		{
			PlayerPrefs.SetInt("GPSusing", 1);
		}
		float num = Screen.width;
		num /= 1280f;
		PanelMenu.transform.localScale = new Vector3(num, num);
	}

	private void OnGUI()
	{
		if (!AAAAAAAAAAAAAAAbt)
		{
			Camera.GetComponent<Camera>().orthographicSize += 0.0003f;
			if (Camera.GetComponent<Camera>().orthographicSize >= 5.1f)
			{
				AAAAAAAAAAAAAAAbt = true;
			}
		}
		else
		{
			Camera.GetComponent<Camera>().orthographicSize -= 0.0002f;
			if (Camera.GetComponent<Camera>().orthographicSize <= 4.35f)
			{
				AAAAAAAAAAAAAAAbt = false;
			}
		}
		if (AAAAAAAAAAAAAAAAAAAAcm)
		{
			Camera.transform.position = Vector3.MoveTowards(Camera.transform.position, AAAAAAAAAAAAAAAAAAAcd, Time.deltaTime * 0.01f);
			if (Camera.transform.position == AAAAAAAAAAAAAAAAAAAcd)
			{
				AAAAAAAAAAAAAAAAAAAAcm = false;
			}
		}
		if (!AAAAAAAAAAAAAAAAAAAAcm)
		{
			Camera.transform.position = Vector3.MoveTowards(Camera.transform.position, AAAAAAAAAAAAAAAbu, Time.deltaTime * 0.01f);
			if (Camera.transform.position == AAAAAAAAAAAAAAAbu)
			{
				AAAAAAAAAAAAAAAAAAAAcm = true;
			}
		}
		if (AAAAAAAAAAAAAAAAAAda)
		{
			AAAAAAAAAAAAAAAAAAAce -= 0.002f;
			if (AAAAAAAAAAAAAAAAAAAce <= 0f)
			{
				AAAAAAAAAAAAAAAAAAda = false;
			}
		}
		if (!AAAAAAAAAAAAAAAAAAda)
		{
			AAAAAAAAAAAAAAAAAAAce += 0.001f;
			if ((double)AAAAAAAAAAAAAAAAAAAce >= 0.99)
			{
				AAAAAAAAAAAAAAAAAAda = true;
			}
		}
		if (AAAAAAAAAAAAAAAAAAAce >= 0.988f && AAAAAAAAAAAAAAAAAAAce <= 0.991f)
		{
			Lighting.GetComponent<AudioSource>().mute = AudioGame.mute;
			Lighting.GetComponent<AudioSource>().volume = AudioGame.volume;
			Lighting.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("Sound/backMusic/thunder/thunder-2");
			Lighting.GetComponent<AudioSource>().Play();
		}
		if (AAAAAAAAAAAAAAAAAAAce >= 0.988f || (AAAAAAAAAAAAAAAAAAAce >= 86f && AAAAAAAAAAAAAAAAAAAce <= 9f))
		{
			Lighting.GetComponent<Image>().color = new Color(1f, 1f, 1f, AAAAAAAAAAAAAAAAAAAce);
		}
		else
		{
			Lighting.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
		}
	}

	public static void AAAAAAAAAAAAAAAAbz()
	{
		SoundMenu.clip = effectBip;
		SoundMenu.Play();
	}

	public void OpenMesadge()
	{
		AAAAAAAAAAAAAAAAbz();
		MessadgePanel = (GameObject)Object.Instantiate(Resources.Load("Prefabs/PrefabOfStartmenu/UpdateMessadge"));
		MessadgePanel.transform.SetParent(GameObject.Find("Canvas").transform);
		MessadgePanel.transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = "Огромная благодарность тестировщикам, сообщавшим об ошибках и неточностях!\nОбновление 1.275\nДобавлен квест у группировки Долг: ''Разведка на насосной станции''.\nИсправлениа ошибка с детекторами Велес и Медведь.\nПереработан квест ''Проводник''.\nДобавлена винтовка ''СВУ''.\nУвеличен урон всех гранат.\nПроведены работы по оптимизации, уменьшен размер приложения.\nПриносим свои извинения за ошибки, которые еще не удалось исправить.\nСпасибо за понимание. Всем удачи!\n\nОбновление 1.272\nПереработан квест ''Провоник''.\nРаненный кровосос, в начале своего хода, восстанавливает 6% здоровья.\nСокращена частота автосохранений (работает 1 раз в 5 ходов, при переходе на локацию и начале новой игры).\nПереработана реклама, вознаграждения, меню рекламы.\nПриносим свои извинения за ошибки, которые еще не удалось исправить.\nПроведены работы по исправлению ошибок сохранений.\nСпасибо за понимание. Всем удачи!\n\nОбновление 1.267\nПроведены работы по исправлению сохранений.\nДобавлен предмет: Бронекостюм ''Булат''.\nДобавлен квест Одиночек на Агропроме: ''Найти награбленный хабар''.\nПриносим свои извинения за ошибки, которые еще не удалось исправить.\nСпасибо за понимание. Всем удачи!\n\nОбновление 1.264\nВ предыдущем обновлении была обнаружена ошибка сохранения, при переходе на другую локацию.\nПриносим извинения за неудобства и публикуем обновление с исправлением.\nСпасибо за понимание. Всем удачи!\n\nОбновление 1.263\nВ КПК добавлена энциклопедия.\nПереработаны квесты военных (можно перепройти заново, но 1 раз).\nДобавленсквест Одиночек на Агропроме:  ''Разведать планы военных''.\nИнтерфейс доработан под низкое разрешение экрана.\nВ целях повышения стабильности, в очередной раз переработан механизм сохранения.\nПриносим свои извинения за ошибки, которые еще не удалось исправить.\nСпасибо за понимание. Всем удачи!\n\nОбновление 1.261\nПолностью переработано стартовое меню.\nВ тестовом режиме добавлены достижения: Соратник Долга, Спутник Свободы, Ассистент, Дипломат, Разведчик ЧН.\nПереработано достижение: ''Исстребитель мутантов'' (мутанты приносят разное количество очков, в зависимости от вида).\nПереработан квест: ''Найти информацию об экспериментах'', общее число документов увеличено до 21-го.\nДобавлен квест у Одиночек: ''Следопыт''.\nДобавлен уникалный предмет: ''Аномальная куртка''.\nРабота по исправлению ошибок ведется регулярно.\nПриносим свои извинения за ошибки, которые еще не удалось исправить.\nСпасибо за понимание. Всем удачи!\n\nОбновление 1.259\nПолностью переработан интерфейс ПДА.\nДобавлена карта в ПДА.\nДобавлен квест у одиночек ''Найти кольт''.\nДобавлен предмет: ''Heckler - Koch G36E''\n\nОбновление 1.254\nПроведены работы по исправлению критических ошибок, зависаний НПС, исправлению сюжетных квестов, исправлению ошибок на локации ''Дикая территория''.\nДобавлены Предметы: ''Walther P99'', ''Кора 919'', ''H&K USP.45 Compact'', ''SPAS-12'', патроны: .45 АСР, ''часть тела контролера''.\nДобавлен квест у Одиночек, на кордоне: ''Спасти новичка''.\nВ тестовом режиме, добавлены сервисы Google Play Games (далее: GPS). Для тестирования необходимо стабильное подключение к интернету и в настройках включить соответствующее тестирование в основном меню.\nТестируются достижения и таблица рейтинга игроков (в зависимости о опыта).\nУвеличен переносимый вес, относительно очков хода, на 3 кг.\nУменьшен шанс спауна контролера.\n\nОбновление 1.253\nДобавлена локация ''Дикая территория''.\nНПС захватывают только точки, подконтрольные враждебным группировкам.\nПроведены работы по устранению ошибки исчезновения предметов при загрузке, зависанию НПС.\n\nОбновление 1.248\nДобавлен мутант : ''Контролер'' (в тестовом режиме, спаунится случайно и редко).\nПереработана квестовая ветка у наемников, добавлены новые квесты, переработаны некоторые старые.\nИсправлена дальность использования гранат.\nДобавлены костюмы: СПП99м, Экзоскелет ''Наемников''.\nВнесены изменения в интелект НПС.\nПредыдущие обновления:\n\nОбновление 1.247\nДобавлена возможность изменить имя главного героя (в тестовом режиме)\nИсправлена ошибка сохранения дипломатии.\nДобавлена возможность использовать нож в ближнем бою.\nСущественно переработаны характеристики оружия.\nДальнобойное оружие нельзя использовать на ближних дистанциях.\nПереработано меню персонажей на текущей локации.\nДобавлен квест у наемников: ''Принести схемы Выжигателя''\n\nОбновление 1.245\nПерерисована карта: Радар.\nДобавлены предметы: «Экзоскелет Монолита», ОЦ - 14 «Гроза».\nДобавлена возможность изменения громкости фоновой музыки.\nПереработано меню выбора заданий на точке.\n";
		MessadgePanel.transform.localPosition = new Vector3(0f, 0f);
		float num = Screen.width;
		num /= 1280f;
		Debug.Log(Screen.width + " " + num);
		MessadgePanel.transform.localScale = new Vector3(num, num);
	}

	public void SaveLoadPanelShow()
	{
		GameObject gameObject = GameObject.Find("SoundEffect");
		gameObject.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("Sound/pda/contact_1");
		gameObject.GetComponent<AudioSource>().Play();
		GameObject gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/SaveLoad/PanelSaveLoadMenu"));
		gameObject2.name = "PanelSaveLoadMenu";
		gameObject2.transform.SetParent(GameObject.Find("Canvas").transform);
		gameObject2.transform.localPosition = new Vector3(0f, 0f);
		float num = Screen.width;
		num /= 1200f;
		gameObject2.transform.localScale = new Vector3(num, num);
		gameObject2.transform.GetChild(0).transform.localPosition = new Vector3(0f, 0f);
	}

	public void NewGamePanelShow()
	{
		GameObject gameObject = GameObject.Find("SoundEffect");
		gameObject.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("Sound/pda/contact_1");
		gameObject.GetComponent<AudioSource>().Play();
		GameObject gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/NewGamePanel/NewGamePanel"));
		gameObject2.name = "NewGamePanel";
		gameObject2.transform.SetParent(GameObject.Find("Canvas").transform);
		gameObject2.transform.localPosition = new Vector3(0f, 0f);
		float num = Screen.width;
		num /= 1200f;
		gameObject2.transform.localScale = new Vector3(num, num);
	}

	public void SettingsShow()
	{
		GameObject gameObject = GameObject.Find("SoundEffect");
		gameObject.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("Sound/pda/contact_1");
		gameObject.GetComponent<AudioSource>().Play();
		GameObject gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Settings/SettingsStartMenu"));
		gameObject2.name = "SettingsStartMenu";
		gameObject2.transform.SetParent(GameObject.Find("Canvas").transform);
		gameObject2.transform.localPosition = new Vector3(0f, 0f);
		gameObject2.gameObject.transform.GetChild(0).GetChild(0).GetComponent<Text>()
			.text = "Громкость: " + (int)(AudioGame.volume * 100f);
		gameObject2.gameObject.transform.GetChild(1).GetChild(0).GetComponent<Text>()
			.text = "Громкость фоновой музыки: " + (int)(SoundBG.volume * 100f);
		if (AudioGame.mute)
		{
			gameObject2.gameObject.transform.GetChild(2).GetChild(0).GetComponent<Text>()
				.text = "Mute";
			gameObject2.gameObject.transform.GetChild(2).GetChild(1).GetChild(0)
				.GetComponent<RawImage>()
				.texture = (Texture2D)Resources.Load("Sprites/IconGUI/mute64w");
		}
		else
		{
			gameObject2.gameObject.transform.GetChild(2).GetChild(0).GetComponent<Text>()
				.text = "Mute off";
			gameObject2.gameObject.transform.GetChild(2).GetChild(1).GetChild(0)
				.GetComponent<RawImage>()
				.texture = (Texture2D)Resources.Load("Sprites/IconGUI/muteOff64w");
		}
		if (PlayerPrefs.GetInt("GPSusing") == 0)
		{
			gameObject2.gameObject.transform.GetChild(3).GetChild(0).GetChild(0)
				.GetComponent<Text>()
				.text = "Включить сервис\nGooglePlayGames";
		}
		else
		{
			gameObject2.gameObject.transform.GetChild(3).GetChild(0).GetChild(0)
				.GetComponent<Text>()
				.text = "Отключить сервис\nGooglePlayGames";
		}
		float num = Screen.width;
		num /= 1100f;
		gameObject2.transform.localScale = new Vector3(num, num);
	}

	public void QuitGame()
	{
		PlayGamesPlatform.Instance.SignOut();
		Application.Quit();
	}

	public static void AAAAAAAAAAAAAAAAca(string AAAAAAAAAAAAAAAbv)
	{
		if (SoundMenu != null)
		{
			SoundMenu.clip = (AudioClip)Resources.Load("Sound/pda/pda_tip");
			SoundMenu.Play();
		}
		GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessagePanel"));
		gameObject.name = "MessagePanel";
		gameObject.transform.SetParent(GameObject.Find("Canvas").transform);
		gameObject.transform.localPosition = new Vector3(0f, 0f);
		gameObject.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width / 2);
		gameObject.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 2);
		gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().fontSize = Screen.height / 24;
		gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().color = new Color(0.85f, 0.72f, 0.48f, 0.95f);
		gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = AAAAAAAAAAAAAAAbv;
	}
}
