using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMotion : MonoBehaviour
{
	public static bool CApanel;

	public static bool ItemGG;

	public static bool NPSPanel;

	public static bool DealerPanel;

	public static bool CachePanel;

	public static bool RepairPanel;

	public static bool RewardPanel;

	public static int SlotEquipment;

	private static int AAAAAAAAAAAAAAAAAAAv = 5;

	public static AAAAAAAAAAAAAAAAAAk SlotSubject;

	public static int _curCharacter = 0;

	public static int _DistansMove = 0;

	public static string _TurgetGexName;

	public static GameObject _Turget;

	public static GameObject _CameraCM;

	public static GameObject _Blood;

	public static GameObject GexX;

	public static GameObject TurgetWhite;

	public static List<GameObject> TargetsList = new List<GameObject>();

	public static GameObject PointInform;

	public static GameObject NameChild;

	public static GameObject PanelInfChild;

	public static GameObject BGofPointAndChar;

	public static GameObject ActPointAndChar;

	public static ConstructorGex _CurGex;

	public static List<ConstructorGex> _NextGex;

	public static ConstructorGex[] GexNears = new ConstructorGex[6];

	public static ConstructorGex _TurGex;

	public static GameObject taskIcon;

	public static GameObject arrow;

	public static float aColorTaskIcon;

	public static float aColorArrow = 0.2f;

	public static bool boolForAColor;

	public static bool boolForAColorArrow;

	public static Vector3 posSwipe0;

	public static Vector3 posSwipe1;

	public static Vector3 posSwipe2;

	private static Vector3 AAAAAAAAAAAAAAAAAAAAh;

	public static bool swipe;

	public static bool MoveInPoint;

	public static Vector3 PositionCurChar;

	public static bool[] SortInPoint;

	public static float coefficientScreen = Screen.width / 288;

	public static float coefficientSpeedSwipe = 0.17f;

	public static bool zoom;

	public static bool EjectIsActive;

	private Vector2 AAAAAAAAAAAAAAAAAm;

	private Vector2 AAAAAAAAAAAAAAAAAAAAAn;

	public static float dir;

	public static int _PointsMove
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAv;
		}
		set
		{
			if (value <= 7)
			{
				AAAAAAAAAAAAAAAAAAAv = value;
			}
			if (value > 7)
			{
				AAAAAAAAAAAAAAAAAAAv = 7;
			}
		}
	}

	public static Vector3 VectorOfSwipe
	{
		get
		{
			return AAAAAAAAAAAAAAAAAAAAh;
		}
		set
		{
			if (value.x <= 11f && value.x >= -11f)
			{
				AAAAAAAAAAAAAAAAAAAAh.x = value.x;
			}
			if (value.x > 11f)
			{
				AAAAAAAAAAAAAAAAAAAAh.x = 11f;
			}
			if (value.x < -11f)
			{
				AAAAAAAAAAAAAAAAAAAAh.x = -11f;
			}
			if (value.y <= 13f && value.x >= -13f)
			{
				AAAAAAAAAAAAAAAAAAAAh.y = value.y;
			}
			if (value.y > 13f)
			{
				AAAAAAAAAAAAAAAAAAAAh.y = 13f;
			}
			if (value.y < -13f)
			{
				AAAAAAAAAAAAAAAAAAAAh.y = -13f;
			}
		}
	}

	private void Start()
	{
		_NextGex = new List<ConstructorGex>();
		_CameraCM = GameObject.Find("CameraChar");
		_Turget = GameObject.Find("Turget");
		_TurGex = Data.CharacterD[_curCharacter].CurGexChar;
		_TurgetGexName = Data.CharacterD[_curCharacter].CurGexChar.NameGex;
		_Turget.transform.position = Data.CharacterD[_curCharacter].CurGexChar.GexGO.transform.position;
		taskIcon = Object.Instantiate(Resources.Load<GameObject>("Prefabs/TaskTurget"));
		taskIcon.name = "TaskTurget";
		taskIcon.GetComponent<SpriteRenderer>().color = new Color(0.9f, 0.75f, 0.5f, aColorTaskIcon);
		arrow = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Arrow"));
		arrow.name = "Arrow";
		arrow.GetComponent<SpriteRenderer>().color = new Color(0.9f, 0.75f, 0.5f, aColorTaskIcon);
		posSwipe0 = Data.CharacterD[_curCharacter].CharUnits.transform.position;
		posSwipe1 = Data.CharacterD[_curCharacter].CharUnits.transform.position;
		posSwipe2 = Data.CharacterD[_curCharacter].CharUnits.transform.position;
		_CameraCM.transform.position = Data.CharacterD[_curCharacter].CharUnits.transform.position;
		VectorOfSwipe = Data.CharacterD[_curCharacter].CharUnits.transform.position;
		GexX = (GameObject)Object.Instantiate(Resources.Load("Prefabs/GexXXX"));
		GexX.transform.SetParent(GameObject.Find("Backgrownd").transform);
		GexX.SetActive(false);
		PointInform = (GameObject)Object.Instantiate(Resources.Load("Prefabs/PointInformation"));
		PointInform.transform.SetParent(GameObject.Find("Canvas").transform);
		PointInform.transform.GetChild(0).GetComponent<GridLayoutGroup>().cellSize = new Vector2(Screen.height / 4 - 6, Screen.height / 4);
		PointInform.transform.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 4);
		PointInform.transform.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 4);
	}

	private void Update()
	{
		if (Input.touchCount < 2)
		{
			AAAAAAAAAAAAAAAAAm = Vector2.zero;
			AAAAAAAAAAAAAAAAAAAAAn = Vector2.zero;
			zoom = false;
		}
		if (Input.touchCount >= 2)
		{
			zoom = true;
			AAAAAAAAAAAAAAAAAAAw();
		}
		if (!boolForAColor)
		{
			aColorTaskIcon += 0.25f;
			if (aColorTaskIcon >= 1f)
			{
				boolForAColor = true;
			}
		}
		if (boolForAColor)
		{
			aColorTaskIcon -= 0.01f;
			if (aColorTaskIcon <= 0f)
			{
				boolForAColor = false;
			}
		}
		if (!boolForAColorArrow)
		{
			aColorArrow += 0.25f;
			if (aColorArrow >= 1f)
			{
				boolForAColorArrow = true;
			}
		}
		if (boolForAColorArrow)
		{
			aColorArrow -= 0.01f;
			if (aColorArrow <= 0f)
			{
				boolForAColorArrow = false;
			}
		}
		taskIcon.GetComponent<SpriteRenderer>().color = new Color(0.9f, 0.75f, 0.5f, aColorArrow);
		arrow.GetComponent<SpriteRenderer>().color = new Color(0.9f, 0.75f, 0.5f, aColorTaskIcon);
		if (Inventory._GGActive)
		{
			if (PointInform != null)
			{
				PointInform.SetActive(false);
			}
			if (_PointsMove > 0)
			{
				Data.CharacterD[_curCharacter].CharUnits.transform.position = Vector3.MoveTowards(Data.CharacterD[_curCharacter].CharUnits.transform.position, _NextGex[_NextGex.Count - 2].GexGO.transform.position, Time.deltaTime * AAAAAAAAAAAAAAAAAAAAct.GameSpeed);
				if (Data.CharacterD[_curCharacter].CharUnits.transform.position == _NextGex[_NextGex.Count - 2].GexGO.transform.position)
				{
					if (!EjectIsActive)
					{
						_PointsMove--;
						if (_PointsMove == 0 || _PointsMove == 4)
						{
							Data.CharacterD[_curCharacter].CharUnits.GetComponent<AudioSource>().clip = Data.CharacterD[_curCharacter].AudioStep_L;
							Data.CharacterD[_curCharacter].CharUnits.GetComponent<AudioSource>().Play();
						}
						if (_PointsMove == 2 || _PointsMove == 6)
						{
							Inventory.SoundMenu.clip = Data.CharacterD[_curCharacter].AudioStep_R;
							Inventory.SoundMenu.Play();
						}
						GameObject gexGO = _NextGex[_NextGex.Count - 1].GexGO;
						gexGO.GetComponent<SpriteRenderer>().color = new Color(0.45f, 0.45f, 0.25f, 0f);
						if (gexGO.transform.childCount > 0)
						{
							Object.Destroy(gexGO.transform.GetChild(0).gameObject);
						}
						_NextGex.Remove(_NextGex[_NextGex.Count - 1]);
						Data.CharacterD[_curCharacter].CurGexChar = _NextGex[_NextGex.Count - 1];
						AAAAAAAAAAAAAAAAAAAAi();
					}
					if (EjectIsActive)
					{
						_PointsMove--;
						if (_PointsMove == 0)
						{
							Data.CharacterD[_curCharacter].CharUnits.GetComponent<AudioSource>().clip = Data.CharacterD[_curCharacter].AudioPain_L;
							Data.CharacterD[_curCharacter].CharUnits.GetComponent<AudioSource>().Play();
						}
						if (_PointsMove == 4)
						{
							Data.CharacterD[_curCharacter].CharUnits.GetComponent<AudioSource>().clip = Data.CharacterD[_curCharacter].AudioPain_R;
							Data.CharacterD[_curCharacter].CharUnits.GetComponent<AudioSource>().Play();
						}
						if (_PointsMove == 2 || _PointsMove == 6)
						{
							Inventory.SoundMenu.clip = Data.CharacterD[_curCharacter].AudioStep_R;
							Inventory.SoundMenu.Play();
						}
						GameObject gexGO2 = _NextGex[_NextGex.Count - 1].GexGO;
						gexGO2.GetComponent<SpriteRenderer>().color = new Color(0.45f, 0.45f, 0.25f, 0f);
						if (gexGO2.transform.childCount > 0)
						{
							Object.Destroy(gexGO2.transform.GetChild(0).gameObject);
						}
						_NextGex.Remove(_NextGex[_NextGex.Count - 1]);
						Data.CharacterD[_curCharacter].CurGexChar = _NextGex[_NextGex.Count - 1];
						Data.CharacterD[_curCharacter].CurHealth -= 4f;
						AAAAAAAAAAAAAAAAAAAAi();
						if (Data.CharacterD[_curCharacter].CurHealth <= 0.5f)
						{
							Inventory._GGActive = false;
							if (_curCharacter == 0)
							{
								GameObject.Find("Data").GetComponent<Inventory>().AAAAAAAAAAAAAAby();
							}
							if (_curCharacter != 0)
							{
								GameObject.Find("Data").GetComponent<Inventory>().AAAAAAAAAAAAAAAAAAcg();
							}
						}
					}
					if (Inventory._CurrentPoint.Count > 0 && Data.Points[Inventory._CurrentPoint[0]].XRay > 0)
					{
						int num = 0;
						num += Data.Points[Inventory._CurrentPoint[0]].XRay;
						for (int i = 0; i < 4; i++)
						{
							num -= Data.CharacterD[_curCharacter].ArtContainers[i].XRayProtection;
						}
						num -= Data.CharacterD[_curCharacter].SuitChar.XRayProtection;
						if (num < 0)
						{
							num = 0;
						}
						Data.CharacterD[_curCharacter].DiseaseXRay += num;
					}
				}
			}
			if (Data.CharacterD[_curCharacter].CharUnits.transform.position == Data.CharacterD[_curCharacter].TaskGexChar.GexGO.transform.position || _PointsMove == 0 || Data.CharacterD[_curCharacter].CharUnits.transform.position == _Turget.transform.position)
			{
				Inventory._GGActive = false;
				_DistansMove = 0;
				AAAAAAAAAAAAAAAAAAAAi();
				Inventory.AAAAAAAAAAAAAAAAAAAAAce();
				Inventory.AAAAAAAAAAAAAAAAAbx();
				Methods.AAAAAAAAAAAAAAcn();
				Inventory.AAAAAAAAAAAAAAAAAAAbx();
				if (Inventory._CurrentCharUnit.Count > 0 && _DistansMove < Inventory._Range)
				{
					Inventory._fireButton = true;
				}
				else
				{
					Inventory._fireButton = false;
				}
				swipe = false;
				MoveInPoint = true;
				PositionCurChar = Data.CharacterD[_curCharacter].CharUnits.transform.position;
				SortInPoint = new bool[7];
				for (int j = 0; j < Inventory._CurrentCharUnit.Count; j++)
				{
					if (Data.CharacterD[Inventory._CurrentCharUnit[j]].CharUnits.transform.position == Data.CharacterD[_curCharacter].CharUnits.transform.position && Data.CharacterD[Inventory._CurrentCharUnit[j]].CharUnits.name != Data.CharacterD[_curCharacter].CharUnits.name)
					{
						SortInPoint[0] = true;
					}
					if (Data.CharacterD[Inventory._CurrentCharUnit[j]].CharUnits.transform.position == Data.CharacterD[_curCharacter].CharUnits.transform.position + new Vector3(-0.3f, 0.2f, 0f) && Data.CharacterD[Inventory._CurrentCharUnit[j]].CharUnits.name != Data.CharacterD[_curCharacter].CharUnits.name)
					{
						SortInPoint[1] = true;
					}
					if (Data.CharacterD[Inventory._CurrentCharUnit[j]].CharUnits.transform.position == Data.CharacterD[_curCharacter].CharUnits.transform.position + new Vector3(0.3f, 0.2f, 0f) && Data.CharacterD[Inventory._CurrentCharUnit[j]].CharUnits.name != Data.CharacterD[_curCharacter].CharUnits.name)
					{
						SortInPoint[2] = true;
					}
					if (Data.CharacterD[Inventory._CurrentCharUnit[j]].CharUnits.transform.position == Data.CharacterD[_curCharacter].CharUnits.transform.position + new Vector3(0.3f, -0.2f, 0f) && Data.CharacterD[Inventory._CurrentCharUnit[j]].CharUnits.name != Data.CharacterD[_curCharacter].CharUnits.name)
					{
						SortInPoint[3] = true;
					}
					if (Data.CharacterD[Inventory._CurrentCharUnit[j]].CharUnits.transform.position == Data.CharacterD[_curCharacter].CharUnits.transform.position + new Vector3(-0.3f, -0.2f, 0f) && Data.CharacterD[Inventory._CurrentCharUnit[j]].CharUnits.name != Data.CharacterD[_curCharacter].CharUnits.name)
					{
						SortInPoint[4] = true;
					}
					if (Data.CharacterD[Inventory._CurrentCharUnit[j]].CharUnits.transform.position == Data.CharacterD[_curCharacter].CharUnits.transform.position + new Vector3(0.3f, 0f, 0f) && Data.CharacterD[Inventory._CurrentCharUnit[j]].CharUnits.name != Data.CharacterD[_curCharacter].CharUnits.name)
					{
						SortInPoint[5] = true;
					}
					if (Data.CharacterD[Inventory._CurrentCharUnit[j]].CharUnits.transform.position == Data.CharacterD[_curCharacter].CharUnits.transform.position + new Vector3(-0.3f, 0f, 0f) && Data.CharacterD[Inventory._CurrentCharUnit[j]].CharUnits.name != Data.CharacterD[_curCharacter].CharUnits.name)
					{
						SortInPoint[6] = true;
					}
				}
				for (int k = 0; k < SortInPoint.Length; k++)
				{
					if (SortInPoint[k])
					{
						continue;
					}
					if (k == 0)
					{
						PositionCurChar = Data.CharacterD[_curCharacter].CharUnits.transform.position;
						break;
					}
					if (k == 1)
					{
						PositionCurChar = Data.CharacterD[_curCharacter].CharUnits.transform.position + new Vector3(-0.3f, 0.2f, 0f);
						break;
					}
					if (k == 2)
					{
						PositionCurChar = Data.CharacterD[_curCharacter].CharUnits.transform.position + new Vector3(0.3f, 0.2f, 0f);
						break;
					}
					if (k == 3)
					{
						PositionCurChar = Data.CharacterD[_curCharacter].CharUnits.transform.position + new Vector3(0.3f, -0.2f, 0f);
						break;
					}
					if (k == 4)
					{
						PositionCurChar = Data.CharacterD[_curCharacter].CharUnits.transform.position + new Vector3(-0.3f, -0.2f, 0f);
					}
					switch (k)
					{
					case 5:
						PositionCurChar = Data.CharacterD[_curCharacter].CharUnits.transform.position + new Vector3(0.3f, 0f, 0f);
						break;
					case 6:
						PositionCurChar = Data.CharacterD[_curCharacter].CharUnits.transform.position + new Vector3(-0.3f, 0f, 0f);
						break;
					}
					break;
				}
			}
		}
		if (MoveInPoint)
		{
			Data.CharacterD[_curCharacter].CharUnits.transform.position = Vector3.MoveTowards(Data.CharacterD[_curCharacter].CharUnits.transform.position, PositionCurChar, Time.deltaTime * AAAAAAAAAAAAAAAAAAAAct.GameSpeed);
			_CameraCM.transform.position = Data.CharacterD[_curCharacter].CharUnits.transform.position;
			if (Data.CharacterD[_curCharacter].CharUnits.transform.position == PositionCurChar)
			{
				MoveInPoint = false;
			}
		}
		if (Data.CharacterD[_curCharacter].ControlGamer)
		{
			if (!Inventory._GGActive)
			{
				if (swipe)
				{
					_CameraCM.transform.position = Vector3.MoveTowards(_CameraCM.transform.position, VectorOfSwipe, coefficientSpeedSwipe);
				}
				if (!swipe)
				{
					_CameraCM.transform.position = Vector3.MoveTowards(_CameraCM.transform.position, Data.CharacterD[_curCharacter].CharUnits.transform.position, coefficientSpeedSwipe);
				}
			}
			if (Inventory._GGActive)
			{
				_CameraCM.transform.position = Data.CharacterD[_curCharacter].CharUnits.transform.position;
			}
		}
		if (!Data.CharacterD[_curCharacter].ControlGamer)
		{
			if (!Data.CharacterD[_curCharacter].Life)
			{
			}
			if (EjectTimeSc.Ejection > 2 && Data.CharacterD[_curCharacter].Life && Vector3.Distance(Data.CharacterD[_curCharacter].CurGexChar.GexGO.transform.position, Data.CharacterD[0].CurGexChar.GexGO.transform.position) < 13f)
			{
				_CameraCM.transform.position = Data.CharacterD[_curCharacter].CharUnits.transform.position;
			}
			if (Inventory._GGActive)
			{
				_CameraCM.transform.position = Data.CharacterD[_curCharacter].CharUnits.transform.position;
			}
		}
	}

	public static void AAAAAAAAAAAAAAAAAAAAi()
	{
		Inventory._CurrentCharUnit.Clear();
		Inventory._CurrentPoint.Clear();
		for (int i = 0; i < Data.CharacterD.Count; i++)
		{
			if (Data.CharacterD[i].CurGexChar == Data.CharacterD[_curCharacter].CurGexChar)
			{
				Inventory._CurrentCharUnit.Add(i);
			}
		}
		for (int j = 0; j < Data.Points.Count; j++)
		{
			if (Data.Points[j].curGexPoint == Data.CharacterD[_curCharacter].CurGexChar)
			{
				Inventory._CurrentPoint.Add(j);
			}
		}
		if (Inventory._CurrentPoint.Count > 0 && Data.Points[Inventory._CurrentPoint[0]].XRay > 0)
		{
			Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/pda/xRay");
			Inventory.SoundMenu.Play();
		}
		if (Inventory._CurrentCharUnit.Count > 0)
		{
			if (Inventory._CurrentCharUnit[0] == 0)
			{
				if (Inventory._CurrentCharUnit.Count > 1)
				{
					Inventory._currentCharacterNumber = Inventory._CurrentCharUnit[1];
					Inventory._curNumb = 1;
				}
				if (Inventory._CurrentCharUnit.Count <= 1)
				{
					Inventory._currentCharacterNumber = Inventory._CurrentCharUnit[0];
					Inventory._curNumb = 0;
				}
			}
			else
			{
				Inventory._currentCharacterNumber = Inventory._CurrentCharUnit[0];
				Inventory._curNumb = 0;
			}
		}
		Inventory._CurtainIconCharacterU.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, (Inventory._CurrentCharUnit.Count + Inventory._CurrentPoint.Count) * Inventory._posY8);
	}

	public void AAAAAAAAAAAAAAAAAAAw()
	{
		if (AAAAAAAAAAAAAAAAAm == Vector2.zero && AAAAAAAAAAAAAAAAAAAAAn == Vector2.zero)
		{
			AAAAAAAAAAAAAAAAAm = Input.GetTouch(0).position;
			AAAAAAAAAAAAAAAAAAAAAn = Input.GetTouch(1).position;
		}
		Vector2 position = Input.GetTouch(0).position;
		Vector2 position2 = Input.GetTouch(1).position;
		dir = Mathf.Sign(Vector2.Distance(AAAAAAAAAAAAAAAAAAAAAn, AAAAAAAAAAAAAAAAAm) - Vector2.Distance(position, position2));
		_CameraCM.GetComponentInChildren<Camera>().orthographicSize += 0.1f * dir;
		if (_CameraCM.GetComponentInChildren<Camera>().orthographicSize > 7.5f)
		{
			_CameraCM.GetComponentInChildren<Camera>().orthographicSize = 7.5f;
		}
		if (_CameraCM.GetComponentInChildren<Camera>().orthographicSize < 4f)
		{
			_CameraCM.GetComponentInChildren<Camera>().orthographicSize = 4f;
		}
	}

	public static void AAAAAAAAAAAAAAAAAAAAAAj()
	{
		for (int i = 0; i < TargetsList.Count; i++)
		{
			Object.Destroy(TargetsList[i]);
		}
		TargetsList.Clear();
		_NextGex.Reverse();
		int num = Data.CharacterD[_curCharacter].WeaponChar.Range;
		if (Data.CharacterD[_curCharacter].WeaponChar.SightInstallation)
		{
			num++;
		}
		if (num < _NextGex.Count)
		{
			for (int j = 0; j < num + 1; j++)
			{
				TurgetWhite = (GameObject)Object.Instantiate(Resources.Load("Prefabs/TurgetWhite"));
				TurgetWhite.transform.SetParent(_NextGex[j].GexGO.transform);
				TurgetWhite.transform.localPosition = Vector3.zero;
				TargetsList.Add(TurgetWhite);
			}
		}
		if (num >= _NextGex.Count)
		{
			for (int k = 0; k < _NextGex.Count; k++)
			{
				TurgetWhite = (GameObject)Object.Instantiate(Resources.Load("Prefabs/TurgetWhite"));
				TurgetWhite.transform.SetParent(_NextGex[k].GexGO.transform);
				TurgetWhite.transform.localPosition = Vector3.zero;
				TargetsList.Add(TurgetWhite);
			}
		}
		_NextGex.Reverse();
	}
}
