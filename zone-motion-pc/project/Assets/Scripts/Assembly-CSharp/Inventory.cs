using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
	private int AAAAAAAAAAAAAAAAAAAAcb;

	public static int _QuantityClipsOfAdvertising;

	private int AAAAAAAAAAAAAAAAAbr;

	public static int _posY2;

	public static int _posX2;

	public static int _posY3;

	public static int _posX3;

	public static int _posY4;

	public static int _posX4;

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

	public static int _posY12;

	public static int _posY16;

	public static int _posY20;

	public static int _posY32;

	public static int _posX32;

	public static int _posY64;

	private int AAAAAAAAAAAAAAAAAAAAcc;

	private int AAAAAAAAAAAAAAAAbq;

	private int AAAAAAAAAAAAAAAAAbs;

	private int AAAAAAAAAAAAAAAAAAAAAca;

	private int AAAAAAAAAAAAAAAAAAco;

	private int AAAAAAAAAAAAAAAAAAAbs;

	private int AAAAAAAAAAAAAAAAAAAAAcb;

	private int AAAAAAAAAAAAAAAbo;

	private int AAAAAAAAAAAAAAAAAAcp;

	public static int _posBottomX10;

	private float AAAAAAAAAAAAAAbv;

	private float AAAAAAAAAAAAAAAAAAAAAcc;

	public static float angleArrow;

	public static Vector2 touchPosF;

	public static Vector2 touchPosL;

	public static float vecSwipe;

	public static int _currentCharacterNumber = 0;

	public static int _curNumb = 0;

	public int _numberGroup;

	private int AAAAAAAAAAAAAAAAAAAbt;

	public static int _numberGroupOfCharInGuide;

	public static int _Range;

	public static int _TaskNum;

	public static int _NewTaskNum;

	public int _RateNum;

	public static float _TradeCost = 0f;

	public static float _CurProtectoinSuit = 0f;

	public static float _CurDamage = 0f;

	public static float _CurDamageForSuit = 0f;

	public static float _CurWeigh = 0f;

	public static int _CalcWeigh = 0;

	public static List<int> _CurrentCharUnit;

	public static List<int> _FigherGroup = new List<int>();

	public static List<int> _CurrentPoint;

	public GUIStyle _guiEquipment;

	public GUIStyle _guiIconGroup;

	public GUIStyle _StateCh;

	public GUIStyle _StateH;

	public GUIStyle _RedFont;

	public GUIStyle _ComentsFont;

	public GUIStyle _ComentsFontYellow;

	public static GameObject InstantMessage;

	public static GameObject EjectGameObject;

	public static GameObject _CurtainIconCharacterU;

	public static GameObject _CurtainGUIEquipment;

	public static GameObject _CurtainInventory;

	public static GameObject _CurtainState;

	public static GameObject _CurtainUnitChar;

	public static GameObject _Fire;

	public static Vector3 _camPos;

	public static string _heroInTask;

	public static bool _Equipment;

	public static bool _StateGG;

	public static bool _PointInformation;

	public static bool _GG_Char;

	public static bool _invSubj;

	public static bool _PointInf;

	public static bool _Cache;

	public static bool _Exchange;

	public static bool _JoinBool;

	public static bool _DeathCharWeapon;

	public static bool _GGActive;

	public static bool _StateCharacter;

	public static bool _fireButton;

	public static bool _diplomacy;

	public static bool _taskText;

	public static bool _taskReward;

	public static bool _NoneReward;

	public static bool _choiceFighter;

	public static bool _NoneIntertnet;

	public static bool _NoneDevice;

	public static bool _hasKey;

	public static bool _HungerBool;

	public static bool _ThirstIconBool;

	public static bool _LimitAdv;

	public static bool _HelpBool;

	public static bool _HelpField;

	public static bool _HelpField1;

	public static bool _RateGame;

	public static bool _repeirs;

	public static bool _capture;

	public static bool _hire;

	public static bool _improveAttitude;

	public static bool showAdv;

	public static AAAAAAAAAAAAAAAAAAk _currentSubject;

	public static AAAAAAAAAAAAAAAAAAk _QuestSubject;

	public static AAAAAAAAAAAAAAAAAAk _RewardAdvertisingSubject;

	public static AAAAAAAAAAAAAAAAAAk _RewardSubject;

	public static ConstructorTasks _currentTask;

	public static ConstructorTasks _EmptyTask;

	private Texture2D AAAAAAAAAAAAAAbw;

	public static Texture2D _Stay;

	public static Texture2D _Run;

	public static Texture2D _Overload;

	public static Texture2D _OverloadMove;

	public static Texture2D _FireTurI;

	public static Texture2D _CurIcon;

	public static Texture2D _CharInf;

	public static Texture2D _CurCharIcon;

	public static Texture2D _CurCharGreen;

	public static Texture2D PDAbutton;

	private Texture2D AAAAAAAAAAAAAAAAAbt;

	private Texture2D AAAAAAAAAAAAAAbx;

	private Texture2D AAAAAAAAAAAAAAAAAAcq;

	private Texture2D AAAAAAAAAAAAAAAAAAcr;

	private Texture2D AAAAAAAAAAAAAAAAAAAAcd;

	public static Texture2D _curInventory;

	public static Texture2D _CompleteMove;

	public static Texture2D _bleeding;

	public static Texture2D _xRayDisease;

	public static Texture2D _cartridges;

	private Texture2D AAAAAAAAAAAAAAAAAAAbu;

	private Texture2D AAAAAAAAAAAAAAAAAAAbv;

	private Texture2D AAAAAAAAAAAAAAAAbr;

	private Texture2D AAAAAAAAAAAAAAAAAAcs;

	private Texture2D AAAAAAAAAAAAAAAAAAAAAcd;

	public Texture2D _exit;

	public Texture2D _exitBrown;

	public Texture2D _queue;

	public Texture2D _up;

	public Texture2D _down;

	public Texture2D _diplomacyIcon;

	public Texture2D _BGdiplomacy;

	public Texture2D _Task;

	public Texture2D _Stock;

	public Texture2D _TaskBrown;

	public Texture2D _TableSellNone;

	public Texture2D _TableSellRed;

	public Texture2D _TableSellGreen;

	public Texture2D _TableSellYellow;

	public static Texture2D _Slot;

	public static Texture2D _Ok;

	public static Texture2D _DirectGroup;

	public static Texture2D _Present;

	public static Texture2D _HungerIcon;

	public static Texture2D _ThirstIcon;

	public static Texture2D _HelpButton;

	public static Texture2D _HelpOff;

	public static Texture2D _HungerYellow;

	public static Texture2D _UsingButton;

	public static Texture2D _Cash128;

	public static Texture2D _repairs96;

	public static Texture2D _capture96;

	public static Texture2D _join;

	public static Texture2D _Change0;

	public static Texture2D _cache;

	public static Texture2D _hire96;

	public static AudioSource AudioGame;

	public static AudioSource SoundMenu;

	public static AudioSource SoundBG;

	public static AudioSource SoundEffect;

	public static AudioClip effectBip;

	public static AudioClip effectBeep;

	public static AudioClip effectOpen;

	public static AudioClip effectClose;

	public static AudioClip effectPaw;

	public static AudioClip effectNews;

	public static AudioClip effectObjective;

	public static AudioClip effectRadioOff;

	public static AudioClip effectEmpty;

	public static Texture2D _textureDethChar;

	public static Sprite _spriteDethChar;

	private static Texture2D[] AAAAAAAAAAAAAAAAAbu = new Texture2D[13];

	private static int AAAAAAAAAAAAAAAbp = 0;

	public static GameObject TaskPanelGO;

	public static GameObject CurTaskIcon;

	public int AutoSavePeriod
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAAcb;
		}
		set
		{
			if (value <= 8)
			{
				AAAAAAAAAAAAAAAAAAAAcb = value;
			}
			if (value > 8)
			{
				AAAAAAAAAAAAAAAAAAAAcb = 0;
			}
		}
	}

	public static int ArtRespawnTime
	{
		get
		{
			return AAAAAAAAAAAAAAAbp;
		}
		set
		{
			if (value < 200)
			{
				AAAAAAAAAAAAAAAbp = value;
			}
			if (value == 200)
			{
				AAAAAAAAAAAAAAAbp = 0;
			}
		}
	}

	public float QueueInt
	{
		get
		{
			return AAAAAAAAAAAAAAbv;
		}
		set
		{
			if (value >= 0f)
			{
				AAAAAAAAAAAAAAbv = 0f;
			}
			if (value < 0f && value > (float)(-Screen.width) * 1.8f)
			{
				AAAAAAAAAAAAAAbv = value;
			}
			if (value <= (float)(-Screen.width) * 1.8f)
			{
				AAAAAAAAAAAAAAbv = (float)(-Screen.width) * 1.8f;
			}
		}
	}

	public void AAAAAAAAAAAAAAAAAbv()
	{
		StartCoroutine(AAAAAAAAAAAAAAAAAAAAce());
	}

	public static IEnumerator AAAAAAAAAAAAAAAAAAAAce()
	{
		if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Cartridge == 0 && CharacterMotion._PointsMove > 0)
		{
			AAAAAAAAAAAAAAAAbx();
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Cartridge <= 0 || CharacterMotion._PointsMove <= 0 || Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == Data.CharacterD[_currentCharacterNumber].TypeChInt || !Data.CharacterD[CharacterMotion._curCharacter].ControlGamer)
		{
			yield break;
		}
		CharacterMotion._PointsMove--;
		if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Cartridge <= 0)
		{
			yield break;
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].ControlGamer)
		{
			II._EnemyTarget = Data.CharacterD[_currentCharacterNumber];
		}
		_Fire.GetComponent<LineRenderer>().SetPosition(0, Data.CharacterD[CharacterMotion._curCharacter].CharUnits.transform.position);
		_Fire.GetComponent<LineRenderer>().SetPosition(1, GameObject.Find(II._EnemyTarget.CharUnits.name).transform.position);
		Data.CharacterD[_currentCharacterNumber].Alarm = true;
		Data.CharacterD[_currentCharacterNumber].Aggressor = Data.CharacterD[CharacterMotion._curCharacter].NameU;
		_CurProtectoinSuit = Data.CharacterD[_currentCharacterNumber].SuitChar.Protection + Data.CharacterD[_currentCharacterNumber].ArtContainers[0].Protection + Data.CharacterD[_currentCharacterNumber].ArtContainers[1].Protection + Data.CharacterD[_currentCharacterNumber].ArtContainers[2].Protection + Data.CharacterD[_currentCharacterNumber].ArtContainers[3].Protection;
		_CurProtectoinSuit += Data.CharacterD[_currentCharacterNumber].SuitChar.UpGrade;
		_CurProtectoinSuit += Data.CharacterD[_currentCharacterNumber].SuitChar.UpGrade;
		_CurProtectoinSuit = _CurProtectoinSuit / 1000f * Data.CharacterD[_currentCharacterNumber].SuitChar.State;
		_CurDamage = Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Damage / 100f * Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.State;
		_CurDamage -= _CurProtectoinSuit;
		_CurDamage *= SaveLoad.Difficulty;
		_CurDamage += Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.UpGrade;
		if (_CurDamage < 1f)
		{
			_CurDamage = 1f;
		}
		Data.CharacterD[_currentCharacterNumber].CurHealth -= _CurDamage;
		Data.CharacterD[_currentCharacterNumber].Bleeding += Random.Range(0, 2);
		_CurDamageForSuit = _CurDamage / 10f;
		Data.CharacterD[_currentCharacterNumber].SuitChar.State -= _CurDamageForSuit;
		if (Data.CharacterD[_currentCharacterNumber].SuitChar.SingModification)
		{
			Data.CharacterD[_currentCharacterNumber].SuitChar.State -= _CurDamageForSuit;
		}
		if (Data.CharacterD[_currentCharacterNumber].SuitChar.State < 0f)
		{
			Data.CharacterD[_currentCharacterNumber].SuitChar.State = 0f;
		}
		Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.State -= Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Wear;
		if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.SingModification)
		{
			float num = Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Wear / 2f;
			Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.State -= num;
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.State < 0f)
		{
			Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.State = 0f;
		}
		Data.CharacterD[_currentCharacterNumber].CharUnits.transform.GetChild(0).transform.localPosition = new Vector3((Data.CharacterD[_currentCharacterNumber].CurHealth / 100f - 0.5f) / 2f, 0.5f);
		Data.CharacterD[_currentCharacterNumber].CharUnits.transform.GetChild(0).transform.localScale = new Vector3(Data.CharacterD[_currentCharacterNumber].CurHealth / 100f, 0.3f);
		if (Data.CharacterD[_currentCharacterNumber].CharUnits.name == "Следопыт")
		{
			Methods.AAAAAAAAAAAAAAcn();
		}
		if (Data.CharacterD[_currentCharacterNumber].CurHealth <= 0f)
		{
			Data.CharacterD[_currentCharacterNumber].CharUnits.GetComponent<AudioSource>().clip = Data.CharacterD[_currentCharacterNumber].AudioDeath;
			Data.CharacterD[_currentCharacterNumber].CharUnits.GetComponent<AudioSource>().Play();
			Data.CharacterD[_currentCharacterNumber].AudioDeath = (AudioClip)Resources.Load("Sound/pda/paw_earth1");
			Data.CharacterD[CharacterMotion._curCharacter].Skill++;
			GPSscript.AAAAAAAAAAAAAAAAAAAAAj("CgkI2OGbhtMLEAIQBg", Data.CharacterD[CharacterMotion._curCharacter].Skill);
			SaveLoad.Difficulty -= 0.0002f;
			Data.CharacterD[_currentCharacterNumber].Life = false;
			Data.CharacterD[_currentCharacterNumber].TextureChar = _textureDethChar;
			AAAAAAAAAAAAAAAAAAAAAce();
			AAAAAAAAAAAAAAAAAbx();
			Methods.AAAAAAAAAAAAAAcn();
			Methods.AAAAAAAAAAAAAAcm();
			Methods.AAAAAAAAAAAAAAAce();
			Data.CharacterD[_currentCharacterNumber].CharUnits.GetComponent<SpriteRenderer>().sprite = _spriteDethChar;
			Data.CharacterD[_currentCharacterNumber].CharUnits.GetComponent<SpriteRenderer>().sortingOrder = 5;
			if (Data.CharacterD[_currentCharacterNumber].TypeChInt == 9 || Data.CharacterD[_currentCharacterNumber].TypeChInt == 10)
			{
				Data.KillingMutants_Data++;
				if (Data.CharacterD[_currentCharacterNumber].TypeChar == AAAAAAAAAAAAAAAAf.TypeCharacter.Плоть || Data.CharacterD[_currentCharacterNumber].TypeChar == AAAAAAAAAAAAAAAAf.TypeCharacter.Кабан || Data.CharacterD[_currentCharacterNumber].TypeChar == AAAAAAAAAAAAAAAAf.TypeCharacter.Пес)
				{
					GPSscript.AAAAAAAAAAAAAAAAAi("CgkI2OGbhtMLEAIQAQ", 1);
				}
				if (Data.CharacterD[_currentCharacterNumber].TypeChar == AAAAAAAAAAAAAAAAf.TypeCharacter.Псевдособака || Data.CharacterD[_currentCharacterNumber].TypeChar == AAAAAAAAAAAAAAAAf.TypeCharacter.Снорк)
				{
					GPSscript.AAAAAAAAAAAAAAAAAi("CgkI2OGbhtMLEAIQAQ", 2);
				}
				if (Data.CharacterD[_currentCharacterNumber].TypeChar == AAAAAAAAAAAAAAAAf.TypeCharacter.Кровосос)
				{
					GPSscript.AAAAAAAAAAAAAAAAAi("CgkI2OGbhtMLEAIQAQ", 3);
				}
				if (Data.CharacterD[_currentCharacterNumber].TypeChar == AAAAAAAAAAAAAAAAf.TypeCharacter.Контролер)
				{
					GPSscript.AAAAAAAAAAAAAAAAAi("CgkI2OGbhtMLEAIQAQ", 4);
				}
			}
		}
		if (!Data.CharacterD[_currentCharacterNumber].Life)
		{
			AAAAAAAAAAAAAAAAAci.AAAAAAAAAAAAAAAAcf();
		}
		if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.CharacterD[CharacterMotion._curCharacter].TypeChInt, Data.CharacterD[_currentCharacterNumber].TypeChInt] != 0 && AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.CharacterD[_currentCharacterNumber].TypeChInt] > 0 && Data.CharacterD[CharacterMotion._curCharacter].TypeChInt != 0 && Data.CharacterD[_currentCharacterNumber].TypeChInt != 9 && Data.CharacterD[_currentCharacterNumber].TypeChInt != 10 && Data.CharacterD[_currentCharacterNumber].CharUnits.name != "Следопыт")
		{
			MessagePanel(Data.CharacterD[_currentCharacterNumber].CharUnits.name + ": ''Ты атакуешь наших бойцов! Сейчас ты под защитой своей группировки, но если ты ее покинешь, мои люди припомнят твои темные делишки!''");
		}
		if (Data.CharacterD[_currentCharacterNumber].CharUnits.name != "Следопыт")
		{
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.CharacterD[_currentCharacterNumber].TypeChInt] = 0;
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.CharacterD[_currentCharacterNumber].TypeChInt, 0] = 0;
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.AutomaticFire)
		{
			GameObject.Find(Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name).GetComponent<AudioSource>().clip = Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.AudioFire;
			GameObject.Find(Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name).GetComponent<AudioSource>().Play();
			yield return new WaitForSeconds(Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.RateOfFire / AAAAAAAAAAAAAAAAAAAAct.GameSpeed);
			GameObject.Find(Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name).GetComponent<AudioSource>().Play();
			yield return new WaitForSeconds(Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.RateOfFire / AAAAAAAAAAAAAAAAAAAAct.GameSpeed);
			GameObject.Find(Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name).GetComponent<AudioSource>().Play();
			yield return new WaitForSeconds(Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.RateOfFire / AAAAAAAAAAAAAAAAAAAAct.GameSpeed);
		}
		if (!Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.AutomaticFire)
		{
			GameObject.Find(Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name).GetComponent<AudioSource>().clip = Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.AudioFire;
			GameObject.Find(Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name).GetComponent<AudioSource>().Play();
			yield return new WaitForSeconds(0.3f / AAAAAAAAAAAAAAAAAAAAct.GameSpeed);
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.AutomaticFire)
		{
			Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Cartridge -= 3;
			if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Cartridge < 1)
			{
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Cartridge = 0;
			}
		}
		else
		{
			Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Cartridge--;
			if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Cartridge < 1)
			{
				Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Cartridge = 0;
			}
		}
		yield return new WaitForSeconds(0.4f);
		Data.CharacterD[_currentCharacterNumber].CurGexChar.GexGO.GetComponentInChildren<SpriteRenderer>().color = new Color(0f, 1f, 1f, 0.8f);
		_Fire.GetComponent<LineRenderer>().SetPosition(0, CharacterMotion._CameraCM.transform.position);
		_Fire.GetComponent<LineRenderer>().SetPosition(1, CharacterMotion._CameraCM.transform.position);
		yield return new WaitForSeconds(0.4f);
	}

	public void AAAAAAAAAAAAAAAAAAct()
	{
		if (CharacterMotion.PointInform != null)
		{
			CharacterMotion.PointInform.SetActive(false);
		}
		if (CharacterMotion._NextGex.Count > 0)
		{
			for (int i = 0; i < CharacterMotion._NextGex.Count; i++)
			{
				GameObject.Find(CharacterMotion._NextGex[i].NameGex).GetComponent<SpriteRenderer>().color = new Color(0.45f, 0.45f, 0.25f, 0f);
			}
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].CurGexChar == Data.CharacterD[_currentCharacterNumber].CurGexChar)
		{
			Data.CharacterD[_currentCharacterNumber].CurGexChar.GexGO.GetComponentInChildren<SpriteRenderer>().color = new Color(1f, 0f, 0f, 0.8f);
		}
		else
		{
			Data.CharacterD[_currentCharacterNumber].CurGexChar.GexGO.GetComponentInChildren<SpriteRenderer>().color = new Color(1f, 0f, 0f, 0.8f);
			Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.GetComponentInChildren<SpriteRenderer>().color = new Color(0f, 1f, 1f, 0.8f);
		}
		if (CharacterMotion._NextGex.Count > 0)
		{
			foreach (ConstructorGex item in CharacterMotion._NextGex)
			{
				GameObject gameObject = GameObject.Find(item.NameGex);
				if (gameObject.transform.childCount > 0)
				{
					if (gameObject.transform.childCount > 1)
					{
						Object.Destroy(gameObject.transform.GetChild(1).gameObject);
					}
					if (gameObject.transform.childCount > 0)
					{
						Object.Destroy(gameObject.transform.GetChild(0).gameObject);
					}
				}
			}
		}
		AAAAAAAAAAAAAAAAAbv();
	}

	public void AAAAAAAAAAAAAAAAAAcg()
	{
		AAAAAAAAAAAAAAAAAAAAcf();
		if (CharacterMotion.PointInform != null)
		{
			CharacterMotion.PointInform.SetActive(false);
		}
		if (CharacterMotion._NextGex.Count > 0)
		{
			foreach (ConstructorGex item in CharacterMotion._NextGex)
			{
				GameObject gameObject = GameObject.Find(item.NameGex);
				if (gameObject.transform.childCount > 0)
				{
					if (gameObject.transform.childCount > 1)
					{
						Object.Destroy(gameObject.transform.GetChild(1).gameObject);
					}
					if (gameObject.transform.childCount > 0)
					{
						Object.Destroy(gameObject.transform.GetChild(0).gameObject);
					}
				}
			}
		}
		Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.GetComponentInChildren<SpriteRenderer>().color = new Color(0.45f, 0.45f, 0.25f, 0f);
		Methods.AAAAAAAAAAAAAAAAAAAAAct();
		CharacterMotion._curCharacter++;
		if (!Data.CharacterD[0].Life)
		{
			CharacterMotion._curCharacter = 0;
		}
		if (CharacterMotion._curCharacter == Data.CharacterD.Count)
		{
			CharacterMotion._curCharacter = 0;
		}
		if (CharacterMotion._curCharacter == 0)
		{
			EjectTimeSc.Ejection--;
			if (EjectTimeSc.Ejection == 1)
			{
				AAAAAAAAAAAAAAAAAAAbz();
			}
			if (EjectTimeSc.Ejection == -2)
			{
				AAAAAAAAAAAAAAAAAby();
				AAAAAAAAAAAAAAAAbw();
			}
			if (EjectTimeSc.Ejection == 2)
			{
				AAAAAAAAAAAAAAAAAAcx();
			}
			if (EjectTimeSc.Ejection == 1)
			{
				CharacterMotion.AAAAAAAAAAAAAAAAAAAAi();
				if (_CurrentPoint.Count > 0)
				{
					MessagePanel("Во время выброса лучше не покидать укрытие. Чтобы дождаться окончания выброса завершите ход.");
					AAAAAAAAAAAAAAAAAAAca();
				}
			}
			if (EjectTimeSc.Ejection == -1)
			{
				AAAAAAAAAAAAAAAAAAAca();
			}
		}
		bool flag = false;
		if (!Data.CharacterD[CharacterMotion._curCharacter].ControlGamer)
		{
			if (EjectTimeSc.Ejection > 3 && !Data.CharacterD[CharacterMotion._curCharacter].Alarm && Data.CharacterD[CharacterMotion._curCharacter].Life)
			{
				float num = 1200f;
				foreach (AAAAAAAAAAAAAAAAf item2 in Data.CharacterD)
				{
					if (item2.ControlGamer)
					{
						float num2 = Vector3.Distance(Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.transform.position, item2.CurGexChar.GexGO.transform.position);
						if (num2 < num)
						{
							num = num2;
						}
					}
				}
				if (num > 13f)
				{
					flag = true;
				}
			}
			if (!Data.CharacterD[CharacterMotion._curCharacter].Life)
			{
				if (Data.CharacterD[CharacterMotion._curCharacter].AgeOfDeath < 6)
				{
					Data.CharacterD[CharacterMotion._curCharacter].AgeOfDeath++;
				}
				if (Data.CharacterD[CharacterMotion._curCharacter].AgeOfDeath >= 6)
				{
					ChangeCaracter.typeDeathChar = Data.CharacterD[CharacterMotion._curCharacter].TypeChar;
					Object.Destroy(GameObject.Find(Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name));
					ChangeCaracter.AAAAAAAAAAAAAAAAAAAu();
					flag = true;
				}
				else
				{
					flag = true;
				}
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name == "Следопыт")
			{
				flag = true;
			}
		}
		Bonus.AAAAAAAAAAAAAAAAAAdh();
		AAAAAAAAAAAAAAAAbs();
		if (Data.CharacterD[CharacterMotion._curCharacter].ControlGamer || (!Data.CharacterD[CharacterMotion._curCharacter].ControlGamer && Data.CharacterD[CharacterMotion._curCharacter].Life && !flag))
		{
			AAAAAAAAAAAAAAAAAAcu();
		}
		else
		{
			StartCoroutine(GameObject.Find("Data").GetComponent<CoroutinsAll>().AAAAAAAAAAAAAAAAAAcg());
		}
	}

	public void AAAAAAAAAAAAAAby()
	{
		if (CharacterMotion._NextGex.Count > 0)
		{
			foreach (ConstructorGex item in CharacterMotion._NextGex)
			{
				GameObject gameObject = GameObject.Find(item.NameGex);
				if (gameObject.transform.childCount > 0)
				{
					Object.Destroy(gameObject.transform.GetChild(0).gameObject);
				}
			}
		}
		GameObject.Find(Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.NameGex).GetComponentInChildren<SpriteRenderer>().color = new Color(0.45f, 0.45f, 0.25f, 0f);
		Methods.AAAAAAAAAAAAAAAAAAAAAct();
		Bonus.AAAAAAAAAAAAAAAAAAdh();
		AAAAAAAAAAAAAAAAbs();
		StopAllCoroutines();
		AAAAAAAAAAAAAAAAAAcu();
	}

	public void AAAAAAAAAAAAAAAAAAcu()
	{
		_GGActive = false;
		AAAAAAAAAAAAAAAAAAAAch();
		AAAAAAAAAAAAAAAAAbw();
		CharacterMotion._PointsMove = _CalcWeigh;
		if (Data.CharacterD[CharacterMotion._curCharacter].ControlGamer && Data.CharacterD[CharacterMotion._curCharacter].Life)
		{
			AutoSavePeriod++;
			if (AutoSavePeriod == 7)
			{
				SaveLoad.AAAAAAAAAAAAAAAAAAde("AutoSave", false);
				Debug.Log("SaveLoad.SaveInJSON(''AutoSave'')");
			}
		}
		foreach (ConstructorPoints point in Data.Points)
		{
			if (point.curGexPoint == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar && point.XRay > 0)
			{
				int num = 0;
				num += point.XRay;
				num -= Data.CharacterD[CharacterMotion._curCharacter].SuitChar.XRayProtection;
				if (num < 0)
				{
					num = 0;
				}
				Data.CharacterD[CharacterMotion._curCharacter].DiseaseXRay += num;
				break;
			}
		}
		_HungerBool = false;
		if (Data.CharacterD[CharacterMotion._curCharacter].ControlGamer)
		{
			Data.CharacterD[CharacterMotion._curCharacter].Satiety--;
			Data.CharacterD[CharacterMotion._curCharacter].Thirst -= Random.Range(0, 2);
			Data.CharacterD[CharacterMotion._curCharacter].PSIprotection--;
			if (Data.CharacterD[CharacterMotion._curCharacter].Satiety >= 30)
			{
				_HungerBool = false;
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Thirst >= 30)
			{
				_ThirstIconBool = false;
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Satiety < 30 && Data.CharacterD[CharacterMotion._curCharacter].Satiety >= 20)
			{
				_HungerBool = true;
				_HungerIcon = (Texture2D)Resources.Load("Sprites/IconGUI/HungerGreen64");
				MessagePanel("Персонаж испытывает голод");
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Thirst < 30 && Data.CharacterD[CharacterMotion._curCharacter].Thirst >= 20)
			{
				_ThirstIconBool = true;
				_ThirstIcon = (Texture2D)Resources.Load("Sprites/IconGUI/ThirstG64");
				MessagePanel("Персонаж испытывает жажду");
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Satiety < 20 && Data.CharacterD[CharacterMotion._curCharacter].Satiety >= 10)
			{
				Data.CharacterD[CharacterMotion._curCharacter].CurHealth--;
				if (CharacterMotion._PointsMove > 2)
				{
					CharacterMotion._PointsMove--;
				}
				_HungerBool = true;
				_HungerIcon = (Texture2D)Resources.Load("Sprites/IconGUI/HungerYellow64");
				MessagePanel("Персонаж испытывает голод");
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Thirst < 20 && Data.CharacterD[CharacterMotion._curCharacter].Thirst >= 10)
			{
				Data.CharacterD[CharacterMotion._curCharacter].CurHealth--;
				if (CharacterMotion._PointsMove > 2)
				{
					CharacterMotion._PointsMove--;
				}
				_ThirstIconBool = true;
				_ThirstIcon = (Texture2D)Resources.Load("Sprites/IconGUI/ThirstY64");
				MessagePanel("Персонаж испытывает жажду");
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Satiety < 10)
			{
				Data.CharacterD[CharacterMotion._curCharacter].CurHealth -= 2f;
				if (CharacterMotion._PointsMove > 2)
				{
					CharacterMotion._PointsMove = 2;
				}
				_HungerBool = true;
				_HungerIcon = (Texture2D)Resources.Load("Sprites/IconGUI/HungerRed64");
				MessagePanel("Персонаж испытывает голод");
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Thirst < 10)
			{
				Data.CharacterD[CharacterMotion._curCharacter].CurHealth -= 2f;
				if (CharacterMotion._PointsMove > 2)
				{
					CharacterMotion._PointsMove = 2;
				}
				_ThirstIconBool = true;
				_ThirstIcon = (Texture2D)Resources.Load("Sprites/IconGUI/ThirstR64");
				MessagePanel("Персонаж испытывает жажду");
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Satiety <= 0)
			{
				Data.CharacterD[CharacterMotion._curCharacter].CurHealth = 0f;
				_HungerBool = true;
				_HungerIcon = (Texture2D)Resources.Load("Sprites/IconGUI/HungerRed64");
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Thirst <= 0)
			{
				Data.CharacterD[CharacterMotion._curCharacter].CurHealth = 0f;
				_ThirstIconBool = true;
				_ThirstIcon = (Texture2D)Resources.Load("Sprites/IconGUI/ThirstR64");
			}
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].TypeChar == AAAAAAAAAAAAAAAAf.TypeCharacter.Кровосос && Data.CharacterD[CharacterMotion._curCharacter].Life)
		{
			Data.CharacterD[CharacterMotion._curCharacter].CurHealth += 6f;
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].Life)
		{
			int num2 = 0;
			num2 -= Data.CharacterD[CharacterMotion._curCharacter].SuitChar.XRayProtection;
			for (int i = 0; i < 4; i++)
			{
				if (Data.CharacterD[CharacterMotion._curCharacter].ControlGamer)
				{
					num2 += Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[i].XrayNegatife;
				}
				if (Data.CharacterD[CharacterMotion._curCharacter].SuitChar.ArtContainer <= i && Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[i].NameSubject != "None" && Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[i].NameSubject != string.Empty && Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[i].NameSubject != null)
				{
					num2 += 5;
				}
				Data.CharacterD[CharacterMotion._curCharacter].CurHealth += Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[i].Sanitation;
				Data.CharacterD[CharacterMotion._curCharacter].Bleeding += Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[i].Bleeding;
				num2 -= Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[i].XRayProtection;
			}
			if (num2 > 0)
			{
				Data.CharacterD[CharacterMotion._curCharacter].DiseaseXRay += num2;
			}
			for (int j = 0; j < 4; j++)
			{
				Data.CharacterD[CharacterMotion._curCharacter].DiseaseXRay -= Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[j].XRaySanitation;
			}
		}
		CharacterMotion._Turget.transform.position = Data.CharacterD[CharacterMotion._curCharacter].CharUnits.transform.position;
		for (int k = 0; k < II._IINextGex.Count; k++)
		{
			II._IINextGex[k].GexGO.GetComponentInChildren<SpriteRenderer>().color = new Color(0.45f, 0.45f, 0.25f, 0f);
		}
		Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.GetComponentInChildren<SpriteRenderer>().color = new Color(0f, 1f, 1f, 0.8f);
		if (CharacterMotion.EjectIsActive)
		{
			CharacterMotion.AAAAAAAAAAAAAAAAAAAAi();
			if (_CurrentPoint.Count == 0)
			{
				int num3 = 40;
				num3 -= Data.CharacterD[CharacterMotion._curCharacter].PritectionEjectEffect;
				num3 -= Data.CharacterD[CharacterMotion._curCharacter].SuitChar.ProtectionFromEject;
				Data.CharacterD[CharacterMotion._curCharacter].DiseaseXRay++;
				Data.CharacterD[CharacterMotion._curCharacter].Bleeding++;
				if (num3 > 0)
				{
					Data.CharacterD[CharacterMotion._curCharacter].CurHealth -= num3;
				}
			}
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].PritectionEjectEffect > 0)
		{
			Data.CharacterD[CharacterMotion._curCharacter].PritectionEjectEffect -= 7;
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].DiseaseXRay > 0)
		{
			Data.CharacterD[CharacterMotion._curCharacter].CurHealth -= Data.CharacterD[CharacterMotion._curCharacter].DiseaseXRay;
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].Bleeding > 0f)
		{
			Data.CharacterD[CharacterMotion._curCharacter].CurHealth -= Data.CharacterD[CharacterMotion._curCharacter].Bleeding;
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].SuitChar.Sanitation > 0f)
		{
			Data.CharacterD[CharacterMotion._curCharacter].CurHealth += Data.CharacterD[CharacterMotion._curCharacter].SuitChar.Sanitation;
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].Life && Data.CharacterD[CharacterMotion._curCharacter].CurHealth <= 0f)
		{
			Data.CharacterD[CharacterMotion._curCharacter].Life = false;
			Data.CharacterD[CharacterMotion._curCharacter].TextureChar = _textureDethChar;
			Data.CharacterD[CharacterMotion._curCharacter].CharUnits.GetComponent<SpriteRenderer>().sprite = _spriteDethChar;
			Data.CharacterD[CharacterMotion._curCharacter].CharUnits.GetComponent<SpriteRenderer>().sortingOrder = 5;
			CharacterMotion._PointsMove = 0;
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].CurHealth <= 0f)
		{
			Data.CharacterD[CharacterMotion._curCharacter].Life = false;
		}
		if (!Data.CharacterD[CharacterMotion._curCharacter].Life)
		{
			Data.CharacterD[CharacterMotion._curCharacter].CurHealth = 0f;
		}
		Data.CharacterD[CharacterMotion._curCharacter].CharUnits.transform.GetChild(0).transform.localPosition = new Vector3((Data.CharacterD[CharacterMotion._curCharacter].CurHealth / 100f - 0.5f) / 2f, 0.5f);
		Data.CharacterD[CharacterMotion._curCharacter].CharUnits.transform.GetChild(0).transform.localScale = new Vector3(Data.CharacterD[CharacterMotion._curCharacter].CurHealth / 100f, 0.3f);
		AAAAAAAAAAAAAAAAAAAAAce();
		CharacterMotion._TurGex = Data.CharacterD[CharacterMotion._curCharacter].CurGexChar;
		CharacterMotion._Turget.transform.position = Data.CharacterD[CharacterMotion._curCharacter].CharUnits.transform.position;
		foreach (ConstructorGex item in CharacterMotion._NextGex)
		{
			item.GexGO.GetComponent<SpriteRenderer>().color = new Color(0.45f, 0.45f, 0.25f, 0f);
		}
		CharacterMotion._NextGex.Clear();
		_CurrentCharUnit.Clear();
		_CurrentPoint.Clear();
		CharacterMotion._DistansMove = 0;
		for (int l = 0; l < Data.CharacterD.Count; l++)
		{
			if (Data.CharacterD[l].CurGexChar == CharacterMotion._TurGex)
			{
				_CurrentCharUnit.Add(l);
			}
		}
		for (int m = 0; m < Data.Points.Count; m++)
		{
			if (Data.Points[m].curGexPoint == CharacterMotion._TurGex)
			{
				_CurrentPoint.Add(m);
			}
		}
		if (_CurrentCharUnit.Count + _CurrentPoint.Count > 0 && _CurtainIconCharacterU.activeSelf)
		{
			_CurtainIconCharacterU.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, (_CurrentCharUnit.Count + _CurrentPoint.Count) * _posY8);
		}
		_Range = Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Range;
		if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.SightInstallation)
		{
			_Range++;
		}
		_currentCharacterNumber = CharacterMotion._curCharacter;
		for (int n = 0; n < _CurrentCharUnit.Count; n++)
		{
			if (_CurrentCharUnit[n] == _currentCharacterNumber)
			{
				_curNumb = n;
			}
		}
		if (_CurrentCharUnit.Count > 1)
		{
			if (CharacterMotion._DistansMove <= Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Range && CharacterMotion._DistansMove >= Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.MinRange)
			{
				_fireButton = true;
			}
			else
			{
				_fireButton = false;
			}
		}
		if (_currentCharacterNumber == CharacterMotion._curCharacter)
		{
			_fireButton = false;
		}
		if (!Data.CharacterD[CharacterMotion._curCharacter].Life)
		{
			Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO.GetComponentInChildren<SpriteRenderer>().color = new Color(0.45f, 0.45f, 0.25f, 0f);
			_currentCharacterNumber = CharacterMotion._curCharacter;
			_currentCharacterNumber = 0;
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].ControlGamer)
		{
			return;
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].Life)
		{
			bool flag = false;
			if (Data.CharacterD[CharacterMotion._curCharacter].CurGexChar == Data.CharacterD[CharacterMotion._curCharacter].TaskGexChar)
			{
				for (int num4 = 0; num4 < Data.Points.Count; num4++)
				{
					if (Data.Points[num4].ControlInt == Data.CharacterD[CharacterMotion._curCharacter].TypeChInt)
					{
						flag = true;
						if (Data.CharacterD[CharacterMotion._curCharacter].TaskGexChar == Data.Points[num4].curGexPoint)
						{
							Data.CharacterD[CharacterMotion._curCharacter].TaskGexChar = Gexa.GexLib[Random.Range(0, Gexa.GexLib.Count - 1)];
							AAAAAAAAAAAAAAAAAAAby();
							break;
						}
						if (Data.CharacterD[CharacterMotion._curCharacter].TaskGexChar != Data.Points[num4].curGexPoint)
						{
							Data.CharacterD[CharacterMotion._curCharacter].TaskGexChar = Data.Points[num4].curGexPoint;
							break;
						}
					}
				}
				if (!flag)
				{
					for (int num5 = 0; num5 < Data.Points.Count; num5++)
					{
						if (Data.Points[num5].curGexPoint == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar && Data.Points[num5].pointTypes != ConstructorPoints.PointTypes.Anomaly && (Data.Points[num5].ControlInt == 0 || AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.CharacterD[CharacterMotion._curCharacter].TypeChInt, Data.Points[num5].ControlInt] < 1))
						{
							AAAAAAAAAAAAAAAAAAAAcj();
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					List<ConstructorPoints> list = new List<ConstructorPoints>();
					for (int num6 = 0; num6 < Data.Points.Count; num6++)
					{
						if (Data.Points[num6].pointTypes != ConstructorPoints.PointTypes.Anomaly)
						{
							list.Add(Data.Points[num6]);
						}
					}
					if (list.Count > 0)
					{
						Data.CharacterD[CharacterMotion._curCharacter].TaskGexChar = list[Random.Range(0, list.Count - 1)].curGexPoint;
						Debug.Log(Data.CharacterD[CharacterMotion._curCharacter].NameU + " двигается для захвата базы");
					}
					else
					{
						Debug.Log(Data.CharacterD[CharacterMotion._curCharacter].NameU + " не находит свободных точек");
						Data.CharacterD[CharacterMotion._curCharacter].TaskGexChar = Gexa.GexLib[Random.Range(0, Gexa.GexLib.Count - 1)];
					}
				}
			}
		}
		AAAAAAAAAAAAAAAAAAAAcg();
	}

	public void AAAAAAAAAAAAAAAAAAAAcf()
	{
		StopAllCoroutines();
	}

	public void AAAAAAAAAAAAAAAAAAAAcg()
	{
		if (Data.CharacterD[CharacterMotion._curCharacter].Life && Data.CharacterD[CharacterMotion._curCharacter].TypeChInt != 9)
		{
			II.AAAAAAAAAAAAAAAAAAcn();
			II.AAAAAAAAAAAAAAAAAbp();
			II.AAAAAAAAAAAAAAAAAAAbq();
			II.AAAAAAAAAAAAAAAAAAAbr();
			if (Data.CharacterD[CharacterMotion._curCharacter].Bleeding > 0f && Data.CharacterD[CharacterMotion._curCharacter].CurHealth >= 1f)
			{
				II.AAAAAAAAAAAAAAAAAAcm();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].CurHealth <= 35f && Data.CharacterD[CharacterMotion._curCharacter].CurHealth >= 1f)
			{
				II.AAAAAAAAAAAAAAbu();
			}
		}
		StartCoroutine(II.AAAAAAAAAAAAAAbs());
	}

	private void Start()
	{
		_currentSubject = new AAAAAAAAAAAAAAAAAAbi();
		_QuestSubject = new AAAAAAAAAAAAAAAAAAbi();
		_RewardAdvertisingSubject = new AAAAAAAAAAAAAAAAAAbi();
		_RewardSubject = new AAAAAAAAAAAAAAAAAAbi();
		SoundEffect = GameObject.Find("Backgrownd").AddComponent<AudioSource>();
		AudioGame = GameObject.Find("Main Camera").GetComponent<AudioSource>();
		SoundMenu = GameObject.Find("SoundEffect").GetComponent<AudioSource>();
		SoundBG = GameObject.Find("SoundBG").GetComponent<AudioSource>();
		AAAAAAAAAAAAAAAAAAcz.AAAAAAAAAAAAAAAAAcb();
		effectBip = (AudioClip)Resources.Load("Sound/pda/contact_1");
		effectBeep = (AudioClip)Resources.Load("Sound/pda/beep");
		effectOpen = (AudioClip)Resources.Load("Sound/Suit/inv_open");
		effectClose = (AudioClip)Resources.Load("Sound/Suit/inv_close");
		effectPaw = (AudioClip)Resources.Load("Sound/pda/paw_earth1");
		effectNews = (AudioClip)Resources.Load("Sound/pda/pda_news");
		effectObjective = (AudioClip)Resources.Load("Sound/pda/pda_objective");
		effectRadioOff = (AudioClip)Resources.Load("Sound/pda/contact_4");
		effectEmpty = (AudioClip)Resources.Load("Sound/weapons/generic_empty");
		AAAAAAAAAAAAAAAAAbr = Screen.height;
		_posY2 = Screen.height / 2;
		_posX2 = Screen.width / 2;
		_posX2_3 = Screen.width / 3 * 2;
		_posX3 = Screen.width / 3;
		_posY3 = Screen.height / 3;
		_posX4 = Screen.width / 4;
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
		_posY12 = Screen.height / 12;
		_posY16 = Screen.height / 16;
		_posY20 = Screen.height / 20;
		_posY32 = Screen.height / 32;
		_posX32 = Screen.width / 32;
		_posY64 = Screen.height / 64;
		AAAAAAAAAAAAAAAAAAAAcc = Screen.height / 96;
		AAAAAAAAAAAAAAAAbq = _posY8 * 3;
		AAAAAAAAAAAAAAAAAbs = Screen.height - _posY4;
		AAAAAAAAAAAAAAAAAAAAAca = Screen.height - _posY6;
		AAAAAAAAAAAAAAAAAAco = Screen.height - _posY8;
		AAAAAAAAAAAAAAAAAAAAAcb = Screen.width - _posY2;
		AAAAAAAAAAAAAAAbo = Screen.width - _posY4;
		AAAAAAAAAAAAAAAAAAAbs = Screen.width - _posY8;
		AAAAAAAAAAAAAAAAAAcp = Screen.height - _posX8;
		_posBottomX10 = Screen.height - _posX10;
		AAAAAAAAAAAAAAAAAAAAAcc = Screen.height - _posY5 - _posY6;
		if (SceneManager.GetActiveScene().name != "Menu")
		{
			_guiEquipment.fontSize = _posY16;
			_guiIconGroup.fontSize = _posY16 - _posY64;
			_StateCh.fontSize = _posY16 - _posY64;
			_StateCh.font = (Font)Resources.Load("NeoSt");
			_StateH.fontSize = Screen.height / 24;
			_StateH.font = (Font)Resources.Load("NeoSt");
			_RedFont.fontSize = _posY8 / 3 * 2;
			_ComentsFont.wordWrap = true;
			_ComentsFont.fontSize = Screen.height / 30;
			_ComentsFont.normal.textColor = new Color(0f, 1f, 1f, 1f);
			_ComentsFontYellow.fontSize = Screen.height / 30;
			_ComentsFontYellow.normal.textColor = new Color(0.85f, 0.72f, 0.48f, 0.95f);
		}
		_Equipment = true;
		_StateCharacter = true;
		_CurrentCharUnit = new List<int>();
		_CurrentPoint = new List<int>();
		_currentSubject = Data._NoneSubject;
		_CurtainIconCharacterU = GameObject.Find("CurtainIconGroup");
		_CurtainIconCharacterU.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _posY8);
		_CurtainIconCharacterU.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 0f);
		_CurtainGUIEquipment = GameObject.Find("CurtainGUIEquipment");
		_CurtainGUIEquipment.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _posY3);
		_CurtainGUIEquipment.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _posY5 + _posY6);
		_CurtainInventory = GameObject.Find("CurtainInventory");
		_CurtainInventory.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width);
		_CurtainInventory.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height);
		_CurtainState = GameObject.Find("CurtainState");
		_CurtainState.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _posY4);
		_CurtainState.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _posY2 + _posY8);
		AAAAAAAAAAAAAAbw = (Texture2D)Resources.Load("Sprites/IconGroup/Star");
		_Stay = (Texture2D)Resources.Load("Sprites/IconGUI/Stay2");
		_Run = (Texture2D)Resources.Load("Sprites/IconGUI/Go4");
		_Overload = (Texture2D)Resources.Load("Sprites/IconGUI/Overload");
		_OverloadMove = (Texture2D)Resources.Load("Sprites/IconGUI/OverloadMove");
		_FireTurI = (Texture2D)Resources.Load("Sprites/IconGUI/FireTur1");
		_CharInf = (Texture2D)Resources.Load("Sprites/IconGUI/CharInf64");
		_CurCharIcon = (Texture2D)Resources.Load("Sprites/IconGUI/CurCharBGBlue");
		_CurCharGreen = (Texture2D)Resources.Load("Sprites/IconGUI/CurCharBGGreen");
		PDAbutton = (Texture2D)Resources.Load("Sprites/IconGUI/pdaButton");
		AAAAAAAAAAAAAAAAAbt = (Texture2D)Resources.Load("Sprites/IconGUI/CurCharBGRed");
		AAAAAAAAAAAAAAAAAAAAcd = (Texture2D)Resources.Load("Sprites/IconGUI/CurCharBGY");
		_curInventory = (Texture2D)Resources.Load("Sprites/IconGUI/InvBut");
		_CompleteMove = (Texture2D)Resources.Load("Sprites/IconGUI/CompleteMove");
		_textureDethChar = (Texture2D)Resources.Load("Sprites/IconGroup/Dchar0");
		_bleeding = (Texture2D)Resources.Load("Sprites/IconGUI/blood");
		_xRayDisease = (Texture2D)Resources.Load("Sprites/IconGUI/xRay");
		_cartridges = (Texture2D)Resources.Load("Sprites/IconGUI/Cartridges");
		AAAAAAAAAAAAAAAAAAAbu = (Texture2D)Resources.Load("Sprites/IconGUI/Touls");
		AAAAAAAAAAAAAAAAAAAbv = (Texture2D)Resources.Load("Sprites/IconGUI/minus64");
		AAAAAAAAAAAAAAAAbr = (Texture2D)Resources.Load("Sprites/IconGUI/plus64");
		AAAAAAAAAAAAAAAAAAcs = (Texture2D)Resources.Load("Sprites/IconGUI/mute64");
		AAAAAAAAAAAAAAAAAAAAAcd = (Texture2D)Resources.Load("Sprites/IconGUI/muteOff64");
		_exit = (Texture2D)Resources.Load("Sprites/IconGUI/Exit64");
		_exitBrown = (Texture2D)Resources.Load("Sprites/IconGUI/Quit1");
		_queue = (Texture2D)Resources.Load("Sprites/IconGUI/queue00");
		_up = (Texture2D)Resources.Load("Sprites/IconGUI/Up64");
		_down = (Texture2D)Resources.Load("Sprites/IconGUI/Down64");
		_diplomacyIcon = (Texture2D)Resources.Load("Sprites/IconGUI/Diplomacy");
		_BGdiplomacy = (Texture2D)Resources.Load("Sprites/IconGUI/CurChar0");
		_Task = (Texture2D)Resources.Load("Sprites/IconGUI/Tasks0");
		_TaskBrown = (Texture2D)Resources.Load("Sprites/IconGUI/TaskBackGr");
		_Ok = (Texture2D)Resources.Load("Sprites/IconGUI/Use");
		_Stock = (Texture2D)Resources.Load("Sprites/IconGUI/Stock96");
		_DirectGroup = (Texture2D)Resources.Load("Sprites/IconGUI/Direct");
		AAAAAAAAAAAAAAAAAbu[0] = (Texture2D)Resources.Load("Sprites/IconGroup/GasMask64A");
		AAAAAAAAAAAAAAAAAbu[1] = (Texture2D)Resources.Load("Sprites/IconGroup/StalkerIcon64");
		AAAAAAAAAAAAAAAAAbu[2] = (Texture2D)Resources.Load("Sprites/IconGroup/Bandit64C");
		AAAAAAAAAAAAAAAAAbu[3] = (Texture2D)Resources.Load("Sprites/IconGroup/Army64");
		AAAAAAAAAAAAAAAAAbu[4] = (Texture2D)Resources.Load("Sprites/IconGroup/Dolg64");
		AAAAAAAAAAAAAAAAAbu[5] = (Texture2D)Resources.Load("Sprites/IconGroup/Mercenaries64");
		AAAAAAAAAAAAAAAAAbu[6] = (Texture2D)Resources.Load("Sprites/IconGroup/Freedom64new");
		AAAAAAAAAAAAAAAAAbu[7] = (Texture2D)Resources.Load("Sprites/IconGroup/ClearSky64A");
		AAAAAAAAAAAAAAAAAbu[8] = (Texture2D)Resources.Load("Sprites/IconGroup/Monolith64Var");
		AAAAAAAAAAAAAAAAAbu[9] = (Texture2D)Resources.Load("Sprites/IconGroup/PseudoDog64_00");
		AAAAAAAAAAAAAAAAAbu[10] = (Texture2D)Resources.Load("Sprites/IconGroup/Zomby64");
		AAAAAAAAAAAAAAAAAbu[11] = (Texture2D)Resources.Load("Sprites/IconGroup/Ecolog64");
		AAAAAAAAAAAAAAAAAbu[12] = (Texture2D)Resources.Load("Sprites/IconGroup/Renegade64");
		_spriteDethChar = Resources.Load<Sprite>("Sprites/IconGroup/Dchar0");
		_TableSellRed = (Texture2D)Resources.Load("Sprites/OtherSprite/RedI");
		_TableSellGreen = (Texture2D)Resources.Load("Sprites/OtherSprite/GreenI");
		_TableSellYellow = (Texture2D)Resources.Load("Sprites/OtherSprite/YellowI");
		_Slot = (Texture2D)Resources.Load("Sprites/OtherSprite/Slot128");
		_Present = (Texture2D)Resources.Load("Sprites/IconGUI/Present");
		_HelpButton = (Texture2D)Resources.Load("Sprites/IconGUI/Help64V");
		AAAAAAAAAAAAAAbx = (Texture2D)Resources.Load("Sprites/IconGUI/TurL");
		AAAAAAAAAAAAAAAAAAcq = (Texture2D)Resources.Load("Sprites/IconGUI/TurUp");
		AAAAAAAAAAAAAAAAAAcr = (Texture2D)Resources.Load("Sprites/IconGUI/TurDown");
		_HelpOff = (Texture2D)Resources.Load("Sprites/IconGUI/Help64Off");
		_HungerYellow = (Texture2D)Resources.Load("Sprites/IconGUI/HungerYellow64");
		_UsingButton = (Texture2D)Resources.Load("Sprites/IconGUI/Using");
		_Cash128 = (Texture2D)Resources.Load("Sprites/IconGUI/cash128");
		_repairs96 = (Texture2D)Resources.Load("Sprites/IconGUI/repairs96");
		_capture96 = (Texture2D)Resources.Load("Sprites/IconGUI/Capture96");
		_join = (Texture2D)Resources.Load("Sprites/IconGUI/Join96");
		_Change0 = (Texture2D)Resources.Load("Sprites/IconGUI/Change0");
		_cache = (Texture2D)Resources.Load("Sprites/IconGUI/Cache96");
		_hire96 = (Texture2D)Resources.Load("Sprites/IconGUI/hire96");
		_Fire = GameObject.Find("Fire");
		_CurtainIconCharacterU.SetActive(true);
		_CurtainState.SetActive(true);
		_CurtainInventory.SetActive(false);
		_Equipment = true;
		_CurtainGUIEquipment.SetActive(true);
		_CurtainIconCharacterU.SetActive(true);
		_CurtainState.SetActive(true);
		_CurtainInventory.SetActive(false);
		_QuestSubject = Data._NoneSubject;
		GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize = AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAcf;
		if (Data.CharacterD.Count > 0)
		{
			foreach (AAAAAAAAAAAAAAAAf item in Data.CharacterD)
			{
				if (!item.Life)
				{
					item.CharUnits.GetComponent<SpriteRenderer>().sprite = _spriteDethChar;
					item.CharUnits.GetComponent<SpriteRenderer>().sortingOrder = 5;
				}
			}
			if (Data.TaskAll.Count > 1)
			{
				_TaskNum = 0;
				foreach (ConstructorTasks item2 in Data.TaskAll)
				{
					if (item2.NameTask == "Найти Механика")
					{
						_TaskNum = 1;
						break;
					}
				}
			}
			if (Data.TaskAll.Count > 1 && Data.TaskAll[1].NameTask == "Старый скряга" && SceneManager.GetActiveScene().name == "Kordon")
			{
				_TaskNum = 0;
				_Equipment = false;
				_CurtainInventory.SetActive(true);
				_CurtainGUIEquipment.SetActive(false);
				_taskText = true;
				SoundMenu.clip = effectNews;
				SoundMenu.Play();
			}
			AAAAAAAAAAAAAAAAAAAbx();
			AAAAAAAAAAAAAAAAAAAAch();
			AAAAAAAAAAAAAAAAAbw();
			AAAAAAAAAAAAAAAAAAcw();
			string text = "nameQuestCharacter";
			foreach (ConstructorTasks item3 in Data.TaskAll)
			{
				if (item3.GuideQuest)
				{
					text = item3.KillCharacterName;
					break;
				}
			}
			for (int i = 1; i < Data.CharacterD.Count; i++)
			{
				if (Data.CharacterD[i].ControlGamer && Data.CharacterD[i].TypeChInt != Data.CharacterD[0].TypeChInt && Data.CharacterD[i].NameU != text)
				{
					Data.CharacterD[i].ControlGamer = false;
				}
			}
			for (int j = 0; j < Data.TaskAll.Count; j++)
			{
				if (Data.TaskAll[j].NameTask == "Проводник" && Data.CharacterD[Data.TaskAll[j].NumberTurgetInData].CharUnits.name == Data.TaskAll[j].KillCharacterName)
				{
					Data.CharacterD[Data.TaskAll[j].NumberTurgetInData].ControlGamer = true;
					break;
				}
			}
		}
		AAAAAAAAAAAAAAAAAbz();
		_RewardAdvertisingSubject = new AAAAAAAAAAAAAAAAAAbi();
		Methods.AAAAAAAAAAAAAAAcf();
		InstantMessage = Object.Instantiate(Resources.Load<GameObject>("Prefabs/InstantMessage/InstantMessage"));
		InstantMessage.name = "InstantMessage";
		InstantMessage.transform.SetParent(GameObject.Find("Canvas").transform);
		InstantMessage.transform.localPosition = new Vector3(0f, 0f);
		float num = Screen.width;
		num /= 1280f;
		InstantMessage.transform.localScale = new Vector3(num, num);
	}

	private void OnGUI()
	{
		if (Data.CharacterD.Count <= 0)
		{
			return;
		}
		if (_Equipment)
		{
			if (_CurrentPoint.Count > 0 && Data.Points[_CurrentPoint[0]].XRay > 0)
			{
				GUI.Label(new Rect(AAAAAAAAAAAAAAAbo, 0f, _posY8, _posY8), _xRayDisease, _guiIconGroup);
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].DiseaseXRay > 0 && GUI.Button(new Rect(_posY4, _posY8, _posY8, _posY8), _xRayDisease, _guiIconGroup))
			{
				II.AAAAAAAAAAAAAAAAAAAAAby();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Bleeding > 0f && GUI.Button(new Rect(_posY4, 0f, _posY8, _posY8), _bleeding, _guiIconGroup))
			{
				II.AAAAAAAAAAAAAAAAAAcm();
			}
			if (_HungerBool && GUI.Button(new Rect(_posY4, _posY4 + _posY8, _posY8, _posY8), _HungerIcon, _guiIconGroup))
			{
				MessagePanel("Персонаж испытывает голод");
			}
			if (_ThirstIconBool && GUI.Button(new Rect(_posY2, 0f, _posY8, _posY8), _ThirstIcon, _guiIconGroup))
			{
				MessagePanel("Персонаж испытывает жажду");
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].Life)
			{
				GUI.Label(new Rect(0f, AAAAAAAAAAAAAAAAAAAAAcc, _posY5, _posY5), Data.CharacterD[CharacterMotion._curCharacter].SuitChar.IconCharacter, _guiEquipment);
				GUI.Label(new Rect(_posY64, AAAAAAAAAAAAAAAAAAAAAcc, _posY32, _posY16), string.Empty + (int)Data.CharacterD[CharacterMotion._curCharacter].CurHealth, _StateH);
				GUI.Label(new Rect(_posY6, AAAAAAAAAAAAAAAAAAAAAcc + (float)_posY7, _posY32, _posY16), string.Empty + CharacterMotion._PointsMove, _StateCh);
			}
			else
			{
				GUI.Label(new Rect(0f, AAAAAAAAAAAAAAAAAAAAAcc, _posY5, _posY5), Data.CharacterD[CharacterMotion._curCharacter].SuitChar.IconCharacterDead, _guiEquipment);
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].SuitChar.SingModification)
			{
				GUI.Label(new Rect(0f, AAAAAAAAAAAAAAAAAAAAAcc + (float)_posY6, _posY32, _posY32), (Texture2D)Resources.Load("Sprites/Upgrade/UG"), _guiEquipment);
			}
			GUI.Label(new Rect(0f, Screen.height - _posY6, _posY3, _posY6), Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.TextureSubject, _guiEquipment);
			if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.SingModification)
			{
				GUI.Label(new Rect(0f, Screen.height - _posY32, _posY32, _posY32), (Texture2D)Resources.Load("Sprites/Upgrade/UG"), _guiEquipment);
			}
			GUI.Label(new Rect(_posY5, AAAAAAAAAAAAAAAAAAAAAcc, _posY3 - _posY5, _posY5), Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[0].TextureSubject, _guiEquipment);
			if (CharacterMotion._curCharacter == 0)
			{
				GUI.Label(new Rect(_posY8, AAAAAAAAAAAAAAAAAAAAAcc - (float)_posY32, _posY6, _posY8), PlayerPrefs.GetString("HeroName"), _StateH);
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].TypeChInt < 9)
			{
				GUI.Label(new Rect(_posY7 + _posY8, Screen.height - _posY16, _posY32, _posY16), string.Empty + Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Cartridge, _StateCh);
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Cartridge * 4 < Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.CartridgeInMagazineFull)
			{
				if (GUI.Button(new Rect(_posY4, AAAAAAAAAAAAAAAAAAcp, _posY8, _posY8), Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.CartridgesImage, _guiIconGroup))
				{
					AAAAAAAAAAAAAAAAbx();
					Object.Destroy(CharacterMotion.PointInform);
				}
			}
			else if (Data.CharacterD[CharacterMotion._curCharacter].DetectorChar != null && Data.CharacterD[CharacterMotion._curCharacter].DetectorChar.TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Detector)
			{
				GUI.Label(new Rect(_posY4, AAAAAAAAAAAAAAAAAAcp, _posY8, _posY8), Data.CharacterD[CharacterMotion._curCharacter].DetectorChar.TextureSubject, _guiIconGroup);
			}
			if (_CurrentCharUnit.Count > 0)
			{
				if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.CharacterD[CharacterMotion._curCharacter].TypeChInt, Data.CharacterD[_currentCharacterNumber].TypeChInt] >= 5)
				{
					GUI.Label(new Rect(AAAAAAAAAAAAAAAAAAAbs, _posY8 * _curNumb + _posY8 * _CurrentPoint.Count, _posY8, _posY8), _CurCharGreen, _guiIconGroup);
				}
				if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.CharacterD[CharacterMotion._curCharacter].TypeChInt, Data.CharacterD[_currentCharacterNumber].TypeChInt] == 0)
				{
					GUI.Label(new Rect(AAAAAAAAAAAAAAAAAAAbs, _posY8 * _curNumb + _posY8 * _CurrentPoint.Count, _posY8, _posY8), AAAAAAAAAAAAAAAAAbt, _guiIconGroup);
				}
				if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.CharacterD[CharacterMotion._curCharacter].TypeChInt, Data.CharacterD[_currentCharacterNumber].TypeChInt] >= 1 && AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.CharacterD[CharacterMotion._curCharacter].TypeChInt, Data.CharacterD[_currentCharacterNumber].TypeChInt] < 5)
				{
					GUI.Label(new Rect(AAAAAAAAAAAAAAAAAAAbs, _posY8 * _curNumb + _posY8 * _CurrentPoint.Count, _posY8, _posY8), AAAAAAAAAAAAAAAAAAAAcd, _guiIconGroup);
				}
			}
			for (int i = 0; i < _CurrentCharUnit.Count; i++)
			{
				if (_CurrentCharUnit[i] == CharacterMotion._curCharacter)
				{
					GUI.Label(new Rect(AAAAAAAAAAAAAAAAAAAbs, _posY8 * i + _posY8 * _CurrentPoint.Count, _posY8, _posY8), _CurCharIcon, _guiIconGroup);
				}
				if (Data.CharacterD[_CurrentCharUnit[i]].Life)
				{
					if (GUI.Button(new Rect(AAAAAAAAAAAAAAAAAAAbs, _posY8 * i + _posY8 * _CurrentPoint.Count, _posY8, _posY8), Data.CharacterD[_CurrentCharUnit[i]].SuitChar.IconCharacter, _guiIconGroup))
					{
						AAAAAAAAAAAAAAAAAAAAAcf();
						if (CharacterMotion._DistansMove <= Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Range && CharacterMotion._DistansMove >= Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.MinRange)
						{
							_fireButton = true;
						}
						else
						{
							_fireButton = false;
						}
						_currentCharacterNumber = _CurrentCharUnit[i];
						_curNumb = i;
						if (_currentCharacterNumber == CharacterMotion._curCharacter && _CurrentCharUnit.Count == 1)
						{
							_currentCharacterNumber = _CurrentCharUnit[0];
							_curNumb = 0;
						}
					}
					GUI.Label(new Rect(AAAAAAAAAAAAAAAAAAAbs, _posY8 * i + _posY8 * _CurrentPoint.Count - AAAAAAAAAAAAAAAAAAAAcc, _posY32, _posY16), string.Empty + (int)Data.CharacterD[_CurrentCharUnit[i]].CurHealth, _StateH);
				}
				if (!Data.CharacterD[_CurrentCharUnit[i]].Life && GUI.Button(new Rect(AAAAAAAAAAAAAAAAAAAbs, _posY8 * i + _posY8 * _CurrentPoint.Count, _posY8, _posY8), Data.CharacterD[_CurrentCharUnit[i]].SuitChar.IconCharacterDead, _guiIconGroup))
				{
					AAAAAAAAAAAAAAAAAAAAAcf();
					if (CharacterMotion._DistansMove <= Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Range && CharacterMotion._DistansMove >= Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.MinRange)
					{
						_fireButton = true;
					}
					else
					{
						_fireButton = false;
					}
					_currentCharacterNumber = _CurrentCharUnit[i];
					_curNumb = i;
					if (_currentCharacterNumber == CharacterMotion._curCharacter && _CurrentCharUnit.Count == 1)
					{
						_currentCharacterNumber = _CurrentCharUnit[0];
						_curNumb = 0;
					}
				}
			}
			for (int j = 0; j < _CurrentPoint.Count; j++)
			{
				if (GUI.Button(new Rect(AAAAAAAAAAAAAAAAAAAbs, _posY8 * j, _posY8, _posY8), AAAAAAAAAAAAAAbw, _guiIconGroup))
				{
					if (CharacterMotion.PointInform != null)
					{
						CharacterMotion.PointInform.SetActive(false);
					}
					AAAAAAAAAAAAAAAAAAAAAcf();
					Methods.AAAAAAAAAAAAAAAAAAAAAcs();
					_Equipment = false;
					_PointInformation = true;
					_PointInf = true;
					_CurtainGUIEquipment.SetActive(false);
					_CurtainIconCharacterU.SetActive(false);
					_CurtainState.SetActive(false);
					_CurtainInventory.SetActive(true);
					_currentSubject = new AAAAAAAAAAAAAAAAAAbi();
					Methods.AAAAAAAAAAAAAAcn();
				}
			}
			if (_StateCharacter && Data.CharacterD[CharacterMotion._curCharacter].CurGexChar != CharacterMotion._TurGex && CharacterMotion._PointsMove > 0)
			{
				if (_GGActive)
				{
					_CurIcon = _Run;
				}
				else
				{
					_CurIcon = _Stay;
				}
				if (GUI.Button(new Rect(0f, _posY2, _posY8, _posY8), _CurIcon, _guiIconGroup))
				{
					_currentCharacterNumber = CharacterMotion._curCharacter;
					for (int k = 0; k < _CurrentCharUnit.Count; k++)
					{
						if (_CurrentCharUnit[k] == _currentCharacterNumber)
						{
							_curNumb = k;
						}
					}
					for (int l = 0; l < CharacterMotion._NextGex.Count; l++)
					{
						CharacterMotion._NextGex[l].GexGO.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 1f, 0.8f);
					}
					for (int m = 0; m < CharacterMotion._NextGex.Count - 1 - CharacterMotion._PointsMove; m++)
					{
						CharacterMotion._NextGex[m].GexGO.GetComponent<SpriteRenderer>().color = new Color(0.65f, 0.65f, 0.5f, 0.8f);
					}
					if (CharacterMotion._DistansMove < CharacterMotion._PointsMove)
					{
						_StateCharacter = true;
					}
					else
					{
						_StateCharacter = false;
						if (CharacterMotion._Turget.GetComponentInChildren<SpriteRenderer>() != null)
						{
							CharacterMotion._Turget.GetComponentInChildren<SpriteRenderer>().color = new Color(0.65f, 0.65f, 0.5f, 0.8f);
						}
					}
					_GGActive = true;
					_CurrentCharUnit.Clear();
					_CurrentPoint.Clear();
					_CurtainIconCharacterU.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 0f);
				}
			}
			if (!_GGActive && _fireButton && CharacterMotion._PointsMove > 0 && Data.CharacterD[CharacterMotion._curCharacter].ControlGamer && Data.CharacterD[CharacterMotion._curCharacter].Life && _CurrentCharUnit.Count > 0 && Data.CharacterD[_CurrentCharUnit[_curNumb]].Life && Data.CharacterD[CharacterMotion._curCharacter].TypeChInt != Data.CharacterD[_CurrentCharUnit[_curNumb]].TypeChInt && GUI.Button(new Rect(0f, AAAAAAAAAAAAAAAAbq, _posY8, _posY8), Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.FireButton, _guiIconGroup) && Data.CharacterD[CharacterMotion._curCharacter].ControlGamer)
			{
				AAAAAAAAAAAAAAAAAAct();
			}
			if (!_GGActive && Data.CharacterD[CharacterMotion._curCharacter].ControlGamer)
			{
				if (Data.CharacterD[CharacterMotion._curCharacter].ControlGamer && GUI.Button(new Rect(0f, _posY8, _posY8, _posY8), PDAbutton, _guiIconGroup))
				{
					if (CharacterMotion.PointInform != null)
					{
						CharacterMotion.PointInform.SetActive(false);
					}
					AAAAAAAAAAAAAAAAAAAAAcf();
					AAAAAAAAAAAAAAAAby();
					_Equipment = false;
					_CurtainGUIEquipment.SetActive(false);
					_CurtainIconCharacterU.SetActive(false);
					_CurtainState.SetActive(false);
					_CurtainInventory.SetActive(true);
				}
				if (GUI.Button(new Rect(0f, 0f, _posY8, _posY8), _CompleteMove, _guiIconGroup))
				{
					AAAAAAAAAAAAAAAAAAAAAcf();
					AAAAAAAAAAAAAAAAAAcg();
				}
				if (GUI.Button(new Rect(0f, _posY4, _posY8, _posY8), _curInventory, _guiIconGroup))
				{
					if (CharacterMotion.PointInform != null)
					{
						CharacterMotion.PointInform.SetActive(false);
					}
					SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_close");
					SoundMenu.Play();
					_Equipment = false;
					_CurtainGUIEquipment.SetActive(false);
					_CurtainIconCharacterU.SetActive(false);
					_CurtainState.SetActive(false);
					_currentSubject = Data._NoneSubject;
					GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/NewEquipmentPanel"));
					gameObject.name = "NewEquipmentPanel";
					gameObject.transform.SetParent(GameObject.Find("Canvas").transform);
					SubjectAct.AAAAAAAAAAAAAAAAAAAbo();
				}
				if (!_GGActive && _CurrentCharUnit.Count > 1 && Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.NameGex == Data.CharacterD[_currentCharacterNumber].CurGexChar.NameGex && _currentCharacterNumber != CharacterMotion._curCharacter)
				{
					if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.CharacterD[CharacterMotion._curCharacter].TypeChInt, Data.CharacterD[_currentCharacterNumber].TypeChInt] != 0 || !Data.CharacterD[_currentCharacterNumber].Life)
					{
						if (GUI.Button(new Rect(_posY8, _posY4, _posY8, _posY8), _CharInf, _guiIconGroup))
						{
							if (CharacterMotion.PointInform != null)
							{
								CharacterMotion.PointInform.SetActive(false);
							}
							SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_close");
							SoundMenu.Play();
							_Equipment = false;
							_CurtainGUIEquipment.SetActive(false);
							_CurtainIconCharacterU.SetActive(false);
							_CurtainState.SetActive(false);
							_currentSubject = Data._NoneSubject;
							ContragentInstanse.AAAAAAAAAAAAAAAAAbo();
						}
					}
					else if (Data.CharacterD[CharacterMotion._curCharacter].CurGexChar == CharacterMotion._TurGex && _HelpBool)
					{
						GUI.Label(new Rect(_posY2, _posX10, AAAAAAAAAAAAAAAAAbr, _posX10), "Враждебные персонажи не торгуют", _ComentsFont);
					}
				}
			}
			if (_HelpBool && !Data.CharacterD[CharacterMotion._curCharacter].ControlGamer)
			{
				GUI.Label(new Rect(_posY2, AAAAAAAAAAAAAAAAAAco, Screen.height, _posY8), "Ожидание ...", _ComentsFont);
			}
			if (_HelpBool && Data.CharacterD[CharacterMotion._curCharacter].ControlGamer)
			{
				if (CharacterMotion._TurgetGexName == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.NameGex && CharacterMotion._PointsMove > 0)
				{
					if (_CurrentPoint.Count == 0)
					{
						GUI.Label(new Rect(AAAAAAAAAAAAAAAAAbr - _posY16, 0f, _posY2, _posY8), "Вы можете в любое время отключить и включить подсказки в настройках", _ComentsFont);
					}
					GUI.Label(new Rect(_posY2, AAAAAAAAAAAAAAAAAbs, Screen.height, _posY8), "Выберете направление движения, нажав на любую точку на карте", _ComentsFont);
					if (GUI.Button(new Rect(_posY8, 0f, _posY8, _posY8), _HelpButton, _guiIconGroup))
					{
						AAAAAAAAAAAAAAAAAAAAAcf();
						_HelpField = true;
						_Equipment = false;
						_CurtainGUIEquipment.SetActive(false);
						_CurtainIconCharacterU.SetActive(false);
						_CurtainState.SetActive(false);
						_CurtainInventory.SetActive(true);
					}
				}
				if (CharacterMotion._NextGex.Count > CharacterMotion._PointsMove + 1 && CharacterMotion._PointsMove > 0)
				{
					GUI.Label(new Rect(_posY2, AAAAAAAAAAAAAAAAAbs, Screen.height, _posY8), "Недостаточно очков хода, чтобы дойти в эту точку", _ComentsFont);
					if (GUI.Button(new Rect(_posY8, 0f, _posY8, _posY8), _HelpButton, _guiIconGroup))
					{
						AAAAAAAAAAAAAAAAAAAAAcf();
						_HelpField = true;
						_Equipment = false;
						_CurtainGUIEquipment.SetActive(false);
						_CurtainIconCharacterU.SetActive(false);
						_CurtainState.SetActive(false);
						_CurtainInventory.SetActive(true);
					}
				}
				if (CharacterMotion._TurgetGexName != Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.NameGex && CharacterMotion._PointsMove > 0 && CharacterMotion._NextGex.Count <= CharacterMotion._PointsMove + 1 && GUI.Button(new Rect(_posY8, _posY2, _posY8, _posY8), _HelpButton, _guiIconGroup))
				{
					AAAAAAAAAAAAAAAAAAAAAcf();
					_HelpField = true;
					_Equipment = false;
					_CurtainGUIEquipment.SetActive(false);
					_CurtainIconCharacterU.SetActive(false);
					_CurtainState.SetActive(false);
					_CurtainInventory.SetActive(true);
				}
				if (_CurrentPoint.Count > 0)
				{
					GUI.Label(new Rect(_posX2 + _posY8, 0f, _posX3, _posY8), "Нажмите на звезду, чтобы посмотреть информацию о точке", _ComentsFont);
				}
			}
			if (_RateGame)
			{
				if (GUI.Button(new Rect(_posX3, _posY4, _posX3, _posY16), string.Empty, _guiEquipment))
				{
					Application.OpenURL("https://play.google.com/store/apps/details?id=com.Sokol.ZoneMotion&hl=ru");
					_RateGame = false;
				}
				GUI.Label(new Rect(_posX3, _posY4, _posX3, _posY16), "Оценить игру", _ComentsFont);
			}
		}
		if (_HelpField)
		{
			GUI.Label(new Rect(0f, _posY8, _posY2, _posY8), "Настройки", _ComentsFont);
			GUI.Label(new Rect(_posY2 + _posY8, _posY8, _posY8, _posY8), AAAAAAAAAAAAAAAAAAAbu, _guiIconGroup);
			GUI.Label(new Rect(0f, _posY4, _posY2, _posY8), "Завершить ход", _ComentsFont);
			GUI.Label(new Rect(_posY2 + _posY8, _posY4, _posY8, _posY8), _CompleteMove, _guiIconGroup);
			GUI.Label(new Rect(0f, AAAAAAAAAAAAAAAAbq, _posY2, _posY8), "Персонажи на локации", _ComentsFont);
			GUI.Label(new Rect(_posY2 + _posY8, AAAAAAAAAAAAAAAAbq, _posY8, _posY8), _queue, _guiIconGroup);
			GUI.Label(new Rect(0f, _posY2, _posY2, _posY8), "Экипировка", _ComentsFont);
			GUI.Label(new Rect(_posY2 + _posY8, _posY2, _posY8, _posY8), _curInventory, _guiIconGroup);
			GUI.Label(new Rect(0f, _posY2 + _posY8, _posY2, _posY8), "Квесты", _ComentsFont);
			GUI.Label(new Rect(_posY2 + _posY8, _posY2 + _posY8, _posY8, _posY8), _Task, _guiIconGroup);
			GUI.Label(new Rect(0f, _posY2 + _posY4, _posY2, _posY8), "Перемещение в заданную точку", _ComentsFont);
			GUI.Label(new Rect(_posY2 + _posY8, _posY2 + _posY4, _posY8, _posY8), _Stay, _guiIconGroup);
			GUI.Label(new Rect(_posX2, _posY8, _posY2, _posY8), "Дипломатия", _ComentsFont);
			GUI.Label(new Rect(AAAAAAAAAAAAAAAbo, _posY8, _posY8, _posY8), _diplomacyIcon, _guiIconGroup);
			GUI.Label(new Rect(_posX2, _posY4, _posY2, _posY8), "Информация о персонажах в точке", _ComentsFont);
			GUI.Label(new Rect(AAAAAAAAAAAAAAAbo, _posY4, _posY8, _posY8), _CharInf, _guiIconGroup);
			GUI.Label(new Rect(_posX2, AAAAAAAAAAAAAAAAbq, _posY2, _posY8), "Атака (радиус выстрела и вид кнопки зависит от вида оружия)", _ComentsFont);
			GUI.Label(new Rect(AAAAAAAAAAAAAAAbo, AAAAAAAAAAAAAAAAbq, _posY8, _posY8), Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.FireButton, _guiIconGroup);
			GUI.Label(new Rect(_posX2, _posY2, _posY2, _posY8), "Включен режим подсказок", _ComentsFont);
			GUI.Label(new Rect(AAAAAAAAAAAAAAAbo, _posY2, _posY8, _posY8), _HelpButton, _guiIconGroup);
			GUI.Label(new Rect(_posX2, _posY2 + _posY4, _posY2, _posY8), "Ejection Time: " + EjectTimeSc.Ejection, _ComentsFont);
			if (GUI.Button(new Rect(AAAAAAAAAAAAAAAAAAAbs, AAAAAAAAAAAAAAAAAAco, _posY8, _posY8), _down, _guiIconGroup))
			{
				_HelpField = false;
				_HelpField1 = true;
			}
			if (GUI.Button(new Rect(0f, 0f, _posY8, _posY8), _exit, _guiIconGroup))
			{
				AAAAAAAAAAAAAAAAAAAAAcf();
				_HelpField = false;
				_Equipment = true;
				_CurtainGUIEquipment.SetActive(true);
				_CurtainIconCharacterU.SetActive(true);
				_CurtainState.SetActive(true);
				_CurtainInventory.SetActive(false);
			}
		}
		if (_HelpField1)
		{
			GUI.Label(new Rect(0f, _posY8, _posY2, _posY8), "Кровотечение", _ComentsFont);
			GUI.Label(new Rect(_posY2 + _posY8, _posY8, _posY8, _posY8), _bleeding, _guiIconGroup);
			GUI.Label(new Rect(0f, _posY4, _posY2, _posY8), "Радиация", _ComentsFont);
			GUI.Label(new Rect(_posY2 + _posY8, _posY4, _posY8, _posY8), _xRayDisease, _guiIconGroup);
			GUI.Label(new Rect(0f, AAAAAAAAAAAAAAAAbq, _posY2, _posY8), "Голод", _ComentsFont);
			GUI.Label(new Rect(_posY2 + _posY8, AAAAAAAAAAAAAAAAbq, _posY8, _posY8), _HungerYellow, _guiIconGroup);
			GUI.Label(new Rect(0f, _posY2, _posY2, _posY8), "Пустой магазин в оружии", _ComentsFont);
			GUI.Label(new Rect(_posY2 + _posY8, _posY2, _posY8, _posY8), _cartridges, _guiIconGroup);
			GUI.Label(new Rect(0f, _posY2 + _posY8, _posY2, _posY8), "Одна из ключевых точек", _ComentsFont);
			GUI.Label(new Rect(_posY2 + _posY8, _posY2 + _posY8, _posY8, _posY8), AAAAAAAAAAAAAAbw, _guiIconGroup);
			GUI.Label(new Rect(0f, _posY2 + _posY4, _posY2, _posY8), "Купить, продать, забрать, оставить, переместить в слот", _ComentsFont);
			GUI.Label(new Rect(_posY2 + _posY8, _posY2 + _posY4, _posY8, _posY8), _UsingButton, _guiIconGroup);
			if (Data.CharacterD[CharacterMotion._curCharacter].Life)
			{
				GUI.Label(new Rect(AAAAAAAAAAAAAAAAAbr, _posY3, _posY5, _posY5), Data.CharacterD[CharacterMotion._curCharacter].SuitChar.IconCharacter, _guiEquipment);
				GUI.Label(new Rect(AAAAAAAAAAAAAAAAAbr + _posY32, _posY3, _posY32, _posY16), string.Empty + (int)Data.CharacterD[CharacterMotion._curCharacter].CurHealth, _StateH);
				GUI.Label(new Rect(AAAAAAAAAAAAAAAAAbr + _posY7, _posY3 + _posY7, _posY32, _posY16), string.Empty + CharacterMotion._PointsMove, _StateCh);
			}
			else
			{
				GUI.Label(new Rect(AAAAAAAAAAAAAAAAAbr, _posY3, _posY5, _posY5), Data.CharacterD[CharacterMotion._curCharacter].SuitChar.IconCharacterDead, _guiEquipment);
			}
			GUI.Label(new Rect(AAAAAAAAAAAAAAAAAbr, _posY2 + _posY32, _posY3, _posY6), Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.TextureSubject, _guiEquipment);
			GUI.Label(new Rect(AAAAAAAAAAAAAAAAAbr + _posY5, _posY3, _posY3 - _posY5, _posY5), Data.CharacterD[CharacterMotion._curCharacter].ArtChar.TextureSubject, _guiEquipment);
			if (Data.CharacterD[CharacterMotion._curCharacter].TypeChInt < 9)
			{
				GUI.Label(new Rect(AAAAAAAAAAAAAAAAAbr + _posY7 + _posY8, _posY3 + _posY5 + _posY16, _posY32, _posY16), string.Empty + Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Cartridge, _StateCh);
			}
			GUI.Label(new Rect(_posX2, _posY8, _posY2, _posY8), "Здоровье, 50 - max", _ComentsFont);
			GUI.Label(new Rect(_posX2 + _posY64, _posY8 + _posY16, _posY4, _posY8), AAAAAAAAAAAAAAAAAAcr, _ComentsFont);
			GUI.Label(new Rect(_posX2 + _posX4, _posY4 + _posY16, _posY3, _posY8), "Очки хода, 6 - max, зависят от веса экипировки", _ComentsFont);
			GUI.Label(new Rect(_posX2 + _posX4, AAAAAAAAAAAAAAAAbq + _posY16, _posY4 + _posY64, _posY8), AAAAAAAAAAAAAAbx, _ComentsFont);
			GUI.Label(new Rect(_posX2, _posY2 + _posY4, _posY2, _posY8), "Кол-во патронов в магазине", _ComentsFont);
			GUI.Label(new Rect(AAAAAAAAAAAAAAAAAbr + _posY5, _posY2 + _posY8 + _posY16, _posY8, _posY8), AAAAAAAAAAAAAAAAAAcq, _ComentsFont);
			if (GUI.Button(new Rect(0f, 0f, _posY8, _posY8), _exit, _guiIconGroup))
			{
				AAAAAAAAAAAAAAAAAAAAAcf();
				_HelpField1 = false;
				_Equipment = true;
				_CurtainGUIEquipment.SetActive(true);
				_CurtainIconCharacterU.SetActive(true);
				_CurtainState.SetActive(true);
				_CurtainInventory.SetActive(false);
			}
		}
		if (_taskText)
		{
			GUI.Label(new Rect(0f, _posY4, _posY2, _posY2), Data.TaskAll[_TaskNum].ImageTask, _guiIconGroup);
			GUI.Label(new Rect(_posY2, 0f, AAAAAAAAAAAAAAAAAAAAAcb, Screen.height), Data.TaskAll[_TaskNum].TextTask, _guiIconGroup);
			GUI.Label(new Rect(AAAAAAAAAAAAAAAAAAAbs, AAAAAAAAAAAAAAAAAAco, _posY8, _posY8), _Ok, _guiIconGroup);
			if (GUI.Button(new Rect(0f, 0f, Screen.width, Screen.height), string.Empty, _guiIconGroup))
			{
				SoundMenu.clip = effectObjective;
				SoundMenu.Play();
				if (_TaskNum == 0 && Data.TaskAll[0].NameTask == "Найти Механика")
				{
					_TaskNum = 1;
				}
				else
				{
					_taskText = false;
					if (Data.TaskAll[_TaskNum].RewardSubject.NameSubject != "None" || Data.TaskAll[_TaskNum].RewardMoney != 0)
					{
						_taskReward = true;
						_RewardSubject = Data.TaskAll[_TaskNum].RewardSubject;
						_currentSubject = Data.TaskAll[_TaskNum].RewardSubject;
						Data.CharacterD[0].Cash += Data.TaskAll[_TaskNum].RewardMoney;
					}
					if (Data.TaskAll[_TaskNum].SubjectQuest)
					{
						_taskReward = true;
					}
					if (Data.TaskAll[_TaskNum].RewardSubject.NameSubject == "None" && Data.TaskAll[_TaskNum].RewardMoney == 0 && !Data.TaskAll[_TaskNum].SubjectQuest)
					{
						_CurtainInventory.SetActive(false);
						_CurtainGUIEquipment.SetActive(true);
						_CurtainIconCharacterU.SetActive(true);
						_CurtainState.SetActive(true);
						_Equipment = true;
					}
				}
				AAAAAAAAAAAAAAAAAAAbx();
			}
		}
		if (_taskReward && _taskReward)
		{
			AAAAAAAAAAAAAAAAAAAAch();
			AAAAAAAAAAAAAAAAAbw();
			if (CharacterMotion.PointInform != null)
			{
				CharacterMotion.PointInform.SetActive(false);
			}
			SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
			SoundMenu.Play();
			_CurtainGUIEquipment.SetActive(false);
			_CurtainIconCharacterU.SetActive(false);
			_CurtainState.SetActive(false);
			_currentSubject = new AAAAAAAAAAAAAAAAAAbi();
			ContragentInstanse.AAAAAAAAAAAAAAAbk();
			_PointInformation = false;
			_PointInf = false;
			_taskReward = false;
		}
		if (!_PointInformation)
		{
			return;
		}
		if (_NoneReward)
		{
			GUI.Label(new Rect(0f, 0f, _posY4, _posY4), AAAAAAAAAAAAAAAAAbu[Data.Points[_CurrentPoint[0]].ControlInt], _guiIconGroup);
			GUI.Label(new Rect(0f, _posY3, _posY2, _posY2), Data.Dealers[Data.Points[_CurrentPoint[0]].ControlInt].ImageChar, _guiIconGroup);
			GUI.Label(new Rect(0f, _posY4, Screen.width, _posY8), "Сейчас для тебя ничего нет.", _guiIconGroup);
			if (GUI.Button(new Rect(AAAAAAAAAAAAAAAAAAAbs, _posY64, _posY10, _posY10), _exitBrown, _guiIconGroup))
			{
				AAAAAAAAAAAAAAAAAAAAAcf();
				_NoneReward = false;
				_PointInf = true;
			}
		}
		if (_JoinBool)
		{
			if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.Points[_CurrentPoint[0]].ControlInt, CharacterMotion._curCharacter] > 2 && Data.Points[_CurrentPoint[0]].ControlInt != Data.CharacterD[CharacterMotion._curCharacter].TypeChInt)
			{
				if (Data.CharacterD[CharacterMotion._curCharacter].CurGexChar == Data.Points[_CurrentPoint[0]].curGexPoint)
				{
					GUI.Label(new Rect(0f, 0f, _posY4, _posY4), AAAAAAAAAAAAAAAAAbu[Data.Points[_CurrentPoint[0]].ControlInt], _guiIconGroup);
					GUI.Label(new Rect(_posY4, 0f, AAAAAAAAAAAAAAAbo, _posY8), Data.Dealers[Data.Points[_CurrentPoint[0]].ControlInt].NameGroup, _guiIconGroup);
					GUI.Label(new Rect(0f, _posY3, _posY2, _posY2), Data.Dealers[Data.Points[_CurrentPoint[0]].ControlInt].ImageChar, _guiIconGroup);
					GUI.Label(new Rect(0f, _posY4, Screen.width, _posY8), Data.Dealers[Data.Points[_CurrentPoint[0]].ControlInt].DescriptionGroup, _guiIconGroup);
					if (CharacterMotion._curCharacter != 0)
					{
						GUI.Label(new Rect(_posX8, _posY2, AAAAAAAAAAAAAAAAAbr, _posY4), "Вступить в группировку может только главный герой", _guiIconGroup);
					}
					if (Data.Points[_CurrentPoint[0]].ControlInt != Data.CharacterD[CharacterMotion._curCharacter].TypeChInt && CharacterMotion._curCharacter == 0)
					{
						string text = string.Empty;
						for (int n = 1; n < Data.CharacterD.Count; n++)
						{
							if (Data.CharacterD[n].ControlGamer)
							{
								text = text + Data.CharacterD[n].NameU + " ";
							}
						}
						if (text != string.Empty)
						{
							GUI.Label(new Rect(_posX3, _posY2, AAAAAAAAAAAAAAAAAbr, _posY4), "вы не можете вступать в группировки с подконтрольными персонажами: " + text, _guiEquipment);
						}
						else if (GUI.Button(new Rect(_posX2, _posY2, _posY2, _posY4), "Вступить в группировку: " + Data.Dealers[Data.Points[_CurrentPoint[0]].ControlInt].NameGroup, _guiEquipment))
						{
							AAAAAAAAAAAAAAAAbt();
						}
					}
				}
			}
			else if (Data.Points[_CurrentPoint[0]].ControlInt == Data.CharacterD[CharacterMotion._curCharacter].TypeChInt)
			{
				GUI.Label(new Rect(0f, _posY3, _posY2, _posY2), Data.Dealers[Data.Points[_CurrentPoint[0]].DealerInt].ImageChar, _guiIconGroup);
				GUI.Label(new Rect(_posY2, _posY3, AAAAAAAAAAAAAAAAAbr, _posY2), "Рад тебя видеть, брат! Раз уж ты к нам присоединился, то загляни к торговцу, выбери себе что-нибудь стоящее. Его предложение напрямую зависит от твоего рейтинга в группировке...", _guiIconGroup);
			}
			else
			{
				GUI.Label(new Rect(0f, _posY3, _posY2, _posY2), Data.Dealers[Data.Points[_CurrentPoint[0]].DealerInt].ImageChar, _guiIconGroup);
				GUI.Label(new Rect(_posY2, _posY3, AAAAAAAAAAAAAAAAAbr, _posY2), "Вступить в нашу группировку? ... Хм... Мы еще не можем тебе доверять. Выполняй задания, уничтожай наших врагов и приходи к нам снова!", _guiIconGroup);
			}
			if (GUI.Button(new Rect(AAAAAAAAAAAAAAAAAAAbs, _posY64, _posY10, _posY10), _exitBrown, _guiIconGroup))
			{
				AAAAAAAAAAAAAAAAAAAAAcf();
				_JoinBool = false;
				_PointInf = true;
			}
		}
		if (_choiceFighter)
		{
			GUI.Label(new Rect(0f, 0f, _posY4, _posY4), AAAAAAAAAAAAAAAAAbu[Data.Points[_CurrentPoint[0]].ControlInt], _guiIconGroup);
			GUI.Label(new Rect(_posY4, 0f, AAAAAAAAAAAAAAAbo, _posY4), "Твой авторитет в группирове вырос достаточно, чтобы руководить другими бойцами:", _guiIconGroup);
			if (_FigherGroup.Count < 1)
			{
				GUI.Label(new Rect(_posY4, _posY2, AAAAAAAAAAAAAAAbo, _posY4), "Поблизости пока нет бойцов твоей группировки.", _guiIconGroup);
			}
			GUI.Label(new Rect(0f, _posY3, _posY2, _posY2), Data.Dealers[Data.Points[_CurrentPoint[0]].ControlInt].ImageChar, _guiIconGroup);
			for (int num = 1; num < _FigherGroup.Count; num++)
			{
				if (GUI.Button(new Rect(_posY2 + _posY8, num * _posY8 + _posY4, AAAAAAAAAAAAAAAAAbr, _posY8), Data.CharacterD[_FigherGroup[num]].CharUnits.name, _guiEquipment) && Data.CharacterD[_FigherGroup[num]].CharUnits.name != "Следопыт")
				{
					Data.CharacterD[_FigherGroup[num]].ControlGamer = !Data.CharacterD[_FigherGroup[num]].ControlGamer;
				}
				if (Data.CharacterD[_FigherGroup[num]].ControlGamer)
				{
					GUI.Label(new Rect(_posY2, num * _posY8 + _posY4, _posY8, _posY8), _Ok, _guiEquipment);
				}
				if (!Data.CharacterD[_FigherGroup[num]].ControlGamer)
				{
					GUI.Label(new Rect(_posY2, num * _posY8 + _posY4, _posY8, _posY8), _exitBrown, _guiEquipment);
				}
			}
			if (GUI.Button(new Rect(AAAAAAAAAAAAAAAAAAAbs, _posY64, _posY10, _posY10), _exitBrown, _guiIconGroup))
			{
				AAAAAAAAAAAAAAAAAAAAAcf();
				_choiceFighter = false;
				_PointInf = true;
			}
		}
		if (_capture)
		{
			if (Data.CharacterD[CharacterMotion._curCharacter].CurGexChar == Data.Points[_CurrentPoint[0]].curGexPoint)
			{
				GUI.Label(new Rect(0f, 0f, _posX3, _posY8), Data.Points[_CurrentPoint[0]].namePoint, _guiIconGroup);
				GUI.Label(new Rect(0f, _posY8, _posX3, _posY8), "Контроль точки: " + Data.Points[_CurrentPoint[0]].pointControl, _guiIconGroup);
				GUI.Label(new Rect(0f, _posY4, _posY4, _posY4), AAAAAAAAAAAAAAAAAbu[Data.Points[_CurrentPoint[0]].ControlInt], _guiIconGroup);
				GUI.Label(new Rect(0f, _posY2, _posY2, _posY2), Data.Dealers[Data.Points[_CurrentPoint[0]].ControlInt].ImageChar, _guiIconGroup);
				if (Data.Points[_CurrentPoint[0]].ControlInt != Data.CharacterD[CharacterMotion._curCharacter].TypeChInt && GUI.Button(new Rect(_posX2, _posY2, _posY2, _posY4), "Захватить точку под контроль: " + Data.Dealers[Data.CharacterD[CharacterMotion._curCharacter].TypeChInt].NameGroup, _guiEquipment))
				{
					AAAAAAAAAAAAAAAAAAAAcj();
				}
			}
			if (GUI.Button(new Rect(AAAAAAAAAAAAAAAAAAAbs, _posY64, _posY10, _posY10), _exitBrown, _guiIconGroup))
			{
				AAAAAAAAAAAAAAAAAAAAAcf();
				_capture = false;
				_PointInf = true;
			}
		}
		if (_hire)
		{
			if (Data.CharacterD[CharacterMotion._curCharacter].CurGexChar == Data.Points[_CurrentPoint[0]].curGexPoint)
			{
				GUI.Label(new Rect(0f, 0f, _posX3, _posY8), Data.Points[_CurrentPoint[0]].namePoint, _guiIconGroup);
				GUI.Label(new Rect(0f, _posY8, _posX3, _posY8), "Пригласить на точку специалистов", _guiIconGroup);
				GUI.Label(new Rect(0f, _posY4, _posY4, _posY4), AAAAAAAAAAAAAAAAAbu[Data.Points[_CurrentPoint[0]].ControlInt], _guiIconGroup);
				GUI.Label(new Rect(0f, _posY2, _posY2, _posY2), Data.Dealers[Data.Points[_CurrentPoint[0]].ControlInt].ImageChar, _guiIconGroup);
				GUI.Label(new Rect(AAAAAAAAAAAAAAAbo - _posY32, _posY2 + _posY4, _posY16, _posY4), _Cash128, _ComentsFont);
				GUI.Label(new Rect(AAAAAAAAAAAAAAAbo, _posY2 + _posY4, _posY4, _posY4), string.Empty + Data.CharacterD[CharacterMotion._curCharacter].Cash, _ComentsFont);
				if (!Data.Points[_CurrentPoint[0]].Repair)
				{
					if (GUI.Button(new Rect(_posX2, _posY3 + _posY4, _posX2 - _posY8, _posY8), "Пригласить на точку техника. Оплата: 5000", _guiEquipment) && Data.CharacterD[CharacterMotion._curCharacter].Cash >= 5000)
					{
						Data.CharacterD[CharacterMotion._curCharacter].Cash -= 5000;
						Data.Points[_CurrentPoint[0]].Repair = true;
					}
				}
				else
				{
					GUI.Label(new Rect(_posX2, _posY3 + _posY4, _posX2 - _posY8, _posY8), "На точке уже имеется техник.", _guiEquipment);
				}
				if (!Data.Points[_CurrentPoint[0]].exchange)
				{
					if (GUI.Button(new Rect(_posX2, _posY3, _posX2 - _posY8, _posY8), "Пригласить на точку торговца. Оплата: 7000", _guiEquipment) && Data.CharacterD[CharacterMotion._curCharacter].Cash >= 7000)
					{
						Data.CharacterD[CharacterMotion._curCharacter].Cash -= 7000;
						Data.Points[_CurrentPoint[0]].exchange = true;
					}
				}
				else
				{
					GUI.Label(new Rect(_posX2, _posY3, _posX2 - _posY8, _posY8), "На точке уже имеется торговец.", _guiEquipment);
				}
			}
			if (GUI.Button(new Rect(AAAAAAAAAAAAAAAAAAAbs, _posY64, _posY10, _posY10), _exitBrown, _guiIconGroup))
			{
				AAAAAAAAAAAAAAAAAAAAAcf();
				_hire = false;
				_PointInf = true;
			}
		}
		if (_PointInf && _CurrentPoint.Count > 0)
		{
			if (Data.Points[_CurrentPoint[0]].ControlInt > 0 && Data.Points[_CurrentPoint[0]].ControlInt < 9 && GUI.Button(new Rect(AAAAAAAAAAAAAAAAAAAbs, _posY2 + _posY4 + _posY64, _posY10, _posY10), _Present, _guiIconGroup))
			{
				AAAAAAAAAAAAAAAAAAAAAcf();
				_PointInf = false;
				AAAAAAAAAAAAAAAAbv();
			}
			if (Data.Points[_CurrentPoint[0]].ControlInt == 11 && GUI.Button(new Rect(AAAAAAAAAAAAAAAAAAAbs, _posY2 + _posY4 + _posY64, _posY10, _posY10), _Present, _guiIconGroup))
			{
				AAAAAAAAAAAAAAAAAAAAAcf();
				_PointInf = false;
				AAAAAAAAAAAAAAAAbv();
			}
			if (CharacterMotion._curCharacter == 0 && Data.Points[_CurrentPoint[0]].ControlInt == Data.CharacterD[CharacterMotion._curCharacter].TypeChInt && Data.Points[_CurrentPoint[0]].ControlInt != 0 && GUI.Button(new Rect(AAAAAAAAAAAAAAAbo, _posY2 + _posY8 + _posY64, _posY10, _posY10), _DirectGroup, _guiIconGroup))
			{
				AAAAAAAAAAAAAAca();
				AAAAAAAAAAAAAAAAAAAAAcf();
				_PointInf = false;
				_choiceFighter = true;
			}
			int width = Screen.width;
			if (width < 1500)
			{
				GUI.Label(new Rect(0f, 0f, _posX2_3, _posY3 * 2), (Texture2D)Resources.Load("Sprites/IconGUI/ui_pda"), _guiIconGroup);
			}
			GUI.Label(new Rect(0f, 0f, _posX2_3, _posY8), Data.Points[_CurrentPoint[0]].namePoint + ". Контроль точки: " + Data.Points[_CurrentPoint[0]].pointControl, _guiIconGroup);
			GUI.Label(new Rect(_posY32, _posY8, _posX2_3 - _posY16, _posY2), Data.Points[_CurrentPoint[0]].DescriptionPoint, _guiIconGroup);
			if (Data.CharacterD[CharacterMotion._curCharacter].CurGexChar == Data.Points[_CurrentPoint[0]].curGexPoint)
			{
				if (Data.Points[_CurrentPoint[0]].pointTypes == ConstructorPoints.PointTypes.Anomaly)
				{
					if (Data.CharacterD[CharacterMotion._curCharacter].DetectorChar.NameSubject == "None")
					{
						GUI.Label(new Rect(_posX2_3, _posY4, _posY4, _posY4), "Аномалия. Для поиска артефактов необходим детектор.", _guiIconGroup);
					}
					else
					{
						GUI.Label(new Rect(_posX2_3, _posY4, _posY4, _posY4), "Детектор регистрирует аномальную активность. Здесь могут быть артефакты.", _guiIconGroup);
						if (GUI.Button(new Rect(AAAAAAAAAAAAAAAAAAAbs, _posY4 + _posY64, _posY10, _posY10), _cache, _guiIconGroup))
						{
							AAAAAAAAAAAAAAAAAAAAch();
							AAAAAAAAAAAAAAAAAbw();
							if (CharacterMotion.PointInform != null)
							{
								CharacterMotion.PointInform.SetActive(false);
							}
							SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
							SoundMenu.Play();
							_PointInf = false;
							CharacterMotion.CachePanel = true;
							_CurtainGUIEquipment.SetActive(false);
							_CurtainIconCharacterU.SetActive(false);
							_CurtainState.SetActive(false);
							_currentSubject = Data._NoneSubject;
							ContragentInstanse.AAAAAAAAAAAAAAAAAAAAby();
						}
					}
				}
				else
				{
					if (Data.Points[_CurrentPoint[0]].exchange || Data.Points[_CurrentPoint[0]].Repair)
					{
						GUI.Label(new Rect(_posX2_3, 0f, _posY4, _posY4), Data.Dealers[Data.Points[_CurrentPoint[0]].DealerInt].ImageChar, _guiIconGroup);
						GUI.Label(new Rect(_posX2_3, _posY4, _posY4, _posY4), Data.Dealers[Data.Points[_CurrentPoint[0]].DealerInt].TextChar, _guiIconGroup);
					}
					if (GUI.Button(new Rect(AAAAAAAAAAAAAAAAAAAbs, _posY4 + _posY64, _posY10, _posY10), _cache, _guiIconGroup))
					{
						AAAAAAAAAAAAAAAAAAAAch();
						AAAAAAAAAAAAAAAAAbw();
						if (CharacterMotion.PointInform != null)
						{
							CharacterMotion.PointInform.SetActive(false);
						}
						SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
						SoundMenu.Play();
						_PointInf = false;
						CharacterMotion.CachePanel = true;
						_CurtainGUIEquipment.SetActive(false);
						_CurtainIconCharacterU.SetActive(false);
						_CurtainState.SetActive(false);
						_currentSubject = Data._NoneSubject;
						ContragentInstanse.AAAAAAAAAAAAAAAAAAAAby();
					}
				}
			}
			if (GUI.Button(new Rect(AAAAAAAAAAAAAAAAAAAbs, _posY64, _posY10, _posY10), _exitBrown, _guiIconGroup))
			{
				SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
				SoundMenu.Play();
				_PointInformation = false;
				_PointInf = false;
				_Equipment = true;
				_CurtainGUIEquipment.SetActive(true);
				_CurtainIconCharacterU.SetActive(true);
				_CurtainState.SetActive(true);
				_CurtainInventory.SetActive(false);
				_currentSubject = Data._NoneSubject;
				Methods.AAAAAAAAAAAAAAAAAAAAAct();
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].CurGexChar == Data.Points[_CurrentPoint[0]].curGexPoint && Data.CharacterD[CharacterMotion._curCharacter].TypeChInt != 0 && AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAcd[Data.Points[_CurrentPoint[0]].ControlInt] <= 0 && Data.Points[_CurrentPoint[0]].DealerInt != Data.CharacterD[CharacterMotion._curCharacter].TypeChInt && Data.Points[_CurrentPoint[0]].pointTypes != ConstructorPoints.PointTypes.Anomaly && GUI.Button(new Rect(AAAAAAAAAAAAAAAbo, _posY64, _posY10, _posY10), _capture96, _guiIconGroup))
			{
				AAAAAAAAAAAAAAca();
				AAAAAAAAAAAAAAAAAAAAAcf();
				_PointInf = false;
				_capture = true;
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].TypeChInt != 0 && Data.CharacterD[CharacterMotion._curCharacter].CurGexChar == Data.Points[_CurrentPoint[0]].curGexPoint && Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == Data.Points[_CurrentPoint[0]].ControlInt && Data.Points[_CurrentPoint[0]].pointTypes != ConstructorPoints.PointTypes.Anomaly && GUI.Button(new Rect(AAAAAAAAAAAAAAAbo, _posY8 + _posY64, _posY10, _posY10), _hire96, _guiIconGroup))
			{
				AAAAAAAAAAAAAAca();
				AAAAAAAAAAAAAAAAAAAAAcf();
				_PointInf = false;
				_hire = true;
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].CurGexChar == Data.Points[_CurrentPoint[0]].curGexPoint)
			{
				if (Data.Points[_CurrentPoint[0]].Repair && GUI.Button(new Rect(AAAAAAAAAAAAAAAbo, _posY2 + _posY64, _posY10, _posY10), _repairs96, _guiIconGroup))
				{
					if (CharacterMotion.PointInform != null)
					{
						CharacterMotion.PointInform.SetActive(false);
					}
					SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_close");
					SoundMenu.Play();
					_Equipment = false;
					_PointInf = false;
					_CurtainGUIEquipment.SetActive(false);
					_CurtainIconCharacterU.SetActive(false);
					_CurtainState.SetActive(false);
					_currentSubject = Data._NoneSubject;
					ContragentInstanse.AAAAAAAAAAAAAAbo();
				}
				if (Data.Points[_CurrentPoint[0]].TaskChoise && CharacterMotion._curCharacter == 0)
				{
					if (GUI.Button(new Rect(AAAAAAAAAAAAAAAAAAAbs, _posY4 + _posY8 + _posY64, _posY10, _posY10), _Ok, _guiIconGroup))
					{
						AAAAAAAAAAAAAAAAAAAAAcf();
						_PointInf = false;
						AAAAAAAAAAAAAAAAAbx();
						Methods.AAAAAAAAAAAAAAAAAAAAAcs();
						_currentTask = Data.TaskCurrentCharacter[0];
						_NewTaskNum = 0;
						AAAAAAAAAAAAAAAAAAAcb();
						_Equipment = false;
						_CurtainGUIEquipment.SetActive(false);
						_CurtainIconCharacterU.SetActive(false);
						_CurtainState.SetActive(false);
					}
					if (GUI.Button(new Rect(AAAAAAAAAAAAAAAAAAAbs, _posY4 + _posY4 + _posY64, _posY10, _posY10), _Stock, _guiIconGroup))
					{
						Methods.AAAAAAAAAAAAAAbp();
					}
				}
				if (Data.Points[_CurrentPoint[0]].exchange)
				{
					if (CharacterMotion._curCharacter == 0 && GUI.Button(new Rect(AAAAAAAAAAAAAAAAAAAbs, _posY2 + _posY8 + _posY64, _posY10, _posY10), _join, _guiIconGroup))
					{
						AAAAAAAAAAAAAAAAAAAAAcf();
						_JoinBool = true;
						_PointInf = false;
					}
					if (GUI.Button(new Rect(AAAAAAAAAAAAAAAAAAAbs, _posY8 + _posY64, _posY10, _posY10), _Change0, _guiIconGroup))
					{
						AAAAAAAAAAAAAAAAAAAAch();
						AAAAAAAAAAAAAAAAAbw();
						if (CharacterMotion.PointInform != null)
						{
							CharacterMotion.PointInform.SetActive(false);
						}
						SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
						SoundMenu.Play();
						_PointInf = false;
						CharacterMotion.DealerPanel = true;
						_CurtainGUIEquipment.SetActive(false);
						_CurtainIconCharacterU.SetActive(false);
						_CurtainState.SetActive(false);
						_currentSubject = Data._NoneSubject;
						ContragentInstanse.AAAAAAAAAAAAAAAbj();
					}
				}
			}
			if (Data.Points[_CurrentPoint[0]].Teleport != "None" && Data.Points[_CurrentPoint[0]].curGexPoint == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar && CharacterMotion._curCharacter == 0)
			{
				GUI.Label(new Rect(0f, _posY3 * 2, _posX2_3, _posY12), (Texture2D)Resources.Load("Sprites/IconGUI/ui_button0"), _guiIconGroup);
				if (GUI.Button(new Rect(0f, _posY3 * 2, _posX2_3, _posY12), "Перейти" + Data.Points[_CurrentPoint[0]].TeleportName, _guiIconGroup))
				{
					_PointInf = false;
					SaveLoad.AAAAAAAAAAAAAAAAAAAck(Data.Points[_CurrentPoint[0]].Teleport, Data.Points[_CurrentPoint[0]].TeleportGex.NameGex, null);
					_CurrentCharUnit.Clear();
					GameObject.Find("Main Camera").GetComponent<LoadingCircleScript>().AAAAAAAAAAAAAAAAe(Data.Points[_CurrentPoint[0]].Teleport, "AutoSave");
				}
			}
			if (Data.Points[_CurrentPoint[0]].Teleport != "None" && Data.Points[_CurrentPoint[0]].curGexPoint == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar && CharacterMotion._curCharacter == 0)
			{
				for (int num2 = 0; num2 < _CurrentCharUnit.Count; num2++)
				{
					if (_CurrentCharUnit[num2] == 0 || !Data.CharacterD[_CurrentCharUnit[num2]].ControlGamer)
					{
						continue;
					}
					if (Data.CharacterD.Count > 13)
					{
						GUI.Label(new Rect(0f, _posY3 * 2 + _posY12, _posX2_3, _posY12), (Texture2D)Resources.Load("Sprites/IconGUI/ui_button0"), _guiIconGroup);
						if (GUI.Button(new Rect(0f, _posY3 * 2 + _posY12, _posX2_3, _posY12), "Перейти с союзником" + Data.Points[_CurrentPoint[0]].TeleportName, _guiIconGroup))
						{
							_PointInf = false;
							AAAAAAAAAAAAAAAAf aAAAAAAAAAAAAAcl = Data.CharacterD[_CurrentCharUnit[num2]];
							SaveLoad.AAAAAAAAAAAAAAAAAAAck(Data.Points[_CurrentPoint[0]].Teleport, Data.Points[_CurrentPoint[0]].TeleportGex.NameGex, aAAAAAAAAAAAAAcl);
							_CurrentCharUnit.Clear();
							GameObject.Find("Main Camera").GetComponent<LoadingCircleScript>().AAAAAAAAAAAAAAAAe(Data.Points[_CurrentPoint[0]].Teleport, "AutoSave");
						}
					}
					else
					{
						GUI.Label(new Rect(0f, _posY3 * 2 + _posY12, _posX2_3, _posY12), "Переход с союзником невозможен. Мало союзников осталось на карте.", _guiIconGroup);
					}
					break;
				}
			}
			if (Data.Points[_CurrentPoint[0]].TeleportDouble != "None" && Data.Points[_CurrentPoint[0]].curGexPoint == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar && CharacterMotion._curCharacter == 0)
			{
				GUI.Label(new Rect(0f, _posY3 * 2 + _posY12 + _posY12, _posX2_3, _posY12), (Texture2D)Resources.Load("Sprites/IconGUI/ui_button0"), _guiIconGroup);
				if (GUI.Button(new Rect(0f, _posY3 * 2 + _posY12 + _posY12, _posX2_3, _posY12), "Перейти" + Data.Points[_CurrentPoint[0]].TeleportNameDouble, _guiIconGroup))
				{
					_PointInf = false;
					SaveLoad.AAAAAAAAAAAAAAAAAAAck(Data.Points[_CurrentPoint[0]].TeleportDouble, Data.Points[_CurrentPoint[0]].TeleportGexDouble.NameGex, null);
					_CurrentCharUnit.Clear();
					GameObject.Find("Main Camera").GetComponent<LoadingCircleScript>().AAAAAAAAAAAAAAAAe(Data.Points[_CurrentPoint[0]].TeleportDouble, "AutoSave");
				}
			}
			if (Data.Points[_CurrentPoint[0]].TeleportDouble != "None" && Data.Points[_CurrentPoint[0]].curGexPoint == Data.CharacterD[CharacterMotion._curCharacter].CurGexChar && CharacterMotion._curCharacter == 0)
			{
				for (int num3 = 0; num3 < _CurrentCharUnit.Count; num3++)
				{
					if (_CurrentCharUnit[num3] == 0 || !Data.CharacterD[_CurrentCharUnit[num3]].ControlGamer)
					{
						continue;
					}
					if (Data.CharacterD.Count > 13)
					{
						GUI.Label(new Rect(0f, _posY3 * 2 + _posY12 + _posY12 + _posY12, _posX2_3, _posY12), (Texture2D)Resources.Load("Sprites/IconGUI/ui_button0"), _guiIconGroup);
						if (GUI.Button(new Rect(0f, _posY3 * 2 + _posY12 + _posY12 + _posY12, _posX2_3, _posY12), "Перейти с союзником" + Data.Points[_CurrentPoint[0]].TeleportNameDouble, _guiIconGroup))
						{
							_PointInf = false;
							AAAAAAAAAAAAAAAAf aAAAAAAAAAAAAAcl2 = Data.CharacterD[_CurrentCharUnit[num3]];
							SaveLoad.AAAAAAAAAAAAAAAAAAAck(Data.Points[_CurrentPoint[0]].TeleportDouble, Data.Points[_CurrentPoint[0]].TeleportGexDouble.NameGex, aAAAAAAAAAAAAAcl2);
							_CurrentCharUnit.Clear();
							GameObject.Find("Main Camera").GetComponent<LoadingCircleScript>().AAAAAAAAAAAAAAAAe(Data.Points[_CurrentPoint[0]].TeleportDouble, "AutoSave");
						}
					}
					else
					{
						GUI.Label(new Rect(0f, _posY3 * 2 + _posY12 + _posY12 + _posY12, _posX2_3, _posY12), "Переход с союзником невозможен. Мало союзников осталось на карте.", _guiIconGroup);
					}
					break;
				}
			}
		}
		if (_PointInf && _CurrentPoint.Count == 0)
		{
			SoundMenu.clip = (AudioClip)Resources.Load("Sound/Suit/inv_belt");
			SoundMenu.Play();
			_PointInformation = false;
			_PointInf = false;
			_Equipment = true;
			_CurtainGUIEquipment.SetActive(true);
			_CurtainIconCharacterU.SetActive(true);
			_CurtainState.SetActive(true);
			_CurtainInventory.SetActive(false);
			_currentSubject = Data._NoneSubject;
			Methods.AAAAAAAAAAAAAAAAAAAAAct();
		}
		if (_Cache)
		{
			AAAAAAAAAAAAAAAAAAAAch();
			AAAAAAAAAAAAAAAAAbw();
		}
		if (_Exchange)
		{
			AAAAAAAAAAAAAAAAAAAAch();
			AAAAAAAAAAAAAAAAAbw();
		}
	}

	public static void AAAAAAAAAAAAAAAAbs()
	{
		ArtRespawnTime++;
		if (ArtRespawnTime == 199)
		{
			for (int i = 0; i < Data.Points.Count; i++)
			{
				if (Data.Points[i].pointTypes == ConstructorPoints.PointTypes.Anomaly)
				{
					Data.Points[i].Cache[0] = Data.Artefacts[Random.Range(0, Data.Artefacts.Count - 1)];
				}
			}
		}
		if ((ArtRespawnTime == 25 || ArtRespawnTime == 50 || ArtRespawnTime == 75 || ArtRespawnTime == 100 || ArtRespawnTime == 125 || ArtRespawnTime == 150 || ArtRespawnTime == 175 || ArtRespawnTime == 199) && _QuantityClipsOfAdvertising > 7)
		{
			_QuantityClipsOfAdvertising = 0;
		}
	}

	public static void AAAAAAAAAAAAAAAAAAAAch()
	{
		_CurWeigh = Data.CharacterD[CharacterMotion._curCharacter].SuitChar.WeightSubject + Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.WeightSubject + Data.CharacterD[CharacterMotion._curCharacter].DetectorChar.WeightSubject + Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[0].WeightSubject - Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[0].Force + Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[1].WeightSubject - Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[1].Force + Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[2].WeightSubject - Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[2].Force + Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[3].WeightSubject - Data.CharacterD[CharacterMotion._curCharacter].ArtContainers[3].Force;
		_CurWeigh += Data.CharacterD[CharacterMotion._curCharacter].SuitChar.WeightUpGrade;
		_CurWeigh += Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.WeightUpGrade;
		for (int i = 0; i < 20; i++)
		{
			float num = Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].WeightSubject * (float)Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].Stack;
			_CurWeigh += num;
		}
		_CurWeigh -= Data.CharacterD[CharacterMotion._curCharacter].SuitChar.Force;
	}

	public static void AAAAAAAAAAAAAAAAAbw()
	{
		if (_CurWeigh < 12f)
		{
			_CalcWeigh = 7;
		}
		if (_CurWeigh < 17f && _CurWeigh >= 12f)
		{
			_CalcWeigh = 6;
		}
		if (_CurWeigh < 25f && _CurWeigh >= 17f)
		{
			_CalcWeigh = 5;
		}
		if (_CurWeigh < 30f && _CurWeigh >= 25f)
		{
			_CalcWeigh = 4;
		}
		if (_CurWeigh < 40f && _CurWeigh >= 30f)
		{
			_CalcWeigh = 3;
		}
		if (_CurWeigh < 55f && _CurWeigh >= 40f)
		{
			_CalcWeigh = 2;
		}
		if (_CurWeigh >= 55f)
		{
			_CalcWeigh = 1;
		}
	}

	public static void AAAAAAAAAAAAAAAAAbx()
	{
		for (int i = 0; i < 13; i++)
		{
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAcd[i] = 0;
			for (int j = 0; j < Data.CharacterD.Count; j++)
			{
				if (Data.CharacterD[j].TypeChInt == i && Data.CharacterD[j].Life)
				{
					AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAcd[i]++;
				}
			}
		}
	}

	public static void AAAAAAAAAAAAAAAAAAAAAce()
	{
		if (_CurrentCharUnit.Count > 0 && !Data.CharacterD[_currentCharacterNumber].Life && _currentCharacterNumber != 0 && Data.CharacterD[_currentCharacterNumber].CharUnits.name != "Хищник")
		{
			Data.CharacterD[_currentCharacterNumber].ControlGamer = false;
		}
		if (!Data.CharacterD[0].Life || (Data.CharacterD[_currentCharacterNumber].ControlGamer && Data.CharacterD[_currentCharacterNumber].CharUnits.name == "Хищник" && !Data.CharacterD[_currentCharacterNumber].Life))
		{
			AAAAAAAAAAAAAAAAAAAbw();
		}
	}

	public static void AAAAAAAAAAAAAAAAAAAAci()
	{
		_diplomacy = false;
		_taskReward = false;
		_PointInformation = false;
		_Equipment = false;
		_JoinBool = false;
	}

	public static void AAAAAAAAAAAAAAAAAAAAAcf()
	{
		SoundMenu.clip = effectBip;
		SoundMenu.Play();
	}

	public static void AAAAAAAAAAAAAAbz()
	{
		SoundMenu.clip = effectPaw;
		SoundMenu.Play();
	}

	public static void AAAAAAAAAAAAAAAAAAcv()
	{
		SoundMenu.clip = effectEmpty;
		SoundMenu.Play();
	}

	public static void AAAAAAAAAAAAAAAAbt()
	{
		for (int i = 1; i < Data.CharacterD.Count; i++)
		{
			Data.CharacterD[i].ControlGamer = false;
		}
		Data.CharacterD[CharacterMotion._curCharacter].TypeChInt = Data.Points[_CurrentPoint[0]].ControlInt;
		if (Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 1)
		{
			Data.CharacterD[CharacterMotion._curCharacter].TypeChar = AAAAAAAAAAAAAAAAf.TypeCharacter.Одиночки;
			GameObject.Find(Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/IconGroup/StalkerIcon64");
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 2)
		{
			Data.CharacterD[CharacterMotion._curCharacter].TypeChar = AAAAAAAAAAAAAAAAf.TypeCharacter.Бандиты;
			GameObject.Find(Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/IconGroup/Bandit64C");
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 3)
		{
			Data.CharacterD[CharacterMotion._curCharacter].TypeChar = AAAAAAAAAAAAAAAAf.TypeCharacter.Военные;
			GameObject.Find(Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/IconGroup/Army64");
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 4)
		{
			Data.CharacterD[CharacterMotion._curCharacter].TypeChar = AAAAAAAAAAAAAAAAf.TypeCharacter.Долг;
			GameObject.Find(Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/IconGroup/Dolg64");
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 5)
		{
			Data.CharacterD[CharacterMotion._curCharacter].TypeChar = AAAAAAAAAAAAAAAAf.TypeCharacter.Наемники;
			GameObject.Find(Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/IconGroup/Mercenaries64");
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 6)
		{
			Data.CharacterD[CharacterMotion._curCharacter].TypeChar = AAAAAAAAAAAAAAAAf.TypeCharacter.Свобода;
			GameObject.Find(Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/IconGroup/Freedom64new");
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 7)
		{
			Data.CharacterD[CharacterMotion._curCharacter].TypeChar = AAAAAAAAAAAAAAAAf.TypeCharacter.Чистое_небо;
			GameObject.Find(Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/IconGroup/ClearSky64A");
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 8)
		{
			Data.CharacterD[CharacterMotion._curCharacter].TypeChar = AAAAAAAAAAAAAAAAf.TypeCharacter.Монолит;
			GameObject.Find(Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/IconGroup/Monolith64Var");
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 11)
		{
			Data.CharacterD[CharacterMotion._curCharacter].TypeChar = AAAAAAAAAAAAAAAAf.TypeCharacter.Ученые;
			GameObject.Find(Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/IconGroup/Ecolog64");
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 12)
		{
			Data.CharacterD[CharacterMotion._curCharacter].TypeChar = AAAAAAAAAAAAAAAAf.TypeCharacter.Ренегаты;
			GameObject.Find(Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/IconGroup/Renegade64");
		}
		Data.CharacterD[CharacterMotion._curCharacter].NameCharac = Data.CharacterD[CharacterMotion._curCharacter].TypeChar.ToString();
		if (Data.CharacterD[0].TypeChInt == 1)
		{
			GPSscript.AAAAAAAAAAAAAAAAAAAAe("CgkI2OGbhtMLEAIQAw");
		}
		if (Data.CharacterD[0].TypeChInt == 2)
		{
			GPSscript.AAAAAAAAAAAAAAAAAAAAe("CgkI2OGbhtMLEAIQBA");
		}
		if (Data.CharacterD[0].TypeChInt == 4)
		{
			GPSscript.AAAAAAAAAAAAAAAAAAAAe("CgkI2OGbhtMLEAIQCA");
		}
		if (Data.CharacterD[0].TypeChInt == 5)
		{
			GPSscript.AAAAAAAAAAAAAAAAAAAAe("CgkI2OGbhtMLEAIQBQ");
		}
		if (Data.CharacterD[0].TypeChInt == 6)
		{
			GPSscript.AAAAAAAAAAAAAAAAAAAAe("CgkI2OGbhtMLEAIQCQ");
		}
	}

	public static void AAAAAAAAAAAAAAAAAAAAAcg()
	{
		if (CharacterMotion._curCharacter == 0 || Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name == "Хищник")
		{
			if (Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 0)
			{
				Data.CharacterD[CharacterMotion._curCharacter].TypeChar = AAAAAAAAAAAAAAAAf.TypeCharacter.Странник;
				GameObject.Find(Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/IconGroup/GasMask64A");
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 1)
			{
				Data.CharacterD[CharacterMotion._curCharacter].TypeChar = AAAAAAAAAAAAAAAAf.TypeCharacter.Одиночки;
				GameObject.Find(Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/IconGroup/StalkerIcon64");
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 2)
			{
				Data.CharacterD[CharacterMotion._curCharacter].TypeChar = AAAAAAAAAAAAAAAAf.TypeCharacter.Бандиты;
				GameObject.Find(Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/IconGroup/Bandit64C");
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 3)
			{
				Data.CharacterD[CharacterMotion._curCharacter].TypeChar = AAAAAAAAAAAAAAAAf.TypeCharacter.Военные;
				GameObject.Find(Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/IconGroup/Army64");
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 4)
			{
				Data.CharacterD[CharacterMotion._curCharacter].TypeChar = AAAAAAAAAAAAAAAAf.TypeCharacter.Долг;
				GameObject.Find(Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/IconGroup/Dolg64");
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 5)
			{
				Data.CharacterD[CharacterMotion._curCharacter].TypeChar = AAAAAAAAAAAAAAAAf.TypeCharacter.Наемники;
				GameObject.Find(Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/IconGroup/Mercenaries64");
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 6)
			{
				Data.CharacterD[CharacterMotion._curCharacter].TypeChar = AAAAAAAAAAAAAAAAf.TypeCharacter.Свобода;
				GameObject.Find(Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/IconGroup/Freedom64new");
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 7)
			{
				Data.CharacterD[CharacterMotion._curCharacter].TypeChar = AAAAAAAAAAAAAAAAf.TypeCharacter.Чистое_небо;
				GameObject.Find(Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/IconGroup/ClearSky64A");
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 8)
			{
				Data.CharacterD[CharacterMotion._curCharacter].TypeChar = AAAAAAAAAAAAAAAAf.TypeCharacter.Монолит;
				GameObject.Find(Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/IconGroup/Monolith64Var");
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 11)
			{
				Data.CharacterD[CharacterMotion._curCharacter].TypeChar = AAAAAAAAAAAAAAAAf.TypeCharacter.Ученые;
				GameObject.Find(Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/IconGroup/Ecolog64");
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 12)
			{
				Data.CharacterD[CharacterMotion._curCharacter].TypeChar = AAAAAAAAAAAAAAAAf.TypeCharacter.Ренегаты;
				GameObject.Find(Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/IconGroup/Renegade64");
			}
		}
	}

	public static void AAAAAAAAAAAAAAca()
	{
		_FigherGroup.Clear();
		for (int i = 0; i < Data.CharacterD.Count; i++)
		{
			if (Data.CharacterD[i].TypeChInt == Data.CharacterD[CharacterMotion._curCharacter].TypeChInt && Data.CharacterD[i].Life)
			{
				Data.CharacterD[i].Thirst = 55;
				Data.CharacterD[i].Satiety = 50;
				_FigherGroup.Add(i);
			}
		}
	}

	public static void AAAAAAAAAAAAAAAAAAAAAch()
	{
		if (Data.CharacterD[CharacterMotion._curCharacter].Skill >= 0 && Data.CharacterD[CharacterMotion._curCharacter].Skill < 3)
		{
			_RewardAdvertisingSubject = new AAAAAAAAAAAAAAAAAAbj();
			if (_QuantityClipsOfAdvertising == 1)
			{
				_RewardAdvertisingSubject = new TOZ34();
			}
			if (_QuantityClipsOfAdvertising == 2)
			{
				_RewardAdvertisingSubject = new AAAAAAAAAAAAAAbb();
			}
			if (_QuantityClipsOfAdvertising == 3)
			{
				_RewardAdvertisingSubject = new Cartridge12x70();
				_RewardAdvertisingSubject.Stack = 30;
			}
			if (_QuantityClipsOfAdvertising == 4)
			{
				_RewardAdvertisingSubject = new AAAAAAAAAAAAAAAAAAbj();
			}
			if (_QuantityClipsOfAdvertising == 5)
			{
				_RewardAdvertisingSubject = new AAAAAAAAAAAAAAAAy();
			}
			if (_QuantityClipsOfAdvertising == 6)
			{
				_RewardAdvertisingSubject = new MP5();
			}
			if (_QuantityClipsOfAdvertising == 7)
			{
				_RewardAdvertisingSubject = new Cartridge9x19();
				_RewardAdvertisingSubject.Stack = 30;
			}
			if (_QuantityClipsOfAdvertising == 8)
			{
				_RewardAdvertisingSubject = new F1();
			}
			if (_QuantityClipsOfAdvertising == 9)
			{
				_RewardAdvertisingSubject = new AAAAAAAAAAAAAAAAAAbk();
			}
			if (_QuantityClipsOfAdvertising == 10)
			{
				_RewardAdvertisingSubject = Data.Artefacts[Random.Range(0, Data.Artefacts.Count - 1)];
			}
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].Skill >= 3 && Data.CharacterD[CharacterMotion._curCharacter].Skill < 6)
		{
			_RewardAdvertisingSubject = new AAAAAAAAAAAAAAAs();
			if (_QuantityClipsOfAdvertising == 1)
			{
				_RewardAdvertisingSubject = new Bekas12();
			}
			if (_QuantityClipsOfAdvertising == 2)
			{
				_RewardAdvertisingSubject = new Winchester1300();
			}
			if (_QuantityClipsOfAdvertising == 3)
			{
				_RewardAdvertisingSubject = new Cartridge9x19();
				_RewardAdvertisingSubject.Stack = 30;
			}
			if (_QuantityClipsOfAdvertising == 4)
			{
				_RewardAdvertisingSubject = new Remington870Tactical();
			}
			if (_QuantityClipsOfAdvertising == 5)
			{
				_RewardAdvertisingSubject = new AAAAAAAAAAAAAAAAz();
			}
			if (_QuantityClipsOfAdvertising == 6)
			{
				_RewardAdvertisingSubject = new F1();
			}
			if (_QuantityClipsOfAdvertising == 7)
			{
				_RewardAdvertisingSubject = new AK74();
			}
			if (_QuantityClipsOfAdvertising == 8)
			{
				_RewardAdvertisingSubject = new LR300ML();
			}
			if (_QuantityClipsOfAdvertising == 9)
			{
				_RewardAdvertisingSubject = new AAAAAAAAAAAAAAAAAw();
			}
			if (_QuantityClipsOfAdvertising == 10)
			{
				_RewardAdvertisingSubject = Data.Artefacts[Random.Range(0, Data.Artefacts.Count - 1)];
			}
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].Skill >= 6 && Data.CharacterD[CharacterMotion._curCharacter].Skill < 9)
		{
			_RewardAdvertisingSubject = new AAAAAAAAAAAAAAAAy();
			if (_QuantityClipsOfAdvertising == 1)
			{
				_RewardAdvertisingSubject = new Winchester1300();
			}
			if (_QuantityClipsOfAdvertising == 2)
			{
				_RewardAdvertisingSubject = new MP135();
			}
			if (_QuantityClipsOfAdvertising == 3)
			{
				_RewardAdvertisingSubject = new Remington870Tactical();
			}
			if (_QuantityClipsOfAdvertising == 4)
			{
				_RewardAdvertisingSubject = new MP5();
			}
			if (_QuantityClipsOfAdvertising == 5)
			{
				_RewardAdvertisingSubject = new Cartridge_5_45x39();
				_RewardAdvertisingSubject.Stack = 30;
			}
			if (_QuantityClipsOfAdvertising == 6)
			{
				_RewardAdvertisingSubject = new AAAAAAAAAAAAAAbb();
			}
			if (_QuantityClipsOfAdvertising == 7)
			{
				_RewardAdvertisingSubject = new Bekas12();
			}
			if (_QuantityClipsOfAdvertising == 8)
			{
				_RewardAdvertisingSubject = Data.Artefacts[Random.Range(0, Data.Artefacts.Count - 1)];
			}
			if (_QuantityClipsOfAdvertising == 9)
			{
				_RewardAdvertisingSubject = new F1();
			}
			if (_QuantityClipsOfAdvertising == 10)
			{
				_RewardAdvertisingSubject = Data.Artefacts[Random.Range(0, Data.Artefacts.Count - 1)];
			}
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].Skill >= 10 && Data.CharacterD[CharacterMotion._curCharacter].Skill < 13)
		{
			_RewardAdvertisingSubject = new AAAAAAAAAAAAAAAAAAAAAbj();
			if (_QuantityClipsOfAdvertising == 1)
			{
				_RewardAdvertisingSubject = new MP135();
			}
			if (_QuantityClipsOfAdvertising == 2)
			{
				_RewardAdvertisingSubject = new Remington870Tactical();
			}
			if (_QuantityClipsOfAdvertising == 3)
			{
				_RewardAdvertisingSubject = new AAAAAAAAAAAAAAAAAAbk();
			}
			if (_QuantityClipsOfAdvertising == 4)
			{
				_RewardAdvertisingSubject = new AK74();
			}
			if (_QuantityClipsOfAdvertising == 5)
			{
				_RewardAdvertisingSubject = Data.Artefacts[Random.Range(0, Data.Artefacts.Count - 1)];
			}
			if (_QuantityClipsOfAdvertising == 6)
			{
				_RewardAdvertisingSubject = new Cartridge_5_45x39();
				_RewardAdvertisingSubject.Stack = 30;
			}
			if (_QuantityClipsOfAdvertising == 7)
			{
				_RewardAdvertisingSubject = new AAAAAAAAAAAAAAbb();
			}
			if (_QuantityClipsOfAdvertising == 8)
			{
				_RewardAdvertisingSubject = new MP5();
			}
			if (_QuantityClipsOfAdvertising == 9)
			{
				_RewardAdvertisingSubject = new F1();
			}
			if (_QuantityClipsOfAdvertising == 10)
			{
				_RewardAdvertisingSubject = Data.Artefacts[Random.Range(0, Data.Artefacts.Count - 1)];
			}
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].Skill >= 14 && Data.CharacterD[CharacterMotion._curCharacter].Skill < 16)
		{
			_RewardAdvertisingSubject = new AAAAAAAAAAAAAAAt();
			if (_QuantityClipsOfAdvertising == 1)
			{
				_RewardAdvertisingSubject = new Remington870Tactical();
			}
			if (_QuantityClipsOfAdvertising == 2)
			{
				_RewardAdvertisingSubject = new AAAAAAAAAAAAAAAAAw();
			}
			if (_QuantityClipsOfAdvertising == 3)
			{
				_RewardAdvertisingSubject = new AK74();
			}
			if (_QuantityClipsOfAdvertising == 4)
			{
				_RewardAdvertisingSubject = new RGD5();
			}
			if (_QuantityClipsOfAdvertising == 5)
			{
				_RewardAdvertisingSubject = new AAAAAAAAAAAAAAAAy();
			}
			if (_QuantityClipsOfAdvertising == 6)
			{
				_RewardAdvertisingSubject = new AAAAAAAAAAAAAAbb();
			}
			if (_QuantityClipsOfAdvertising == 7)
			{
				_RewardAdvertisingSubject = new AAAAAAAAAAAAAAAAw();
			}
			if (_QuantityClipsOfAdvertising == 8)
			{
				_RewardAdvertisingSubject = new Cartridge_5_56x45();
				_RewardAdvertisingSubject.Stack = 30;
			}
			if (_QuantityClipsOfAdvertising == 9)
			{
				_RewardAdvertisingSubject = new F1();
			}
			if (_QuantityClipsOfAdvertising == 10)
			{
				_RewardAdvertisingSubject = Data.Artefacts[Random.Range(0, Data.Artefacts.Count - 1)];
			}
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].Skill >= 16 && Data.CharacterD[CharacterMotion._curCharacter].Skill < 19)
		{
			_RewardAdvertisingSubject = new AAAAAAAAAAAAAAAAAAAAAbi();
			if (_QuantityClipsOfAdvertising == 1)
			{
				_RewardAdvertisingSubject = new AAAAAAAAAAAAAAAAAAbj();
			}
			if (_QuantityClipsOfAdvertising == 2)
			{
				_RewardAdvertisingSubject = new Remington870Tactical();
			}
			if (_QuantityClipsOfAdvertising == 3)
			{
				_RewardAdvertisingSubject = new VOG25();
			}
			if (_QuantityClipsOfAdvertising == 4)
			{
				_RewardAdvertisingSubject = new AAAAAAAAAAAAAAAAAw();
			}
			if (_QuantityClipsOfAdvertising == 5)
			{
				_RewardAdvertisingSubject = new AAAAAAAAAAAAAAbb();
			}
			if (_QuantityClipsOfAdvertising == 6)
			{
				_RewardAdvertisingSubject = new AAAAAAAAAAAAAAAAw();
			}
			if (_QuantityClipsOfAdvertising == 7)
			{
				_RewardAdvertisingSubject = new MP5();
			}
			if (_QuantityClipsOfAdvertising == 8)
			{
				_RewardAdvertisingSubject = new AN94();
			}
			if (_QuantityClipsOfAdvertising == 9)
			{
				_RewardAdvertisingSubject = new F1();
			}
			if (_QuantityClipsOfAdvertising == 10)
			{
				_RewardAdvertisingSubject = Data.Artefacts[Random.Range(0, Data.Artefacts.Count - 1)];
			}
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].Skill >= 19 && Data.CharacterD[CharacterMotion._curCharacter].Skill < 22)
		{
			_RewardAdvertisingSubject = new MP135();
			if (_QuantityClipsOfAdvertising == 1)
			{
				_RewardAdvertisingSubject = new AK74();
			}
			if (_QuantityClipsOfAdvertising == 2)
			{
				_RewardAdvertisingSubject = new Cartridge_5_45x39();
				_RewardAdvertisingSubject.Stack = 30;
			}
			if (_QuantityClipsOfAdvertising == 3)
			{
				_RewardAdvertisingSubject = new VOG25();
			}
			if (_QuantityClipsOfAdvertising == 4)
			{
				_RewardAdvertisingSubject = new F1();
			}
			if (_QuantityClipsOfAdvertising == 5)
			{
				_RewardAdvertisingSubject = new AAAAAAAAAAAAAAAAw();
			}
			if (_QuantityClipsOfAdvertising == 6)
			{
				_RewardAdvertisingSubject = new Winchester1300();
			}
			if (_QuantityClipsOfAdvertising == 7)
			{
				_RewardAdvertisingSubject = new AAAAAAAAAAAAAAAAAAbm();
			}
			if (_QuantityClipsOfAdvertising == 8)
			{
				_RewardAdvertisingSubject = new AAAAAAAAAAAAAAbb();
			}
			if (_QuantityClipsOfAdvertising == 9)
			{
				_RewardAdvertisingSubject = new F1();
			}
			if (_QuantityClipsOfAdvertising == 10)
			{
				_RewardAdvertisingSubject = Data.Artefacts[Random.Range(0, Data.Artefacts.Count - 1)];
			}
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].Skill >= 22 && Data.CharacterD[CharacterMotion._curCharacter].Skill < 25)
		{
			_RewardAdvertisingSubject = new MP135();
			if (_QuantityClipsOfAdvertising == 1)
			{
				_RewardAdvertisingSubject = new Cartridge9x19();
				_RewardAdvertisingSubject.Stack = 30;
			}
			if (_QuantityClipsOfAdvertising == 2)
			{
				_RewardAdvertisingSubject = new Bekas12Tactical();
			}
			if (_QuantityClipsOfAdvertising == 3)
			{
				_RewardAdvertisingSubject = new AAAAAAAAAAAAAAAAAAbj();
			}
			if (_QuantityClipsOfAdvertising == 4)
			{
				_RewardAdvertisingSubject = new MP5();
			}
			if (_QuantityClipsOfAdvertising == 5)
			{
				_RewardAdvertisingSubject = Data.Artefacts[Random.Range(0, Data.Artefacts.Count - 1)];
			}
			if (_QuantityClipsOfAdvertising == 6)
			{
				_RewardAdvertisingSubject = new AAAAAAAAAAAAAAAAt();
			}
			if (_QuantityClipsOfAdvertising == 7)
			{
				_RewardAdvertisingSubject = new AAAAAAAAAAAAAAAAAAbm();
			}
			if (_QuantityClipsOfAdvertising == 8)
			{
				_RewardAdvertisingSubject = new AKSy();
			}
			if (_QuantityClipsOfAdvertising == 9)
			{
				_RewardAdvertisingSubject = new F1();
			}
			if (_QuantityClipsOfAdvertising == 10)
			{
				_RewardAdvertisingSubject = Data.Artefacts[Random.Range(0, Data.Artefacts.Count - 1)];
			}
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].Skill >= 25 && Data.CharacterD[CharacterMotion._curCharacter].Skill < 28)
		{
			_RewardAdvertisingSubject = new LR300ML();
			if (_QuantityClipsOfAdvertising == 1)
			{
				_RewardAdvertisingSubject = new Bekas12Tactical();
			}
			if (_QuantityClipsOfAdvertising == 2)
			{
				_RewardAdvertisingSubject = Data.Artefacts[Random.Range(0, Data.Artefacts.Count - 1)];
			}
			if (_QuantityClipsOfAdvertising == 3)
			{
				_RewardAdvertisingSubject = new MP5();
			}
			if (_QuantityClipsOfAdvertising == 4)
			{
				_RewardAdvertisingSubject = new AAAAAAAAAAAAAAAAAAbk();
			}
			if (_QuantityClipsOfAdvertising == 5)
			{
				_RewardAdvertisingSubject = new Cartridge_9x39_sp5();
				_RewardAdvertisingSubject.Stack = 30;
			}
			if (_QuantityClipsOfAdvertising == 6)
			{
				_RewardAdvertisingSubject = new AAAAAAAAAAAAAAAAAAbm();
			}
			if (_QuantityClipsOfAdvertising == 7)
			{
				_RewardAdvertisingSubject = new AAAAAAAAAAAAAAbb();
			}
			if (_QuantityClipsOfAdvertising == 8)
			{
				_RewardAdvertisingSubject = new AKSy();
			}
			if (_QuantityClipsOfAdvertising == 9)
			{
				_RewardAdvertisingSubject = new F1();
			}
			if (_QuantityClipsOfAdvertising == 10)
			{
				_RewardAdvertisingSubject = Data.Artefacts[Random.Range(0, Data.Artefacts.Count - 1)];
			}
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].Skill >= 28 && Data.CharacterD[CharacterMotion._curCharacter].Skill < 32)
		{
			_RewardAdvertisingSubject = new MP5();
			if (_QuantityClipsOfAdvertising == 1)
			{
				_RewardAdvertisingSubject = new Bekas12();
			}
			if (_QuantityClipsOfAdvertising == 2)
			{
				_RewardAdvertisingSubject = new AAAAAAAAAAAAAAbb();
			}
			if (_QuantityClipsOfAdvertising == 3)
			{
				_RewardAdvertisingSubject = new Cartridge_7_62x54();
				_RewardAdvertisingSubject.Stack = 30;
			}
			if (_QuantityClipsOfAdvertising == 4)
			{
				_RewardAdvertisingSubject = new AAAAAAAAAAAAAAAAba();
			}
			if (_QuantityClipsOfAdvertising == 5)
			{
				_RewardAdvertisingSubject = new AAAAAAAAAAAAAAAAAAbm();
			}
			if (_QuantityClipsOfAdvertising == 6)
			{
				_RewardAdvertisingSubject = new F1();
			}
			if (_QuantityClipsOfAdvertising == 7)
			{
				_RewardAdvertisingSubject = new VOG25();
				_RewardAdvertisingSubject.Stack = 2;
			}
			if (_QuantityClipsOfAdvertising == 8)
			{
				_RewardAdvertisingSubject = new AKSy();
			}
			if (_QuantityClipsOfAdvertising == 9)
			{
				_RewardAdvertisingSubject = new GausAccumulator();
				_RewardAdvertisingSubject.Stack = 20;
			}
			if (_QuantityClipsOfAdvertising == 10)
			{
				_RewardAdvertisingSubject = Data.Artefacts[Random.Range(0, Data.Artefacts.Count - 1)];
			}
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].Skill >= 32)
		{
			_RewardAdvertisingSubject = Data.Artefacts[Random.Range(0, Data.Artefacts.Count - 1)];
		}
	}

	public static void AAAAAAAAAAAAAAAAbu()
	{
		if (Application.platform == RuntimePlatform.Android && Advertisement.isSupported)
		{
			Advertisement.Initialize("1587463", false);
			_NoneDevice = false;
			_NoneIntertnet = true;
		}
		else
		{
			_NoneDevice = true;
		}
	}

	public static void AAAAAAAAAAAAAAAAAAAbw()
	{
		SoundMenu.clip = (AudioClip)Resources.Load("Sound/pda/pda_tip");
		SoundMenu.Play();
		GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Advertise/AdvertisePanel_DeadHero"));
		gameObject.name = "AdvertisePanel_DeadHero";
		gameObject.transform.SetParent(GameObject.Find("Canvas").transform);
		gameObject.transform.localPosition = new Vector3(0f, 0f);
		gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/IconChar/doktor128");
		gameObject.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = PlayerPrefs.GetString("HeroName") + " серьезно ранен!\nЯ смогу вернуть его к жизни, пока ты смотришь ролик...";
		gameObject.transform.GetChild(2).gameObject.SetActive(true);
		float num = Screen.width;
		num /= 1280f;
		gameObject.transform.localScale = new Vector3(num, num);
		SoundMenu.clip = effectNews;
		SoundMenu.Play();
		_Equipment = false;
		_PointInf = false;
		_PointInformation = false;
		_CurtainInventory.SetActive(false);
		_CurtainGUIEquipment.SetActive(true);
		_CurtainIconCharacterU.SetActive(true);
	}

	public void AAAAAAAAAAAAAAAAbv()
	{
		SoundMenu.clip = (AudioClip)Resources.Load("Sound/pda/pda_tip");
		SoundMenu.Play();
		GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Advertise/AdvertisePanel"));
		gameObject.name = "AdvertisePanel";
		gameObject.transform.SetParent(GameObject.Find("Canvas").transform);
		gameObject.transform.localPosition = new Vector3(0f, 0f);
		gameObject.transform.GetChild(1).transform.GetChild(0).GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Sprites/IconChar/iconStalkerSuit128");
		gameObject.transform.GetChild(2).transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Если нет хорошей снаряги, то в зоне придется туговато!\nПосмотри ролик, пока я присмотрю тебе чего-нибудь...";
		gameObject.transform.GetChild(3).gameObject.SetActive(true);
		gameObject.transform.GetChild(0).localPosition = new Vector3(585f, -300f);
		float num = Screen.width;
		num /= 1280f;
		gameObject.transform.localScale = new Vector3(num, num);
		SoundMenu.clip = effectNews;
		SoundMenu.Play();
		_Equipment = false;
		_PointInf = false;
		_PointInformation = false;
		_CurtainInventory.SetActive(false);
		_CurtainGUIEquipment.SetActive(true);
		_CurtainIconCharacterU.SetActive(true);
	}

	public static void AAAAAAAAAAAAAAAAAAcw()
	{
		_HungerBool = false;
		if (Data.CharacterD[CharacterMotion._curCharacter].Satiety < 30 && Data.CharacterD[CharacterMotion._curCharacter].Satiety >= 20)
		{
			_HungerBool = true;
			_HungerIcon = (Texture2D)Resources.Load("Sprites/IconGUI/HungerGreen64");
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].Satiety < 20 && Data.CharacterD[CharacterMotion._curCharacter].Satiety >= 10)
		{
			_HungerBool = true;
			_HungerIcon = (Texture2D)Resources.Load("Sprites/IconGUI/HungerYellow64");
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].Satiety < 10)
		{
			_HungerBool = true;
			_HungerIcon = (Texture2D)Resources.Load("Sprites/IconGUI/HungerRed64");
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].Satiety <= 0)
		{
			_HungerBool = true;
			_HungerIcon = (Texture2D)Resources.Load("Sprites/IconGUI/HungerRed64");
		}
		_ThirstIconBool = false;
		if (Data.CharacterD[CharacterMotion._curCharacter].Thirst < 30 && Data.CharacterD[CharacterMotion._curCharacter].Thirst >= 20)
		{
			_ThirstIconBool = true;
			_ThirstIcon = (Texture2D)Resources.Load("Sprites/IconGUI/ThirstG64");
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].Thirst < 20 && Data.CharacterD[CharacterMotion._curCharacter].Thirst >= 10)
		{
			_ThirstIconBool = true;
			_ThirstIcon = (Texture2D)Resources.Load("Sprites/IconGUI/ThirstY64");
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].Thirst < 10)
		{
			_ThirstIconBool = true;
			_ThirstIcon = (Texture2D)Resources.Load("Sprites/IconGUI/ThirstR64");
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].Thirst <= 0)
		{
			_ThirstIconBool = true;
			_ThirstIcon = (Texture2D)Resources.Load("Sprites/IconGUI/ThirstR64");
		}
	}

	public static void AAAAAAAAAAAAAAAAAAAbx()
	{
		float num = Vector3.Distance(Data.CharacterD[CharacterMotion._curCharacter].CharUnits.transform.position, CharacterMotion.taskIcon.transform.position);
		if (Data.TaskAll[_TaskNum].MapName == SceneManager.GetActiveScene().name && Data.TaskAll[_TaskNum].NamePointTask != string.Empty && Data.TaskAll[_TaskNum].NamePointTask != "None")
		{
			CharacterMotion.taskIcon.SetActive(true);
			CharacterMotion.taskIcon.transform.position = GameObject.Find(Data.TaskAll[_TaskNum].NamePointTask).transform.position;
			CharacterMotion.arrow.SetActive(true);
		}
		else
		{
			CharacterMotion.taskIcon.SetActive(false);
			CharacterMotion.arrow.SetActive(false);
		}
		if (Data.TaskAll[_TaskNum].MapName != SceneManager.GetActiveScene().name)
		{
			if (SceneManager.GetActiveScene().name == "Kordon")
			{
				CharacterMotion.taskIcon.SetActive(true);
				CharacterMotion.taskIcon.transform.position = GameObject.Find("Дорога на свалку").transform.position;
				CharacterMotion.arrow.SetActive(true);
			}
			if (SceneManager.GetActiveScene().name == "Marsh")
			{
				if (Data.TaskAll[_TaskNum].MapName == "Kordon")
				{
					CharacterMotion.taskIcon.SetActive(true);
					CharacterMotion.taskIcon.transform.position = GameObject.Find("Руины деревни").transform.position;
					CharacterMotion.arrow.SetActive(true);
				}
				if (Data.TaskAll[_TaskNum].MapName == "Dump" || Data.TaskAll[_TaskNum].MapName == "DarkValley" || Data.TaskAll[_TaskNum].MapName == "Bar" || Data.TaskAll[_TaskNum].MapName == "WildTerritory" || Data.TaskAll[_TaskNum].MapName == "Military" || Data.TaskAll[_TaskNum].MapName == "Radar" || Data.TaskAll[_TaskNum].MapName == "Backwater")
				{
					CharacterMotion.taskIcon.SetActive(true);
					CharacterMotion.taskIcon.transform.position = GameObject.Find("Северный хутор").transform.position;
					CharacterMotion.arrow.SetActive(true);
				}
				if (Data.TaskAll[_TaskNum].MapName == "Agroprom" || Data.TaskAll[_TaskNum].MapName == "Amber" || Data.TaskAll[_TaskNum].MapName == "DeadCity" || Data.TaskAll[_TaskNum].MapName == "RedForest")
				{
					CharacterMotion.taskIcon.SetActive(true);
					CharacterMotion.taskIcon.transform.position = GameObject.Find("Товарный состав").transform.position;
					CharacterMotion.arrow.SetActive(true);
				}
			}
			if (SceneManager.GetActiveScene().name == "Dump")
			{
				if (Data.TaskAll[_TaskNum].MapName == "Kordon")
				{
					CharacterMotion.taskIcon.SetActive(true);
					CharacterMotion.taskIcon.transform.position = GameObject.Find("Блок-пост приемник").transform.position;
					CharacterMotion.arrow.SetActive(true);
				}
				if (Data.TaskAll[_TaskNum].MapName == "Marsh")
				{
					CharacterMotion.taskIcon.SetActive(true);
					CharacterMotion.taskIcon.transform.position = GameObject.Find("Дорога на болото").transform.position;
					CharacterMotion.arrow.SetActive(true);
				}
				if (Data.TaskAll[_TaskNum].MapName == "Agroprom")
				{
					CharacterMotion.taskIcon.SetActive(true);
					CharacterMotion.taskIcon.transform.position = GameObject.Find("Дорога на НИИ Агропром").transform.position;
					CharacterMotion.arrow.SetActive(true);
				}
				if (Data.TaskAll[_TaskNum].MapName == "DarkValley")
				{
					CharacterMotion.taskIcon.SetActive(true);
					CharacterMotion.taskIcon.transform.position = GameObject.Find("Дорога в темную долину").transform.position;
					CharacterMotion.arrow.SetActive(true);
				}
				if (Data.TaskAll[_TaskNum].MapName == "Bar" || Data.TaskAll[_TaskNum].MapName == "WildTerritory" || Data.TaskAll[_TaskNum].MapName == "Amber" || Data.TaskAll[_TaskNum].MapName == "DeadCity" || Data.TaskAll[_TaskNum].MapName == "Military" || Data.TaskAll[_TaskNum].MapName == "Radar" || Data.TaskAll[_TaskNum].MapName == "RedForest" || Data.TaskAll[_TaskNum].MapName == "Backwater")
				{
					CharacterMotion.taskIcon.SetActive(true);
					CharacterMotion.taskIcon.transform.position = GameObject.Find("Барьер").transform.position;
					CharacterMotion.arrow.SetActive(true);
				}
			}
			if (SceneManager.GetActiveScene().name == "Agroprom")
			{
				if (Data.TaskAll[_TaskNum].MapName == "Kordon" || Data.TaskAll[_TaskNum].MapName == "Dump" || Data.TaskAll[_TaskNum].MapName == "DarkValley" || Data.TaskAll[_TaskNum].MapName == "Bar" || Data.TaskAll[_TaskNum].MapName == "Military" || Data.TaskAll[_TaskNum].MapName == "Radar" || Data.TaskAll[_TaskNum].MapName == "Backwater")
				{
					CharacterMotion.taskIcon.SetActive(true);
					CharacterMotion.taskIcon.transform.position = GameObject.Find("Автобусная остановка").transform.position;
					CharacterMotion.arrow.SetActive(true);
				}
				if (Data.TaskAll[_TaskNum].MapName == "Amber" || Data.TaskAll[_TaskNum].MapName == "WildTerritory" || Data.TaskAll[_TaskNum].MapName == "DeadCity" || Data.TaskAll[_TaskNum].MapName == "RedForest")
				{
					CharacterMotion.taskIcon.SetActive(true);
					CharacterMotion.taskIcon.transform.position = GameObject.Find("Переход на янтарь").transform.position;
					CharacterMotion.arrow.SetActive(true);
				}
				if (Data.TaskAll[_TaskNum].MapName == "Marsh")
				{
					CharacterMotion.taskIcon.SetActive(true);
					CharacterMotion.taskIcon.transform.position = GameObject.Find("Болотная тропа").transform.position;
					CharacterMotion.arrow.SetActive(true);
				}
			}
			if (SceneManager.GetActiveScene().name == "DarkValley")
			{
				if (Data.TaskAll[_TaskNum].MapName == "Kordon")
				{
					CharacterMotion.taskIcon.SetActive(true);
					CharacterMotion.taskIcon.transform.position = GameObject.Find("Блокпост у фермы").transform.position;
					CharacterMotion.arrow.SetActive(true);
				}
				if (Data.TaskAll[_TaskNum].MapName == "Dump" || Data.TaskAll[_TaskNum].MapName == "Amber" || Data.TaskAll[_TaskNum].MapName == "Agroprom" || Data.TaskAll[_TaskNum].MapName == "Marsh")
				{
					CharacterMotion.taskIcon.SetActive(true);
					CharacterMotion.taskIcon.transform.position = GameObject.Find("Дальний блокпост").transform.position;
					CharacterMotion.arrow.SetActive(true);
				}
				if (Data.TaskAll[_TaskNum].MapName == "Bar" || Data.TaskAll[_TaskNum].MapName == "WildTerritory" || Data.TaskAll[_TaskNum].MapName == "Military" || Data.TaskAll[_TaskNum].MapName == "Radar" || Data.TaskAll[_TaskNum].MapName == "DeadCity" || Data.TaskAll[_TaskNum].MapName == "RedForest" || Data.TaskAll[_TaskNum].MapName == "Backwater")
				{
					CharacterMotion.taskIcon.SetActive(true);
					CharacterMotion.taskIcon.transform.position = GameObject.Find("Лесная тропа").transform.position;
					CharacterMotion.arrow.SetActive(true);
				}
			}
			if (SceneManager.GetActiveScene().name == "Bar")
			{
				if (Data.TaskAll[_TaskNum].MapName == "Dump" || Data.TaskAll[_TaskNum].MapName == "Kordon" || Data.TaskAll[_TaskNum].MapName == "Agroprom" || Data.TaskAll[_TaskNum].MapName == "Marsh")
				{
					CharacterMotion.taskIcon.SetActive(true);
					CharacterMotion.taskIcon.transform.position = GameObject.Find("Собачья тропа").transform.position;
					CharacterMotion.arrow.SetActive(true);
				}
				if (Data.TaskAll[_TaskNum].MapName == "Amber" || Data.TaskAll[_TaskNum].MapName == "WildTerritory" || Data.TaskAll[_TaskNum].MapName == "DeadCity")
				{
					CharacterMotion.taskIcon.SetActive(true);
					CharacterMotion.taskIcon.transform.position = GameObject.Find("Путь к дикой территории").transform.position;
					CharacterMotion.arrow.SetActive(true);
				}
				if (Data.TaskAll[_TaskNum].MapName == "DarkValley")
				{
					CharacterMotion.taskIcon.SetActive(true);
					CharacterMotion.taskIcon.transform.position = GameObject.Find("Старая дорога").transform.position;
					CharacterMotion.arrow.SetActive(true);
				}
				if (Data.TaskAll[_TaskNum].MapName == "Military" || Data.TaskAll[_TaskNum].MapName == "Radar" || Data.TaskAll[_TaskNum].MapName == "RedForest" || Data.TaskAll[_TaskNum].MapName == "Backwater")
				{
					CharacterMotion.taskIcon.SetActive(true);
					CharacterMotion.taskIcon.transform.position = GameObject.Find("Дорога на военные склады").transform.position;
					CharacterMotion.arrow.SetActive(true);
				}
			}
			if (SceneManager.GetActiveScene().name == "Amber")
			{
				if (Data.TaskAll[_TaskNum].MapName == "Agroprom" || Data.TaskAll[_TaskNum].MapName == "Marsh")
				{
					CharacterMotion.taskIcon.SetActive(true);
					CharacterMotion.taskIcon.transform.position = GameObject.Find("Переход к НИИ Агропром").transform.position;
					CharacterMotion.arrow.SetActive(true);
				}
				if (Data.TaskAll[_TaskNum].MapName == "Military" || Data.TaskAll[_TaskNum].MapName == "Radar" || Data.TaskAll[_TaskNum].MapName == "Backwater")
				{
					CharacterMotion.taskIcon.SetActive(true);
					CharacterMotion.taskIcon.transform.position = GameObject.Find("Проводник к военным складам").transform.position;
					CharacterMotion.arrow.SetActive(true);
				}
				if (Data.TaskAll[_TaskNum].MapName == "DeadCity" || Data.TaskAll[_TaskNum].MapName == "RedForest")
				{
					CharacterMotion.taskIcon.SetActive(true);
					CharacterMotion.taskIcon.transform.position = GameObject.Find("Тайная тропа в мертвый город").transform.position;
					CharacterMotion.arrow.SetActive(true);
				}
				if (Data.TaskAll[_TaskNum].MapName == "Bar" || Data.TaskAll[_TaskNum].MapName == "WildTerritory" || Data.TaskAll[_TaskNum].MapName == "DarkValley" || Data.TaskAll[_TaskNum].MapName == "Dump" || Data.TaskAll[_TaskNum].MapName == "Kordon")
				{
					CharacterMotion.taskIcon.SetActive(true);
					CharacterMotion.taskIcon.transform.position = GameObject.Find("Дорога через дикую территорию").transform.position;
					CharacterMotion.arrow.SetActive(true);
				}
			}
			if (SceneManager.GetActiveScene().name == "WildTerritory")
			{
				if (Data.TaskAll[_TaskNum].MapName == "Amber" || Data.TaskAll[_TaskNum].MapName == "Agroprom" || Data.TaskAll[_TaskNum].MapName == "Marsh")
				{
					CharacterMotion.taskIcon.SetActive(true);
					CharacterMotion.taskIcon.transform.position = GameObject.Find("Дорога к озеру").transform.position;
					CharacterMotion.arrow.SetActive(true);
				}
				if (Data.TaskAll[_TaskNum].MapName == "Military" || Data.TaskAll[_TaskNum].MapName == "Radar" || Data.TaskAll[_TaskNum].MapName == "Backwater")
				{
					CharacterMotion.taskIcon.SetActive(true);
					CharacterMotion.taskIcon.transform.position = GameObject.Find("Северный лагерь").transform.position;
					CharacterMotion.arrow.SetActive(true);
				}
				if (Data.TaskAll[_TaskNum].MapName == "DeadCity" || Data.TaskAll[_TaskNum].MapName == "RedForest")
				{
					CharacterMotion.taskIcon.SetActive(true);
					CharacterMotion.taskIcon.transform.position = GameObject.Find("Черная тропа").transform.position;
					CharacterMotion.arrow.SetActive(true);
				}
				if (Data.TaskAll[_TaskNum].MapName == "Bar" || Data.TaskAll[_TaskNum].MapName == "DarkValley" || Data.TaskAll[_TaskNum].MapName == "Dump" || Data.TaskAll[_TaskNum].MapName == "Kordon")
				{
					CharacterMotion.taskIcon.SetActive(true);
					CharacterMotion.taskIcon.transform.position = GameObject.Find("Дорога к Бару").transform.position;
					CharacterMotion.arrow.SetActive(true);
				}
			}
			if (SceneManager.GetActiveScene().name == "DeadCity")
			{
				if (Data.TaskAll[_TaskNum].MapName == "WildTerritory")
				{
					CharacterMotion.taskIcon.SetActive(true);
					CharacterMotion.taskIcon.transform.position = GameObject.Find("Переход к черной тропе").transform.position;
					CharacterMotion.arrow.SetActive(true);
				}
				if (Data.TaskAll[_TaskNum].MapName == "Bar" || Data.TaskAll[_TaskNum].MapName == "DarkValley" || Data.TaskAll[_TaskNum].MapName == "Dump" || Data.TaskAll[_TaskNum].MapName == "Kordon")
				{
					CharacterMotion.taskIcon.SetActive(true);
					CharacterMotion.taskIcon.transform.position = GameObject.Find("Переход к черной тропе").transform.position;
					CharacterMotion.arrow.SetActive(true);
				}
				if (Data.TaskAll[_TaskNum].MapName == "Amber" || Data.TaskAll[_TaskNum].MapName == "Agroprom" || Data.TaskAll[_TaskNum].MapName == "Marsh")
				{
					CharacterMotion.taskIcon.SetActive(true);
					CharacterMotion.taskIcon.transform.position = GameObject.Find("Путь на Янтарь").transform.position;
					CharacterMotion.arrow.SetActive(true);
				}
				if (Data.TaskAll[_TaskNum].MapName == "Military" || Data.TaskAll[_TaskNum].MapName == "Radar" || Data.TaskAll[_TaskNum].MapName == "Backwater")
				{
					CharacterMotion.taskIcon.SetActive(true);
					CharacterMotion.taskIcon.transform.position = GameObject.Find("Путь на военные склады").transform.position;
					CharacterMotion.arrow.SetActive(true);
				}
				if (Data.TaskAll[_TaskNum].MapName == "RedForest")
				{
					CharacterMotion.taskIcon.SetActive(true);
					CharacterMotion.taskIcon.transform.position = GameObject.Find("Мертвый хутор").transform.position;
					CharacterMotion.arrow.SetActive(true);
				}
			}
			if (SceneManager.GetActiveScene().name == "Military")
			{
				if (Data.TaskAll[_TaskNum].MapName == "WildTerritory")
				{
					CharacterMotion.taskIcon.SetActive(true);
					CharacterMotion.taskIcon.transform.position = GameObject.Find("Дорога между холмами").transform.position;
					CharacterMotion.arrow.SetActive(true);
				}
				if (Data.TaskAll[_TaskNum].MapName == "Bar" || Data.TaskAll[_TaskNum].MapName == "DarkValley" || Data.TaskAll[_TaskNum].MapName == "Dump" || Data.TaskAll[_TaskNum].MapName == "Kordon" || Data.TaskAll[_TaskNum].MapName == "Marsh")
				{
					CharacterMotion.taskIcon.SetActive(true);
					CharacterMotion.taskIcon.transform.position = GameObject.Find("Дорога между холмами").transform.position;
					CharacterMotion.arrow.SetActive(true);
				}
				if (Data.TaskAll[_TaskNum].MapName == "Amber")
				{
					CharacterMotion.taskIcon.SetActive(true);
					CharacterMotion.taskIcon.transform.position = GameObject.Find("Проводник к Янтарю").transform.position;
					CharacterMotion.arrow.SetActive(true);
				}
				if (Data.TaskAll[_TaskNum].MapName == "DeadCity" || Data.TaskAll[_TaskNum].MapName == "Agroprom")
				{
					CharacterMotion.taskIcon.SetActive(true);
					CharacterMotion.taskIcon.transform.position = GameObject.Find("Блокпост наемников").transform.position;
					CharacterMotion.arrow.SetActive(true);
				}
				if (Data.TaskAll[_TaskNum].MapName == "Radar" || Data.TaskAll[_TaskNum].MapName == "Backwater")
				{
					CharacterMotion.taskIcon.SetActive(true);
					CharacterMotion.taskIcon.transform.position = GameObject.Find("Барьер монолита").transform.position;
					CharacterMotion.arrow.SetActive(true);
				}
				if (Data.TaskAll[_TaskNum].MapName == "RedForest")
				{
					CharacterMotion.taskIcon.SetActive(true);
					CharacterMotion.taskIcon.transform.position = GameObject.Find("Тропа в рыжий лес").transform.position;
					CharacterMotion.arrow.SetActive(true);
				}
			}
			if (SceneManager.GetActiveScene().name == "RedForest")
			{
				if (Data.TaskAll[_TaskNum].MapName == "Military" || Data.TaskAll[_TaskNum].MapName == "Bar" || Data.TaskAll[_TaskNum].MapName == "DarkValley" || Data.TaskAll[_TaskNum].MapName == "Dump" || Data.TaskAll[_TaskNum].MapName == "Kordon")
				{
					CharacterMotion.taskIcon.SetActive(true);
					CharacterMotion.taskIcon.transform.position = GameObject.Find("Лихая тропа").transform.position;
					CharacterMotion.arrow.SetActive(true);
				}
				if (Data.TaskAll[_TaskNum].MapName == "Amber" || Data.TaskAll[_TaskNum].MapName == "WildTerritory" || Data.TaskAll[_TaskNum].MapName == "DeadCity" || Data.TaskAll[_TaskNum].MapName == "Agroprom" || Data.TaskAll[_TaskNum].MapName == "Marsh")
				{
					CharacterMotion.taskIcon.SetActive(true);
					CharacterMotion.taskIcon.transform.position = GameObject.Find("Казармы в шахте").transform.position;
					CharacterMotion.arrow.SetActive(true);
				}
				if (Data.TaskAll[_TaskNum].MapName == "Radar" || Data.TaskAll[_TaskNum].MapName == "Backwater")
				{
					CharacterMotion.taskIcon.SetActive(true);
					CharacterMotion.taskIcon.transform.position = GameObject.Find("Собачья стоянка").transform.position;
					CharacterMotion.arrow.SetActive(true);
				}
			}
			if (SceneManager.GetActiveScene().name == "Radar")
			{
				if (Data.TaskAll[_TaskNum].MapName == "Backwater")
				{
					CharacterMotion.taskIcon.SetActive(true);
					CharacterMotion.taskIcon.transform.position = GameObject.Find("Вход в подземный бункер").transform.position;
					CharacterMotion.arrow.SetActive(true);
				}
				if (Data.TaskAll[_TaskNum].MapName == "RedForest")
				{
					CharacterMotion.taskIcon.SetActive(true);
					CharacterMotion.taskIcon.transform.position = GameObject.Find("Мертвый лес").transform.position;
					CharacterMotion.arrow.SetActive(true);
				}
				if (Data.TaskAll[_TaskNum].MapName == "Amber" || Data.TaskAll[_TaskNum].MapName == "WildTerritory" || Data.TaskAll[_TaskNum].MapName == "DeadCity" || Data.TaskAll[_TaskNum].MapName == "Agroprom" || Data.TaskAll[_TaskNum].MapName == "Marsh" || Data.TaskAll[_TaskNum].MapName == "Military" || Data.TaskAll[_TaskNum].MapName == "Bar" || Data.TaskAll[_TaskNum].MapName == "DarkValley" || Data.TaskAll[_TaskNum].MapName == "Dump" || Data.TaskAll[_TaskNum].MapName == "Kordon")
				{
					CharacterMotion.taskIcon.SetActive(true);
					CharacterMotion.taskIcon.transform.position = GameObject.Find("Южный блокпост радара").transform.position;
					CharacterMotion.arrow.SetActive(true);
				}
			}
			if (CharacterMotion.arrow.activeSelf && num > 3f)
			{
				CharacterMotion.arrow.SetActive(true);
			}
			else
			{
				CharacterMotion.arrow.SetActive(false);
			}
		}
		float num2 = (CharacterMotion.taskIcon.transform.position.x + Data.CharacterD[CharacterMotion._curCharacter].CharUnits.transform.position.x) / 2f;
		float num3 = (CharacterMotion.taskIcon.transform.position.y + Data.CharacterD[CharacterMotion._curCharacter].CharUnits.transform.position.y) / 2f;
		num2 = (num2 + Data.CharacterD[CharacterMotion._curCharacter].CharUnits.transform.position.x) / 2f;
		num3 = (num3 + Data.CharacterD[CharacterMotion._curCharacter].CharUnits.transform.position.y) / 2f;
		CharacterMotion.arrow.transform.position = new Vector3(num2, num3, 0f);
		if (Data.CharacterD[CharacterMotion._curCharacter].CharUnits.transform.position.y > CharacterMotion.taskIcon.transform.position.y)
		{
			angleArrow = Vector3.Angle(CharacterMotion.taskIcon.transform.position - Data.CharacterD[CharacterMotion._curCharacter].CharUnits.transform.position, new Vector3(10f, 0f, 0f));
			CharacterMotion.arrow.transform.rotation = Quaternion.Euler(0f, 0f, 0f - angleArrow);
		}
		else
		{
			angleArrow = Vector3.Angle(CharacterMotion.taskIcon.transform.position - Data.CharacterD[CharacterMotion._curCharacter].CharUnits.transform.position, new Vector3(10f, 0f, 0f));
			CharacterMotion.arrow.transform.rotation = Quaternion.Euler(0f, 0f, angleArrow);
		}
	}

	public static void AAAAAAAAAAAAAAAAAAAAcj()
	{
		if (Data.Points[_CurrentPoint[0]].ControlInt != 0)
		{
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.Points[_CurrentPoint[0]].ControlInt, Data.CharacterD[CharacterMotion._curCharacter].TypeChInt]--;
			if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.Points[_CurrentPoint[0]].ControlInt, Data.CharacterD[CharacterMotion._curCharacter].TypeChInt] < 0)
			{
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.Points[_CurrentPoint[0]].ControlInt, Data.CharacterD[CharacterMotion._curCharacter].TypeChInt] = 0;
			}
			AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.CharacterD[CharacterMotion._curCharacter].TypeChInt, Data.Points[_CurrentPoint[0]].ControlInt]--;
			if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.CharacterD[CharacterMotion._curCharacter].TypeChInt, Data.Points[_CurrentPoint[0]].ControlInt] < 0)
			{
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.CharacterD[CharacterMotion._curCharacter].TypeChInt, Data.Points[_CurrentPoint[0]].ControlInt] = 0;
			}
			if (Data.CharacterD[CharacterMotion._curCharacter].ControlGamer)
			{
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.Points[_CurrentPoint[0]].ControlInt, 0]--;
				if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.Points[_CurrentPoint[0]].ControlInt, 0] < 0)
				{
					AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.Points[_CurrentPoint[0]].ControlInt, 0] = 0;
				}
				AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.Points[_CurrentPoint[0]].ControlInt]--;
				if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.Points[_CurrentPoint[0]].ControlInt] < 0)
				{
					AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.Points[_CurrentPoint[0]].ControlInt] = 0;
				}
				if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[0, Data.Points[_CurrentPoint[0]].ControlInt] > 0)
				{
					MessagePanel(Data.Dealers[Data.Points[_CurrentPoint[0]].ControlInt].NameGroup + ": ''" + Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name + "! Наши бойцы стали хуже к тебе относиться...''");
				}
				else
				{
					MessagePanel(Data.Dealers[Data.Points[_CurrentPoint[0]].ControlInt].NameGroup + ": ''" + Data.CharacterD[CharacterMotion._curCharacter].CharUnits.name + "! Наши люди атакуют тебя при первой возможности!''");
				}
			}
			MessagePanel("Ухудшились отношения группировок: " + Data.Dealers[Data.Points[_CurrentPoint[0]].ControlInt].NameGroup + " и " + Data.CharacterD[CharacterMotion._curCharacter].TypeChar);
		}
		ChangeCaracter.GroupOfCupture = Data.CharacterD[CharacterMotion._curCharacter].TypeChInt;
		MessagePanel("Группировка " + Data.Dealers[Data.CharacterD[CharacterMotion._curCharacter].TypeChInt].NameGroup + " захватила точку: " + Data.Points[_CurrentPoint[0]].namePoint);
		Data.Points[_CurrentPoint[0]].ControlInt = Data.CharacterD[CharacterMotion._curCharacter].TypeChInt;
		Data.Points[_CurrentPoint[0]].DealerInt = Data.CharacterD[CharacterMotion._curCharacter].TypeChInt;
		Data.Points[_CurrentPoint[0]].exchange = false;
		Data.Points[_CurrentPoint[0]].Repair = false;
		Methods.AAAAAAAAAAAAAAcn();
		if (Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 1)
		{
			Data.Points[_CurrentPoint[0]].pointControl = ConstructorPoints.PointControl.Одиночки;
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 2)
		{
			Data.Points[_CurrentPoint[0]].pointControl = ConstructorPoints.PointControl.Бандиты;
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 3)
		{
			Data.Points[_CurrentPoint[0]].pointControl = ConstructorPoints.PointControl.Военные;
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 4)
		{
			Data.Points[_CurrentPoint[0]].pointControl = ConstructorPoints.PointControl.Долг;
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 5)
		{
			Data.Points[_CurrentPoint[0]].pointControl = ConstructorPoints.PointControl.Наемники;
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 6)
		{
			Data.Points[_CurrentPoint[0]].pointControl = ConstructorPoints.PointControl.Свобода;
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 7)
		{
			Data.Points[_CurrentPoint[0]].pointControl = ConstructorPoints.PointControl.Чистое_небо;
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 8)
		{
			Data.Points[_CurrentPoint[0]].pointControl = ConstructorPoints.PointControl.Монолит;
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 9)
		{
			Data.Points[_CurrentPoint[0]].pointControl = ConstructorPoints.PointControl.Мутанты;
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 10)
		{
			Data.Points[_CurrentPoint[0]].pointControl = ConstructorPoints.PointControl.Зомби;
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 11)
		{
			Data.Points[_CurrentPoint[0]].pointControl = ConstructorPoints.PointControl.Ученые;
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].TypeChInt == 12)
		{
			Data.Points[_CurrentPoint[0]].pointControl = ConstructorPoints.PointControl.Ренегаты;
		}
	}

	public static void AAAAAAAAAAAAAAAAAAAby()
	{
		if (Data.CharacterD[CharacterMotion._curCharacter].Cash >= 4000 && !Data.Points[_CurrentPoint[0]].exchange)
		{
			Data.Points[_CurrentPoint[0]].exchange = true;
			Data.CharacterD[CharacterMotion._curCharacter].Cash -= 4000;
		}
		if (Data.CharacterD[CharacterMotion._curCharacter].Cash >= 5000 && !Data.Points[_CurrentPoint[0]].Repair)
		{
			Data.Points[_CurrentPoint[0]].Repair = true;
			Data.CharacterD[CharacterMotion._curCharacter].Cash -= 5000;
		}
	}

	public static void AAAAAAAAAAAAAAAAAAAbz()
	{
		CharacterMotion.EjectIsActive = true;
		EjectGameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Ejection"));
		EjectGameObject.name = "Ejection";
		EjectGameObject.transform.SetParent(GameObject.Find("Canvas").transform);
		EjectGameObject.transform.localPosition = new Vector3(-Screen.width / 2, (float)Screen.height / 2f);
		EjectGameObject.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width);
		EjectGameObject.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height);
		SoundBG = GameObject.Find("SoundBG").GetComponent<AudioSource>();
		SoundBG.clip = (AudioClip)Resources.Load("Sound/backMusic/EjectionTrack");
		SoundBG.Play();
	}

	public static void AAAAAAAAAAAAAAAAbw()
	{
		CharacterMotion.EjectIsActive = false;
		Object.Destroy(EjectGameObject);
		GameObject gameObject = GameObject.Find("Main Camera");
		gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
		SoundBG = GameObject.Find("SoundBG").GetComponent<AudioSource>();
		SoundBG.clip = (AudioClip)Resources.Load("Sound/backMusic/bg/amb17_r");
		SoundBG.Play();
		for (int i = 0; i < Data.Points.Count; i++)
		{
			if (Data.Points[i].pointTypes == ConstructorPoints.PointTypes.Anomaly)
			{
				Data.Points[i].Cache[0] = Data.Artefacts[Random.Range(0, Data.Artefacts.Count - 1)];
			}
		}
	}

	public static void MessagePanel(string TextMessage)
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
		gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = TextMessage;
	}

	public static void AAAAAAAAAAAAAAAAAAcx()
	{
		MessagePanel("Внимание! Всем, кто меня слышит! Приборы регистрируют сильнейшую аномальную активность. До выброса осталось очень мало времени. Срочно двигайтесь к ближайшей точке и оставайтесь там до окончания выброса. Тем, кто не может добраться до укрытия, срочно принять Анабиотик, если он конечно имеется...");
	}

	public static void AAAAAAAAAAAAAAAAAby()
	{
		MessagePanel("Выброс закончен. Всем, кто в живых остался, удачи!");
	}

	public static void AAAAAAAAAAAAAAAAAAAca()
	{
		CharacterMotion.PointInform = (GameObject)Object.Instantiate(Resources.Load("Prefabs/PointInformation"));
		CharacterMotion.PointInform.transform.SetParent(GameObject.Find("Canvas").transform);
		CharacterMotion.PointInform.transform.localPosition = new Vector2(Screen.height / 3, Screen.height / 6);
		CharacterMotion.PointInform.transform.GetChild(0).GetComponent<GridLayoutGroup>().cellSize = new Vector2(Screen.height / 3, Screen.height / 10);
		CharacterMotion.PointInform.transform.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 3);
		CharacterMotion.PanelInfChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/PointInfChild"));
		CharacterMotion.PanelInfChild.transform.SetParent(CharacterMotion.PointInform.transform.GetChild(0));
		CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().texture = _CompleteMove;
		CharacterMotion.PanelInfChild.GetComponentInChildren<GridLayoutGroup>().cellSize = new Vector2(_posY9, _posY9);
		CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 9);
		CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 9);
		CharacterMotion.NameChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/NameChild"));
		CharacterMotion.NameChild.transform.SetParent(CharacterMotion.PanelInfChild.transform.Find("RawImage").transform);
		CharacterMotion.NameChild.GetComponent<Text>().text = "Завершить ход";
		CharacterMotion.NameChild.transform.localPosition = new Vector2(Screen.height / 5, 0f);
		CharacterMotion.NameChild.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 6);
		CharacterMotion.NameChild.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 12);
	}

	public static void AAAAAAAAAAAAAAAAAbz()
	{
		for (int i = 0; i < Data.Points.Count; i++)
		{
			if (Data.Points[i].DealerInt != 0 && Data.Points[i].DealerInt != Data.CharacterD[0].TypeChInt)
			{
				Data.Points[i].exchange = true;
			}
		}
	}

	public static void AAAAAAAAAAAAAAAAbx()
	{
		bool flag = false;
		for (int i = 0; i < 20; i++)
		{
			if (Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].NameSubject == Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.CartridgeType)
			{
				flag = true;
				int num = Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.CartridgeInMagazineFull - Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Cartridge;
				if (num >= Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].Stack)
				{
					Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Cartridge = Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].Stack;
					Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i] = new AAAAAAAAAAAAAAAAAAbi();
				}
				else
				{
					Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Cartridge = Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.CartridgeInMagazineFull;
					Data.CharacterD[CharacterMotion._curCharacter].CharBackpack[i].Stack -= num;
				}
				CharacterMotion._PointsMove--;
				Data.CharacterD[CharacterMotion._curCharacter].CharUnits.GetComponent<AudioSource>().clip = Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.AudioReload;
				Data.CharacterD[CharacterMotion._curCharacter].CharUnits.GetComponent<AudioSource>().Play();
				break;
			}
		}
		if (!flag)
		{
			MessagePanel("Отсутствуют боеприпасы");
		}
	}

	public static void AAAAAAAAAAAAAAAAAAAAAci(Texture2D AAAAAAAAAAAAAAAAAca, string AAAAAAAAAAAAAAAbq)
	{
		SoundMenu.clip = (AudioClip)Resources.Load("Sound/pda/pda_tip");
		SoundMenu.Play();
		GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MessaegeTask"));
		gameObject.name = "MessaegeTask";
		gameObject.transform.SetParent(GameObject.Find("Canvas").transform);
		gameObject.transform.localPosition = new Vector3(0f, 0f);
		gameObject.transform.GetChild(1).transform.GetChild(0).GetComponent<RawImage>().texture = AAAAAAAAAAAAAAAAAca;
		gameObject.transform.GetChild(2).transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = AAAAAAAAAAAAAAAbq;
		gameObject.transform.GetChild(3).gameObject.SetActive(false);
		gameObject.transform.GetChild(4).gameObject.SetActive(false);
		gameObject.transform.GetChild(5).gameObject.SetActive(true);
		float num = Screen.width;
		num /= 1280f;
		gameObject.transform.localScale = new Vector3(num, num);
	}

	public static void AAAAAAAAAAAAAAcb()
	{
		AAAAAAAAAAAAAAAAAAAAAcf();
		GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/CharacterInformationPanel/CharacterInformationPanel"));
		gameObject.name = "CharacterInformationPanel";
		gameObject.transform.SetParent(GameObject.Find("Canvas").transform);
		gameObject.transform.localPosition = new Vector3(0f, 0f);
		foreach (AAAAAAAAAAAAAAAAf item in Data.CharacterD)
		{
			GameObject gameObject2 = Object.Instantiate(Resources.Load<GameObject>("Prefabs/CharacterInformationPanel/InformationCharacter"));
			gameObject2.transform.SetParent(gameObject.transform.GetChild(1).GetChild(0));
			gameObject2.transform.GetChild(0).GetComponent<RawImage>().texture = item.SuitChar.IconCharacter;
			if (!item.Life)
			{
				gameObject2.transform.GetChild(0).GetComponent<RawImage>().texture = item.SuitChar.IconCharacterDead;
			}
			gameObject2.transform.GetChild(1).GetComponent<RawImage>().texture = item.WeaponChar.TextureSubject;
			gameObject2.transform.GetChild(1).GetComponent<RawImage>().SetNativeSize();
			if (item.NameU != "Странник")
			{
				gameObject2.transform.GetChild(2).GetComponent<Text>().text = item.NameU + "\n";
			}
			if (item.NameU == "Странник")
			{
				gameObject2.transform.GetChild(2).GetComponent<Text>().text = PlayerPrefs.GetString("HeroName") + "\n";
			}
			Text component = gameObject2.transform.GetChild(2).GetComponent<Text>();
			component.text = component.text + "Опыт: " + item.Skill;
			gameObject2.transform.GetChild(3).GetComponent<Text>().text = "HP: " + item.CurHealth + "\n";
			Text component2 = gameObject2.transform.GetChild(3).GetComponent<Text>();
			string text = component2.text;
			component2.text = text + "Кровотечение: " + item.Bleeding + "\n";
			Text component3 = gameObject2.transform.GetChild(3).GetComponent<Text>();
			component3.text = component3.text + "Радиация: " + item.DiseaseXRay;
		}
		float num = Screen.width;
		num /= 1280f;
		gameObject.transform.localScale = new Vector3(num, num);
	}

	public static void RenameHero()
	{
		GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/RenameHero/RenameHero"));
		gameObject.name = "RenameHero";
		gameObject.transform.SetParent(GameObject.Find("Canvas").transform);
		gameObject.transform.localPosition = new Vector3(0f, 100f);
		if (PlayerPrefs.HasKey("HeroName"))
		{
			gameObject.transform.GetChild(0).GetComponent<InputField>().text = PlayerPrefs.GetString("HeroName");
		}
		else
		{
			gameObject.transform.GetChild(0).GetComponent<InputField>().text = "Странник";
		}
	}

	public static void AAAAAAAAAAAAAAAAAAAAck()
	{
		SoundMenu.clip = (AudioClip)Resources.Load("Sound/pda/pda_tip");
		SoundMenu.Play();
		TaskPanelGO = Object.Instantiate(Resources.Load<GameObject>("Prefabs/TaskPanel"));
		TaskPanelGO.name = "TaskPanel";
		TaskPanelGO.transform.SetParent(GameObject.Find("Canvas").transform);
		TaskPanelGO.transform.localPosition = new Vector3(0f, 0f);
		int num = 0;
		foreach (ConstructorTasks item in Data.TaskAll)
		{
			GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/TaskPanelInem"));
			gameObject.name = num.ToString();
			num++;
			gameObject.transform.SetParent(TaskPanelGO.transform.GetChild(2).transform.GetChild(0));
			if (item.ImageTask != null)
			{
				gameObject.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<RawImage>().texture = item.ImageTask;
				gameObject.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
				if (gameObject.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<RectTransform>().rect.height < 50f)
				{
					gameObject.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.localScale = new Vector3(gameObject.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.localScale.x * 1.5f, gameObject.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.localScale.y * 1.5f);
				}
			}
			gameObject.transform.GetChild(1).GetComponent<Text>().text = item.NameTask;
			gameObject.transform.GetChild(1).GetComponent<Text>().color = new Color(0.6f, 0.6f, 0.6f, 0.8f);
			gameObject.transform.GetChild(2).GetComponent<Text>().text = item.DescriptionTask;
			gameObject.transform.GetChild(2).GetComponent<Text>().color = new Color(0.6f, 0.6f, 0.6f, 0.8f);
			if (item.BalansQuest)
			{
				Text component = gameObject.transform.GetChild(2).GetComponent<Text>();
				component.text = component.text + item.GroupName + ". Район: " + item.NamePointTask;
			}
			if (item.SubjectQuest)
			{
				if (item.QuestSubject.NameSubject != "None")
				{
					Text component2 = gameObject.transform.GetChild(2).GetComponent<Text>();
					component2.text = component2.text + ": " + item.QuestSubject.NameSubject + ".";
				}
				Text component3 = gameObject.transform.GetChild(2).GetComponent<Text>();
				component3.text = component3.text + " Заказчик на точке: " + item.NamePointTask + ".";
			}
			if (item.KillQuest)
			{
				Text component4 = gameObject.transform.GetChild(2).GetComponent<Text>();
				component4.text = component4.text + " Цель: " + item.KillCharacterName;
			}
			if (item.GuideQuest)
			{
				Text component5 = gameObject.transform.GetChild(2).GetComponent<Text>();
				string text = component5.text;
				component5.text = text + " Заказчик: " + item.KillCharacterName + ". Цель: " + item.NamePointTask;
			}
			if (item.CaptureQuest)
			{
				Text component6 = gameObject.transform.GetChild(2).GetComponent<Text>();
				component6.text = component6.text + item.NamePointTask + ". Заказчик: " + item.GroupName;
			}
		}
		CurTaskIcon = Object.Instantiate(Resources.Load<GameObject>("Prefabs/CurTaskIcon"));
		CurTaskIcon.name = "CurTaskIcon";
		CurTaskIcon.transform.SetParent(TaskPanelGO.transform.GetChild(2).transform.GetChild(0).transform.GetChild(_TaskNum).transform.GetChild(3).transform);
		CurTaskIcon.transform.localPosition = new Vector3(0f, 0f);
		CurTaskIcon.transform.parent.transform.parent.transform.GetChild(1).GetComponent<Text>().color = new Color(0.3f, 0.7f, 0.3f, 1f);
		CurTaskIcon.transform.parent.transform.parent.transform.GetChild(2).GetComponent<Text>().color = new Color(0.3f, 0.7f, 0.3f, 1f);
		float num2 = Screen.width;
		num2 /= 1024f;
		TaskPanelGO.transform.localScale = new Vector3(num2, num2);
	}

	public static void AAAAAAAAAAAAAAAAAAAcb()
	{
		SoundMenu.clip = (AudioClip)Resources.Load("Sound/pda/pda_tip");
		SoundMenu.Play();
		TaskPanelGO = Object.Instantiate(Resources.Load<GameObject>("Prefabs/TaskPanel"));
		TaskPanelGO.name = "TaskPanel";
		TaskPanelGO.transform.SetParent(GameObject.Find("Canvas").transform);
		TaskPanelGO.transform.localPosition = new Vector3(0f, 0f);
		TaskPanelGO.transform.GetChild(1).GetComponent<Text>().text = "Работа:";
		int num = 0;
		foreach (ConstructorTasks item in Data.TaskCurrentCharacter)
		{
			GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/TaskPanelInem"));
			gameObject.name = num.ToString();
			num++;
			gameObject.transform.SetParent(TaskPanelGO.transform.GetChild(2).transform.GetChild(0));
			if (item.ImageTask != null)
			{
				gameObject.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<RawImage>().texture = item.ImageTask;
				gameObject.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<RawImage>().SetNativeSize();
				if (gameObject.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<RectTransform>().rect.height < 50f)
				{
					gameObject.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.localScale = new Vector3(gameObject.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.localScale.x * 1.4f, gameObject.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.localScale.y * 1.45f);
				}
			}
			gameObject.transform.GetChild(1).GetComponent<Text>().text = item.NameTask;
			gameObject.transform.GetChild(1).GetComponent<Text>().color = new Color(0.6f, 0.6f, 0.6f, 0.8f);
			gameObject.transform.GetChild(2).GetComponent<Text>().text = item.DescriptionTask;
			gameObject.transform.GetChild(2).GetComponent<Text>().color = new Color(0.6f, 0.6f, 0.6f, 0.8f);
			if (item.BalansQuest)
			{
				Text component = gameObject.transform.GetChild(2).GetComponent<Text>();
				component.text = component.text + item.GroupName + ". Район: " + item.NamePointTask;
			}
			if (item.SubjectQuest)
			{
				if (item.QuestSubject.NameSubject != "None")
				{
					Text component2 = gameObject.transform.GetChild(2).GetComponent<Text>();
					component2.text = component2.text + ": " + item.QuestSubject.NameSubject + ".";
				}
				Text component3 = gameObject.transform.GetChild(2).GetComponent<Text>();
				component3.text = component3.text + " Заказчик на точке: " + item.NamePointTask + ".";
			}
			if (item.KillQuest)
			{
				Text component4 = gameObject.transform.GetChild(2).GetComponent<Text>();
				component4.text = component4.text + " Цель: " + item.KillCharacterName;
			}
			if (item.GuideQuest)
			{
				Text component5 = gameObject.transform.GetChild(2).GetComponent<Text>();
				string text = component5.text;
				component5.text = text + " Заказчик: " + item.KillCharacterName + ". Цель: " + item.NamePointTask;
			}
			if (item.CaptureQuest)
			{
				Text component6 = gameObject.transform.GetChild(2).GetComponent<Text>();
				component6.text = component6.text + item.NamePointTask + ". Заказчик: " + item.GroupName;
			}
		}
		CurTaskIcon = Object.Instantiate(Resources.Load<GameObject>("Prefabs/CurTaskIcon"));
		CurTaskIcon.name = "CurTaskIcon";
		CurTaskIcon.transform.SetParent(TaskPanelGO.transform.GetChild(2).transform.GetChild(0).transform.GetChild(_NewTaskNum).transform.GetChild(3).transform);
		CurTaskIcon.transform.localPosition = new Vector3(0f, 0f);
		CurTaskIcon.transform.parent.transform.parent.transform.GetChild(1).GetComponent<Text>().color = new Color(0.3f, 0.7f, 0.3f, 1f);
		CurTaskIcon.transform.parent.transform.parent.transform.GetChild(2).GetComponent<Text>().color = new Color(0.3f, 0.7f, 0.3f, 1f);
		if (CurTaskIcon.transform.parent.transform.parent.transform.GetChild(1).GetComponent<Text>().text == "Работы пока нет")
		{
			CurTaskIcon.transform.parent.transform.parent.transform.GetChild(3).gameObject.SetActive(false);
		}
		float num2 = Screen.width;
		num2 /= 1000f;
		TaskPanelGO.transform.localScale = new Vector3(num2, num2);
	}

	public static void AAAAAAAAAAAAAAAAby()
	{
		AAAAAAAAAAAAAAAAAAAAAcf();
		GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/PDA/PDApanel"));
		gameObject.name = "PDApanel";
		gameObject.transform.SetParent(GameObject.Find("Canvas").transform);
		gameObject.transform.localPosition = new Vector3(0f, 0f);
		if (SceneManager.GetActiveScene().name == "Kordon" || SceneManager.GetActiveScene().name == "Marsh")
		{
			gameObject.transform.GetChild(0).GetChild(0).localPosition = new Vector3(357f, 1536f);
		}
		if (SceneManager.GetActiveScene().name == "Dump" || SceneManager.GetActiveScene().name == "Agroprom")
		{
			gameObject.transform.GetChild(0).GetChild(0).localPosition = new Vector3(300f, 983f);
		}
		if (SceneManager.GetActiveScene().name == "DarkValley")
		{
			gameObject.transform.GetChild(0).GetChild(0).localPosition = new Vector3(-331f, 835f);
		}
		if (SceneManager.GetActiveScene().name == "Amber" || SceneManager.GetActiveScene().name == "Bar" || SceneManager.GetActiveScene().name == "WildTerritory")
		{
			gameObject.transform.GetChild(0).GetChild(0).localPosition = new Vector3(346f, 448f);
		}
		if (SceneManager.GetActiveScene().name == "DeadCity" || SceneManager.GetActiveScene().name == "Military")
		{
			gameObject.transform.GetChild(0).GetChild(0).localPosition = new Vector3(355f, 146f);
		}
		if (SceneManager.GetActiveScene().name == "RedForest" || SceneManager.GetActiveScene().name == "Radar")
		{
			gameObject.transform.GetChild(0).GetChild(0).localPosition = new Vector3(42f, -186f);
		}
		if (SceneManager.GetActiveScene().name == "Backwater")
		{
			gameObject.transform.GetChild(0).GetChild(0).localPosition = new Vector3(-200f, -1220f);
		}
		float num = Screen.width;
		num /= 1280f;
		gameObject.transform.localScale = new Vector3(num, num);
	}

	public static void AAAAAAAAAAAAAAAAAAAcc(Texture2D AAAAAAAAAAAAAAAbr, string AAAAAAAAAAAAAAAAAAAAAcj)
	{
		GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/InstantMessage/ItamMessage"));
		gameObject.transform.SetParent(InstantMessage.transform);
		gameObject.transform.localScale = new Vector3(1f, 1f);
		gameObject.transform.GetChild(0).GetComponent<RawImage>().texture = AAAAAAAAAAAAAAAbr;
		gameObject.transform.GetChild(1).GetComponent<Text>().text = AAAAAAAAAAAAAAAAAAAAAcj;
	}

	public static void AAAAAAAAAAAAAAAAAAcy(string AAAAAAAAAAAAAAAAAAAAcl)
	{
		string aAAAAAAAAAAAAAAAAAAAAcj = string.Empty;
		if (AAAAAAAAAAAAAAAAAAAAcl == "Save")
		{
			aAAAAAAAAAAAAAAAAAAAAcj = "Сохранено в слот: 1";
		}
		if (AAAAAAAAAAAAAAAAAAAAcl == "Save1")
		{
			aAAAAAAAAAAAAAAAAAAAAcj = "Сохранено в слот: 2";
		}
		if (AAAAAAAAAAAAAAAAAAAAcl == "Save2")
		{
			aAAAAAAAAAAAAAAAAAAAAcj = "Сохранено в слот: 3";
		}
		if (AAAAAAAAAAAAAAAAAAAAcl == "Save3")
		{
			aAAAAAAAAAAAAAAAAAAAAcj = "Сохранено в слот: 4";
		}
		if (AAAAAAAAAAAAAAAAAAAAcl == "AutoSave")
		{
			aAAAAAAAAAAAAAAAAAAAAcj = "Автосохранение";
		}
		if (AAAAAAAAAAAAAAAAAAAAcl == "CloudSave")
		{
			aAAAAAAAAAAAAAAAAAAAAcj = "Сохранено в облако";
		}
		AAAAAAAAAAAAAAAAAAAcc((Texture2D)Resources.Load("Sprites/IconGUI/saveW"), aAAAAAAAAAAAAAAAAAAAAcj);
	}
}
